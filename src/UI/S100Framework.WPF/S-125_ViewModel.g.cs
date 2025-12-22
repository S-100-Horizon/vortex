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
			"RangeSystem" => new RangeSystemViewModel { Name = name },
			"AtonAggregations" => new AtonAggregationsViewModel { Name = name },
			"AtonAssociations" => new AtonAssociationsViewModel { Name = name },
			"DangerousFeatureAssociation" => new DangerousFeatureAssociationViewModel { Name = name },
			"StructureEquipment" => new StructureEquipmentViewModel { Name = name },
			"PhysicalAIS" => new PhysicalAISViewModel { Name = name },
			"SyntheticAIS" => new SyntheticAISViewModel { Name = name },
			"VirtualAIS" => new VirtualAISViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"SpatialQuality" => new SpatialQualityViewModel { Name = name },
			"AtonStatusInformation" => new AtonStatusInformationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"NavigationLine" => new NavigationLineViewModel { Name = name },
			"RecommendedTrack" => new RecommendedTrackViewModel { Name = name },
			"Landmark" => new LandmarkViewModel { Name = name },
			"Daymark" => new DaymarkViewModel { Name = name },
			"FogSignal" => new FogSignalViewModel { Name = name },
			"RadarReflector" => new RadarReflectorViewModel { Name = name },
			"RadarTransponderBeacon" => new RadarTransponderBeaconViewModel { Name = name },
			"RadioStation" => new RadioStationViewModel { Name = name },
			"Retroreflector" => new RetroreflectorViewModel { Name = name },
			"LightAirObstruction" => new LightAirObstructionViewModel { Name = name },
			"LightAllAround" => new LightAllAroundViewModel { Name = name },
			"LightFogDetector" => new LightFogDetectorViewModel { Name = name },
			"LightSectored" => new LightSectoredViewModel { Name = name },
			"LightFloat" => new LightFloatViewModel { Name = name },
			"LightVessel" => new LightVesselViewModel { Name = name },
			"OffshorePlatform" => new OffshorePlatformViewModel { Name = name },
			"Pile" => new PileViewModel { Name = name },
			"SiloTank" => new SiloTankViewModel { Name = name },
			"CardinalBuoy" => new CardinalBuoyViewModel { Name = name },
			"EmergencyWreckMarkingBuoy" => new EmergencyWreckMarkingBuoyViewModel { Name = name },
			"InstallationBuoy" => new InstallationBuoyViewModel { Name = name },
			"IsolatedDangerBuoy" => new IsolatedDangerBuoyViewModel { Name = name },
			"LateralBuoy" => new LateralBuoyViewModel { Name = name },
			"MooringBuoy" => new MooringBuoyViewModel { Name = name },
			"SafeWaterBuoy" => new SafeWaterBuoyViewModel { Name = name },
			"SpecialPurposeGeneralBuoy" => new SpecialPurposeGeneralBuoyViewModel { Name = name },
			"CardinalBeacon" => new CardinalBeaconViewModel { Name = name },
			"IsolatedDangerBeacon" => new IsolatedDangerBeaconViewModel { Name = name },
			"SafeWaterBeacon" => new SafeWaterBeaconViewModel { Name = name },
			"SpecialPurposeGeneralBeacon" => new SpecialPurposeGeneralBeaconViewModel { Name = name },
			"LateralBeacon" => new LateralBeaconViewModel { Name = name },
			"WindTurbine" => new WindTurbineViewModel { Name = name },
			"VerticalDatumOfData" => new VerticalDatumOfDataViewModel { Name = name },
			"DataCoverage" => new DataCoverageViewModel { Name = name },
			"LocalDirectionOfBuoyage" => new LocalDirectionOfBuoyageViewModel { Name = name },
			"NavigationalSystemOfMarks" => new NavigationalSystemOfMarksViewModel { Name = name },
			"SoundingDatum" => new SoundingDatumViewModel { Name = name },
			"QualityOfBathymetricData" => new QualityOfBathymetricDataViewModel { Name = name },
			"DangerousFeature" => new DangerousFeatureViewModel { Name = name },
			"SyntheticAISAidToNavigation" => new SyntheticAISAidToNavigationViewModel { Name = name },
			"PhysicalAISAidToNavigation" => new PhysicalAISAidToNavigationViewModel { Name = name },
			"VirtualAISAidToNavigation" => new VirtualAISAidToNavigationViewModel { Name = name },
			"Topmark" => new TopmarkViewModel { Name = name },
			"AtonAggregation" => new AtonAggregationViewModel { Name = name },
			"AtonAssociation" => new AtonAssociationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("Atonstatus", "Statuspart") => ["AtonStatusInformation"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("AtonAggregations", "peerAtonAggregation") => ["AtonAggregation"],
			("AtonAssociations", "peerAtonAssociation") => ["AtonAssociation"],
			("RangeSystem", "navigableTrack") => ["RecommendedTrack"],
			("RangeSystem", "navigationLine") => ["NavigationLine"],
			("StructureEquipment", "parent") => ["StructureObject"],
			("StructureEquipment", "child") => ["Equipment"],
			("PhysicalAIS", "physicalAISbroadcastBy") => ["PhysicalAISAidToNavigation"],
			("SyntheticAIS", "syntheticAISbroadcastBy") => ["SyntheticAISAidToNavigation"],
			("VirtualAIS", "virtualAISbroadcastBy") => ["VirtualAISAidToNavigation"],
			("DangerousFeatureAssociation", "markingAton") => ["AtonAssociation"],
			("AtonAggregations", "atonAggregationBy") => ["AidsToNavigation"],
			("DangerousFeatureAssociation", "danger") => ["DangerousFeature"],
			("AtonAssociations", "atonAssociationBy") => ["AidsToNavigation"],
			("SyntheticAIS", "syntheticAISbroadcasts") => ["RadioStation"],
			("PhysicalAIS", "physicalAISbroadcasts") => ["RadioStation"],
			("VirtualAIS", "virtualAISbroadcasts") => ["RadioStation"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Specific information or description regarding modifications or updates made to an object, system, or dataset. This term typically includes the nature, scope, and reason for the change, as well as any impact it may have on operations or functionality.
	/// </summary>
	[Description("Specific information or description regarding modifications or updates made to an object, system, or dataset. This term typically includes the nature, scope, and reason for the change, as well as any impact it may have on operations or functionality.")]
	[CategoryOrder("changeDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class changeDetailsViewModel : ComplexViewModel<changeDetails> {
		private atonCommissioning? _atonCommissioning  = default;

		[Description("The process of deploying and activating a new Aid to Navigation (AtoN), ensuring that it is properly installed and operational.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("The process of decommissioning and physically removing an AtoN from its designated location, either temporarily or permanently.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27])]
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

		[Description("The act of swapping an existing AtoN with a new or upgraded unit, either due to maintenance needs or technological improvements.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("Modifications or updates to fixed AtoNs, such as lighthouses or beacons, which are permanently positioned.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("Adjustments or replacements related to floating AtoNs, such as buoys, which are anchored but can move with water currents.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("Any modification to an AtoN that uses sound signals, such as foghorns or bells, to assist in navigation under low visibility conditions.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("Updates or modifications to light-emitting AtoNs, including changing light characteristics, intensity, or operational status.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
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

		private electronicAtoNChange? _electronicAtoNChange  = default;

		[Description("Modifications to electronic or digital AtoNs, such as AIS (Automatic Identification System) AtoNs, virtual AtoNs, or remote-controlled systems.")]
		//[Editor(typeof(Editors.HorizonEditor<changeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30])]
		[Optional]
		public electronicAtoNChange? electronicAtoNChange {
			get {
				return _electronicAtoNChange;
			}
			set {
				SetValue(ref _electronicAtoNChange, value);
			}
		}

		public changeDetailsViewModel Load(changeDetails instance) {
			atonCommissioning = instance.atonCommissioning;
			atonRemoval = instance.atonRemoval;
			atonReplacement = instance.atonReplacement;
			fixedAtonChange = instance.fixedAtonChange;
			floatingAtonChange = instance.floatingAtonChange;
			audibleSignalAtonChange = instance.audibleSignalAtonChange;
			lightedAtonChange = instance.lightedAtonChange;
			electronicAtoNChange = instance.electronicAtoNChange;
			return this;
		}

		public override string Serialize() {
			var instance = new changeDetails {
				atonCommissioning = this.atonCommissioning,
				atonRemoval = this.atonRemoval,
				atonReplacement = this.atonReplacement,
				fixedAtonChange = this.fixedAtonChange,
				floatingAtonChange = this.floatingAtonChange,
				audibleSignalAtonChange = this.audibleSignalAtonChange,
				lightedAtonChange = this.lightedAtonChange,
				electronicAtoNChange = this.electronicAtoNChange,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public changeDetails Model => new () {
			atonCommissioning = this._atonCommissioning,
			atonRemoval = this._atonRemoval,
			atonReplacement = this._atonReplacement,
			fixedAtonChange = this._fixedAtonChange,
			floatingAtonChange = this._floatingAtonChange,
			audibleSignalAtonChange = this._audibleSignalAtonChange,
			lightedAtonChange = this._lightedAtonChange,
			electronicAtoNChange = this._electronicAtoNChange,
		};

		public override string? ToString() => $"Change Details";
	}


	/// <summary>
	/// A portion or sector of a navigational aid, such as a light or beacon, that is blocked or obscured from view due to obstacles (e.g., landforms, buildings, or other structures). In marine or aviation navigation, it usually refers to an area where the light signal or visibility is intentionally or unintentionally reduced or not visible to vessels or aircraft.
	/// </summary>
	[Description("A portion or sector of a navigational aid, such as a light or beacon, that is blocked or obscured from view due to obstacles (e.g., landforms, buildings, or other structures). In marine or aviation navigation, it usually refers to an area where the light signal or visibility is intentionally or unintentionally reduced or not visible to vessels or aircraft.")]
	[CategoryOrder("obscuredSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class obscuredSectorViewModel : ComplexViewModel<obscuredSector> {
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

		public obscuredSectorViewModel Load(obscuredSector instance) {
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
			var instance = new obscuredSector {
				sectorLimit = this.sectorLimit?.Model,
				sectorInformation = this.sectorInformation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public obscuredSector Model => new () {
			sectorLimit = this._sectorLimit?.Model,
			sectorInformation = this._sectorInformation?.Model,
		};

		public override string? ToString() => $"Obscured Sector";
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

		[Description("-")]
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

		[Description("-")]
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

		[Description("-")]
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

		[Description("-")]
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

		[Description("-")]
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
		private String _Language  = string.Empty;

		[Description("-")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String Language {
			get {
				return _Language;
			}
			set {
				SetValue(ref _Language, value);
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
			Language = instance.Language;
			name = instance.name;
			return this;
		}

		public override string Serialize() {
			var instance = new featureName {
				Language = this.Language,
				name = this.name,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public featureName Model => new () {
			Language = this._Language,
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

		private String _Language  = string.Empty;

		[Description("-")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String Language {
			get {
				return _Language;
			}
			set {
				SetValue(ref _Language, value);
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
			Language = instance.Language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new information {
				fileLocator = this.fileLocator,
				fileReference = this.fileReference,
				headline = this.headline,
				Language = this.Language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public information Model => new () {
			fileLocator = this._fileLocator,
			fileReference = this._fileReference,
			headline = this._headline,
			Language = this._Language,
			text = this._text,
		};

		public override string? ToString() => $"Information";
	}


	/// <summary>
	/// The number of features of identical character that exist as a co-located group.
	/// </summary>
	[Description("The number of features of identical character that exist as a co-located group.")]
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

		[Description("	An indication that the default radius of a sector arc is to be extended by 5mm.")]
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
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,25,26,27,28,29])]
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

		[Description("	The time occupied by an entire cycle of intervals of light and eclipse.")]
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

		[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.")]
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
		private String? _Language  = default;

		[Description("-")]
		//[Editor(typeof(Editors.HorizonEditor<sectorInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? Language {
			get {
				return _Language;
			}
			set {
				SetValue(ref _Language, value);
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
			Language = instance.Language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorInformation {
				Language = this.Language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorInformation Model => new () {
			Language = this._Language,
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
	/// The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.
	/// </summary>
	[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.")]
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

		private String? _Language  = default;

		[Description("-")]
		//[Editor(typeof(Editors.HorizonEditor<textualDescription>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? Language {
			get {
				return _Language;
			}
			set {
				SetValue(ref _Language, value);
			}
		}

		public textualDescriptionViewModel Load(textualDescription instance) {
			fileReference = instance.fileReference;
			Language = instance.Language;
			return this;
		}

		public override string Serialize() {
			var instance = new textualDescription {
				fileReference = this.fileReference,
				Language = this.Language,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public textualDescription Model => new () {
			fileReference = this._fileReference,
			Language = this._Language,
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
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("rhythmOfLight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rhythmOfLightViewModel : ComplexViewModel<rhythmOfLight> {
		private lightCharacteristic _lightCharacteristic  = default;

		[Description("The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.")]
		//[Editor(typeof(Editors.HorizonEditor<rhythmOfLight>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,25,26,27,28,29])]
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
		[Optional]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();

		private double? _signalPeriod  = default;

		[Description("	The time occupied by an entire cycle of intervals of light and eclipse.")]
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

		[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.")]
		[Optional]
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

		public override string? ToString() => $"Structure/Equipment";
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
	/// The indication of the quality of the locational information for features in a dataset.
	/// </summary>
	[Description("The indication of the quality of the locational information for features in a dataset.")]
	[CategoryOrder("SpatialQuality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
		private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement  = default;

		[Description("The reliability of the value of a sounding.")]
		[Category("SpatialQuality")]
		//[Editor(typeof(Editors.HorizonEditor<SpatialQuality>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
		[Optional]
		public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
			get {
				return _qualityOfVerticalMeasurement;
			}
			set {
				SetValue(ref _qualityOfVerticalMeasurement, value);
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
			qualityOfVerticalMeasurement = instance.qualityOfVerticalMeasurement;
			spatialAccuracy = new ();
			if (instance.spatialAccuracy != default) {
				spatialAccuracy.Load(instance.spatialAccuracy);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpatialQuality {
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement,
				spatialAccuracy = this.spatialAccuracy?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpatialQuality Model => new () {
			qualityOfVerticalMeasurement = this._qualityOfVerticalMeasurement,
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
	/// This refers to the current operational status or condition of an Aid to Navigation (AtoN). It provides details about whether the navigational aid (such as a buoy, light, or beacon) is functioning properly, temporarily out of service, under maintenance, or has any other status that affects its operation or visibility to mariners.
	/// </summary>
	[Description("This refers to the current operational status or condition of an Aid to Navigation (AtoN). It provides details about whether the navigational aid (such as a buoy, light, or beacon) is functioning properly, temporarily out of service, under maintenance, or has any other status that affects its operation or visibility to mariners.")]
	[CategoryOrder("AtonStatusInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonStatusInformationViewModel : InformationViewModel<AtonStatusInformation> {
		private changeDetailsViewModel _changeDetails  = default;

		[Description("Specific information or description regarding modifications or updates made to an object, system, or dataset. This term typically includes the nature, scope, and reason for the change, as well as any impact it may have on operations or functionality.")]
		[Category("AtonStatusInformation")]
		[ExpandableObject]
		[Mandatory]
		public changeDetailsViewModel changeDetails {
			get {
				return _changeDetails;
			}
			set {
				SetValue(ref _changeDetails, value);
			}
		}

		private changeTypes? _changeTypes  = default;

		[Description("Different categories or kinds of modifications that can be made to data, positions, or objects. For example, changes may involve updates to position, orientation, or attributes of an object.")]
		[Category("AtonStatusInformation")]
		//[Editor(typeof(Editors.HorizonEditor<AtonStatusInformation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public changeTypes? changeTypes {
			get {
				return _changeTypes;
			}
			set {
				SetValue(ref _changeTypes, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];

		public AtonStatusInformationViewModel Load(AtonStatusInformation instance) {
			changeDetails = new ();
			if (instance.changeDetails != default) {
				changeDetails.Load(instance.changeDetails);
			}
			changeTypes = instance.changeTypes;
			return this;
		}

		public override string Serialize() {
			var instance = new AtonStatusInformation {
				changeDetails = this.changeDetails?.Model,
				changeTypes = this.changeTypes,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonStatusInformation Model => new () {
			changeDetails = this._changeDetails?.Model,
			changeTypes = this._changeTypes,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtonStatusInformation.informationBindingDefinitions;

		public AtonStatusInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Aton Status Information";
	}



	/// <summary>
	/// A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.
	/// </summary>
	[Description("A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.")]
	[CategoryOrder("NavigationLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavigationLineViewModel : FeatureViewModel<NavigationLine> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

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

		[Description("The condition of an object at a given instant in time.")]
		[Category("NavigationLine")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("RangeSystem","navigableTrack",["RecommendedTrack"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> RangeSystems { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. RangeSystems.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.RangeSystem> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public NavigationLineViewModel Load(NavigationLine instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				categoryOfNavigationLine = this.categoryOfNavigationLine,
				orientation = this.orientation?.Model,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavigationLine Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			categoryOfNavigationLine = this._categoryOfNavigationLine,
			orientation = this._orientation?.Model,
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private Boolean _basedOnFixedMarks  = false;

		[Description("A straight route (known as a recommended track, range or leading line), which comprises: a. at least two structures (usually beacons or daymarks) and/or natural features, which may carry lights and/or top-marks. The structures/features are positioned so that when observed to be in line, a vessel can follow a known bearing with safety. (Adapted from International Association of Lighthouse Authorities - IALA Aids to Navigation Guide, 1990); or b. a single structure or natural feature, which may carry lights and/or a topmark, and a specified bearing which can be followed with safety. (S-57 Edition 3.1, Appendix A Chapter 2, Page 2.72, November 2000, as amended).")]
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

		[Description("The reliability of the value of a sounding.")]
		[Category("RecommendedTrack")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

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

		[Description("The condition of an object at a given instant in time.")]
		[Category("RecommendedTrack")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Description("Survey method used to obtain depth information.")]
		[Category("RecommendedTrack")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18])]
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


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("RangeSystem","navigationLine",["NavigationLine"], lower:1, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> RangeSystems { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. RangeSystems.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.RangeSystem> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public RecommendedTrackViewModel Load(RecommendedTrack instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// Any prominent object at a fixed location on land which can be used in determining a location or a direction.
	/// </summary>
	[Description("Any prominent object at a fixed location on land which can be used in determining a location or a direction.")]
	[CategoryOrder("Landmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LandmarkViewModel : FeatureViewModel<Landmark> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		[Description("A specific role that describes a feature.")]
		[Category("Landmark")]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50])]
		[Optional]
		public ObservableCollection<function> function  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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

		[Description("The building's primary construction material.")]
		[Category("Landmark")]
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LandmarkViewModel Load(Landmark instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
			function.Clear();
			if (instance.function is not null) {
				foreach(var e in instance.function)
					function.Add(e);
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
			return this;
		}

		public override string Serialize() {
			var instance = new Landmark {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
				categoryOfLandmark = this.categoryOfLandmark.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				function = this.function.ToList(),
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Landmark Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			categoryOfLandmark = this.categoryOfLandmark.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			function = this.function.ToList(),
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// (1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.
	/// </summary>
	[Description("(1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.")]
	[CategoryOrder("Daymark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DaymarkViewModel : FeatureViewModel<Daymark> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		private categoryOfSpecialPurposeMark? _categoryOfSpecialPurposeMark  = default;

		[Description("Classification of an aid to navigation which signifies some special purpose.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

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

		private Boolean _isSlatted  = false;

		[Description("A flag or attribute indicating whether an object has slats, which are flat, narrow strips of material, often used for ventilation or design.")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
			isSlatted = instance.isSlatted;
			return this;
		}

		public override string Serialize() {
			var instance = new Daymark {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				topmarkDaymarkShape = this.topmarkDaymarkShape,
				isSlatted = this.isSlatted,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Daymark Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			categoryOfSpecialPurposeMark = this._categoryOfSpecialPurposeMark,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			topmarkDaymarkShape = this._topmarkDaymarkShape,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.
	/// </summary>
	[Description("A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.")]
	[CategoryOrder("FogSignal",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FogSignalViewModel : FeatureViewModel<FogSignal> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


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

		[Description("The condition of an object at a given instant in time.")]
		[Category("FogSignal")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private signalSequenceViewModel? _signalSequence  = default;

		[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				categoryOfFogSignal = this.categoryOfFogSignal,
				status = this.status.ToList(),
				signalSequence = this.signalSequence?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FogSignal Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			categoryOfFogSignal = this._categoryOfFogSignal,
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public RadarReflectorViewModel Load(RadarReflector instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				height = this.height,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarReflector Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			height = this._height,
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


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

		private signalSequenceViewModel? _signalSequence  = default;

		[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public RadarTransponderBeaconViewModel Load(RadarTransponderBeacon instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			categoryOfRadarTransponderBeacon = instance.categoryOfRadarTransponderBeacon;
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
			radarWaveLength = new ();
			if (instance.radarWaveLength != default) {
				radarWaveLength.Load(instance.radarWaveLength);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RadarTransponderBeacon {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				categoryOfRadarTransponderBeacon = this.categoryOfRadarTransponderBeacon,
				sectorLimitOne = this.sectorLimitOne?.Model,
				sectorLimitTwo = this.sectorLimitTwo?.Model,
				signalGroup = this.signalGroup,
				signalSequence = this.signalSequence?.Model,
				status = this.status.ToList(),
				valueOfNominalRange = this.valueOfNominalRange,
				radarWaveLength = this.radarWaveLength?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarTransponderBeacon Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			categoryOfRadarTransponderBeacon = this._categoryOfRadarTransponderBeacon,
			sectorLimitOne = this._sectorLimitOne?.Model,
			sectorLimitTwo = this._sectorLimitTwo?.Model,
			signalGroup = this._signalGroup,
			signalSequence = this._signalSequence?.Model,
			status = this.status.ToList(),
			valueOfNominalRange = this._valueOfNominalRange,
			radarWaveLength = this._radarWaveLength?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		private categoryOfRadioStation _categoryOfRadioStation  = default;

		[Description("Classification of radio services offered by a radio station.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([20])]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadioStation")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


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
			.. PhysicalAIS.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.PhysicalAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. SyntheticAIS.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.SyntheticAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. VirtualAIS.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.VirtualAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public RadioStationViewModel Load(RadioStation instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				categoryOfRadioStation = this.categoryOfRadioStation,
				estimatedRangeOfTransmission = this.estimatedRangeOfTransmission,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioStation Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			categoryOfRadioStation = this._categoryOfRadioStation,
			estimatedRangeOfTransmission = this._estimatedRangeOfTransmission,
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// A means of distinguishing unlighted marks at night. Retroreflective material is secured to the mark in a particular pattern to reflect back light.
	/// </summary>
	[Description("A means of distinguishing unlighted marks at night. Retroreflective material is secured to the mark in a particular pattern to reflect back light.")]
	[CategoryOrder("Retroreflector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RetroreflectorViewModel : FeatureViewModel<Retroreflector> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("Retroreflector")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
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
		[PermittedValues([1,2,9,10,11,12,13,15])]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public RetroreflectorViewModel Load(Retroreflector instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Retroreflector Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
	/// </summary>
	[Description("An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.")]
	[CategoryOrder("LightAirObstruction",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAirObstructionViewModel : FeatureViewModel<LightAirObstruction> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

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
		[Category("LightAirObstruction")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("The specific visibility of a light, with respect to the light's intensity and ease of recognition.")]
		[Category("LightAirObstruction")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Description("The outward display of the light.")]
		[Category("LightAirObstruction")]
		//[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
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

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Description("The number of features of identical character that exist as a co-located group.")]
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

		[Description("-")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightAirObstructionViewModel Load(LightAirObstruction instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			height = instance.height;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				height = this.height,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			height = this._height,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
	/// </summary>
	[Description("An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.")]
	[CategoryOrder("LightAllAround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAllAroundViewModel : FeatureViewModel<LightAllAround> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

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
		[PermittedValues([1,3,4,5,6,9,10,11])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
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

		[Description("Classification of different light types.")]
		[Category("LightAllAround")]
		[PermittedValues([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

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

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Description("The number of features of identical character that exist as a co-located group.")]
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

		[Description("-")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightAllAroundViewModel Load(LightAllAround instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			height = instance.height;
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
			var instance = new LightAllAround {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				height = this.height,
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
				flareBearing = this.flareBearing,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				rhythmOfLight = this.rhythmOfLight?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightAllAround Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			height = this._height,
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
			flareBearing = this._flareBearing,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			rhythmOfLight = this._rhythmOfLight?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	[Description("A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.")]
	[CategoryOrder("LightFogDetector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightFogDetectorViewModel : FeatureViewModel<LightFogDetector> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

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
		[Category("LightFogDetector")]
		[PermittedValues([1,3,4,5,6,9,10,11])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

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

		[Description("-")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			height = instance.height;
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
			rhythmOfLight = new ();
			if (instance.rhythmOfLight != default) {
				rhythmOfLight.Load(instance.rhythmOfLight);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightFogDetector {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				height = this.height,
				verticalDatum = this.verticalDatum,
				status = this.status.ToList(),
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				colour = this.colour.ToList(),
				signalGeneration = this.signalGeneration,
				rhythmOfLight = this.rhythmOfLight?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightFogDetector Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			height = this._height,
			verticalDatum = this._verticalDatum,
			status = this.status.ToList(),
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			colour = this.colour.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("LightSectored")]
		//[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

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

		[Description("Classification of different light types.")]
		[Category("LightSectored")]
		[PermittedValues([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Description("Describes the characteristics of a light sector.")]
		[Category("LightSectored")]
		[Multiplicity(1)]
		public ObservableCollection<sectorCharacteristicsViewModel> sectorCharacteristics  { get; set; } = new ();

		[Description("A portion or sector of a navigational aid, such as a light or beacon, that is blocked or obscured from view due to obstacles (e.g., landforms, buildings, or other structures). In marine or aviation navigation, it usually refers to an area where the light signal or visibility is intentionally or unintentionally reduced or not visible to vessels or aircraft.")]
		[Category("LightSectored")]
		[Optional]
		public ObservableCollection<obscuredSectorViewModel> obscuredSector  { get; set; } = new ();

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Description("The number of features of identical character that exist as a co-located group.")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightSectoredViewModel Load(LightSectored instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			height = instance.height;
			verticalDatum = instance.verticalDatum;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
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
			obscuredSector.Clear();
			if (instance.obscuredSector is not null) {
				foreach(var e in instance.obscuredSector)
					obscuredSector.Add(new obscuredSectorViewModel().Load(e));
			}
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightSectored {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				height = this.height,
				verticalDatum = this.verticalDatum,
				status = this.status.ToList(),
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				signalGeneration = this.signalGeneration,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				categoryOfLight = this.categoryOfLight.ToList(),
				sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
				obscuredSector = this.obscuredSector.Select(e => e.Model).ToList(),
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightSectored Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			height = this._height,
			verticalDatum = this._verticalDatum,
			status = this.status.ToList(),
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			signalGeneration = this._signalGeneration,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			categoryOfLight = this.categoryOfLight.ToList(),
			sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
			obscuredSector = this.obscuredSector.Select(e => e.Model).ToList(),
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLight));
			};
			sectorCharacteristics.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorCharacteristics));
			};
			obscuredSector.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(obscuredSector));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		[Description("The building's primary construction material.")]
		[Category("LightFloat")]
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("LightFloat")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightFloatViewModel Load(LightFloat instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		[Description("The building's primary construction material.")]
		[Category("LightVessel")]
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("LightVessel")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightVesselViewModel Load(LightVessel instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
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

		[Description("The building's primary construction material.")]
		[Category("OffshorePlatform")]
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("OffshorePlatform")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public OffshorePlatformViewModel Load(OffshorePlatform instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			categoryOfOffshorePlatform = this.categoryOfOffshorePlatform.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			condition = this._condition,
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or seafloor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.
	/// </summary>
	[Description("A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or seafloor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.")]
	[CategoryOrder("Pile",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PileViewModel : FeatureViewModel<Pile> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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
		[PermittedValues([1,3,4,5,6,7,8])]
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public PileViewModel Load(Pile instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
			visualProminence = instance.visualProminence;
			height = instance.height;
			return this;
		}

		public override string Serialize() {
			var instance = new Pile {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			categoryOfPile = this._categoryOfPile,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			visualProminence = this._visualProminence,
			height = this._height,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	[Description("A large storage structure used for storing loose materials, liquids and/or gases.")]
	[CategoryOrder("SiloTank",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SiloTankViewModel : FeatureViewModel<SiloTank> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("SiloTank")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SiloTankViewModel Load(SiloTank instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
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
			return this;
		}

		public override string Serialize() {
			var instance = new SiloTank {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
				buildingShape = this.buildingShape,
				categoryOfSiloTank = this.categoryOfSiloTank,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SiloTank Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			buildingShape = this._buildingShape,
			categoryOfSiloTank = this._categoryOfSiloTank,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	[Description("An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary first response.")]
	[CategoryOrder("EmergencyWreckMarkingBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EmergencyWreckMarkingBuoyViewModel : FeatureViewModel<EmergencyWreckMarkingBuoy> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public EmergencyWreckMarkingBuoyViewModel Load(EmergencyWreckMarkingBuoy instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	[Description("An installation buoy is a buoy used for loading tankers with gas or oil.")]
	[CategoryOrder("InstallationBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InstallationBuoyViewModel : FeatureViewModel<InstallationBuoy> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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

		private categoryOfInstallationBuoy _categoryOfInstallationBuoy  = default;

		[Description("Classification of fixed installation buoy.")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public IsolatedDangerBuoyViewModel Load(IsolatedDangerBuoy instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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

		private categoryOfLateralMark _categoryOfLateralMark  = default;

		[Description("Classification of lateral marks in the IALA Buoyage System.")]
		[Category("LateralBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	[Description("A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.")]
	[CategoryOrder("MooringBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringBuoyViewModel : FeatureViewModel<MooringBuoy> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public MooringBuoyViewModel Load(MooringBuoy instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	[Description("A safe water buoy is used to indicate that there is navigable water around the mark.")]
	[CategoryOrder("SafeWaterBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBuoyViewModel : FeatureViewModel<SafeWaterBuoy> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SafeWaterBuoyViewModel Load(SafeWaterBuoy instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type Equipment used as a buoy in a particular installation.")]
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

		[Description("Classification of an aid to navigation which signifies some special purpose.")]
		[Category("SpecialPurposeGeneralBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SpecialPurposeGeneralBuoyViewModel Load(SpecialPurposeGeneralBuoy instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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

		public override string? ToString() => $"Special Purpose/General Buoy";

		public SpecialPurposeGeneralBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
	/// </summary>
	[Description("A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.")]
	[CategoryOrder("CardinalBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CardinalBeaconViewModel : FeatureViewModel<CardinalBeacon> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalAccuracy  = default;

		[Description("The degree to which a vertical measurement is accurate, typically referring to the accuracy of an object's position in the vertical plane (height or depth)")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfCardinalMark = instance.categoryOfCardinalMark;
			return this;
		}

		public override string Serialize() {
			var instance = new CardinalBeacon {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
				verticalAccuracy = this.verticalAccuracy,
				categoryOfCardinalMark = this.categoryOfCardinalMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CardinalBeacon Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	[Description("An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.")]
	[CategoryOrder("IsolatedDangerBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBeaconViewModel : FeatureViewModel<IsolatedDangerBeacon> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalAccuracy  = default;

		[Description("The degree to which a vertical measurement is accurate, typically referring to the accuracy of an object's position in the vertical plane (height or depth)")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new IsolatedDangerBeacon {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IsolatedDangerBeacon Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// A safe water beacon is used to indicate that there is navigable water around the mark.
	/// </summary>
	[Description("A safe water beacon is used to indicate that there is navigable water around the mark.")]
	[CategoryOrder("SafeWaterBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBeaconViewModel : FeatureViewModel<SafeWaterBeacon> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalAccuracy  = default;

		[Description("The degree to which a vertical measurement is accurate, typically referring to the accuracy of an object's position in the vertical plane (height or depth)")]
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new SafeWaterBeacon {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SafeWaterBeacon Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalAccuracy  = default;

		[Description("The degree to which a vertical measurement is accurate, typically referring to the accuracy of an object's position in the vertical plane (height or depth)")]
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
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SpecialPurposeGeneralBeaconViewModel Load(SpecialPurposeGeneralBeacon instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
				verticalAccuracy = this.verticalAccuracy,
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpecialPurposeGeneralBeacon Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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

		public override string? ToString() => $"Special Purpose/General Beacon";

		public SpecialPurposeGeneralBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.
	/// </summary>
	[Description("A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.")]
	[CategoryOrder("LateralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBeaconViewModel : FeatureViewModel<LateralBeacon> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
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
		[PermittedValues([1,2,9,10,11,12,13,15])]
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
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

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

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalAccuracy  = default;

		[Description("The degree to which a vertical measurement is accurate, typically referring to the accuracy of an object's position in the vertical plane (height or depth)")]
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

		private categoryOfLandmark _categoryOfLandmark  = default;

		[Description("Classification of prominent cultural and natural features in the landscape.")]
		[Category("LateralBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
		[Mandatory]
		public categoryOfLandmark categoryOfLandmark {
			get {
				return _categoryOfLandmark;
			}
			set {
				SetValue(ref _categoryOfLandmark, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LateralBeaconViewModel Load(LateralBeacon instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfLandmark = instance.categoryOfLandmark;
			return this;
		}

		public override string Serialize() {
			var instance = new LateralBeacon {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
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
				verticalAccuracy = this.verticalAccuracy,
				categoryOfLandmark = this.categoryOfLandmark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LateralBeacon Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
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
			verticalAccuracy = this._verticalAccuracy,
			categoryOfLandmark = this._categoryOfLandmark,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// A tower and associated Equipment that generates electrical power from wind. They can be sited offshore and may be either fixed or floating.
	/// </summary>
	[Description("A tower and associated Equipment that generates electrical power from wind. They can be sited offshore and may be either fixed or floating.")]
	[CategoryOrder("WindTurbine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class WindTurbineViewModel : FeatureViewModel<WindTurbine> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
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
		[Category("WindTurbine")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		private colourPattern? _colourPattern  = default;

		[Description("A regular repeated design containing more than one colour.")]
		[Category("WindTurbine")]
		//[Editor(typeof(Editors.HorizonEditor<WindTurbine>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("WindTurbine")]
		//[Editor(typeof(Editors.HorizonEditor<WindTurbine>), typeof(Editors.HorizonEditor))]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private double? _elevation  = default;

		[Description("The altitude of the ground level of a feature, measured from a specified vertical datum.")]
		[Category("WindTurbine")]
		//[Editor(typeof(Editors.HorizonEditor<WindTurbine>), typeof(Editors.HorizonEditor))]
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

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
		[Category("WindTurbine")]
		//[Editor(typeof(Editors.HorizonEditor<WindTurbine>), typeof(Editors.HorizonEditor))]
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
		[Category("WindTurbine")]
		[PermittedValues([6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("A feature which returns a strong radar echo.")]
		[Category("WindTurbine")]
		[Optional]
		public ObservableCollection<Boolean> radarConspicuous  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("WindTurbine")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public WindTurbineViewModel Load(WindTurbine instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern = instance.colourPattern;
			condition = instance.condition;
			elevation = instance.elevation;
			height = instance.height;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous.Clear();
			if (instance.radarConspicuous is not null) {
				foreach(var e in instance.radarConspicuous)
					radarConspicuous.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new WindTurbine {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				contactAddress = this.contactAddress?.Model,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern,
				condition = this.condition,
				elevation = this.elevation,
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public WindTurbine Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			contactAddress = this._contactAddress?.Model,
			colour = this.colour.ToList(),
			colourPattern = this._colourPattern,
			condition = this._condition,
			elevation = this._elevation,
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this.radarConspicuous.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.WindTurbine.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.WindTurbine.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.WindTurbine.featureBindingDefinitions;

		public WindTurbineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public WindTurbineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Wind Turbine";

		public WindTurbineViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			radarConspicuous.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(radarConspicuous));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
	/// An area within which a uniform assessment of the quality of the bathymetric data exists.
	/// </summary>
	[Description("An area within which a uniform assessment of the quality of the bathymetric data exists.")]
	[CategoryOrder("QualityOfBathymetricData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QualityOfBathymetricDataViewModel : FeatureViewModel<QualityOfBathymetricData> {
		private categoryOfTemporalVariation _categoryOfTemporalVariation  = default;

		[Description("An assessment of the likelihood of change over time.")]
		[Category("QualityOfBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfBathymetricData>), typeof(Editors.HorizonEditor))]
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
		[Category("QualityOfBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfBathymetricData>), typeof(Editors.HorizonEditor))]
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
		[Category("QualityOfBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfBathymetricData>), typeof(Editors.HorizonEditor))]
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
		[Category("QualityOfBathymetricData")]
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

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
		[Category("QualityOfBathymetricData")]
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

		private informationViewModel? _information  = default;

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("QualityOfBathymetricData")]
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

		private textualDescriptionViewModel? _textualDescription  = default;

		[Description("Encodes the file name of a single external text file that contains the text in a defined language, which provides additional textual information that cannot be provided using other allowable attributes for the feature.")]
		[Category("QualityOfBathymetricData")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public QualityOfBathymetricDataViewModel Load(QualityOfBathymetricData instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			orientationUncertainty = instance.orientationUncertainty;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			information = new ();
			if (instance.information != default) {
				information.Load(instance.information);
			}
			textualDescription = new ();
			if (instance.textualDescription != default) {
				textualDescription.Load(instance.textualDescription);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new QualityOfBathymetricData {
				categoryOfTemporalVariation = this.categoryOfTemporalVariation,
				orientationUncertainty = this.orientationUncertainty,
				horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				verticalUncertainty = this.verticalUncertainty?.Model,
				information = this.information?.Model,
				textualDescription = this.textualDescription?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public QualityOfBathymetricData Model => new () {
			categoryOfTemporalVariation = this._categoryOfTemporalVariation,
			orientationUncertainty = this._orientationUncertainty,
			horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
			information = this._information?.Model,
			textualDescription = this._textualDescription?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.QualityOfBathymetricData.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.QualityOfBathymetricData.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.QualityOfBathymetricData.featureBindingDefinitions;

		public QualityOfBathymetricDataViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public QualityOfBathymetricDataViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Quality of Bathymetric Data";
	}



	/// <summary>
	/// A characteristic or element in the environment that poses a potential risk to navigation or safety. This could include hazards such as rocks, submerged objects, shallow waters, or man-made structures that could endanger vessels or other forms of transportation.
	/// </summary>
	[Description("A characteristic or element in the environment that poses a potential risk to navigation or safety. This could include hazards such as rocks, submerged objects, shallow waters, or man-made structures that could endanger vessels or other forms of transportation.")]
	[CategoryOrder("DangerousFeature",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DangerousFeatureViewModel : FeatureViewModel<DangerousFeature> {
		private String _interoperabilityIdentifier  = string.Empty;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("DangerousFeature")]
		//[Editor(typeof(Editors.HorizonEditor<DangerousFeature>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

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
			.. DangerousFeatureAssociations.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.DangerousFeatureAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public DangerousFeatureViewModel Load(DangerousFeature instance) {
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DangerousFeature {
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DangerousFeature Model => new () {
			interoperabilityIdentifier = this._interoperabilityIdentifier,
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
	/// A virtual or synthetic Aid to Navigation (AtoN) transmitted via the Automatic Identification System (AIS). Unlike a physical AtoN, which exists in the real world (like buoys or lighthouses), a synthetic AIS AtoN is created in the AIS network to provide navigational information to mariners about a point of interest or hazard, even if no physical object is present at that location. It helps in improving situational awareness.
	/// </summary>
	[Description("A virtual or synthetic Aid to Navigation (AtoN) transmitted via the Automatic Identification System (AIS). Unlike a physical AtoN, which exists in the real world (like buoys or lighthouses), a synthetic AIS AtoN is created in the AIS network to provide navigational information to mariners about a point of interest or hazard, even if no physical object is present at that location. It helps in improving situational awareness.")]
	[CategoryOrder("SyntheticAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SyntheticAISAidToNavigationViewModel : FeatureViewModel<SyntheticAISAidToNavigation> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("ElectronicAtoN")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAtoN>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
			}
		}

		private String _mMSICode  = string.Empty;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ElectronicAtoN")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAtoN>), typeof(Editors.HorizonEditor))]
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
		[Category("ElectronicAtoN")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private categoryOfSyntheticAISAidtoNavigation _categoryOfSyntheticAISAidtoNavigation  = default;

		[Description("A classification of AIS AtoNs that are transmitted electronically and linked to a real-world object but do not physically exist at the broadcast location.")]
		[Category("SyntheticAISAidToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<SyntheticAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public categoryOfSyntheticAISAidtoNavigation categoryOfSyntheticAISAidtoNavigation {
			get {
				return _categoryOfSyntheticAISAidtoNavigation;
			}
			set {
				SetValue(ref _categoryOfSyntheticAISAidtoNavigation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("SyntheticAIS","syntheticAISbroadcasts",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> SyntheticAIS { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. SyntheticAIS.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.SyntheticAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public SyntheticAISAidToNavigationViewModel Load(SyntheticAISAidToNavigation instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
			mMSICode = instance.mMSICode;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfSyntheticAISAidtoNavigation = instance.categoryOfSyntheticAISAidtoNavigation;
			return this;
		}

		public override string Serialize() {
			var instance = new SyntheticAISAidToNavigation {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				mMSICode = this.mMSICode,
				status = this.status.ToList(),
				categoryOfSyntheticAISAidtoNavigation = this.categoryOfSyntheticAISAidtoNavigation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SyntheticAISAidToNavigation Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			categoryOfSyntheticAISAidtoNavigation = this._categoryOfSyntheticAISAidtoNavigation,
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

		public override string? ToString() => $"Synthetic AIS Aid to Navigation";

		public SyntheticAISAidToNavigationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
	/// </summary>
	[Description("An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.")]
	[CategoryOrder("PhysicalAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalAISAidToNavigationViewModel : FeatureViewModel<PhysicalAISAidToNavigation> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("ElectronicAtoN")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAtoN>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
			}
		}

		private String _mMSICode  = string.Empty;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ElectronicAtoN")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAtoN>), typeof(Editors.HorizonEditor))]
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
		[Category("ElectronicAtoN")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private categoryOfPhysicalAISAidToNavigation _categoryOfPhysicalAISAidToNavigation  = default;

		[Description("A classification of AIS AtoNs that correspond to an actual, physical Aid to Navigation at a real-world location.")]
		[Category("PhysicalAISAidToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<PhysicalAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public categoryOfPhysicalAISAidToNavigation categoryOfPhysicalAISAidToNavigation {
			get {
				return _categoryOfPhysicalAISAidToNavigation;
			}
			set {
				SetValue(ref _categoryOfPhysicalAISAidToNavigation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("PhysicalAIS","physicalAISbroadcasts",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> PhysicalAIS { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. PhysicalAIS.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.PhysicalAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public PhysicalAISAidToNavigationViewModel Load(PhysicalAISAidToNavigation instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
			mMSICode = instance.mMSICode;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfPhysicalAISAidToNavigation = instance.categoryOfPhysicalAISAidToNavigation;
			return this;
		}

		public override string Serialize() {
			var instance = new PhysicalAISAidToNavigation {
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				mMSICode = this.mMSICode,
				status = this.status.ToList(),
				categoryOfPhysicalAISAidToNavigation = this.categoryOfPhysicalAISAidToNavigation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PhysicalAISAidToNavigation Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			categoryOfPhysicalAISAidToNavigation = this._categoryOfPhysicalAISAidToNavigation,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.
	/// </summary>
	[Description("An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.")]
	[CategoryOrder("VirtualAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VirtualAISAidToNavigationViewModel : FeatureViewModel<VirtualAISAidToNavigation> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();

		private String _atoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("ElectronicAtoN")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAtoN>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String atoNNumber {
			get {
				return _atoNNumber;
			}
			set {
				SetValue(ref _atoNNumber, value);
			}
		}

		private String _mMSICode  = string.Empty;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ElectronicAtoN")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAtoN>), typeof(Editors.HorizonEditor))]
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
		[Category("ElectronicAtoN")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
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
			.. VirtualAIS.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.VirtualAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public VirtualAISAidToNavigationViewModel Load(VirtualAISAidToNavigation instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
			}
			atoNNumber = instance.atoNNumber;
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				atoNNumber = this.atoNNumber,
				mMSICode = this.mMSICode,
				status = this.status.ToList(),
				virtualAISAidToNavigationType = this.virtualAISAidToNavigationType,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VirtualAISAidToNavigation Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			atoNNumber = this._atoNNumber,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("Topmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TopmarkViewModel : FeatureViewModel<Topmark> {
		private String? _interoperabilityIdentifier  = default;

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
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

		[Description("The file name of an externally referenced picture file.")]
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

		[Description("Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> seasonalActionRequired  { get; set; } = new ();


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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public TopmarkViewModel Load(Topmark instance) {
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
			seasonalActionRequired.Clear();
			if (instance.seasonalActionRequired is not null) {
				foreach(var e in instance.seasonalActionRequired)
					seasonalActionRequired.Add(e);
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
				seasonalActionRequired = this.seasonalActionRequired.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				status = this.status.ToList(),
				topmarkDaymarkShape = this.topmarkDaymarkShape,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Topmark Model => new () {
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
			seasonalActionRequired = this.seasonalActionRequired.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			status = this.status.ToList(),
			topmarkDaymarkShape = this._topmarkDaymarkShape,
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
			seasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(seasonalActionRequired));
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
	/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
	/// </summary>
	[Description("Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.")]
	[CategoryOrder("AtonAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAggregationViewModel : FeatureViewModel<AtonAggregation> {
		private categoryOfAggregation _categoryOfAggregation  = default;

		[Description("Named aggregations between two or more aids to navigation and/or navigationally relevant features.")]
		[Category("AtonAggregation")]
		//[Editor(typeof(Editors.HorizonEditor<AtonAggregation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,2])]
		[Mandatory]
		public categoryOfAggregation categoryOfAggregation {
			get {
				return _categoryOfAggregation;
			}
			set {
				SetValue(ref _categoryOfAggregation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("AtonAggregations","atonAggregationBy",["AidsToNavigation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> AtonAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. AtonAggregations.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.AtonAggregations> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public AtonAggregationViewModel Load(AtonAggregation instance) {
			categoryOfAggregation = instance.categoryOfAggregation;
			return this;
		}

		public override string Serialize() {
			var instance = new AtonAggregation {
				categoryOfAggregation = this.categoryOfAggregation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonAggregation Model => new () {
			categoryOfAggregation = this._categoryOfAggregation,
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
		private categoryOfAssociation _categoryOfAssociation  = default;

		[Description("Named associations between two or more aids to navigation and/or navigationally relevant features.")]
		[Category("AtonAssociation")]
		//[Editor(typeof(Editors.HorizonEditor<AtonAssociation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public categoryOfAssociation categoryOfAssociation {
			get {
				return _categoryOfAssociation;
			}
			set {
				SetValue(ref _categoryOfAssociation, value);
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
			.. DangerousFeatureAssociations.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.DangerousFeatureAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. AtonAssociations.Select(e => new featureBinding<DomainModel.S125.FeatureAssociations.AtonAssociations> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public AtonAssociationViewModel Load(AtonAssociation instance) {
			categoryOfAssociation = instance.categoryOfAssociation;
			return this;
		}

		public override string Serialize() {
			var instance = new AtonAssociation {
				categoryOfAssociation = this.categoryOfAssociation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonAssociation Model => new () {
			categoryOfAssociation = this._categoryOfAssociation,
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



	public static class InformationBindingExtension {
		public static SpatialQualityViewModel LoadInformationBinding(this SpatialQualityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AtonStatusInformationViewModel LoadInformationBinding(this AtonStatusInformationViewModel instance, informationBinding[] bindings) {
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

		public static LandmarkViewModel LoadInformationBinding(this LandmarkViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DaymarkViewModel LoadInformationBinding(this DaymarkViewModel instance, informationBinding[] bindings) {
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

		public static RetroreflectorViewModel LoadInformationBinding(this RetroreflectorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadInformationBinding(this LightAirObstructionViewModel instance, informationBinding[] bindings) {
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

		public static MooringBuoyViewModel LoadInformationBinding(this MooringBuoyViewModel instance, informationBinding[] bindings) {
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

		public static LateralBeaconViewModel LoadInformationBinding(this LateralBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static WindTurbineViewModel LoadInformationBinding(this WindTurbineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static VerticalDatumOfDataViewModel LoadInformationBinding(this VerticalDatumOfDataViewModel instance, informationBinding[] bindings) {
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

		public static QualityOfBathymetricDataViewModel LoadInformationBinding(this QualityOfBathymetricDataViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DangerousFeatureViewModel LoadInformationBinding(this DangerousFeatureViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SyntheticAISAidToNavigationViewModel LoadInformationBinding(this SyntheticAISAidToNavigationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PhysicalAISAidToNavigationViewModel LoadInformationBinding(this PhysicalAISAidToNavigationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static VirtualAISAidToNavigationViewModel LoadInformationBinding(this VirtualAISAidToNavigationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TopmarkViewModel LoadInformationBinding(this TopmarkViewModel instance, informationBinding[] bindings) {
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

	}

	public static class FeatureBindingExtension {
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

		public static LandmarkViewModel LoadFeatureBinding(this LandmarkViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DaymarkViewModel LoadFeatureBinding(this DaymarkViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
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

		public static RadarTransponderBeaconViewModel LoadFeatureBinding(this RadarTransponderBeaconViewModel instance, featureBinding[] bindings) {
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

		public static RetroreflectorViewModel LoadFeatureBinding(this RetroreflectorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadFeatureBinding(this LightAirObstructionViewModel instance, featureBinding[] bindings) {
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

		public static MooringBuoyViewModel LoadFeatureBinding(this MooringBuoyViewModel instance, featureBinding[] bindings) {
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

		public static LateralBeaconViewModel LoadFeatureBinding(this LateralBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static WindTurbineViewModel LoadFeatureBinding(this WindTurbineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static VerticalDatumOfDataViewModel LoadFeatureBinding(this VerticalDatumOfDataViewModel instance, featureBinding[] bindings) {
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

		public static QualityOfBathymetricDataViewModel LoadFeatureBinding(this QualityOfBathymetricDataViewModel instance, featureBinding[] bindings) {
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

		public static TopmarkViewModel LoadFeatureBinding(this TopmarkViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
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

	}

}
