using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S501 {
	public static class Summary
	{
		public static Version Version => new Version("0.0.5");
		public static string[] ComplexTypes => ["qRouteChannelWidth","detectionDateRange","multiplicityOfFeatures","onlineResource","topmark","featureName","fixedDateRange","altitudeRange","altitude","rythmOfLight","verticalClearanceSafe","lastSourceInformation","information","firstSourceInformation","horizontalClearanceFixed","verticalUncertainty","frequencyPair","vesselMeasurementsSpecification","surfaceCharacteristics","magneticInformation","speed","verticalClearanceFixed","sourceIdentification","horizontalPositionUncertainty","sectorCharacteristics","orientation","directionHeading","flightLevel","vesselSpeedLimit","periodicDateRange","shapeInformation","lightSector","signalSequence","sectorInformation","directionalCharacter","sectorLimit","sectorLimitTwo","sectorLimitOne"];
		public static string[] InformationAssociationTypes => [];
		public static string[] FeatureAssociationTypes => [];
		public static string[] InformationTypes => ["ReferenceToAPublication"];
		public static string[] FeatureTypes => ["InstallationBuoy","DepthArea","RadioCallingInPoint","PatrolArea","Checkpoint","MarineManagementArea","DepthContour","EnvironmentallySensitiveSeaArea","Road","River","MilitaryPracticeArea","DiscolouredWater","CardinalBuoy","SafeWaterBuoy","RadioStation","MilitaryExerciseAirspace","ContiguousZone","NormalBaseline","CableArea","ContinentalShelfArea","InternalWaters","AdministrationArea","Bollard","Dolphin","RadarRange","IsolatedDangerBeacon","IsolatedDangerBuoy","SubmarineTransitLane","MaritimeSafetyInformationArea","AirspaceRestriction","Sounding","TrafficSeparationSchemeBoundary","DumpingGround","AirportAirfield","FoulGround","LightAirObstruction","MooringBuoy","UnderwaterAwashRock","CableOverhead","ControlledAirspace","Obstruction","FishingGround","FishingFacility","NavigationSystem","TrafficSeparationSchemeCrossing","TrafficSeparationSchemeLanePart","TerritorialSeaArea","LateralBeacon","CoastGuardStation","SeparationZoneOrLine","BottomFeature","ArchipelagicBaseline","SmallBottomObject","ExclusiveEconomicZone","RadarStation","DivingLocation","RestrictedArea","CableSubmarine","Wreck","QRoute","CompletenessOfProductSpecification","RescueStation","CardinalBeacon","LightVessel","FisheryZone","DredgedArea","FerryRoute","ShorelineConstruction","CautionArea","DeepWaterRoutePart","CurrentNonGravitational","DataCoverage","SeabedArea","SpecialPurposeGeneralBuoy","LightSectored","IceLine","AnchorageArea","LateralBuoy","TrafficSeparationSchemeRoundabout","DeepWaterRouteCentreline","LightFloat","LightAllAround","Coastline","SeaAreaNamedWaterArea","DropZone","Conveyor","LineOfDelimitation","StraightTerritorialSeaBaseline","SafeWaterBeacon","SpecialPurposeGeneralBeacon"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.point => ["InstallationBuoy","RadioCallingInPoint","Checkpoint","DiscolouredWater","CardinalBuoy","SafeWaterBuoy","RadioStation","Bollard","Dolphin","IsolatedDangerBeacon","IsolatedDangerBuoy","DumpingGround","AirportAirfield","LightAirObstruction","MooringBuoy","UnderwaterAwashRock","Obstruction","FishingFacility","NavigationSystem","LateralBeacon","CoastGuardStation","SmallBottomObject","RadarStation","DivingLocation","Wreck","RescueStation","CardinalBeacon","LightVessel","ShorelineConstruction","CautionArea","CurrentNonGravitational","SeabedArea","SpecialPurposeGeneralBuoy","LightSectored","AnchorageArea","LateralBuoy","LightFloat","LightAllAround","SeaAreaNamedWaterArea","SafeWaterBeacon","SpecialPurposeGeneralBeacon"],
			Primitives.surface => ["DepthArea","PatrolArea","Checkpoint","MarineManagementArea","EnvironmentallySensitiveSeaArea","River","MilitaryPracticeArea","DiscolouredWater","MilitaryExerciseAirspace","ContiguousZone","CableArea","ContinentalShelfArea","InternalWaters","AdministrationArea","Dolphin","RadarRange","SubmarineTransitLane","MaritimeSafetyInformationArea","AirspaceRestriction","DumpingGround","AirportAirfield","FoulGround","ControlledAirspace","Obstruction","FishingGround","FishingFacility","TrafficSeparationSchemeCrossing","TrafficSeparationSchemeLanePart","TerritorialSeaArea","CoastGuardStation","SeparationZoneOrLine","BottomFeature","ExclusiveEconomicZone","RestrictedArea","QRoute","CompletenessOfProductSpecification","FisheryZone","DredgedArea","FerryRoute","ShorelineConstruction","CautionArea","DeepWaterRoutePart","DataCoverage","SeabedArea","AnchorageArea","TrafficSeparationSchemeRoundabout","SeaAreaNamedWaterArea","DropZone","Conveyor"],
			Primitives.curve => ["RadioCallingInPoint","DepthContour","Road","ContiguousZone","NormalBaseline","ContinentalShelfArea","AdministrationArea","TrafficSeparationSchemeBoundary","CableOverhead","FishingFacility","TerritorialSeaArea","SeparationZoneOrLine","ArchipelagicBaseline","ExclusiveEconomicZone","CableSubmarine","QRoute","FerryRoute","ShorelineConstruction","SeabedArea","IceLine","DeepWaterRouteCentreline","Coastline","Conveyor","LineOfDelimitation","StraightTerritorialSeaBaseline"],
			Primitives.pointSet => ["Sounding"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"InstallationBuoy" => [Primitives.point],
			"DepthArea" => [Primitives.surface],
			"RadioCallingInPoint" => [Primitives.point,Primitives.curve],
			"PatrolArea" => [Primitives.surface],
			"Checkpoint" => [Primitives.point,Primitives.surface],
			"MarineManagementArea" => [Primitives.surface],
			"DepthContour" => [Primitives.curve],
			"EnvironmentallySensitiveSeaArea" => [Primitives.surface],
			"Road" => [Primitives.curve],
			"River" => [Primitives.surface],
			"MilitaryPracticeArea" => [Primitives.surface],
			"DiscolouredWater" => [Primitives.point,Primitives.surface],
			"CardinalBuoy" => [Primitives.point],
			"SafeWaterBuoy" => [Primitives.point],
			"RadioStation" => [Primitives.point],
			"MilitaryExerciseAirspace" => [Primitives.surface],
			"ContiguousZone" => [Primitives.curve,Primitives.surface],
			"NormalBaseline" => [Primitives.curve],
			"CableArea" => [Primitives.surface],
			"ContinentalShelfArea" => [Primitives.curve,Primitives.surface],
			"InternalWaters" => [Primitives.surface],
			"AdministrationArea" => [Primitives.curve,Primitives.surface],
			"Bollard" => [Primitives.point],
			"Dolphin" => [Primitives.point,Primitives.surface],
			"RadarRange" => [Primitives.surface],
			"IsolatedDangerBeacon" => [Primitives.point],
			"IsolatedDangerBuoy" => [Primitives.point],
			"SubmarineTransitLane" => [Primitives.surface],
			"MaritimeSafetyInformationArea" => [Primitives.surface],
			"AirspaceRestriction" => [Primitives.surface],
			"Sounding" => [Primitives.pointSet],
			"TrafficSeparationSchemeBoundary" => [Primitives.curve],
			"DumpingGround" => [Primitives.point,Primitives.surface],
			"AirportAirfield" => [Primitives.point,Primitives.surface],
			"FoulGround" => [Primitives.surface],
			"LightAirObstruction" => [Primitives.point],
			"MooringBuoy" => [Primitives.point],
			"UnderwaterAwashRock" => [Primitives.point],
			"CableOverhead" => [Primitives.curve],
			"ControlledAirspace" => [Primitives.surface],
			"Obstruction" => [Primitives.point,Primitives.surface],
			"FishingGround" => [Primitives.surface],
			"FishingFacility" => [Primitives.point,Primitives.curve,Primitives.surface],
			"NavigationSystem" => [Primitives.point],
			"TrafficSeparationSchemeCrossing" => [Primitives.surface],
			"TrafficSeparationSchemeLanePart" => [Primitives.surface],
			"TerritorialSeaArea" => [Primitives.curve,Primitives.surface],
			"LateralBeacon" => [Primitives.point],
			"CoastGuardStation" => [Primitives.point,Primitives.surface],
			"SeparationZoneOrLine" => [Primitives.curve,Primitives.surface],
			"BottomFeature" => [Primitives.surface],
			"ArchipelagicBaseline" => [Primitives.curve],
			"SmallBottomObject" => [Primitives.point],
			"ExclusiveEconomicZone" => [Primitives.curve,Primitives.surface],
			"RadarStation" => [Primitives.point],
			"DivingLocation" => [Primitives.point],
			"RestrictedArea" => [Primitives.surface],
			"CableSubmarine" => [Primitives.curve],
			"Wreck" => [Primitives.point],
			"QRoute" => [Primitives.curve,Primitives.surface],
			"CompletenessOfProductSpecification" => [Primitives.surface],
			"RescueStation" => [Primitives.point],
			"CardinalBeacon" => [Primitives.point],
			"LightVessel" => [Primitives.point],
			"FisheryZone" => [Primitives.surface],
			"DredgedArea" => [Primitives.surface],
			"FerryRoute" => [Primitives.curve,Primitives.surface],
			"ShorelineConstruction" => [Primitives.point,Primitives.curve,Primitives.surface],
			"CautionArea" => [Primitives.point,Primitives.surface],
			"DeepWaterRoutePart" => [Primitives.surface],
			"CurrentNonGravitational" => [Primitives.point],
			"DataCoverage" => [Primitives.surface],
			"SeabedArea" => [Primitives.point,Primitives.curve,Primitives.surface],
			"SpecialPurposeGeneralBuoy" => [Primitives.point],
			"LightSectored" => [Primitives.point],
			"IceLine" => [Primitives.curve],
			"AnchorageArea" => [Primitives.point,Primitives.surface],
			"LateralBuoy" => [Primitives.point],
			"TrafficSeparationSchemeRoundabout" => [Primitives.surface],
			"DeepWaterRouteCentreline" => [Primitives.curve],
			"LightFloat" => [Primitives.point],
			"LightAllAround" => [Primitives.point],
			"Coastline" => [Primitives.curve],
			"SeaAreaNamedWaterArea" => [Primitives.point,Primitives.surface],
			"DropZone" => [Primitives.surface],
			"Conveyor" => [Primitives.curve,Primitives.surface],
			"LineOfDelimitation" => [Primitives.curve],
			"StraightTerritorialSeaBaseline" => [Primitives.curve],
			"SafeWaterBeacon" => [Primitives.point],
			"SpecialPurposeGeneralBeacon" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// The extent to which a feature, either natural or artificial, is visible from seaward.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum visualProminence : int {
		[System.ComponentModel.Description("Term applied to an object either natural or artificial which is distinctly and notably visible from seaward.")]
		[EnumMember(Value = "Visually Conspicuous")] 
		[XmlEnum("1")] 
		VisuallyConspicuous = 1,

		[System.ComponentModel.Description("An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.")]
		[EnumMember(Value = "Not Visually Conspicuous")] 
		[XmlEnum("2")] 
		NotVisuallyConspicuous = 2,

		[System.ComponentModel.Description("Objects which are easily identifiable, but do not justify being classed as conspicuous.")]
		[EnumMember(Value = "Prominent")] 
		[XmlEnum("3")] 
		Prominent = 3,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum gradientOfSlope : int {
		[System.ComponentModel.Description("501:Steep (missing definition)")]
		[EnumMember(Value = "Steep")] 
		[XmlEnum("501")] 
		Steep = 501,

		[System.ComponentModel.Description("502:Moderate (missing definition)")]
		[EnumMember(Value = "Moderate")] 
		[XmlEnum("502")] 
		Moderate = 502,

		[System.ComponentModel.Description("503:Gentle (missing definition)")]
		[EnumMember(Value = "Gentle")] 
		[XmlEnum("503")] 
		Gentle = 503,

		[System.ComponentModel.Description("504:Mild (missing definition)")]
		[EnumMember(Value = "Mild")] 
		[XmlEnum("504")] 
		Mild = 504,

		[System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
		[EnumMember(Value = "Flat")] 
		[XmlEnum("505")] 
		Flat = 505,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeofMilitaryActivity : int {
		[System.ComponentModel.Description("501:Anti Aircraft (ground to air) (missing definition)")]
		[EnumMember(Value = "Anti Aircraft (ground to air)")] 
		[XmlEnum("501")] 
		AntiAircraftGroundToAir = 501,

		[System.ComponentModel.Description("502:High and Low angle gunnery (ground to ground) (missing definition)")]
		[EnumMember(Value = "High and Low angle gunnery (ground to ground)")] 
		[XmlEnum("502")] 
		HighAndLowAngleGunneryGroundToGround = 502,

		[System.ComponentModel.Description("503:Air to Air Firing (missing definition)")]
		[EnumMember(Value = "Air to Air Firing")] 
		[XmlEnum("503")] 
		AirToAirFiring = 503,

		[System.ComponentModel.Description("504:Air Combat Training (missing definition)")]
		[EnumMember(Value = "Air Combat Training")] 
		[XmlEnum("504")] 
		AirCombatTraining = 504,

		[System.ComponentModel.Description("505:Air Dropped Torpedo (missing definition)")]
		[EnumMember(Value = "Air Dropped Torpedo")] 
		[XmlEnum("505")] 
		AirDroppedTorpedo = 505,

		[System.ComponentModel.Description("506:Aircraft General (missing definition)")]
		[EnumMember(Value = "Aircraft General")] 
		[XmlEnum("506")] 
		AircraftGeneral = 506,

		[System.ComponentModel.Description("507:Air to Surface Firing (missing definition)")]
		[EnumMember(Value = "Air to Surface Firing")] 
		[XmlEnum("507")] 
		AirToSurfaceFiring = 507,

		[System.ComponentModel.Description("508:Anti Submarine Warfare Exercises (missing definition)")]
		[EnumMember(Value = "Anti Submarine Warfare Exercises")] 
		[XmlEnum("508")] 
		AntiSubmarineWarfareExercises = 508,

		[System.ComponentModel.Description("509:Acoustic Trials (missing definition)")]
		[EnumMember(Value = "Acoustic Trials")] 
		[XmlEnum("509")] 
		AcousticTrials = 509,

		[System.ComponentModel.Description("510:Air Tactical Training (missing definition)")]
		[EnumMember(Value = "Air Tactical Training")] 
		[XmlEnum("510")] 
		AirTacticalTraining = 510,

		[System.ComponentModel.Description("511:Bombing (missing definition)")]
		[EnumMember(Value = "Bombing")] 
		[XmlEnum("511")] 
		Bombing = 511,

		[System.ComponentModel.Description("512:Depth Charge dropping/firing (including rocket/mortar fired DC) (missing definition)")]
		[EnumMember(Value = "Depth Charge dropping/firing (including rocket/mortar fired DC)")] 
		[XmlEnum("512")] 
		DepthChargeDroppingFiringIncludingRocketMortarFiredDc = 512,

		[System.ComponentModel.Description("Neutralization of the strength of the magnetic field of a vessel, by means of suitably arranged electric coils permanently installed in the vessel. See also Degaussing Cable.")]
		[EnumMember(Value = "Degaussing")] 
		[XmlEnum("513")] 
		Degaussing = 513,

		[System.ComponentModel.Description("514:Demolition of unexploded ordnance (missing definition)")]
		[EnumMember(Value = "Demolition of unexploded ordnance")] 
		[XmlEnum("514")] 
		DemolitionOfUnexplodedOrdnance = 514,

		[System.ComponentModel.Description("515:Explosives Trials (missing definition)")]
		[EnumMember(Value = "Explosives Trials")] 
		[XmlEnum("515")] 
		ExplosivesTrials = 515,

		[System.ComponentModel.Description("516:Firing (missing definition)")]
		[EnumMember(Value = "Firing")] 
		[XmlEnum("516")] 
		Firing = 516,

		[System.ComponentModel.Description("517:Flares (missing definition)")]
		[EnumMember(Value = "Flares")] 
		[XmlEnum("517")] 
		Flares = 517,

		[System.ComponentModel.Description("518:Glow Worm (missing definition)")]
		[EnumMember(Value = "Glow Worm")] 
		[XmlEnum("518")] 
		GlowWorm = 518,

		[System.ComponentModel.Description("519:General Practice (missing definition)")]
		[EnumMember(Value = "General Practice")] 
		[XmlEnum("519")] 
		GeneralPractice = 519,

		[System.ComponentModel.Description("520:Guided Weapons (air Flight) (missing definition)")]
		[EnumMember(Value = "Guided Weapons (air Flight)")] 
		[XmlEnum("520")] 
		GuidedWeaponsAirFlight = 520,

		[System.ComponentModel.Description("521:Helicopter exercises (missing definition)")]
		[EnumMember(Value = "Helicopter exercises")] 
		[XmlEnum("521")] 
		HelicopterExercises = 521,

		[System.ComponentModel.Description("522:High Energy Manouvres (missing definition)")]
		[EnumMember(Value = "High Energy Manouvres")] 
		[XmlEnum("522")] 
		HighEnergyManouvres = 522,

		[System.ComponentModel.Description("523:HM Ships (non-firing exercises, practices and trials) (missing definition)")]
		[EnumMember(Value = "HM Ships (non-firing exercises, practices and trials)")] 
		[XmlEnum("523")] 
		HmShipsNonFiringExercisesPracticesAndTrials = 523,

		[System.ComponentModel.Description("524:Live ASW firing (missing definition)")]
		[EnumMember(Value = "Live ASW firing")] 
		[XmlEnum("524")] 
		LiveAswFiring = 524,

		[System.ComponentModel.Description("525:Mine Counter Measures (missing definition)")]
		[EnumMember(Value = "Mine Counter Measures")] 
		[XmlEnum("525")] 
		MineCounterMeasures = 525,

		[System.ComponentModel.Description("526:Mine Disposal (missing definition)")]
		[EnumMember(Value = "Mine Disposal")] 
		[XmlEnum("526")] 
		MineDisposal = 526,

		[System.ComponentModel.Description("527:Missile Firing (missing definition)")]
		[EnumMember(Value = "Missile Firing")] 
		[XmlEnum("527")] 
		MissileFiring = 527,

		[System.ComponentModel.Description("528:Mortar Firing (missing definition)")]
		[EnumMember(Value = "Mortar Firing")] 
		[XmlEnum("528")] 
		MortarFiring = 528,

		[System.ComponentModel.Description("529:Naval Gunfire Support (missing definition)")]
		[EnumMember(Value = "Naval Gunfire Support")] 
		[XmlEnum("529")] 
		NavalGunfireSupport = 529,

		[System.ComponentModel.Description("530:Noise Ranging (missing definition)")]
		[EnumMember(Value = "Noise Ranging")] 
		[XmlEnum("530")] 
		NoiseRanging = 530,

		[System.ComponentModel.Description("531:Parachute Dropping (missing definition)")]
		[EnumMember(Value = "Parachute Dropping")] 
		[XmlEnum("531")] 
		ParachuteDropping = 531,

		[System.ComponentModel.Description("532:Pilotless Target Aircraft (missing definition)")]
		[EnumMember(Value = "Pilotless Target Aircraft")] 
		[XmlEnum("532")] 
		PilotlessTargetAircraft = 532,

		[System.ComponentModel.Description("533:Radar Training Buoy (missing definition)")]
		[EnumMember(Value = "Radar Training Buoy")] 
		[XmlEnum("533")] 
		RadarTrainingBuoy = 533,

		[System.ComponentModel.Description("534:Submarine Exercises (missing definition)")]
		[EnumMember(Value = "Submarine Exercises")] 
		[XmlEnum("534")] 
		SubmarineExercises = 534,

		[System.ComponentModel.Description("Suspension in the atmosphere of small particles produced by combustion.")]
		[EnumMember(Value = "Smoke")] 
		[XmlEnum("535")] 
		Smoke = 535,

		[System.ComponentModel.Description("536:Sonobuoy Dropping (missing definition)")]
		[EnumMember(Value = "Sonobuoy Dropping")] 
		[XmlEnum("536")] 
		SonobuoyDropping = 536,

		[System.ComponentModel.Description("537:Starshell (missing definition)")]
		[EnumMember(Value = "Starshell")] 
		[XmlEnum("537")] 
		Starshell = 537,

		[System.ComponentModel.Description("538:Surface Target Towing (missing definition)")]
		[EnumMember(Value = "Surface Target Towing")] 
		[XmlEnum("538")] 
		SurfaceTargetTowing = 538,

		[System.ComponentModel.Description("539:Surface to Surface Firings (missing definition)")]
		[EnumMember(Value = "Surface to Surface Firings")] 
		[XmlEnum("539")] 
		SurfaceToSurfaceFirings = 539,

		[System.ComponentModel.Description("540:Submarine General (non-firing exercises, practices, trials) (missing definition)")]
		[EnumMember(Value = "Submarine General (non-firing exercises, practices, trials)")] 
		[XmlEnum("540")] 
		SubmarineGeneralNonFiringExercisesPracticesTrials = 540,

		[System.ComponentModel.Description("541:Surface Explosions (missing definition)")]
		[EnumMember(Value = "Surface Explosions")] 
		[XmlEnum("541")] 
		SurfaceExplosions = 541,

		[System.ComponentModel.Description("542:Torpedo Firing Area (missing definition)")]
		[EnumMember(Value = "Torpedo Firing Area")] 
		[XmlEnum("542")] 
		TorpedoFiringArea = 542,

		[System.ComponentModel.Description("543:Towed Array (missing definition)")]
		[EnumMember(Value = "Towed Array")] 
		[XmlEnum("543")] 
		TowedArray = 543,

		[System.ComponentModel.Description("544:Aerial Towed Target or Target Towing Aircraft (missing definition)")]
		[EnumMember(Value = "Aerial Towed Target or Target Towing Aircraft")] 
		[XmlEnum("544")] 
		AerialTowedTargetOrTargetTowingAircraft = 544,

		[System.ComponentModel.Description("545:Weapon Training (missing definition)")]
		[EnumMember(Value = "Weapon Training")] 
		[XmlEnum("545")] 
		WeaponTraining = 545,

		[System.ComponentModel.Description("546:Amphibious (missing definition)")]
		[EnumMember(Value = "Amphibious")] 
		[XmlEnum("546")] 
		Amphibious = 546,

		[System.ComponentModel.Description("A signal or message warning of diving activity.")]
		[EnumMember(Value = "Diving")] 
		[XmlEnum("547")] 
		Diving = 547,

		[System.ComponentModel.Description("598:Balloons (missing definition)")]
		[EnumMember(Value = "Balloons")] 
		[XmlEnum("598")] 
		Balloons = 598,

		[System.ComponentModel.Description("599:Electrical/Optical Hazard (missing definition)")]
		[EnumMember(Value = "Electrical/Optical Hazard")] 
		[XmlEnum("599")] 
		ElectricalOpticalHazard = 599,
	}

	/// <summary>
	/// Physical condition of the coastline.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCoastline : int {
		[System.ComponentModel.Description("A coast backed by rock or earth cliffs, gives a good radar return and is useful for visual identification from a considerable distance off, where cliffs alternate with low lying coast along the shoreline.")]
		[EnumMember(Value = "Steep Coast")] 
		[XmlEnum("1")] 
		SteepCoast = 1,

		[System.ComponentModel.Description("A level coast with no obvious topographic features.")]
		[EnumMember(Value = "Flat Coast")] 
		[XmlEnum("2")] 
		FlatCoast = 2,

		[System.ComponentModel.Description("6:glacier, seaward end (missing definition)")]
		[EnumMember(Value = "glacier, seaward end")] 
		[XmlEnum("6")] 
		GlacierSeawardEnd = 6,

		[System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
		[EnumMember(Value = "Mangrove")] 
		[XmlEnum("7")] 
		Mangrove = 7,

		[System.ComponentModel.Description("A shoreline area made up of spongy land saturated with water. It may have a shallow covering of water, usually with a considerable amount of vegetation appearing above the surface.")]
		[EnumMember(Value = "Marshy Shore")] 
		[XmlEnum("8")] 
		MarshyShore = 8,

		[System.ComponentModel.Description("A vertical cliff forming the seaward edge of an ice shelf, ranging in height from 2 metres to 50 metres or more above sea level.")]
		[EnumMember(Value = "Ice Coast")] 
		[XmlEnum("10")] 
		IceCoast = 10,
	}

	/// <summary>
	/// The units for description of speed.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum speedUnits : int {
		[System.ComponentModel.Description("A unit of speed, expressing the number of kilometres travelled in one hour.")]
		[EnumMember(Value = "Kilometres Per Hour")] 
		[XmlEnum("2")] 
		KilometresPerHour = 2,

		[System.ComponentModel.Description("An imperial and United States customary unit of speed expressing the number of statute miles covered in one hour.")]
		[EnumMember(Value = "Miles Per Hour")] 
		[XmlEnum("3")] 
		MilesPerHour = 3,

		[System.ComponentModel.Description("A nautical unit of speed. One knot is one nautical mile per hour. The name is derived from the knots in the log line.")]
		[EnumMember(Value = "Knots")] 
		[XmlEnum("4")] 
		Knots = 4,
	}

	/// <summary>
	/// Classification of fixed installation buoy.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfInstallationBuoy : int {
		[System.ComponentModel.Description("Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
		[EnumMember(Value = "Catenary Anchor Leg Mooring")] 
		[XmlEnum("1")] 
		CatenaryAnchorLegMooring = 1,

		[System.ComponentModel.Description("A large mooring buoy used by tankers to load and unload in port approaches or in offshore oil and gas fields.")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		[XmlEnum("2")] 
		SingleBuoyMooring = 2,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofRestrictions : int {
		[System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
		[EnumMember(Value = "Nature Reserve")] 
		[XmlEnum("4")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("A place where birds are bred and protected.")]
		[EnumMember(Value = "Bird Sanctuary")] 
		[XmlEnum("5")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
		[EnumMember(Value = "Game Reserve")] 
		[XmlEnum("6")] 
		GameReserve = 6,

		[System.ComponentModel.Description("A place where seals are protected.")]
		[EnumMember(Value = "Seal Sanctuary")] 
		[XmlEnum("7")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
		[EnumMember(Value = "Historic Wreck Area")] 
		[XmlEnum("10")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("An area where marine research takes place.")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("A tract of land or water managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("27:Environmentally Sensitive Sea Area (ESSA) (missing definition)")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area (ESSA)")] 
		[XmlEnum("27")] 
		EnvironmentallySensitiveSeaAreaEssa = 27,

		[System.ComponentModel.Description("28:Particularly Sensitive Sea Area (PSSA) (missing definition)")]
		[EnumMember(Value = "Particularly Sensitive Sea Area (PSSA)")] 
		[XmlEnum("28")] 
		ParticularlySensitiveSeaAreaPssa = 28,

		[System.ComponentModel.Description("A place where coral is protected.")]
		[EnumMember(Value = "Coral Sanctuary")] 
		[XmlEnum("31")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
		[EnumMember(Value = "Recreation Area")] 
		[XmlEnum("32")] 
		RecreationArea = 32,
	}

	/// <summary>
	/// The degree of reliability attributed to a position.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.")]
		[EnumMember(Value = "Approximate")] 
		[XmlEnum("4")] 
		Approximate = 4,

		[System.ComponentModel.Description("Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.")]
		[EnumMember(Value = "Position Doubtful")] 
		[XmlEnum("5")] 
		PositionDoubtful = 5,
	}

	/// <summary>
	/// The jurisdiction applicable to an administrative area.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum jurisdiction : int {
		[System.ComponentModel.Description("Involving more than one country; covering more than one national area.")]
		[EnumMember(Value = "International")] 
		[XmlEnum("1")] 
		International = 1,

		[System.ComponentModel.Description("An area administered or controlled by a single nation.")]
		[EnumMember(Value = "National")] 
		[XmlEnum("2")] 
		National = 2,

		[System.ComponentModel.Description("3:National Sub-Division (missing definition)")]
		[EnumMember(Value = "National Sub-Division")] 
		[XmlEnum("3")] 
		NationalSubDivision = 3,
	}

	/// <summary>
	/// The general material which the land surface or the seabed is composed.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurface : int {
		[System.ComponentModel.Description("Soft, wet earth.")]
		[EnumMember(Value = "Mud")] 
		[XmlEnum("1")] 
		Mud = 1,

		[System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
		[EnumMember(Value = "Clay")] 
		[XmlEnum("2")] 
		Clay = 2,

		[System.ComponentModel.Description("An unconsolidated sediment whose particles range in size from 0.0039 to 0.0625 millimetres in diameter (between clay and sand size).")]
		[EnumMember(Value = "Silt")] 
		[XmlEnum("3")] 
		Silt = 3,

		[System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
		[EnumMember(Value = "Sand")] 
		[XmlEnum("4")] 
		Sand = 4,

		[System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
		[EnumMember(Value = "Stone")] 
		[XmlEnum("5")] 
		Stone = 5,

		[System.ComponentModel.Description("(Particles of 2.0 - 4.0mm); small stones with coarse sand.")]
		[EnumMember(Value = "Gravel")] 
		[XmlEnum("6")] 
		Gravel = 6,

		[System.ComponentModel.Description("A small stone worn smooth and rounded by the action of water, sand, ice, etc. ranging in diameter between 4 and 64 millimetres.")]
		[EnumMember(Value = "Pebbles")] 
		[XmlEnum("7")] 
		Pebbles = 7,

		[System.ComponentModel.Description("A naturally rounded stone larger than a pebble.")]
		[EnumMember(Value = "Cobbles")] 
		[XmlEnum("8")] 
		Cobbles = 8,

		[System.ComponentModel.Description("Any formation of natural origin that constitutes an integral part of the lithosphere. The natural occurring material that forms firm, hard, and solid masses.")]
		[EnumMember(Value = "Rock")] 
		[XmlEnum("9")] 
		Rock = 9,

		[System.ComponentModel.Description("The fluid or semi-fluid matter flowing from a volcano. The substance that results from the cooling of the molten rock. Part of the ocean bed is composed of lava.")]
		[EnumMember(Value = "Lava")] 
		[XmlEnum("11")] 
		Lava = 11,

		[System.ComponentModel.Description("Hard calcareous skeletons of many tribes of marine polyps.")]
		[EnumMember(Value = "Coral")] 
		[XmlEnum("14")] 
		Coral = 14,

		[System.ComponentModel.Description("The hard outside covering of an animal. Part of the ocean bed is composed of numerous shells of marine animals.")]
		[EnumMember(Value = "Shells")] 
		[XmlEnum("17")] 
		Shells = 17,

		[System.ComponentModel.Description("A rounded rock with diameter of 256 millimetres or larger.")]
		[EnumMember(Value = "Boulder")] 
		[XmlEnum("18")] 
		Boulder = 18,
	}

	/// <summary>
	/// The system of navigational buoyage a region complies with.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum marksNavigationalSystemOf : int {
		[System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.")]
		[EnumMember(Value = "IALA A")] 
		[XmlEnum("1")] 
		IalaA = 1,

		[System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.")]
		[EnumMember(Value = "IALA B")] 
		[XmlEnum("2")] 
		IalaB = 2,

		[System.ComponentModel.Description("Navigational aids do not conform to any defined system.")]
		[EnumMember(Value = "No System")] 
		[XmlEnum("9")] 
		NoSystem = 9,

		[System.ComponentModel.Description("Navigational aids as required in international, national or regional regulations that contain the same navigational aids as the European Code for Inland Waterways of UNECE, or if there is no regulation for a waterway, navigational aids as recommended in the European Code for Inland Waterways of UNECE")]
		[EnumMember(Value = "Main European Inland Waterway Marking System")] 
		[XmlEnum("11")] 
		MainEuropeanInlandWaterwayMarkingSystem = 11,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum magneticAnomalyDetectorSignature : int {
		[System.ComponentModel.Description("501:nil (missing definition)")]
		[EnumMember(Value = "nil")] 
		[XmlEnum("501")] 
		Nil = 501,

		[System.ComponentModel.Description("502:slight (missing definition)")]
		[EnumMember(Value = "slight")] 
		[XmlEnum("502")] 
		Slight = 502,

		[System.ComponentModel.Description("503:moderate (missing definition)")]
		[EnumMember(Value = "moderate")] 
		[XmlEnum("503")] 
		Moderate = 503,

		[System.ComponentModel.Description("Not easily broken or destroyed.")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("504")] 
		Strong = 504,
	}

	/// <summary>
	/// Numerical comparison.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("The value of the left value is greater than that of the right.")]
		[EnumMember(Value = "Greater Than")] 
		[XmlEnum("1")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right.")]
		[EnumMember(Value = "Greater Than or Equal To")] 
		[XmlEnum("2")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("The value of the left expression is less than that of the right.")]
		[EnumMember(Value = "Less Than")] 
		[XmlEnum("3")] 
		LessThan = 3,

		[System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right.")]
		[EnumMember(Value = "Less Than or Equal To")] 
		[XmlEnum("4")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("The two values are equivalent.")]
		[EnumMember(Value = "Equal To")] 
		[XmlEnum("5")] 
		EqualTo = 5,

		[System.ComponentModel.Description("The two values are not equivalent.")]
		[EnumMember(Value = "Not Equal To")] 
		[XmlEnum("6")] 
		NotEqualTo = 6,
	}

	/// <summary>
	/// Classification of the cable based on the services provided.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCable : int {
		[System.ComponentModel.Description("A cable that transmits or distributes electrical power.")]
		[EnumMember(Value = "Power Line")] 
		[XmlEnum("1")] 
		PowerLine = 1,

		[System.ComponentModel.Description("Multiple un-insulated cables usually supported by steel lattice towers. Such features are generally more prominent than normal power lines.")]
		[EnumMember(Value = "Transmission Line")] 
		[XmlEnum("3")] 
		TransmissionLine = 3,

		[System.ComponentModel.Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
		[EnumMember(Value = "Mooring Cable")] 
		[XmlEnum("6")] 
		MooringCable = 6,

		[System.ComponentModel.Description("A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.")]
		[EnumMember(Value = "Ferry")] 
		[XmlEnum("7")] 
		Ferry = 7,

		[System.ComponentModel.Description("A cable used for joining components of complex marine structures, for example mooring trots.")]
		[EnumMember(Value = "Junction Cable")] 
		[XmlEnum("9")] 
		JunctionCable = 9,

		[System.ComponentModel.Description("A cable used for the transmission and reception of modulated communication waves/signals.")]
		[EnumMember(Value = "Telecommunications Cable")] 
		[XmlEnum("10")] 
		TelecommunicationsCable = 10,
	}

	/// <summary>
	/// Classification of a wrecked or ruined ship.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfWreck : int {
		[System.ComponentModel.Description("1:non-dangerous wreck (missing definition)")]
		[EnumMember(Value = "non-dangerous wreck")] 
		[XmlEnum("1")] 
		NonDangerousWreck = 1,

		[System.ComponentModel.Description("A wreck submerged at such a depth as to be considered dangerous to surface navigation.")]
		[EnumMember(Value = "Dangerous Wreck")] 
		[XmlEnum("2")] 
		DangerousWreck = 2,

		[System.ComponentModel.Description("A substantively decayed wreck over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.")]
		[EnumMember(Value = "Distributed Remains of Wreck")] 
		[XmlEnum("3")] 
		DistributedRemainsOfWreck = 3,

		[System.ComponentModel.Description("4:wreck showing mast/masts (missing definition)")]
		[EnumMember(Value = "wreck showing mast/masts")] 
		[XmlEnum("4")] 
		WreckShowingMastMasts = 4,

		[System.ComponentModel.Description("Wreck of which any portion of the hull or superstructure is visible at the sounding datum indicated.")]
		[EnumMember(Value = "Wreck Showing Any Portion of Hull or Superstructure")] 
		[XmlEnum("5")] 
		WreckShowingAnyPortionOfHullOrSuperstructure = 5,
	}

	/// <summary>
	/// Classification of lateral marks in the IALA Buoyage System.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLateralMark : int {
		[System.ComponentModel.Description("1:port-hand lateral mark (missing definition)")]
		[EnumMember(Value = "port-hand lateral mark")] 
		[XmlEnum("1")] 
		PortHandLateralMark = 1,

		[System.ComponentModel.Description("2:starboard-hand lateral mark (missing definition)")]
		[EnumMember(Value = "starboard-hand lateral mark")] 
		[XmlEnum("2")] 
		StarboardHandLateralMark = 2,

		[System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")] 
		[XmlEnum("3")] 
		PreferredChannelToStarboardLateralMark = 3,

		[System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Port Lateral Mark")] 
		[XmlEnum("4")] 
		PreferredChannelToPortLateralMark = 4,
	}

	/// <summary>
	/// Category of the designated area
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum areaCategory : int {
		[System.ComponentModel.Description("501:Solid Red (SR) (missing definition)")]
		[EnumMember(Value = "Solid Red (SR)")] 
		[XmlEnum("501")] 
		SolidRedSr = 501,

		[System.ComponentModel.Description("502:Pecked Red (PR) (missing definition)")]
		[EnumMember(Value = "Pecked Red (PR)")] 
		[XmlEnum("502")] 
		PeckedRedPr = 502,
	}

	/// <summary>
	/// The condition of an object at a given instant in time.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum status : int {
		[System.ComponentModel.Description("Intended to last or function indefinitely.")]
		[EnumMember(Value = "Permanent")] 
		[XmlEnum("1")] 
		Permanent = 1,

		[System.ComponentModel.Description("Acting on special occasions; happening irregularly.")]
		[EnumMember(Value = "Occasional")] 
		[XmlEnum("2")] 
		Occasional = 2,

		[System.ComponentModel.Description("Presented as worthy of confidence, acceptance, use, etc.")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("3")] 
		Recommended = 3,

		[System.ComponentModel.Description("Use has ceased, but the facility still exists intact; disused.")]
		[EnumMember(Value = "Not in Use")] 
		[XmlEnum("4")] 
		NotInUse = 4,

		[System.ComponentModel.Description("5:periodic/intermittent (missing definition)")]
		[EnumMember(Value = "periodic/intermittent")] 
		[XmlEnum("5")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("Set apart for some specific use.")]
		[EnumMember(Value = "Reserved")] 
		[XmlEnum("6")] 
		Reserved = 6,

		[System.ComponentModel.Description("Meant to last only for a time.")]
		[EnumMember(Value = "Temporary")] 
		[XmlEnum("7")] 
		Temporary = 7,

		[System.ComponentModel.Description("Administered by an individual or corporation, rather than a State or a public body.")]
		[EnumMember(Value = "Private")] 
		[XmlEnum("8")] 
		Private = 8,

		[System.ComponentModel.Description("Compulsory; enforced.")]
		[EnumMember(Value = "Mandatory")] 
		[XmlEnum("9")] 
		Mandatory = 9,

		[System.ComponentModel.Description("No longer lit.")]
		[EnumMember(Value = "Extinguished")] 
		[XmlEnum("11")] 
		Extinguished = 11,

		[System.ComponentModel.Description("Lit by flood lights, strip lights, etc.")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

		[System.ComponentModel.Description("Famous in history; of historical interest.")]
		[EnumMember(Value = "Historic")] 
		[XmlEnum("13")] 
		Historic = 13,

		[System.ComponentModel.Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("14")] 
		Public = 14,

		[System.ComponentModel.Description("Occur at a time, coincide in point of time, be contemporary or simultaneous.")]
		[EnumMember(Value = "Synchronized")] 
		[XmlEnum("15")] 
		Synchronized = 15,

		[System.ComponentModel.Description("Looked at or observed over a period of time especially so as to be aware of any movement or change.")]
		[EnumMember(Value = "Watched")] 
		[XmlEnum("16")] 
		Watched = 16,

		[System.ComponentModel.Description("Usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
		[EnumMember(Value = "Unwatched")] 
		[XmlEnum("17")] 
		Unwatched = 17,

		[System.ComponentModel.Description("A feature that has been reported but has not been definitely determined to exist.")]
		[EnumMember(Value = "Existence Doubtful")] 
		[XmlEnum("18")] 
		ExistenceDoubtful = 18,

		[System.ComponentModel.Description("Marked by buoys.")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,

		[System.ComponentModel.Description("501:active/in use (missing definition)")]
		[EnumMember(Value = "active/in use")] 
		[XmlEnum("501")] 
		ActiveInUse = 501,

		[System.ComponentModel.Description("A coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.")]
		[EnumMember(Value = "Claimed")] 
		[XmlEnum("502")] 
		Claimed = 502,

		[System.ComponentModel.Description("503:practice and/or exercise purposes (missing definition)")]
		[EnumMember(Value = "practice and/or exercise purposes")] 
		[XmlEnum("503")] 
		PracticeAndOrExercisePurposes = 503,

		[System.ComponentModel.Description("acknowledged and agreed in accordance with the provisions of International Law ")]
		[EnumMember(Value = "Recognised")] 
		[XmlEnum("504")] 
		Recognised = 504,

		[System.ComponentModel.Description("not detected by repeated surveys, leading to doubts about the object's existence. (AML)")]
		[EnumMember(Value = "Dead")] 
		[XmlEnum("505")] 
		Dead = 505,

		[System.ComponentModel.Description("an object that has been salvaged or removed. (AML)")]
		[EnumMember(Value = "Lifted")] 
		[XmlEnum("506")] 
		Lifted = 506,

		[System.ComponentModel.Description("where a significant number of persons have perished as a direct result of a vessel or structure sinking and their remains cannot be recovered, the wreck and immediate area may be declared as a Mass Grave or more specifically, a War Grave. Such sites are protected from disturbance by International Law. (AML)")]
		[EnumMember(Value = "Mass Grave")] 
		[XmlEnum("507")] 
		MassGrave = 507,

		[System.ComponentModel.Description("a borehole drilled in the search for a new source of oil or gas. (An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
		[EnumMember(Value = "Exploration")] 
		[XmlEnum("508")] 
		Exploration = 508,

		[System.ComponentModel.Description("a borehole that is actively engaged in the extraction of oil or gas from the seabed. (Adapted from An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
		[EnumMember(Value = "Production")] 
		[XmlEnum("509")] 
		Production = 509,

		[System.ComponentModel.Description("a well where the extraction of oil or gas has been temporarily abandoned. When suspended, a well is either plugged (filled with concrete and topped with a steel plate) or capped (well-head equipment is installed over the well). (Adapted from An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
		[EnumMember(Value = "Suspended")] 
		[XmlEnum("510")] 
		Suspended = 510,

		[System.ComponentModel.Description("a borehole drilled for the purpose of injecting a secondary substance, for example water,  into the pore spaces in a reservoir rock to encourage oil or gas to flow into adjacent producing wells. (An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
		[EnumMember(Value = "Injection")] 
		[XmlEnum("511")] 
		Injection = 511,

		[System.ComponentModel.Description("the status of the object is unspecified.")]
		[EnumMember(Value = "Unspecified")] 
		[XmlEnum("512")] 
		Unspecified = 512,

		[System.ComponentModel.Description("temporarily quiet, inactive, not being used. (AML).")]
		[EnumMember(Value = "Dormant")] 
		[XmlEnum("516")] 
		Dormant = 516,

		[System.ComponentModel.Description("planned; intended; in accordance with, or achieved by, a careful plan made beforehand (The Concise Oxford Dictionary)")]
		[EnumMember(Value = "Proposed")] 
		[XmlEnum("517")] 
		Proposed = 517,

		[System.ComponentModel.Description("completely deserted; given up (adapted from the Concise Oxford Dictionary)")]
		[EnumMember(Value = "Abandoned")] 
		[XmlEnum("518")] 
		Abandoned = 518,

		[System.ComponentModel.Description("Area of overlap of the unilateral fishing zones of two or more countries")]
		[EnumMember(Value = "Grey zone")] 
		[XmlEnum("519")] 
		GreyZone = 519,

		[System.ComponentModel.Description("An area of the sea of indeterminate jurisdiction where no agreed boundary exist.")]
		[EnumMember(Value = "Indeterminate")] 
		[XmlEnum("520")] 
		Indeterminate = 520,

		[System.ComponentModel.Description("Involving two or more states as parties to an agreement.")]
		[EnumMember(Value = "Multilateral")] 
		[XmlEnum("521")] 
		Multilateral = 521,
	}

	/// <summary>
	/// The four quadrants (north, east, south and west) are bounded by the true bearings NW-NE, NE-SE, SE-SW and SW-NW taken from the point of interest. A cardinal mark is named after the quadrant in which it is placed. The name of the cardinal mark indicates that it should be passed to the named side of the mark.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCardinalMark : int {
		[System.ComponentModel.Description("Quadrant bounded by the true bearing NW-NE taken from the point of interest; it should be passed to the north side of the mark.")]
		[EnumMember(Value = "North Cardinal Mark")] 
		[XmlEnum("1")] 
		NorthCardinalMark = 1,

		[System.ComponentModel.Description("Quadrant bounded by the true bearing NE-SE taken from the point of interest. It should be passed to the east side of the mark.")]
		[EnumMember(Value = "East Cardinal Mark")] 
		[XmlEnum("2")] 
		EastCardinalMark = 2,

		[System.ComponentModel.Description("Quadrant bounded by the true bearing SE-SW taken from the point of interest; it should be passed to the south side of the mark.")]
		[EnumMember(Value = "South Cardinal Mark")] 
		[XmlEnum("3")] 
		SouthCardinalMark = 3,

		[System.ComponentModel.Description("Quadrant bounded by the true bearing SW-NW taken from the point of interest; it should be passed to the west side of the mark.")]
		[EnumMember(Value = "West Cardinal Mark")] 
		[XmlEnum("4")] 
		WestCardinalMark = 4,
	}

	/// <summary>
	/// Classification of airport/airfield based on the primary aircraft and user group.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAirportAirfield : int {
		[System.ComponentModel.Description("A large military airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
		[EnumMember(Value = "Military Aeroplane Airport")] 
		[XmlEnum("1")] 
		MilitaryAeroplaneAirport = 1,

		[System.ComponentModel.Description("A large airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
		[EnumMember(Value = "Civil Aeroplane Airport")] 
		[XmlEnum("2")] 
		CivilAeroplaneAirport = 2,

		[System.ComponentModel.Description("A landing place for helicopters controlled by the military.")]
		[EnumMember(Value = "Military Heliport")] 
		[XmlEnum("3")] 
		MilitaryHeliport = 3,

		[System.ComponentModel.Description("A landing place for helicopters, often the roof of a building.")]
		[EnumMember(Value = "Civil Heliport")] 
		[XmlEnum("4")] 
		CivilHeliport = 4,

		[System.ComponentModel.Description("An area of land set aside for the take-off and landing of gliders.")]
		[EnumMember(Value = "Glider Airfield")] 
		[XmlEnum("5")] 
		GliderAirfield = 5,

		[System.ComponentModel.Description("An area of land set aside for the take-off and landing of small aeroplanes.")]
		[EnumMember(Value = "Small Planes Airfield")] 
		[XmlEnum("6")] 
		SmallPlanesAirfield = 6,

		[System.ComponentModel.Description("An area of land set aside for the take-off and landing of aeroplanes or helicopters in times of emergency.")]
		[EnumMember(Value = "Emergency Airfield")] 
		[XmlEnum("8")] 
		EmergencyAirfield = 8,

		[System.ComponentModel.Description("9:search and rescue (missing definition)")]
		[EnumMember(Value = "search and rescue")] 
		[XmlEnum("9")] 
		SearchAndRescue = 9,
	}

	/// <summary>
	/// Survey method used to obtain depth information.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum techniqueOfVerticalMeasurement : int {
		[System.ComponentModel.Description("The depth was measured by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		[XmlEnum("1")] 
		FoundByEchoSounder = 1,

		[System.ComponentModel.Description("The depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the seabed and generate a record of the seabed configuration.")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		[XmlEnum("2")] 
		FoundBySideScanSonar = 2,

		[System.ComponentModel.Description("The depth was measured by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.")]
		[EnumMember(Value = "Found by Multi Beam")] 
		[XmlEnum("3")] 
		FoundByMultiBeam = 3,

		[System.ComponentModel.Description("The depth was determined by a person skilled in the practice of diving.")]
		[EnumMember(Value = "Found by Diver")] 
		[XmlEnum("4")] 
		FoundByDiver = 4,

		[System.ComponentModel.Description("The depth was measured by using a line, graduated with attached marks and fastened to a sounding lead.")]
		[EnumMember(Value = "Found by Lead Line")] 
		[XmlEnum("5")] 
		FoundByLeadLine = 5,

		[System.ComponentModel.Description("The given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.")]
		[EnumMember(Value = "Swept by Vertical Acoustic System")] 
		[XmlEnum("8")] 
		SweptByVerticalAcousticSystem = 8,

		[System.ComponentModel.Description("The depth was determined by using an instrument that compares electromagnetic signals.")]
		[EnumMember(Value = "Found by Electromagnetic Sensor")] 
		[XmlEnum("9")] 
		FoundByElectromagneticSensor = 9,

		[System.ComponentModel.Description("The science or art of obtaining reliable measurements from photographs.")]
		[EnumMember(Value = "Photogrammetry")] 
		[XmlEnum("10")] 
		Photogrammetry = 10,

		[System.ComponentModel.Description("The depth was determined by using instruments placed aboard an artificial satellite.")]
		[EnumMember(Value = "Satellite Imagery")] 
		[XmlEnum("11")] 
		SatelliteImagery = 11,

		[System.ComponentModel.Description("12:found by leveling (missing definition)")]
		[EnumMember(Value = "found by leveling")] 
		[XmlEnum("12")] 
		FoundByLeveling = 12,

		[System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a side scan sonar.")]
		[EnumMember(Value = "Swept by Side Scan Sonar")] 
		[XmlEnum("13")] 
		SweptBySideScanSonar = 13,

		[System.ComponentModel.Description("The depth was measured by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
		[EnumMember(Value = "Found by LIDAR")] 
		[XmlEnum("15")] 
		FoundByLidar = 15,

		[System.ComponentModel.Description("A radar with a synthetic aperture antenna which is composed of a large number of elementary transducing elements. The signals are electronically combined into a resulting signal equivalent to that of a single antenna of a given aperture in a given direction.")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		[XmlEnum("16")] 
		SyntheticApertureRadar = 16,

		[System.ComponentModel.Description("Term used to describe the imagery derived from subdividing the electromagnetic spectrum into very narrow bandwidths. These narrow bandwidths may be combined with or subtracted from each other in various ways to form images useful in precise terrain or target analysis.")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		[XmlEnum("17")] 
		HyperspectralImagery = 17,

		[System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a line or object below the surface at the desired depth; or least depth(s) and position(s) within an area was identified using the same technique.")]
		[EnumMember(Value = "Mechanically Swept")] 
		[XmlEnum("18")] 
		MechanicallySwept = 18,
	}

	/// <summary>
	/// The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("3")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("13")] 
		LowWater = 13,

		[System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean High Water")] 
		[XmlEnum("16")] 
		MeanHighWater = 16,

		[System.ComponentModel.Description("The average height of the high waters of spring tides.")]
		[EnumMember(Value = "Mean High Water Springs")] 
		[XmlEnum("17")] 
		MeanHighWaterSprings = 17,

		[System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
		[EnumMember(Value = "High Water")] 
		[XmlEnum("18")] 
		HighWater = 18,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("19")] 
		ApproximateMeanSeaLevel = 19,

		[System.ComponentModel.Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
		[EnumMember(Value = "High Water Springs")] 
		[XmlEnum("20")] 
		HighWaterSprings = 20,

		[System.ComponentModel.Description("The average height of higher high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Higher High Water")] 
		[XmlEnum("21")] 
		MeanHigherHighWater = 21,

		[System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("24")] 
		LocalDatum = 24,

		[System.ComponentModel.Description("25:international great (missing definition)")]
		[EnumMember(Value = "international great")] 
		[XmlEnum("25")] 
		InternationalGreat = 25,

		[System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("26")] 
		MeanWaterLevel = 26,

		[System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		[XmlEnum("28")] 
		HigherHighWaterLargeTide = 28,

		[System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		[XmlEnum("29")] 
		NearlyHighestHighWater = 29,

		[System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		[XmlEnum("30")] 
		HighestAstronomicalTide = 30,

		[System.ComponentModel.Description("44:Baltic Sea Chart Datum (missing definition)")]
		[EnumMember(Value = "Baltic Sea Chart Datum")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum = 44,

		[System.ComponentModel.Description("501:Mean Tide Level (missing definition)")]
		[EnumMember(Value = "Mean Tide Level")] 
		[XmlEnum("501")] 
		MeanTideLevel = 501,
	}

	/// <summary>
	/// The outward display of the light.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum exhibitionConditionOfLight : int {
		[System.ComponentModel.Description("A light shown throughout the 24 hours without change of character.")]
		[EnumMember(Value = "Light Shown Without Change of Character")] 
		[XmlEnum("1")] 
		LightShownWithoutChangeOfCharacter = 1,

		[System.ComponentModel.Description("A light which is only exhibited by day.")]
		[EnumMember(Value = "Daytime Light")] 
		[XmlEnum("2")] 
		DaytimeLight = 2,

		[System.ComponentModel.Description("A light which is exhibited in fog or conditions of reduced visibility.")]
		[EnumMember(Value = "Fog Light")] 
		[XmlEnum("3")] 
		FogLight = 3,

		[System.ComponentModel.Description("A light which is only exhibited at night.")]
		[EnumMember(Value = "Night Light")] 
		[XmlEnum("4")] 
		NightLight = 4,
	}

	/// <summary>
	/// Classification of different light types.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLight : int {
		[System.ComponentModel.Description("A light associated with other lights so as to form a leading line to be followed.")]
		[EnumMember(Value = "Leading Light")] 
		[XmlEnum("4")] 
		LeadingLight = 4,

		[System.ComponentModel.Description("An aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.")]
		[EnumMember(Value = "Aero Light")] 
		[XmlEnum("5")] 
		AeroLight = 5,

		[System.ComponentModel.Description("A broad beam light used to illuminate a structure or area.")]
		[EnumMember(Value = "Flood Light")] 
		[XmlEnum("8")] 
		FloodLight = 8,

		[System.ComponentModel.Description("A light whose source has a linear form generally horizontal, which can reach a length of several metres.")]
		[EnumMember(Value = "Strip Light")] 
		[XmlEnum("9")] 
		StripLight = 9,

		[System.ComponentModel.Description("A light placed on or near the support of a main light and having a special use in navigation.")]
		[EnumMember(Value = "Subsidiary Light")] 
		[XmlEnum("10")] 
		SubsidiaryLight = 10,

		[System.ComponentModel.Description("A powerful light focused so as to illuminate a small area.")]
		[EnumMember(Value = "Spotlight")] 
		[XmlEnum("11")] 
		Spotlight = 11,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Front")] 
		[XmlEnum("12")] 
		Front = 12,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Rear")] 
		[XmlEnum("13")] 
		Rear = 13,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Lower")] 
		[XmlEnum("14")] 
		Lower = 14,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Upper")] 
		[XmlEnum("15")] 
		Upper = 15,

		[System.ComponentModel.Description("A light available as a backup to a main light which will be illuminated should the main light fail.")]
		[EnumMember(Value = "Emergency")] 
		[XmlEnum("17")] 
		Emergency = 17,

		[System.ComponentModel.Description("A light which enables its approximate bearing to be obtained without the use of a compass.")]
		[EnumMember(Value = "Bearing Light")] 
		[XmlEnum("18")] 
		BearingLight = 18,

		[System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed horizontally.")]
		[EnumMember(Value = "Horizontally Disposed")] 
		[XmlEnum("19")] 
		HorizontallyDisposed = 19,

		[System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed vertically.")]
		[EnumMember(Value = "Vertically Disposed")] 
		[XmlEnum("20")] 
		VerticallyDisposed = 20,
	}

	/// <summary>
	/// Direction of vessels passing a reference point.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum trafficFlow : int {
		[System.ComponentModel.Description("Traffic flow in a general direction toward a port or similar destination.")]
		[EnumMember(Value = "Inbound")] 
		[XmlEnum("1")] 
		Inbound = 1,

		[System.ComponentModel.Description("Traffic flow in a general direction away from a port or similar point of origin.")]
		[EnumMember(Value = "Outbound")] 
		[XmlEnum("2")] 
		Outbound = 2,

		[System.ComponentModel.Description("3:one-way (missing definition)")]
		[EnumMember(Value = "one-way")] 
		[XmlEnum("3")] 
		OneWay = 3,

		[System.ComponentModel.Description("4:two-way (missing definition)")]
		[EnumMember(Value = "two-way")] 
		[XmlEnum("4")] 
		TwoWay = 4,
	}

	/// <summary>
	/// The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[System.ComponentModel.Description("The achromatic object colour of greatest lightness characteristically perceived to belong to objects that reflect diffusely nearly all incident energy throughout the visible spectrum.")]
		[EnumMember(Value = "White")] 
		[XmlEnum("1")] 
		White = 1,

		[System.ComponentModel.Description("The achromatic color of least lightness characteristically perceived to belong to objects that neither reflect nor transmit light.")]
		[EnumMember(Value = "Black")] 
		[XmlEnum("2")] 
		Black = 2,

		[System.ComponentModel.Description("A color whose hue resembles that of blood or of the ruby or is that of the long-wave extreme of the visible spectrum.")]
		[EnumMember(Value = "Red")] 
		[XmlEnum("3")] 
		Red = 3,

		[System.ComponentModel.Description("Of the color green.")]
		[EnumMember(Value = "Green")] 
		[XmlEnum("4")] 
		Green = 4,

		[System.ComponentModel.Description("A color whose hue is that of the clear sky or that of the portion of the color spectrum lying between green and violet.")]
		[EnumMember(Value = "Blue")] 
		[XmlEnum("5")] 
		Blue = 5,

		[System.ComponentModel.Description("A color whose hue resembles that of ripe lemons or sunflowers or is that of the portion of the spectrum lying between green and orange.")]
		[EnumMember(Value = "Yellow")] 
		[XmlEnum("6")] 
		Yellow = 6,

		[System.ComponentModel.Description("Of the color grey.")]
		[EnumMember(Value = "Grey")] 
		[XmlEnum("7")] 
		Grey = 7,

		[System.ComponentModel.Description("Any of a group of colors between red and yellow in hue, of medium to low lightness, and of moderate to low saturation.")]
		[EnumMember(Value = "Brown")] 
		[XmlEnum("8")] 
		Brown = 8,

		[System.ComponentModel.Description("A variable color averaging a dark orange yellow.")]
		[EnumMember(Value = "Amber")] 
		[XmlEnum("9")] 
		Amber = 9,

		[System.ComponentModel.Description("Any of a group of colors of reddish-blue hue, low lightness, and medium saturation.")]
		[EnumMember(Value = "Violet")] 
		[XmlEnum("10")] 
		Violet = 10,

		[System.ComponentModel.Description("Any of a group of colors that are between red and yellow in hue.")]
		[EnumMember(Value = "Orange")] 
		[XmlEnum("11")] 
		Orange = 11,

		[System.ComponentModel.Description("A deep purplish red.")]
		[EnumMember(Value = "Magenta")] 
		[XmlEnum("12")] 
		Magenta = 12,

		[System.ComponentModel.Description("Any of a group of colors bluish red to red in hue, of medium to high lightness, and of low to moderate saturation.")]
		[EnumMember(Value = "Pink")] 
		[XmlEnum("13")] 
		Pink = 13,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofBoundaryLine : int {
		[System.ComponentModel.Description("A line of demarcation between controlled areas.")]
		[EnumMember(Value = "Administrative Boundary")] 
		[XmlEnum("501")] 
		AdministrativeBoundary = 501,

		[System.ComponentModel.Description("506:de facto boundary (missing definition)")]
		[EnumMember(Value = "de facto boundary")] 
		[XmlEnum("506")] 
		DeFactoBoundary = 506,

		[System.ComponentModel.Description("511:International Maritime Boundary (missing definition)")]
		[EnumMember(Value = "International Maritime Boundary")] 
		[XmlEnum("511")] 
		InternationalMaritimeBoundary = 511,

		[System.ComponentModel.Description("A line every point of which is equidistant from the nearest points on the baselines of two or more states between which it lies.")]
		[EnumMember(Value = "Median Line")] 
		[XmlEnum("599")] 
		MedianLine = 599,
	}

	/// <summary>
	/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum soundingDatum : int {
		[System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		[XmlEnum("501")] 
		MeanLowWaterSprings = 501,

		[System.ComponentModel.Description("The average height of lower low water springs at a place.")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		[XmlEnum("502")] 
		MeanLowerLowWaterSprings = 502,

		[System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("503")] 
		MeanSeaLevel = 503,

		[System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.")]
		[EnumMember(Value = "Lowest Low Water")] 
		[XmlEnum("504")] 
		LowestLowWater = 504,

		[System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Low Water")] 
		[XmlEnum("505")] 
		MeanLowWater = 505,

		[System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		[XmlEnum("506")] 
		LowestLowWaterSprings = 506,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		[XmlEnum("507")] 
		ApproximateMeanLowWaterSprings = 507,

		[System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		[XmlEnum("508")] 
		IndianSpringLowWater = 508,

		[System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
		[EnumMember(Value = "Low Water Springs")] 
		[XmlEnum("509")] 
		LowWaterSprings = 509,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		[XmlEnum("510")] 
		ApproximateLowestAstronomicalTide = 510,

		[System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		[XmlEnum("511")] 
		NearlyLowestLowWater = 511,

		[System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		[XmlEnum("512")] 
		MeanLowerLowWater = 512,

		[System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("513")] 
		LowWater = 513,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		[XmlEnum("514")] 
		ApproximateMeanLowWater = 514,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		[XmlEnum("515")] 
		ApproximateMeanLowerLowWater = 515,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("519")] 
		ApproximateMeanSeaLevel = 519,

		[System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		[XmlEnum("522")] 
		EquinoctialSpringLowWater = 522,

		[System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		[XmlEnum("523")] 
		LowestAstronomicalTide = 523,

		[System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("524")] 
		LocalDatum = 524,

		[System.ComponentModel.Description("525:International Great Lakes Datum 1985 (IGLD 1985) (missing definition)")]
		[EnumMember(Value = "International Great Lakes Datum 1985 (IGLD 1985)")] 
		[XmlEnum("525")] 
		InternationalGreatLakesDatum1985Igld1985 = 525,

		[System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("526")] 
		MeanWaterLevel = 526,

		[System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		[XmlEnum("527")] 
		LowerLowWaterLargeTide = 527,

		[System.ComponentModel.Description("531:Mean Tide Level (missing definition)")]
		[EnumMember(Value = "Mean Tide Level")] 
		[XmlEnum("531")] 
		MeanTideLevel = 531,

		[System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("532")] 
		BalticSeaChartDatum2000 = 532,
	}

	/// <summary>
	/// Classification of an aid to navigation which signifies some special purpose.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSpecialPurposeMark : int {
		[System.ComponentModel.Description("1:firing danger area mark (missing definition)")]
		[EnumMember(Value = "firing danger area mark")] 
		[XmlEnum("1")] 
		FiringDangerAreaMark = 1,

		[System.ComponentModel.Description("Any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.")]
		[EnumMember(Value = "Target Mark")] 
		[XmlEnum("2")] 
		TargetMark = 2,

		[System.ComponentModel.Description("A mark marking the position of a ship which is used as a target during some military exercise.")]
		[EnumMember(Value = "Marker Ship Mark")] 
		[XmlEnum("3")] 
		MarkerShipMark = 3,

		[System.ComponentModel.Description("A mark used to indicate a degaussing range.")]
		[EnumMember(Value = "Degaussing Range Mark")] 
		[XmlEnum("4")] 
		DegaussingRangeMark = 4,

		[System.ComponentModel.Description("A mark of relevance to barges.")]
		[EnumMember(Value = "Barge Mark")] 
		[XmlEnum("5")] 
		BargeMark = 5,

		[System.ComponentModel.Description("A mark used to indicate the position of submarine cables or the point at which they run on to the land.")]
		[EnumMember(Value = "Cable Mark")] 
		[XmlEnum("6")] 
		CableMark = 6,

		[System.ComponentModel.Description("A mark used to indicate the limit of a spoil ground.")]
		[EnumMember(Value = "Spoil Ground Mark")] 
		[XmlEnum("7")] 
		SpoilGroundMark = 7,

		[System.ComponentModel.Description("A mark used to indicate the position of an outfall or the point at which it leaves the land.")]
		[EnumMember(Value = "Outfall Mark")] 
		[XmlEnum("8")] 
		OutfallMark = 8,

		[System.ComponentModel.Description("Ocean Data Acquisition System.")]
		[EnumMember(Value = "ODAS")] 
		[XmlEnum("9")] 
		Odas = 9,

		[System.ComponentModel.Description("A mark used to record data for scientific purposes.")]
		[EnumMember(Value = "Recording Mark")] 
		[XmlEnum("10")] 
		RecordingMark = 10,

		[System.ComponentModel.Description("An area in which seaplanes anchor or may anchor.")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		[XmlEnum("11")] 
		SeaplaneAnchorage = 11,

		[System.ComponentModel.Description("A mark used to indicate a recreation zone.")]
		[EnumMember(Value = "Recreation Zone Mark")] 
		[XmlEnum("12")] 
		RecreationZoneMark = 12,

		[System.ComponentModel.Description("A mark indicating a mooring or moorings.")]
		[EnumMember(Value = "Mooring Mark")] 
		[XmlEnum("14")] 
		MooringMark = 14,

		[System.ComponentModel.Description("A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
		[EnumMember(Value = "LANBY")] 
		[XmlEnum("15")] 
		Lanby = 15,

		[System.ComponentModel.Description("Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
		[EnumMember(Value = "Leading Mark")] 
		[XmlEnum("16")] 
		LeadingMark = 16,

		[System.ComponentModel.Description("A course at sea, whose ends are indicated by ranges ashore, and whose length has been accurately measured for determining the speed of vessels.")]
		[EnumMember(Value = "Measured Distance")] 
		[XmlEnum("17")] 
		MeasuredDistance = 17,

		[System.ComponentModel.Description("A notice board or sign indicating information to the mariner.")]
		[EnumMember(Value = "Notice Mark")] 
		[XmlEnum("18")] 
		NoticeMark = 18,

		[System.ComponentModel.Description("19:TSS mark (Traffic Separation Scheme) (missing definition)")]
		[EnumMember(Value = "TSS mark (Traffic Separation Scheme)")] 
		[XmlEnum("19")] 
		TssMarkTrafficSeparationScheme = 19,

		[System.ComponentModel.Description("An area within which anchoring is not permitted.")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		[XmlEnum("20")] 
		AnchoringProhibited = 20,

		[System.ComponentModel.Description("A mark indicating that berthing is prohibited.")]
		[EnumMember(Value = "Berthing Prohibited Mark")] 
		[XmlEnum("21")] 
		BerthingProhibitedMark = 21,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking is generally prohibited.")]
		[EnumMember(Value = "Overtaking Prohibited")] 
		[XmlEnum("22")] 
		OvertakingProhibited = 22,

		[System.ComponentModel.Description("23:two-way traffic prohibited mark (missing definition)")]
		[EnumMember(Value = "two-way traffic prohibited mark")] 
		[XmlEnum("23")] 
		TwoWayTrafficProhibitedMark = 23,

		[System.ComponentModel.Description("A mark indicating that vessels must not generate excessive wake.")]
		[EnumMember(Value = "Reduced Wake Mark")] 
		[XmlEnum("24")] 
		ReducedWakeMark = 24,

		[System.ComponentModel.Description("A mark indicating that a speed limit applies.")]
		[EnumMember(Value = "Speed Limit Mark")] 
		[XmlEnum("25")] 
		SpeedLimitMark = 25,

		[System.ComponentModel.Description("A mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
		[EnumMember(Value = "Stop Mark")] 
		[XmlEnum("26")] 
		StopMark = 26,

		[System.ComponentModel.Description("A mark indicating that special caution must be exercised in the vicinity of the mark.")]
		[EnumMember(Value = "General Warning Mark")] 
		[XmlEnum("27")] 
		GeneralWarningMark = 27,

		[System.ComponentModel.Description("28:sound ship’s siren mark (missing definition)")]
		[EnumMember(Value = "sound ship’s siren mark")] 
		[XmlEnum("28")] 
		SoundShipSSirenMark = 28,

		[System.ComponentModel.Description("29:restricted vertical (missing definition)")]
		[EnumMember(Value = "restricted vertical")] 
		[XmlEnum("29")] 
		RestrictedVertical = 29,

		[System.ComponentModel.Description("30:maximum vessel’s draught mark (missing definition)")]
		[EnumMember(Value = "maximum vessel’s draught mark")] 
		[XmlEnum("30")] 
		MaximumVesselSDraughtMark = 30,

		[System.ComponentModel.Description("A mark indicating the minimum horizontal space available for passage.")]
		[EnumMember(Value = "Restricted Horizontal Clearance Mark")] 
		[XmlEnum("31")] 
		RestrictedHorizontalClearanceMark = 31,

		[System.ComponentModel.Description("A mark warning of strong currents.")]
		[EnumMember(Value = "Strong Current Warning Mark")] 
		[XmlEnum("32")] 
		StrongCurrentWarningMark = 32,

		[System.ComponentModel.Description("A mark indicating that berthing is allowed.")]
		[EnumMember(Value = "Berthing Permitted Mark")] 
		[XmlEnum("33")] 
		BerthingPermittedMark = 33,

		[System.ComponentModel.Description("A mark indicating an overhead power cable.")]
		[EnumMember(Value = "Overhead Power Cable Mark")] 
		[XmlEnum("34")] 
		OverheadPowerCableMark = 34,

		[System.ComponentModel.Description("A mark indicating the gradient of the slope of a dredge channel edge.")]
		[EnumMember(Value = "Channel Edge Gradient Mark")] 
		[XmlEnum("35")] 
		ChannelEdgeGradientMark = 35,

		[System.ComponentModel.Description("A mark indicating the presence of a telephone.")]
		[EnumMember(Value = "Telephone Mark")] 
		[XmlEnum("36")] 
		TelephoneMark = 36,

		[System.ComponentModel.Description("A mark indicating that a ferry route crosses the ship route; often used with a 'sound ship's siren' mark.")]
		[EnumMember(Value = "Ferry Crossing Mark")] 
		[XmlEnum("37")] 
		FerryCrossingMark = 37,

		[System.ComponentModel.Description("A mark used to indicate the position of submarine pipelines or the point at which they run on to the land.")]
		[EnumMember(Value = "Pipeline Mark")] 
		[XmlEnum("39")] 
		PipelineMark = 39,

		[System.ComponentModel.Description("A mark indicating an anchorage area.")]
		[EnumMember(Value = "Anchorage Mark")] 
		[XmlEnum("40")] 
		AnchorageMark = 40,

		[System.ComponentModel.Description("A mark used to indicate a clearing line.")]
		[EnumMember(Value = "Clearing Mark")] 
		[XmlEnum("41")] 
		ClearingMark = 41,

		[System.ComponentModel.Description("A mark indicating the location at which a restriction or requirement exists.")]
		[EnumMember(Value = "Control Mark")] 
		[XmlEnum("42")] 
		ControlMark = 42,

		[System.ComponentModel.Description("A mark indicating that diving may take place in the vicinity.")]
		[EnumMember(Value = "Diving Mark")] 
		[XmlEnum("43")] 
		DivingMark = 43,

		[System.ComponentModel.Description("A mark providing or indicating a place of safety.")]
		[EnumMember(Value = "Refuge Beacon")] 
		[XmlEnum("44")] 
		RefugeBeacon = 44,

		[System.ComponentModel.Description("A mark indicating a foul ground.")]
		[EnumMember(Value = "Foul Ground Mark")] 
		[XmlEnum("45")] 
		FoulGroundMark = 45,

		[System.ComponentModel.Description("A mark installed for use by yachtsmen.")]
		[EnumMember(Value = "Yachting Mark")] 
		[XmlEnum("46")] 
		YachtingMark = 46,

		[System.ComponentModel.Description("A mark indicating an area where helicopters may land.")]
		[EnumMember(Value = "Heliport Mark")] 
		[XmlEnum("47")] 
		HeliportMark = 47,

		[System.ComponentModel.Description("A mark indicating a location at which a GNSS position has been accurately determined.")]
		[EnumMember(Value = "GNSS Mark")] 
		[XmlEnum("48")] 
		GnssMark = 48,

		[System.ComponentModel.Description("A mark indicating an area where seaplanes land.")]
		[EnumMember(Value = "Seaplane Landing Mark")] 
		[XmlEnum("49")] 
		SeaplaneLandingMark = 49,

		[System.ComponentModel.Description("A mark indicating that entry is prohibited.")]
		[EnumMember(Value = "Entry Prohibited Mark")] 
		[XmlEnum("50")] 
		EntryProhibitedMark = 50,

		[System.ComponentModel.Description("A mark indicating that work (generally construction) is in progress.")]
		[EnumMember(Value = "Work in Progress Mark")] 
		[XmlEnum("51")] 
		WorkInProgressMark = 51,

		[System.ComponentModel.Description("52:mark with unknown (missing definition)")]
		[EnumMember(Value = "mark with unknown")] 
		[XmlEnum("52")] 
		MarkWithUnknown = 52,

		[System.ComponentModel.Description("A mark indicating a borehole that produces or is capable of producing oil or natural gas.")]
		[EnumMember(Value = "Wellhead Mark")] 
		[XmlEnum("53")] 
		WellheadMark = 53,

		[System.ComponentModel.Description("A mark indicating the point at which a channel divides separately into two channels.")]
		[EnumMember(Value = "Channel Separation Mark")] 
		[XmlEnum("54")] 
		ChannelSeparationMark = 54,

		[System.ComponentModel.Description("A mark indicating the existence of a fish, mussel, oyster or pearl farm/culture.")]
		[EnumMember(Value = "Marine Farm Mark")] 
		[XmlEnum("55")] 
		MarineFarmMark = 55,

		[System.ComponentModel.Description("A mark indicating the existence or the extent of an artificial reef.")]
		[EnumMember(Value = "Artificial Reef Mark")] 
		[XmlEnum("56")] 
		ArtificialReefMark = 56,

		[System.ComponentModel.Description("A mark, used year round, that may be submerged when ice passes through the area.")]
		[EnumMember(Value = "Ice Mark")] 
		[XmlEnum("57")] 
		IceMark = 57,

		[System.ComponentModel.Description("A mark used to define the boundary of a nature reserve.")]
		[EnumMember(Value = "Nature Reserve Mark")] 
		[XmlEnum("58")] 
		NatureReserveMark = 58,

		[System.ComponentModel.Description("A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.")]
		[EnumMember(Value = "Fish Aggregating Device")] 
		[XmlEnum("59")] 
		FishAggregatingDevice = 59,

		[System.ComponentModel.Description("A mark used to indicate the existence of a wreck.")]
		[EnumMember(Value = "Wreck Mark")] 
		[XmlEnum("60")] 
		WreckMark = 60,

		[System.ComponentModel.Description("A mark used to indicate the existence of a customs checkpoint.")]
		[EnumMember(Value = "Customs Mark")] 
		[XmlEnum("61")] 
		CustomsMark = 61,

		[System.ComponentModel.Description("A mark used to indicate the existence of a causeway.")]
		[EnumMember(Value = "Causeway Mark")] 
		[XmlEnum("62")] 
		CausewayMark = 62,

		[System.ComponentModel.Description("A surface following buoy used to measure wave activity.")]
		[EnumMember(Value = "Wave Recorder")] 
		[XmlEnum("63")] 
		WaveRecorder = 63,
	}

	/// <summary>
	/// The system of measurement used to define the depth.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum depthUnits : int {
		[System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPatrolArea : int {
		[System.ComponentModel.Description("501:4W disposition grid (missing definition)")]
		[EnumMember(Value = "4W disposition grid")] 
		[XmlEnum("501")] 
		fourwDispositionGrid = 501,

		[System.ComponentModel.Description("502:Operational/Naval Patrol (missing definition)")]
		[EnumMember(Value = "Operational/Naval Patrol")] 
		[XmlEnum("502")] 
		OperationalNavalPatrol = 502,
	}

	/// <summary>
	/// (1) The change of any quantity with distance in any given direction. See Pressure Gradient, Temperature Lapse Rate. (2) The amount of slope, inclination to the horizontal, in road, railway, etc.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum gradient : int {
		[System.ComponentModel.Description("501:Steep (missing definition)")]
		[EnumMember(Value = "Steep")] 
		[XmlEnum("501")] 
		Steep = 501,

		[System.ComponentModel.Description("502:Moderate (missing definition)")]
		[EnumMember(Value = "Moderate")] 
		[XmlEnum("502")] 
		Moderate = 502,

		[System.ComponentModel.Description("503:Gentle (missing definition)")]
		[EnumMember(Value = "Gentle")] 
		[XmlEnum("503")] 
		Gentle = 503,

		[System.ComponentModel.Description("504:Mild (missing definition)")]
		[EnumMember(Value = "Mild")] 
		[XmlEnum("504")] 
		Mild = 504,

		[System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
		[EnumMember(Value = "Flat")] 
		[XmlEnum("505")] 
		Flat = 505,
	}

	/// <summary>
	/// The angle of the major axis of the object expressed to the nearest 45 degrees using cardinal compass point notation.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalPointOrientation : int {
		[System.ComponentModel.Description("501:north/south (missing definition)")]
		[EnumMember(Value = "north/south")] 
		[XmlEnum("501")] 
		NorthSouth = 501,

		[System.ComponentModel.Description("502:east/west (missing definition)")]
		[EnumMember(Value = "east/west")] 
		[XmlEnum("502")] 
		EastWest = 502,

		[System.ComponentModel.Description("503:northeast/southwest (missing definition)")]
		[EnumMember(Value = "northeast/southwest")] 
		[XmlEnum("503")] 
		NortheastSouthwest = 503,

		[System.ComponentModel.Description("504:northwest/southeast (missing definition)")]
		[EnumMember(Value = "northwest/southeast")] 
		[XmlEnum("504")] 
		NorthwestSoutheast = 504,
	}

	/// <summary>
	/// The official legal status of each kind of restricted area defines the kind of restriction(s), for example the restriction for a 'game reserve' may be 'entering prohibited'.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRestrictedArea : int {
		[System.ComponentModel.Description("The area around an offshore installation within which vessels are prohibited from entering without permission. Special regulations protect installations within a safety zone and vessels of all nationalities are required to respect the zone.")]
		[EnumMember(Value = "Offshore Safety Zone")] 
		[XmlEnum("1")] 
		OffshoreSafetyZone = 1,

		[System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
		[EnumMember(Value = "Nature Reserve")] 
		[XmlEnum("4")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("A place where birds are bred and protected.")]
		[EnumMember(Value = "Bird Sanctuary")] 
		[XmlEnum("5")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
		[EnumMember(Value = "Game Reserve")] 
		[XmlEnum("6")] 
		GameReserve = 6,

		[System.ComponentModel.Description("A place where seals are protected.")]
		[EnumMember(Value = "Seal Sanctuary")] 
		[XmlEnum("7")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the seabed in the range and there are cables leading from the range to a control position ashore.")]
		[EnumMember(Value = "Degaussing Range")] 
		[XmlEnum("8")] 
		DegaussingRange = 8,

		[System.ComponentModel.Description("An area controlled by the military in which restrictions may apply.")]
		[EnumMember(Value = "Military Area")] 
		[XmlEnum("9")] 
		MilitaryArea = 9,

		[System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
		[EnumMember(Value = "Historic Wreck Area")] 
		[XmlEnum("10")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("An area around a navigational aid which vessels are prohibited from entering.")]
		[EnumMember(Value = "Navigational Aid Safety Zone")] 
		[XmlEnum("12")] 
		NavigationalAidSafetyZone = 12,

		[System.ComponentModel.Description("An area laid and maintained with explosive mines for defence or practice purposes.")]
		[EnumMember(Value = "Minefield")] 
		[XmlEnum("14")] 
		Minefield = 14,

		[System.ComponentModel.Description("An area in which people may swim and therefore vessel movement may be restricted.")]
		[EnumMember(Value = "Swimming Area")] 
		[XmlEnum("18")] 
		SwimmingArea = 18,

		[System.ComponentModel.Description("An area reserved for vessels waiting to enter a harbour.")]
		[EnumMember(Value = "Waiting Area")] 
		[XmlEnum("19")] 
		WaitingArea = 19,

		[System.ComponentModel.Description("An area where marine research takes place.")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("An area where dredging is taking place.")]
		[EnumMember(Value = "Dredging Area")] 
		[XmlEnum("21")] 
		DredgingArea = 21,

		[System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("A tract of land or water managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
		[EnumMember(Value = "No Wake Area")] 
		[XmlEnum("24")] 
		NoWakeArea = 24,

		[System.ComponentModel.Description("An area where vessels turn.")]
		[EnumMember(Value = "Swinging Area")] 
		[XmlEnum("25")] 
		SwingingArea = 25,

		[System.ComponentModel.Description("A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area")] 
		[XmlEnum("27")] 
		EnvironmentallySensitiveSeaArea = 27,

		[System.ComponentModel.Description("An area that needs special protection through action by IMO because of its significance for regional ecological, socio-economic or scientific reasons and because it may be vulnerable to damage by international shipping activities.")]
		[EnumMember(Value = "Particularly Sensitive Sea Area")] 
		[XmlEnum("28")] 
		ParticularlySensitiveSeaArea = 28,

		[System.ComponentModel.Description("An area near a fairway where vessels can go to clear the way or make an about turn and possibly return to a waiting area when nautical conditions impose it.")]
		[EnumMember(Value = "Disengagement Area")] 
		[XmlEnum("29")] 
		DisengagementArea = 29,

		[System.ComponentModel.Description("An area in which defence, law and treaty enforcement, and counter-terrorism activities that fall within the port and maritime domain apply.")]
		[EnumMember(Value = "Port Security Area")] 
		[XmlEnum("30")] 
		PortSecurityArea = 30,

		[System.ComponentModel.Description("A place where coral is protected.")]
		[EnumMember(Value = "Coral Sanctuary")] 
		[XmlEnum("31")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
		[EnumMember(Value = "Recreation Area")] 
		[XmlEnum("32")] 
		RecreationArea = 32,

		[System.ComponentModel.Description("An area within which notification is required between respective military authorities of future military exercises/activities.")]
		[EnumMember(Value = "Maritime Notification Area")] 
		[XmlEnum("501")] 
		MaritimeNotificationArea = 501,
	}

	/// <summary>
	/// Indicates the relationship of the depth of a feature to the range of depth of the surrounding depth area.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum expositionOfSounding : int {
		[System.ComponentModel.Description("The depth corresponds to the depth range of the surrounding depth area; that is, the depth is not shoaler than the minimum depth of the surrounding depth area or deeper than the maximum depth of the surrounding depth area.")]
		[EnumMember(Value = "Within the Range of Depth of the Surrounding Depth Area")] 
		[XmlEnum("1")] 
		WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,

		[System.ComponentModel.Description("The depth is shoaler than the minimum depth of the surrounding depth area.")]
		[EnumMember(Value = "Shoaler Than the Range of Depth of the Surrounding Depth Area")] 
		[XmlEnum("2")] 
		ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,

		[System.ComponentModel.Description("The depth is deeper than the maximum depth of the surrounding depth area.")]
		[EnumMember(Value = "Deeper Than the Range of Depth of the Surrounding Depth Area")] 
		[XmlEnum("3")] 
		DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
	}

	/// <summary>
	/// Air traffic services and rules of operation (e.g. instrument (IFR), and, visual (VFR), flight rules etc.) that are applicable to the controlled airspace, as defined by the governing aviation authority and in accordance with ICAO standards.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum controlledAirspaceClassDesignation : int {
		[System.ComponentModel.Description("501:A (missing definition)")]
		[EnumMember(Value = "A")] 
		[XmlEnum("501")] 
		A = 501,

		[System.ComponentModel.Description("502:B (missing definition)")]
		[EnumMember(Value = "B")] 
		[XmlEnum("502")] 
		B = 502,

		[System.ComponentModel.Description("503:C (missing definition)")]
		[EnumMember(Value = "C")] 
		[XmlEnum("503")] 
		C = 503,

		[System.ComponentModel.Description("504:D (missing definition)")]
		[EnumMember(Value = "D")] 
		[XmlEnum("504")] 
		D = 504,

		[System.ComponentModel.Description("505:E (missing definition)")]
		[EnumMember(Value = "E")] 
		[XmlEnum("505")] 
		E = 505,

		[System.ComponentModel.Description("506:F (missing definition)")]
		[EnumMember(Value = "F")] 
		[XmlEnum("506")] 
		F = 506,

		[System.ComponentModel.Description("507:G (missing definition)")]
		[EnumMember(Value = "G")] 
		[XmlEnum("507")] 
		G = 507,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum statusOfSmallBottomObject : int {
		[System.ComponentModel.Description("504:Identified (NOMBO) (missing definition)")]
		[EnumMember(Value = "Identified (NOMBO)")] 
		[XmlEnum("504")] 
		IdentifiedNombo = 504,
	}

	/// <summary>
	/// The principal shape and/or design of a buoy.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buoyShape : int {
		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.")]
		[EnumMember(Value = "Conical")] 
		[XmlEnum("1")] 
		Conical = 1,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.")]
		[EnumMember(Value = "Can")] 
		[XmlEnum("2")] 
		Can = 2,

		[System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("3")] 
		Spherical = 3,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.")]
		[EnumMember(Value = "Pillar")] 
		[XmlEnum("4")] 
		Pillar = 4,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.")]
		[EnumMember(Value = "Spar")] 
		[XmlEnum("5")] 
		Spar = 5,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.")]
		[EnumMember(Value = "Barrel")] 
		[XmlEnum("6")] 
		Barrel = 6,

		[System.ComponentModel.Description("A very large buoy designed to carry a signal light of high luminous intensity at a high elevation.")]
		[EnumMember(Value = "Superbuoy")] 
		[XmlEnum("7")] 
		Superbuoy = 7,

		[System.ComponentModel.Description("A specially constructed shuttle shaped buoy which is used in ice conditions.")]
		[EnumMember(Value = "Ice Buoy")] 
		[XmlEnum("8")] 
		IceBuoy = 8,
	}

	/// <summary>
	/// Units of measure of waterway distances.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum heightLengthUnits : int {
		[System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[System.ComponentModel.Description("A unit of length equal to 12 inches, 1/6 of a fathom, or 30.480 centimetres.")]
		[EnumMember(Value = "Feet")] 
		[XmlEnum("2")] 
		Feet = 2,
	}

	/// <summary>
	/// Classification of radio services offered by a radio station.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("1:circular (non-directional) marine or aero-marine radiobeacon (missing definition)")]
		[EnumMember(Value = "circular (non-directional) marine or aero-marine radiobeacon")] 
		[XmlEnum("1")] 
		CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,

		[System.ComponentModel.Description("A special type of radiobeacon station the emissions of which are intended to provide a definite track for guidance.")]
		[EnumMember(Value = "Directional Radiobeacon")] 
		[XmlEnum("2")] 
		DirectionalRadiobeacon = 2,

		[System.ComponentModel.Description("A special type of radiobeacon station emitting a beam of waves to which a uniform turning movement is given, the bearing of the station being determined by means of an ordinary listening receiver and a stop watch. Also referred to as a rotating loop radiobeacon.")]
		[EnumMember(Value = "Rotating Pattern Radiobeacon")] 
		[XmlEnum("3")] 
		RotatingPatternRadiobeacon = 3,

		[System.ComponentModel.Description("A type of long range position fixing beacon.")]
		[EnumMember(Value = "Consol Beacon")] 
		[XmlEnum("4")] 
		ConsolBeacon = 4,

		[System.ComponentModel.Description("5:radio direction-finding station (missing definition)")]
		[EnumMember(Value = "radio direction-finding station")] 
		[XmlEnum("5")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("A radio station which is prepared to provide QTG service; that is to say, to transmit upon request from a ship a radio signal, the bearing of which can be taken by that ship.")]
		[EnumMember(Value = "Coast Radio Station Providing QTG Service")] 
		[XmlEnum("6")] 
		CoastRadioStationProvidingQtgService = 6,

		[System.ComponentModel.Description("A radio beacon designed for aeronautical use.")]
		[EnumMember(Value = "Aeronautical Radiobeacon")] 
		[XmlEnum("7")] 
		AeronauticalRadiobeacon = 7,

		[System.ComponentModel.Description("The Decca Navigator System is a high accuracy, short to medium range radio navigational aid intended for coastal and landfall navigation.")]
		[EnumMember(Value = "Decca")] 
		[XmlEnum("8")] 
		Decca = 8,

		[System.ComponentModel.Description("9:Loran-C (missing definition)")]
		[EnumMember(Value = "Loran-C")] 
		[XmlEnum("9")] 
		LoranC = 9,

		[System.ComponentModel.Description("Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.")]
		[EnumMember(Value = "Differential GNSS")] 
		[XmlEnum("10")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("An electronic position fixing system used mainly by aircraft.")]
		[EnumMember(Value = "Toran")] 
		[XmlEnum("11")] 
		Toran = 11,

		[System.ComponentModel.Description("A long-range radio navigational aid which operates within the VLF frequency band. The system comprises eight land based stations.")]
		[EnumMember(Value = "Omega")] 
		[XmlEnum("12")] 
		Omega = 12,

		[System.ComponentModel.Description("A ranging position fixing system operating at 420-450 MHz over a range of up to 400 Km.")]
		[EnumMember(Value = "Syledis")] 
		[XmlEnum("13")] 
		Syledis = 13,

		[System.ComponentModel.Description("A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
		[EnumMember(Value = "Chaika")] 
		[XmlEnum("14")] 
		Chaika = 14,

		[System.ComponentModel.Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
		[EnumMember(Value = "Radio Telephone Station")] 
		[XmlEnum("19")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("An onshore AIS unit that monitors traffic in the waterways.")]
		[EnumMember(Value = "AIS Base Station")] 
		[XmlEnum("20")] 
		AisBaseStation = 20,

		[System.ComponentModel.Description("504:Distance Measuring Equipment (DME) (missing definition)")]
		[EnumMember(Value = "Distance Measuring Equipment (DME)")] 
		[XmlEnum("504")] 
		DistanceMeasuringEquipmentDme = 504,

		[System.ComponentModel.Description("505:Non-directional Radio Beacon (NDB) (missing definition)")]
		[EnumMember(Value = "Non-directional Radio Beacon (NDB)")] 
		[XmlEnum("505")] 
		NonDirectionalRadioBeaconNdb = 505,

		[System.ComponentModel.Description("506:Radar Responder Beacon (RACON) (missing definition)")]
		[EnumMember(Value = "Radar Responder Beacon (RACON)")] 
		[XmlEnum("506")] 
		RadarResponderBeaconRacon = 506,

		[System.ComponentModel.Description("508:VHF Omni Directional Radio Range (VOR) (missing definition)")]
		[EnumMember(Value = "VHF Omni Directional Radio Range (VOR)")] 
		[XmlEnum("508")] 
		VhfOmniDirectionalRadioRangeVor = 508,

		[System.ComponentModel.Description("509:VHF Omni Directional (VORTAC) (missing definition)")]
		[EnumMember(Value = "VHF Omni Directional (VORTAC)")] 
		[XmlEnum("509")] 
		VhfOmniDirectionalVortac = 509,

		[System.ComponentModel.Description("510:Tactical Air Navigation Equipment (TACAN) (missing definition)")]
		[EnumMember(Value = "Tactical Air Navigation Equipment (TACAN)")] 
		[XmlEnum("510")] 
		TacticalAirNavigationEquipmentTacan = 510,
	}

	/// <summary>
	/// Classification of aid station based on life saving equipment.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRescueStation : int {
		[System.ComponentModel.Description("A place where equipment for saving life at sea is maintained; the type of lifeboat may vary from fast, long distance boats to inflatable inshore boats.")]
		[EnumMember(Value = "Rescue Station with Lifeboat")] 
		[XmlEnum("1")] 
		RescueStationWithLifeboat = 1,

		[System.ComponentModel.Description("A life saving station equipped with line-carrying rocket apparatus.")]
		[EnumMember(Value = "Rescue Station with Rocket")] 
		[XmlEnum("2")] 
		RescueStationWithRocket = 2,

		[System.ComponentModel.Description("Shelter or protection from danger or distress at sea.")]
		[EnumMember(Value = "Refuge for Shipwrecked Mariners")] 
		[XmlEnum("4")] 
		RefugeForShipwreckedMariners = 4,

		[System.ComponentModel.Description("Shelter or protection from danger in areas exposed to extreme and sudden tides or tidal streams.")]
		[EnumMember(Value = "Refuge for Intertidal Area Walkers")] 
		[XmlEnum("5")] 
		RefugeForIntertidalAreaWalkers = 5,

		[System.ComponentModel.Description("A place where a lifeboat is moored ready for use.")]
		[EnumMember(Value = "Lifeboat Lying at a Mooring")] 
		[XmlEnum("6")] 
		LifeboatLyingAtAMooring = 6,

		[System.ComponentModel.Description("A radio station reserved for emergency situations; might also be a public telephone.")]
		[EnumMember(Value = "Aid Radio Station")] 
		[XmlEnum("7")] 
		AidRadioStation = 7,

		[System.ComponentModel.Description("A place where first aid equipment is available.")]
		[EnumMember(Value = "First Aid Equipment")] 
		[XmlEnum("8")] 
		FirstAidEquipment = 8,
	}

	/// <summary>
	/// The various substances which are transported, stored or exploited.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum product : int {
		[System.ComponentModel.Description("A thick, slippery liquid that will not dissolve in water, usually petroleum based in the context of storage tanks.")]
		[EnumMember(Value = "Oil")] 
		[XmlEnum("1")] 
		Oil = 1,

		[System.ComponentModel.Description("A substance with particles that can move freely, usually a fuel substance in the context of storage tanks.")]
		[EnumMember(Value = "Gas")] 
		[XmlEnum("2")] 
		Gas = 2,

		[System.ComponentModel.Description("A colourless, odourless, tasteless liquid that is a compound of hydrogen and oxygen.")]
		[EnumMember(Value = "Water")] 
		[XmlEnum("3")] 
		Water = 3,

		[System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
		[EnumMember(Value = "Stone")] 
		[XmlEnum("4")] 
		Stone = 4,

		[System.ComponentModel.Description("A hard black mineral that is burned as fuel.")]
		[EnumMember(Value = "Coal")] 
		[XmlEnum("5")] 
		Coal = 5,

		[System.ComponentModel.Description("A solid rock or mineral from which metal is obtained.")]
		[EnumMember(Value = "Ore")] 
		[XmlEnum("6")] 
		Ore = 6,

		[System.ComponentModel.Description("Any substance obtained by or used in a chemical process.")]
		[EnumMember(Value = "Chemicals")] 
		[XmlEnum("7")] 
		Chemicals = 7,

		[System.ComponentModel.Description("Water that is suitable for human consumption.")]
		[EnumMember(Value = "Drinking Water")] 
		[XmlEnum("8")] 
		DrinkingWater = 8,

		[System.ComponentModel.Description("A white fluid secreted by female mammals as food for their young.")]
		[EnumMember(Value = "Milk")] 
		[XmlEnum("9")] 
		Milk = 9,

		[System.ComponentModel.Description("A mineral from which aluminum is obtained.")]
		[EnumMember(Value = "Bauxite")] 
		[XmlEnum("10")] 
		Bauxite = 10,

		[System.ComponentModel.Description("A solid substance obtained after gas and tar have been extracted from coal, used as a fuel.")]
		[EnumMember(Value = "Coke")] 
		[XmlEnum("11")] 
		Coke = 11,

		[System.ComponentModel.Description("An oblong lump of cast iron metal.")]
		[EnumMember(Value = "Iron Ingots")] 
		[XmlEnum("12")] 
		IronIngots = 12,

		[System.ComponentModel.Description("Sodium chloride obtained from mines or by the evaporation of sea water.")]
		[EnumMember(Value = "Salt")] 
		[XmlEnum("13")] 
		Salt = 13,

		[System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
		[EnumMember(Value = "Sand")] 
		[XmlEnum("14")] 
		Sand = 14,

		[System.ComponentModel.Description("Wood prepared for use in building or carpentry.")]
		[EnumMember(Value = "Timber")] 
		[XmlEnum("15")] 
		Timber = 15,

		[System.ComponentModel.Description("16:sawdust/wood chips (missing definition)")]
		[EnumMember(Value = "sawdust/wood chips")] 
		[XmlEnum("16")] 
		SawdustWoodChips = 16,

		[System.ComponentModel.Description("Discarded metal suitable for being reprocessed.")]
		[EnumMember(Value = "Scrap Metal")] 
		[XmlEnum("17")] 
		ScrapMetal = 17,

		[System.ComponentModel.Description("18:liquefied natural gas (LNG) (missing definition)")]
		[EnumMember(Value = "liquefied natural gas (LNG)")] 
		[XmlEnum("18")] 
		LiquefiedNaturalGasLng = 18,

		[System.ComponentModel.Description("A compressed gas consisting of flammable light hydrocarbons and derived from petroleum.")]
		[EnumMember(Value = "Liquefied Petroleum Gas")] 
		[XmlEnum("19")] 
		LiquefiedPetroleumGas = 19,

		[System.ComponentModel.Description("The fermented juice of grapes.")]
		[EnumMember(Value = "Wine")] 
		[XmlEnum("20")] 
		Wine = 20,

		[System.ComponentModel.Description("A substance made of powdered lime and clay, mixed with water.")]
		[EnumMember(Value = "Cement")] 
		[XmlEnum("21")] 
		Cement = 21,

		[System.ComponentModel.Description("A small hard seed, especially that of any cereal plant such as wheat, rice, corn, rye etc.")]
		[EnumMember(Value = "Grain")] 
		[XmlEnum("22")] 
		Grain = 22,

		[System.ComponentModel.Description("Electric charge or current.")]
		[EnumMember(Value = "Electricity")] 
		[XmlEnum("23")] 
		Electricity = 23,

		[System.ComponentModel.Description("The solid form of water.")]
		[EnumMember(Value = "Ice")] 
		[XmlEnum("24")] 
		Ice = 24,

		[System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
		[EnumMember(Value = "Clay")] 
		[XmlEnum("25")] 
		Clay = 25,

		[System.ComponentModel.Description("Solid fuel: material wherein the particles firmly cohere; is hard and compact; and is burnt as a source of heat or power.")]
		[EnumMember(Value = "Solid Fuel")] 
		[XmlEnum("502")] 
		SolidFuel = 502,

		[System.ComponentModel.Description("Flammable liquids and gases: a substance which is either; in a state where molecules move freely about one another but do not fly apart; or in a condition in which it has no definite boundaries or fixed volume; but which is combustible under normal atmospheric conditions.")]
		[EnumMember(Value = "Flammable Liquids And Gases")] 
		[XmlEnum("503")] 
		FlammableLiquidsAndGases = 503,

		[System.ComponentModel.Description("Ferrous elements and ores: unrefined and refined: a chemically inseparable substance or solid naturally occurring mineral aggregate, from which one or more valuable constituents may be recovered by treatment or a manufacturing process, and which does contain iron in its trivalent form.")]
		[EnumMember(Value = "Ferrous Elements And Ores")] 
		[XmlEnum("505")] 
		FerrousElementsAndOres = 505,

		[System.ComponentModel.Description("Non ferrous elements and ores: unrefined and refined: A chemically inseparable substance or solid naturally occurring mineral aggregate, from which one or more valuable constituents may be recovered by treatment or a manufacturing process, and which does not contain iron in its trivalent form.")]
		[EnumMember(Value = "Non Ferrous Elements And Ores")] 
		[XmlEnum("506")] 
		NonFerrousElementsAndOres = 506,

		[System.ComponentModel.Description("Constructed from metal.")]
		[EnumMember(Value = "Metal")] 
		[XmlEnum("507")] 
		Metal = 507,

		[System.ComponentModel.Description("Substances produced by a process of in-organic nature; a substance neither animal or vegetable. Normally obtained by mining.")]
		[EnumMember(Value = "Minerals")] 
		[XmlEnum("508")] 
		Minerals = 508,

		[System.ComponentModel.Description("Natural and Chemical: a substance added to the soil to increase its productivity. It may be produced by or pertaining to nature; not the work of man; or which may be formed from a substance or resulting from a reaction involving changes to atoms or molecules.")]
		[EnumMember(Value = "Fertiliser")] 
		[XmlEnum("509")] 
		Fertiliser = 509,

		[System.ComponentModel.Description("Unprocessed and Products: the substance of trees. In unprocessed form, the wood has not undergone change by a method of manufacture into products, being the manufacture of goods or commodities from wood.")]
		[EnumMember(Value = "Wood")] 
		[XmlEnum("510")] 
		Wood = 510,

		[System.ComponentModel.Description("Unprocessed and Products: Strong waterproof elastic material, originally made from the dried sap of a tropical tree, now usually synthetic. In unprocessed form, the rubber has not undergone change by a method of manufacture into products, being the manufacture of goods or commodities from rubber.")]
		[EnumMember(Value = "Rubber")] 
		[XmlEnum("511")] 
		Rubber = 511,

		[System.ComponentModel.Description("513:natural fibres and materials in general (missing definition)")]
		[EnumMember(Value = "natural fibres and materials in general")] 
		[XmlEnum("513")] 
		NaturalFibresAndMaterialsInGeneral = 513,

		[System.ComponentModel.Description("514:foodstuffs, solid (missing definition)")]
		[EnumMember(Value = "foodstuffs, solid")] 
		[XmlEnum("514")] 
		FoodstuffsSolid = 514,

		[System.ComponentModel.Description("515:foodstuffs, liquid (missing definition)")]
		[EnumMember(Value = "foodstuffs, liquid")] 
		[XmlEnum("515")] 
		FoodstuffsLiquid = 515,

		[System.ComponentModel.Description("516:foodstuffs, preserved (missing definition)")]
		[EnumMember(Value = "foodstuffs, preserved")] 
		[XmlEnum("516")] 
		FoodstuffsPreserved = 516,

		[System.ComponentModel.Description("Items relating to the whole or most; not specialised; of broad overall character. Mixed; characterised by scope or variety; items combined or associated.")]
		[EnumMember(Value = "General And Mixed Goods")] 
		[XmlEnum("517")] 
		GeneralAndMixedGoods = 517,

		[System.ComponentModel.Description("Physical matter consisting of a relatively small and hard, but usually separate particles; or in a form which is dusty or easily crumbled into tiny, loose particles.")]
		[EnumMember(Value = "Granular Or Powdery Material")] 
		[XmlEnum("519")] 
		GranularOrPowderyMaterial = 519,

		[System.ComponentModel.Description("Machinery; apparatus usually powered by electricity designed to perform a specific task. Mechanical parts; components of vehicles or machines.")]
		[EnumMember(Value = "Machinery And Mechanical Parts")] 
		[XmlEnum("520")] 
		MachineryAndMechanicalParts = 520,

		[System.ComponentModel.Description("That out of which anything is, or may be made; equipment or implements. Parts that may be put together.")]
		[EnumMember(Value = "Construction Materials")] 
		[XmlEnum("521")] 
		ConstructionMaterials = 521,

		[System.ComponentModel.Description("A means of conveyance or transport especially a structure with wheels in or on which people or things are transported by land.")]
		[EnumMember(Value = "Vehicles")] 
		[XmlEnum("522")] 
		Vehicles = 522,

		[System.ComponentModel.Description("Structure or machine for travelling in the air.")]
		[EnumMember(Value = "Aircraft")] 
		[XmlEnum("523")] 
		Aircraft = 523,

		[System.ComponentModel.Description("A rail or set of parallel rails on which a train, tram, or rail wagon runs.")]
		[EnumMember(Value = "Railway")] 
		[XmlEnum("524")] 
		Railway = 524,

		[System.ComponentModel.Description("Movable structures for giving shelter, normally prefabricated.")]
		[EnumMember(Value = "Portable Buildings")] 
		[XmlEnum("525")] 
		PortableBuildings = 525,

		[System.ComponentModel.Description("Boxes for cargo transport with standardized dimensions.")]
		[EnumMember(Value = "Containers")] 
		[XmlEnum("526")] 
		Containers = 526,

		[System.ComponentModel.Description("Devices based on the technology of the conduction of electricity in a vacuum, gas or a semiconductor.")]
		[EnumMember(Value = "Electronics")] 
		[XmlEnum("527")] 
		Electronics = 527,

		[System.ComponentModel.Description("Constructed from plastic.")]
		[EnumMember(Value = "Plastic")] 
		[XmlEnum("528")] 
		Plastic = 528,

		[System.ComponentModel.Description("Colouring matter, especially in liquid form for imparting colour to a surface.")]
		[EnumMember(Value = "Paint")] 
		[XmlEnum("529")] 
		Paint = 529,

		[System.ComponentModel.Description("530:refuse (also known as rubbish/garbage/trash) and waste (missing definition)")]
		[EnumMember(Value = "refuse (also known as rubbish/garbage/trash) and waste")] 
		[XmlEnum("530")] 
		RefuseAlsoKnownAsRubbishGarbageTrashAndWaste = 530,

		[System.ComponentModel.Description("Relating to, caused by or exhibiting radioactivity; emission of radian elements capable of spontaneously emitting alpha, beta or sometimes gamma rays by the disintegration of the nuclei of atoms")]
		[EnumMember(Value = "Radioactive Material")] 
		[XmlEnum("531")] 
		RadioactiveMaterial = 531,

		[System.ComponentModel.Description("Military weapons, a total means of making war; defensive equipment")]
		[EnumMember(Value = "Armament")] 
		[XmlEnum("532")] 
		Armament = 532,

		[System.ComponentModel.Description("People in general.")]
		[EnumMember(Value = "Personnel")] 
		[XmlEnum("533")] 
		Personnel = 533,

		[System.ComponentModel.Description("534:animals (land and sea) and birds (missing definition)")]
		[EnumMember(Value = "animals (land and sea) and birds")] 
		[XmlEnum("534")] 
		AnimalsLandAndSeaAndBirds = 534,

		[System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
		[EnumMember(Value = "Fish")] 
		[XmlEnum("535")] 
		Fish = 535,

		[System.ComponentModel.Description("Shelled aquatic invertebrates.")]
		[EnumMember(Value = "Shellfish And Crustaceans")] 
		[XmlEnum("536")] 
		ShellfishAndCrustaceans = 536,

		[System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
		[EnumMember(Value = "Ballast")] 
		[XmlEnum("537")] 
		Ballast = 537,

		[System.ComponentModel.Description("Diesel oil available.")]
		[EnumMember(Value = "Diesel Oil")] 
		[XmlEnum("540")] 
		DieselOil = 540,

		[System.ComponentModel.Description("541:petrol/gasoline (missing definition)")]
		[EnumMember(Value = "petrol/gasoline")] 
		[XmlEnum("541")] 
		PetrolGasoline = 541,

		[System.ComponentModel.Description("Persons travelling in a means of transport operated by others.")]
		[EnumMember(Value = "Passengers")] 
		[XmlEnum("542")] 
		Passengers = 542,
	}

	/// <summary>
	/// Classification of the manoeuvrability of the ferry vessel, not the various types of ferry vessel.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFerry : int {
		[System.ComponentModel.Description("A ferry which may have routes that vary with weather, tide and traffic.")]
		[EnumMember(Value = "Free Moving Ferry")] 
		[XmlEnum("1")] 
		FreeMovingFerry = 1,

		[System.ComponentModel.Description("A ferry that follows a fixed route guided by a cable.")]
		[EnumMember(Value = "Cable Ferry")] 
		[XmlEnum("2")] 
		CableFerry = 2,

		[System.ComponentModel.Description("A winter-time ferry which crosses a lead.")]
		[EnumMember(Value = "Ice Ferry")] 
		[XmlEnum("3")] 
		IceFerry = 3,

		[System.ComponentModel.Description("A high speed water vessel for civilian use.")]
		[EnumMember(Value = "High Speed Ferry")] 
		[XmlEnum("5")] 
		HighSpeedFerry = 5,
	}

	/// <summary>
	/// Classification of objects that impede movement.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfObstruction : int {
		[System.ComponentModel.Description("1:snag/stump (missing definition)")]
		[EnumMember(Value = "snag/stump")] 
		[XmlEnum("1")] 
		SnagStump = 1,

		[System.ComponentModel.Description("A submarine structure projecting some distance above the seabed and capping a temporarily abandoned or suspended oil or gas well.")]
		[EnumMember(Value = "Wellhead")] 
		[XmlEnum("2")] 
		Wellhead = 2,

		[System.ComponentModel.Description("A structure on an outfall through which liquids are discharged. The structure will usually project above the level of the outfall and can be an obstruction to navigation.")]
		[EnumMember(Value = "Diffuser")] 
		[XmlEnum("3")] 
		Diffuser = 3,

		[System.ComponentModel.Description("A permanent marine structure usually designed to support or elevate pipelines; especially a structure enclosing a screening device at the offshore end of a potable water intake pipe. The structure is commonly a heavy timber enclosure that has been sunken with rocks or other debris.")]
		[EnumMember(Value = "Crib")] 
		[XmlEnum("4")] 
		Crib = 4,

		[System.ComponentModel.Description("Areas established by private interests, usually sport fishermen, to simulate natural reefs and wrecks that attract fish. The reefs are constructed by dumping assorted junk in areas which may be of very small extent or may stretch a considerable distance along a depth contour.")]
		[EnumMember(Value = "Fish Haven")] 
		[XmlEnum("5")] 
		FishHaven = 5,

		[System.ComponentModel.Description("An area of numerous unidentified dangers to navigation. The area serves as a warning to the mariner that all dangers are not identified individually and that navigation through the area may be hazardous.")]
		[EnumMember(Value = "Foul Area")] 
		[XmlEnum("6")] 
		FoulArea = 6,

		[System.ComponentModel.Description("Floating barriers, anchored to the bottom, used to deflect the path of floating ice in order to prevent the obstruction of locks, intakes, etc., and to prevent damage to bridge piers and other structures.")]
		[EnumMember(Value = "Ice Boom")] 
		[XmlEnum("8")] 
		IceBoom = 8,

		[System.ComponentModel.Description("Equipment such as anchors, concrete blocks, chains and cables, etc., used to position floating structures such as trot and mooring buoys etc.")]
		[EnumMember(Value = "Ground Tackle")] 
		[XmlEnum("9")] 
		GroundTackle = 9,

		[System.ComponentModel.Description("A floating barrier used to protect a river or harbour mouth or to create a sheltered area for storage purposes.")]
		[EnumMember(Value = "Boom")] 
		[XmlEnum("10")] 
		Boom = 10,

		[System.ComponentModel.Description("A device to extract energy from the surface motion of ocean waves or from pressure fluctuations below the surface.")]
		[EnumMember(Value = "Wave Energy Device")] 
		[XmlEnum("12")] 
		WaveEnergyDevice = 12,

		[System.ComponentModel.Description("13:subsurface ocean data acquisition system (ODAS) (missing definition)")]
		[EnumMember(Value = "subsurface ocean data acquisition system (ODAS)")] 
		[XmlEnum("13")] 
		SubsurfaceOceanDataAcquisitionSystemOdas = 13,

		[System.ComponentModel.Description("A man-made structure that may mimic some of the characteristics of a natural reef, intended to attract sea life.")]
		[EnumMember(Value = "Artificial Reef")] 
		[XmlEnum("14")] 
		ArtificialReef = 14,

		[System.ComponentModel.Description("A structure placed on the seafloor below a drilling rig to guide the drill.")]
		[EnumMember(Value = "Template")] 
		[XmlEnum("15")] 
		Template = 15,

		[System.ComponentModel.Description("A large steel structure up to 20 metres in height above the seafloor, or a steel frame secured to the seafloor with piles to anchor the end of a submarine pipeline, for delivery to a production platform.")]
		[EnumMember(Value = "Manifold")] 
		[XmlEnum("16")] 
		Manifold = 16,

		[System.ComponentModel.Description("A hill of soil-covered ice pushed up by hydrostatic pressure in an area of permafrost that is located underwater.")]
		[EnumMember(Value = "Submerged Pingo")] 
		[XmlEnum("17")] 
		SubmergedPingo = 17,

		[System.ComponentModel.Description("The distributed remains of a platform.")]
		[EnumMember(Value = "Remains of Platform")] 
		[XmlEnum("18")] 
		RemainsOfPlatform = 18,

		[System.ComponentModel.Description("An instrument used for scientific purposes.")]
		[EnumMember(Value = "Scientific Instrument")] 
		[XmlEnum("19")] 
		ScientificInstrument = 19,

		[System.ComponentModel.Description("Any of various machines having a rotor, usually with vanes or blades, driven by the pressure, momentum, or reactive thrust of a moving fluid, as steam, water, hot gases, or air, either occurring in the form of free jets or as a fluid passing through and entirely filling a housing around the rotor and is located underwater.")]
		[EnumMember(Value = "Underwater Turbine")] 
		[XmlEnum("20")] 
		UnderwaterTurbine = 20,

		[System.ComponentModel.Description("An active seabed volcano, which may be submerged or projecting above the water at the chart sounding datum.")]
		[EnumMember(Value = "Active Submarine Volcano")] 
		[XmlEnum("21")] 
		ActiveSubmarineVolcano = 21,

		[System.ComponentModel.Description("A submerged net placed around beaches to reduce shark attacks on swimmers.")]
		[EnumMember(Value = "Shark Net")] 
		[XmlEnum("22")] 
		SharkNet = 22,

		[System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
		[EnumMember(Value = "Mangrove")] 
		[XmlEnum("23")] 
		Mangrove = 23,

		[System.ComponentModel.Description("a structure, typically a dome or cube, erected over a wellhead or equipment attached to it (a tree) to lessen the danger of vessels snagging gear. (AML)")]
		[EnumMember(Value = "Well Protection Structure")] 
		[XmlEnum("501")] 
		WellProtectionStructure = 501,

		[System.ComponentModel.Description("any oil or gas related installation or structure on, or projecting from, the seabed, for example a submerged platform or concrete foundations. (AML)")]
		[EnumMember(Value = "Subsea Installation")] 
		[XmlEnum("502")] 
		SubseaInstallation = 502,

		[System.ComponentModel.Description("any pipeline related structure which projects above the seabed, for example a  joint, T-piece, valve or sleeve, or a crossing where one pipeline is raised over another by means of a supporting structure. (AML)")]
		[EnumMember(Value = "Pipeline Obstruction")] 
		[XmlEnum("503")] 
		PipelineObstruction = 503,

		[System.ComponentModel.Description("504:free standing conductor pipe (missing definition)")]
		[EnumMember(Value = "free standing conductor pipe")] 
		[XmlEnum("504")] 
		FreeStandingConductorPipe = 504,

		[System.ComponentModel.Description("large seabed structures, typically made of concrete, capable of storing oil or gas and usually found attached or adjacent to a rig, or marked by a single point mooring buoy. (AML)")]
		[EnumMember(Value = "Storage Tank")] 
		[XmlEnum("506")] 
		StorageTank = 506,

		[System.ComponentModel.Description("A floating structure, usually rectangular in shape which serves as landing, pier head, bridge support, etc.")]
		[EnumMember(Value = "Pontoon")] 
		[XmlEnum("508")] 
		Pontoon = 508,

		[System.ComponentModel.Description("miscellaneous items and objects, most of which have been lost overboard or otherwise abandoned to the sea, for example cargo containers or vehicles. (AML)")]
		[EnumMember(Value = "Sundry Objects")] 
		[XmlEnum("509")] 
		SundryObjects = 509,
	}

	/// <summary>
	/// The official legal statute of each kind of restricted area.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum restriction : int {
		[System.ComponentModel.Description("An area within which anchoring is not permitted.")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		[XmlEnum("1")] 
		AnchoringProhibited = 1,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which anchoring is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Anchoring Restricted")] 
		[XmlEnum("2")] 
		AnchoringRestricted = 2,

		[System.ComponentModel.Description("An area within which fishing is not permitted.")]
		[EnumMember(Value = "Fishing Prohibited")] 
		[XmlEnum("3")] 
		FishingProhibited = 3,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which fishing is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Fishing Restricted")] 
		[XmlEnum("4")] 
		FishingRestricted = 4,

		[System.ComponentModel.Description("An area within which trawling is not permitted.")]
		[EnumMember(Value = "Trawling Prohibited")] 
		[XmlEnum("5")] 
		TrawlingProhibited = 5,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which trawling is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Trawling Restricted")] 
		[XmlEnum("6")] 
		TrawlingRestricted = 6,

		[System.ComponentModel.Description("An area within which navigation and/or anchoring is prohibited.")]
		[EnumMember(Value = "Entry Prohibited")] 
		[XmlEnum("7")] 
		EntryProhibited = 7,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Entry Restricted")] 
		[XmlEnum("8")] 
		EntryRestricted = 8,

		[System.ComponentModel.Description("An area within which dredging is not permitted.")]
		[EnumMember(Value = "Dredging Prohibited")] 
		[XmlEnum("9")] 
		DredgingProhibited = 9,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which dredging is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Dredging Restricted")] 
		[XmlEnum("10")] 
		DredgingRestricted = 10,

		[System.ComponentModel.Description("An area within which diving is not permitted.")]
		[EnumMember(Value = "Diving Prohibited")] 
		[XmlEnum("11")] 
		DivingProhibited = 11,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which diving is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Diving Restricted")] 
		[XmlEnum("12")] 
		DivingRestricted = 12,

		[System.ComponentModel.Description("Mariners must adjust the speed of their vessels to reduce the wave or wash which may cause erosion or disturb moored vessels.")]
		[EnumMember(Value = "No Wake")] 
		[XmlEnum("13")] 
		NoWake = 13,

		[System.ComponentModel.Description("An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.")]
		[EnumMember(Value = "Area To Be Avoided")] 
		[XmlEnum("14")] 
		AreaToBeAvoided = 14,

		[System.ComponentModel.Description("The erection of permanent or temporary fixed structures or artificial islands is prohibited.")]
		[EnumMember(Value = "Construction Prohibited")] 
		[XmlEnum("15")] 
		ConstructionProhibited = 15,

		[System.ComponentModel.Description("An area within which discharging or dumping is prohibited.")]
		[EnumMember(Value = "Discharging Prohibited")] 
		[XmlEnum("16")] 
		DischargingProhibited = 16,

		[System.ComponentModel.Description("A specified area designated by an appropriate authority, within which discharging or dumping is restricted in accordance with specified conditions.")]
		[EnumMember(Value = "Discharging Restricted")] 
		[XmlEnum("17")] 
		DischargingRestricted = 17,

		[System.ComponentModel.Description("18:industrial or mineral (missing definition)")]
		[EnumMember(Value = "industrial or mineral 18")] 
		[XmlEnum("18")] 
		IndustrialOrMineral18 = 18,

		[System.ComponentModel.Description("19:industrial or mineral (missing definition)")]
		[EnumMember(Value = "industrial or mineral 19")] 
		[XmlEnum("19")] 
		IndustrialOrMineral19 = 19,

		[System.ComponentModel.Description("An area within which excavating a hole on the seabed with a drill is prohibited.")]
		[EnumMember(Value = "Drilling Prohibited")] 
		[XmlEnum("20")] 
		DrillingProhibited = 20,

		[System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the seabed with a drill is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Drilling Restricted")] 
		[XmlEnum("21")] 
		DrillingRestricted = 21,

		[System.ComponentModel.Description("22:removal of historic (missing definition)")]
		[EnumMember(Value = "removal of historic")] 
		[XmlEnum("22")] 
		RemovalOfHistoric = 22,

		[System.ComponentModel.Description("23:cargo transhipment (lightening) prohibited (missing definition)")]
		[EnumMember(Value = "cargo transhipment (lightening) prohibited")] 
		[XmlEnum("23")] 
		CargoTranshipmentLighteningProhibited = 23,

		[System.ComponentModel.Description("An area in which the dragging of anything along the seabed, for example bottom trawling, is prohibited.")]
		[EnumMember(Value = "Dragging Prohibited")] 
		[XmlEnum("24")] 
		DraggingProhibited = 24,

		[System.ComponentModel.Description("An area in which a vessel is prohibited from stopping.")]
		[EnumMember(Value = "Stopping Prohibited")] 
		[XmlEnum("25")] 
		StoppingProhibited = 25,

		[System.ComponentModel.Description("An area in which landing is prohibited.")]
		[EnumMember(Value = "Landing Prohibited")] 
		[XmlEnum("26")] 
		LandingProhibited = 26,

		[System.ComponentModel.Description("An area within which speed is restricted.")]
		[EnumMember(Value = "Speed Restricted")] 
		[XmlEnum("27")] 
		SpeedRestricted = 27,

		[System.ComponentModel.Description("An area in which swimming is prohibited.")]
		[EnumMember(Value = "Swimming Prohibited")] 
		[XmlEnum("39")] 
		SwimmingProhibited = 39,

		[System.ComponentModel.Description("42:power-driven vessels (missing definition)")]
		[EnumMember(Value = "power-driven vessels")] 
		[XmlEnum("42")] 
		PowerDrivenVessels = 42,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofMilitaryPracticeArea : int {
		[System.ComponentModel.Description("An area within which exercises are carried out with torpedoes.")]
		[EnumMember(Value = "Torpedo Exercise Area")] 
		[XmlEnum("2")] 
		TorpedoExerciseArea = 2,

		[System.ComponentModel.Description("An area within which submarine exercises are carried out.")]
		[EnumMember(Value = "Submarine Exercise Area")] 
		[XmlEnum("3")] 
		SubmarineExerciseArea = 3,

		[System.ComponentModel.Description("Areas for bombing and missile exercises.")]
		[EnumMember(Value = "Firing Danger Area")] 
		[XmlEnum("4")] 
		FiringDangerArea = 4,

		[System.ComponentModel.Description("5:mine-laying practice area (missing definition)")]
		[EnumMember(Value = "mine-laying practice area")] 
		[XmlEnum("5")] 
		MineLayingPracticeArea = 5,

		[System.ComponentModel.Description("The ACLANT (Allied Command Atlantic) submarine grid provides NATO submarine operating authorities with a common grid for the water space management of NATO submarines.")]
		[EnumMember(Value = "ACLANT grid")] 
		[XmlEnum("501")] 
		AclantGrid = 501,

		[System.ComponentModel.Description("An area in which certain activities or factors of significance to surface navigation or operations apply.")]
		[EnumMember(Value = "Surface Danger Area")] 
		[XmlEnum("502")] 
		SurfaceDangerArea = 502,

		[System.ComponentModel.Description("503:JMC Areas - JENOA grid (missing definition)")]
		[EnumMember(Value = "JMC Areas - JENOA grid")] 
		[XmlEnum("503")] 
		JmcAreasJenoaGrid = 503,

		[System.ComponentModel.Description("506:safe bottoming area (missing definition)")]
		[EnumMember(Value = "safe bottoming area")] 
		[XmlEnum("506")] 
		SafeBottomingArea = 506,

		[System.ComponentModel.Description("An area in which submarine operations are prohibited or limited, owing to the existence of hazards to dived submarines.")]
		[EnumMember(Value = "Submarine Danger Area")] 
		[XmlEnum("507")] 
		SubmarineDangerArea = 507,

		[System.ComponentModel.Description("A specified zone for the provision of sonar calibration or other underwater testing.")]
		[EnumMember(Value = "Testing and Evaluation Range")] 
		[XmlEnum("508")] 
		TestingAndEvaluationRange = 508,

		[System.ComponentModel.Description("510:Impact area (missing definition)")]
		[EnumMember(Value = "Impact area")] 
		[XmlEnum("510")] 
		ImpactArea = 510,

		[System.ComponentModel.Description("An area used for live firing of weapons to bombard a designated area.")]
		[EnumMember(Value = "Live Fire Range")] 
		[XmlEnum("599")] 
		LiveFireRange = 599,
	}

	/// <summary>
	/// An indication of the strength of the echo of a sonic signal returned from an object.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sonarSignalStrength : int {
		[System.ComponentModel.Description("501:nil (missing definition)")]
		[EnumMember(Value = "nil")] 
		[XmlEnum("501")] 
		Nil = 501,

		[System.ComponentModel.Description("Not as good as it could be or should.")]
		[EnumMember(Value = "Poor")] 
		[XmlEnum("502")] 
		Poor = 502,

		[System.ComponentModel.Description("503:moderate (missing definition)")]
		[EnumMember(Value = "moderate")] 
		[XmlEnum("503")] 
		Moderate = 503,

		[System.ComponentModel.Description("Not easily broken or destroyed.")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("504")] 
		Strong = 504,
	}

	/// <summary>
	/// Characteristics of vessels.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("The maximum length of the ship.")]
		[EnumMember(Value = "Length Overall")] 
		[XmlEnum("1")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("The ship's length measured at the waterline.")]
		[EnumMember(Value = "Length at Waterline")] 
		[XmlEnum("2")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("The width or beam of the vessel.")]
		[EnumMember(Value = "Breadth")] 
		[XmlEnum("3")] 
		Breadth = 3,

		[System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded.")]
		[EnumMember(Value = "Draught")] 
		[XmlEnum("4")] 
		Draught = 4,

		[System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement.")]
		[EnumMember(Value = "Displacement Tonnage")] 
		[XmlEnum("6")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.")]
		[EnumMember(Value = "Gross Tonnage")] 
		[XmlEnum("10")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.")]
		[EnumMember(Value = "Net Tonnage")] 
		[XmlEnum("11")] 
		NetTonnage = 11,
	}

	/// <summary>
	/// Indicates the source which subsequently confirmed the object
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lastSensor : int {
		[System.ComponentModel.Description("501:acoustic sensor (missing definition)")]
		[EnumMember(Value = "acoustic sensor")] 
		[XmlEnum("501")] 
		AcousticSensor = 501,

		[System.ComponentModel.Description("the object was reported as a result of detecting a fluctuation in the local magnetic field.")]
		[EnumMember(Value = "Magnetic Sensor")] 
		[XmlEnum("502")] 
		MagneticSensor = 502,

		[System.ComponentModel.Description("503:video sensor (missing definition)")]
		[EnumMember(Value = "video sensor")] 
		[XmlEnum("503")] 
		VideoSensor = 503,

		[System.ComponentModel.Description("504:diver sighting (found by diver - in registry) (missing definition)")]
		[EnumMember(Value = "diver sighting (found by diver - in registry)")] 
		[XmlEnum("504")] 
		DiverSightingFoundByDiverInRegistry = 504,

		[System.ComponentModel.Description("506:physical snag (missing definition)")]
		[EnumMember(Value = "physical snag")] 
		[XmlEnum("506")] 
		PhysicalSnag = 506,

		[System.ComponentModel.Description("507:observed sinking (missing definition)")]
		[EnumMember(Value = "observed sinking")] 
		[XmlEnum("507")] 
		ObservedSinking = 507,

		[System.ComponentModel.Description("508:Reported Sinking (missing definition)")]
		[EnumMember(Value = "Reported Sinking")] 
		[XmlEnum("508")] 
		ReportedSinking = 508,

		[System.ComponentModel.Description("509:None reported (missing definition)")]
		[EnumMember(Value = "None reported")] 
		[XmlEnum("509")] 
		NoneReported = 509,
	}

	/// <summary>
	/// Indicator as to area of data coverage.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCoverage : int {
		[System.ComponentModel.Description("Continuous coverage of spatial objects is available within this area.")]
		[EnumMember(Value = "Coverage Available")] 
		[XmlEnum("1")] 
		CoverageAvailable = 1,

		[System.ComponentModel.Description("An area containing no spatial objects.")]
		[EnumMember(Value = "No Coverage Available")] 
		[XmlEnum("2")] 
		NoCoverageAvailable = 2,
	}

	/// <summary>
	/// Describes the characteristic geometric form of the beacon.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum beaconShape : int {
		[System.ComponentModel.Description("1:stake, pole, perch, post (missing definition)")]
		[EnumMember(Value = "stake, pole, perch, post")] 
		[XmlEnum("1")] 
		StakePolePerchPost = 1,

		[System.ComponentModel.Description("A tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.")]
		[EnumMember(Value = "Withy")] 
		[XmlEnum("2")] 
		Withy = 2,

		[System.ComponentModel.Description("A solid structure of the order of 10 metres in height used as a navigational aid.")]
		[EnumMember(Value = "Beacon Tower")] 
		[XmlEnum("3")] 
		BeaconTower = 3,

		[System.ComponentModel.Description("A structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.")]
		[EnumMember(Value = "Lattice Beacon")] 
		[XmlEnum("4")] 
		LatticeBeacon = 4,

		[System.ComponentModel.Description("A long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.")]
		[EnumMember(Value = "Pile Beacon")] 
		[XmlEnum("5")] 
		PileBeacon = 5,

		[System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("6")] 
		Cairn = 6,

		[System.ComponentModel.Description("A tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.")]
		[EnumMember(Value = "Buoyant Beacon")] 
		[XmlEnum("7")] 
		BuoyantBeacon = 7,
	}

	/// <summary>
	/// Classification of an area based on the type of waste being disposed of.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDumpingGround : int {
		[System.ComponentModel.Description("An area at sea where chemical waste is dumped.")]
		[EnumMember(Value = "Chemical Waste Dumping Ground")] 
		[XmlEnum("2")] 
		ChemicalWasteDumpingGround = 2,

		[System.ComponentModel.Description("An area at sea where nuclear waste is dumped.")]
		[EnumMember(Value = "Nuclear Waste Dumping Ground")] 
		[XmlEnum("3")] 
		NuclearWasteDumpingGround = 3,

		[System.ComponentModel.Description("An area at sea where explosives are dumped.")]
		[EnumMember(Value = "Explosives Dumping Ground")] 
		[XmlEnum("4")] 
		ExplosivesDumpingGround = 4,

		[System.ComponentModel.Description("A sea area where dredged material is deposited.")]
		[EnumMember(Value = "Spoil Ground")] 
		[XmlEnum("5")] 
		SpoilGround = 5,

		[System.ComponentModel.Description("An area at sea where disused vessels are scuttled.")]
		[EnumMember(Value = "Vessel Dumping Ground")] 
		[XmlEnum("6")] 
		VesselDumpingGround = 6,
	}

	/// <summary>
	/// Classification of an area where different use types of vessel can remain static.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAnchorage : int {
		[System.ComponentModel.Description("An area in which vessels anchor or may anchor.")]
		[EnumMember(Value = "Unrestricted Anchorage")] 
		[XmlEnum("1")] 
		UnrestrictedAnchorage = 1,

		[System.ComponentModel.Description("An area in which vessels of deep draught anchor or may anchor.")]
		[EnumMember(Value = "Deep Water Anchorage")] 
		[XmlEnum("2")] 
		DeepWaterAnchorage = 2,

		[System.ComponentModel.Description("An area in which tankers anchor or may anchor.")]
		[EnumMember(Value = "Tanker Anchorage")] 
		[XmlEnum("3")] 
		TankerAnchorage = 3,

		[System.ComponentModel.Description("An area where a vessel anchors when satisfying quarantine regulations.")]
		[EnumMember(Value = "Quarantine Anchorage")] 
		[XmlEnum("5")] 
		QuarantineAnchorage = 5,

		[System.ComponentModel.Description("An area in which seaplanes anchor or may anchor.")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		[XmlEnum("6")] 
		SeaplaneAnchorage = 6,

		[System.ComponentModel.Description("An area in which yachts and small boats anchor or may anchor.")]
		[EnumMember(Value = "Small Craft Anchorage")] 
		[XmlEnum("7")] 
		SmallCraftAnchorage = 7,

		[System.ComponentModel.Description("An area in which vessels anchor or may anchor for periods of up to 24 hours.")]
		[EnumMember(Value = "Anchorage for Periods Up To 24 Hours")] 
		[XmlEnum("9")] 
		AnchorageForPeriodsUpTo24Hours = 9,

		[System.ComponentModel.Description("An area in which vessels may anchor for a period of time not to exceed a specific limit.")]
		[EnumMember(Value = "Anchorage for a Limited Period of Time")] 
		[XmlEnum("10")] 
		AnchorageForALimitedPeriodOfTime = 10,

		[System.ComponentModel.Description("An area in which vessels anchor or may anchor while waiting, for example, for access to a port or berth.")]
		[EnumMember(Value = "Waiting Anchorage")] 
		[XmlEnum("14")] 
		WaitingAnchorage = 14,

		[System.ComponentModel.Description("A location not defined by a regulatory authority that has been reported to be suitable and safe for anchoring.")]
		[EnumMember(Value = "Reported Anchorage")] 
		[XmlEnum("15")] 
		ReportedAnchorage = 15,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum catagoryOfAirspaceRestriction : int {
		[System.ComponentModel.Description("An area designated by a proper authority, in which a danger to craft exists. Also called danger zone.")]
		[EnumMember(Value = "Danger Area")] 
		[XmlEnum("501")] 
		DangerArea = 501,

		[System.ComponentModel.Description("(1) An area shown on charts within which navigation and/or anchoring is prohibited. (2) In aviation terminology, a specified area within the land areas of a state or territorial waters adjacent thereto over which the flight of aircraft is prohibited.")]
		[EnumMember(Value = "Prohibited Area")] 
		[XmlEnum("502")] 
		ProhibitedArea = 502,

		[System.ComponentModel.Description("A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Restricted Area")] 
		[XmlEnum("503")] 
		RestrictedArea = 503,
	}

	/// <summary>
	/// A regular repeated design containing more than one colour.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colourPattern : int {
		[System.ComponentModel.Description("Straight bands or stripes of differing colours oriented horizontally.")]
		[EnumMember(Value = "Horizontal Stripes")] 
		[XmlEnum("1")] 
		HorizontalStripes = 1,

		[System.ComponentModel.Description("Straight bands or stripes of differing colours oriented vertically.")]
		[EnumMember(Value = "Vertical Stripes")] 
		[XmlEnum("2")] 
		VerticalStripes = 2,

		[System.ComponentModel.Description("Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).")]
		[EnumMember(Value = "Diagonal Stripes")] 
		[XmlEnum("3")] 
		DiagonalStripes = 3,

		[System.ComponentModel.Description("Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
		[EnumMember(Value = "Squared")] 
		[XmlEnum("4")] 
		Squared = 4,

		[System.ComponentModel.Description("5:stripes (direction unknown) (missing definition)")]
		[EnumMember(Value = "stripes (direction unknown)")] 
		[XmlEnum("5")] 
		StripesDirectionUnknown = 5,

		[System.ComponentModel.Description("A band or stripe of colour which is displayed around the outer edge of the feature, which may also form a border to an inner pattern or plain colour.")]
		[EnumMember(Value = "Border Stripe")] 
		[XmlEnum("6")] 
		BorderStripe = 6,
	}

	/// <summary>
	/// Classification of radar station based on the services offered.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarStation : int {
		[System.ComponentModel.Description("A radar station established for traffic surveillance.")]
		[EnumMember(Value = "Radar Surveillance Station")] 
		[XmlEnum("1")] 
		RadarSurveillanceStation = 1,

		[System.ComponentModel.Description("A shore-based station which the mariner can contact by radio to obtain a position.")]
		[EnumMember(Value = "Coast Radar Station")] 
		[XmlEnum("2")] 
		CoastRadarStation = 2,
	}

	/// <summary>
	/// Air Traffic Services airspace classifications, applicable to the ATS airspace, as defined by the governing aviation authority and in accordance with ICAO standards
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfControlledAirspace : int {
		[System.ComponentModel.Description("A control area or portion thereof established in the form of a corridor equipped with radio navigation aids.")]
		[EnumMember(Value = "Airway")] 
		[XmlEnum("501")] 
		Airway = 501,

		[System.ComponentModel.Description("502:Altimeter Setting Region (ASR) (missing definition)")]
		[EnumMember(Value = "Altimeter Setting Region (ASR)")] 
		[XmlEnum("502")] 
		AltimeterSettingRegionAsr = 502,

		[System.ComponentModel.Description("503:Avoidance Area (AA) (missing definition)")]
		[EnumMember(Value = "Avoidance Area (AA)")] 
		[XmlEnum("503")] 
		AvoidanceAreaAa = 503,

		[System.ComponentModel.Description("504:Control Area (CTA) (missing definition)")]
		[EnumMember(Value = "Control Area (CTA)")] 
		[XmlEnum("504")] 
		ControlAreaCta = 504,

		[System.ComponentModel.Description("505:Control Zone (CTR/CTZ) (missing definition)")]
		[EnumMember(Value = "Control Zone (CTR/CTZ)")] 
		[XmlEnum("505")] 
		ControlZoneCtrCtz = 505,

		[System.ComponentModel.Description("506:Flight Information Region (FIR) (missing definition)")]
		[EnumMember(Value = "Flight Information Region (FIR)")] 
		[XmlEnum("506")] 
		FlightInformationRegionFir = 506,

		[System.ComponentModel.Description("507:Terminal Control Area (TMA/TCA) (missing definition)")]
		[EnumMember(Value = "Terminal Control Area (TMA/TCA)")] 
		[XmlEnum("507")] 
		TerminalControlAreaTmaTca = 507,

		[System.ComponentModel.Description("508:Aerodrome Traffic Zone (ATZ) (missing definition)")]
		[EnumMember(Value = "Aerodrome Traffic Zone (ATZ)")] 
		[XmlEnum("508")] 
		AerodromeTrafficZoneAtz = 508,

		[System.ComponentModel.Description("509:Helicopter Protection Zone (HPZ) (missing definition)")]
		[EnumMember(Value = "Helicopter Protection Zone (HPZ)")] 
		[XmlEnum("509")] 
		HelicopterProtectionZoneHpz = 509,

		[System.ComponentModel.Description("510:Helicopter Main Route (HMR) (missing definition)")]
		[EnumMember(Value = "Helicopter Main Route (HMR)")] 
		[XmlEnum("510")] 
		HelicopterMainRouteHmr = 510,

		[System.ComponentModel.Description("511:Helicopter Transit Corridor (HTC) (missing definition)")]
		[EnumMember(Value = "Helicopter Transit Corridor (HTC)")] 
		[XmlEnum("511")] 
		HelicopterTransitCorridorHtc = 511,

		[System.ComponentModel.Description("512:Military Aerodrome Traffic Zone (MATZ) (missing definition)")]
		[EnumMember(Value = "Military Aerodrome Traffic Zone (MATZ)")] 
		[XmlEnum("512")] 
		MilitaryAerodromeTrafficZoneMatz = 512,

		[System.ComponentModel.Description("513:Ocean Control Area (OCA) (missing definition)")]
		[EnumMember(Value = "Ocean Control Area (OCA)")] 
		[XmlEnum("513")] 
		OceanControlAreaOca = 513,

		[System.ComponentModel.Description("514:Coastguard track [surveillance] (missing definition)")]
		[EnumMember(Value = "Coastguard track [surveillance]")] 
		[XmlEnum("514")] 
		CoastguardTrackSurveillance = 514,

		[System.ComponentModel.Description("515:Military Terminal Control Area (MTCA) (missing definition)")]
		[EnumMember(Value = "Military Terminal Control Area (MTCA)")] 
		[XmlEnum("515")] 
		MilitaryTerminalControlAreaMtca = 515,

		[System.ComponentModel.Description("516:Identification Zone (ADIZ) (missing definition)")]
		[EnumMember(Value = "Identification Zone (ADIZ)")] 
		[XmlEnum("516")] 
		IdentificationZoneAdiz = 516,

		[System.ComponentModel.Description("517:Advisory Area (ADA) or (UDA) (missing definition)")]
		[EnumMember(Value = "Advisory Area (ADA) or (UDA)")] 
		[XmlEnum("517")] 
		AdvisoryAreaAdaOrUda = 517,

		[System.ComponentModel.Description("518:Air Route Tradffic Control Center (ARTCC) (missing definition)")]
		[EnumMember(Value = "Air Route Tradffic Control Center (ARTCC)")] 
		[XmlEnum("518")] 
		AirRouteTradfficControlCenterArtcc = 518,

		[System.ComponentModel.Description("519:Area Control Center (ACC) (missing definition)")]
		[EnumMember(Value = "Area Control Center (ACC)")] 
		[XmlEnum("519")] 
		AreaControlCenterAcc = 519,

		[System.ComponentModel.Description("An airspace for which a radar service is specified")]
		[EnumMember(Value = "Radar Area")] 
		[XmlEnum("520")] 
		RadarArea = 520,

		[System.ComponentModel.Description("521:Upper Flight Information Region (UIR) (missing definition)")]
		[EnumMember(Value = "Upper Flight Information Region (UIR)")] 
		[XmlEnum("521")] 
		UpperFlightInformationRegionUir = 521,

		[System.ComponentModel.Description("522:Buffer Zone (BZ) (missing definition)")]
		[EnumMember(Value = "Buffer Zone (BZ)")] 
		[XmlEnum("522")] 
		BufferZoneBz = 522,
	}

	/// <summary>
	/// Indicates whether the feature content has throughrougly included all criteria present in product specification.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCompleteness : int {
		[System.ComponentModel.Description("The area specified has been populated for all known features. Absence of features indicates that there are no such entities available to the data producer.")]
		[EnumMember(Value = "Complete")] 
		[XmlEnum("501")] 
		Complete = 501,

		[System.ComponentModel.Description("Certain features have not been included (or only partially included) within the specified area. Details must be provided in supporting textual information.")]
		[EnumMember(Value = "Partial")] 
		[XmlEnum("502")] 
		Partial = 502,
	}

	/// <summary>
	/// Classification of the different types of cargo that a ship may be carrying.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel, for example oil or grain.")]
		[EnumMember(Value = "Bulk")] 
		[XmlEnum("1")] 
		Bulk = 1,

		[System.ComponentModel.Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
		[EnumMember(Value = "Container")] 
		[XmlEnum("2")] 
		Container = 2,

		[System.ComponentModel.Description("Break bulk cargo normally loaded by crane.")]
		[EnumMember(Value = "General")] 
		[XmlEnum("3")] 
		General = 3,

		[System.ComponentModel.Description("Any cargo loaded by pipeline.")]
		[EnumMember(Value = "Liquid")] 
		[XmlEnum("4")] 
		Liquid = 4,

		[System.ComponentModel.Description("A fee paying traveller.")]
		[EnumMember(Value = "Passenger")] 
		[XmlEnum("5")] 
		Passenger = 5,

		[System.ComponentModel.Description("Live animals carried in bulk.")]
		[EnumMember(Value = "Livestock")] 
		[XmlEnum("6")] 
		Livestock = 6,

		[System.ComponentModel.Description("Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.")]
		[EnumMember(Value = "Dangerous or Hazardous")] 
		[XmlEnum("7")] 
		DangerousOrHazardous = 7,

		[System.ComponentModel.Description("Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.")]
		[EnumMember(Value = "Heavy Lift")] 
		[XmlEnum("8")] 
		HeavyLift = 8,

		[System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
		[EnumMember(Value = "Ballast")] 
		[XmlEnum("9")] 
		Ballast = 9,

		[System.ComponentModel.Description("Commodity cargo that is transported unpackaged in large quantities. These types of goods usually need to be kept dry during the whole transportation period.")]
		[EnumMember(Value = "Dry Bulk Cargo")] 
		[XmlEnum("10")] 
		DryBulkCargo = 10,

		[System.ComponentModel.Description("Liquids or gases that are transported in bulk and carried unpackaged.")]
		[EnumMember(Value = "Liquid Bulk Cargo")] 
		[XmlEnum("11")] 
		LiquidBulkCargo = 11,

		[System.ComponentModel.Description("Cargo transported in refrigerated containers, generally perishable commodities which require temperature-controlled transportation, such as fruit, meat, fish, vegetables, dairy products and other foods.")]
		[EnumMember(Value = "Reefer Container Cargo")] 
		[XmlEnum("12")] 
		ReeferContainerCargo = 12,

		[System.ComponentModel.Description("13:Ro-Ro cargo (missing definition)")]
		[EnumMember(Value = "Ro-Ro cargo")] 
		[XmlEnum("13")] 
		RoRoCargo = 13,

		[System.ComponentModel.Description("Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.")]
		[EnumMember(Value = "Project Cargo")] 
		[XmlEnum("14")] 
		ProjectCargo = 14,

		[System.ComponentModel.Description("Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.")]
		[EnumMember(Value = "Break Bulk Cargo")] 
		[XmlEnum("15")] 
		BreakBulkCargo = 15,
	}

	/// <summary>
	/// The indication of an element of a signal sequence being a period of light/sound or eclipse/silence.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalStatus : int {
		[System.ComponentModel.Description("1:lit/sound (missing definition)")]
		[EnumMember(Value = "lit/sound")] 
		[XmlEnum("1")] 
		LitSound = 1,

		[System.ComponentModel.Description("2:eclipsed/silent (missing definition)")]
		[EnumMember(Value = "eclipsed/silent")] 
		[XmlEnum("2")] 
		EclipsedSilent = 2,
	}

	/// <summary>
	/// Type of diving activity taking place. 
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum divingActivity : int {
		[System.ComponentModel.Description("501:Commercial Diving (missing definition)")]
		[EnumMember(Value = "Commercial Diving")] 
		[XmlEnum("501")] 
		CommercialDiving = 501,

		[System.ComponentModel.Description("502:Sports Diving (missing definition)")]
		[EnumMember(Value = "Sports Diving")] 
		[XmlEnum("502")] 
		SportsDiving = 502,

		[System.ComponentModel.Description("503:Dive Training (missing definition)")]
		[EnumMember(Value = "Dive Training")] 
		[XmlEnum("503")] 
		DiveTraining = 503,
	}

	/// <summary>
	/// The various conditions of buildings and other constructions.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum condition : int {
		[System.ComponentModel.Description("Being built but not yet capable of function.")]
		[EnumMember(Value = "Under Construction")] 
		[XmlEnum("1")] 
		UnderConstruction = 1,

		[System.ComponentModel.Description("A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.")]
		[EnumMember(Value = "Ruined")] 
		[XmlEnum("2")] 
		Ruined = 2,

		[System.ComponentModel.Description("An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.")]
		[EnumMember(Value = "Under Reclamation")] 
		[XmlEnum("3")] 
		UnderReclamation = 3,

		[System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,

		[System.ComponentModel.Description("completed, undamaged and working normally. ")]
		[EnumMember(Value = "Operational")] 
		[XmlEnum("501")] 
		Operational = 501,
	}

	/// <summary>
	/// Classification of the type and display level of the name of a feature in an end-user system.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum nameUsage : int {
		[System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
		[EnumMember(Value = "Default Name Display")] 
		[XmlEnum("1")] 
		DefaultNameDisplay = 1,

		[System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
		[EnumMember(Value = "Alternate Name Display")] 
		[XmlEnum("2")] 
		AlternateNameDisplay = 2,
	}

	/// <summary>
	/// Indication of the strength of the magnetic anomaly caused by the object.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum strengthOfMagneticAnomaly : int {
		[System.ComponentModel.Description("501:nil (missing definition)")]
		[EnumMember(Value = "nil")] 
		[XmlEnum("501")] 
		Nil = 501,

		[System.ComponentModel.Description("502:slight (missing definition)")]
		[EnumMember(Value = "slight")] 
		[XmlEnum("502")] 
		Slight = 502,

		[System.ComponentModel.Description("503:moderate (missing definition)")]
		[EnumMember(Value = "moderate")] 
		[XmlEnum("503")] 
		Moderate = 503,

		[System.ComponentModel.Description("Not easily broken or destroyed.")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("504")] 
		Strong = 504,
	}

	/// <summary>
	/// The nature of various forms of natural surface materials in terms of their size, morphology and consistency.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurfaceQualifyingTerms : int {
		[System.ComponentModel.Description("Falls within the smallest size continuum for a particular nature of surface term.")]
		[EnumMember(Value = "Fine")] 
		[XmlEnum("1")] 
		Fine = 1,

		[System.ComponentModel.Description("Falls within the moderate size continuum for a particular nature of surface term.")]
		[EnumMember(Value = "Medium")] 
		[XmlEnum("2")] 
		Medium = 2,

		[System.ComponentModel.Description("Falls within the largest size continuum for a particular nature of surface term.")]
		[EnumMember(Value = "Coarse")] 
		[XmlEnum("3")] 
		Coarse = 3,

		[System.ComponentModel.Description("Fractured or in pieces.")]
		[EnumMember(Value = "Broken")] 
		[XmlEnum("4")] 
		Broken = 4,

		[System.ComponentModel.Description("Having an adhesive or glue like property.")]
		[EnumMember(Value = "Sticky")] 
		[XmlEnum("5")] 
		Sticky = 5,

		[System.ComponentModel.Description("Not hard or firm.")]
		[EnumMember(Value = "Soft")] 
		[XmlEnum("6")] 
		Soft = 6,

		[System.ComponentModel.Description("Not pliant; thick, resistant to flow.")]
		[EnumMember(Value = "Stiff")] 
		[XmlEnum("7")] 
		Stiff = 7,

		[System.ComponentModel.Description("Composed of or containing material ejected from a volcano.")]
		[EnumMember(Value = "Volcanic")] 
		[XmlEnum("8")] 
		Volcanic = 8,

		[System.ComponentModel.Description("Composed of or containing calcium or calcium carbonate.")]
		[EnumMember(Value = "Calcareous")] 
		[XmlEnum("9")] 
		Calcareous = 9,

		[System.ComponentModel.Description("Firm; usually refers to an area of the seafloor not covered by unconsolidated sediment.")]
		[EnumMember(Value = "Hard")] 
		[XmlEnum("10")] 
		Hard = 10,
	}

	/// <summary>
	/// The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightCharacteristic : int {
		[System.ComponentModel.Description("A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
		[EnumMember(Value = "Fixed")] 
		[XmlEnum("1")] 
		Fixed = 1,

		[System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
		[EnumMember(Value = "Flashing")] 
		[XmlEnum("2")] 
		Flashing = 2,

		[System.ComponentModel.Description("3:long-flashing (missing definition)")]
		[EnumMember(Value = "long-flashing")] 
		[XmlEnum("3")] 
		LongFlashing = 3,

		[System.ComponentModel.Description("4:quick-flashing (missing definition)")]
		[EnumMember(Value = "quick-flashing")] 
		[XmlEnum("4")] 
		QuickFlashing = 4,

		[System.ComponentModel.Description("5:very quick-flashing (missing definition)")]
		[EnumMember(Value = "very quick-flashing")] 
		[XmlEnum("5")] 
		VeryQuickFlashing = 5,

		[System.ComponentModel.Description("6:ultra quick-flashing (missing definition)")]
		[EnumMember(Value = "ultra quick-flashing")] 
		[XmlEnum("6")] 
		UltraQuickFlashing = 6,

		[System.ComponentModel.Description("A light with all durations of light and darkness equal.")]
		[EnumMember(Value = "Isophased")] 
		[XmlEnum("7")] 
		Isophased = 7,

		[System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be: - Single-occulting: An occulting light in which an eclipse is regularly repeated. - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated. - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
		[EnumMember(Value = "Occulting")] 
		[XmlEnum("8")] 
		Occulting = 8,

		[System.ComponentModel.Description("A light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.")]
		[EnumMember(Value = "Interrupted Ultra Quick-Flashing")] 
		[XmlEnum("11")] 
		InterruptedUltraQuickFlashing = 11,

		[System.ComponentModel.Description("A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
		[EnumMember(Value = "Morse")] 
		[XmlEnum("12")] 
		Morse = 12,

		[System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Fixed and Flash")] 
		[XmlEnum("13")] 
		FixedAndFlash = 13,

		[System.ComponentModel.Description("14:flash and long-flash (missing definition)")]
		[EnumMember(Value = "flash and long-flash")] 
		[XmlEnum("14")] 
		FlashAndLongFlash = 14,

		[System.ComponentModel.Description("A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Occulting and Flash")] 
		[XmlEnum("15")] 
		OccultingAndFlash = 15,

		[System.ComponentModel.Description("16:fixed and long-flash (missing definition)")]
		[EnumMember(Value = "fixed and long-flash")] 
		[XmlEnum("16")] 
		FixedAndLongFlash = 16,

		[System.ComponentModel.Description("An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.")]
		[EnumMember(Value = "Occulting Alternating")] 
		[XmlEnum("17")] 
		OccultingAlternating = 17,

		[System.ComponentModel.Description("18:long-flash alternating (missing definition)")]
		[EnumMember(Value = "long-flash alternating")] 
		[XmlEnum("18")] 
		LongFlashAlternating = 18,

		[System.ComponentModel.Description("An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
		[EnumMember(Value = "Flash Alternating")] 
		[XmlEnum("19")] 
		FlashAlternating = 19,

		[System.ComponentModel.Description("25:quick-flash plus longflash (missing definition)")]
		[EnumMember(Value = "quick-flash plus longflash")] 
		[XmlEnum("25")] 
		QuickFlashPlusLongflash = 25,

		[System.ComponentModel.Description("26:very quick-flash plus long-flash (missing definition)")]
		[EnumMember(Value = "very quick-flash plus long-flash")] 
		[XmlEnum("26")] 
		VeryQuickFlashPlusLongFlash = 26,

		[System.ComponentModel.Description("27:ultra quick-flash plus (missing definition)")]
		[EnumMember(Value = "ultra quick-flash plus")] 
		[XmlEnum("27")] 
		UltraQuickFlashPlus = 27,

		[System.ComponentModel.Description("A signal light that shows continuously, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Alternating")] 
		[XmlEnum("28")] 
		Alternating = 28,

		[System.ComponentModel.Description("29:fixed and alternating (missing definition)")]
		[EnumMember(Value = "fixed and alternating")] 
		[XmlEnum("29")] 
		FixedAndAlternating = 29,
	}

	/// <summary>
	/// Classification of a place where vehicles or travellers are stopped for identification or inspection.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCheckpoint : int {
		[System.ComponentModel.Description("Serves as a government checkpoint where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
		[EnumMember(Value = "Custom")] 
		[XmlEnum("1")] 
		Custom = 1,

		[System.ComponentModel.Description("501:RV Location (missing definition)")]
		[EnumMember(Value = "RV Location")] 
		[XmlEnum("501")] 
		RvLocation = 501,
	}

	/// <summary>
	/// The shape a topmark or daymark exhibits.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[System.ComponentModel.Description("1:cone (point up) (missing definition)")]
		[EnumMember(Value = "cone (point up)")] 
		[XmlEnum("1")] 
		ConePointUp = 1,

		[System.ComponentModel.Description("2:cone (point down) (missing definition)")]
		[EnumMember(Value = "cone (point down)")] 
		[XmlEnum("2")] 
		ConePointDown = 2,

		[System.ComponentModel.Description("A curved surface all points of which are equidistant from a fixed point within, called the centre.")]
		[EnumMember(Value = "Sphere")] 
		[XmlEnum("3")] 
		Sphere = 3,

		[System.ComponentModel.Description("4:2 spheres (missing definition)")]
		[EnumMember(Value = "2 spheres")] 
		[XmlEnum("4")] 
		twoSpheres = 4,

		[System.ComponentModel.Description("A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, its ends being parallel circles).")]
		[EnumMember(Value = "Cylinder")] 
		[XmlEnum("5")] 
		Cylinder = 5,

		[System.ComponentModel.Description("Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
		[EnumMember(Value = "Board")] 
		[XmlEnum("6")] 
		Board = 6,

		[System.ComponentModel.Description("7:x-shaped (missing definition)")]
		[EnumMember(Value = "x-shaped")] 
		[XmlEnum("7")] 
		XShaped = 7,

		[System.ComponentModel.Description("A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.")]
		[EnumMember(Value = "Upright Cross")] 
		[XmlEnum("8")] 
		UprightCross = 8,

		[System.ComponentModel.Description("9:cube (point up) (missing definition)")]
		[EnumMember(Value = "cube (point up)")] 
		[XmlEnum("9")] 
		CubePointUp = 9,

		[System.ComponentModel.Description("10:2 cones (point to point) (missing definition)")]
		[EnumMember(Value = "2 cones (point to point)")] 
		[XmlEnum("10")] 
		twoConesPointToPoint = 10,

		[System.ComponentModel.Description("11:2 cones (base to base) (missing definition)")]
		[EnumMember(Value = "2 cones (base to base)")] 
		[XmlEnum("11")] 
		twoConesBaseToBase = 11,

		[System.ComponentModel.Description("A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.")]
		[EnumMember(Value = "Rhombus")] 
		[XmlEnum("12")] 
		Rhombus = 12,

		[System.ComponentModel.Description("13:2 cones (points upward) (missing definition)")]
		[EnumMember(Value = "2 cones (points upward)")] 
		[XmlEnum("13")] 
		twoConesPointsUpward = 13,

		[System.ComponentModel.Description("14:2 cones (points downward) (missing definition)")]
		[EnumMember(Value = "2 cones (points downward)")] 
		[XmlEnum("14")] 
		twoConesPointsDownward = 14,

		[System.ComponentModel.Description("15:besom (point up) (missing definition)")]
		[EnumMember(Value = "besom (point up)")] 
		[XmlEnum("15")] 
		BesomPointUp = 15,

		[System.ComponentModel.Description("16:besom (point down) (missing definition)")]
		[EnumMember(Value = "besom (point down)")] 
		[XmlEnum("16")] 
		BesomPointDown = 16,

		[System.ComponentModel.Description("A flag mounted on a short pole.")]
		[EnumMember(Value = "Flag")] 
		[XmlEnum("17")] 
		Flag = 17,

		[System.ComponentModel.Description("A sphere located above a rhombus.")]
		[EnumMember(Value = "Sphere Over a Rhombus")] 
		[XmlEnum("18")] 
		SphereOverARhombus = 18,

		[System.ComponentModel.Description("A plane figure with four right angles and four equal straight sides.")]
		[EnumMember(Value = "Square")] 
		[XmlEnum("19")] 
		Square = 19,

		[System.ComponentModel.Description("20:rectangle (horizontal) (missing definition)")]
		[EnumMember(Value = "rectangle (horizontal)")] 
		[XmlEnum("20")] 
		RectangleHorizontal = 20,

		[System.ComponentModel.Description("21:rectangle (vertical) (missing definition)")]
		[EnumMember(Value = "rectangle (vertical)")] 
		[XmlEnum("21")] 
		RectangleVertical = 21,

		[System.ComponentModel.Description("22:trapezium (up) (missing definition)")]
		[EnumMember(Value = "trapezium (up)")] 
		[XmlEnum("22")] 
		TrapeziumUp = 22,

		[System.ComponentModel.Description("23:trapezium (down) (missing definition)")]
		[EnumMember(Value = "trapezium (down)")] 
		[XmlEnum("23")] 
		TrapeziumDown = 23,

		[System.ComponentModel.Description("24:triangle (point up) (missing definition)")]
		[EnumMember(Value = "triangle (point up)")] 
		[XmlEnum("24")] 
		TrianglePointUp = 24,

		[System.ComponentModel.Description("25:triangle (point down) (missing definition)")]
		[EnumMember(Value = "triangle (point down)")] 
		[XmlEnum("25")] 
		TrianglePointDown = 25,

		[System.ComponentModel.Description("A perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
		[EnumMember(Value = "Circle")] 
		[XmlEnum("26")] 
		Circle = 26,

		[System.ComponentModel.Description("27:two upright crosses (one over the other) (missing definition)")]
		[EnumMember(Value = "two upright crosses (one over the other)")] 
		[XmlEnum("27")] 
		TwoUprightCrossesOneOverTheOther = 27,

		[System.ComponentModel.Description("28:T-shape (missing definition)")]
		[EnumMember(Value = "T-shape")] 
		[XmlEnum("28")] 
		TShape = 28,

		[System.ComponentModel.Description("A triangle, vertex uppermost, located above a circle.")]
		[EnumMember(Value = "Triangle Pointing Up Over a Circle")] 
		[XmlEnum("29")] 
		TrianglePointingUpOverACircle = 29,

		[System.ComponentModel.Description("An upright cross located above a circle.")]
		[EnumMember(Value = "Upright Cross Over a Circle")] 
		[XmlEnum("30")] 
		UprightCrossOverACircle = 30,

		[System.ComponentModel.Description("A rhombus located above a circle.")]
		[EnumMember(Value = "Rhombus Over a Circle")] 
		[XmlEnum("31")] 
		RhombusOverACircle = 31,

		[System.ComponentModel.Description("A circle located over a triangle, vertex uppermost.")]
		[EnumMember(Value = "Circle Over a Triangle Pointing Up")] 
		[XmlEnum("32")] 
		CircleOverATrianglePointingUp = 32,

		[System.ComponentModel.Description("33:other shape (see shape information) (missing definition)")]
		[EnumMember(Value = "other shape (see shape information)")] 
		[XmlEnum("33")] 
		OtherShapeSeeShapeInformation = 33,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofMarineProtectedArea : int {
		[System.ComponentModel.Description("Strict Nature Reserve: Protected area managed mainly for science.")]
		[EnumMember(Value = "IUCN Category Ia")] 
		[XmlEnum("1")] 
		IucnCategoryIa = 1,

		[System.ComponentModel.Description("Wilderness Area: Protected area managed mainly for wilderness protection.")]
		[EnumMember(Value = "IUCN Category Ib")] 
		[XmlEnum("2")] 
		IucnCategoryIb = 2,

		[System.ComponentModel.Description("National Park: Protected area managed mainly for ecosystem protection and recreation.")]
		[EnumMember(Value = "IUCN Category II")] 
		[XmlEnum("3")] 
		IucnCategoryIi = 3,

		[System.ComponentModel.Description("Natural Monument: Protected area managed mainly for conservation of specific natural features.")]
		[EnumMember(Value = "IUCN Category III")] 
		[XmlEnum("4")] 
		IucnCategoryIii = 4,

		[System.ComponentModel.Description("Habitat/Species Management Area: Protected area managed mainly for conservation through management intervention.")]
		[EnumMember(Value = "IUCN Category IV")] 
		[XmlEnum("5")] 
		IucnCategoryIv = 5,

		[System.ComponentModel.Description("Protected Landscape/Seascape: Protected area managed mainly for landscape/seascape conservation and recreation.")]
		[EnumMember(Value = "IUCN Category V")] 
		[XmlEnum("6")] 
		IucnCategoryV = 6,

		[System.ComponentModel.Description("Managed Resource Protected Area: Protected area managed mainly for the sustainable use of natural ecosystems.")]
		[EnumMember(Value = "IUCN Category VI")] 
		[XmlEnum("7")] 
		IucnCategoryVi = 7,
	}

	/// <summary>
	/// The building's primary construction material.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfConstruction : int {
		[System.ComponentModel.Description("Constructed of stones or bricks, usually quarried, shaped, and mortared.")]
		[EnumMember(Value = "Masonry")] 
		[XmlEnum("1")] 
		Masonry = 1,

		[System.ComponentModel.Description("Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
		[EnumMember(Value = "Concreted")] 
		[XmlEnum("2")] 
		Concreted = 2,

		[System.ComponentModel.Description("Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
		[EnumMember(Value = "Loose Boulders")] 
		[XmlEnum("3")] 
		LooseBoulders = 3,

		[System.ComponentModel.Description("4:hard surface (missing definition)")]
		[EnumMember(Value = "hard surface")] 
		[XmlEnum("4")] 
		HardSurface = 4,

		[System.ComponentModel.Description("Constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.")]
		[EnumMember(Value = "Unsurfaced")] 
		[XmlEnum("5")] 
		Unsurfaced = 5,

		[System.ComponentModel.Description("Constructed from wood.")]
		[EnumMember(Value = "Wooden")] 
		[XmlEnum("6")] 
		Wooden = 6,

		[System.ComponentModel.Description("Constructed from metal.")]
		[EnumMember(Value = "Metal")] 
		[XmlEnum("7")] 
		Metal = 7,

		[System.ComponentModel.Description("Constructed from a plastic material strengthened with fibres of glass.")]
		[EnumMember(Value = "Glass Reinforced Plastic")] 
		[XmlEnum("8")] 
		GlassReinforcedPlastic = 8,

		[System.ComponentModel.Description("A structure of crossed wooden or metal strips usually arranged to form a diagonal pattern of open spaces between the strips.")]
		[EnumMember(Value = "Latticed")] 
		[XmlEnum("11")] 
		Latticed = 11,

		[System.ComponentModel.Description("[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like. [2] Something made of such a substance, as a windowpane.")]
		[EnumMember(Value = "Glass")] 
		[XmlEnum("12")] 
		Glass = 12,
	}

	/// <summary>
	/// Classification of a post or group of posts, used for mooring or warping a vessel.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDolphin : int {
		[System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used as a mooring point for vessels.")]
		[EnumMember(Value = "Mooring Dolphin")] 
		[XmlEnum("1")] 
		MooringDolphin = 1,

		[System.ComponentModel.Description("A post or group of posts, which a vessel may swing around for compass adjustment.")]
		[EnumMember(Value = "Deviation Dolphin")] 
		[XmlEnum("2")] 
		DeviationDolphin = 2,

		[System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to extend the berth of a vessel by providing extra mooring points.")]
		[EnumMember(Value = "Berthing Dolphin")] 
		[XmlEnum("3")] 
		BerthingDolphin = 3,

		[System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to assist in berthing of vessels by taking up some berthing loads; keep vessels from pressing against the pier structure; or to protect structures from possible impact by ships.")]
		[EnumMember(Value = "Fender or Breasting Dolphin")] 
		[XmlEnum("4")] 
		FenderOrBreastingDolphin = 4,
	}

	/// <summary>
	/// The reliability of the value of a sounding.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfVerticalMeasurement : int {
		[System.ComponentModel.Description("The depth from the chart datum to the seabed (or to the top of a drying feature) is known.")]
		[EnumMember(Value = "Depth Known")] 
		[XmlEnum("1")] 
		DepthKnown = 1,

		[System.ComponentModel.Description("2:depth unknown (missing definition)")]
		[EnumMember(Value = "depth unknown")] 
		[XmlEnum("2")] 
		DepthUnknown = 2,

		[System.ComponentModel.Description("A depth that may be less than indicated.")]
		[EnumMember(Value = "Doubtful Sounding")] 
		[XmlEnum("3")] 
		DoubtfulSounding = 3,

		[System.ComponentModel.Description("A depth that is considered to be an unreliable value.")]
		[EnumMember(Value = "Unreliable Sounding")] 
		[XmlEnum("4")] 
		UnreliableSounding = 4,

		[System.ComponentModel.Description("The shoalest depth over a feature is of known value.")]
		[EnumMember(Value = "Least Depth Known")] 
		[XmlEnum("6")] 
		LeastDepthKnown = 6,

		[System.ComponentModel.Description("7:least depth unknown, safe clearance at value shown (missing definition)")]
		[EnumMember(Value = "least depth unknown, safe clearance at value shown")] 
		[XmlEnum("7")] 
		LeastDepthUnknownSafeClearanceAtValueShown = 7,

		[System.ComponentModel.Description("8:value reported (not surveyed) (missing definition)")]
		[EnumMember(Value = "value reported (not surveyed)")] 
		[XmlEnum("8")] 
		ValueReportedNotSurveyed = 8,

		[System.ComponentModel.Description("9:value reported (not confirmed) (missing definition)")]
		[EnumMember(Value = "value reported (not confirmed)")] 
		[XmlEnum("9")] 
		ValueReportedNotConfirmed = 9,

		[System.ComponentModel.Description("The depth at which a channel is kept by human influence, usually by dredging.")]
		[EnumMember(Value = "Maintained Depth")] 
		[XmlEnum("10")] 
		MaintainedDepth = 10,

		[System.ComponentModel.Description("Depths may be altered by human influence, but will not be routinely maintained.")]
		[EnumMember(Value = "Not Regularly Maintained")] 
		[XmlEnum("11")] 
		NotRegularlyMaintained = 11,
	}

	/// <summary>
	/// Classification of shoreline construction based on use.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfShorelineConstruction : int {
		[System.ComponentModel.Description("A structure protecting a shore area, harbour, anchorage, or basin from waves.")]
		[EnumMember(Value = "Breakwater")] 
		[XmlEnum("1")] 
		Breakwater = 1,

		[System.ComponentModel.Description("A low artificial wall-like structure of durable material extending from the land to seaward for a particular purpose, such as to protect the coast or to force a current to scour a channel.")]
		[EnumMember(Value = "Groyne")] 
		[XmlEnum("2")] 
		Groyne = 2,

		[System.ComponentModel.Description("A form of breakwater alongside which vessels may lie on the sheltered side only; in some cases it may lie entirely within an artificial harbour, permitting vessels to lie along both sides.")]
		[EnumMember(Value = "Mole")] 
		[XmlEnum("3")] 
		Mole = 3,

		[System.ComponentModel.Description("4:pier (jetty) (missing definition)")]
		[EnumMember(Value = "pier (jetty)")] 
		[XmlEnum("4")] 
		PierJetty = 4,

		[System.ComponentModel.Description("A pier built only for recreational purposes.")]
		[EnumMember(Value = "Promenade Pier")] 
		[XmlEnum("5")] 
		PromenadePier = 5,

		[System.ComponentModel.Description("6:wharf (quay) (missing definition)")]
		[EnumMember(Value = "wharf (quay)")] 
		[XmlEnum("6")] 
		WharfQuay = 6,

		[System.ComponentModel.Description("A wall or bank, often submerged, built to direct or confine the flow of a river or tidal current, or to promote a scour action.")]
		[EnumMember(Value = "Training Wall")] 
		[XmlEnum("7")] 
		TrainingWall = 7,

		[System.ComponentModel.Description("A layer of broken rock, cobbles, boulders, or fragments of sufficient size to resist the erosive forces of flowing water and wave action.")]
		[EnumMember(Value = "Rip Rap")] 
		[XmlEnum("8")] 
		RipRap = 8,

		[System.ComponentModel.Description("Facing of stone or other material, either permanent or temporary, placed along the edge of a stream, river or canal to stabilize the bank and to protect it from the erosive action of the stream.")]
		[EnumMember(Value = "Revetment")] 
		[XmlEnum("9")] 
		Revetment = 9,

		[System.ComponentModel.Description("An embankment or wall for protection against waves or tidal action along a shore or water front.")]
		[EnumMember(Value = "Sea Wall")] 
		[XmlEnum("10")] 
		SeaWall = 10,

		[System.ComponentModel.Description("Steps at the shoreline as the connection between land and water on different levels.")]
		[EnumMember(Value = "Landing Steps")] 
		[XmlEnum("11")] 
		LandingSteps = 11,

		[System.ComponentModel.Description("(1) A sloping structure which may include rails that can either be used, as a landing place, at variable water levels, for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel. (2) An accumulation of snow that forms an inclined plane between land or land ice elements and sea ice or ice shelf. Also called drift ice foot.")]
		[EnumMember(Value = "Ramp")] 
		[XmlEnum("12")] 
		Ramp = 12,

		[System.ComponentModel.Description("The prepared and usually reinforced inclined surface on which keel- and bilge-blocks are laid for supporting a vessel under construction.")]
		[EnumMember(Value = "Slipway")] 
		[XmlEnum("13")] 
		Slipway = 13,

		[System.ComponentModel.Description("A protective structure designed to cushion the impact of a vessel and prevent damage.")]
		[EnumMember(Value = "Fender")] 
		[XmlEnum("14")] 
		Fender = 14,

		[System.ComponentModel.Description("A wharf consisting of a solid wall of concrete, masonry, wood etc., such that the water cannot circulate freely under the wharf. The type of construction affects ship-handling; for example, a solid face wharf may give shelter from tidal streams, but under certain circumstances a cushion of water may build up between such a wharf and a ship attempting to berth at it, causing difficulties in ship handling.")]
		[EnumMember(Value = "Solid Face Wharf")] 
		[XmlEnum("15")] 
		SolidFaceWharf = 15,

		[System.ComponentModel.Description("A wharf supported on piles or other structures which allow free circulation of water under the wharf.")]
		[EnumMember(Value = "Open Face Wharf")] 
		[XmlEnum("16")] 
		OpenFaceWharf = 16,

		[System.ComponentModel.Description("An inclined plane used to dump logs into the water for transport, or to haul logs out of the water for processing.")]
		[EnumMember(Value = "Log Ramp")] 
		[XmlEnum("17")] 
		LogRamp = 17,

		[System.ComponentModel.Description("An artificial pool or swimming enclosure, especially one in the open air, which may be constructed of wire mesh or heavy netting supported by cables, buoys or piles, for swimming in.")]
		[EnumMember(Value = "Swimming Facility")] 
		[XmlEnum("20")] 
		SwimmingFacility = 20,

		[System.ComponentModel.Description("A wharf approximately parallel to the shoreline and accommodating ships on one side only, the other side being attached to the shore. It is usually of solid construction, as contrasted with the open pile construction usually used for piers.")]
		[EnumMember(Value = "Quay")] 
		[XmlEnum("22")] 
		Quay = 22,

		[System.ComponentModel.Description("23:tie-up wall (missing definition)")]
		[EnumMember(Value = "tie-up wall")] 
		[XmlEnum("23")] 
		TieUpWall = 23,

		[System.ComponentModel.Description("Man-made structure that acts as an obstacle to landing operations.")]
		[EnumMember(Value = "Artificial Obstacle")] 
		[XmlEnum("501")] 
		ArtificialObstacle = 501,
	}

	/// <summary>
	/// The specific visibility of a light, with respect to the light's intensity and ease of recognition.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightVisibility : int {
		[System.ComponentModel.Description("Non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).")]
		[EnumMember(Value = "High Intensity")] 
		[XmlEnum("1")] 
		HighIntensity = 1,

		[System.ComponentModel.Description("Non-marine lights with lower power than marine lights.")]
		[EnumMember(Value = "Low Intensity")] 
		[XmlEnum("2")] 
		LowIntensity = 2,

		[System.ComponentModel.Description("A decrease in the apparent intensity of a light which may occur in the case of partial obstructions.")]
		[EnumMember(Value = "Faint")] 
		[XmlEnum("3")] 
		Faint = 3,

		[System.ComponentModel.Description("A light in a sector is intensified (that is, has longer range than other sectors).")]
		[EnumMember(Value = "Intensified")] 
		[XmlEnum("4")] 
		Intensified = 4,

		[System.ComponentModel.Description("A light in a sector is unintensified (that is, has shorter range than other sectors).")]
		[EnumMember(Value = "Unintensified")] 
		[XmlEnum("5")] 
		Unintensified = 5,

		[System.ComponentModel.Description("A light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.")]
		[EnumMember(Value = "Visibility Deliberately Restricted")] 
		[XmlEnum("6")] 
		VisibilityDeliberatelyRestricted = 6,

		[System.ComponentModel.Description("Said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.")]
		[EnumMember(Value = "Obscured")] 
		[XmlEnum("7")] 
		Obscured = 7,

		[System.ComponentModel.Description("This value specifies that parts of the sector are obscured.")]
		[EnumMember(Value = "Partially Obscured")] 
		[XmlEnum("8")] 
		PartiallyObscured = 8,

		[System.ComponentModel.Description("Lights that must be in line to be visible.")]
		[EnumMember(Value = "Visible in Line of Range")] 
		[XmlEnum("9")] 
		VisibleInLineOfRange = 9,
	}

	/// <summary>
	/// Classification of an area based on its physical characteristics.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSeaArea : int {
		[System.ComponentModel.Description("A natural or artificial passage or channel through shoals or steep banks, or across a line of banks lying between two channels.")]
		[EnumMember(Value = "Gat")] 
		[XmlEnum("2")] 
		Gat = 2,

		[System.ComponentModel.Description("An elevation of the seafloor, at depths generally less than 200 m, but sufficient for safe surface navigation, commonly found on the continental shelf or near an island.")]
		[EnumMember(Value = "Bank")] 
		[XmlEnum("3")] 
		Bank = 3,

		[System.ComponentModel.Description("In oceanography, an obsolete term which was generally restricted to depths greater than 6,000 m.")]
		[EnumMember(Value = "Deep")] 
		[XmlEnum("4")] 
		Deep = 4,

		[System.ComponentModel.Description("A wide indentation in the coastline generally smaller than a gulf and larger than a cove. For the purposes of the United Nations Convention on the Law of the Sea, a bay is a well-marked indentation whose penetration is in such proportion to the width of its mouth as to contain land locked waters and constitute more than a mere curvature of the coast.")]
		[EnumMember(Value = "Bay")] 
		[XmlEnum("5")] 
		Bay = 5,

		[System.ComponentModel.Description("A long, deep, asymmetrical depression with relatively steep sides, that is associated with subduction.")]
		[EnumMember(Value = "Trench")] 
		[XmlEnum("6")] 
		Trench = 6,

		[System.ComponentModel.Description("A depression of the seafloor more or less equidimensional in plan and of variable extent.")]
		[EnumMember(Value = "Basin")] 
		[XmlEnum("7")] 
		Basin = 7,

		[System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
		[EnumMember(Value = "Mud Flats")] 
		[XmlEnum("8")] 
		MudFlats = 8,

		[System.ComponentModel.Description("A shallow elevation composed of consolidated material that may constitute a hazard to surface navigation.")]
		[EnumMember(Value = "Reef")] 
		[XmlEnum("9")] 
		Reef = 9,

		[System.ComponentModel.Description("A rocky formation continuous with and fringing the shore.")]
		[EnumMember(Value = "Ledge")] 
		[XmlEnum("10")] 
		Ledge = 10,

		[System.ComponentModel.Description("An elongated, narrow, steep-sided depression that generally deepens down-slope.")]
		[EnumMember(Value = "Canyon")] 
		[XmlEnum("11")] 
		Canyon = 11,

		[System.ComponentModel.Description("A navigable narrow part of a bay, strait, river, etc.")]
		[EnumMember(Value = "Narrows")] 
		[XmlEnum("12")] 
		Narrows = 12,

		[System.ComponentModel.Description("A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.")]
		[EnumMember(Value = "Shoal")] 
		[XmlEnum("13")] 
		Shoal = 13,

		[System.ComponentModel.Description("A distinct elevation with a rounded profile less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
		[EnumMember(Value = "Knoll")] 
		[XmlEnum("14")] 
		Knoll = 14,

		[System.ComponentModel.Description("An elongated elevation of varying complexity and size, generally having steep sides.")]
		[EnumMember(Value = "Ridge")] 
		[XmlEnum("15")] 
		Ridge = 15,

		[System.ComponentModel.Description("A distinct generally equidimensional elevation greater than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
		[EnumMember(Value = "Seamount")] 
		[XmlEnum("16")] 
		Seamount = 16,

		[System.ComponentModel.Description("Any high tower or spire-shaped pillar or rock or coral, alone or cresting a summit. It may extend above the surface of the water. It may or may not be a hazard to surface navigation.")]
		[EnumMember(Value = "Pinnacle")] 
		[XmlEnum("17")] 
		Pinnacle = 17,

		[System.ComponentModel.Description("An extensive, flat, gently sloping or nearly level region at abyssal depths.")]
		[EnumMember(Value = "Abyssal Plain")] 
		[XmlEnum("18")] 
		AbyssalPlain = 18,

		[System.ComponentModel.Description("A large, relatively flat elevation that is higher than the surrounding relief with one or more relatively steep sides.")]
		[EnumMember(Value = "Plateau")] 
		[XmlEnum("19")] 
		Plateau = 19,

		[System.ComponentModel.Description("A subordinate ridge protruding from a larger feature.")]
		[EnumMember(Value = "Spur")] 
		[XmlEnum("20")] 
		Spur = 20,

		[System.ComponentModel.Description("The flat or gently sloping region adjacent to a continent or around an island that extends from the low water line to a depth, generally about 200m, where there is a marked increase in downward slope.")]
		[EnumMember(Value = "Shelf")] 
		[XmlEnum("21")] 
		Shelf = 21,

		[System.ComponentModel.Description("A long depression generally wide and flat bottomed with symmetrical and parallel sides.")]
		[EnumMember(Value = "Trough")] 
		[XmlEnum("22")] 
		Trough = 22,

		[System.ComponentModel.Description("A broad pass or col in a ridge, rise or other elevation.")]
		[EnumMember(Value = "Saddle")] 
		[XmlEnum("23")] 
		Saddle = 23,

		[System.ComponentModel.Description("An isolated small elevation on the deep seafloor.")]
		[EnumMember(Value = "Abyssal Hill")] 
		[XmlEnum("24")] 
		AbyssalHill = 24,

		[System.ComponentModel.Description("A gently dipping slope, with a smooth surface, commonly found around groups of islands and seamounts.")]
		[EnumMember(Value = "Apron")] 
		[XmlEnum("25")] 
		Apron = 25,

		[System.ComponentModel.Description("A gentle slope with a generally smooth surface of the seafloor, characteristically found around groups of islands or seamounts.")]
		[EnumMember(Value = "Archipelagic Apron")] 
		[XmlEnum("26")] 
		ArchipelagicApron = 26,

		[System.ComponentModel.Description("A region adjacent to a continent, normally occupied by or bordering a shelf and sometimes emerging as islands, that is irregular or blocky in plan or profile, with depths well in excess of those typical of a shelf.")]
		[EnumMember(Value = "Borderland")] 
		[XmlEnum("27")] 
		Borderland = 27,

		[System.ComponentModel.Description("The zone, generally consisting of shelf, slope and continental rise, separating the continent from the deep seafloor or abyssal plain or plain. Occasionally a trench may be present in place of a continental rise.")]
		[EnumMember(Value = "Continental Margin")] 
		[XmlEnum("28")] 
		ContinentalMargin = 28,

		[System.ComponentModel.Description("A gentle slope rising from the oceanic depths towards the foot of a continental slope.")]
		[EnumMember(Value = "Continental Rise")] 
		[XmlEnum("29")] 
		ContinentalRise = 29,

		[System.ComponentModel.Description("An elongated, characteristically linear, steep slope separating horizontal or gently sloping areas of the seafloor.")]
		[EnumMember(Value = "Escarpment")] 
		[XmlEnum("30")] 
		Escarpment = 30,

		[System.ComponentModel.Description("A relatively smooth, depositional feature continuously deepening away from a sediment source commonly located at the lower termination of a canyon or canyon system.")]
		[EnumMember(Value = "Fan")] 
		[XmlEnum("31")] 
		Fan = 31,

		[System.ComponentModel.Description("A long narrow zone of irregular topography formed by the movement of tectonic plates associated with an offset of a spreading ridge axis, characterized by steep-sided and/or asymmetrical ridges, troughs or escarpments.")]
		[EnumMember(Value = "Fracture Zone")] 
		[XmlEnum("32")] 
		FractureZone = 32,

		[System.ComponentModel.Description("A narrow break in a ridge, rise or other elevation.")]
		[EnumMember(Value = "Gap")] 
		[XmlEnum("33")] 
		Gap = 33,

		[System.ComponentModel.Description("A seamount having a comparatively smooth flat top.")]
		[EnumMember(Value = "Guyot")] 
		[XmlEnum("34")] 
		Guyot = 34,

		[System.ComponentModel.Description("[1] A small isolated elevation, smaller than a mountain. [2] A distinct elevation generally of irregular shape, less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
		[EnumMember(Value = "Hill")] 
		[XmlEnum("35")] 
		Hill = 35,

		[System.ComponentModel.Description("A depression of limited extent with all sides rising steeply from a relatively flat bottom.")]
		[EnumMember(Value = "Hole")] 
		[XmlEnum("36")] 
		Hole = 36,

		[System.ComponentModel.Description("A depositional embankment bordering a canyon, valley or sea channel.")]
		[EnumMember(Value = "Levee")] 
		[XmlEnum("37")] 
		Levee = 37,

		[System.ComponentModel.Description("The axial depression of the mid-oceanic ridge system.")]
		[EnumMember(Value = "Median Valley")] 
		[XmlEnum("38")] 
		MedianValley = 38,

		[System.ComponentModel.Description("An annular or partially annular depression commonly located at the base of seamounts, islands and other isolated elevations.")]
		[EnumMember(Value = "Moat")] 
		[XmlEnum("39")] 
		Moat = 39,

		[System.ComponentModel.Description("A natural elevation of the earth's surface rising more or less abruptly from the surrounding level, and attaining an altitude which, relatively to adjacent elevations, is impressive or notable.")]
		[EnumMember(Value = "Mountains")] 
		[XmlEnum("40")] 
		Mountains = 40,

		[System.ComponentModel.Description("A conical or pointed elevation on a larger feature such as a seamount.")]
		[EnumMember(Value = "Peak")] 
		[XmlEnum("41")] 
		Peak = 41,

		[System.ComponentModel.Description("A geographically distinct region with a number of shared physiographic characteristics that contrast with those in the surrounding areas. This term should be modified with the generic term that best describes the majority of features in the region, for example \"Seamount\" in Baja California Seamount Province.")]
		[EnumMember(Value = "Province")] 
		[XmlEnum("42")] 
		Province = 42,

		[System.ComponentModel.Description("A broad elevation that generally rises gently and smoothly from the surrounding relief.")]
		[EnumMember(Value = "Rise")] 
		[XmlEnum("43")] 
		Rise = 43,

		[System.ComponentModel.Description("An elongated, meandering depression, usually occurring on a gently sloping plain or fan.")]
		[EnumMember(Value = "Sea Channel")] 
		[XmlEnum("44")] 
		SeaChannel = 44,

		[System.ComponentModel.Description("Several seamounts in linear or arcuate alignment.")]
		[EnumMember(Value = "Seamount Chain")] 
		[XmlEnum("45")] 
		SeamountChain = 45,

		[System.ComponentModel.Description("46:shelf-edge (missing definition)")]
		[EnumMember(Value = "shelf-edge")] 
		[XmlEnum("46")] 
		ShelfEdge = 46,

		[System.ComponentModel.Description("A relatively shallow barrier between BASINS that may inhibit water movement.")]
		[EnumMember(Value = "Sill")] 
		[XmlEnum("47")] 
		Sill = 47,

		[System.ComponentModel.Description("The sloping region that deepens from a shelf to the point where there is a general decrease in gradient.")]
		[EnumMember(Value = "Slope")] 
		[XmlEnum("48")] 
		Slope = 48,

		[System.ComponentModel.Description("A flat or gently sloping region, generally long and narrow, bounded along one edge by a steeper descending slope and along the other by a steeper ascending slope.")]
		[EnumMember(Value = "Terrace")] 
		[XmlEnum("49")] 
		Terrace = 49,

		[System.ComponentModel.Description("An elongated depression that generally widens and deepens down-slope.")]
		[EnumMember(Value = "Valley")] 
		[XmlEnum("50")] 
		Valley = 50,

		[System.ComponentModel.Description("An artificial waterway with no flow, or a controlled flow, used for navigation, or for draining or irrigating land (ditch).")]
		[EnumMember(Value = "Canal")] 
		[XmlEnum("51")] 
		Canal = 51,

		[System.ComponentModel.Description("A large body of water entirely surrounded by land.")]
		[EnumMember(Value = "Lake")] 
		[XmlEnum("52")] 
		Lake = 52,

		[System.ComponentModel.Description("A relatively large natural stream of water.")]
		[EnumMember(Value = "River")] 
		[XmlEnum("53")] 
		River = 53,

		[System.ComponentModel.Description("A straight section of a river, especially a navigable river between two bends; or an arm of the sea extending into the land.")]
		[EnumMember(Value = "Reach")] 
		[XmlEnum("54")] 
		Reach = 54,

		[System.ComponentModel.Description("A low, flat island of sand, coral, etc. awash or submerged at high water.")]
		[EnumMember(Value = "Intertidal Cay")] 
		[XmlEnum("55")] 
		IntertidalCay = 55,

		[System.ComponentModel.Description("A seabed volcano, submerged at the chart sounding datum, which may or may not be active.")]
		[EnumMember(Value = "Submarine Volcano")] 
		[XmlEnum("56")] 
		SubmarineVolcano = 56,
	}

	/// <summary>
	/// Classification of conveyor used for moving goods from one location to another.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfConveyor : int {
		[System.ComponentModel.Description("A transportation system consisting of load cables strung between pylons on which carrier units (for example: cars or buckets intended to transport people, material, and/or equipment) are suspended.")]
		[EnumMember(Value = "Aerial Cableway")] 
		[XmlEnum("1")] 
		AerialCableway = 1,

		[System.ComponentModel.Description("A conveyor along which material or people are transported by means of a moving belt.")]
		[EnumMember(Value = "Belt Conveyor")] 
		[XmlEnum("2")] 
		BeltConveyor = 2,

		[System.ComponentModel.Description("An artificial channel, usually an inclined chute or trough, for carrying water to furnish power, transport logs down a mountainside, etc.")]
		[EnumMember(Value = "Flume")] 
		[XmlEnum("3")] 
		Flume = 3,

		[System.ComponentModel.Description("4:lift/elevator (missing definition)")]
		[EnumMember(Value = "lift/elevator")] 
		[XmlEnum("4")] 
		LiftElevator = 4,
	}

	/// <summary>
	/// Classification of a road based on size.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRoad : int {
		[System.ComponentModel.Description("A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.")]
		[EnumMember(Value = "Motorway")] 
		[XmlEnum("1")] 
		Motorway = 1,

		[System.ComponentModel.Description("A hard surfaced (metalled) road; a main through route.")]
		[EnumMember(Value = "Major Road")] 
		[XmlEnum("2")] 
		MajorRoad = 2,

		[System.ComponentModel.Description("A secondary road for local traffic.")]
		[EnumMember(Value = "Minor Road")] 
		[XmlEnum("3")] 
		MinorRoad = 3,

		[System.ComponentModel.Description("4:track/path (missing definition)")]
		[EnumMember(Value = "track/path")] 
		[XmlEnum("4")] 
		TrackPath = 4,

		[System.ComponentModel.Description("A main road, in an urban area, for through traffic.")]
		[EnumMember(Value = "Major Street")] 
		[XmlEnum("5")] 
		MajorStreet = 5,

		[System.ComponentModel.Description("A secondary road, in an urban area, for local traffic.")]
		[EnumMember(Value = "Minor Street")] 
		[XmlEnum("6")] 
		MinorStreet = 6,
	}

	/// <summary>
	/// Classification of naturally occurring bottom features on the seabed.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum bottomFeatureClassification : int {
		[System.ComponentModel.Description("In geology, a break of shear in the earth's crust with an observable displacement between the two sides of the break, and parallel to the plane of the break.")]
		[EnumMember(Value = "Fault")] 
		[XmlEnum("502")] 
		Fault = 502,

		[System.ComponentModel.Description("A large mobile wave-like sediment feature in shallow water and composed of sand. The wavelength may reach 100 metres, the amplitude may be up to 20 metres.")]
		[EnumMember(Value = "Sandwave")] 
		[XmlEnum("510")] 
		Sandwave = 510,
	}

	/// <summary>
	/// The unit used for vessel characteristics attribute.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.")]
		[EnumMember(Value = "Metric Ton")] 
		[XmlEnum("3")] 
		MetricTon = 3,

		[System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
		[EnumMember(Value = "Ton")] 
		[XmlEnum("4")] 
		Ton = 4,

		[System.ComponentModel.Description("A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
		[EnumMember(Value = "Short Ton")] 
		[XmlEnum("5")] 
		ShortTon = 5,

		[System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
		[EnumMember(Value = "Gross Ton")] 
		[XmlEnum("6")] 
		GrossTon = 6,

		[System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
		[EnumMember(Value = "Net Ton")] 
		[XmlEnum("7")] 
		NetTon = 7,
	}

	/// <summary>
	/// Indicates by the use of which sensor the object was originally reported
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum firstSensor : int {
		[System.ComponentModel.Description("501:acoustic sensor (missing definition)")]
		[EnumMember(Value = "acoustic sensor")] 
		[XmlEnum("501")] 
		AcousticSensor = 501,

		[System.ComponentModel.Description("the object was reported as a result of detecting a fluctuation in the local magnetic field.")]
		[EnumMember(Value = "Magnetic Sensor")] 
		[XmlEnum("502")] 
		MagneticSensor = 502,

		[System.ComponentModel.Description("503:video sensor (missing definition)")]
		[EnumMember(Value = "video sensor")] 
		[XmlEnum("503")] 
		VideoSensor = 503,

		[System.ComponentModel.Description("504:diver sighting - (found by diver - in registry) (missing definition)")]
		[EnumMember(Value = "diver sighting - (found by diver - in registry)")] 
		[XmlEnum("504")] 
		DiverSightingFoundByDiverInRegistry = 504,

		[System.ComponentModel.Description("506:physical snag (missing definition)")]
		[EnumMember(Value = "physical snag")] 
		[XmlEnum("506")] 
		PhysicalSnag = 506,

		[System.ComponentModel.Description("507:observed sinking (missing definition)")]
		[EnumMember(Value = "observed sinking")] 
		[XmlEnum("507")] 
		ObservedSinking = 507,

		[System.ComponentModel.Description("508:Reported Sinking (missing definition)")]
		[EnumMember(Value = "Reported Sinking")] 
		[XmlEnum("508")] 
		ReportedSinking = 508,

		[System.ComponentModel.Description("509:None reported (missing definition)")]
		[EnumMember(Value = "None reported")] 
		[XmlEnum("509")] 
		NoneReported = 509,
	}

	/// <summary>
	/// The effect of the surrounding water on an object.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum waterLevelEffect : int {
		[System.ComponentModel.Description("Partially covered and partially dry at high water.")]
		[EnumMember(Value = "Partly Submerged at High Water")] 
		[XmlEnum("1")] 
		PartlySubmergedAtHighWater = 1,

		[System.ComponentModel.Description("Not covered at high water under average meteorological conditions.")]
		[EnumMember(Value = "Always Dry")] 
		[XmlEnum("2")] 
		AlwaysDry = 2,

		[System.ComponentModel.Description("3:always under water/ (missing definition)")]
		[EnumMember(Value = "always under water/")] 
		[XmlEnum("3")] 
		AlwaysUnderWater = 3,

		[System.ComponentModel.Description("Expression intended to indicate an area of a reef or other projection from the bottom of a body of water which periodically extends above and is submerged below the surface. Also referred to as dries or uncovers.")]
		[EnumMember(Value = "Covers and Uncovers")] 
		[XmlEnum("4")] 
		CoversAndUncovers = 4,

		[System.ComponentModel.Description("Flush with, or washed by the waves at low water under average meteorological conditions.")]
		[EnumMember(Value = "Awash")] 
		[XmlEnum("5")] 
		Awash = 5,

		[System.ComponentModel.Description("6:subject to inundation or (missing definition)")]
		[EnumMember(Value = "subject to inundation or")] 
		[XmlEnum("6")] 
		SubjectToInundationOr = 6,

		[System.ComponentModel.Description("Resting or moving on the surface of a liquid without sinking.")]
		[EnumMember(Value = "Floating")] 
		[XmlEnum("7")] 
		Floating = 7,
	}

	/// <summary>
	/// Identifies the status of a boundary
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum boundaryStatusType : int {
		[System.ComponentModel.Description("501:definite (missing definition)")]
		[EnumMember(Value = "definite")] 
		[XmlEnum("501")] 
		Definite = 501,

		[System.ComponentModel.Description("502:indefinite (missing definition)")]
		[EnumMember(Value = "indefinite")] 
		[XmlEnum("502")] 
		Indefinite = 502,

		[System.ComponentModel.Description("Has not been defined by either of the adjoining authorities.")]
		[EnumMember(Value = "no defined boundary")] 
		[XmlEnum("504")] 
		NoDefinedBoundary = 504,

		[System.ComponentModel.Description("Boundary has not been ratified")]
		[EnumMember(Value = "Not Yet Ratified")] 
		[XmlEnum("599")] 
		NotYetRatified = 599,
	}

	/// <summary>
	/// The mechanism used to generate a fog or light signal.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalGeneration : int {
		[System.ComponentModel.Description("Activated by radio signal.")]
		[EnumMember(Value = "Radio Activated")] 
		[XmlEnum("5")] 
		RadioActivated = 5,

		[System.ComponentModel.Description("Activated by making a call to a manned station.")]
		[EnumMember(Value = "Call Activated")] 
		[XmlEnum("6")] 
		CallActivated = 6,
	}

	/// <summary>
	/// missing definition
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum speciesGrouping : int {
		[System.ComponentModel.Description("Any of an order (Cetacea) of aquatic mostly marine mammals that includes the whales, dolphins, porpoises, and related forms and that have a torpedo-shaped nearly hairless body, paddle-shaped forelimbs but no hind limbs, one or two nares opening externally at the top of the head, and a horizontally flattened tail used for locomotion.")]
		[EnumMember(Value = "Cetacean")] 
		[XmlEnum("501")] 
		Cetacean = 501,

		[System.ComponentModel.Description("Any of an order or suborder (Pinnipedia) of aquatic carnivorous mammals (such as a seal or walrus) with all four limbs modified into flippers.")]
		[EnumMember(Value = "Pinniped")] 
		[XmlEnum("502")] 
		Pinniped = 502,

		[System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
		[EnumMember(Value = "Fish")] 
		[XmlEnum("503")] 
		Fish = 503,

		[System.ComponentModel.Description("Any of an order (Testudines synonym Chelonia) of terrestrial, freshwater, and marine reptiles that have a toothless horny beak and a shell of bony dermal plates usually covered with horny shields enclosing the trunk and into which the head, limbs, and tail usually may be withdrawn.")]
		[EnumMember(Value = "Turtle")] 
		[XmlEnum("504")] 
		Turtle = 504,

		[System.ComponentModel.Description("Any of a class (Aves) of warm-blooded vertebrates distinguished by having the body more or less completely covered with feathers and the forelimbs modified as wings.")]
		[EnumMember(Value = "Bird")] 
		[XmlEnum("505")] 
		Bird = 505,

		[System.ComponentModel.Description("Any of an order (Sirenia) of aquatic herbivorous mammals (such as a manatee, dugong, or Steller's sea cow) that have large forelimbs resembling paddles, no hind limbs, and a flattened tail resembling a fin.")]
		[EnumMember(Value = "Sirenian")] 
		[XmlEnum("506")] 
		Sirenian = 506,

		[System.ComponentModel.Description("507:Otter (animal) (missing definition)")]
		[EnumMember(Value = "Otter (animal)")] 
		[XmlEnum("507")] 
		OtterAnimal = 507,

		[System.ComponentModel.Description("A large creamy-white carnivorous bear (Ursus maritimus synonym Thalarctos maritimus) that inhabits arctic regions.")]
		[EnumMember(Value = "Polar bear")] 
		[XmlEnum("508")] 
		PolarBear = 508,

		[System.ComponentModel.Description("Any of numerous venomous aquatic chiefly viviparous elapid snakes of warm seas.")]
		[EnumMember(Value = "Sea snake")] 
		[XmlEnum("509")] 
		SeaSnake = 509,

		[System.ComponentModel.Description("A reef, often of large extent, composed chiefly of coral and its derivatives.")]
		[EnumMember(Value = "Coral Reef")] 
		[XmlEnum("510")] 
		CoralReef = 510,
	}

	/// <summary>
	/// Category of reporting/radio calling-in point.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfReportingRadioCallingInPoint : int {
		[System.ComponentModel.Description("501:Reporting/Radio calling in point (missing definition)")]
		[EnumMember(Value = "Reporting/Radio calling in point")] 
		[XmlEnum("501")] 
		ReportingRadioCallingInPoint = 501,
	}

	/// <summary>
	/// Classification of fishing facility provided based on different fishing methods.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFishingFacility : int {
		[System.ComponentModel.Description("Poles or stakes placed in shallow water to outline a fishing ground or to catch fish.")]
		[EnumMember(Value = "Fishing Stake")] 
		[XmlEnum("1")] 
		FishingStake = 1,

		[System.ComponentModel.Description("A structure (usually portable) for catching fish.")]
		[EnumMember(Value = "Fish Trap")] 
		[XmlEnum("2")] 
		FishTrap = 2,

		[System.ComponentModel.Description("A fence of stakes or stones set in a river or along the shore to trap fish.")]
		[EnumMember(Value = "Fish Weir")] 
		[XmlEnum("3")] 
		FishWeir = 3,

		[System.ComponentModel.Description("A net built at sea for catching tunny.")]
		[EnumMember(Value = "Tunny Net")] 
		[XmlEnum("4")] 
		TunnyNet = 4,
	}

	public static class CodeList
	{
	}

	namespace ComplexAttributes {
		/// <summary>
		/// The predefined span on clearance, determined after assessing geographical and Mine Countermeasure (MCM) conditions, within which a designated Q Route operates.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class qRouteChannelWidth {
			[XmlElement("rightQRouteWidth")]
			public required decimal? rightQRouteWidth {get;set;} = default;
		}

		/// <summary>
		/// The range in years in which the object was originally reported
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class detectionDateRange {
			[XmlElement("lastDetectionYear")]
			public String? lastDetectionYear {get;set;} = default;

			public bool ShouldSerializelastDetectionYear() { return !string.IsNullOrEmpty(lastDetectionYear); }

			[XmlElement("firstDetectionYear")]
			public String? firstDetectionYear {get;set;} = default;

			public bool ShouldSerializefirstDetectionYear() { return !string.IsNullOrEmpty(firstDetectionYear); }
		}

		/// <summary>
		/// The number of features of identical character that exist as a co-located group.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class multiplicityOfFeatures {
			[XmlElement("numberOfFeatures")]
			public int? numberOfFeatures {get;set;} = default;

			public bool ShouldSerializenumberOfFeatures() { return numberOfFeatures.HasValue; }

			[XmlElement("multiplicityKnown")]
			public required Boolean? multiplicityKnown {get;set;} = default;
		}

		/// <summary>
		/// Information about online sources from which a resource or data can be obtained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("linkage")]
			public required String? linkage {get;set;} = default;

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }
		}

		/// <summary>
		/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			public nameUsage? nameUsage {get;set;} = default;

			[JsonIgnore]
			[XmlElement("nameUsage")]
			public SerializableEnumeration<nameUsage>? nameUsageElement { get { return nameUsage; } set { } }

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }

			[XmlElement("name")]
			public required String? name {get;set;} = default;

			[XmlElement("language")]
			public required String? language {get;set;} = default;
		}

		/// <summary>
		/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class fixedDateRange {
			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			[XmlElement("dateEnd")]
			public String? dateEnd {get;set;} = default;

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }
		}

		/// <summary>
		/// Altitude range encompasses both the maximum and minimum heights (AGL - above ground level) above the surface level, representing the vertical span from the highest to the lowest point of the feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class altitudeRange {
			[XmlElement("minimumAltitude")]
			public required int? minimumAltitude {get;set;} = default;

			[XmlElement("maximumAltitude")]
			public required int? maximumAltitude {get;set;} = default;
		}

		/// <summary>
		/// (1) The vertical distance of a level, a point or an object considered as a point (but not affixed to the surface of the earth), measured from a given datum, usually mean sea level. See also elevation and height. (2) In astronomy, the vertical angle between the plane of the horizon and the line to a celestial body. See also angle of depression and angle of elevation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class altitude {
			[XmlElement("minimumAltitude")]
			public required int? minimumAltitude {get;set;} = default;

			[XmlElement("maximumAltitude")]
			public required int? maximumAltitude {get;set;} = default;
		}

		/// <summary>
		/// The source and the sensor used of the subsequent report of the object. 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lastSourceInformation {
			[XmlIgnore]
			[EnumerationValue([501,502,503,504,506,509])]
			public lastSensor? lastSensor {get;set;} = default;

			[JsonIgnore]
			[XmlElement("lastSensor")]
			public SerializableEnumeration<lastSensor>? lastSensorElement { get { return lastSensor; } set { } }

			public bool ShouldSerializelastSensor() { return lastSensor.HasValue; }

			[XmlElement("lastSource")]
			public String? lastSource {get;set;} = default;

			public bool ShouldSerializelastSource() { return !string.IsNullOrEmpty(lastSource); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		/// <summary>
		/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("language")]
			public required String? language {get;set;} = default;

			[XmlElement("fileLocator")]
			public String? fileLocator {get;set;} = default;

			public bool ShouldSerializefileLocator() { return !string.IsNullOrEmpty(fileLocator); }

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }

			[XmlElement("fileReference")]
			public String? fileReference {get;set;} = default;

			public bool ShouldSerializefileReference() { return !string.IsNullOrEmpty(fileReference); }
		}

		/// <summary>
		/// The source and the sensor used of the original report of the object.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class firstSourceInformation {
			[XmlIgnore]
			[EnumerationValue([501,502,503,504,506,509])]
			public required firstSensor? firstSensor {get;set;} = default;

			[JsonIgnore]
			[XmlElement("firstSensor")]
			public SerializableEnumeration<firstSensor>? firstSensorElement { get { return firstSensor.HasValue ? firstSensor : default; } set { } }

			[XmlElement("firstSource")]
			public String? firstSource {get;set;} = default;

			public bool ShouldSerializefirstSource() { return !string.IsNullOrEmpty(firstSource); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		/// <summary>
		/// The horizontal clearance measured between two points for a fixed span.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalClearanceFixed {
			[XmlElement("horizontalClearanceValue")]
			public required decimal? horizontalClearanceValue {get;set;} = default;

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }
		}

		/// <summary>
		/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty {
			[XmlElement("uncertaintyVariableFactor")]
			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }

			[XmlElement("uncertaintyFixed")]
			public required decimal? uncertaintyFixed {get;set;} = default;
		}

		/// <summary>
		/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			[XmlElement("frequencyShoreStationReceives")]
			public int? frequencyShoreStationReceives {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }

			[XmlElement("frequencyShoreStationTransmits")]
			public required int? frequencyShoreStationTransmits {get;set;} = default;
		}

		/// <summary>
		/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselMeasurementsSpecification {
			[XmlElement("vesselsCharacteristicsValue")]
			public required decimal? vesselsCharacteristicsValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,10,11])]
			public required vesselsCharacteristics? vesselsCharacteristics {get;set;} = default;

			[JsonIgnore]
			[XmlElement("vesselsCharacteristics")]
			public SerializableEnumeration<vesselsCharacteristics>? vesselsCharacteristicsElement { get { return vesselsCharacteristics.HasValue ? vesselsCharacteristics : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7])]
			public required vesselsCharacteristicsUnit? vesselsCharacteristicsUnit {get;set;} = default;

			[JsonIgnore]
			[XmlElement("vesselsCharacteristicsUnit")]
			public SerializableEnumeration<vesselsCharacteristicsUnit>? vesselsCharacteristicsUnitElement { get { return vesselsCharacteristicsUnit.HasValue ? vesselsCharacteristicsUnit : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public comparisonOperator? comparisonOperator {get;set;} = default;

			[JsonIgnore]
			[XmlElement("comparisonOperator")]
			public SerializableEnumeration<comparisonOperator>? comparisonOperatorElement { get { return comparisonOperator; } set { } }

			public bool ShouldSerializecomparisonOperator() { return comparisonOperator.HasValue; }
		}

		/// <summary>
		/// The general nature of the material of which the land surface or the seabed is composed.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surfaceCharacteristics {
			[XmlElement("underlyingLayer")]
			public int? underlyingLayer {get;set;} = default;

			public bool ShouldSerializeunderlyingLayer() { return underlyingLayer.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfSurfaceQualifyingTerms")]
			public SerializableEnumeration<natureOfSurfaceQualifyingTerms>[] natureOfSurfaceQualifyingTermsElement { get { return [.. natureOfSurfaceQualifyingTerms]; } set { } }

			public bool ShouldSerializenatureOfSurfaceQualifyingTerms() { return natureOfSurfaceQualifyingTerms.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			[JsonIgnore]
			[XmlElement("natureOfSurface")]
			public SerializableEnumeration<natureOfSurface>? natureOfSurfaceElement { get { return natureOfSurface; } set { } }

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }
		}

		/// <summary>
		/// Indication of the collective magnetic attributes and characteristics associated with an object, as measured and quantified through various magnetic detection methods.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class magneticInformation {
			[XmlIgnore]
			[EnumerationValue([501,502,503,504])]
			public strengthOfMagneticAnomaly? strengthOfMagneticAnomaly {get;set;} = default;

			[JsonIgnore]
			[XmlElement("strengthOfMagneticAnomaly")]
			public SerializableEnumeration<strengthOfMagneticAnomaly>? strengthOfMagneticAnomalyElement { get { return strengthOfMagneticAnomaly; } set { } }

			public bool ShouldSerializestrengthOfMagneticAnomaly() { return strengthOfMagneticAnomaly.HasValue; }

			[XmlElement("magneticIntensity")]
			public int? magneticIntensity {get;set;} = default;

			public bool ShouldSerializemagneticIntensity() { return magneticIntensity.HasValue; }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504])]
			public required magneticAnomalyDetectorSignature? magneticAnomalyDetectorSignature {get;set;} = default;

			[JsonIgnore]
			[XmlElement("magneticAnomalyDetectorSignature")]
			public SerializableEnumeration<magneticAnomalyDetectorSignature>? magneticAnomalyDetectorSignatureElement { get { return magneticAnomalyDetectorSignature.HasValue ? magneticAnomalyDetectorSignature : default; } set { } }
		}

		/// <summary>
		/// Rate of motion. The terms speed and velocity are often used interchangeably, but speed is a scalar, having magnitude only, while velocity is a vector quantity, having both magnitude and direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class speed {
			[XmlElement("speedMinimum")]
			public decimal? speedMinimum {get;set;} = default;

			public bool ShouldSerializespeedMinimum() { return speedMinimum.HasValue; }

			[XmlElement("speedMaximum")]
			public required decimal? speedMaximum {get;set;} = default;
		}

		/// <summary>
		/// The vertical clearance measured from the horizontal plane towards a fixed (non-opening) feature overhead.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalClearanceFixed {
			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("verticalClearanceValue")]
			public required decimal? verticalClearanceValue {get;set;} = default;
		}

		/// <summary>
		/// A complex attribute that provides detailed information about the origin of a source, including the agency responsible for its production, the nation of origin, the type of source, and a unique identifier for the source.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIdentification {
			[XmlElement("producerNation")]
			public String? producerNation {get;set;} = default;

			public bool ShouldSerializeproducerNation() { return !string.IsNullOrEmpty(producerNation); }

			[XmlElement("sourceType")]
			public String? sourceType {get;set;} = default;

			public bool ShouldSerializesourceType() { return !string.IsNullOrEmpty(sourceType); }

			[XmlElement("productionAgency")]
			public String? productionAgency {get;set;} = default;

			public bool ShouldSerializeproductionAgency() { return !string.IsNullOrEmpty(productionAgency); }

			[XmlElement("sourceID")]
			public required String? sourceID {get;set;} = default;
		}

		/// <summary>
		/// The best estimate of the accuracy of a position.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty {
			[XmlElement("uncertaintyFixed")]
			public required decimal? uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
		}

		/// <summary>
		/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation {
			[XmlElement("orientationValue")]
			public required decimal? orientationValue {get;set;} = default;

			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }
		}

		/// <summary>
		/// Indicates the the angular orientation from true north, often measured in degrees clockwise, along a specified route.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionHeading {
			[XmlElement("headingDownBearing")]
			public required decimal? headingDownBearing {get;set;} = default;

			[XmlElement("headingUpBearing")]
			public required decimal? headingUpBearing {get;set;} = default;
		}

		/// <summary>
		/// The range of altitudes within which an object or aircraft operates, encompassing the highest and lowest points of constant atmospheric pressure in aviation, each separated from the next by a 500-foot interval, measured in relation to 1,013.2 hectopascals (hPa) or 29.92 inches of mercury.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class flightLevel {
			[XmlElement("minimumFlightLevel")]
			public required int? minimumFlightLevel {get;set;} = default;

			[XmlElement("maximumFlightLevel")]
			public required int? maximumFlightLevel {get;set;} = default;
		}

		/// <summary>
		/// The maximum allowed rate of travel for a vessel in an area in knots.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselSpeedLimit {
			[XmlIgnore]
			[EnumerationValue([2,3,4])]
			public required speedUnits? speedUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("speedUnits")]
			public SerializableEnumeration<speedUnits>? speedUnitsElement { get { return speedUnits.HasValue ? speedUnits : default; } set { } }

			[XmlElement("vesselClass")]
			public String? vesselClass {get;set;} = default;

			public bool ShouldSerializevesselClass() { return !string.IsNullOrEmpty(vesselClass); }

			[XmlElement("speedLimit")]
			public required decimal? speedLimit {get;set;} = default;
		}

		/// <summary>
		/// The active period of a recurring event or occurrence.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[XmlElement("dateStart")]
			public required String? dateStart {get;set;} = default;

			[XmlElement("dateEnd")]
			public required String? dateEnd {get;set;} = default;

			[XmlElement("periodicDateEnd")]
			public required String? periodicDateEnd {get;set;} = default;

			[XmlElement("periodicDateStart")]
			public required String? periodicDateStart {get;set;} = default;
		}

		/// <summary>
		/// Textual information about the shape of a non-standard topmark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class shapeInformation {
			[XmlElement("text")]
			public required String? text {get;set;} = default;

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		/// <summary>
		/// The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class signalSequence {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			public required signalStatus? signalStatus {get;set;} = default;

			[JsonIgnore]
			[XmlElement("signalStatus")]
			public SerializableEnumeration<signalStatus>? signalStatusElement { get { return signalStatus.HasValue ? signalStatus : default; } set { } }

			[XmlElement("signalDuration")]
			public required decimal? signalDuration {get;set;} = default;
		}

		/// <summary>
		/// Additional textual information about a light sector.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorInformation {
			[XmlElement("text")]
			public required String? text {get;set;} = default;

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		/// <summary>
		/// A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionalCharacter {
			[XmlElement("orientation")]
			public required orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};

			[XmlElement("moireEffect")]
			public Boolean? moireEffect {get;set;} = default;

			public bool ShouldSerializemoireEffect() { return moireEffect.HasValue; }
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo {
			[XmlElement("sectorLineLength")]
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }

			[XmlElement("sectorBearing")]
			public required decimal? sectorBearing {get;set;} = default;
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne {
			[XmlElement("sectorLineLength")]
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }

			[XmlElement("sectorBearing")]
			public required decimal? sectorBearing {get;set;} = default;
		}

		/// <summary>
		/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class topmark {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33])]
			public required topmarkDaymarkShape? topmarkDaymarkShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("topmarkDaymarkShape")]
			public SerializableEnumeration<topmarkDaymarkShape>? topmarkDaymarkShapeElement { get { return topmarkDaymarkShape.HasValue ? topmarkDaymarkShape : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public colour? colour {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>? colourElement { get { return colour; } set { } }

			public bool ShouldSerializecolour() { return colour.HasValue; }

			[XmlElement("shapeInformation")]
			public List<shapeInformation> shapeInformation {get;set;} = [];

			public bool ShouldSerializeshapeInformation() { return shapeInformation.Any(); }
		}

		/// <summary>
		/// missing definition
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rythmOfLight {
			[XmlElement("signalSequence")]
			public List<signalSequence> signalSequence {get;set;} = [];

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }

			[XmlElement("signalPeriod")]
			public decimal? signalPeriod {get;set;} = default;

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			[XmlElement("signalGroup")]
			public List<String> signalGroup {get;set;} = [];

			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,25,26,27,28,29])]
			public required lightCharacteristic? lightCharacteristic {get;set;} = default;

			[JsonIgnore]
			[XmlElement("lightCharacteristic")]
			public SerializableEnumeration<lightCharacteristic>? lightCharacteristicElement { get { return lightCharacteristic.HasValue ? lightCharacteristic : default; } set { } }
		}

		/// <summary>
		/// The safe vertical clearance of a feature measured from the horizontal plane towards the feature overhead.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalClearanceSafe {
			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("verticalClearanceValue")]
			public required decimal? verticalClearanceValue {get;set;} = default;
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimit {
			[XmlElement("sectorLimitOne")]
			public required sectorLimitOne sectorLimitOne {get;set;} = new sectorLimitOne {
				sectorBearing = default,
			};

			[XmlElement("sectorLimitTwo")]
			public required sectorLimitTwo sectorLimitTwo {get;set;} = new sectorLimitTwo {
				sectorBearing = default,
			};
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lightSector {
			[XmlElement("sectorLimit")]
			public sectorLimit? sectorLimit {get;set;} = default;

			public bool ShouldSerializesectorLimit() { return sectorLimit!=default; }

			[XmlElement("sectorInformation")]
			public List<sectorInformation> sectorInformation {get;set;} = [];

			public bool ShouldSerializesectorInformation() { return sectorInformation.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>[] lightVisibilityElement { get { return [.. lightVisibility]; } set { } }

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("sectorArcExtension")]
			public Boolean? sectorArcExtension {get;set;} = default;

			public bool ShouldSerializesectorArcExtension() { return sectorArcExtension.HasValue; }

			[XmlElement("directionalCharacter")]
			public directionalCharacter? directionalCharacter {get;set;} = default;

			public bool ShouldSerializedirectionalCharacter() { return directionalCharacter!=default; }

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }
		}

		/// <summary>
		/// Describes the characteristics of a light sector.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorCharacteristics {
			[XmlElement("signalSequence")]
			public List<signalSequence> signalSequence {get;set;} = [];

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }

			[XmlElement("signalPeriod")]
			public decimal? signalPeriod {get;set;} = default;

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			[XmlElement("lightSector")]
			public List<lightSector> lightSector {get;set;} = [];

			public bool ShouldSerializelightSector() { return lightSector.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,25,26,27,28,29])]
			public required lightCharacteristic? lightCharacteristic {get;set;} = default;

			[JsonIgnore]
			[XmlElement("lightCharacteristic")]
			public SerializableEnumeration<lightCharacteristic>? lightCharacteristicElement { get { return lightCharacteristic.HasValue ? lightCharacteristic : default; } set { } }

			[XmlElement("signalGroup")]
			public List<String> signalGroup {get;set;} = [];

			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }
		}

	}
}

namespace S100Framework.DomainModel.S501 {
	using ComplexAttributes;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// ReferenceToAPublication (missing definition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ReferenceToAPublication : InformationNode, IInformationBindingDefinition {
			[XmlElement("editionDate")]
			public String? editionDate {get;set;} = default;

			public bool ShouldSerializeeditionDate() { return !string.IsNullOrEmpty(editionDate); }

			[XmlElement("editionNumber")]
			public String? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return !string.IsNullOrEmpty(editionNumber); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ReferenceToAPublication);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ReferenceToAPublication._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

		}
	}
	namespace FeatureTypes {
		using System.Xml;
		using System.Xml.Linq;

		/// <summary>
		/// An installation buoy is a buoy used for loading tankers with gas or oil.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InstallationBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,18,19])]
			public List<product> product {get;set;} = [];

			[JsonIgnore]
			[XmlElement("product")]
			public SerializableEnumeration<product>[] productElement { get { return [.. product]; } set { } }

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape? buoyShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape>? buoyShapeElement { get { return buoyShape.HasValue ? buoyShape : default; } set { } }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([7,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfInstallationBuoy? categoryOfInstallationBuoy {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfInstallationBuoy")]
			public SerializableEnumeration<categoryOfInstallationBuoy>? categoryOfInstallationBuoyElement { get { return categoryOfInstallationBuoy; } set { } }

			public bool ShouldSerializecategoryOfInstallationBuoy() { return categoryOfInstallationBuoy.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InstallationBuoy);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InstallationBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => InstallationBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A water area whose depth is within a defined range of values.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DepthArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("depthRangeMaximumValue")]
			public required decimal? depthRangeMaximumValue {get;set;} = default;

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("depthRangeMinimumValue")]
			public required decimal? depthRangeMinimumValue {get;set;} = default;

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DepthArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DepthArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DepthArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DepthArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioCallingInPoint : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([501])]
			public categoryOfReportingRadioCallingInPoint? categoryOfReportingRadioCallingInPoint {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfReportingRadioCallingInPoint")]
			public SerializableEnumeration<categoryOfReportingRadioCallingInPoint>? categoryOfReportingRadioCallingInPointElement { get { return categoryOfReportingRadioCallingInPoint; } set { } }

			public bool ShouldSerializecategoryOfReportingRadioCallingInPoint() { return categoryOfReportingRadioCallingInPoint.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("orientationValue")]
			public List<decimal> orientationValue {get;set;} = [];

			public bool ShouldSerializeorientationValue() { return orientationValue.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,9,501])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow? trafficFlow {get;set;} = default;

			[JsonIgnore]
			[XmlElement("trafficFlow")]
			public SerializableEnumeration<trafficFlow>? trafficFlowElement { get { return trafficFlow.HasValue ? trafficFlow : default; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioCallingInPoint);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadioCallingInPoint._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadioCallingInPoint._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A defined area on land or over water which is patrolled by a controlling or regulatory authority.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PatrolArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlIgnore]
			[EnumerationValue([501,502])]
			public required categoryOfPatrolArea? categoryOfPatrolArea {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfPatrolArea")]
			public SerializableEnumeration<categoryOfPatrolArea>? categoryOfPatrolAreaElement { get { return categoryOfPatrolArea.HasValue ? categoryOfPatrolArea : default; } set { } }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,501])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PatrolArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => PatrolArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => PatrolArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => PatrolArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An official location at which to register, declare and/or inspect goods and/or people.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Checkpoint : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,9,12])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,501])]
			public categoryOfCheckpoint? categoryOfCheckpoint {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCheckpoint")]
			public SerializableEnumeration<categoryOfCheckpoint>? categoryOfCheckpointElement { get { return categoryOfCheckpoint; } set { } }

			public bool ShouldSerializecategoryOfCheckpoint() { return categoryOfCheckpoint.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Checkpoint);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Checkpoint._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Checkpoint._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Checkpoint._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area which is managed and/or monitored by a controlling authority to protect the marine environment and ensure restrictions applicable to that area, or marine activities carried out within the area conform to current legislation/regulations.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MarineManagementArea : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public restriction? restriction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>? restrictionElement { get { return restriction; } set { } }

			public bool ShouldSerializerestriction() { return restriction.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510])]
			public List<speciesGrouping> speciesGrouping {get;set;} = [];

			[JsonIgnore]
			[XmlElement("speciesGrouping")]
			public SerializableEnumeration<speciesGrouping>[] speciesGroupingElement { get { return [.. speciesGrouping]; } set { } }

			public bool ShouldSerializespeciesGrouping() { return speciesGrouping.Any(); }

			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,2])]
			public required jurisdiction? jurisdiction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("jurisdiction")]
			public SerializableEnumeration<jurisdiction>? jurisdictionElement { get { return jurisdiction.HasValue ? jurisdiction : default; } set { } }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public categoryofMarineProtectedArea? categoryofMarineProtectedArea {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryofMarineProtectedArea")]
			public SerializableEnumeration<categoryofMarineProtectedArea>? categoryofMarineProtectedAreaElement { get { return categoryofMarineProtectedArea; } set { } }

			public bool ShouldSerializecategoryofMarineProtectedArea() { return categoryofMarineProtectedArea.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,13,14,16,17,519])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlIgnore]
			[EnumerationValue([4,5,6,7,10,20,22,23,27,28,31,32])]
			public List<categoryofRestrictions> categoryofRestrictions {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryofRestrictions")]
			public SerializableEnumeration<categoryofRestrictions>[] categoryofRestrictionsElement { get { return [.. categoryofRestrictions]; } set { } }

			public bool ShouldSerializecategoryofRestrictions() { return categoryofRestrictions.Any(); }

			[XmlElement("species")]
			public List<String> species {get;set;} = [];

			public bool ShouldSerializespecies() { return species.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MarineManagementArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MarineManagementArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MarineManagementArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MarineManagementArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A line connecting points of equal water depth which is sometimes significantly displaced outside of soundings, symbols, and other chart detail for clarity as well as generalization. Depth contours therefore often represent an approximate location of the line of equal depth as related to the surveyed line delineated on the source.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DepthContour : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("valueOfDepthContour")]
			public required decimal? valueOfDepthContour {get;set;} = default;

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DepthContour);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DepthContour._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DepthContour._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DepthContour._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class EnvironmentallySensitiveSeaArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(EnvironmentallySensitiveSeaArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => EnvironmentallySensitiveSeaArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => EnvironmentallySensitiveSeaArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => EnvironmentallySensitiveSeaArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A route with a specially prepared surface that is intended for use by wheeled vehicles or pedestrians.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Road : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([4,5])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public categoryOfRoad? categoryOfRoad {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRoad")]
			public SerializableEnumeration<categoryOfRoad>? categoryOfRoadElement { get { return categoryOfRoad; } set { } }

			public bool ShouldSerializecategoryOfRoad() { return categoryOfRoad.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,5,501])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,4,6,7,8,12,13,14])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Road);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Road._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Road._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Road._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A relatively large natural stream of water.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class River : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([5])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(River);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => River._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => River._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => River._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area within which naval, military or aerial exercises are carried out.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MilitaryPracticeArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("altitudeRange")]
			public altitudeRange? altitudeRange {get;set;} = default;

			public bool ShouldSerializealtitudeRange() { return altitudeRange!=default; }

			[XmlElement("depthRestriction")]
			public required String? depthRestriction {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1])]
			public depthUnits? depthUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("depthUnits")]
			public SerializableEnumeration<depthUnits>? depthUnitsElement { get { return depthUnits; } set { } }

			public bool ShouldSerializedepthUnits() { return depthUnits.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,516,517,518,519,520,521,522,523,524,525,526,527,528,529,530,531,532,533,534,535,536,537,538,539,540,541,542,543,544,545,546,547,598,599])]
			public List<typeofMilitaryActivity> typeofMilitaryActivity {get;set;} = [];

			[JsonIgnore]
			[XmlElement("typeofMilitaryActivity")]
			public SerializableEnumeration<typeofMilitaryActivity>[] typeofMilitaryActivityElement { get { return [.. typeofMilitaryActivity]; } set { } }

			public bool ShouldSerializetypeofMilitaryActivity() { return typeofMilitaryActivity.Any(); }

			[XmlElement("activePeriod")]
			public String? activePeriod {get;set;} = default;

			public bool ShouldSerializeactivePeriod() { return !string.IsNullOrEmpty(activePeriod); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("minimumSafeDepth")]
			public int? minimumSafeDepth {get;set;} = default;

			public bool ShouldSerializeminimumSafeDepth() { return minimumSafeDepth.HasValue; }

			[XmlIgnore]
			[EnumerationValue([2,3,4,5,501,502,503,506,507,508,510,599])]
			public List<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryofMilitaryPracticeArea")]
			public SerializableEnumeration<categoryofMilitaryPracticeArea>[] categoryofMilitaryPracticeAreaElement { get { return [.. categoryofMilitaryPracticeArea]; } set { } }

			public bool ShouldSerializecategoryofMilitaryPracticeArea() { return categoryofMilitaryPracticeArea.Any(); }

			[XmlElement("bottomVerticalSafetySeparation")]
			public int? bottomVerticalSafetySeparation {get;set;} = default;

			public bool ShouldSerializebottomVerticalSafetySeparation() { return bottomVerticalSafetySeparation.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			[EnumerationValue([501,502])]
			public areaCategory? areaCategory {get;set;} = default;

			[JsonIgnore]
			[XmlElement("areaCategory")]
			public SerializableEnumeration<areaCategory>? areaCategoryElement { get { return areaCategory; } set { } }

			public bool ShouldSerializeareaCategory() { return areaCategory.HasValue; }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44,501])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,6,7,16,17,501,503,517,520])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MilitaryPracticeArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MilitaryPracticeArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MilitaryPracticeArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Unnatural coloured areas in the sea which may or may not indicate the existence of shoals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DiscolouredWater : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DiscolouredWater);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DiscolouredWater._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DiscolouredWater._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DiscolouredWater._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfCardinalMark? categoryOfCardinalMark {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCardinalMark")]
			public SerializableEnumeration<categoryOfCardinalMark>? categoryOfCardinalMarkElement { get { return categoryOfCardinalMark.HasValue ? categoryOfCardinalMark : default; } set { } }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape? buoyShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape>? buoyShapeElement { get { return buoyShape.HasValue ? buoyShape : default; } set { } }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CardinalBuoy);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CardinalBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CardinalBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A safe water buoy is used to indicate that there is navigable water around the mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape? buoyShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape>? buoyShapeElement { get { return buoyShape.HasValue ? buoyShape : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SafeWaterBuoy);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SafeWaterBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioStation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("frequencyPair")]
			public frequencyPair? frequencyPair {get;set;} = default;

			public bool ShouldSerializefrequencyPair() { return frequencyPair!=default; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("callsign")]
			public String? callsign {get;set;} = default;

			public bool ShouldSerializecallsign() { return !string.IsNullOrEmpty(callsign); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("communicationChannel")]
			public String? communicationChannel {get;set;} = default;

			public bool ShouldSerializecommunicationChannel() { return !string.IsNullOrEmpty(communicationChannel); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([5,10,11,14,19,20])]
			public List<categoryOfRadioStation> categoryOfRadioStation {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRadioStation")]
			public SerializableEnumeration<categoryOfRadioStation>[] categoryOfRadioStationElement { get { return [.. categoryOfRadioStation]; } set { } }

			public bool ShouldSerializecategoryOfRadioStation() { return categoryOfRadioStation.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("estimatedRangeofTransmission")]
			public decimal? estimatedRangeofTransmission {get;set;} = default;

			public bool ShouldSerializeestimatedRangeofTransmission() { return estimatedRangeofTransmission.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioStation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadioStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Airspace of defined dimension identified by area on Earth's surface where activities must be confined because of their nature and/or where limitations may be imposed on aircraft.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MilitaryExerciseAirspace : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("activePeriod")]
			public String? activePeriod {get;set;} = default;

			public bool ShouldSerializeactivePeriod() { return !string.IsNullOrEmpty(activePeriod); }

			[XmlElement("altitude")]
			public altitude? altitude {get;set;} = default;

			public bool ShouldSerializealtitude() { return altitude!=default; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("flightLevel")]
			public flightLevel? flightLevel {get;set;} = default;

			public bool ShouldSerializeflightLevel() { return flightLevel!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MilitaryExerciseAirspace);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MilitaryExerciseAirspace._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MilitaryExerciseAirspace._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MilitaryExerciseAirspace._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A zone contiguous to a coastal State's Territorial Sea, which may not extend beyond 24 nautical miles from the baselines from which the breadth of the Territorial Sea is measured. The coastal State may exercise certain control in this zone subject to the provisions of International Law.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContiguousZone : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([502,504,520])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlElement("nationality")]
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ContiguousZone);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ContiguousZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ContiguousZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ContiguousZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The low-water line along the coast as marked on large-scale charts officially recognized by the coastal State. In the case of islands situated on atolls or of islands having fringing reefs, the baseline for measuring the breadth of the territorial sea is the seaward low-water line of the reef, as shown by the appropriate symbol on charts officially recognized by the coastal State. Where a low-tide elevation is situated wholly or partly at a distance not exceeding the breadth of the territorial sea from the mainland or an island, the low-water line on that elevation may be used as the baseline for measuring the breadth of the territorial sea.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NormalBaseline : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("nationality")]
			public required String? nationality {get;set;} = default;

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NormalBaseline);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NormalBaseline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => NormalBaseline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NormalBaseline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area which contains one or more submarine cables.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,7,13])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,16,17,18,20,23,24,25,27,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,7,10])]
			public List<categoryOfCable> categoryOfCable {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfCable")]
			public SerializableEnumeration<categoryOfCable>[] categoryOfCableElement { get { return [.. categoryOfCable]; } set { } }

			public bool ShouldSerializecategoryOfCable() { return categoryOfCable.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CableArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CableArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CableArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CableArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The Continental Shelf of a coastal State comprises the seabed and subsoil of the submarine areas that extend beyond its Territorial Sea throughout the natural prolongation of its land territory to the outer edge of the continental margin, or to a distance of 200 nautical miles from the baselines from which the breadth of the Territorial Sea is measured where the outer edge of the continental margin does not extend up to that distance.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContinentalShelfArea : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("nationality")]
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ContinentalShelfArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ContinentalShelfArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ContinentalShelfArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ContinentalShelfArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Waters on the landward side of the baseline of the territorial sea.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InternalWaters : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("nationality")]
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("lineTypeGeodesic")]
			public Boolean? lineTypeGeodesic {get;set;} = default;

			public bool ShouldSerializelineTypeGeodesic() { return lineTypeGeodesic.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InternalWaters);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InternalWaters._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => InternalWaters._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => InternalWaters._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A defined area within which a jurisdiction applies. It may or may not be named.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AdministrationArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public required jurisdiction? jurisdiction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("jurisdiction")]
			public SerializableEnumeration<jurisdiction>? jurisdictionElement { get { return jurisdiction.HasValue ? jurisdiction : default; } set { } }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("nationality")]
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AdministrationArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AdministrationArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AdministrationArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AdministrationArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Small shaped post, mounted on a wharf or dolphin used to secure ship's lines.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bollard : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,3,4,6,7,8,12,14,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Bollard);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Bollard._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Bollard._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Bollard._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Dolphin : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfDolphin? categoryOfDolphin {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfDolphin")]
			public SerializableEnumeration<categoryOfDolphin>? categoryOfDolphinElement { get { return categoryOfDolphin.HasValue ? categoryOfDolphin : default; } set { } }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,12,14,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,6,7])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Dolphin);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Dolphin._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Dolphin._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Dolphin._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Indicates the coverage of a sea area by a radar surveillance station. Inside this area a vessel may request shore-based radar assistance, particularly in poor visibility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarRange : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,7])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadarRange);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadarRange._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadarRange._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBeacon : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape? beaconShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("beaconShape")]
			public SerializableEnumeration<beaconShape>? beaconShapeElement { get { return beaconShape.HasValue ? beaconShape : default; } set { } }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(IsolatedDangerBeacon);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => IsolatedDangerBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape? buoyShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape>? buoyShapeElement { get { return buoyShape.HasValue ? buoyShape : default; } set { } }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(IsolatedDangerBuoy);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => IsolatedDangerBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A lane where submarines may navigate under water or at the surface.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SubmarineTransitLane : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlElement("bottomVerticalSafetySeparation")]
			public int? bottomVerticalSafetySeparation {get;set;} = default;

			public bool ShouldSerializebottomVerticalSafetySeparation() { return bottomVerticalSafetySeparation.HasValue; }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("minimumSafeDepth")]
			public int? minimumSafeDepth {get;set;} = default;

			public bool ShouldSerializeminimumSafeDepth() { return minimumSafeDepth.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SubmarineTransitLane);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SubmarineTransitLane._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SubmarineTransitLane._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SubmarineTransitLane._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// MaritimeSafetyInformationArea (missing definition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MaritimeSafetyInformationArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MaritimeSafetyInformationArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MaritimeSafetyInformationArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MaritimeSafetyInformationArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MaritimeSafetyInformationArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The airspace above a designated land or water area through which flight is prohibited or restricted.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AirspaceRestriction : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("flightLevel")]
			public flightLevel? flightLevel {get;set;} = default;

			public bool ShouldSerializeflightLevel() { return flightLevel!=default; }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("altitudeRange")]
			public altitudeRange? altitudeRange {get;set;} = default;

			public bool ShouldSerializealtitudeRange() { return altitudeRange!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits>? heightLengthUnitsElement { get { return heightLengthUnits; } set { } }

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlIgnore]
			[EnumerationValue([501,502,503])]
			public catagoryOfAirspaceRestriction? catagoryOfAirspaceRestriction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("catagoryOfAirspaceRestriction")]
			public SerializableEnumeration<catagoryOfAirspaceRestriction>? catagoryOfAirspaceRestrictionElement { get { return catagoryOfAirspaceRestriction; } set { } }

			public bool ShouldSerializecatagoryOfAirspaceRestriction() { return catagoryOfAirspaceRestriction.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AirspaceRestriction);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AirspaceRestriction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AirspaceRestriction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AirspaceRestriction._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Measured or charted depth of water (may be a drying height), or the measurement of such a depth, which has been reduced to a vertical datum.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Sounding : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([18])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,3,4,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>[] qualityOfVerticalMeasurementElement { get { return [.. qualityOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("displayUncertainties")]
			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Sounding);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Sounding._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Sounding._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Sounding._primitives;
			public static Primitives[] _primitives => [
				Primitives.pointSet
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The outer limit of a traffic lane part or a traffic separation scheme roundabout.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeBoundary : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TrafficSeparationSchemeBoundary);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeBoundary._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeBoundary._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeBoundary._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DumpingGround : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6])]
			public List<categoryOfDumpingGround> categoryOfDumpingGround {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfDumpingGround")]
			public SerializableEnumeration<categoryOfDumpingGround>[] categoryOfDumpingGroundElement { get { return [.. categoryOfDumpingGround]; } set { } }

			public bool ShouldSerializecategoryOfDumpingGround() { return categoryOfDumpingGround.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,6,7])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("dateDisused")]
			public String? dateDisused {get;set;} = default;

			public bool ShouldSerializedateDisused() { return !string.IsNullOrEmpty(dateDisused); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DumpingGround);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DumpingGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DumpingGround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DumpingGround._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A defined area on land (including any buildings, installations and equipment) intended to be used either wholly or in part for the arrival, departure and surface movement of aircraft.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AirportAirfield : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,9])]
			public List<categoryOfAirportAirfield> categoryOfAirportAirfield {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfAirportAirfield")]
			public SerializableEnumeration<categoryOfAirportAirfield>[] categoryOfAirportAirfieldElement { get { return [.. categoryOfAirportAirfield]; } set { } }

			public bool ShouldSerializecategoryOfAirportAirfield() { return categoryOfAirportAirfield.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("runwayLength")]
			public int? runwayLength {get;set;} = default;

			public bool ShouldSerializerunwayLength() { return runwayLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits>? heightLengthUnitsElement { get { return heightLengthUnits; } set { } }

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("iCAOcode")]
			public String? iCAOcode {get;set;} = default;

			public bool ShouldSerializeiCAOcode() { return !string.IsNullOrEmpty(iCAOcode); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,7,8,12,14])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AirportAirfield);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AirportAirfield._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AirportAirfield._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AirportAirfield._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Areas over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FoulGround : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([13,18,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("valueOfSounding")]
			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>[] qualityOfVerticalMeasurementElement { get { return [.. qualityOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FoulGround);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FoulGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FoulGround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FoulGround._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAirObstruction : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("pictorialRepresentation")]
			public required String? pictorialRepresentation {get;set;} = default;

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("multiplicityOfFeatures")]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("rythmOfLight")]
			public rythmOfLight? rythmOfLight {get;set;} = default;

			public bool ShouldSerializerythmOfLight() { return rythmOfLight!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("flareBearing")]
			public int? flareBearing {get;set;} = default;

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits>? heightLengthUnitsElement { get { return heightLengthUnits; } set { } }

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>[] lightVisibilityElement { get { return [.. lightVisibility]; } set { } }

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("relativeHorizontalAccuracy")]
			public decimal? relativeHorizontalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeHorizontalAccuracy() { return relativeHorizontalAccuracy.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("relativeVerticalAccuracy")]
			public decimal? relativeVerticalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeVerticalAccuracy() { return relativeVerticalAccuracy.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightAirObstruction);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightAirObstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightAirObstruction._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("maximumPermittedVesselLength")]
			public decimal? maximumPermittedVesselLength {get;set;} = default;

			public bool ShouldSerializemaximumPermittedVesselLength() { return maximumPermittedVesselLength.HasValue; }

			[XmlElement("maximumPermittedDraught")]
			public decimal? maximumPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape? buoyShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape>? buoyShapeElement { get { return buoyShape.HasValue ? buoyShape : default; } set { } }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("visitorsMooring")]
			public Boolean? visitorsMooring {get;set;} = default;

			public bool ShouldSerializevisitorsMooring() { return visitorsMooring.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MooringBuoy);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MooringBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A concreted mass of stony material or coral which dries, is awash or is below the water surface.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnderwaterAwashRock : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("valueOfSounding")]
			public required decimal? valueOfSounding {get;set;} = default;

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlIgnore]
			[EnumerationValue([3,4,5])]
			public required waterLevelEffect? waterLevelEffect {get;set;} = default;

			[JsonIgnore]
			[XmlElement("waterLevelEffect")]
			public SerializableEnumeration<waterLevelEffect>? waterLevelEffectElement { get { return waterLevelEffect.HasValue ? waterLevelEffect : default; } set { } }

			[XmlElement("surroundingDepth")]
			public decimal? surroundingDepth {get;set;} = default;

			public bool ShouldSerializesurroundingDepth() { return surroundingDepth.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([14,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			[JsonIgnore]
			[XmlElement("natureOfSurface")]
			public SerializableEnumeration<natureOfSurface>? natureOfSurfaceElement { get { return natureOfSurface; } set { } }

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("displayUncertainties")]
			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			[JsonIgnore]
			[XmlElement("expositionOfSounding")]
			public SerializableEnumeration<expositionOfSounding>? expositionOfSoundingElement { get { return expositionOfSounding; } set { } }

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

			[XmlElement("defaultClearanceDepth")]
			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

			[XmlIgnore]
			[EnumerationValue([18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("firstSourceInformation")]
			public firstSourceInformation? firstSourceInformation {get;set;} = default;

			public bool ShouldSerializefirstSourceInformation() { return firstSourceInformation!=default; }

			[XmlElement("lastSourceInformation")]
			public lastSourceInformation? lastSourceInformation {get;set;} = default;

			public bool ShouldSerializelastSourceInformation() { return lastSourceInformation!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>? qualityOfVerticalMeasurementElement { get { return qualityOfVerticalMeasurement; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(UnderwaterAwashRock);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => UnderwaterAwashRock._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => UnderwaterAwashRock._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => UnderwaterAwashRock._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A single continuous rope-like bundle consisting of multiple strands of fiber, plastic, metal, and/or glass, which is supported by structures such as poles or pylons and passing over or nearby navigable waters.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableOverhead : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,4,5,7,12,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,3])]
			public categoryOfCable? categoryOfCable {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCable")]
			public SerializableEnumeration<categoryOfCable>? categoryOfCableElement { get { return categoryOfCable; } set { } }

			public bool ShouldSerializecategoryOfCable() { return categoryOfCable.HasValue; }

			[XmlElement("verticalClearanceSafe")]
			public verticalClearanceSafe? verticalClearanceSafe {get;set;} = default;

			public bool ShouldSerializeverticalClearanceSafe() { return verticalClearanceSafe!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("verticalClearanceFixed")]
			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			public bool ShouldSerializeverticalClearanceFixed() { return verticalClearanceFixed!=default; }

			[XmlElement("multiplicityOfFeatures")]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("iceFactor")]
			public decimal? iceFactor {get;set;} = default;

			public bool ShouldSerializeiceFactor() { return iceFactor.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CableOverhead);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CableOverhead._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CableOverhead._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CableOverhead._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Designated airspace within which some or all aircraft may be subjected to air traffic control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ControlledAirspace : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([501,502,503,504,505,506,507])]
			public controlledAirspaceClassDesignation? controlledAirspaceClassDesignation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("controlledAirspaceClassDesignation")]
			public SerializableEnumeration<controlledAirspaceClassDesignation>? controlledAirspaceClassDesignationElement { get { return controlledAirspaceClassDesignation; } set { } }

			public bool ShouldSerializecontrolledAirspaceClassDesignation() { return controlledAirspaceClassDesignation.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,516,517,518,519,520,521,522])]
			public categoryOfControlledAirspace? categoryOfControlledAirspace {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfControlledAirspace")]
			public SerializableEnumeration<categoryOfControlledAirspace>? categoryOfControlledAirspaceElement { get { return categoryOfControlledAirspace; } set { } }

			public bool ShouldSerializecategoryOfControlledAirspace() { return categoryOfControlledAirspace.HasValue; }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("altitude")]
			public altitude? altitude {get;set;} = default;

			public bool ShouldSerializealtitude() { return altitude!=default; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits>? heightLengthUnitsElement { get { return heightLengthUnits; } set { } }

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("flightLevel")]
			public flightLevel? flightLevel {get;set;} = default;

			public bool ShouldSerializeflightLevel() { return flightLevel!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ControlledAirspace);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ControlledAirspace._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ControlledAirspace._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ControlledAirspace._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// In marine navigation, anything that hinders or prevents movement, particularly anything that endangers or prevents passage of a vessel. The term is usually used to refer to an isolated danger to navigation, such as a sunken rock or pinnacle.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Obstruction : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,11,12])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,502,503,505,506,507,508,509,510,511,513,514,515,516,517,519,520,521,522,523,524,525,526,527,528,529,530,531,532,533,534,535,536,537,540,541,542])]
			public List<product> product {get;set;} = [];

			[JsonIgnore]
			[XmlElement("product")]
			public SerializableEnumeration<product>[] productElement { get { return [.. product]; } set { } }

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("existenceOfRestrictedArea")]
			public Boolean? existenceOfRestrictedArea {get;set;} = default;

			public bool ShouldSerializeexistenceOfRestrictedArea() { return existenceOfRestrictedArea.HasValue; }

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			[XmlElement("lastSourceInformation")]
			public lastSourceInformation? lastSourceInformation {get;set;} = default;

			public bool ShouldSerializelastSourceInformation() { return lastSourceInformation!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			[JsonIgnore]
			[XmlElement("expositionOfSounding")]
			public SerializableEnumeration<expositionOfSounding>? expositionOfSoundingElement { get { return expositionOfSounding; } set { } }

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

			[XmlElement("firstSourceInformation")]
			public firstSourceInformation? firstSourceInformation {get;set;} = default;

			public bool ShouldSerializefirstSourceInformation() { return firstSourceInformation!=default; }

			[XmlElement("abandonmentDate")]
			public String? abandonmentDate {get;set;} = default;

			public bool ShouldSerializeabandonmentDate() { return !string.IsNullOrEmpty(abandonmentDate); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("soundingDepth")]
			public decimal? soundingDepth {get;set;} = default;

			public bool ShouldSerializesoundingDepth() { return soundingDepth.HasValue; }

			[XmlElement("orientation")]
			public orientation? orientation {get;set;} = default;

			public bool ShouldSerializeorientation() { return orientation!=default; }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,519,522,523,524,525,526,527,531,532])]
			public soundingDatum? soundingDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("soundingDatum")]
			public SerializableEnumeration<soundingDatum>? soundingDatumElement { get { return soundingDatum; } set { } }

			public bool ShouldSerializesoundingDatum() { return soundingDatum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("magneticInformation")]
			public magneticInformation? magneticInformation {get;set;} = default;

			public bool ShouldSerializemagneticInformation() { return magneticInformation!=default; }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,4,5,7,8,13,18,28,501,503,505,506,507,508,509,510,511,512,516,517,518])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("generalWaterDepth")]
			public int? generalWaterDepth {get;set;} = default;

			public bool ShouldSerializegeneralWaterDepth() { return generalWaterDepth.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>[] qualityOfVerticalMeasurementElement { get { return [.. qualityOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlElement("detectionDateRange")]
			public detectionDateRange? detectionDateRange {get;set;} = default;

			public bool ShouldSerializedetectionDateRange() { return detectionDateRange!=default; }

			[XmlElement("oprtor")]
			public String? oprtor {get;set;} = default;

			public bool ShouldSerializeoprtor() { return !string.IsNullOrEmpty(oprtor); }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44,501])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504])]
			public sonarSignalStrength? sonarSignalStrength {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sonarSignalStrength")]
			public SerializableEnumeration<sonarSignalStrength>? sonarSignalStrengthElement { get { return sonarSignalStrength; } set { } }

			public bool ShouldSerializesonarSignalStrength() { return sonarSignalStrength.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("maximumPermittedDraught")]
			public decimal? maximumPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfSurface")]
			public SerializableEnumeration<natureOfSurface>[] natureOfSurfaceElement { get { return [.. natureOfSurface]; } set { } }

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.Any(); }

			[XmlElement("spuddedDate")]
			public String? spuddedDate {get;set;} = default;

			public bool ShouldSerializespuddedDate() { return !string.IsNullOrEmpty(spuddedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,12,13,14,15,16,17,18,19,20,21,22,23,501,502,503,504,506,508,509])]
			public categoryOfObstruction? categoryOfObstruction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfObstruction")]
			public SerializableEnumeration<categoryOfObstruction>? categoryOfObstructionElement { get { return categoryOfObstruction; } set { } }

			public bool ShouldSerializecategoryOfObstruction() { return categoryOfObstruction.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("dateSunk")]
			public String? dateSunk {get;set;} = default;

			public bool ShouldSerializedateSunk() { return !string.IsNullOrEmpty(dateSunk); }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("currentScourDimensions")]
			public String? currentScourDimensions {get;set;} = default;

			public bool ShouldSerializecurrentScourDimensions() { return !string.IsNullOrEmpty(currentScourDimensions); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504])]
			public cardinalPointOrientation? cardinalPointOrientation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("cardinalPointOrientation")]
			public SerializableEnumeration<cardinalPointOrientation>? cardinalPointOrientationElement { get { return cardinalPointOrientation; } set { } }

			public bool ShouldSerializecardinalPointOrientation() { return cardinalPointOrientation.HasValue; }

			[XmlElement("valueOfSounding")]
			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,7])]
			public required waterLevelEffect? waterLevelEffect {get;set;} = default;

			[JsonIgnore]
			[XmlElement("waterLevelEffect")]
			public SerializableEnumeration<waterLevelEffect>? waterLevelEffectElement { get { return waterLevelEffect.HasValue ? waterLevelEffect : default; } set { } }

			[XmlElement("nation")]
			public String? nation {get;set;} = default;

			public bool ShouldSerializenation() { return !string.IsNullOrEmpty(nation); }

			[XmlElement("defaultClearanceDepth")]
			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

			[XmlElement("displayUncertainties")]
			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Obstruction);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Obstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Obstruction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Obstruction._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A water area in which fishing is frequently carried on.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FishingGround : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,5,6,7,8,14,16,17,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,8,9,10,11,12,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FishingGround);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FishingGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FishingGround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FishingGround._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A structure for fishing purposes which can be an obstruction to ships in general. The position of these structures may vary frequently over time.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FishingFacility : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,12,18,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfFishingFacility? categoryOfFishingFacility {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfFishingFacility")]
			public SerializableEnumeration<categoryOfFishingFacility>? categoryOfFishingFacilityElement { get { return categoryOfFishingFacility; } set { } }

			public bool ShouldSerializecategoryOfFishingFacility() { return categoryOfFishingFacility.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FishingFacility);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FishingFacility._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FishingFacility._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FishingFacility._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Any visual or electronic device which provides point-to-point guidance information or position data 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationSystem : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20,504,505,506,508,509,510])]
			public categoryOfRadioStation? categoryOfRadioStation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRadioStation")]
			public SerializableEnumeration<categoryOfRadioStation>? categoryOfRadioStationElement { get { return categoryOfRadioStation; } set { } }

			public bool ShouldSerializecategoryOfRadioStation() { return categoryOfRadioStation.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("callsign")]
			public String? callsign {get;set;} = default;

			public bool ShouldSerializecallsign() { return !string.IsNullOrEmpty(callsign); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("communicationChannel")]
			public String? communicationChannel {get;set;} = default;

			public bool ShouldSerializecommunicationChannel() { return !string.IsNullOrEmpty(communicationChannel); }

			[XmlElement("signalFrequency")]
			public int? signalFrequency {get;set;} = default;

			public bool ShouldSerializesignalFrequency() { return signalFrequency.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavigationSystem);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NavigationSystem._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => NavigationSystem._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NavigationSystem._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A defined area where traffic lanes cross.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeCrossing : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TrafficSeparationSchemeCrossing);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeCrossing._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeCrossing._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeCrossing._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area within defined limits in which one-way traffic is established. Natural obstacles, including those forming separation zones, may constitute a boundary.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeLanePart : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("orientationValue")]
			public decimal? orientationValue {get;set;} = default;

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TrafficSeparationSchemeLanePart);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeLanePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeLanePart._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeLanePart._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A belt of water of a defined breadth but not exceeding 12 nautical miles measured seaward from the territorial sea baseline.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TerritorialSeaArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("nationality")]
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([2,4,6,8,9,10,12,17,18,19,20,21,22,23,24,27])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TerritorialSeaArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TerritorialSeaArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TerritorialSeaArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TerritorialSeaArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBeacon : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape? beaconShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("beaconShape")]
			public SerializableEnumeration<beaconShape>? beaconShapeElement { get { return beaconShape.HasValue ? beaconShape : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfLateralMark? categoryOfLateralMark {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfLateralMark")]
			public SerializableEnumeration<categoryOfLateralMark>? categoryOfLateralMarkElement { get { return categoryOfLateralMark.HasValue ? categoryOfLateralMark : default; } set { } }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LateralBeacon);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LateralBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LateralBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A station at which a visual/radio/radar marine watch is kept either continuously or at certain times only.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CoastGuardStation : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,4,5,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("isMRCC")]
			public Boolean? isMRCC {get;set;} = default;

			public bool ShouldSerializeisMRCC() { return isMRCC.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("communicationsChannel")]
			public List<String> communicationsChannel {get;set;} = [];

			public bool ShouldSerializecommunicationsChannel() { return communicationsChannel.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CoastGuardStation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CoastGuardStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CoastGuardStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CoastGuardStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A zone or line separating the traffic lanes in which ships are proceeding in opposite, or nearly opposite directions; or separating a traffic lane from the adjacent sea area; or separating traffic lanes designated for particular classes of ships proceeding in the same direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeparationZoneOrLine : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SeparationZoneOrLine);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SeparationZoneOrLine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SeparationZoneOrLine._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SeparationZoneOrLine._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A significant configuration of underwater topography 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BottomFeature : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("migrationDirection")]
			public int? migrationDirection {get;set;} = default;

			public bool ShouldSerializemigrationDirection() { return migrationDirection.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([502,510])]
			public bottomFeatureClassification? bottomFeatureClassification {get;set;} = default;

			[JsonIgnore]
			[XmlElement("bottomFeatureClassification")]
			public SerializableEnumeration<bottomFeatureClassification>? bottomFeatureClassificationElement { get { return bottomFeatureClassification; } set { } }

			public bool ShouldSerializebottomFeatureClassification() { return bottomFeatureClassification.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BottomFeature);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => BottomFeature._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => BottomFeature._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => BottomFeature._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Straight baselines joining the outermost points of the outermost islands and drying reefs of the archipelago provided that within such baselines are included the main islands and an area in which the ratio of the area of the water to the area of the land, including atolls, is between 1 to 1 and 9 to 1.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ArchipelagicBaseline : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlElement("nationality")]
			public required String? nationality {get;set;} = default;

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ArchipelagicBaseline);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ArchipelagicBaseline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ArchipelagicBaseline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ArchipelagicBaseline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Underwater feature appearing mine-like on a sonar image (AML)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SmallBottomObject : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			[EnumerationValue([504])]
			public statusOfSmallBottomObject? statusOfSmallBottomObject {get;set;} = default;

			[JsonIgnore]
			[XmlElement("statusOfSmallBottomObject")]
			public SerializableEnumeration<statusOfSmallBottomObject>? statusOfSmallBottomObjectElement { get { return statusOfSmallBottomObject; } set { } }

			public bool ShouldSerializestatusOfSmallBottomObject() { return statusOfSmallBottomObject.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("valueOfSounding")]
			public required decimal? valueOfSounding {get;set;} = default;

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SmallBottomObject);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SmallBottomObject._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SmallBottomObject._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SmallBottomObject._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area, not exceeding 200 nautical miles from the baselines from which the breadth of the territorial sea is measured, subject to a specific legal regime established in the United Nations Convention on the Law of the Sea under which the coastal state has certain rights and jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ExclusiveEconomicZone : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlElement("nationality")]
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ExclusiveEconomicZone);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ExclusiveEconomicZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ExclusiveEconomicZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ExclusiveEconomicZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A station with a transmitter emitting pulses of ultra-high frequency radio waves which are reflected by solid objects and are detected upon their return to the sending station.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarStation : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,4,7,8])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfRadarStation? categoryOfRadarStation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRadarStation")]
			public SerializableEnumeration<categoryOfRadarStation>? categoryOfRadarStationElement { get { return categoryOfRadarStation; } set { } }

			public bool ShouldSerializecategoryOfRadarStation() { return categoryOfRadarStation.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("callsign")]
			public String? callsign {get;set;} = default;

			public bool ShouldSerializecallsign() { return !string.IsNullOrEmpty(callsign); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("valueOfMaximumRange")]
			public decimal? valueOfMaximumRange {get;set;} = default;

			public bool ShouldSerializevalueOfMaximumRange() { return valueOfMaximumRange.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadarStation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadarStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadarStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadarStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Location where civilian diving activities take place. 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DivingLocation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("waterClarity")]
			public decimal? waterClarity {get;set;} = default;

			public bool ShouldSerializewaterClarity() { return waterClarity.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([501,502,503])]
			public divingActivity? divingActivity {get;set;} = default;

			[JsonIgnore]
			[XmlElement("divingActivity")]
			public SerializableEnumeration<divingActivity>? divingActivityElement { get { return divingActivity; } set { } }

			public bool ShouldSerializedivingActivity() { return divingActivity.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DivingLocation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DivingLocation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DivingLocation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DivingLocation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,18,19,20,21,22,23,24,25,27,28,29,30,31,32,501])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,9,18,28,501])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,39,42])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RestrictedArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RestrictedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RestrictedArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RestrictedArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the seafloor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableSubmarine : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,4,13,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("depthRangeMinimumValue")]
			public decimal? depthRangeMinimumValue {get;set;} = default;

			public bool ShouldSerializedepthRangeMinimumValue() { return depthRangeMinimumValue.HasValue; }

			[XmlElement("buriedDepth")]
			public decimal? buriedDepth {get;set;} = default;

			public bool ShouldSerializeburiedDepth() { return buriedDepth.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,6,7,9,10])]
			public categoryOfCable? categoryOfCable {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCable")]
			public SerializableEnumeration<categoryOfCable>? categoryOfCableElement { get { return categoryOfCable; } set { } }

			public bool ShouldSerializecategoryOfCable() { return categoryOfCable.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CableSubmarine);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CableSubmarine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CableSubmarine._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The ruined remains of a stranded or sunken vessel which has been rendered useless.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Wreck : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("surroundingDepth")]
			public decimal? surroundingDepth {get;set;} = default;

			public bool ShouldSerializesurroundingDepth() { return surroundingDepth.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("currentScourDimensions")]
			public String? currentScourDimensions {get;set;} = default;

			public bool ShouldSerializecurrentScourDimensions() { return !string.IsNullOrEmpty(currentScourDimensions); }

			[XmlIgnore]
			[EnumerationValue([7,13,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504])]
			public sonarSignalStrength? sonarSignalStrength {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sonarSignalStrength")]
			public SerializableEnumeration<sonarSignalStrength>? sonarSignalStrengthElement { get { return sonarSignalStrength; } set { } }

			public bool ShouldSerializesonarSignalStrength() { return sonarSignalStrength.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("magneticInformation")]
			public magneticInformation? magneticInformation {get;set;} = default;

			public bool ShouldSerializemagneticInformation() { return magneticInformation!=default; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			[EnumerationValue([6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("defaultClearanceDepth")]
			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			[JsonIgnore]
			[XmlElement("natureOfSurface")]
			public SerializableEnumeration<natureOfSurface>? natureOfSurfaceElement { get { return natureOfSurface; } set { } }

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }

			[XmlElement("orientationValue")]
			public decimal? orientationValue {get;set;} = default;

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			[XmlElement("typeOfWreck")]
			public String? typeOfWreck {get;set;} = default;

			public bool ShouldSerializetypeOfWreck() { return !string.IsNullOrEmpty(typeOfWreck); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			public required waterLevelEffect? waterLevelEffect {get;set;} = default;

			[JsonIgnore]
			[XmlElement("waterLevelEffect")]
			public SerializableEnumeration<waterLevelEffect>? waterLevelEffectElement { get { return waterLevelEffect.HasValue ? waterLevelEffect : default; } set { } }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			public categoryOfWreck? categoryOfWreck {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfWreck")]
			public SerializableEnumeration<categoryOfWreck>? categoryOfWreckElement { get { return categoryOfWreck; } set { } }

			public bool ShouldSerializecategoryOfWreck() { return categoryOfWreck.HasValue; }

			[XmlIgnore]
			[EnumerationValue([4,5])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfHorizontalMeasurement")]
			public SerializableEnumeration<qualityOfHorizontalMeasurement>? qualityOfHorizontalMeasurementElement { get { return qualityOfHorizontalMeasurement; } set { } }

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("debrisField")]
			public String? debrisField {get;set;} = default;

			public bool ShouldSerializedebrisField() { return !string.IsNullOrEmpty(debrisField); }

			[XmlElement("nationality")]
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			[XmlElement("lastSourceInformation")]
			public lastSourceInformation? lastSourceInformation {get;set;} = default;

			public bool ShouldSerializelastSourceInformation() { return lastSourceInformation!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>? qualityOfVerticalMeasurementElement { get { return qualityOfVerticalMeasurement; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504])]
			public cardinalPointOrientation? cardinalPointOrientation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("cardinalPointOrientation")]
			public SerializableEnumeration<cardinalPointOrientation>? cardinalPointOrientationElement { get { return cardinalPointOrientation; } set { } }

			public bool ShouldSerializecardinalPointOrientation() { return cardinalPointOrientation.HasValue; }

			[XmlElement("vesselMeasurementsSpecification")]
			public List<vesselMeasurementsSpecification> vesselMeasurementsSpecification {get;set;} = [];

			public bool ShouldSerializevesselMeasurementsSpecification() { return vesselMeasurementsSpecification.Any(); }

			[XmlElement("existenceOfRestrictedArea")]
			public Boolean? existenceOfRestrictedArea {get;set;} = default;

			public bool ShouldSerializeexistenceOfRestrictedArea() { return existenceOfRestrictedArea.HasValue; }

			[XmlElement("dateSunk")]
			public String? dateSunk {get;set;} = default;

			public bool ShouldSerializedateSunk() { return !string.IsNullOrEmpty(dateSunk); }

			[XmlElement("firstSourceInformation")]
			public firstSourceInformation? firstSourceInformation {get;set;} = default;

			public bool ShouldSerializefirstSourceInformation() { return firstSourceInformation!=default; }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("valueOfSounding")]
			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25])]
			public List<product> product {get;set;} = [];

			[JsonIgnore]
			[XmlElement("product")]
			public SerializableEnumeration<product>[] productElement { get { return [.. product]; } set { } }

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("displayUncertainties")]
			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			[JsonIgnore]
			[XmlElement("expositionOfSounding")]
			public SerializableEnumeration<expositionOfSounding>? expositionOfSoundingElement { get { return expositionOfSounding; } set { } }

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Wreck);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Wreck._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Wreck._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Wreck._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A pre-planned dormant channel and/or route, surveyed for mine-like contacts during peacetime that can be 'activated' to provide shipping with safe navigable routes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QRoute : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([2,503])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("qRouteChannelWidth")]
			public qRouteChannelWidth? qRouteChannelWidth {get;set;} = default;

			public bool ShouldSerializeqRouteChannelWidth() { return qRouteChannelWidth!=default; }

			[XmlElement("directionHeading")]
			public directionHeading? directionHeading {get;set;} = default;

			public bool ShouldSerializedirectionHeading() { return directionHeading!=default; }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(QRoute);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => QRoute._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => QRoute._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => QRoute._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// CompletenessOfProductSpecification (missing definition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CompletenessOfProductSpecification : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			[EnumerationValue([501,502])]
			public required categoryOfCompleteness? categoryOfCompleteness {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCompleteness")]
			public SerializableEnumeration<categoryOfCompleteness>? categoryOfCompletenessElement { get { return categoryOfCompleteness.HasValue ? categoryOfCompleteness : default; } set { } }

			[XmlElement("copyrightStatement")]
			public String? copyrightStatement {get;set;} = default;

			public bool ShouldSerializecopyrightStatement() { return !string.IsNullOrEmpty(copyrightStatement); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CompletenessOfProductSpecification);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CompletenessOfProductSpecification._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CompletenessOfProductSpecification._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CompletenessOfProductSpecification._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A place where equipment for saving life at sea is maintained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RescueStation : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,7,8])]
			public List<categoryOfRescueStation> categoryOfRescueStation {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRescueStation")]
			public SerializableEnumeration<categoryOfRescueStation>[] categoryOfRescueStationElement { get { return [.. categoryOfRescueStation]; } set { } }

			public bool ShouldSerializecategoryOfRescueStation() { return categoryOfRescueStation.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RescueStation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RescueStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RescueStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RescueStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBeacon : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,5,6,7])]
			public required beaconShape? beaconShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("beaconShape")]
			public SerializableEnumeration<beaconShape>? beaconShapeElement { get { return beaconShape.HasValue ? beaconShape : default; } set { } }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfCardinalMark? categoryOfCardinalMark {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCardinalMark")]
			public SerializableEnumeration<categoryOfCardinalMark>? categoryOfCardinalMarkElement { get { return categoryOfCardinalMark.HasValue ? categoryOfCardinalMark : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CardinalBeacon);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CardinalBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CardinalBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightVessel : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([6,7])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightVessel);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightVessel._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightVessel._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The offshore zone in which exclusive fishing rights and management are held by the coastal nation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FisheryZone : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("nationality")]
			public required String? nationality {get;set;} = default;

			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlElement("species")]
			public List<String> species {get;set;} = [];

			public bool ShouldSerializespecies() { return species.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,5,6,7,501,502,504,519,521])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FisheryZone);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FisheryZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FisheryZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FisheryZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area of the bottom of a body of water which has been deepened by dredging.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DredgedArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("maximumPermittedDraught")]
			public decimal? maximumPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("dredgedDate")]
			public String? dredgedDate {get;set;} = default;

			public bool ShouldSerializedredgedDate() { return !string.IsNullOrEmpty(dredgedDate); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("depthRangeMaximumValue")]
			public decimal? depthRangeMaximumValue {get;set;} = default;

			public bool ShouldSerializedepthRangeMaximumValue() { return depthRangeMaximumValue.HasValue; }

			[XmlIgnore]
			[EnumerationValue([10,11])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>? qualityOfVerticalMeasurementElement { get { return qualityOfVerticalMeasurement; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("depthRangeMinimumValue")]
			public required decimal? depthRangeMinimumValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,11,12,13,16,17,18,19,20,21,23,25,27,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DredgedArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DredgedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DredgedArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DredgedArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A route in a body of water where a ferry crosses from one shoreline to another.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FerryRoute : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,7,8,9,14])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,5])]
			public List<categoryOfFerry> categoryOfFerry {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfFerry")]
			public SerializableEnumeration<categoryOfFerry>[] categoryOfFerryElement { get { return [.. categoryOfFerry]; } set { } }

			public bool ShouldSerializecategoryOfFerry() { return categoryOfFerry.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FerryRoute);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FerryRoute._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FerryRoute._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FerryRoute._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A fixed artificial structure in the water and/or adjoining the land. It may also refer to features such as training walls, which are not necessarily connected to, nor form part of the shoreline.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShorelineConstruction : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504,505])]
			public gradientOfSlope? gradientOfSlope {get;set;} = default;

			[JsonIgnore]
			[XmlElement("gradientOfSlope")]
			public SerializableEnumeration<gradientOfSlope>? gradientOfSlopeElement { get { return gradientOfSlope; } set { } }

			public bool ShouldSerializegradientOfSlope() { return gradientOfSlope.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("horizontalClearanceFixed")]
			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public bool ShouldSerializehorizontalClearanceFixed() { return horizontalClearanceFixed!=default; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,12,13,14,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required waterLevelEffect? waterLevelEffect {get;set;} = default;

			[JsonIgnore]
			[XmlElement("waterLevelEffect")]
			public SerializableEnumeration<waterLevelEffect>? waterLevelEffectElement { get { return waterLevelEffect.HasValue ? waterLevelEffect : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,20,22,23,501])]
			public categoryOfShorelineConstruction? categoryOfShorelineConstruction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfShorelineConstruction")]
			public SerializableEnumeration<categoryOfShorelineConstruction>? categoryOfShorelineConstructionElement { get { return categoryOfShorelineConstruction; } set { } }

			public bool ShouldSerializecategoryOfShorelineConstruction() { return categoryOfShorelineConstruction.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShorelineConstruction);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ShorelineConstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ShorelineConstruction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ShorelineConstruction._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CautionArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([5,7])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,3,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CautionArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CautionArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CautionArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area of a deep water route within which ships proceed in the same direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DeepWaterRoutePart : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("imoAdopted")]
			public Boolean? imoAdopted {get;set;} = default;

			public bool ShouldSerializeimoAdopted() { return imoAdopted.HasValue; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow? trafficFlow {get;set;} = default;

			[JsonIgnore]
			[XmlElement("trafficFlow")]
			public SerializableEnumeration<trafficFlow>? trafficFlowElement { get { return trafficFlow.HasValue ? trafficFlow : default; } set { } }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("depthRangeMinimumValue")]
			public required decimal? depthRangeMinimumValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,5,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,3,6,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("orientationValue")]
			public required decimal? orientationValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>[] qualityOfVerticalMeasurementElement { get { return [.. qualityOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DeepWaterRoutePart);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRoutePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoutePart._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DeepWaterRoutePart._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Any current that is caused by other than tide producing forces.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CurrentNonGravitational : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("orientation")]
			public required orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("speed")]
			public required speed speed {get;set;} = new speed {
				speedMaximum = default,
			};

			[XmlIgnore]
			[EnumerationValue([5])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CurrentNonGravitational);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CurrentNonGravitational._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CurrentNonGravitational._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CurrentNonGravitational._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A geographical area that describes the coverage and extent of spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("drawingIndex")]
			public int? drawingIndex {get;set;} = default;

			public bool ShouldSerializedrawingIndex() { return drawingIndex.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfCoverage? categoryOfCoverage {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCoverage")]
			public SerializableEnumeration<categoryOfCoverage>? categoryOfCoverageElement { get { return categoryOfCoverage; } set { } }

			public bool ShouldSerializecategoryOfCoverage() { return categoryOfCoverage.HasValue; }

			[XmlElement("optimumDisplayScale")]
			public required int? optimumDisplayScale {get;set;} = default;

			[XmlElement("minimumDisplayScale")]
			public required int? minimumDisplayScale {get;set;} = default;

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("maximumDisplayScale")]
			public required int? maximumDisplayScale {get;set;} = default;

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DataCoverage);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DataCoverage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A region of the seabed including the material of which it is composed and its physical characteristics. Also called nature of bottom, character (or characteristics) of the bottom, or quality of the bottom.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeabedArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([3,4,5])]
			public required waterLevelEffect? waterLevelEffect {get;set;} = default;

			[JsonIgnore]
			[XmlElement("waterLevelEffect")]
			public SerializableEnumeration<waterLevelEffect>? waterLevelEffectElement { get { return waterLevelEffect.HasValue ? waterLevelEffect : default; } set { } }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("surfaceCharacteristics")]
			public List<surfaceCharacteristics> surfaceCharacteristics {get;set;} = [];

			public bool ShouldSerializesurfaceCharacteristics() { return surfaceCharacteristics.Any(); }

			[XmlElement("attenuation")]
			public decimal? attenuation {get;set;} = default;

			public bool ShouldSerializeattenuation() { return attenuation.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SeabedArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SeabedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SeabedArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SeabedArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape? buoyShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape>? buoyShapeElement { get { return buoyShape.HasValue ? buoyShape : default; } set { } }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,42,43,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfSpecialPurposeMark")]
			public SerializableEnumeration<categoryOfSpecialPurposeMark>[] categoryOfSpecialPurposeMarkElement { get { return [.. categoryOfSpecialPurposeMark]; } set { } }

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,8,18,503])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlIgnore]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("fixedDateRange")]
			public List<fixedDateRange> fixedDateRange {get;set;} = [];

			public bool ShouldSerializefixedDateRange() { return fixedDateRange.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBuoy);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SpecialPurposeGeneralBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightSectored : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("relativeHorizontalAccuracy")]
			public decimal? relativeHorizontalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeHorizontalAccuracy() { return relativeHorizontalAccuracy.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("relativeVerticalAccuracy")]
			public decimal? relativeVerticalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeVerticalAccuracy() { return relativeVerticalAccuracy.HasValue; }

			[XmlIgnore]
			[EnumerationValue([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfLight")]
			public SerializableEnumeration<categoryOfLight>[] categoryOfLightElement { get { return [.. categoryOfLight]; } set { } }

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("pictorialRepresentation")]
			public required String? pictorialRepresentation {get;set;} = default;

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits>? heightLengthUnitsElement { get { return heightLengthUnits; } set { } }

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("sectorCharacteristics")]
			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];

			public bool ShouldSerializesectorCharacteristics() { return sectorCharacteristics.Any(); }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlIgnore]
			[EnumerationValue([5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightSectored);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightSectored._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightSectored._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The Ice Line provides a measured, observed or estimated limit of the ice infested waters. (ECDIS Ice Objects Version 3.0)			
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IceLine : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(IceLine);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IceLine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => IceLine._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => IceLine._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area in which vessels or seaplanes anchor or may anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorageArea : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,8,9,10,11,12,13,15,16,17,18,19,20,21,23,24,27,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public periodicDateRange? periodicDateRange {get;set;} = default;

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,5,6,7,9,10,14,15])]
			public List<categoryOfAnchorage> categoryOfAnchorage {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfAnchorage")]
			public SerializableEnumeration<categoryOfAnchorage>[] categoryOfAnchorageElement { get { return [.. categoryOfAnchorage]; } set { } }

			public bool ShouldSerializecategoryOfAnchorage() { return categoryOfAnchorage.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,5,6,7,8,9,14])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AnchorageArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AnchorageArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well-defined channels and are used in conjunction with a conventional direction of buoyage.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfLateralMark? categoryOfLateralMark {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfLateralMark")]
			public SerializableEnumeration<categoryOfLateralMark>? categoryOfLateralMarkElement { get { return categoryOfLateralMark.HasValue ? categoryOfLateralMark : default; } set { } }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape? buoyShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape>? buoyShapeElement { get { return buoyShape.HasValue ? buoyShape : default; } set { } }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LateralBuoy);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LateralBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LateralBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A routeing measure comprising a separation point or circular separation zone and a circular traffic lane within defined limits. Traffic within the roundabout is separated by moving in a counter-clockwise direction around the separation point or zone.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeRoundabout : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("vesselSpeedLimit")]
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TrafficSeparationSchemeRoundabout);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeRoundabout._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeRoundabout._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeRoundabout._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The Deep Water route centreline indicates the centreline of a route, the width of which is not explicitly defined.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DeepWaterRouteCentreline : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>[] qualityOfVerticalMeasurementElement { get { return [.. qualityOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlElement("orientationValue")]
			public required decimal? orientationValue {get;set;} = default;

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow? trafficFlow {get;set;} = default;

			[JsonIgnore]
			[XmlElement("trafficFlow")]
			public SerializableEnumeration<trafficFlow>? trafficFlowElement { get { return trafficFlow.HasValue ? trafficFlow : default; } set { } }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("imoAdopted")]
			public Boolean? imoAdopted {get;set;} = default;

			public bool ShouldSerializeimoAdopted() { return imoAdopted.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("depthRangeMinimumValue")]
			public decimal? depthRangeMinimumValue {get;set;} = default;

			public bool ShouldSerializedepthRangeMinimumValue() { return depthRangeMinimumValue.HasValue; }

			[XmlElement("basedOnFixedMarks")]
			public required Boolean? basedOnFixedMarks {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,5,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DeepWaterRouteCentreline);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRouteCentreline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRouteCentreline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DeepWaterRouteCentreline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFloat : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([6,7,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightFloat);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightFloat._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightFloat._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAllAround : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlIgnore]
			[EnumerationValue([5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("multiplicityOfFeatures")]
			public required multiplicityOfFeatures multiplicityOfFeatures {get;set;} = new multiplicityOfFeatures {
				multiplicityKnown = false,
			};

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("relativeHorizontalAccuracy")]
			public decimal? relativeHorizontalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeHorizontalAccuracy() { return relativeHorizontalAccuracy.HasValue; }

			[XmlIgnore]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("majorLight")]
			public Boolean? majorLight {get;set;} = default;

			public bool ShouldSerializemajorLight() { return majorLight.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public lightVisibility? lightVisibility {get;set;} = default;

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>? lightVisibilityElement { get { return lightVisibility; } set { } }

			public bool ShouldSerializelightVisibility() { return lightVisibility.HasValue; }

			[XmlElement("flareBearing")]
			public int? flareBearing {get;set;} = default;

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits>? heightLengthUnitsElement { get { return heightLengthUnits; } set { } }

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlIgnore]
			[EnumerationValue([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfLight")]
			public SerializableEnumeration<categoryOfLight>[] categoryOfLightElement { get { return [.. categoryOfLight]; } set { } }

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[XmlElement("rythmOfLight")]
			public required rythmOfLight rythmOfLight {get;set;} = new rythmOfLight {
				lightCharacteristic = default,
			};

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightAllAround);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightAllAround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightAllAround._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The line where shore and water meet. Shoreline and coastline are generally used synonymously.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Coastline : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,11,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,6,7,8,10])]
			public categoryOfCoastline? categoryOfCoastline {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCoastline")]
			public SerializableEnumeration<categoryOfCoastline>? categoryOfCoastlineElement { get { return categoryOfCoastline; } set { } }

			public bool ShouldSerializecategoryOfCoastline() { return categoryOfCoastline.HasValue; }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17])]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfSurface")]
			public SerializableEnumeration<natureOfSurface>[] natureOfSurfaceElement { get { return [.. natureOfSurface]; } set { } }

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Coastline);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Coastline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Coastline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Coastline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A geographically defined part of the sea or other navigable waters. It may be specified within its limits by its proper name.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeaAreaNamedWaterArea : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56])]
			public categoryOfSeaArea? categoryOfSeaArea {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfSeaArea")]
			public SerializableEnumeration<categoryOfSeaArea>? categoryOfSeaAreaElement { get { return categoryOfSeaArea; } set { } }

			public bool ShouldSerializecategoryOfSeaArea() { return categoryOfSeaArea.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([501,502,503,504,505])]
			public gradient? gradient {get;set;} = default;

			[JsonIgnore]
			[XmlElement("gradient")]
			public SerializableEnumeration<gradient>? gradientElement { get { return gradient; } set { } }

			public bool ShouldSerializegradient() { return gradient.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([4])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfHorizontalMeasurement")]
			public SerializableEnumeration<qualityOfHorizontalMeasurement>? qualityOfHorizontalMeasurementElement { get { return qualityOfHorizontalMeasurement; } set { } }

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SeaAreaNamedWaterArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SeaAreaNamedWaterArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SeaAreaNamedWaterArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SeaAreaNamedWaterArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Area designated for landing personnel and/or equipment by parachute 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DropZone : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DropZone);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DropZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DropZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DropZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A mechanical device for conveying bulk material or people using an endless moving belt or series of rollers.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Conveyor : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfConveyor? categoryOfConveyor {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfConveyor")]
			public SerializableEnumeration<categoryOfConveyor>? categoryOfConveyorElement { get { return categoryOfConveyor; } set { } }

			public bool ShouldSerializecategoryOfConveyor() { return categoryOfConveyor.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("multiplicityOfFeatures")]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			[XmlIgnore]
			[EnumerationValue([4,12])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("liftingCapacity")]
			public decimal? liftingCapacity {get;set;} = default;

			public bool ShouldSerializeliftingCapacity() { return liftingCapacity.HasValue; }

			[XmlElement("verticalClearanceFixed")]
			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			public bool ShouldSerializeverticalClearanceFixed() { return verticalClearanceFixed!=default; }

			[XmlIgnore]
			[EnumerationValue([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([4,5,6,10,11,12,13,14,15,16,17,22,25])]
			public List<product> product {get;set;} = [];

			[JsonIgnore]
			[XmlElement("product")]
			public SerializableEnumeration<product>[] productElement { get { return [.. product]; } set { } }

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Conveyor);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Conveyor._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Conveyor._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Conveyor._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A line drawn on a map or chart depicting the separation of any type of maritime jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LineOfDelimitation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlIgnore]
			[EnumerationValue([501,502,504,599])]
			public boundaryStatusType? boundaryStatusType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("boundaryStatusType")]
			public SerializableEnumeration<boundaryStatusType>? boundaryStatusTypeElement { get { return boundaryStatusType; } set { } }

			public bool ShouldSerializeboundaryStatusType() { return boundaryStatusType.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public jurisdiction? jurisdiction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("jurisdiction")]
			public SerializableEnumeration<jurisdiction>? jurisdictionElement { get { return jurisdiction; } set { } }

			public bool ShouldSerializejurisdiction() { return jurisdiction.HasValue; }

			[XmlIgnore]
			[EnumerationValue([501,506,511,599])]
			public categoryofBoundaryLine? categoryofBoundaryLine {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryofBoundaryLine")]
			public SerializableEnumeration<categoryofBoundaryLine>? categoryofBoundaryLineElement { get { return categoryofBoundaryLine; } set { } }

			public bool ShouldSerializecategoryofBoundaryLine() { return categoryofBoundaryLine.HasValue; }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LineOfDelimitation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LineOfDelimitation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LineOfDelimitation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LineOfDelimitation._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Straight baselines are a system of straight lines joining specified or discrete points on the low-water line, usually known as straight baseline turning points. Straight baselines are used in delimitation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StraightTerritorialSeaBaseline : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("nationality")]
			public required String? nationality {get;set;} = default;

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(StraightTerritorialSeaBaseline);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => StraightTerritorialSeaBaseline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => StraightTerritorialSeaBaseline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => StraightTerritorialSeaBaseline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A safe water beacon is used to indicate that there is navigable water around the mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBeacon : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape? beaconShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("beaconShape")]
			public SerializableEnumeration<beaconShape>? beaconShapeElement { get { return beaconShape.HasValue ? beaconShape : default; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SafeWaterBeacon);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SafeWaterBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBeacon : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>? colourPatternElement { get { return colourPattern; } set { } }

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape? beaconShape {get;set;} = default;

			[JsonIgnore]
			[XmlElement("beaconShape")]
			public SerializableEnumeration<beaconShape>? beaconShapeElement { get { return beaconShape.HasValue ? beaconShape : default; } set { } }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,10,11,12,14,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,60,61,62,63])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfSpecialPurposeMark")]
			public SerializableEnumeration<categoryOfSpecialPurposeMark>[] categoryOfSpecialPurposeMarkElement { get { return [.. categoryOfSpecialPurposeMark]; } set { } }

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBeacon);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SpecialPurposeGeneralBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S501/0.0")]
	[XmlRoot(Namespace = "http://www.iho.int/S501/0.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S501/0.0 501_0.0.5.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S501/0.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.ReferenceToAPublication", typeof(InformationTypes.ReferenceToAPublication), Order = 1, ElementName = "ReferenceToAPublication")]
		[XmlElement("FeatureTypes.InstallationBuoy", typeof(FeatureTypes.InstallationBuoy), Order = 1, ElementName = "InstallationBuoy")]
		[XmlElement("FeatureTypes.DepthArea", typeof(FeatureTypes.DepthArea), Order = 1, ElementName = "DepthArea")]
		[XmlElement("FeatureTypes.RadioCallingInPoint", typeof(FeatureTypes.RadioCallingInPoint), Order = 1, ElementName = "RadioCallingInPoint")]
		[XmlElement("FeatureTypes.PatrolArea", typeof(FeatureTypes.PatrolArea), Order = 1, ElementName = "PatrolArea")]
		[XmlElement("FeatureTypes.Checkpoint", typeof(FeatureTypes.Checkpoint), Order = 1, ElementName = "Checkpoint")]
		[XmlElement("FeatureTypes.MarineManagementArea", typeof(FeatureTypes.MarineManagementArea), Order = 1, ElementName = "MarineManagementArea")]
		[XmlElement("FeatureTypes.DepthContour", typeof(FeatureTypes.DepthContour), Order = 1, ElementName = "DepthContour")]
		[XmlElement("FeatureTypes.EnvironmentallySensitiveSeaArea", typeof(FeatureTypes.EnvironmentallySensitiveSeaArea), Order = 1, ElementName = "EnvironmentallySensitiveSeaArea")]
		[XmlElement("FeatureTypes.Road", typeof(FeatureTypes.Road), Order = 1, ElementName = "Road")]
		[XmlElement("FeatureTypes.River", typeof(FeatureTypes.River), Order = 1, ElementName = "River")]
		[XmlElement("FeatureTypes.MilitaryPracticeArea", typeof(FeatureTypes.MilitaryPracticeArea), Order = 1, ElementName = "MilitaryPracticeArea")]
		[XmlElement("FeatureTypes.DiscolouredWater", typeof(FeatureTypes.DiscolouredWater), Order = 1, ElementName = "DiscolouredWater")]
		[XmlElement("FeatureTypes.CardinalBuoy", typeof(FeatureTypes.CardinalBuoy), Order = 1, ElementName = "CardinalBuoy")]
		[XmlElement("FeatureTypes.SafeWaterBuoy", typeof(FeatureTypes.SafeWaterBuoy), Order = 1, ElementName = "SafeWaterBuoy")]
		[XmlElement("FeatureTypes.RadioStation", typeof(FeatureTypes.RadioStation), Order = 1, ElementName = "RadioStation")]
		[XmlElement("FeatureTypes.MilitaryExerciseAirspace", typeof(FeatureTypes.MilitaryExerciseAirspace), Order = 1, ElementName = "MilitaryExerciseAirspace")]
		[XmlElement("FeatureTypes.ContiguousZone", typeof(FeatureTypes.ContiguousZone), Order = 1, ElementName = "ContiguousZone")]
		[XmlElement("FeatureTypes.NormalBaseline", typeof(FeatureTypes.NormalBaseline), Order = 1, ElementName = "NormalBaseline")]
		[XmlElement("FeatureTypes.CableArea", typeof(FeatureTypes.CableArea), Order = 1, ElementName = "CableArea")]
		[XmlElement("FeatureTypes.ContinentalShelfArea", typeof(FeatureTypes.ContinentalShelfArea), Order = 1, ElementName = "ContinentalShelfArea")]
		[XmlElement("FeatureTypes.InternalWaters", typeof(FeatureTypes.InternalWaters), Order = 1, ElementName = "InternalWaters")]
		[XmlElement("FeatureTypes.AdministrationArea", typeof(FeatureTypes.AdministrationArea), Order = 1, ElementName = "AdministrationArea")]
		[XmlElement("FeatureTypes.Bollard", typeof(FeatureTypes.Bollard), Order = 1, ElementName = "Bollard")]
		[XmlElement("FeatureTypes.Dolphin", typeof(FeatureTypes.Dolphin), Order = 1, ElementName = "Dolphin")]
		[XmlElement("FeatureTypes.RadarRange", typeof(FeatureTypes.RadarRange), Order = 1, ElementName = "RadarRange")]
		[XmlElement("FeatureTypes.IsolatedDangerBeacon", typeof(FeatureTypes.IsolatedDangerBeacon), Order = 1, ElementName = "IsolatedDangerBeacon")]
		[XmlElement("FeatureTypes.IsolatedDangerBuoy", typeof(FeatureTypes.IsolatedDangerBuoy), Order = 1, ElementName = "IsolatedDangerBuoy")]
		[XmlElement("FeatureTypes.SubmarineTransitLane", typeof(FeatureTypes.SubmarineTransitLane), Order = 1, ElementName = "SubmarineTransitLane")]
		[XmlElement("FeatureTypes.MaritimeSafetyInformationArea", typeof(FeatureTypes.MaritimeSafetyInformationArea), Order = 1, ElementName = "MaritimeSafetyInformationArea")]
		[XmlElement("FeatureTypes.AirspaceRestriction", typeof(FeatureTypes.AirspaceRestriction), Order = 1, ElementName = "AirspaceRestriction")]
		[XmlElement("FeatureTypes.Sounding", typeof(FeatureTypes.Sounding), Order = 1, ElementName = "Sounding")]
		[XmlElement("FeatureTypes.TrafficSeparationSchemeBoundary", typeof(FeatureTypes.TrafficSeparationSchemeBoundary), Order = 1, ElementName = "TrafficSeparationSchemeBoundary")]
		[XmlElement("FeatureTypes.DumpingGround", typeof(FeatureTypes.DumpingGround), Order = 1, ElementName = "DumpingGround")]
		[XmlElement("FeatureTypes.AirportAirfield", typeof(FeatureTypes.AirportAirfield), Order = 1, ElementName = "AirportAirfield")]
		[XmlElement("FeatureTypes.FoulGround", typeof(FeatureTypes.FoulGround), Order = 1, ElementName = "FoulGround")]
		[XmlElement("FeatureTypes.LightAirObstruction", typeof(FeatureTypes.LightAirObstruction), Order = 1, ElementName = "LightAirObstruction")]
		[XmlElement("FeatureTypes.MooringBuoy", typeof(FeatureTypes.MooringBuoy), Order = 1, ElementName = "MooringBuoy")]
		[XmlElement("FeatureTypes.UnderwaterAwashRock", typeof(FeatureTypes.UnderwaterAwashRock), Order = 1, ElementName = "UnderwaterAwashRock")]
		[XmlElement("FeatureTypes.CableOverhead", typeof(FeatureTypes.CableOverhead), Order = 1, ElementName = "CableOverhead")]
		[XmlElement("FeatureTypes.ControlledAirspace", typeof(FeatureTypes.ControlledAirspace), Order = 1, ElementName = "ControlledAirspace")]
		[XmlElement("FeatureTypes.Obstruction", typeof(FeatureTypes.Obstruction), Order = 1, ElementName = "Obstruction")]
		[XmlElement("FeatureTypes.FishingGround", typeof(FeatureTypes.FishingGround), Order = 1, ElementName = "FishingGround")]
		[XmlElement("FeatureTypes.FishingFacility", typeof(FeatureTypes.FishingFacility), Order = 1, ElementName = "FishingFacility")]
		[XmlElement("FeatureTypes.NavigationSystem", typeof(FeatureTypes.NavigationSystem), Order = 1, ElementName = "NavigationSystem")]
		[XmlElement("FeatureTypes.TrafficSeparationSchemeCrossing", typeof(FeatureTypes.TrafficSeparationSchemeCrossing), Order = 1, ElementName = "TrafficSeparationSchemeCrossing")]
		[XmlElement("FeatureTypes.TrafficSeparationSchemeLanePart", typeof(FeatureTypes.TrafficSeparationSchemeLanePart), Order = 1, ElementName = "TrafficSeparationSchemeLanePart")]
		[XmlElement("FeatureTypes.TerritorialSeaArea", typeof(FeatureTypes.TerritorialSeaArea), Order = 1, ElementName = "TerritorialSeaArea")]
		[XmlElement("FeatureTypes.LateralBeacon", typeof(FeatureTypes.LateralBeacon), Order = 1, ElementName = "LateralBeacon")]
		[XmlElement("FeatureTypes.CoastGuardStation", typeof(FeatureTypes.CoastGuardStation), Order = 1, ElementName = "CoastGuardStation")]
		[XmlElement("FeatureTypes.SeparationZoneOrLine", typeof(FeatureTypes.SeparationZoneOrLine), Order = 1, ElementName = "SeparationZoneOrLine")]
		[XmlElement("FeatureTypes.BottomFeature", typeof(FeatureTypes.BottomFeature), Order = 1, ElementName = "BottomFeature")]
		[XmlElement("FeatureTypes.ArchipelagicBaseline", typeof(FeatureTypes.ArchipelagicBaseline), Order = 1, ElementName = "ArchipelagicBaseline")]
		[XmlElement("FeatureTypes.SmallBottomObject", typeof(FeatureTypes.SmallBottomObject), Order = 1, ElementName = "SmallBottomObject")]
		[XmlElement("FeatureTypes.ExclusiveEconomicZone", typeof(FeatureTypes.ExclusiveEconomicZone), Order = 1, ElementName = "ExclusiveEconomicZone")]
		[XmlElement("FeatureTypes.RadarStation", typeof(FeatureTypes.RadarStation), Order = 1, ElementName = "RadarStation")]
		[XmlElement("FeatureTypes.DivingLocation", typeof(FeatureTypes.DivingLocation), Order = 1, ElementName = "DivingLocation")]
		[XmlElement("FeatureTypes.RestrictedArea", typeof(FeatureTypes.RestrictedArea), Order = 1, ElementName = "RestrictedArea")]
		[XmlElement("FeatureTypes.CableSubmarine", typeof(FeatureTypes.CableSubmarine), Order = 1, ElementName = "CableSubmarine")]
		[XmlElement("FeatureTypes.Wreck", typeof(FeatureTypes.Wreck), Order = 1, ElementName = "Wreck")]
		[XmlElement("FeatureTypes.QRoute", typeof(FeatureTypes.QRoute), Order = 1, ElementName = "QRoute")]
		[XmlElement("FeatureTypes.CompletenessOfProductSpecification", typeof(FeatureTypes.CompletenessOfProductSpecification), Order = 1, ElementName = "CompletenessOfProductSpecification")]
		[XmlElement("FeatureTypes.RescueStation", typeof(FeatureTypes.RescueStation), Order = 1, ElementName = "RescueStation")]
		[XmlElement("FeatureTypes.CardinalBeacon", typeof(FeatureTypes.CardinalBeacon), Order = 1, ElementName = "CardinalBeacon")]
		[XmlElement("FeatureTypes.LightVessel", typeof(FeatureTypes.LightVessel), Order = 1, ElementName = "LightVessel")]
		[XmlElement("FeatureTypes.FisheryZone", typeof(FeatureTypes.FisheryZone), Order = 1, ElementName = "FisheryZone")]
		[XmlElement("FeatureTypes.DredgedArea", typeof(FeatureTypes.DredgedArea), Order = 1, ElementName = "DredgedArea")]
		[XmlElement("FeatureTypes.FerryRoute", typeof(FeatureTypes.FerryRoute), Order = 1, ElementName = "FerryRoute")]
		[XmlElement("FeatureTypes.ShorelineConstruction", typeof(FeatureTypes.ShorelineConstruction), Order = 1, ElementName = "ShorelineConstruction")]
		[XmlElement("FeatureTypes.CautionArea", typeof(FeatureTypes.CautionArea), Order = 1, ElementName = "CautionArea")]
		[XmlElement("FeatureTypes.DeepWaterRoutePart", typeof(FeatureTypes.DeepWaterRoutePart), Order = 1, ElementName = "DeepWaterRoutePart")]
		[XmlElement("FeatureTypes.CurrentNonGravitational", typeof(FeatureTypes.CurrentNonGravitational), Order = 1, ElementName = "CurrentNonGravitational")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.SeabedArea", typeof(FeatureTypes.SeabedArea), Order = 1, ElementName = "SeabedArea")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBuoy", typeof(FeatureTypes.SpecialPurposeGeneralBuoy), Order = 1, ElementName = "SpecialPurposeGeneralBuoy")]
		[XmlElement("FeatureTypes.LightSectored", typeof(FeatureTypes.LightSectored), Order = 1, ElementName = "LightSectored")]
		[XmlElement("FeatureTypes.IceLine", typeof(FeatureTypes.IceLine), Order = 1, ElementName = "IceLine")]
		[XmlElement("FeatureTypes.AnchorageArea", typeof(FeatureTypes.AnchorageArea), Order = 1, ElementName = "AnchorageArea")]
		[XmlElement("FeatureTypes.LateralBuoy", typeof(FeatureTypes.LateralBuoy), Order = 1, ElementName = "LateralBuoy")]
		[XmlElement("FeatureTypes.TrafficSeparationSchemeRoundabout", typeof(FeatureTypes.TrafficSeparationSchemeRoundabout), Order = 1, ElementName = "TrafficSeparationSchemeRoundabout")]
		[XmlElement("FeatureTypes.DeepWaterRouteCentreline", typeof(FeatureTypes.DeepWaterRouteCentreline), Order = 1, ElementName = "DeepWaterRouteCentreline")]
		[XmlElement("FeatureTypes.LightFloat", typeof(FeatureTypes.LightFloat), Order = 1, ElementName = "LightFloat")]
		[XmlElement("FeatureTypes.LightAllAround", typeof(FeatureTypes.LightAllAround), Order = 1, ElementName = "LightAllAround")]
		[XmlElement("FeatureTypes.Coastline", typeof(FeatureTypes.Coastline), Order = 1, ElementName = "Coastline")]
		[XmlElement("FeatureTypes.SeaAreaNamedWaterArea", typeof(FeatureTypes.SeaAreaNamedWaterArea), Order = 1, ElementName = "SeaAreaNamedWaterArea")]
		[XmlElement("FeatureTypes.DropZone", typeof(FeatureTypes.DropZone), Order = 1, ElementName = "DropZone")]
		[XmlElement("FeatureTypes.Conveyor", typeof(FeatureTypes.Conveyor), Order = 1, ElementName = "Conveyor")]
		[XmlElement("FeatureTypes.LineOfDelimitation", typeof(FeatureTypes.LineOfDelimitation), Order = 1, ElementName = "LineOfDelimitation")]
		[XmlElement("FeatureTypes.StraightTerritorialSeaBaseline", typeof(FeatureTypes.StraightTerritorialSeaBaseline), Order = 1, ElementName = "StraightTerritorialSeaBaseline")]
		[XmlElement("FeatureTypes.SafeWaterBeacon", typeof(FeatureTypes.SafeWaterBeacon), Order = 1, ElementName = "SafeWaterBeacon")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBeacon", typeof(FeatureTypes.SpecialPurposeGeneralBeacon), Order = 1, ElementName = "SpecialPurposeGeneralBeacon")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
