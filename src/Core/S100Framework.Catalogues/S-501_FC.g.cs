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

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum visualProminence : int {
		[System.ComponentModel.Description("TermAppliedToAnObjectEitherNaturalOrArtificialWhichIsDistinctlyAndNotablyVisibleFromSeaward")]
		[EnumMember(Value = "Visually Conspicuous")] 
		[XmlEnum("1")] 
		VisuallyConspicuous = 1,

		[System.ComponentModel.Description("AnObjectThatMayBeVisibleFromSeawardButCannotBeUsedAsAFixingMarkAndIsNotConspicuous")]
		[EnumMember(Value = "Not Visually Conspicuous")] 
		[XmlEnum("2")] 
		NotVisuallyConspicuous = 2,

		[System.ComponentModel.Description("ObjectsWhichAreEasilyIdentifiableButDoNotJustifyBeingClassedAsConspicuous")]
		[EnumMember(Value = "Prominent")] 
		[XmlEnum("3")] 
		Prominent = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum gradientOfSlope : int {
		[System.ComponentModel.Description("five01SteepMissingDefinition")]
		[EnumMember(Value = "Steep")] 
		[XmlEnum("501")] 
		Steep = 501,

		[System.ComponentModel.Description("five02ModerateMissingDefinition")]
		[EnumMember(Value = "Moderate")] 
		[XmlEnum("502")] 
		Moderate = 502,

		[System.ComponentModel.Description("five03GentleMissingDefinition")]
		[EnumMember(Value = "Gentle")] 
		[XmlEnum("503")] 
		Gentle = 503,

		[System.ComponentModel.Description("five04MildMissingDefinition")]
		[EnumMember(Value = "Mild")] 
		[XmlEnum("504")] 
		Mild = 504,

		[System.ComponentModel.Description("ALevelTractOfLandAsTheBedOfADryLakeOrAnAreaFrequentlyUncoveredAtLowTideUsuallyInPlural")]
		[EnumMember(Value = "Flat")] 
		[XmlEnum("505")] 
		Flat = 505,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeofMilitaryActivity : int {
		[System.ComponentModel.Description("five01AntiAircraftGroundToAirMissingDefinition")]
		[EnumMember(Value = "Anti Aircraft (ground to air)")] 
		[XmlEnum("501")] 
		AntiAircraftGroundToAir = 501,

		[System.ComponentModel.Description("five02HighAndLowAngleGunneryGroundToGroundMissingDefinition")]
		[EnumMember(Value = "High and Low angle gunnery (ground to ground)")] 
		[XmlEnum("502")] 
		HighAndLowAngleGunneryGroundToGround = 502,

		[System.ComponentModel.Description("five03AirToAirFiringMissingDefinition")]
		[EnumMember(Value = "Air to Air Firing")] 
		[XmlEnum("503")] 
		AirToAirFiring = 503,

		[System.ComponentModel.Description("five04AirCombatTrainingMissingDefinition")]
		[EnumMember(Value = "Air Combat Training")] 
		[XmlEnum("504")] 
		AirCombatTraining = 504,

		[System.ComponentModel.Description("five0fiveAirDroppedTorpedoMissingDefinition")]
		[EnumMember(Value = "Air Dropped Torpedo")] 
		[XmlEnum("505")] 
		AirDroppedTorpedo = 505,

		[System.ComponentModel.Description("five06AircraftGeneralMissingDefinition")]
		[EnumMember(Value = "Aircraft General")] 
		[XmlEnum("506")] 
		AircraftGeneral = 506,

		[System.ComponentModel.Description("five07AirToSurfaceFiringMissingDefinition")]
		[EnumMember(Value = "Air to Surface Firing")] 
		[XmlEnum("507")] 
		AirToSurfaceFiring = 507,

		[System.ComponentModel.Description("five08AntiSubmarineWarfareExercisesMissingDefinition")]
		[EnumMember(Value = "Anti Submarine Warfare Exercises")] 
		[XmlEnum("508")] 
		AntiSubmarineWarfareExercises = 508,

		[System.ComponentModel.Description("five09AcousticTrialsMissingDefinition")]
		[EnumMember(Value = "Acoustic Trials")] 
		[XmlEnum("509")] 
		AcousticTrials = 509,

		[System.ComponentModel.Description("five10AirTacticalTrainingMissingDefinition")]
		[EnumMember(Value = "Air Tactical Training")] 
		[XmlEnum("510")] 
		AirTacticalTraining = 510,

		[System.ComponentModel.Description("five11BombingMissingDefinition")]
		[EnumMember(Value = "Bombing")] 
		[XmlEnum("511")] 
		Bombing = 511,

		[System.ComponentModel.Description("five12DepthChargeDroppingFiringIncludingRocketMortarFiredDcMissingDefinition")]
		[EnumMember(Value = "Depth Charge dropping/firing (including rocket/mortar fired DC)")] 
		[XmlEnum("512")] 
		DepthChargeDroppingFiringIncludingRocketMortarFiredDc = 512,

		[System.ComponentModel.Description("NeutralizationOfTheStrengthOfTheMagneticFieldOfAVesselByMeansOfSuitablyArrangedElectricCoilsPermanentlyInstalledInTheVesselSeeAlsoDegaussingCable")]
		[EnumMember(Value = "Degaussing")] 
		[XmlEnum("513")] 
		Degaussing = 513,

		[System.ComponentModel.Description("five14DemolitionOfUnexplodedOrdnanceMissingDefinition")]
		[EnumMember(Value = "Demolition of unexploded ordnance")] 
		[XmlEnum("514")] 
		DemolitionOfUnexplodedOrdnance = 514,

		[System.ComponentModel.Description("five1fiveExplosivesTrialsMissingDefinition")]
		[EnumMember(Value = "Explosives Trials")] 
		[XmlEnum("515")] 
		ExplosivesTrials = 515,

		[System.ComponentModel.Description("five16FiringMissingDefinition")]
		[EnumMember(Value = "Firing")] 
		[XmlEnum("516")] 
		Firing = 516,

		[System.ComponentModel.Description("five17FlaresMissingDefinition")]
		[EnumMember(Value = "Flares")] 
		[XmlEnum("517")] 
		Flares = 517,

		[System.ComponentModel.Description("five18GlowWormMissingDefinition")]
		[EnumMember(Value = "Glow Worm")] 
		[XmlEnum("518")] 
		GlowWorm = 518,

		[System.ComponentModel.Description("five19GeneralPracticeMissingDefinition")]
		[EnumMember(Value = "General Practice")] 
		[XmlEnum("519")] 
		GeneralPractice = 519,

		[System.ComponentModel.Description("five20GuidedWeaponsAirFlightMissingDefinition")]
		[EnumMember(Value = "Guided Weapons (air Flight)")] 
		[XmlEnum("520")] 
		GuidedWeaponsAirFlight = 520,

		[System.ComponentModel.Description("five21HelicopterExercisesMissingDefinition")]
		[EnumMember(Value = "Helicopter exercises")] 
		[XmlEnum("521")] 
		HelicopterExercises = 521,

		[System.ComponentModel.Description("five22HighEnergyManouvresMissingDefinition")]
		[EnumMember(Value = "High Energy Manouvres")] 
		[XmlEnum("522")] 
		HighEnergyManouvres = 522,

		[System.ComponentModel.Description("five23HmShipsNonFiringExercisesPracticesAndTrialsMissingDefinition")]
		[EnumMember(Value = "HM Ships (non-firing exercises, practices and trials)")] 
		[XmlEnum("523")] 
		HmShipsNonFiringExercisesPracticesAndTrials = 523,

		[System.ComponentModel.Description("five24LiveAswFiringMissingDefinition")]
		[EnumMember(Value = "Live ASW firing")] 
		[XmlEnum("524")] 
		LiveAswFiring = 524,

		[System.ComponentModel.Description("five2fiveMineCounterMeasuresMissingDefinition")]
		[EnumMember(Value = "Mine Counter Measures")] 
		[XmlEnum("525")] 
		MineCounterMeasures = 525,

		[System.ComponentModel.Description("five26MineDisposalMissingDefinition")]
		[EnumMember(Value = "Mine Disposal")] 
		[XmlEnum("526")] 
		MineDisposal = 526,

		[System.ComponentModel.Description("five27MissileFiringMissingDefinition")]
		[EnumMember(Value = "Missile Firing")] 
		[XmlEnum("527")] 
		MissileFiring = 527,

		[System.ComponentModel.Description("five28MortarFiringMissingDefinition")]
		[EnumMember(Value = "Mortar Firing")] 
		[XmlEnum("528")] 
		MortarFiring = 528,

		[System.ComponentModel.Description("five29NavalGunfireSupportMissingDefinition")]
		[EnumMember(Value = "Naval Gunfire Support")] 
		[XmlEnum("529")] 
		NavalGunfireSupport = 529,

		[System.ComponentModel.Description("five30NoiseRangingMissingDefinition")]
		[EnumMember(Value = "Noise Ranging")] 
		[XmlEnum("530")] 
		NoiseRanging = 530,

		[System.ComponentModel.Description("five31ParachuteDroppingMissingDefinition")]
		[EnumMember(Value = "Parachute Dropping")] 
		[XmlEnum("531")] 
		ParachuteDropping = 531,

		[System.ComponentModel.Description("five32PilotlessTargetAircraftMissingDefinition")]
		[EnumMember(Value = "Pilotless Target Aircraft")] 
		[XmlEnum("532")] 
		PilotlessTargetAircraft = 532,

		[System.ComponentModel.Description("five33RadarTrainingBuoyMissingDefinition")]
		[EnumMember(Value = "Radar Training Buoy")] 
		[XmlEnum("533")] 
		RadarTrainingBuoy = 533,

		[System.ComponentModel.Description("five34SubmarineExercisesMissingDefinition")]
		[EnumMember(Value = "Submarine Exercises")] 
		[XmlEnum("534")] 
		SubmarineExercises = 534,

		[System.ComponentModel.Description("SuspensionInTheAtmosphereOfSmallParticlesProducedByCombustion")]
		[EnumMember(Value = "Smoke")] 
		[XmlEnum("535")] 
		Smoke = 535,

		[System.ComponentModel.Description("five36SonobuoyDroppingMissingDefinition")]
		[EnumMember(Value = "Sonobuoy Dropping")] 
		[XmlEnum("536")] 
		SonobuoyDropping = 536,

		[System.ComponentModel.Description("five37StarshellMissingDefinition")]
		[EnumMember(Value = "Starshell")] 
		[XmlEnum("537")] 
		Starshell = 537,

		[System.ComponentModel.Description("five38SurfaceTargetTowingMissingDefinition")]
		[EnumMember(Value = "Surface Target Towing")] 
		[XmlEnum("538")] 
		SurfaceTargetTowing = 538,

		[System.ComponentModel.Description("five39SurfaceToSurfaceFiringsMissingDefinition")]
		[EnumMember(Value = "Surface to Surface Firings")] 
		[XmlEnum("539")] 
		SurfaceToSurfaceFirings = 539,

		[System.ComponentModel.Description("five40SubmarineGeneralNonFiringExercisesPracticesTrialsMissingDefinition")]
		[EnumMember(Value = "Submarine General (non-firing exercises, practices, trials)")] 
		[XmlEnum("540")] 
		SubmarineGeneralNonFiringExercisesPracticesTrials = 540,

		[System.ComponentModel.Description("five41SurfaceExplosionsMissingDefinition")]
		[EnumMember(Value = "Surface Explosions")] 
		[XmlEnum("541")] 
		SurfaceExplosions = 541,

		[System.ComponentModel.Description("five42TorpedoFiringAreaMissingDefinition")]
		[EnumMember(Value = "Torpedo Firing Area")] 
		[XmlEnum("542")] 
		TorpedoFiringArea = 542,

		[System.ComponentModel.Description("five43TowedArrayMissingDefinition")]
		[EnumMember(Value = "Towed Array")] 
		[XmlEnum("543")] 
		TowedArray = 543,

		[System.ComponentModel.Description("five44AerialTowedTargetOrTargetTowingAircraftMissingDefinition")]
		[EnumMember(Value = "Aerial Towed Target or Target Towing Aircraft")] 
		[XmlEnum("544")] 
		AerialTowedTargetOrTargetTowingAircraft = 544,

		[System.ComponentModel.Description("five4fiveWeaponTrainingMissingDefinition")]
		[EnumMember(Value = "Weapon Training")] 
		[XmlEnum("545")] 
		WeaponTraining = 545,

		[System.ComponentModel.Description("five46AmphibiousMissingDefinition")]
		[EnumMember(Value = "Amphibious")] 
		[XmlEnum("546")] 
		Amphibious = 546,

		[System.ComponentModel.Description("ASignalOrMessageWarningOfDivingActivity")]
		[EnumMember(Value = "Diving")] 
		[XmlEnum("547")] 
		Diving = 547,

		[System.ComponentModel.Description("five98BalloonsMissingDefinition")]
		[EnumMember(Value = "Balloons")] 
		[XmlEnum("598")] 
		Balloons = 598,

		[System.ComponentModel.Description("five99ElectricalOpticalHazardMissingDefinition")]
		[EnumMember(Value = "Electrical/Optical Hazard")] 
		[XmlEnum("599")] 
		ElectricalOpticalHazard = 599,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCoastline : int {
		[System.ComponentModel.Description("ACoastBackedByRockOrEarthCliffsGivesAGoodRadarReturnAndIsUsefulForVisualIdentificationFromAConsiderableDistanceOffWhereCliffsAlternateWithLowLyingCoastAlongTheShoreline")]
		[EnumMember(Value = "Steep Coast")] 
		[XmlEnum("1")] 
		SteepCoast = 1,

		[System.ComponentModel.Description("ALevelCoastWithNoObviousTopographicFeatures")]
		[EnumMember(Value = "Flat Coast")] 
		[XmlEnum("2")] 
		FlatCoast = 2,

		[System.ComponentModel.Description("sixGlacierSeawardEndMissingDefinition")]
		[EnumMember(Value = "glacier, seaward end")] 
		[XmlEnum("6")] 
		GlacierSeawardEnd = 6,

		[System.ComponentModel.Description("OneOfSeveralGeneraOfTropicalTreesOrShrubsWhichProduceManyPropRootsAndGrowAlongLowLyingCoastsIntoShallowWater")]
		[EnumMember(Value = "Mangrove")] 
		[XmlEnum("7")] 
		Mangrove = 7,

		[System.ComponentModel.Description("AShorelineAreaMadeUpOfSpongyLandSaturatedWithWaterItMayHaveAShallowCoveringOfWaterUsuallyWithAConsiderableAmountOfVegetationAppearingAboveTheSurface")]
		[EnumMember(Value = "Marshy Shore")] 
		[XmlEnum("8")] 
		MarshyShore = 8,

		[System.ComponentModel.Description("AVerticalCliffFormingTheSeawardEdgeOfAnIceShelfRangingInHeightFrom2MetresTo50MetresOrMoreAboveSeaLevel")]
		[EnumMember(Value = "Ice Coast")] 
		[XmlEnum("10")] 
		IceCoast = 10,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum speedUnits : int {
		[System.ComponentModel.Description("AUnitOfSpeedExpressingTheNumberOfKilometresTravelledInOneHour")]
		[EnumMember(Value = "Kilometres Per Hour")] 
		[XmlEnum("2")] 
		KilometresPerHour = 2,

		[System.ComponentModel.Description("AnImperialAndUnitedStatesCustomaryUnitOfSpeedExpressingTheNumberOfStatuteMilesCoveredInOneHour")]
		[EnumMember(Value = "Miles Per Hour")] 
		[XmlEnum("3")] 
		MilesPerHour = 3,

		[System.ComponentModel.Description("ANauticalUnitOfSpeedOneKnotIsOneNauticalMilePerHourTheNameIsDerivedFromTheKnotsInTheLogLine")]
		[EnumMember(Value = "Knots")] 
		[XmlEnum("4")] 
		Knots = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfInstallationBuoy : int {
		[System.ComponentModel.Description("IncorporatesALargeBuoyWhichRemainsOnTheSurfaceAtAllTimesAndIsMooredBy4OrMoreAnchorsMooringHawsersAndCargoHosesLeadFromATurntableOnTopOfTheBuoySoThatTheBuoyDoesNotTurnAsTheShipSwingsToWindAndStream")]
		[EnumMember(Value = "Catenary Anchor Leg Mooring")] 
		[XmlEnum("1")] 
		CatenaryAnchorLegMooring = 1,

		[System.ComponentModel.Description("ALargeMooringBuoyUsedByTankersToLoadAndUnloadInPortApproachesOrInOffshoreOilAndGasFields")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		[XmlEnum("2")] 
		SingleBuoyMooring = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofRestrictions : int {
		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveItsFloraFaunaPhysicalFeaturesEtc")]
		[EnumMember(Value = "Nature Reserve")] 
		[XmlEnum("4")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("APlaceWhereBirdsAreBredAndProtected")]
		[EnumMember(Value = "Bird Sanctuary")] 
		[XmlEnum("5")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("APlaceWhereWildAnimalsOrBirdsHuntedForSportOrFoodAreKeptUndisturbedForPrivateUse")]
		[EnumMember(Value = "Game Reserve")] 
		[XmlEnum("6")] 
		GameReserve = 6,

		[System.ComponentModel.Description("APlaceWhereSealsAreProtected")]
		[EnumMember(Value = "Seal Sanctuary")] 
		[XmlEnum("7")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("AnAreaAroundCertainWrecksOfHistoricalImportanceToProtectTheWrecksFromUnauthorizedInterferenceByDivingSalvageOrDepositionIncludingAnchoring")]
		[EnumMember(Value = "Historic Wreck Area")] 
		[XmlEnum("10")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("AnAreaWhereMarineResearchTakesPlace")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("APlaceWhereFishIncludingShellfishAndCrustaceansAreProtected")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveTheRelationOfPlantsAndLivingCreaturesToEachOtherAndToTheirSurroundings")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("two7EnvironmentallySensitiveSeaAreaEssaMissingDefinition")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area (ESSA)")] 
		[XmlEnum("27")] 
		EnvironmentallySensitiveSeaAreaEssa = 27,

		[System.ComponentModel.Description("two8ParticularlySensitiveSeaAreaPssaMissingDefinition")]
		[EnumMember(Value = "Particularly Sensitive Sea Area (PSSA)")] 
		[XmlEnum("28")] 
		ParticularlySensitiveSeaAreaPssa = 28,

		[System.ComponentModel.Description("APlaceWhereCoralIsProtected")]
		[EnumMember(Value = "Coral Sanctuary")] 
		[XmlEnum("31")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("AnAreaWithinWhichRecreationalActivitiesRegularlyTakePlaceAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Recreation Area")] 
		[XmlEnum("32")] 
		RecreationArea = 32,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("APositionThatIsConsideredToBeLessThanThirdOrderAccuracyButIsGenerallyConsideredToBeWithin305MetresOfItsCorrectGeographicLocationAlsoMayApplyToAFeatureWhosePositionDoesNotRemainFixed")]
		[EnumMember(Value = "Approximate")] 
		[XmlEnum("4")] 
		Approximate = 4,

		[System.ComponentModel.Description("OfUncertainPositionTheExpressionIsUsedPrincipallyOnChartsToIndicateThatAWreckShoalEtcHasBeenReportedInVariousPositionsAndNotDefinitelyDeterminedInAny")]
		[EnumMember(Value = "Position Doubtful")] 
		[XmlEnum("5")] 
		PositionDoubtful = 5,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum jurisdiction : int {
		[System.ComponentModel.Description("InvolvingMoreThanOneCountryCoveringMoreThanOneNationalArea")]
		[EnumMember(Value = "International")] 
		[XmlEnum("1")] 
		International = 1,

		[System.ComponentModel.Description("AnAreaAdministeredOrControlledByASingleNation")]
		[EnumMember(Value = "National")] 
		[XmlEnum("2")] 
		National = 2,

		[System.ComponentModel.Description("threeNationalSubDivisionMissingDefinition")]
		[EnumMember(Value = "National Sub-Division")] 
		[XmlEnum("3")] 
		NationalSubDivision = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurface : int {
		[System.ComponentModel.Description("SoftWetEarth")]
		[EnumMember(Value = "Mud")] 
		[XmlEnum("1")] 
		Mud = 1,

		[System.ComponentModel.Description("ParticlesOfLessThan0002mmStiffStickyEarthThatBecomesHardWhenBaked")]
		[EnumMember(Value = "Clay")] 
		[XmlEnum("2")] 
		Clay = 2,

		[System.ComponentModel.Description("AnUnconsolidatedSedimentWhoseParticlesRangeInSizeFrom00039To00625MillimetresInDiameterBetweenClayAndSandSize")]
		[EnumMember(Value = "Silt")] 
		[XmlEnum("3")] 
		Silt = 3,

		[System.ComponentModel.Description("LooseMaterialConsistingOfSmallButEasilyDistinguishableSeparateGrainsBetween00625And2000MillimetresInDiameter")]
		[EnumMember(Value = "Sand")] 
		[XmlEnum("4")] 
		Sand = 4,

		[System.ComponentModel.Description("AGeneralTermForRockAndRockFragmentsRangingInSizeFromPebblesAndGravelToBouldersOrLargeRockMasses")]
		[EnumMember(Value = "Stone")] 
		[XmlEnum("5")] 
		Stone = 5,

		[System.ComponentModel.Description("ParticlesOf2040mmSmallStonesWithCoarseSand")]
		[EnumMember(Value = "Gravel")] 
		[XmlEnum("6")] 
		Gravel = 6,

		[System.ComponentModel.Description("ASmallStoneWornSmoothAndRoundedByTheActionOfWaterSandIceEtcRangingInDiameterBetween4And64Millimetres")]
		[EnumMember(Value = "Pebbles")] 
		[XmlEnum("7")] 
		Pebbles = 7,

		[System.ComponentModel.Description("ANaturallyRoundedStoneLargerThanAPebble")]
		[EnumMember(Value = "Cobbles")] 
		[XmlEnum("8")] 
		Cobbles = 8,

		[System.ComponentModel.Description("AnyFormationOfNaturalOriginThatConstitutesAnIntegralPartOfTheLithosphereTheNaturalOccurringMaterialThatFormsFirmHardAndSolidMasses")]
		[EnumMember(Value = "Rock")] 
		[XmlEnum("9")] 
		Rock = 9,

		[System.ComponentModel.Description("TheFluidOrSemiFluidMatterFlowingFromAVolcanoTheSubstanceThatResultsFromTheCoolingOfTheMoltenRockPartOfTheOceanBedIsComposedOfLava")]
		[EnumMember(Value = "Lava")] 
		[XmlEnum("11")] 
		Lava = 11,

		[System.ComponentModel.Description("HardCalcareousSkeletonsOfManyTribesOfMarinePolyps")]
		[EnumMember(Value = "Coral")] 
		[XmlEnum("14")] 
		Coral = 14,

		[System.ComponentModel.Description("TheHardOutsideCoveringOfAnAnimalPartOfTheOceanBedIsComposedOfNumerousShellsOfMarineAnimals")]
		[EnumMember(Value = "Shells")] 
		[XmlEnum("17")] 
		Shells = 17,

		[System.ComponentModel.Description("ARoundedRockWithDiameterOf256MillimetresOrLarger")]
		[EnumMember(Value = "Boulder")] 
		[XmlEnum("18")] 
		Boulder = 18,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum marksNavigationalSystemOf : int {
		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaASystem")]
		[EnumMember(Value = "IALA A")] 
		[XmlEnum("1")] 
		IalaA = 1,

		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaBSystem")]
		[EnumMember(Value = "IALA B")] 
		[XmlEnum("2")] 
		IalaB = 2,

		[System.ComponentModel.Description("NavigationalAidsDoNotConformToAnyDefinedSystem")]
		[EnumMember(Value = "No System")] 
		[XmlEnum("9")] 
		NoSystem = 9,

		[System.ComponentModel.Description("NavigationalAidsAsRequiredInInternationalNationalOrRegionalRegulationsThatContainTheSameNavigationalAidsAsTheEuropeanCodeForInlandWaterwaysOfUneceOrIfThereIsNoRegulationForAWaterwayNavigationalAidsAsRecommendedInTheEuropeanCodeForInlandWaterwaysOfUnece")]
		[EnumMember(Value = "Main European Inland Waterway Marking System")] 
		[XmlEnum("11")] 
		MainEuropeanInlandWaterwayMarkingSystem = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum magneticAnomalyDetectorSignature : int {
		[System.ComponentModel.Description("five01NilMissingDefinition")]
		[EnumMember(Value = "nil")] 
		[XmlEnum("501")] 
		Nil = 501,

		[System.ComponentModel.Description("five02SlightMissingDefinition")]
		[EnumMember(Value = "slight")] 
		[XmlEnum("502")] 
		Slight = 502,

		[System.ComponentModel.Description("five03ModerateMissingDefinition")]
		[EnumMember(Value = "moderate")] 
		[XmlEnum("503")] 
		Moderate = 503,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("504")] 
		Strong = 504,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("TheValueOfTheLeftValueIsGreaterThanThatOfTheRight")]
		[EnumMember(Value = "Greater Than")] 
		[XmlEnum("1")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsGreaterThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Greater Than or Equal To")] 
		[XmlEnum("2")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanThatOfTheRight")]
		[EnumMember(Value = "Less Than")] 
		[XmlEnum("3")] 
		LessThan = 3,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Less Than or Equal To")] 
		[XmlEnum("4")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("TheTwoValuesAreEquivalent")]
		[EnumMember(Value = "Equal To")] 
		[XmlEnum("5")] 
		EqualTo = 5,

		[System.ComponentModel.Description("TheTwoValuesAreNotEquivalent")]
		[EnumMember(Value = "Not Equal To")] 
		[XmlEnum("6")] 
		NotEqualTo = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCable : int {
		[System.ComponentModel.Description("ACableThatTransmitsOrDistributesElectricalPower")]
		[EnumMember(Value = "Power Line")] 
		[XmlEnum("1")] 
		PowerLine = 1,

		[System.ComponentModel.Description("MultipleUnInsulatedCablesUsuallySupportedBySteelLatticeTowersSuchFeaturesAreGenerallyMoreProminentThanNormalPowerLines")]
		[EnumMember(Value = "Transmission Line")] 
		[XmlEnum("3")] 
		TransmissionLine = 3,

		[System.ComponentModel.Description("AChainOrVeryStrongFibreOrWireRopeUsedToAnchorOrMoorVesselsOrBuoys")]
		[EnumMember(Value = "Mooring Cable")] 
		[XmlEnum("6")] 
		MooringCable = 6,

		[System.ComponentModel.Description("AVesselForTransportingPassengersVehiclesAndOrGoodsAcrossAStretchOfWaterEspeciallyAsARegularService")]
		[EnumMember(Value = "Ferry")] 
		[XmlEnum("7")] 
		Ferry = 7,

		[System.ComponentModel.Description("ACableUsedForJoiningComponentsOfComplexMarineStructuresForExampleMooringTrots")]
		[EnumMember(Value = "Junction Cable")] 
		[XmlEnum("9")] 
		JunctionCable = 9,

		[System.ComponentModel.Description("ACableUsedForTheTransmissionAndReceptionOfModulatedCommunicationWavesSignals")]
		[EnumMember(Value = "Telecommunications Cable")] 
		[XmlEnum("10")] 
		TelecommunicationsCable = 10,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfWreck : int {
		[System.ComponentModel.Description("oneNonDangerousWreckMissingDefinition")]
		[EnumMember(Value = "non-dangerous wreck")] 
		[XmlEnum("1")] 
		NonDangerousWreck = 1,

		[System.ComponentModel.Description("AWreckSubmergedAtSuchADepthAsToBeConsideredDangerousToSurfaceNavigation")]
		[EnumMember(Value = "Dangerous Wreck")] 
		[XmlEnum("2")] 
		DangerousWreck = 2,

		[System.ComponentModel.Description("ASubstantivelyDecayedWreckOverWhichItIsSafeToNavigateButWhichShouldBeAvoidedForAnchoringTakingTheGroundOrGroundFishing")]
		[EnumMember(Value = "Distributed Remains of Wreck")] 
		[XmlEnum("3")] 
		DistributedRemainsOfWreck = 3,

		[System.ComponentModel.Description("fourWreckShowingMastMastsMissingDefinition")]
		[EnumMember(Value = "wreck showing mast/masts")] 
		[XmlEnum("4")] 
		WreckShowingMastMasts = 4,

		[System.ComponentModel.Description("WreckOfWhichAnyPortionOfTheHullOrSuperstructureIsVisibleAtTheSoundingDatumIndicated")]
		[EnumMember(Value = "Wreck Showing Any Portion of Hull or Superstructure")] 
		[XmlEnum("5")] 
		WreckShowingAnyPortionOfHullOrSuperstructure = 5,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLateralMark : int {
		[System.ComponentModel.Description("onePortHandLateralMarkMissingDefinition")]
		[EnumMember(Value = "port-hand lateral mark")] 
		[XmlEnum("1")] 
		PortHandLateralMark = 1,

		[System.ComponentModel.Description("twoStarboardHandLateralMarkMissingDefinition")]
		[EnumMember(Value = "starboard-hand lateral mark")] 
		[XmlEnum("2")] 
		StarboardHandLateralMark = 2,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedPortHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")] 
		[XmlEnum("3")] 
		PreferredChannelToStarboardLateralMark = 3,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedStarboardHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Port Lateral Mark")] 
		[XmlEnum("4")] 
		PreferredChannelToPortLateralMark = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum areaCategory : int {
		[System.ComponentModel.Description("five01SolidRedSrMissingDefinition")]
		[EnumMember(Value = "Solid Red (SR)")] 
		[XmlEnum("501")] 
		SolidRedSr = 501,

		[System.ComponentModel.Description("five02PeckedRedPrMissingDefinition")]
		[EnumMember(Value = "Pecked Red (PR)")] 
		[XmlEnum("502")] 
		PeckedRedPr = 502,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum status : int {
		[System.ComponentModel.Description("IntendedToLastOrFunctionIndefinitely")]
		[EnumMember(Value = "Permanent")] 
		[XmlEnum("1")] 
		Permanent = 1,

		[System.ComponentModel.Description("ActingOnSpecialOccasionsHappeningIrregularly")]
		[EnumMember(Value = "Occasional")] 
		[XmlEnum("2")] 
		Occasional = 2,

		[System.ComponentModel.Description("PresentedAsWorthyOfConfidenceAcceptanceUseEtc")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("3")] 
		Recommended = 3,

		[System.ComponentModel.Description("UseHasCeasedButTheFacilityStillExistsIntactDisused")]
		[EnumMember(Value = "Not in Use")] 
		[XmlEnum("4")] 
		NotInUse = 4,

		[System.ComponentModel.Description("fivePeriodicIntermittentMissingDefinition")]
		[EnumMember(Value = "periodic/intermittent")] 
		[XmlEnum("5")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("SetApartForSomeSpecificUse")]
		[EnumMember(Value = "Reserved")] 
		[XmlEnum("6")] 
		Reserved = 6,

		[System.ComponentModel.Description("MeantToLastOnlyForATime")]
		[EnumMember(Value = "Temporary")] 
		[XmlEnum("7")] 
		Temporary = 7,

		[System.ComponentModel.Description("AdministeredByAnIndividualOrCorporationRatherThanAStateOrAPublicBody")]
		[EnumMember(Value = "Private")] 
		[XmlEnum("8")] 
		Private = 8,

		[System.ComponentModel.Description("CompulsoryEnforced")]
		[EnumMember(Value = "Mandatory")] 
		[XmlEnum("9")] 
		Mandatory = 9,

		[System.ComponentModel.Description("NoLongerLit")]
		[EnumMember(Value = "Extinguished")] 
		[XmlEnum("11")] 
		Extinguished = 11,

		[System.ComponentModel.Description("LitByFloodLightsStripLightsEtc")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

		[System.ComponentModel.Description("FamousInHistoryOfHistoricalInterest")]
		[EnumMember(Value = "Historic")] 
		[XmlEnum("13")] 
		Historic = 13,

		[System.ComponentModel.Description("BelongingToAvailableToUsedOrSharedByTheCommunityAsAWholeAndNotRestrictedToPrivateUse")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("14")] 
		Public = 14,

		[System.ComponentModel.Description("OccurAtATimeCoincideInPointOfTimeBeContemporaryOrSimultaneous")]
		[EnumMember(Value = "Synchronized")] 
		[XmlEnum("15")] 
		Synchronized = 15,

		[System.ComponentModel.Description("LookedAtOrObservedOverAPeriodOfTimeEspeciallySoAsToBeAwareOfAnyMovementOrChange")]
		[EnumMember(Value = "Watched")] 
		[XmlEnum("16")] 
		Watched = 16,

		[System.ComponentModel.Description("UsuallyAutomaticInOperationWithoutAnyPermanentlyStationedPersonnelToSuperintendIt")]
		[EnumMember(Value = "Unwatched")] 
		[XmlEnum("17")] 
		Unwatched = 17,

		[System.ComponentModel.Description("AFeatureThatHasBeenReportedButHasNotBeenDefinitelyDeterminedToExist")]
		[EnumMember(Value = "Existence Doubtful")] 
		[XmlEnum("18")] 
		ExistenceDoubtful = 18,

		[System.ComponentModel.Description("MarkedByBuoys")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,

		[System.ComponentModel.Description("five01ActiveInUseMissingDefinition")]
		[EnumMember(Value = "active/in use")] 
		[XmlEnum("501")] 
		ActiveInUse = 501,

		[System.ComponentModel.Description("ACoastalStateClaimsOrMayClaimASpecificJurisdictionInAccordanceWithTheProvisionsOfInternationalLaw")]
		[EnumMember(Value = "Claimed")] 
		[XmlEnum("502")] 
		Claimed = 502,

		[System.ComponentModel.Description("five03PracticeAndOrExercisePurposesMissingDefinition")]
		[EnumMember(Value = "practice and/or exercise purposes")] 
		[XmlEnum("503")] 
		PracticeAndOrExercisePurposes = 503,

		[System.ComponentModel.Description("AcknowledgedAndAgreedInAccordanceWithTheProvisionsOfInternationalLaw")]
		[EnumMember(Value = "Recognised")] 
		[XmlEnum("504")] 
		Recognised = 504,

		[System.ComponentModel.Description("NotDetectedByRepeatedSurveysLeadingToDoubtsAboutTheObjectSExistenceAml")]
		[EnumMember(Value = "Dead")] 
		[XmlEnum("505")] 
		Dead = 505,

		[System.ComponentModel.Description("AnObjectThatHasBeenSalvagedOrRemovedAml")]
		[EnumMember(Value = "Lifted")] 
		[XmlEnum("506")] 
		Lifted = 506,

		[System.ComponentModel.Description("WhereASignificantNumberOfPersonsHavePerishedAsADirectResultOfAVesselOrStructureSinkingAndTheirRemainsCannotBeRecoveredTheWreckAndImmediateAreaMayBeDeclaredAsAMassGraveOrMoreSpecificallyAWarGraveSuchSitesAreProtectedFromDisturbanceByInternationalLawAml")]
		[EnumMember(Value = "Mass Grave")] 
		[XmlEnum("507")] 
		MassGrave = 507,

		[System.ComponentModel.Description("ABoreholeDrilledInTheSearchForANewSourceOfOilOrGasAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Exploration")] 
		[XmlEnum("508")] 
		Exploration = 508,

		[System.ComponentModel.Description("ABoreholeThatIsActivelyEngagedInTheExtractionOfOilOrGasFromTheSeabedAdaptedFromAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Production")] 
		[XmlEnum("509")] 
		Production = 509,

		[System.ComponentModel.Description("AWellWhereTheExtractionOfOilOrGasHasBeenTemporarilyAbandonedWhenSuspendedAWellIsEitherPluggedFilledWithConcreteAndToppedWithASteelPlateOrCappedWellHeadEquipmentIsInstalledOverTheWellAdaptedFromAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Suspended")] 
		[XmlEnum("510")] 
		Suspended = 510,

		[System.ComponentModel.Description("ABoreholeDrilledForThePurposeOfInjectingASecondarySubstanceForExampleWaterIntoThePoreSpacesInAReservoirRockToEncourageOilOrGasToFlowIntoAdjacentProducingWellsAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Injection")] 
		[XmlEnum("511")] 
		Injection = 511,

		[System.ComponentModel.Description("TheStatusOfTheObjectIsUnspecified")]
		[EnumMember(Value = "Unspecified")] 
		[XmlEnum("512")] 
		Unspecified = 512,

		[System.ComponentModel.Description("TemporarilyQuietInactiveNotBeingUsedAml")]
		[EnumMember(Value = "Dormant")] 
		[XmlEnum("516")] 
		Dormant = 516,

		[System.ComponentModel.Description("PlannedIntendedInAccordanceWithOrAchievedByACarefulPlanMadeBeforehandTheConciseOxfordDictionary")]
		[EnumMember(Value = "Proposed")] 
		[XmlEnum("517")] 
		Proposed = 517,

		[System.ComponentModel.Description("CompletelyDesertedGivenUpAdaptedFromTheConciseOxfordDictionary")]
		[EnumMember(Value = "Abandoned")] 
		[XmlEnum("518")] 
		Abandoned = 518,

		[System.ComponentModel.Description("AreaOfOverlapOfTheUnilateralFishingZonesOfTwoOrMoreCountries")]
		[EnumMember(Value = "Grey zone")] 
		[XmlEnum("519")] 
		GreyZone = 519,

		[System.ComponentModel.Description("AnAreaOfTheSeaOfIndeterminateJurisdictionWhereNoAgreedBoundaryExist")]
		[EnumMember(Value = "Indeterminate")] 
		[XmlEnum("520")] 
		Indeterminate = 520,

		[System.ComponentModel.Description("InvolvingTwoOrMoreStatesAsPartiesToAnAgreement")]
		[EnumMember(Value = "Multilateral")] 
		[XmlEnum("521")] 
		Multilateral = 521,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCardinalMark : int {
		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNwNeTakenFromThePointOfInterestItShouldBePassedToTheNorthSideOfTheMark")]
		[EnumMember(Value = "North Cardinal Mark")] 
		[XmlEnum("1")] 
		NorthCardinalMark = 1,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNeSeTakenFromThePointOfInterestItShouldBePassedToTheEastSideOfTheMark")]
		[EnumMember(Value = "East Cardinal Mark")] 
		[XmlEnum("2")] 
		EastCardinalMark = 2,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSeSwTakenFromThePointOfInterestItShouldBePassedToTheSouthSideOfTheMark")]
		[EnumMember(Value = "South Cardinal Mark")] 
		[XmlEnum("3")] 
		SouthCardinalMark = 3,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSwNwTakenFromThePointOfInterestItShouldBePassedToTheWestSideOfTheMark")]
		[EnumMember(Value = "West Cardinal Mark")] 
		[XmlEnum("4")] 
		WestCardinalMark = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAirportAirfield : int {
		[System.ComponentModel.Description("ALargeMilitaryAirfieldUsuallyEquippedWithAControlTowerHangarsAndAccommodationForTheReceivingAndDischargingOfPassengersOrCargo")]
		[EnumMember(Value = "Military Aeroplane Airport")] 
		[XmlEnum("1")] 
		MilitaryAeroplaneAirport = 1,

		[System.ComponentModel.Description("ALargeAirfieldUsuallyEquippedWithAControlTowerHangarsAndAccommodationForTheReceivingAndDischargingOfPassengersOrCargo")]
		[EnumMember(Value = "Civil Aeroplane Airport")] 
		[XmlEnum("2")] 
		CivilAeroplaneAirport = 2,

		[System.ComponentModel.Description("ALandingPlaceForHelicoptersControlledByTheMilitary")]
		[EnumMember(Value = "Military Heliport")] 
		[XmlEnum("3")] 
		MilitaryHeliport = 3,

		[System.ComponentModel.Description("ALandingPlaceForHelicoptersOftenTheRoofOfABuilding")]
		[EnumMember(Value = "Civil Heliport")] 
		[XmlEnum("4")] 
		CivilHeliport = 4,

		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfGliders")]
		[EnumMember(Value = "Glider Airfield")] 
		[XmlEnum("5")] 
		GliderAirfield = 5,

		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfSmallAeroplanes")]
		[EnumMember(Value = "Small Planes Airfield")] 
		[XmlEnum("6")] 
		SmallPlanesAirfield = 6,

		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfAeroplanesOrHelicoptersInTimesOfEmergency")]
		[EnumMember(Value = "Emergency Airfield")] 
		[XmlEnum("8")] 
		EmergencyAirfield = 8,

		[System.ComponentModel.Description("nineSearchAndRescueMissingDefinition")]
		[EnumMember(Value = "search and rescue")] 
		[XmlEnum("9")] 
		SearchAndRescue = 9,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum techniqueOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatDeterminesDepthOfWaterByMeasuringTheTimeIntervalBetweenEmissionOfASonicOrUltrasonicSignalAndReturnOfItsEchoFromTheBottom")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		[XmlEnum("1")] 
		FoundByEchoSounder = 1,

		[System.ComponentModel.Description("TheDepthWasComputedFromARecordProducedByActiveSonarInWhichFixedAcousticBeamsAreDirectedIntoTheWaterPerpendicularlyToTheDirectionOfTravelToScanTheSeabedAndGenerateARecordOfTheSeabedConfiguration")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		[XmlEnum("2")] 
		FoundBySideScanSonar = 2,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAWideSwathEchoSounderThatUsesMultipleBeamsToMeasureDepthsDirectlyBelowAndTransverseToTheShipSTrack")]
		[EnumMember(Value = "Found by Multi Beam")] 
		[XmlEnum("3")] 
		FoundByMultiBeam = 3,

		[System.ComponentModel.Description("TheDepthWasDeterminedByAPersonSkilledInThePracticeOfDiving")]
		[EnumMember(Value = "Found by Diver")] 
		[XmlEnum("4")] 
		FoundByDiver = 4,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingALineGraduatedWithAttachedMarksAndFastenedToASoundingLead")]
		[EnumMember(Value = "Found by Lead Line")] 
		[XmlEnum("5")] 
		FoundByLeadLine = 5,

		[System.ComponentModel.Description("TheGivenAreaHasBeenSweptUsingASystemComprisedOfMultipleEchoSounderTransducersAttachedToBoomsDeployedFromTheSurveyVessel")]
		[EnumMember(Value = "Swept by Vertical Acoustic System")] 
		[XmlEnum("8")] 
		SweptByVerticalAcousticSystem = 8,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatComparesElectromagneticSignals")]
		[EnumMember(Value = "Found by Electromagnetic Sensor")] 
		[XmlEnum("9")] 
		FoundByElectromagneticSensor = 9,

		[System.ComponentModel.Description("TheScienceOrArtOfObtainingReliableMeasurementsFromPhotographs")]
		[EnumMember(Value = "Photogrammetry")] 
		[XmlEnum("10")] 
		Photogrammetry = 10,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingInstrumentsPlacedAboardAnArtificialSatellite")]
		[EnumMember(Value = "Satellite Imagery")] 
		[XmlEnum("11")] 
		SatelliteImagery = 11,

		[System.ComponentModel.Description("one2FoundByLevelingMissingDefinition")]
		[EnumMember(Value = "found by leveling")] 
		[XmlEnum("12")] 
		FoundByLeveling = 12,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingASideScanSonar")]
		[EnumMember(Value = "Swept by Side Scan Sonar")] 
		[XmlEnum("13")] 
		SweptBySideScanSonar = 13,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatMeasuresDistanceByEmittingTimedPulsesOfLaserLightAndMeasuringTheTimeBetweenEmissionAndReceptionOfTheReflectedPulses")]
		[EnumMember(Value = "Found by LIDAR")] 
		[XmlEnum("15")] 
		FoundByLidar = 15,

		[System.ComponentModel.Description("ARadarWithASyntheticApertureAntennaWhichIsComposedOfALargeNumberOfElementaryTransducingElementsTheSignalsAreElectronicallyCombinedIntoAResultingSignalEquivalentToThatOfASingleAntennaOfAGivenApertureInAGivenDirection")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		[XmlEnum("16")] 
		SyntheticApertureRadar = 16,

		[System.ComponentModel.Description("TermUsedToDescribeTheImageryDerivedFromSubdividingTheElectromagneticSpectrumIntoVeryNarrowBandwidthsTheseNarrowBandwidthsMayBeCombinedWithOrSubtractedFromEachOtherInVariousWaysToFormImagesUsefulInPreciseTerrainOrTargetAnalysis")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		[XmlEnum("17")] 
		HyperspectralImagery = 17,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingALineOrObjectBelowTheSurfaceAtTheDesiredDepthOrLeastDepthSAndPositionSWithinAnAreaWasIdentifiedUsingTheSameTechnique")]
		[EnumMember(Value = "Mechanically Swept")] 
		[XmlEnum("18")] 
		MechanicallySwept = 18,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheSurfaceOfTheSeaAtATideStationForAllStagesOfTheTideOverA19YearPeriodUsuallyDeterminedFromHourlyHeightReadingsMeasuredFromAFixedPredeterminedReferenceLevel")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("3")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("13")] 
		LowWater = 13,

		[System.ComponentModel.Description("TheAverageHeightOfAllHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean High Water")] 
		[XmlEnum("16")] 
		MeanHighWater = 16,

		[System.ComponentModel.Description("TheAverageHeightOfTheHighWatersOfSpringTides")]
		[EnumMember(Value = "Mean High Water Springs")] 
		[XmlEnum("17")] 
		MeanHighWaterSprings = 17,

		[System.ComponentModel.Description("TheHighestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "High Water")] 
		[XmlEnum("18")] 
		HighWater = 18,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanSeaLevelMsl")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("19")] 
		ApproximateMeanSeaLevel = 19,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanHighWaterSpringsMhws")]
		[EnumMember(Value = "High Water Springs")] 
		[XmlEnum("20")] 
		HighWaterSprings = 20,

		[System.ComponentModel.Description("TheAverageHeightOfHigherHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Higher High Water")] 
		[XmlEnum("21")] 
		MeanHigherHighWater = 21,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("24")] 
		LocalDatum = 24,

		[System.ComponentModel.Description("two5InternationalGreatMissingDefinition")]
		[EnumMember(Value = "international great")] 
		[XmlEnum("25")] 
		InternationalGreat = 25,

		[System.ComponentModel.Description("TheAverageOfAllHourlyWaterLevelsOverTheAvailablePeriodOfRecord")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("26")] 
		MeanWaterLevel = 26,

		[System.ComponentModel.Description("TheAverageOfTheHighestHighWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		[XmlEnum("28")] 
		HigherHighWaterLargeTide = 28,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheHighestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheHighWaterSprings")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		[XmlEnum("29")] 
		NearlyHighestHighWater = 29,

		[System.ComponentModel.Description("TheHighestTidalLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		[XmlEnum("30")] 
		HighestAstronomicalTide = 30,

		[System.ComponentModel.Description("fourfourBalticSeaChartDatumMissingDefinition")]
		[EnumMember(Value = "Baltic Sea Chart Datum")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum = 44,

		[System.ComponentModel.Description("five01MeanTideLevelMissingDefinition")]
		[EnumMember(Value = "Mean Tide Level")] 
		[XmlEnum("501")] 
		MeanTideLevel = 501,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum exhibitionConditionOfLight : int {
		[System.ComponentModel.Description("ALightShownThroughoutThe24HoursWithoutChangeOfCharacter")]
		[EnumMember(Value = "Light Shown Without Change of Character")] 
		[XmlEnum("1")] 
		LightShownWithoutChangeOfCharacter = 1,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedByDay")]
		[EnumMember(Value = "Daytime Light")] 
		[XmlEnum("2")] 
		DaytimeLight = 2,

		[System.ComponentModel.Description("ALightWhichIsExhibitedInFogOrConditionsOfReducedVisibility")]
		[EnumMember(Value = "Fog Light")] 
		[XmlEnum("3")] 
		FogLight = 3,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedAtNight")]
		[EnumMember(Value = "Night Light")] 
		[XmlEnum("4")] 
		NightLight = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLight : int {
		[System.ComponentModel.Description("ALightAssociatedWithOtherLightsSoAsToFormALeadingLineToBeFollowed")]
		[EnumMember(Value = "Leading Light")] 
		[XmlEnum("4")] 
		LeadingLight = 4,

		[System.ComponentModel.Description("AnAeroLightIsEstablishedForAeronauticalNavigationAndMayBeOfHigherPowerThanMarineLightsAndVisibleFromWellOffshore")]
		[EnumMember(Value = "Aero Light")] 
		[XmlEnum("5")] 
		AeroLight = 5,

		[System.ComponentModel.Description("ABroadBeamLightUsedToIlluminateAStructureOrArea")]
		[EnumMember(Value = "Flood Light")] 
		[XmlEnum("8")] 
		FloodLight = 8,

		[System.ComponentModel.Description("ALightWhoseSourceHasALinearFormGenerallyHorizontalWhichCanReachALengthOfSeveralMetres")]
		[EnumMember(Value = "Strip Light")] 
		[XmlEnum("9")] 
		StripLight = 9,

		[System.ComponentModel.Description("ALightPlacedOnOrNearTheSupportOfAMainLightAndHavingASpecialUseInNavigation")]
		[EnumMember(Value = "Subsidiary Light")] 
		[XmlEnum("10")] 
		SubsidiaryLight = 10,

		[System.ComponentModel.Description("APowerfulLightFocusedSoAsToIlluminateASmallArea")]
		[EnumMember(Value = "Spotlight")] 
		[XmlEnum("11")] 
		Spotlight = 11,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Front")] 
		[XmlEnum("12")] 
		Front = 12,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Rear")] 
		[XmlEnum("13")] 
		Rear = 13,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Lower")] 
		[XmlEnum("14")] 
		Lower = 14,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Upper")] 
		[XmlEnum("15")] 
		Upper = 15,

		[System.ComponentModel.Description("ALightAvailableAsABackupToAMainLightWhichWillBeIlluminatedShouldTheMainLightFail")]
		[EnumMember(Value = "Emergency")] 
		[XmlEnum("17")] 
		Emergency = 17,

		[System.ComponentModel.Description("ALightWhichEnablesItsApproximateBearingToBeObtainedWithoutTheUseOfACompass")]
		[EnumMember(Value = "Bearing Light")] 
		[XmlEnum("18")] 
		BearingLight = 18,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedHorizontally")]
		[EnumMember(Value = "Horizontally Disposed")] 
		[XmlEnum("19")] 
		HorizontallyDisposed = 19,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedVertically")]
		[EnumMember(Value = "Vertically Disposed")] 
		[XmlEnum("20")] 
		VerticallyDisposed = 20,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum trafficFlow : int {
		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionTowardAPortOrSimilarDestination")]
		[EnumMember(Value = "Inbound")] 
		[XmlEnum("1")] 
		Inbound = 1,

		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionAwayFromAPortOrSimilarPointOfOrigin")]
		[EnumMember(Value = "Outbound")] 
		[XmlEnum("2")] 
		Outbound = 2,

		[System.ComponentModel.Description("threeOneWayMissingDefinition")]
		[EnumMember(Value = "one-way")] 
		[XmlEnum("3")] 
		OneWay = 3,

		[System.ComponentModel.Description("fourTwoWayMissingDefinition")]
		[EnumMember(Value = "two-way")] 
		[XmlEnum("4")] 
		TwoWay = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[System.ComponentModel.Description("TheAchromaticObjectColourOfGreatestLightnessCharacteristicallyPerceivedToBelongToObjectsThatReflectDiffuselyNearlyAllIncidentEnergyThroughoutTheVisibleSpectrum")]
		[EnumMember(Value = "White")] 
		[XmlEnum("1")] 
		White = 1,

		[System.ComponentModel.Description("TheAchromaticColorOfLeastLightnessCharacteristicallyPerceivedToBelongToObjectsThatNeitherReflectNorTransmitLight")]
		[EnumMember(Value = "Black")] 
		[XmlEnum("2")] 
		Black = 2,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfBloodOrOfTheRubyOrIsThatOfTheLongWaveExtremeOfTheVisibleSpectrum")]
		[EnumMember(Value = "Red")] 
		[XmlEnum("3")] 
		Red = 3,

		[System.ComponentModel.Description("OfTheColorGreen")]
		[EnumMember(Value = "Green")] 
		[XmlEnum("4")] 
		Green = 4,

		[System.ComponentModel.Description("AColorWhoseHueIsThatOfTheClearSkyOrThatOfThePortionOfTheColorSpectrumLyingBetweenGreenAndViolet")]
		[EnumMember(Value = "Blue")] 
		[XmlEnum("5")] 
		Blue = 5,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfRipeLemonsOrSunflowersOrIsThatOfThePortionOfTheSpectrumLyingBetweenGreenAndOrange")]
		[EnumMember(Value = "Yellow")] 
		[XmlEnum("6")] 
		Yellow = 6,

		[System.ComponentModel.Description("OfTheColorGrey")]
		[EnumMember(Value = "Grey")] 
		[XmlEnum("7")] 
		Grey = 7,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBetweenRedAndYellowInHueOfMediumToLowLightnessAndOfModerateToLowSaturation")]
		[EnumMember(Value = "Brown")] 
		[XmlEnum("8")] 
		Brown = 8,

		[System.ComponentModel.Description("AVariableColorAveragingADarkOrangeYellow")]
		[EnumMember(Value = "Amber")] 
		[XmlEnum("9")] 
		Amber = 9,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsOfReddishBlueHueLowLightnessAndMediumSaturation")]
		[EnumMember(Value = "Violet")] 
		[XmlEnum("10")] 
		Violet = 10,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsThatAreBetweenRedAndYellowInHue")]
		[EnumMember(Value = "Orange")] 
		[XmlEnum("11")] 
		Orange = 11,

		[System.ComponentModel.Description("ADeepPurplishRed")]
		[EnumMember(Value = "Magenta")] 
		[XmlEnum("12")] 
		Magenta = 12,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBluishRedToRedInHueOfMediumToHighLightnessAndOfLowToModerateSaturation")]
		[EnumMember(Value = "Pink")] 
		[XmlEnum("13")] 
		Pink = 13,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofBoundaryLine : int {
		[System.ComponentModel.Description("ALineOfDemarcationBetweenControlledAreas")]
		[EnumMember(Value = "Administrative Boundary")] 
		[XmlEnum("501")] 
		AdministrativeBoundary = 501,

		[System.ComponentModel.Description("five06DeFactoBoundaryMissingDefinition")]
		[EnumMember(Value = "de facto boundary")] 
		[XmlEnum("506")] 
		DeFactoBoundary = 506,

		[System.ComponentModel.Description("five11InternationalMaritimeBoundaryMissingDefinition")]
		[EnumMember(Value = "International Maritime Boundary")] 
		[XmlEnum("511")] 
		InternationalMaritimeBoundary = 511,

		[System.ComponentModel.Description("ALineEveryPointOfWhichIsEquidistantFromTheNearestPointsOnTheBaselinesOfTwoOrMoreStatesBetweenWhichItLies")]
		[EnumMember(Value = "Median Line")] 
		[XmlEnum("599")] 
		MedianLine = 599,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum soundingDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheLowWatersOfSpringTidesThisLevelIsUsedAsATidalDatumInSomeAreas")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		[XmlEnum("501")] 
		MeanLowWaterSprings = 501,

		[System.ComponentModel.Description("TheAverageHeightOfLowerLowWaterSpringsAtAPlace")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		[XmlEnum("502")] 
		MeanLowerLowWaterSprings = 502,

		[System.ComponentModel.Description("TheAverageHeightOfTheSurfaceOfTheSeaAtATideStationForAllStagesOfTheTideOverA19YearPeriodUsuallyDeterminedFromHourlyHeightReadingsMeasuredFromAFixedPredeterminedReferenceLevel")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("503")] 
		MeanSeaLevel = 503,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestTideObservedAtAPlaceOrSomewhatLower")]
		[EnumMember(Value = "Lowest Low Water")] 
		[XmlEnum("504")] 
		LowestLowWater = 504,

		[System.ComponentModel.Description("TheAverageHeightOfAllLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Low Water")] 
		[XmlEnum("505")] 
		MeanLowWater = 505,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestWaterLevelObservedAtAPlaceAtSpringTidesDuringAPeriodOfTimeShorterThan19Years")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		[XmlEnum("506")] 
		LowestLowWaterSprings = 506,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		[XmlEnum("507")] 
		ApproximateMeanLowWaterSprings = 507,

		[System.ComponentModel.Description("AnArbitraryTidalDatumApproximatingTheLevelOfTheMeanOfTheLowerLowWaterAtSpringTidesItWasFirstUsedInWatersSurroundingIndia")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		[XmlEnum("508")] 
		IndianSpringLowWater = 508,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Low Water Springs")] 
		[XmlEnum("509")] 
		LowWaterSprings = 509,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfLowestAstronomicalTideLat")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		[XmlEnum("510")] 
		ApproximateLowestAstronomicalTide = 510,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheLowestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheIndianSpringLowWaterIslw")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		[XmlEnum("511")] 
		NearlyLowestLowWater = 511,

		[System.ComponentModel.Description("TheAverageHeightOfTheLowerLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		[XmlEnum("512")] 
		MeanLowerLowWater = 512,

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("513")] 
		LowWater = 513,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterMlw")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		[XmlEnum("514")] 
		ApproximateMeanLowWater = 514,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowerLowWaterMllw")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		[XmlEnum("515")] 
		ApproximateMeanLowerLowWater = 515,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanSeaLevelMsl")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("519")] 
		ApproximateMeanSeaLevel = 519,

		[System.ComponentModel.Description("TheLevelOfLowWaterSpringsNearTheTimeOfAnEquinox")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		[XmlEnum("522")] 
		EquinoctialSpringLowWater = 522,

		[System.ComponentModel.Description("TheLowestTideLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		[XmlEnum("523")] 
		LowestAstronomicalTide = 523,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("524")] 
		LocalDatum = 524,

		[System.ComponentModel.Description("five2fiveInternationalGreatLakesDatum198fiveIgld198fiveMissingDefinition")]
		[EnumMember(Value = "International Great Lakes Datum 1985 (IGLD 1985)")] 
		[XmlEnum("525")] 
		InternationalGreatLakesDatum1985Igld1985 = 525,

		[System.ComponentModel.Description("TheAverageOfAllHourlyWaterLevelsOverTheAvailablePeriodOfRecord")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("526")] 
		MeanWaterLevel = 526,

		[System.ComponentModel.Description("TheAverageOfTheLowestLowWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		[XmlEnum("527")] 
		LowerLowWaterLargeTide = 527,

		[System.ComponentModel.Description("five31MeanTideLevelMissingDefinition")]
		[EnumMember(Value = "Mean Tide Level")] 
		[XmlEnum("531")] 
		MeanTideLevel = 531,

		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("532")] 
		BalticSeaChartDatum2000 = 532,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSpecialPurposeMark : int {
		[System.ComponentModel.Description("oneFiringDangerAreaMarkMissingDefinition")]
		[EnumMember(Value = "firing danger area mark")] 
		[XmlEnum("1")] 
		FiringDangerAreaMark = 1,

		[System.ComponentModel.Description("AnyObjectTowardWhichSomethingIsDirectedTheDistinctiveMarkingOrInstrumentationOfAGroundPointToAidItsIdentificationOnAPhotograph")]
		[EnumMember(Value = "Target Mark")] 
		[XmlEnum("2")] 
		TargetMark = 2,

		[System.ComponentModel.Description("AMarkMarkingThePositionOfAShipWhichIsUsedAsATargetDuringSomeMilitaryExercise")]
		[EnumMember(Value = "Marker Ship Mark")] 
		[XmlEnum("3")] 
		MarkerShipMark = 3,

		[System.ComponentModel.Description("AMarkUsedToIndicateADegaussingRange")]
		[EnumMember(Value = "Degaussing Range Mark")] 
		[XmlEnum("4")] 
		DegaussingRangeMark = 4,

		[System.ComponentModel.Description("AMarkOfRelevanceToBarges")]
		[EnumMember(Value = "Barge Mark")] 
		[XmlEnum("5")] 
		BargeMark = 5,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarineCablesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Cable Mark")] 
		[XmlEnum("6")] 
		CableMark = 6,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheLimitOfASpoilGround")]
		[EnumMember(Value = "Spoil Ground Mark")] 
		[XmlEnum("7")] 
		SpoilGroundMark = 7,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfAnOutfallOrThePointAtWhichItLeavesTheLand")]
		[EnumMember(Value = "Outfall Mark")] 
		[XmlEnum("8")] 
		OutfallMark = 8,

		[System.ComponentModel.Description("OceanDataAcquisitionSystem")]
		[EnumMember(Value = "ODAS")] 
		[XmlEnum("9")] 
		Odas = 9,

		[System.ComponentModel.Description("AMarkUsedToRecordDataForScientificPurposes")]
		[EnumMember(Value = "Recording Mark")] 
		[XmlEnum("10")] 
		RecordingMark = 10,

		[System.ComponentModel.Description("AnAreaInWhichSeaplanesAnchorOrMayAnchor")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		[XmlEnum("11")] 
		SeaplaneAnchorage = 11,

		[System.ComponentModel.Description("AMarkUsedToIndicateARecreationZone")]
		[EnumMember(Value = "Recreation Zone Mark")] 
		[XmlEnum("12")] 
		RecreationZoneMark = 12,

		[System.ComponentModel.Description("AMarkIndicatingAMooringOrMoorings")]
		[EnumMember(Value = "Mooring Mark")] 
		[XmlEnum("14")] 
		MooringMark = 14,

		[System.ComponentModel.Description("ALargeBuoyDesignedToTakeThePlaceOfALightshipWhereConstructionOfAnOffshoreLightStationIsNotFeasible")]
		[EnumMember(Value = "LANBY")] 
		[XmlEnum("15")] 
		Lanby = 15,

		[System.ComponentModel.Description("AidsToNavigationOrOtherIndicatorsSoLocatedAsToIndicateThePathToBeFollowedLeadingMarksIdentifyALeadingLineWhenTheyAreInTransit")]
		[EnumMember(Value = "Leading Mark")] 
		[XmlEnum("16")] 
		LeadingMark = 16,

		[System.ComponentModel.Description("ACourseAtSeaWhoseEndsAreIndicatedByRangesAshoreAndWhoseLengthHasBeenAccuratelyMeasuredForDeterminingTheSpeedOfVessels")]
		[EnumMember(Value = "Measured Distance")] 
		[XmlEnum("17")] 
		MeasuredDistance = 17,

		[System.ComponentModel.Description("ANoticeBoardOrSignIndicatingInformationToTheMariner")]
		[EnumMember(Value = "Notice Mark")] 
		[XmlEnum("18")] 
		NoticeMark = 18,

		[System.ComponentModel.Description("one9TssMarkTrafficSeparationSchemeMissingDefinition")]
		[EnumMember(Value = "TSS mark (Traffic Separation Scheme)")] 
		[XmlEnum("19")] 
		TssMarkTrafficSeparationScheme = 19,

		[System.ComponentModel.Description("AnAreaWithinWhichAnchoringIsNotPermitted")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		[XmlEnum("20")] 
		AnchoringProhibited = 20,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsProhibited")]
		[EnumMember(Value = "Berthing Prohibited Mark")] 
		[XmlEnum("21")] 
		BerthingProhibitedMark = 21,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichOvertakingIsGenerallyProhibited")]
		[EnumMember(Value = "Overtaking Prohibited")] 
		[XmlEnum("22")] 
		OvertakingProhibited = 22,

		[System.ComponentModel.Description("two3TwoWayTrafficProhibitedMarkMissingDefinition")]
		[EnumMember(Value = "two-way traffic prohibited mark")] 
		[XmlEnum("23")] 
		TwoWayTrafficProhibitedMark = 23,

		[System.ComponentModel.Description("AMarkIndicatingThatVesselsMustNotGenerateExcessiveWake")]
		[EnumMember(Value = "Reduced Wake Mark")] 
		[XmlEnum("24")] 
		ReducedWakeMark = 24,

		[System.ComponentModel.Description("AMarkIndicatingThatASpeedLimitApplies")]
		[EnumMember(Value = "Speed Limit Mark")] 
		[XmlEnum("25")] 
		SpeedLimitMark = 25,

		[System.ComponentModel.Description("AMarkIndicatingThePlaceWhereTheBowOfAShipMustStopWhenTrafficLightsShowRed")]
		[EnumMember(Value = "Stop Mark")] 
		[XmlEnum("26")] 
		StopMark = 26,

		[System.ComponentModel.Description("AMarkIndicatingThatSpecialCautionMustBeExercisedInTheVicinityOfTheMark")]
		[EnumMember(Value = "General Warning Mark")] 
		[XmlEnum("27")] 
		GeneralWarningMark = 27,

		[System.ComponentModel.Description("two8SoundShipSSirenMarkMissingDefinition")]
		[EnumMember(Value = "sound ship’s siren mark")] 
		[XmlEnum("28")] 
		SoundShipSSirenMark = 28,

		[System.ComponentModel.Description("two9RestrictedVerticalMissingDefinition")]
		[EnumMember(Value = "restricted vertical")] 
		[XmlEnum("29")] 
		RestrictedVertical = 29,

		[System.ComponentModel.Description("three0MaximumVesselSDraughtMarkMissingDefinition")]
		[EnumMember(Value = "maximum vessel’s draught mark")] 
		[XmlEnum("30")] 
		MaximumVesselSDraughtMark = 30,

		[System.ComponentModel.Description("AMarkIndicatingTheMinimumHorizontalSpaceAvailableForPassage")]
		[EnumMember(Value = "Restricted Horizontal Clearance Mark")] 
		[XmlEnum("31")] 
		RestrictedHorizontalClearanceMark = 31,

		[System.ComponentModel.Description("AMarkWarningOfStrongCurrents")]
		[EnumMember(Value = "Strong Current Warning Mark")] 
		[XmlEnum("32")] 
		StrongCurrentWarningMark = 32,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsAllowed")]
		[EnumMember(Value = "Berthing Permitted Mark")] 
		[XmlEnum("33")] 
		BerthingPermittedMark = 33,

		[System.ComponentModel.Description("AMarkIndicatingAnOverheadPowerCable")]
		[EnumMember(Value = "Overhead Power Cable Mark")] 
		[XmlEnum("34")] 
		OverheadPowerCableMark = 34,

		[System.ComponentModel.Description("AMarkIndicatingTheGradientOfTheSlopeOfADredgeChannelEdge")]
		[EnumMember(Value = "Channel Edge Gradient Mark")] 
		[XmlEnum("35")] 
		ChannelEdgeGradientMark = 35,

		[System.ComponentModel.Description("AMarkIndicatingThePresenceOfATelephone")]
		[EnumMember(Value = "Telephone Mark")] 
		[XmlEnum("36")] 
		TelephoneMark = 36,

		[System.ComponentModel.Description("AMarkIndicatingThatAFerryRouteCrossesTheShipRouteOftenUsedWithASoundShipSSirenMark")]
		[EnumMember(Value = "Ferry Crossing Mark")] 
		[XmlEnum("37")] 
		FerryCrossingMark = 37,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarinePipelinesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Pipeline Mark")] 
		[XmlEnum("39")] 
		PipelineMark = 39,

		[System.ComponentModel.Description("AMarkIndicatingAnAnchorageArea")]
		[EnumMember(Value = "Anchorage Mark")] 
		[XmlEnum("40")] 
		AnchorageMark = 40,

		[System.ComponentModel.Description("AMarkUsedToIndicateAClearingLine")]
		[EnumMember(Value = "Clearing Mark")] 
		[XmlEnum("41")] 
		ClearingMark = 41,

		[System.ComponentModel.Description("AMarkIndicatingTheLocationAtWhichARestrictionOrRequirementExists")]
		[EnumMember(Value = "Control Mark")] 
		[XmlEnum("42")] 
		ControlMark = 42,

		[System.ComponentModel.Description("AMarkIndicatingThatDivingMayTakePlaceInTheVicinity")]
		[EnumMember(Value = "Diving Mark")] 
		[XmlEnum("43")] 
		DivingMark = 43,

		[System.ComponentModel.Description("AMarkProvidingOrIndicatingAPlaceOfSafety")]
		[EnumMember(Value = "Refuge Beacon")] 
		[XmlEnum("44")] 
		RefugeBeacon = 44,

		[System.ComponentModel.Description("AMarkIndicatingAFoulGround")]
		[EnumMember(Value = "Foul Ground Mark")] 
		[XmlEnum("45")] 
		FoulGroundMark = 45,

		[System.ComponentModel.Description("AMarkInstalledForUseByYachtsmen")]
		[EnumMember(Value = "Yachting Mark")] 
		[XmlEnum("46")] 
		YachtingMark = 46,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereHelicoptersMayLand")]
		[EnumMember(Value = "Heliport Mark")] 
		[XmlEnum("47")] 
		HeliportMark = 47,

		[System.ComponentModel.Description("AMarkIndicatingALocationAtWhichAGnssPositionHasBeenAccuratelyDetermined")]
		[EnumMember(Value = "GNSS Mark")] 
		[XmlEnum("48")] 
		GnssMark = 48,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereSeaplanesLand")]
		[EnumMember(Value = "Seaplane Landing Mark")] 
		[XmlEnum("49")] 
		SeaplaneLandingMark = 49,

		[System.ComponentModel.Description("AMarkIndicatingThatEntryIsProhibited")]
		[EnumMember(Value = "Entry Prohibited Mark")] 
		[XmlEnum("50")] 
		EntryProhibitedMark = 50,

		[System.ComponentModel.Description("AMarkIndicatingThatWorkGenerallyConstructionIsInProgress")]
		[EnumMember(Value = "Work in Progress Mark")] 
		[XmlEnum("51")] 
		WorkInProgressMark = 51,

		[System.ComponentModel.Description("five2MarkWithUnknownMissingDefinition")]
		[EnumMember(Value = "mark with unknown")] 
		[XmlEnum("52")] 
		MarkWithUnknown = 52,

		[System.ComponentModel.Description("AMarkIndicatingABoreholeThatProducesOrIsCapableOfProducingOilOrNaturalGas")]
		[EnumMember(Value = "Wellhead Mark")] 
		[XmlEnum("53")] 
		WellheadMark = 53,

		[System.ComponentModel.Description("AMarkIndicatingThePointAtWhichAChannelDividesSeparatelyIntoTwoChannels")]
		[EnumMember(Value = "Channel Separation Mark")] 
		[XmlEnum("54")] 
		ChannelSeparationMark = 54,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOfAFishMusselOysterOrPearlFarmCulture")]
		[EnumMember(Value = "Marine Farm Mark")] 
		[XmlEnum("55")] 
		MarineFarmMark = 55,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOrTheExtentOfAnArtificialReef")]
		[EnumMember(Value = "Artificial Reef Mark")] 
		[XmlEnum("56")] 
		ArtificialReefMark = 56,

		[System.ComponentModel.Description("AMarkUsedYearRoundThatMayBeSubmergedWhenIcePassesThroughTheArea")]
		[EnumMember(Value = "Ice Mark")] 
		[XmlEnum("57")] 
		IceMark = 57,

		[System.ComponentModel.Description("AMarkUsedToDefineTheBoundaryOfANatureReserve")]
		[EnumMember(Value = "Nature Reserve Mark")] 
		[XmlEnum("58")] 
		NatureReserveMark = 58,

		[System.ComponentModel.Description("AFishAggregatingOrAggregationDeviceFadIsAManMadeObjectUsedToAttractOceanGoingPelagicFishSuchAsMarlinTunaAndMahiMahiDolphinFishTheyUsuallyConsistOfBuoysOrFloatsTetheredToTheOceanFloorWithConcreteBlocksOrAdrift")]
		[EnumMember(Value = "Fish Aggregating Device")] 
		[XmlEnum("59")] 
		FishAggregatingDevice = 59,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfAWreck")]
		[EnumMember(Value = "Wreck Mark")] 
		[XmlEnum("60")] 
		WreckMark = 60,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACustomsCheckpoint")]
		[EnumMember(Value = "Customs Mark")] 
		[XmlEnum("61")] 
		CustomsMark = 61,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACauseway")]
		[EnumMember(Value = "Causeway Mark")] 
		[XmlEnum("62")] 
		CausewayMark = 62,

		[System.ComponentModel.Description("ASurfaceFollowingBuoyUsedToMeasureWaveActivity")]
		[EnumMember(Value = "Wave Recorder")] 
		[XmlEnum("63")] 
		WaveRecorder = 63,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum depthUnits : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPatrolArea : int {
		[System.ComponentModel.Description("five014wDispositionGridMissingDefinition")]
		[EnumMember(Value = "4W disposition grid")] 
		[XmlEnum("501")] 
		fourwDispositionGrid = 501,

		[System.ComponentModel.Description("five02OperationalNavalPatrolMissingDefinition")]
		[EnumMember(Value = "Operational/Naval Patrol")] 
		[XmlEnum("502")] 
		OperationalNavalPatrol = 502,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum gradient : int {
		[System.ComponentModel.Description("five01SteepMissingDefinition")]
		[EnumMember(Value = "Steep")] 
		[XmlEnum("501")] 
		Steep = 501,

		[System.ComponentModel.Description("five02ModerateMissingDefinition")]
		[EnumMember(Value = "Moderate")] 
		[XmlEnum("502")] 
		Moderate = 502,

		[System.ComponentModel.Description("five03GentleMissingDefinition")]
		[EnumMember(Value = "Gentle")] 
		[XmlEnum("503")] 
		Gentle = 503,

		[System.ComponentModel.Description("five04MildMissingDefinition")]
		[EnumMember(Value = "Mild")] 
		[XmlEnum("504")] 
		Mild = 504,

		[System.ComponentModel.Description("ALevelTractOfLandAsTheBedOfADryLakeOrAnAreaFrequentlyUncoveredAtLowTideUsuallyInPlural")]
		[EnumMember(Value = "Flat")] 
		[XmlEnum("505")] 
		Flat = 505,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalPointOrientation : int {
		[System.ComponentModel.Description("five01NorthSouthMissingDefinition")]
		[EnumMember(Value = "north/south")] 
		[XmlEnum("501")] 
		NorthSouth = 501,

		[System.ComponentModel.Description("five02EastWestMissingDefinition")]
		[EnumMember(Value = "east/west")] 
		[XmlEnum("502")] 
		EastWest = 502,

		[System.ComponentModel.Description("five03NortheastSouthwestMissingDefinition")]
		[EnumMember(Value = "northeast/southwest")] 
		[XmlEnum("503")] 
		NortheastSouthwest = 503,

		[System.ComponentModel.Description("five04NorthwestSoutheastMissingDefinition")]
		[EnumMember(Value = "northwest/southeast")] 
		[XmlEnum("504")] 
		NorthwestSoutheast = 504,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRestrictedArea : int {
		[System.ComponentModel.Description("TheAreaAroundAnOffshoreInstallationWithinWhichVesselsAreProhibitedFromEnteringWithoutPermissionSpecialRegulationsProtectInstallationsWithinASafetyZoneAndVesselsOfAllNationalitiesAreRequiredToRespectTheZone")]
		[EnumMember(Value = "Offshore Safety Zone")] 
		[XmlEnum("1")] 
		OffshoreSafetyZone = 1,

		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveItsFloraFaunaPhysicalFeaturesEtc")]
		[EnumMember(Value = "Nature Reserve")] 
		[XmlEnum("4")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("APlaceWhereBirdsAreBredAndProtected")]
		[EnumMember(Value = "Bird Sanctuary")] 
		[XmlEnum("5")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("APlaceWhereWildAnimalsOrBirdsHuntedForSportOrFoodAreKeptUndisturbedForPrivateUse")]
		[EnumMember(Value = "Game Reserve")] 
		[XmlEnum("6")] 
		GameReserve = 6,

		[System.ComponentModel.Description("APlaceWhereSealsAreProtected")]
		[EnumMember(Value = "Seal Sanctuary")] 
		[XmlEnum("7")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("AnAreaUsuallyAboutTwoCablesDiameterWithinWhichShipsMagneticFieldsMayBeMeasuredSensingInstrumentsAndCablesAreInstalledOnTheSeabedInTheRangeAndThereAreCablesLeadingFromTheRangeToAControlPositionAshore")]
		[EnumMember(Value = "Degaussing Range")] 
		[XmlEnum("8")] 
		DegaussingRange = 8,

		[System.ComponentModel.Description("AnAreaControlledByTheMilitaryInWhichRestrictionsMayApply")]
		[EnumMember(Value = "Military Area")] 
		[XmlEnum("9")] 
		MilitaryArea = 9,

		[System.ComponentModel.Description("AnAreaAroundCertainWrecksOfHistoricalImportanceToProtectTheWrecksFromUnauthorizedInterferenceByDivingSalvageOrDepositionIncludingAnchoring")]
		[EnumMember(Value = "Historic Wreck Area")] 
		[XmlEnum("10")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("AnAreaAroundANavigationalAidWhichVesselsAreProhibitedFromEntering")]
		[EnumMember(Value = "Navigational Aid Safety Zone")] 
		[XmlEnum("12")] 
		NavigationalAidSafetyZone = 12,

		[System.ComponentModel.Description("AnAreaLaidAndMaintainedWithExplosiveMinesForDefenceOrPracticePurposes")]
		[EnumMember(Value = "Minefield")] 
		[XmlEnum("14")] 
		Minefield = 14,

		[System.ComponentModel.Description("AnAreaInWhichPeopleMaySwimAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Swimming Area")] 
		[XmlEnum("18")] 
		SwimmingArea = 18,

		[System.ComponentModel.Description("AnAreaReservedForVesselsWaitingToEnterAHarbour")]
		[EnumMember(Value = "Waiting Area")] 
		[XmlEnum("19")] 
		WaitingArea = 19,

		[System.ComponentModel.Description("AnAreaWhereMarineResearchTakesPlace")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("AnAreaWhereDredgingIsTakingPlace")]
		[EnumMember(Value = "Dredging Area")] 
		[XmlEnum("21")] 
		DredgingArea = 21,

		[System.ComponentModel.Description("APlaceWhereFishIncludingShellfishAndCrustaceansAreProtected")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveTheRelationOfPlantsAndLivingCreaturesToEachOtherAndToTheirSurroundings")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("AnAreaInWhichAVesselsSpeedMustBeReducedInOrderToReduceTheSizeOfTheWakeItProduces")]
		[EnumMember(Value = "No Wake Area")] 
		[XmlEnum("24")] 
		NoWakeArea = 24,

		[System.ComponentModel.Description("AnAreaWhereVesselsTurn")]
		[EnumMember(Value = "Swinging Area")] 
		[XmlEnum("25")] 
		SwingingArea = 25,

		[System.ComponentModel.Description("AGenericTermWhichMayBeUsedToDescribeAWideRangeOfAreasConsideredSensitiveForAVarietyOfEnvironmentalReasons")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area")] 
		[XmlEnum("27")] 
		EnvironmentallySensitiveSeaArea = 27,

		[System.ComponentModel.Description("AnAreaThatNeedsSpecialProtectionThroughActionByImoBecauseOfItsSignificanceForRegionalEcologicalSocioEconomicOrScientificReasonsAndBecauseItMayBeVulnerableToDamageByInternationalShippingActivities")]
		[EnumMember(Value = "Particularly Sensitive Sea Area")] 
		[XmlEnum("28")] 
		ParticularlySensitiveSeaArea = 28,

		[System.ComponentModel.Description("AnAreaNearAFairwayWhereVesselsCanGoToClearTheWayOrMakeAnAboutTurnAndPossiblyReturnToAWaitingAreaWhenNauticalConditionsImposeIt")]
		[EnumMember(Value = "Disengagement Area")] 
		[XmlEnum("29")] 
		DisengagementArea = 29,

		[System.ComponentModel.Description("AnAreaInWhichDefenceLawAndTreatyEnforcementAndCounterTerrorismActivitiesThatFallWithinThePortAndMaritimeDomainApply")]
		[EnumMember(Value = "Port Security Area")] 
		[XmlEnum("30")] 
		PortSecurityArea = 30,

		[System.ComponentModel.Description("APlaceWhereCoralIsProtected")]
		[EnumMember(Value = "Coral Sanctuary")] 
		[XmlEnum("31")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("AnAreaWithinWhichRecreationalActivitiesRegularlyTakePlaceAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Recreation Area")] 
		[XmlEnum("32")] 
		RecreationArea = 32,

		[System.ComponentModel.Description("AnAreaWithinWhichNotificationIsRequiredBetweenRespectiveMilitaryAuthoritiesOfFutureMilitaryExercisesActivities")]
		[EnumMember(Value = "Maritime Notification Area")] 
		[XmlEnum("501")] 
		MaritimeNotificationArea = 501,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum expositionOfSounding : int {
		[System.ComponentModel.Description("TheDepthCorrespondsToTheDepthRangeOfTheSurroundingDepthAreaThatIsTheDepthIsNotShoalerThanTheMinimumDepthOfTheSurroundingDepthAreaOrDeeperThanTheMaximumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Within the Range of Depth of the Surrounding Depth Area")] 
		[XmlEnum("1")] 
		WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,

		[System.ComponentModel.Description("TheDepthIsShoalerThanTheMinimumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Shoaler Than the Range of Depth of the Surrounding Depth Area")] 
		[XmlEnum("2")] 
		ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,

		[System.ComponentModel.Description("TheDepthIsDeeperThanTheMaximumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Deeper Than the Range of Depth of the Surrounding Depth Area")] 
		[XmlEnum("3")] 
		DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum controlledAirspaceClassDesignation : int {
		[System.ComponentModel.Description("five01AMissingDefinition")]
		[EnumMember(Value = "A")] 
		[XmlEnum("501")] 
		A = 501,

		[System.ComponentModel.Description("five02BMissingDefinition")]
		[EnumMember(Value = "B")] 
		[XmlEnum("502")] 
		B = 502,

		[System.ComponentModel.Description("five03CMissingDefinition")]
		[EnumMember(Value = "C")] 
		[XmlEnum("503")] 
		C = 503,

		[System.ComponentModel.Description("five04DMissingDefinition")]
		[EnumMember(Value = "D")] 
		[XmlEnum("504")] 
		D = 504,

		[System.ComponentModel.Description("five0fiveEMissingDefinition")]
		[EnumMember(Value = "E")] 
		[XmlEnum("505")] 
		E = 505,

		[System.ComponentModel.Description("five06FMissingDefinition")]
		[EnumMember(Value = "F")] 
		[XmlEnum("506")] 
		F = 506,

		[System.ComponentModel.Description("five07GMissingDefinition")]
		[EnumMember(Value = "G")] 
		[XmlEnum("507")] 
		G = 507,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum statusOfSmallBottomObject : int {
		[System.ComponentModel.Description("five04IdentifiedNomboMissingDefinition")]
		[EnumMember(Value = "Identified (NOMBO)")] 
		[XmlEnum("504")] 
		IdentifiedNombo = 504,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buoyShape : int {
		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasApproximatelyTheShapeOrTheAppearanceOfAPointedConeWithThePointUpwards")]
		[EnumMember(Value = "Conical")] 
		[XmlEnum("1")] 
		Conical = 1,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheShapeOfACylinderOrATruncatedConeThatApproximatesToACylinderWithAFlatEndUppermost")]
		[EnumMember(Value = "Can")] 
		[XmlEnum("2")] 
		Can = 2,

		[System.ComponentModel.Description("ShapedLikeASphereWhichIsABodyTheSurfaceOfWhichIsAtAllPointsEquidistantFromTheCentre")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("3")] 
		Spherical = 3,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureIsANarrowVerticalStructurePillarOrLatticeTower")]
		[EnumMember(Value = "Pillar")] 
		[XmlEnum("4")] 
		Pillar = 4,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfAPoleOrOfAVeryLongCylinderFloatingUpright")]
		[EnumMember(Value = "Spar")] 
		[XmlEnum("5")] 
		Spar = 5,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfABarrelOrCylinderFloatingHorizontally")]
		[EnumMember(Value = "Barrel")] 
		[XmlEnum("6")] 
		Barrel = 6,

		[System.ComponentModel.Description("AVeryLargeBuoyDesignedToCarryASignalLightOfHighLuminousIntensityAtAHighElevation")]
		[EnumMember(Value = "Superbuoy")] 
		[XmlEnum("7")] 
		Superbuoy = 7,

		[System.ComponentModel.Description("ASpeciallyConstructedShuttleShapedBuoyWhichIsUsedInIceConditions")]
		[EnumMember(Value = "Ice Buoy")] 
		[XmlEnum("8")] 
		IceBuoy = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum heightLengthUnits : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[System.ComponentModel.Description("AUnitOfLengthEqualTo12Inches16OfAFathomOr30480Centimetres")]
		[EnumMember(Value = "Feet")] 
		[XmlEnum("2")] 
		Feet = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("oneCircularNonDirectionalMarineOrAeroMarineRadiobeaconMissingDefinition")]
		[EnumMember(Value = "circular (non-directional) marine or aero-marine radiobeacon")] 
		[XmlEnum("1")] 
		CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationTheEmissionsOfWhichAreIntendedToProvideADefiniteTrackForGuidance")]
		[EnumMember(Value = "Directional Radiobeacon")] 
		[XmlEnum("2")] 
		DirectionalRadiobeacon = 2,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationEmittingABeamOfWavesToWhichAUniformTurningMovementIsGivenTheBearingOfTheStationBeingDeterminedByMeansOfAnOrdinaryListeningReceiverAndAStopWatchAlsoReferredToAsARotatingLoopRadiobeacon")]
		[EnumMember(Value = "Rotating Pattern Radiobeacon")] 
		[XmlEnum("3")] 
		RotatingPatternRadiobeacon = 3,

		[System.ComponentModel.Description("ATypeOfLongRangePositionFixingBeacon")]
		[EnumMember(Value = "Consol Beacon")] 
		[XmlEnum("4")] 
		ConsolBeacon = 4,

		[System.ComponentModel.Description("fiveRadioDirectionFindingStationMissingDefinition")]
		[EnumMember(Value = "radio direction-finding station")] 
		[XmlEnum("5")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("ARadioStationWhichIsPreparedToProvideQtgServiceThatIsToSayToTransmitUponRequestFromAShipARadioSignalTheBearingOfWhichCanBeTakenByThatShip")]
		[EnumMember(Value = "Coast Radio Station Providing QTG Service")] 
		[XmlEnum("6")] 
		CoastRadioStationProvidingQtgService = 6,

		[System.ComponentModel.Description("ARadioBeaconDesignedForAeronauticalUse")]
		[EnumMember(Value = "Aeronautical Radiobeacon")] 
		[XmlEnum("7")] 
		AeronauticalRadiobeacon = 7,

		[System.ComponentModel.Description("TheDeccaNavigatorSystemIsAHighAccuracyShortToMediumRangeRadioNavigationalAidIntendedForCoastalAndLandfallNavigation")]
		[EnumMember(Value = "Decca")] 
		[XmlEnum("8")] 
		Decca = 8,

		[System.ComponentModel.Description("nineLoranCMissingDefinition")]
		[EnumMember(Value = "Loran-C")] 
		[XmlEnum("9")] 
		LoranC = 9,

		[System.ComponentModel.Description("DifferentialGnssIsImplementedByPlacingAGnssMonitorReceiverAtAPreciselyKnownLocationInsteadOfComputingANavigationFixTheMonitorDeterminesTheRangeErrorToEveryGnssSatelliteItCanTrackTheseRangingErrorsAreThenTransmittedToLocalUsersWhereTheyAreAppliedAsCorrectionsBeforeComputingTheNavigationResult")]
		[EnumMember(Value = "Differential GNSS")] 
		[XmlEnum("10")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("AnElectronicPositionFixingSystemUsedMainlyByAircraft")]
		[EnumMember(Value = "Toran")] 
		[XmlEnum("11")] 
		Toran = 11,

		[System.ComponentModel.Description("ALongRangeRadioNavigationalAidWhichOperatesWithinTheVlfFrequencyBandTheSystemComprisesEightLandBasedStations")]
		[EnumMember(Value = "Omega")] 
		[XmlEnum("12")] 
		Omega = 12,

		[System.ComponentModel.Description("ARangingPositionFixingSystemOperatingAt420450MhzOverARangeOfUpTo400Km")]
		[EnumMember(Value = "Syledis")] 
		[XmlEnum("13")] 
		Syledis = 13,

		[System.ComponentModel.Description("ALowFrequencyElectronicPositionFixingSystemUsingPulsedTransmissionsAt100Khz")]
		[EnumMember(Value = "Chaika")] 
		[XmlEnum("14")] 
		Chaika = 14,

		[System.ComponentModel.Description("TheEquipmentNeededAtOneStationToCarryOnTwoWayVoiceCommunicationByRadioWavesOnly")]
		[EnumMember(Value = "Radio Telephone Station")] 
		[XmlEnum("19")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("AnOnshoreAisUnitThatMonitorsTrafficInTheWaterways")]
		[EnumMember(Value = "AIS Base Station")] 
		[XmlEnum("20")] 
		AisBaseStation = 20,

		[System.ComponentModel.Description("five04DistanceMeasuringEquipmentDmeMissingDefinition")]
		[EnumMember(Value = "Distance Measuring Equipment (DME)")] 
		[XmlEnum("504")] 
		DistanceMeasuringEquipmentDme = 504,

		[System.ComponentModel.Description("five0fiveNonDirectionalRadioBeaconNdbMissingDefinition")]
		[EnumMember(Value = "Non-directional Radio Beacon (NDB)")] 
		[XmlEnum("505")] 
		NonDirectionalRadioBeaconNdb = 505,

		[System.ComponentModel.Description("five06RadarResponderBeaconRaconMissingDefinition")]
		[EnumMember(Value = "Radar Responder Beacon (RACON)")] 
		[XmlEnum("506")] 
		RadarResponderBeaconRacon = 506,

		[System.ComponentModel.Description("five08VhfOmniDirectionalRadioRangeVorMissingDefinition")]
		[EnumMember(Value = "VHF Omni Directional Radio Range (VOR)")] 
		[XmlEnum("508")] 
		VhfOmniDirectionalRadioRangeVor = 508,

		[System.ComponentModel.Description("five09VhfOmniDirectionalVortacMissingDefinition")]
		[EnumMember(Value = "VHF Omni Directional (VORTAC)")] 
		[XmlEnum("509")] 
		VhfOmniDirectionalVortac = 509,

		[System.ComponentModel.Description("five10TacticalAirNavigationEquipmentTacanMissingDefinition")]
		[EnumMember(Value = "Tactical Air Navigation Equipment (TACAN)")] 
		[XmlEnum("510")] 
		TacticalAirNavigationEquipmentTacan = 510,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRescueStation : int {
		[System.ComponentModel.Description("APlaceWhereEquipmentForSavingLifeAtSeaIsMaintainedTheTypeOfLifeboatMayVaryFromFastLongDistanceBoatsToInflatableInshoreBoats")]
		[EnumMember(Value = "Rescue Station with Lifeboat")] 
		[XmlEnum("1")] 
		RescueStationWithLifeboat = 1,

		[System.ComponentModel.Description("ALifeSavingStationEquippedWithLineCarryingRocketApparatus")]
		[EnumMember(Value = "Rescue Station with Rocket")] 
		[XmlEnum("2")] 
		RescueStationWithRocket = 2,

		[System.ComponentModel.Description("ShelterOrProtectionFromDangerOrDistressAtSea")]
		[EnumMember(Value = "Refuge for Shipwrecked Mariners")] 
		[XmlEnum("4")] 
		RefugeForShipwreckedMariners = 4,

		[System.ComponentModel.Description("ShelterOrProtectionFromDangerInAreasExposedToExtremeAndSuddenTidesOrTidalStreams")]
		[EnumMember(Value = "Refuge for Intertidal Area Walkers")] 
		[XmlEnum("5")] 
		RefugeForIntertidalAreaWalkers = 5,

		[System.ComponentModel.Description("APlaceWhereALifeboatIsMooredReadyForUse")]
		[EnumMember(Value = "Lifeboat Lying at a Mooring")] 
		[XmlEnum("6")] 
		LifeboatLyingAtAMooring = 6,

		[System.ComponentModel.Description("ARadioStationReservedForEmergencySituationsMightAlsoBeAPublicTelephone")]
		[EnumMember(Value = "Aid Radio Station")] 
		[XmlEnum("7")] 
		AidRadioStation = 7,

		[System.ComponentModel.Description("APlaceWhereFirstAidEquipmentIsAvailable")]
		[EnumMember(Value = "First Aid Equipment")] 
		[XmlEnum("8")] 
		FirstAidEquipment = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum product : int {
		[System.ComponentModel.Description("AThickSlipperyLiquidThatWillNotDissolveInWaterUsuallyPetroleumBasedInTheContextOfStorageTanks")]
		[EnumMember(Value = "Oil")] 
		[XmlEnum("1")] 
		Oil = 1,

		[System.ComponentModel.Description("ASubstanceWithParticlesThatCanMoveFreelyUsuallyAFuelSubstanceInTheContextOfStorageTanks")]
		[EnumMember(Value = "Gas")] 
		[XmlEnum("2")] 
		Gas = 2,

		[System.ComponentModel.Description("AColourlessOdourlessTastelessLiquidThatIsACompoundOfHydrogenAndOxygen")]
		[EnumMember(Value = "Water")] 
		[XmlEnum("3")] 
		Water = 3,

		[System.ComponentModel.Description("AGeneralTermForRockAndRockFragmentsRangingInSizeFromPebblesAndGravelToBouldersOrLargeRockMasses")]
		[EnumMember(Value = "Stone")] 
		[XmlEnum("4")] 
		Stone = 4,

		[System.ComponentModel.Description("AHardBlackMineralThatIsBurnedAsFuel")]
		[EnumMember(Value = "Coal")] 
		[XmlEnum("5")] 
		Coal = 5,

		[System.ComponentModel.Description("ASolidRockOrMineralFromWhichMetalIsObtained")]
		[EnumMember(Value = "Ore")] 
		[XmlEnum("6")] 
		Ore = 6,

		[System.ComponentModel.Description("AnySubstanceObtainedByOrUsedInAChemicalProcess")]
		[EnumMember(Value = "Chemicals")] 
		[XmlEnum("7")] 
		Chemicals = 7,

		[System.ComponentModel.Description("WaterThatIsSuitableForHumanConsumption")]
		[EnumMember(Value = "Drinking Water")] 
		[XmlEnum("8")] 
		DrinkingWater = 8,

		[System.ComponentModel.Description("AWhiteFluidSecretedByFemaleMammalsAsFoodForTheirYoung")]
		[EnumMember(Value = "Milk")] 
		[XmlEnum("9")] 
		Milk = 9,

		[System.ComponentModel.Description("AMineralFromWhichAluminumIsObtained")]
		[EnumMember(Value = "Bauxite")] 
		[XmlEnum("10")] 
		Bauxite = 10,

		[System.ComponentModel.Description("ASolidSubstanceObtainedAfterGasAndTarHaveBeenExtractedFromCoalUsedAsAFuel")]
		[EnumMember(Value = "Coke")] 
		[XmlEnum("11")] 
		Coke = 11,

		[System.ComponentModel.Description("AnOblongLumpOfCastIronMetal")]
		[EnumMember(Value = "Iron Ingots")] 
		[XmlEnum("12")] 
		IronIngots = 12,

		[System.ComponentModel.Description("SodiumChlorideObtainedFromMinesOrByTheEvaporationOfSeaWater")]
		[EnumMember(Value = "Salt")] 
		[XmlEnum("13")] 
		Salt = 13,

		[System.ComponentModel.Description("LooseMaterialConsistingOfSmallButEasilyDistinguishableSeparateGrainsBetween00625And2000MillimetresInDiameter")]
		[EnumMember(Value = "Sand")] 
		[XmlEnum("14")] 
		Sand = 14,

		[System.ComponentModel.Description("WoodPreparedForUseInBuildingOrCarpentry")]
		[EnumMember(Value = "Timber")] 
		[XmlEnum("15")] 
		Timber = 15,

		[System.ComponentModel.Description("one6SawdustWoodChipsMissingDefinition")]
		[EnumMember(Value = "sawdust/wood chips")] 
		[XmlEnum("16")] 
		SawdustWoodChips = 16,

		[System.ComponentModel.Description("DiscardedMetalSuitableForBeingReprocessed")]
		[EnumMember(Value = "Scrap Metal")] 
		[XmlEnum("17")] 
		ScrapMetal = 17,

		[System.ComponentModel.Description("one8LiquefiedNaturalGasLngMissingDefinition")]
		[EnumMember(Value = "liquefied natural gas (LNG)")] 
		[XmlEnum("18")] 
		LiquefiedNaturalGasLng = 18,

		[System.ComponentModel.Description("ACompressedGasConsistingOfFlammableLightHydrocarbonsAndDerivedFromPetroleum")]
		[EnumMember(Value = "Liquefied Petroleum Gas")] 
		[XmlEnum("19")] 
		LiquefiedPetroleumGas = 19,

		[System.ComponentModel.Description("TheFermentedJuiceOfGrapes")]
		[EnumMember(Value = "Wine")] 
		[XmlEnum("20")] 
		Wine = 20,

		[System.ComponentModel.Description("ASubstanceMadeOfPowderedLimeAndClayMixedWithWater")]
		[EnumMember(Value = "Cement")] 
		[XmlEnum("21")] 
		Cement = 21,

		[System.ComponentModel.Description("ASmallHardSeedEspeciallyThatOfAnyCerealPlantSuchAsWheatRiceCornRyeEtc")]
		[EnumMember(Value = "Grain")] 
		[XmlEnum("22")] 
		Grain = 22,

		[System.ComponentModel.Description("ElectricChargeOrCurrent")]
		[EnumMember(Value = "Electricity")] 
		[XmlEnum("23")] 
		Electricity = 23,

		[System.ComponentModel.Description("TheSolidFormOfWater")]
		[EnumMember(Value = "Ice")] 
		[XmlEnum("24")] 
		Ice = 24,

		[System.ComponentModel.Description("ParticlesOfLessThan0002mmStiffStickyEarthThatBecomesHardWhenBaked")]
		[EnumMember(Value = "Clay")] 
		[XmlEnum("25")] 
		Clay = 25,

		[System.ComponentModel.Description("SolidFuelMaterialWhereinTheParticlesFirmlyCohereIsHardAndCompactAndIsBurntAsASourceOfHeatOrPower")]
		[EnumMember(Value = "Solid Fuel")] 
		[XmlEnum("502")] 
		SolidFuel = 502,

		[System.ComponentModel.Description("FlammableLiquidsAndGasesASubstanceWhichIsEitherInAStateWhereMoleculesMoveFreelyAboutOneAnotherButDoNotFlyApartOrInAConditionInWhichItHasNoDefiniteBoundariesOrFixedVolumeButWhichIsCombustibleUnderNormalAtmosphericConditions")]
		[EnumMember(Value = "Flammable Liquids And Gases")] 
		[XmlEnum("503")] 
		FlammableLiquidsAndGases = 503,

		[System.ComponentModel.Description("FerrousElementsAndOresUnrefinedAndRefinedAChemicallyInseparableSubstanceOrSolidNaturallyOccurringMineralAggregateFromWhichOneOrMoreValuableConstituentsMayBeRecoveredByTreatmentOrAManufacturingProcessAndWhichDoesContainIronInItsTrivalentForm")]
		[EnumMember(Value = "Ferrous Elements And Ores")] 
		[XmlEnum("505")] 
		FerrousElementsAndOres = 505,

		[System.ComponentModel.Description("NonFerrousElementsAndOresUnrefinedAndRefinedAChemicallyInseparableSubstanceOrSolidNaturallyOccurringMineralAggregateFromWhichOneOrMoreValuableConstituentsMayBeRecoveredByTreatmentOrAManufacturingProcessAndWhichDoesNotContainIronInItsTrivalentForm")]
		[EnumMember(Value = "Non Ferrous Elements And Ores")] 
		[XmlEnum("506")] 
		NonFerrousElementsAndOres = 506,

		[System.ComponentModel.Description("ConstructedFromMetal")]
		[EnumMember(Value = "Metal")] 
		[XmlEnum("507")] 
		Metal = 507,

		[System.ComponentModel.Description("SubstancesProducedByAProcessOfInOrganicNatureASubstanceNeitherAnimalOrVegetableNormallyObtainedByMining")]
		[EnumMember(Value = "Minerals")] 
		[XmlEnum("508")] 
		Minerals = 508,

		[System.ComponentModel.Description("NaturalAndChemicalASubstanceAddedToTheSoilToIncreaseItsProductivityItMayBeProducedByOrPertainingToNatureNotTheWorkOfManOrWhichMayBeFormedFromASubstanceOrResultingFromAReactionInvolvingChangesToAtomsOrMolecules")]
		[EnumMember(Value = "Fertiliser")] 
		[XmlEnum("509")] 
		Fertiliser = 509,

		[System.ComponentModel.Description("UnprocessedAndProductsTheSubstanceOfTreesInUnprocessedFormTheWoodHasNotUndergoneChangeByAMethodOfManufactureIntoProductsBeingTheManufactureOfGoodsOrCommoditiesFromWood")]
		[EnumMember(Value = "Wood")] 
		[XmlEnum("510")] 
		Wood = 510,

		[System.ComponentModel.Description("UnprocessedAndProductsStrongWaterproofElasticMaterialOriginallyMadeFromTheDriedSapOfATropicalTreeNowUsuallySyntheticInUnprocessedFormTheRubberHasNotUndergoneChangeByAMethodOfManufactureIntoProductsBeingTheManufactureOfGoodsOrCommoditiesFromRubber")]
		[EnumMember(Value = "Rubber")] 
		[XmlEnum("511")] 
		Rubber = 511,

		[System.ComponentModel.Description("five13NaturalFibresAndMaterialsInGeneralMissingDefinition")]
		[EnumMember(Value = "natural fibres and materials in general")] 
		[XmlEnum("513")] 
		NaturalFibresAndMaterialsInGeneral = 513,

		[System.ComponentModel.Description("five14FoodstuffsSolidMissingDefinition")]
		[EnumMember(Value = "foodstuffs, solid")] 
		[XmlEnum("514")] 
		FoodstuffsSolid = 514,

		[System.ComponentModel.Description("five1fiveFoodstuffsLiquidMissingDefinition")]
		[EnumMember(Value = "foodstuffs, liquid")] 
		[XmlEnum("515")] 
		FoodstuffsLiquid = 515,

		[System.ComponentModel.Description("five16FoodstuffsPreservedMissingDefinition")]
		[EnumMember(Value = "foodstuffs, preserved")] 
		[XmlEnum("516")] 
		FoodstuffsPreserved = 516,

		[System.ComponentModel.Description("ItemsRelatingToTheWholeOrMostNotSpecialisedOfBroadOverallCharacterMixedCharacterisedByScopeOrVarietyItemsCombinedOrAssociated")]
		[EnumMember(Value = "General And Mixed Goods")] 
		[XmlEnum("517")] 
		GeneralAndMixedGoods = 517,

		[System.ComponentModel.Description("PhysicalMatterConsistingOfARelativelySmallAndHardButUsuallySeparateParticlesOrInAFormWhichIsDustyOrEasilyCrumbledIntoTinyLooseParticles")]
		[EnumMember(Value = "Granular Or Powdery Material")] 
		[XmlEnum("519")] 
		GranularOrPowderyMaterial = 519,

		[System.ComponentModel.Description("MachineryApparatusUsuallyPoweredByElectricityDesignedToPerformASpecificTaskMechanicalPartsComponentsOfVehiclesOrMachines")]
		[EnumMember(Value = "Machinery And Mechanical Parts")] 
		[XmlEnum("520")] 
		MachineryAndMechanicalParts = 520,

		[System.ComponentModel.Description("ThatOutOfWhichAnythingIsOrMayBeMadeEquipmentOrImplementsPartsThatMayBePutTogether")]
		[EnumMember(Value = "Construction Materials")] 
		[XmlEnum("521")] 
		ConstructionMaterials = 521,

		[System.ComponentModel.Description("AMeansOfConveyanceOrTransportEspeciallyAStructureWithWheelsInOrOnWhichPeopleOrThingsAreTransportedByLand")]
		[EnumMember(Value = "Vehicles")] 
		[XmlEnum("522")] 
		Vehicles = 522,

		[System.ComponentModel.Description("StructureOrMachineForTravellingInTheAir")]
		[EnumMember(Value = "Aircraft")] 
		[XmlEnum("523")] 
		Aircraft = 523,

		[System.ComponentModel.Description("ARailOrSetOfParallelRailsOnWhichATrainTramOrRailWagonRuns")]
		[EnumMember(Value = "Railway")] 
		[XmlEnum("524")] 
		Railway = 524,

		[System.ComponentModel.Description("MovableStructuresForGivingShelterNormallyPrefabricated")]
		[EnumMember(Value = "Portable Buildings")] 
		[XmlEnum("525")] 
		PortableBuildings = 525,

		[System.ComponentModel.Description("BoxesForCargoTransportWithStandardizedDimensions")]
		[EnumMember(Value = "Containers")] 
		[XmlEnum("526")] 
		Containers = 526,

		[System.ComponentModel.Description("DevicesBasedOnTheTechnologyOfTheConductionOfElectricityInAVacuumGasOrASemiconductor")]
		[EnumMember(Value = "Electronics")] 
		[XmlEnum("527")] 
		Electronics = 527,

		[System.ComponentModel.Description("ConstructedFromPlastic")]
		[EnumMember(Value = "Plastic")] 
		[XmlEnum("528")] 
		Plastic = 528,

		[System.ComponentModel.Description("ColouringMatterEspeciallyInLiquidFormForImpartingColourToASurface")]
		[EnumMember(Value = "Paint")] 
		[XmlEnum("529")] 
		Paint = 529,

		[System.ComponentModel.Description("five30RefuseAlsoKnownAsRubbishGarbageTrashAndWasteMissingDefinition")]
		[EnumMember(Value = "refuse (also known as rubbish/garbage/trash) and waste")] 
		[XmlEnum("530")] 
		RefuseAlsoKnownAsRubbishGarbageTrashAndWaste = 530,

		[System.ComponentModel.Description("RelatingToCausedByOrExhibitingRadioactivityEmissionOfRadianElementsCapableOfSpontaneouslyEmittingAlphaBetaOrSometimesGammaRaysByTheDisintegrationOfTheNucleiOfAtoms")]
		[EnumMember(Value = "Radioactive Material")] 
		[XmlEnum("531")] 
		RadioactiveMaterial = 531,

		[System.ComponentModel.Description("MilitaryWeaponsATotalMeansOfMakingWarDefensiveEquipment")]
		[EnumMember(Value = "Armament")] 
		[XmlEnum("532")] 
		Armament = 532,

		[System.ComponentModel.Description("PeopleInGeneral")]
		[EnumMember(Value = "Personnel")] 
		[XmlEnum("533")] 
		Personnel = 533,

		[System.ComponentModel.Description("five34AnimalsLandAndSeaAndBirdsMissingDefinition")]
		[EnumMember(Value = "animals (land and sea) and birds")] 
		[XmlEnum("534")] 
		AnimalsLandAndSeaAndBirds = 534,

		[System.ComponentModel.Description("VertebrateColdBloodedAnimalWithGillsLivingInWater")]
		[EnumMember(Value = "Fish")] 
		[XmlEnum("535")] 
		Fish = 535,

		[System.ComponentModel.Description("ShelledAquaticInvertebrates")]
		[EnumMember(Value = "Shellfish And Crustaceans")] 
		[XmlEnum("536")] 
		ShellfishAndCrustaceans = 536,

		[System.ComponentModel.Description("MaterialCarriedByAShipToEnsureItsStability")]
		[EnumMember(Value = "Ballast")] 
		[XmlEnum("537")] 
		Ballast = 537,

		[System.ComponentModel.Description("DieselOilAvailable")]
		[EnumMember(Value = "Diesel Oil")] 
		[XmlEnum("540")] 
		DieselOil = 540,

		[System.ComponentModel.Description("five41PetrolGasolineMissingDefinition")]
		[EnumMember(Value = "petrol/gasoline")] 
		[XmlEnum("541")] 
		PetrolGasoline = 541,

		[System.ComponentModel.Description("PersonsTravellingInAMeansOfTransportOperatedByOthers")]
		[EnumMember(Value = "Passengers")] 
		[XmlEnum("542")] 
		Passengers = 542,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFerry : int {
		[System.ComponentModel.Description("AFerryWhichMayHaveRoutesThatVaryWithWeatherTideAndTraffic")]
		[EnumMember(Value = "Free Moving Ferry")] 
		[XmlEnum("1")] 
		FreeMovingFerry = 1,

		[System.ComponentModel.Description("AFerryThatFollowsAFixedRouteGuidedByACable")]
		[EnumMember(Value = "Cable Ferry")] 
		[XmlEnum("2")] 
		CableFerry = 2,

		[System.ComponentModel.Description("AWinterTimeFerryWhichCrossesALead")]
		[EnumMember(Value = "Ice Ferry")] 
		[XmlEnum("3")] 
		IceFerry = 3,

		[System.ComponentModel.Description("AHighSpeedWaterVesselForCivilianUse")]
		[EnumMember(Value = "High Speed Ferry")] 
		[XmlEnum("5")] 
		HighSpeedFerry = 5,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfObstruction : int {
		[System.ComponentModel.Description("oneSnagStumpMissingDefinition")]
		[EnumMember(Value = "snag/stump")] 
		[XmlEnum("1")] 
		SnagStump = 1,

		[System.ComponentModel.Description("ASubmarineStructureProjectingSomeDistanceAboveTheSeabedAndCappingATemporarilyAbandonedOrSuspendedOilOrGasWell")]
		[EnumMember(Value = "Wellhead")] 
		[XmlEnum("2")] 
		Wellhead = 2,

		[System.ComponentModel.Description("AStructureOnAnOutfallThroughWhichLiquidsAreDischargedTheStructureWillUsuallyProjectAboveTheLevelOfTheOutfallAndCanBeAnObstructionToNavigation")]
		[EnumMember(Value = "Diffuser")] 
		[XmlEnum("3")] 
		Diffuser = 3,

		[System.ComponentModel.Description("APermanentMarineStructureUsuallyDesignedToSupportOrElevatePipelinesEspeciallyAStructureEnclosingAScreeningDeviceAtTheOffshoreEndOfAPotableWaterIntakePipeTheStructureIsCommonlyAHeavyTimberEnclosureThatHasBeenSunkenWithRocksOrOtherDebris")]
		[EnumMember(Value = "Crib")] 
		[XmlEnum("4")] 
		Crib = 4,

		[System.ComponentModel.Description("AreasEstablishedByPrivateInterestsUsuallySportFishermenToSimulateNaturalReefsAndWrecksThatAttractFishTheReefsAreConstructedByDumpingAssortedJunkInAreasWhichMayBeOfVerySmallExtentOrMayStretchAConsiderableDistanceAlongADepthContour")]
		[EnumMember(Value = "Fish Haven")] 
		[XmlEnum("5")] 
		FishHaven = 5,

		[System.ComponentModel.Description("AnAreaOfNumerousUnidentifiedDangersToNavigationTheAreaServesAsAWarningToTheMarinerThatAllDangersAreNotIdentifiedIndividuallyAndThatNavigationThroughTheAreaMayBeHazardous")]
		[EnumMember(Value = "Foul Area")] 
		[XmlEnum("6")] 
		FoulArea = 6,

		[System.ComponentModel.Description("FloatingBarriersAnchoredToTheBottomUsedToDeflectThePathOfFloatingIceInOrderToPreventTheObstructionOfLocksIntakesEtcAndToPreventDamageToBridgePiersAndOtherStructures")]
		[EnumMember(Value = "Ice Boom")] 
		[XmlEnum("8")] 
		IceBoom = 8,

		[System.ComponentModel.Description("EquipmentSuchAsAnchorsConcreteBlocksChainsAndCablesEtcUsedToPositionFloatingStructuresSuchAsTrotAndMooringBuoysEtc")]
		[EnumMember(Value = "Ground Tackle")] 
		[XmlEnum("9")] 
		GroundTackle = 9,

		[System.ComponentModel.Description("AFloatingBarrierUsedToProtectARiverOrHarbourMouthOrToCreateAShelteredAreaForStoragePurposes")]
		[EnumMember(Value = "Boom")] 
		[XmlEnum("10")] 
		Boom = 10,

		[System.ComponentModel.Description("ADeviceToExtractEnergyFromTheSurfaceMotionOfOceanWavesOrFromPressureFluctuationsBelowTheSurface")]
		[EnumMember(Value = "Wave Energy Device")] 
		[XmlEnum("12")] 
		WaveEnergyDevice = 12,

		[System.ComponentModel.Description("one3SubsurfaceOceanDataAcquisitionSystemOdasMissingDefinition")]
		[EnumMember(Value = "subsurface ocean data acquisition system (ODAS)")] 
		[XmlEnum("13")] 
		SubsurfaceOceanDataAcquisitionSystemOdas = 13,

		[System.ComponentModel.Description("AManMadeStructureThatMayMimicSomeOfTheCharacteristicsOfANaturalReefIntendedToAttractSeaLife")]
		[EnumMember(Value = "Artificial Reef")] 
		[XmlEnum("14")] 
		ArtificialReef = 14,

		[System.ComponentModel.Description("AStructurePlacedOnTheSeafloorBelowADrillingRigToGuideTheDrill")]
		[EnumMember(Value = "Template")] 
		[XmlEnum("15")] 
		Template = 15,

		[System.ComponentModel.Description("ALargeSteelStructureUpTo20MetresInHeightAboveTheSeafloorOrASteelFrameSecuredToTheSeafloorWithPilesToAnchorTheEndOfASubmarinePipelineForDeliveryToAProductionPlatform")]
		[EnumMember(Value = "Manifold")] 
		[XmlEnum("16")] 
		Manifold = 16,

		[System.ComponentModel.Description("AHillOfSoilCoveredIcePushedUpByHydrostaticPressureInAnAreaOfPermafrostThatIsLocatedUnderwater")]
		[EnumMember(Value = "Submerged Pingo")] 
		[XmlEnum("17")] 
		SubmergedPingo = 17,

		[System.ComponentModel.Description("TheDistributedRemainsOfAPlatform")]
		[EnumMember(Value = "Remains of Platform")] 
		[XmlEnum("18")] 
		RemainsOfPlatform = 18,

		[System.ComponentModel.Description("AnInstrumentUsedForScientificPurposes")]
		[EnumMember(Value = "Scientific Instrument")] 
		[XmlEnum("19")] 
		ScientificInstrument = 19,

		[System.ComponentModel.Description("AnyOfVariousMachinesHavingARotorUsuallyWithVanesOrBladesDrivenByThePressureMomentumOrReactiveThrustOfAMovingFluidAsSteamWaterHotGasesOrAirEitherOccurringInTheFormOfFreeJetsOrAsAFluidPassingThroughAndEntirelyFillingAHousingAroundTheRotorAndIsLocatedUnderwater")]
		[EnumMember(Value = "Underwater Turbine")] 
		[XmlEnum("20")] 
		UnderwaterTurbine = 20,

		[System.ComponentModel.Description("AnActiveSeabedVolcanoWhichMayBeSubmergedOrProjectingAboveTheWaterAtTheChartSoundingDatum")]
		[EnumMember(Value = "Active Submarine Volcano")] 
		[XmlEnum("21")] 
		ActiveSubmarineVolcano = 21,

		[System.ComponentModel.Description("ASubmergedNetPlacedAroundBeachesToReduceSharkAttacksOnSwimmers")]
		[EnumMember(Value = "Shark Net")] 
		[XmlEnum("22")] 
		SharkNet = 22,

		[System.ComponentModel.Description("OneOfSeveralGeneraOfTropicalTreesOrShrubsWhichProduceManyPropRootsAndGrowAlongLowLyingCoastsIntoShallowWater")]
		[EnumMember(Value = "Mangrove")] 
		[XmlEnum("23")] 
		Mangrove = 23,

		[System.ComponentModel.Description("AStructureTypicallyADomeOrCubeErectedOverAWellheadOrEquipmentAttachedToItATreeToLessenTheDangerOfVesselsSnaggingGearAml")]
		[EnumMember(Value = "Well Protection Structure")] 
		[XmlEnum("501")] 
		WellProtectionStructure = 501,

		[System.ComponentModel.Description("AnyOilOrGasRelatedInstallationOrStructureOnOrProjectingFromTheSeabedForExampleASubmergedPlatformOrConcreteFoundationsAml")]
		[EnumMember(Value = "Subsea Installation")] 
		[XmlEnum("502")] 
		SubseaInstallation = 502,

		[System.ComponentModel.Description("AnyPipelineRelatedStructureWhichProjectsAboveTheSeabedForExampleAJointTPieceValveOrSleeveOrACrossingWhereOnePipelineIsRaisedOverAnotherByMeansOfASupportingStructureAml")]
		[EnumMember(Value = "Pipeline Obstruction")] 
		[XmlEnum("503")] 
		PipelineObstruction = 503,

		[System.ComponentModel.Description("five04FreeStandingConductorPipeMissingDefinition")]
		[EnumMember(Value = "free standing conductor pipe")] 
		[XmlEnum("504")] 
		FreeStandingConductorPipe = 504,

		[System.ComponentModel.Description("LargeSeabedStructuresTypicallyMadeOfConcreteCapableOfStoringOilOrGasAndUsuallyFoundAttachedOrAdjacentToARigOrMarkedByASinglePointMooringBuoyAml")]
		[EnumMember(Value = "Storage Tank")] 
		[XmlEnum("506")] 
		StorageTank = 506,

		[System.ComponentModel.Description("AFloatingStructureUsuallyRectangularInShapeWhichServesAsLandingPierHeadBridgeSupportEtc")]
		[EnumMember(Value = "Pontoon")] 
		[XmlEnum("508")] 
		Pontoon = 508,

		[System.ComponentModel.Description("MiscellaneousItemsAndObjectsMostOfWhichHaveBeenLostOverboardOrOtherwiseAbandonedToTheSeaForExampleCargoContainersOrVehiclesAml")]
		[EnumMember(Value = "Sundry Objects")] 
		[XmlEnum("509")] 
		SundryObjects = 509,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum restriction : int {
		[System.ComponentModel.Description("AnAreaWithinWhichAnchoringIsNotPermitted")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		[XmlEnum("1")] 
		AnchoringProhibited = 1,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichAnchoringIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Anchoring Restricted")] 
		[XmlEnum("2")] 
		AnchoringRestricted = 2,

		[System.ComponentModel.Description("AnAreaWithinWhichFishingIsNotPermitted")]
		[EnumMember(Value = "Fishing Prohibited")] 
		[XmlEnum("3")] 
		FishingProhibited = 3,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichFishingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Fishing Restricted")] 
		[XmlEnum("4")] 
		FishingRestricted = 4,

		[System.ComponentModel.Description("AnAreaWithinWhichTrawlingIsNotPermitted")]
		[EnumMember(Value = "Trawling Prohibited")] 
		[XmlEnum("5")] 
		TrawlingProhibited = 5,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichTrawlingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Trawling Restricted")] 
		[XmlEnum("6")] 
		TrawlingRestricted = 6,

		[System.ComponentModel.Description("AnAreaWithinWhichNavigationAndOrAnchoringIsProhibited")]
		[EnumMember(Value = "Entry Prohibited")] 
		[XmlEnum("7")] 
		EntryProhibited = 7,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichNavigationIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Entry Restricted")] 
		[XmlEnum("8")] 
		EntryRestricted = 8,

		[System.ComponentModel.Description("AnAreaWithinWhichDredgingIsNotPermitted")]
		[EnumMember(Value = "Dredging Prohibited")] 
		[XmlEnum("9")] 
		DredgingProhibited = 9,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDredgingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Dredging Restricted")] 
		[XmlEnum("10")] 
		DredgingRestricted = 10,

		[System.ComponentModel.Description("AnAreaWithinWhichDivingIsNotPermitted")]
		[EnumMember(Value = "Diving Prohibited")] 
		[XmlEnum("11")] 
		DivingProhibited = 11,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDivingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Diving Restricted")] 
		[XmlEnum("12")] 
		DivingRestricted = 12,

		[System.ComponentModel.Description("MarinersMustAdjustTheSpeedOfTheirVesselsToReduceTheWaveOrWashWhichMayCauseErosionOrDisturbMooredVessels")]
		[EnumMember(Value = "No Wake")] 
		[XmlEnum("13")] 
		NoWake = 13,

		[System.ComponentModel.Description("AnImoDeclaredRouteingMeasureComprisingAnAreaWithinDefinedLimitsInWhichEitherNavigationIsParticularlyHazardousOrItIsExceptionallyImportantToAvoidCasualtiesAndWhichShouldBeAvoidedByAllShipsOrCertainClassesOfShips")]
		[EnumMember(Value = "Area To Be Avoided")] 
		[XmlEnum("14")] 
		AreaToBeAvoided = 14,

		[System.ComponentModel.Description("TheErectionOfPermanentOrTemporaryFixedStructuresOrArtificialIslandsIsProhibited")]
		[EnumMember(Value = "Construction Prohibited")] 
		[XmlEnum("15")] 
		ConstructionProhibited = 15,

		[System.ComponentModel.Description("AnAreaWithinWhichDischargingOrDumpingIsProhibited")]
		[EnumMember(Value = "Discharging Prohibited")] 
		[XmlEnum("16")] 
		DischargingProhibited = 16,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichDischargingOrDumpingIsRestrictedInAccordanceWithSpecifiedConditions")]
		[EnumMember(Value = "Discharging Restricted")] 
		[XmlEnum("17")] 
		DischargingRestricted = 17,

		[System.ComponentModel.Description("one8IndustrialOrMineralMissingDefinition")]
		[EnumMember(Value = "industrial or mineral 18")] 
		[XmlEnum("18")] 
		IndustrialOrMineral18 = 18,

		[System.ComponentModel.Description("one9IndustrialOrMineralMissingDefinition")]
		[EnumMember(Value = "industrial or mineral 19")] 
		[XmlEnum("19")] 
		IndustrialOrMineral19 = 19,

		[System.ComponentModel.Description("AnAreaWithinWhichExcavatingAHoleOnTheSeabedWithADrillIsProhibited")]
		[EnumMember(Value = "Drilling Prohibited")] 
		[XmlEnum("20")] 
		DrillingProhibited = 20,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichExcavatingAHoleOnTheSeabedWithADrillIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Drilling Restricted")] 
		[XmlEnum("21")] 
		DrillingRestricted = 21,

		[System.ComponentModel.Description("twotwoRemovalOfHistoricMissingDefinition")]
		[EnumMember(Value = "removal of historic")] 
		[XmlEnum("22")] 
		RemovalOfHistoric = 22,

		[System.ComponentModel.Description("two3CargoTranshipmentLighteningProhibitedMissingDefinition")]
		[EnumMember(Value = "cargo transhipment (lightening) prohibited")] 
		[XmlEnum("23")] 
		CargoTranshipmentLighteningProhibited = 23,

		[System.ComponentModel.Description("AnAreaInWhichTheDraggingOfAnythingAlongTheSeabedForExampleBottomTrawlingIsProhibited")]
		[EnumMember(Value = "Dragging Prohibited")] 
		[XmlEnum("24")] 
		DraggingProhibited = 24,

		[System.ComponentModel.Description("AnAreaInWhichAVesselIsProhibitedFromStopping")]
		[EnumMember(Value = "Stopping Prohibited")] 
		[XmlEnum("25")] 
		StoppingProhibited = 25,

		[System.ComponentModel.Description("AnAreaInWhichLandingIsProhibited")]
		[EnumMember(Value = "Landing Prohibited")] 
		[XmlEnum("26")] 
		LandingProhibited = 26,

		[System.ComponentModel.Description("AnAreaWithinWhichSpeedIsRestricted")]
		[EnumMember(Value = "Speed Restricted")] 
		[XmlEnum("27")] 
		SpeedRestricted = 27,

		[System.ComponentModel.Description("AnAreaInWhichSwimmingIsProhibited")]
		[EnumMember(Value = "Swimming Prohibited")] 
		[XmlEnum("39")] 
		SwimmingProhibited = 39,

		[System.ComponentModel.Description("four2PowerDrivenVesselsMissingDefinition")]
		[EnumMember(Value = "power-driven vessels")] 
		[XmlEnum("42")] 
		PowerDrivenVessels = 42,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofMilitaryPracticeArea : int {
		[System.ComponentModel.Description("AnAreaWithinWhichExercisesAreCarriedOutWithTorpedoes")]
		[EnumMember(Value = "Torpedo Exercise Area")] 
		[XmlEnum("2")] 
		TorpedoExerciseArea = 2,

		[System.ComponentModel.Description("AnAreaWithinWhichSubmarineExercisesAreCarriedOut")]
		[EnumMember(Value = "Submarine Exercise Area")] 
		[XmlEnum("3")] 
		SubmarineExerciseArea = 3,

		[System.ComponentModel.Description("AreasForBombingAndMissileExercises")]
		[EnumMember(Value = "Firing Danger Area")] 
		[XmlEnum("4")] 
		FiringDangerArea = 4,

		[System.ComponentModel.Description("fiveMineLayingPracticeAreaMissingDefinition")]
		[EnumMember(Value = "mine-laying practice area")] 
		[XmlEnum("5")] 
		MineLayingPracticeArea = 5,

		[System.ComponentModel.Description("TheAclantAlliedCommandAtlanticSubmarineGridProvidesNatoSubmarineOperatingAuthoritiesWithACommonGridForTheWaterSpaceManagementOfNatoSubmarines")]
		[EnumMember(Value = "ACLANT grid")] 
		[XmlEnum("501")] 
		AclantGrid = 501,

		[System.ComponentModel.Description("AnAreaInWhichCertainActivitiesOrFactorsOfSignificanceToSurfaceNavigationOrOperationsApply")]
		[EnumMember(Value = "Surface Danger Area")] 
		[XmlEnum("502")] 
		SurfaceDangerArea = 502,

		[System.ComponentModel.Description("five03JmcAreasJenoaGridMissingDefinition")]
		[EnumMember(Value = "JMC Areas - JENOA grid")] 
		[XmlEnum("503")] 
		JmcAreasJenoaGrid = 503,

		[System.ComponentModel.Description("five06SafeBottomingAreaMissingDefinition")]
		[EnumMember(Value = "safe bottoming area")] 
		[XmlEnum("506")] 
		SafeBottomingArea = 506,

		[System.ComponentModel.Description("AnAreaInWhichSubmarineOperationsAreProhibitedOrLimitedOwingToTheExistenceOfHazardsToDivedSubmarines")]
		[EnumMember(Value = "Submarine Danger Area")] 
		[XmlEnum("507")] 
		SubmarineDangerArea = 507,

		[System.ComponentModel.Description("ASpecifiedZoneForTheProvisionOfSonarCalibrationOrOtherUnderwaterTesting")]
		[EnumMember(Value = "Testing and Evaluation Range")] 
		[XmlEnum("508")] 
		TestingAndEvaluationRange = 508,

		[System.ComponentModel.Description("five10ImpactAreaMissingDefinition")]
		[EnumMember(Value = "Impact area")] 
		[XmlEnum("510")] 
		ImpactArea = 510,

		[System.ComponentModel.Description("AnAreaUsedForLiveFiringOfWeaponsToBombardADesignatedArea")]
		[EnumMember(Value = "Live Fire Range")] 
		[XmlEnum("599")] 
		LiveFireRange = 599,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sonarSignalStrength : int {
		[System.ComponentModel.Description("five01NilMissingDefinition")]
		[EnumMember(Value = "nil")] 
		[XmlEnum("501")] 
		Nil = 501,

		[System.ComponentModel.Description("NotAsGoodAsItCouldBeOrShould")]
		[EnumMember(Value = "Poor")] 
		[XmlEnum("502")] 
		Poor = 502,

		[System.ComponentModel.Description("five03ModerateMissingDefinition")]
		[EnumMember(Value = "moderate")] 
		[XmlEnum("503")] 
		Moderate = 503,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("504")] 
		Strong = 504,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("TheMaximumLengthOfTheShip")]
		[EnumMember(Value = "Length Overall")] 
		[XmlEnum("1")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("TheShipSLengthMeasuredAtTheWaterline")]
		[EnumMember(Value = "Length at Waterline")] 
		[XmlEnum("2")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("TheWidthOrBeamOfTheVessel")]
		[EnumMember(Value = "Breadth")] 
		[XmlEnum("3")] 
		Breadth = 3,

		[System.ComponentModel.Description("TheDepthOfWaterNecessaryToFloatAVesselFullyLoaded")]
		[EnumMember(Value = "Draught")] 
		[XmlEnum("4")] 
		Draught = 4,

		[System.ComponentModel.Description("AMeasurementOfTheWeightOfTheVesselUsuallyUsedForWarshipsMerchantShipsAreUsuallyMeasuredBasedOnTheVolumeOfCargoSpaceSeeTonnageDisplacementIsExpressedEitherInLongTonsOf2240PoundsOrMetricTonnesOf1000KgSinceTheTwoUnitsAreVeryCloseInSize2240Pounds1016KgAnd1000Kg2205PoundsItIsCommonNotToDistinguishBetweenThemToPreserveSecrecyNationsSometimesMisstateAWarshipSDisplacement")]
		[EnumMember(Value = "Displacement Tonnage")] 
		[XmlEnum("6")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("TheEntireInternalCubicCapacityOfTheShipExpressedInTonsOf100CubicFeetToTheTonExceptCertainSpacesWithAreExemptedSuchAsPeakAndOtherTanksForWaterBallastOpenForecastleBridgeAndPoopAccessOfHatchwaysCertainLightAndAirSpacesDomesOfSkylightsCondenserAnchorGearSteeringGearWheelHouseGalleyAndCabinForPassengers")]
		[EnumMember(Value = "Gross Tonnage")] 
		[XmlEnum("10")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("ObtainedFromTheGrossTonnageByDeductingCrewAndNavigatingSpacesAndAllowancesForPropulsionMachinery")]
		[EnumMember(Value = "Net Tonnage")] 
		[XmlEnum("11")] 
		NetTonnage = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lastSensor : int {
		[System.ComponentModel.Description("five01AcousticSensorMissingDefinition")]
		[EnumMember(Value = "acoustic sensor")] 
		[XmlEnum("501")] 
		AcousticSensor = 501,

		[System.ComponentModel.Description("TheObjectWasReportedAsAResultOfDetectingAFluctuationInTheLocalMagneticField")]
		[EnumMember(Value = "Magnetic Sensor")] 
		[XmlEnum("502")] 
		MagneticSensor = 502,

		[System.ComponentModel.Description("five03VideoSensorMissingDefinition")]
		[EnumMember(Value = "video sensor")] 
		[XmlEnum("503")] 
		VideoSensor = 503,

		[System.ComponentModel.Description("five04DiverSightingFoundByDiverInRegistryMissingDefinition")]
		[EnumMember(Value = "diver sighting (found by diver - in registry)")] 
		[XmlEnum("504")] 
		DiverSightingFoundByDiverInRegistry = 504,

		[System.ComponentModel.Description("five06PhysicalSnagMissingDefinition")]
		[EnumMember(Value = "physical snag")] 
		[XmlEnum("506")] 
		PhysicalSnag = 506,

		[System.ComponentModel.Description("five07ObservedSinkingMissingDefinition")]
		[EnumMember(Value = "observed sinking")] 
		[XmlEnum("507")] 
		ObservedSinking = 507,

		[System.ComponentModel.Description("five08ReportedSinkingMissingDefinition")]
		[EnumMember(Value = "Reported Sinking")] 
		[XmlEnum("508")] 
		ReportedSinking = 508,

		[System.ComponentModel.Description("five09NoneReportedMissingDefinition")]
		[EnumMember(Value = "None reported")] 
		[XmlEnum("509")] 
		NoneReported = 509,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCoverage : int {
		[System.ComponentModel.Description("ContinuousCoverageOfSpatialObjectsIsAvailableWithinThisArea")]
		[EnumMember(Value = "Coverage Available")] 
		[XmlEnum("1")] 
		CoverageAvailable = 1,

		[System.ComponentModel.Description("AnAreaContainingNoSpatialObjects")]
		[EnumMember(Value = "No Coverage Available")] 
		[XmlEnum("2")] 
		NoCoverageAvailable = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum beaconShape : int {
		[System.ComponentModel.Description("oneStakePolePerchPostMissingDefinition")]
		[EnumMember(Value = "stake, pole, perch, post")] 
		[XmlEnum("1")] 
		StakePolePerchPost = 1,

		[System.ComponentModel.Description("ATreeWithoutRootsStuckOrSpoiledIntoTheBottomOfTheSeaToServeAsANavigationalAid")]
		[EnumMember(Value = "Withy")] 
		[XmlEnum("2")] 
		Withy = 2,

		[System.ComponentModel.Description("ASolidStructureOfTheOrderOf10MetresInHeightUsedAsANavigationalAid")]
		[EnumMember(Value = "Beacon Tower")] 
		[XmlEnum("3")] 
		BeaconTower = 3,

		[System.ComponentModel.Description("AStructureConsistingOfStripsOfMetalOrWoodCrossedOrInterlacedToFormAStructureToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Lattice Beacon")] 
		[XmlEnum("4")] 
		LatticeBeacon = 4,

		[System.ComponentModel.Description("ALongHeavyTimberSOrSectionSOfSteelWoodConcreteEtcForcedIntoTheSeabedToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Pile Beacon")] 
		[XmlEnum("5")] 
		PileBeacon = 5,

		[System.ComponentModel.Description("AMoundOfStonesUsuallyConicalOrPyramidalRaisedAsALandmarkOrToDesignateAPointOfImportanceInSurveying")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("6")] 
		Cairn = 6,

		[System.ComponentModel.Description("ATallSparLikeBeaconFittedWithAPermanentlySubmergedBuoyancyChamberTheLowerEndOfTheBodyIsSecuredToSeabedSinkerEitherByAFlexibleJointOrByACableUnderTension")]
		[EnumMember(Value = "Buoyant Beacon")] 
		[XmlEnum("7")] 
		BuoyantBeacon = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDumpingGround : int {
		[System.ComponentModel.Description("AnAreaAtSeaWhereChemicalWasteIsDumped")]
		[EnumMember(Value = "Chemical Waste Dumping Ground")] 
		[XmlEnum("2")] 
		ChemicalWasteDumpingGround = 2,

		[System.ComponentModel.Description("AnAreaAtSeaWhereNuclearWasteIsDumped")]
		[EnumMember(Value = "Nuclear Waste Dumping Ground")] 
		[XmlEnum("3")] 
		NuclearWasteDumpingGround = 3,

		[System.ComponentModel.Description("AnAreaAtSeaWhereExplosivesAreDumped")]
		[EnumMember(Value = "Explosives Dumping Ground")] 
		[XmlEnum("4")] 
		ExplosivesDumpingGround = 4,

		[System.ComponentModel.Description("ASeaAreaWhereDredgedMaterialIsDeposited")]
		[EnumMember(Value = "Spoil Ground")] 
		[XmlEnum("5")] 
		SpoilGround = 5,

		[System.ComponentModel.Description("AnAreaAtSeaWhereDisusedVesselsAreScuttled")]
		[EnumMember(Value = "Vessel Dumping Ground")] 
		[XmlEnum("6")] 
		VesselDumpingGround = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAnchorage : int {
		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchor")]
		[EnumMember(Value = "Unrestricted Anchorage")] 
		[XmlEnum("1")] 
		UnrestrictedAnchorage = 1,

		[System.ComponentModel.Description("AnAreaInWhichVesselsOfDeepDraughtAnchorOrMayAnchor")]
		[EnumMember(Value = "Deep Water Anchorage")] 
		[XmlEnum("2")] 
		DeepWaterAnchorage = 2,

		[System.ComponentModel.Description("AnAreaInWhichTankersAnchorOrMayAnchor")]
		[EnumMember(Value = "Tanker Anchorage")] 
		[XmlEnum("3")] 
		TankerAnchorage = 3,

		[System.ComponentModel.Description("AnAreaWhereAVesselAnchorsWhenSatisfyingQuarantineRegulations")]
		[EnumMember(Value = "Quarantine Anchorage")] 
		[XmlEnum("5")] 
		QuarantineAnchorage = 5,

		[System.ComponentModel.Description("AnAreaInWhichSeaplanesAnchorOrMayAnchor")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		[XmlEnum("6")] 
		SeaplaneAnchorage = 6,

		[System.ComponentModel.Description("AnAreaInWhichYachtsAndSmallBoatsAnchorOrMayAnchor")]
		[EnumMember(Value = "Small Craft Anchorage")] 
		[XmlEnum("7")] 
		SmallCraftAnchorage = 7,

		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchorForPeriodsOfUpTo24Hours")]
		[EnumMember(Value = "Anchorage for Periods Up To 24 Hours")] 
		[XmlEnum("9")] 
		AnchorageForPeriodsUpTo24Hours = 9,

		[System.ComponentModel.Description("AnAreaInWhichVesselsMayAnchorForAPeriodOfTimeNotToExceedASpecificLimit")]
		[EnumMember(Value = "Anchorage for a Limited Period of Time")] 
		[XmlEnum("10")] 
		AnchorageForALimitedPeriodOfTime = 10,

		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchorWhileWaitingForExampleForAccessToAPortOrBerth")]
		[EnumMember(Value = "Waiting Anchorage")] 
		[XmlEnum("14")] 
		WaitingAnchorage = 14,

		[System.ComponentModel.Description("ALocationNotDefinedByARegulatoryAuthorityThatHasBeenReportedToBeSuitableAndSafeForAnchoring")]
		[EnumMember(Value = "Reported Anchorage")] 
		[XmlEnum("15")] 
		ReportedAnchorage = 15,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum catagoryOfAirspaceRestriction : int {
		[System.ComponentModel.Description("AnAreaDesignatedByAProperAuthorityInWhichADangerToCraftExistsAlsoCalledDangerZone")]
		[EnumMember(Value = "Danger Area")] 
		[XmlEnum("501")] 
		DangerArea = 501,

		[System.ComponentModel.Description("oneAnAreaShownOnChartsWithinWhichNavigationAndOrAnchoringIsProhibited2InAviationTerminologyASpecifiedAreaWithinTheLandAreasOfAStateOrTerritorialWatersAdjacentTheretoOverWhichTheFlightOfAircraftIsProhibited")]
		[EnumMember(Value = "Prohibited Area")] 
		[XmlEnum("502")] 
		ProhibitedArea = 502,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichNavigationIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Restricted Area")] 
		[XmlEnum("503")] 
		RestrictedArea = 503,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colourPattern : int {
		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedHorizontally")]
		[EnumMember(Value = "Horizontal Stripes")] 
		[XmlEnum("1")] 
		HorizontalStripes = 1,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedVertically")]
		[EnumMember(Value = "Vertical Stripes")] 
		[XmlEnum("2")] 
		VerticalStripes = 2,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedDiagonallyThatIsNotHorizontallyOrVertically")]
		[EnumMember(Value = "Diagonal Stripes")] 
		[XmlEnum("3")] 
		DiagonalStripes = 3,

		[System.ComponentModel.Description("OftenReferredToAsCheckerPlateWhereAlternateColoursAreUsedToCreateSquaresSimilarToAChessOrDraughtBoardThePatternMayBeStraightOrDiagonal")]
		[EnumMember(Value = "Squared")] 
		[XmlEnum("4")] 
		Squared = 4,

		[System.ComponentModel.Description("fiveStripesDirectionUnknownMissingDefinition")]
		[EnumMember(Value = "stripes (direction unknown)")] 
		[XmlEnum("5")] 
		StripesDirectionUnknown = 5,

		[System.ComponentModel.Description("ABandOrStripeOfColourWhichIsDisplayedAroundTheOuterEdgeOfTheFeatureWhichMayAlsoFormABorderToAnInnerPatternOrPlainColour")]
		[EnumMember(Value = "Border Stripe")] 
		[XmlEnum("6")] 
		BorderStripe = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarStation : int {
		[System.ComponentModel.Description("ARadarStationEstablishedForTrafficSurveillance")]
		[EnumMember(Value = "Radar Surveillance Station")] 
		[XmlEnum("1")] 
		RadarSurveillanceStation = 1,

		[System.ComponentModel.Description("AShoreBasedStationWhichTheMarinerCanContactByRadioToObtainAPosition")]
		[EnumMember(Value = "Coast Radar Station")] 
		[XmlEnum("2")] 
		CoastRadarStation = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfControlledAirspace : int {
		[System.ComponentModel.Description("AControlAreaOrPortionThereofEstablishedInTheFormOfACorridorEquippedWithRadioNavigationAids")]
		[EnumMember(Value = "Airway")] 
		[XmlEnum("501")] 
		Airway = 501,

		[System.ComponentModel.Description("five02AltimeterSettingRegionAsrMissingDefinition")]
		[EnumMember(Value = "Altimeter Setting Region (ASR)")] 
		[XmlEnum("502")] 
		AltimeterSettingRegionAsr = 502,

		[System.ComponentModel.Description("five03AvoidanceAreaAaMissingDefinition")]
		[EnumMember(Value = "Avoidance Area (AA)")] 
		[XmlEnum("503")] 
		AvoidanceAreaAa = 503,

		[System.ComponentModel.Description("five04ControlAreaCtaMissingDefinition")]
		[EnumMember(Value = "Control Area (CTA)")] 
		[XmlEnum("504")] 
		ControlAreaCta = 504,

		[System.ComponentModel.Description("five0fiveControlZoneCtrCtzMissingDefinition")]
		[EnumMember(Value = "Control Zone (CTR/CTZ)")] 
		[XmlEnum("505")] 
		ControlZoneCtrCtz = 505,

		[System.ComponentModel.Description("five06FlightInformationRegionFirMissingDefinition")]
		[EnumMember(Value = "Flight Information Region (FIR)")] 
		[XmlEnum("506")] 
		FlightInformationRegionFir = 506,

		[System.ComponentModel.Description("five07TerminalControlAreaTmaTcaMissingDefinition")]
		[EnumMember(Value = "Terminal Control Area (TMA/TCA)")] 
		[XmlEnum("507")] 
		TerminalControlAreaTmaTca = 507,

		[System.ComponentModel.Description("five08AerodromeTrafficZoneAtzMissingDefinition")]
		[EnumMember(Value = "Aerodrome Traffic Zone (ATZ)")] 
		[XmlEnum("508")] 
		AerodromeTrafficZoneAtz = 508,

		[System.ComponentModel.Description("five09HelicopterProtectionZoneHpzMissingDefinition")]
		[EnumMember(Value = "Helicopter Protection Zone (HPZ)")] 
		[XmlEnum("509")] 
		HelicopterProtectionZoneHpz = 509,

		[System.ComponentModel.Description("five10HelicopterMainRouteHmrMissingDefinition")]
		[EnumMember(Value = "Helicopter Main Route (HMR)")] 
		[XmlEnum("510")] 
		HelicopterMainRouteHmr = 510,

		[System.ComponentModel.Description("five11HelicopterTransitCorridorHtcMissingDefinition")]
		[EnumMember(Value = "Helicopter Transit Corridor (HTC)")] 
		[XmlEnum("511")] 
		HelicopterTransitCorridorHtc = 511,

		[System.ComponentModel.Description("five12MilitaryAerodromeTrafficZoneMatzMissingDefinition")]
		[EnumMember(Value = "Military Aerodrome Traffic Zone (MATZ)")] 
		[XmlEnum("512")] 
		MilitaryAerodromeTrafficZoneMatz = 512,

		[System.ComponentModel.Description("five13OceanControlAreaOcaMissingDefinition")]
		[EnumMember(Value = "Ocean Control Area (OCA)")] 
		[XmlEnum("513")] 
		OceanControlAreaOca = 513,

		[System.ComponentModel.Description("five14CoastguardTrackSurveillanceMissingDefinition")]
		[EnumMember(Value = "Coastguard track [surveillance]")] 
		[XmlEnum("514")] 
		CoastguardTrackSurveillance = 514,

		[System.ComponentModel.Description("five1fiveMilitaryTerminalControlAreaMtcaMissingDefinition")]
		[EnumMember(Value = "Military Terminal Control Area (MTCA)")] 
		[XmlEnum("515")] 
		MilitaryTerminalControlAreaMtca = 515,

		[System.ComponentModel.Description("five16IdentificationZoneAdizMissingDefinition")]
		[EnumMember(Value = "Identification Zone (ADIZ)")] 
		[XmlEnum("516")] 
		IdentificationZoneAdiz = 516,

		[System.ComponentModel.Description("five17AdvisoryAreaAdaOrUdaMissingDefinition")]
		[EnumMember(Value = "Advisory Area (ADA) or (UDA)")] 
		[XmlEnum("517")] 
		AdvisoryAreaAdaOrUda = 517,

		[System.ComponentModel.Description("five18AirRouteTradfficControlCenterArtccMissingDefinition")]
		[EnumMember(Value = "Air Route Tradffic Control Center (ARTCC)")] 
		[XmlEnum("518")] 
		AirRouteTradfficControlCenterArtcc = 518,

		[System.ComponentModel.Description("five19AreaControlCenterAccMissingDefinition")]
		[EnumMember(Value = "Area Control Center (ACC)")] 
		[XmlEnum("519")] 
		AreaControlCenterAcc = 519,

		[System.ComponentModel.Description("AnAirspaceForWhichARadarServiceIsSpecified")]
		[EnumMember(Value = "Radar Area")] 
		[XmlEnum("520")] 
		RadarArea = 520,

		[System.ComponentModel.Description("five21UpperFlightInformationRegionUirMissingDefinition")]
		[EnumMember(Value = "Upper Flight Information Region (UIR)")] 
		[XmlEnum("521")] 
		UpperFlightInformationRegionUir = 521,

		[System.ComponentModel.Description("five22BufferZoneBzMissingDefinition")]
		[EnumMember(Value = "Buffer Zone (BZ)")] 
		[XmlEnum("522")] 
		BufferZoneBz = 522,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCompleteness : int {
		[System.ComponentModel.Description("TheAreaSpecifiedHasBeenPopulatedForAllKnownFeaturesAbsenceOfFeaturesIndicatesThatThereAreNoSuchEntitiesAvailableToTheDataProducer")]
		[EnumMember(Value = "Complete")] 
		[XmlEnum("501")] 
		Complete = 501,

		[System.ComponentModel.Description("CertainFeaturesHaveNotBeenIncludedOrOnlyPartiallyIncludedWithinTheSpecifiedAreaDetailsMustBeProvidedInSupportingTextualInformation")]
		[EnumMember(Value = "Partial")] 
		[XmlEnum("502")] 
		Partial = 502,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("UnpackedHomogenousCargoPouredLooseInACertainSpaceOfAVesselForExampleOilOrGrain")]
		[EnumMember(Value = "Bulk")] 
		[XmlEnum("1")] 
		Bulk = 1,

		[System.ComponentModel.Description("OneOfANumberOfStandardSizedCargoCarryingUnitsSecuredUsingStandardCornerAttachmentsAndBar")]
		[EnumMember(Value = "Container")] 
		[XmlEnum("2")] 
		Container = 2,

		[System.ComponentModel.Description("BreakBulkCargoNormallyLoadedByCrane")]
		[EnumMember(Value = "General")] 
		[XmlEnum("3")] 
		General = 3,

		[System.ComponentModel.Description("AnyCargoLoadedByPipeline")]
		[EnumMember(Value = "Liquid")] 
		[XmlEnum("4")] 
		Liquid = 4,

		[System.ComponentModel.Description("AFeePayingTraveller")]
		[EnumMember(Value = "Passenger")] 
		[XmlEnum("5")] 
		Passenger = 5,

		[System.ComponentModel.Description("LiveAnimalsCarriedInBulk")]
		[EnumMember(Value = "Livestock")] 
		[XmlEnum("6")] 
		Livestock = 6,

		[System.ComponentModel.Description("DangerousOrHazardousCargoAsDescribedByTheImoInternationalMaritimeDangerousGoodsCode")]
		[EnumMember(Value = "Dangerous or Hazardous")] 
		[XmlEnum("7")] 
		DangerousOrHazardous = 7,

		[System.ComponentModel.Description("IndivisibleHeavyItemsOfWeightGenerallyOver100TonsAndWidthOrHeightGreaterThan100Metres")]
		[EnumMember(Value = "Heavy Lift")] 
		[XmlEnum("8")] 
		HeavyLift = 8,

		[System.ComponentModel.Description("MaterialCarriedByAShipToEnsureItsStability")]
		[EnumMember(Value = "Ballast")] 
		[XmlEnum("9")] 
		Ballast = 9,

		[System.ComponentModel.Description("CommodityCargoThatIsTransportedUnpackagedInLargeQuantitiesTheseTypesOfGoodsUsuallyNeedToBeKeptDryDuringTheWholeTransportationPeriod")]
		[EnumMember(Value = "Dry Bulk Cargo")] 
		[XmlEnum("10")] 
		DryBulkCargo = 10,

		[System.ComponentModel.Description("LiquidsOrGasesThatAreTransportedInBulkAndCarriedUnpackaged")]
		[EnumMember(Value = "Liquid Bulk Cargo")] 
		[XmlEnum("11")] 
		LiquidBulkCargo = 11,

		[System.ComponentModel.Description("CargoTransportedInRefrigeratedContainersGenerallyPerishableCommoditiesWhichRequireTemperatureControlledTransportationSuchAsFruitMeatFishVegetablesDairyProductsAndOtherFoods")]
		[EnumMember(Value = "Reefer Container Cargo")] 
		[XmlEnum("12")] 
		ReeferContainerCargo = 12,

		[System.ComponentModel.Description("one3RoRoCargoMissingDefinition")]
		[EnumMember(Value = "Ro-Ro cargo")] 
		[XmlEnum("13")] 
		RoRoCargo = 13,

		[System.ComponentModel.Description("ProjectCargoIsATermUsedToBroadlyDescribeTheNationalOrInternationalTransportationOfLargeHeavyHighValueOrCriticalToTheProjectTheyAreIntendedForPiecesOfEquipmentAlsoCommonlyReferredToAsHeavyLiftThisIncludesShipmentsMadeOfVariousComponentsWhichNeedDisassemblyForShipmentAndReassemblyAfterDelivery")]
		[EnumMember(Value = "Project Cargo")] 
		[XmlEnum("14")] 
		ProjectCargo = 14,

		[System.ComponentModel.Description("GoodsThatAreStowedOnBoardShipInIndividuallyCountedUnitsAndNotInIntermodalContainersNorInBulkAsWithOilOrGrain")]
		[EnumMember(Value = "Break Bulk Cargo")] 
		[XmlEnum("15")] 
		BreakBulkCargo = 15,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalStatus : int {
		[System.ComponentModel.Description("oneLitSoundMissingDefinition")]
		[EnumMember(Value = "lit/sound")] 
		[XmlEnum("1")] 
		LitSound = 1,

		[System.ComponentModel.Description("twoEclipsedSilentMissingDefinition")]
		[EnumMember(Value = "eclipsed/silent")] 
		[XmlEnum("2")] 
		EclipsedSilent = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum divingActivity : int {
		[System.ComponentModel.Description("five01CommercialDivingMissingDefinition")]
		[EnumMember(Value = "Commercial Diving")] 
		[XmlEnum("501")] 
		CommercialDiving = 501,

		[System.ComponentModel.Description("five02SportsDivingMissingDefinition")]
		[EnumMember(Value = "Sports Diving")] 
		[XmlEnum("502")] 
		SportsDiving = 502,

		[System.ComponentModel.Description("five03DiveTrainingMissingDefinition")]
		[EnumMember(Value = "Dive Training")] 
		[XmlEnum("503")] 
		DiveTraining = 503,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum condition : int {
		[System.ComponentModel.Description("BeingBuiltButNotYetCapableOfFunction")]
		[EnumMember(Value = "Under Construction")] 
		[XmlEnum("1")] 
		UnderConstruction = 1,

		[System.ComponentModel.Description("AStructureInADecayedOrDeterioratedConditionResultingFromNeglectOrDisuseOrADamagedStructureInNeedOfRepair")]
		[EnumMember(Value = "Ruined")] 
		[XmlEnum("2")] 
		Ruined = 2,

		[System.ComponentModel.Description("AnAreaOfTheSeaALakeOrTheNavigablePartOfARiverThatIsBeingReclaimedAsLandUsuallyByTheDumpingOfEarthAndOtherMaterial")]
		[EnumMember(Value = "Under Reclamation")] 
		[XmlEnum("3")] 
		UnderReclamation = 3,

		[System.ComponentModel.Description("DetailedPlanningHasBeenCompletedButConstructionHasNotBeenInitiated")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,

		[System.ComponentModel.Description("CompletedUndamagedAndWorkingNormally")]
		[EnumMember(Value = "Operational")] 
		[XmlEnum("501")] 
		Operational = 501,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum nameUsage : int {
		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToTheDefaultNameTextDisplaySetting")]
		[EnumMember(Value = "Default Name Display")] 
		[XmlEnum("1")] 
		DefaultNameDisplay = 1,

		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToAnAlternateNameTextDisplaySettingForExampleAnAlternateLanguage")]
		[EnumMember(Value = "Alternate Name Display")] 
		[XmlEnum("2")] 
		AlternateNameDisplay = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum strengthOfMagneticAnomaly : int {
		[System.ComponentModel.Description("five01NilMissingDefinition")]
		[EnumMember(Value = "nil")] 
		[XmlEnum("501")] 
		Nil = 501,

		[System.ComponentModel.Description("five02SlightMissingDefinition")]
		[EnumMember(Value = "slight")] 
		[XmlEnum("502")] 
		Slight = 502,

		[System.ComponentModel.Description("five03ModerateMissingDefinition")]
		[EnumMember(Value = "moderate")] 
		[XmlEnum("503")] 
		Moderate = 503,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("504")] 
		Strong = 504,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurfaceQualifyingTerms : int {
		[System.ComponentModel.Description("FallsWithinTheSmallestSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Fine")] 
		[XmlEnum("1")] 
		Fine = 1,

		[System.ComponentModel.Description("FallsWithinTheModerateSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Medium")] 
		[XmlEnum("2")] 
		Medium = 2,

		[System.ComponentModel.Description("FallsWithinTheLargestSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Coarse")] 
		[XmlEnum("3")] 
		Coarse = 3,

		[System.ComponentModel.Description("FracturedOrInPieces")]
		[EnumMember(Value = "Broken")] 
		[XmlEnum("4")] 
		Broken = 4,

		[System.ComponentModel.Description("HavingAnAdhesiveOrGlueLikeProperty")]
		[EnumMember(Value = "Sticky")] 
		[XmlEnum("5")] 
		Sticky = 5,

		[System.ComponentModel.Description("NotHardOrFirm")]
		[EnumMember(Value = "Soft")] 
		[XmlEnum("6")] 
		Soft = 6,

		[System.ComponentModel.Description("NotPliantThickResistantToFlow")]
		[EnumMember(Value = "Stiff")] 
		[XmlEnum("7")] 
		Stiff = 7,

		[System.ComponentModel.Description("ComposedOfOrContainingMaterialEjectedFromAVolcano")]
		[EnumMember(Value = "Volcanic")] 
		[XmlEnum("8")] 
		Volcanic = 8,

		[System.ComponentModel.Description("ComposedOfOrContainingCalciumOrCalciumCarbonate")]
		[EnumMember(Value = "Calcareous")] 
		[XmlEnum("9")] 
		Calcareous = 9,

		[System.ComponentModel.Description("FirmUsuallyRefersToAnAreaOfTheSeafloorNotCoveredByUnconsolidatedSediment")]
		[EnumMember(Value = "Hard")] 
		[XmlEnum("10")] 
		Hard = 10,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightCharacteristic : int {
		[System.ComponentModel.Description("ASignalLightThatShowsContinuouslyInAnyGivenDirectionWithConstantLuminousIntensityAndColour")]
		[EnumMember(Value = "Fixed")] 
		[XmlEnum("1")] 
		Fixed = 1,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flashing")] 
		[XmlEnum("2")] 
		Flashing = 2,

		[System.ComponentModel.Description("threeLongFlashingMissingDefinition")]
		[EnumMember(Value = "long-flashing")] 
		[XmlEnum("3")] 
		LongFlashing = 3,

		[System.ComponentModel.Description("fourQuickFlashingMissingDefinition")]
		[EnumMember(Value = "quick-flashing")] 
		[XmlEnum("4")] 
		QuickFlashing = 4,

		[System.ComponentModel.Description("fiveVeryQuickFlashingMissingDefinition")]
		[EnumMember(Value = "very quick-flashing")] 
		[XmlEnum("5")] 
		VeryQuickFlashing = 5,

		[System.ComponentModel.Description("sixUltraQuickFlashingMissingDefinition")]
		[EnumMember(Value = "ultra quick-flashing")] 
		[XmlEnum("6")] 
		UltraQuickFlashing = 6,

		[System.ComponentModel.Description("ALightWithAllDurationsOfLightAndDarknessEqual")]
		[EnumMember(Value = "Isophased")] 
		[XmlEnum("7")] 
		Isophased = 7,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndAllTheEclipsesAreOfEqualDurationItMayBeSingleOccultingAnOccultingLightInWhichAnEclipseIsRegularlyRepeatedGroupOccultingAnOccultingLightInWhichAGroupOfTwoOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedCompositeGroupOccultingAnOccultingLightInWhichASequenceOfGroupsOfOneOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedAndTheGroupsCompriseDifferentNumbersOfEclipses")]
		[EnumMember(Value = "Occulting")] 
		[XmlEnum("8")] 
		Occulting = 8,

		[System.ComponentModel.Description("ALightInWhichTheUltraQuickFlashes160OrMorePerMinuteAreInterruptedAtRegularIntervalsByEclipsesOfLongDuration")]
		[EnumMember(Value = "Interrupted Ultra Quick-Flashing")] 
		[XmlEnum("11")] 
		InterruptedUltraQuickFlashing = 11,

		[System.ComponentModel.Description("ARhythmicLightInWhichAppearancesOfLightOfTwoClearlyDifferentDurationsAreGroupedToRepresentACharacterOrCharactersInTheMorseCode")]
		[EnumMember(Value = "Morse")] 
		[XmlEnum("12")] 
		Morse = 12,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFixedLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Fixed and Flash")] 
		[XmlEnum("13")] 
		FixedAndFlash = 13,

		[System.ComponentModel.Description("one4FlashAndLongFlashMissingDefinition")]
		[EnumMember(Value = "flash and long-flash")] 
		[XmlEnum("14")] 
		FlashAndLongFlash = 14,

		[System.ComponentModel.Description("ARhythmicLightInWhichAnOccultingLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Occulting and Flash")] 
		[XmlEnum("15")] 
		OccultingAndFlash = 15,

		[System.ComponentModel.Description("one6FixedAndLongFlashMissingDefinition")]
		[EnumMember(Value = "fixed and long-flash")] 
		[XmlEnum("16")] 
		FixedAndLongFlash = 16,

		[System.ComponentModel.Description("AnAlternatingLightInWhichTheTotalDurationOfLightInEachPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndInWhichTheIntervalsOfDarknessOccultationsAreAllOfEqualDuration")]
		[EnumMember(Value = "Occulting Alternating")] 
		[XmlEnum("17")] 
		OccultingAlternating = 17,

		[System.ComponentModel.Description("one8LongFlashAlternatingMissingDefinition")]
		[EnumMember(Value = "long-flash alternating")] 
		[XmlEnum("18")] 
		LongFlashAlternating = 18,

		[System.ComponentModel.Description("AnAlternatingRhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flash Alternating")] 
		[XmlEnum("19")] 
		FlashAlternating = 19,

		[System.ComponentModel.Description("two5QuickFlashPlusLongflashMissingDefinition")]
		[EnumMember(Value = "quick-flash plus longflash")] 
		[XmlEnum("25")] 
		QuickFlashPlusLongflash = 25,

		[System.ComponentModel.Description("two6VeryQuickFlashPlusLongFlashMissingDefinition")]
		[EnumMember(Value = "very quick-flash plus long-flash")] 
		[XmlEnum("26")] 
		VeryQuickFlashPlusLongFlash = 26,

		[System.ComponentModel.Description("two7UltraQuickFlashPlusMissingDefinition")]
		[EnumMember(Value = "ultra quick-flash plus")] 
		[XmlEnum("27")] 
		UltraQuickFlashPlus = 27,

		[System.ComponentModel.Description("ASignalLightThatShowsContinuouslyInAnyGivenDirectionTwoOrMoreColoursInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Alternating")] 
		[XmlEnum("28")] 
		Alternating = 28,

		[System.ComponentModel.Description("two9FixedAndAlternatingMissingDefinition")]
		[EnumMember(Value = "fixed and alternating")] 
		[XmlEnum("29")] 
		FixedAndAlternating = 29,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCheckpoint : int {
		[System.ComponentModel.Description("ServesAsAGovernmentCheckpointWhereCustomsDutiesAreCollectedTheFlowOfGoodsAreRegulatedAndRestrictionsEnforcedAndShipmentsOrVehiclesAreClearedForEnteringOrLeavingACountry")]
		[EnumMember(Value = "Custom")] 
		[XmlEnum("1")] 
		Custom = 1,

		[System.ComponentModel.Description("five01RvLocationMissingDefinition")]
		[EnumMember(Value = "RV Location")] 
		[XmlEnum("501")] 
		RvLocation = 501,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[System.ComponentModel.Description("oneConePointUpMissingDefinition")]
		[EnumMember(Value = "cone (point up)")] 
		[XmlEnum("1")] 
		ConePointUp = 1,

		[System.ComponentModel.Description("twoConePointDownMissingDefinition")]
		[EnumMember(Value = "cone (point down)")] 
		[XmlEnum("2")] 
		ConePointDown = 2,

		[System.ComponentModel.Description("ACurvedSurfaceAllPointsOfWhichAreEquidistantFromAFixedPointWithinCalledTheCentre")]
		[EnumMember(Value = "Sphere")] 
		[XmlEnum("3")] 
		Sphere = 3,

		[System.ComponentModel.Description("four2SpheresMissingDefinition")]
		[EnumMember(Value = "2 spheres")] 
		[XmlEnum("4")] 
		twoSpheres = 4,

		[System.ComponentModel.Description("ASolidGeometricalFigureGeneratedByStraightLinesFixedInDirectionAndDescribingWithOneOfPointAClosedCurveEspeciallyACircleInWhichCaseTheFigureIsCircularCylinderItsEndsBeingParallelCircles")]
		[EnumMember(Value = "Cylinder")] 
		[XmlEnum("5")] 
		Cylinder = 5,

		[System.ComponentModel.Description("UsuallyOfRectangularShapeMadeFromTimberOrMetalAndUsedToProvideAContrastWithTheNaturalBackgroundOfADaymarkTheActualDaymarkIsOftenPaintedOnToThisBoard")]
		[EnumMember(Value = "Board")] 
		[XmlEnum("6")] 
		Board = 6,

		[System.ComponentModel.Description("sevenXShapedMissingDefinition")]
		[EnumMember(Value = "x-shaped")] 
		[XmlEnum("7")] 
		XShaped = 7,

		[System.ComponentModel.Description("ACrossWithOneVerticalMemberAndOneHorizontalMemberThatIsSimilarInShapeToTheCharacter")]
		[EnumMember(Value = "Upright Cross")] 
		[XmlEnum("8")] 
		UprightCross = 8,

		[System.ComponentModel.Description("nineCubePointUpMissingDefinition")]
		[EnumMember(Value = "cube (point up)")] 
		[XmlEnum("9")] 
		CubePointUp = 9,

		[System.ComponentModel.Description("one02ConesPointToPointMissingDefinition")]
		[EnumMember(Value = "2 cones (point to point)")] 
		[XmlEnum("10")] 
		twoConesPointToPoint = 10,

		[System.ComponentModel.Description("oneone2ConesBaseToBaseMissingDefinition")]
		[EnumMember(Value = "2 cones (base to base)")] 
		[XmlEnum("11")] 
		twoConesBaseToBase = 11,

		[System.ComponentModel.Description("APlaneFigureHavingFourEqualSidesAndEqualOppositeAnglesTwoAcuteAndTwoObtuseAnObliqueEquilateralParallelogram")]
		[EnumMember(Value = "Rhombus")] 
		[XmlEnum("12")] 
		Rhombus = 12,

		[System.ComponentModel.Description("one32ConesPointsUpwardMissingDefinition")]
		[EnumMember(Value = "2 cones (points upward)")] 
		[XmlEnum("13")] 
		twoConesPointsUpward = 13,

		[System.ComponentModel.Description("one42ConesPointsDownwardMissingDefinition")]
		[EnumMember(Value = "2 cones (points downward)")] 
		[XmlEnum("14")] 
		twoConesPointsDownward = 14,

		[System.ComponentModel.Description("one5BesomPointUpMissingDefinition")]
		[EnumMember(Value = "besom (point up)")] 
		[XmlEnum("15")] 
		BesomPointUp = 15,

		[System.ComponentModel.Description("one6BesomPointDownMissingDefinition")]
		[EnumMember(Value = "besom (point down)")] 
		[XmlEnum("16")] 
		BesomPointDown = 16,

		[System.ComponentModel.Description("AFlagMountedOnAShortPole")]
		[EnumMember(Value = "Flag")] 
		[XmlEnum("17")] 
		Flag = 17,

		[System.ComponentModel.Description("ASphereLocatedAboveARhombus")]
		[EnumMember(Value = "Sphere Over a Rhombus")] 
		[XmlEnum("18")] 
		SphereOverARhombus = 18,

		[System.ComponentModel.Description("APlaneFigureWithFourRightAnglesAndFourEqualStraightSides")]
		[EnumMember(Value = "Square")] 
		[XmlEnum("19")] 
		Square = 19,

		[System.ComponentModel.Description("two0RectangleHorizontalMissingDefinition")]
		[EnumMember(Value = "rectangle (horizontal)")] 
		[XmlEnum("20")] 
		RectangleHorizontal = 20,

		[System.ComponentModel.Description("two1RectangleVerticalMissingDefinition")]
		[EnumMember(Value = "rectangle (vertical)")] 
		[XmlEnum("21")] 
		RectangleVertical = 21,

		[System.ComponentModel.Description("twotwoTrapeziumUpMissingDefinition")]
		[EnumMember(Value = "trapezium (up)")] 
		[XmlEnum("22")] 
		TrapeziumUp = 22,

		[System.ComponentModel.Description("two3TrapeziumDownMissingDefinition")]
		[EnumMember(Value = "trapezium (down)")] 
		[XmlEnum("23")] 
		TrapeziumDown = 23,

		[System.ComponentModel.Description("two4TrianglePointUpMissingDefinition")]
		[EnumMember(Value = "triangle (point up)")] 
		[XmlEnum("24")] 
		TrianglePointUp = 24,

		[System.ComponentModel.Description("two5TrianglePointDownMissingDefinition")]
		[EnumMember(Value = "triangle (point down)")] 
		[XmlEnum("25")] 
		TrianglePointDown = 25,

		[System.ComponentModel.Description("APerfectlyRoundPlaneFigureWhoseCircumferenceIsEverywhereEquidistantFromItsCentre")]
		[EnumMember(Value = "Circle")] 
		[XmlEnum("26")] 
		Circle = 26,

		[System.ComponentModel.Description("two7TwoUprightCrossesOneOverTheOtherMissingDefinition")]
		[EnumMember(Value = "two upright crosses (one over the other)")] 
		[XmlEnum("27")] 
		TwoUprightCrossesOneOverTheOther = 27,

		[System.ComponentModel.Description("two8TShapeMissingDefinition")]
		[EnumMember(Value = "T-shape")] 
		[XmlEnum("28")] 
		TShape = 28,

		[System.ComponentModel.Description("ATriangleVertexUppermostLocatedAboveACircle")]
		[EnumMember(Value = "Triangle Pointing Up Over a Circle")] 
		[XmlEnum("29")] 
		TrianglePointingUpOverACircle = 29,

		[System.ComponentModel.Description("AnUprightCrossLocatedAboveACircle")]
		[EnumMember(Value = "Upright Cross Over a Circle")] 
		[XmlEnum("30")] 
		UprightCrossOverACircle = 30,

		[System.ComponentModel.Description("ARhombusLocatedAboveACircle")]
		[EnumMember(Value = "Rhombus Over a Circle")] 
		[XmlEnum("31")] 
		RhombusOverACircle = 31,

		[System.ComponentModel.Description("ACircleLocatedOverATriangleVertexUppermost")]
		[EnumMember(Value = "Circle Over a Triangle Pointing Up")] 
		[XmlEnum("32")] 
		CircleOverATrianglePointingUp = 32,

		[System.ComponentModel.Description("threethreeOtherShapeSeeShapeInformationMissingDefinition")]
		[EnumMember(Value = "other shape (see shape information)")] 
		[XmlEnum("33")] 
		OtherShapeSeeShapeInformation = 33,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofMarineProtectedArea : int {
		[System.ComponentModel.Description("StrictNatureReserveProtectedAreaManagedMainlyForScience")]
		[EnumMember(Value = "IUCN Category Ia")] 
		[XmlEnum("1")] 
		IucnCategoryIa = 1,

		[System.ComponentModel.Description("WildernessAreaProtectedAreaManagedMainlyForWildernessProtection")]
		[EnumMember(Value = "IUCN Category Ib")] 
		[XmlEnum("2")] 
		IucnCategoryIb = 2,

		[System.ComponentModel.Description("NationalParkProtectedAreaManagedMainlyForEcosystemProtectionAndRecreation")]
		[EnumMember(Value = "IUCN Category II")] 
		[XmlEnum("3")] 
		IucnCategoryIi = 3,

		[System.ComponentModel.Description("NaturalMonumentProtectedAreaManagedMainlyForConservationOfSpecificNaturalFeatures")]
		[EnumMember(Value = "IUCN Category III")] 
		[XmlEnum("4")] 
		IucnCategoryIii = 4,

		[System.ComponentModel.Description("HabitatSpeciesManagementAreaProtectedAreaManagedMainlyForConservationThroughManagementIntervention")]
		[EnumMember(Value = "IUCN Category IV")] 
		[XmlEnum("5")] 
		IucnCategoryIv = 5,

		[System.ComponentModel.Description("ProtectedLandscapeSeascapeProtectedAreaManagedMainlyForLandscapeSeascapeConservationAndRecreation")]
		[EnumMember(Value = "IUCN Category V")] 
		[XmlEnum("6")] 
		IucnCategoryV = 6,

		[System.ComponentModel.Description("ManagedResourceProtectedAreaProtectedAreaManagedMainlyForTheSustainableUseOfNaturalEcosystems")]
		[EnumMember(Value = "IUCN Category VI")] 
		[XmlEnum("7")] 
		IucnCategoryVi = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfConstruction : int {
		[System.ComponentModel.Description("ConstructedOfStonesOrBricksUsuallyQuarriedShapedAndMortared")]
		[EnumMember(Value = "Masonry")] 
		[XmlEnum("1")] 
		Masonry = 1,

		[System.ComponentModel.Description("ConstructedOfConcreteAMaterialMadeOfSandAndGravelThatIsUnitedByCementIntoAHardenedMassUsedForRoadsFoundationsEtc")]
		[EnumMember(Value = "Concreted")] 
		[XmlEnum("2")] 
		Concreted = 2,

		[System.ComponentModel.Description("ConstructedFromLargeStonesOrBlocksOfConcreteOftenPlacedLooselyForProtectionAgainstWavesOrWaterTurbulence")]
		[EnumMember(Value = "Loose Boulders")] 
		[XmlEnum("3")] 
		LooseBoulders = 3,

		[System.ComponentModel.Description("fourHardSurfaceMissingDefinition")]
		[EnumMember(Value = "hard surface")] 
		[XmlEnum("4")] 
		HardSurface = 4,

		[System.ComponentModel.Description("ConstructedWithNoExtraProtectionUsuallyATermAppliedToRoadsNotSurfacedWithAHardMaterial")]
		[EnumMember(Value = "Unsurfaced")] 
		[XmlEnum("5")] 
		Unsurfaced = 5,

		[System.ComponentModel.Description("ConstructedFromWood")]
		[EnumMember(Value = "Wooden")] 
		[XmlEnum("6")] 
		Wooden = 6,

		[System.ComponentModel.Description("ConstructedFromMetal")]
		[EnumMember(Value = "Metal")] 
		[XmlEnum("7")] 
		Metal = 7,

		[System.ComponentModel.Description("ConstructedFromAPlasticMaterialStrengthenedWithFibresOfGlass")]
		[EnumMember(Value = "Glass Reinforced Plastic")] 
		[XmlEnum("8")] 
		GlassReinforcedPlastic = 8,

		[System.ComponentModel.Description("AStructureOfCrossedWoodenOrMetalStripsUsuallyArrangedToFormADiagonalPatternOfOpenSpacesBetweenTheStrips")]
		[EnumMember(Value = "Latticed")] 
		[XmlEnum("11")] 
		Latticed = 11,

		[System.ComponentModel.Description("oneAnyArtificialOrNaturalSubstanceHavingSimilarPropertiesAndCompositionAsFusedBoraxObsidianOrTheLike2SomethingMadeOfSuchASubstanceAsAWindowpane")]
		[EnumMember(Value = "Glass")] 
		[XmlEnum("12")] 
		Glass = 12,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDolphin : int {
		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedAsAMooringPointForVessels")]
		[EnumMember(Value = "Mooring Dolphin")] 
		[XmlEnum("1")] 
		MooringDolphin = 1,

		[System.ComponentModel.Description("APostOrGroupOfPostsWhichAVesselMaySwingAroundForCompassAdjustment")]
		[EnumMember(Value = "Deviation Dolphin")] 
		[XmlEnum("2")] 
		DeviationDolphin = 2,

		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedToExtendTheBerthOfAVesselByProvidingExtraMooringPoints")]
		[EnumMember(Value = "Berthing Dolphin")] 
		[XmlEnum("3")] 
		BerthingDolphin = 3,

		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedToAssistInBerthingOfVesselsByTakingUpSomeBerthingLoadsKeepVesselsFromPressingAgainstThePierStructureOrToProtectStructuresFromPossibleImpactByShips")]
		[EnumMember(Value = "Fender or Breasting Dolphin")] 
		[XmlEnum("4")] 
		FenderOrBreastingDolphin = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthFromTheChartDatumToTheSeabedOrToTheTopOfADryingFeatureIsKnown")]
		[EnumMember(Value = "Depth Known")] 
		[XmlEnum("1")] 
		DepthKnown = 1,

		[System.ComponentModel.Description("twoDepthUnknownMissingDefinition")]
		[EnumMember(Value = "depth unknown")] 
		[XmlEnum("2")] 
		DepthUnknown = 2,

		[System.ComponentModel.Description("ADepthThatMayBeLessThanIndicated")]
		[EnumMember(Value = "Doubtful Sounding")] 
		[XmlEnum("3")] 
		DoubtfulSounding = 3,

		[System.ComponentModel.Description("ADepthThatIsConsideredToBeAnUnreliableValue")]
		[EnumMember(Value = "Unreliable Sounding")] 
		[XmlEnum("4")] 
		UnreliableSounding = 4,

		[System.ComponentModel.Description("TheShoalestDepthOverAFeatureIsOfKnownValue")]
		[EnumMember(Value = "Least Depth Known")] 
		[XmlEnum("6")] 
		LeastDepthKnown = 6,

		[System.ComponentModel.Description("sevenLeastDepthUnknownSafeClearanceAtValueShownMissingDefinition")]
		[EnumMember(Value = "least depth unknown, safe clearance at value shown")] 
		[XmlEnum("7")] 
		LeastDepthUnknownSafeClearanceAtValueShown = 7,

		[System.ComponentModel.Description("eightValueReportedNotSurveyedMissingDefinition")]
		[EnumMember(Value = "value reported (not surveyed)")] 
		[XmlEnum("8")] 
		ValueReportedNotSurveyed = 8,

		[System.ComponentModel.Description("nineValueReportedNotConfirmedMissingDefinition")]
		[EnumMember(Value = "value reported (not confirmed)")] 
		[XmlEnum("9")] 
		ValueReportedNotConfirmed = 9,

		[System.ComponentModel.Description("TheDepthAtWhichAChannelIsKeptByHumanInfluenceUsuallyByDredging")]
		[EnumMember(Value = "Maintained Depth")] 
		[XmlEnum("10")] 
		MaintainedDepth = 10,

		[System.ComponentModel.Description("DepthsMayBeAlteredByHumanInfluenceButWillNotBeRoutinelyMaintained")]
		[EnumMember(Value = "Not Regularly Maintained")] 
		[XmlEnum("11")] 
		NotRegularlyMaintained = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfShorelineConstruction : int {
		[System.ComponentModel.Description("AStructureProtectingAShoreAreaHarbourAnchorageOrBasinFromWaves")]
		[EnumMember(Value = "Breakwater")] 
		[XmlEnum("1")] 
		Breakwater = 1,

		[System.ComponentModel.Description("ALowArtificialWallLikeStructureOfDurableMaterialExtendingFromTheLandToSeawardForAParticularPurposeSuchAsToProtectTheCoastOrToForceACurrentToScourAChannel")]
		[EnumMember(Value = "Groyne")] 
		[XmlEnum("2")] 
		Groyne = 2,

		[System.ComponentModel.Description("AFormOfBreakwaterAlongsideWhichVesselsMayLieOnTheShelteredSideOnlyInSomeCasesItMayLieEntirelyWithinAnArtificialHarbourPermittingVesselsToLieAlongBothSides")]
		[EnumMember(Value = "Mole")] 
		[XmlEnum("3")] 
		Mole = 3,

		[System.ComponentModel.Description("fourPierJettyMissingDefinition")]
		[EnumMember(Value = "pier (jetty)")] 
		[XmlEnum("4")] 
		PierJetty = 4,

		[System.ComponentModel.Description("APierBuiltOnlyForRecreationalPurposes")]
		[EnumMember(Value = "Promenade Pier")] 
		[XmlEnum("5")] 
		PromenadePier = 5,

		[System.ComponentModel.Description("sixWharfQuayMissingDefinition")]
		[EnumMember(Value = "wharf (quay)")] 
		[XmlEnum("6")] 
		WharfQuay = 6,

		[System.ComponentModel.Description("AWallOrBankOftenSubmergedBuiltToDirectOrConfineTheFlowOfARiverOrTidalCurrentOrToPromoteAScourAction")]
		[EnumMember(Value = "Training Wall")] 
		[XmlEnum("7")] 
		TrainingWall = 7,

		[System.ComponentModel.Description("ALayerOfBrokenRockCobblesBouldersOrFragmentsOfSufficientSizeToResistTheErosiveForcesOfFlowingWaterAndWaveAction")]
		[EnumMember(Value = "Rip Rap")] 
		[XmlEnum("8")] 
		RipRap = 8,

		[System.ComponentModel.Description("FacingOfStoneOrOtherMaterialEitherPermanentOrTemporaryPlacedAlongTheEdgeOfAStreamRiverOrCanalToStabilizeTheBankAndToProtectItFromTheErosiveActionOfTheStream")]
		[EnumMember(Value = "Revetment")] 
		[XmlEnum("9")] 
		Revetment = 9,

		[System.ComponentModel.Description("AnEmbankmentOrWallForProtectionAgainstWavesOrTidalActionAlongAShoreOrWaterFront")]
		[EnumMember(Value = "Sea Wall")] 
		[XmlEnum("10")] 
		SeaWall = 10,

		[System.ComponentModel.Description("StepsAtTheShorelineAsTheConnectionBetweenLandAndWaterOnDifferentLevels")]
		[EnumMember(Value = "Landing Steps")] 
		[XmlEnum("11")] 
		LandingSteps = 11,

		[System.ComponentModel.Description("oneASlopingStructureWhichMayIncludeRailsThatCanEitherBeUsedAsALandingPlaceAtVariableWaterLevelsForSmallVesselsLandingShipsOrAFerryBoatOrForHaulingACradleCarryingAVessel2AnAccumulationOfSnowThatFormsAnInclinedPlaneBetweenLandOrLandIceElementsAndSeaIceOrIceShelfAlsoCalledDriftIceFoot")]
		[EnumMember(Value = "Ramp")] 
		[XmlEnum("12")] 
		Ramp = 12,

		[System.ComponentModel.Description("ThePreparedAndUsuallyReinforcedInclinedSurfaceOnWhichKeelAndBilgeBlocksAreLaidForSupportingAVesselUnderConstruction")]
		[EnumMember(Value = "Slipway")] 
		[XmlEnum("13")] 
		Slipway = 13,

		[System.ComponentModel.Description("AProtectiveStructureDesignedToCushionTheImpactOfAVesselAndPreventDamage")]
		[EnumMember(Value = "Fender")] 
		[XmlEnum("14")] 
		Fender = 14,

		[System.ComponentModel.Description("AWharfConsistingOfASolidWallOfConcreteMasonryWoodEtcSuchThatTheWaterCannotCirculateFreelyUnderTheWharfTheTypeOfConstructionAffectsShipHandlingForExampleASolidFaceWharfMayGiveShelterFromTidalStreamsButUnderCertainCircumstancesACushionOfWaterMayBuildUpBetweenSuchAWharfAndAShipAttemptingToBerthAtItCausingDifficultiesInShipHandling")]
		[EnumMember(Value = "Solid Face Wharf")] 
		[XmlEnum("15")] 
		SolidFaceWharf = 15,

		[System.ComponentModel.Description("AWharfSupportedOnPilesOrOtherStructuresWhichAllowFreeCirculationOfWaterUnderTheWharf")]
		[EnumMember(Value = "Open Face Wharf")] 
		[XmlEnum("16")] 
		OpenFaceWharf = 16,

		[System.ComponentModel.Description("AnInclinedPlaneUsedToDumpLogsIntoTheWaterForTransportOrToHaulLogsOutOfTheWaterForProcessing")]
		[EnumMember(Value = "Log Ramp")] 
		[XmlEnum("17")] 
		LogRamp = 17,

		[System.ComponentModel.Description("AnArtificialPoolOrSwimmingEnclosureEspeciallyOneInTheOpenAirWhichMayBeConstructedOfWireMeshOrHeavyNettingSupportedByCablesBuoysOrPilesForSwimmingIn")]
		[EnumMember(Value = "Swimming Facility")] 
		[XmlEnum("20")] 
		SwimmingFacility = 20,

		[System.ComponentModel.Description("AWharfApproximatelyParallelToTheShorelineAndAccommodatingShipsOnOneSideOnlyTheOtherSideBeingAttachedToTheShoreItIsUsuallyOfSolidConstructionAsContrastedWithTheOpenPileConstructionUsuallyUsedForPiers")]
		[EnumMember(Value = "Quay")] 
		[XmlEnum("22")] 
		Quay = 22,

		[System.ComponentModel.Description("two3TieUpWallMissingDefinition")]
		[EnumMember(Value = "tie-up wall")] 
		[XmlEnum("23")] 
		TieUpWall = 23,

		[System.ComponentModel.Description("ManMadeStructureThatActsAsAnObstacleToLandingOperations")]
		[EnumMember(Value = "Artificial Obstacle")] 
		[XmlEnum("501")] 
		ArtificialObstacle = 501,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightVisibility : int {
		[System.ComponentModel.Description("NonMarineLightsWithAHigherPowerThanMarineLightsAndVisibleFromWellOffShoreOftenAeroLights")]
		[EnumMember(Value = "High Intensity")] 
		[XmlEnum("1")] 
		HighIntensity = 1,

		[System.ComponentModel.Description("NonMarineLightsWithLowerPowerThanMarineLights")]
		[EnumMember(Value = "Low Intensity")] 
		[XmlEnum("2")] 
		LowIntensity = 2,

		[System.ComponentModel.Description("ADecreaseInTheApparentIntensityOfALightWhichMayOccurInTheCaseOfPartialObstructions")]
		[EnumMember(Value = "Faint")] 
		[XmlEnum("3")] 
		Faint = 3,

		[System.ComponentModel.Description("ALightInASectorIsIntensifiedThatIsHasLongerRangeThanOtherSectors")]
		[EnumMember(Value = "Intensified")] 
		[XmlEnum("4")] 
		Intensified = 4,

		[System.ComponentModel.Description("ALightInASectorIsUnintensifiedThatIsHasShorterRangeThanOtherSectors")]
		[EnumMember(Value = "Unintensified")] 
		[XmlEnum("5")] 
		Unintensified = 5,

		[System.ComponentModel.Description("ALightSectorIsDeliberatelyReducedInIntensityForExampleToReduceItsEffectOnABuiltUpArea")]
		[EnumMember(Value = "Visibility Deliberately Restricted")] 
		[XmlEnum("6")] 
		VisibilityDeliberatelyRestricted = 6,

		[System.ComponentModel.Description("SaidOfTheArcOfALightSectorDesignatedByItsLimitingBearingsInWhichTheLightIsNotVisibleFromSeaward")]
		[EnumMember(Value = "Obscured")] 
		[XmlEnum("7")] 
		Obscured = 7,

		[System.ComponentModel.Description("ThisValueSpecifiesThatPartsOfTheSectorAreObscured")]
		[EnumMember(Value = "Partially Obscured")] 
		[XmlEnum("8")] 
		PartiallyObscured = 8,

		[System.ComponentModel.Description("LightsThatMustBeInLineToBeVisible")]
		[EnumMember(Value = "Visible in Line of Range")] 
		[XmlEnum("9")] 
		VisibleInLineOfRange = 9,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSeaArea : int {
		[System.ComponentModel.Description("ANaturalOrArtificialPassageOrChannelThroughShoalsOrSteepBanksOrAcrossALineOfBanksLyingBetweenTwoChannels")]
		[EnumMember(Value = "Gat")] 
		[XmlEnum("2")] 
		Gat = 2,

		[System.ComponentModel.Description("AnElevationOfTheSeafloorAtDepthsGenerallyLessThan200MButSufficientForSafeSurfaceNavigationCommonlyFoundOnTheContinentalShelfOrNearAnIsland")]
		[EnumMember(Value = "Bank")] 
		[XmlEnum("3")] 
		Bank = 3,

		[System.ComponentModel.Description("InOceanographyAnObsoleteTermWhichWasGenerallyRestrictedToDepthsGreaterThan6000M")]
		[EnumMember(Value = "Deep")] 
		[XmlEnum("4")] 
		Deep = 4,

		[System.ComponentModel.Description("AWideIndentationInTheCoastlineGenerallySmallerThanAGulfAndLargerThanACoveForThePurposesOfTheUnitedNationsConventionOnTheLawOfTheSeaABayIsAWellMarkedIndentationWhosePenetrationIsInSuchProportionToTheWidthOfItsMouthAsToContainLandLockedWatersAndConstituteMoreThanAMereCurvatureOfTheCoast")]
		[EnumMember(Value = "Bay")] 
		[XmlEnum("5")] 
		Bay = 5,

		[System.ComponentModel.Description("ALongDeepAsymmetricalDepressionWithRelativelySteepSidesThatIsAssociatedWithSubduction")]
		[EnumMember(Value = "Trench")] 
		[XmlEnum("6")] 
		Trench = 6,

		[System.ComponentModel.Description("ADepressionOfTheSeafloorMoreOrLessEquidimensionalInPlanAndOfVariableExtent")]
		[EnumMember(Value = "Basin")] 
		[XmlEnum("7")] 
		Basin = 7,

		[System.ComponentModel.Description("ALevelTractOfLandAsTheBedOfADryLakeOrAnAreaFrequentlyUncoveredAtLowTideUsuallyInPlural")]
		[EnumMember(Value = "Mud Flats")] 
		[XmlEnum("8")] 
		MudFlats = 8,

		[System.ComponentModel.Description("AShallowElevationComposedOfConsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Reef")] 
		[XmlEnum("9")] 
		Reef = 9,

		[System.ComponentModel.Description("ARockyFormationContinuousWithAndFringingTheShore")]
		[EnumMember(Value = "Ledge")] 
		[XmlEnum("10")] 
		Ledge = 10,

		[System.ComponentModel.Description("AnElongatedNarrowSteepSidedDepressionThatGenerallyDeepensDownSlope")]
		[EnumMember(Value = "Canyon")] 
		[XmlEnum("11")] 
		Canyon = 11,

		[System.ComponentModel.Description("ANavigableNarrowPartOfABayStraitRiverEtc")]
		[EnumMember(Value = "Narrows")] 
		[XmlEnum("12")] 
		Narrows = 12,

		[System.ComponentModel.Description("AShallowElevationComposedOfUnconsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Shoal")] 
		[XmlEnum("13")] 
		Shoal = 13,

		[System.ComponentModel.Description("ADistinctElevationWithARoundedProfileLessThan1000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Knoll")] 
		[XmlEnum("14")] 
		Knoll = 14,

		[System.ComponentModel.Description("AnElongatedElevationOfVaryingComplexityAndSizeGenerallyHavingSteepSides")]
		[EnumMember(Value = "Ridge")] 
		[XmlEnum("15")] 
		Ridge = 15,

		[System.ComponentModel.Description("ADistinctGenerallyEquidimensionalElevationGreaterThan1000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Seamount")] 
		[XmlEnum("16")] 
		Seamount = 16,

		[System.ComponentModel.Description("AnyHighTowerOrSpireShapedPillarOrRockOrCoralAloneOrCrestingASummitItMayExtendAboveTheSurfaceOfTheWaterItMayOrMayNotBeAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Pinnacle")] 
		[XmlEnum("17")] 
		Pinnacle = 17,

		[System.ComponentModel.Description("AnExtensiveFlatGentlySlopingOrNearlyLevelRegionAtAbyssalDepths")]
		[EnumMember(Value = "Abyssal Plain")] 
		[XmlEnum("18")] 
		AbyssalPlain = 18,

		[System.ComponentModel.Description("ALargeRelativelyFlatElevationThatIsHigherThanTheSurroundingReliefWithOneOrMoreRelativelySteepSides")]
		[EnumMember(Value = "Plateau")] 
		[XmlEnum("19")] 
		Plateau = 19,

		[System.ComponentModel.Description("ASubordinateRidgeProtrudingFromALargerFeature")]
		[EnumMember(Value = "Spur")] 
		[XmlEnum("20")] 
		Spur = 20,

		[System.ComponentModel.Description("TheFlatOrGentlySlopingRegionAdjacentToAContinentOrAroundAnIslandThatExtendsFromTheLowWaterLineToADepthGenerallyAbout200mWhereThereIsAMarkedIncreaseInDownwardSlope")]
		[EnumMember(Value = "Shelf")] 
		[XmlEnum("21")] 
		Shelf = 21,

		[System.ComponentModel.Description("ALongDepressionGenerallyWideAndFlatBottomedWithSymmetricalAndParallelSides")]
		[EnumMember(Value = "Trough")] 
		[XmlEnum("22")] 
		Trough = 22,

		[System.ComponentModel.Description("ABroadPassOrColInARidgeRiseOrOtherElevation")]
		[EnumMember(Value = "Saddle")] 
		[XmlEnum("23")] 
		Saddle = 23,

		[System.ComponentModel.Description("AnIsolatedSmallElevationOnTheDeepSeafloor")]
		[EnumMember(Value = "Abyssal Hill")] 
		[XmlEnum("24")] 
		AbyssalHill = 24,

		[System.ComponentModel.Description("AGentlyDippingSlopeWithASmoothSurfaceCommonlyFoundAroundGroupsOfIslandsAndSeamounts")]
		[EnumMember(Value = "Apron")] 
		[XmlEnum("25")] 
		Apron = 25,

		[System.ComponentModel.Description("AGentleSlopeWithAGenerallySmoothSurfaceOfTheSeafloorCharacteristicallyFoundAroundGroupsOfIslandsOrSeamounts")]
		[EnumMember(Value = "Archipelagic Apron")] 
		[XmlEnum("26")] 
		ArchipelagicApron = 26,

		[System.ComponentModel.Description("ARegionAdjacentToAContinentNormallyOccupiedByOrBorderingAShelfAndSometimesEmergingAsIslandsThatIsIrregularOrBlockyInPlanOrProfileWithDepthsWellInExcessOfThoseTypicalOfAShelf")]
		[EnumMember(Value = "Borderland")] 
		[XmlEnum("27")] 
		Borderland = 27,

		[System.ComponentModel.Description("TheZoneGenerallyConsistingOfShelfSlopeAndContinentalRiseSeparatingTheContinentFromTheDeepSeafloorOrAbyssalPlainOrPlainOccasionallyATrenchMayBePresentInPlaceOfAContinentalRise")]
		[EnumMember(Value = "Continental Margin")] 
		[XmlEnum("28")] 
		ContinentalMargin = 28,

		[System.ComponentModel.Description("AGentleSlopeRisingFromTheOceanicDepthsTowardsTheFootOfAContinentalSlope")]
		[EnumMember(Value = "Continental Rise")] 
		[XmlEnum("29")] 
		ContinentalRise = 29,

		[System.ComponentModel.Description("AnElongatedCharacteristicallyLinearSteepSlopeSeparatingHorizontalOrGentlySlopingAreasOfTheSeafloor")]
		[EnumMember(Value = "Escarpment")] 
		[XmlEnum("30")] 
		Escarpment = 30,

		[System.ComponentModel.Description("ARelativelySmoothDepositionalFeatureContinuouslyDeepeningAwayFromASedimentSourceCommonlyLocatedAtTheLowerTerminationOfACanyonOrCanyonSystem")]
		[EnumMember(Value = "Fan")] 
		[XmlEnum("31")] 
		Fan = 31,

		[System.ComponentModel.Description("ALongNarrowZoneOfIrregularTopographyFormedByTheMovementOfTectonicPlatesAssociatedWithAnOffsetOfASpreadingRidgeAxisCharacterizedBySteepSidedAndOrAsymmetricalRidgesTroughsOrEscarpments")]
		[EnumMember(Value = "Fracture Zone")] 
		[XmlEnum("32")] 
		FractureZone = 32,

		[System.ComponentModel.Description("ANarrowBreakInARidgeRiseOrOtherElevation")]
		[EnumMember(Value = "Gap")] 
		[XmlEnum("33")] 
		Gap = 33,

		[System.ComponentModel.Description("ASeamountHavingAComparativelySmoothFlatTop")]
		[EnumMember(Value = "Guyot")] 
		[XmlEnum("34")] 
		Guyot = 34,

		[System.ComponentModel.Description("oneASmallIsolatedElevationSmallerThanAMountain2ADistinctElevationGenerallyOfIrregularShapeLessThanone000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Hill")] 
		[XmlEnum("35")] 
		Hill = 35,

		[System.ComponentModel.Description("ADepressionOfLimitedExtentWithAllSidesRisingSteeplyFromARelativelyFlatBottom")]
		[EnumMember(Value = "Hole")] 
		[XmlEnum("36")] 
		Hole = 36,

		[System.ComponentModel.Description("ADepositionalEmbankmentBorderingACanyonValleyOrSeaChannel")]
		[EnumMember(Value = "Levee")] 
		[XmlEnum("37")] 
		Levee = 37,

		[System.ComponentModel.Description("TheAxialDepressionOfTheMidOceanicRidgeSystem")]
		[EnumMember(Value = "Median Valley")] 
		[XmlEnum("38")] 
		MedianValley = 38,

		[System.ComponentModel.Description("AnAnnularOrPartiallyAnnularDepressionCommonlyLocatedAtTheBaseOfSeamountsIslandsAndOtherIsolatedElevations")]
		[EnumMember(Value = "Moat")] 
		[XmlEnum("39")] 
		Moat = 39,

		[System.ComponentModel.Description("ANaturalElevationOfTheEarthSSurfaceRisingMoreOrLessAbruptlyFromTheSurroundingLevelAndAttainingAnAltitudeWhichRelativelyToAdjacentElevationsIsImpressiveOrNotable")]
		[EnumMember(Value = "Mountains")] 
		[XmlEnum("40")] 
		Mountains = 40,

		[System.ComponentModel.Description("AConicalOrPointedElevationOnALargerFeatureSuchAsASeamount")]
		[EnumMember(Value = "Peak")] 
		[XmlEnum("41")] 
		Peak = 41,

		[System.ComponentModel.Description("AGeographicallyDistinctRegionWithANumberOfSharedPhysiographicCharacteristicsThatContrastWithThoseInTheSurroundingAreasThisTermShouldBeModifiedWithTheGenericTermThatBestDescribesTheMajorityOfFeaturesInTheRegionForExampleSeamountInBajaCaliforniaSeamountProvince")]
		[EnumMember(Value = "Province")] 
		[XmlEnum("42")] 
		Province = 42,

		[System.ComponentModel.Description("ABroadElevationThatGenerallyRisesGentlyAndSmoothlyFromTheSurroundingRelief")]
		[EnumMember(Value = "Rise")] 
		[XmlEnum("43")] 
		Rise = 43,

		[System.ComponentModel.Description("AnElongatedMeanderingDepressionUsuallyOccurringOnAGentlySlopingPlainOrFan")]
		[EnumMember(Value = "Sea Channel")] 
		[XmlEnum("44")] 
		SeaChannel = 44,

		[System.ComponentModel.Description("SeveralSeamountsInLinearOrArcuateAlignment")]
		[EnumMember(Value = "Seamount Chain")] 
		[XmlEnum("45")] 
		SeamountChain = 45,

		[System.ComponentModel.Description("four6ShelfEdgeMissingDefinition")]
		[EnumMember(Value = "shelf-edge")] 
		[XmlEnum("46")] 
		ShelfEdge = 46,

		[System.ComponentModel.Description("ARelativelyShallowBarrierBetweenBasinsThatMayInhibitWaterMovement")]
		[EnumMember(Value = "Sill")] 
		[XmlEnum("47")] 
		Sill = 47,

		[System.ComponentModel.Description("TheSlopingRegionThatDeepensFromAShelfToThePointWhereThereIsAGeneralDecreaseInGradient")]
		[EnumMember(Value = "Slope")] 
		[XmlEnum("48")] 
		Slope = 48,

		[System.ComponentModel.Description("AFlatOrGentlySlopingRegionGenerallyLongAndNarrowBoundedAlongOneEdgeByASteeperDescendingSlopeAndAlongTheOtherByASteeperAscendingSlope")]
		[EnumMember(Value = "Terrace")] 
		[XmlEnum("49")] 
		Terrace = 49,

		[System.ComponentModel.Description("AnElongatedDepressionThatGenerallyWidensAndDeepensDownSlope")]
		[EnumMember(Value = "Valley")] 
		[XmlEnum("50")] 
		Valley = 50,

		[System.ComponentModel.Description("AnArtificialWaterwayWithNoFlowOrAControlledFlowUsedForNavigationOrForDrainingOrIrrigatingLandDitch")]
		[EnumMember(Value = "Canal")] 
		[XmlEnum("51")] 
		Canal = 51,

		[System.ComponentModel.Description("ALargeBodyOfWaterEntirelySurroundedByLand")]
		[EnumMember(Value = "Lake")] 
		[XmlEnum("52")] 
		Lake = 52,

		[System.ComponentModel.Description("ARelativelyLargeNaturalStreamOfWater")]
		[EnumMember(Value = "River")] 
		[XmlEnum("53")] 
		River = 53,

		[System.ComponentModel.Description("AStraightSectionOfARiverEspeciallyANavigableRiverBetweenTwoBendsOrAnArmOfTheSeaExtendingIntoTheLand")]
		[EnumMember(Value = "Reach")] 
		[XmlEnum("54")] 
		Reach = 54,

		[System.ComponentModel.Description("ALowFlatIslandOfSandCoralEtcAwashOrSubmergedAtHighWater")]
		[EnumMember(Value = "Intertidal Cay")] 
		[XmlEnum("55")] 
		IntertidalCay = 55,

		[System.ComponentModel.Description("ASeabedVolcanoSubmergedAtTheChartSoundingDatumWhichMayOrMayNotBeActive")]
		[EnumMember(Value = "Submarine Volcano")] 
		[XmlEnum("56")] 
		SubmarineVolcano = 56,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfConveyor : int {
		[System.ComponentModel.Description("ATransportationSystemConsistingOfLoadCablesStrungBetweenPylonsOnWhichCarrierUnitsForExampleCarsOrBucketsIntendedToTransportPeopleMaterialAndOrEquipmentAreSuspended")]
		[EnumMember(Value = "Aerial Cableway")] 
		[XmlEnum("1")] 
		AerialCableway = 1,

		[System.ComponentModel.Description("AConveyorAlongWhichMaterialOrPeopleAreTransportedByMeansOfAMovingBelt")]
		[EnumMember(Value = "Belt Conveyor")] 
		[XmlEnum("2")] 
		BeltConveyor = 2,

		[System.ComponentModel.Description("AnArtificialChannelUsuallyAnInclinedChuteOrTroughForCarryingWaterToFurnishPowerTransportLogsDownAMountainsideEtc")]
		[EnumMember(Value = "Flume")] 
		[XmlEnum("3")] 
		Flume = 3,

		[System.ComponentModel.Description("fourLiftElevatorMissingDefinition")]
		[EnumMember(Value = "lift/elevator")] 
		[XmlEnum("4")] 
		LiftElevator = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRoad : int {
		[System.ComponentModel.Description("ALimitedAccessDualCarriagewayRoadSpeciallyDesignedForFastLongDistanceTrafficAndSubjectToSpecialRegulationsConcerningItsUseItMayHaveMoreThanTwoLanes")]
		[EnumMember(Value = "Motorway")] 
		[XmlEnum("1")] 
		Motorway = 1,

		[System.ComponentModel.Description("AHardSurfacedMetalledRoadAMainThroughRoute")]
		[EnumMember(Value = "Major Road")] 
		[XmlEnum("2")] 
		MajorRoad = 2,

		[System.ComponentModel.Description("ASecondaryRoadForLocalTraffic")]
		[EnumMember(Value = "Minor Road")] 
		[XmlEnum("3")] 
		MinorRoad = 3,

		[System.ComponentModel.Description("fourTrackPathMissingDefinition")]
		[EnumMember(Value = "track/path")] 
		[XmlEnum("4")] 
		TrackPath = 4,

		[System.ComponentModel.Description("AMainRoadInAnUrbanAreaForThroughTraffic")]
		[EnumMember(Value = "Major Street")] 
		[XmlEnum("5")] 
		MajorStreet = 5,

		[System.ComponentModel.Description("ASecondaryRoadInAnUrbanAreaForLocalTraffic")]
		[EnumMember(Value = "Minor Street")] 
		[XmlEnum("6")] 
		MinorStreet = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum bottomFeatureClassification : int {
		[System.ComponentModel.Description("InGeologyABreakOfShearInTheEarthSCrustWithAnObservableDisplacementBetweenTheTwoSidesOfTheBreakAndParallelToThePlaneOfTheBreak")]
		[EnumMember(Value = "Fault")] 
		[XmlEnum("502")] 
		Fault = 502,

		[System.ComponentModel.Description("ALargeMobileWaveLikeSedimentFeatureInShallowWaterAndComposedOfSandTheWavelengthMayReach100MetresTheAmplitudeMayBeUpTo20Metres")]
		[EnumMember(Value = "Sandwave")] 
		[XmlEnum("510")] 
		Sandwave = 510,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[System.ComponentModel.Description("TheTonneOrMetricTonUSOftenRedundantlyReferredToAsAMetricTonneIsAUnitOfMassEqualTo1000Kg2205LbOrApproximatelyTheMassOfOneCubicMetreOfWaterAtFourDegreesCelsiusItIsSometimesAbbreviatedAsMtInTheUnitedStatesButThisConflictsWithOtherSiSymbolsTheTonneIsNotAUnitInTheInternationalSystemOfUnitsSiButIsAcceptedForUseWithTheSiInSiUnitsAndPrefixesTheTonneIsAMegagramMgTheImperialAndUsCustomaryUnitsComparableToTheTonneAreBothSpelledTonInEnglishThoughTheyDifferInMassPronunciationOfTonneTheWordUsedInTheUkAndTonIsUsuallyIdenticalButIsNotTooConfusingUnlessAccuracyIsImportantAsTheTonneAndUkLongTonDifferByOnly16")]
		[EnumMember(Value = "Metric Ton")] 
		[XmlEnum("3")] 
		MetricTon = 3,

		[System.ComponentModel.Description("LongTonWeightTonOrImperialTonIsTheNameForTheUnitCalledTheTonInTheAvoirdupoisOrImperialSystemOfMeasurementsAsUsedInTheUnitedKingdomAndSeveralOtherCommonwealthCountriesItHasBeenMostlyReplacedByTheTonneAndInTheUnitedStatesByTheShortTonOneLongTonIsEqualTo2240Pounds1016KgOr35CubicFeet09911MOfSaltWaterWithADensityOf64LbFt1025GMlItHasSomeLimitedUseInTheUnitedStatesMostCommonlyInMeasuringTheDisplacementOfShipsAndWasTheUnitPrescribedForWarshipsByTheWashingtonNavalTreatyForExampleBattleshipsWereLimitedToAMassOf35000LongTons36000T39000St")]
		[EnumMember(Value = "Ton")] 
		[XmlEnum("4")] 
		Ton = 4,

		[System.ComponentModel.Description("AUnitOfWeightEqualTo2000Pounds90718474KgInTheUnitedStatesItIsOftenCalledSimplyTonWithoutDistinguishingItFromTheMetricTonTonne1000KilogramsOrTheLongTon2240Pounds10160469088KilogramsRatherTheOtherTwoAreSpecificallyNotedThereAreHoweverSomeUsApplicationsForWhichUnspecifiedTonsNormallyMeansLongTonsForExampleNavyShipsOrMetricTonsWorldGrainProductionFiguresBothTheLongAndShortTonAreDefinedAs20HundredweightsButAHundredweightIs100Pounds45359237KgInTheUsSystemShortOrNetHundredweightAnd112Pounds5080234544KgInTheImperialSystemLongOrGrossHundredweight")]
		[EnumMember(Value = "Short Ton")] 
		[XmlEnum("5")] 
		ShortTon = 5,

		[System.ComponentModel.Description("GrossTonnageGtIsAFunctionOfTheVolumeOfAllShipSEnclosedSpacesFromKeelToFunnelMeasuredToTheOutsideOfTheHullFramingThereIsASlidingScaleFactorSoGtIsAKindOfCapacityDerivedIndexThatIsUsedToRankAShipForPurposesOfDeterminingManningSafetyAndOtherStatutoryRequirementsAndIsExpressedSimplyAsGtWhichIsAUnitlessEntityEvenThoughItsDerivationIsTiedToTheCubicMeterUnitOfVolumetricCapacityTonnageMeasurementsAreNowGovernedByAnImoConventionInternationalConventionOnTonnageMeasurementOfShips1969LondonRulesWhichAppliesToAllShipsBuiltAfterJuly1982InAccordanceWithTheConventionTheCorrectTermToUseNowIsGtWhichIsAFunctionOfTheMouldedVolumeOfAllEnclosedSpacesOfTheShip")]
		[EnumMember(Value = "Gross Ton")] 
		[XmlEnum("6")] 
		GrossTon = 6,

		[System.ComponentModel.Description("NetTonnageNtIsBasedOnACalculationOfTheVolumeOfAllCargoSpacesOfTheShipItIndicatesAVesselsEarningSpaceAndIsAFunctionOfTheMouldedVolumeOfAllCargoSpacesOfTheShip")]
		[EnumMember(Value = "Net Ton")] 
		[XmlEnum("7")] 
		NetTon = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum firstSensor : int {
		[System.ComponentModel.Description("five01AcousticSensorMissingDefinition")]
		[EnumMember(Value = "acoustic sensor")] 
		[XmlEnum("501")] 
		AcousticSensor = 501,

		[System.ComponentModel.Description("TheObjectWasReportedAsAResultOfDetectingAFluctuationInTheLocalMagneticField")]
		[EnumMember(Value = "Magnetic Sensor")] 
		[XmlEnum("502")] 
		MagneticSensor = 502,

		[System.ComponentModel.Description("five03VideoSensorMissingDefinition")]
		[EnumMember(Value = "video sensor")] 
		[XmlEnum("503")] 
		VideoSensor = 503,

		[System.ComponentModel.Description("five04DiverSightingFoundByDiverInRegistryMissingDefinition")]
		[EnumMember(Value = "diver sighting - (found by diver - in registry)")] 
		[XmlEnum("504")] 
		DiverSightingFoundByDiverInRegistry = 504,

		[System.ComponentModel.Description("five06PhysicalSnagMissingDefinition")]
		[EnumMember(Value = "physical snag")] 
		[XmlEnum("506")] 
		PhysicalSnag = 506,

		[System.ComponentModel.Description("five07ObservedSinkingMissingDefinition")]
		[EnumMember(Value = "observed sinking")] 
		[XmlEnum("507")] 
		ObservedSinking = 507,

		[System.ComponentModel.Description("five08ReportedSinkingMissingDefinition")]
		[EnumMember(Value = "Reported Sinking")] 
		[XmlEnum("508")] 
		ReportedSinking = 508,

		[System.ComponentModel.Description("five09NoneReportedMissingDefinition")]
		[EnumMember(Value = "None reported")] 
		[XmlEnum("509")] 
		NoneReported = 509,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum waterLevelEffect : int {
		[System.ComponentModel.Description("PartiallyCoveredAndPartiallyDryAtHighWater")]
		[EnumMember(Value = "Partly Submerged at High Water")] 
		[XmlEnum("1")] 
		PartlySubmergedAtHighWater = 1,

		[System.ComponentModel.Description("NotCoveredAtHighWaterUnderAverageMeteorologicalConditions")]
		[EnumMember(Value = "Always Dry")] 
		[XmlEnum("2")] 
		AlwaysDry = 2,

		[System.ComponentModel.Description("threeAlwaysUnderWaterMissingDefinition")]
		[EnumMember(Value = "always under water/")] 
		[XmlEnum("3")] 
		AlwaysUnderWater = 3,

		[System.ComponentModel.Description("ExpressionIntendedToIndicateAnAreaOfAReefOrOtherProjectionFromTheBottomOfABodyOfWaterWhichPeriodicallyExtendsAboveAndIsSubmergedBelowTheSurfaceAlsoReferredToAsDriesOrUncovers")]
		[EnumMember(Value = "Covers and Uncovers")] 
		[XmlEnum("4")] 
		CoversAndUncovers = 4,

		[System.ComponentModel.Description("FlushWithOrWashedByTheWavesAtLowWaterUnderAverageMeteorologicalConditions")]
		[EnumMember(Value = "Awash")] 
		[XmlEnum("5")] 
		Awash = 5,

		[System.ComponentModel.Description("sixSubjectToInundationOrMissingDefinition")]
		[EnumMember(Value = "subject to inundation or")] 
		[XmlEnum("6")] 
		SubjectToInundationOr = 6,

		[System.ComponentModel.Description("RestingOrMovingOnTheSurfaceOfALiquidWithoutSinking")]
		[EnumMember(Value = "Floating")] 
		[XmlEnum("7")] 
		Floating = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum boundaryStatusType : int {
		[System.ComponentModel.Description("five01DefiniteMissingDefinition")]
		[EnumMember(Value = "definite")] 
		[XmlEnum("501")] 
		Definite = 501,

		[System.ComponentModel.Description("five02IndefiniteMissingDefinition")]
		[EnumMember(Value = "indefinite")] 
		[XmlEnum("502")] 
		Indefinite = 502,

		[System.ComponentModel.Description("HasNotBeenDefinedByEitherOfTheAdjoiningAuthorities")]
		[EnumMember(Value = "no defined boundary")] 
		[XmlEnum("504")] 
		NoDefinedBoundary = 504,

		[System.ComponentModel.Description("BoundaryHasNotBeenRatified")]
		[EnumMember(Value = "Not Yet Ratified")] 
		[XmlEnum("599")] 
		NotYetRatified = 599,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalGeneration : int {
		[System.ComponentModel.Description("ActivatedByRadioSignal")]
		[EnumMember(Value = "Radio Activated")] 
		[XmlEnum("5")] 
		RadioActivated = 5,

		[System.ComponentModel.Description("ActivatedByMakingACallToAMannedStation")]
		[EnumMember(Value = "Call Activated")] 
		[XmlEnum("6")] 
		CallActivated = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum speciesGrouping : int {
		[System.ComponentModel.Description("AnyOfAnOrderCetaceaOfAquaticMostlyMarineMammalsThatIncludesTheWhalesDolphinsPorpoisesAndRelatedFormsAndThatHaveATorpedoShapedNearlyHairlessBodyPaddleShapedForelimbsButNoHindLimbsOneOrTwoNaresOpeningExternallyAtTheTopOfTheHeadAndAHorizontallyFlattenedTailUsedForLocomotion")]
		[EnumMember(Value = "Cetacean")] 
		[XmlEnum("501")] 
		Cetacean = 501,

		[System.ComponentModel.Description("AnyOfAnOrderOrSuborderPinnipediaOfAquaticCarnivorousMammalsSuchAsASealOrWalrusWithAllFourLimbsModifiedIntoFlippers")]
		[EnumMember(Value = "Pinniped")] 
		[XmlEnum("502")] 
		Pinniped = 502,

		[System.ComponentModel.Description("VertebrateColdBloodedAnimalWithGillsLivingInWater")]
		[EnumMember(Value = "Fish")] 
		[XmlEnum("503")] 
		Fish = 503,

		[System.ComponentModel.Description("AnyOfAnOrderTestudinesSynonymCheloniaOfTerrestrialFreshwaterAndMarineReptilesThatHaveAToothlessHornyBeakAndAShellOfBonyDermalPlatesUsuallyCoveredWithHornyShieldsEnclosingTheTrunkAndIntoWhichTheHeadLimbsAndTailUsuallyMayBeWithdrawn")]
		[EnumMember(Value = "Turtle")] 
		[XmlEnum("504")] 
		Turtle = 504,

		[System.ComponentModel.Description("AnyOfAClassAvesOfWarmBloodedVertebratesDistinguishedByHavingTheBodyMoreOrLessCompletelyCoveredWithFeathersAndTheForelimbsModifiedAsWings")]
		[EnumMember(Value = "Bird")] 
		[XmlEnum("505")] 
		Bird = 505,

		[System.ComponentModel.Description("AnyOfAnOrderSireniaOfAquaticHerbivorousMammalsSuchAsAManateeDugongOrStellerSSeaCowThatHaveLargeForelimbsResemblingPaddlesNoHindLimbsAndAFlattenedTailResemblingAFin")]
		[EnumMember(Value = "Sirenian")] 
		[XmlEnum("506")] 
		Sirenian = 506,

		[System.ComponentModel.Description("five07OtterAnimalMissingDefinition")]
		[EnumMember(Value = "Otter (animal)")] 
		[XmlEnum("507")] 
		OtterAnimal = 507,

		[System.ComponentModel.Description("ALargeCreamyWhiteCarnivorousBearUrsusMaritimusSynonymThalarctosMaritimusThatInhabitsArcticRegions")]
		[EnumMember(Value = "Polar bear")] 
		[XmlEnum("508")] 
		PolarBear = 508,

		[System.ComponentModel.Description("AnyOfNumerousVenomousAquaticChieflyViviparousElapidSnakesOfWarmSeas")]
		[EnumMember(Value = "Sea snake")] 
		[XmlEnum("509")] 
		SeaSnake = 509,

		[System.ComponentModel.Description("AReefOftenOfLargeExtentComposedChieflyOfCoralAndItsDerivatives")]
		[EnumMember(Value = "Coral Reef")] 
		[XmlEnum("510")] 
		CoralReef = 510,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfReportingRadioCallingInPoint : int {
		[System.ComponentModel.Description("five01ReportingRadioCallingInPointMissingDefinition")]
		[EnumMember(Value = "Reporting/Radio calling in point")] 
		[XmlEnum("501")] 
		ReportingRadioCallingInPoint = 501,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFishingFacility : int {
		[System.ComponentModel.Description("PolesOrStakesPlacedInShallowWaterToOutlineAFishingGroundOrToCatchFish")]
		[EnumMember(Value = "Fishing Stake")] 
		[XmlEnum("1")] 
		FishingStake = 1,

		[System.ComponentModel.Description("AStructureUsuallyPortableForCatchingFish")]
		[EnumMember(Value = "Fish Trap")] 
		[XmlEnum("2")] 
		FishTrap = 2,

		[System.ComponentModel.Description("AFenceOfStakesOrStonesSetInARiverOrAlongTheShoreToTrapFish")]
		[EnumMember(Value = "Fish Weir")] 
		[XmlEnum("3")] 
		FishWeir = 3,

		[System.ComponentModel.Description("ANetBuiltAtSeaForCatchingTunny")]
		[EnumMember(Value = "Tunny Net")] 
		[XmlEnum("4")] 
		TunnyNet = 4,
	}

	public static class CodeList
	{
	}

	namespace ComplexAttributes {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class qRouteChannelWidth {
			[XmlElement("rightQRouteWidth")]
			public required decimal rightQRouteWidth {get;set;} = default;
		}

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

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class multiplicityOfFeatures {
			[XmlElement("numberOfFeatures")]
			public int? numberOfFeatures {get;set;} = default;

			public bool ShouldSerializenumberOfFeatures() { return numberOfFeatures.HasValue; }

			[XmlElement("multiplicityKnown")]
			public required Boolean multiplicityKnown {get;set;} = false;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("linkage")]
			public required String linkage {get;set;} = string.Empty;

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[XmlElement("nameUsage")]
			[EnumerationValue([1,2])]
			public nameUsage? nameUsage {get;set;} = default;

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }

			[XmlElement("name")]
			public required String name {get;set;} = string.Empty;

			[XmlElement("language")]
			public required String language {get;set;} = string.Empty;
		}

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

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class altitudeRange {
			[XmlElement("minimumAltitude")]
			public required int minimumAltitude {get;set;} = default;

			[XmlElement("maximumAltitude")]
			public required int maximumAltitude {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class altitude {
			[XmlElement("minimumAltitude")]
			public required int minimumAltitude {get;set;} = default;

			[XmlElement("maximumAltitude")]
			public required int maximumAltitude {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lastSourceInformation {
			[XmlElement("lastSensor")]
			[EnumerationValue([501,502,503,504,506,509])]
			public lastSensor? lastSensor {get;set;} = default;

			public bool ShouldSerializelastSensor() { return lastSensor.HasValue; }

			[XmlElement("lastSource")]
			public String? lastSource {get;set;} = default;

			public bool ShouldSerializelastSource() { return !string.IsNullOrEmpty(lastSource); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("language")]
			public required String language {get;set;} = string.Empty;

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

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class firstSourceInformation {
			[XmlElement("firstSensor")]
			[EnumerationValue([501,502,503,504,506,509])]
			public required firstSensor firstSensor {get;set;} = default;

			[XmlElement("firstSource")]
			public String? firstSource {get;set;} = default;

			public bool ShouldSerializefirstSource() { return !string.IsNullOrEmpty(firstSource); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalClearanceFixed {
			[XmlElement("horizontalClearanceValue")]
			public required decimal horizontalClearanceValue {get;set;} = default;

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty {
			[XmlElement("uncertaintyVariableFactor")]
			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }

			[XmlElement("uncertaintyFixed")]
			public required decimal uncertaintyFixed {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			[XmlElement("frequencyShoreStationReceives")]
			public int? frequencyShoreStationReceives {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }

			[XmlElement("frequencyShoreStationTransmits")]
			public required int frequencyShoreStationTransmits {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselMeasurementsSpecification {
			[XmlElement("vesselsCharacteristicsValue")]
			public required decimal vesselsCharacteristicsValue {get;set;} = default;

			[XmlElement("vesselsCharacteristics")]
			[EnumerationValue([1,2,3,4,6,10,11])]
			public required vesselsCharacteristics vesselsCharacteristics {get;set;} = default;

			[XmlElement("vesselsCharacteristicsUnit")]
			[EnumerationValue([1,3,4,5,6,7])]
			public required vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;} = default;

			[XmlElement("comparisonOperator")]
			[EnumerationValue([1,2,3,4,5,6])]
			public comparisonOperator? comparisonOperator {get;set;} = default;

			public bool ShouldSerializecomparisonOperator() { return comparisonOperator.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surfaceCharacteristics {
			[XmlElement("underlyingLayer")]
			public int? underlyingLayer {get;set;} = default;

			public bool ShouldSerializeunderlyingLayer() { return underlyingLayer.HasValue; }

			[XmlElement("natureOfSurfaceQualifyingTerms")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms {get;set;} = [];

			public bool ShouldSerializenatureOfSurfaceQualifyingTerms() { return natureOfSurfaceQualifyingTerms.Any(); }

			[XmlElement("natureOfSurface")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class magneticInformation {
			[XmlElement("strengthOfMagneticAnomaly")]
			[EnumerationValue([501,502,503,504])]
			public strengthOfMagneticAnomaly? strengthOfMagneticAnomaly {get;set;} = default;

			public bool ShouldSerializestrengthOfMagneticAnomaly() { return strengthOfMagneticAnomaly.HasValue; }

			[XmlElement("magneticIntensity")]
			public int? magneticIntensity {get;set;} = default;

			public bool ShouldSerializemagneticIntensity() { return magneticIntensity.HasValue; }

			[XmlElement("magneticAnomalyDetectorSignature")]
			[EnumerationValue([501,502,503,504])]
			public required magneticAnomalyDetectorSignature magneticAnomalyDetectorSignature {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class speed {
			[XmlElement("speedMinimum")]
			public decimal? speedMinimum {get;set;} = default;

			public bool ShouldSerializespeedMinimum() { return speedMinimum.HasValue; }

			[XmlElement("speedMaximum")]
			public required decimal speedMaximum {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalClearanceFixed {
			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("verticalClearanceValue")]
			public required decimal verticalClearanceValue {get;set;} = default;
		}

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
			public required String sourceID {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty {
			[XmlElement("uncertaintyFixed")]
			public required decimal uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation {
			[XmlElement("orientationValue")]
			public required decimal orientationValue {get;set;} = default;

			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionHeading {
			[XmlElement("headingDownBearing")]
			public required decimal headingDownBearing {get;set;} = default;

			[XmlElement("headingUpBearing")]
			public required decimal headingUpBearing {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class flightLevel {
			[XmlElement("minimumFlightLevel")]
			public required int minimumFlightLevel {get;set;} = default;

			[XmlElement("maximumFlightLevel")]
			public required int maximumFlightLevel {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselSpeedLimit {
			[XmlElement("speedUnits")]
			[EnumerationValue([2,3,4])]
			public required speedUnits speedUnits {get;set;} = default;

			[XmlElement("vesselClass")]
			public String? vesselClass {get;set;} = default;

			public bool ShouldSerializevesselClass() { return !string.IsNullOrEmpty(vesselClass); }

			[XmlElement("speedLimit")]
			public required decimal speedLimit {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[XmlElement("dateStart")]
			public required String dateStart {get;set;} = string.Empty;

			[XmlElement("dateEnd")]
			public required String dateEnd {get;set;} = string.Empty;

			[XmlElement("periodicDateEnd")]
			public required String periodicDateEnd {get;set;} = string.Empty;

			[XmlElement("periodicDateStart")]
			public required String periodicDateStart {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class shapeInformation {
			[XmlElement("text")]
			public required String text {get;set;} = string.Empty;

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class signalSequence {
			[XmlElement("signalStatus")]
			[EnumerationValue([1,2])]
			public required signalStatus signalStatus {get;set;} = default;

			[XmlElement("signalDuration")]
			public required decimal signalDuration {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorInformation {
			[XmlElement("text")]
			public required String text {get;set;} = string.Empty;

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionalCharacter {
			[XmlElement("orientation")]
			public required orientation orientation {get;set;} = default;

			[XmlElement("moireEffect")]
			public Boolean? moireEffect {get;set;} = default;

			public bool ShouldSerializemoireEffect() { return moireEffect.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo {
			[XmlElement("sectorLineLength")]
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }

			[XmlElement("sectorBearing")]
			public required decimal sectorBearing {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne {
			[XmlElement("sectorLineLength")]
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }

			[XmlElement("sectorBearing")]
			public required decimal sectorBearing {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class topmark {
			[XmlElement("topmarkDaymarkShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33])]
			public required topmarkDaymarkShape topmarkDaymarkShape {get;set;} = default;

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public colour? colour {get;set;} = default;

			public bool ShouldSerializecolour() { return colour.HasValue; }

			[XmlElement("shapeInformation")]
			public List<shapeInformation> shapeInformation {get;set;} = [];

			public bool ShouldSerializeshapeInformation() { return shapeInformation.Any(); }
		}

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

			[XmlElement("lightCharacteristic")]
			[EnumerationValue([1,2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,25,26,27,28,29])]
			public required lightCharacteristic lightCharacteristic {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalClearanceSafe {
			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("verticalClearanceValue")]
			public required decimal verticalClearanceValue {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimit {
			[XmlElement("sectorLimitOne")]
			public required sectorLimitOne sectorLimitOne {get;set;} = default;

			[XmlElement("sectorLimitTwo")]
			public required sectorLimitTwo sectorLimitTwo {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lightSector {
			[XmlElement("sectorLimit")]
			public sectorLimit? sectorLimit {get;set;} = default;

			public bool ShouldSerializesectorLimit() { return sectorLimit!=default; }

			[XmlElement("sectorInformation")]
			public List<sectorInformation> sectorInformation {get;set;} = [];

			public bool ShouldSerializesectorInformation() { return sectorInformation.Any(); }

			[XmlElement("lightVisibility")]
			[EnumerationValue([1,2,3,4,5,6,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

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

			[XmlElement("colour")]
			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }
		}

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

			[XmlElement("lightCharacteristic")]
			[EnumerationValue([1,2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,25,26,27,28,29])]
			public required lightCharacteristic lightCharacteristic {get;set;} = default;

			[XmlElement("signalGroup")]
			public List<String> signalGroup {get;set;} = [];

			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }
		}

	}
}

namespace S100Framework.DomainModel.S501 {
	using ComplexAttributes;

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
			public override string Code => nameof(ReferenceToAPublication);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ReferenceToAPublication._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}
	}
	namespace FeatureTypes {
		using System.Xml;

		/// <summary>
		/// An installation buoy is a buoy used for loading tankers with gas or oil.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InstallationBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("product")]
			[EnumerationValue([1,2,18,19])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

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

			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([7,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("categoryOfInstallationBuoy")]
			[EnumerationValue([1,2])]
			public categoryOfInstallationBuoy? categoryOfInstallationBuoy {get;set;} = default;

			public bool ShouldSerializecategoryOfInstallationBuoy() { return categoryOfInstallationBuoy.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(InstallationBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InstallationBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => InstallationBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A water area whose depth is within a defined range of values.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DepthArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("depthRangeMaximumValue")]
			public required decimal depthRangeMaximumValue {get;set;} = default;

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("depthRangeMinimumValue")]
			public required decimal depthRangeMinimumValue {get;set;} = default;

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[JsonIgnore]
			public override string Code => nameof(DepthArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DepthArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DepthArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DepthArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioCallingInPoint : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("categoryOfReportingRadioCallingInPoint")]
			[EnumerationValue([501])]
			public categoryOfReportingRadioCallingInPoint? categoryOfReportingRadioCallingInPoint {get;set;} = default;

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

			[XmlElement("status")]
			[EnumerationValue([1,3,4,5,6,7,9,501])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("trafficFlow")]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow trafficFlow {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(RadioCallingInPoint);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadioCallingInPoint._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadioCallingInPoint._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("categoryOfPatrolArea")]
			[EnumerationValue([501,502])]
			public required categoryOfPatrolArea categoryOfPatrolArea {get;set;} = default;

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,501])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(PatrolArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => PatrolArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => PatrolArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => PatrolArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,2,5,7,9,12])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("categoryOfCheckpoint")]
			[EnumerationValue([1,501])]
			public categoryOfCheckpoint? categoryOfCheckpoint {get;set;} = default;

			public bool ShouldSerializecategoryOfCheckpoint() { return categoryOfCheckpoint.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(Checkpoint);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Checkpoint._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Checkpoint._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Checkpoint._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area which is managed and/or monitored by a controlling authority to protect the marine environment and ensure restrictions applicable to that area, or marine activities carried out within the area conform to current legislation/regulations.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MarineManagementArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public restriction? restriction {get;set;} = default;

			public bool ShouldSerializerestriction() { return restriction.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("speciesGrouping")]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510])]
			public List<speciesGrouping> speciesGrouping {get;set;} = [];

			public bool ShouldSerializespeciesGrouping() { return speciesGrouping.Any(); }

			[XmlElement("nationalMaritimeAuthority")]
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[XmlElement("jurisdiction")]
			[EnumerationValue([1,2,2])]
			public required jurisdiction jurisdiction {get;set;} = default;

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("categoryofMarineProtectedArea")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public categoryofMarineProtectedArea? categoryofMarineProtectedArea {get;set;} = default;

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

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,13,14,16,17,519])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("categoryofRestrictions")]
			[EnumerationValue([4,5,6,7,10,20,22,23,27,28,31,32])]
			public List<categoryofRestrictions> categoryofRestrictions {get;set;} = [];

			public bool ShouldSerializecategoryofRestrictions() { return categoryofRestrictions.Any(); }

			[XmlElement("species")]
			public List<String> species {get;set;} = [];

			public bool ShouldSerializespecies() { return species.Any(); }

			[JsonIgnore]
			public override string Code => nameof(MarineManagementArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MarineManagementArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MarineManagementArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MarineManagementArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public required decimal valueOfDepthContour {get;set;} = default;

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
			public override string Code => nameof(DepthContour);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DepthContour._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DepthContour._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DepthContour._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public override string Code => nameof(EnvironmentallySensitiveSeaArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => EnvironmentallySensitiveSeaArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => EnvironmentallySensitiveSeaArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => EnvironmentallySensitiveSeaArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A route with a specially prepared surface that is intended for use by wheeled vehicles or pedestrians.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Road : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("natureOfConstruction")]
			[EnumerationValue([4,5])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

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

			[XmlElement("categoryOfRoad")]
			[EnumerationValue([1,2,3,4,5,6])]
			public categoryOfRoad? categoryOfRoad {get;set;} = default;

			public bool ShouldSerializecategoryOfRoad() { return categoryOfRoad.HasValue; }

			[XmlElement("condition")]
			[EnumerationValue([1,2,5,501])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,4,6,7,8,12,13,14])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(Road);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Road._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Road._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Road._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([5])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(River);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => River._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => River._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => River._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public required String depthRestriction {get;set;} = string.Empty;

			[XmlElement("depthUnits")]
			[EnumerationValue([1])]
			public depthUnits? depthUnits {get;set;} = default;

			public bool ShouldSerializedepthUnits() { return depthUnits.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("typeofMilitaryActivity")]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,516,517,518,519,520,521,522,523,524,525,526,527,528,529,530,531,532,533,534,535,536,537,538,539,540,541,542,543,544,545,546,547,598,599])]
			public List<typeofMilitaryActivity> typeofMilitaryActivity {get;set;} = [];

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

			[XmlElement("categoryofMilitaryPracticeArea")]
			[EnumerationValue([2,3,4,5,501,502,503,506,507,508,510,599])]
			public List<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea {get;set;} = [];

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

			[XmlElement("areaCategory")]
			[EnumerationValue([501,502])]
			public areaCategory? areaCategory {get;set;} = default;

			public bool ShouldSerializeareaCategory() { return areaCategory.HasValue; }

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44,501])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("status")]
			[EnumerationValue([1,2,5,6,7,16,17,501,503,517,520])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[JsonIgnore]
			public override string Code => nameof(MilitaryPracticeArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MilitaryPracticeArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MilitaryPracticeArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public override string Code => nameof(DiscolouredWater);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DiscolouredWater._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DiscolouredWater._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DiscolouredWater._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("categoryOfCardinalMark")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfCardinalMark categoryOfCardinalMark {get;set;} = default;

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("status")]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

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
			public override string Code => nameof(CardinalBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CardinalBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CardinalBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A safe water buoy is used to indicate that there is navigable water around the mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBuoy : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

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

			[XmlElement("status")]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

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

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

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

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(SafeWaterBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SafeWaterBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("categoryOfRadioStation")]
			[EnumerationValue([5,10,11,14,19,20])]
			public List<categoryOfRadioStation> categoryOfRadioStation {get;set;} = [];

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
			public override string Code => nameof(RadioStation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadioStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public override string Code => nameof(MilitaryExerciseAirspace);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MilitaryExerciseAirspace._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MilitaryExerciseAirspace._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MilitaryExerciseAirspace._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([502,504,520])]
			public List<status> status {get;set;} = [];

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
			public override string Code => nameof(ContiguousZone);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ContiguousZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ContiguousZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ContiguousZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public required String nationality {get;set;} = string.Empty;

			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("status")]
			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[JsonIgnore]
			public override string Code => nameof(NormalBaseline);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NormalBaseline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => NormalBaseline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NormalBaseline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,7,13])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,16,17,18,20,23,24,25,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("categoryOfCable")]
			[EnumerationValue([1,7,10])]
			public List<categoryOfCable> categoryOfCable {get;set;} = [];

			public bool ShouldSerializecategoryOfCable() { return categoryOfCable.Any(); }

			[JsonIgnore]
			public override string Code => nameof(CableArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CableArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CableArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CableArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The Continental Shelf of a coastal State comprises the seabed and subsoil of the submarine areas that extend beyond its Territorial Sea throughout the natural prolongation of its land territory to the outer edge of the continental margin, or to a distance of 200 nautical miles from the baselines from which the breadth of the Territorial Sea is measured where the outer edge of the continental margin does not extend up to that distance.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContinentalShelfArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

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
			public override string Code => nameof(ContinentalShelfArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ContinentalShelfArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ContinentalShelfArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ContinentalShelfArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(InternalWaters);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InternalWaters._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => InternalWaters._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => InternalWaters._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("jurisdiction")]
			[EnumerationValue([1,2,3])]
			public required jurisdiction jurisdiction {get;set;} = default;

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
			public override string Code => nameof(AdministrationArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AdministrationArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AdministrationArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AdministrationArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,3,4,6,7,8,12,14,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(Bollard);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Bollard._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Bollard._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Bollard._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("categoryOfDolphin")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfDolphin categoryOfDolphin {get;set;} = default;

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,12,14,18])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

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

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,6,7])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[JsonIgnore]
			public override string Code => nameof(Dolphin);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Dolphin._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Dolphin._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Dolphin._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,2,4,7])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(RadarRange);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadarRange._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadarRange._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBeacon : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("condition")]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("beaconShape")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape beaconShape {get;set;} = default;

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

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

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(IsolatedDangerBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => IsolatedDangerBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(IsolatedDangerBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => IsolatedDangerBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

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
			public override string Code => nameof(SubmarineTransitLane);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SubmarineTransitLane._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SubmarineTransitLane._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SubmarineTransitLane._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public override string Code => nameof(MaritimeSafetyInformationArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MaritimeSafetyInformationArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MaritimeSafetyInformationArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MaritimeSafetyInformationArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("heightLengthUnits")]
			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlElement("catagoryOfAirspaceRestriction")]
			[EnumerationValue([501,502,503])]
			public catagoryOfAirspaceRestriction? catagoryOfAirspaceRestriction {get;set;} = default;

			public bool ShouldSerializecatagoryOfAirspaceRestriction() { return catagoryOfAirspaceRestriction.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(AirspaceRestriction);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AirspaceRestriction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AirspaceRestriction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AirspaceRestriction._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Measured or charted depth of water (may be a drying height), or the measurement of such a depth, which has been reduced to a vertical datum.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Sounding : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([18])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,3,4,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

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
			public override string Code => nameof(Sounding);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Sounding._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Sounding._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Sounding._primitives;
			public static Primitives[] _primitives => [
				Primitives.pointSet
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

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
			public override string Code => nameof(TrafficSeparationSchemeBoundary);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeBoundary._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeBoundary._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeBoundary._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DumpingGround : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("categoryOfDumpingGround")]
			[EnumerationValue([2,3,4,5,6])]
			public List<categoryOfDumpingGround> categoryOfDumpingGround {get;set;} = [];

			public bool ShouldSerializecategoryOfDumpingGround() { return categoryOfDumpingGround.Any(); }

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,2,4,6,7])]
			public List<status> status {get;set;} = [];

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
			public override string Code => nameof(DumpingGround);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DumpingGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DumpingGround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DumpingGround._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A defined area on land (including any buildings, installations and equipment) intended to be used either wholly or in part for the arrival, departure and surface movement of aircraft.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AirportAirfield : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("categoryOfAirportAirfield")]
			[EnumerationValue([1,2,3,4,5,6,8,9])]
			public List<categoryOfAirportAirfield> categoryOfAirportAirfield {get;set;} = [];

			public bool ShouldSerializecategoryOfAirportAirfield() { return categoryOfAirportAirfield.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("condition")]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("runwayLength")]
			public int? runwayLength {get;set;} = default;

			public bool ShouldSerializerunwayLength() { return runwayLength.HasValue; }

			[XmlElement("heightLengthUnits")]
			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

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

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

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

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,6,7,8,12,14])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[JsonIgnore]
			public override string Code => nameof(AirportAirfield);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AirportAirfield._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AirportAirfield._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AirportAirfield._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Areas over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FoulGround : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([13,18,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("valueOfSounding")]
			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

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
			public override string Code => nameof(FoulGround);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FoulGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FoulGround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FoulGround._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAirObstruction : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("pictorialRepresentation")]
			public required String pictorialRepresentation {get;set;} = string.Empty;

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

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("heightLengthUnits")]
			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlElement("lightVisibility")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

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

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("relativeVerticalAccuracy")]
			public decimal? relativeVerticalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeVerticalAccuracy() { return relativeVerticalAccuracy.HasValue; }

			[XmlElement("exhibitionConditionOfLight")]
			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("colour")]
			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[JsonIgnore]
			public override string Code => nameof(LightAirObstruction);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightAirObstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightAirObstruction._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

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
			public override string Code => nameof(MooringBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => MooringBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A concreted mass of stony material or coral which dries, is awash or is below the water surface.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnderwaterAwashRock : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("valueOfSounding")]
			public required decimal valueOfSounding {get;set;} = default;

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("waterLevelEffect")]
			[EnumerationValue([3,4,5])]
			public required waterLevelEffect waterLevelEffect {get;set;} = default;

			[XmlElement("surroundingDepth")]
			public decimal? surroundingDepth {get;set;} = default;

			public bool ShouldSerializesurroundingDepth() { return surroundingDepth.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("natureOfSurface")]
			[EnumerationValue([14,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("displayUncertainties")]
			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[XmlElement("expositionOfSounding")]
			[EnumerationValue([1,2])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

			[XmlElement("defaultClearanceDepth")]
			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

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

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(UnderwaterAwashRock);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => UnderwaterAwashRock._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => UnderwaterAwashRock._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => UnderwaterAwashRock._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A single continuous rope-like bundle consisting of multiple strands of fiber, plastic, metal, and/or glass, which is supported by structures such as poles or pylons and passing over or nearby navigable waters.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableOverhead : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("condition")]
			[EnumerationValue([1,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,4,5,7,12,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("categoryOfCable")]
			[EnumerationValue([1,3])]
			public categoryOfCable? categoryOfCable {get;set;} = default;

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

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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
			public override string Code => nameof(CableOverhead);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CableOverhead._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CableOverhead._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CableOverhead._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Designated airspace within which some or all aircraft may be subjected to air traffic control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ControlledAirspace : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("controlledAirspaceClassDesignation")]
			[EnumerationValue([501,502,503,504,505,506,507])]
			public controlledAirspaceClassDesignation? controlledAirspaceClassDesignation {get;set;} = default;

			public bool ShouldSerializecontrolledAirspaceClassDesignation() { return controlledAirspaceClassDesignation.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("categoryOfControlledAirspace")]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,516,517,518,519,520,521,522])]
			public categoryOfControlledAirspace? categoryOfControlledAirspace {get;set;} = default;

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

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("heightLengthUnits")]
			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

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
			public override string Code => nameof(ControlledAirspace);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ControlledAirspace._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ControlledAirspace._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ControlledAirspace._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// In marine navigation, anything that hinders or prevents movement, particularly anything that endangers or prevents passage of a vessel. The term is usually used to refer to an isolated danger to navigation, such as a sunken rock or pinnacle.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Obstruction : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,11,12])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("controllingAuthority")]
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[XmlElement("product")]
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,502,503,505,506,507,508,509,510,511,513,514,515,516,517,519,520,521,522,523,524,525,526,527,528,529,530,531,532,533,534,535,536,537,540,541,542])]
			public List<product> product {get;set;} = [];

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

			[XmlElement("expositionOfSounding")]
			[EnumerationValue([1,2,3])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

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

			[XmlElement("soundingDatum")]
			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,519,522,523,524,525,526,527,531,532])]
			public soundingDatum? soundingDatum {get;set;} = default;

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

			[XmlElement("status")]
			[EnumerationValue([1,4,5,7,8,13,18,28,501,503,505,506,507,508,509,510,511,512,516,517,518])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("generalWaterDepth")]
			public int? generalWaterDepth {get;set;} = default;

			public bool ShouldSerializegeneralWaterDepth() { return generalWaterDepth.HasValue; }

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlElement("detectionDateRange")]
			public detectionDateRange? detectionDateRange {get;set;} = default;

			public bool ShouldSerializedetectionDateRange() { return detectionDateRange!=default; }

			[XmlElement("oprtor")]
			public String? oprtor {get;set;} = default;

			public bool ShouldSerializeoprtor() { return !string.IsNullOrEmpty(oprtor); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44,501])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("sonarSignalStrength")]
			[EnumerationValue([501,502,503,504])]
			public sonarSignalStrength? sonarSignalStrength {get;set;} = default;

			public bool ShouldSerializesonarSignalStrength() { return sonarSignalStrength.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("maximumPermittedDraught")]
			public decimal? maximumPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			[XmlElement("natureOfSurface")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.Any(); }

			[XmlElement("spuddedDate")]
			public String? spuddedDate {get;set;} = default;

			public bool ShouldSerializespuddedDate() { return !string.IsNullOrEmpty(spuddedDate); }

			[XmlElement("categoryOfObstruction")]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,12,13,14,15,16,17,18,19,20,21,22,23,501,502,503,504,506,508,509])]
			public categoryOfObstruction? categoryOfObstruction {get;set;} = default;

			public bool ShouldSerializecategoryOfObstruction() { return categoryOfObstruction.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("cardinalPointOrientation")]
			[EnumerationValue([501,502,503,504])]
			public cardinalPointOrientation? cardinalPointOrientation {get;set;} = default;

			public bool ShouldSerializecardinalPointOrientation() { return cardinalPointOrientation.HasValue; }

			[XmlElement("valueOfSounding")]
			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[XmlElement("waterLevelEffect")]
			[EnumerationValue([1,2,3,4,5,7])]
			public required waterLevelEffect waterLevelEffect {get;set;} = default;

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
			public override string Code => nameof(Obstruction);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Obstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Obstruction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Obstruction._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A water area in which fishing is frequently carried on.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FishingGround : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,5,6,7,8,14,16,17,28])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("restriction")]
			[EnumerationValue([1,2,4,5,6,8,9,10,11,12,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(FishingGround);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FishingGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FishingGround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FishingGround._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,4,5,6,7,8,12,18,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("categoryOfFishingFacility")]
			[EnumerationValue([1,2,3,4])]
			public categoryOfFishingFacility? categoryOfFishingFacility {get;set;} = default;

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
			public override string Code => nameof(FishingFacility);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FishingFacility._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FishingFacility._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FishingFacility._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("categoryOfRadioStation")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20,504,505,506,508,509,510])]
			public categoryOfRadioStation? categoryOfRadioStation {get;set;} = default;

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
			public override string Code => nameof(NavigationSystem);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NavigationSystem._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => NavigationSystem._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NavigationSystem._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A defined area where traffic lanes cross.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeCrossing : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

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

			[XmlElement("status")]
			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

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
			public override string Code => nameof(TrafficSeparationSchemeCrossing);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeCrossing._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeCrossing._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeCrossing._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("orientationValue")]
			public decimal? orientationValue {get;set;} = default;

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationSchemeLanePart);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeLanePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeLanePart._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeLanePart._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

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

			[XmlElement("restriction")]
			[EnumerationValue([2,4,6,8,9,10,12,17,18,19,20,21,22,23,24,27])]
			public List<restriction> restriction {get;set;} = [];

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
			public override string Code => nameof(TerritorialSeaArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TerritorialSeaArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TerritorialSeaArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TerritorialSeaArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("beaconShape")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape beaconShape {get;set;} = default;

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("categoryOfLateralMark")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfLateralMark categoryOfLateralMark {get;set;} = default;

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

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

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[JsonIgnore]
			public override string Code => nameof(LateralBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LateralBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LateralBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A station at which a visual/radio/radar marine watch is kept either continuously or at certain times only.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CoastGuardStation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,4,5,16,17])]
			public List<status> status {get;set;} = [];

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
			public override string Code => nameof(CoastGuardStation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CoastGuardStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CoastGuardStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CoastGuardStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

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
			public override string Code => nameof(SeparationZoneOrLine);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SeparationZoneOrLine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SeparationZoneOrLine._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SeparationZoneOrLine._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("bottomFeatureClassification")]
			[EnumerationValue([502,510])]
			public bottomFeatureClassification? bottomFeatureClassification {get;set;} = default;

			public bool ShouldSerializebottomFeatureClassification() { return bottomFeatureClassification.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(BottomFeature);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => BottomFeature._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => BottomFeature._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => BottomFeature._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[XmlElement("nationality")]
			public required String nationality {get;set;} = string.Empty;

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
			public override string Code => nameof(ArchipelagicBaseline);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ArchipelagicBaseline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ArchipelagicBaseline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ArchipelagicBaseline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("statusOfSmallBottomObject")]
			[EnumerationValue([504])]
			public statusOfSmallBottomObject? statusOfSmallBottomObject {get;set;} = default;

			public bool ShouldSerializestatusOfSmallBottomObject() { return statusOfSmallBottomObject.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("valueOfSounding")]
			public required decimal valueOfSounding {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SmallBottomObject);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SmallBottomObject._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SmallBottomObject._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SmallBottomObject._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public override string Code => nameof(ExclusiveEconomicZone);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ExclusiveEconomicZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ExclusiveEconomicZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ExclusiveEconomicZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A station with a transmitter emitting pulses of ultra-high frequency radio waves which are reflected by solid objects and are detected upon their return to the sending station.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarStation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,2,4,7,8])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("categoryOfRadarStation")]
			[EnumerationValue([1,2])]
			public categoryOfRadarStation? categoryOfRadarStation {get;set;} = default;

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
			public override string Code => nameof(RadarStation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RadarStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RadarStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RadarStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("divingActivity")]
			[EnumerationValue([501,502,503])]
			public divingActivity? divingActivity {get;set;} = default;

			public bool ShouldSerializedivingActivity() { return divingActivity.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(DivingLocation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DivingLocation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DivingLocation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DivingLocation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("categoryOfRestrictedArea")]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,18,19,20,21,22,23,24,25,27,28,29,30,31,32,501])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,9,18,28,501])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,39,42])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[JsonIgnore]
			public override string Code => nameof(RestrictedArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RestrictedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RestrictedArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RestrictedArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the seafloor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableSubmarine : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,4,13,18])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("categoryOfCable")]
			[EnumerationValue([1,6,7,9,10])]
			public categoryOfCable? categoryOfCable {get;set;} = default;

			public bool ShouldSerializecategoryOfCable() { return categoryOfCable.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("condition")]
			[EnumerationValue([1,5])]
			public condition? condition {get;set;} = default;

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
			public override string Code => nameof(CableSubmarine);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CableSubmarine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CableSubmarine._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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

			[XmlElement("status")]
			[EnumerationValue([7,13,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("sonarSignalStrength")]
			[EnumerationValue([501,502,503,504])]
			public sonarSignalStrength? sonarSignalStrength {get;set;} = default;

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

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("defaultClearanceDepth")]
			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

			[XmlElement("natureOfSurface")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }

			[XmlElement("orientationValue")]
			public decimal? orientationValue {get;set;} = default;

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			[XmlElement("typeOfWreck")]
			public String? typeOfWreck {get;set;} = default;

			public bool ShouldSerializetypeOfWreck() { return !string.IsNullOrEmpty(typeOfWreck); }

			[XmlElement("waterLevelEffect")]
			[EnumerationValue([1,2,3,4,5])]
			public required waterLevelEffect waterLevelEffect {get;set;} = default;

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("categoryOfWreck")]
			[EnumerationValue([1,2,3,4,5])]
			public categoryOfWreck? categoryOfWreck {get;set;} = default;

			public bool ShouldSerializecategoryOfWreck() { return categoryOfWreck.HasValue; }

			[XmlElement("qualityOfHorizontalMeasurement")]
			[EnumerationValue([4,5])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

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

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[XmlElement("cardinalPointOrientation")]
			[EnumerationValue([501,502,503,504])]
			public cardinalPointOrientation? cardinalPointOrientation {get;set;} = default;

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

			[XmlElement("product")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("displayUncertainties")]
			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[XmlElement("expositionOfSounding")]
			[EnumerationValue([1,2,3])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			public override string Code => nameof(Wreck);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Wreck._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Wreck._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Wreck._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([2,503])]
			public List<status> status {get;set;} = [];

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
			public override string Code => nameof(QRoute);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => QRoute._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => QRoute._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => QRoute._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("categoryOfCompleteness")]
			[EnumerationValue([501,502])]
			public required categoryOfCompleteness categoryOfCompleteness {get;set;} = default;

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
			public override string Code => nameof(CompletenessOfProductSpecification);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CompletenessOfProductSpecification._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CompletenessOfProductSpecification._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CompletenessOfProductSpecification._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A place where equipment for saving life at sea is maintained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RescueStation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("categoryOfRescueStation")]
			[EnumerationValue([1,2,4,5,6,7,8])]
			public List<categoryOfRescueStation> categoryOfRescueStation {get;set;} = [];

			public bool ShouldSerializecategoryOfRescueStation() { return categoryOfRescueStation.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(RescueStation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => RescueStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => RescueStation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => RescueStation._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("beaconShape")]
			[EnumerationValue([1,2,3,5,6,7])]
			public required beaconShape beaconShape {get;set;} = default;

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("categoryOfCardinalMark")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfCardinalMark categoryOfCardinalMark {get;set;} = default;

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("condition")]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			public override string Code => nameof(CardinalBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CardinalBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CardinalBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightVessel : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

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
			public override string Code => nameof(LightVessel);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightVessel._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightVessel._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public required String nationality {get;set;} = string.Empty;

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

			[XmlElement("status")]
			[EnumerationValue([1,5,6,7,501,502,504,519,521])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(FisheryZone);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FisheryZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FisheryZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FisheryZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([10,11])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("depthRangeMinimumValue")]
			public required decimal depthRangeMinimumValue {get;set;} = default;

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,8,11,12,13,16,17,18,19,20,21,23,25,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(DredgedArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DredgedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DredgedArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DredgedArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A route in a body of water where a ferry crosses from one shoreline to another.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FerryRoute : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,6,7,8,9,14])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("categoryOfFerry")]
			[EnumerationValue([1,2,3,5])]
			public List<categoryOfFerry> categoryOfFerry {get;set;} = [];

			public bool ShouldSerializecategoryOfFerry() { return categoryOfFerry.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[JsonIgnore]
			public override string Code => nameof(FerryRoute);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FerryRoute._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FerryRoute._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FerryRoute._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("gradientOfSlope")]
			[EnumerationValue([501,502,503,504,505])]
			public gradientOfSlope? gradientOfSlope {get;set;} = default;

			public bool ShouldSerializegradientOfSlope() { return gradientOfSlope.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("condition")]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

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

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,6,7,8,12,13,14,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("waterLevelEffect")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required waterLevelEffect waterLevelEffect {get;set;} = default;

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("categoryOfShorelineConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,20,22,23,501])]
			public categoryOfShorelineConstruction? categoryOfShorelineConstruction {get;set;} = default;

			public bool ShouldSerializecategoryOfShorelineConstruction() { return categoryOfShorelineConstruction.HasValue; }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			public override string Code => nameof(ShorelineConstruction);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ShorelineConstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => ShorelineConstruction._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => ShorelineConstruction._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([5,7])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("condition")]
			[EnumerationValue([1,3,5])]
			public condition? condition {get;set;} = default;

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
			public override string Code => nameof(CautionArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CautionArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CautionArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("trafficFlow")]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow trafficFlow {get;set;} = default;

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
			public required decimal depthRangeMinimumValue {get;set;} = default;

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,3,5,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,3,6,9,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("orientationValue")]
			public required decimal orientationValue {get;set;} = default;

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,6,7])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[JsonIgnore]
			public override string Code => nameof(DeepWaterRoutePart);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRoutePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoutePart._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DeepWaterRoutePart._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public required orientation orientation {get;set;} = default;

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("speed")]
			public required speed speed {get;set;} = default;

			[XmlElement("status")]
			[EnumerationValue([5])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(CurrentNonGravitational);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CurrentNonGravitational._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CurrentNonGravitational._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CurrentNonGravitational._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("categoryOfCoverage")]
			[EnumerationValue([1,2])]
			public categoryOfCoverage? categoryOfCoverage {get;set;} = default;

			public bool ShouldSerializecategoryOfCoverage() { return categoryOfCoverage.HasValue; }

			[XmlElement("optimumDisplayScale")]
			public required int optimumDisplayScale {get;set;} = default;

			[XmlElement("minimumDisplayScale")]
			public required int minimumDisplayScale {get;set;} = default;

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("maximumDisplayScale")]
			public required int maximumDisplayScale {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(DataCoverage);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DataCoverage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("waterLevelEffect")]
			[EnumerationValue([3,4,5])]
			public required waterLevelEffect waterLevelEffect {get;set;} = default;

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
			public override string Code => nameof(SeabedArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SeabedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SeabedArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SeabedArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("categoryOfSpecialPurposeMark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,42,43,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("status")]
			[EnumerationValue([1,2,5,7,8,18,503])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

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
			public override string Code => nameof(SpecialPurposeGeneralBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SpecialPurposeGeneralBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightSectored : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

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

			[XmlElement("categoryOfLight")]
			[EnumerationValue([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[XmlElement("exhibitionConditionOfLight")]
			[EnumerationValue([1,2,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

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
			public required String pictorialRepresentation {get;set;} = string.Empty;

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("heightLengthUnits")]
			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("sectorCharacteristics")]
			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];

			public bool ShouldSerializesectorCharacteristics() { return sectorCharacteristics.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("signalGeneration")]
			[EnumerationValue([5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			public override string Code => nameof(LightSectored);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightSectored._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightSectored._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public override string Code => nameof(IceLine);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IceLine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => IceLine._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => IceLine._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area in which vessels or seaplanes anchor or may anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorageArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("restriction")]
			[EnumerationValue([2,3,4,5,6,8,9,10,11,12,13,15,16,17,18,19,20,21,23,24,27,39])]
			public List<restriction> restriction {get;set;} = [];

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

			[XmlElement("categoryOfAnchorage")]
			[EnumerationValue([1,2,3,5,6,7,9,10,14,15])]
			public List<categoryOfAnchorage> categoryOfAnchorage {get;set;} = [];

			public bool ShouldSerializecategoryOfAnchorage() { return categoryOfAnchorage.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,5,6,7,8,9,14])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("categoryOfCargo")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[JsonIgnore]
			public override string Code => nameof(AnchorageArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AnchorageArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

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

			[XmlElement("status")]
			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("categoryOfLateralMark")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfLateralMark categoryOfLateralMark {get;set;} = default;

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(LateralBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LateralBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LateralBuoy._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("restriction")]
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationSchemeRoundabout);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeRoundabout._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeRoundabout._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TrafficSeparationSchemeRoundabout._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The Deep Water route centreline indicates the centreline of a route, the width of which is not explicitly defined.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DeepWaterRouteCentreline : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,6,7])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlElement("orientationValue")]
			public required decimal orientationValue {get;set;} = default;

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("trafficFlow")]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow trafficFlow {get;set;} = default;

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

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
			public required Boolean basedOnFixedMarks {get;set;} = false;

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,3,5,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[JsonIgnore]
			public override string Code => nameof(DeepWaterRouteCentreline);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRouteCentreline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRouteCentreline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DeepWaterRouteCentreline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([6,7,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

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

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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
			public override string Code => nameof(LightFloat);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightFloat._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightFloat._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("signalGeneration")]
			[EnumerationValue([5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("multiplicityOfFeatures")]
			public required multiplicityOfFeatures multiplicityOfFeatures {get;set;} = default;

			[XmlElement("exhibitionConditionOfLight")]
			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("relativeHorizontalAccuracy")]
			public decimal? relativeHorizontalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeHorizontalAccuracy() { return relativeHorizontalAccuracy.HasValue; }

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("majorLight")]
			public Boolean? majorLight {get;set;} = default;

			public bool ShouldSerializemajorLight() { return majorLight.HasValue; }

			[XmlElement("lightVisibility")]
			[EnumerationValue([1,2])]
			public lightVisibility? lightVisibility {get;set;} = default;

			public bool ShouldSerializelightVisibility() { return lightVisibility.HasValue; }

			[XmlElement("flareBearing")]
			public int? flareBearing {get;set;} = default;

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

			[XmlElement("heightLengthUnits")]
			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[XmlElement("categoryOfLight")]
			[EnumerationValue([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[XmlElement("rythmOfLight")]
			public required rythmOfLight rythmOfLight {get;set;} = default;

			[XmlElement("colour")]
			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			public override string Code => nameof(LightAllAround);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LightAllAround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LightAllAround._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The line where shore and water meet. Shoreline and coastline are generally used synonymously.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Coastline : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,6,7,8,11,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("categoryOfCoastline")]
			[EnumerationValue([1,2,6,7,8,10])]
			public categoryOfCoastline? categoryOfCoastline {get;set;} = default;

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

			[XmlElement("natureOfSurface")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17])]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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
			public override string Code => nameof(Coastline);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Coastline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Coastline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Coastline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A geographically defined part of the sea or other navigable waters. It may be specified within its limits by its proper name.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeaAreaNamedWaterArea : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("categoryOfSeaArea")]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56])]
			public categoryOfSeaArea? categoryOfSeaArea {get;set;} = default;

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

			[XmlElement("gradient")]
			[EnumerationValue([501,502,503,504,505])]
			public gradient? gradient {get;set;} = default;

			public bool ShouldSerializegradient() { return gradient.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("qualityOfHorizontalMeasurement")]
			[EnumerationValue([4])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(SeaAreaNamedWaterArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SeaAreaNamedWaterArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SeaAreaNamedWaterArea._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SeaAreaNamedWaterArea._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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
			public override string Code => nameof(DropZone);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DropZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DropZone._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DropZone._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A mechanical device for conveying bulk material or people using an endless moving belt or series of rollers.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Conveyor : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("categoryOfConveyor")]
			[EnumerationValue([1,2,3,4])]
			public categoryOfConveyor? categoryOfConveyor {get;set;} = default;

			public bool ShouldSerializecategoryOfConveyor() { return categoryOfConveyor.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

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

			[XmlElement("status")]
			[EnumerationValue([4,12])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("liftingCapacity")]
			public decimal? liftingCapacity {get;set;} = default;

			public bool ShouldSerializeliftingCapacity() { return liftingCapacity.HasValue; }

			[XmlElement("verticalClearanceFixed")]
			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			public bool ShouldSerializeverticalClearanceFixed() { return verticalClearanceFixed!=default; }

			[XmlElement("verticalDatum")]
			[EnumerationValue([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("product")]
			[EnumerationValue([4,5,6,10,11,12,13,14,15,16,17,22,25])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(Conveyor);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => Conveyor._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => Conveyor._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => Conveyor._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("boundaryStatusType")]
			[EnumerationValue([501,502,504,599])]
			public boundaryStatusType? boundaryStatusType {get;set;} = default;

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

			[XmlElement("jurisdiction")]
			[EnumerationValue([1,2,3])]
			public jurisdiction? jurisdiction {get;set;} = default;

			public bool ShouldSerializejurisdiction() { return jurisdiction.HasValue; }

			[XmlElement("categoryofBoundaryLine")]
			[EnumerationValue([501,506,511,599])]
			public categoryofBoundaryLine? categoryofBoundaryLine {get;set;} = default;

			public bool ShouldSerializecategoryofBoundaryLine() { return categoryofBoundaryLine.HasValue; }

			[XmlElement("inDispute")]
			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(LineOfDelimitation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LineOfDelimitation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LineOfDelimitation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LineOfDelimitation._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Straight baselines are a system of straight lines joining specified or discrete points on the low-water line, usually known as straight baseline turning points. Straight baselines are used in delimitation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StraightTerritorialSeaBaseline : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("nationality")]
			public required String nationality {get;set;} = string.Empty;

			[XmlElement("sourceIdentification")]
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("status")]
			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

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
			public override string Code => nameof(StraightTerritorialSeaBaseline);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => StraightTerritorialSeaBaseline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => StraightTerritorialSeaBaseline._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => StraightTerritorialSeaBaseline._primitives;
			public static Primitives[] _primitives => [
				Primitives.curve
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("beaconShape")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape beaconShape {get;set;} = default;

			[XmlElement("status")]
			[EnumerationValue([1,2,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

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

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(SafeWaterBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SafeWaterBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[XmlElement("status")]
			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

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

			[XmlElement("condition")]
			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("beaconShape")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape beaconShape {get;set;} = default;

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("topmark")]
			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[XmlElement("categoryOfSpecialPurposeMark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,10,11,12,14,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,60,61,62,63])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[JsonIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SpecialPurposeGeneralBeacon._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S501/0.0")]
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
