using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable enable
namespace S100Framework.DomainModel.S501 {
    public static class Information {
        public static Version Version => new Version("0.0.5");
        public static string[] ComplexTypes => ["qRouteChannelWidth", "detectionDateRange", "multiplicityOfFeatures", "onlineResource", "featureName", "fixedDateRange", "altitudeRange", "altitude", "lastSourceInformation", "information", "firstSourceInformation", "horizontalClearanceFixed", "verticalUncertainty", "frequencyPair", "vesselMeasurementsSpecification", "surfaceCharacteristics", "magneticInformation", "speed", "verticalClearanceFixed", "sourceIdentification", "horizontalPositionUncertainty", "orientation", "directionHeading", "flightLevel", "vesselSpeedLimit", "periodicDateRange", "shapeInformation", "signalSequence", "sectorInformation", "directionalCharacter", "sectorLimitTwo", "sectorLimitOne", "topmark", "rythmOfLight", "verticalClearanceSafe", "sectorLimit", "lightSector", "sectorCharacteristics",];
        public static string[] SpatialAssociationTypes => [];
        public static string[] InformationAssociationTypes => [];
        public static string[] FeatureAssociationTypes => [];
        public static string[] InformationTypes => ["ReferenceToAPublication",];
        public static string[] FeatureTypes => ["InstallationBuoy", "DepthArea", "RadioCallingInPoint", "PatrolArea", "Checkpoint", "MarineManagementArea", "DepthContour", "EnvironmentallySensitiveSeaArea", "Road", "River", "MilitaryPracticeArea", "DiscolouredWater", "CardinalBuoy", "SafeWaterBuoy", "RadioStation", "MilitaryExerciseAirspace", "ContiguousZone", "NormalBaseline", "CableArea", "ContinentalShelfArea", "InternalWaters", "AdministrationArea", "Bollard", "Dolphin", "RadarRange", "IsolatedDangerBeacon", "IsolatedDangerBuoy", "SubmarineTransitLane", "MaritimeSafetyInformationArea", "AirspaceRestriction", "Sounding", "TrafficSeparationSchemeBoundary", "DumpingGround", "AirportAirfield", "FoulGround", "LightAirObstruction", "MooringBuoy", "UnderwaterAwashRock", "CableOverhead", "ControlledAirspace", "Obstruction", "FishingGround", "FishingFacility", "NavigationSystem", "TrafficSeparationSchemeCrossing", "TrafficSeparationSchemeLanePart", "TerritorialSeaArea", "LateralBeacon", "CoastGuardStation", "SeparationZoneOrLine", "BottomFeature", "ArchipelagicBaseline", "SmallBottomObject", "ExclusiveEconomicZone", "RadarStation", "DivingLocation", "RestrictedArea", "CableSubmarine", "Wreck", "QRoute", "CompletenessOfProductSpecification", "RescueStation", "CardinalBeacon", "LightVessel", "FisheryZone", "DredgedArea", "FerryRoute", "ShorelineConstruction", "CautionArea", "DeepWaterRoutePart", "CurrentNonGravitational", "DataCoverage", "SeabedArea", "SpecialPurposeGeneralBuoy", "LightSectored", "IceLine", "AnchorageArea", "LateralBuoy", "TrafficSeparationSchemeRoundabout", "DeepWaterRouteCentreline", "LightFloat", "LightAllAround", "Coastline", "SeaAreaNamedWaterArea", "DropZone", "Conveyor", "LineOfDelimitation", "StraightTerritorialSeaBaseline", "SafeWaterBeacon", "SpecialPurposeGeneralBeacon",];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum visualProminence : int {
        [System.ComponentModel.Description("Term applied to an object either natural or artificial which is distinctly and notably visible from seaward.")]
        [EnumMember(Value = "Visually Conspicuous")]
        VisuallyConspicuous = 1,
        [System.ComponentModel.Description("An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.")]
        [EnumMember(Value = "Not Visually Conspicuous")]
        NotVisuallyConspicuous = 2,
        [System.ComponentModel.Description("Objects which are easily identifiable, but do not justify being classed as conspicuous.")]
        [EnumMember(Value = "Prominent")]
        Prominent = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum gradientOfSlope : int {
        [System.ComponentModel.Description("501:Steep (missing definition)")]
        [EnumMember(Value = "Steep")]
        Steep = 501,
        [System.ComponentModel.Description("502:Moderate (missing definition)")]
        [EnumMember(Value = "Moderate")]
        Moderate = 502,
        [System.ComponentModel.Description("503:Gentle (missing definition)")]
        [EnumMember(Value = "Gentle")]
        Gentle = 503,
        [System.ComponentModel.Description("504:Mild (missing definition)")]
        [EnumMember(Value = "Mild")]
        Mild = 504,
        [System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
        [EnumMember(Value = "Flat")]
        Flat = 505,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum typeofMilitaryActivity : int {
        [System.ComponentModel.Description("501:Anti Aircraft (ground to air) (missing definition)")]
        [EnumMember(Value = "Anti Aircraft (ground to air)")]
        AntiAircraftGroundToAir = 501,
        [System.ComponentModel.Description("502:High and Low angle gunnery (ground to ground) (missing definition)")]
        [EnumMember(Value = "High and Low angle gunnery (ground to ground)")]
        HighAndLowAngleGunneryGroundToGround = 502,
        [System.ComponentModel.Description("503:Air to Air Firing (missing definition)")]
        [EnumMember(Value = "Air to Air Firing")]
        AirToAirFiring = 503,
        [System.ComponentModel.Description("504:Air Combat Training (missing definition)")]
        [EnumMember(Value = "Air Combat Training")]
        AirCombatTraining = 504,
        [System.ComponentModel.Description("505:Air Dropped Torpedo (missing definition)")]
        [EnumMember(Value = "Air Dropped Torpedo")]
        AirDroppedTorpedo = 505,
        [System.ComponentModel.Description("506:Aircraft General (missing definition)")]
        [EnumMember(Value = "Aircraft General")]
        AircraftGeneral = 506,
        [System.ComponentModel.Description("507:Air to Surface Firing (missing definition)")]
        [EnumMember(Value = "Air to Surface Firing")]
        AirToSurfaceFiring = 507,
        [System.ComponentModel.Description("508:Anti Submarine Warfare Exercises (missing definition)")]
        [EnumMember(Value = "Anti Submarine Warfare Exercises")]
        AntiSubmarineWarfareExercises = 508,
        [System.ComponentModel.Description("509:Acoustic Trials (missing definition)")]
        [EnumMember(Value = "Acoustic Trials")]
        AcousticTrials = 509,
        [System.ComponentModel.Description("510:Air Tactical Training (missing definition)")]
        [EnumMember(Value = "Air Tactical Training")]
        AirTacticalTraining = 510,
        [System.ComponentModel.Description("511:Bombing (missing definition)")]
        [EnumMember(Value = "Bombing")]
        Bombing = 511,
        [System.ComponentModel.Description("512:Depth Charge dropping/firing (including rocket/mortar fired DC) (missing definition)")]
        [EnumMember(Value = "Depth Charge dropping/firing (including rocket/mortar fired DC)")]
        DepthChargeDroppingFiringIncludingRocketMortarFiredDc = 512,
        [System.ComponentModel.Description("Neutralization of the strength of the magnetic field of a vessel, by means of suitably arranged electric coils permanently installed in the vessel. See also Degaussing Cable.")]
        [EnumMember(Value = "Degaussing")]
        Degaussing = 513,
        [System.ComponentModel.Description("514:Demolition of unexploded ordnance (missing definition)")]
        [EnumMember(Value = "Demolition of unexploded ordnance")]
        DemolitionOfUnexplodedOrdnance = 514,
        [System.ComponentModel.Description("515:Explosives Trials (missing definition)")]
        [EnumMember(Value = "Explosives Trials")]
        ExplosivesTrials = 515,
        [System.ComponentModel.Description("516:Firing (missing definition)")]
        [EnumMember(Value = "Firing")]
        Firing = 516,
        [System.ComponentModel.Description("517:Flares (missing definition)")]
        [EnumMember(Value = "Flares")]
        Flares = 517,
        [System.ComponentModel.Description("518:Glow Worm (missing definition)")]
        [EnumMember(Value = "Glow Worm")]
        GlowWorm = 518,
        [System.ComponentModel.Description("519:General Practice (missing definition)")]
        [EnumMember(Value = "General Practice")]
        GeneralPractice = 519,
        [System.ComponentModel.Description("520:Guided Weapons (air Flight) (missing definition)")]
        [EnumMember(Value = "Guided Weapons (air Flight)")]
        GuidedWeaponsAirFlight = 520,
        [System.ComponentModel.Description("521:Helicopter exercises (missing definition)")]
        [EnumMember(Value = "Helicopter exercises")]
        HelicopterExercises = 521,
        [System.ComponentModel.Description("522:High Energy Manouvres (missing definition)")]
        [EnumMember(Value = "High Energy Manouvres")]
        HighEnergyManouvres = 522,
        [System.ComponentModel.Description("523:HM Ships (non-firing exercises, practices and trials) (missing definition)")]
        [EnumMember(Value = "HM Ships (non-firing exercises, practices and trials)")]
        HmShipsNonFiringExercisesPracticesAndTrials = 523,
        [System.ComponentModel.Description("524:Live ASW firing (missing definition)")]
        [EnumMember(Value = "Live ASW firing")]
        LiveAswFiring = 524,
        [System.ComponentModel.Description("525:Mine Counter Measures (missing definition)")]
        [EnumMember(Value = "Mine Counter Measures")]
        MineCounterMeasures = 525,
        [System.ComponentModel.Description("526:Mine Disposal (missing definition)")]
        [EnumMember(Value = "Mine Disposal")]
        MineDisposal = 526,
        [System.ComponentModel.Description("527:Missile Firing (missing definition)")]
        [EnumMember(Value = "Missile Firing")]
        MissileFiring = 527,
        [System.ComponentModel.Description("528:Mortar Firing (missing definition)")]
        [EnumMember(Value = "Mortar Firing")]
        MortarFiring = 528,
        [System.ComponentModel.Description("529:Naval Gunfire Support (missing definition)")]
        [EnumMember(Value = "Naval Gunfire Support")]
        NavalGunfireSupport = 529,
        [System.ComponentModel.Description("530:Noise Ranging (missing definition)")]
        [EnumMember(Value = "Noise Ranging")]
        NoiseRanging = 530,
        [System.ComponentModel.Description("531:Parachute Dropping (missing definition)")]
        [EnumMember(Value = "Parachute Dropping")]
        ParachuteDropping = 531,
        [System.ComponentModel.Description("532:Pilotless Target Aircraft (missing definition)")]
        [EnumMember(Value = "Pilotless Target Aircraft")]
        PilotlessTargetAircraft = 532,
        [System.ComponentModel.Description("533:Radar Training Buoy (missing definition)")]
        [EnumMember(Value = "Radar Training Buoy")]
        RadarTrainingBuoy = 533,
        [System.ComponentModel.Description("534:Submarine Exercises (missing definition)")]
        [EnumMember(Value = "Submarine Exercises")]
        SubmarineExercises = 534,
        [System.ComponentModel.Description("Suspension in the atmosphere of small particles produced by combustion.")]
        [EnumMember(Value = "Smoke")]
        Smoke = 535,
        [System.ComponentModel.Description("536:Sonobuoy Dropping (missing definition)")]
        [EnumMember(Value = "Sonobuoy Dropping")]
        SonobuoyDropping = 536,
        [System.ComponentModel.Description("537:Starshell (missing definition)")]
        [EnumMember(Value = "Starshell")]
        Starshell = 537,
        [System.ComponentModel.Description("538:Surface Target Towing (missing definition)")]
        [EnumMember(Value = "Surface Target Towing")]
        SurfaceTargetTowing = 538,
        [System.ComponentModel.Description("539:Surface to Surface Firings (missing definition)")]
        [EnumMember(Value = "Surface to Surface Firings")]
        SurfaceToSurfaceFirings = 539,
        [System.ComponentModel.Description("540:Submarine General (non-firing exercises, practices, trials) (missing definition)")]
        [EnumMember(Value = "Submarine General (non-firing exercises, practices, trials)")]
        SubmarineGeneralNonFiringExercisesPracticesTrials = 540,
        [System.ComponentModel.Description("541:Surface Explosions (missing definition)")]
        [EnumMember(Value = "Surface Explosions")]
        SurfaceExplosions = 541,
        [System.ComponentModel.Description("542:Torpedo Firing Area (missing definition)")]
        [EnumMember(Value = "Torpedo Firing Area")]
        TorpedoFiringArea = 542,
        [System.ComponentModel.Description("543:Towed Array (missing definition)")]
        [EnumMember(Value = "Towed Array")]
        TowedArray = 543,
        [System.ComponentModel.Description("544:Aerial Towed Target or Target Towing Aircraft (missing definition)")]
        [EnumMember(Value = "Aerial Towed Target or Target Towing Aircraft")]
        AerialTowedTargetOrTargetTowingAircraft = 544,
        [System.ComponentModel.Description("545:Weapon Training (missing definition)")]
        [EnumMember(Value = "Weapon Training")]
        WeaponTraining = 545,
        [System.ComponentModel.Description("546:Amphibious (missing definition)")]
        [EnumMember(Value = "Amphibious")]
        Amphibious = 546,
        [System.ComponentModel.Description("A signal or message warning of diving activity.")]
        [EnumMember(Value = "Diving")]
        Diving = 547,
        [System.ComponentModel.Description("598:Balloons (missing definition)")]
        [EnumMember(Value = "Balloons")]
        Balloons = 598,
        [System.ComponentModel.Description("599:Electrical/Optical Hazard (missing definition)")]
        [EnumMember(Value = "Electrical/Optical Hazard")]
        ElectricalOpticalHazard = 599,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCoastline : int {
        [System.ComponentModel.Description("A coast backed by rock or earth cliffs, gives a good radar return and is useful for visual identification from a considerable distance off, where cliffs alternate with low lying coast along the shoreline.")]
        [EnumMember(Value = "Steep Coast")]
        SteepCoast = 1,
        [System.ComponentModel.Description("A level coast with no obvious topographic features.")]
        [EnumMember(Value = "Flat Coast")]
        FlatCoast = 2,
        [System.ComponentModel.Description("6:glacier, seaward end (missing definition)")]
        [EnumMember(Value = "glacier, seaward end")]
        GlacierSeawardEnd = 6,
        [System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
        [EnumMember(Value = "Mangrove")]
        Mangrove = 7,
        [System.ComponentModel.Description("A shoreline area made up of spongy land saturated with water. It may have a shallow covering of water, usually with a considerable amount of vegetation appearing above the surface.")]
        [EnumMember(Value = "Marshy Shore")]
        MarshyShore = 8,
        [System.ComponentModel.Description("A vertical cliff forming the seaward edge of an ice shelf, ranging in height from 2 metres to 50 metres or more above sea level.")]
        [EnumMember(Value = "Ice Coast")]
        IceCoast = 10,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum speedUnits : int {
        [System.ComponentModel.Description("A unit of speed, expressing the number of kilometres travelled in one hour.")]
        [EnumMember(Value = "Kilometres Per Hour")]
        KilometresPerHour = 2,
        [System.ComponentModel.Description("An imperial and United States customary unit of speed expressing the number of statute miles covered in one hour.")]
        [EnumMember(Value = "Miles Per Hour")]
        MilesPerHour = 3,
        [System.ComponentModel.Description("A nautical unit of speed. One knot is one nautical mile per hour. The name is derived from the knots in the log line.")]
        [EnumMember(Value = "Knots")]
        Knots = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfInstallationBuoy : int {
        [System.ComponentModel.Description("Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
        [EnumMember(Value = "Catenary Anchor Leg Mooring")]
        CatenaryAnchorLegMooring = 1,
        [System.ComponentModel.Description("A large mooring buoy used by tankers to load and unload in port approaches or in offshore oil and gas fields.")]
        [EnumMember(Value = "Single Buoy Mooring")]
        SingleBuoyMooring = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofRestrictions : int {
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
        [EnumMember(Value = "Nature Reserve")]
        NatureReserve = 4,
        [System.ComponentModel.Description("A place where birds are bred and protected.")]
        [EnumMember(Value = "Bird Sanctuary")]
        BirdSanctuary = 5,
        [System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
        [EnumMember(Value = "Game Reserve")]
        GameReserve = 6,
        [System.ComponentModel.Description("A place where seals are protected.")]
        [EnumMember(Value = "Seal Sanctuary")]
        SealSanctuary = 7,
        [System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
        [EnumMember(Value = "Historic Wreck Area")]
        HistoricWreckArea = 10,
        [System.ComponentModel.Description("An area where marine research takes place.")]
        [EnumMember(Value = "Research Area")]
        ResearchArea = 20,
        [System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
        [EnumMember(Value = "Fish Sanctuary")]
        FishSanctuary = 22,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        [EnumMember(Value = "Ecological Reserve")]
        EcologicalReserve = 23,
        [System.ComponentModel.Description("27:Environmentally Sensitive Sea Area (ESSA) (missing definition)")]
        [EnumMember(Value = "Environmentally Sensitive Sea Area (ESSA)")]
        EnvironmentallySensitiveSeaAreaEssa = 27,
        [System.ComponentModel.Description("28:Particularly Sensitive Sea Area (PSSA) (missing definition)")]
        [EnumMember(Value = "Particularly Sensitive Sea Area (PSSA)")]
        ParticularlySensitiveSeaAreaPssa = 28,
        [System.ComponentModel.Description("A place where coral is protected.")]
        [EnumMember(Value = "Coral Sanctuary")]
        CoralSanctuary = 31,
        [System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
        [EnumMember(Value = "Recreation Area")]
        RecreationArea = 32,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum qualityOfHorizontalMeasurement : int {
        [System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.")]
        [EnumMember(Value = "Approximate")]
        Approximate = 4,
        [System.ComponentModel.Description("Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.")]
        [EnumMember(Value = "Position Doubtful")]
        PositionDoubtful = 5,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum jurisdiction : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Involving more than one country; covering more than one national area.")]
        [EnumMember(Value = "International")]
        International = 1,
        [System.ComponentModel.Description("An area administered or controlled by a single nation.")]
        [EnumMember(Value = "National")]
        National = 2,
        [System.ComponentModel.Description("3:National Sub-Division (missing definition)")]
        [EnumMember(Value = "National Sub-Division")]
        NationalSubDivision = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfSurface : int {
        [System.ComponentModel.Description("Soft, wet earth.")]
        [EnumMember(Value = "Mud")]
        Mud = 1,
        [System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
        [EnumMember(Value = "Clay")]
        Clay = 2,
        [System.ComponentModel.Description("An unconsolidated sediment whose particles range in size from 0.0039 to 0.0625 millimetres in diameter (between clay and sand size).")]
        [EnumMember(Value = "Silt")]
        Silt = 3,
        [System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
        [EnumMember(Value = "Sand")]
        Sand = 4,
        [System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
        [EnumMember(Value = "Stone")]
        Stone = 5,
        [System.ComponentModel.Description("(Particles of 2.0 - 4.0mm); small stones with coarse sand.")]
        [EnumMember(Value = "Gravel")]
        Gravel = 6,
        [System.ComponentModel.Description("A small stone worn smooth and rounded by the action of water, sand, ice, etc. ranging in diameter between 4 and 64 millimetres.")]
        [EnumMember(Value = "Pebbles")]
        Pebbles = 7,
        [System.ComponentModel.Description("A naturally rounded stone larger than a pebble.")]
        [EnumMember(Value = "Cobbles")]
        Cobbles = 8,
        [System.ComponentModel.Description("Any formation of natural origin that constitutes an integral part of the lithosphere. The natural occurring material that forms firm, hard, and solid masses.")]
        [EnumMember(Value = "Rock")]
        Rock = 9,
        [System.ComponentModel.Description("The fluid or semi-fluid matter flowing from a volcano. The substance that results from the cooling of the molten rock. Part of the ocean bed is composed of lava.")]
        [EnumMember(Value = "Lava")]
        Lava = 11,
        [System.ComponentModel.Description("Hard calcareous skeletons of many tribes of marine polyps.")]
        [EnumMember(Value = "Coral")]
        Coral = 14,
        [System.ComponentModel.Description("The hard outside covering of an animal. Part of the ocean bed is composed of numerous shells of marine animals.")]
        [EnumMember(Value = "Shells")]
        Shells = 17,
        [System.ComponentModel.Description("A rounded rock with diameter of 256 millimetres or larger.")]
        [EnumMember(Value = "Boulder")]
        Boulder = 18,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum marksNavigationalSystemOf : int {
        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.")]
        [EnumMember(Value = "IALA A")]
        IalaA = 1,
        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.")]
        [EnumMember(Value = "IALA B")]
        IalaB = 2,
        [System.ComponentModel.Description("Navigational aids do not conform to any defined system.")]
        [EnumMember(Value = "No System")]
        NoSystem = 9,
        [System.ComponentModel.Description("Navigational aids as required in international, national or regional regulations that contain the same navigational aids as the European Code for Inland Waterways of UNECE, or if there is no regulation for a waterway, navigational aids as recommended in the European Code for Inland Waterways of UNECE")]
        [EnumMember(Value = "Main European Inland Waterway Marking System")]
        MainEuropeanInlandWaterwayMarkingSystem = 11,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum magneticAnomalyDetectorSignature : int {
        [System.ComponentModel.Description("501:nil (missing definition)")]
        [EnumMember(Value = "nil")]
        Nil = 501,
        [System.ComponentModel.Description("502:slight (missing definition)")]
        [EnumMember(Value = "slight")]
        Slight = 502,
        [System.ComponentModel.Description("503:moderate (missing definition)")]
        [EnumMember(Value = "moderate")]
        Moderate = 503,
        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        [EnumMember(Value = "Strong")]
        Strong = 504,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum comparisonOperator : int {
        [System.ComponentModel.Description("The value of the left value is greater than that of the right.")]
        [EnumMember(Value = "Greater Than")]
        GreaterThan = 1,
        [System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right.")]
        [EnumMember(Value = "Greater Than or Equal To")]
        GreaterThanOrEqualTo = 2,
        [System.ComponentModel.Description("The value of the left expression is less than that of the right.")]
        [EnumMember(Value = "Less Than")]
        LessThan = 3,
        [System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right.")]
        [EnumMember(Value = "Less Than or Equal To")]
        LessThanOrEqualTo = 4,
        [System.ComponentModel.Description("The two values are equivalent.")]
        [EnumMember(Value = "Equal To")]
        EqualTo = 5,
        [System.ComponentModel.Description("The two values are not equivalent.")]
        [EnumMember(Value = "Not Equal To")]
        NotEqualTo = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCable : int {
        [System.ComponentModel.Description("A cable that transmits or distributes electrical power.")]
        [EnumMember(Value = "Power Line")]
        PowerLine = 1,
        [System.ComponentModel.Description("Multiple un-insulated cables usually supported by steel lattice towers. Such features are generally more prominent than normal power lines.")]
        [EnumMember(Value = "Transmission Line")]
        TransmissionLine = 3,
        [System.ComponentModel.Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
        [EnumMember(Value = "Mooring Cable")]
        MooringCable = 6,
        [System.ComponentModel.Description("A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.")]
        [EnumMember(Value = "Ferry")]
        Ferry = 7,
        [System.ComponentModel.Description("A cable used for joining components of complex marine structures, for example mooring trots.")]
        [EnumMember(Value = "Junction Cable")]
        JunctionCable = 9,
        [System.ComponentModel.Description("A cable used for the transmission and reception of modulated communication waves/signals.")]
        [EnumMember(Value = "Telecommunications Cable")]
        TelecommunicationsCable = 10,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfWreck : int {
        [System.ComponentModel.Description("1:non-dangerous wreck (missing definition)")]
        [EnumMember(Value = "non-dangerous wreck")]
        NonDangerousWreck = 1,
        [System.ComponentModel.Description("A wreck submerged at such a depth as to be considered dangerous to surface navigation.")]
        [EnumMember(Value = "Dangerous Wreck")]
        DangerousWreck = 2,
        [System.ComponentModel.Description("A substantively decayed wreck over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.")]
        [EnumMember(Value = "Distributed Remains of Wreck")]
        DistributedRemainsOfWreck = 3,
        [System.ComponentModel.Description("4:wreck showing mast/masts (missing definition)")]
        [EnumMember(Value = "wreck showing mast/masts")]
        WreckShowingMastMasts = 4,
        [System.ComponentModel.Description("Wreck of which any portion of the hull or superstructure is visible at the sounding datum indicated.")]
        [EnumMember(Value = "Wreck Showing Any Portion of Hull or Superstructure")]
        WreckShowingAnyPortionOfHullOrSuperstructure = 5,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLateralMark : int {
        [System.ComponentModel.Description("1:port-hand lateral mark (missing definition)")]
        [EnumMember(Value = "port-hand lateral mark")]
        PortHandLateralMark = 1,
        [System.ComponentModel.Description("2:starboard-hand lateral mark (missing definition)")]
        [EnumMember(Value = "starboard-hand lateral mark")]
        StarboardHandLateralMark = 2,
        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
        [EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")]
        PreferredChannelToStarboardLateralMark = 3,
        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
        [EnumMember(Value = "Preferred Channel to Port Lateral Mark")]
        PreferredChannelToPortLateralMark = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum areaCategory : int {
        [System.ComponentModel.Description("501:Solid Red (SR) (missing definition)")]
        [EnumMember(Value = "Solid Red (SR)")]
        SolidRedSr = 501,
        [System.ComponentModel.Description("502:Pecked Red (PR) (missing definition)")]
        [EnumMember(Value = "Pecked Red (PR)")]
        PeckedRedPr = 502,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum status : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Intended to last or function indefinitely.")]
        [EnumMember(Value = "Permanent")]
        Permanent = 1,
        [System.ComponentModel.Description("Acting on special occasions; happening irregularly.")]
        [EnumMember(Value = "Occasional")]
        Occasional = 2,
        [System.ComponentModel.Description("Presented as worthy of confidence, acceptance, use, etc.")]
        [EnumMember(Value = "Recommended")]
        Recommended = 3,
        [System.ComponentModel.Description("Use has ceased, but the facility still exists intact; disused.")]
        [EnumMember(Value = "Not in Use")]
        NotInUse = 4,
        [System.ComponentModel.Description("5:periodic/intermittent (missing definition)")]
        [EnumMember(Value = "periodic/intermittent")]
        PeriodicIntermittent = 5,
        [System.ComponentModel.Description("Set apart for some specific use.")]
        [EnumMember(Value = "Reserved")]
        Reserved = 6,
        [System.ComponentModel.Description("Meant to last only for a time.")]
        [EnumMember(Value = "Temporary")]
        Temporary = 7,
        [System.ComponentModel.Description("Administered by an individual or corporation, rather than a State or a public body.")]
        [EnumMember(Value = "Private")]
        Private = 8,
        [System.ComponentModel.Description("Compulsory; enforced.")]
        [EnumMember(Value = "Mandatory")]
        Mandatory = 9,
        [System.ComponentModel.Description("No longer lit.")]
        [EnumMember(Value = "Extinguished")]
        Extinguished = 11,
        [System.ComponentModel.Description("Lit by flood lights, strip lights, etc.")]
        [EnumMember(Value = "Illuminated")]
        Illuminated = 12,
        [System.ComponentModel.Description("Famous in history; of historical interest.")]
        [EnumMember(Value = "Historic")]
        Historic = 13,
        [System.ComponentModel.Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
        [EnumMember(Value = "Public")]
        Public = 14,
        [System.ComponentModel.Description("Occur at a time, coincide in point of time, be contemporary or simultaneous.")]
        [EnumMember(Value = "Synchronized")]
        Synchronized = 15,
        [System.ComponentModel.Description("Looked at or observed over a period of time especially so as to be aware of any movement or change.")]
        [EnumMember(Value = "Watched")]
        Watched = 16,
        [System.ComponentModel.Description("Usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
        [EnumMember(Value = "Unwatched")]
        Unwatched = 17,
        [System.ComponentModel.Description("A feature that has been reported but has not been definitely determined to exist.")]
        [EnumMember(Value = "Existence Doubtful")]
        ExistenceDoubtful = 18,
        [System.ComponentModel.Description("Marked by buoys.")]
        [EnumMember(Value = "Buoyed")]
        Buoyed = 28,
        [System.ComponentModel.Description("501:active/in use (missing definition)")]
        [EnumMember(Value = "active/in use")]
        ActiveInUse = 501,
        [System.ComponentModel.Description("A coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.")]
        [EnumMember(Value = "Claimed")]
        Claimed = 502,
        [System.ComponentModel.Description("503:practice and/or exercise purposes (missing definition)")]
        [EnumMember(Value = "practice and/or exercise purposes")]
        PracticeAndOrExercisePurposes = 503,
        [System.ComponentModel.Description("acknowledged and agreed in accordance with the provisions of International Law ")]
        [EnumMember(Value = "Recognised")]
        Recognised = 504,
        [System.ComponentModel.Description("not detected by repeated surveys, leading to doubts about the object's existence. (AML)")]
        [EnumMember(Value = "Dead")]
        Dead = 505,
        [System.ComponentModel.Description("an object that has been salvaged or removed. (AML)")]
        [EnumMember(Value = "Lifted")]
        Lifted = 506,
        [System.ComponentModel.Description("where a significant number of persons have perished as a direct result of a vessel or structure sinking and their remains cannot be recovered, the wreck and immediate area may be declared as a Mass Grave or more specifically, a War Grave. Such sites are protected from disturbance by International Law. (AML)")]
        [EnumMember(Value = "Mass Grave")]
        MassGrave = 507,
        [System.ComponentModel.Description("a borehole drilled in the search for a new source of oil or gas. (An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        [EnumMember(Value = "Exploration")]
        Exploration = 508,
        [System.ComponentModel.Description("a borehole that is actively engaged in the extraction of oil or gas from the seabed. (Adapted from An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        [EnumMember(Value = "Production")]
        Production = 509,
        [System.ComponentModel.Description("a well where the extraction of oil or gas has been temporarily abandoned. When suspended, a well is either plugged (filled with concrete and topped with a steel plate) or capped (well-head equipment is installed over the well). (Adapted from An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        [EnumMember(Value = "Suspended")]
        Suspended = 510,
        [System.ComponentModel.Description("a borehole drilled for the purpose of injecting a secondary substance, for example water,  into the pore spaces in a reservoir rock to encourage oil or gas to flow into adjacent producing wells. (An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        [EnumMember(Value = "Injection")]
        Injection = 511,
        [System.ComponentModel.Description("the status of the object is unspecified.")]
        [EnumMember(Value = "Unspecified")]
        Unspecified = 512,
        [System.ComponentModel.Description("temporarily quiet, inactive, not being used. (AML).")]
        [EnumMember(Value = "Dormant")]
        Dormant = 516,
        [System.ComponentModel.Description("planned; intended; in accordance with, or achieved by, a careful plan made beforehand (The Concise Oxford Dictionary)")]
        [EnumMember(Value = "Proposed")]
        Proposed = 517,
        [System.ComponentModel.Description("completely deserted; given up (adapted from the Concise Oxford Dictionary)")]
        [EnumMember(Value = "Abandoned")]
        Abandoned = 518,
        [System.ComponentModel.Description("Area of overlap of the unilateral fishing zones of two or more countries")]
        [EnumMember(Value = "Grey zone")]
        GreyZone = 519,
        [System.ComponentModel.Description("An area of the sea of indeterminate jurisdiction where no agreed boundary exist.")]
        [EnumMember(Value = "Indeterminate")]
        Indeterminate = 520,
        [System.ComponentModel.Description("Involving two or more states as parties to an agreement.")]
        [EnumMember(Value = "Multilateral")]
        Multilateral = 521,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCardinalMark : int {
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NW-NE taken from the point of interest; it should be passed to the north side of the mark.")]
        [EnumMember(Value = "North Cardinal Mark")]
        NorthCardinalMark = 1,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NE-SE taken from the point of interest. It should be passed to the east side of the mark.")]
        [EnumMember(Value = "East Cardinal Mark")]
        EastCardinalMark = 2,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SE-SW taken from the point of interest; it should be passed to the south side of the mark.")]
        [EnumMember(Value = "South Cardinal Mark")]
        SouthCardinalMark = 3,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SW-NW taken from the point of interest; it should be passed to the west side of the mark.")]
        [EnumMember(Value = "West Cardinal Mark")]
        WestCardinalMark = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAirportAirfield : int {
        [System.ComponentModel.Description("A large military airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
        [EnumMember(Value = "Military Aeroplane Airport")]
        MilitaryAeroplaneAirport = 1,
        [System.ComponentModel.Description("A large airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
        [EnumMember(Value = "Civil Aeroplane Airport")]
        CivilAeroplaneAirport = 2,
        [System.ComponentModel.Description("A landing place for helicopters controlled by the military.")]
        [EnumMember(Value = "Military Heliport")]
        MilitaryHeliport = 3,
        [System.ComponentModel.Description("A landing place for helicopters, often the roof of a building.")]
        [EnumMember(Value = "Civil Heliport")]
        CivilHeliport = 4,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of gliders.")]
        [EnumMember(Value = "Glider Airfield")]
        GliderAirfield = 5,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of small aeroplanes.")]
        [EnumMember(Value = "Small Planes Airfield")]
        SmallPlanesAirfield = 6,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of aeroplanes or helicopters in times of emergency.")]
        [EnumMember(Value = "Emergency Airfield")]
        EmergencyAirfield = 8,
        [System.ComponentModel.Description("9:search and rescue (missing definition)")]
        [EnumMember(Value = "search and rescue")]
        SearchAndRescue = 9,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum techniqueOfVerticalMeasurement : int {
        [System.ComponentModel.Description("The depth was measured by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.")]
        [EnumMember(Value = "Found by Echo Sounder")]
        FoundByEchoSounder = 1,
        [System.ComponentModel.Description("The depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the seabed and generate a record of the seabed configuration.")]
        [EnumMember(Value = "Found by Side Scan Sonar")]
        FoundBySideScanSonar = 2,
        [System.ComponentModel.Description("The depth was measured by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.")]
        [EnumMember(Value = "Found by Multi Beam")]
        FoundByMultiBeam = 3,
        [System.ComponentModel.Description("The depth was determined by a person skilled in the practice of diving.")]
        [EnumMember(Value = "Found by Diver")]
        FoundByDiver = 4,
        [System.ComponentModel.Description("The depth was measured by using a line, graduated with attached marks and fastened to a sounding lead.")]
        [EnumMember(Value = "Found by Lead Line")]
        FoundByLeadLine = 5,
        [System.ComponentModel.Description("The given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.")]
        [EnumMember(Value = "Swept by Vertical Acoustic System")]
        SweptByVerticalAcousticSystem = 8,
        [System.ComponentModel.Description("The depth was determined by using an instrument that compares electromagnetic signals.")]
        [EnumMember(Value = "Found by Electromagnetic Sensor")]
        FoundByElectromagneticSensor = 9,
        [System.ComponentModel.Description("The science or art of obtaining reliable measurements from photographs.")]
        [EnumMember(Value = "Photogrammetry")]
        Photogrammetry = 10,
        [System.ComponentModel.Description("The depth was determined by using instruments placed aboard an artificial satellite.")]
        [EnumMember(Value = "Satellite Imagery")]
        SatelliteImagery = 11,
        [System.ComponentModel.Description("12:found by leveling (missing definition)")]
        [EnumMember(Value = "found by leveling")]
        FoundByLeveling = 12,
        [System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a side scan sonar.")]
        [EnumMember(Value = "Swept by Side Scan Sonar")]
        SweptBySideScanSonar = 13,
        [System.ComponentModel.Description("The depth was measured by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
        [EnumMember(Value = "Found by LIDAR")]
        FoundByLidar = 15,
        [System.ComponentModel.Description("A radar with a synthetic aperture antenna which is composed of a large number of elementary transducing elements. The signals are electronically combined into a resulting signal equivalent to that of a single antenna of a given aperture in a given direction.")]
        [EnumMember(Value = "Synthetic Aperture Radar")]
        SyntheticApertureRadar = 16,
        [System.ComponentModel.Description("Term used to describe the imagery derived from subdividing the electromagnetic spectrum into very narrow bandwidths. These narrow bandwidths may be combined with or subtracted from each other in various ways to form images useful in precise terrain or target analysis.")]
        [EnumMember(Value = "Hyperspectral Imagery")]
        HyperspectralImagery = 17,
        [System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a line or object below the surface at the desired depth; or least depth(s) and position(s) within an area was identified using the same technique.")]
        [EnumMember(Value = "Mechanically Swept")]
        MechanicallySwept = 18,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum verticalDatum : int {
        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        [EnumMember(Value = "Mean Sea Level")]
        MeanSeaLevel = 3,
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        [EnumMember(Value = "Low Water")]
        LowWater = 13,
        [System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean High Water")]
        MeanHighWater = 16,
        [System.ComponentModel.Description("The average height of the high waters of spring tides.")]
        [EnumMember(Value = "Mean High Water Springs")]
        MeanHighWaterSprings = 17,
        [System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
        [EnumMember(Value = "High Water")]
        HighWater = 18,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
        [EnumMember(Value = "Approximate Mean Sea Level")]
        ApproximateMeanSeaLevel = 19,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
        [EnumMember(Value = "High Water Springs")]
        HighWaterSprings = 20,
        [System.ComponentModel.Description("The average height of higher high waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean Higher High Water")]
        MeanHigherHighWater = 21,
        [System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        [EnumMember(Value = "Local Datum")]
        LocalDatum = 24,
        [System.ComponentModel.Description("25:international great (missing definition)")]
        [EnumMember(Value = "international great")]
        InternationalGreat = 25,
        [System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
        [EnumMember(Value = "Mean Water Level")]
        MeanWaterLevel = 26,
        [System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
        [EnumMember(Value = "Higher High Water Large Tide")]
        HigherHighWaterLargeTide = 28,
        [System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
        [EnumMember(Value = "Nearly Highest High Water")]
        NearlyHighestHighWater = 29,
        [System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        [EnumMember(Value = "Highest Astronomical Tide")]
        HighestAstronomicalTide = 30,
        [System.ComponentModel.Description("44:Baltic Sea Chart Datum (missing definition)")]
        [EnumMember(Value = "Baltic Sea Chart Datum")]
        BalticSeaChartDatum = 44,
        [System.ComponentModel.Description("501:Mean Tide Level (missing definition)")]
        [EnumMember(Value = "Mean Tide Level")]
        MeanTideLevel = 501,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum exhibitionConditionOfLight : int {
        [System.ComponentModel.Description("A light shown throughout the 24 hours without change of character.")]
        [EnumMember(Value = "Light Shown Without Change of Character")]
        LightShownWithoutChangeOfCharacter = 1,
        [System.ComponentModel.Description("A light which is only exhibited by day.")]
        [EnumMember(Value = "Daytime Light")]
        DaytimeLight = 2,
        [System.ComponentModel.Description("A light which is exhibited in fog or conditions of reduced visibility.")]
        [EnumMember(Value = "Fog Light")]
        FogLight = 3,
        [System.ComponentModel.Description("A light which is only exhibited at night.")]
        [EnumMember(Value = "Night Light")]
        NightLight = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLight : int {
        [System.ComponentModel.Description("A light associated with other lights so as to form a leading line to be followed.")]
        [EnumMember(Value = "Leading Light")]
        LeadingLight = 4,
        [System.ComponentModel.Description("An aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.")]
        [EnumMember(Value = "Aero Light")]
        AeroLight = 5,
        [System.ComponentModel.Description("A broad beam light used to illuminate a structure or area.")]
        [EnumMember(Value = "Flood Light")]
        FloodLight = 8,
        [System.ComponentModel.Description("A light whose source has a linear form generally horizontal, which can reach a length of several metres.")]
        [EnumMember(Value = "Strip Light")]
        StripLight = 9,
        [System.ComponentModel.Description("A light placed on or near the support of a main light and having a special use in navigation.")]
        [EnumMember(Value = "Subsidiary Light")]
        SubsidiaryLight = 10,
        [System.ComponentModel.Description("A powerful light focused so as to illuminate a small area.")]
        [EnumMember(Value = "Spotlight")]
        Spotlight = 11,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [EnumMember(Value = "Front")]
        Front = 12,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [EnumMember(Value = "Rear")]
        Rear = 13,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [EnumMember(Value = "Lower")]
        Lower = 14,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [EnumMember(Value = "Upper")]
        Upper = 15,
        [System.ComponentModel.Description("A light available as a backup to a main light which will be illuminated should the main light fail.")]
        [EnumMember(Value = "Emergency")]
        Emergency = 17,
        [System.ComponentModel.Description("A light which enables its approximate bearing to be obtained without the use of a compass.")]
        [EnumMember(Value = "Bearing Light")]
        BearingLight = 18,
        [System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed horizontally.")]
        [EnumMember(Value = "Horizontally Disposed")]
        HorizontallyDisposed = 19,
        [System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed vertically.")]
        [EnumMember(Value = "Vertically Disposed")]
        VerticallyDisposed = 20,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum trafficFlow : int {
        [System.ComponentModel.Description("Traffic flow in a general direction toward a port or similar destination.")]
        [EnumMember(Value = "Inbound")]
        Inbound = 1,
        [System.ComponentModel.Description("Traffic flow in a general direction away from a port or similar point of origin.")]
        [EnumMember(Value = "Outbound")]
        Outbound = 2,
        [System.ComponentModel.Description("3:one-way (missing definition)")]
        [EnumMember(Value = "one-way")]
        OneWay = 3,
        [System.ComponentModel.Description("4:two-way (missing definition)")]
        [EnumMember(Value = "two-way")]
        TwoWay = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum colour : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("The achromatic object colour of greatest lightness characteristically perceived to belong to objects that reflect diffusely nearly all incident energy throughout the visible spectrum.")]
        [EnumMember(Value = "White")]
        White = 1,
        [System.ComponentModel.Description("The achromatic color of least lightness characteristically perceived to belong to objects that neither reflect nor transmit light.")]
        [EnumMember(Value = "Black")]
        Black = 2,
        [System.ComponentModel.Description("A color whose hue resembles that of blood or of the ruby or is that of the long-wave extreme of the visible spectrum.")]
        [EnumMember(Value = "Red")]
        Red = 3,
        [System.ComponentModel.Description("Of the color green.")]
        [EnumMember(Value = "Green")]
        Green = 4,
        [System.ComponentModel.Description("A color whose hue is that of the clear sky or that of the portion of the color spectrum lying between green and violet.")]
        [EnumMember(Value = "Blue")]
        Blue = 5,
        [System.ComponentModel.Description("A color whose hue resembles that of ripe lemons or sunflowers or is that of the portion of the spectrum lying between green and orange.")]
        [EnumMember(Value = "Yellow")]
        Yellow = 6,
        [System.ComponentModel.Description("Of the color grey.")]
        [EnumMember(Value = "Grey")]
        Grey = 7,
        [System.ComponentModel.Description("Any of a group of colors between red and yellow in hue, of medium to low lightness, and of moderate to low saturation.")]
        [EnumMember(Value = "Brown")]
        Brown = 8,
        [System.ComponentModel.Description("A variable color averaging a dark orange yellow.")]
        [EnumMember(Value = "Amber")]
        Amber = 9,
        [System.ComponentModel.Description("Any of a group of colors of reddish-blue hue, low lightness, and medium saturation.")]
        [EnumMember(Value = "Violet")]
        Violet = 10,
        [System.ComponentModel.Description("Any of a group of colors that are between red and yellow in hue.")]
        [EnumMember(Value = "Orange")]
        Orange = 11,
        [System.ComponentModel.Description("A deep purplish red.")]
        [EnumMember(Value = "Magenta")]
        Magenta = 12,
        [System.ComponentModel.Description("Any of a group of colors bluish red to red in hue, of medium to high lightness, and of low to moderate saturation.")]
        [EnumMember(Value = "Pink")]
        Pink = 13,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofBoundaryLine : int {
        [System.ComponentModel.Description("A line of demarcation between controlled areas.")]
        [EnumMember(Value = "Administrative Boundary")]
        AdministrativeBoundary = 501,
        [System.ComponentModel.Description("506:de facto boundary (missing definition)")]
        [EnumMember(Value = "de facto boundary")]
        DeFactoBoundary = 506,
        [System.ComponentModel.Description("511:International Maritime Boundary (missing definition)")]
        [EnumMember(Value = "International Maritime Boundary")]
        InternationalMaritimeBoundary = 511,
        [System.ComponentModel.Description("A line every point of which is equidistant from the nearest points on the baselines of two or more states between which it lies.")]
        [EnumMember(Value = "Median Line")]
        MedianLine = 599,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum soundingDatum : int {
        [System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.")]
        [EnumMember(Value = "Mean Low Water Springs")]
        MeanLowWaterSprings = 501,
        [System.ComponentModel.Description("The average height of lower low water springs at a place.")]
        [EnumMember(Value = "Mean Lower Low Water Springs")]
        MeanLowerLowWaterSprings = 502,
        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        [EnumMember(Value = "Mean Sea Level")]
        MeanSeaLevel = 503,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.")]
        [EnumMember(Value = "Lowest Low Water")]
        LowestLowWater = 504,
        [System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean Low Water")]
        MeanLowWater = 505,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
        [EnumMember(Value = "Lowest Low Water Springs")]
        LowestLowWaterSprings = 506,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
        [EnumMember(Value = "Approximate Mean Low Water Springs")]
        ApproximateMeanLowWaterSprings = 507,
        [System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
        [EnumMember(Value = "Indian Spring Low Water")]
        IndianSpringLowWater = 508,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
        [EnumMember(Value = "Low Water Springs")]
        LowWaterSprings = 509,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
        [EnumMember(Value = "Approximate Lowest Astronomical Tide")]
        ApproximateLowestAstronomicalTide = 510,
        [System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
        [EnumMember(Value = "Nearly Lowest Low Water")]
        NearlyLowestLowWater = 511,
        [System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean Lower Low Water")]
        MeanLowerLowWater = 512,
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        [EnumMember(Value = "Low Water")]
        LowWater = 513,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
        [EnumMember(Value = "Approximate Mean Low Water")]
        ApproximateMeanLowWater = 514,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
        [EnumMember(Value = "Approximate Mean Lower Low Water")]
        ApproximateMeanLowerLowWater = 515,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
        [EnumMember(Value = "Approximate Mean Sea Level")]
        ApproximateMeanSeaLevel = 519,
        [System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
        [EnumMember(Value = "Equinoctial Spring Low Water")]
        EquinoctialSpringLowWater = 522,
        [System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        [EnumMember(Value = "Lowest Astronomical Tide")]
        LowestAstronomicalTide = 523,
        [System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        [EnumMember(Value = "Local Datum")]
        LocalDatum = 524,
        [System.ComponentModel.Description("525:International Great Lakes Datum 1985 (IGLD 1985) (missing definition)")]
        [EnumMember(Value = "International Great Lakes Datum 1985 (IGLD 1985)")]
        InternationalGreatLakesDatum1985Igld1985 = 525,
        [System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
        [EnumMember(Value = "Mean Water Level")]
        MeanWaterLevel = 526,
        [System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
        [EnumMember(Value = "Lower Low Water Large Tide")]
        LowerLowWaterLargeTide = 527,
        [System.ComponentModel.Description("531:Mean Tide Level (missing definition)")]
        [EnumMember(Value = "Mean Tide Level")]
        MeanTideLevel = 531,
        [System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
        [EnumMember(Value = "Baltic Sea Chart Datum 2000")]
        BalticSeaChartDatum2000 = 532,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSpecialPurposeMark : int {
        [System.ComponentModel.Description("1:firing danger area mark (missing definition)")]
        [EnumMember(Value = "firing danger area mark")]
        FiringDangerAreaMark = 1,
        [System.ComponentModel.Description("Any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.")]
        [EnumMember(Value = "Target Mark")]
        TargetMark = 2,
        [System.ComponentModel.Description("A mark marking the position of a ship which is used as a target during some military exercise.")]
        [EnumMember(Value = "Marker Ship Mark")]
        MarkerShipMark = 3,
        [System.ComponentModel.Description("A mark used to indicate a degaussing range.")]
        [EnumMember(Value = "Degaussing Range Mark")]
        DegaussingRangeMark = 4,
        [System.ComponentModel.Description("A mark of relevance to barges.")]
        [EnumMember(Value = "Barge Mark")]
        BargeMark = 5,
        [System.ComponentModel.Description("A mark used to indicate the position of submarine cables or the point at which they run on to the land.")]
        [EnumMember(Value = "Cable Mark")]
        CableMark = 6,
        [System.ComponentModel.Description("A mark used to indicate the limit of a spoil ground.")]
        [EnumMember(Value = "Spoil Ground Mark")]
        SpoilGroundMark = 7,
        [System.ComponentModel.Description("A mark used to indicate the position of an outfall or the point at which it leaves the land.")]
        [EnumMember(Value = "Outfall Mark")]
        OutfallMark = 8,
        [System.ComponentModel.Description("Ocean Data Acquisition System.")]
        [EnumMember(Value = "ODAS")]
        Odas = 9,
        [System.ComponentModel.Description("A mark used to record data for scientific purposes.")]
        [EnumMember(Value = "Recording Mark")]
        RecordingMark = 10,
        [System.ComponentModel.Description("An area in which seaplanes anchor or may anchor.")]
        [EnumMember(Value = "Seaplane Anchorage")]
        SeaplaneAnchorage = 11,
        [System.ComponentModel.Description("A mark used to indicate a recreation zone.")]
        [EnumMember(Value = "Recreation Zone Mark")]
        RecreationZoneMark = 12,
        [System.ComponentModel.Description("A mark indicating a mooring or moorings.")]
        [EnumMember(Value = "Mooring Mark")]
        MooringMark = 14,
        [System.ComponentModel.Description("A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
        [EnumMember(Value = "LANBY")]
        Lanby = 15,
        [System.ComponentModel.Description("Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
        [EnumMember(Value = "Leading Mark")]
        LeadingMark = 16,
        [System.ComponentModel.Description("A course at sea, whose ends are indicated by ranges ashore, and whose length has been accurately measured for determining the speed of vessels.")]
        [EnumMember(Value = "Measured Distance")]
        MeasuredDistance = 17,
        [System.ComponentModel.Description("A notice board or sign indicating information to the mariner.")]
        [EnumMember(Value = "Notice Mark")]
        NoticeMark = 18,
        [System.ComponentModel.Description("19:TSS mark (Traffic Separation Scheme) (missing definition)")]
        [EnumMember(Value = "TSS mark (Traffic Separation Scheme)")]
        TssMarkTrafficSeparationScheme = 19,
        [System.ComponentModel.Description("An area within which anchoring is not permitted.")]
        [EnumMember(Value = "Anchoring Prohibited")]
        AnchoringProhibited = 20,
        [System.ComponentModel.Description("A mark indicating that berthing is prohibited.")]
        [EnumMember(Value = "Berthing Prohibited Mark")]
        BerthingProhibitedMark = 21,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking is generally prohibited.")]
        [EnumMember(Value = "Overtaking Prohibited")]
        OvertakingProhibited = 22,
        [System.ComponentModel.Description("23:two-way traffic prohibited mark (missing definition)")]
        [EnumMember(Value = "two-way traffic prohibited mark")]
        TwoWayTrafficProhibitedMark = 23,
        [System.ComponentModel.Description("A mark indicating that vessels must not generate excessive wake.")]
        [EnumMember(Value = "Reduced Wake Mark")]
        ReducedWakeMark = 24,
        [System.ComponentModel.Description("A mark indicating that a speed limit applies.")]
        [EnumMember(Value = "Speed Limit Mark")]
        SpeedLimitMark = 25,
        [System.ComponentModel.Description("A mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
        [EnumMember(Value = "Stop Mark")]
        StopMark = 26,
        [System.ComponentModel.Description("A mark indicating that special caution must be exercised in the vicinity of the mark.")]
        [EnumMember(Value = "General Warning Mark")]
        GeneralWarningMark = 27,
        [System.ComponentModel.Description("28:sound ship’s siren mark (missing definition)")]
        [EnumMember(Value = "sound ship’s siren mark")]
        SoundShipSSirenMark = 28,
        [System.ComponentModel.Description("29:restricted vertical (missing definition)")]
        [EnumMember(Value = "restricted vertical")]
        RestrictedVertical = 29,
        [System.ComponentModel.Description("30:maximum vessel’s draught mark (missing definition)")]
        [EnumMember(Value = "maximum vessel’s draught mark")]
        MaximumVesselSDraughtMark = 30,
        [System.ComponentModel.Description("A mark indicating the minimum horizontal space available for passage.")]
        [EnumMember(Value = "Restricted Horizontal Clearance Mark")]
        RestrictedHorizontalClearanceMark = 31,
        [System.ComponentModel.Description("A mark warning of strong currents.")]
        [EnumMember(Value = "Strong Current Warning Mark")]
        StrongCurrentWarningMark = 32,
        [System.ComponentModel.Description("A mark indicating that berthing is allowed.")]
        [EnumMember(Value = "Berthing Permitted Mark")]
        BerthingPermittedMark = 33,
        [System.ComponentModel.Description("A mark indicating an overhead power cable.")]
        [EnumMember(Value = "Overhead Power Cable Mark")]
        OverheadPowerCableMark = 34,
        [System.ComponentModel.Description("A mark indicating the gradient of the slope of a dredge channel edge.")]
        [EnumMember(Value = "Channel Edge Gradient Mark")]
        ChannelEdgeGradientMark = 35,
        [System.ComponentModel.Description("A mark indicating the presence of a telephone.")]
        [EnumMember(Value = "Telephone Mark")]
        TelephoneMark = 36,
        [System.ComponentModel.Description("A mark indicating that a ferry route crosses the ship route; often used with a 'sound ship's siren' mark.")]
        [EnumMember(Value = "Ferry Crossing Mark")]
        FerryCrossingMark = 37,
        [System.ComponentModel.Description("A mark used to indicate the position of submarine pipelines or the point at which they run on to the land.")]
        [EnumMember(Value = "Pipeline Mark")]
        PipelineMark = 39,
        [System.ComponentModel.Description("A mark indicating an anchorage area.")]
        [EnumMember(Value = "Anchorage Mark")]
        AnchorageMark = 40,
        [System.ComponentModel.Description("A mark used to indicate a clearing line.")]
        [EnumMember(Value = "Clearing Mark")]
        ClearingMark = 41,
        [System.ComponentModel.Description("A mark indicating the location at which a restriction or requirement exists.")]
        [EnumMember(Value = "Control Mark")]
        ControlMark = 42,
        [System.ComponentModel.Description("A mark indicating that diving may take place in the vicinity.")]
        [EnumMember(Value = "Diving Mark")]
        DivingMark = 43,
        [System.ComponentModel.Description("A mark providing or indicating a place of safety.")]
        [EnumMember(Value = "Refuge Beacon")]
        RefugeBeacon = 44,
        [System.ComponentModel.Description("A mark indicating a foul ground.")]
        [EnumMember(Value = "Foul Ground Mark")]
        FoulGroundMark = 45,
        [System.ComponentModel.Description("A mark installed for use by yachtsmen.")]
        [EnumMember(Value = "Yachting Mark")]
        YachtingMark = 46,
        [System.ComponentModel.Description("A mark indicating an area where helicopters may land.")]
        [EnumMember(Value = "Heliport Mark")]
        HeliportMark = 47,
        [System.ComponentModel.Description("A mark indicating a location at which a GNSS position has been accurately determined.")]
        [EnumMember(Value = "GNSS Mark")]
        GnssMark = 48,
        [System.ComponentModel.Description("A mark indicating an area where seaplanes land.")]
        [EnumMember(Value = "Seaplane Landing Mark")]
        SeaplaneLandingMark = 49,
        [System.ComponentModel.Description("A mark indicating that entry is prohibited.")]
        [EnumMember(Value = "Entry Prohibited Mark")]
        EntryProhibitedMark = 50,
        [System.ComponentModel.Description("A mark indicating that work (generally construction) is in progress.")]
        [EnumMember(Value = "Work in Progress Mark")]
        WorkInProgressMark = 51,
        [System.ComponentModel.Description("52:mark with unknown (missing definition)")]
        [EnumMember(Value = "mark with unknown")]
        MarkWithUnknown = 52,
        [System.ComponentModel.Description("A mark indicating a borehole that produces or is capable of producing oil or natural gas.")]
        [EnumMember(Value = "Wellhead Mark")]
        WellheadMark = 53,
        [System.ComponentModel.Description("A mark indicating the point at which a channel divides separately into two channels.")]
        [EnumMember(Value = "Channel Separation Mark")]
        ChannelSeparationMark = 54,
        [System.ComponentModel.Description("A mark indicating the existence of a fish, mussel, oyster or pearl farm/culture.")]
        [EnumMember(Value = "Marine Farm Mark")]
        MarineFarmMark = 55,
        [System.ComponentModel.Description("A mark indicating the existence or the extent of an artificial reef.")]
        [EnumMember(Value = "Artificial Reef Mark")]
        ArtificialReefMark = 56,
        [System.ComponentModel.Description("A mark, used year round, that may be submerged when ice passes through the area.")]
        [EnumMember(Value = "Ice Mark")]
        IceMark = 57,
        [System.ComponentModel.Description("A mark used to define the boundary of a nature reserve.")]
        [EnumMember(Value = "Nature Reserve Mark")]
        NatureReserveMark = 58,
        [System.ComponentModel.Description("A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.")]
        [EnumMember(Value = "Fish Aggregating Device")]
        FishAggregatingDevice = 59,
        [System.ComponentModel.Description("A mark used to indicate the existence of a wreck.")]
        [EnumMember(Value = "Wreck Mark")]
        WreckMark = 60,
        [System.ComponentModel.Description("A mark used to indicate the existence of a customs checkpoint.")]
        [EnumMember(Value = "Customs Mark")]
        CustomsMark = 61,
        [System.ComponentModel.Description("A mark used to indicate the existence of a causeway.")]
        [EnumMember(Value = "Causeway Mark")]
        CausewayMark = 62,
        [System.ComponentModel.Description("A surface following buoy used to measure wave activity.")]
        [EnumMember(Value = "Wave Recorder")]
        WaveRecorder = 63,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum depthUnits : int {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        [EnumMember(Value = "Metres")]
        Metres = 1,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPatrolArea : int {
        [System.ComponentModel.Description("501:4W disposition grid (missing definition)")]
        [EnumMember(Value = "4W disposition grid")]
        fourwDispositionGrid = 501,
        [System.ComponentModel.Description("502:Operational/Naval Patrol (missing definition)")]
        [EnumMember(Value = "Operational/Naval Patrol")]
        OperationalNavalPatrol = 502,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum gradient : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("501:Steep (missing definition)")]
        [EnumMember(Value = "Steep")]
        Steep = 501,
        [System.ComponentModel.Description("502:Moderate (missing definition)")]
        [EnumMember(Value = "Moderate")]
        Moderate = 502,
        [System.ComponentModel.Description("503:Gentle (missing definition)")]
        [EnumMember(Value = "Gentle")]
        Gentle = 503,
        [System.ComponentModel.Description("504:Mild (missing definition)")]
        [EnumMember(Value = "Mild")]
        Mild = 504,
        [System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
        [EnumMember(Value = "Flat")]
        Flat = 505,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum cardinalPointOrientation : int {
        [System.ComponentModel.Description("501:north/south (missing definition)")]
        [EnumMember(Value = "north/south")]
        NorthSouth = 501,
        [System.ComponentModel.Description("502:east/west (missing definition)")]
        [EnumMember(Value = "east/west")]
        EastWest = 502,
        [System.ComponentModel.Description("503:northeast/southwest (missing definition)")]
        [EnumMember(Value = "northeast/southwest")]
        NortheastSouthwest = 503,
        [System.ComponentModel.Description("504:northwest/southeast (missing definition)")]
        [EnumMember(Value = "northwest/southeast")]
        NorthwestSoutheast = 504,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRestrictedArea : int {
        [System.ComponentModel.Description("The area around an offshore installation within which vessels are prohibited from entering without permission. Special regulations protect installations within a safety zone and vessels of all nationalities are required to respect the zone.")]
        [EnumMember(Value = "Offshore Safety Zone")]
        OffshoreSafetyZone = 1,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
        [EnumMember(Value = "Nature Reserve")]
        NatureReserve = 4,
        [System.ComponentModel.Description("A place where birds are bred and protected.")]
        [EnumMember(Value = "Bird Sanctuary")]
        BirdSanctuary = 5,
        [System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
        [EnumMember(Value = "Game Reserve")]
        GameReserve = 6,
        [System.ComponentModel.Description("A place where seals are protected.")]
        [EnumMember(Value = "Seal Sanctuary")]
        SealSanctuary = 7,
        [System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the seabed in the range and there are cables leading from the range to a control position ashore.")]
        [EnumMember(Value = "Degaussing Range")]
        DegaussingRange = 8,
        [System.ComponentModel.Description("An area controlled by the military in which restrictions may apply.")]
        [EnumMember(Value = "Military Area")]
        MilitaryArea = 9,
        [System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
        [EnumMember(Value = "Historic Wreck Area")]
        HistoricWreckArea = 10,
        [System.ComponentModel.Description("An area around a navigational aid which vessels are prohibited from entering.")]
        [EnumMember(Value = "Navigational Aid Safety Zone")]
        NavigationalAidSafetyZone = 12,
        [System.ComponentModel.Description("An area laid and maintained with explosive mines for defence or practice purposes.")]
        [EnumMember(Value = "Minefield")]
        Minefield = 14,
        [System.ComponentModel.Description("An area in which people may swim and therefore vessel movement may be restricted.")]
        [EnumMember(Value = "Swimming Area")]
        SwimmingArea = 18,
        [System.ComponentModel.Description("An area reserved for vessels waiting to enter a harbour.")]
        [EnumMember(Value = "Waiting Area")]
        WaitingArea = 19,
        [System.ComponentModel.Description("An area where marine research takes place.")]
        [EnumMember(Value = "Research Area")]
        ResearchArea = 20,
        [System.ComponentModel.Description("An area where dredging is taking place.")]
        [EnumMember(Value = "Dredging Area")]
        DredgingArea = 21,
        [System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
        [EnumMember(Value = "Fish Sanctuary")]
        FishSanctuary = 22,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        [EnumMember(Value = "Ecological Reserve")]
        EcologicalReserve = 23,
        [System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
        [EnumMember(Value = "No Wake Area")]
        NoWakeArea = 24,
        [System.ComponentModel.Description("An area where vessels turn.")]
        [EnumMember(Value = "Swinging Area")]
        SwingingArea = 25,
        [System.ComponentModel.Description("A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.")]
        [EnumMember(Value = "Environmentally Sensitive Sea Area")]
        EnvironmentallySensitiveSeaArea = 27,
        [System.ComponentModel.Description("An area that needs special protection through action by IMO because of its significance for regional ecological, socio-economic or scientific reasons and because it may be vulnerable to damage by international shipping activities.")]
        [EnumMember(Value = "Particularly Sensitive Sea Area")]
        ParticularlySensitiveSeaArea = 28,
        [System.ComponentModel.Description("An area near a fairway where vessels can go to clear the way or make an about turn and possibly return to a waiting area when nautical conditions impose it.")]
        [EnumMember(Value = "Disengagement Area")]
        DisengagementArea = 29,
        [System.ComponentModel.Description("An area in which defence, law and treaty enforcement, and counter-terrorism activities that fall within the port and maritime domain apply.")]
        [EnumMember(Value = "Port Security Area")]
        PortSecurityArea = 30,
        [System.ComponentModel.Description("A place where coral is protected.")]
        [EnumMember(Value = "Coral Sanctuary")]
        CoralSanctuary = 31,
        [System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
        [EnumMember(Value = "Recreation Area")]
        RecreationArea = 32,
        [System.ComponentModel.Description("An area within which notification is required between respective military authorities of future military exercises/activities.")]
        [EnumMember(Value = "Maritime Notification Area")]
        MaritimeNotificationArea = 501,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum expositionOfSounding : int {
        [System.ComponentModel.Description("The depth corresponds to the depth range of the surrounding depth area; that is, the depth is not shoaler than the minimum depth of the surrounding depth area or deeper than the maximum depth of the surrounding depth area.")]
        [EnumMember(Value = "Within the Range of Depth of the Surrounding Depth Area")]
        WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,
        [System.ComponentModel.Description("The depth is shoaler than the minimum depth of the surrounding depth area.")]
        [EnumMember(Value = "Shoaler Than the Range of Depth of the Surrounding Depth Area")]
        ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,
        [System.ComponentModel.Description("The depth is deeper than the maximum depth of the surrounding depth area.")]
        [EnumMember(Value = "Deeper Than the Range of Depth of the Surrounding Depth Area")]
        DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum controlledAirspaceClassDesignation : int {
        [System.ComponentModel.Description("501:A (missing definition)")]
        [EnumMember(Value = "A")]
        A = 501,
        [System.ComponentModel.Description("502:B (missing definition)")]
        [EnumMember(Value = "B")]
        B = 502,
        [System.ComponentModel.Description("503:C (missing definition)")]
        [EnumMember(Value = "C")]
        C = 503,
        [System.ComponentModel.Description("504:D (missing definition)")]
        [EnumMember(Value = "D")]
        D = 504,
        [System.ComponentModel.Description("505:E (missing definition)")]
        [EnumMember(Value = "E")]
        E = 505,
        [System.ComponentModel.Description("506:F (missing definition)")]
        [EnumMember(Value = "F")]
        F = 506,
        [System.ComponentModel.Description("507:G (missing definition)")]
        [EnumMember(Value = "G")]
        G = 507,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum statusOfSmallBottomObject : int {
        [System.ComponentModel.Description("504:Identified (NOMBO) (missing definition)")]
        [EnumMember(Value = "Identified (NOMBO)")]
        IdentifiedNombo = 504,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum buoyShape : int {
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.")]
        [EnumMember(Value = "Conical")]
        Conical = 1,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.")]
        [EnumMember(Value = "Can")]
        Can = 2,
        [System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
        [EnumMember(Value = "Spherical")]
        Spherical = 3,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.")]
        [EnumMember(Value = "Pillar")]
        Pillar = 4,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.")]
        [EnumMember(Value = "Spar")]
        Spar = 5,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.")]
        [EnumMember(Value = "Barrel")]
        Barrel = 6,
        [System.ComponentModel.Description("A very large buoy designed to carry a signal light of high luminous intensity at a high elevation.")]
        [EnumMember(Value = "Superbuoy")]
        Superbuoy = 7,
        [System.ComponentModel.Description("A specially constructed shuttle shaped buoy which is used in ice conditions.")]
        [EnumMember(Value = "Ice Buoy")]
        IceBuoy = 8,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum heightLengthUnits : int {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        [EnumMember(Value = "Metres")]
        Metres = 1,
        [System.ComponentModel.Description("A unit of length equal to 12 inches, 1/6 of a fathom, or 30.480 centimetres.")]
        [EnumMember(Value = "Feet")]
        Feet = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRadioStation : int {
        [System.ComponentModel.Description("1:circular (non-directional) marine or aero-marine radiobeacon (missing definition)")]
        [EnumMember(Value = "circular (non-directional) marine or aero-marine radiobeacon")]
        CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,
        [System.ComponentModel.Description("A special type of radiobeacon station the emissions of which are intended to provide a definite track for guidance.")]
        [EnumMember(Value = "Directional Radiobeacon")]
        DirectionalRadiobeacon = 2,
        [System.ComponentModel.Description("A special type of radiobeacon station emitting a beam of waves to which a uniform turning movement is given, the bearing of the station being determined by means of an ordinary listening receiver and a stop watch. Also referred to as a rotating loop radiobeacon.")]
        [EnumMember(Value = "Rotating Pattern Radiobeacon")]
        RotatingPatternRadiobeacon = 3,
        [System.ComponentModel.Description("A type of long range position fixing beacon.")]
        [EnumMember(Value = "Consol Beacon")]
        ConsolBeacon = 4,
        [System.ComponentModel.Description("5:radio direction-finding station (missing definition)")]
        [EnumMember(Value = "radio direction-finding station")]
        RadioDirectionFindingStation = 5,
        [System.ComponentModel.Description("A radio station which is prepared to provide QTG service; that is to say, to transmit upon request from a ship a radio signal, the bearing of which can be taken by that ship.")]
        [EnumMember(Value = "Coast Radio Station Providing QTG Service")]
        CoastRadioStationProvidingQtgService = 6,
        [System.ComponentModel.Description("A radio beacon designed for aeronautical use.")]
        [EnumMember(Value = "Aeronautical Radiobeacon")]
        AeronauticalRadiobeacon = 7,
        [System.ComponentModel.Description("The Decca Navigator System is a high accuracy, short to medium range radio navigational aid intended for coastal and landfall navigation.")]
        [EnumMember(Value = "Decca")]
        Decca = 8,
        [System.ComponentModel.Description("9:Loran-C (missing definition)")]
        [EnumMember(Value = "Loran-C")]
        LoranC = 9,
        [System.ComponentModel.Description("Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.")]
        [EnumMember(Value = "Differential GNSS")]
        DifferentialGnss = 10,
        [System.ComponentModel.Description("An electronic position fixing system used mainly by aircraft.")]
        [EnumMember(Value = "Toran")]
        Toran = 11,
        [System.ComponentModel.Description("A long-range radio navigational aid which operates within the VLF frequency band. The system comprises eight land based stations.")]
        [EnumMember(Value = "Omega")]
        Omega = 12,
        [System.ComponentModel.Description("A ranging position fixing system operating at 420-450 MHz over a range of up to 400 Km.")]
        [EnumMember(Value = "Syledis")]
        Syledis = 13,
        [System.ComponentModel.Description("A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
        [EnumMember(Value = "Chaika")]
        Chaika = 14,
        [System.ComponentModel.Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
        [EnumMember(Value = "Radio Telephone Station")]
        RadioTelephoneStation = 19,
        [System.ComponentModel.Description("An onshore AIS unit that monitors traffic in the waterways.")]
        [EnumMember(Value = "AIS Base Station")]
        AisBaseStation = 20,
        [System.ComponentModel.Description("504:Distance Measuring Equipment (DME) (missing definition)")]
        [EnumMember(Value = "Distance Measuring Equipment (DME)")]
        DistanceMeasuringEquipmentDme = 504,
        [System.ComponentModel.Description("505:Non-directional Radio Beacon (NDB) (missing definition)")]
        [EnumMember(Value = "Non-directional Radio Beacon (NDB)")]
        NonDirectionalRadioBeaconNdb = 505,
        [System.ComponentModel.Description("506:Radar Responder Beacon (RACON) (missing definition)")]
        [EnumMember(Value = "Radar Responder Beacon (RACON)")]
        RadarResponderBeaconRacon = 506,
        [System.ComponentModel.Description("508:VHF Omni Directional Radio Range (VOR) (missing definition)")]
        [EnumMember(Value = "VHF Omni Directional Radio Range (VOR)")]
        VhfOmniDirectionalRadioRangeVor = 508,
        [System.ComponentModel.Description("509:VHF Omni Directional (VORTAC) (missing definition)")]
        [EnumMember(Value = "VHF Omni Directional (VORTAC)")]
        VhfOmniDirectionalVortac = 509,
        [System.ComponentModel.Description("510:Tactical Air Navigation Equipment (TACAN) (missing definition)")]
        [EnumMember(Value = "Tactical Air Navigation Equipment (TACAN)")]
        TacticalAirNavigationEquipmentTacan = 510,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRescueStation : int {
        [System.ComponentModel.Description("A place where equipment for saving life at sea is maintained; the type of lifeboat may vary from fast, long distance boats to inflatable inshore boats.")]
        [EnumMember(Value = "Rescue Station with Lifeboat")]
        RescueStationWithLifeboat = 1,
        [System.ComponentModel.Description("A life saving station equipped with line-carrying rocket apparatus.")]
        [EnumMember(Value = "Rescue Station with Rocket")]
        RescueStationWithRocket = 2,
        [System.ComponentModel.Description("Shelter or protection from danger or distress at sea.")]
        [EnumMember(Value = "Refuge for Shipwrecked Mariners")]
        RefugeForShipwreckedMariners = 4,
        [System.ComponentModel.Description("Shelter or protection from danger in areas exposed to extreme and sudden tides or tidal streams.")]
        [EnumMember(Value = "Refuge for Intertidal Area Walkers")]
        RefugeForIntertidalAreaWalkers = 5,
        [System.ComponentModel.Description("A place where a lifeboat is moored ready for use.")]
        [EnumMember(Value = "Lifeboat Lying at a Mooring")]
        LifeboatLyingAtAMooring = 6,
        [System.ComponentModel.Description("A radio station reserved for emergency situations; might also be a public telephone.")]
        [EnumMember(Value = "Aid Radio Station")]
        AidRadioStation = 7,
        [System.ComponentModel.Description("A place where first aid equipment is available.")]
        [EnumMember(Value = "First Aid Equipment")]
        FirstAidEquipment = 8,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum product : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("A thick, slippery liquid that will not dissolve in water, usually petroleum based in the context of storage tanks.")]
        [EnumMember(Value = "Oil")]
        Oil = 1,
        [System.ComponentModel.Description("A substance with particles that can move freely, usually a fuel substance in the context of storage tanks.")]
        [EnumMember(Value = "Gas")]
        Gas = 2,
        [System.ComponentModel.Description("A colourless, odourless, tasteless liquid that is a compound of hydrogen and oxygen.")]
        [EnumMember(Value = "Water")]
        Water = 3,
        [System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
        [EnumMember(Value = "Stone")]
        Stone = 4,
        [System.ComponentModel.Description("A hard black mineral that is burned as fuel.")]
        [EnumMember(Value = "Coal")]
        Coal = 5,
        [System.ComponentModel.Description("A solid rock or mineral from which metal is obtained.")]
        [EnumMember(Value = "Ore")]
        Ore = 6,
        [System.ComponentModel.Description("Any substance obtained by or used in a chemical process.")]
        [EnumMember(Value = "Chemicals")]
        Chemicals = 7,
        [System.ComponentModel.Description("Water that is suitable for human consumption.")]
        [EnumMember(Value = "Drinking Water")]
        DrinkingWater = 8,
        [System.ComponentModel.Description("A white fluid secreted by female mammals as food for their young.")]
        [EnumMember(Value = "Milk")]
        Milk = 9,
        [System.ComponentModel.Description("A mineral from which aluminum is obtained.")]
        [EnumMember(Value = "Bauxite")]
        Bauxite = 10,
        [System.ComponentModel.Description("A solid substance obtained after gas and tar have been extracted from coal, used as a fuel.")]
        [EnumMember(Value = "Coke")]
        Coke = 11,
        [System.ComponentModel.Description("An oblong lump of cast iron metal.")]
        [EnumMember(Value = "Iron Ingots")]
        IronIngots = 12,
        [System.ComponentModel.Description("Sodium chloride obtained from mines or by the evaporation of sea water.")]
        [EnumMember(Value = "Salt")]
        Salt = 13,
        [System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
        [EnumMember(Value = "Sand")]
        Sand = 14,
        [System.ComponentModel.Description("Wood prepared for use in building or carpentry.")]
        [EnumMember(Value = "Timber")]
        Timber = 15,
        [System.ComponentModel.Description("16:sawdust/wood chips (missing definition)")]
        [EnumMember(Value = "sawdust/wood chips")]
        SawdustWoodChips = 16,
        [System.ComponentModel.Description("Discarded metal suitable for being reprocessed.")]
        [EnumMember(Value = "Scrap Metal")]
        ScrapMetal = 17,
        [System.ComponentModel.Description("18:liquefied natural gas (LNG) (missing definition)")]
        [EnumMember(Value = "liquefied natural gas (LNG)")]
        LiquefiedNaturalGasLng = 18,
        [System.ComponentModel.Description("A compressed gas consisting of flammable light hydrocarbons and derived from petroleum.")]
        [EnumMember(Value = "Liquefied Petroleum Gas")]
        LiquefiedPetroleumGas = 19,
        [System.ComponentModel.Description("The fermented juice of grapes.")]
        [EnumMember(Value = "Wine")]
        Wine = 20,
        [System.ComponentModel.Description("A substance made of powdered lime and clay, mixed with water.")]
        [EnumMember(Value = "Cement")]
        Cement = 21,
        [System.ComponentModel.Description("A small hard seed, especially that of any cereal plant such as wheat, rice, corn, rye etc.")]
        [EnumMember(Value = "Grain")]
        Grain = 22,
        [System.ComponentModel.Description("Electric charge or current.")]
        [EnumMember(Value = "Electricity")]
        Electricity = 23,
        [System.ComponentModel.Description("The solid form of water.")]
        [EnumMember(Value = "Ice")]
        Ice = 24,
        [System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
        [EnumMember(Value = "Clay")]
        Clay = 25,
        [System.ComponentModel.Description("Solid fuel: material wherein the particles firmly cohere; is hard and compact; and is burnt as a source of heat or power.")]
        [EnumMember(Value = "Solid Fuel")]
        SolidFuel = 502,
        [System.ComponentModel.Description("Flammable liquids and gases: a substance which is either; in a state where molecules move freely about one another but do not fly apart; or in a condition in which it has no definite boundaries or fixed volume; but which is combustible under normal atmospheric conditions.")]
        [EnumMember(Value = "Flammable Liquids And Gases")]
        FlammableLiquidsAndGases = 503,
        [System.ComponentModel.Description("Ferrous elements and ores: unrefined and refined: a chemically inseparable substance or solid naturally occurring mineral aggregate, from which one or more valuable constituents may be recovered by treatment or a manufacturing process, and which does contain iron in its trivalent form.")]
        [EnumMember(Value = "Ferrous Elements And Ores")]
        FerrousElementsAndOres = 505,
        [System.ComponentModel.Description("Non ferrous elements and ores: unrefined and refined: A chemically inseparable substance or solid naturally occurring mineral aggregate, from which one or more valuable constituents may be recovered by treatment or a manufacturing process, and which does not contain iron in its trivalent form.")]
        [EnumMember(Value = "Non Ferrous Elements And Ores")]
        NonFerrousElementsAndOres = 506,
        [System.ComponentModel.Description("Constructed from metal.")]
        [EnumMember(Value = "Metal")]
        Metal = 507,
        [System.ComponentModel.Description("Substances produced by a process of in-organic nature; a substance neither animal or vegetable. Normally obtained by mining.")]
        [EnumMember(Value = "Minerals")]
        Minerals = 508,
        [System.ComponentModel.Description("Natural and Chemical: a substance added to the soil to increase its productivity. It may be produced by or pertaining to nature; not the work of man; or which may be formed from a substance or resulting from a reaction involving changes to atoms or molecules.")]
        [EnumMember(Value = "Fertiliser")]
        Fertiliser = 509,
        [System.ComponentModel.Description("Unprocessed and Products: the substance of trees. In unprocessed form, the wood has not undergone change by a method of manufacture into products, being the manufacture of goods or commodities from wood.")]
        [EnumMember(Value = "Wood")]
        Wood = 510,
        [System.ComponentModel.Description("Unprocessed and Products: Strong waterproof elastic material, originally made from the dried sap of a tropical tree, now usually synthetic. In unprocessed form, the rubber has not undergone change by a method of manufacture into products, being the manufacture of goods or commodities from rubber.")]
        [EnumMember(Value = "Rubber")]
        Rubber = 511,
        [System.ComponentModel.Description("513:natural fibres and materials in general (missing definition)")]
        [EnumMember(Value = "natural fibres and materials in general")]
        NaturalFibresAndMaterialsInGeneral = 513,
        [System.ComponentModel.Description("514:foodstuffs, solid (missing definition)")]
        [EnumMember(Value = "foodstuffs, solid")]
        FoodstuffsSolid = 514,
        [System.ComponentModel.Description("515:foodstuffs, liquid (missing definition)")]
        [EnumMember(Value = "foodstuffs, liquid")]
        FoodstuffsLiquid = 515,
        [System.ComponentModel.Description("516:foodstuffs, preserved (missing definition)")]
        [EnumMember(Value = "foodstuffs, preserved")]
        FoodstuffsPreserved = 516,
        [System.ComponentModel.Description("Items relating to the whole or most; not specialised; of broad overall character. Mixed; characterised by scope or variety; items combined or associated.")]
        [EnumMember(Value = "General And Mixed Goods")]
        GeneralAndMixedGoods = 517,
        [System.ComponentModel.Description("Physical matter consisting of a relatively small and hard, but usually separate particles; or in a form which is dusty or easily crumbled into tiny, loose particles.")]
        [EnumMember(Value = "Granular Or Powdery Material")]
        GranularOrPowderyMaterial = 519,
        [System.ComponentModel.Description("Machinery; apparatus usually powered by electricity designed to perform a specific task. Mechanical parts; components of vehicles or machines.")]
        [EnumMember(Value = "Machinery And Mechanical Parts")]
        MachineryAndMechanicalParts = 520,
        [System.ComponentModel.Description("That out of which anything is, or may be made; equipment or implements. Parts that may be put together.")]
        [EnumMember(Value = "Construction Materials")]
        ConstructionMaterials = 521,
        [System.ComponentModel.Description("A means of conveyance or transport especially a structure with wheels in or on which people or things are transported by land.")]
        [EnumMember(Value = "Vehicles")]
        Vehicles = 522,
        [System.ComponentModel.Description("Structure or machine for travelling in the air.")]
        [EnumMember(Value = "Aircraft")]
        Aircraft = 523,
        [System.ComponentModel.Description("A rail or set of parallel rails on which a train, tram, or rail wagon runs.")]
        [EnumMember(Value = "Railway")]
        Railway = 524,
        [System.ComponentModel.Description("Movable structures for giving shelter, normally prefabricated.")]
        [EnumMember(Value = "Portable Buildings")]
        PortableBuildings = 525,
        [System.ComponentModel.Description("Boxes for cargo transport with standardized dimensions.")]
        [EnumMember(Value = "Containers")]
        Containers = 526,
        [System.ComponentModel.Description("Devices based on the technology of the conduction of electricity in a vacuum, gas or a semiconductor.")]
        [EnumMember(Value = "Electronics")]
        Electronics = 527,
        [System.ComponentModel.Description("Constructed from plastic.")]
        [EnumMember(Value = "Plastic")]
        Plastic = 528,
        [System.ComponentModel.Description("Colouring matter, especially in liquid form for imparting colour to a surface.")]
        [EnumMember(Value = "Paint")]
        Paint = 529,
        [System.ComponentModel.Description("530:refuse (also known as rubbish/garbage/trash) and waste (missing definition)")]
        [EnumMember(Value = "refuse (also known as rubbish/garbage/trash) and waste")]
        RefuseAlsoKnownAsRubbishGarbageTrashAndWaste = 530,
        [System.ComponentModel.Description("Relating to, caused by or exhibiting radioactivity; emission of radian elements capable of spontaneously emitting alpha, beta or sometimes gamma rays by the disintegration of the nuclei of atoms")]
        [EnumMember(Value = "Radioactive Material")]
        RadioactiveMaterial = 531,
        [System.ComponentModel.Description("Military weapons, a total means of making war; defensive equipment")]
        [EnumMember(Value = "Armament")]
        Armament = 532,
        [System.ComponentModel.Description("People in general.")]
        [EnumMember(Value = "Personnel")]
        Personnel = 533,
        [System.ComponentModel.Description("534:animals (land and sea) and birds (missing definition)")]
        [EnumMember(Value = "animals (land and sea) and birds")]
        AnimalsLandAndSeaAndBirds = 534,
        [System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
        [EnumMember(Value = "Fish")]
        Fish = 535,
        [System.ComponentModel.Description("Shelled aquatic invertebrates.")]
        [EnumMember(Value = "Shellfish And Crustaceans")]
        ShellfishAndCrustaceans = 536,
        [System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
        [EnumMember(Value = "Ballast")]
        Ballast = 537,
        [System.ComponentModel.Description("Diesel oil available.")]
        [EnumMember(Value = "Diesel Oil")]
        DieselOil = 540,
        [System.ComponentModel.Description("541:petrol/gasoline (missing definition)")]
        [EnumMember(Value = "petrol/gasoline")]
        PetrolGasoline = 541,
        [System.ComponentModel.Description("Persons travelling in a means of transport operated by others.")]
        [EnumMember(Value = "Passengers")]
        Passengers = 542,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfFerry : int {
        [System.ComponentModel.Description("A ferry which may have routes that vary with weather, tide and traffic.")]
        [EnumMember(Value = "Free Moving Ferry")]
        FreeMovingFerry = 1,
        [System.ComponentModel.Description("A ferry that follows a fixed route guided by a cable.")]
        [EnumMember(Value = "Cable Ferry")]
        CableFerry = 2,
        [System.ComponentModel.Description("A winter-time ferry which crosses a lead.")]
        [EnumMember(Value = "Ice Ferry")]
        IceFerry = 3,
        [System.ComponentModel.Description("A high speed water vessel for civilian use.")]
        [EnumMember(Value = "High Speed Ferry")]
        HighSpeedFerry = 5,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfObstruction : int {
        [System.ComponentModel.Description("1:snag/stump (missing definition)")]
        [EnumMember(Value = "snag/stump")]
        SnagStump = 1,
        [System.ComponentModel.Description("A submarine structure projecting some distance above the seabed and capping a temporarily abandoned or suspended oil or gas well.")]
        [EnumMember(Value = "Wellhead")]
        Wellhead = 2,
        [System.ComponentModel.Description("A structure on an outfall through which liquids are discharged. The structure will usually project above the level of the outfall and can be an obstruction to navigation.")]
        [EnumMember(Value = "Diffuser")]
        Diffuser = 3,
        [System.ComponentModel.Description("A permanent marine structure usually designed to support or elevate pipelines; especially a structure enclosing a screening device at the offshore end of a potable water intake pipe. The structure is commonly a heavy timber enclosure that has been sunken with rocks or other debris.")]
        [EnumMember(Value = "Crib")]
        Crib = 4,
        [System.ComponentModel.Description("Areas established by private interests, usually sport fishermen, to simulate natural reefs and wrecks that attract fish. The reefs are constructed by dumping assorted junk in areas which may be of very small extent or may stretch a considerable distance along a depth contour.")]
        [EnumMember(Value = "Fish Haven")]
        FishHaven = 5,
        [System.ComponentModel.Description("An area of numerous unidentified dangers to navigation. The area serves as a warning to the mariner that all dangers are not identified individually and that navigation through the area may be hazardous.")]
        [EnumMember(Value = "Foul Area")]
        FoulArea = 6,
        [System.ComponentModel.Description("Floating barriers, anchored to the bottom, used to deflect the path of floating ice in order to prevent the obstruction of locks, intakes, etc., and to prevent damage to bridge piers and other structures.")]
        [EnumMember(Value = "Ice Boom")]
        IceBoom = 8,
        [System.ComponentModel.Description("Equipment such as anchors, concrete blocks, chains and cables, etc., used to position floating structures such as trot and mooring buoys etc.")]
        [EnumMember(Value = "Ground Tackle")]
        GroundTackle = 9,
        [System.ComponentModel.Description("A floating barrier used to protect a river or harbour mouth or to create a sheltered area for storage purposes.")]
        [EnumMember(Value = "Boom")]
        Boom = 10,
        [System.ComponentModel.Description("A device to extract energy from the surface motion of ocean waves or from pressure fluctuations below the surface.")]
        [EnumMember(Value = "Wave Energy Device")]
        WaveEnergyDevice = 12,
        [System.ComponentModel.Description("13:subsurface ocean data acquisition system (ODAS) (missing definition)")]
        [EnumMember(Value = "subsurface ocean data acquisition system (ODAS)")]
        SubsurfaceOceanDataAcquisitionSystemOdas = 13,
        [System.ComponentModel.Description("A man-made structure that may mimic some of the characteristics of a natural reef, intended to attract sea life.")]
        [EnumMember(Value = "Artificial Reef")]
        ArtificialReef = 14,
        [System.ComponentModel.Description("A structure placed on the seafloor below a drilling rig to guide the drill.")]
        [EnumMember(Value = "Template")]
        Template = 15,
        [System.ComponentModel.Description("A large steel structure up to 20 metres in height above the seafloor, or a steel frame secured to the seafloor with piles to anchor the end of a submarine pipeline, for delivery to a production platform.")]
        [EnumMember(Value = "Manifold")]
        Manifold = 16,
        [System.ComponentModel.Description("A hill of soil-covered ice pushed up by hydrostatic pressure in an area of permafrost that is located underwater.")]
        [EnumMember(Value = "Submerged Pingo")]
        SubmergedPingo = 17,
        [System.ComponentModel.Description("The distributed remains of a platform.")]
        [EnumMember(Value = "Remains of Platform")]
        RemainsOfPlatform = 18,
        [System.ComponentModel.Description("An instrument used for scientific purposes.")]
        [EnumMember(Value = "Scientific Instrument")]
        ScientificInstrument = 19,
        [System.ComponentModel.Description("Any of various machines having a rotor, usually with vanes or blades, driven by the pressure, momentum, or reactive thrust of a moving fluid, as steam, water, hot gases, or air, either occurring in the form of free jets or as a fluid passing through and entirely filling a housing around the rotor and is located underwater.")]
        [EnumMember(Value = "Underwater Turbine")]
        UnderwaterTurbine = 20,
        [System.ComponentModel.Description("An active seabed volcano, which may be submerged or projecting above the water at the chart sounding datum.")]
        [EnumMember(Value = "Active Submarine Volcano")]
        ActiveSubmarineVolcano = 21,
        [System.ComponentModel.Description("A submerged net placed around beaches to reduce shark attacks on swimmers.")]
        [EnumMember(Value = "Shark Net")]
        SharkNet = 22,
        [System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
        [EnumMember(Value = "Mangrove")]
        Mangrove = 23,
        [System.ComponentModel.Description("a structure, typically a dome or cube, erected over a wellhead or equipment attached to it (a tree) to lessen the danger of vessels snagging gear. (AML)")]
        [EnumMember(Value = "Well Protection Structure")]
        WellProtectionStructure = 501,
        [System.ComponentModel.Description("any oil or gas related installation or structure on, or projecting from, the seabed, for example a submerged platform or concrete foundations. (AML)")]
        [EnumMember(Value = "Subsea Installation")]
        SubseaInstallation = 502,
        [System.ComponentModel.Description("any pipeline related structure which projects above the seabed, for example a  joint, T-piece, valve or sleeve, or a crossing where one pipeline is raised over another by means of a supporting structure. (AML)")]
        [EnumMember(Value = "Pipeline Obstruction")]
        PipelineObstruction = 503,
        [System.ComponentModel.Description("504:free standing conductor pipe (missing definition)")]
        [EnumMember(Value = "free standing conductor pipe")]
        FreeStandingConductorPipe = 504,
        [System.ComponentModel.Description("large seabed structures, typically made of concrete, capable of storing oil or gas and usually found attached or adjacent to a rig, or marked by a single point mooring buoy. (AML)")]
        [EnumMember(Value = "Storage Tank")]
        StorageTank = 506,
        [System.ComponentModel.Description("A floating structure, usually rectangular in shape which serves as landing, pier head, bridge support, etc.")]
        [EnumMember(Value = "Pontoon")]
        Pontoon = 508,
        [System.ComponentModel.Description("miscellaneous items and objects, most of which have been lost overboard or otherwise abandoned to the sea, for example cargo containers or vehicles. (AML)")]
        [EnumMember(Value = "Sundry Objects")]
        SundryObjects = 509,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum restriction : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("An area within which anchoring is not permitted.")]
        [EnumMember(Value = "Anchoring Prohibited")]
        AnchoringProhibited = 1,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which anchoring is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Anchoring Restricted")]
        AnchoringRestricted = 2,
        [System.ComponentModel.Description("An area within which fishing is not permitted.")]
        [EnumMember(Value = "Fishing Prohibited")]
        FishingProhibited = 3,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which fishing is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Fishing Restricted")]
        FishingRestricted = 4,
        [System.ComponentModel.Description("An area within which trawling is not permitted.")]
        [EnumMember(Value = "Trawling Prohibited")]
        TrawlingProhibited = 5,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which trawling is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Trawling Restricted")]
        TrawlingRestricted = 6,
        [System.ComponentModel.Description("An area within which navigation and/or anchoring is prohibited.")]
        [EnumMember(Value = "Entry Prohibited")]
        EntryProhibited = 7,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Entry Restricted")]
        EntryRestricted = 8,
        [System.ComponentModel.Description("An area within which dredging is not permitted.")]
        [EnumMember(Value = "Dredging Prohibited")]
        DredgingProhibited = 9,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which dredging is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Dredging Restricted")]
        DredgingRestricted = 10,
        [System.ComponentModel.Description("An area within which diving is not permitted.")]
        [EnumMember(Value = "Diving Prohibited")]
        DivingProhibited = 11,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which diving is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Diving Restricted")]
        DivingRestricted = 12,
        [System.ComponentModel.Description("Mariners must adjust the speed of their vessels to reduce the wave or wash which may cause erosion or disturb moored vessels.")]
        [EnumMember(Value = "No Wake")]
        NoWake = 13,
        [System.ComponentModel.Description("An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.")]
        [EnumMember(Value = "Area To Be Avoided")]
        AreaToBeAvoided = 14,
        [System.ComponentModel.Description("The erection of permanent or temporary fixed structures or artificial islands is prohibited.")]
        [EnumMember(Value = "Construction Prohibited")]
        ConstructionProhibited = 15,
        [System.ComponentModel.Description("An area within which discharging or dumping is prohibited.")]
        [EnumMember(Value = "Discharging Prohibited")]
        DischargingProhibited = 16,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which discharging or dumping is restricted in accordance with specified conditions.")]
        [EnumMember(Value = "Discharging Restricted")]
        DischargingRestricted = 17,
        [System.ComponentModel.Description("18:industrial or mineral (missing definition)")]
        [EnumMember(Value = "industrial or mineral 18")]
        IndustrialOrMineral18 = 18,
        [System.ComponentModel.Description("19:industrial or mineral (missing definition)")]
        [EnumMember(Value = "industrial or mineral 19")]
        IndustrialOrMineral19 = 19,
        [System.ComponentModel.Description("An area within which excavating a hole on the seabed with a drill is prohibited.")]
        [EnumMember(Value = "Drilling Prohibited")]
        DrillingProhibited = 20,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the seabed with a drill is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Drilling Restricted")]
        DrillingRestricted = 21,
        [System.ComponentModel.Description("22:removal of historic (missing definition)")]
        [EnumMember(Value = "removal of historic")]
        RemovalOfHistoric = 22,
        [System.ComponentModel.Description("23:cargo transhipment (lightening) prohibited (missing definition)")]
        [EnumMember(Value = "cargo transhipment (lightening) prohibited")]
        CargoTranshipmentLighteningProhibited = 23,
        [System.ComponentModel.Description("An area in which the dragging of anything along the seabed, for example bottom trawling, is prohibited.")]
        [EnumMember(Value = "Dragging Prohibited")]
        DraggingProhibited = 24,
        [System.ComponentModel.Description("An area in which a vessel is prohibited from stopping.")]
        [EnumMember(Value = "Stopping Prohibited")]
        StoppingProhibited = 25,
        [System.ComponentModel.Description("An area in which landing is prohibited.")]
        [EnumMember(Value = "Landing Prohibited")]
        LandingProhibited = 26,
        [System.ComponentModel.Description("An area within which speed is restricted.")]
        [EnumMember(Value = "Speed Restricted")]
        SpeedRestricted = 27,
        [System.ComponentModel.Description("An area in which swimming is prohibited.")]
        [EnumMember(Value = "Swimming Prohibited")]
        SwimmingProhibited = 39,
        [System.ComponentModel.Description("42:power-driven vessels (missing definition)")]
        [EnumMember(Value = "power-driven vessels")]
        PowerDrivenVessels = 42,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofMilitaryPracticeArea : int {
        [System.ComponentModel.Description("An area within which exercises are carried out with torpedoes.")]
        [EnumMember(Value = "Torpedo Exercise Area")]
        TorpedoExerciseArea = 2,
        [System.ComponentModel.Description("An area within which submarine exercises are carried out.")]
        [EnumMember(Value = "Submarine Exercise Area")]
        SubmarineExerciseArea = 3,
        [System.ComponentModel.Description("Areas for bombing and missile exercises.")]
        [EnumMember(Value = "Firing Danger Area")]
        FiringDangerArea = 4,
        [System.ComponentModel.Description("5:mine-laying practice area (missing definition)")]
        [EnumMember(Value = "mine-laying practice area")]
        MineLayingPracticeArea = 5,
        [System.ComponentModel.Description("The ACLANT (Allied Command Atlantic) submarine grid provides NATO submarine operating authorities with a common grid for the water space management of NATO submarines.")]
        [EnumMember(Value = "ACLANT grid")]
        AclantGrid = 501,
        [System.ComponentModel.Description("An area in which certain activities or factors of significance to surface navigation or operations apply.")]
        [EnumMember(Value = "Surface Danger Area")]
        SurfaceDangerArea = 502,
        [System.ComponentModel.Description("503:JMC Areas - JENOA grid (missing definition)")]
        [EnumMember(Value = "JMC Areas - JENOA grid")]
        JmcAreasJenoaGrid = 503,
        [System.ComponentModel.Description("506:safe bottoming area (missing definition)")]
        [EnumMember(Value = "safe bottoming area")]
        SafeBottomingArea = 506,
        [System.ComponentModel.Description("An area in which submarine operations are prohibited or limited, owing to the existence of hazards to dived submarines.")]
        [EnumMember(Value = "Submarine Danger Area")]
        SubmarineDangerArea = 507,
        [System.ComponentModel.Description("A specified zone for the provision of sonar calibration or other underwater testing.")]
        [EnumMember(Value = "Testing and Evaluation Range")]
        TestingAndEvaluationRange = 508,
        [System.ComponentModel.Description("510:Impact area (missing definition)")]
        [EnumMember(Value = "Impact area")]
        ImpactArea = 510,
        [System.ComponentModel.Description("An area used for live firing of weapons to bombard a designated area.")]
        [EnumMember(Value = "Live Fire Range")]
        LiveFireRange = 599,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum sonarSignalStrength : int {
        [System.ComponentModel.Description("501:nil (missing definition)")]
        [EnumMember(Value = "nil")]
        Nil = 501,
        [System.ComponentModel.Description("Not as good as it could be or should.")]
        [EnumMember(Value = "Poor")]
        Poor = 502,
        [System.ComponentModel.Description("503:moderate (missing definition)")]
        [EnumMember(Value = "moderate")]
        Moderate = 503,
        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        [EnumMember(Value = "Strong")]
        Strong = 504,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristics : int {
        [System.ComponentModel.Description("The maximum length of the ship.")]
        [EnumMember(Value = "Length Overall")]
        LengthOverall = 1,
        [System.ComponentModel.Description("The ship's length measured at the waterline.")]
        [EnumMember(Value = "Length at Waterline")]
        LengthAtWaterline = 2,
        [System.ComponentModel.Description("The width or beam of the vessel.")]
        [EnumMember(Value = "Breadth")]
        Breadth = 3,
        [System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded.")]
        [EnumMember(Value = "Draught")]
        Draught = 4,
        [System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement.")]
        [EnumMember(Value = "Displacement Tonnage")]
        DisplacementTonnage = 6,
        [System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.")]
        [EnumMember(Value = "Gross Tonnage")]
        GrossTonnage = 10,
        [System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.")]
        [EnumMember(Value = "Net Tonnage")]
        NetTonnage = 11,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lastSensor : int {
        [System.ComponentModel.Description("501:acoustic sensor (missing definition)")]
        [EnumMember(Value = "acoustic sensor")]
        AcousticSensor = 501,
        [System.ComponentModel.Description("the object was reported as a result of detecting a fluctuation in the local magnetic field.")]
        [EnumMember(Value = "Magnetic Sensor")]
        MagneticSensor = 502,
        [System.ComponentModel.Description("503:video sensor (missing definition)")]
        [EnumMember(Value = "video sensor")]
        VideoSensor = 503,
        [System.ComponentModel.Description("504:diver sighting (found by diver - in registry) (missing definition)")]
        [EnumMember(Value = "diver sighting (found by diver - in registry)")]
        DiverSightingFoundByDiverInRegistry = 504,
        [System.ComponentModel.Description("506:physical snag (missing definition)")]
        [EnumMember(Value = "physical snag")]
        PhysicalSnag = 506,
        [System.ComponentModel.Description("507:observed sinking (missing definition)")]
        [EnumMember(Value = "observed sinking")]
        ObservedSinking = 507,
        [System.ComponentModel.Description("508:Reported Sinking (missing definition)")]
        [EnumMember(Value = "Reported Sinking")]
        ReportedSinking = 508,
        [System.ComponentModel.Description("509:None reported (missing definition)")]
        [EnumMember(Value = "None reported")]
        NoneReported = 509,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCoverage : int {
        [System.ComponentModel.Description("Continuous coverage of spatial objects is available within this area.")]
        [EnumMember(Value = "Coverage Available")]
        CoverageAvailable = 1,
        [System.ComponentModel.Description("An area containing no spatial objects.")]
        [EnumMember(Value = "No Coverage Available")]
        NoCoverageAvailable = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum beaconShape : int {
        [System.ComponentModel.Description("1:stake, pole, perch, post (missing definition)")]
        [EnumMember(Value = "stake, pole, perch, post")]
        StakePolePerchPost = 1,
        [System.ComponentModel.Description("A tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.")]
        [EnumMember(Value = "Withy")]
        Withy = 2,
        [System.ComponentModel.Description("A solid structure of the order of 10 metres in height used as a navigational aid.")]
        [EnumMember(Value = "Beacon Tower")]
        BeaconTower = 3,
        [System.ComponentModel.Description("A structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.")]
        [EnumMember(Value = "Lattice Beacon")]
        LatticeBeacon = 4,
        [System.ComponentModel.Description("A long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.")]
        [EnumMember(Value = "Pile Beacon")]
        PileBeacon = 5,
        [System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
        [EnumMember(Value = "Cairn")]
        Cairn = 6,
        [System.ComponentModel.Description("A tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.")]
        [EnumMember(Value = "Buoyant Beacon")]
        BuoyantBeacon = 7,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDumpingGround : int {
        [System.ComponentModel.Description("An area at sea where chemical waste is dumped.")]
        [EnumMember(Value = "Chemical Waste Dumping Ground")]
        ChemicalWasteDumpingGround = 2,
        [System.ComponentModel.Description("An area at sea where nuclear waste is dumped.")]
        [EnumMember(Value = "Nuclear Waste Dumping Ground")]
        NuclearWasteDumpingGround = 3,
        [System.ComponentModel.Description("An area at sea where explosives are dumped.")]
        [EnumMember(Value = "Explosives Dumping Ground")]
        ExplosivesDumpingGround = 4,
        [System.ComponentModel.Description("A sea area where dredged material is deposited.")]
        [EnumMember(Value = "Spoil Ground")]
        SpoilGround = 5,
        [System.ComponentModel.Description("An area at sea where disused vessels are scuttled.")]
        [EnumMember(Value = "Vessel Dumping Ground")]
        VesselDumpingGround = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAnchorage : int {
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor.")]
        [EnumMember(Value = "Unrestricted Anchorage")]
        UnrestrictedAnchorage = 1,
        [System.ComponentModel.Description("An area in which vessels of deep draught anchor or may anchor.")]
        [EnumMember(Value = "Deep Water Anchorage")]
        DeepWaterAnchorage = 2,
        [System.ComponentModel.Description("An area in which tankers anchor or may anchor.")]
        [EnumMember(Value = "Tanker Anchorage")]
        TankerAnchorage = 3,
        [System.ComponentModel.Description("An area where a vessel anchors when satisfying quarantine regulations.")]
        [EnumMember(Value = "Quarantine Anchorage")]
        QuarantineAnchorage = 5,
        [System.ComponentModel.Description("An area in which seaplanes anchor or may anchor.")]
        [EnumMember(Value = "Seaplane Anchorage")]
        SeaplaneAnchorage = 6,
        [System.ComponentModel.Description("An area in which yachts and small boats anchor or may anchor.")]
        [EnumMember(Value = "Small Craft Anchorage")]
        SmallCraftAnchorage = 7,
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor for periods of up to 24 hours.")]
        [EnumMember(Value = "Anchorage for Periods Up To 24 Hours")]
        AnchorageForPeriodsUpTo24Hours = 9,
        [System.ComponentModel.Description("An area in which vessels may anchor for a period of time not to exceed a specific limit.")]
        [EnumMember(Value = "Anchorage for a Limited Period of Time")]
        AnchorageForALimitedPeriodOfTime = 10,
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor while waiting, for example, for access to a port or berth.")]
        [EnumMember(Value = "Waiting Anchorage")]
        WaitingAnchorage = 14,
        [System.ComponentModel.Description("A location not defined by a regulatory authority that has been reported to be suitable and safe for anchoring.")]
        [EnumMember(Value = "Reported Anchorage")]
        ReportedAnchorage = 15,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum catagoryOfAirspaceRestriction : int {
        [System.ComponentModel.Description("An area designated by a proper authority, in which a danger to craft exists. Also called danger zone.")]
        [EnumMember(Value = "Danger Area")]
        DangerArea = 501,
        [System.ComponentModel.Description("(1) An area shown on charts within which navigation and/or anchoring is prohibited. (2) In aviation terminology, a specified area within the land areas of a state or territorial waters adjacent thereto over which the flight of aircraft is prohibited.")]
        [EnumMember(Value = "Prohibited Area")]
        ProhibitedArea = 502,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Restricted Area")]
        RestrictedArea = 503,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum colourPattern : int {
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented horizontally.")]
        [EnumMember(Value = "Horizontal Stripes")]
        HorizontalStripes = 1,
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented vertically.")]
        [EnumMember(Value = "Vertical Stripes")]
        VerticalStripes = 2,
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).")]
        [EnumMember(Value = "Diagonal Stripes")]
        DiagonalStripes = 3,
        [System.ComponentModel.Description("Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
        [EnumMember(Value = "Squared")]
        Squared = 4,
        [System.ComponentModel.Description("5:stripes (direction unknown) (missing definition)")]
        [EnumMember(Value = "stripes (direction unknown)")]
        StripesDirectionUnknown = 5,
        [System.ComponentModel.Description("A band or stripe of colour which is displayed around the outer edge of the feature, which may also form a border to an inner pattern or plain colour.")]
        [EnumMember(Value = "Border Stripe")]
        BorderStripe = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRadarStation : int {
        [System.ComponentModel.Description("A radar station established for traffic surveillance.")]
        [EnumMember(Value = "Radar Surveillance Station")]
        RadarSurveillanceStation = 1,
        [System.ComponentModel.Description("A shore-based station which the mariner can contact by radio to obtain a position.")]
        [EnumMember(Value = "Coast Radar Station")]
        CoastRadarStation = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfControlledAirspace : int {
        [System.ComponentModel.Description("A control area or portion thereof established in the form of a corridor equipped with radio navigation aids.")]
        [EnumMember(Value = "Airway")]
        Airway = 501,
        [System.ComponentModel.Description("502:Altimeter Setting Region (ASR) (missing definition)")]
        [EnumMember(Value = "Altimeter Setting Region (ASR)")]
        AltimeterSettingRegionAsr = 502,
        [System.ComponentModel.Description("503:Avoidance Area (AA) (missing definition)")]
        [EnumMember(Value = "Avoidance Area (AA)")]
        AvoidanceAreaAa = 503,
        [System.ComponentModel.Description("504:Control Area (CTA) (missing definition)")]
        [EnumMember(Value = "Control Area (CTA)")]
        ControlAreaCta = 504,
        [System.ComponentModel.Description("505:Control Zone (CTR/CTZ) (missing definition)")]
        [EnumMember(Value = "Control Zone (CTR/CTZ)")]
        ControlZoneCtrCtz = 505,
        [System.ComponentModel.Description("506:Flight Information Region (FIR) (missing definition)")]
        [EnumMember(Value = "Flight Information Region (FIR)")]
        FlightInformationRegionFir = 506,
        [System.ComponentModel.Description("507:Terminal Control Area (TMA/TCA) (missing definition)")]
        [EnumMember(Value = "Terminal Control Area (TMA/TCA)")]
        TerminalControlAreaTmaTca = 507,
        [System.ComponentModel.Description("508:Aerodrome Traffic Zone (ATZ) (missing definition)")]
        [EnumMember(Value = "Aerodrome Traffic Zone (ATZ)")]
        AerodromeTrafficZoneAtz = 508,
        [System.ComponentModel.Description("509:Helicopter Protection Zone (HPZ) (missing definition)")]
        [EnumMember(Value = "Helicopter Protection Zone (HPZ)")]
        HelicopterProtectionZoneHpz = 509,
        [System.ComponentModel.Description("510:Helicopter Main Route (HMR) (missing definition)")]
        [EnumMember(Value = "Helicopter Main Route (HMR)")]
        HelicopterMainRouteHmr = 510,
        [System.ComponentModel.Description("511:Helicopter Transit Corridor (HTC) (missing definition)")]
        [EnumMember(Value = "Helicopter Transit Corridor (HTC)")]
        HelicopterTransitCorridorHtc = 511,
        [System.ComponentModel.Description("512:Military Aerodrome Traffic Zone (MATZ) (missing definition)")]
        [EnumMember(Value = "Military Aerodrome Traffic Zone (MATZ)")]
        MilitaryAerodromeTrafficZoneMatz = 512,
        [System.ComponentModel.Description("513:Ocean Control Area (OCA) (missing definition)")]
        [EnumMember(Value = "Ocean Control Area (OCA)")]
        OceanControlAreaOca = 513,
        [System.ComponentModel.Description("514:Coastguard track [surveillance] (missing definition)")]
        [EnumMember(Value = "Coastguard track [surveillance]")]
        CoastguardTrackSurveillance = 514,
        [System.ComponentModel.Description("515:Military Terminal Control Area (MTCA) (missing definition)")]
        [EnumMember(Value = "Military Terminal Control Area (MTCA)")]
        MilitaryTerminalControlAreaMtca = 515,
        [System.ComponentModel.Description("516:Identification Zone (ADIZ) (missing definition)")]
        [EnumMember(Value = "Identification Zone (ADIZ)")]
        IdentificationZoneAdiz = 516,
        [System.ComponentModel.Description("517:Advisory Area (ADA) or (UDA) (missing definition)")]
        [EnumMember(Value = "Advisory Area (ADA) or (UDA)")]
        AdvisoryAreaAdaOrUda = 517,
        [System.ComponentModel.Description("518:Air Route Tradffic Control Center (ARTCC) (missing definition)")]
        [EnumMember(Value = "Air Route Tradffic Control Center (ARTCC)")]
        AirRouteTradfficControlCenterArtcc = 518,
        [System.ComponentModel.Description("519:Area Control Center (ACC) (missing definition)")]
        [EnumMember(Value = "Area Control Center (ACC)")]
        AreaControlCenterAcc = 519,
        [System.ComponentModel.Description("An airspace for which a radar service is specified")]
        [EnumMember(Value = "Radar Area")]
        RadarArea = 520,
        [System.ComponentModel.Description("521:Upper Flight Information Region (UIR) (missing definition)")]
        [EnumMember(Value = "Upper Flight Information Region (UIR)")]
        UpperFlightInformationRegionUir = 521,
        [System.ComponentModel.Description("522:Buffer Zone (BZ) (missing definition)")]
        [EnumMember(Value = "Buffer Zone (BZ)")]
        BufferZoneBz = 522,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCompleteness : int {
        [System.ComponentModel.Description("The area specified has been populated for all known features. Absence of features indicates that there are no such entities available to the data producer.")]
        [EnumMember(Value = "Complete")]
        Complete = 501,
        [System.ComponentModel.Description("Certain features have not been included (or only partially included) within the specified area. Details must be provided in supporting textual information.")]
        [EnumMember(Value = "Partial")]
        Partial = 502,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCargo : int {
        [System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel, for example oil or grain.")]
        [EnumMember(Value = "Bulk")]
        Bulk = 1,
        [System.ComponentModel.Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
        [EnumMember(Value = "Container")]
        Container = 2,
        [System.ComponentModel.Description("Break bulk cargo normally loaded by crane.")]
        [EnumMember(Value = "General")]
        General = 3,
        [System.ComponentModel.Description("Any cargo loaded by pipeline.")]
        [EnumMember(Value = "Liquid")]
        Liquid = 4,
        [System.ComponentModel.Description("A fee paying traveller.")]
        [EnumMember(Value = "Passenger")]
        Passenger = 5,
        [System.ComponentModel.Description("Live animals carried in bulk.")]
        [EnumMember(Value = "Livestock")]
        Livestock = 6,
        [System.ComponentModel.Description("Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.")]
        [EnumMember(Value = "Dangerous or Hazardous")]
        DangerousOrHazardous = 7,
        [System.ComponentModel.Description("Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.")]
        [EnumMember(Value = "Heavy Lift")]
        HeavyLift = 8,
        [System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
        [EnumMember(Value = "Ballast")]
        Ballast = 9,
        [System.ComponentModel.Description("Commodity cargo that is transported unpackaged in large quantities. These types of goods usually need to be kept dry during the whole transportation period.")]
        [EnumMember(Value = "Dry Bulk Cargo")]
        DryBulkCargo = 10,
        [System.ComponentModel.Description("Liquids or gases that are transported in bulk and carried unpackaged.")]
        [EnumMember(Value = "Liquid Bulk Cargo")]
        LiquidBulkCargo = 11,
        [System.ComponentModel.Description("Cargo transported in refrigerated containers, generally perishable commodities which require temperature-controlled transportation, such as fruit, meat, fish, vegetables, dairy products and other foods.")]
        [EnumMember(Value = "Reefer Container Cargo")]
        ReeferContainerCargo = 12,
        [System.ComponentModel.Description("13:Ro-Ro cargo (missing definition)")]
        [EnumMember(Value = "Ro-Ro cargo")]
        RoRoCargo = 13,
        [System.ComponentModel.Description("Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.")]
        [EnumMember(Value = "Project Cargo")]
        ProjectCargo = 14,
        [System.ComponentModel.Description("Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.")]
        [EnumMember(Value = "Break Bulk Cargo")]
        BreakBulkCargo = 15,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum signalStatus : int {
        [System.ComponentModel.Description("1:lit/sound (missing definition)")]
        [EnumMember(Value = "lit/sound")]
        LitSound = 1,
        [System.ComponentModel.Description("2:eclipsed/silent (missing definition)")]
        [EnumMember(Value = "eclipsed/silent")]
        EclipsedSilent = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum divingActivity : int {
        [System.ComponentModel.Description("501:Commercial Diving (missing definition)")]
        [EnumMember(Value = "Commercial Diving")]
        CommercialDiving = 501,
        [System.ComponentModel.Description("502:Sports Diving (missing definition)")]
        [EnumMember(Value = "Sports Diving")]
        SportsDiving = 502,
        [System.ComponentModel.Description("503:Dive Training (missing definition)")]
        [EnumMember(Value = "Dive Training")]
        DiveTraining = 503,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum condition : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Being built but not yet capable of function.")]
        [EnumMember(Value = "Under Construction")]
        UnderConstruction = 1,
        [System.ComponentModel.Description("A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.")]
        [EnumMember(Value = "Ruined")]
        Ruined = 2,
        [System.ComponentModel.Description("An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.")]
        [EnumMember(Value = "Under Reclamation")]
        UnderReclamation = 3,
        [System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
        [EnumMember(Value = "Planned Construction")]
        PlannedConstruction = 5,
        [System.ComponentModel.Description("completed, undamaged and working normally. ")]
        [EnumMember(Value = "Operational")]
        Operational = 501,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum nameUsage : int {
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
        [EnumMember(Value = "Default Name Display")]
        DefaultNameDisplay = 1,
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
        [EnumMember(Value = "Alternate Name Display")]
        AlternateNameDisplay = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum strengthOfMagneticAnomaly : int {
        [System.ComponentModel.Description("501:nil (missing definition)")]
        [EnumMember(Value = "nil")]
        Nil = 501,
        [System.ComponentModel.Description("502:slight (missing definition)")]
        [EnumMember(Value = "slight")]
        Slight = 502,
        [System.ComponentModel.Description("503:moderate (missing definition)")]
        [EnumMember(Value = "moderate")]
        Moderate = 503,
        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        [EnumMember(Value = "Strong")]
        Strong = 504,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfSurfaceQualifyingTerms : int {
        [System.ComponentModel.Description("Falls within the smallest size continuum for a particular nature of surface term.")]
        [EnumMember(Value = "Fine")]
        Fine = 1,
        [System.ComponentModel.Description("Falls within the moderate size continuum for a particular nature of surface term.")]
        [EnumMember(Value = "Medium")]
        Medium = 2,
        [System.ComponentModel.Description("Falls within the largest size continuum for a particular nature of surface term.")]
        [EnumMember(Value = "Coarse")]
        Coarse = 3,
        [System.ComponentModel.Description("Fractured or in pieces.")]
        [EnumMember(Value = "Broken")]
        Broken = 4,
        [System.ComponentModel.Description("Having an adhesive or glue like property.")]
        [EnumMember(Value = "Sticky")]
        Sticky = 5,
        [System.ComponentModel.Description("Not hard or firm.")]
        [EnumMember(Value = "Soft")]
        Soft = 6,
        [System.ComponentModel.Description("Not pliant; thick, resistant to flow.")]
        [EnumMember(Value = "Stiff")]
        Stiff = 7,
        [System.ComponentModel.Description("Composed of or containing material ejected from a volcano.")]
        [EnumMember(Value = "Volcanic")]
        Volcanic = 8,
        [System.ComponentModel.Description("Composed of or containing calcium or calcium carbonate.")]
        [EnumMember(Value = "Calcareous")]
        Calcareous = 9,
        [System.ComponentModel.Description("Firm; usually refers to an area of the seafloor not covered by unconsolidated sediment.")]
        [EnumMember(Value = "Hard")]
        Hard = 10,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lightCharacteristic : int {
        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
        [EnumMember(Value = "Fixed")]
        Fixed = 1,
        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        [EnumMember(Value = "Flashing")]
        Flashing = 2,
        [System.ComponentModel.Description("3:long-flashing (missing definition)")]
        [EnumMember(Value = "long-flashing")]
        LongFlashing = 3,
        [System.ComponentModel.Description("4:quick-flashing (missing definition)")]
        [EnumMember(Value = "quick-flashing")]
        QuickFlashing = 4,
        [System.ComponentModel.Description("5:very quick-flashing (missing definition)")]
        [EnumMember(Value = "very quick-flashing")]
        VeryQuickFlashing = 5,
        [System.ComponentModel.Description("6:ultra quick-flashing (missing definition)")]
        [EnumMember(Value = "ultra quick-flashing")]
        UltraQuickFlashing = 6,
        [System.ComponentModel.Description("A light with all durations of light and darkness equal.")]
        [EnumMember(Value = "Isophased")]
        Isophased = 7,
        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be: - Single-occulting: An occulting light in which an eclipse is regularly repeated. - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated. - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
        [EnumMember(Value = "Occulting")]
        Occulting = 8,
        [System.ComponentModel.Description("A light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.")]
        [EnumMember(Value = "Interrupted Ultra Quick-Flashing")]
        InterruptedUltraQuickFlashing = 11,
        [System.ComponentModel.Description("A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
        [EnumMember(Value = "Morse")]
        Morse = 12,
        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
        [EnumMember(Value = "Fixed and Flash")]
        FixedAndFlash = 13,
        [System.ComponentModel.Description("14:flash and long-flash (missing definition)")]
        [EnumMember(Value = "flash and long-flash")]
        FlashAndLongFlash = 14,
        [System.ComponentModel.Description("A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.")]
        [EnumMember(Value = "Occulting and Flash")]
        OccultingAndFlash = 15,
        [System.ComponentModel.Description("16:fixed and long-flash (missing definition)")]
        [EnumMember(Value = "fixed and long-flash")]
        FixedAndLongFlash = 16,
        [System.ComponentModel.Description("An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.")]
        [EnumMember(Value = "Occulting Alternating")]
        OccultingAlternating = 17,
        [System.ComponentModel.Description("18:long-flash alternating (missing definition)")]
        [EnumMember(Value = "long-flash alternating")]
        LongFlashAlternating = 18,
        [System.ComponentModel.Description("An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        [EnumMember(Value = "Flash Alternating")]
        FlashAlternating = 19,
        [System.ComponentModel.Description("25:quick-flash plus longflash (missing definition)")]
        [EnumMember(Value = "quick-flash plus longflash")]
        QuickFlashPlusLongflash = 25,
        [System.ComponentModel.Description("26:very quick-flash plus long-flash (missing definition)")]
        [EnumMember(Value = "very quick-flash plus long-flash")]
        VeryQuickFlashPlusLongFlash = 26,
        [System.ComponentModel.Description("27:ultra quick-flash plus (missing definition)")]
        [EnumMember(Value = "ultra quick-flash plus")]
        UltraQuickFlashPlus = 27,
        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
        [EnumMember(Value = "Alternating")]
        Alternating = 28,
        [System.ComponentModel.Description("29:fixed and alternating (missing definition)")]
        [EnumMember(Value = "fixed and alternating")]
        FixedAndAlternating = 29,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCheckpoint : int {
        [System.ComponentModel.Description("Serves as a government checkpoint where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
        [EnumMember(Value = "Custom")]
        Custom = 1,
        [System.ComponentModel.Description("501:RV Location (missing definition)")]
        [EnumMember(Value = "RV Location")]
        RvLocation = 501,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum topmarkDaymarkShape : int {
        [System.ComponentModel.Description("1:cone (point up) (missing definition)")]
        [EnumMember(Value = "cone (point up)")]
        ConePointUp = 1,
        [System.ComponentModel.Description("2:cone (point down) (missing definition)")]
        [EnumMember(Value = "cone (point down)")]
        ConePointDown = 2,
        [System.ComponentModel.Description("A curved surface all points of which are equidistant from a fixed point within, called the centre.")]
        [EnumMember(Value = "Sphere")]
        Sphere = 3,
        [System.ComponentModel.Description("4:2 spheres (missing definition)")]
        [EnumMember(Value = "2 spheres")]
        twoSpheres = 4,
        [System.ComponentModel.Description("A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, its ends being parallel circles).")]
        [EnumMember(Value = "Cylinder")]
        Cylinder = 5,
        [System.ComponentModel.Description("Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
        [EnumMember(Value = "Board")]
        Board = 6,
        [System.ComponentModel.Description("7:x-shaped (missing definition)")]
        [EnumMember(Value = "x-shaped")]
        XShaped = 7,
        [System.ComponentModel.Description("A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.")]
        [EnumMember(Value = "Upright Cross")]
        UprightCross = 8,
        [System.ComponentModel.Description("9:cube (point up) (missing definition)")]
        [EnumMember(Value = "cube (point up)")]
        CubePointUp = 9,
        [System.ComponentModel.Description("10:2 cones (point to point) (missing definition)")]
        [EnumMember(Value = "2 cones (point to point)")]
        twoConesPointToPoint = 10,
        [System.ComponentModel.Description("11:2 cones (base to base) (missing definition)")]
        [EnumMember(Value = "2 cones (base to base)")]
        twoConesBaseToBase = 11,
        [System.ComponentModel.Description("A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.")]
        [EnumMember(Value = "Rhombus")]
        Rhombus = 12,
        [System.ComponentModel.Description("13:2 cones (points upward) (missing definition)")]
        [EnumMember(Value = "2 cones (points upward)")]
        twoConesPointsUpward = 13,
        [System.ComponentModel.Description("14:2 cones (points downward) (missing definition)")]
        [EnumMember(Value = "2 cones (points downward)")]
        twoConesPointsDownward = 14,
        [System.ComponentModel.Description("15:besom (point up) (missing definition)")]
        [EnumMember(Value = "besom (point up)")]
        BesomPointUp = 15,
        [System.ComponentModel.Description("16:besom (point down) (missing definition)")]
        [EnumMember(Value = "besom (point down)")]
        BesomPointDown = 16,
        [System.ComponentModel.Description("A flag mounted on a short pole.")]
        [EnumMember(Value = "Flag")]
        Flag = 17,
        [System.ComponentModel.Description("A sphere located above a rhombus.")]
        [EnumMember(Value = "Sphere Over a Rhombus")]
        SphereOverARhombus = 18,
        [System.ComponentModel.Description("A plane figure with four right angles and four equal straight sides.")]
        [EnumMember(Value = "Square")]
        Square = 19,
        [System.ComponentModel.Description("20:rectangle (horizontal) (missing definition)")]
        [EnumMember(Value = "rectangle (horizontal)")]
        RectangleHorizontal = 20,
        [System.ComponentModel.Description("21:rectangle (vertical) (missing definition)")]
        [EnumMember(Value = "rectangle (vertical)")]
        RectangleVertical = 21,
        [System.ComponentModel.Description("22:trapezium (up) (missing definition)")]
        [EnumMember(Value = "trapezium (up)")]
        TrapeziumUp = 22,
        [System.ComponentModel.Description("23:trapezium (down) (missing definition)")]
        [EnumMember(Value = "trapezium (down)")]
        TrapeziumDown = 23,
        [System.ComponentModel.Description("24:triangle (point up) (missing definition)")]
        [EnumMember(Value = "triangle (point up)")]
        TrianglePointUp = 24,
        [System.ComponentModel.Description("25:triangle (point down) (missing definition)")]
        [EnumMember(Value = "triangle (point down)")]
        TrianglePointDown = 25,
        [System.ComponentModel.Description("A perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
        [EnumMember(Value = "Circle")]
        Circle = 26,
        [System.ComponentModel.Description("27:two upright crosses (one over the other) (missing definition)")]
        [EnumMember(Value = "two upright crosses (one over the other)")]
        TwoUprightCrossesOneOverTheOther = 27,
        [System.ComponentModel.Description("28:T-shape (missing definition)")]
        [EnumMember(Value = "T-shape")]
        TShape = 28,
        [System.ComponentModel.Description("A triangle, vertex uppermost, located above a circle.")]
        [EnumMember(Value = "Triangle Pointing Up Over a Circle")]
        TrianglePointingUpOverACircle = 29,
        [System.ComponentModel.Description("An upright cross located above a circle.")]
        [EnumMember(Value = "Upright Cross Over a Circle")]
        UprightCrossOverACircle = 30,
        [System.ComponentModel.Description("A rhombus located above a circle.")]
        [EnumMember(Value = "Rhombus Over a Circle")]
        RhombusOverACircle = 31,
        [System.ComponentModel.Description("A circle located over a triangle, vertex uppermost.")]
        [EnumMember(Value = "Circle Over a Triangle Pointing Up")]
        CircleOverATrianglePointingUp = 32,
        [System.ComponentModel.Description("33:other shape (see shape information) (missing definition)")]
        [EnumMember(Value = "other shape (see shape information)")]
        OtherShapeSeeShapeInformation = 33,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofMarineProtectedArea : int {
        [System.ComponentModel.Description("Strict Nature Reserve: Protected area managed mainly for science.")]
        [EnumMember(Value = "IUCN Category Ia")]
        IucnCategoryIa = 1,
        [System.ComponentModel.Description("Wilderness Area: Protected area managed mainly for wilderness protection.")]
        [EnumMember(Value = "IUCN Category Ib")]
        IucnCategoryIb = 2,
        [System.ComponentModel.Description("National Park: Protected area managed mainly for ecosystem protection and recreation.")]
        [EnumMember(Value = "IUCN Category II")]
        IucnCategoryIi = 3,
        [System.ComponentModel.Description("Natural Monument: Protected area managed mainly for conservation of specific natural features.")]
        [EnumMember(Value = "IUCN Category III")]
        IucnCategoryIii = 4,
        [System.ComponentModel.Description("Habitat/Species Management Area: Protected area managed mainly for conservation through management intervention.")]
        [EnumMember(Value = "IUCN Category IV")]
        IucnCategoryIv = 5,
        [System.ComponentModel.Description("Protected Landscape/Seascape: Protected area managed mainly for landscape/seascape conservation and recreation.")]
        [EnumMember(Value = "IUCN Category V")]
        IucnCategoryV = 6,
        [System.ComponentModel.Description("Managed Resource Protected Area: Protected area managed mainly for the sustainable use of natural ecosystems.")]
        [EnumMember(Value = "IUCN Category VI")]
        IucnCategoryVi = 7,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfConstruction : int {
        [System.ComponentModel.Description("Constructed of stones or bricks, usually quarried, shaped, and mortared.")]
        [EnumMember(Value = "Masonry")]
        Masonry = 1,
        [System.ComponentModel.Description("Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
        [EnumMember(Value = "Concreted")]
        Concreted = 2,
        [System.ComponentModel.Description("Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
        [EnumMember(Value = "Loose Boulders")]
        LooseBoulders = 3,
        [System.ComponentModel.Description("4:hard surface (missing definition)")]
        [EnumMember(Value = "hard surface")]
        HardSurface = 4,
        [System.ComponentModel.Description("Constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.")]
        [EnumMember(Value = "Unsurfaced")]
        Unsurfaced = 5,
        [System.ComponentModel.Description("Constructed from wood.")]
        [EnumMember(Value = "Wooden")]
        Wooden = 6,
        [System.ComponentModel.Description("Constructed from metal.")]
        [EnumMember(Value = "Metal")]
        Metal = 7,
        [System.ComponentModel.Description("Constructed from a plastic material strengthened with fibres of glass.")]
        [EnumMember(Value = "Glass Reinforced Plastic")]
        GlassReinforcedPlastic = 8,
        [System.ComponentModel.Description("A structure of crossed wooden or metal strips usually arranged to form a diagonal pattern of open spaces between the strips.")]
        [EnumMember(Value = "Latticed")]
        Latticed = 11,
        [System.ComponentModel.Description("[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like. [2] Something made of such a substance, as a windowpane.")]
        [EnumMember(Value = "Glass")]
        Glass = 12,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDolphin : int {
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used as a mooring point for vessels.")]
        [EnumMember(Value = "Mooring Dolphin")]
        MooringDolphin = 1,
        [System.ComponentModel.Description("A post or group of posts, which a vessel may swing around for compass adjustment.")]
        [EnumMember(Value = "Deviation Dolphin")]
        DeviationDolphin = 2,
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to extend the berth of a vessel by providing extra mooring points.")]
        [EnumMember(Value = "Berthing Dolphin")]
        BerthingDolphin = 3,
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to assist in berthing of vessels by taking up some berthing loads; keep vessels from pressing against the pier structure; or to protect structures from possible impact by ships.")]
        [EnumMember(Value = "Fender or Breasting Dolphin")]
        FenderOrBreastingDolphin = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum qualityOfVerticalMeasurement : int {
        [System.ComponentModel.Description("The depth from the chart datum to the seabed (or to the top of a drying feature) is known.")]
        [EnumMember(Value = "Depth Known")]
        DepthKnown = 1,
        [System.ComponentModel.Description("2:depth unknown (missing definition)")]
        [EnumMember(Value = "depth unknown")]
        DepthUnknown = 2,
        [System.ComponentModel.Description("A depth that may be less than indicated.")]
        [EnumMember(Value = "Doubtful Sounding")]
        DoubtfulSounding = 3,
        [System.ComponentModel.Description("A depth that is considered to be an unreliable value.")]
        [EnumMember(Value = "Unreliable Sounding")]
        UnreliableSounding = 4,
        [System.ComponentModel.Description("The shoalest depth over a feature is of known value.")]
        [EnumMember(Value = "Least Depth Known")]
        LeastDepthKnown = 6,
        [System.ComponentModel.Description("7:least depth unknown, safe clearance at value shown (missing definition)")]
        [EnumMember(Value = "least depth unknown, safe clearance at value shown")]
        LeastDepthUnknownSafeClearanceAtValueShown = 7,
        [System.ComponentModel.Description("8:value reported (not surveyed) (missing definition)")]
        [EnumMember(Value = "value reported (not surveyed)")]
        ValueReportedNotSurveyed = 8,
        [System.ComponentModel.Description("9:value reported (not confirmed) (missing definition)")]
        [EnumMember(Value = "value reported (not confirmed)")]
        ValueReportedNotConfirmed = 9,
        [System.ComponentModel.Description("The depth at which a channel is kept by human influence, usually by dredging.")]
        [EnumMember(Value = "Maintained Depth")]
        MaintainedDepth = 10,
        [System.ComponentModel.Description("Depths may be altered by human influence, but will not be routinely maintained.")]
        [EnumMember(Value = "Not Regularly Maintained")]
        NotRegularlyMaintained = 11,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfShorelineConstruction : int {
        [System.ComponentModel.Description("A structure protecting a shore area, harbour, anchorage, or basin from waves.")]
        [EnumMember(Value = "Breakwater")]
        Breakwater = 1,
        [System.ComponentModel.Description("A low artificial wall-like structure of durable material extending from the land to seaward for a particular purpose, such as to protect the coast or to force a current to scour a channel.")]
        [EnumMember(Value = "Groyne")]
        Groyne = 2,
        [System.ComponentModel.Description("A form of breakwater alongside which vessels may lie on the sheltered side only; in some cases it may lie entirely within an artificial harbour, permitting vessels to lie along both sides.")]
        [EnumMember(Value = "Mole")]
        Mole = 3,
        [System.ComponentModel.Description("4:pier (jetty) (missing definition)")]
        [EnumMember(Value = "pier (jetty)")]
        PierJetty = 4,
        [System.ComponentModel.Description("A pier built only for recreational purposes.")]
        [EnumMember(Value = "Promenade Pier")]
        PromenadePier = 5,
        [System.ComponentModel.Description("6:wharf (quay) (missing definition)")]
        [EnumMember(Value = "wharf (quay)")]
        WharfQuay = 6,
        [System.ComponentModel.Description("A wall or bank, often submerged, built to direct or confine the flow of a river or tidal current, or to promote a scour action.")]
        [EnumMember(Value = "Training Wall")]
        TrainingWall = 7,
        [System.ComponentModel.Description("A layer of broken rock, cobbles, boulders, or fragments of sufficient size to resist the erosive forces of flowing water and wave action.")]
        [EnumMember(Value = "Rip Rap")]
        RipRap = 8,
        [System.ComponentModel.Description("Facing of stone or other material, either permanent or temporary, placed along the edge of a stream, river or canal to stabilize the bank and to protect it from the erosive action of the stream.")]
        [EnumMember(Value = "Revetment")]
        Revetment = 9,
        [System.ComponentModel.Description("An embankment or wall for protection against waves or tidal action along a shore or water front.")]
        [EnumMember(Value = "Sea Wall")]
        SeaWall = 10,
        [System.ComponentModel.Description("Steps at the shoreline as the connection between land and water on different levels.")]
        [EnumMember(Value = "Landing Steps")]
        LandingSteps = 11,
        [System.ComponentModel.Description("(1) A sloping structure which may include rails that can either be used, as a landing place, at variable water levels, for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel. (2) An accumulation of snow that forms an inclined plane between land or land ice elements and sea ice or ice shelf. Also called drift ice foot.")]
        [EnumMember(Value = "Ramp")]
        Ramp = 12,
        [System.ComponentModel.Description("The prepared and usually reinforced inclined surface on which keel- and bilge-blocks are laid for supporting a vessel under construction.")]
        [EnumMember(Value = "Slipway")]
        Slipway = 13,
        [System.ComponentModel.Description("A protective structure designed to cushion the impact of a vessel and prevent damage.")]
        [EnumMember(Value = "Fender")]
        Fender = 14,
        [System.ComponentModel.Description("A wharf consisting of a solid wall of concrete, masonry, wood etc., such that the water cannot circulate freely under the wharf. The type of construction affects ship-handling; for example, a solid face wharf may give shelter from tidal streams, but under certain circumstances a cushion of water may build up between such a wharf and a ship attempting to berth at it, causing difficulties in ship handling.")]
        [EnumMember(Value = "Solid Face Wharf")]
        SolidFaceWharf = 15,
        [System.ComponentModel.Description("A wharf supported on piles or other structures which allow free circulation of water under the wharf.")]
        [EnumMember(Value = "Open Face Wharf")]
        OpenFaceWharf = 16,
        [System.ComponentModel.Description("An inclined plane used to dump logs into the water for transport, or to haul logs out of the water for processing.")]
        [EnumMember(Value = "Log Ramp")]
        LogRamp = 17,
        [System.ComponentModel.Description("An artificial pool or swimming enclosure, especially one in the open air, which may be constructed of wire mesh or heavy netting supported by cables, buoys or piles, for swimming in.")]
        [EnumMember(Value = "Swimming Facility")]
        SwimmingFacility = 20,
        [System.ComponentModel.Description("A wharf approximately parallel to the shoreline and accommodating ships on one side only, the other side being attached to the shore. It is usually of solid construction, as contrasted with the open pile construction usually used for piers.")]
        [EnumMember(Value = "Quay")]
        Quay = 22,
        [System.ComponentModel.Description("23:tie-up wall (missing definition)")]
        [EnumMember(Value = "tie-up wall")]
        TieUpWall = 23,
        [System.ComponentModel.Description("Man-made structure that acts as an obstacle to landing operations.")]
        [EnumMember(Value = "Artificial Obstacle")]
        ArtificialObstacle = 501,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lightVisibility : int {
        [System.ComponentModel.Description("Non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).")]
        [EnumMember(Value = "High Intensity")]
        HighIntensity = 1,
        [System.ComponentModel.Description("Non-marine lights with lower power than marine lights.")]
        [EnumMember(Value = "Low Intensity")]
        LowIntensity = 2,
        [System.ComponentModel.Description("A decrease in the apparent intensity of a light which may occur in the case of partial obstructions.")]
        [EnumMember(Value = "Faint")]
        Faint = 3,
        [System.ComponentModel.Description("A light in a sector is intensified (that is, has longer range than other sectors).")]
        [EnumMember(Value = "Intensified")]
        Intensified = 4,
        [System.ComponentModel.Description("A light in a sector is unintensified (that is, has shorter range than other sectors).")]
        [EnumMember(Value = "Unintensified")]
        Unintensified = 5,
        [System.ComponentModel.Description("A light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.")]
        [EnumMember(Value = "Visibility Deliberately Restricted")]
        VisibilityDeliberatelyRestricted = 6,
        [System.ComponentModel.Description("Said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.")]
        [EnumMember(Value = "Obscured")]
        Obscured = 7,
        [System.ComponentModel.Description("This value specifies that parts of the sector are obscured.")]
        [EnumMember(Value = "Partially Obscured")]
        PartiallyObscured = 8,
        [System.ComponentModel.Description("Lights that must be in line to be visible.")]
        [EnumMember(Value = "Visible in Line of Range")]
        VisibleInLineOfRange = 9,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSeaArea : int {
        [System.ComponentModel.Description("A natural or artificial passage or channel through shoals or steep banks, or across a line of banks lying between two channels.")]
        [EnumMember(Value = "Gat")]
        Gat = 2,
        [System.ComponentModel.Description("An elevation of the seafloor, at depths generally less than 200 m, but sufficient for safe surface navigation, commonly found on the continental shelf or near an island.")]
        [EnumMember(Value = "Bank")]
        Bank = 3,
        [System.ComponentModel.Description("In oceanography, an obsolete term which was generally restricted to depths greater than 6,000 m.")]
        [EnumMember(Value = "Deep")]
        Deep = 4,
        [System.ComponentModel.Description("A wide indentation in the coastline generally smaller than a gulf and larger than a cove. For the purposes of the United Nations Convention on the Law of the Sea, a bay is a well-marked indentation whose penetration is in such proportion to the width of its mouth as to contain land locked waters and constitute more than a mere curvature of the coast.")]
        [EnumMember(Value = "Bay")]
        Bay = 5,
        [System.ComponentModel.Description("A long, deep, asymmetrical depression with relatively steep sides, that is associated with subduction.")]
        [EnumMember(Value = "Trench")]
        Trench = 6,
        [System.ComponentModel.Description("A depression of the seafloor more or less equidimensional in plan and of variable extent.")]
        [EnumMember(Value = "Basin")]
        Basin = 7,
        [System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
        [EnumMember(Value = "Mud Flats")]
        MudFlats = 8,
        [System.ComponentModel.Description("A shallow elevation composed of consolidated material that may constitute a hazard to surface navigation.")]
        [EnumMember(Value = "Reef")]
        Reef = 9,
        [System.ComponentModel.Description("A rocky formation continuous with and fringing the shore.")]
        [EnumMember(Value = "Ledge")]
        Ledge = 10,
        [System.ComponentModel.Description("An elongated, narrow, steep-sided depression that generally deepens down-slope.")]
        [EnumMember(Value = "Canyon")]
        Canyon = 11,
        [System.ComponentModel.Description("A navigable narrow part of a bay, strait, river, etc.")]
        [EnumMember(Value = "Narrows")]
        Narrows = 12,
        [System.ComponentModel.Description("A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.")]
        [EnumMember(Value = "Shoal")]
        Shoal = 13,
        [System.ComponentModel.Description("A distinct elevation with a rounded profile less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        [EnumMember(Value = "Knoll")]
        Knoll = 14,
        [System.ComponentModel.Description("An elongated elevation of varying complexity and size, generally having steep sides.")]
        [EnumMember(Value = "Ridge")]
        Ridge = 15,
        [System.ComponentModel.Description("A distinct generally equidimensional elevation greater than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        [EnumMember(Value = "Seamount")]
        Seamount = 16,
        [System.ComponentModel.Description("Any high tower or spire-shaped pillar or rock or coral, alone or cresting a summit. It may extend above the surface of the water. It may or may not be a hazard to surface navigation.")]
        [EnumMember(Value = "Pinnacle")]
        Pinnacle = 17,
        [System.ComponentModel.Description("An extensive, flat, gently sloping or nearly level region at abyssal depths.")]
        [EnumMember(Value = "Abyssal Plain")]
        AbyssalPlain = 18,
        [System.ComponentModel.Description("A large, relatively flat elevation that is higher than the surrounding relief with one or more relatively steep sides.")]
        [EnumMember(Value = "Plateau")]
        Plateau = 19,
        [System.ComponentModel.Description("A subordinate ridge protruding from a larger feature.")]
        [EnumMember(Value = "Spur")]
        Spur = 20,
        [System.ComponentModel.Description("The flat or gently sloping region adjacent to a continent or around an island that extends from the low water line to a depth, generally about 200m, where there is a marked increase in downward slope.")]
        [EnumMember(Value = "Shelf")]
        Shelf = 21,
        [System.ComponentModel.Description("A long depression generally wide and flat bottomed with symmetrical and parallel sides.")]
        [EnumMember(Value = "Trough")]
        Trough = 22,
        [System.ComponentModel.Description("A broad pass or col in a ridge, rise or other elevation.")]
        [EnumMember(Value = "Saddle")]
        Saddle = 23,
        [System.ComponentModel.Description("An isolated small elevation on the deep seafloor.")]
        [EnumMember(Value = "Abyssal Hill")]
        AbyssalHill = 24,
        [System.ComponentModel.Description("A gently dipping slope, with a smooth surface, commonly found around groups of islands and seamounts.")]
        [EnumMember(Value = "Apron")]
        Apron = 25,
        [System.ComponentModel.Description("A gentle slope with a generally smooth surface of the seafloor, characteristically found around groups of islands or seamounts.")]
        [EnumMember(Value = "Archipelagic Apron")]
        ArchipelagicApron = 26,
        [System.ComponentModel.Description("A region adjacent to a continent, normally occupied by or bordering a shelf and sometimes emerging as islands, that is irregular or blocky in plan or profile, with depths well in excess of those typical of a shelf.")]
        [EnumMember(Value = "Borderland")]
        Borderland = 27,
        [System.ComponentModel.Description("The zone, generally consisting of shelf, slope and continental rise, separating the continent from the deep seafloor or abyssal plain or plain. Occasionally a trench may be present in place of a continental rise.")]
        [EnumMember(Value = "Continental Margin")]
        ContinentalMargin = 28,
        [System.ComponentModel.Description("A gentle slope rising from the oceanic depths towards the foot of a continental slope.")]
        [EnumMember(Value = "Continental Rise")]
        ContinentalRise = 29,
        [System.ComponentModel.Description("An elongated, characteristically linear, steep slope separating horizontal or gently sloping areas of the seafloor.")]
        [EnumMember(Value = "Escarpment")]
        Escarpment = 30,
        [System.ComponentModel.Description("A relatively smooth, depositional feature continuously deepening away from a sediment source commonly located at the lower termination of a canyon or canyon system.")]
        [EnumMember(Value = "Fan")]
        Fan = 31,
        [System.ComponentModel.Description("A long narrow zone of irregular topography formed by the movement of tectonic plates associated with an offset of a spreading ridge axis, characterized by steep-sided and/or asymmetrical ridges, troughs or escarpments.")]
        [EnumMember(Value = "Fracture Zone")]
        FractureZone = 32,
        [System.ComponentModel.Description("A narrow break in a ridge, rise or other elevation.")]
        [EnumMember(Value = "Gap")]
        Gap = 33,
        [System.ComponentModel.Description("A seamount having a comparatively smooth flat top.")]
        [EnumMember(Value = "Guyot")]
        Guyot = 34,
        [System.ComponentModel.Description("[1] A small isolated elevation, smaller than a mountain. [2] A distinct elevation generally of irregular shape, less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        [EnumMember(Value = "Hill")]
        Hill = 35,
        [System.ComponentModel.Description("A depression of limited extent with all sides rising steeply from a relatively flat bottom.")]
        [EnumMember(Value = "Hole")]
        Hole = 36,
        [System.ComponentModel.Description("A depositional embankment bordering a canyon, valley or sea channel.")]
        [EnumMember(Value = "Levee")]
        Levee = 37,
        [System.ComponentModel.Description("The axial depression of the mid-oceanic ridge system.")]
        [EnumMember(Value = "Median Valley")]
        MedianValley = 38,
        [System.ComponentModel.Description("An annular or partially annular depression commonly located at the base of seamounts, islands and other isolated elevations.")]
        [EnumMember(Value = "Moat")]
        Moat = 39,
        [System.ComponentModel.Description("A natural elevation of the earth's surface rising more or less abruptly from the surrounding level, and attaining an altitude which, relatively to adjacent elevations, is impressive or notable.")]
        [EnumMember(Value = "Mountains")]
        Mountains = 40,
        [System.ComponentModel.Description("A conical or pointed elevation on a larger feature such as a seamount.")]
        [EnumMember(Value = "Peak")]
        Peak = 41,
        [System.ComponentModel.Description("A geographically distinct region with a number of shared physiographic characteristics that contrast with those in the surrounding areas. This term should be modified with the generic term that best describes the majority of features in the region, for example \"Seamount\" in Baja California Seamount Province.")]
        [EnumMember(Value = "Province")]
        Province = 42,
        [System.ComponentModel.Description("A broad elevation that generally rises gently and smoothly from the surrounding relief.")]
        [EnumMember(Value = "Rise")]
        Rise = 43,
        [System.ComponentModel.Description("An elongated, meandering depression, usually occurring on a gently sloping plain or fan.")]
        [EnumMember(Value = "Sea Channel")]
        SeaChannel = 44,
        [System.ComponentModel.Description("Several seamounts in linear or arcuate alignment.")]
        [EnumMember(Value = "Seamount Chain")]
        SeamountChain = 45,
        [System.ComponentModel.Description("46:shelf-edge (missing definition)")]
        [EnumMember(Value = "shelf-edge")]
        ShelfEdge = 46,
        [System.ComponentModel.Description("A relatively shallow barrier between BASINS that may inhibit water movement.")]
        [EnumMember(Value = "Sill")]
        Sill = 47,
        [System.ComponentModel.Description("The sloping region that deepens from a shelf to the point where there is a general decrease in gradient.")]
        [EnumMember(Value = "Slope")]
        Slope = 48,
        [System.ComponentModel.Description("A flat or gently sloping region, generally long and narrow, bounded along one edge by a steeper descending slope and along the other by a steeper ascending slope.")]
        [EnumMember(Value = "Terrace")]
        Terrace = 49,
        [System.ComponentModel.Description("An elongated depression that generally widens and deepens down-slope.")]
        [EnumMember(Value = "Valley")]
        Valley = 50,
        [System.ComponentModel.Description("An artificial waterway with no flow, or a controlled flow, used for navigation, or for draining or irrigating land (ditch).")]
        [EnumMember(Value = "Canal")]
        Canal = 51,
        [System.ComponentModel.Description("A large body of water entirely surrounded by land.")]
        [EnumMember(Value = "Lake")]
        Lake = 52,
        [System.ComponentModel.Description("A relatively large natural stream of water.")]
        [EnumMember(Value = "River")]
        River = 53,
        [System.ComponentModel.Description("A straight section of a river, especially a navigable river between two bends; or an arm of the sea extending into the land.")]
        [EnumMember(Value = "Reach")]
        Reach = 54,
        [System.ComponentModel.Description("A low, flat island of sand, coral, etc. awash or submerged at high water.")]
        [EnumMember(Value = "Intertidal Cay")]
        IntertidalCay = 55,
        [System.ComponentModel.Description("A seabed volcano, submerged at the chart sounding datum, which may or may not be active.")]
        [EnumMember(Value = "Submarine Volcano")]
        SubmarineVolcano = 56,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfConveyor : int {
        [System.ComponentModel.Description("A transportation system consisting of load cables strung between pylons on which carrier units (for example: cars or buckets intended to transport people, material, and/or equipment) are suspended.")]
        [EnumMember(Value = "Aerial Cableway")]
        AerialCableway = 1,
        [System.ComponentModel.Description("A conveyor along which material or people are transported by means of a moving belt.")]
        [EnumMember(Value = "Belt Conveyor")]
        BeltConveyor = 2,
        [System.ComponentModel.Description("An artificial channel, usually an inclined chute or trough, for carrying water to furnish power, transport logs down a mountainside, etc.")]
        [EnumMember(Value = "Flume")]
        Flume = 3,
        [System.ComponentModel.Description("4:lift/elevator (missing definition)")]
        [EnumMember(Value = "lift/elevator")]
        LiftElevator = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRoad : int {
        [System.ComponentModel.Description("A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.")]
        [EnumMember(Value = "Motorway")]
        Motorway = 1,
        [System.ComponentModel.Description("A hard surfaced (metalled) road; a main through route.")]
        [EnumMember(Value = "Major Road")]
        MajorRoad = 2,
        [System.ComponentModel.Description("A secondary road for local traffic.")]
        [EnumMember(Value = "Minor Road")]
        MinorRoad = 3,
        [System.ComponentModel.Description("4:track/path (missing definition)")]
        [EnumMember(Value = "track/path")]
        TrackPath = 4,
        [System.ComponentModel.Description("A main road, in an urban area, for through traffic.")]
        [EnumMember(Value = "Major Street")]
        MajorStreet = 5,
        [System.ComponentModel.Description("A secondary road, in an urban area, for local traffic.")]
        [EnumMember(Value = "Minor Street")]
        MinorStreet = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum bottomFeatureClassification : int {
        [System.ComponentModel.Description("In geology, a break of shear in the earth's crust with an observable displacement between the two sides of the break, and parallel to the plane of the break.")]
        [EnumMember(Value = "Fault")]
        Fault = 502,
        [System.ComponentModel.Description("A large mobile wave-like sediment feature in shallow water and composed of sand. The wavelength may reach 100 metres, the amplitude may be up to 20 metres.")]
        [EnumMember(Value = "Sandwave")]
        Sandwave = 510,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristicsUnit : int {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        [EnumMember(Value = "Metres")]
        Metres = 1,
        [System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.")]
        [EnumMember(Value = "Metric Ton")]
        MetricTon = 3,
        [System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
        [EnumMember(Value = "Ton")]
        Ton = 4,
        [System.ComponentModel.Description("A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
        [EnumMember(Value = "Short Ton")]
        ShortTon = 5,
        [System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
        [EnumMember(Value = "Gross Ton")]
        GrossTon = 6,
        [System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
        [EnumMember(Value = "Net Ton")]
        NetTon = 7,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum firstSensor : int {
        [System.ComponentModel.Description("501:acoustic sensor (missing definition)")]
        [EnumMember(Value = "acoustic sensor")]
        AcousticSensor = 501,
        [System.ComponentModel.Description("the object was reported as a result of detecting a fluctuation in the local magnetic field.")]
        [EnumMember(Value = "Magnetic Sensor")]
        MagneticSensor = 502,
        [System.ComponentModel.Description("503:video sensor (missing definition)")]
        [EnumMember(Value = "video sensor")]
        VideoSensor = 503,
        [System.ComponentModel.Description("504:diver sighting - (found by diver - in registry) (missing definition)")]
        [EnumMember(Value = "diver sighting - (found by diver - in registry)")]
        DiverSightingFoundByDiverInRegistry = 504,
        [System.ComponentModel.Description("506:physical snag (missing definition)")]
        [EnumMember(Value = "physical snag")]
        PhysicalSnag = 506,
        [System.ComponentModel.Description("507:observed sinking (missing definition)")]
        [EnumMember(Value = "observed sinking")]
        ObservedSinking = 507,
        [System.ComponentModel.Description("508:Reported Sinking (missing definition)")]
        [EnumMember(Value = "Reported Sinking")]
        ReportedSinking = 508,
        [System.ComponentModel.Description("509:None reported (missing definition)")]
        [EnumMember(Value = "None reported")]
        NoneReported = 509,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum waterLevelEffect : int {
        [System.ComponentModel.Description("Partially covered and partially dry at high water.")]
        [EnumMember(Value = "Partly Submerged at High Water")]
        PartlySubmergedAtHighWater = 1,
        [System.ComponentModel.Description("Not covered at high water under average meteorological conditions.")]
        [EnumMember(Value = "Always Dry")]
        AlwaysDry = 2,
        [System.ComponentModel.Description("3:always under water/ (missing definition)")]
        [EnumMember(Value = "always under water/")]
        AlwaysUnderWater = 3,
        [System.ComponentModel.Description("Expression intended to indicate an area of a reef or other projection from the bottom of a body of water which periodically extends above and is submerged below the surface. Also referred to as dries or uncovers.")]
        [EnumMember(Value = "Covers and Uncovers")]
        CoversAndUncovers = 4,
        [System.ComponentModel.Description("Flush with, or washed by the waves at low water under average meteorological conditions.")]
        [EnumMember(Value = "Awash")]
        Awash = 5,
        [System.ComponentModel.Description("6:subject to inundation or (missing definition)")]
        [EnumMember(Value = "subject to inundation or")]
        SubjectToInundationOr = 6,
        [System.ComponentModel.Description("Resting or moving on the surface of a liquid without sinking.")]
        [EnumMember(Value = "Floating")]
        Floating = 7,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum boundaryStatusType : int {
        [System.ComponentModel.Description("501:definite (missing definition)")]
        [EnumMember(Value = "definite")]
        Definite = 501,
        [System.ComponentModel.Description("502:indefinite (missing definition)")]
        [EnumMember(Value = "indefinite")]
        Indefinite = 502,
        [System.ComponentModel.Description("Has not been defined by either of the adjoining authorities.")]
        [EnumMember(Value = "no defined boundary")]
        NoDefinedBoundary = 504,
        [System.ComponentModel.Description("Boundary has not been ratified")]
        [EnumMember(Value = "Not Yet Ratified")]
        NotYetRatified = 599,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum signalGeneration : int {
        [System.ComponentModel.Description("Activated by radio signal.")]
        [EnumMember(Value = "Radio Activated")]
        RadioActivated = 5,
        [System.ComponentModel.Description("Activated by making a call to a manned station.")]
        [EnumMember(Value = "Call Activated")]
        CallActivated = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum speciesGrouping : int {
        [System.ComponentModel.Description("Any of an order (Cetacea) of aquatic mostly marine mammals that includes the whales, dolphins, porpoises, and related forms and that have a torpedo-shaped nearly hairless body, paddle-shaped forelimbs but no hind limbs, one or two nares opening externally at the top of the head, and a horizontally flattened tail used for locomotion.")]
        [EnumMember(Value = "Cetacean")]
        Cetacean = 501,
        [System.ComponentModel.Description("Any of an order or suborder (Pinnipedia) of aquatic carnivorous mammals (such as a seal or walrus) with all four limbs modified into flippers.")]
        [EnumMember(Value = "Pinniped")]
        Pinniped = 502,
        [System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
        [EnumMember(Value = "Fish")]
        Fish = 503,
        [System.ComponentModel.Description("Any of an order (Testudines synonym Chelonia) of terrestrial, freshwater, and marine reptiles that have a toothless horny beak and a shell of bony dermal plates usually covered with horny shields enclosing the trunk and into which the head, limbs, and tail usually may be withdrawn.")]
        [EnumMember(Value = "Turtle")]
        Turtle = 504,
        [System.ComponentModel.Description("Any of a class (Aves) of warm-blooded vertebrates distinguished by having the body more or less completely covered with feathers and the forelimbs modified as wings.")]
        [EnumMember(Value = "Bird")]
        Bird = 505,
        [System.ComponentModel.Description("Any of an order (Sirenia) of aquatic herbivorous mammals (such as a manatee, dugong, or Steller's sea cow) that have large forelimbs resembling paddles, no hind limbs, and a flattened tail resembling a fin.")]
        [EnumMember(Value = "Sirenian")]
        Sirenian = 506,
        [System.ComponentModel.Description("507:Otter (animal) (missing definition)")]
        [EnumMember(Value = "Otter (animal)")]
        OtterAnimal = 507,
        [System.ComponentModel.Description("A large creamy-white carnivorous bear (Ursus maritimus synonym Thalarctos maritimus) that inhabits arctic regions.")]
        [EnumMember(Value = "Polar bear")]
        PolarBear = 508,
        [System.ComponentModel.Description("Any of numerous venomous aquatic chiefly viviparous elapid snakes of warm seas.")]
        [EnumMember(Value = "Sea snake")]
        SeaSnake = 509,
        [System.ComponentModel.Description("A reef, often of large extent, composed chiefly of coral and its derivatives.")]
        [EnumMember(Value = "Coral Reef")]
        CoralReef = 510,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfReportingRadioCallingInPoint : int {
        [System.ComponentModel.Description("501:Reporting/Radio calling in point (missing definition)")]
        [EnumMember(Value = "Reporting/Radio calling in point")]
        ReportingRadioCallingInPoint = 501,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfFishingFacility : int {
        [System.ComponentModel.Description("Poles or stakes placed in shallow water to outline a fishing ground or to catch fish.")]
        [EnumMember(Value = "Fishing Stake")]
        FishingStake = 1,
        [System.ComponentModel.Description("A structure (usually portable) for catching fish.")]
        [EnumMember(Value = "Fish Trap")]
        FishTrap = 2,
        [System.ComponentModel.Description("A fence of stakes or stones set in a river or along the shore to trap fish.")]
        [EnumMember(Value = "Fish Weir")]
        FishWeir = 3,
        [System.ComponentModel.Description("A net built at sea for catching tunny.")]
        [EnumMember(Value = "Tunny Net")]
        TunnyNet = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    public static class CodeList {
    }

    namespace ComplexAttributes {
        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class qRouteChannelWidth {
            [Required()]
            public Decimal rightQRouteWidth { get; set; }

            public qRouteChannelWidth() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class detectionDateRange {
            public DateOnly? lastDetectionYear { get; set; } = default;
            public DateOnly? firstDetectionYear { get; set; } = default;

            public detectionDateRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class multiplicityOfFeatures {
            public Int32? numberOfFeatures { get; set; } = default;

            [Required()]
            public Boolean multiplicityKnown { get; set; }

            public multiplicityOfFeatures() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class onlineResource {
            public String? headline { get; set; } = null;
            public String linkage { get; set; } = string.Empty;
            public String? nameOfResource { get; set; } = null;

            public onlineResource() {
                linkage = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public nameUsage? nameUsage { get; set; } = default;
            public String name { get; set; } = string.Empty;
            public String language { get; set; } = string.Empty;

            public featureName() {
                name = string.Empty;
                language = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class fixedDateRange {
            public DateOnly? dateStart { get; set; } = default;
            public DateOnly? dateEnd { get; set; } = default;

            public fixedDateRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class altitudeRange {
            [Required()]
            public Int32 minimumAltitude { get; set; }

            [Required()]
            public Int32 maximumAltitude { get; set; }

            public altitudeRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class altitude
#pragma warning restore CS8981
        {
            [Required()]
            public Int32 minimumAltitude { get; set; }

            [Required()]
            public Int32 maximumAltitude { get; set; }

            public altitude() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class lastSourceInformation {
            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(506)]
            [EnumerationValue(509)]
            public lastSensor? lastSensor { get; set; } = default;
            public String? lastSource { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;

            public lastSourceInformation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class information
#pragma warning restore CS8981
        {
            public String? headline { get; set; } = null;
            public String language { get; set; } = string.Empty;
            public String? fileLocator { get; set; } = null;
            public String? text { get; set; } = null;
            public String? fileReference { get; set; } = null;

            public information() {
                language = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class firstSourceInformation {
            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(506)]
            [EnumerationValue(509)]
            [Required()]
            public firstSensor firstSensor { get; set; }
            public String? firstSource { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;

            public firstSourceInformation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class horizontalClearanceFixed {
            [Required()]
            public Decimal horizontalClearanceValue { get; set; }
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            public horizontalClearanceFixed() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalUncertainty {
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            [Required()]
            public Decimal uncertaintyFixed { get; set; }

            public verticalUncertainty() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class frequencyPair {
            public Int32? frequencyShoreStationReceives { get; set; } = default;

            [Required()]
            public Int32 frequencyShoreStationTransmits { get; set; }

            public frequencyPair() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class vesselMeasurementsSpecification {
            [Required()]
            public Decimal vesselsCharacteristicsValue { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [Required()]
            public vesselsCharacteristics vesselsCharacteristics { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public comparisonOperator? comparisonOperator { get; set; } = default;

            public vesselMeasurementsSpecification() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class surfaceCharacteristics {
            public Int32? underlyingLayer { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public natureOfSurface? natureOfSurface { get; set; } = default;

            public surfaceCharacteristics() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class magneticInformation {
            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            public strengthOfMagneticAnomaly? strengthOfMagneticAnomaly { get; set; } = default;
            public Int32? magneticIntensity { get; set; } = default;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [Required()]
            public magneticAnomalyDetectorSignature magneticAnomalyDetectorSignature { get; set; }

            public magneticInformation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class speed
#pragma warning restore CS8981
        {
            public Decimal? speedMinimum { get; set; } = default;

            [Required()]
            public Decimal speedMaximum { get; set; }

            public speed() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalClearanceFixed {
            public verticalUncertainty? verticalUncertainty { get; set; }

            [Required()]
            public Decimal verticalClearanceValue { get; set; }

            public verticalClearanceFixed() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sourceIdentification {
            public String? producerNation { get; set; } = null;
            public String? sourceType { get; set; } = null;
            public String? productionAgency { get; set; } = null;
            public String sourceID { get; set; } = string.Empty;

            public sourceIdentification() {
                sourceID = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class horizontalPositionUncertainty {
            [Required()]
            public Decimal uncertaintyFixed { get; set; }
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            public horizontalPositionUncertainty() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class orientation
#pragma warning restore CS8981
        {
            [Required()]
            public Decimal orientationValue { get; set; }
            public Decimal? orientationUncertainty { get; set; } = default;

            public orientation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class directionHeading {
            [Required()]
            public Decimal headingDownBearing { get; set; }

            [Required()]
            public Decimal headingUpBearing { get; set; }

            public directionHeading() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class flightLevel {
            [Required()]
            public Int32 minimumFlightLevel { get; set; }

            [Required()]
            public Int32 maximumFlightLevel { get; set; }

            public flightLevel() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class vesselSpeedLimit {
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public speedUnits speedUnits { get; set; }
            public String? vesselClass { get; set; } = null;

            [Required()]
            public Decimal speedLimit { get; set; }

            public vesselSpeedLimit() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class periodicDateRange {
            [Required()]
            public DateOnly dateStart { get; set; }

            [Required()]
            public DateOnly dateEnd { get; set; }

            [Required()]
            public DateOnly periodicDateEnd { get; set; }

            [Required()]
            public DateOnly periodicDateStart { get; set; }

            public periodicDateRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class shapeInformation {
            public String text { get; set; } = string.Empty;
            public String? language { get; set; } = null;

            public shapeInformation() {
                text = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class signalSequence {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [Required()]
            public signalStatus signalStatus { get; set; }

            [Required()]
            public Decimal signalDuration { get; set; }

            public signalSequence() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorInformation {
            public String text { get; set; } = string.Empty;
            public String? language { get; set; } = null;

            public sectorInformation() {
                text = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class directionalCharacter {
            [Required()]
            public orientation orientation { get; set; }
            public Boolean? moireEffect { get; set; } = default;

            public directionalCharacter() {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitTwo {
            public Decimal? sectorLineLength { get; set; } = default;

            [Required()]
            public Decimal sectorBearing { get; set; }

            public sectorLimitTwo() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitOne {
            public Decimal? sectorLineLength { get; set; } = default;

            [Required()]
            public Decimal sectorBearing { get; set; }

            public sectorLimitOne() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class topmark
#pragma warning restore CS8981
        {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            [EnumerationValue(33)]
            [Required()]
            public topmarkDaymarkShape topmarkDaymarkShape { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            public colour? colour { get; set; } = default;
            public List<shapeInformation> shapeInformation { get; set; } = [];

            public topmark() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class rythmOfLight {
            public List<signalSequence> signalSequence { get; set; } = [];
            public Decimal? signalPeriod { get; set; } = default;
            public List<String> signalGroup { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [Required()]
            public lightCharacteristic lightCharacteristic { get; set; }

            public rythmOfLight() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalClearanceSafe {
            public verticalUncertainty? verticalUncertainty { get; set; }

            [Required()]
            public Decimal verticalClearanceValue { get; set; }

            public verticalClearanceSafe() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimit {
            [Required()]
            public sectorLimitOne sectorLimitOne { get; set; }

            [Required()]
            public sectorLimitTwo sectorLimitTwo { get; set; }

            public sectorLimit() {
                sectorLimitOne = new sectorLimitOne()
                {
                    sectorBearing = default(Decimal),
                };
                sectorLimitTwo = new sectorLimitTwo()
                {
                    sectorBearing = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class lightSector {
            public sectorLimit? sectorLimit { get; set; }
            public List<sectorInformation> sectorInformation { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public List<lightVisibility> lightVisibility { get; set; } = [];
            public Decimal? valueOfNominalRange { get; set; } = default;
            public Boolean? sectorArcExtension { get; set; } = default;
            public directionalCharacter? directionalCharacter { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [Required()]
            public List<colour> colour { get; set; }

            public lightSector() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorCharacteristics {
            public List<signalSequence> signalSequence { get; set; } = [];
            public Decimal? signalPeriod { get; set; } = default;

            [Required()]
            public List<lightSector> lightSector { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [Required()]
            public lightCharacteristic lightCharacteristic { get; set; }
            public List<String> signalGroup { get; set; } = [];

            public sectorCharacteristics() {
                lightSector = new();
                ;
            }
        }
    }
}

namespace S100Framework.DomainModel.S501 {
    public enum Role {
    }

    namespace Associations {
        namespace SpatialAssociations {
        }

        namespace InformationAssociations {
            using S100Framework.DomainModel.S501.InformationTypes;
        }

        namespace FeatureAssociations {
            using S100Framework.DomainModel.S501.FeatureTypes;
        }
    }

    namespace Bindings {
    }
}

namespace S100Framework.DomainModel.S501 {
    namespace InformationTypes {
        using ComplexAttributes;
        using DomainModel;
        using S100Framework.DomainModel.S501.Associations.InformationAssociations;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ReferenceToAPublication : InformationNode, IInformationBindingDefinition {
            public DateOnly? editionDate { get; set; } = default;
            public String? editionNumber { get; set; } = null;
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(ReferenceToAPublication);
            public informationBindingDefinition[] informationBindingDefinitions => ReferenceToAPublication._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];

            public ReferenceToAPublication() {
            }
        }
    }

    namespace FeatureTypes {
        using ComplexAttributes;
        using InformationTypes;
        using DomainModel;
        using System.Runtime.Serialization;
        using S100Framework.DomainModel.S501.Associations.InformationAssociations;
        using S100Framework.DomainModel.S501.Associations.FeatureAssociations;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InstallationBuoy : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            public List<product> product { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [Required()]
            public buoyShape buoyShape { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(7)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public categoryOfInstallationBuoy? categoryOfInstallationBuoy { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(InstallationBuoy);
            public informationBindingDefinition[] informationBindingDefinitions => InstallationBuoy._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public InstallationBuoy() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DepthArea : FeatureNode, IFeatureBindingDefinition {
            [Required()]
            public Decimal depthRangeMaximumValue { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<information> information { get; set; } = [];

            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }

            [JsonIgnore]
            public override string Code => nameof(DepthArea);
            public informationBindingDefinition[] informationBindingDefinitions => DepthArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DepthArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DepthArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadioCallingInPoint : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(501)]
            public categoryOfReportingRadioCallingInPoint? categoryOfReportingRadioCallingInPoint { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<String> communicationChannel { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<Decimal> orientationValue { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(9)]
            [EnumerationValue(501)]
            public List<status> status { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public trafficFlow trafficFlow { get; set; }

            [JsonIgnore]
            public override string Code => nameof(RadioCallingInPoint);
            public informationBindingDefinition[] informationBindingDefinitions => RadioCallingInPoint._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public RadioCallingInPoint() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PatrolArea : FeatureNode, IFeatureBindingDefinition {
            public String? agencyResponsibleForProduction { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;
            public String? nationality { get; set; } = null;
            public String? controllingAuthority { get; set; } = null;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [Required()]
            public categoryOfPatrolArea categoryOfPatrolArea { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(501)]
            public List<status> status { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(PatrolArea);
            public informationBindingDefinition[] informationBindingDefinitions => PatrolArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => PatrolArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public PatrolArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Checkpoint : FeatureNode, IFeatureBindingDefinition {
            public String? controllingAuthority { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];
            public String? agencyResponsibleForProduction { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(9)]
            [EnumerationValue(12)]
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(501)]
            public categoryOfCheckpoint? categoryOfCheckpoint { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(Checkpoint);
            public informationBindingDefinition[] informationBindingDefinitions => Checkpoint._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Checkpoint._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Checkpoint() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MarineManagementArea : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            public restriction? restriction { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            [EnumerationValue(510)]
            public List<speciesGrouping> speciesGrouping { get; set; } = [];

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(2)]
            [Required()]
            public jurisdiction jurisdiction { get; set; }
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            public categoryofMarineProtectedArea? categoryofMarineProtectedArea { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];
            public String? controllingAuthority { get; set; } = null;
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(519)]
            public status? status { get; set; } = default;

            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(10)]
            [EnumerationValue(20)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            public List<categoryofRestrictions> categoryofRestrictions { get; set; } = [];
            public List<String> species { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(MarineManagementArea);
            public informationBindingDefinition[] informationBindingDefinitions => MarineManagementArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => MarineManagementArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public MarineManagementArea() {
                nationalMaritimeAuthority = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DepthContour : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public verticalUncertainty? verticalUncertainty { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }

            [Required()]
            public Decimal valueOfDepthContour { get; set; }
            public String? agencyResponsibleForProduction { get; set; } = null;
            public String? interoperabilityIdentifier { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(DepthContour);
            public informationBindingDefinition[] informationBindingDefinitions => DepthContour._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DepthContour._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DepthContour() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class EnvironmentallySensitiveSeaArea : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];
            public String? controllingAuthority { get; set; } = null;
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(EnvironmentallySensitiveSeaArea);
            public informationBindingDefinition[] informationBindingDefinitions => EnvironmentallySensitiveSeaArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => EnvironmentallySensitiveSeaArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public EnvironmentallySensitiveSeaArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Road : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public categoryOfRoad? categoryOfRoad { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(501)]
            public condition? condition { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(Road);
            public informationBindingDefinition[] informationBindingDefinitions => Road._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Road._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Road() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class River : FeatureNode, IFeatureBindingDefinition {
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(5)]
            public List<status> status { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(River);
            public informationBindingDefinition[] informationBindingDefinitions => River._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => River._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public River() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MilitaryPracticeArea : FeatureNode, IFeatureBindingDefinition {
            public altitudeRange? altitudeRange { get; set; }
            public String depthRestriction { get; set; } = string.Empty;

            [EnumerationValue(1)]
            public depthUnits? depthUnits { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String? nationality { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(39)]
            public List<restriction> restriction { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            [EnumerationValue(510)]
            [EnumerationValue(511)]
            [EnumerationValue(512)]
            [EnumerationValue(513)]
            [EnumerationValue(514)]
            [EnumerationValue(515)]
            [EnumerationValue(516)]
            [EnumerationValue(517)]
            [EnumerationValue(518)]
            [EnumerationValue(519)]
            [EnumerationValue(520)]
            [EnumerationValue(521)]
            [EnumerationValue(522)]
            [EnumerationValue(523)]
            [EnumerationValue(524)]
            [EnumerationValue(525)]
            [EnumerationValue(526)]
            [EnumerationValue(527)]
            [EnumerationValue(528)]
            [EnumerationValue(529)]
            [EnumerationValue(530)]
            [EnumerationValue(531)]
            [EnumerationValue(532)]
            [EnumerationValue(533)]
            [EnumerationValue(534)]
            [EnumerationValue(535)]
            [EnumerationValue(536)]
            [EnumerationValue(537)]
            [EnumerationValue(538)]
            [EnumerationValue(539)]
            [EnumerationValue(540)]
            [EnumerationValue(541)]
            [EnumerationValue(542)]
            [EnumerationValue(543)]
            [EnumerationValue(544)]
            [EnumerationValue(545)]
            [EnumerationValue(546)]
            [EnumerationValue(547)]
            [EnumerationValue(598)]
            [EnumerationValue(599)]
            public List<typeofMilitaryActivity> typeofMilitaryActivity { get; set; } = [];
            public String? activePeriod { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];
            public Int32? minimumSafeDepth { get; set; } = default;

            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            [EnumerationValue(508)]
            [EnumerationValue(510)]
            [EnumerationValue(599)]
            public List<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea { get; set; } = [];
            public Int32? bottomVerticalSafetySeparation { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public String? agencyResponsibleForProduction { get; set; } = null;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            public areaCategory? areaCategory { get; set; } = default;

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            [EnumerationValue(501)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(501)]
            [EnumerationValue(503)]
            [EnumerationValue(517)]
            [EnumerationValue(520)]
            public List<status> status { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public String? controllingAuthority { get; set; } = null;

            [JsonIgnore]
            public override string Code => nameof(MilitaryPracticeArea);
            public informationBindingDefinition[] informationBindingDefinitions => MilitaryPracticeArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public MilitaryPracticeArea() {
                depthRestriction = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DiscolouredWater : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(DiscolouredWater);
            public informationBindingDefinition[] informationBindingDefinitions => DiscolouredWater._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DiscolouredWater._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DiscolouredWater() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CardinalBuoy : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public categoryOfCardinalMark categoryOfCardinalMark { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [Required()]
            public buoyShape buoyShape { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public topmark? topmark { get; set; }
            public List<information> information { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;

            [JsonIgnore]
            public override string Code => nameof(CardinalBuoy);
            public informationBindingDefinition[] informationBindingDefinitions => CardinalBuoy._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CardinalBuoy() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SafeWaterBuoy : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [Required()]
            public buoyShape buoyShape { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public topmark? topmark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(SafeWaterBuoy);
            public informationBindingDefinition[] informationBindingDefinitions => SafeWaterBuoy._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SafeWaterBuoy() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadioStation : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];
            public frequencyPair? frequencyPair { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public String? callsign { get; set; } = null;
            public fixedDateRange? fixedDateRange { get; set; }
            public String? communicationChannel { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(5)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            public List<categoryOfRadioStation> categoryOfRadioStation { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Decimal? estimatedRangeofTransmission { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [JsonIgnore]
            public override string Code => nameof(RadioStation);
            public informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public RadioStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MilitaryExerciseAirspace : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;
            public String? controllingAuthority { get; set; } = null;
            public String? activePeriod { get; set; } = null;
            public altitude? altitude { get; set; }
            public String? agencyResponsibleForProduction { get; set; } = null;
            public flightLevel? flightLevel { get; set; }

            [JsonIgnore]
            public override string Code => nameof(MilitaryExerciseAirspace);
            public informationBindingDefinition[] informationBindingDefinitions => MilitaryExerciseAirspace._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => MilitaryExerciseAirspace._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public MilitaryExerciseAirspace() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContiguousZone : FeatureNode, IFeatureBindingDefinition {
            public sourceIdentification? sourceIdentification { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(502)]
            [EnumerationValue(504)]
            [EnumerationValue(520)]
            public List<status> status { get; set; } = [];
            public Boolean? inDispute { get; set; } = default;

            [Required()]
            public List<String> nationality { get; set; }

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(ContiguousZone);
            public informationBindingDefinition[] informationBindingDefinitions => ContiguousZone._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => ContiguousZone._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public ContiguousZone() {
                nationality = new();
                ;
                nationalMaritimeAuthority = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NormalBaseline : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String nationality { get; set; } = string.Empty;
            public String? agencyResponsibleForProduction { get; set; } = null;

            [EnumerationValue(502)]
            [EnumerationValue(504)]
            public status? status { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }

            [JsonIgnore]
            public override string Code => nameof(NormalBaseline);
            public informationBindingDefinition[] informationBindingDefinitions => NormalBaseline._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => NormalBaseline._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public NormalBaseline() {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableArea : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(7)]
            [EnumerationValue(13)]
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(20)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            [EnumerationValue(39)]
            public List<restriction> restriction { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(7)]
            [EnumerationValue(10)]
            public List<categoryOfCable> categoryOfCable { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(CableArea);
            public informationBindingDefinition[] informationBindingDefinitions => CableArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CableArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CableArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContinentalShelfArea : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(502)]
            [EnumerationValue(504)]
            [EnumerationValue(520)]
            public status? status { get; set; } = default;
            public Boolean? inDispute { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];

            [Required()]
            public List<String> nationality { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;

            [JsonIgnore]
            public override string Code => nameof(ContinentalShelfArea);
            public informationBindingDefinition[] informationBindingDefinitions => ContinentalShelfArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => ContinentalShelfArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public ContinentalShelfArea() {
                nationalMaritimeAuthority = new();
                ;
                nationality = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InternalWaters : FeatureNode, IFeatureBindingDefinition {
            [Required()]
            public List<String> nationality { get; set; }

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public Boolean? inDispute { get; set; } = default;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public Boolean? lineTypeGeodesic { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(502)]
            [EnumerationValue(504)]
            [EnumerationValue(520)]
            public status? status { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(InternalWaters);
            public informationBindingDefinition[] informationBindingDefinitions => InternalWaters._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => InternalWaters._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public InternalWaters() {
                nationality = new();
                ;
                nationalMaritimeAuthority = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AdministrationArea : FeatureNode, IFeatureBindingDefinition {
            public String? pictorialRepresentation { get; set; } = null;
            public Boolean? inDispute { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [Required()]
            public jurisdiction jurisdiction { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public List<String> nationality { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(AdministrationArea);
            public informationBindingDefinition[] informationBindingDefinitions => AdministrationArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => AdministrationArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public AdministrationArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Bollard : FeatureNode, IFeatureBindingDefinition {
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(14)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(Bollard);
            public informationBindingDefinition[] informationBindingDefinitions => Bollard._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Bollard._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Bollard() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Dolphin : FeatureNode, IFeatureBindingDefinition {
            public String? pictorialRepresentation { get; set; } = null;
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public categoryOfDolphin categoryOfDolphin { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            public List<colour> colour { get; set; } = [];
            public List<information> information { get; set; } = [];
            public Decimal? elevation { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(14)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? height { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(Dolphin);
            public informationBindingDefinition[] informationBindingDefinitions => Dolphin._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Dolphin._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Dolphin() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarRange : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<String> communicationChannel { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(7)]
            public List<status> status { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(RadarRange);
            public informationBindingDefinition[] informationBindingDefinitions => RadarRange._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public RadarRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IsolatedDangerBeacon : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public beaconShape beaconShape { get; set; }
            public Boolean? radarConspicuous { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public String? pictorialRepresentation { get; set; } = null;
            public sourceIdentification? sourceIdentification { get; set; }
            public topmark? topmark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public Decimal? height { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(IsolatedDangerBeacon);
            public informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBeacon._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public IsolatedDangerBeacon() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IsolatedDangerBuoy : FeatureNode, IFeatureBindingDefinition {
            public fixedDateRange? fixedDateRange { get; set; }
            public topmark? topmark { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [Required()]
            public buoyShape buoyShape { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(IsolatedDangerBuoy);
            public informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBuoy._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public IsolatedDangerBuoy() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SubmarineTransitLane : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public String? nationality { get; set; } = null;
            public Int32? bottomVerticalSafetySeparation { get; set; } = default;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public String? controllingAuthority { get; set; } = null;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            public List<restriction> restriction { get; set; } = [];
            public String? agencyResponsibleForProduction { get; set; } = null;
            public Int32? minimumSafeDepth { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(SubmarineTransitLane);
            public informationBindingDefinition[] informationBindingDefinitions => SubmarineTransitLane._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SubmarineTransitLane._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SubmarineTransitLane() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MaritimeSafetyInformationArea : FeatureNode, IFeatureBindingDefinition {
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public String? agencyResponsibleForProduction { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(MaritimeSafetyInformationArea);
            public informationBindingDefinition[] informationBindingDefinitions => MaritimeSafetyInformationArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => MaritimeSafetyInformationArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public MaritimeSafetyInformationArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AirspaceRestriction : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];
            public String? agencyResponsibleForProduction { get; set; } = null;
            public flightLevel? flightLevel { get; set; }
            public String? controllingAuthority { get; set; } = null;
            public altitudeRange? altitudeRange { get; set; }
            public List<information> information { get; set; } = [];

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(2)]
            public heightLengthUnits? heightLengthUnits { get; set; } = default;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            public catagoryOfAirspaceRestriction? catagoryOfAirspaceRestriction { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(AirspaceRestriction);
            public informationBindingDefinition[] informationBindingDefinitions => AirspaceRestriction._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => AirspaceRestriction._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public AirspaceRestriction() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Sounding : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(18)]
            public status? status { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public Boolean? displayUncertainties { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(Sounding);
            public informationBindingDefinition[] informationBindingDefinitions => Sounding._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Sounding._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Sounding() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeBoundary : FeatureNode, IFeatureBindingDefinition {
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(9)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(TrafficSeparationSchemeBoundary);
            public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeBoundary._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeBoundary._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public TrafficSeparationSchemeBoundary() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DumpingGround : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public List<categoryOfDumpingGround> categoryOfDumpingGround { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            public List<restriction> restriction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? dateDisused { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(DumpingGround);
            public informationBindingDefinition[] informationBindingDefinitions => DumpingGround._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DumpingGround._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DumpingGround() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AirportAirfield : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public List<categoryOfAirportAirfield> categoryOfAirportAirfield { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public Int32? runwayLength { get; set; } = default;

            [EnumerationValue(2)]
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String? controllingAuthority { get; set; } = null;
            public Decimal? elevation { get; set; } = default;

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public String? pictorialRepresentation { get; set; } = null;
            public String? iCAOcode { get; set; } = null;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(14)]
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [JsonIgnore]
            public override string Code => nameof(AirportAirfield);
            public informationBindingDefinition[] informationBindingDefinitions => AirportAirfield._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => AirportAirfield._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public AirportAirfield() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FoulGround : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(13)]
            [EnumerationValue(18)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];
            public Decimal? valueOfSounding { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(FoulGround);
            public informationBindingDefinition[] informationBindingDefinitions => FoulGround._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => FoulGround._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public FoulGround() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightAirObstruction : FeatureNode, IFeatureBindingDefinition {
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Decimal? valueOfNominalRange { get; set; } = default;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public rythmOfLight? rythmOfLight { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public Int32? flareBearing { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            public heightLengthUnits? heightLengthUnits { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public List<lightVisibility> lightVisibility { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Decimal? relativeHorizontalAccuracy { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? relativeVerticalAccuracy { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            public List<colour> colour { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(LightAirObstruction);
            public informationBindingDefinition[] informationBindingDefinitions => LightAirObstruction._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LightAirObstruction() {
                pictorialRepresentation = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MooringBuoy : FeatureNode, IFeatureBindingDefinition {
            public Decimal? maximumPermittedVesselLength { get; set; } = default;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            public List<colour> colour { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [Required()]
            public buoyShape buoyShape { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;
            public Boolean? visitorsMooring { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [JsonIgnore]
            public override string Code => nameof(MooringBuoy);
            public informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public MooringBuoy() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class UnderwaterAwashRock : FeatureNode, IFeatureBindingDefinition {
            [Required()]
            public Decimal valueOfSounding { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;

            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Decimal? surroundingDepth { get; set; } = default;
            public List<information> information { get; set; } = [];

            [EnumerationValue(14)]
            [EnumerationValue(18)]
            public natureOfSurface? natureOfSurface { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public Boolean? displayUncertainties { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? horizontalLength { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public firstSourceInformation? firstSourceInformation { get; set; }
            public lastSourceInformation? lastSourceInformation { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(UnderwaterAwashRock);
            public informationBindingDefinition[] informationBindingDefinitions => UnderwaterAwashRock._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => UnderwaterAwashRock._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public UnderwaterAwashRock() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableOverhead : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(12)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(3)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            public categoryOfCable? categoryOfCable { get; set; } = default;
            public verticalClearanceSafe? verticalClearanceSafe { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public Decimal? iceFactor { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(CableOverhead);
            public informationBindingDefinition[] informationBindingDefinitions => CableOverhead._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CableOverhead._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CableOverhead() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ControlledAirspace : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            public controlledAirspaceClassDesignation? controlledAirspaceClassDesignation { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            [EnumerationValue(510)]
            [EnumerationValue(511)]
            [EnumerationValue(512)]
            [EnumerationValue(513)]
            [EnumerationValue(514)]
            [EnumerationValue(515)]
            [EnumerationValue(516)]
            [EnumerationValue(517)]
            [EnumerationValue(518)]
            [EnumerationValue(519)]
            [EnumerationValue(520)]
            [EnumerationValue(521)]
            [EnumerationValue(522)]
            public categoryOfControlledAirspace? categoryOfControlledAirspace { get; set; } = default;
            public String? controllingAuthority { get; set; } = null;
            public altitude? altitude { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;

            [EnumerationValue(2)]
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;
            public flightLevel? flightLevel { get; set; }

            [JsonIgnore]
            public override string Code => nameof(ControlledAirspace);
            public informationBindingDefinition[] informationBindingDefinitions => ControlledAirspace._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => ControlledAirspace._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public ControlledAirspace() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Obstruction : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public String? controllingAuthority { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(25)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            [EnumerationValue(510)]
            [EnumerationValue(511)]
            [EnumerationValue(513)]
            [EnumerationValue(514)]
            [EnumerationValue(515)]
            [EnumerationValue(516)]
            [EnumerationValue(517)]
            [EnumerationValue(519)]
            [EnumerationValue(520)]
            [EnumerationValue(521)]
            [EnumerationValue(522)]
            [EnumerationValue(523)]
            [EnumerationValue(524)]
            [EnumerationValue(525)]
            [EnumerationValue(526)]
            [EnumerationValue(527)]
            [EnumerationValue(528)]
            [EnumerationValue(529)]
            [EnumerationValue(530)]
            [EnumerationValue(531)]
            [EnumerationValue(532)]
            [EnumerationValue(533)]
            [EnumerationValue(534)]
            [EnumerationValue(535)]
            [EnumerationValue(536)]
            [EnumerationValue(537)]
            [EnumerationValue(540)]
            [EnumerationValue(541)]
            [EnumerationValue(542)]
            public List<product> product { get; set; } = [];
            public Boolean? existenceOfRestrictedArea { get; set; } = default;
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;
            public lastSourceInformation? lastSourceInformation { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public firstSourceInformation? firstSourceInformation { get; set; }
            public DateOnly? abandonmentDate { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public Decimal? soundingDepth { get; set; } = default;
            public orientation? orientation { get; set; }

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            [EnumerationValue(510)]
            [EnumerationValue(511)]
            [EnumerationValue(512)]
            [EnumerationValue(513)]
            [EnumerationValue(514)]
            [EnumerationValue(515)]
            [EnumerationValue(519)]
            [EnumerationValue(522)]
            [EnumerationValue(523)]
            [EnumerationValue(524)]
            [EnumerationValue(525)]
            [EnumerationValue(526)]
            [EnumerationValue(527)]
            [EnumerationValue(531)]
            [EnumerationValue(532)]
            public soundingDatum? soundingDatum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public magneticInformation? magneticInformation { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(13)]
            [EnumerationValue(18)]
            [EnumerationValue(28)]
            [EnumerationValue(501)]
            [EnumerationValue(503)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(507)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            [EnumerationValue(510)]
            [EnumerationValue(511)]
            [EnumerationValue(512)]
            [EnumerationValue(516)]
            [EnumerationValue(517)]
            [EnumerationValue(518)]
            public List<status> status { get; set; } = [];
            public verticalUncertainty? verticalUncertainty { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public Int32? generalWaterDepth { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public detectionDateRange? detectionDateRange { get; set; }
            public String? oprtor { get; set; } = null;

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            [EnumerationValue(501)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? height { get; set; } = default;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            public sonarSignalStrength? sonarSignalStrength { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public DateOnly? spuddedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(506)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            public categoryOfObstruction? categoryOfObstruction { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public DateOnly? dateSunk { get; set; } = default;
            public Decimal? horizontalLength { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public String? currentScourDimensions { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            public cardinalPointOrientation? cardinalPointOrientation { get; set; } = default;
            public Decimal? valueOfSounding { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public String? nation { get; set; } = null;
            public Decimal? defaultClearanceDepth { get; set; } = default;
            public Boolean? displayUncertainties { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(Obstruction);
            public informationBindingDefinition[] informationBindingDefinitions => Obstruction._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Obstruction._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Obstruction() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FishingGround : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(14)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(39)]
            public List<restriction> restriction { get; set; } = [];
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(FishingGround);
            public informationBindingDefinition[] informationBindingDefinitions => FishingGround._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => FishingGround._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public FishingGround() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FishingFacility : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(18)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            public categoryOfFishingFacility? categoryOfFishingFacility { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(FishingFacility);
            public informationBindingDefinition[] informationBindingDefinitions => FishingFacility._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => FishingFacility._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public FishingFacility() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NavigationSystem : FeatureNode, IFeatureBindingDefinition {
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public String? agencyResponsibleForProduction { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            [EnumerationValue(506)]
            [EnumerationValue(508)]
            [EnumerationValue(509)]
            [EnumerationValue(510)]
            public categoryOfRadioStation? categoryOfRadioStation { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String? callsign { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];
            public String? communicationChannel { get; set; } = null;
            public Int32? signalFrequency { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(NavigationSystem);
            public informationBindingDefinition[] informationBindingDefinitions => NavigationSystem._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => NavigationSystem._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public NavigationSystem() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeCrossing : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            public List<restriction> restriction { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(6)]
            [EnumerationValue(9)]
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(TrafficSeparationSchemeCrossing);
            public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeCrossing._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeCrossing._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public TrafficSeparationSchemeCrossing() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeLanePart : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            public List<restriction> restriction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? orientationValue { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(9)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(TrafficSeparationSchemeLanePart);
            public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeLanePart._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeLanePart._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public TrafficSeparationSchemeLanePart() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TerritorialSeaArea : FeatureNode, IFeatureBindingDefinition {
            [Required()]
            public List<String> nationality { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(502)]
            [EnumerationValue(504)]
            [EnumerationValue(520)]
            public status? status { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(12)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(27)]
            public List<restriction> restriction { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(TerritorialSeaArea);
            public informationBindingDefinition[] informationBindingDefinitions => TerritorialSeaArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => TerritorialSeaArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public TerritorialSeaArea() {
                nationality = new();
                ;
                nationalMaritimeAuthority = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LateralBeacon : FeatureNode, IFeatureBindingDefinition {
            public Decimal? elevation { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public beaconShape beaconShape { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public categoryOfLateralMark categoryOfLateralMark { get; set; }
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public Boolean? radarConspicuous { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public topmark? topmark { get; set; }
            public Decimal? height { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }

            [JsonIgnore]
            public override string Code => nameof(LateralBeacon);
            public informationBindingDefinition[] informationBindingDefinitions => LateralBeacon._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LateralBeacon() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CoastGuardStation : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Boolean? isMRCC { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public List<String> communicationsChannel { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(CoastGuardStation);
            public informationBindingDefinition[] informationBindingDefinitions => CoastGuardStation._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CoastGuardStation._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CoastGuardStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeparationZoneOrLine : FeatureNode, IFeatureBindingDefinition {
            public DateOnly? reportedDate { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(9)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }

            [JsonIgnore]
            public override string Code => nameof(SeparationZoneOrLine);
            public informationBindingDefinition[] informationBindingDefinitions => SeparationZoneOrLine._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SeparationZoneOrLine._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SeparationZoneOrLine() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class BottomFeature : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public Int32? migrationDirection { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? horizontalLength { get; set; } = default;

            [EnumerationValue(502)]
            [EnumerationValue(510)]
            public bottomFeatureClassification? bottomFeatureClassification { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(BottomFeature);
            public informationBindingDefinition[] informationBindingDefinitions => BottomFeature._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => BottomFeature._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public BottomFeature() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ArchipelagicBaseline : FeatureNode, IFeatureBindingDefinition {
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(502)]
            [EnumerationValue(504)]
            public status? status { get; set; } = default;
            public Boolean? inDispute { get; set; } = default;
            public String nationality { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public String? agencyResponsibleForProduction { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(ArchipelagicBaseline);
            public informationBindingDefinition[] informationBindingDefinitions => ArchipelagicBaseline._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => ArchipelagicBaseline._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public ArchipelagicBaseline() {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SmallBottomObject : FeatureNode, IFeatureBindingDefinition {
            public String? agencyResponsibleForProduction { get; set; } = null;

            [EnumerationValue(504)]
            public statusOfSmallBottomObject? statusOfSmallBottomObject { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];

            [Required()]
            public Decimal valueOfSounding { get; set; }

            [JsonIgnore]
            public override string Code => nameof(SmallBottomObject);
            public informationBindingDefinition[] informationBindingDefinitions => SmallBottomObject._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SmallBottomObject._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SmallBottomObject() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ExclusiveEconomicZone : FeatureNode, IFeatureBindingDefinition {
            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public Boolean? inDispute { get; set; } = default;

            [Required()]
            public List<String> nationality { get; set; }

            [JsonIgnore]
            public override string Code => nameof(ExclusiveEconomicZone);
            public informationBindingDefinition[] informationBindingDefinitions => ExclusiveEconomicZone._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => ExclusiveEconomicZone._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public ExclusiveEconomicZone() {
                nationalMaritimeAuthority = new();
                ;
                nationality = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarStation : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public categoryOfRadarStation? categoryOfRadarStation { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public String? callsign { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<String> communicationChannel { get; set; } = [];
            public Decimal? valueOfMaximumRange { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(RadarStation);
            public informationBindingDefinition[] informationBindingDefinitions => RadarStation._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => RadarStation._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public RadarStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DivingLocation : FeatureNode, IFeatureBindingDefinition {
            public Decimal? waterClarity { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            public divingActivity? divingActivity { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(DivingLocation);
            public informationBindingDefinition[] informationBindingDefinitions => DivingLocation._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DivingLocation._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DivingLocation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RestrictedArea : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(12)]
            [EnumerationValue(14)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            [EnumerationValue(501)]
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String? nationality { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(9)]
            [EnumerationValue(18)]
            [EnumerationValue(28)]
            [EnumerationValue(501)]
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public String? controllingAuthority { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(39)]
            [EnumerationValue(42)]
            [Required()]
            public List<restriction> restriction { get; set; }

            [JsonIgnore]
            public override string Code => nameof(RestrictedArea);
            public informationBindingDefinition[] informationBindingDefinitions => RestrictedArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => RestrictedArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public RestrictedArea() {
                restriction = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableSubmarine : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(4)]
            [EnumerationValue(13)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public Decimal? buriedDepth { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            public categoryOfCable? categoryOfCable { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public fixedDateRange? fixedDateRange { get; set; }

            [JsonIgnore]
            public override string Code => nameof(CableSubmarine);
            public informationBindingDefinition[] informationBindingDefinitions => CableSubmarine._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CableSubmarine() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Wreck : FeatureNode, IFeatureBindingDefinition {
            public Decimal? surroundingDepth { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public horizontalPositionUncertainty? horizontalPositionUncertainty { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Decimal? horizontalLength { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public String? currentScourDimensions { get; set; } = null;

            [EnumerationValue(7)]
            [EnumerationValue(13)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            public sonarSignalStrength? sonarSignalStrength { get; set; } = default;
            public List<information> information { get; set; } = [];
            public magneticInformation? magneticInformation { get; set; }
            public String? agencyResponsibleForProduction { get; set; } = null;

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public natureOfSurface? natureOfSurface { get; set; } = default;
            public Decimal? orientationValue { get; set; } = default;
            public String? typeOfWreck { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            public categoryOfWreck? categoryOfWreck { get; set; } = default;

            [EnumerationValue(4)]
            [EnumerationValue(5)]
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Decimal? height { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String? debrisField { get; set; } = null;

            [Required()]
            public List<String> nationality { get; set; }
            public lastSourceInformation? lastSourceInformation { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            public cardinalPointOrientation? cardinalPointOrientation { get; set; } = default;
            public List<vesselMeasurementsSpecification> vesselMeasurementsSpecification { get; set; } = [];
            public Boolean? existenceOfRestrictedArea { get; set; } = default;
            public DateOnly? dateSunk { get; set; } = default;
            public firstSourceInformation? firstSourceInformation { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;
            public Decimal? valueOfSounding { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            public List<product> product { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;
            public Boolean? displayUncertainties { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(Wreck);
            public informationBindingDefinition[] informationBindingDefinitions => Wreck._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Wreck._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Wreck() {
                nationality = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class QRoute : FeatureNode, IFeatureBindingDefinition {
            public String? agencyResponsibleForProduction { get; set; } = null;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(2)]
            [EnumerationValue(503)]
            public List<status> status { get; set; } = [];
            public qRouteChannelWidth? qRouteChannelWidth { get; set; }
            public directionHeading? directionHeading { get; set; }
            public String? nationality { get; set; } = null;

            [JsonIgnore]
            public override string Code => nameof(QRoute);
            public informationBindingDefinition[] informationBindingDefinitions => QRoute._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => QRoute._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public QRoute() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CompletenessOfProductSpecification : FeatureNode, IFeatureBindingDefinition {
            public String? agencyResponsibleForProduction { get; set; } = null;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [Required()]
            public categoryOfCompleteness categoryOfCompleteness { get; set; }
            public String? copyrightStatement { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(CompletenessOfProductSpecification);
            public informationBindingDefinition[] informationBindingDefinitions => CompletenessOfProductSpecification._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CompletenessOfProductSpecification._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CompletenessOfProductSpecification() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RescueStation : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(14)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            public List<status> status { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<String> communicationChannel { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<categoryOfRescueStation> categoryOfRescueStation { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(RescueStation);
            public informationBindingDefinition[] informationBindingDefinitions => RescueStation._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => RescueStation._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public RescueStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CardinalBeacon : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public beaconShape beaconShape { get; set; }
            public topmark? topmark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public categoryOfCardinalMark categoryOfCardinalMark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public Decimal? elevation { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(CardinalBeacon);
            public informationBindingDefinition[] informationBindingDefinitions => CardinalBeacon._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CardinalBeacon() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightVessel : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(14)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;
            public Decimal? horizontalLength { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Decimal? horizontalWidth { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(LightVessel);
            public informationBindingDefinition[] informationBindingDefinitions => LightVessel._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LightVessel() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FisheryZone : FeatureNode, IFeatureBindingDefinition {
            public String? interoperabilityIdentifier { get; set; } = null;
            public String nationality { get; set; } = string.Empty;

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public List<String> species { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(504)]
            [EnumerationValue(519)]
            [EnumerationValue(521)]
            public status? status { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(FisheryZone);
            public informationBindingDefinition[] informationBindingDefinitions => FisheryZone._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => FisheryZone._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public FisheryZone() {
                nationality = string.Empty;
                nationalMaritimeAuthority = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DredgedArea : FeatureNode, IFeatureBindingDefinition {
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public DateOnly? dredgedDate { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? depthRangeMaximumValue { get; set; } = default;

            [EnumerationValue(10)]
            [EnumerationValue(11)]
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(23)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            [EnumerationValue(39)]
            public List<restriction> restriction { get; set; } = [];
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(DredgedArea);
            public informationBindingDefinition[] informationBindingDefinitions => DredgedArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DredgedArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DredgedArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FerryRoute : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(14)]
            public List<status> status { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String? agencyResponsibleForProduction { get; set; } = null;
            public String? pictorialRepresentation { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            [Required()]
            public List<categoryOfFerry> categoryOfFerry { get; set; }
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [JsonIgnore]
            public override string Code => nameof(FerryRoute);
            public informationBindingDefinition[] informationBindingDefinitions => FerryRoute._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => FerryRoute._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public FerryRoute() {
                categoryOfFerry = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ShorelineConstruction : FeatureNode, IFeatureBindingDefinition {
            public Decimal? horizontalLength { get; set; } = default;

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            public gradientOfSlope? gradientOfSlope { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            public List<colour> colour { get; set; } = [];
            public Decimal? horizontalWidth { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(20)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(501)]
            public categoryOfShorelineConstruction? categoryOfShorelineConstruction { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(ShorelineConstruction);
            public informationBindingDefinition[] informationBindingDefinitions => ShorelineConstruction._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => ShorelineConstruction._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public ShorelineConstruction() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CautionArea : FeatureNode, IFeatureBindingDefinition {
            public DateOnly? reportedDate { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(5)]
            [EnumerationValue(7)]
            public status? status { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(CautionArea);
            public informationBindingDefinition[] informationBindingDefinitions => CautionArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CautionArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DeepWaterRoutePart : FeatureNode, IFeatureBindingDefinition {
            public Boolean? imoAdopted { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;

            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(6)]
            [EnumerationValue(9)]
            [EnumerationValue(28)]
            public List<status> status { get; set; } = [];

            [Required()]
            public Decimal orientationValue { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            public List<restriction> restriction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(DeepWaterRoutePart);
            public informationBindingDefinition[] informationBindingDefinitions => DeepWaterRoutePart._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoutePart._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DeepWaterRoutePart() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CurrentNonGravitational : FeatureNode, IFeatureBindingDefinition {
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public orientation orientation { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [Required()]
            public speed speed { get; set; }

            [EnumerationValue(5)]
            public status? status { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(CurrentNonGravitational);
            public informationBindingDefinition[] informationBindingDefinitions => CurrentNonGravitational._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => CurrentNonGravitational._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public CurrentNonGravitational() {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
                speed = new speed()
                {
                    speedMaximum = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
            public Int32? drawingIndex { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public categoryOfCoverage? categoryOfCoverage { get; set; } = default;

            [Required()]
            public Int32 optimumDisplayScale { get; set; }

            [Required()]
            public Int32 minimumDisplayScale { get; set; }
            public List<information> information { get; set; } = [];

            [Required()]
            public Int32 maximumDisplayScale { get; set; }

            [JsonIgnore]
            public override string Code => nameof(DataCoverage);
            public informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DataCoverage() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeabedArea : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public String? agencyResponsibleForProduction { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [Required()]
            public List<surfaceCharacteristics> surfaceCharacteristics { get; set; }
            public Decimal? attenuation { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(SeabedArea);
            public informationBindingDefinition[] informationBindingDefinitions => SeabedArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SeabedArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SeabedArea() {
                surfaceCharacteristics = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpecialPurposeGeneralBuoy : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [Required()]
            public buoyShape buoyShape { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            [EnumerationValue(33)]
            [EnumerationValue(34)]
            [EnumerationValue(35)]
            [EnumerationValue(36)]
            [EnumerationValue(37)]
            [EnumerationValue(39)]
            [EnumerationValue(40)]
            [EnumerationValue(42)]
            [EnumerationValue(43)]
            [EnumerationValue(45)]
            [EnumerationValue(46)]
            [EnumerationValue(47)]
            [EnumerationValue(48)]
            [EnumerationValue(49)]
            [EnumerationValue(50)]
            [EnumerationValue(51)]
            [EnumerationValue(52)]
            [EnumerationValue(53)]
            [EnumerationValue(54)]
            [EnumerationValue(55)]
            [EnumerationValue(56)]
            [EnumerationValue(57)]
            [EnumerationValue(58)]
            [EnumerationValue(59)]
            [EnumerationValue(60)]
            [EnumerationValue(61)]
            [EnumerationValue(62)]
            [EnumerationValue(63)]
            [Required()]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(18)]
            [EnumerationValue(503)]
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public topmark? topmark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<fixedDateRange> fixedDateRange { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(SpecialPurposeGeneralBuoy);
            public informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBuoy._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SpecialPurposeGeneralBuoy() {
                categoryOfSpecialPurposeMark = new();
                ;
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightSectored : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            public List<status> status { get; set; } = [];
            public Decimal? relativeHorizontalAccuracy { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Decimal? relativeVerticalAccuracy { get; set; } = default;

            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            public List<categoryOfLight> categoryOfLight { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Decimal? height { get; set; } = default;

            [EnumerationValue(1)]
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [Required()]
            public List<sectorCharacteristics> sectorCharacteristics { get; set; }

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }

            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public signalGeneration? signalGeneration { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(LightSectored);
            public informationBindingDefinition[] informationBindingDefinitions => LightSectored._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LightSectored() {
                pictorialRepresentation = string.Empty;
                sectorCharacteristics = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IceLine : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(IceLine);
            public informationBindingDefinition[] informationBindingDefinitions => IceLine._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => IceLine._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public IceLine() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AnchorageArea : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(27)]
            [EnumerationValue(39)]
            public List<restriction> restriction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public periodicDateRange? periodicDateRange { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            public List<categoryOfAnchorage> categoryOfAnchorage { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(14)]
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(AnchorageArea);
            public informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public AnchorageArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LateralBuoy : FeatureNode, IFeatureBindingDefinition {
            public Boolean? radarConspicuous { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;
            public String? pictorialRepresentation { get; set; } = null;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public categoryOfLateralMark categoryOfLateralMark { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [Required()]
            public buoyShape buoyShape { get; set; }
            public topmark? topmark { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public Decimal? verticalLength { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(LateralBuoy);
            public informationBindingDefinition[] informationBindingDefinitions => LateralBuoy._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LateralBuoy() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeRoundabout : FeatureNode, IFeatureBindingDefinition {
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(6)]
            [EnumerationValue(9)]
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(27)]
            public List<restriction> restriction { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(TrafficSeparationSchemeRoundabout);
            public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeRoundabout._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeRoundabout._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public TrafficSeparationSchemeRoundabout() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DeepWaterRouteCentreline : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(6)]
            [EnumerationValue(9)]
            public List<status> status { get; set; } = [];
            public Boolean? imoAdopted { get; set; } = default;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [Required()]
            public Boolean basedOnFixedMarks { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(13)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(DeepWaterRouteCentreline);
            public informationBindingDefinition[] informationBindingDefinitions => DeepWaterRouteCentreline._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DeepWaterRouteCentreline._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DeepWaterRouteCentreline() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightFloat : FeatureNode, IFeatureBindingDefinition {
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(14)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(11)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public String? pictorialRepresentation { get; set; } = null;
            public topmark? topmark { get; set; }
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(LightFloat);
            public informationBindingDefinition[] informationBindingDefinitions => LightFloat._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LightFloat() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightAllAround : FeatureNode, IFeatureBindingDefinition {
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public signalGeneration? signalGeneration { get; set; } = default;
            public Decimal? valueOfNominalRange { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public multiplicityOfFeatures multiplicityOfFeatures { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public Decimal? relativeHorizontalAccuracy { get; set; } = default;

            [EnumerationValue(3)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Boolean? majorLight { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public lightVisibility? lightVisibility { get; set; } = default;
            public Int32? flareBearing { get; set; } = default;

            [EnumerationValue(1)]
            public heightLengthUnits? heightLengthUnits { get; set; } = default;

            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            public List<categoryOfLight> categoryOfLight { get; set; } = [];

            [Required()]
            public rythmOfLight rythmOfLight { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [Required()]
            public List<colour> colour { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(LightAllAround);
            public informationBindingDefinition[] informationBindingDefinitions => LightAllAround._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LightAllAround() {
                multiplicityOfFeatures = new multiplicityOfFeatures()
                {
                    multiplicityKnown = default(Boolean),
                };
                rythmOfLight = new rythmOfLight()
                {
                    lightCharacteristic = default(lightCharacteristic),
                };
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Coastline : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(11)]
            [EnumerationValue(13)]
            public List<colour> colour { get; set; } = [];
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(10)]
            public categoryOfCoastline? categoryOfCoastline { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public String? interoperabilityIdentifier { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            [EnumerationValue(14)]
            [EnumerationValue(17)]
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;
            public DateOnly? reportedDate { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(Coastline);
            public informationBindingDefinition[] informationBindingDefinitions => Coastline._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Coastline._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Coastline() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeaAreaNamedWaterArea : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            [EnumerationValue(33)]
            [EnumerationValue(34)]
            [EnumerationValue(35)]
            [EnumerationValue(36)]
            [EnumerationValue(37)]
            [EnumerationValue(38)]
            [EnumerationValue(39)]
            [EnumerationValue(40)]
            [EnumerationValue(41)]
            [EnumerationValue(42)]
            [EnumerationValue(43)]
            [EnumerationValue(44)]
            [EnumerationValue(45)]
            [EnumerationValue(46)]
            [EnumerationValue(47)]
            [EnumerationValue(48)]
            [EnumerationValue(49)]
            [EnumerationValue(50)]
            [EnumerationValue(51)]
            [EnumerationValue(52)]
            [EnumerationValue(53)]
            [EnumerationValue(54)]
            [EnumerationValue(55)]
            [EnumerationValue(56)]
            public categoryOfSeaArea? categoryOfSeaArea { get; set; } = default;
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(503)]
            [EnumerationValue(504)]
            [EnumerationValue(505)]
            public gradient? gradient { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(4)]
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(SeaAreaNamedWaterArea);
            public informationBindingDefinition[] informationBindingDefinitions => SeaAreaNamedWaterArea._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SeaAreaNamedWaterArea._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SeaAreaNamedWaterArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DropZone : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(DropZone);
            public informationBindingDefinition[] informationBindingDefinitions => DropZone._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => DropZone._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public DropZone() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Conveyor : FeatureNode, IFeatureBindingDefinition {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            public categoryOfConveyor? categoryOfConveyor { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            public List<colour> colour { get; set; } = [];
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [EnumerationValue(4)]
            [EnumerationValue(12)]
            public List<status> status { get; set; } = [];
            public Decimal? liftingCapacity { get; set; } = default;
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }

            [EnumerationValue(3)]
            [EnumerationValue(13)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(44)]
            public verticalDatum? verticalDatum { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;
            public fixedDateRange? fixedDateRange { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;

            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            [EnumerationValue(15)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(22)]
            [EnumerationValue(25)]
            public List<product> product { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(Conveyor);
            public informationBindingDefinition[] informationBindingDefinitions => Conveyor._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => Conveyor._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public Conveyor() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LineOfDelimitation : FeatureNode, IFeatureBindingDefinition {
            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }

            [EnumerationValue(501)]
            [EnumerationValue(502)]
            [EnumerationValue(504)]
            [EnumerationValue(599)]
            public boundaryStatusType? boundaryStatusType { get; set; } = default;
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public jurisdiction? jurisdiction { get; set; } = default;

            [EnumerationValue(501)]
            [EnumerationValue(506)]
            [EnumerationValue(511)]
            [EnumerationValue(599)]
            public categoryofBoundaryLine? categoryofBoundaryLine { get; set; } = default;
            public Boolean? inDispute { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(LineOfDelimitation);
            public informationBindingDefinition[] informationBindingDefinitions => LineOfDelimitation._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => LineOfDelimitation._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public LineOfDelimitation() {
                nationalMaritimeAuthority = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class StraightTerritorialSeaBaseline : FeatureNode, IFeatureBindingDefinition {
            public String nationality { get; set; } = string.Empty;
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];

            [EnumerationValue(502)]
            [EnumerationValue(504)]
            public status? status { get; set; } = default;
            public Boolean? inDispute { get; set; } = default;
            public String? agencyResponsibleForProduction { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(StraightTerritorialSeaBaseline);
            public informationBindingDefinition[] informationBindingDefinitions => StraightTerritorialSeaBaseline._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => StraightTerritorialSeaBaseline._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public StraightTerritorialSeaBaseline() {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SafeWaterBeacon : FeatureNode, IFeatureBindingDefinition {
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Decimal? elevation { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public topmark? topmark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? verticalLength { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public beaconShape beaconShape { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public String? interoperabilityIdentifier { get; set; } = null;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;

            [JsonIgnore]
            public override string Code => nameof(SafeWaterBeacon);
            public informationBindingDefinition[] informationBindingDefinitions => SafeWaterBeacon._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SafeWaterBeacon() {
                colour = new();
                ;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpecialPurposeGeneralBeacon : FeatureNode, IFeatureBindingDefinition {
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(12)]
            [EnumerationValue(18)]
            public List<status> status { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public String? interoperabilityIdentifier { get; set; } = null;
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? height { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(5)]
            public condition? condition { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public Decimal? elevation { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public colourPattern? colourPattern { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public String? pictorialRepresentation { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public beaconShape beaconShape { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public topmark? topmark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(14)]
            [EnumerationValue(16)]
            [EnumerationValue(17)]
            [EnumerationValue(18)]
            [EnumerationValue(19)]
            [EnumerationValue(20)]
            [EnumerationValue(21)]
            [EnumerationValue(22)]
            [EnumerationValue(23)]
            [EnumerationValue(24)]
            [EnumerationValue(25)]
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            [EnumerationValue(33)]
            [EnumerationValue(34)]
            [EnumerationValue(35)]
            [EnumerationValue(36)]
            [EnumerationValue(37)]
            [EnumerationValue(39)]
            [EnumerationValue(40)]
            [EnumerationValue(41)]
            [EnumerationValue(42)]
            [EnumerationValue(43)]
            [EnumerationValue(44)]
            [EnumerationValue(45)]
            [EnumerationValue(46)]
            [EnumerationValue(47)]
            [EnumerationValue(48)]
            [EnumerationValue(49)]
            [EnumerationValue(50)]
            [EnumerationValue(51)]
            [EnumerationValue(52)]
            [EnumerationValue(53)]
            [EnumerationValue(54)]
            [EnumerationValue(55)]
            [EnumerationValue(56)]
            [EnumerationValue(57)]
            [EnumerationValue(58)]
            [EnumerationValue(60)]
            [EnumerationValue(61)]
            [EnumerationValue(62)]
            [EnumerationValue(63)]
            [Required()]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(9)]
            [EnumerationValue(11)]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public visualProminence? visualProminence { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public List<colour> colour { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [JsonIgnore]
            public override string Code => nameof(SpecialPurposeGeneralBeacon);
            public informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBeacon._informationBindingDefinitions;
            public static informationBindingDefinition[] _informationBindingDefinitions => [];
            public featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;
            public static featureBindingDefinition[] _featureBindingDefinitions => [];

            public SpecialPurposeGeneralBeacon() {
                categoryOfSpecialPurposeMark = new();
                ;
                colour = new();
                ;
            }
        }
    }
}