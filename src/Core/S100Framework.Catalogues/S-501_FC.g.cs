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
		VisuallyConspicuous = 1,

		[System.ComponentModel.Description("AnObjectThatMayBeVisibleFromSeawardButCannotBeUsedAsAFixingMarkAndIsNotConspicuous")]
		[EnumMember(Value = "Not Visually Conspicuous")] 
		NotVisuallyConspicuous = 2,

		[System.ComponentModel.Description("ObjectsWhichAreEasilyIdentifiableButDoNotJustifyBeingClassedAsConspicuous")]
		[EnumMember(Value = "Prominent")] 
		Prominent = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum gradientOfSlope : int {
		[System.ComponentModel.Description("five01SteepMissingDefinition")]
		[EnumMember(Value = "Steep")] 
		Steep = 501,

		[System.ComponentModel.Description("five02ModerateMissingDefinition")]
		[EnumMember(Value = "Moderate")] 
		Moderate = 502,

		[System.ComponentModel.Description("five03GentleMissingDefinition")]
		[EnumMember(Value = "Gentle")] 
		Gentle = 503,

		[System.ComponentModel.Description("five04MildMissingDefinition")]
		[EnumMember(Value = "Mild")] 
		Mild = 504,

		[System.ComponentModel.Description("ALevelTractOfLandAsTheBedOfADryLakeOrAnAreaFrequentlyUncoveredAtLowTideUsuallyInPlural")]
		[EnumMember(Value = "Flat")] 
		Flat = 505,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeofMilitaryActivity : int {
		[System.ComponentModel.Description("five01AntiAircraftGroundToAirMissingDefinition")]
		[EnumMember(Value = "Anti Aircraft (ground to air)")] 
		AntiAircraftGroundToAir = 501,

		[System.ComponentModel.Description("five02HighAndLowAngleGunneryGroundToGroundMissingDefinition")]
		[EnumMember(Value = "High and Low angle gunnery (ground to ground)")] 
		HighAndLowAngleGunneryGroundToGround = 502,

		[System.ComponentModel.Description("five03AirToAirFiringMissingDefinition")]
		[EnumMember(Value = "Air to Air Firing")] 
		AirToAirFiring = 503,

		[System.ComponentModel.Description("five04AirCombatTrainingMissingDefinition")]
		[EnumMember(Value = "Air Combat Training")] 
		AirCombatTraining = 504,

		[System.ComponentModel.Description("five0fiveAirDroppedTorpedoMissingDefinition")]
		[EnumMember(Value = "Air Dropped Torpedo")] 
		AirDroppedTorpedo = 505,

		[System.ComponentModel.Description("five06AircraftGeneralMissingDefinition")]
		[EnumMember(Value = "Aircraft General")] 
		AircraftGeneral = 506,

		[System.ComponentModel.Description("five07AirToSurfaceFiringMissingDefinition")]
		[EnumMember(Value = "Air to Surface Firing")] 
		AirToSurfaceFiring = 507,

		[System.ComponentModel.Description("five08AntiSubmarineWarfareExercisesMissingDefinition")]
		[EnumMember(Value = "Anti Submarine Warfare Exercises")] 
		AntiSubmarineWarfareExercises = 508,

		[System.ComponentModel.Description("five09AcousticTrialsMissingDefinition")]
		[EnumMember(Value = "Acoustic Trials")] 
		AcousticTrials = 509,

		[System.ComponentModel.Description("five10AirTacticalTrainingMissingDefinition")]
		[EnumMember(Value = "Air Tactical Training")] 
		AirTacticalTraining = 510,

		[System.ComponentModel.Description("five11BombingMissingDefinition")]
		[EnumMember(Value = "Bombing")] 
		Bombing = 511,

		[System.ComponentModel.Description("five12DepthChargeDroppingFiringIncludingRocketMortarFiredDcMissingDefinition")]
		[EnumMember(Value = "Depth Charge dropping/firing (including rocket/mortar fired DC)")] 
		DepthChargeDroppingFiringIncludingRocketMortarFiredDc = 512,

		[System.ComponentModel.Description("NeutralizationOfTheStrengthOfTheMagneticFieldOfAVesselByMeansOfSuitablyArrangedElectricCoilsPermanentlyInstalledInTheVesselSeeAlsoDegaussingCable")]
		[EnumMember(Value = "Degaussing")] 
		Degaussing = 513,

		[System.ComponentModel.Description("five14DemolitionOfUnexplodedOrdnanceMissingDefinition")]
		[EnumMember(Value = "Demolition of unexploded ordnance")] 
		DemolitionOfUnexplodedOrdnance = 514,

		[System.ComponentModel.Description("five1fiveExplosivesTrialsMissingDefinition")]
		[EnumMember(Value = "Explosives Trials")] 
		ExplosivesTrials = 515,

		[System.ComponentModel.Description("five16FiringMissingDefinition")]
		[EnumMember(Value = "Firing")] 
		Firing = 516,

		[System.ComponentModel.Description("five17FlaresMissingDefinition")]
		[EnumMember(Value = "Flares")] 
		Flares = 517,

		[System.ComponentModel.Description("five18GlowWormMissingDefinition")]
		[EnumMember(Value = "Glow Worm")] 
		GlowWorm = 518,

		[System.ComponentModel.Description("five19GeneralPracticeMissingDefinition")]
		[EnumMember(Value = "General Practice")] 
		GeneralPractice = 519,

		[System.ComponentModel.Description("five20GuidedWeaponsAirFlightMissingDefinition")]
		[EnumMember(Value = "Guided Weapons (air Flight)")] 
		GuidedWeaponsAirFlight = 520,

		[System.ComponentModel.Description("five21HelicopterExercisesMissingDefinition")]
		[EnumMember(Value = "Helicopter exercises")] 
		HelicopterExercises = 521,

		[System.ComponentModel.Description("five22HighEnergyManouvresMissingDefinition")]
		[EnumMember(Value = "High Energy Manouvres")] 
		HighEnergyManouvres = 522,

		[System.ComponentModel.Description("five23HmShipsNonFiringExercisesPracticesAndTrialsMissingDefinition")]
		[EnumMember(Value = "HM Ships (non-firing exercises, practices and trials)")] 
		HmShipsNonFiringExercisesPracticesAndTrials = 523,

		[System.ComponentModel.Description("five24LiveAswFiringMissingDefinition")]
		[EnumMember(Value = "Live ASW firing")] 
		LiveAswFiring = 524,

		[System.ComponentModel.Description("five2fiveMineCounterMeasuresMissingDefinition")]
		[EnumMember(Value = "Mine Counter Measures")] 
		MineCounterMeasures = 525,

		[System.ComponentModel.Description("five26MineDisposalMissingDefinition")]
		[EnumMember(Value = "Mine Disposal")] 
		MineDisposal = 526,

		[System.ComponentModel.Description("five27MissileFiringMissingDefinition")]
		[EnumMember(Value = "Missile Firing")] 
		MissileFiring = 527,

		[System.ComponentModel.Description("five28MortarFiringMissingDefinition")]
		[EnumMember(Value = "Mortar Firing")] 
		MortarFiring = 528,

		[System.ComponentModel.Description("five29NavalGunfireSupportMissingDefinition")]
		[EnumMember(Value = "Naval Gunfire Support")] 
		NavalGunfireSupport = 529,

		[System.ComponentModel.Description("five30NoiseRangingMissingDefinition")]
		[EnumMember(Value = "Noise Ranging")] 
		NoiseRanging = 530,

		[System.ComponentModel.Description("five31ParachuteDroppingMissingDefinition")]
		[EnumMember(Value = "Parachute Dropping")] 
		ParachuteDropping = 531,

		[System.ComponentModel.Description("five32PilotlessTargetAircraftMissingDefinition")]
		[EnumMember(Value = "Pilotless Target Aircraft")] 
		PilotlessTargetAircraft = 532,

		[System.ComponentModel.Description("five33RadarTrainingBuoyMissingDefinition")]
		[EnumMember(Value = "Radar Training Buoy")] 
		RadarTrainingBuoy = 533,

		[System.ComponentModel.Description("five34SubmarineExercisesMissingDefinition")]
		[EnumMember(Value = "Submarine Exercises")] 
		SubmarineExercises = 534,

		[System.ComponentModel.Description("SuspensionInTheAtmosphereOfSmallParticlesProducedByCombustion")]
		[EnumMember(Value = "Smoke")] 
		Smoke = 535,

		[System.ComponentModel.Description("five36SonobuoyDroppingMissingDefinition")]
		[EnumMember(Value = "Sonobuoy Dropping")] 
		SonobuoyDropping = 536,

		[System.ComponentModel.Description("five37StarshellMissingDefinition")]
		[EnumMember(Value = "Starshell")] 
		Starshell = 537,

		[System.ComponentModel.Description("five38SurfaceTargetTowingMissingDefinition")]
		[EnumMember(Value = "Surface Target Towing")] 
		SurfaceTargetTowing = 538,

		[System.ComponentModel.Description("five39SurfaceToSurfaceFiringsMissingDefinition")]
		[EnumMember(Value = "Surface to Surface Firings")] 
		SurfaceToSurfaceFirings = 539,

		[System.ComponentModel.Description("five40SubmarineGeneralNonFiringExercisesPracticesTrialsMissingDefinition")]
		[EnumMember(Value = "Submarine General (non-firing exercises, practices, trials)")] 
		SubmarineGeneralNonFiringExercisesPracticesTrials = 540,

		[System.ComponentModel.Description("five41SurfaceExplosionsMissingDefinition")]
		[EnumMember(Value = "Surface Explosions")] 
		SurfaceExplosions = 541,

		[System.ComponentModel.Description("five42TorpedoFiringAreaMissingDefinition")]
		[EnumMember(Value = "Torpedo Firing Area")] 
		TorpedoFiringArea = 542,

		[System.ComponentModel.Description("five43TowedArrayMissingDefinition")]
		[EnumMember(Value = "Towed Array")] 
		TowedArray = 543,

		[System.ComponentModel.Description("five44AerialTowedTargetOrTargetTowingAircraftMissingDefinition")]
		[EnumMember(Value = "Aerial Towed Target or Target Towing Aircraft")] 
		AerialTowedTargetOrTargetTowingAircraft = 544,

		[System.ComponentModel.Description("five4fiveWeaponTrainingMissingDefinition")]
		[EnumMember(Value = "Weapon Training")] 
		WeaponTraining = 545,

		[System.ComponentModel.Description("five46AmphibiousMissingDefinition")]
		[EnumMember(Value = "Amphibious")] 
		Amphibious = 546,

		[System.ComponentModel.Description("ASignalOrMessageWarningOfDivingActivity")]
		[EnumMember(Value = "Diving")] 
		Diving = 547,

		[System.ComponentModel.Description("five98BalloonsMissingDefinition")]
		[EnumMember(Value = "Balloons")] 
		Balloons = 598,

		[System.ComponentModel.Description("five99ElectricalOpticalHazardMissingDefinition")]
		[EnumMember(Value = "Electrical/Optical Hazard")] 
		ElectricalOpticalHazard = 599,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCoastline : int {
		[System.ComponentModel.Description("ACoastBackedByRockOrEarthCliffsGivesAGoodRadarReturnAndIsUsefulForVisualIdentificationFromAConsiderableDistanceOffWhereCliffsAlternateWithLowLyingCoastAlongTheShoreline")]
		[EnumMember(Value = "Steep Coast")] 
		SteepCoast = 1,

		[System.ComponentModel.Description("ALevelCoastWithNoObviousTopographicFeatures")]
		[EnumMember(Value = "Flat Coast")] 
		FlatCoast = 2,

		[System.ComponentModel.Description("sixGlacierSeawardEndMissingDefinition")]
		[EnumMember(Value = "glacier, seaward end")] 
		GlacierSeawardEnd = 6,

		[System.ComponentModel.Description("OneOfSeveralGeneraOfTropicalTreesOrShrubsWhichProduceManyPropRootsAndGrowAlongLowLyingCoastsIntoShallowWater")]
		[EnumMember(Value = "Mangrove")] 
		Mangrove = 7,

		[System.ComponentModel.Description("AShorelineAreaMadeUpOfSpongyLandSaturatedWithWaterItMayHaveAShallowCoveringOfWaterUsuallyWithAConsiderableAmountOfVegetationAppearingAboveTheSurface")]
		[EnumMember(Value = "Marshy Shore")] 
		MarshyShore = 8,

		[System.ComponentModel.Description("AVerticalCliffFormingTheSeawardEdgeOfAnIceShelfRangingInHeightFrom2MetresTo50MetresOrMoreAboveSeaLevel")]
		[EnumMember(Value = "Ice Coast")] 
		IceCoast = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum speedUnits : int {
		[System.ComponentModel.Description("AUnitOfSpeedExpressingTheNumberOfKilometresTravelledInOneHour")]
		[EnumMember(Value = "Kilometres Per Hour")] 
		KilometresPerHour = 2,

		[System.ComponentModel.Description("AnImperialAndUnitedStatesCustomaryUnitOfSpeedExpressingTheNumberOfStatuteMilesCoveredInOneHour")]
		[EnumMember(Value = "Miles Per Hour")] 
		MilesPerHour = 3,

		[System.ComponentModel.Description("ANauticalUnitOfSpeedOneKnotIsOneNauticalMilePerHourTheNameIsDerivedFromTheKnotsInTheLogLine")]
		[EnumMember(Value = "Knots")] 
		Knots = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfInstallationBuoy : int {
		[System.ComponentModel.Description("IncorporatesALargeBuoyWhichRemainsOnTheSurfaceAtAllTimesAndIsMooredBy4OrMoreAnchorsMooringHawsersAndCargoHosesLeadFromATurntableOnTopOfTheBuoySoThatTheBuoyDoesNotTurnAsTheShipSwingsToWindAndStream")]
		[EnumMember(Value = "Catenary Anchor Leg Mooring")] 
		CatenaryAnchorLegMooring = 1,

		[System.ComponentModel.Description("ALargeMooringBuoyUsedByTankersToLoadAndUnloadInPortApproachesOrInOffshoreOilAndGasFields")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		SingleBuoyMooring = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofRestrictions : int {
		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveItsFloraFaunaPhysicalFeaturesEtc")]
		[EnumMember(Value = "Nature Reserve")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("APlaceWhereBirdsAreBredAndProtected")]
		[EnumMember(Value = "Bird Sanctuary")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("APlaceWhereWildAnimalsOrBirdsHuntedForSportOrFoodAreKeptUndisturbedForPrivateUse")]
		[EnumMember(Value = "Game Reserve")] 
		GameReserve = 6,

		[System.ComponentModel.Description("APlaceWhereSealsAreProtected")]
		[EnumMember(Value = "Seal Sanctuary")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("AnAreaAroundCertainWrecksOfHistoricalImportanceToProtectTheWrecksFromUnauthorizedInterferenceByDivingSalvageOrDepositionIncludingAnchoring")]
		[EnumMember(Value = "Historic Wreck Area")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("AnAreaWhereMarineResearchTakesPlace")]
		[EnumMember(Value = "Research Area")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("APlaceWhereFishIncludingShellfishAndCrustaceansAreProtected")]
		[EnumMember(Value = "Fish Sanctuary")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveTheRelationOfPlantsAndLivingCreaturesToEachOtherAndToTheirSurroundings")]
		[EnumMember(Value = "Ecological Reserve")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("two7EnvironmentallySensitiveSeaAreaEssaMissingDefinition")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area (ESSA)")] 
		EnvironmentallySensitiveSeaAreaEssa = 27,

		[System.ComponentModel.Description("two8ParticularlySensitiveSeaAreaPssaMissingDefinition")]
		[EnumMember(Value = "Particularly Sensitive Sea Area (PSSA)")] 
		ParticularlySensitiveSeaAreaPssa = 28,

		[System.ComponentModel.Description("APlaceWhereCoralIsProtected")]
		[EnumMember(Value = "Coral Sanctuary")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("AnAreaWithinWhichRecreationalActivitiesRegularlyTakePlaceAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Recreation Area")] 
		RecreationArea = 32,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("APositionThatIsConsideredToBeLessThanThirdOrderAccuracyButIsGenerallyConsideredToBeWithin305MetresOfItsCorrectGeographicLocationAlsoMayApplyToAFeatureWhosePositionDoesNotRemainFixed")]
		[EnumMember(Value = "Approximate")] 
		Approximate = 4,

		[System.ComponentModel.Description("OfUncertainPositionTheExpressionIsUsedPrincipallyOnChartsToIndicateThatAWreckShoalEtcHasBeenReportedInVariousPositionsAndNotDefinitelyDeterminedInAny")]
		[EnumMember(Value = "Position Doubtful")] 
		PositionDoubtful = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum jurisdiction : int {
		[System.ComponentModel.Description("InvolvingMoreThanOneCountryCoveringMoreThanOneNationalArea")]
		[EnumMember(Value = "International")] 
		International = 1,

		[System.ComponentModel.Description("AnAreaAdministeredOrControlledByASingleNation")]
		[EnumMember(Value = "National")] 
		National = 2,

		[System.ComponentModel.Description("threeNationalSubDivisionMissingDefinition")]
		[EnumMember(Value = "National Sub-Division")] 
		NationalSubDivision = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurface : int {
		[System.ComponentModel.Description("SoftWetEarth")]
		[EnumMember(Value = "Mud")] 
		Mud = 1,

		[System.ComponentModel.Description("ParticlesOfLessThan0002mmStiffStickyEarthThatBecomesHardWhenBaked")]
		[EnumMember(Value = "Clay")] 
		Clay = 2,

		[System.ComponentModel.Description("AnUnconsolidatedSedimentWhoseParticlesRangeInSizeFrom00039To00625MillimetresInDiameterBetweenClayAndSandSize")]
		[EnumMember(Value = "Silt")] 
		Silt = 3,

		[System.ComponentModel.Description("LooseMaterialConsistingOfSmallButEasilyDistinguishableSeparateGrainsBetween00625And2000MillimetresInDiameter")]
		[EnumMember(Value = "Sand")] 
		Sand = 4,

		[System.ComponentModel.Description("AGeneralTermForRockAndRockFragmentsRangingInSizeFromPebblesAndGravelToBouldersOrLargeRockMasses")]
		[EnumMember(Value = "Stone")] 
		Stone = 5,

		[System.ComponentModel.Description("ParticlesOf2040mmSmallStonesWithCoarseSand")]
		[EnumMember(Value = "Gravel")] 
		Gravel = 6,

		[System.ComponentModel.Description("ASmallStoneWornSmoothAndRoundedByTheActionOfWaterSandIceEtcRangingInDiameterBetween4And64Millimetres")]
		[EnumMember(Value = "Pebbles")] 
		Pebbles = 7,

		[System.ComponentModel.Description("ANaturallyRoundedStoneLargerThanAPebble")]
		[EnumMember(Value = "Cobbles")] 
		Cobbles = 8,

		[System.ComponentModel.Description("AnyFormationOfNaturalOriginThatConstitutesAnIntegralPartOfTheLithosphereTheNaturalOccurringMaterialThatFormsFirmHardAndSolidMasses")]
		[EnumMember(Value = "Rock")] 
		Rock = 9,

		[System.ComponentModel.Description("TheFluidOrSemiFluidMatterFlowingFromAVolcanoTheSubstanceThatResultsFromTheCoolingOfTheMoltenRockPartOfTheOceanBedIsComposedOfLava")]
		[EnumMember(Value = "Lava")] 
		Lava = 11,

		[System.ComponentModel.Description("HardCalcareousSkeletonsOfManyTribesOfMarinePolyps")]
		[EnumMember(Value = "Coral")] 
		Coral = 14,

		[System.ComponentModel.Description("TheHardOutsideCoveringOfAnAnimalPartOfTheOceanBedIsComposedOfNumerousShellsOfMarineAnimals")]
		[EnumMember(Value = "Shells")] 
		Shells = 17,

		[System.ComponentModel.Description("ARoundedRockWithDiameterOf256MillimetresOrLarger")]
		[EnumMember(Value = "Boulder")] 
		Boulder = 18,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum marksNavigationalSystemOf : int {
		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaASystem")]
		[EnumMember(Value = "IALA A")] 
		IalaA = 1,

		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaBSystem")]
		[EnumMember(Value = "IALA B")] 
		IalaB = 2,

		[System.ComponentModel.Description("NavigationalAidsDoNotConformToAnyDefinedSystem")]
		[EnumMember(Value = "No System")] 
		NoSystem = 9,

		[System.ComponentModel.Description("NavigationalAidsAsRequiredInInternationalNationalOrRegionalRegulationsThatContainTheSameNavigationalAidsAsTheEuropeanCodeForInlandWaterwaysOfUneceOrIfThereIsNoRegulationForAWaterwayNavigationalAidsAsRecommendedInTheEuropeanCodeForInlandWaterwaysOfUnece")]
		[EnumMember(Value = "Main European Inland Waterway Marking System")] 
		MainEuropeanInlandWaterwayMarkingSystem = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum magneticAnomalyDetectorSignature : int {
		[System.ComponentModel.Description("five01NilMissingDefinition")]
		[EnumMember(Value = "nil")] 
		Nil = 501,

		[System.ComponentModel.Description("five02SlightMissingDefinition")]
		[EnumMember(Value = "slight")] 
		Slight = 502,

		[System.ComponentModel.Description("five03ModerateMissingDefinition")]
		[EnumMember(Value = "moderate")] 
		Moderate = 503,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		Strong = 504,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("TheValueOfTheLeftValueIsGreaterThanThatOfTheRight")]
		[EnumMember(Value = "Greater Than")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsGreaterThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Greater Than or Equal To")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanThatOfTheRight")]
		[EnumMember(Value = "Less Than")] 
		LessThan = 3,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Less Than or Equal To")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("TheTwoValuesAreEquivalent")]
		[EnumMember(Value = "Equal To")] 
		EqualTo = 5,

		[System.ComponentModel.Description("TheTwoValuesAreNotEquivalent")]
		[EnumMember(Value = "Not Equal To")] 
		NotEqualTo = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCable : int {
		[System.ComponentModel.Description("ACableThatTransmitsOrDistributesElectricalPower")]
		[EnumMember(Value = "Power Line")] 
		PowerLine = 1,

		[System.ComponentModel.Description("MultipleUnInsulatedCablesUsuallySupportedBySteelLatticeTowersSuchFeaturesAreGenerallyMoreProminentThanNormalPowerLines")]
		[EnumMember(Value = "Transmission Line")] 
		TransmissionLine = 3,

		[System.ComponentModel.Description("AChainOrVeryStrongFibreOrWireRopeUsedToAnchorOrMoorVesselsOrBuoys")]
		[EnumMember(Value = "Mooring Cable")] 
		MooringCable = 6,

		[System.ComponentModel.Description("AVesselForTransportingPassengersVehiclesAndOrGoodsAcrossAStretchOfWaterEspeciallyAsARegularService")]
		[EnumMember(Value = "Ferry")] 
		Ferry = 7,

		[System.ComponentModel.Description("ACableUsedForJoiningComponentsOfComplexMarineStructuresForExampleMooringTrots")]
		[EnumMember(Value = "Junction Cable")] 
		JunctionCable = 9,

		[System.ComponentModel.Description("ACableUsedForTheTransmissionAndReceptionOfModulatedCommunicationWavesSignals")]
		[EnumMember(Value = "Telecommunications Cable")] 
		TelecommunicationsCable = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfWreck : int {
		[System.ComponentModel.Description("oneNonDangerousWreckMissingDefinition")]
		[EnumMember(Value = "non-dangerous wreck")] 
		NonDangerousWreck = 1,

		[System.ComponentModel.Description("AWreckSubmergedAtSuchADepthAsToBeConsideredDangerousToSurfaceNavigation")]
		[EnumMember(Value = "Dangerous Wreck")] 
		DangerousWreck = 2,

		[System.ComponentModel.Description("ASubstantivelyDecayedWreckOverWhichItIsSafeToNavigateButWhichShouldBeAvoidedForAnchoringTakingTheGroundOrGroundFishing")]
		[EnumMember(Value = "Distributed Remains of Wreck")] 
		DistributedRemainsOfWreck = 3,

		[System.ComponentModel.Description("fourWreckShowingMastMastsMissingDefinition")]
		[EnumMember(Value = "wreck showing mast/masts")] 
		WreckShowingMastMasts = 4,

		[System.ComponentModel.Description("WreckOfWhichAnyPortionOfTheHullOrSuperstructureIsVisibleAtTheSoundingDatumIndicated")]
		[EnumMember(Value = "Wreck Showing Any Portion of Hull or Superstructure")] 
		WreckShowingAnyPortionOfHullOrSuperstructure = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLateralMark : int {
		[System.ComponentModel.Description("onePortHandLateralMarkMissingDefinition")]
		[EnumMember(Value = "port-hand lateral mark")] 
		PortHandLateralMark = 1,

		[System.ComponentModel.Description("twoStarboardHandLateralMarkMissingDefinition")]
		[EnumMember(Value = "starboard-hand lateral mark")] 
		StarboardHandLateralMark = 2,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedPortHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")] 
		PreferredChannelToStarboardLateralMark = 3,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedStarboardHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Port Lateral Mark")] 
		PreferredChannelToPortLateralMark = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum areaCategory : int {
		[System.ComponentModel.Description("five01SolidRedSrMissingDefinition")]
		[EnumMember(Value = "Solid Red (SR)")] 
		SolidRedSr = 501,

		[System.ComponentModel.Description("five02PeckedRedPrMissingDefinition")]
		[EnumMember(Value = "Pecked Red (PR)")] 
		PeckedRedPr = 502,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum status : int {
		[System.ComponentModel.Description("IntendedToLastOrFunctionIndefinitely")]
		[EnumMember(Value = "Permanent")] 
		Permanent = 1,

		[System.ComponentModel.Description("ActingOnSpecialOccasionsHappeningIrregularly")]
		[EnumMember(Value = "Occasional")] 
		Occasional = 2,

		[System.ComponentModel.Description("PresentedAsWorthyOfConfidenceAcceptanceUseEtc")]
		[EnumMember(Value = "Recommended")] 
		Recommended = 3,

		[System.ComponentModel.Description("UseHasCeasedButTheFacilityStillExistsIntactDisused")]
		[EnumMember(Value = "Not in Use")] 
		NotInUse = 4,

		[System.ComponentModel.Description("fivePeriodicIntermittentMissingDefinition")]
		[EnumMember(Value = "periodic/intermittent")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("SetApartForSomeSpecificUse")]
		[EnumMember(Value = "Reserved")] 
		Reserved = 6,

		[System.ComponentModel.Description("MeantToLastOnlyForATime")]
		[EnumMember(Value = "Temporary")] 
		Temporary = 7,

		[System.ComponentModel.Description("AdministeredByAnIndividualOrCorporationRatherThanAStateOrAPublicBody")]
		[EnumMember(Value = "Private")] 
		Private = 8,

		[System.ComponentModel.Description("CompulsoryEnforced")]
		[EnumMember(Value = "Mandatory")] 
		Mandatory = 9,

		[System.ComponentModel.Description("NoLongerLit")]
		[EnumMember(Value = "Extinguished")] 
		Extinguished = 11,

		[System.ComponentModel.Description("LitByFloodLightsStripLightsEtc")]
		[EnumMember(Value = "Illuminated")] 
		Illuminated = 12,

		[System.ComponentModel.Description("FamousInHistoryOfHistoricalInterest")]
		[EnumMember(Value = "Historic")] 
		Historic = 13,

		[System.ComponentModel.Description("BelongingToAvailableToUsedOrSharedByTheCommunityAsAWholeAndNotRestrictedToPrivateUse")]
		[EnumMember(Value = "Public")] 
		Public = 14,

		[System.ComponentModel.Description("OccurAtATimeCoincideInPointOfTimeBeContemporaryOrSimultaneous")]
		[EnumMember(Value = "Synchronized")] 
		Synchronized = 15,

		[System.ComponentModel.Description("LookedAtOrObservedOverAPeriodOfTimeEspeciallySoAsToBeAwareOfAnyMovementOrChange")]
		[EnumMember(Value = "Watched")] 
		Watched = 16,

		[System.ComponentModel.Description("UsuallyAutomaticInOperationWithoutAnyPermanentlyStationedPersonnelToSuperintendIt")]
		[EnumMember(Value = "Unwatched")] 
		Unwatched = 17,

		[System.ComponentModel.Description("AFeatureThatHasBeenReportedButHasNotBeenDefinitelyDeterminedToExist")]
		[EnumMember(Value = "Existence Doubtful")] 
		ExistenceDoubtful = 18,

		[System.ComponentModel.Description("MarkedByBuoys")]
		[EnumMember(Value = "Buoyed")] 
		Buoyed = 28,

		[System.ComponentModel.Description("five01ActiveInUseMissingDefinition")]
		[EnumMember(Value = "active/in use")] 
		ActiveInUse = 501,

		[System.ComponentModel.Description("ACoastalStateClaimsOrMayClaimASpecificJurisdictionInAccordanceWithTheProvisionsOfInternationalLaw")]
		[EnumMember(Value = "Claimed")] 
		Claimed = 502,

		[System.ComponentModel.Description("five03PracticeAndOrExercisePurposesMissingDefinition")]
		[EnumMember(Value = "practice and/or exercise purposes")] 
		PracticeAndOrExercisePurposes = 503,

		[System.ComponentModel.Description("AcknowledgedAndAgreedInAccordanceWithTheProvisionsOfInternationalLaw")]
		[EnumMember(Value = "Recognised")] 
		Recognised = 504,

		[System.ComponentModel.Description("NotDetectedByRepeatedSurveysLeadingToDoubtsAboutTheObjectSExistenceAml")]
		[EnumMember(Value = "Dead")] 
		Dead = 505,

		[System.ComponentModel.Description("AnObjectThatHasBeenSalvagedOrRemovedAml")]
		[EnumMember(Value = "Lifted")] 
		Lifted = 506,

		[System.ComponentModel.Description("WhereASignificantNumberOfPersonsHavePerishedAsADirectResultOfAVesselOrStructureSinkingAndTheirRemainsCannotBeRecoveredTheWreckAndImmediateAreaMayBeDeclaredAsAMassGraveOrMoreSpecificallyAWarGraveSuchSitesAreProtectedFromDisturbanceByInternationalLawAml")]
		[EnumMember(Value = "Mass Grave")] 
		MassGrave = 507,

		[System.ComponentModel.Description("ABoreholeDrilledInTheSearchForANewSourceOfOilOrGasAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Exploration")] 
		Exploration = 508,

		[System.ComponentModel.Description("ABoreholeThatIsActivelyEngagedInTheExtractionOfOilOrGasFromTheSeabedAdaptedFromAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Production")] 
		Production = 509,

		[System.ComponentModel.Description("AWellWhereTheExtractionOfOilOrGasHasBeenTemporarilyAbandonedWhenSuspendedAWellIsEitherPluggedFilledWithConcreteAndToppedWithASteelPlateOrCappedWellHeadEquipmentIsInstalledOverTheWellAdaptedFromAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Suspended")] 
		Suspended = 510,

		[System.ComponentModel.Description("ABoreholeDrilledForThePurposeOfInjectingASecondarySubstanceForExampleWaterIntoThePoreSpacesInAReservoirRockToEncourageOilOrGasToFlowIntoAdjacentProducingWellsAnAZOfOffshoreOilGasByHarryWhitehead2ndEd1983GulfPublishingCompany")]
		[EnumMember(Value = "Injection")] 
		Injection = 511,

		[System.ComponentModel.Description("TheStatusOfTheObjectIsUnspecified")]
		[EnumMember(Value = "Unspecified")] 
		Unspecified = 512,

		[System.ComponentModel.Description("TemporarilyQuietInactiveNotBeingUsedAml")]
		[EnumMember(Value = "Dormant")] 
		Dormant = 516,

		[System.ComponentModel.Description("PlannedIntendedInAccordanceWithOrAchievedByACarefulPlanMadeBeforehandTheConciseOxfordDictionary")]
		[EnumMember(Value = "Proposed")] 
		Proposed = 517,

		[System.ComponentModel.Description("CompletelyDesertedGivenUpAdaptedFromTheConciseOxfordDictionary")]
		[EnumMember(Value = "Abandoned")] 
		Abandoned = 518,

		[System.ComponentModel.Description("AreaOfOverlapOfTheUnilateralFishingZonesOfTwoOrMoreCountries")]
		[EnumMember(Value = "Grey zone")] 
		GreyZone = 519,

		[System.ComponentModel.Description("AnAreaOfTheSeaOfIndeterminateJurisdictionWhereNoAgreedBoundaryExist")]
		[EnumMember(Value = "Indeterminate")] 
		Indeterminate = 520,

		[System.ComponentModel.Description("InvolvingTwoOrMoreStatesAsPartiesToAnAgreement")]
		[EnumMember(Value = "Multilateral")] 
		Multilateral = 521,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCardinalMark : int {
		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNwNeTakenFromThePointOfInterestItShouldBePassedToTheNorthSideOfTheMark")]
		[EnumMember(Value = "North Cardinal Mark")] 
		NorthCardinalMark = 1,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNeSeTakenFromThePointOfInterestItShouldBePassedToTheEastSideOfTheMark")]
		[EnumMember(Value = "East Cardinal Mark")] 
		EastCardinalMark = 2,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSeSwTakenFromThePointOfInterestItShouldBePassedToTheSouthSideOfTheMark")]
		[EnumMember(Value = "South Cardinal Mark")] 
		SouthCardinalMark = 3,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSwNwTakenFromThePointOfInterestItShouldBePassedToTheWestSideOfTheMark")]
		[EnumMember(Value = "West Cardinal Mark")] 
		WestCardinalMark = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAirportAirfield : int {
		[System.ComponentModel.Description("ALargeMilitaryAirfieldUsuallyEquippedWithAControlTowerHangarsAndAccommodationForTheReceivingAndDischargingOfPassengersOrCargo")]
		[EnumMember(Value = "Military Aeroplane Airport")] 
		MilitaryAeroplaneAirport = 1,

		[System.ComponentModel.Description("ALargeAirfieldUsuallyEquippedWithAControlTowerHangarsAndAccommodationForTheReceivingAndDischargingOfPassengersOrCargo")]
		[EnumMember(Value = "Civil Aeroplane Airport")] 
		CivilAeroplaneAirport = 2,

		[System.ComponentModel.Description("ALandingPlaceForHelicoptersControlledByTheMilitary")]
		[EnumMember(Value = "Military Heliport")] 
		MilitaryHeliport = 3,

		[System.ComponentModel.Description("ALandingPlaceForHelicoptersOftenTheRoofOfABuilding")]
		[EnumMember(Value = "Civil Heliport")] 
		CivilHeliport = 4,

		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfGliders")]
		[EnumMember(Value = "Glider Airfield")] 
		GliderAirfield = 5,

		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfSmallAeroplanes")]
		[EnumMember(Value = "Small Planes Airfield")] 
		SmallPlanesAirfield = 6,

		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfAeroplanesOrHelicoptersInTimesOfEmergency")]
		[EnumMember(Value = "Emergency Airfield")] 
		EmergencyAirfield = 8,

		[System.ComponentModel.Description("nineSearchAndRescueMissingDefinition")]
		[EnumMember(Value = "search and rescue")] 
		SearchAndRescue = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum techniqueOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatDeterminesDepthOfWaterByMeasuringTheTimeIntervalBetweenEmissionOfASonicOrUltrasonicSignalAndReturnOfItsEchoFromTheBottom")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		FoundByEchoSounder = 1,

		[System.ComponentModel.Description("TheDepthWasComputedFromARecordProducedByActiveSonarInWhichFixedAcousticBeamsAreDirectedIntoTheWaterPerpendicularlyToTheDirectionOfTravelToScanTheSeabedAndGenerateARecordOfTheSeabedConfiguration")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		FoundBySideScanSonar = 2,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAWideSwathEchoSounderThatUsesMultipleBeamsToMeasureDepthsDirectlyBelowAndTransverseToTheShipSTrack")]
		[EnumMember(Value = "Found by Multi Beam")] 
		FoundByMultiBeam = 3,

		[System.ComponentModel.Description("TheDepthWasDeterminedByAPersonSkilledInThePracticeOfDiving")]
		[EnumMember(Value = "Found by Diver")] 
		FoundByDiver = 4,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingALineGraduatedWithAttachedMarksAndFastenedToASoundingLead")]
		[EnumMember(Value = "Found by Lead Line")] 
		FoundByLeadLine = 5,

		[System.ComponentModel.Description("TheGivenAreaHasBeenSweptUsingASystemComprisedOfMultipleEchoSounderTransducersAttachedToBoomsDeployedFromTheSurveyVessel")]
		[EnumMember(Value = "Swept by Vertical Acoustic System")] 
		SweptByVerticalAcousticSystem = 8,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatComparesElectromagneticSignals")]
		[EnumMember(Value = "Found by Electromagnetic Sensor")] 
		FoundByElectromagneticSensor = 9,

		[System.ComponentModel.Description("TheScienceOrArtOfObtainingReliableMeasurementsFromPhotographs")]
		[EnumMember(Value = "Photogrammetry")] 
		Photogrammetry = 10,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingInstrumentsPlacedAboardAnArtificialSatellite")]
		[EnumMember(Value = "Satellite Imagery")] 
		SatelliteImagery = 11,

		[System.ComponentModel.Description("one2FoundByLevelingMissingDefinition")]
		[EnumMember(Value = "found by leveling")] 
		FoundByLeveling = 12,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingASideScanSonar")]
		[EnumMember(Value = "Swept by Side Scan Sonar")] 
		SweptBySideScanSonar = 13,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatMeasuresDistanceByEmittingTimedPulsesOfLaserLightAndMeasuringTheTimeBetweenEmissionAndReceptionOfTheReflectedPulses")]
		[EnumMember(Value = "Found by LIDAR")] 
		FoundByLidar = 15,

		[System.ComponentModel.Description("ARadarWithASyntheticApertureAntennaWhichIsComposedOfALargeNumberOfElementaryTransducingElementsTheSignalsAreElectronicallyCombinedIntoAResultingSignalEquivalentToThatOfASingleAntennaOfAGivenApertureInAGivenDirection")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		SyntheticApertureRadar = 16,

		[System.ComponentModel.Description("TermUsedToDescribeTheImageryDerivedFromSubdividingTheElectromagneticSpectrumIntoVeryNarrowBandwidthsTheseNarrowBandwidthsMayBeCombinedWithOrSubtractedFromEachOtherInVariousWaysToFormImagesUsefulInPreciseTerrainOrTargetAnalysis")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		HyperspectralImagery = 17,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingALineOrObjectBelowTheSurfaceAtTheDesiredDepthOrLeastDepthSAndPositionSWithinAnAreaWasIdentifiedUsingTheSameTechnique")]
		[EnumMember(Value = "Mechanically Swept")] 
		MechanicallySwept = 18,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheSurfaceOfTheSeaAtATideStationForAllStagesOfTheTideOverA19YearPeriodUsuallyDeterminedFromHourlyHeightReadingsMeasuredFromAFixedPredeterminedReferenceLevel")]
		[EnumMember(Value = "Mean Sea Level")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "Low Water")] 
		LowWater = 13,

		[System.ComponentModel.Description("TheAverageHeightOfAllHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean High Water")] 
		MeanHighWater = 16,

		[System.ComponentModel.Description("TheAverageHeightOfTheHighWatersOfSpringTides")]
		[EnumMember(Value = "Mean High Water Springs")] 
		MeanHighWaterSprings = 17,

		[System.ComponentModel.Description("TheHighestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "High Water")] 
		HighWater = 18,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanSeaLevelMsl")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		ApproximateMeanSeaLevel = 19,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanHighWaterSpringsMhws")]
		[EnumMember(Value = "High Water Springs")] 
		HighWaterSprings = 20,

		[System.ComponentModel.Description("TheAverageHeightOfHigherHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Higher High Water")] 
		MeanHigherHighWater = 21,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		LocalDatum = 24,

		[System.ComponentModel.Description("two5InternationalGreatMissingDefinition")]
		[EnumMember(Value = "international great")] 
		InternationalGreat = 25,

		[System.ComponentModel.Description("TheAverageOfAllHourlyWaterLevelsOverTheAvailablePeriodOfRecord")]
		[EnumMember(Value = "Mean Water Level")] 
		MeanWaterLevel = 26,

		[System.ComponentModel.Description("TheAverageOfTheHighestHighWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		HigherHighWaterLargeTide = 28,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheHighestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheHighWaterSprings")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		NearlyHighestHighWater = 29,

		[System.ComponentModel.Description("TheHighestTidalLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		HighestAstronomicalTide = 30,

		[System.ComponentModel.Description("fourfourBalticSeaChartDatumMissingDefinition")]
		[EnumMember(Value = "Baltic Sea Chart Datum")] 
		BalticSeaChartDatum = 44,

		[System.ComponentModel.Description("five01MeanTideLevelMissingDefinition")]
		[EnumMember(Value = "Mean Tide Level")] 
		MeanTideLevel = 501,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum exhibitionConditionOfLight : int {
		[System.ComponentModel.Description("ALightShownThroughoutThe24HoursWithoutChangeOfCharacter")]
		[EnumMember(Value = "Light Shown Without Change of Character")] 
		LightShownWithoutChangeOfCharacter = 1,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedByDay")]
		[EnumMember(Value = "Daytime Light")] 
		DaytimeLight = 2,

		[System.ComponentModel.Description("ALightWhichIsExhibitedInFogOrConditionsOfReducedVisibility")]
		[EnumMember(Value = "Fog Light")] 
		FogLight = 3,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedAtNight")]
		[EnumMember(Value = "Night Light")] 
		NightLight = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLight : int {
		[System.ComponentModel.Description("ALightAssociatedWithOtherLightsSoAsToFormALeadingLineToBeFollowed")]
		[EnumMember(Value = "Leading Light")] 
		LeadingLight = 4,

		[System.ComponentModel.Description("AnAeroLightIsEstablishedForAeronauticalNavigationAndMayBeOfHigherPowerThanMarineLightsAndVisibleFromWellOffshore")]
		[EnumMember(Value = "Aero Light")] 
		AeroLight = 5,

		[System.ComponentModel.Description("ABroadBeamLightUsedToIlluminateAStructureOrArea")]
		[EnumMember(Value = "Flood Light")] 
		FloodLight = 8,

		[System.ComponentModel.Description("ALightWhoseSourceHasALinearFormGenerallyHorizontalWhichCanReachALengthOfSeveralMetres")]
		[EnumMember(Value = "Strip Light")] 
		StripLight = 9,

		[System.ComponentModel.Description("ALightPlacedOnOrNearTheSupportOfAMainLightAndHavingASpecialUseInNavigation")]
		[EnumMember(Value = "Subsidiary Light")] 
		SubsidiaryLight = 10,

		[System.ComponentModel.Description("APowerfulLightFocusedSoAsToIlluminateASmallArea")]
		[EnumMember(Value = "Spotlight")] 
		Spotlight = 11,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Front")] 
		Front = 12,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Rear")] 
		Rear = 13,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Lower")] 
		Lower = 14,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Upper")] 
		Upper = 15,

		[System.ComponentModel.Description("ALightAvailableAsABackupToAMainLightWhichWillBeIlluminatedShouldTheMainLightFail")]
		[EnumMember(Value = "Emergency")] 
		Emergency = 17,

		[System.ComponentModel.Description("ALightWhichEnablesItsApproximateBearingToBeObtainedWithoutTheUseOfACompass")]
		[EnumMember(Value = "Bearing Light")] 
		BearingLight = 18,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedHorizontally")]
		[EnumMember(Value = "Horizontally Disposed")] 
		HorizontallyDisposed = 19,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedVertically")]
		[EnumMember(Value = "Vertically Disposed")] 
		VerticallyDisposed = 20,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum trafficFlow : int {
		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionTowardAPortOrSimilarDestination")]
		[EnumMember(Value = "Inbound")] 
		Inbound = 1,

		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionAwayFromAPortOrSimilarPointOfOrigin")]
		[EnumMember(Value = "Outbound")] 
		Outbound = 2,

		[System.ComponentModel.Description("threeOneWayMissingDefinition")]
		[EnumMember(Value = "one-way")] 
		OneWay = 3,

		[System.ComponentModel.Description("fourTwoWayMissingDefinition")]
		[EnumMember(Value = "two-way")] 
		TwoWay = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[System.ComponentModel.Description("TheAchromaticObjectColourOfGreatestLightnessCharacteristicallyPerceivedToBelongToObjectsThatReflectDiffuselyNearlyAllIncidentEnergyThroughoutTheVisibleSpectrum")]
		[EnumMember(Value = "White")] 
		White = 1,

		[System.ComponentModel.Description("TheAchromaticColorOfLeastLightnessCharacteristicallyPerceivedToBelongToObjectsThatNeitherReflectNorTransmitLight")]
		[EnumMember(Value = "Black")] 
		Black = 2,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfBloodOrOfTheRubyOrIsThatOfTheLongWaveExtremeOfTheVisibleSpectrum")]
		[EnumMember(Value = "Red")] 
		Red = 3,

		[System.ComponentModel.Description("OfTheColorGreen")]
		[EnumMember(Value = "Green")] 
		Green = 4,

		[System.ComponentModel.Description("AColorWhoseHueIsThatOfTheClearSkyOrThatOfThePortionOfTheColorSpectrumLyingBetweenGreenAndViolet")]
		[EnumMember(Value = "Blue")] 
		Blue = 5,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfRipeLemonsOrSunflowersOrIsThatOfThePortionOfTheSpectrumLyingBetweenGreenAndOrange")]
		[EnumMember(Value = "Yellow")] 
		Yellow = 6,

		[System.ComponentModel.Description("OfTheColorGrey")]
		[EnumMember(Value = "Grey")] 
		Grey = 7,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBetweenRedAndYellowInHueOfMediumToLowLightnessAndOfModerateToLowSaturation")]
		[EnumMember(Value = "Brown")] 
		Brown = 8,

		[System.ComponentModel.Description("AVariableColorAveragingADarkOrangeYellow")]
		[EnumMember(Value = "Amber")] 
		Amber = 9,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsOfReddishBlueHueLowLightnessAndMediumSaturation")]
		[EnumMember(Value = "Violet")] 
		Violet = 10,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsThatAreBetweenRedAndYellowInHue")]
		[EnumMember(Value = "Orange")] 
		Orange = 11,

		[System.ComponentModel.Description("ADeepPurplishRed")]
		[EnumMember(Value = "Magenta")] 
		Magenta = 12,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBluishRedToRedInHueOfMediumToHighLightnessAndOfLowToModerateSaturation")]
		[EnumMember(Value = "Pink")] 
		Pink = 13,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofBoundaryLine : int {
		[System.ComponentModel.Description("ALineOfDemarcationBetweenControlledAreas")]
		[EnumMember(Value = "Administrative Boundary")] 
		AdministrativeBoundary = 501,

		[System.ComponentModel.Description("five06DeFactoBoundaryMissingDefinition")]
		[EnumMember(Value = "de facto boundary")] 
		DeFactoBoundary = 506,

		[System.ComponentModel.Description("five11InternationalMaritimeBoundaryMissingDefinition")]
		[EnumMember(Value = "International Maritime Boundary")] 
		InternationalMaritimeBoundary = 511,

		[System.ComponentModel.Description("ALineEveryPointOfWhichIsEquidistantFromTheNearestPointsOnTheBaselinesOfTwoOrMoreStatesBetweenWhichItLies")]
		[EnumMember(Value = "Median Line")] 
		MedianLine = 599,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum soundingDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheLowWatersOfSpringTidesThisLevelIsUsedAsATidalDatumInSomeAreas")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		MeanLowWaterSprings = 501,

		[System.ComponentModel.Description("TheAverageHeightOfLowerLowWaterSpringsAtAPlace")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		MeanLowerLowWaterSprings = 502,

		[System.ComponentModel.Description("TheAverageHeightOfTheSurfaceOfTheSeaAtATideStationForAllStagesOfTheTideOverA19YearPeriodUsuallyDeterminedFromHourlyHeightReadingsMeasuredFromAFixedPredeterminedReferenceLevel")]
		[EnumMember(Value = "Mean Sea Level")] 
		MeanSeaLevel = 503,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestTideObservedAtAPlaceOrSomewhatLower")]
		[EnumMember(Value = "Lowest Low Water")] 
		LowestLowWater = 504,

		[System.ComponentModel.Description("TheAverageHeightOfAllLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Low Water")] 
		MeanLowWater = 505,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestWaterLevelObservedAtAPlaceAtSpringTidesDuringAPeriodOfTimeShorterThan19Years")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		LowestLowWaterSprings = 506,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		ApproximateMeanLowWaterSprings = 507,

		[System.ComponentModel.Description("AnArbitraryTidalDatumApproximatingTheLevelOfTheMeanOfTheLowerLowWaterAtSpringTidesItWasFirstUsedInWatersSurroundingIndia")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		IndianSpringLowWater = 508,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Low Water Springs")] 
		LowWaterSprings = 509,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfLowestAstronomicalTideLat")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		ApproximateLowestAstronomicalTide = 510,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheLowestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheIndianSpringLowWaterIslw")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		NearlyLowestLowWater = 511,

		[System.ComponentModel.Description("TheAverageHeightOfTheLowerLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		MeanLowerLowWater = 512,

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "Low Water")] 
		LowWater = 513,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterMlw")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		ApproximateMeanLowWater = 514,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowerLowWaterMllw")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		ApproximateMeanLowerLowWater = 515,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanSeaLevelMsl")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		ApproximateMeanSeaLevel = 519,

		[System.ComponentModel.Description("TheLevelOfLowWaterSpringsNearTheTimeOfAnEquinox")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		EquinoctialSpringLowWater = 522,

		[System.ComponentModel.Description("TheLowestTideLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		LowestAstronomicalTide = 523,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		LocalDatum = 524,

		[System.ComponentModel.Description("five2fiveInternationalGreatLakesDatum198fiveIgld198fiveMissingDefinition")]
		[EnumMember(Value = "International Great Lakes Datum 1985 (IGLD 1985)")] 
		InternationalGreatLakesDatum1985Igld1985 = 525,

		[System.ComponentModel.Description("TheAverageOfAllHourlyWaterLevelsOverTheAvailablePeriodOfRecord")]
		[EnumMember(Value = "Mean Water Level")] 
		MeanWaterLevel = 526,

		[System.ComponentModel.Description("TheAverageOfTheLowestLowWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		LowerLowWaterLargeTide = 527,

		[System.ComponentModel.Description("five31MeanTideLevelMissingDefinition")]
		[EnumMember(Value = "Mean Tide Level")] 
		MeanTideLevel = 531,

		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		BalticSeaChartDatum2000 = 532,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSpecialPurposeMark : int {
		[System.ComponentModel.Description("oneFiringDangerAreaMarkMissingDefinition")]
		[EnumMember(Value = "firing danger area mark")] 
		FiringDangerAreaMark = 1,

		[System.ComponentModel.Description("AnyObjectTowardWhichSomethingIsDirectedTheDistinctiveMarkingOrInstrumentationOfAGroundPointToAidItsIdentificationOnAPhotograph")]
		[EnumMember(Value = "Target Mark")] 
		TargetMark = 2,

		[System.ComponentModel.Description("AMarkMarkingThePositionOfAShipWhichIsUsedAsATargetDuringSomeMilitaryExercise")]
		[EnumMember(Value = "Marker Ship Mark")] 
		MarkerShipMark = 3,

		[System.ComponentModel.Description("AMarkUsedToIndicateADegaussingRange")]
		[EnumMember(Value = "Degaussing Range Mark")] 
		DegaussingRangeMark = 4,

		[System.ComponentModel.Description("AMarkOfRelevanceToBarges")]
		[EnumMember(Value = "Barge Mark")] 
		BargeMark = 5,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarineCablesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Cable Mark")] 
		CableMark = 6,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheLimitOfASpoilGround")]
		[EnumMember(Value = "Spoil Ground Mark")] 
		SpoilGroundMark = 7,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfAnOutfallOrThePointAtWhichItLeavesTheLand")]
		[EnumMember(Value = "Outfall Mark")] 
		OutfallMark = 8,

		[System.ComponentModel.Description("OceanDataAcquisitionSystem")]
		[EnumMember(Value = "ODAS")] 
		Odas = 9,

		[System.ComponentModel.Description("AMarkUsedToRecordDataForScientificPurposes")]
		[EnumMember(Value = "Recording Mark")] 
		RecordingMark = 10,

		[System.ComponentModel.Description("AnAreaInWhichSeaplanesAnchorOrMayAnchor")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		SeaplaneAnchorage = 11,

		[System.ComponentModel.Description("AMarkUsedToIndicateARecreationZone")]
		[EnumMember(Value = "Recreation Zone Mark")] 
		RecreationZoneMark = 12,

		[System.ComponentModel.Description("AMarkIndicatingAMooringOrMoorings")]
		[EnumMember(Value = "Mooring Mark")] 
		MooringMark = 14,

		[System.ComponentModel.Description("ALargeBuoyDesignedToTakeThePlaceOfALightshipWhereConstructionOfAnOffshoreLightStationIsNotFeasible")]
		[EnumMember(Value = "LANBY")] 
		Lanby = 15,

		[System.ComponentModel.Description("AidsToNavigationOrOtherIndicatorsSoLocatedAsToIndicateThePathToBeFollowedLeadingMarksIdentifyALeadingLineWhenTheyAreInTransit")]
		[EnumMember(Value = "Leading Mark")] 
		LeadingMark = 16,

		[System.ComponentModel.Description("ACourseAtSeaWhoseEndsAreIndicatedByRangesAshoreAndWhoseLengthHasBeenAccuratelyMeasuredForDeterminingTheSpeedOfVessels")]
		[EnumMember(Value = "Measured Distance")] 
		MeasuredDistance = 17,

		[System.ComponentModel.Description("ANoticeBoardOrSignIndicatingInformationToTheMariner")]
		[EnumMember(Value = "Notice Mark")] 
		NoticeMark = 18,

		[System.ComponentModel.Description("one9TssMarkTrafficSeparationSchemeMissingDefinition")]
		[EnumMember(Value = "TSS mark (Traffic Separation Scheme)")] 
		TssMarkTrafficSeparationScheme = 19,

		[System.ComponentModel.Description("AnAreaWithinWhichAnchoringIsNotPermitted")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		AnchoringProhibited = 20,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsProhibited")]
		[EnumMember(Value = "Berthing Prohibited Mark")] 
		BerthingProhibitedMark = 21,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichOvertakingIsGenerallyProhibited")]
		[EnumMember(Value = "Overtaking Prohibited")] 
		OvertakingProhibited = 22,

		[System.ComponentModel.Description("two3TwoWayTrafficProhibitedMarkMissingDefinition")]
		[EnumMember(Value = "two-way traffic prohibited mark")] 
		TwoWayTrafficProhibitedMark = 23,

		[System.ComponentModel.Description("AMarkIndicatingThatVesselsMustNotGenerateExcessiveWake")]
		[EnumMember(Value = "Reduced Wake Mark")] 
		ReducedWakeMark = 24,

		[System.ComponentModel.Description("AMarkIndicatingThatASpeedLimitApplies")]
		[EnumMember(Value = "Speed Limit Mark")] 
		SpeedLimitMark = 25,

		[System.ComponentModel.Description("AMarkIndicatingThePlaceWhereTheBowOfAShipMustStopWhenTrafficLightsShowRed")]
		[EnumMember(Value = "Stop Mark")] 
		StopMark = 26,

		[System.ComponentModel.Description("AMarkIndicatingThatSpecialCautionMustBeExercisedInTheVicinityOfTheMark")]
		[EnumMember(Value = "General Warning Mark")] 
		GeneralWarningMark = 27,

		[System.ComponentModel.Description("two8SoundShipSSirenMarkMissingDefinition")]
		[EnumMember(Value = "sound ship’s siren mark")] 
		SoundShipSSirenMark = 28,

		[System.ComponentModel.Description("two9RestrictedVerticalMissingDefinition")]
		[EnumMember(Value = "restricted vertical")] 
		RestrictedVertical = 29,

		[System.ComponentModel.Description("three0MaximumVesselSDraughtMarkMissingDefinition")]
		[EnumMember(Value = "maximum vessel’s draught mark")] 
		MaximumVesselSDraughtMark = 30,

		[System.ComponentModel.Description("AMarkIndicatingTheMinimumHorizontalSpaceAvailableForPassage")]
		[EnumMember(Value = "Restricted Horizontal Clearance Mark")] 
		RestrictedHorizontalClearanceMark = 31,

		[System.ComponentModel.Description("AMarkWarningOfStrongCurrents")]
		[EnumMember(Value = "Strong Current Warning Mark")] 
		StrongCurrentWarningMark = 32,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsAllowed")]
		[EnumMember(Value = "Berthing Permitted Mark")] 
		BerthingPermittedMark = 33,

		[System.ComponentModel.Description("AMarkIndicatingAnOverheadPowerCable")]
		[EnumMember(Value = "Overhead Power Cable Mark")] 
		OverheadPowerCableMark = 34,

		[System.ComponentModel.Description("AMarkIndicatingTheGradientOfTheSlopeOfADredgeChannelEdge")]
		[EnumMember(Value = "Channel Edge Gradient Mark")] 
		ChannelEdgeGradientMark = 35,

		[System.ComponentModel.Description("AMarkIndicatingThePresenceOfATelephone")]
		[EnumMember(Value = "Telephone Mark")] 
		TelephoneMark = 36,

		[System.ComponentModel.Description("AMarkIndicatingThatAFerryRouteCrossesTheShipRouteOftenUsedWithASoundShipSSirenMark")]
		[EnumMember(Value = "Ferry Crossing Mark")] 
		FerryCrossingMark = 37,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarinePipelinesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Pipeline Mark")] 
		PipelineMark = 39,

		[System.ComponentModel.Description("AMarkIndicatingAnAnchorageArea")]
		[EnumMember(Value = "Anchorage Mark")] 
		AnchorageMark = 40,

		[System.ComponentModel.Description("AMarkUsedToIndicateAClearingLine")]
		[EnumMember(Value = "Clearing Mark")] 
		ClearingMark = 41,

		[System.ComponentModel.Description("AMarkIndicatingTheLocationAtWhichARestrictionOrRequirementExists")]
		[EnumMember(Value = "Control Mark")] 
		ControlMark = 42,

		[System.ComponentModel.Description("AMarkIndicatingThatDivingMayTakePlaceInTheVicinity")]
		[EnumMember(Value = "Diving Mark")] 
		DivingMark = 43,

		[System.ComponentModel.Description("AMarkProvidingOrIndicatingAPlaceOfSafety")]
		[EnumMember(Value = "Refuge Beacon")] 
		RefugeBeacon = 44,

		[System.ComponentModel.Description("AMarkIndicatingAFoulGround")]
		[EnumMember(Value = "Foul Ground Mark")] 
		FoulGroundMark = 45,

		[System.ComponentModel.Description("AMarkInstalledForUseByYachtsmen")]
		[EnumMember(Value = "Yachting Mark")] 
		YachtingMark = 46,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereHelicoptersMayLand")]
		[EnumMember(Value = "Heliport Mark")] 
		HeliportMark = 47,

		[System.ComponentModel.Description("AMarkIndicatingALocationAtWhichAGnssPositionHasBeenAccuratelyDetermined")]
		[EnumMember(Value = "GNSS Mark")] 
		GnssMark = 48,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereSeaplanesLand")]
		[EnumMember(Value = "Seaplane Landing Mark")] 
		SeaplaneLandingMark = 49,

		[System.ComponentModel.Description("AMarkIndicatingThatEntryIsProhibited")]
		[EnumMember(Value = "Entry Prohibited Mark")] 
		EntryProhibitedMark = 50,

		[System.ComponentModel.Description("AMarkIndicatingThatWorkGenerallyConstructionIsInProgress")]
		[EnumMember(Value = "Work in Progress Mark")] 
		WorkInProgressMark = 51,

		[System.ComponentModel.Description("five2MarkWithUnknownMissingDefinition")]
		[EnumMember(Value = "mark with unknown")] 
		MarkWithUnknown = 52,

		[System.ComponentModel.Description("AMarkIndicatingABoreholeThatProducesOrIsCapableOfProducingOilOrNaturalGas")]
		[EnumMember(Value = "Wellhead Mark")] 
		WellheadMark = 53,

		[System.ComponentModel.Description("AMarkIndicatingThePointAtWhichAChannelDividesSeparatelyIntoTwoChannels")]
		[EnumMember(Value = "Channel Separation Mark")] 
		ChannelSeparationMark = 54,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOfAFishMusselOysterOrPearlFarmCulture")]
		[EnumMember(Value = "Marine Farm Mark")] 
		MarineFarmMark = 55,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOrTheExtentOfAnArtificialReef")]
		[EnumMember(Value = "Artificial Reef Mark")] 
		ArtificialReefMark = 56,

		[System.ComponentModel.Description("AMarkUsedYearRoundThatMayBeSubmergedWhenIcePassesThroughTheArea")]
		[EnumMember(Value = "Ice Mark")] 
		IceMark = 57,

		[System.ComponentModel.Description("AMarkUsedToDefineTheBoundaryOfANatureReserve")]
		[EnumMember(Value = "Nature Reserve Mark")] 
		NatureReserveMark = 58,

		[System.ComponentModel.Description("AFishAggregatingOrAggregationDeviceFadIsAManMadeObjectUsedToAttractOceanGoingPelagicFishSuchAsMarlinTunaAndMahiMahiDolphinFishTheyUsuallyConsistOfBuoysOrFloatsTetheredToTheOceanFloorWithConcreteBlocksOrAdrift")]
		[EnumMember(Value = "Fish Aggregating Device")] 
		FishAggregatingDevice = 59,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfAWreck")]
		[EnumMember(Value = "Wreck Mark")] 
		WreckMark = 60,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACustomsCheckpoint")]
		[EnumMember(Value = "Customs Mark")] 
		CustomsMark = 61,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACauseway")]
		[EnumMember(Value = "Causeway Mark")] 
		CausewayMark = 62,

		[System.ComponentModel.Description("ASurfaceFollowingBuoyUsedToMeasureWaveActivity")]
		[EnumMember(Value = "Wave Recorder")] 
		WaveRecorder = 63,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum depthUnits : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		Metres = 1,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPatrolArea : int {
		[System.ComponentModel.Description("five014wDispositionGridMissingDefinition")]
		[EnumMember(Value = "4W disposition grid")] 
		fourwDispositionGrid = 501,

		[System.ComponentModel.Description("five02OperationalNavalPatrolMissingDefinition")]
		[EnumMember(Value = "Operational/Naval Patrol")] 
		OperationalNavalPatrol = 502,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum gradient : int {
		[System.ComponentModel.Description("five01SteepMissingDefinition")]
		[EnumMember(Value = "Steep")] 
		Steep = 501,

		[System.ComponentModel.Description("five02ModerateMissingDefinition")]
		[EnumMember(Value = "Moderate")] 
		Moderate = 502,

		[System.ComponentModel.Description("five03GentleMissingDefinition")]
		[EnumMember(Value = "Gentle")] 
		Gentle = 503,

		[System.ComponentModel.Description("five04MildMissingDefinition")]
		[EnumMember(Value = "Mild")] 
		Mild = 504,

		[System.ComponentModel.Description("ALevelTractOfLandAsTheBedOfADryLakeOrAnAreaFrequentlyUncoveredAtLowTideUsuallyInPlural")]
		[EnumMember(Value = "Flat")] 
		Flat = 505,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalPointOrientation : int {
		[System.ComponentModel.Description("five01NorthSouthMissingDefinition")]
		[EnumMember(Value = "north/south")] 
		NorthSouth = 501,

		[System.ComponentModel.Description("five02EastWestMissingDefinition")]
		[EnumMember(Value = "east/west")] 
		EastWest = 502,

		[System.ComponentModel.Description("five03NortheastSouthwestMissingDefinition")]
		[EnumMember(Value = "northeast/southwest")] 
		NortheastSouthwest = 503,

		[System.ComponentModel.Description("five04NorthwestSoutheastMissingDefinition")]
		[EnumMember(Value = "northwest/southeast")] 
		NorthwestSoutheast = 504,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRestrictedArea : int {
		[System.ComponentModel.Description("TheAreaAroundAnOffshoreInstallationWithinWhichVesselsAreProhibitedFromEnteringWithoutPermissionSpecialRegulationsProtectInstallationsWithinASafetyZoneAndVesselsOfAllNationalitiesAreRequiredToRespectTheZone")]
		[EnumMember(Value = "Offshore Safety Zone")] 
		OffshoreSafetyZone = 1,

		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveItsFloraFaunaPhysicalFeaturesEtc")]
		[EnumMember(Value = "Nature Reserve")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("APlaceWhereBirdsAreBredAndProtected")]
		[EnumMember(Value = "Bird Sanctuary")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("APlaceWhereWildAnimalsOrBirdsHuntedForSportOrFoodAreKeptUndisturbedForPrivateUse")]
		[EnumMember(Value = "Game Reserve")] 
		GameReserve = 6,

		[System.ComponentModel.Description("APlaceWhereSealsAreProtected")]
		[EnumMember(Value = "Seal Sanctuary")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("AnAreaUsuallyAboutTwoCablesDiameterWithinWhichShipsMagneticFieldsMayBeMeasuredSensingInstrumentsAndCablesAreInstalledOnTheSeabedInTheRangeAndThereAreCablesLeadingFromTheRangeToAControlPositionAshore")]
		[EnumMember(Value = "Degaussing Range")] 
		DegaussingRange = 8,

		[System.ComponentModel.Description("AnAreaControlledByTheMilitaryInWhichRestrictionsMayApply")]
		[EnumMember(Value = "Military Area")] 
		MilitaryArea = 9,

		[System.ComponentModel.Description("AnAreaAroundCertainWrecksOfHistoricalImportanceToProtectTheWrecksFromUnauthorizedInterferenceByDivingSalvageOrDepositionIncludingAnchoring")]
		[EnumMember(Value = "Historic Wreck Area")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("AnAreaAroundANavigationalAidWhichVesselsAreProhibitedFromEntering")]
		[EnumMember(Value = "Navigational Aid Safety Zone")] 
		NavigationalAidSafetyZone = 12,

		[System.ComponentModel.Description("AnAreaLaidAndMaintainedWithExplosiveMinesForDefenceOrPracticePurposes")]
		[EnumMember(Value = "Minefield")] 
		Minefield = 14,

		[System.ComponentModel.Description("AnAreaInWhichPeopleMaySwimAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Swimming Area")] 
		SwimmingArea = 18,

		[System.ComponentModel.Description("AnAreaReservedForVesselsWaitingToEnterAHarbour")]
		[EnumMember(Value = "Waiting Area")] 
		WaitingArea = 19,

		[System.ComponentModel.Description("AnAreaWhereMarineResearchTakesPlace")]
		[EnumMember(Value = "Research Area")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("AnAreaWhereDredgingIsTakingPlace")]
		[EnumMember(Value = "Dredging Area")] 
		DredgingArea = 21,

		[System.ComponentModel.Description("APlaceWhereFishIncludingShellfishAndCrustaceansAreProtected")]
		[EnumMember(Value = "Fish Sanctuary")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveTheRelationOfPlantsAndLivingCreaturesToEachOtherAndToTheirSurroundings")]
		[EnumMember(Value = "Ecological Reserve")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("AnAreaInWhichAVesselsSpeedMustBeReducedInOrderToReduceTheSizeOfTheWakeItProduces")]
		[EnumMember(Value = "No Wake Area")] 
		NoWakeArea = 24,

		[System.ComponentModel.Description("AnAreaWhereVesselsTurn")]
		[EnumMember(Value = "Swinging Area")] 
		SwingingArea = 25,

		[System.ComponentModel.Description("AGenericTermWhichMayBeUsedToDescribeAWideRangeOfAreasConsideredSensitiveForAVarietyOfEnvironmentalReasons")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area")] 
		EnvironmentallySensitiveSeaArea = 27,

		[System.ComponentModel.Description("AnAreaThatNeedsSpecialProtectionThroughActionByImoBecauseOfItsSignificanceForRegionalEcologicalSocioEconomicOrScientificReasonsAndBecauseItMayBeVulnerableToDamageByInternationalShippingActivities")]
		[EnumMember(Value = "Particularly Sensitive Sea Area")] 
		ParticularlySensitiveSeaArea = 28,

		[System.ComponentModel.Description("AnAreaNearAFairwayWhereVesselsCanGoToClearTheWayOrMakeAnAboutTurnAndPossiblyReturnToAWaitingAreaWhenNauticalConditionsImposeIt")]
		[EnumMember(Value = "Disengagement Area")] 
		DisengagementArea = 29,

		[System.ComponentModel.Description("AnAreaInWhichDefenceLawAndTreatyEnforcementAndCounterTerrorismActivitiesThatFallWithinThePortAndMaritimeDomainApply")]
		[EnumMember(Value = "Port Security Area")] 
		PortSecurityArea = 30,

		[System.ComponentModel.Description("APlaceWhereCoralIsProtected")]
		[EnumMember(Value = "Coral Sanctuary")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("AnAreaWithinWhichRecreationalActivitiesRegularlyTakePlaceAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Recreation Area")] 
		RecreationArea = 32,

		[System.ComponentModel.Description("AnAreaWithinWhichNotificationIsRequiredBetweenRespectiveMilitaryAuthoritiesOfFutureMilitaryExercisesActivities")]
		[EnumMember(Value = "Maritime Notification Area")] 
		MaritimeNotificationArea = 501,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum expositionOfSounding : int {
		[System.ComponentModel.Description("TheDepthCorrespondsToTheDepthRangeOfTheSurroundingDepthAreaThatIsTheDepthIsNotShoalerThanTheMinimumDepthOfTheSurroundingDepthAreaOrDeeperThanTheMaximumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Within the Range of Depth of the Surrounding Depth Area")] 
		WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,

		[System.ComponentModel.Description("TheDepthIsShoalerThanTheMinimumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Shoaler Than the Range of Depth of the Surrounding Depth Area")] 
		ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,

		[System.ComponentModel.Description("TheDepthIsDeeperThanTheMaximumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Deeper Than the Range of Depth of the Surrounding Depth Area")] 
		DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum controlledAirspaceClassDesignation : int {
		[System.ComponentModel.Description("five01AMissingDefinition")]
		[EnumMember(Value = "A")] 
		A = 501,

		[System.ComponentModel.Description("five02BMissingDefinition")]
		[EnumMember(Value = "B")] 
		B = 502,

		[System.ComponentModel.Description("five03CMissingDefinition")]
		[EnumMember(Value = "C")] 
		C = 503,

		[System.ComponentModel.Description("five04DMissingDefinition")]
		[EnumMember(Value = "D")] 
		D = 504,

		[System.ComponentModel.Description("five0fiveEMissingDefinition")]
		[EnumMember(Value = "E")] 
		E = 505,

		[System.ComponentModel.Description("five06FMissingDefinition")]
		[EnumMember(Value = "F")] 
		F = 506,

		[System.ComponentModel.Description("five07GMissingDefinition")]
		[EnumMember(Value = "G")] 
		G = 507,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum statusOfSmallBottomObject : int {
		[System.ComponentModel.Description("five04IdentifiedNomboMissingDefinition")]
		[EnumMember(Value = "Identified (NOMBO)")] 
		IdentifiedNombo = 504,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buoyShape : int {
		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasApproximatelyTheShapeOrTheAppearanceOfAPointedConeWithThePointUpwards")]
		[EnumMember(Value = "Conical")] 
		Conical = 1,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheShapeOfACylinderOrATruncatedConeThatApproximatesToACylinderWithAFlatEndUppermost")]
		[EnumMember(Value = "Can")] 
		Can = 2,

		[System.ComponentModel.Description("ShapedLikeASphereWhichIsABodyTheSurfaceOfWhichIsAtAllPointsEquidistantFromTheCentre")]
		[EnumMember(Value = "Spherical")] 
		Spherical = 3,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureIsANarrowVerticalStructurePillarOrLatticeTower")]
		[EnumMember(Value = "Pillar")] 
		Pillar = 4,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfAPoleOrOfAVeryLongCylinderFloatingUpright")]
		[EnumMember(Value = "Spar")] 
		Spar = 5,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfABarrelOrCylinderFloatingHorizontally")]
		[EnumMember(Value = "Barrel")] 
		Barrel = 6,

		[System.ComponentModel.Description("AVeryLargeBuoyDesignedToCarryASignalLightOfHighLuminousIntensityAtAHighElevation")]
		[EnumMember(Value = "Superbuoy")] 
		Superbuoy = 7,

		[System.ComponentModel.Description("ASpeciallyConstructedShuttleShapedBuoyWhichIsUsedInIceConditions")]
		[EnumMember(Value = "Ice Buoy")] 
		IceBuoy = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum heightLengthUnits : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		Metres = 1,

		[System.ComponentModel.Description("AUnitOfLengthEqualTo12Inches16OfAFathomOr30480Centimetres")]
		[EnumMember(Value = "Feet")] 
		Feet = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("oneCircularNonDirectionalMarineOrAeroMarineRadiobeaconMissingDefinition")]
		[EnumMember(Value = "circular (non-directional) marine or aero-marine radiobeacon")] 
		CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationTheEmissionsOfWhichAreIntendedToProvideADefiniteTrackForGuidance")]
		[EnumMember(Value = "Directional Radiobeacon")] 
		DirectionalRadiobeacon = 2,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationEmittingABeamOfWavesToWhichAUniformTurningMovementIsGivenTheBearingOfTheStationBeingDeterminedByMeansOfAnOrdinaryListeningReceiverAndAStopWatchAlsoReferredToAsARotatingLoopRadiobeacon")]
		[EnumMember(Value = "Rotating Pattern Radiobeacon")] 
		RotatingPatternRadiobeacon = 3,

		[System.ComponentModel.Description("ATypeOfLongRangePositionFixingBeacon")]
		[EnumMember(Value = "Consol Beacon")] 
		ConsolBeacon = 4,

		[System.ComponentModel.Description("fiveRadioDirectionFindingStationMissingDefinition")]
		[EnumMember(Value = "radio direction-finding station")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("ARadioStationWhichIsPreparedToProvideQtgServiceThatIsToSayToTransmitUponRequestFromAShipARadioSignalTheBearingOfWhichCanBeTakenByThatShip")]
		[EnumMember(Value = "Coast Radio Station Providing QTG Service")] 
		CoastRadioStationProvidingQtgService = 6,

		[System.ComponentModel.Description("ARadioBeaconDesignedForAeronauticalUse")]
		[EnumMember(Value = "Aeronautical Radiobeacon")] 
		AeronauticalRadiobeacon = 7,

		[System.ComponentModel.Description("TheDeccaNavigatorSystemIsAHighAccuracyShortToMediumRangeRadioNavigationalAidIntendedForCoastalAndLandfallNavigation")]
		[EnumMember(Value = "Decca")] 
		Decca = 8,

		[System.ComponentModel.Description("nineLoranCMissingDefinition")]
		[EnumMember(Value = "Loran-C")] 
		LoranC = 9,

		[System.ComponentModel.Description("DifferentialGnssIsImplementedByPlacingAGnssMonitorReceiverAtAPreciselyKnownLocationInsteadOfComputingANavigationFixTheMonitorDeterminesTheRangeErrorToEveryGnssSatelliteItCanTrackTheseRangingErrorsAreThenTransmittedToLocalUsersWhereTheyAreAppliedAsCorrectionsBeforeComputingTheNavigationResult")]
		[EnumMember(Value = "Differential GNSS")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("AnElectronicPositionFixingSystemUsedMainlyByAircraft")]
		[EnumMember(Value = "Toran")] 
		Toran = 11,

		[System.ComponentModel.Description("ALongRangeRadioNavigationalAidWhichOperatesWithinTheVlfFrequencyBandTheSystemComprisesEightLandBasedStations")]
		[EnumMember(Value = "Omega")] 
		Omega = 12,

		[System.ComponentModel.Description("ARangingPositionFixingSystemOperatingAt420450MhzOverARangeOfUpTo400Km")]
		[EnumMember(Value = "Syledis")] 
		Syledis = 13,

		[System.ComponentModel.Description("ALowFrequencyElectronicPositionFixingSystemUsingPulsedTransmissionsAt100Khz")]
		[EnumMember(Value = "Chaika")] 
		Chaika = 14,

		[System.ComponentModel.Description("TheEquipmentNeededAtOneStationToCarryOnTwoWayVoiceCommunicationByRadioWavesOnly")]
		[EnumMember(Value = "Radio Telephone Station")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("AnOnshoreAisUnitThatMonitorsTrafficInTheWaterways")]
		[EnumMember(Value = "AIS Base Station")] 
		AisBaseStation = 20,

		[System.ComponentModel.Description("five04DistanceMeasuringEquipmentDmeMissingDefinition")]
		[EnumMember(Value = "Distance Measuring Equipment (DME)")] 
		DistanceMeasuringEquipmentDme = 504,

		[System.ComponentModel.Description("five0fiveNonDirectionalRadioBeaconNdbMissingDefinition")]
		[EnumMember(Value = "Non-directional Radio Beacon (NDB)")] 
		NonDirectionalRadioBeaconNdb = 505,

		[System.ComponentModel.Description("five06RadarResponderBeaconRaconMissingDefinition")]
		[EnumMember(Value = "Radar Responder Beacon (RACON)")] 
		RadarResponderBeaconRacon = 506,

		[System.ComponentModel.Description("five08VhfOmniDirectionalRadioRangeVorMissingDefinition")]
		[EnumMember(Value = "VHF Omni Directional Radio Range (VOR)")] 
		VhfOmniDirectionalRadioRangeVor = 508,

		[System.ComponentModel.Description("five09VhfOmniDirectionalVortacMissingDefinition")]
		[EnumMember(Value = "VHF Omni Directional (VORTAC)")] 
		VhfOmniDirectionalVortac = 509,

		[System.ComponentModel.Description("five10TacticalAirNavigationEquipmentTacanMissingDefinition")]
		[EnumMember(Value = "Tactical Air Navigation Equipment (TACAN)")] 
		TacticalAirNavigationEquipmentTacan = 510,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRescueStation : int {
		[System.ComponentModel.Description("APlaceWhereEquipmentForSavingLifeAtSeaIsMaintainedTheTypeOfLifeboatMayVaryFromFastLongDistanceBoatsToInflatableInshoreBoats")]
		[EnumMember(Value = "Rescue Station with Lifeboat")] 
		RescueStationWithLifeboat = 1,

		[System.ComponentModel.Description("ALifeSavingStationEquippedWithLineCarryingRocketApparatus")]
		[EnumMember(Value = "Rescue Station with Rocket")] 
		RescueStationWithRocket = 2,

		[System.ComponentModel.Description("ShelterOrProtectionFromDangerOrDistressAtSea")]
		[EnumMember(Value = "Refuge for Shipwrecked Mariners")] 
		RefugeForShipwreckedMariners = 4,

		[System.ComponentModel.Description("ShelterOrProtectionFromDangerInAreasExposedToExtremeAndSuddenTidesOrTidalStreams")]
		[EnumMember(Value = "Refuge for Intertidal Area Walkers")] 
		RefugeForIntertidalAreaWalkers = 5,

		[System.ComponentModel.Description("APlaceWhereALifeboatIsMooredReadyForUse")]
		[EnumMember(Value = "Lifeboat Lying at a Mooring")] 
		LifeboatLyingAtAMooring = 6,

		[System.ComponentModel.Description("ARadioStationReservedForEmergencySituationsMightAlsoBeAPublicTelephone")]
		[EnumMember(Value = "Aid Radio Station")] 
		AidRadioStation = 7,

		[System.ComponentModel.Description("APlaceWhereFirstAidEquipmentIsAvailable")]
		[EnumMember(Value = "First Aid Equipment")] 
		FirstAidEquipment = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum product : int {
		[System.ComponentModel.Description("AThickSlipperyLiquidThatWillNotDissolveInWaterUsuallyPetroleumBasedInTheContextOfStorageTanks")]
		[EnumMember(Value = "Oil")] 
		Oil = 1,

		[System.ComponentModel.Description("ASubstanceWithParticlesThatCanMoveFreelyUsuallyAFuelSubstanceInTheContextOfStorageTanks")]
		[EnumMember(Value = "Gas")] 
		Gas = 2,

		[System.ComponentModel.Description("AColourlessOdourlessTastelessLiquidThatIsACompoundOfHydrogenAndOxygen")]
		[EnumMember(Value = "Water")] 
		Water = 3,

		[System.ComponentModel.Description("AGeneralTermForRockAndRockFragmentsRangingInSizeFromPebblesAndGravelToBouldersOrLargeRockMasses")]
		[EnumMember(Value = "Stone")] 
		Stone = 4,

		[System.ComponentModel.Description("AHardBlackMineralThatIsBurnedAsFuel")]
		[EnumMember(Value = "Coal")] 
		Coal = 5,

		[System.ComponentModel.Description("ASolidRockOrMineralFromWhichMetalIsObtained")]
		[EnumMember(Value = "Ore")] 
		Ore = 6,

		[System.ComponentModel.Description("AnySubstanceObtainedByOrUsedInAChemicalProcess")]
		[EnumMember(Value = "Chemicals")] 
		Chemicals = 7,

		[System.ComponentModel.Description("WaterThatIsSuitableForHumanConsumption")]
		[EnumMember(Value = "Drinking Water")] 
		DrinkingWater = 8,

		[System.ComponentModel.Description("AWhiteFluidSecretedByFemaleMammalsAsFoodForTheirYoung")]
		[EnumMember(Value = "Milk")] 
		Milk = 9,

		[System.ComponentModel.Description("AMineralFromWhichAluminumIsObtained")]
		[EnumMember(Value = "Bauxite")] 
		Bauxite = 10,

		[System.ComponentModel.Description("ASolidSubstanceObtainedAfterGasAndTarHaveBeenExtractedFromCoalUsedAsAFuel")]
		[EnumMember(Value = "Coke")] 
		Coke = 11,

		[System.ComponentModel.Description("AnOblongLumpOfCastIronMetal")]
		[EnumMember(Value = "Iron Ingots")] 
		IronIngots = 12,

		[System.ComponentModel.Description("SodiumChlorideObtainedFromMinesOrByTheEvaporationOfSeaWater")]
		[EnumMember(Value = "Salt")] 
		Salt = 13,

		[System.ComponentModel.Description("LooseMaterialConsistingOfSmallButEasilyDistinguishableSeparateGrainsBetween00625And2000MillimetresInDiameter")]
		[EnumMember(Value = "Sand")] 
		Sand = 14,

		[System.ComponentModel.Description("WoodPreparedForUseInBuildingOrCarpentry")]
		[EnumMember(Value = "Timber")] 
		Timber = 15,

		[System.ComponentModel.Description("one6SawdustWoodChipsMissingDefinition")]
		[EnumMember(Value = "sawdust/wood chips")] 
		SawdustWoodChips = 16,

		[System.ComponentModel.Description("DiscardedMetalSuitableForBeingReprocessed")]
		[EnumMember(Value = "Scrap Metal")] 
		ScrapMetal = 17,

		[System.ComponentModel.Description("one8LiquefiedNaturalGasLngMissingDefinition")]
		[EnumMember(Value = "liquefied natural gas (LNG)")] 
		LiquefiedNaturalGasLng = 18,

		[System.ComponentModel.Description("ACompressedGasConsistingOfFlammableLightHydrocarbonsAndDerivedFromPetroleum")]
		[EnumMember(Value = "Liquefied Petroleum Gas")] 
		LiquefiedPetroleumGas = 19,

		[System.ComponentModel.Description("TheFermentedJuiceOfGrapes")]
		[EnumMember(Value = "Wine")] 
		Wine = 20,

		[System.ComponentModel.Description("ASubstanceMadeOfPowderedLimeAndClayMixedWithWater")]
		[EnumMember(Value = "Cement")] 
		Cement = 21,

		[System.ComponentModel.Description("ASmallHardSeedEspeciallyThatOfAnyCerealPlantSuchAsWheatRiceCornRyeEtc")]
		[EnumMember(Value = "Grain")] 
		Grain = 22,

		[System.ComponentModel.Description("ElectricChargeOrCurrent")]
		[EnumMember(Value = "Electricity")] 
		Electricity = 23,

		[System.ComponentModel.Description("TheSolidFormOfWater")]
		[EnumMember(Value = "Ice")] 
		Ice = 24,

		[System.ComponentModel.Description("ParticlesOfLessThan0002mmStiffStickyEarthThatBecomesHardWhenBaked")]
		[EnumMember(Value = "Clay")] 
		Clay = 25,

		[System.ComponentModel.Description("SolidFuelMaterialWhereinTheParticlesFirmlyCohereIsHardAndCompactAndIsBurntAsASourceOfHeatOrPower")]
		[EnumMember(Value = "Solid Fuel")] 
		SolidFuel = 502,

		[System.ComponentModel.Description("FlammableLiquidsAndGasesASubstanceWhichIsEitherInAStateWhereMoleculesMoveFreelyAboutOneAnotherButDoNotFlyApartOrInAConditionInWhichItHasNoDefiniteBoundariesOrFixedVolumeButWhichIsCombustibleUnderNormalAtmosphericConditions")]
		[EnumMember(Value = "Flammable Liquids And Gases")] 
		FlammableLiquidsAndGases = 503,

		[System.ComponentModel.Description("FerrousElementsAndOresUnrefinedAndRefinedAChemicallyInseparableSubstanceOrSolidNaturallyOccurringMineralAggregateFromWhichOneOrMoreValuableConstituentsMayBeRecoveredByTreatmentOrAManufacturingProcessAndWhichDoesContainIronInItsTrivalentForm")]
		[EnumMember(Value = "Ferrous Elements And Ores")] 
		FerrousElementsAndOres = 505,

		[System.ComponentModel.Description("NonFerrousElementsAndOresUnrefinedAndRefinedAChemicallyInseparableSubstanceOrSolidNaturallyOccurringMineralAggregateFromWhichOneOrMoreValuableConstituentsMayBeRecoveredByTreatmentOrAManufacturingProcessAndWhichDoesNotContainIronInItsTrivalentForm")]
		[EnumMember(Value = "Non Ferrous Elements And Ores")] 
		NonFerrousElementsAndOres = 506,

		[System.ComponentModel.Description("ConstructedFromMetal")]
		[EnumMember(Value = "Metal")] 
		Metal = 507,

		[System.ComponentModel.Description("SubstancesProducedByAProcessOfInOrganicNatureASubstanceNeitherAnimalOrVegetableNormallyObtainedByMining")]
		[EnumMember(Value = "Minerals")] 
		Minerals = 508,

		[System.ComponentModel.Description("NaturalAndChemicalASubstanceAddedToTheSoilToIncreaseItsProductivityItMayBeProducedByOrPertainingToNatureNotTheWorkOfManOrWhichMayBeFormedFromASubstanceOrResultingFromAReactionInvolvingChangesToAtomsOrMolecules")]
		[EnumMember(Value = "Fertiliser")] 
		Fertiliser = 509,

		[System.ComponentModel.Description("UnprocessedAndProductsTheSubstanceOfTreesInUnprocessedFormTheWoodHasNotUndergoneChangeByAMethodOfManufactureIntoProductsBeingTheManufactureOfGoodsOrCommoditiesFromWood")]
		[EnumMember(Value = "Wood")] 
		Wood = 510,

		[System.ComponentModel.Description("UnprocessedAndProductsStrongWaterproofElasticMaterialOriginallyMadeFromTheDriedSapOfATropicalTreeNowUsuallySyntheticInUnprocessedFormTheRubberHasNotUndergoneChangeByAMethodOfManufactureIntoProductsBeingTheManufactureOfGoodsOrCommoditiesFromRubber")]
		[EnumMember(Value = "Rubber")] 
		Rubber = 511,

		[System.ComponentModel.Description("five13NaturalFibresAndMaterialsInGeneralMissingDefinition")]
		[EnumMember(Value = "natural fibres and materials in general")] 
		NaturalFibresAndMaterialsInGeneral = 513,

		[System.ComponentModel.Description("five14FoodstuffsSolidMissingDefinition")]
		[EnumMember(Value = "foodstuffs, solid")] 
		FoodstuffsSolid = 514,

		[System.ComponentModel.Description("five1fiveFoodstuffsLiquidMissingDefinition")]
		[EnumMember(Value = "foodstuffs, liquid")] 
		FoodstuffsLiquid = 515,

		[System.ComponentModel.Description("five16FoodstuffsPreservedMissingDefinition")]
		[EnumMember(Value = "foodstuffs, preserved")] 
		FoodstuffsPreserved = 516,

		[System.ComponentModel.Description("ItemsRelatingToTheWholeOrMostNotSpecialisedOfBroadOverallCharacterMixedCharacterisedByScopeOrVarietyItemsCombinedOrAssociated")]
		[EnumMember(Value = "General And Mixed Goods")] 
		GeneralAndMixedGoods = 517,

		[System.ComponentModel.Description("PhysicalMatterConsistingOfARelativelySmallAndHardButUsuallySeparateParticlesOrInAFormWhichIsDustyOrEasilyCrumbledIntoTinyLooseParticles")]
		[EnumMember(Value = "Granular Or Powdery Material")] 
		GranularOrPowderyMaterial = 519,

		[System.ComponentModel.Description("MachineryApparatusUsuallyPoweredByElectricityDesignedToPerformASpecificTaskMechanicalPartsComponentsOfVehiclesOrMachines")]
		[EnumMember(Value = "Machinery And Mechanical Parts")] 
		MachineryAndMechanicalParts = 520,

		[System.ComponentModel.Description("ThatOutOfWhichAnythingIsOrMayBeMadeEquipmentOrImplementsPartsThatMayBePutTogether")]
		[EnumMember(Value = "Construction Materials")] 
		ConstructionMaterials = 521,

		[System.ComponentModel.Description("AMeansOfConveyanceOrTransportEspeciallyAStructureWithWheelsInOrOnWhichPeopleOrThingsAreTransportedByLand")]
		[EnumMember(Value = "Vehicles")] 
		Vehicles = 522,

		[System.ComponentModel.Description("StructureOrMachineForTravellingInTheAir")]
		[EnumMember(Value = "Aircraft")] 
		Aircraft = 523,

		[System.ComponentModel.Description("ARailOrSetOfParallelRailsOnWhichATrainTramOrRailWagonRuns")]
		[EnumMember(Value = "Railway")] 
		Railway = 524,

		[System.ComponentModel.Description("MovableStructuresForGivingShelterNormallyPrefabricated")]
		[EnumMember(Value = "Portable Buildings")] 
		PortableBuildings = 525,

		[System.ComponentModel.Description("BoxesForCargoTransportWithStandardizedDimensions")]
		[EnumMember(Value = "Containers")] 
		Containers = 526,

		[System.ComponentModel.Description("DevicesBasedOnTheTechnologyOfTheConductionOfElectricityInAVacuumGasOrASemiconductor")]
		[EnumMember(Value = "Electronics")] 
		Electronics = 527,

		[System.ComponentModel.Description("ConstructedFromPlastic")]
		[EnumMember(Value = "Plastic")] 
		Plastic = 528,

		[System.ComponentModel.Description("ColouringMatterEspeciallyInLiquidFormForImpartingColourToASurface")]
		[EnumMember(Value = "Paint")] 
		Paint = 529,

		[System.ComponentModel.Description("five30RefuseAlsoKnownAsRubbishGarbageTrashAndWasteMissingDefinition")]
		[EnumMember(Value = "refuse (also known as rubbish/garbage/trash) and waste")] 
		RefuseAlsoKnownAsRubbishGarbageTrashAndWaste = 530,

		[System.ComponentModel.Description("RelatingToCausedByOrExhibitingRadioactivityEmissionOfRadianElementsCapableOfSpontaneouslyEmittingAlphaBetaOrSometimesGammaRaysByTheDisintegrationOfTheNucleiOfAtoms")]
		[EnumMember(Value = "Radioactive Material")] 
		RadioactiveMaterial = 531,

		[System.ComponentModel.Description("MilitaryWeaponsATotalMeansOfMakingWarDefensiveEquipment")]
		[EnumMember(Value = "Armament")] 
		Armament = 532,

		[System.ComponentModel.Description("PeopleInGeneral")]
		[EnumMember(Value = "Personnel")] 
		Personnel = 533,

		[System.ComponentModel.Description("five34AnimalsLandAndSeaAndBirdsMissingDefinition")]
		[EnumMember(Value = "animals (land and sea) and birds")] 
		AnimalsLandAndSeaAndBirds = 534,

		[System.ComponentModel.Description("VertebrateColdBloodedAnimalWithGillsLivingInWater")]
		[EnumMember(Value = "Fish")] 
		Fish = 535,

		[System.ComponentModel.Description("ShelledAquaticInvertebrates")]
		[EnumMember(Value = "Shellfish And Crustaceans")] 
		ShellfishAndCrustaceans = 536,

		[System.ComponentModel.Description("MaterialCarriedByAShipToEnsureItsStability")]
		[EnumMember(Value = "Ballast")] 
		Ballast = 537,

		[System.ComponentModel.Description("DieselOilAvailable")]
		[EnumMember(Value = "Diesel Oil")] 
		DieselOil = 540,

		[System.ComponentModel.Description("five41PetrolGasolineMissingDefinition")]
		[EnumMember(Value = "petrol/gasoline")] 
		PetrolGasoline = 541,

		[System.ComponentModel.Description("PersonsTravellingInAMeansOfTransportOperatedByOthers")]
		[EnumMember(Value = "Passengers")] 
		Passengers = 542,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFerry : int {
		[System.ComponentModel.Description("AFerryWhichMayHaveRoutesThatVaryWithWeatherTideAndTraffic")]
		[EnumMember(Value = "Free Moving Ferry")] 
		FreeMovingFerry = 1,

		[System.ComponentModel.Description("AFerryThatFollowsAFixedRouteGuidedByACable")]
		[EnumMember(Value = "Cable Ferry")] 
		CableFerry = 2,

		[System.ComponentModel.Description("AWinterTimeFerryWhichCrossesALead")]
		[EnumMember(Value = "Ice Ferry")] 
		IceFerry = 3,

		[System.ComponentModel.Description("AHighSpeedWaterVesselForCivilianUse")]
		[EnumMember(Value = "High Speed Ferry")] 
		HighSpeedFerry = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfObstruction : int {
		[System.ComponentModel.Description("oneSnagStumpMissingDefinition")]
		[EnumMember(Value = "snag/stump")] 
		SnagStump = 1,

		[System.ComponentModel.Description("ASubmarineStructureProjectingSomeDistanceAboveTheSeabedAndCappingATemporarilyAbandonedOrSuspendedOilOrGasWell")]
		[EnumMember(Value = "Wellhead")] 
		Wellhead = 2,

		[System.ComponentModel.Description("AStructureOnAnOutfallThroughWhichLiquidsAreDischargedTheStructureWillUsuallyProjectAboveTheLevelOfTheOutfallAndCanBeAnObstructionToNavigation")]
		[EnumMember(Value = "Diffuser")] 
		Diffuser = 3,

		[System.ComponentModel.Description("APermanentMarineStructureUsuallyDesignedToSupportOrElevatePipelinesEspeciallyAStructureEnclosingAScreeningDeviceAtTheOffshoreEndOfAPotableWaterIntakePipeTheStructureIsCommonlyAHeavyTimberEnclosureThatHasBeenSunkenWithRocksOrOtherDebris")]
		[EnumMember(Value = "Crib")] 
		Crib = 4,

		[System.ComponentModel.Description("AreasEstablishedByPrivateInterestsUsuallySportFishermenToSimulateNaturalReefsAndWrecksThatAttractFishTheReefsAreConstructedByDumpingAssortedJunkInAreasWhichMayBeOfVerySmallExtentOrMayStretchAConsiderableDistanceAlongADepthContour")]
		[EnumMember(Value = "Fish Haven")] 
		FishHaven = 5,

		[System.ComponentModel.Description("AnAreaOfNumerousUnidentifiedDangersToNavigationTheAreaServesAsAWarningToTheMarinerThatAllDangersAreNotIdentifiedIndividuallyAndThatNavigationThroughTheAreaMayBeHazardous")]
		[EnumMember(Value = "Foul Area")] 
		FoulArea = 6,

		[System.ComponentModel.Description("FloatingBarriersAnchoredToTheBottomUsedToDeflectThePathOfFloatingIceInOrderToPreventTheObstructionOfLocksIntakesEtcAndToPreventDamageToBridgePiersAndOtherStructures")]
		[EnumMember(Value = "Ice Boom")] 
		IceBoom = 8,

		[System.ComponentModel.Description("EquipmentSuchAsAnchorsConcreteBlocksChainsAndCablesEtcUsedToPositionFloatingStructuresSuchAsTrotAndMooringBuoysEtc")]
		[EnumMember(Value = "Ground Tackle")] 
		GroundTackle = 9,

		[System.ComponentModel.Description("AFloatingBarrierUsedToProtectARiverOrHarbourMouthOrToCreateAShelteredAreaForStoragePurposes")]
		[EnumMember(Value = "Boom")] 
		Boom = 10,

		[System.ComponentModel.Description("ADeviceToExtractEnergyFromTheSurfaceMotionOfOceanWavesOrFromPressureFluctuationsBelowTheSurface")]
		[EnumMember(Value = "Wave Energy Device")] 
		WaveEnergyDevice = 12,

		[System.ComponentModel.Description("one3SubsurfaceOceanDataAcquisitionSystemOdasMissingDefinition")]
		[EnumMember(Value = "subsurface ocean data acquisition system (ODAS)")] 
		SubsurfaceOceanDataAcquisitionSystemOdas = 13,

		[System.ComponentModel.Description("AManMadeStructureThatMayMimicSomeOfTheCharacteristicsOfANaturalReefIntendedToAttractSeaLife")]
		[EnumMember(Value = "Artificial Reef")] 
		ArtificialReef = 14,

		[System.ComponentModel.Description("AStructurePlacedOnTheSeafloorBelowADrillingRigToGuideTheDrill")]
		[EnumMember(Value = "Template")] 
		Template = 15,

		[System.ComponentModel.Description("ALargeSteelStructureUpTo20MetresInHeightAboveTheSeafloorOrASteelFrameSecuredToTheSeafloorWithPilesToAnchorTheEndOfASubmarinePipelineForDeliveryToAProductionPlatform")]
		[EnumMember(Value = "Manifold")] 
		Manifold = 16,

		[System.ComponentModel.Description("AHillOfSoilCoveredIcePushedUpByHydrostaticPressureInAnAreaOfPermafrostThatIsLocatedUnderwater")]
		[EnumMember(Value = "Submerged Pingo")] 
		SubmergedPingo = 17,

		[System.ComponentModel.Description("TheDistributedRemainsOfAPlatform")]
		[EnumMember(Value = "Remains of Platform")] 
		RemainsOfPlatform = 18,

		[System.ComponentModel.Description("AnInstrumentUsedForScientificPurposes")]
		[EnumMember(Value = "Scientific Instrument")] 
		ScientificInstrument = 19,

		[System.ComponentModel.Description("AnyOfVariousMachinesHavingARotorUsuallyWithVanesOrBladesDrivenByThePressureMomentumOrReactiveThrustOfAMovingFluidAsSteamWaterHotGasesOrAirEitherOccurringInTheFormOfFreeJetsOrAsAFluidPassingThroughAndEntirelyFillingAHousingAroundTheRotorAndIsLocatedUnderwater")]
		[EnumMember(Value = "Underwater Turbine")] 
		UnderwaterTurbine = 20,

		[System.ComponentModel.Description("AnActiveSeabedVolcanoWhichMayBeSubmergedOrProjectingAboveTheWaterAtTheChartSoundingDatum")]
		[EnumMember(Value = "Active Submarine Volcano")] 
		ActiveSubmarineVolcano = 21,

		[System.ComponentModel.Description("ASubmergedNetPlacedAroundBeachesToReduceSharkAttacksOnSwimmers")]
		[EnumMember(Value = "Shark Net")] 
		SharkNet = 22,

		[System.ComponentModel.Description("OneOfSeveralGeneraOfTropicalTreesOrShrubsWhichProduceManyPropRootsAndGrowAlongLowLyingCoastsIntoShallowWater")]
		[EnumMember(Value = "Mangrove")] 
		Mangrove = 23,

		[System.ComponentModel.Description("AStructureTypicallyADomeOrCubeErectedOverAWellheadOrEquipmentAttachedToItATreeToLessenTheDangerOfVesselsSnaggingGearAml")]
		[EnumMember(Value = "Well Protection Structure")] 
		WellProtectionStructure = 501,

		[System.ComponentModel.Description("AnyOilOrGasRelatedInstallationOrStructureOnOrProjectingFromTheSeabedForExampleASubmergedPlatformOrConcreteFoundationsAml")]
		[EnumMember(Value = "Subsea Installation")] 
		SubseaInstallation = 502,

		[System.ComponentModel.Description("AnyPipelineRelatedStructureWhichProjectsAboveTheSeabedForExampleAJointTPieceValveOrSleeveOrACrossingWhereOnePipelineIsRaisedOverAnotherByMeansOfASupportingStructureAml")]
		[EnumMember(Value = "Pipeline Obstruction")] 
		PipelineObstruction = 503,

		[System.ComponentModel.Description("five04FreeStandingConductorPipeMissingDefinition")]
		[EnumMember(Value = "free standing conductor pipe")] 
		FreeStandingConductorPipe = 504,

		[System.ComponentModel.Description("LargeSeabedStructuresTypicallyMadeOfConcreteCapableOfStoringOilOrGasAndUsuallyFoundAttachedOrAdjacentToARigOrMarkedByASinglePointMooringBuoyAml")]
		[EnumMember(Value = "Storage Tank")] 
		StorageTank = 506,

		[System.ComponentModel.Description("AFloatingStructureUsuallyRectangularInShapeWhichServesAsLandingPierHeadBridgeSupportEtc")]
		[EnumMember(Value = "Pontoon")] 
		Pontoon = 508,

		[System.ComponentModel.Description("MiscellaneousItemsAndObjectsMostOfWhichHaveBeenLostOverboardOrOtherwiseAbandonedToTheSeaForExampleCargoContainersOrVehiclesAml")]
		[EnumMember(Value = "Sundry Objects")] 
		SundryObjects = 509,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum restriction : int {
		[System.ComponentModel.Description("AnAreaWithinWhichAnchoringIsNotPermitted")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		AnchoringProhibited = 1,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichAnchoringIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Anchoring Restricted")] 
		AnchoringRestricted = 2,

		[System.ComponentModel.Description("AnAreaWithinWhichFishingIsNotPermitted")]
		[EnumMember(Value = "Fishing Prohibited")] 
		FishingProhibited = 3,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichFishingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Fishing Restricted")] 
		FishingRestricted = 4,

		[System.ComponentModel.Description("AnAreaWithinWhichTrawlingIsNotPermitted")]
		[EnumMember(Value = "Trawling Prohibited")] 
		TrawlingProhibited = 5,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichTrawlingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Trawling Restricted")] 
		TrawlingRestricted = 6,

		[System.ComponentModel.Description("AnAreaWithinWhichNavigationAndOrAnchoringIsProhibited")]
		[EnumMember(Value = "Entry Prohibited")] 
		EntryProhibited = 7,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichNavigationIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Entry Restricted")] 
		EntryRestricted = 8,

		[System.ComponentModel.Description("AnAreaWithinWhichDredgingIsNotPermitted")]
		[EnumMember(Value = "Dredging Prohibited")] 
		DredgingProhibited = 9,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDredgingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Dredging Restricted")] 
		DredgingRestricted = 10,

		[System.ComponentModel.Description("AnAreaWithinWhichDivingIsNotPermitted")]
		[EnumMember(Value = "Diving Prohibited")] 
		DivingProhibited = 11,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDivingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Diving Restricted")] 
		DivingRestricted = 12,

		[System.ComponentModel.Description("MarinersMustAdjustTheSpeedOfTheirVesselsToReduceTheWaveOrWashWhichMayCauseErosionOrDisturbMooredVessels")]
		[EnumMember(Value = "No Wake")] 
		NoWake = 13,

		[System.ComponentModel.Description("AnImoDeclaredRouteingMeasureComprisingAnAreaWithinDefinedLimitsInWhichEitherNavigationIsParticularlyHazardousOrItIsExceptionallyImportantToAvoidCasualtiesAndWhichShouldBeAvoidedByAllShipsOrCertainClassesOfShips")]
		[EnumMember(Value = "Area To Be Avoided")] 
		AreaToBeAvoided = 14,

		[System.ComponentModel.Description("TheErectionOfPermanentOrTemporaryFixedStructuresOrArtificialIslandsIsProhibited")]
		[EnumMember(Value = "Construction Prohibited")] 
		ConstructionProhibited = 15,

		[System.ComponentModel.Description("AnAreaWithinWhichDischargingOrDumpingIsProhibited")]
		[EnumMember(Value = "Discharging Prohibited")] 
		DischargingProhibited = 16,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichDischargingOrDumpingIsRestrictedInAccordanceWithSpecifiedConditions")]
		[EnumMember(Value = "Discharging Restricted")] 
		DischargingRestricted = 17,

		[System.ComponentModel.Description("one8IndustrialOrMineralMissingDefinition")]
		[EnumMember(Value = "industrial or mineral 18")] 
		IndustrialOrMineral18 = 18,

		[System.ComponentModel.Description("one9IndustrialOrMineralMissingDefinition")]
		[EnumMember(Value = "industrial or mineral 19")] 
		IndustrialOrMineral19 = 19,

		[System.ComponentModel.Description("AnAreaWithinWhichExcavatingAHoleOnTheSeabedWithADrillIsProhibited")]
		[EnumMember(Value = "Drilling Prohibited")] 
		DrillingProhibited = 20,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichExcavatingAHoleOnTheSeabedWithADrillIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Drilling Restricted")] 
		DrillingRestricted = 21,

		[System.ComponentModel.Description("twotwoRemovalOfHistoricMissingDefinition")]
		[EnumMember(Value = "removal of historic")] 
		RemovalOfHistoric = 22,

		[System.ComponentModel.Description("two3CargoTranshipmentLighteningProhibitedMissingDefinition")]
		[EnumMember(Value = "cargo transhipment (lightening) prohibited")] 
		CargoTranshipmentLighteningProhibited = 23,

		[System.ComponentModel.Description("AnAreaInWhichTheDraggingOfAnythingAlongTheSeabedForExampleBottomTrawlingIsProhibited")]
		[EnumMember(Value = "Dragging Prohibited")] 
		DraggingProhibited = 24,

		[System.ComponentModel.Description("AnAreaInWhichAVesselIsProhibitedFromStopping")]
		[EnumMember(Value = "Stopping Prohibited")] 
		StoppingProhibited = 25,

		[System.ComponentModel.Description("AnAreaInWhichLandingIsProhibited")]
		[EnumMember(Value = "Landing Prohibited")] 
		LandingProhibited = 26,

		[System.ComponentModel.Description("AnAreaWithinWhichSpeedIsRestricted")]
		[EnumMember(Value = "Speed Restricted")] 
		SpeedRestricted = 27,

		[System.ComponentModel.Description("AnAreaInWhichSwimmingIsProhibited")]
		[EnumMember(Value = "Swimming Prohibited")] 
		SwimmingProhibited = 39,

		[System.ComponentModel.Description("four2PowerDrivenVesselsMissingDefinition")]
		[EnumMember(Value = "power-driven vessels")] 
		PowerDrivenVessels = 42,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofMilitaryPracticeArea : int {
		[System.ComponentModel.Description("AnAreaWithinWhichExercisesAreCarriedOutWithTorpedoes")]
		[EnumMember(Value = "Torpedo Exercise Area")] 
		TorpedoExerciseArea = 2,

		[System.ComponentModel.Description("AnAreaWithinWhichSubmarineExercisesAreCarriedOut")]
		[EnumMember(Value = "Submarine Exercise Area")] 
		SubmarineExerciseArea = 3,

		[System.ComponentModel.Description("AreasForBombingAndMissileExercises")]
		[EnumMember(Value = "Firing Danger Area")] 
		FiringDangerArea = 4,

		[System.ComponentModel.Description("fiveMineLayingPracticeAreaMissingDefinition")]
		[EnumMember(Value = "mine-laying practice area")] 
		MineLayingPracticeArea = 5,

		[System.ComponentModel.Description("TheAclantAlliedCommandAtlanticSubmarineGridProvidesNatoSubmarineOperatingAuthoritiesWithACommonGridForTheWaterSpaceManagementOfNatoSubmarines")]
		[EnumMember(Value = "ACLANT grid")] 
		AclantGrid = 501,

		[System.ComponentModel.Description("AnAreaInWhichCertainActivitiesOrFactorsOfSignificanceToSurfaceNavigationOrOperationsApply")]
		[EnumMember(Value = "Surface Danger Area")] 
		SurfaceDangerArea = 502,

		[System.ComponentModel.Description("five03JmcAreasJenoaGridMissingDefinition")]
		[EnumMember(Value = "JMC Areas - JENOA grid")] 
		JmcAreasJenoaGrid = 503,

		[System.ComponentModel.Description("five06SafeBottomingAreaMissingDefinition")]
		[EnumMember(Value = "safe bottoming area")] 
		SafeBottomingArea = 506,

		[System.ComponentModel.Description("AnAreaInWhichSubmarineOperationsAreProhibitedOrLimitedOwingToTheExistenceOfHazardsToDivedSubmarines")]
		[EnumMember(Value = "Submarine Danger Area")] 
		SubmarineDangerArea = 507,

		[System.ComponentModel.Description("ASpecifiedZoneForTheProvisionOfSonarCalibrationOrOtherUnderwaterTesting")]
		[EnumMember(Value = "Testing and Evaluation Range")] 
		TestingAndEvaluationRange = 508,

		[System.ComponentModel.Description("five10ImpactAreaMissingDefinition")]
		[EnumMember(Value = "Impact area")] 
		ImpactArea = 510,

		[System.ComponentModel.Description("AnAreaUsedForLiveFiringOfWeaponsToBombardADesignatedArea")]
		[EnumMember(Value = "Live Fire Range")] 
		LiveFireRange = 599,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sonarSignalStrength : int {
		[System.ComponentModel.Description("five01NilMissingDefinition")]
		[EnumMember(Value = "nil")] 
		Nil = 501,

		[System.ComponentModel.Description("NotAsGoodAsItCouldBeOrShould")]
		[EnumMember(Value = "Poor")] 
		Poor = 502,

		[System.ComponentModel.Description("five03ModerateMissingDefinition")]
		[EnumMember(Value = "moderate")] 
		Moderate = 503,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		Strong = 504,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("TheMaximumLengthOfTheShip")]
		[EnumMember(Value = "Length Overall")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("TheShipSLengthMeasuredAtTheWaterline")]
		[EnumMember(Value = "Length at Waterline")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("TheWidthOrBeamOfTheVessel")]
		[EnumMember(Value = "Breadth")] 
		Breadth = 3,

		[System.ComponentModel.Description("TheDepthOfWaterNecessaryToFloatAVesselFullyLoaded")]
		[EnumMember(Value = "Draught")] 
		Draught = 4,

		[System.ComponentModel.Description("AMeasurementOfTheWeightOfTheVesselUsuallyUsedForWarshipsMerchantShipsAreUsuallyMeasuredBasedOnTheVolumeOfCargoSpaceSeeTonnageDisplacementIsExpressedEitherInLongTonsOf2240PoundsOrMetricTonnesOf1000KgSinceTheTwoUnitsAreVeryCloseInSize2240Pounds1016KgAnd1000Kg2205PoundsItIsCommonNotToDistinguishBetweenThemToPreserveSecrecyNationsSometimesMisstateAWarshipSDisplacement")]
		[EnumMember(Value = "Displacement Tonnage")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("TheEntireInternalCubicCapacityOfTheShipExpressedInTonsOf100CubicFeetToTheTonExceptCertainSpacesWithAreExemptedSuchAsPeakAndOtherTanksForWaterBallastOpenForecastleBridgeAndPoopAccessOfHatchwaysCertainLightAndAirSpacesDomesOfSkylightsCondenserAnchorGearSteeringGearWheelHouseGalleyAndCabinForPassengers")]
		[EnumMember(Value = "Gross Tonnage")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("ObtainedFromTheGrossTonnageByDeductingCrewAndNavigatingSpacesAndAllowancesForPropulsionMachinery")]
		[EnumMember(Value = "Net Tonnage")] 
		NetTonnage = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lastSensor : int {
		[System.ComponentModel.Description("five01AcousticSensorMissingDefinition")]
		[EnumMember(Value = "acoustic sensor")] 
		AcousticSensor = 501,

		[System.ComponentModel.Description("TheObjectWasReportedAsAResultOfDetectingAFluctuationInTheLocalMagneticField")]
		[EnumMember(Value = "Magnetic Sensor")] 
		MagneticSensor = 502,

		[System.ComponentModel.Description("five03VideoSensorMissingDefinition")]
		[EnumMember(Value = "video sensor")] 
		VideoSensor = 503,

		[System.ComponentModel.Description("five04DiverSightingFoundByDiverInRegistryMissingDefinition")]
		[EnumMember(Value = "diver sighting (found by diver - in registry)")] 
		DiverSightingFoundByDiverInRegistry = 504,

		[System.ComponentModel.Description("five06PhysicalSnagMissingDefinition")]
		[EnumMember(Value = "physical snag")] 
		PhysicalSnag = 506,

		[System.ComponentModel.Description("five07ObservedSinkingMissingDefinition")]
		[EnumMember(Value = "observed sinking")] 
		ObservedSinking = 507,

		[System.ComponentModel.Description("five08ReportedSinkingMissingDefinition")]
		[EnumMember(Value = "Reported Sinking")] 
		ReportedSinking = 508,

		[System.ComponentModel.Description("five09NoneReportedMissingDefinition")]
		[EnumMember(Value = "None reported")] 
		NoneReported = 509,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCoverage : int {
		[System.ComponentModel.Description("ContinuousCoverageOfSpatialObjectsIsAvailableWithinThisArea")]
		[EnumMember(Value = "Coverage Available")] 
		CoverageAvailable = 1,

		[System.ComponentModel.Description("AnAreaContainingNoSpatialObjects")]
		[EnumMember(Value = "No Coverage Available")] 
		NoCoverageAvailable = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum beaconShape : int {
		[System.ComponentModel.Description("oneStakePolePerchPostMissingDefinition")]
		[EnumMember(Value = "stake, pole, perch, post")] 
		StakePolePerchPost = 1,

		[System.ComponentModel.Description("ATreeWithoutRootsStuckOrSpoiledIntoTheBottomOfTheSeaToServeAsANavigationalAid")]
		[EnumMember(Value = "Withy")] 
		Withy = 2,

		[System.ComponentModel.Description("ASolidStructureOfTheOrderOf10MetresInHeightUsedAsANavigationalAid")]
		[EnumMember(Value = "Beacon Tower")] 
		BeaconTower = 3,

		[System.ComponentModel.Description("AStructureConsistingOfStripsOfMetalOrWoodCrossedOrInterlacedToFormAStructureToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Lattice Beacon")] 
		LatticeBeacon = 4,

		[System.ComponentModel.Description("ALongHeavyTimberSOrSectionSOfSteelWoodConcreteEtcForcedIntoTheSeabedToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Pile Beacon")] 
		PileBeacon = 5,

		[System.ComponentModel.Description("AMoundOfStonesUsuallyConicalOrPyramidalRaisedAsALandmarkOrToDesignateAPointOfImportanceInSurveying")]
		[EnumMember(Value = "Cairn")] 
		Cairn = 6,

		[System.ComponentModel.Description("ATallSparLikeBeaconFittedWithAPermanentlySubmergedBuoyancyChamberTheLowerEndOfTheBodyIsSecuredToSeabedSinkerEitherByAFlexibleJointOrByACableUnderTension")]
		[EnumMember(Value = "Buoyant Beacon")] 
		BuoyantBeacon = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDumpingGround : int {
		[System.ComponentModel.Description("AnAreaAtSeaWhereChemicalWasteIsDumped")]
		[EnumMember(Value = "Chemical Waste Dumping Ground")] 
		ChemicalWasteDumpingGround = 2,

		[System.ComponentModel.Description("AnAreaAtSeaWhereNuclearWasteIsDumped")]
		[EnumMember(Value = "Nuclear Waste Dumping Ground")] 
		NuclearWasteDumpingGround = 3,

		[System.ComponentModel.Description("AnAreaAtSeaWhereExplosivesAreDumped")]
		[EnumMember(Value = "Explosives Dumping Ground")] 
		ExplosivesDumpingGround = 4,

		[System.ComponentModel.Description("ASeaAreaWhereDredgedMaterialIsDeposited")]
		[EnumMember(Value = "Spoil Ground")] 
		SpoilGround = 5,

		[System.ComponentModel.Description("AnAreaAtSeaWhereDisusedVesselsAreScuttled")]
		[EnumMember(Value = "Vessel Dumping Ground")] 
		VesselDumpingGround = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAnchorage : int {
		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchor")]
		[EnumMember(Value = "Unrestricted Anchorage")] 
		UnrestrictedAnchorage = 1,

		[System.ComponentModel.Description("AnAreaInWhichVesselsOfDeepDraughtAnchorOrMayAnchor")]
		[EnumMember(Value = "Deep Water Anchorage")] 
		DeepWaterAnchorage = 2,

		[System.ComponentModel.Description("AnAreaInWhichTankersAnchorOrMayAnchor")]
		[EnumMember(Value = "Tanker Anchorage")] 
		TankerAnchorage = 3,

		[System.ComponentModel.Description("AnAreaWhereAVesselAnchorsWhenSatisfyingQuarantineRegulations")]
		[EnumMember(Value = "Quarantine Anchorage")] 
		QuarantineAnchorage = 5,

		[System.ComponentModel.Description("AnAreaInWhichSeaplanesAnchorOrMayAnchor")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		SeaplaneAnchorage = 6,

		[System.ComponentModel.Description("AnAreaInWhichYachtsAndSmallBoatsAnchorOrMayAnchor")]
		[EnumMember(Value = "Small Craft Anchorage")] 
		SmallCraftAnchorage = 7,

		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchorForPeriodsOfUpTo24Hours")]
		[EnumMember(Value = "Anchorage for Periods Up To 24 Hours")] 
		AnchorageForPeriodsUpTo24Hours = 9,

		[System.ComponentModel.Description("AnAreaInWhichVesselsMayAnchorForAPeriodOfTimeNotToExceedASpecificLimit")]
		[EnumMember(Value = "Anchorage for a Limited Period of Time")] 
		AnchorageForALimitedPeriodOfTime = 10,

		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchorWhileWaitingForExampleForAccessToAPortOrBerth")]
		[EnumMember(Value = "Waiting Anchorage")] 
		WaitingAnchorage = 14,

		[System.ComponentModel.Description("ALocationNotDefinedByARegulatoryAuthorityThatHasBeenReportedToBeSuitableAndSafeForAnchoring")]
		[EnumMember(Value = "Reported Anchorage")] 
		ReportedAnchorage = 15,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum catagoryOfAirspaceRestriction : int {
		[System.ComponentModel.Description("AnAreaDesignatedByAProperAuthorityInWhichADangerToCraftExistsAlsoCalledDangerZone")]
		[EnumMember(Value = "Danger Area")] 
		DangerArea = 501,

		[System.ComponentModel.Description("oneAnAreaShownOnChartsWithinWhichNavigationAndOrAnchoringIsProhibited2InAviationTerminologyASpecifiedAreaWithinTheLandAreasOfAStateOrTerritorialWatersAdjacentTheretoOverWhichTheFlightOfAircraftIsProhibited")]
		[EnumMember(Value = "Prohibited Area")] 
		ProhibitedArea = 502,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichNavigationIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Restricted Area")] 
		RestrictedArea = 503,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colourPattern : int {
		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedHorizontally")]
		[EnumMember(Value = "Horizontal Stripes")] 
		HorizontalStripes = 1,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedVertically")]
		[EnumMember(Value = "Vertical Stripes")] 
		VerticalStripes = 2,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedDiagonallyThatIsNotHorizontallyOrVertically")]
		[EnumMember(Value = "Diagonal Stripes")] 
		DiagonalStripes = 3,

		[System.ComponentModel.Description("OftenReferredToAsCheckerPlateWhereAlternateColoursAreUsedToCreateSquaresSimilarToAChessOrDraughtBoardThePatternMayBeStraightOrDiagonal")]
		[EnumMember(Value = "Squared")] 
		Squared = 4,

		[System.ComponentModel.Description("fiveStripesDirectionUnknownMissingDefinition")]
		[EnumMember(Value = "stripes (direction unknown)")] 
		StripesDirectionUnknown = 5,

		[System.ComponentModel.Description("ABandOrStripeOfColourWhichIsDisplayedAroundTheOuterEdgeOfTheFeatureWhichMayAlsoFormABorderToAnInnerPatternOrPlainColour")]
		[EnumMember(Value = "Border Stripe")] 
		BorderStripe = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarStation : int {
		[System.ComponentModel.Description("ARadarStationEstablishedForTrafficSurveillance")]
		[EnumMember(Value = "Radar Surveillance Station")] 
		RadarSurveillanceStation = 1,

		[System.ComponentModel.Description("AShoreBasedStationWhichTheMarinerCanContactByRadioToObtainAPosition")]
		[EnumMember(Value = "Coast Radar Station")] 
		CoastRadarStation = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfControlledAirspace : int {
		[System.ComponentModel.Description("AControlAreaOrPortionThereofEstablishedInTheFormOfACorridorEquippedWithRadioNavigationAids")]
		[EnumMember(Value = "Airway")] 
		Airway = 501,

		[System.ComponentModel.Description("five02AltimeterSettingRegionAsrMissingDefinition")]
		[EnumMember(Value = "Altimeter Setting Region (ASR)")] 
		AltimeterSettingRegionAsr = 502,

		[System.ComponentModel.Description("five03AvoidanceAreaAaMissingDefinition")]
		[EnumMember(Value = "Avoidance Area (AA)")] 
		AvoidanceAreaAa = 503,

		[System.ComponentModel.Description("five04ControlAreaCtaMissingDefinition")]
		[EnumMember(Value = "Control Area (CTA)")] 
		ControlAreaCta = 504,

		[System.ComponentModel.Description("five0fiveControlZoneCtrCtzMissingDefinition")]
		[EnumMember(Value = "Control Zone (CTR/CTZ)")] 
		ControlZoneCtrCtz = 505,

		[System.ComponentModel.Description("five06FlightInformationRegionFirMissingDefinition")]
		[EnumMember(Value = "Flight Information Region (FIR)")] 
		FlightInformationRegionFir = 506,

		[System.ComponentModel.Description("five07TerminalControlAreaTmaTcaMissingDefinition")]
		[EnumMember(Value = "Terminal Control Area (TMA/TCA)")] 
		TerminalControlAreaTmaTca = 507,

		[System.ComponentModel.Description("five08AerodromeTrafficZoneAtzMissingDefinition")]
		[EnumMember(Value = "Aerodrome Traffic Zone (ATZ)")] 
		AerodromeTrafficZoneAtz = 508,

		[System.ComponentModel.Description("five09HelicopterProtectionZoneHpzMissingDefinition")]
		[EnumMember(Value = "Helicopter Protection Zone (HPZ)")] 
		HelicopterProtectionZoneHpz = 509,

		[System.ComponentModel.Description("five10HelicopterMainRouteHmrMissingDefinition")]
		[EnumMember(Value = "Helicopter Main Route (HMR)")] 
		HelicopterMainRouteHmr = 510,

		[System.ComponentModel.Description("five11HelicopterTransitCorridorHtcMissingDefinition")]
		[EnumMember(Value = "Helicopter Transit Corridor (HTC)")] 
		HelicopterTransitCorridorHtc = 511,

		[System.ComponentModel.Description("five12MilitaryAerodromeTrafficZoneMatzMissingDefinition")]
		[EnumMember(Value = "Military Aerodrome Traffic Zone (MATZ)")] 
		MilitaryAerodromeTrafficZoneMatz = 512,

		[System.ComponentModel.Description("five13OceanControlAreaOcaMissingDefinition")]
		[EnumMember(Value = "Ocean Control Area (OCA)")] 
		OceanControlAreaOca = 513,

		[System.ComponentModel.Description("five14CoastguardTrackSurveillanceMissingDefinition")]
		[EnumMember(Value = "Coastguard track [surveillance]")] 
		CoastguardTrackSurveillance = 514,

		[System.ComponentModel.Description("five1fiveMilitaryTerminalControlAreaMtcaMissingDefinition")]
		[EnumMember(Value = "Military Terminal Control Area (MTCA)")] 
		MilitaryTerminalControlAreaMtca = 515,

		[System.ComponentModel.Description("five16IdentificationZoneAdizMissingDefinition")]
		[EnumMember(Value = "Identification Zone (ADIZ)")] 
		IdentificationZoneAdiz = 516,

		[System.ComponentModel.Description("five17AdvisoryAreaAdaOrUdaMissingDefinition")]
		[EnumMember(Value = "Advisory Area (ADA) or (UDA)")] 
		AdvisoryAreaAdaOrUda = 517,

		[System.ComponentModel.Description("five18AirRouteTradfficControlCenterArtccMissingDefinition")]
		[EnumMember(Value = "Air Route Tradffic Control Center (ARTCC)")] 
		AirRouteTradfficControlCenterArtcc = 518,

		[System.ComponentModel.Description("five19AreaControlCenterAccMissingDefinition")]
		[EnumMember(Value = "Area Control Center (ACC)")] 
		AreaControlCenterAcc = 519,

		[System.ComponentModel.Description("AnAirspaceForWhichARadarServiceIsSpecified")]
		[EnumMember(Value = "Radar Area")] 
		RadarArea = 520,

		[System.ComponentModel.Description("five21UpperFlightInformationRegionUirMissingDefinition")]
		[EnumMember(Value = "Upper Flight Information Region (UIR)")] 
		UpperFlightInformationRegionUir = 521,

		[System.ComponentModel.Description("five22BufferZoneBzMissingDefinition")]
		[EnumMember(Value = "Buffer Zone (BZ)")] 
		BufferZoneBz = 522,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCompleteness : int {
		[System.ComponentModel.Description("TheAreaSpecifiedHasBeenPopulatedForAllKnownFeaturesAbsenceOfFeaturesIndicatesThatThereAreNoSuchEntitiesAvailableToTheDataProducer")]
		[EnumMember(Value = "Complete")] 
		Complete = 501,

		[System.ComponentModel.Description("CertainFeaturesHaveNotBeenIncludedOrOnlyPartiallyIncludedWithinTheSpecifiedAreaDetailsMustBeProvidedInSupportingTextualInformation")]
		[EnumMember(Value = "Partial")] 
		Partial = 502,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("UnpackedHomogenousCargoPouredLooseInACertainSpaceOfAVesselForExampleOilOrGrain")]
		[EnumMember(Value = "Bulk")] 
		Bulk = 1,

		[System.ComponentModel.Description("OneOfANumberOfStandardSizedCargoCarryingUnitsSecuredUsingStandardCornerAttachmentsAndBar")]
		[EnumMember(Value = "Container")] 
		Container = 2,

		[System.ComponentModel.Description("BreakBulkCargoNormallyLoadedByCrane")]
		[EnumMember(Value = "General")] 
		General = 3,

		[System.ComponentModel.Description("AnyCargoLoadedByPipeline")]
		[EnumMember(Value = "Liquid")] 
		Liquid = 4,

		[System.ComponentModel.Description("AFeePayingTraveller")]
		[EnumMember(Value = "Passenger")] 
		Passenger = 5,

		[System.ComponentModel.Description("LiveAnimalsCarriedInBulk")]
		[EnumMember(Value = "Livestock")] 
		Livestock = 6,

		[System.ComponentModel.Description("DangerousOrHazardousCargoAsDescribedByTheImoInternationalMaritimeDangerousGoodsCode")]
		[EnumMember(Value = "Dangerous or Hazardous")] 
		DangerousOrHazardous = 7,

		[System.ComponentModel.Description("IndivisibleHeavyItemsOfWeightGenerallyOver100TonsAndWidthOrHeightGreaterThan100Metres")]
		[EnumMember(Value = "Heavy Lift")] 
		HeavyLift = 8,

		[System.ComponentModel.Description("MaterialCarriedByAShipToEnsureItsStability")]
		[EnumMember(Value = "Ballast")] 
		Ballast = 9,

		[System.ComponentModel.Description("CommodityCargoThatIsTransportedUnpackagedInLargeQuantitiesTheseTypesOfGoodsUsuallyNeedToBeKeptDryDuringTheWholeTransportationPeriod")]
		[EnumMember(Value = "Dry Bulk Cargo")] 
		DryBulkCargo = 10,

		[System.ComponentModel.Description("LiquidsOrGasesThatAreTransportedInBulkAndCarriedUnpackaged")]
		[EnumMember(Value = "Liquid Bulk Cargo")] 
		LiquidBulkCargo = 11,

		[System.ComponentModel.Description("CargoTransportedInRefrigeratedContainersGenerallyPerishableCommoditiesWhichRequireTemperatureControlledTransportationSuchAsFruitMeatFishVegetablesDairyProductsAndOtherFoods")]
		[EnumMember(Value = "Reefer Container Cargo")] 
		ReeferContainerCargo = 12,

		[System.ComponentModel.Description("one3RoRoCargoMissingDefinition")]
		[EnumMember(Value = "Ro-Ro cargo")] 
		RoRoCargo = 13,

		[System.ComponentModel.Description("ProjectCargoIsATermUsedToBroadlyDescribeTheNationalOrInternationalTransportationOfLargeHeavyHighValueOrCriticalToTheProjectTheyAreIntendedForPiecesOfEquipmentAlsoCommonlyReferredToAsHeavyLiftThisIncludesShipmentsMadeOfVariousComponentsWhichNeedDisassemblyForShipmentAndReassemblyAfterDelivery")]
		[EnumMember(Value = "Project Cargo")] 
		ProjectCargo = 14,

		[System.ComponentModel.Description("GoodsThatAreStowedOnBoardShipInIndividuallyCountedUnitsAndNotInIntermodalContainersNorInBulkAsWithOilOrGrain")]
		[EnumMember(Value = "Break Bulk Cargo")] 
		BreakBulkCargo = 15,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalStatus : int {
		[System.ComponentModel.Description("oneLitSoundMissingDefinition")]
		[EnumMember(Value = "lit/sound")] 
		LitSound = 1,

		[System.ComponentModel.Description("twoEclipsedSilentMissingDefinition")]
		[EnumMember(Value = "eclipsed/silent")] 
		EclipsedSilent = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum divingActivity : int {
		[System.ComponentModel.Description("five01CommercialDivingMissingDefinition")]
		[EnumMember(Value = "Commercial Diving")] 
		CommercialDiving = 501,

		[System.ComponentModel.Description("five02SportsDivingMissingDefinition")]
		[EnumMember(Value = "Sports Diving")] 
		SportsDiving = 502,

		[System.ComponentModel.Description("five03DiveTrainingMissingDefinition")]
		[EnumMember(Value = "Dive Training")] 
		DiveTraining = 503,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum condition : int {
		[System.ComponentModel.Description("BeingBuiltButNotYetCapableOfFunction")]
		[EnumMember(Value = "Under Construction")] 
		UnderConstruction = 1,

		[System.ComponentModel.Description("AStructureInADecayedOrDeterioratedConditionResultingFromNeglectOrDisuseOrADamagedStructureInNeedOfRepair")]
		[EnumMember(Value = "Ruined")] 
		Ruined = 2,

		[System.ComponentModel.Description("AnAreaOfTheSeaALakeOrTheNavigablePartOfARiverThatIsBeingReclaimedAsLandUsuallyByTheDumpingOfEarthAndOtherMaterial")]
		[EnumMember(Value = "Under Reclamation")] 
		UnderReclamation = 3,

		[System.ComponentModel.Description("DetailedPlanningHasBeenCompletedButConstructionHasNotBeenInitiated")]
		[EnumMember(Value = "Planned Construction")] 
		PlannedConstruction = 5,

		[System.ComponentModel.Description("CompletedUndamagedAndWorkingNormally")]
		[EnumMember(Value = "Operational")] 
		Operational = 501,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum nameUsage : int {
		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToTheDefaultNameTextDisplaySetting")]
		[EnumMember(Value = "Default Name Display")] 
		DefaultNameDisplay = 1,

		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToAnAlternateNameTextDisplaySettingForExampleAnAlternateLanguage")]
		[EnumMember(Value = "Alternate Name Display")] 
		AlternateNameDisplay = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum strengthOfMagneticAnomaly : int {
		[System.ComponentModel.Description("five01NilMissingDefinition")]
		[EnumMember(Value = "nil")] 
		Nil = 501,

		[System.ComponentModel.Description("five02SlightMissingDefinition")]
		[EnumMember(Value = "slight")] 
		Slight = 502,

		[System.ComponentModel.Description("five03ModerateMissingDefinition")]
		[EnumMember(Value = "moderate")] 
		Moderate = 503,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		Strong = 504,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurfaceQualifyingTerms : int {
		[System.ComponentModel.Description("FallsWithinTheSmallestSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Fine")] 
		Fine = 1,

		[System.ComponentModel.Description("FallsWithinTheModerateSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Medium")] 
		Medium = 2,

		[System.ComponentModel.Description("FallsWithinTheLargestSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Coarse")] 
		Coarse = 3,

		[System.ComponentModel.Description("FracturedOrInPieces")]
		[EnumMember(Value = "Broken")] 
		Broken = 4,

		[System.ComponentModel.Description("HavingAnAdhesiveOrGlueLikeProperty")]
		[EnumMember(Value = "Sticky")] 
		Sticky = 5,

		[System.ComponentModel.Description("NotHardOrFirm")]
		[EnumMember(Value = "Soft")] 
		Soft = 6,

		[System.ComponentModel.Description("NotPliantThickResistantToFlow")]
		[EnumMember(Value = "Stiff")] 
		Stiff = 7,

		[System.ComponentModel.Description("ComposedOfOrContainingMaterialEjectedFromAVolcano")]
		[EnumMember(Value = "Volcanic")] 
		Volcanic = 8,

		[System.ComponentModel.Description("ComposedOfOrContainingCalciumOrCalciumCarbonate")]
		[EnumMember(Value = "Calcareous")] 
		Calcareous = 9,

		[System.ComponentModel.Description("FirmUsuallyRefersToAnAreaOfTheSeafloorNotCoveredByUnconsolidatedSediment")]
		[EnumMember(Value = "Hard")] 
		Hard = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightCharacteristic : int {
		[System.ComponentModel.Description("ASignalLightThatShowsContinuouslyInAnyGivenDirectionWithConstantLuminousIntensityAndColour")]
		[EnumMember(Value = "Fixed")] 
		Fixed = 1,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flashing")] 
		Flashing = 2,

		[System.ComponentModel.Description("threeLongFlashingMissingDefinition")]
		[EnumMember(Value = "long-flashing")] 
		LongFlashing = 3,

		[System.ComponentModel.Description("fourQuickFlashingMissingDefinition")]
		[EnumMember(Value = "quick-flashing")] 
		QuickFlashing = 4,

		[System.ComponentModel.Description("fiveVeryQuickFlashingMissingDefinition")]
		[EnumMember(Value = "very quick-flashing")] 
		VeryQuickFlashing = 5,

		[System.ComponentModel.Description("sixUltraQuickFlashingMissingDefinition")]
		[EnumMember(Value = "ultra quick-flashing")] 
		UltraQuickFlashing = 6,

		[System.ComponentModel.Description("ALightWithAllDurationsOfLightAndDarknessEqual")]
		[EnumMember(Value = "Isophased")] 
		Isophased = 7,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndAllTheEclipsesAreOfEqualDurationItMayBeSingleOccultingAnOccultingLightInWhichAnEclipseIsRegularlyRepeatedGroupOccultingAnOccultingLightInWhichAGroupOfTwoOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedCompositeGroupOccultingAnOccultingLightInWhichASequenceOfGroupsOfOneOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedAndTheGroupsCompriseDifferentNumbersOfEclipses")]
		[EnumMember(Value = "Occulting")] 
		Occulting = 8,

		[System.ComponentModel.Description("ALightInWhichTheUltraQuickFlashes160OrMorePerMinuteAreInterruptedAtRegularIntervalsByEclipsesOfLongDuration")]
		[EnumMember(Value = "Interrupted Ultra Quick-Flashing")] 
		InterruptedUltraQuickFlashing = 11,

		[System.ComponentModel.Description("ARhythmicLightInWhichAppearancesOfLightOfTwoClearlyDifferentDurationsAreGroupedToRepresentACharacterOrCharactersInTheMorseCode")]
		[EnumMember(Value = "Morse")] 
		Morse = 12,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFixedLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Fixed and Flash")] 
		FixedAndFlash = 13,

		[System.ComponentModel.Description("one4FlashAndLongFlashMissingDefinition")]
		[EnumMember(Value = "flash and long-flash")] 
		FlashAndLongFlash = 14,

		[System.ComponentModel.Description("ARhythmicLightInWhichAnOccultingLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Occulting and Flash")] 
		OccultingAndFlash = 15,

		[System.ComponentModel.Description("one6FixedAndLongFlashMissingDefinition")]
		[EnumMember(Value = "fixed and long-flash")] 
		FixedAndLongFlash = 16,

		[System.ComponentModel.Description("AnAlternatingLightInWhichTheTotalDurationOfLightInEachPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndInWhichTheIntervalsOfDarknessOccultationsAreAllOfEqualDuration")]
		[EnumMember(Value = "Occulting Alternating")] 
		OccultingAlternating = 17,

		[System.ComponentModel.Description("one8LongFlashAlternatingMissingDefinition")]
		[EnumMember(Value = "long-flash alternating")] 
		LongFlashAlternating = 18,

		[System.ComponentModel.Description("AnAlternatingRhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flash Alternating")] 
		FlashAlternating = 19,

		[System.ComponentModel.Description("two5QuickFlashPlusLongflashMissingDefinition")]
		[EnumMember(Value = "quick-flash plus longflash")] 
		QuickFlashPlusLongflash = 25,

		[System.ComponentModel.Description("two6VeryQuickFlashPlusLongFlashMissingDefinition")]
		[EnumMember(Value = "very quick-flash plus long-flash")] 
		VeryQuickFlashPlusLongFlash = 26,

		[System.ComponentModel.Description("two7UltraQuickFlashPlusMissingDefinition")]
		[EnumMember(Value = "ultra quick-flash plus")] 
		UltraQuickFlashPlus = 27,

		[System.ComponentModel.Description("ASignalLightThatShowsContinuouslyInAnyGivenDirectionTwoOrMoreColoursInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Alternating")] 
		Alternating = 28,

		[System.ComponentModel.Description("two9FixedAndAlternatingMissingDefinition")]
		[EnumMember(Value = "fixed and alternating")] 
		FixedAndAlternating = 29,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCheckpoint : int {
		[System.ComponentModel.Description("ServesAsAGovernmentCheckpointWhereCustomsDutiesAreCollectedTheFlowOfGoodsAreRegulatedAndRestrictionsEnforcedAndShipmentsOrVehiclesAreClearedForEnteringOrLeavingACountry")]
		[EnumMember(Value = "Custom")] 
		Custom = 1,

		[System.ComponentModel.Description("five01RvLocationMissingDefinition")]
		[EnumMember(Value = "RV Location")] 
		RvLocation = 501,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[System.ComponentModel.Description("oneConePointUpMissingDefinition")]
		[EnumMember(Value = "cone (point up)")] 
		ConePointUp = 1,

		[System.ComponentModel.Description("twoConePointDownMissingDefinition")]
		[EnumMember(Value = "cone (point down)")] 
		ConePointDown = 2,

		[System.ComponentModel.Description("ACurvedSurfaceAllPointsOfWhichAreEquidistantFromAFixedPointWithinCalledTheCentre")]
		[EnumMember(Value = "Sphere")] 
		Sphere = 3,

		[System.ComponentModel.Description("four2SpheresMissingDefinition")]
		[EnumMember(Value = "2 spheres")] 
		twoSpheres = 4,

		[System.ComponentModel.Description("ASolidGeometricalFigureGeneratedByStraightLinesFixedInDirectionAndDescribingWithOneOfPointAClosedCurveEspeciallyACircleInWhichCaseTheFigureIsCircularCylinderItsEndsBeingParallelCircles")]
		[EnumMember(Value = "Cylinder")] 
		Cylinder = 5,

		[System.ComponentModel.Description("UsuallyOfRectangularShapeMadeFromTimberOrMetalAndUsedToProvideAContrastWithTheNaturalBackgroundOfADaymarkTheActualDaymarkIsOftenPaintedOnToThisBoard")]
		[EnumMember(Value = "Board")] 
		Board = 6,

		[System.ComponentModel.Description("sevenXShapedMissingDefinition")]
		[EnumMember(Value = "x-shaped")] 
		XShaped = 7,

		[System.ComponentModel.Description("ACrossWithOneVerticalMemberAndOneHorizontalMemberThatIsSimilarInShapeToTheCharacter")]
		[EnumMember(Value = "Upright Cross")] 
		UprightCross = 8,

		[System.ComponentModel.Description("nineCubePointUpMissingDefinition")]
		[EnumMember(Value = "cube (point up)")] 
		CubePointUp = 9,

		[System.ComponentModel.Description("one02ConesPointToPointMissingDefinition")]
		[EnumMember(Value = "2 cones (point to point)")] 
		twoConesPointToPoint = 10,

		[System.ComponentModel.Description("oneone2ConesBaseToBaseMissingDefinition")]
		[EnumMember(Value = "2 cones (base to base)")] 
		twoConesBaseToBase = 11,

		[System.ComponentModel.Description("APlaneFigureHavingFourEqualSidesAndEqualOppositeAnglesTwoAcuteAndTwoObtuseAnObliqueEquilateralParallelogram")]
		[EnumMember(Value = "Rhombus")] 
		Rhombus = 12,

		[System.ComponentModel.Description("one32ConesPointsUpwardMissingDefinition")]
		[EnumMember(Value = "2 cones (points upward)")] 
		twoConesPointsUpward = 13,

		[System.ComponentModel.Description("one42ConesPointsDownwardMissingDefinition")]
		[EnumMember(Value = "2 cones (points downward)")] 
		twoConesPointsDownward = 14,

		[System.ComponentModel.Description("one5BesomPointUpMissingDefinition")]
		[EnumMember(Value = "besom (point up)")] 
		BesomPointUp = 15,

		[System.ComponentModel.Description("one6BesomPointDownMissingDefinition")]
		[EnumMember(Value = "besom (point down)")] 
		BesomPointDown = 16,

		[System.ComponentModel.Description("AFlagMountedOnAShortPole")]
		[EnumMember(Value = "Flag")] 
		Flag = 17,

		[System.ComponentModel.Description("ASphereLocatedAboveARhombus")]
		[EnumMember(Value = "Sphere Over a Rhombus")] 
		SphereOverARhombus = 18,

		[System.ComponentModel.Description("APlaneFigureWithFourRightAnglesAndFourEqualStraightSides")]
		[EnumMember(Value = "Square")] 
		Square = 19,

		[System.ComponentModel.Description("two0RectangleHorizontalMissingDefinition")]
		[EnumMember(Value = "rectangle (horizontal)")] 
		RectangleHorizontal = 20,

		[System.ComponentModel.Description("two1RectangleVerticalMissingDefinition")]
		[EnumMember(Value = "rectangle (vertical)")] 
		RectangleVertical = 21,

		[System.ComponentModel.Description("twotwoTrapeziumUpMissingDefinition")]
		[EnumMember(Value = "trapezium (up)")] 
		TrapeziumUp = 22,

		[System.ComponentModel.Description("two3TrapeziumDownMissingDefinition")]
		[EnumMember(Value = "trapezium (down)")] 
		TrapeziumDown = 23,

		[System.ComponentModel.Description("two4TrianglePointUpMissingDefinition")]
		[EnumMember(Value = "triangle (point up)")] 
		TrianglePointUp = 24,

		[System.ComponentModel.Description("two5TrianglePointDownMissingDefinition")]
		[EnumMember(Value = "triangle (point down)")] 
		TrianglePointDown = 25,

		[System.ComponentModel.Description("APerfectlyRoundPlaneFigureWhoseCircumferenceIsEverywhereEquidistantFromItsCentre")]
		[EnumMember(Value = "Circle")] 
		Circle = 26,

		[System.ComponentModel.Description("two7TwoUprightCrossesOneOverTheOtherMissingDefinition")]
		[EnumMember(Value = "two upright crosses (one over the other)")] 
		TwoUprightCrossesOneOverTheOther = 27,

		[System.ComponentModel.Description("two8TShapeMissingDefinition")]
		[EnumMember(Value = "T-shape")] 
		TShape = 28,

		[System.ComponentModel.Description("ATriangleVertexUppermostLocatedAboveACircle")]
		[EnumMember(Value = "Triangle Pointing Up Over a Circle")] 
		TrianglePointingUpOverACircle = 29,

		[System.ComponentModel.Description("AnUprightCrossLocatedAboveACircle")]
		[EnumMember(Value = "Upright Cross Over a Circle")] 
		UprightCrossOverACircle = 30,

		[System.ComponentModel.Description("ARhombusLocatedAboveACircle")]
		[EnumMember(Value = "Rhombus Over a Circle")] 
		RhombusOverACircle = 31,

		[System.ComponentModel.Description("ACircleLocatedOverATriangleVertexUppermost")]
		[EnumMember(Value = "Circle Over a Triangle Pointing Up")] 
		CircleOverATrianglePointingUp = 32,

		[System.ComponentModel.Description("threethreeOtherShapeSeeShapeInformationMissingDefinition")]
		[EnumMember(Value = "other shape (see shape information)")] 
		OtherShapeSeeShapeInformation = 33,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryofMarineProtectedArea : int {
		[System.ComponentModel.Description("StrictNatureReserveProtectedAreaManagedMainlyForScience")]
		[EnumMember(Value = "IUCN Category Ia")] 
		IucnCategoryIa = 1,

		[System.ComponentModel.Description("WildernessAreaProtectedAreaManagedMainlyForWildernessProtection")]
		[EnumMember(Value = "IUCN Category Ib")] 
		IucnCategoryIb = 2,

		[System.ComponentModel.Description("NationalParkProtectedAreaManagedMainlyForEcosystemProtectionAndRecreation")]
		[EnumMember(Value = "IUCN Category II")] 
		IucnCategoryIi = 3,

		[System.ComponentModel.Description("NaturalMonumentProtectedAreaManagedMainlyForConservationOfSpecificNaturalFeatures")]
		[EnumMember(Value = "IUCN Category III")] 
		IucnCategoryIii = 4,

		[System.ComponentModel.Description("HabitatSpeciesManagementAreaProtectedAreaManagedMainlyForConservationThroughManagementIntervention")]
		[EnumMember(Value = "IUCN Category IV")] 
		IucnCategoryIv = 5,

		[System.ComponentModel.Description("ProtectedLandscapeSeascapeProtectedAreaManagedMainlyForLandscapeSeascapeConservationAndRecreation")]
		[EnumMember(Value = "IUCN Category V")] 
		IucnCategoryV = 6,

		[System.ComponentModel.Description("ManagedResourceProtectedAreaProtectedAreaManagedMainlyForTheSustainableUseOfNaturalEcosystems")]
		[EnumMember(Value = "IUCN Category VI")] 
		IucnCategoryVi = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfConstruction : int {
		[System.ComponentModel.Description("ConstructedOfStonesOrBricksUsuallyQuarriedShapedAndMortared")]
		[EnumMember(Value = "Masonry")] 
		Masonry = 1,

		[System.ComponentModel.Description("ConstructedOfConcreteAMaterialMadeOfSandAndGravelThatIsUnitedByCementIntoAHardenedMassUsedForRoadsFoundationsEtc")]
		[EnumMember(Value = "Concreted")] 
		Concreted = 2,

		[System.ComponentModel.Description("ConstructedFromLargeStonesOrBlocksOfConcreteOftenPlacedLooselyForProtectionAgainstWavesOrWaterTurbulence")]
		[EnumMember(Value = "Loose Boulders")] 
		LooseBoulders = 3,

		[System.ComponentModel.Description("fourHardSurfaceMissingDefinition")]
		[EnumMember(Value = "hard surface")] 
		HardSurface = 4,

		[System.ComponentModel.Description("ConstructedWithNoExtraProtectionUsuallyATermAppliedToRoadsNotSurfacedWithAHardMaterial")]
		[EnumMember(Value = "Unsurfaced")] 
		Unsurfaced = 5,

		[System.ComponentModel.Description("ConstructedFromWood")]
		[EnumMember(Value = "Wooden")] 
		Wooden = 6,

		[System.ComponentModel.Description("ConstructedFromMetal")]
		[EnumMember(Value = "Metal")] 
		Metal = 7,

		[System.ComponentModel.Description("ConstructedFromAPlasticMaterialStrengthenedWithFibresOfGlass")]
		[EnumMember(Value = "Glass Reinforced Plastic")] 
		GlassReinforcedPlastic = 8,

		[System.ComponentModel.Description("AStructureOfCrossedWoodenOrMetalStripsUsuallyArrangedToFormADiagonalPatternOfOpenSpacesBetweenTheStrips")]
		[EnumMember(Value = "Latticed")] 
		Latticed = 11,

		[System.ComponentModel.Description("oneAnyArtificialOrNaturalSubstanceHavingSimilarPropertiesAndCompositionAsFusedBoraxObsidianOrTheLike2SomethingMadeOfSuchASubstanceAsAWindowpane")]
		[EnumMember(Value = "Glass")] 
		Glass = 12,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDolphin : int {
		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedAsAMooringPointForVessels")]
		[EnumMember(Value = "Mooring Dolphin")] 
		MooringDolphin = 1,

		[System.ComponentModel.Description("APostOrGroupOfPostsWhichAVesselMaySwingAroundForCompassAdjustment")]
		[EnumMember(Value = "Deviation Dolphin")] 
		DeviationDolphin = 2,

		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedToExtendTheBerthOfAVesselByProvidingExtraMooringPoints")]
		[EnumMember(Value = "Berthing Dolphin")] 
		BerthingDolphin = 3,

		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedToAssistInBerthingOfVesselsByTakingUpSomeBerthingLoadsKeepVesselsFromPressingAgainstThePierStructureOrToProtectStructuresFromPossibleImpactByShips")]
		[EnumMember(Value = "Fender or Breasting Dolphin")] 
		FenderOrBreastingDolphin = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthFromTheChartDatumToTheSeabedOrToTheTopOfADryingFeatureIsKnown")]
		[EnumMember(Value = "Depth Known")] 
		DepthKnown = 1,

		[System.ComponentModel.Description("twoDepthUnknownMissingDefinition")]
		[EnumMember(Value = "depth unknown")] 
		DepthUnknown = 2,

		[System.ComponentModel.Description("ADepthThatMayBeLessThanIndicated")]
		[EnumMember(Value = "Doubtful Sounding")] 
		DoubtfulSounding = 3,

		[System.ComponentModel.Description("ADepthThatIsConsideredToBeAnUnreliableValue")]
		[EnumMember(Value = "Unreliable Sounding")] 
		UnreliableSounding = 4,

		[System.ComponentModel.Description("TheShoalestDepthOverAFeatureIsOfKnownValue")]
		[EnumMember(Value = "Least Depth Known")] 
		LeastDepthKnown = 6,

		[System.ComponentModel.Description("sevenLeastDepthUnknownSafeClearanceAtValueShownMissingDefinition")]
		[EnumMember(Value = "least depth unknown, safe clearance at value shown")] 
		LeastDepthUnknownSafeClearanceAtValueShown = 7,

		[System.ComponentModel.Description("eightValueReportedNotSurveyedMissingDefinition")]
		[EnumMember(Value = "value reported (not surveyed)")] 
		ValueReportedNotSurveyed = 8,

		[System.ComponentModel.Description("nineValueReportedNotConfirmedMissingDefinition")]
		[EnumMember(Value = "value reported (not confirmed)")] 
		ValueReportedNotConfirmed = 9,

		[System.ComponentModel.Description("TheDepthAtWhichAChannelIsKeptByHumanInfluenceUsuallyByDredging")]
		[EnumMember(Value = "Maintained Depth")] 
		MaintainedDepth = 10,

		[System.ComponentModel.Description("DepthsMayBeAlteredByHumanInfluenceButWillNotBeRoutinelyMaintained")]
		[EnumMember(Value = "Not Regularly Maintained")] 
		NotRegularlyMaintained = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfShorelineConstruction : int {
		[System.ComponentModel.Description("AStructureProtectingAShoreAreaHarbourAnchorageOrBasinFromWaves")]
		[EnumMember(Value = "Breakwater")] 
		Breakwater = 1,

		[System.ComponentModel.Description("ALowArtificialWallLikeStructureOfDurableMaterialExtendingFromTheLandToSeawardForAParticularPurposeSuchAsToProtectTheCoastOrToForceACurrentToScourAChannel")]
		[EnumMember(Value = "Groyne")] 
		Groyne = 2,

		[System.ComponentModel.Description("AFormOfBreakwaterAlongsideWhichVesselsMayLieOnTheShelteredSideOnlyInSomeCasesItMayLieEntirelyWithinAnArtificialHarbourPermittingVesselsToLieAlongBothSides")]
		[EnumMember(Value = "Mole")] 
		Mole = 3,

		[System.ComponentModel.Description("fourPierJettyMissingDefinition")]
		[EnumMember(Value = "pier (jetty)")] 
		PierJetty = 4,

		[System.ComponentModel.Description("APierBuiltOnlyForRecreationalPurposes")]
		[EnumMember(Value = "Promenade Pier")] 
		PromenadePier = 5,

		[System.ComponentModel.Description("sixWharfQuayMissingDefinition")]
		[EnumMember(Value = "wharf (quay)")] 
		WharfQuay = 6,

		[System.ComponentModel.Description("AWallOrBankOftenSubmergedBuiltToDirectOrConfineTheFlowOfARiverOrTidalCurrentOrToPromoteAScourAction")]
		[EnumMember(Value = "Training Wall")] 
		TrainingWall = 7,

		[System.ComponentModel.Description("ALayerOfBrokenRockCobblesBouldersOrFragmentsOfSufficientSizeToResistTheErosiveForcesOfFlowingWaterAndWaveAction")]
		[EnumMember(Value = "Rip Rap")] 
		RipRap = 8,

		[System.ComponentModel.Description("FacingOfStoneOrOtherMaterialEitherPermanentOrTemporaryPlacedAlongTheEdgeOfAStreamRiverOrCanalToStabilizeTheBankAndToProtectItFromTheErosiveActionOfTheStream")]
		[EnumMember(Value = "Revetment")] 
		Revetment = 9,

		[System.ComponentModel.Description("AnEmbankmentOrWallForProtectionAgainstWavesOrTidalActionAlongAShoreOrWaterFront")]
		[EnumMember(Value = "Sea Wall")] 
		SeaWall = 10,

		[System.ComponentModel.Description("StepsAtTheShorelineAsTheConnectionBetweenLandAndWaterOnDifferentLevels")]
		[EnumMember(Value = "Landing Steps")] 
		LandingSteps = 11,

		[System.ComponentModel.Description("oneASlopingStructureWhichMayIncludeRailsThatCanEitherBeUsedAsALandingPlaceAtVariableWaterLevelsForSmallVesselsLandingShipsOrAFerryBoatOrForHaulingACradleCarryingAVessel2AnAccumulationOfSnowThatFormsAnInclinedPlaneBetweenLandOrLandIceElementsAndSeaIceOrIceShelfAlsoCalledDriftIceFoot")]
		[EnumMember(Value = "Ramp")] 
		Ramp = 12,

		[System.ComponentModel.Description("ThePreparedAndUsuallyReinforcedInclinedSurfaceOnWhichKeelAndBilgeBlocksAreLaidForSupportingAVesselUnderConstruction")]
		[EnumMember(Value = "Slipway")] 
		Slipway = 13,

		[System.ComponentModel.Description("AProtectiveStructureDesignedToCushionTheImpactOfAVesselAndPreventDamage")]
		[EnumMember(Value = "Fender")] 
		Fender = 14,

		[System.ComponentModel.Description("AWharfConsistingOfASolidWallOfConcreteMasonryWoodEtcSuchThatTheWaterCannotCirculateFreelyUnderTheWharfTheTypeOfConstructionAffectsShipHandlingForExampleASolidFaceWharfMayGiveShelterFromTidalStreamsButUnderCertainCircumstancesACushionOfWaterMayBuildUpBetweenSuchAWharfAndAShipAttemptingToBerthAtItCausingDifficultiesInShipHandling")]
		[EnumMember(Value = "Solid Face Wharf")] 
		SolidFaceWharf = 15,

		[System.ComponentModel.Description("AWharfSupportedOnPilesOrOtherStructuresWhichAllowFreeCirculationOfWaterUnderTheWharf")]
		[EnumMember(Value = "Open Face Wharf")] 
		OpenFaceWharf = 16,

		[System.ComponentModel.Description("AnInclinedPlaneUsedToDumpLogsIntoTheWaterForTransportOrToHaulLogsOutOfTheWaterForProcessing")]
		[EnumMember(Value = "Log Ramp")] 
		LogRamp = 17,

		[System.ComponentModel.Description("AnArtificialPoolOrSwimmingEnclosureEspeciallyOneInTheOpenAirWhichMayBeConstructedOfWireMeshOrHeavyNettingSupportedByCablesBuoysOrPilesForSwimmingIn")]
		[EnumMember(Value = "Swimming Facility")] 
		SwimmingFacility = 20,

		[System.ComponentModel.Description("AWharfApproximatelyParallelToTheShorelineAndAccommodatingShipsOnOneSideOnlyTheOtherSideBeingAttachedToTheShoreItIsUsuallyOfSolidConstructionAsContrastedWithTheOpenPileConstructionUsuallyUsedForPiers")]
		[EnumMember(Value = "Quay")] 
		Quay = 22,

		[System.ComponentModel.Description("two3TieUpWallMissingDefinition")]
		[EnumMember(Value = "tie-up wall")] 
		TieUpWall = 23,

		[System.ComponentModel.Description("ManMadeStructureThatActsAsAnObstacleToLandingOperations")]
		[EnumMember(Value = "Artificial Obstacle")] 
		ArtificialObstacle = 501,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightVisibility : int {
		[System.ComponentModel.Description("NonMarineLightsWithAHigherPowerThanMarineLightsAndVisibleFromWellOffShoreOftenAeroLights")]
		[EnumMember(Value = "High Intensity")] 
		HighIntensity = 1,

		[System.ComponentModel.Description("NonMarineLightsWithLowerPowerThanMarineLights")]
		[EnumMember(Value = "Low Intensity")] 
		LowIntensity = 2,

		[System.ComponentModel.Description("ADecreaseInTheApparentIntensityOfALightWhichMayOccurInTheCaseOfPartialObstructions")]
		[EnumMember(Value = "Faint")] 
		Faint = 3,

		[System.ComponentModel.Description("ALightInASectorIsIntensifiedThatIsHasLongerRangeThanOtherSectors")]
		[EnumMember(Value = "Intensified")] 
		Intensified = 4,

		[System.ComponentModel.Description("ALightInASectorIsUnintensifiedThatIsHasShorterRangeThanOtherSectors")]
		[EnumMember(Value = "Unintensified")] 
		Unintensified = 5,

		[System.ComponentModel.Description("ALightSectorIsDeliberatelyReducedInIntensityForExampleToReduceItsEffectOnABuiltUpArea")]
		[EnumMember(Value = "Visibility Deliberately Restricted")] 
		VisibilityDeliberatelyRestricted = 6,

		[System.ComponentModel.Description("SaidOfTheArcOfALightSectorDesignatedByItsLimitingBearingsInWhichTheLightIsNotVisibleFromSeaward")]
		[EnumMember(Value = "Obscured")] 
		Obscured = 7,

		[System.ComponentModel.Description("ThisValueSpecifiesThatPartsOfTheSectorAreObscured")]
		[EnumMember(Value = "Partially Obscured")] 
		PartiallyObscured = 8,

		[System.ComponentModel.Description("LightsThatMustBeInLineToBeVisible")]
		[EnumMember(Value = "Visible in Line of Range")] 
		VisibleInLineOfRange = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSeaArea : int {
		[System.ComponentModel.Description("ANaturalOrArtificialPassageOrChannelThroughShoalsOrSteepBanksOrAcrossALineOfBanksLyingBetweenTwoChannels")]
		[EnumMember(Value = "Gat")] 
		Gat = 2,

		[System.ComponentModel.Description("AnElevationOfTheSeafloorAtDepthsGenerallyLessThan200MButSufficientForSafeSurfaceNavigationCommonlyFoundOnTheContinentalShelfOrNearAnIsland")]
		[EnumMember(Value = "Bank")] 
		Bank = 3,

		[System.ComponentModel.Description("InOceanographyAnObsoleteTermWhichWasGenerallyRestrictedToDepthsGreaterThan6000M")]
		[EnumMember(Value = "Deep")] 
		Deep = 4,

		[System.ComponentModel.Description("AWideIndentationInTheCoastlineGenerallySmallerThanAGulfAndLargerThanACoveForThePurposesOfTheUnitedNationsConventionOnTheLawOfTheSeaABayIsAWellMarkedIndentationWhosePenetrationIsInSuchProportionToTheWidthOfItsMouthAsToContainLandLockedWatersAndConstituteMoreThanAMereCurvatureOfTheCoast")]
		[EnumMember(Value = "Bay")] 
		Bay = 5,

		[System.ComponentModel.Description("ALongDeepAsymmetricalDepressionWithRelativelySteepSidesThatIsAssociatedWithSubduction")]
		[EnumMember(Value = "Trench")] 
		Trench = 6,

		[System.ComponentModel.Description("ADepressionOfTheSeafloorMoreOrLessEquidimensionalInPlanAndOfVariableExtent")]
		[EnumMember(Value = "Basin")] 
		Basin = 7,

		[System.ComponentModel.Description("ALevelTractOfLandAsTheBedOfADryLakeOrAnAreaFrequentlyUncoveredAtLowTideUsuallyInPlural")]
		[EnumMember(Value = "Mud Flats")] 
		MudFlats = 8,

		[System.ComponentModel.Description("AShallowElevationComposedOfConsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Reef")] 
		Reef = 9,

		[System.ComponentModel.Description("ARockyFormationContinuousWithAndFringingTheShore")]
		[EnumMember(Value = "Ledge")] 
		Ledge = 10,

		[System.ComponentModel.Description("AnElongatedNarrowSteepSidedDepressionThatGenerallyDeepensDownSlope")]
		[EnumMember(Value = "Canyon")] 
		Canyon = 11,

		[System.ComponentModel.Description("ANavigableNarrowPartOfABayStraitRiverEtc")]
		[EnumMember(Value = "Narrows")] 
		Narrows = 12,

		[System.ComponentModel.Description("AShallowElevationComposedOfUnconsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Shoal")] 
		Shoal = 13,

		[System.ComponentModel.Description("ADistinctElevationWithARoundedProfileLessThan1000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Knoll")] 
		Knoll = 14,

		[System.ComponentModel.Description("AnElongatedElevationOfVaryingComplexityAndSizeGenerallyHavingSteepSides")]
		[EnumMember(Value = "Ridge")] 
		Ridge = 15,

		[System.ComponentModel.Description("ADistinctGenerallyEquidimensionalElevationGreaterThan1000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Seamount")] 
		Seamount = 16,

		[System.ComponentModel.Description("AnyHighTowerOrSpireShapedPillarOrRockOrCoralAloneOrCrestingASummitItMayExtendAboveTheSurfaceOfTheWaterItMayOrMayNotBeAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Pinnacle")] 
		Pinnacle = 17,

		[System.ComponentModel.Description("AnExtensiveFlatGentlySlopingOrNearlyLevelRegionAtAbyssalDepths")]
		[EnumMember(Value = "Abyssal Plain")] 
		AbyssalPlain = 18,

		[System.ComponentModel.Description("ALargeRelativelyFlatElevationThatIsHigherThanTheSurroundingReliefWithOneOrMoreRelativelySteepSides")]
		[EnumMember(Value = "Plateau")] 
		Plateau = 19,

		[System.ComponentModel.Description("ASubordinateRidgeProtrudingFromALargerFeature")]
		[EnumMember(Value = "Spur")] 
		Spur = 20,

		[System.ComponentModel.Description("TheFlatOrGentlySlopingRegionAdjacentToAContinentOrAroundAnIslandThatExtendsFromTheLowWaterLineToADepthGenerallyAbout200mWhereThereIsAMarkedIncreaseInDownwardSlope")]
		[EnumMember(Value = "Shelf")] 
		Shelf = 21,

		[System.ComponentModel.Description("ALongDepressionGenerallyWideAndFlatBottomedWithSymmetricalAndParallelSides")]
		[EnumMember(Value = "Trough")] 
		Trough = 22,

		[System.ComponentModel.Description("ABroadPassOrColInARidgeRiseOrOtherElevation")]
		[EnumMember(Value = "Saddle")] 
		Saddle = 23,

		[System.ComponentModel.Description("AnIsolatedSmallElevationOnTheDeepSeafloor")]
		[EnumMember(Value = "Abyssal Hill")] 
		AbyssalHill = 24,

		[System.ComponentModel.Description("AGentlyDippingSlopeWithASmoothSurfaceCommonlyFoundAroundGroupsOfIslandsAndSeamounts")]
		[EnumMember(Value = "Apron")] 
		Apron = 25,

		[System.ComponentModel.Description("AGentleSlopeWithAGenerallySmoothSurfaceOfTheSeafloorCharacteristicallyFoundAroundGroupsOfIslandsOrSeamounts")]
		[EnumMember(Value = "Archipelagic Apron")] 
		ArchipelagicApron = 26,

		[System.ComponentModel.Description("ARegionAdjacentToAContinentNormallyOccupiedByOrBorderingAShelfAndSometimesEmergingAsIslandsThatIsIrregularOrBlockyInPlanOrProfileWithDepthsWellInExcessOfThoseTypicalOfAShelf")]
		[EnumMember(Value = "Borderland")] 
		Borderland = 27,

		[System.ComponentModel.Description("TheZoneGenerallyConsistingOfShelfSlopeAndContinentalRiseSeparatingTheContinentFromTheDeepSeafloorOrAbyssalPlainOrPlainOccasionallyATrenchMayBePresentInPlaceOfAContinentalRise")]
		[EnumMember(Value = "Continental Margin")] 
		ContinentalMargin = 28,

		[System.ComponentModel.Description("AGentleSlopeRisingFromTheOceanicDepthsTowardsTheFootOfAContinentalSlope")]
		[EnumMember(Value = "Continental Rise")] 
		ContinentalRise = 29,

		[System.ComponentModel.Description("AnElongatedCharacteristicallyLinearSteepSlopeSeparatingHorizontalOrGentlySlopingAreasOfTheSeafloor")]
		[EnumMember(Value = "Escarpment")] 
		Escarpment = 30,

		[System.ComponentModel.Description("ARelativelySmoothDepositionalFeatureContinuouslyDeepeningAwayFromASedimentSourceCommonlyLocatedAtTheLowerTerminationOfACanyonOrCanyonSystem")]
		[EnumMember(Value = "Fan")] 
		Fan = 31,

		[System.ComponentModel.Description("ALongNarrowZoneOfIrregularTopographyFormedByTheMovementOfTectonicPlatesAssociatedWithAnOffsetOfASpreadingRidgeAxisCharacterizedBySteepSidedAndOrAsymmetricalRidgesTroughsOrEscarpments")]
		[EnumMember(Value = "Fracture Zone")] 
		FractureZone = 32,

		[System.ComponentModel.Description("ANarrowBreakInARidgeRiseOrOtherElevation")]
		[EnumMember(Value = "Gap")] 
		Gap = 33,

		[System.ComponentModel.Description("ASeamountHavingAComparativelySmoothFlatTop")]
		[EnumMember(Value = "Guyot")] 
		Guyot = 34,

		[System.ComponentModel.Description("oneASmallIsolatedElevationSmallerThanAMountain2ADistinctElevationGenerallyOfIrregularShapeLessThanone000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Hill")] 
		Hill = 35,

		[System.ComponentModel.Description("ADepressionOfLimitedExtentWithAllSidesRisingSteeplyFromARelativelyFlatBottom")]
		[EnumMember(Value = "Hole")] 
		Hole = 36,

		[System.ComponentModel.Description("ADepositionalEmbankmentBorderingACanyonValleyOrSeaChannel")]
		[EnumMember(Value = "Levee")] 
		Levee = 37,

		[System.ComponentModel.Description("TheAxialDepressionOfTheMidOceanicRidgeSystem")]
		[EnumMember(Value = "Median Valley")] 
		MedianValley = 38,

		[System.ComponentModel.Description("AnAnnularOrPartiallyAnnularDepressionCommonlyLocatedAtTheBaseOfSeamountsIslandsAndOtherIsolatedElevations")]
		[EnumMember(Value = "Moat")] 
		Moat = 39,

		[System.ComponentModel.Description("ANaturalElevationOfTheEarthSSurfaceRisingMoreOrLessAbruptlyFromTheSurroundingLevelAndAttainingAnAltitudeWhichRelativelyToAdjacentElevationsIsImpressiveOrNotable")]
		[EnumMember(Value = "Mountains")] 
		Mountains = 40,

		[System.ComponentModel.Description("AConicalOrPointedElevationOnALargerFeatureSuchAsASeamount")]
		[EnumMember(Value = "Peak")] 
		Peak = 41,

		[System.ComponentModel.Description("AGeographicallyDistinctRegionWithANumberOfSharedPhysiographicCharacteristicsThatContrastWithThoseInTheSurroundingAreasThisTermShouldBeModifiedWithTheGenericTermThatBestDescribesTheMajorityOfFeaturesInTheRegionForExampleSeamountInBajaCaliforniaSeamountProvince")]
		[EnumMember(Value = "Province")] 
		Province = 42,

		[System.ComponentModel.Description("ABroadElevationThatGenerallyRisesGentlyAndSmoothlyFromTheSurroundingRelief")]
		[EnumMember(Value = "Rise")] 
		Rise = 43,

		[System.ComponentModel.Description("AnElongatedMeanderingDepressionUsuallyOccurringOnAGentlySlopingPlainOrFan")]
		[EnumMember(Value = "Sea Channel")] 
		SeaChannel = 44,

		[System.ComponentModel.Description("SeveralSeamountsInLinearOrArcuateAlignment")]
		[EnumMember(Value = "Seamount Chain")] 
		SeamountChain = 45,

		[System.ComponentModel.Description("four6ShelfEdgeMissingDefinition")]
		[EnumMember(Value = "shelf-edge")] 
		ShelfEdge = 46,

		[System.ComponentModel.Description("ARelativelyShallowBarrierBetweenBasinsThatMayInhibitWaterMovement")]
		[EnumMember(Value = "Sill")] 
		Sill = 47,

		[System.ComponentModel.Description("TheSlopingRegionThatDeepensFromAShelfToThePointWhereThereIsAGeneralDecreaseInGradient")]
		[EnumMember(Value = "Slope")] 
		Slope = 48,

		[System.ComponentModel.Description("AFlatOrGentlySlopingRegionGenerallyLongAndNarrowBoundedAlongOneEdgeByASteeperDescendingSlopeAndAlongTheOtherByASteeperAscendingSlope")]
		[EnumMember(Value = "Terrace")] 
		Terrace = 49,

		[System.ComponentModel.Description("AnElongatedDepressionThatGenerallyWidensAndDeepensDownSlope")]
		[EnumMember(Value = "Valley")] 
		Valley = 50,

		[System.ComponentModel.Description("AnArtificialWaterwayWithNoFlowOrAControlledFlowUsedForNavigationOrForDrainingOrIrrigatingLandDitch")]
		[EnumMember(Value = "Canal")] 
		Canal = 51,

		[System.ComponentModel.Description("ALargeBodyOfWaterEntirelySurroundedByLand")]
		[EnumMember(Value = "Lake")] 
		Lake = 52,

		[System.ComponentModel.Description("ARelativelyLargeNaturalStreamOfWater")]
		[EnumMember(Value = "River")] 
		River = 53,

		[System.ComponentModel.Description("AStraightSectionOfARiverEspeciallyANavigableRiverBetweenTwoBendsOrAnArmOfTheSeaExtendingIntoTheLand")]
		[EnumMember(Value = "Reach")] 
		Reach = 54,

		[System.ComponentModel.Description("ALowFlatIslandOfSandCoralEtcAwashOrSubmergedAtHighWater")]
		[EnumMember(Value = "Intertidal Cay")] 
		IntertidalCay = 55,

		[System.ComponentModel.Description("ASeabedVolcanoSubmergedAtTheChartSoundingDatumWhichMayOrMayNotBeActive")]
		[EnumMember(Value = "Submarine Volcano")] 
		SubmarineVolcano = 56,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfConveyor : int {
		[System.ComponentModel.Description("ATransportationSystemConsistingOfLoadCablesStrungBetweenPylonsOnWhichCarrierUnitsForExampleCarsOrBucketsIntendedToTransportPeopleMaterialAndOrEquipmentAreSuspended")]
		[EnumMember(Value = "Aerial Cableway")] 
		AerialCableway = 1,

		[System.ComponentModel.Description("AConveyorAlongWhichMaterialOrPeopleAreTransportedByMeansOfAMovingBelt")]
		[EnumMember(Value = "Belt Conveyor")] 
		BeltConveyor = 2,

		[System.ComponentModel.Description("AnArtificialChannelUsuallyAnInclinedChuteOrTroughForCarryingWaterToFurnishPowerTransportLogsDownAMountainsideEtc")]
		[EnumMember(Value = "Flume")] 
		Flume = 3,

		[System.ComponentModel.Description("fourLiftElevatorMissingDefinition")]
		[EnumMember(Value = "lift/elevator")] 
		LiftElevator = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRoad : int {
		[System.ComponentModel.Description("ALimitedAccessDualCarriagewayRoadSpeciallyDesignedForFastLongDistanceTrafficAndSubjectToSpecialRegulationsConcerningItsUseItMayHaveMoreThanTwoLanes")]
		[EnumMember(Value = "Motorway")] 
		Motorway = 1,

		[System.ComponentModel.Description("AHardSurfacedMetalledRoadAMainThroughRoute")]
		[EnumMember(Value = "Major Road")] 
		MajorRoad = 2,

		[System.ComponentModel.Description("ASecondaryRoadForLocalTraffic")]
		[EnumMember(Value = "Minor Road")] 
		MinorRoad = 3,

		[System.ComponentModel.Description("fourTrackPathMissingDefinition")]
		[EnumMember(Value = "track/path")] 
		TrackPath = 4,

		[System.ComponentModel.Description("AMainRoadInAnUrbanAreaForThroughTraffic")]
		[EnumMember(Value = "Major Street")] 
		MajorStreet = 5,

		[System.ComponentModel.Description("ASecondaryRoadInAnUrbanAreaForLocalTraffic")]
		[EnumMember(Value = "Minor Street")] 
		MinorStreet = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum bottomFeatureClassification : int {
		[System.ComponentModel.Description("InGeologyABreakOfShearInTheEarthSCrustWithAnObservableDisplacementBetweenTheTwoSidesOfTheBreakAndParallelToThePlaneOfTheBreak")]
		[EnumMember(Value = "Fault")] 
		Fault = 502,

		[System.ComponentModel.Description("ALargeMobileWaveLikeSedimentFeatureInShallowWaterAndComposedOfSandTheWavelengthMayReach100MetresTheAmplitudeMayBeUpTo20Metres")]
		[EnumMember(Value = "Sandwave")] 
		Sandwave = 510,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		Metres = 1,

		[System.ComponentModel.Description("TheTonneOrMetricTonUSOftenRedundantlyReferredToAsAMetricTonneIsAUnitOfMassEqualTo1000Kg2205LbOrApproximatelyTheMassOfOneCubicMetreOfWaterAtFourDegreesCelsiusItIsSometimesAbbreviatedAsMtInTheUnitedStatesButThisConflictsWithOtherSiSymbolsTheTonneIsNotAUnitInTheInternationalSystemOfUnitsSiButIsAcceptedForUseWithTheSiInSiUnitsAndPrefixesTheTonneIsAMegagramMgTheImperialAndUsCustomaryUnitsComparableToTheTonneAreBothSpelledTonInEnglishThoughTheyDifferInMassPronunciationOfTonneTheWordUsedInTheUkAndTonIsUsuallyIdenticalButIsNotTooConfusingUnlessAccuracyIsImportantAsTheTonneAndUkLongTonDifferByOnly16")]
		[EnumMember(Value = "Metric Ton")] 
		MetricTon = 3,

		[System.ComponentModel.Description("LongTonWeightTonOrImperialTonIsTheNameForTheUnitCalledTheTonInTheAvoirdupoisOrImperialSystemOfMeasurementsAsUsedInTheUnitedKingdomAndSeveralOtherCommonwealthCountriesItHasBeenMostlyReplacedByTheTonneAndInTheUnitedStatesByTheShortTonOneLongTonIsEqualTo2240Pounds1016KgOr35CubicFeet09911MOfSaltWaterWithADensityOf64LbFt1025GMlItHasSomeLimitedUseInTheUnitedStatesMostCommonlyInMeasuringTheDisplacementOfShipsAndWasTheUnitPrescribedForWarshipsByTheWashingtonNavalTreatyForExampleBattleshipsWereLimitedToAMassOf35000LongTons36000T39000St")]
		[EnumMember(Value = "Ton")] 
		Ton = 4,

		[System.ComponentModel.Description("AUnitOfWeightEqualTo2000Pounds90718474KgInTheUnitedStatesItIsOftenCalledSimplyTonWithoutDistinguishingItFromTheMetricTonTonne1000KilogramsOrTheLongTon2240Pounds10160469088KilogramsRatherTheOtherTwoAreSpecificallyNotedThereAreHoweverSomeUsApplicationsForWhichUnspecifiedTonsNormallyMeansLongTonsForExampleNavyShipsOrMetricTonsWorldGrainProductionFiguresBothTheLongAndShortTonAreDefinedAs20HundredweightsButAHundredweightIs100Pounds45359237KgInTheUsSystemShortOrNetHundredweightAnd112Pounds5080234544KgInTheImperialSystemLongOrGrossHundredweight")]
		[EnumMember(Value = "Short Ton")] 
		ShortTon = 5,

		[System.ComponentModel.Description("GrossTonnageGtIsAFunctionOfTheVolumeOfAllShipSEnclosedSpacesFromKeelToFunnelMeasuredToTheOutsideOfTheHullFramingThereIsASlidingScaleFactorSoGtIsAKindOfCapacityDerivedIndexThatIsUsedToRankAShipForPurposesOfDeterminingManningSafetyAndOtherStatutoryRequirementsAndIsExpressedSimplyAsGtWhichIsAUnitlessEntityEvenThoughItsDerivationIsTiedToTheCubicMeterUnitOfVolumetricCapacityTonnageMeasurementsAreNowGovernedByAnImoConventionInternationalConventionOnTonnageMeasurementOfShips1969LondonRulesWhichAppliesToAllShipsBuiltAfterJuly1982InAccordanceWithTheConventionTheCorrectTermToUseNowIsGtWhichIsAFunctionOfTheMouldedVolumeOfAllEnclosedSpacesOfTheShip")]
		[EnumMember(Value = "Gross Ton")] 
		GrossTon = 6,

		[System.ComponentModel.Description("NetTonnageNtIsBasedOnACalculationOfTheVolumeOfAllCargoSpacesOfTheShipItIndicatesAVesselsEarningSpaceAndIsAFunctionOfTheMouldedVolumeOfAllCargoSpacesOfTheShip")]
		[EnumMember(Value = "Net Ton")] 
		NetTon = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum firstSensor : int {
		[System.ComponentModel.Description("five01AcousticSensorMissingDefinition")]
		[EnumMember(Value = "acoustic sensor")] 
		AcousticSensor = 501,

		[System.ComponentModel.Description("TheObjectWasReportedAsAResultOfDetectingAFluctuationInTheLocalMagneticField")]
		[EnumMember(Value = "Magnetic Sensor")] 
		MagneticSensor = 502,

		[System.ComponentModel.Description("five03VideoSensorMissingDefinition")]
		[EnumMember(Value = "video sensor")] 
		VideoSensor = 503,

		[System.ComponentModel.Description("five04DiverSightingFoundByDiverInRegistryMissingDefinition")]
		[EnumMember(Value = "diver sighting - (found by diver - in registry)")] 
		DiverSightingFoundByDiverInRegistry = 504,

		[System.ComponentModel.Description("five06PhysicalSnagMissingDefinition")]
		[EnumMember(Value = "physical snag")] 
		PhysicalSnag = 506,

		[System.ComponentModel.Description("five07ObservedSinkingMissingDefinition")]
		[EnumMember(Value = "observed sinking")] 
		ObservedSinking = 507,

		[System.ComponentModel.Description("five08ReportedSinkingMissingDefinition")]
		[EnumMember(Value = "Reported Sinking")] 
		ReportedSinking = 508,

		[System.ComponentModel.Description("five09NoneReportedMissingDefinition")]
		[EnumMember(Value = "None reported")] 
		NoneReported = 509,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum waterLevelEffect : int {
		[System.ComponentModel.Description("PartiallyCoveredAndPartiallyDryAtHighWater")]
		[EnumMember(Value = "Partly Submerged at High Water")] 
		PartlySubmergedAtHighWater = 1,

		[System.ComponentModel.Description("NotCoveredAtHighWaterUnderAverageMeteorologicalConditions")]
		[EnumMember(Value = "Always Dry")] 
		AlwaysDry = 2,

		[System.ComponentModel.Description("threeAlwaysUnderWaterMissingDefinition")]
		[EnumMember(Value = "always under water/")] 
		AlwaysUnderWater = 3,

		[System.ComponentModel.Description("ExpressionIntendedToIndicateAnAreaOfAReefOrOtherProjectionFromTheBottomOfABodyOfWaterWhichPeriodicallyExtendsAboveAndIsSubmergedBelowTheSurfaceAlsoReferredToAsDriesOrUncovers")]
		[EnumMember(Value = "Covers and Uncovers")] 
		CoversAndUncovers = 4,

		[System.ComponentModel.Description("FlushWithOrWashedByTheWavesAtLowWaterUnderAverageMeteorologicalConditions")]
		[EnumMember(Value = "Awash")] 
		Awash = 5,

		[System.ComponentModel.Description("sixSubjectToInundationOrMissingDefinition")]
		[EnumMember(Value = "subject to inundation or")] 
		SubjectToInundationOr = 6,

		[System.ComponentModel.Description("RestingOrMovingOnTheSurfaceOfALiquidWithoutSinking")]
		[EnumMember(Value = "Floating")] 
		Floating = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum boundaryStatusType : int {
		[System.ComponentModel.Description("five01DefiniteMissingDefinition")]
		[EnumMember(Value = "definite")] 
		Definite = 501,

		[System.ComponentModel.Description("five02IndefiniteMissingDefinition")]
		[EnumMember(Value = "indefinite")] 
		Indefinite = 502,

		[System.ComponentModel.Description("HasNotBeenDefinedByEitherOfTheAdjoiningAuthorities")]
		[EnumMember(Value = "no defined boundary")] 
		NoDefinedBoundary = 504,

		[System.ComponentModel.Description("BoundaryHasNotBeenRatified")]
		[EnumMember(Value = "Not Yet Ratified")] 
		NotYetRatified = 599,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalGeneration : int {
		[System.ComponentModel.Description("ActivatedByRadioSignal")]
		[EnumMember(Value = "Radio Activated")] 
		RadioActivated = 5,

		[System.ComponentModel.Description("ActivatedByMakingACallToAMannedStation")]
		[EnumMember(Value = "Call Activated")] 
		CallActivated = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum speciesGrouping : int {
		[System.ComponentModel.Description("AnyOfAnOrderCetaceaOfAquaticMostlyMarineMammalsThatIncludesTheWhalesDolphinsPorpoisesAndRelatedFormsAndThatHaveATorpedoShapedNearlyHairlessBodyPaddleShapedForelimbsButNoHindLimbsOneOrTwoNaresOpeningExternallyAtTheTopOfTheHeadAndAHorizontallyFlattenedTailUsedForLocomotion")]
		[EnumMember(Value = "Cetacean")] 
		Cetacean = 501,

		[System.ComponentModel.Description("AnyOfAnOrderOrSuborderPinnipediaOfAquaticCarnivorousMammalsSuchAsASealOrWalrusWithAllFourLimbsModifiedIntoFlippers")]
		[EnumMember(Value = "Pinniped")] 
		Pinniped = 502,

		[System.ComponentModel.Description("VertebrateColdBloodedAnimalWithGillsLivingInWater")]
		[EnumMember(Value = "Fish")] 
		Fish = 503,

		[System.ComponentModel.Description("AnyOfAnOrderTestudinesSynonymCheloniaOfTerrestrialFreshwaterAndMarineReptilesThatHaveAToothlessHornyBeakAndAShellOfBonyDermalPlatesUsuallyCoveredWithHornyShieldsEnclosingTheTrunkAndIntoWhichTheHeadLimbsAndTailUsuallyMayBeWithdrawn")]
		[EnumMember(Value = "Turtle")] 
		Turtle = 504,

		[System.ComponentModel.Description("AnyOfAClassAvesOfWarmBloodedVertebratesDistinguishedByHavingTheBodyMoreOrLessCompletelyCoveredWithFeathersAndTheForelimbsModifiedAsWings")]
		[EnumMember(Value = "Bird")] 
		Bird = 505,

		[System.ComponentModel.Description("AnyOfAnOrderSireniaOfAquaticHerbivorousMammalsSuchAsAManateeDugongOrStellerSSeaCowThatHaveLargeForelimbsResemblingPaddlesNoHindLimbsAndAFlattenedTailResemblingAFin")]
		[EnumMember(Value = "Sirenian")] 
		Sirenian = 506,

		[System.ComponentModel.Description("five07OtterAnimalMissingDefinition")]
		[EnumMember(Value = "Otter (animal)")] 
		OtterAnimal = 507,

		[System.ComponentModel.Description("ALargeCreamyWhiteCarnivorousBearUrsusMaritimusSynonymThalarctosMaritimusThatInhabitsArcticRegions")]
		[EnumMember(Value = "Polar bear")] 
		PolarBear = 508,

		[System.ComponentModel.Description("AnyOfNumerousVenomousAquaticChieflyViviparousElapidSnakesOfWarmSeas")]
		[EnumMember(Value = "Sea snake")] 
		SeaSnake = 509,

		[System.ComponentModel.Description("AReefOftenOfLargeExtentComposedChieflyOfCoralAndItsDerivatives")]
		[EnumMember(Value = "Coral Reef")] 
		CoralReef = 510,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfReportingRadioCallingInPoint : int {
		[System.ComponentModel.Description("five01ReportingRadioCallingInPointMissingDefinition")]
		[EnumMember(Value = "Reporting/Radio calling in point")] 
		ReportingRadioCallingInPoint = 501,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFishingFacility : int {
		[System.ComponentModel.Description("PolesOrStakesPlacedInShallowWaterToOutlineAFishingGroundOrToCatchFish")]
		[EnumMember(Value = "Fishing Stake")] 
		FishingStake = 1,

		[System.ComponentModel.Description("AStructureUsuallyPortableForCatchingFish")]
		[EnumMember(Value = "Fish Trap")] 
		FishTrap = 2,

		[System.ComponentModel.Description("AFenceOfStakesOrStonesSetInARiverOrAlongTheShoreToTrapFish")]
		[EnumMember(Value = "Fish Weir")] 
		FishWeir = 3,

		[System.ComponentModel.Description("ANetBuiltAtSeaForCatchingTunny")]
		[EnumMember(Value = "Tunny Net")] 
		TunnyNet = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	public static class CodeList
	{
	}

	namespace ComplexAttributes {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class qRouteChannelWidth {
			[Required()]
			public decimal rightQRouteWidth {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class detectionDateRange {
			public String? lastDetectionYear {get;set;} = default;

			public bool ShouldSerializelastDetectionYear() { return !string.IsNullOrEmpty(lastDetectionYear); }

			public String? firstDetectionYear {get;set;} = default;

			public bool ShouldSerializefirstDetectionYear() { return !string.IsNullOrEmpty(firstDetectionYear); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class multiplicityOfFeatures {
			public int? numberOfFeatures {get;set;} = default;

			public bool ShouldSerializenumberOfFeatures() { return numberOfFeatures.HasValue; }

			[Required()]
			public Boolean multiplicityKnown {get;set;} = false;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			public String linkage {get;set;} = string.Empty;

			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[EnumerationValue([1,2])]
			public nameUsage? nameUsage {get;set;} = default;

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }

			public String name {get;set;} = string.Empty;

			public String language {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class fixedDateRange {
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			public String? dateEnd {get;set;} = default;

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class altitudeRange {
			[Required()]
			public int minimumAltitude {get;set;}

			[Required()]
			public int maximumAltitude {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class altitude {
			[Required()]
			public int minimumAltitude {get;set;}

			[Required()]
			public int maximumAltitude {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lastSourceInformation {
			[EnumerationValue([501,502,503,504,506,509])]
			public lastSensor? lastSensor {get;set;} = default;

			public bool ShouldSerializelastSensor() { return lastSensor.HasValue; }

			public String? lastSource {get;set;} = default;

			public bool ShouldSerializelastSource() { return !string.IsNullOrEmpty(lastSource); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			public String language {get;set;} = string.Empty;

			public String? fileLocator {get;set;} = default;

			public bool ShouldSerializefileLocator() { return !string.IsNullOrEmpty(fileLocator); }

			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }

			public String? fileReference {get;set;} = default;

			public bool ShouldSerializefileReference() { return !string.IsNullOrEmpty(fileReference); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class firstSourceInformation {
			[EnumerationValue([501,502,503,504,506,509])]
			[Required()]
			public firstSensor firstSensor {get;set;}

			public String? firstSource {get;set;} = default;

			public bool ShouldSerializefirstSource() { return !string.IsNullOrEmpty(firstSource); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalClearanceFixed {
			[Required()]
			public decimal horizontalClearanceValue {get;set;}

			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty {
			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }

			[Required()]
			public decimal uncertaintyFixed {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			public int? frequencyShoreStationReceives {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }

			[Required()]
			public int frequencyShoreStationTransmits {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselMeasurementsSpecification {
			[Required()]
			public decimal vesselsCharacteristicsValue {get;set;}

			[EnumerationValue([1,2,3,4,6,10,11])]
			[Required()]
			public vesselsCharacteristics vesselsCharacteristics {get;set;}

			[EnumerationValue([1,3,4,5,6,7])]
			[Required()]
			public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;}

			[EnumerationValue([1,2,3,4,5,6])]
			public comparisonOperator? comparisonOperator {get;set;} = default;

			public bool ShouldSerializecomparisonOperator() { return comparisonOperator.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surfaceCharacteristics {
			public int? underlyingLayer {get;set;} = default;

			public bool ShouldSerializeunderlyingLayer() { return underlyingLayer.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms {get;set;} = [];

			public bool ShouldSerializenatureOfSurfaceQualifyingTerms() { return natureOfSurfaceQualifyingTerms.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class magneticInformation {
			[EnumerationValue([501,502,503,504])]
			public strengthOfMagneticAnomaly? strengthOfMagneticAnomaly {get;set;} = default;

			public bool ShouldSerializestrengthOfMagneticAnomaly() { return strengthOfMagneticAnomaly.HasValue; }

			public int? magneticIntensity {get;set;} = default;

			public bool ShouldSerializemagneticIntensity() { return magneticIntensity.HasValue; }

			[EnumerationValue([501,502,503,504])]
			[Required()]
			public magneticAnomalyDetectorSignature magneticAnomalyDetectorSignature {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class speed {
			public decimal? speedMinimum {get;set;} = default;

			public bool ShouldSerializespeedMinimum() { return speedMinimum.HasValue; }

			[Required()]
			public decimal speedMaximum {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalClearanceFixed {
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[Required()]
			public decimal verticalClearanceValue {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIdentification {
			public String? producerNation {get;set;} = default;

			public bool ShouldSerializeproducerNation() { return !string.IsNullOrEmpty(producerNation); }

			public String? sourceType {get;set;} = default;

			public bool ShouldSerializesourceType() { return !string.IsNullOrEmpty(sourceType); }

			public String? productionAgency {get;set;} = default;

			public bool ShouldSerializeproductionAgency() { return !string.IsNullOrEmpty(productionAgency); }

			public String sourceID {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty {
			[Required()]
			public decimal uncertaintyFixed {get;set;}

			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation {
			[Required()]
			public decimal orientationValue {get;set;}

			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionHeading {
			[Required()]
			public decimal headingDownBearing {get;set;}

			[Required()]
			public decimal headingUpBearing {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class flightLevel {
			[Required()]
			public int minimumFlightLevel {get;set;}

			[Required()]
			public int maximumFlightLevel {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselSpeedLimit {
			[EnumerationValue([2,3,4])]
			[Required()]
			public speedUnits speedUnits {get;set;}

			public String? vesselClass {get;set;} = default;

			public bool ShouldSerializevesselClass() { return !string.IsNullOrEmpty(vesselClass); }

			[Required()]
			public decimal speedLimit {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			public String dateStart {get;set;}

			public String dateEnd {get;set;}

			public String periodicDateEnd {get;set;}

			public String periodicDateStart {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class shapeInformation {
			public String text {get;set;} = string.Empty;

			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class signalSequence {
			[EnumerationValue([1,2])]
			[Required()]
			public signalStatus signalStatus {get;set;}

			[Required()]
			public decimal signalDuration {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorInformation {
			public String text {get;set;} = string.Empty;

			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionalCharacter {
			[Required()]
			public orientation orientation {get;set;}

			public Boolean? moireEffect {get;set;} = default;

			public bool ShouldSerializemoireEffect() { return moireEffect.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo {
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }

			[Required()]
			public decimal sectorBearing {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne {
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }

			[Required()]
			public decimal sectorBearing {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class topmark {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33])]
			[Required()]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public colour? colour {get;set;} = default;

			public bool ShouldSerializecolour() { return colour.HasValue; }

			public List<shapeInformation> shapeInformation {get;set;} = [];

			public bool ShouldSerializeshapeInformation() { return shapeInformation.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rythmOfLight {
			public List<signalSequence> signalSequence {get;set;} = [];

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }

			public decimal? signalPeriod {get;set;} = default;

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			public List<String> signalGroup {get;set;} = [];

			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,25,26,27,28,29])]
			[Required()]
			public lightCharacteristic lightCharacteristic {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalClearanceSafe {
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[Required()]
			public decimal verticalClearanceValue {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimit {
			[Required()]
			public sectorLimitOne sectorLimitOne {get;set;}

			[Required()]
			public sectorLimitTwo sectorLimitTwo {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lightSector {
			public sectorLimit? sectorLimit {get;set;} = default;

			public bool ShouldSerializesectorLimit() { return sectorLimit!=default; }

			public List<sectorInformation> sectorInformation {get;set;} = [];

			public bool ShouldSerializesectorInformation() { return sectorInformation.Any(); }

			[EnumerationValue([1,2,3,4,5,6,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public Boolean? sectorArcExtension {get;set;} = default;

			public bool ShouldSerializesectorArcExtension() { return sectorArcExtension.HasValue; }

			public directionalCharacter? directionalCharacter {get;set;} = default;

			public bool ShouldSerializedirectionalCharacter() { return directionalCharacter!=default; }

			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorCharacteristics {
			public List<signalSequence> signalSequence {get;set;} = [];

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }

			public decimal? signalPeriod {get;set;} = default;

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			public List<lightSector> lightSector {get;set;} = [];

			public bool ShouldSerializelightSector() { return lightSector.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,25,26,27,28,29])]
			[Required()]
			public lightCharacteristic lightCharacteristic {get;set;}

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
			public String? editionDate {get;set;} = default;

			public bool ShouldSerializeeditionDate() { return !string.IsNullOrEmpty(editionDate); }

			public String? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return !string.IsNullOrEmpty(editionNumber); }

			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[EnumerationValue([1,2,18,19])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([1,2,4,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([7,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

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
			[Required()]
			public decimal depthRangeMaximumValue {get;set;}

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[Required()]
			public decimal depthRangeMinimumValue {get;set;}

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
			[EnumerationValue([501])]
			public categoryOfReportingRadioCallingInPoint? categoryOfReportingRadioCallingInPoint {get;set;} = default;

			public bool ShouldSerializecategoryOfReportingRadioCallingInPoint() { return categoryOfReportingRadioCallingInPoint.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<decimal> orientationValue {get;set;} = [];

			public bool ShouldSerializeorientationValue() { return orientationValue.Any(); }

			[EnumerationValue([1,3,4,5,6,7,9,501])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

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
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[EnumerationValue([501,502])]
			[Required()]
			public categoryOfPatrolArea categoryOfPatrolArea {get;set;}

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[EnumerationValue([1,2,5,7,9,12])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

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
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public restriction? restriction {get;set;} = default;

			public bool ShouldSerializerestriction() { return restriction.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[EnumerationValue([501,502,503,504,505,506,507,508,509,510])]
			public List<speciesGrouping> speciesGrouping {get;set;} = [];

			public bool ShouldSerializespeciesGrouping() { return speciesGrouping.Any(); }

			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[EnumerationValue([1,2,2])]
			[Required()]
			public jurisdiction jurisdiction {get;set;}

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7])]
			public categoryofMarineProtectedArea? categoryofMarineProtectedArea {get;set;} = default;

			public bool ShouldSerializecategoryofMarineProtectedArea() { return categoryofMarineProtectedArea.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,13,14,16,17,519])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[EnumerationValue([4,5,6,7,10,20,22,23,27,28,31,32])]
			public List<categoryofRestrictions> categoryofRestrictions {get;set;} = [];

			public bool ShouldSerializecategoryofRestrictions() { return categoryofRestrictions.Any(); }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[Required()]
			public decimal valueOfDepthContour {get;set;}

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

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
			[EnumerationValue([4,5])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,3,4,5,6])]
			public categoryOfRoad? categoryOfRoad {get;set;} = default;

			public bool ShouldSerializecategoryOfRoad() { return categoryOfRoad.HasValue; }

			[EnumerationValue([1,2,5,501])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,4,6,7,8,12,13,14])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

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
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([5])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
			public altitudeRange? altitudeRange {get;set;} = default;

			public bool ShouldSerializealtitudeRange() { return altitudeRange!=default; }

			public String depthRestriction {get;set;} = string.Empty;

			[EnumerationValue([1])]
			public depthUnits? depthUnits {get;set;} = default;

			public bool ShouldSerializedepthUnits() { return depthUnits.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,516,517,518,519,520,521,522,523,524,525,526,527,528,529,530,531,532,533,534,535,536,537,538,539,540,541,542,543,544,545,546,547,598,599])]
			public List<typeofMilitaryActivity> typeofMilitaryActivity {get;set;} = [];

			public bool ShouldSerializetypeofMilitaryActivity() { return typeofMilitaryActivity.Any(); }

			public String? activePeriod {get;set;} = default;

			public bool ShouldSerializeactivePeriod() { return !string.IsNullOrEmpty(activePeriod); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public int? minimumSafeDepth {get;set;} = default;

			public bool ShouldSerializeminimumSafeDepth() { return minimumSafeDepth.HasValue; }

			[EnumerationValue([2,3,4,5,501,502,503,506,507,508,510,599])]
			public List<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea {get;set;} = [];

			public bool ShouldSerializecategoryofMilitaryPracticeArea() { return categoryofMilitaryPracticeArea.Any(); }

			public int? bottomVerticalSafetySeparation {get;set;} = default;

			public bool ShouldSerializebottomVerticalSafetySeparation() { return bottomVerticalSafetySeparation.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[EnumerationValue([501,502])]
			public areaCategory? areaCategory {get;set;} = default;

			public bool ShouldSerializeareaCategory() { return areaCategory.HasValue; }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44,501])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,5,6,7,16,17,501,503,517,520])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

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
			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public frequencyPair? frequencyPair {get;set;} = default;

			public bool ShouldSerializefrequencyPair() { return frequencyPair!=default; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? callsign {get;set;} = default;

			public bool ShouldSerializecallsign() { return !string.IsNullOrEmpty(callsign); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? communicationChannel {get;set;} = default;

			public bool ShouldSerializecommunicationChannel() { return !string.IsNullOrEmpty(communicationChannel); }

			[EnumerationValue([1,2,4,5,7,8])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([5,10,11,14,19,20])]
			public List<categoryOfRadioStation> categoryOfRadioStation {get;set;} = [];

			public bool ShouldSerializecategoryOfRadioStation() { return categoryOfRadioStation.Any(); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public decimal? estimatedRangeofTransmission {get;set;} = default;

			public bool ShouldSerializeestimatedRangeofTransmission() { return estimatedRangeofTransmission.HasValue; }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			public String? activePeriod {get;set;} = default;

			public bool ShouldSerializeactivePeriod() { return !string.IsNullOrEmpty(activePeriod); }

			public altitude? altitude {get;set;} = default;

			public bool ShouldSerializealtitude() { return altitude!=default; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

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
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([502,504,520])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public String nationality {get;set;} = string.Empty;

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,7,13])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,16,17,18,20,23,24,25,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

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
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public Boolean? lineTypeGeodesic {get;set;} = default;

			public bool ShouldSerializelineTypeGeodesic() { return lineTypeGeodesic.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			[EnumerationValue([1,2,3])]
			[Required()]
			public jurisdiction jurisdiction {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

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
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

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
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfDolphin categoryOfDolphin {get;set;}

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,12,14,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

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
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,3,4,5,6,7])]
			[Required()]
			public beaconShape beaconShape {get;set;}

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			public int? bottomVerticalSafetySeparation {get;set;} = default;

			public bool ShouldSerializebottomVerticalSafetySeparation() { return bottomVerticalSafetySeparation.HasValue; }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public int? minimumSafeDepth {get;set;} = default;

			public bool ShouldSerializeminimumSafeDepth() { return minimumSafeDepth.HasValue; }

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
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public flightLevel? flightLevel {get;set;} = default;

			public bool ShouldSerializeflightLevel() { return flightLevel!=default; }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			public altitudeRange? altitudeRange {get;set;} = default;

			public bool ShouldSerializealtitudeRange() { return altitudeRange!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

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
			[EnumerationValue([18])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,3,4,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

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
			[EnumerationValue([2,3,4,5,6])]
			public List<categoryOfDumpingGround> categoryOfDumpingGround {get;set;} = [];

			public bool ShouldSerializecategoryOfDumpingGround() { return categoryOfDumpingGround.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[EnumerationValue([1,2,4,6,7])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? dateDisused {get;set;} = default;

			public bool ShouldSerializedateDisused() { return !string.IsNullOrEmpty(dateDisused); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

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
			[EnumerationValue([1,2,3,4,5,6,8,9])]
			public List<categoryOfAirportAirfield> categoryOfAirportAirfield {get;set;} = [];

			public bool ShouldSerializecategoryOfAirportAirfield() { return categoryOfAirportAirfield.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public int? runwayLength {get;set;} = default;

			public bool ShouldSerializerunwayLength() { return runwayLength.HasValue; }

			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public String? iCAOcode {get;set;} = default;

			public bool ShouldSerializeiCAOcode() { return !string.IsNullOrEmpty(iCAOcode); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,4,5,6,7,8,12,14])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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
			[EnumerationValue([13,18,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

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
			public String pictorialRepresentation {get;set;} = string.Empty;

			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public rythmOfLight? rythmOfLight {get;set;} = default;

			public bool ShouldSerializerythmOfLight() { return rythmOfLight!=default; }

			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public int? flareBearing {get;set;} = default;

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public decimal? relativeHorizontalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeHorizontalAccuracy() { return relativeHorizontalAccuracy.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public decimal? relativeVerticalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeVerticalAccuracy() { return relativeVerticalAccuracy.HasValue; }

			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			public decimal? maximumPermittedVesselLength {get;set;} = default;

			public bool ShouldSerializemaximumPermittedVesselLength() { return maximumPermittedVesselLength.HasValue; }

			public decimal? maximumPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[EnumerationValue([1,2,4,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public Boolean? visitorsMooring {get;set;} = default;

			public bool ShouldSerializevisitorsMooring() { return visitorsMooring.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			[Required()]
			public decimal valueOfSounding {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[EnumerationValue([3,4,5])]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public decimal? surroundingDepth {get;set;} = default;

			public bool ShouldSerializesurroundingDepth() { return surroundingDepth.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([14,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[EnumerationValue([1,2])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

			[EnumerationValue([18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public firstSourceInformation? firstSourceInformation {get;set;} = default;

			public bool ShouldSerializefirstSourceInformation() { return firstSourceInformation!=default; }

			public lastSourceInformation? lastSourceInformation {get;set;} = default;

			public bool ShouldSerializelastSourceInformation() { return lastSourceInformation!=default; }

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
			[EnumerationValue([1,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[EnumerationValue([1,4,5,7,12,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[EnumerationValue([1,3])]
			public categoryOfCable? categoryOfCable {get;set;} = default;

			public bool ShouldSerializecategoryOfCable() { return categoryOfCable.HasValue; }

			public verticalClearanceSafe? verticalClearanceSafe {get;set;} = default;

			public bool ShouldSerializeverticalClearanceSafe() { return verticalClearanceSafe!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			public bool ShouldSerializeverticalClearanceFixed() { return verticalClearanceFixed!=default; }

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

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
			[EnumerationValue([501,502,503,504,505,506,507])]
			public controlledAirspaceClassDesignation? controlledAirspaceClassDesignation {get;set;} = default;

			public bool ShouldSerializecontrolledAirspaceClassDesignation() { return controlledAirspaceClassDesignation.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,516,517,518,519,520,521,522])]
			public categoryOfControlledAirspace? categoryOfControlledAirspace {get;set;} = default;

			public bool ShouldSerializecategoryOfControlledAirspace() { return categoryOfControlledAirspace.HasValue; }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			public altitude? altitude {get;set;} = default;

			public bool ShouldSerializealtitude() { return altitude!=default; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[EnumerationValue([2])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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
			[EnumerationValue([1,2,3,4,5,6,7,8,11,12])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,502,503,505,506,507,508,509,510,511,513,514,515,516,517,519,520,521,522,523,524,525,526,527,528,529,530,531,532,533,534,535,536,537,540,541,542])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			public Boolean? existenceOfRestrictedArea {get;set;} = default;

			public bool ShouldSerializeexistenceOfRestrictedArea() { return existenceOfRestrictedArea.HasValue; }

			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			public lastSourceInformation? lastSourceInformation {get;set;} = default;

			public bool ShouldSerializelastSourceInformation() { return lastSourceInformation!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([1,2,3])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

			public firstSourceInformation? firstSourceInformation {get;set;} = default;

			public bool ShouldSerializefirstSourceInformation() { return firstSourceInformation!=default; }

			public String? abandonmentDate {get;set;} = default;

			public bool ShouldSerializeabandonmentDate() { return !string.IsNullOrEmpty(abandonmentDate); }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public decimal? soundingDepth {get;set;} = default;

			public bool ShouldSerializesoundingDepth() { return soundingDepth.HasValue; }

			public orientation? orientation {get;set;} = default;

			public bool ShouldSerializeorientation() { return orientation!=default; }

			[EnumerationValue([501,502,503,504,505,506,507,508,509,510,511,512,513,514,515,519,522,523,524,525,526,527,531,532])]
			public soundingDatum? soundingDatum {get;set;} = default;

			public bool ShouldSerializesoundingDatum() { return soundingDatum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public magneticInformation? magneticInformation {get;set;} = default;

			public bool ShouldSerializemagneticInformation() { return magneticInformation!=default; }

			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[EnumerationValue([1,4,5,7,8,13,18,28,501,503,505,506,507,508,509,510,511,512,516,517,518])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public int? generalWaterDepth {get;set;} = default;

			public bool ShouldSerializegeneralWaterDepth() { return generalWaterDepth.HasValue; }

			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			public detectionDateRange? detectionDateRange {get;set;} = default;

			public bool ShouldSerializedetectionDateRange() { return detectionDateRange!=default; }

			public String? oprtor {get;set;} = default;

			public bool ShouldSerializeoprtor() { return !string.IsNullOrEmpty(oprtor); }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44,501])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[EnumerationValue([501,502,503,504])]
			public sonarSignalStrength? sonarSignalStrength {get;set;} = default;

			public bool ShouldSerializesonarSignalStrength() { return sonarSignalStrength.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public decimal? maximumPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.Any(); }

			public String? spuddedDate {get;set;} = default;

			public bool ShouldSerializespuddedDate() { return !string.IsNullOrEmpty(spuddedDate); }

			[EnumerationValue([1,2,3,4,5,6,8,9,10,12,13,14,15,16,17,18,19,20,21,22,23,501,502,503,504,506,508,509])]
			public categoryOfObstruction? categoryOfObstruction {get;set;} = default;

			public bool ShouldSerializecategoryOfObstruction() { return categoryOfObstruction.HasValue; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public String? dateSunk {get;set;} = default;

			public bool ShouldSerializedateSunk() { return !string.IsNullOrEmpty(dateSunk); }

			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? currentScourDimensions {get;set;} = default;

			public bool ShouldSerializecurrentScourDimensions() { return !string.IsNullOrEmpty(currentScourDimensions); }

			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([501,502,503,504])]
			public cardinalPointOrientation? cardinalPointOrientation {get;set;} = default;

			public bool ShouldSerializecardinalPointOrientation() { return cardinalPointOrientation.HasValue; }

			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[EnumerationValue([1,2,3,4,5,7])]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public String? nation {get;set;} = default;

			public bool ShouldSerializenation() { return !string.IsNullOrEmpty(nation); }

			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

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
			[EnumerationValue([1,5,6,7,8,14,16,17,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,4,5,6,8,9,10,11,12,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,4,5,6,7,8,12,18,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,3,4])]
			public categoryOfFishingFacility? categoryOfFishingFacility {get;set;} = default;

			public bool ShouldSerializecategoryOfFishingFacility() { return categoryOfFishingFacility.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

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
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20,504,505,506,508,509,510])]
			public categoryOfRadioStation? categoryOfRadioStation {get;set;} = default;

			public bool ShouldSerializecategoryOfRadioStation() { return categoryOfRadioStation.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public String? callsign {get;set;} = default;

			public bool ShouldSerializecallsign() { return !string.IsNullOrEmpty(callsign); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? communicationChannel {get;set;} = default;

			public bool ShouldSerializecommunicationChannel() { return !string.IsNullOrEmpty(communicationChannel); }

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
			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public decimal? orientationValue {get;set;} = default;

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

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
			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([502,504,520])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([2,4,6,8,9,10,12,17,18,19,20,21,22,23,24,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

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
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7])]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

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
			[EnumerationValue([1,4,5,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public Boolean? isMRCC {get;set;} = default;

			public bool ShouldSerializeisMRCC() { return isMRCC.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

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
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,3,9,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? migrationDirection {get;set;} = default;

			public bool ShouldSerializemigrationDirection() { return migrationDirection.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[EnumerationValue([502,510])]
			public bottomFeatureClassification? bottomFeatureClassification {get;set;} = default;

			public bool ShouldSerializebottomFeatureClassification() { return bottomFeatureClassification.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			public String nationality {get;set;} = string.Empty;

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

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
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[EnumerationValue([504])]
			public statusOfSmallBottomObject? statusOfSmallBottomObject {get;set;} = default;

			public bool ShouldSerializestatusOfSmallBottomObject() { return statusOfSmallBottomObject.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[Required()]
			public decimal valueOfSounding {get;set;}

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
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

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
			[EnumerationValue([1,2,4,7,8])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2])]
			public categoryOfRadarStation? categoryOfRadarStation {get;set;} = default;

			public bool ShouldSerializecategoryOfRadarStation() { return categoryOfRadarStation.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? callsign {get;set;} = default;

			public bool ShouldSerializecallsign() { return !string.IsNullOrEmpty(callsign); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

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
			public decimal? waterClarity {get;set;} = default;

			public bool ShouldSerializewaterClarity() { return waterClarity.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,18,19,20,21,22,23,24,25,27,28,29,30,31,32,501])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[EnumerationValue([1,2,3,4,5,6,7,9,18,28,501])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? controllingAuthority {get;set;} = default;

			public bool ShouldSerializecontrollingAuthority() { return !string.IsNullOrEmpty(controllingAuthority); }

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
			[EnumerationValue([1,4,13,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public bool ShouldSerializedepthRangeMinimumValue() { return depthRangeMinimumValue.HasValue; }

			public decimal? buriedDepth {get;set;} = default;

			public bool ShouldSerializeburiedDepth() { return buriedDepth.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,6,7,9,10])]
			public categoryOfCable? categoryOfCable {get;set;} = default;

			public bool ShouldSerializecategoryOfCable() { return categoryOfCable.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

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
			public decimal? surroundingDepth {get;set;} = default;

			public bool ShouldSerializesurroundingDepth() { return surroundingDepth.HasValue; }

			[EnumerationValue([1,2,3,4,5,8,9,10,11,12,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public String? currentScourDimensions {get;set;} = default;

			public bool ShouldSerializecurrentScourDimensions() { return !string.IsNullOrEmpty(currentScourDimensions); }

			[EnumerationValue([7,13,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([501,502,503,504])]
			public sonarSignalStrength? sonarSignalStrength {get;set;} = default;

			public bool ShouldSerializesonarSignalStrength() { return sonarSignalStrength.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public magneticInformation? magneticInformation {get;set;} = default;

			public bool ShouldSerializemagneticInformation() { return magneticInformation!=default; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[EnumerationValue([6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public decimal? defaultClearanceDepth {get;set;} = default;

			public bool ShouldSerializedefaultClearanceDepth() { return defaultClearanceDepth.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17,18])]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.HasValue; }

			public decimal? orientationValue {get;set;} = default;

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			public String? typeOfWreck {get;set;} = default;

			public bool ShouldSerializetypeOfWreck() { return !string.IsNullOrEmpty(typeOfWreck); }

			[EnumerationValue([1,2,3,4,5])]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,2,3,4,5])]
			public categoryOfWreck? categoryOfWreck {get;set;} = default;

			public bool ShouldSerializecategoryOfWreck() { return categoryOfWreck.HasValue; }

			[EnumerationValue([4,5])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? debrisField {get;set;} = default;

			public bool ShouldSerializedebrisField() { return !string.IsNullOrEmpty(debrisField); }

			public List<String> nationality {get;set;} = [];

			public bool ShouldSerializenationality() { return nationality.Any(); }

			public lastSourceInformation? lastSourceInformation {get;set;} = default;

			public bool ShouldSerializelastSourceInformation() { return lastSourceInformation!=default; }

			[EnumerationValue([1,2,3,4,6,7,8,9])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[EnumerationValue([501,502,503,504])]
			public cardinalPointOrientation? cardinalPointOrientation {get;set;} = default;

			public bool ShouldSerializecardinalPointOrientation() { return cardinalPointOrientation.HasValue; }

			public List<vesselMeasurementsSpecification> vesselMeasurementsSpecification {get;set;} = [];

			public bool ShouldSerializevesselMeasurementsSpecification() { return vesselMeasurementsSpecification.Any(); }

			public Boolean? existenceOfRestrictedArea {get;set;} = default;

			public bool ShouldSerializeexistenceOfRestrictedArea() { return existenceOfRestrictedArea.HasValue; }

			public String? dateSunk {get;set;} = default;

			public bool ShouldSerializedateSunk() { return !string.IsNullOrEmpty(dateSunk); }

			public firstSourceInformation? firstSourceInformation {get;set;} = default;

			public bool ShouldSerializefirstSourceInformation() { return firstSourceInformation!=default; }

			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			public decimal? valueOfSounding {get;set;} = default;

			public bool ShouldSerializevalueOfSounding() { return valueOfSounding.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public Boolean? displayUncertainties {get;set;} = default;

			public bool ShouldSerializedisplayUncertainties() { return displayUncertainties.HasValue; }

			[EnumerationValue([1,2,3])]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public bool ShouldSerializeexpositionOfSounding() { return expositionOfSounding.HasValue; }

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
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([2,503])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public qRouteChannelWidth? qRouteChannelWidth {get;set;} = default;

			public bool ShouldSerializeqRouteChannelWidth() { return qRouteChannelWidth!=default; }

			public directionHeading? directionHeading {get;set;} = default;

			public bool ShouldSerializedirectionHeading() { return directionHeading!=default; }

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
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[EnumerationValue([501,502])]
			[Required()]
			public categoryOfCompleteness categoryOfCompleteness {get;set;}

			public String? copyrightStatement {get;set;} = default;

			public bool ShouldSerializecopyrightStatement() { return !string.IsNullOrEmpty(copyrightStatement); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

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
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,2,4,5,6,7,8])]
			public List<categoryOfRescueStation> categoryOfRescueStation {get;set;} = [];

			public bool ShouldSerializecategoryOfRescueStation() { return categoryOfRescueStation.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[EnumerationValue([1,2,3,5,6,7])]
			[Required()]
			public beaconShape beaconShape {get;set;}

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

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
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([6,7])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

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
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String nationality {get;set;} = string.Empty;

			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			public List<String> species {get;set;} = [];

			public bool ShouldSerializespecies() { return species.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

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
			public decimal? maximumPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public String? dredgedDate {get;set;} = default;

			public bool ShouldSerializedredgedDate() { return !string.IsNullOrEmpty(dredgedDate); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public decimal? depthRangeMaximumValue {get;set;} = default;

			public bool ShouldSerializedepthRangeMaximumValue() { return depthRangeMaximumValue.HasValue; }

			[EnumerationValue([10,11])]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.HasValue; }

			[EnumerationValue([1,2,3,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[Required()]
			public decimal depthRangeMinimumValue {get;set;}

			[EnumerationValue([1,2,3,4,5,6,8,11,12,13,16,17,18,19,20,21,23,25,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

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
			[EnumerationValue([1,2,4,5,6,7,8,9,14])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,3,5])]
			public List<categoryOfFerry> categoryOfFerry {get;set;} = [];

			public bool ShouldSerializecategoryOfFerry() { return categoryOfFerry.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[EnumerationValue([501,502,503,504,505])]
			public gradientOfSlope? gradientOfSlope {get;set;} = default;

			public bool ShouldSerializegradientOfSlope() { return gradientOfSlope.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public bool ShouldSerializehorizontalClearanceFixed() { return horizontalClearanceFixed!=default; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,3,4,6,7,8,12,13,14,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7])]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,20,22,23,501])]
			public categoryOfShorelineConstruction? categoryOfShorelineConstruction {get;set;} = default;

			public bool ShouldSerializecategoryOfShorelineConstruction() { return categoryOfShorelineConstruction.HasValue; }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

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
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([5,7])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			[EnumerationValue([1,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

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
			public Boolean? imoAdopted {get;set;} = default;

			public bool ShouldSerializeimoAdopted() { return imoAdopted.HasValue; }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[Required()]
			public decimal depthRangeMinimumValue {get;set;}

			[EnumerationValue([1,3,5,8,9,13,15,16,17,18])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,3,6,9,28])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[Required()]
			public decimal orientationValue {get;set;}

			[EnumerationValue([1,2,3,4,5,6,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,27])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

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
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[Required()]
			public orientation orientation {get;set;}

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[Required()]
			public speed speed {get;set;}

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
			public int? drawingIndex {get;set;} = default;

			public bool ShouldSerializedrawingIndex() { return drawingIndex.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,2])]
			public categoryOfCoverage? categoryOfCoverage {get;set;} = default;

			public bool ShouldSerializecategoryOfCoverage() { return categoryOfCoverage.HasValue; }

			[Required()]
			public int optimumDisplayScale {get;set;}

			[Required()]
			public int minimumDisplayScale {get;set;}

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[Required()]
			public int maximumDisplayScale {get;set;}

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([3,4,5])]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public List<surfaceCharacteristics> surfaceCharacteristics {get;set;} = [];

			public bool ShouldSerializesurfaceCharacteristics() { return surfaceCharacteristics.Any(); }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,42,43,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,5,7,8,18,503])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public List<fixedDateRange> fixedDateRange {get;set;} = [];

			public bool ShouldSerializefixedDateRange() { return fixedDateRange.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public decimal? relativeHorizontalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeHorizontalAccuracy() { return relativeHorizontalAccuracy.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public decimal? relativeVerticalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeVerticalAccuracy() { return relativeVerticalAccuracy.HasValue; }

			[EnumerationValue([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[EnumerationValue([1,2,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String pictorialRepresentation {get;set;} = string.Empty;

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];

			public bool ShouldSerializesectorCharacteristics() { return sectorCharacteristics.Any(); }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[EnumerationValue([5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			[EnumerationValue([2,3,4,5,6,8,9,10,11,12,13,15,16,17,18,19,20,21,23,24,27,39])]
			public List<restriction> restriction {get;set;} = [];

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public periodicDateRange? periodicDateRange {get;set;} = default;

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,3,5,6,7,9,10,14,15])]
			public List<categoryOfAnchorage> categoryOfAnchorage {get;set;} = [];

			public bool ShouldSerializecategoryOfAnchorage() { return categoryOfAnchorage.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([1,2,3,5,6,7,8,9,14])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,5,7,8,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([6,7,8,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

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
			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public bool ShouldSerializevesselSpeedLimit() { return vesselSpeedLimit.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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
			[EnumerationValue([1,2,3,4,6,7])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[Required()]
			public decimal orientationValue {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([1,3,6,9])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public Boolean? imoAdopted {get;set;} = default;

			public bool ShouldSerializeimoAdopted() { return imoAdopted.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public bool ShouldSerializedepthRangeMinimumValue() { return depthRangeMinimumValue.HasValue; }

			[Required()]
			public Boolean basedOnFixedMarks {get;set;} = false;

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
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([6,7,11])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

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
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[EnumerationValue([5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,2,4,5,6,7,8,11,14,15,16,17])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[Required()]
			public multiplicityOfFeatures multiplicityOfFeatures {get;set;}

			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			public decimal? relativeHorizontalAccuracy {get;set;} = default;

			public bool ShouldSerializerelativeHorizontalAccuracy() { return relativeHorizontalAccuracy.HasValue; }

			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public Boolean? majorLight {get;set;} = default;

			public bool ShouldSerializemajorLight() { return majorLight.HasValue; }

			[EnumerationValue([1,2])]
			public lightVisibility? lightVisibility {get;set;} = default;

			public bool ShouldSerializelightVisibility() { return lightVisibility.HasValue; }

			public int? flareBearing {get;set;} = default;

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

			[EnumerationValue([1])]
			public heightLengthUnits? heightLengthUnits {get;set;} = default;

			public bool ShouldSerializeheightLengthUnits() { return heightLengthUnits.HasValue; }

			[EnumerationValue([4,5,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[Required()]
			public rythmOfLight rythmOfLight {get;set;}

			[EnumerationValue([1,3,4,5,6,9,10,11])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

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
			[EnumerationValue([1,2,3,4,6,7,8,11,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,6,7,8,10])]
			public categoryOfCoastline? categoryOfCoastline {get;set;} = default;

			public bool ShouldSerializecategoryOfCoastline() { return categoryOfCoastline.HasValue; }

			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,14,17])]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			public bool ShouldSerializenatureOfSurface() { return natureOfSurface.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56])]
			public categoryOfSeaArea? categoryOfSeaArea {get;set;} = default;

			public bool ShouldSerializecategoryOfSeaArea() { return categoryOfSeaArea.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([501,502,503,504,505])]
			public gradient? gradient {get;set;} = default;

			public bool ShouldSerializegradient() { return gradient.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

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
			[EnumerationValue([1,2,3,4])]
			public categoryOfConveyor? categoryOfConveyor {get;set;} = default;

			public bool ShouldSerializecategoryOfConveyor() { return categoryOfConveyor.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			[EnumerationValue([4,12])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public decimal? liftingCapacity {get;set;} = default;

			public bool ShouldSerializeliftingCapacity() { return liftingCapacity.HasValue; }

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			public bool ShouldSerializeverticalClearanceFixed() { return verticalClearanceFixed!=default; }

			[EnumerationValue([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[EnumerationValue([4,5,6,10,11,12,13,14,15,16,17,22,25])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

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
			public List<String> nationalMaritimeAuthority {get;set;} = [];

			public bool ShouldSerializenationalMaritimeAuthority() { return nationalMaritimeAuthority.Any(); }

			[EnumerationValue([501,502,504,599])]
			public boundaryStatusType? boundaryStatusType {get;set;} = default;

			public bool ShouldSerializeboundaryStatusType() { return boundaryStatusType.HasValue; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			[EnumerationValue([1,2,3])]
			public jurisdiction? jurisdiction {get;set;} = default;

			public bool ShouldSerializejurisdiction() { return jurisdiction.HasValue; }

			[EnumerationValue([501,506,511,599])]
			public categoryofBoundaryLine? categoryofBoundaryLine {get;set;} = default;

			public bool ShouldSerializecategoryofBoundaryLine() { return categoryofBoundaryLine.HasValue; }

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
			public String nationality {get;set;} = string.Empty;

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([502,504])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

			public Boolean? inDispute {get;set;} = default;

			public bool ShouldSerializeinDispute() { return inDispute.HasValue; }

			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7])]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue([1,2,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

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
			public sourceIdentification? sourceIdentification {get;set;} = default;

			public bool ShouldSerializesourceIdentification() { return sourceIdentification!=default; }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[EnumerationValue([1,2,4,5,7,8,12,18])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[EnumerationValue([1,2,6,7,8])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[EnumerationValue([1,2,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[EnumerationValue([1,2,3,4,5,6])]
			public colourPattern? colourPattern {get;set;} = default;

			public bool ShouldSerializecolourPattern() { return colourPattern.HasValue; }

			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[EnumerationValue([1,2,3,4,5,6,7])]
			[Required()]
			public beaconShape beaconShape {get;set;}

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public topmark? topmark {get;set;} = default;

			public bool ShouldSerializetopmark() { return topmark!=default; }

			[EnumerationValue([1,2,3,4,5,6,7,8,10,11,12,14,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,60,61,62,63])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

			[EnumerationValue([1,2,9,11])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

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
