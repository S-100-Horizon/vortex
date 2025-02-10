#nullable enable
namespace S100Framework.DomainModel.S501
{
    public static class Information {
        public static Version Version => new Version("0.0.5");
        public static string[] ComplexTypes => ["qRouteChannelWidth", "detectionDateRange", "multiplicityOfFeatures", "onlineResource", "featureName", "fixedDateRange", "altitudeRange", "altitude", "lastSourceInformation", "information", "firstSourceInformation", "horizontalClearanceFixed", "verticalUncertainty", "frequencyPair", "vesselMeasurementsSpecification", "surfaceCharacteristics", "magneticInformation", "speed", "verticalClearanceFixed", "sourceIdentification", "horizontalPositionUncertainty", "orientation", "directionHeading", "flightLevel", "vesselSpeedLimit", "periodicDateRange", "shapeInformation", "signalSequence", "sectorInformation", "directionalCharacter", "sectorLimitTwo", "sectorLimitOne", "topmark", "rythmOfLight", "verticalClearanceSafe", "sectorLimit", "lightSector", "sectorCharacteristics",];
        public static string[] InformationAssociationTypes => [];
        public static string[] FeatureAssociationTypes => [];
        public static string[] InformationTypes => ["ReferenceToAPublication",];
        public static string[] FeatureTypes => ["InstallationBuoy", "DepthArea", "RadioCallingInPoint", "PatrolArea", "Checkpoint", "MarineManagementArea", "DepthContour", "EnvironmentallySensitiveSeaArea", "Road", "River", "MilitaryPracticeArea", "DiscolouredWater", "CardinalBuoy", "SafeWaterBuoy", "RadioStation", "MilitaryExerciseAirspace", "ContiguousZone", "NormalBaseline", "CableArea", "ContinentalShelfArea", "InternalWaters", "AdministrationArea", "Bollard", "Dolphin", "RadarRange", "IsolatedDangerBeacon", "IsolatedDangerBuoy", "SubmarineTransitLane", "MaritimeSafetyInformationArea", "AirspaceRestriction", "Sounding", "TrafficSeparationSchemeBoundary", "DumpingGround", "AirportAirfield", "FoulGround", "LightAirObstruction", "MooringBuoy", "UnderwaterAwashRock", "CableOverhead", "ControlledAirspace", "Obstruction", "FishingGround", "FishingFacility", "NavigationSystem", "TrafficSeparationSchemeCrossing", "TrafficSeparationSchemeLanePart", "TerritorialSeaArea", "LateralBeacon", "CoastGuardStation", "SeparationZoneOrLine", "BottomFeature", "ArchipelagicBaseline", "SmallBottomObject", "ExclusiveEconomicZone", "RadarStation", "DivingLocation", "RestrictedArea", "CableSubmarine", "Wreck", "QRoute", "CompletenessOfProductSpecification", "RescueStation", "CardinalBeacon", "LightVessel", "FisheryZone", "DredgedArea", "FerryRoute", "ShorelineConstruction", "CautionArea", "DeepWaterRoutePart", "CurrentNonGravitational", "DataCoverage", "SeabedArea", "SpecialPurposeGeneralBuoy", "LightSectored", "IceLine", "AnchorageArea", "LateralBuoy", "TrafficSeparationSchemeRoundabout", "DeepWaterRouteCentreline", "LightFloat", "LightAllAround", "Coastline", "SeaAreaNamedWaterArea", "DropZone", "Conveyor", "LineOfDelimitation", "StraightTerritorialSeaBaseline", "SafeWaterBeacon", "SpecialPurposeGeneralBeacon",];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum visualProminence : int {
        [System.ComponentModel.Description("Term applied to an object either natural or artificial which is distinctly and notably visible from seaward.")]
        VisuallyConspicuous = 1,
        [System.ComponentModel.Description("An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.")]
        NotVisuallyConspicuous = 2,
        [System.ComponentModel.Description("Objects which are easily identifiable, but do not justify being classed as conspicuous.")]
        Prominent = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum gradientOfSlope : int {
        [System.ComponentModel.Description("501:Steep (missing definition)")]
        Steep = 501,
        [System.ComponentModel.Description("502:Moderate (missing definition)")]
        Moderate = 502,
        [System.ComponentModel.Description("503:Gentle (missing definition)")]
        Gentle = 503,
        [System.ComponentModel.Description("504:Mild (missing definition)")]
        Mild = 504,
        [System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
        Flat = 505,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum typeofMilitaryActivity : int {
        [System.ComponentModel.Description("501:Anti Aircraft (ground to air) (missing definition)")]
        AntiAircraftGroundToAir = 501,
        [System.ComponentModel.Description("502:High and Low angle gunnery (ground to ground) (missing definition)")]
        HighAndLowAngleGunneryGroundToGround = 502,
        [System.ComponentModel.Description("503:Air to Air Firing (missing definition)")]
        AirToAirFiring = 503,
        [System.ComponentModel.Description("504:Air Combat Training (missing definition)")]
        AirCombatTraining = 504,
        [System.ComponentModel.Description("505:Air Dropped Torpedo (missing definition)")]
        AirDroppedTorpedo = 505,
        [System.ComponentModel.Description("506:Aircraft General (missing definition)")]
        AircraftGeneral = 506,
        [System.ComponentModel.Description("507:Air to Surface Firing (missing definition)")]
        AirToSurfaceFiring = 507,
        [System.ComponentModel.Description("508:Anti Submarine Warfare Exercises (missing definition)")]
        AntiSubmarineWarfareExercises = 508,
        [System.ComponentModel.Description("509:Acoustic Trials (missing definition)")]
        AcousticTrials = 509,
        [System.ComponentModel.Description("510:Air Tactical Training (missing definition)")]
        AirTacticalTraining = 510,
        [System.ComponentModel.Description("511:Bombing (missing definition)")]
        Bombing = 511,
        [System.ComponentModel.Description("512:Depth Charge dropping/firing (including rocket/mortar fired DC) (missing definition)")]
        DepthChargeDroppingFiringIncludingRocketMortarFiredDc = 512,
        [System.ComponentModel.Description("Neutralization of the strength of the magnetic field of a vessel, by means of suitably arranged electric coils permanently installed in the vessel. See also Degaussing Cable.")]
        Degaussing = 513,
        [System.ComponentModel.Description("514:Demolition of unexploded ordnance (missing definition)")]
        DemolitionOfUnexplodedOrdnance = 514,
        [System.ComponentModel.Description("515:Explosives Trials (missing definition)")]
        ExplosivesTrials = 515,
        [System.ComponentModel.Description("516:Firing (missing definition)")]
        Firing = 516,
        [System.ComponentModel.Description("517:Flares (missing definition)")]
        Flares = 517,
        [System.ComponentModel.Description("518:Glow Worm (missing definition)")]
        GlowWorm = 518,
        [System.ComponentModel.Description("519:General Practice (missing definition)")]
        GeneralPractice = 519,
        [System.ComponentModel.Description("520:Guided Weapons (air Flight) (missing definition)")]
        GuidedWeaponsAirFlight = 520,
        [System.ComponentModel.Description("521:Helicopter exercises (missing definition)")]
        HelicopterExercises = 521,
        [System.ComponentModel.Description("522:High Energy Manouvres (missing definition)")]
        HighEnergyManouvres = 522,
        [System.ComponentModel.Description("523:HM Ships (non-firing exercises, practices and trials) (missing definition)")]
        HmShipsNonFiringExercisesPracticesAndTrials = 523,
        [System.ComponentModel.Description("524:Live ASW firing (missing definition)")]
        LiveAswFiring = 524,
        [System.ComponentModel.Description("525:Mine Counter Measures (missing definition)")]
        MineCounterMeasures = 525,
        [System.ComponentModel.Description("526:Mine Disposal (missing definition)")]
        MineDisposal = 526,
        [System.ComponentModel.Description("527:Missile Firing (missing definition)")]
        MissileFiring = 527,
        [System.ComponentModel.Description("528:Mortar Firing (missing definition)")]
        MortarFiring = 528,
        [System.ComponentModel.Description("529:Naval Gunfire Support (missing definition)")]
        NavalGunfireSupport = 529,
        [System.ComponentModel.Description("530:Noise Ranging (missing definition)")]
        NoiseRanging = 530,
        [System.ComponentModel.Description("531:Parachute Dropping (missing definition)")]
        ParachuteDropping = 531,
        [System.ComponentModel.Description("532:Pilotless Target Aircraft (missing definition)")]
        PilotlessTargetAircraft = 532,
        [System.ComponentModel.Description("533:Radar Training Buoy (missing definition)")]
        RadarTrainingBuoy = 533,
        [System.ComponentModel.Description("534:Submarine Exercises (missing definition)")]
        SubmarineExercises = 534,
        [System.ComponentModel.Description("Suspension in the atmosphere of small particles produced by combustion.")]
        Smoke = 535,
        [System.ComponentModel.Description("536:Sonobuoy Dropping (missing definition)")]
        SonobuoyDropping = 536,
        [System.ComponentModel.Description("537:Starshell (missing definition)")]
        Starshell = 537,
        [System.ComponentModel.Description("538:Surface Target Towing (missing definition)")]
        SurfaceTargetTowing = 538,
        [System.ComponentModel.Description("539:Surface to Surface Firings (missing definition)")]
        SurfaceToSurfaceFirings = 539,
        [System.ComponentModel.Description("540:Submarine General (non-firing exercises, practices, trials) (missing definition)")]
        SubmarineGeneralNonFiringExercisesPracticesTrials = 540,
        [System.ComponentModel.Description("541:Surface Explosions (missing definition)")]
        SurfaceExplosions = 541,
        [System.ComponentModel.Description("542:Torpedo Firing Area (missing definition)")]
        TorpedoFiringArea = 542,
        [System.ComponentModel.Description("543:Towed Array (missing definition)")]
        TowedArray = 543,
        [System.ComponentModel.Description("544:Aerial Towed Target or Target Towing Aircraft (missing definition)")]
        AerialTowedTargetOrTargetTowingAircraft = 544,
        [System.ComponentModel.Description("545:Weapon Training (missing definition)")]
        WeaponTraining = 545,
        [System.ComponentModel.Description("546:Amphibious (missing definition)")]
        Amphibious = 546,
        [System.ComponentModel.Description("A signal or message warning of diving activity.")]
        Diving = 547,
        [System.ComponentModel.Description("598:Balloons (missing definition)")]
        Balloons = 598,
        [System.ComponentModel.Description("599:Electrical/Optical Hazard (missing definition)")]
        ElectricalOpticalHazard = 599,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCoastline : int {
        [System.ComponentModel.Description("A coast backed by rock or earth cliffs, gives a good radar return and is useful for visual identification from a considerable distance off, where cliffs alternate with low lying coast along the shoreline.")]
        SteepCoast = 1,
        [System.ComponentModel.Description("A level coast with no obvious topographic features.")]
        FlatCoast = 2,
        [System.ComponentModel.Description("6:glacier, seaward end (missing definition)")]
        GlacierSeawardEnd = 6,
        [System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
        Mangrove = 7,
        [System.ComponentModel.Description("A shoreline area made up of spongy land saturated with water. It may have a shallow covering of water, usually with a considerable amount of vegetation appearing above the surface.")]
        MarshyShore = 8,
        [System.ComponentModel.Description("A vertical cliff forming the seaward edge of an ice shelf, ranging in height from 2 metres to 50 metres or more above sea level.")]
        IceCoast = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum speedUnits : int {
        [System.ComponentModel.Description("A unit of speed, expressing the number of kilometres travelled in one hour.")]
        KilometresPerHour = 2,
        [System.ComponentModel.Description("An imperial and United States customary unit of speed expressing the number of statute miles covered in one hour.")]
        MilesPerHour = 3,
        [System.ComponentModel.Description("A nautical unit of speed. One knot is one nautical mile per hour. The name is derived from the knots in the log line.")]
        Knots = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfInstallationBuoy : int {
        [System.ComponentModel.Description("Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
        CatenaryAnchorLegMooring = 1,
        [System.ComponentModel.Description("A large mooring buoy used by tankers to load and unload in port approaches or in offshore oil and gas fields.")]
        SingleBuoyMooring = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofRestrictions : int {
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
        NatureReserve = 4,
        [System.ComponentModel.Description("A place where birds are bred and protected.")]
        BirdSanctuary = 5,
        [System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
        GameReserve = 6,
        [System.ComponentModel.Description("A place where seals are protected.")]
        SealSanctuary = 7,
        [System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
        HistoricWreckArea = 10,
        [System.ComponentModel.Description("An area where marine research takes place.")]
        ResearchArea = 20,
        [System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
        FishSanctuary = 22,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        EcologicalReserve = 23,
        [System.ComponentModel.Description("27:Environmentally Sensitive Sea Area (ESSA) (missing definition)")]
        EnvironmentallySensitiveSeaAreaEssa = 27,
        [System.ComponentModel.Description("28:Particularly Sensitive Sea Area (PSSA) (missing definition)")]
        ParticularlySensitiveSeaAreaPssa = 28,
        [System.ComponentModel.Description("A place where coral is protected.")]
        CoralSanctuary = 31,
        [System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
        RecreationArea = 32,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum qualityOfHorizontalMeasurement : int {
        [System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.")]
        Approximate = 4,
        [System.ComponentModel.Description("Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.")]
        PositionDoubtful = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum jurisdiction : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Involving more than one country; covering more than one national area.")]
        International = 1,
        [System.ComponentModel.Description("An area administered or controlled by a single nation.")]
        National = 2,
        [System.ComponentModel.Description("3:National Sub-Division (missing definition)")]
        NationalSubDivision = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfSurface : int {
        [System.ComponentModel.Description("Soft, wet earth.")]
        Mud = 1,
        [System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
        Clay = 2,
        [System.ComponentModel.Description("An unconsolidated sediment whose particles range in size from 0.0039 to 0.0625 millimetres in diameter (between clay and sand size).")]
        Silt = 3,
        [System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
        Sand = 4,
        [System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
        Stone = 5,
        [System.ComponentModel.Description("(Particles of 2.0 - 4.0mm); small stones with coarse sand.")]
        Gravel = 6,
        [System.ComponentModel.Description("A small stone worn smooth and rounded by the action of water, sand, ice, etc. ranging in diameter between 4 and 64 millimetres.")]
        Pebbles = 7,
        [System.ComponentModel.Description("A naturally rounded stone larger than a pebble.")]
        Cobbles = 8,
        [System.ComponentModel.Description("Any formation of natural origin that constitutes an integral part of the lithosphere. The natural occurring material that forms firm, hard, and solid masses.")]
        Rock = 9,
        [System.ComponentModel.Description("The fluid or semi-fluid matter flowing from a volcano. The substance that results from the cooling of the molten rock. Part of the ocean bed is composed of lava.")]
        Lava = 11,
        [System.ComponentModel.Description("Hard calcareous skeletons of many tribes of marine polyps.")]
        Coral = 14,
        [System.ComponentModel.Description("The hard outside covering of an animal. Part of the ocean bed is composed of numerous shells of marine animals.")]
        Shells = 17,
        [System.ComponentModel.Description("A rounded rock with diameter of 256 millimetres or larger.")]
        Boulder = 18,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum marksNavigationalSystemOf : int {
        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.")]
        IalaA = 1,
        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.")]
        IalaB = 2,
        [System.ComponentModel.Description("Navigational aids do not conform to any defined system.")]
        NoSystem = 9,
        [System.ComponentModel.Description("Navigational aids as required in international, national or regional regulations that contain the same navigational aids as the European Code for Inland Waterways of UNECE, or if there is no regulation for a waterway, navigational aids as recommended in the European Code for Inland Waterways of UNECE")]
        MainEuropeanInlandWaterwayMarkingSystem = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum magneticAnomalyDetectorSignature : int {
        [System.ComponentModel.Description("501:nil (missing definition)")]
        Nil = 501,
        [System.ComponentModel.Description("502:slight (missing definition)")]
        Slight = 502,
        [System.ComponentModel.Description("503:moderate (missing definition)")]
        Moderate = 503,
        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        Strong = 504,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum comparisonOperator : int {
        [System.ComponentModel.Description("The value of the left value is greater than that of the right.")]
        GreaterThan = 1,
        [System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right.")]
        GreaterThanOrEqualTo = 2,
        [System.ComponentModel.Description("The value of the left expression is less than that of the right.")]
        LessThan = 3,
        [System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right.")]
        LessThanOrEqualTo = 4,
        [System.ComponentModel.Description("The two values are equivalent.")]
        EqualTo = 5,
        [System.ComponentModel.Description("The two values are not equivalent.")]
        NotEqualTo = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCable : int {
        [System.ComponentModel.Description("A cable that transmits or distributes electrical power.")]
        PowerLine = 1,
        [System.ComponentModel.Description("Multiple un-insulated cables usually supported by steel lattice towers. Such features are generally more prominent than normal power lines.")]
        TransmissionLine = 3,
        [System.ComponentModel.Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
        MooringCable = 6,
        [System.ComponentModel.Description("A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.")]
        Ferry = 7,
        [System.ComponentModel.Description("A cable used for joining components of complex marine structures, for example mooring trots.")]
        JunctionCable = 9,
        [System.ComponentModel.Description("A cable used for the transmission and reception of modulated communication waves/signals.")]
        TelecommunicationsCable = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfWreck : int {
        [System.ComponentModel.Description("1:non-dangerous wreck (missing definition)")]
        NonDangerousWreck = 1,
        [System.ComponentModel.Description("A wreck submerged at such a depth as to be considered dangerous to surface navigation.")]
        DangerousWreck = 2,
        [System.ComponentModel.Description("A substantively decayed wreck over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.")]
        DistributedRemainsOfWreck = 3,
        [System.ComponentModel.Description("4:wreck showing mast/masts (missing definition)")]
        WreckShowingMastMasts = 4,
        [System.ComponentModel.Description("Wreck of which any portion of the hull or superstructure is visible at the sounding datum indicated.")]
        WreckShowingAnyPortionOfHullOrSuperstructure = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLateralMark : int {
        [System.ComponentModel.Description("1:port-hand lateral mark (missing definition)")]
        PortHandLateralMark = 1,
        [System.ComponentModel.Description("2:starboard-hand lateral mark (missing definition)")]
        StarboardHandLateralMark = 2,
        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
        PreferredChannelToStarboardLateralMark = 3,
        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
        PreferredChannelToPortLateralMark = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum areaCategory : int {
        [System.ComponentModel.Description("501:Solid Red (SR) (missing definition)")]
        SolidRedSr = 501,
        [System.ComponentModel.Description("502:Pecked Red (PR) (missing definition)")]
        PeckedRedPr = 502,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum status : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Intended to last or function indefinitely.")]
        Permanent = 1,
        [System.ComponentModel.Description("Acting on special occasions; happening irregularly.")]
        Occasional = 2,
        [System.ComponentModel.Description("Presented as worthy of confidence, acceptance, use, etc.")]
        Recommended = 3,
        [System.ComponentModel.Description("Use has ceased, but the facility still exists intact; disused.")]
        NotInUse = 4,
        [System.ComponentModel.Description("5:periodic/intermittent (missing definition)")]
        PeriodicIntermittent = 5,
        [System.ComponentModel.Description("Set apart for some specific use.")]
        Reserved = 6,
        [System.ComponentModel.Description("Meant to last only for a time.")]
        Temporary = 7,
        [System.ComponentModel.Description("Administered by an individual or corporation, rather than a State or a public body.")]
        Private = 8,
        [System.ComponentModel.Description("Compulsory; enforced.")]
        Mandatory = 9,
        [System.ComponentModel.Description("No longer lit.")]
        Extinguished = 11,
        [System.ComponentModel.Description("Lit by flood lights, strip lights, etc.")]
        Illuminated = 12,
        [System.ComponentModel.Description("Famous in history; of historical interest.")]
        Historic = 13,
        [System.ComponentModel.Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
        Public = 14,
        [System.ComponentModel.Description("Occur at a time, coincide in point of time, be contemporary or simultaneous.")]
        Synchronized = 15,
        [System.ComponentModel.Description("Looked at or observed over a period of time especially so as to be aware of any movement or change.")]
        Watched = 16,
        [System.ComponentModel.Description("Usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
        Unwatched = 17,
        [System.ComponentModel.Description("A feature that has been reported but has not been definitely determined to exist.")]
        ExistenceDoubtful = 18,
        [System.ComponentModel.Description("Marked by buoys.")]
        Buoyed = 28,
        [System.ComponentModel.Description("501:active/in use (missing definition)")]
        ActiveInUse = 501,
        [System.ComponentModel.Description("A coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.")]
        Claimed = 502,
        [System.ComponentModel.Description("503:practice and/or exercise purposes (missing definition)")]
        PracticeAndOrExercisePurposes = 503,
        [System.ComponentModel.Description("acknowledged and agreed in accordance with the provisions of International Law ")]
        Recognised = 504,
        [System.ComponentModel.Description("not detected by repeated surveys, leading to doubts about the object's existence. (AML)")]
        Dead = 505,
        [System.ComponentModel.Description("an object that has been salvaged or removed. (AML)")]
        Lifted = 506,
        [System.ComponentModel.Description("where a significant number of persons have perished as a direct result of a vessel or structure sinking and their remains cannot be recovered, the wreck and immediate area may be declared as a Mass Grave or more specifically, a War Grave. Such sites are protected from disturbance by International Law. (AML)")]
        MassGrave = 507,
        [System.ComponentModel.Description("a borehole drilled in the search for a new source of oil or gas. (An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        Exploration = 508,
        [System.ComponentModel.Description("a borehole that is actively engaged in the extraction of oil or gas from the seabed. (Adapted from An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        Production = 509,
        [System.ComponentModel.Description("a well where the extraction of oil or gas has been temporarily abandoned. When suspended, a well is either plugged (filled with concrete and topped with a steel plate) or capped (well-head equipment is installed over the well). (Adapted from An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        Suspended = 510,
        [System.ComponentModel.Description("a borehole drilled for the purpose of injecting a secondary substance, for example water,  into the pore spaces in a reservoir rock to encourage oil or gas to flow into adjacent producing wells. (An A-Z of Offshore Oil & Gas by Harry Whitehead, 2nd Ed, 1983, Gulf Publishing Company)")]
        Injection = 511,
        [System.ComponentModel.Description("the status of the object is unspecified.")]
        Unspecified = 512,
        [System.ComponentModel.Description("temporarily quiet, inactive, not being used. (AML).")]
        Dormant = 516,
        [System.ComponentModel.Description("planned; intended; in accordance with, or achieved by, a careful plan made beforehand (The Concise Oxford Dictionary)")]
        Proposed = 517,
        [System.ComponentModel.Description("completely deserted; given up (adapted from the Concise Oxford Dictionary)")]
        Abandoned = 518,
        [System.ComponentModel.Description("Area of overlap of the unilateral fishing zones of two or more countries")]
        GreyZone = 519,
        [System.ComponentModel.Description("An area of the sea of indeterminate jurisdiction where no agreed boundary exist.")]
        Indeterminate = 520,
        [System.ComponentModel.Description("Involving two or more states as parties to an agreement.")]
        Multilateral = 521,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCardinalMark : int {
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NW-NE taken from the point of interest; it should be passed to the north side of the mark.")]
        NorthCardinalMark = 1,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NE-SE taken from the point of interest. It should be passed to the east side of the mark.")]
        EastCardinalMark = 2,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SE-SW taken from the point of interest; it should be passed to the south side of the mark.")]
        SouthCardinalMark = 3,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SW-NW taken from the point of interest; it should be passed to the west side of the mark.")]
        WestCardinalMark = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAirportAirfield : int {
        [System.ComponentModel.Description("A large military airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
        MilitaryAeroplaneAirport = 1,
        [System.ComponentModel.Description("A large airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
        CivilAeroplaneAirport = 2,
        [System.ComponentModel.Description("A landing place for helicopters controlled by the military.")]
        MilitaryHeliport = 3,
        [System.ComponentModel.Description("A landing place for helicopters, often the roof of a building.")]
        CivilHeliport = 4,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of gliders.")]
        GliderAirfield = 5,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of small aeroplanes.")]
        SmallPlanesAirfield = 6,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of aeroplanes or helicopters in times of emergency.")]
        EmergencyAirfield = 8,
        [System.ComponentModel.Description("9:search and rescue (missing definition)")]
        SearchAndRescue = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum techniqueOfVerticalMeasurement : int {
        [System.ComponentModel.Description("The depth was measured by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.")]
        FoundByEchoSounder = 1,
        [System.ComponentModel.Description("The depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the seabed and generate a record of the seabed configuration.")]
        FoundBySideScanSonar = 2,
        [System.ComponentModel.Description("The depth was measured by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.")]
        FoundByMultiBeam = 3,
        [System.ComponentModel.Description("The depth was determined by a person skilled in the practice of diving.")]
        FoundByDiver = 4,
        [System.ComponentModel.Description("The depth was measured by using a line, graduated with attached marks and fastened to a sounding lead.")]
        FoundByLeadLine = 5,
        [System.ComponentModel.Description("The given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.")]
        SweptByVerticalAcousticSystem = 8,
        [System.ComponentModel.Description("The depth was determined by using an instrument that compares electromagnetic signals.")]
        FoundByElectromagneticSensor = 9,
        [System.ComponentModel.Description("The science or art of obtaining reliable measurements from photographs.")]
        Photogrammetry = 10,
        [System.ComponentModel.Description("The depth was determined by using instruments placed aboard an artificial satellite.")]
        SatelliteImagery = 11,
        [System.ComponentModel.Description("12:found by leveling (missing definition)")]
        FoundByLeveling = 12,
        [System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a side scan sonar.")]
        SweptBySideScanSonar = 13,
        [System.ComponentModel.Description("The depth was measured by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
        FoundByLidar = 15,
        [System.ComponentModel.Description("A radar with a synthetic aperture antenna which is composed of a large number of elementary transducing elements. The signals are electronically combined into a resulting signal equivalent to that of a single antenna of a given aperture in a given direction.")]
        SyntheticApertureRadar = 16,
        [System.ComponentModel.Description("Term used to describe the imagery derived from subdividing the electromagnetic spectrum into very narrow bandwidths. These narrow bandwidths may be combined with or subtracted from each other in various ways to form images useful in precise terrain or target analysis.")]
        HyperspectralImagery = 17,
        [System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a line or object below the surface at the desired depth; or least depth(s) and position(s) within an area was identified using the same technique.")]
        MechanicallySwept = 18,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum verticalDatum : int {
        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        MeanSeaLevel = 3,
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        LowWater = 13,
        [System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
        MeanHighWater = 16,
        [System.ComponentModel.Description("The average height of the high waters of spring tides.")]
        MeanHighWaterSprings = 17,
        [System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
        HighWater = 18,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
        ApproximateMeanSeaLevel = 19,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
        HighWaterSprings = 20,
        [System.ComponentModel.Description("The average height of higher high waters at a place over a 19-year period.")]
        MeanHigherHighWater = 21,
        [System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        LocalDatum = 24,
        [System.ComponentModel.Description("25:international great (missing definition)")]
        InternationalGreat = 25,
        [System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
        MeanWaterLevel = 26,
        [System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
        HigherHighWaterLargeTide = 28,
        [System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
        NearlyHighestHighWater = 29,
        [System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        HighestAstronomicalTide = 30,
        [System.ComponentModel.Description("44:Baltic Sea Chart Datum (missing definition)")]
        BalticSeaChartDatum = 44,
        [System.ComponentModel.Description("501:Mean Tide Level (missing definition)")]
        MeanTideLevel = 501,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum exhibitionConditionOfLight : int {
        [System.ComponentModel.Description("A light shown throughout the 24 hours without change of character.")]
        LightShownWithoutChangeOfCharacter = 1,
        [System.ComponentModel.Description("A light which is only exhibited by day.")]
        DaytimeLight = 2,
        [System.ComponentModel.Description("A light which is exhibited in fog or conditions of reduced visibility.")]
        FogLight = 3,
        [System.ComponentModel.Description("A light which is only exhibited at night.")]
        NightLight = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLight : int {
        [System.ComponentModel.Description("A light associated with other lights so as to form a leading line to be followed.")]
        LeadingLight = 4,
        [System.ComponentModel.Description("An aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.")]
        AeroLight = 5,
        [System.ComponentModel.Description("A broad beam light used to illuminate a structure or area.")]
        FloodLight = 8,
        [System.ComponentModel.Description("A light whose source has a linear form generally horizontal, which can reach a length of several metres.")]
        StripLight = 9,
        [System.ComponentModel.Description("A light placed on or near the support of a main light and having a special use in navigation.")]
        SubsidiaryLight = 10,
        [System.ComponentModel.Description("A powerful light focused so as to illuminate a small area.")]
        Spotlight = 11,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        Front = 12,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        Rear = 13,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        Lower = 14,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        Upper = 15,
        [System.ComponentModel.Description("A light available as a backup to a main light which will be illuminated should the main light fail.")]
        Emergency = 17,
        [System.ComponentModel.Description("A light which enables its approximate bearing to be obtained without the use of a compass.")]
        BearingLight = 18,
        [System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed horizontally.")]
        HorizontallyDisposed = 19,
        [System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed vertically.")]
        VerticallyDisposed = 20,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum trafficFlow : int {
        [System.ComponentModel.Description("Traffic flow in a general direction toward a port or similar destination.")]
        Inbound = 1,
        [System.ComponentModel.Description("Traffic flow in a general direction away from a port or similar point of origin.")]
        Outbound = 2,
        [System.ComponentModel.Description("3:one-way (missing definition)")]
        OneWay = 3,
        [System.ComponentModel.Description("4:two-way (missing definition)")]
        TwoWay = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum colour : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("The achromatic object colour of greatest lightness characteristically perceived to belong to objects that reflect diffusely nearly all incident energy throughout the visible spectrum.")]
        White = 1,
        [System.ComponentModel.Description("The achromatic color of least lightness characteristically perceived to belong to objects that neither reflect nor transmit light.")]
        Black = 2,
        [System.ComponentModel.Description("A color whose hue resembles that of blood or of the ruby or is that of the long-wave extreme of the visible spectrum.")]
        Red = 3,
        [System.ComponentModel.Description("Of the color green.")]
        Green = 4,
        [System.ComponentModel.Description("A color whose hue is that of the clear sky or that of the portion of the color spectrum lying between green and violet.")]
        Blue = 5,
        [System.ComponentModel.Description("A color whose hue resembles that of ripe lemons or sunflowers or is that of the portion of the spectrum lying between green and orange.")]
        Yellow = 6,
        [System.ComponentModel.Description("Of the color grey.")]
        Grey = 7,
        [System.ComponentModel.Description("Any of a group of colors between red and yellow in hue, of medium to low lightness, and of moderate to low saturation.")]
        Brown = 8,
        [System.ComponentModel.Description("A variable color averaging a dark orange yellow.")]
        Amber = 9,
        [System.ComponentModel.Description("Any of a group of colors of reddish-blue hue, low lightness, and medium saturation.")]
        Violet = 10,
        [System.ComponentModel.Description("Any of a group of colors that are between red and yellow in hue.")]
        Orange = 11,
        [System.ComponentModel.Description("A deep purplish red.")]
        Magenta = 12,
        [System.ComponentModel.Description("Any of a group of colors bluish red to red in hue, of medium to high lightness, and of low to moderate saturation.")]
        Pink = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofBoundaryLine : int {
        [System.ComponentModel.Description("A line of demarcation between controlled areas.")]
        AdministrativeBoundary = 501,
        [System.ComponentModel.Description("506:de facto boundary (missing definition)")]
        DeFactoBoundary = 506,
        [System.ComponentModel.Description("511:International Maritime Boundary (missing definition)")]
        InternationalMaritimeBoundary = 511,
        [System.ComponentModel.Description("A line every point of which is equidistant from the nearest points on the baselines of two or more states between which it lies.")]
        MedianLine = 599,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum soundingDatum : int {
        [System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.")]
        MeanLowWaterSprings = 501,
        [System.ComponentModel.Description("The average height of lower low water springs at a place.")]
        MeanLowerLowWaterSprings = 502,
        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        MeanSeaLevel = 503,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.")]
        LowestLowWater = 504,
        [System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
        MeanLowWater = 505,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
        LowestLowWaterSprings = 506,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
        ApproximateMeanLowWaterSprings = 507,
        [System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
        IndianSpringLowWater = 508,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
        LowWaterSprings = 509,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
        ApproximateLowestAstronomicalTide = 510,
        [System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
        NearlyLowestLowWater = 511,
        [System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
        MeanLowerLowWater = 512,
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        LowWater = 513,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
        ApproximateMeanLowWater = 514,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
        ApproximateMeanLowerLowWater = 515,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
        ApproximateMeanSeaLevel = 519,
        [System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
        EquinoctialSpringLowWater = 522,
        [System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        LowestAstronomicalTide = 523,
        [System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        LocalDatum = 524,
        [System.ComponentModel.Description("525:International Great Lakes Datum 1985 (IGLD 1985) (missing definition)")]
        InternationalGreatLakesDatum1985Igld1985 = 525,
        [System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
        MeanWaterLevel = 526,
        [System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
        LowerLowWaterLargeTide = 527,
        [System.ComponentModel.Description("531:Mean Tide Level (missing definition)")]
        MeanTideLevel = 531,
        [System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
        BalticSeaChartDatum2000 = 532,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSpecialPurposeMark : int {
        [System.ComponentModel.Description("1:firing danger area mark (missing definition)")]
        FiringDangerAreaMark = 1,
        [System.ComponentModel.Description("Any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.")]
        TargetMark = 2,
        [System.ComponentModel.Description("A mark marking the position of a ship which is used as a target during some military exercise.")]
        MarkerShipMark = 3,
        [System.ComponentModel.Description("A mark used to indicate a degaussing range.")]
        DegaussingRangeMark = 4,
        [System.ComponentModel.Description("A mark of relevance to barges.")]
        BargeMark = 5,
        [System.ComponentModel.Description("A mark used to indicate the position of submarine cables or the point at which they run on to the land.")]
        CableMark = 6,
        [System.ComponentModel.Description("A mark used to indicate the limit of a spoil ground.")]
        SpoilGroundMark = 7,
        [System.ComponentModel.Description("A mark used to indicate the position of an outfall or the point at which it leaves the land.")]
        OutfallMark = 8,
        [System.ComponentModel.Description("Ocean Data Acquisition System.")]
        Odas = 9,
        [System.ComponentModel.Description("A mark used to record data for scientific purposes.")]
        RecordingMark = 10,
        [System.ComponentModel.Description("An area in which seaplanes anchor or may anchor.")]
        SeaplaneAnchorage = 11,
        [System.ComponentModel.Description("A mark used to indicate a recreation zone.")]
        RecreationZoneMark = 12,
        [System.ComponentModel.Description("A mark indicating a mooring or moorings.")]
        MooringMark = 14,
        [System.ComponentModel.Description("A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
        Lanby = 15,
        [System.ComponentModel.Description("Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
        LeadingMark = 16,
        [System.ComponentModel.Description("A course at sea, whose ends are indicated by ranges ashore, and whose length has been accurately measured for determining the speed of vessels.")]
        MeasuredDistance = 17,
        [System.ComponentModel.Description("A notice board or sign indicating information to the mariner.")]
        NoticeMark = 18,
        [System.ComponentModel.Description("19:TSS mark (Traffic Separation Scheme) (missing definition)")]
        TssMarkTrafficSeparationScheme = 19,
        [System.ComponentModel.Description("An area within which anchoring is not permitted.")]
        AnchoringProhibited = 20,
        [System.ComponentModel.Description("A mark indicating that berthing is prohibited.")]
        BerthingProhibitedMark = 21,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking is generally prohibited.")]
        OvertakingProhibited = 22,
        [System.ComponentModel.Description("23:two-way traffic prohibited mark (missing definition)")]
        TwoWayTrafficProhibitedMark = 23,
        [System.ComponentModel.Description("A mark indicating that vessels must not generate excessive wake.")]
        ReducedWakeMark = 24,
        [System.ComponentModel.Description("A mark indicating that a speed limit applies.")]
        SpeedLimitMark = 25,
        [System.ComponentModel.Description("A mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
        StopMark = 26,
        [System.ComponentModel.Description("A mark indicating that special caution must be exercised in the vicinity of the mark.")]
        GeneralWarningMark = 27,
        [System.ComponentModel.Description("28:sound ship’s siren mark (missing definition)")]
        SoundShipSSirenMark = 28,
        [System.ComponentModel.Description("29:restricted vertical (missing definition)")]
        RestrictedVertical = 29,
        [System.ComponentModel.Description("30:maximum vessel’s draught mark (missing definition)")]
        MaximumVesselSDraughtMark = 30,
        [System.ComponentModel.Description("A mark indicating the minimum horizontal space available for passage.")]
        RestrictedHorizontalClearanceMark = 31,
        [System.ComponentModel.Description("A mark warning of strong currents.")]
        StrongCurrentWarningMark = 32,
        [System.ComponentModel.Description("A mark indicating that berthing is allowed.")]
        BerthingPermittedMark = 33,
        [System.ComponentModel.Description("A mark indicating an overhead power cable.")]
        OverheadPowerCableMark = 34,
        [System.ComponentModel.Description("A mark indicating the gradient of the slope of a dredge channel edge.")]
        ChannelEdgeGradientMark = 35,
        [System.ComponentModel.Description("A mark indicating the presence of a telephone.")]
        TelephoneMark = 36,
        [System.ComponentModel.Description("A mark indicating that a ferry route crosses the ship route; often used with a 'sound ship's siren' mark.")]
        FerryCrossingMark = 37,
        [System.ComponentModel.Description("A mark used to indicate the position of submarine pipelines or the point at which they run on to the land.")]
        PipelineMark = 39,
        [System.ComponentModel.Description("A mark indicating an anchorage area.")]
        AnchorageMark = 40,
        [System.ComponentModel.Description("A mark used to indicate a clearing line.")]
        ClearingMark = 41,
        [System.ComponentModel.Description("A mark indicating the location at which a restriction or requirement exists.")]
        ControlMark = 42,
        [System.ComponentModel.Description("A mark indicating that diving may take place in the vicinity.")]
        DivingMark = 43,
        [System.ComponentModel.Description("A mark providing or indicating a place of safety.")]
        RefugeBeacon = 44,
        [System.ComponentModel.Description("A mark indicating a foul ground.")]
        FoulGroundMark = 45,
        [System.ComponentModel.Description("A mark installed for use by yachtsmen.")]
        YachtingMark = 46,
        [System.ComponentModel.Description("A mark indicating an area where helicopters may land.")]
        HeliportMark = 47,
        [System.ComponentModel.Description("A mark indicating a location at which a GNSS position has been accurately determined.")]
        GnssMark = 48,
        [System.ComponentModel.Description("A mark indicating an area where seaplanes land.")]
        SeaplaneLandingMark = 49,
        [System.ComponentModel.Description("A mark indicating that entry is prohibited.")]
        EntryProhibitedMark = 50,
        [System.ComponentModel.Description("A mark indicating that work (generally construction) is in progress.")]
        WorkInProgressMark = 51,
        [System.ComponentModel.Description("52:mark with unknown (missing definition)")]
        MarkWithUnknown = 52,
        [System.ComponentModel.Description("A mark indicating a borehole that produces or is capable of producing oil or natural gas.")]
        WellheadMark = 53,
        [System.ComponentModel.Description("A mark indicating the point at which a channel divides separately into two channels.")]
        ChannelSeparationMark = 54,
        [System.ComponentModel.Description("A mark indicating the existence of a fish, mussel, oyster or pearl farm/culture.")]
        MarineFarmMark = 55,
        [System.ComponentModel.Description("A mark indicating the existence or the extent of an artificial reef.")]
        ArtificialReefMark = 56,
        [System.ComponentModel.Description("A mark, used year round, that may be submerged when ice passes through the area.")]
        IceMark = 57,
        [System.ComponentModel.Description("A mark used to define the boundary of a nature reserve.")]
        NatureReserveMark = 58,
        [System.ComponentModel.Description("A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.")]
        FishAggregatingDevice = 59,
        [System.ComponentModel.Description("A mark used to indicate the existence of a wreck.")]
        WreckMark = 60,
        [System.ComponentModel.Description("A mark used to indicate the existence of a customs checkpoint.")]
        CustomsMark = 61,
        [System.ComponentModel.Description("A mark used to indicate the existence of a causeway.")]
        CausewayMark = 62,
        [System.ComponentModel.Description("A surface following buoy used to measure wave activity.")]
        WaveRecorder = 63,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum depthUnits : int {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        Metres = 1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPatrolArea : int {
        [System.ComponentModel.Description("501:4W disposition grid (missing definition)")]
        fourwDispositionGrid = 501,
        [System.ComponentModel.Description("502:Operational/Naval Patrol (missing definition)")]
        OperationalNavalPatrol = 502,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum gradient : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("501:Steep (missing definition)")]
        Steep = 501,
        [System.ComponentModel.Description("502:Moderate (missing definition)")]
        Moderate = 502,
        [System.ComponentModel.Description("503:Gentle (missing definition)")]
        Gentle = 503,
        [System.ComponentModel.Description("504:Mild (missing definition)")]
        Mild = 504,
        [System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
        Flat = 505,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum cardinalPointOrientation : int {
        [System.ComponentModel.Description("501:north/south (missing definition)")]
        NorthSouth = 501,
        [System.ComponentModel.Description("502:east/west (missing definition)")]
        EastWest = 502,
        [System.ComponentModel.Description("503:northeast/southwest (missing definition)")]
        NortheastSouthwest = 503,
        [System.ComponentModel.Description("504:northwest/southeast (missing definition)")]
        NorthwestSoutheast = 504,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRestrictedArea : int {
        [System.ComponentModel.Description("The area around an offshore installation within which vessels are prohibited from entering without permission. Special regulations protect installations within a safety zone and vessels of all nationalities are required to respect the zone.")]
        OffshoreSafetyZone = 1,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
        NatureReserve = 4,
        [System.ComponentModel.Description("A place where birds are bred and protected.")]
        BirdSanctuary = 5,
        [System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
        GameReserve = 6,
        [System.ComponentModel.Description("A place where seals are protected.")]
        SealSanctuary = 7,
        [System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the seabed in the range and there are cables leading from the range to a control position ashore.")]
        DegaussingRange = 8,
        [System.ComponentModel.Description("An area controlled by the military in which restrictions may apply.")]
        MilitaryArea = 9,
        [System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
        HistoricWreckArea = 10,
        [System.ComponentModel.Description("An area around a navigational aid which vessels are prohibited from entering.")]
        NavigationalAidSafetyZone = 12,
        [System.ComponentModel.Description("An area laid and maintained with explosive mines for defence or practice purposes.")]
        Minefield = 14,
        [System.ComponentModel.Description("An area in which people may swim and therefore vessel movement may be restricted.")]
        SwimmingArea = 18,
        [System.ComponentModel.Description("An area reserved for vessels waiting to enter a harbour.")]
        WaitingArea = 19,
        [System.ComponentModel.Description("An area where marine research takes place.")]
        ResearchArea = 20,
        [System.ComponentModel.Description("An area where dredging is taking place.")]
        DredgingArea = 21,
        [System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
        FishSanctuary = 22,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        EcologicalReserve = 23,
        [System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
        NoWakeArea = 24,
        [System.ComponentModel.Description("An area where vessels turn.")]
        SwingingArea = 25,
        [System.ComponentModel.Description("A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.")]
        EnvironmentallySensitiveSeaArea = 27,
        [System.ComponentModel.Description("An area that needs special protection through action by IMO because of its significance for regional ecological, socio-economic or scientific reasons and because it may be vulnerable to damage by international shipping activities.")]
        ParticularlySensitiveSeaArea = 28,
        [System.ComponentModel.Description("An area near a fairway where vessels can go to clear the way or make an about turn and possibly return to a waiting area when nautical conditions impose it.")]
        DisengagementArea = 29,
        [System.ComponentModel.Description("An area in which defence, law and treaty enforcement, and counter-terrorism activities that fall within the port and maritime domain apply.")]
        PortSecurityArea = 30,
        [System.ComponentModel.Description("A place where coral is protected.")]
        CoralSanctuary = 31,
        [System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
        RecreationArea = 32,
        [System.ComponentModel.Description("An area within which notification is required between respective military authorities of future military exercises/activities.")]
        MaritimeNotificationArea = 501,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum expositionOfSounding : int {
        [System.ComponentModel.Description("The depth corresponds to the depth range of the surrounding depth area; that is, the depth is not shoaler than the minimum depth of the surrounding depth area or deeper than the maximum depth of the surrounding depth area.")]
        WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,
        [System.ComponentModel.Description("The depth is shoaler than the minimum depth of the surrounding depth area.")]
        ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,
        [System.ComponentModel.Description("The depth is deeper than the maximum depth of the surrounding depth area.")]
        DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum controlledAirspaceClassDesignation : int {
        [System.ComponentModel.Description("501:A (missing definition)")]
        A = 501,
        [System.ComponentModel.Description("502:B (missing definition)")]
        B = 502,
        [System.ComponentModel.Description("503:C (missing definition)")]
        C = 503,
        [System.ComponentModel.Description("504:D (missing definition)")]
        D = 504,
        [System.ComponentModel.Description("505:E (missing definition)")]
        E = 505,
        [System.ComponentModel.Description("506:F (missing definition)")]
        F = 506,
        [System.ComponentModel.Description("507:G (missing definition)")]
        G = 507,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum statusOfSmallBottomObject : int {
        [System.ComponentModel.Description("504:Identified (NOMBO) (missing definition)")]
        IdentifiedNombo = 504,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum buoyShape : int {
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.")]
        Conical = 1,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.")]
        Can = 2,
        [System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
        Spherical = 3,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.")]
        Pillar = 4,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.")]
        Spar = 5,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.")]
        Barrel = 6,
        [System.ComponentModel.Description("A very large buoy designed to carry a signal light of high luminous intensity at a high elevation.")]
        Superbuoy = 7,
        [System.ComponentModel.Description("A specially constructed shuttle shaped buoy which is used in ice conditions.")]
        IceBuoy = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum heightLengthUnits : int {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        Metres = 1,
        [System.ComponentModel.Description("A unit of length equal to 12 inches, 1/6 of a fathom, or 30.480 centimetres.")]
        Feet = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRadioStation : int {
        [System.ComponentModel.Description("1:circular (non-directional) marine or aero-marine radiobeacon (missing definition)")]
        CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,
        [System.ComponentModel.Description("A special type of radiobeacon station the emissions of which are intended to provide a definite track for guidance.")]
        DirectionalRadiobeacon = 2,
        [System.ComponentModel.Description("A special type of radiobeacon station emitting a beam of waves to which a uniform turning movement is given, the bearing of the station being determined by means of an ordinary listening receiver and a stop watch. Also referred to as a rotating loop radiobeacon.")]
        RotatingPatternRadiobeacon = 3,
        [System.ComponentModel.Description("A type of long range position fixing beacon.")]
        ConsolBeacon = 4,
        [System.ComponentModel.Description("5:radio direction-finding station (missing definition)")]
        RadioDirectionFindingStation = 5,
        [System.ComponentModel.Description("A radio station which is prepared to provide QTG service; that is to say, to transmit upon request from a ship a radio signal, the bearing of which can be taken by that ship.")]
        CoastRadioStationProvidingQtgService = 6,
        [System.ComponentModel.Description("A radio beacon designed for aeronautical use.")]
        AeronauticalRadiobeacon = 7,
        [System.ComponentModel.Description("The Decca Navigator System is a high accuracy, short to medium range radio navigational aid intended for coastal and landfall navigation.")]
        Decca = 8,
        [System.ComponentModel.Description("9:Loran-C (missing definition)")]
        LoranC = 9,
        [System.ComponentModel.Description("Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.")]
        DifferentialGnss = 10,
        [System.ComponentModel.Description("An electronic position fixing system used mainly by aircraft.")]
        Toran = 11,
        [System.ComponentModel.Description("A long-range radio navigational aid which operates within the VLF frequency band. The system comprises eight land based stations.")]
        Omega = 12,
        [System.ComponentModel.Description("A ranging position fixing system operating at 420-450 MHz over a range of up to 400 Km.")]
        Syledis = 13,
        [System.ComponentModel.Description("A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
        Chaika = 14,
        [System.ComponentModel.Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
        RadioTelephoneStation = 19,
        [System.ComponentModel.Description("An onshore AIS unit that monitors traffic in the waterways.")]
        AisBaseStation = 20,
        [System.ComponentModel.Description("504:Distance Measuring Equipment (DME) (missing definition)")]
        DistanceMeasuringEquipmentDme = 504,
        [System.ComponentModel.Description("505:Non-directional Radio Beacon (NDB) (missing definition)")]
        NonDirectionalRadioBeaconNdb = 505,
        [System.ComponentModel.Description("506:Radar Responder Beacon (RACON) (missing definition)")]
        RadarResponderBeaconRacon = 506,
        [System.ComponentModel.Description("508:VHF Omni Directional Radio Range (VOR) (missing definition)")]
        VhfOmniDirectionalRadioRangeVor = 508,
        [System.ComponentModel.Description("509:VHF Omni Directional (VORTAC) (missing definition)")]
        VhfOmniDirectionalVortac = 509,
        [System.ComponentModel.Description("510:Tactical Air Navigation Equipment (TACAN) (missing definition)")]
        TacticalAirNavigationEquipmentTacan = 510,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRescueStation : int {
        [System.ComponentModel.Description("A place where equipment for saving life at sea is maintained; the type of lifeboat may vary from fast, long distance boats to inflatable inshore boats.")]
        RescueStationWithLifeboat = 1,
        [System.ComponentModel.Description("A life saving station equipped with line-carrying rocket apparatus.")]
        RescueStationWithRocket = 2,
        [System.ComponentModel.Description("Shelter or protection from danger or distress at sea.")]
        RefugeForShipwreckedMariners = 4,
        [System.ComponentModel.Description("Shelter or protection from danger in areas exposed to extreme and sudden tides or tidal streams.")]
        RefugeForIntertidalAreaWalkers = 5,
        [System.ComponentModel.Description("A place where a lifeboat is moored ready for use.")]
        LifeboatLyingAtAMooring = 6,
        [System.ComponentModel.Description("A radio station reserved for emergency situations; might also be a public telephone.")]
        AidRadioStation = 7,
        [System.ComponentModel.Description("A place where first aid equipment is available.")]
        FirstAidEquipment = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum product : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("A thick, slippery liquid that will not dissolve in water, usually petroleum based in the context of storage tanks.")]
        Oil = 1,
        [System.ComponentModel.Description("A substance with particles that can move freely, usually a fuel substance in the context of storage tanks.")]
        Gas = 2,
        [System.ComponentModel.Description("A colourless, odourless, tasteless liquid that is a compound of hydrogen and oxygen.")]
        Water = 3,
        [System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
        Stone = 4,
        [System.ComponentModel.Description("A hard black mineral that is burned as fuel.")]
        Coal = 5,
        [System.ComponentModel.Description("A solid rock or mineral from which metal is obtained.")]
        Ore = 6,
        [System.ComponentModel.Description("Any substance obtained by or used in a chemical process.")]
        Chemicals = 7,
        [System.ComponentModel.Description("Water that is suitable for human consumption.")]
        DrinkingWater = 8,
        [System.ComponentModel.Description("A white fluid secreted by female mammals as food for their young.")]
        Milk = 9,
        [System.ComponentModel.Description("A mineral from which aluminum is obtained.")]
        Bauxite = 10,
        [System.ComponentModel.Description("A solid substance obtained after gas and tar have been extracted from coal, used as a fuel.")]
        Coke = 11,
        [System.ComponentModel.Description("An oblong lump of cast iron metal.")]
        IronIngots = 12,
        [System.ComponentModel.Description("Sodium chloride obtained from mines or by the evaporation of sea water.")]
        Salt = 13,
        [System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
        Sand = 14,
        [System.ComponentModel.Description("Wood prepared for use in building or carpentry.")]
        Timber = 15,
        [System.ComponentModel.Description("16:sawdust/wood chips (missing definition)")]
        SawdustWoodChips = 16,
        [System.ComponentModel.Description("Discarded metal suitable for being reprocessed.")]
        ScrapMetal = 17,
        [System.ComponentModel.Description("18:liquefied natural gas (LNG) (missing definition)")]
        LiquefiedNaturalGasLng = 18,
        [System.ComponentModel.Description("A compressed gas consisting of flammable light hydrocarbons and derived from petroleum.")]
        LiquefiedPetroleumGas = 19,
        [System.ComponentModel.Description("The fermented juice of grapes.")]
        Wine = 20,
        [System.ComponentModel.Description("A substance made of powdered lime and clay, mixed with water.")]
        Cement = 21,
        [System.ComponentModel.Description("A small hard seed, especially that of any cereal plant such as wheat, rice, corn, rye etc.")]
        Grain = 22,
        [System.ComponentModel.Description("Electric charge or current.")]
        Electricity = 23,
        [System.ComponentModel.Description("The solid form of water.")]
        Ice = 24,
        [System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
        Clay = 25,
        [System.ComponentModel.Description("Solid fuel: material wherein the particles firmly cohere; is hard and compact; and is burnt as a source of heat or power.")]
        SolidFuel = 502,
        [System.ComponentModel.Description("Flammable liquids and gases: a substance which is either; in a state where molecules move freely about one another but do not fly apart; or in a condition in which it has no definite boundaries or fixed volume; but which is combustible under normal atmospheric conditions.")]
        FlammableLiquidsAndGases = 503,
        [System.ComponentModel.Description("Ferrous elements and ores: unrefined and refined: a chemically inseparable substance or solid naturally occurring mineral aggregate, from which one or more valuable constituents may be recovered by treatment or a manufacturing process, and which does contain iron in its trivalent form.")]
        FerrousElementsAndOres = 505,
        [System.ComponentModel.Description("Non ferrous elements and ores: unrefined and refined: A chemically inseparable substance or solid naturally occurring mineral aggregate, from which one or more valuable constituents may be recovered by treatment or a manufacturing process, and which does not contain iron in its trivalent form.")]
        NonFerrousElementsAndOres = 506,
        [System.ComponentModel.Description("Constructed from metal.")]
        Metal = 507,
        [System.ComponentModel.Description("Substances produced by a process of in-organic nature; a substance neither animal or vegetable. Normally obtained by mining.")]
        Minerals = 508,
        [System.ComponentModel.Description("Natural and Chemical: a substance added to the soil to increase its productivity. It may be produced by or pertaining to nature; not the work of man; or which may be formed from a substance or resulting from a reaction involving changes to atoms or molecules.")]
        Fertiliser = 509,
        [System.ComponentModel.Description("Unprocessed and Products: the substance of trees. In unprocessed form, the wood has not undergone change by a method of manufacture into products, being the manufacture of goods or commodities from wood.")]
        Wood = 510,
        [System.ComponentModel.Description("Unprocessed and Products: Strong waterproof elastic material, originally made from the dried sap of a tropical tree, now usually synthetic. In unprocessed form, the rubber has not undergone change by a method of manufacture into products, being the manufacture of goods or commodities from rubber.")]
        Rubber = 511,
        [System.ComponentModel.Description("513:natural fibres and materials in general (missing definition)")]
        NaturalFibresAndMaterialsInGeneral = 513,
        [System.ComponentModel.Description("514:foodstuffs, solid (missing definition)")]
        FoodstuffsSolid = 514,
        [System.ComponentModel.Description("515:foodstuffs, liquid (missing definition)")]
        FoodstuffsLiquid = 515,
        [System.ComponentModel.Description("516:foodstuffs, preserved (missing definition)")]
        FoodstuffsPreserved = 516,
        [System.ComponentModel.Description("Items relating to the whole or most; not specialised; of broad overall character. Mixed; characterised by scope or variety; items combined or associated.")]
        GeneralAndMixedGoods = 517,
        [System.ComponentModel.Description("Physical matter consisting of a relatively small and hard, but usually separate particles; or in a form which is dusty or easily crumbled into tiny, loose particles.")]
        GranularOrPowderyMaterial = 519,
        [System.ComponentModel.Description("Machinery; apparatus usually powered by electricity designed to perform a specific task. Mechanical parts; components of vehicles or machines.")]
        MachineryAndMechanicalParts = 520,
        [System.ComponentModel.Description("That out of which anything is, or may be made; equipment or implements. Parts that may be put together.")]
        ConstructionMaterials = 521,
        [System.ComponentModel.Description("A means of conveyance or transport especially a structure with wheels in or on which people or things are transported by land.")]
        Vehicles = 522,
        [System.ComponentModel.Description("Structure or machine for travelling in the air.")]
        Aircraft = 523,
        [System.ComponentModel.Description("A rail or set of parallel rails on which a train, tram, or rail wagon runs.")]
        Railway = 524,
        [System.ComponentModel.Description("Movable structures for giving shelter, normally prefabricated.")]
        PortableBuildings = 525,
        [System.ComponentModel.Description("Boxes for cargo transport with standardized dimensions.")]
        Containers = 526,
        [System.ComponentModel.Description("Devices based on the technology of the conduction of electricity in a vacuum, gas or a semiconductor.")]
        Electronics = 527,
        [System.ComponentModel.Description("Constructed from plastic.")]
        Plastic = 528,
        [System.ComponentModel.Description("Colouring matter, especially in liquid form for imparting colour to a surface.")]
        Paint = 529,
        [System.ComponentModel.Description("530:refuse (also known as rubbish/garbage/trash) and waste (missing definition)")]
        RefuseAlsoKnownAsRubbishGarbageTrashAndWaste = 530,
        [System.ComponentModel.Description("Relating to, caused by or exhibiting radioactivity; emission of radian elements capable of spontaneously emitting alpha, beta or sometimes gamma rays by the disintegration of the nuclei of atoms")]
        RadioactiveMaterial = 531,
        [System.ComponentModel.Description("Military weapons, a total means of making war; defensive equipment")]
        Armament = 532,
        [System.ComponentModel.Description("People in general.")]
        Personnel = 533,
        [System.ComponentModel.Description("534:animals (land and sea) and birds (missing definition)")]
        AnimalsLandAndSeaAndBirds = 534,
        [System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
        Fish = 535,
        [System.ComponentModel.Description("Shelled aquatic invertebrates.")]
        ShellfishAndCrustaceans = 536,
        [System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
        Ballast = 537,
        [System.ComponentModel.Description("Diesel oil available.")]
        DieselOil = 540,
        [System.ComponentModel.Description("541:petrol/gasoline (missing definition)")]
        PetrolGasoline = 541,
        [System.ComponentModel.Description("Persons travelling in a means of transport operated by others.")]
        Passengers = 542,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfFerry : int {
        [System.ComponentModel.Description("A ferry which may have routes that vary with weather, tide and traffic.")]
        FreeMovingFerry = 1,
        [System.ComponentModel.Description("A ferry that follows a fixed route guided by a cable.")]
        CableFerry = 2,
        [System.ComponentModel.Description("A winter-time ferry which crosses a lead.")]
        IceFerry = 3,
        [System.ComponentModel.Description("A high speed water vessel for civilian use.")]
        HighSpeedFerry = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfObstruction : int {
        [System.ComponentModel.Description("1:snag/stump (missing definition)")]
        SnagStump = 1,
        [System.ComponentModel.Description("A submarine structure projecting some distance above the seabed and capping a temporarily abandoned or suspended oil or gas well.")]
        Wellhead = 2,
        [System.ComponentModel.Description("A structure on an outfall through which liquids are discharged. The structure will usually project above the level of the outfall and can be an obstruction to navigation.")]
        Diffuser = 3,
        [System.ComponentModel.Description("A permanent marine structure usually designed to support or elevate pipelines; especially a structure enclosing a screening device at the offshore end of a potable water intake pipe. The structure is commonly a heavy timber enclosure that has been sunken with rocks or other debris.")]
        Crib = 4,
        [System.ComponentModel.Description("Areas established by private interests, usually sport fishermen, to simulate natural reefs and wrecks that attract fish. The reefs are constructed by dumping assorted junk in areas which may be of very small extent or may stretch a considerable distance along a depth contour.")]
        FishHaven = 5,
        [System.ComponentModel.Description("An area of numerous unidentified dangers to navigation. The area serves as a warning to the mariner that all dangers are not identified individually and that navigation through the area may be hazardous.")]
        FoulArea = 6,
        [System.ComponentModel.Description("Floating barriers, anchored to the bottom, used to deflect the path of floating ice in order to prevent the obstruction of locks, intakes, etc., and to prevent damage to bridge piers and other structures.")]
        IceBoom = 8,
        [System.ComponentModel.Description("Equipment such as anchors, concrete blocks, chains and cables, etc., used to position floating structures such as trot and mooring buoys etc.")]
        GroundTackle = 9,
        [System.ComponentModel.Description("A floating barrier used to protect a river or harbour mouth or to create a sheltered area for storage purposes.")]
        Boom = 10,
        [System.ComponentModel.Description("A device to extract energy from the surface motion of ocean waves or from pressure fluctuations below the surface.")]
        WaveEnergyDevice = 12,
        [System.ComponentModel.Description("13:subsurface ocean data acquisition system (ODAS) (missing definition)")]
        SubsurfaceOceanDataAcquisitionSystemOdas = 13,
        [System.ComponentModel.Description("A man-made structure that may mimic some of the characteristics of a natural reef, intended to attract sea life.")]
        ArtificialReef = 14,
        [System.ComponentModel.Description("A structure placed on the seafloor below a drilling rig to guide the drill.")]
        Template = 15,
        [System.ComponentModel.Description("A large steel structure up to 20 metres in height above the seafloor, or a steel frame secured to the seafloor with piles to anchor the end of a submarine pipeline, for delivery to a production platform.")]
        Manifold = 16,
        [System.ComponentModel.Description("A hill of soil-covered ice pushed up by hydrostatic pressure in an area of permafrost that is located underwater.")]
        SubmergedPingo = 17,
        [System.ComponentModel.Description("The distributed remains of a platform.")]
        RemainsOfPlatform = 18,
        [System.ComponentModel.Description("An instrument used for scientific purposes.")]
        ScientificInstrument = 19,
        [System.ComponentModel.Description("Any of various machines having a rotor, usually with vanes or blades, driven by the pressure, momentum, or reactive thrust of a moving fluid, as steam, water, hot gases, or air, either occurring in the form of free jets or as a fluid passing through and entirely filling a housing around the rotor and is located underwater.")]
        UnderwaterTurbine = 20,
        [System.ComponentModel.Description("An active seabed volcano, which may be submerged or projecting above the water at the chart sounding datum.")]
        ActiveSubmarineVolcano = 21,
        [System.ComponentModel.Description("A submerged net placed around beaches to reduce shark attacks on swimmers.")]
        SharkNet = 22,
        [System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
        Mangrove = 23,
        [System.ComponentModel.Description("a structure, typically a dome or cube, erected over a wellhead or equipment attached to it (a tree) to lessen the danger of vessels snagging gear. (AML)")]
        WellProtectionStructure = 501,
        [System.ComponentModel.Description("any oil or gas related installation or structure on, or projecting from, the seabed, for example a submerged platform or concrete foundations. (AML)")]
        SubseaInstallation = 502,
        [System.ComponentModel.Description("any pipeline related structure which projects above the seabed, for example a  joint, T-piece, valve or sleeve, or a crossing where one pipeline is raised over another by means of a supporting structure. (AML)")]
        PipelineObstruction = 503,
        [System.ComponentModel.Description("504:free standing conductor pipe (missing definition)")]
        FreeStandingConductorPipe = 504,
        [System.ComponentModel.Description("large seabed structures, typically made of concrete, capable of storing oil or gas and usually found attached or adjacent to a rig, or marked by a single point mooring buoy. (AML)")]
        StorageTank = 506,
        [System.ComponentModel.Description("A floating structure, usually rectangular in shape which serves as landing, pier head, bridge support, etc.")]
        Pontoon = 508,
        [System.ComponentModel.Description("miscellaneous items and objects, most of which have been lost overboard or otherwise abandoned to the sea, for example cargo containers or vehicles. (AML)")]
        SundryObjects = 509,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum restriction : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("An area within which anchoring is not permitted.")]
        AnchoringProhibited = 1,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which anchoring is restricted in accordance with certain specified conditions.")]
        AnchoringRestricted = 2,
        [System.ComponentModel.Description("An area within which fishing is not permitted.")]
        FishingProhibited = 3,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which fishing is restricted in accordance with certain specified conditions.")]
        FishingRestricted = 4,
        [System.ComponentModel.Description("An area within which trawling is not permitted.")]
        TrawlingProhibited = 5,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which trawling is restricted in accordance with certain specified conditions.")]
        TrawlingRestricted = 6,
        [System.ComponentModel.Description("An area within which navigation and/or anchoring is prohibited.")]
        EntryProhibited = 7,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.")]
        EntryRestricted = 8,
        [System.ComponentModel.Description("An area within which dredging is not permitted.")]
        DredgingProhibited = 9,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which dredging is restricted in accordance with certain specified conditions.")]
        DredgingRestricted = 10,
        [System.ComponentModel.Description("An area within which diving is not permitted.")]
        DivingProhibited = 11,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which diving is restricted in accordance with certain specified conditions.")]
        DivingRestricted = 12,
        [System.ComponentModel.Description("Mariners must adjust the speed of their vessels to reduce the wave or wash which may cause erosion or disturb moored vessels.")]
        NoWake = 13,
        [System.ComponentModel.Description("An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.")]
        AreaToBeAvoided = 14,
        [System.ComponentModel.Description("The erection of permanent or temporary fixed structures or artificial islands is prohibited.")]
        ConstructionProhibited = 15,
        [System.ComponentModel.Description("An area within which discharging or dumping is prohibited.")]
        DischargingProhibited = 16,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which discharging or dumping is restricted in accordance with specified conditions.")]
        DischargingRestricted = 17,
        [System.ComponentModel.Description("18:industrial or mineral (missing definition)")]
        IndustrialOrMineral18 = 18,
        [System.ComponentModel.Description("19:industrial or mineral (missing definition)")]
        IndustrialOrMineral19 = 19,
        [System.ComponentModel.Description("An area within which excavating a hole on the seabed with a drill is prohibited.")]
        DrillingProhibited = 20,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the seabed with a drill is restricted in accordance with certain specified conditions.")]
        DrillingRestricted = 21,
        [System.ComponentModel.Description("22:removal of historic (missing definition)")]
        RemovalOfHistoric = 22,
        [System.ComponentModel.Description("23:cargo transhipment (lightening) prohibited (missing definition)")]
        CargoTranshipmentLighteningProhibited = 23,
        [System.ComponentModel.Description("An area in which the dragging of anything along the seabed, for example bottom trawling, is prohibited.")]
        DraggingProhibited = 24,
        [System.ComponentModel.Description("An area in which a vessel is prohibited from stopping.")]
        StoppingProhibited = 25,
        [System.ComponentModel.Description("An area in which landing is prohibited.")]
        LandingProhibited = 26,
        [System.ComponentModel.Description("An area within which speed is restricted.")]
        SpeedRestricted = 27,
        [System.ComponentModel.Description("An area in which swimming is prohibited.")]
        SwimmingProhibited = 39,
        [System.ComponentModel.Description("42:power-driven vessels (missing definition)")]
        PowerDrivenVessels = 42,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofMilitaryPracticeArea : int {
        [System.ComponentModel.Description("An area within which exercises are carried out with torpedoes.")]
        TorpedoExerciseArea = 2,
        [System.ComponentModel.Description("An area within which submarine exercises are carried out.")]
        SubmarineExerciseArea = 3,
        [System.ComponentModel.Description("Areas for bombing and missile exercises.")]
        FiringDangerArea = 4,
        [System.ComponentModel.Description("5:mine-laying practice area (missing definition)")]
        MineLayingPracticeArea = 5,
        [System.ComponentModel.Description("The ACLANT (Allied Command Atlantic) submarine grid provides NATO submarine operating authorities with a common grid for the water space management of NATO submarines.")]
        AclantGrid = 501,
        [System.ComponentModel.Description("An area in which certain activities or factors of significance to surface navigation or operations apply.")]
        SurfaceDangerArea = 502,
        [System.ComponentModel.Description("503:JMC Areas - JENOA grid (missing definition)")]
        JmcAreasJenoaGrid = 503,
        [System.ComponentModel.Description("506:safe bottoming area (missing definition)")]
        SafeBottomingArea = 506,
        [System.ComponentModel.Description("An area in which submarine operations are prohibited or limited, owing to the existence of hazards to dived submarines.")]
        SubmarineDangerArea = 507,
        [System.ComponentModel.Description("A specified zone for the provision of sonar calibration or other underwater testing.")]
        TestingAndEvaluationRange = 508,
        [System.ComponentModel.Description("510:Impact area (missing definition)")]
        ImpactArea = 510,
        [System.ComponentModel.Description("An area used for live firing of weapons to bombard a designated area.")]
        LiveFireRange = 599,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum sonarSignalStrength : int {
        [System.ComponentModel.Description("501:nil (missing definition)")]
        Nil = 501,
        [System.ComponentModel.Description("Not as good as it could be or should.")]
        Poor = 502,
        [System.ComponentModel.Description("503:moderate (missing definition)")]
        Moderate = 503,
        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        Strong = 504,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristics : int {
        [System.ComponentModel.Description("The maximum length of the ship.")]
        LengthOverall = 1,
        [System.ComponentModel.Description("The ship's length measured at the waterline.")]
        LengthAtWaterline = 2,
        [System.ComponentModel.Description("The width or beam of the vessel.")]
        Breadth = 3,
        [System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded.")]
        Draught = 4,
        [System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement.")]
        DisplacementTonnage = 6,
        [System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.")]
        GrossTonnage = 10,
        [System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.")]
        NetTonnage = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lastSensor : int {
        [System.ComponentModel.Description("501:acoustic sensor (missing definition)")]
        AcousticSensor = 501,
        [System.ComponentModel.Description("the object was reported as a result of detecting a fluctuation in the local magnetic field.")]
        MagneticSensor = 502,
        [System.ComponentModel.Description("503:video sensor (missing definition)")]
        VideoSensor = 503,
        [System.ComponentModel.Description("504:diver sighting (found by diver - in registry) (missing definition)")]
        DiverSightingFoundByDiverInRegistry = 504,
        [System.ComponentModel.Description("506:physical snag (missing definition)")]
        PhysicalSnag = 506,
        [System.ComponentModel.Description("507:observed sinking (missing definition)")]
        ObservedSinking = 507,
        [System.ComponentModel.Description("508:Reported Sinking (missing definition)")]
        ReportedSinking = 508,
        [System.ComponentModel.Description("509:None reported (missing definition)")]
        NoneReported = 509,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCoverage : int {
        [System.ComponentModel.Description("Continuous coverage of spatial objects is available within this area.")]
        CoverageAvailable = 1,
        [System.ComponentModel.Description("An area containing no spatial objects.")]
        NoCoverageAvailable = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum beaconShape : int {
        [System.ComponentModel.Description("1:stake, pole, perch, post (missing definition)")]
        StakePolePerchPost = 1,
        [System.ComponentModel.Description("A tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.")]
        Withy = 2,
        [System.ComponentModel.Description("A solid structure of the order of 10 metres in height used as a navigational aid.")]
        BeaconTower = 3,
        [System.ComponentModel.Description("A structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.")]
        LatticeBeacon = 4,
        [System.ComponentModel.Description("A long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.")]
        PileBeacon = 5,
        [System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
        Cairn = 6,
        [System.ComponentModel.Description("A tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.")]
        BuoyantBeacon = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDumpingGround : int {
        [System.ComponentModel.Description("An area at sea where chemical waste is dumped.")]
        ChemicalWasteDumpingGround = 2,
        [System.ComponentModel.Description("An area at sea where nuclear waste is dumped.")]
        NuclearWasteDumpingGround = 3,
        [System.ComponentModel.Description("An area at sea where explosives are dumped.")]
        ExplosivesDumpingGround = 4,
        [System.ComponentModel.Description("A sea area where dredged material is deposited.")]
        SpoilGround = 5,
        [System.ComponentModel.Description("An area at sea where disused vessels are scuttled.")]
        VesselDumpingGround = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAnchorage : int {
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor.")]
        UnrestrictedAnchorage = 1,
        [System.ComponentModel.Description("An area in which vessels of deep draught anchor or may anchor.")]
        DeepWaterAnchorage = 2,
        [System.ComponentModel.Description("An area in which tankers anchor or may anchor.")]
        TankerAnchorage = 3,
        [System.ComponentModel.Description("An area where a vessel anchors when satisfying quarantine regulations.")]
        QuarantineAnchorage = 5,
        [System.ComponentModel.Description("An area in which seaplanes anchor or may anchor.")]
        SeaplaneAnchorage = 6,
        [System.ComponentModel.Description("An area in which yachts and small boats anchor or may anchor.")]
        SmallCraftAnchorage = 7,
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor for periods of up to 24 hours.")]
        AnchorageForPeriodsUpTo24Hours = 9,
        [System.ComponentModel.Description("An area in which vessels may anchor for a period of time not to exceed a specific limit.")]
        AnchorageForALimitedPeriodOfTime = 10,
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor while waiting, for example, for access to a port or berth.")]
        WaitingAnchorage = 14,
        [System.ComponentModel.Description("A location not defined by a regulatory authority that has been reported to be suitable and safe for anchoring.")]
        ReportedAnchorage = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum catagoryOfAirspaceRestriction : int {
        [System.ComponentModel.Description("An area designated by a proper authority, in which a danger to craft exists. Also called danger zone.")]
        DangerArea = 501,
        [System.ComponentModel.Description("(1) An area shown on charts within which navigation and/or anchoring is prohibited. (2) In aviation terminology, a specified area within the land areas of a state or territorial waters adjacent thereto over which the flight of aircraft is prohibited.")]
        ProhibitedArea = 502,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.")]
        RestrictedArea = 503,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum colourPattern : int {
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented horizontally.")]
        HorizontalStripes = 1,
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented vertically.")]
        VerticalStripes = 2,
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).")]
        DiagonalStripes = 3,
        [System.ComponentModel.Description("Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
        Squared = 4,
        [System.ComponentModel.Description("5:stripes (direction unknown) (missing definition)")]
        StripesDirectionUnknown = 5,
        [System.ComponentModel.Description("A band or stripe of colour which is displayed around the outer edge of the feature, which may also form a border to an inner pattern or plain colour.")]
        BorderStripe = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRadarStation : int {
        [System.ComponentModel.Description("A radar station established for traffic surveillance.")]
        RadarSurveillanceStation = 1,
        [System.ComponentModel.Description("A shore-based station which the mariner can contact by radio to obtain a position.")]
        CoastRadarStation = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfControlledAirspace : int {
        [System.ComponentModel.Description("A control area or portion thereof established in the form of a corridor equipped with radio navigation aids.")]
        Airway = 501,
        [System.ComponentModel.Description("502:Altimeter Setting Region (ASR) (missing definition)")]
        AltimeterSettingRegionAsr = 502,
        [System.ComponentModel.Description("503:Avoidance Area (AA) (missing definition)")]
        AvoidanceAreaAa = 503,
        [System.ComponentModel.Description("504:Control Area (CTA) (missing definition)")]
        ControlAreaCta = 504,
        [System.ComponentModel.Description("505:Control Zone (CTR/CTZ) (missing definition)")]
        ControlZoneCtrCtz = 505,
        [System.ComponentModel.Description("506:Flight Information Region (FIR) (missing definition)")]
        FlightInformationRegionFir = 506,
        [System.ComponentModel.Description("507:Terminal Control Area (TMA/TCA) (missing definition)")]
        TerminalControlAreaTmaTca = 507,
        [System.ComponentModel.Description("508:Aerodrome Traffic Zone (ATZ) (missing definition)")]
        AerodromeTrafficZoneAtz = 508,
        [System.ComponentModel.Description("509:Helicopter Protection Zone (HPZ) (missing definition)")]
        HelicopterProtectionZoneHpz = 509,
        [System.ComponentModel.Description("510:Helicopter Main Route (HMR) (missing definition)")]
        HelicopterMainRouteHmr = 510,
        [System.ComponentModel.Description("511:Helicopter Transit Corridor (HTC) (missing definition)")]
        HelicopterTransitCorridorHtc = 511,
        [System.ComponentModel.Description("512:Military Aerodrome Traffic Zone (MATZ) (missing definition)")]
        MilitaryAerodromeTrafficZoneMatz = 512,
        [System.ComponentModel.Description("513:Ocean Control Area (OCA) (missing definition)")]
        OceanControlAreaOca = 513,
        [System.ComponentModel.Description("514:Coastguard track [surveillance] (missing definition)")]
        CoastguardTrackSurveillance = 514,
        [System.ComponentModel.Description("515:Military Terminal Control Area (MTCA) (missing definition)")]
        MilitaryTerminalControlAreaMtca = 515,
        [System.ComponentModel.Description("516:Identification Zone (ADIZ) (missing definition)")]
        IdentificationZoneAdiz = 516,
        [System.ComponentModel.Description("517:Advisory Area (ADA) or (UDA) (missing definition)")]
        AdvisoryAreaAdaOrUda = 517,
        [System.ComponentModel.Description("518:Air Route Tradffic Control Center (ARTCC) (missing definition)")]
        AirRouteTradfficControlCenterArtcc = 518,
        [System.ComponentModel.Description("519:Area Control Center (ACC) (missing definition)")]
        AreaControlCenterAcc = 519,
        [System.ComponentModel.Description("An airspace for which a radar service is specified")]
        RadarArea = 520,
        [System.ComponentModel.Description("521:Upper Flight Information Region (UIR) (missing definition)")]
        UpperFlightInformationRegionUir = 521,
        [System.ComponentModel.Description("522:Buffer Zone (BZ) (missing definition)")]
        BufferZoneBz = 522,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCompleteness : int {
        [System.ComponentModel.Description("The area specified has been populated for all known features. Absence of features indicates that there are no such entities available to the data producer.")]
        Complete = 501,
        [System.ComponentModel.Description("Certain features have not been included (or only partially included) within the specified area. Details must be provided in supporting textual information.")]
        Partial = 502,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCargo : int {
        [System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel, for example oil or grain.")]
        Bulk = 1,
        [System.ComponentModel.Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
        Container = 2,
        [System.ComponentModel.Description("Break bulk cargo normally loaded by crane.")]
        General = 3,
        [System.ComponentModel.Description("Any cargo loaded by pipeline.")]
        Liquid = 4,
        [System.ComponentModel.Description("A fee paying traveller.")]
        Passenger = 5,
        [System.ComponentModel.Description("Live animals carried in bulk.")]
        Livestock = 6,
        [System.ComponentModel.Description("Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.")]
        DangerousOrHazardous = 7,
        [System.ComponentModel.Description("Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.")]
        HeavyLift = 8,
        [System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
        Ballast = 9,
        [System.ComponentModel.Description("Commodity cargo that is transported unpackaged in large quantities. These types of goods usually need to be kept dry during the whole transportation period.")]
        DryBulkCargo = 10,
        [System.ComponentModel.Description("Liquids or gases that are transported in bulk and carried unpackaged.")]
        LiquidBulkCargo = 11,
        [System.ComponentModel.Description("Cargo transported in refrigerated containers, generally perishable commodities which require temperature-controlled transportation, such as fruit, meat, fish, vegetables, dairy products and other foods.")]
        ReeferContainerCargo = 12,
        [System.ComponentModel.Description("13:Ro-Ro cargo (missing definition)")]
        RoRoCargo = 13,
        [System.ComponentModel.Description("Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.")]
        ProjectCargo = 14,
        [System.ComponentModel.Description("Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.")]
        BreakBulkCargo = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum signalStatus : int {
        [System.ComponentModel.Description("1:lit/sound (missing definition)")]
        LitSound = 1,
        [System.ComponentModel.Description("2:eclipsed/silent (missing definition)")]
        EclipsedSilent = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum divingActivity : int {
        [System.ComponentModel.Description("501:Commercial Diving (missing definition)")]
        CommercialDiving = 501,
        [System.ComponentModel.Description("502:Sports Diving (missing definition)")]
        SportsDiving = 502,
        [System.ComponentModel.Description("503:Dive Training (missing definition)")]
        DiveTraining = 503,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum condition : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Being built but not yet capable of function.")]
        UnderConstruction = 1,
        [System.ComponentModel.Description("A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.")]
        Ruined = 2,
        [System.ComponentModel.Description("An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.")]
        UnderReclamation = 3,
        [System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
        PlannedConstruction = 5,
        [System.ComponentModel.Description("completed, undamaged and working normally. ")]
        Operational = 501,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum nameUsage : int {
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
        DefaultNameDisplay = 1,
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
        AlternateNameDisplay = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum strengthOfMagneticAnomaly : int {
        [System.ComponentModel.Description("501:nil (missing definition)")]
        Nil = 501,
        [System.ComponentModel.Description("502:slight (missing definition)")]
        Slight = 502,
        [System.ComponentModel.Description("503:moderate (missing definition)")]
        Moderate = 503,
        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        Strong = 504,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfSurfaceQualifyingTerms : int {
        [System.ComponentModel.Description("Falls within the smallest size continuum for a particular nature of surface term.")]
        Fine = 1,
        [System.ComponentModel.Description("Falls within the moderate size continuum for a particular nature of surface term.")]
        Medium = 2,
        [System.ComponentModel.Description("Falls within the largest size continuum for a particular nature of surface term.")]
        Coarse = 3,
        [System.ComponentModel.Description("Fractured or in pieces.")]
        Broken = 4,
        [System.ComponentModel.Description("Having an adhesive or glue like property.")]
        Sticky = 5,
        [System.ComponentModel.Description("Not hard or firm.")]
        Soft = 6,
        [System.ComponentModel.Description("Not pliant; thick, resistant to flow.")]
        Stiff = 7,
        [System.ComponentModel.Description("Composed of or containing material ejected from a volcano.")]
        Volcanic = 8,
        [System.ComponentModel.Description("Composed of or containing calcium or calcium carbonate.")]
        Calcareous = 9,
        [System.ComponentModel.Description("Firm; usually refers to an area of the seafloor not covered by unconsolidated sediment.")]
        Hard = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lightCharacteristic : int {
        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
        Fixed = 1,
        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        Flashing = 2,
        [System.ComponentModel.Description("3:long-flashing (missing definition)")]
        LongFlashing = 3,
        [System.ComponentModel.Description("4:quick-flashing (missing definition)")]
        QuickFlashing = 4,
        [System.ComponentModel.Description("5:very quick-flashing (missing definition)")]
        VeryQuickFlashing = 5,
        [System.ComponentModel.Description("6:ultra quick-flashing (missing definition)")]
        UltraQuickFlashing = 6,
        [System.ComponentModel.Description("A light with all durations of light and darkness equal.")]
        Isophased = 7,
        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be: - Single-occulting: An occulting light in which an eclipse is regularly repeated. - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated. - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
        Occulting = 8,
        [System.ComponentModel.Description("A light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.")]
        InterruptedUltraQuickFlashing = 11,
        [System.ComponentModel.Description("A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
        Morse = 12,
        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
        FixedAndFlash = 13,
        [System.ComponentModel.Description("14:flash and long-flash (missing definition)")]
        FlashAndLongFlash = 14,
        [System.ComponentModel.Description("A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.")]
        OccultingAndFlash = 15,
        [System.ComponentModel.Description("16:fixed and long-flash (missing definition)")]
        FixedAndLongFlash = 16,
        [System.ComponentModel.Description("An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.")]
        OccultingAlternating = 17,
        [System.ComponentModel.Description("18:long-flash alternating (missing definition)")]
        LongFlashAlternating = 18,
        [System.ComponentModel.Description("An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        FlashAlternating = 19,
        [System.ComponentModel.Description("25:quick-flash plus longflash (missing definition)")]
        QuickFlashPlusLongflash = 25,
        [System.ComponentModel.Description("26:very quick-flash plus long-flash (missing definition)")]
        VeryQuickFlashPlusLongFlash = 26,
        [System.ComponentModel.Description("27:ultra quick-flash plus (missing definition)")]
        UltraQuickFlashPlus = 27,
        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
        Alternating = 28,
        [System.ComponentModel.Description("29:fixed and alternating (missing definition)")]
        FixedAndAlternating = 29,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCheckpoint : int {
        [System.ComponentModel.Description("Serves as a government checkpoint where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
        Custom = 1,
        [System.ComponentModel.Description("501:RV Location (missing definition)")]
        RvLocation = 501,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum topmarkDaymarkShape : int {
        [System.ComponentModel.Description("1:cone (point up) (missing definition)")]
        ConePointUp = 1,
        [System.ComponentModel.Description("2:cone (point down) (missing definition)")]
        ConePointDown = 2,
        [System.ComponentModel.Description("A curved surface all points of which are equidistant from a fixed point within, called the centre.")]
        Sphere = 3,
        [System.ComponentModel.Description("4:2 spheres (missing definition)")]
        twoSpheres = 4,
        [System.ComponentModel.Description("A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, its ends being parallel circles).")]
        Cylinder = 5,
        [System.ComponentModel.Description("Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
        Board = 6,
        [System.ComponentModel.Description("7:x-shaped (missing definition)")]
        XShaped = 7,
        [System.ComponentModel.Description("A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.")]
        UprightCross = 8,
        [System.ComponentModel.Description("9:cube (point up) (missing definition)")]
        CubePointUp = 9,
        [System.ComponentModel.Description("10:2 cones (point to point) (missing definition)")]
        twoConesPointToPoint = 10,
        [System.ComponentModel.Description("11:2 cones (base to base) (missing definition)")]
        twoConesBaseToBase = 11,
        [System.ComponentModel.Description("A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.")]
        Rhombus = 12,
        [System.ComponentModel.Description("13:2 cones (points upward) (missing definition)")]
        twoConesPointsUpward = 13,
        [System.ComponentModel.Description("14:2 cones (points downward) (missing definition)")]
        twoConesPointsDownward = 14,
        [System.ComponentModel.Description("15:besom (point up) (missing definition)")]
        BesomPointUp = 15,
        [System.ComponentModel.Description("16:besom (point down) (missing definition)")]
        BesomPointDown = 16,
        [System.ComponentModel.Description("A flag mounted on a short pole.")]
        Flag = 17,
        [System.ComponentModel.Description("A sphere located above a rhombus.")]
        SphereOverARhombus = 18,
        [System.ComponentModel.Description("A plane figure with four right angles and four equal straight sides.")]
        Square = 19,
        [System.ComponentModel.Description("20:rectangle (horizontal) (missing definition)")]
        RectangleHorizontal = 20,
        [System.ComponentModel.Description("21:rectangle (vertical) (missing definition)")]
        RectangleVertical = 21,
        [System.ComponentModel.Description("22:trapezium (up) (missing definition)")]
        TrapeziumUp = 22,
        [System.ComponentModel.Description("23:trapezium (down) (missing definition)")]
        TrapeziumDown = 23,
        [System.ComponentModel.Description("24:triangle (point up) (missing definition)")]
        TrianglePointUp = 24,
        [System.ComponentModel.Description("25:triangle (point down) (missing definition)")]
        TrianglePointDown = 25,
        [System.ComponentModel.Description("A perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
        Circle = 26,
        [System.ComponentModel.Description("27:two upright crosses (one over the other) (missing definition)")]
        TwoUprightCrossesOneOverTheOther = 27,
        [System.ComponentModel.Description("28:T-shape (missing definition)")]
        TShape = 28,
        [System.ComponentModel.Description("A triangle, vertex uppermost, located above a circle.")]
        TrianglePointingUpOverACircle = 29,
        [System.ComponentModel.Description("An upright cross located above a circle.")]
        UprightCrossOverACircle = 30,
        [System.ComponentModel.Description("A rhombus located above a circle.")]
        RhombusOverACircle = 31,
        [System.ComponentModel.Description("A circle located over a triangle, vertex uppermost.")]
        CircleOverATrianglePointingUp = 32,
        [System.ComponentModel.Description("33:other shape (see shape information) (missing definition)")]
        OtherShapeSeeShapeInformation = 33,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryofMarineProtectedArea : int {
        [System.ComponentModel.Description("Strict Nature Reserve: Protected area managed mainly for science.")]
        IucnCategoryIa = 1,
        [System.ComponentModel.Description("Wilderness Area: Protected area managed mainly for wilderness protection.")]
        IucnCategoryIb = 2,
        [System.ComponentModel.Description("National Park: Protected area managed mainly for ecosystem protection and recreation.")]
        IucnCategoryIi = 3,
        [System.ComponentModel.Description("Natural Monument: Protected area managed mainly for conservation of specific natural features.")]
        IucnCategoryIii = 4,
        [System.ComponentModel.Description("Habitat/Species Management Area: Protected area managed mainly for conservation through management intervention.")]
        IucnCategoryIv = 5,
        [System.ComponentModel.Description("Protected Landscape/Seascape: Protected area managed mainly for landscape/seascape conservation and recreation.")]
        IucnCategoryV = 6,
        [System.ComponentModel.Description("Managed Resource Protected Area: Protected area managed mainly for the sustainable use of natural ecosystems.")]
        IucnCategoryVi = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfConstruction : int {
        [System.ComponentModel.Description("Constructed of stones or bricks, usually quarried, shaped, and mortared.")]
        Masonry = 1,
        [System.ComponentModel.Description("Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
        Concreted = 2,
        [System.ComponentModel.Description("Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
        LooseBoulders = 3,
        [System.ComponentModel.Description("4:hard surface (missing definition)")]
        HardSurface = 4,
        [System.ComponentModel.Description("Constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.")]
        Unsurfaced = 5,
        [System.ComponentModel.Description("Constructed from wood.")]
        Wooden = 6,
        [System.ComponentModel.Description("Constructed from metal.")]
        Metal = 7,
        [System.ComponentModel.Description("Constructed from a plastic material strengthened with fibres of glass.")]
        GlassReinforcedPlastic = 8,
        [System.ComponentModel.Description("A structure of crossed wooden or metal strips usually arranged to form a diagonal pattern of open spaces between the strips.")]
        Latticed = 11,
        [System.ComponentModel.Description("[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like. [2] Something made of such a substance, as a windowpane.")]
        Glass = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDolphin : int {
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used as a mooring point for vessels.")]
        MooringDolphin = 1,
        [System.ComponentModel.Description("A post or group of posts, which a vessel may swing around for compass adjustment.")]
        DeviationDolphin = 2,
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to extend the berth of a vessel by providing extra mooring points.")]
        BerthingDolphin = 3,
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to assist in berthing of vessels by taking up some berthing loads; keep vessels from pressing against the pier structure; or to protect structures from possible impact by ships.")]
        FenderOrBreastingDolphin = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum qualityOfVerticalMeasurement : int {
        [System.ComponentModel.Description("The depth from the chart datum to the seabed (or to the top of a drying feature) is known.")]
        DepthKnown = 1,
        [System.ComponentModel.Description("2:depth unknown (missing definition)")]
        DepthUnknown = 2,
        [System.ComponentModel.Description("A depth that may be less than indicated.")]
        DoubtfulSounding = 3,
        [System.ComponentModel.Description("A depth that is considered to be an unreliable value.")]
        UnreliableSounding = 4,
        [System.ComponentModel.Description("The shoalest depth over a feature is of known value.")]
        LeastDepthKnown = 6,
        [System.ComponentModel.Description("7:least depth unknown, safe clearance at value shown (missing definition)")]
        LeastDepthUnknownSafeClearanceAtValueShown = 7,
        [System.ComponentModel.Description("8:value reported (not surveyed) (missing definition)")]
        ValueReportedNotSurveyed = 8,
        [System.ComponentModel.Description("9:value reported (not confirmed) (missing definition)")]
        ValueReportedNotConfirmed = 9,
        [System.ComponentModel.Description("The depth at which a channel is kept by human influence, usually by dredging.")]
        MaintainedDepth = 10,
        [System.ComponentModel.Description("Depths may be altered by human influence, but will not be routinely maintained.")]
        NotRegularlyMaintained = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfShorelineConstruction : int {
        [System.ComponentModel.Description("A structure protecting a shore area, harbour, anchorage, or basin from waves.")]
        Breakwater = 1,
        [System.ComponentModel.Description("A low artificial wall-like structure of durable material extending from the land to seaward for a particular purpose, such as to protect the coast or to force a current to scour a channel.")]
        Groyne = 2,
        [System.ComponentModel.Description("A form of breakwater alongside which vessels may lie on the sheltered side only; in some cases it may lie entirely within an artificial harbour, permitting vessels to lie along both sides.")]
        Mole = 3,
        [System.ComponentModel.Description("4:pier (jetty) (missing definition)")]
        PierJetty = 4,
        [System.ComponentModel.Description("A pier built only for recreational purposes.")]
        PromenadePier = 5,
        [System.ComponentModel.Description("6:wharf (quay) (missing definition)")]
        WharfQuay = 6,
        [System.ComponentModel.Description("A wall or bank, often submerged, built to direct or confine the flow of a river or tidal current, or to promote a scour action.")]
        TrainingWall = 7,
        [System.ComponentModel.Description("A layer of broken rock, cobbles, boulders, or fragments of sufficient size to resist the erosive forces of flowing water and wave action.")]
        RipRap = 8,
        [System.ComponentModel.Description("Facing of stone or other material, either permanent or temporary, placed along the edge of a stream, river or canal to stabilize the bank and to protect it from the erosive action of the stream.")]
        Revetment = 9,
        [System.ComponentModel.Description("An embankment or wall for protection against waves or tidal action along a shore or water front.")]
        SeaWall = 10,
        [System.ComponentModel.Description("Steps at the shoreline as the connection between land and water on different levels.")]
        LandingSteps = 11,
        [System.ComponentModel.Description("(1) A sloping structure which may include rails that can either be used, as a landing place, at variable water levels, for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel. (2) An accumulation of snow that forms an inclined plane between land or land ice elements and sea ice or ice shelf. Also called drift ice foot.")]
        Ramp = 12,
        [System.ComponentModel.Description("The prepared and usually reinforced inclined surface on which keel- and bilge-blocks are laid for supporting a vessel under construction.")]
        Slipway = 13,
        [System.ComponentModel.Description("A protective structure designed to cushion the impact of a vessel and prevent damage.")]
        Fender = 14,
        [System.ComponentModel.Description("A wharf consisting of a solid wall of concrete, masonry, wood etc., such that the water cannot circulate freely under the wharf. The type of construction affects ship-handling; for example, a solid face wharf may give shelter from tidal streams, but under certain circumstances a cushion of water may build up between such a wharf and a ship attempting to berth at it, causing difficulties in ship handling.")]
        SolidFaceWharf = 15,
        [System.ComponentModel.Description("A wharf supported on piles or other structures which allow free circulation of water under the wharf.")]
        OpenFaceWharf = 16,
        [System.ComponentModel.Description("An inclined plane used to dump logs into the water for transport, or to haul logs out of the water for processing.")]
        LogRamp = 17,
        [System.ComponentModel.Description("An artificial pool or swimming enclosure, especially one in the open air, which may be constructed of wire mesh or heavy netting supported by cables, buoys or piles, for swimming in.")]
        SwimmingFacility = 20,
        [System.ComponentModel.Description("A wharf approximately parallel to the shoreline and accommodating ships on one side only, the other side being attached to the shore. It is usually of solid construction, as contrasted with the open pile construction usually used for piers.")]
        Quay = 22,
        [System.ComponentModel.Description("23:tie-up wall (missing definition)")]
        TieUpWall = 23,
        [System.ComponentModel.Description("Man-made structure that acts as an obstacle to landing operations.")]
        ArtificialObstacle = 501,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lightVisibility : int {
        [System.ComponentModel.Description("Non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).")]
        HighIntensity = 1,
        [System.ComponentModel.Description("Non-marine lights with lower power than marine lights.")]
        LowIntensity = 2,
        [System.ComponentModel.Description("A decrease in the apparent intensity of a light which may occur in the case of partial obstructions.")]
        Faint = 3,
        [System.ComponentModel.Description("A light in a sector is intensified (that is, has longer range than other sectors).")]
        Intensified = 4,
        [System.ComponentModel.Description("A light in a sector is unintensified (that is, has shorter range than other sectors).")]
        Unintensified = 5,
        [System.ComponentModel.Description("A light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.")]
        VisibilityDeliberatelyRestricted = 6,
        [System.ComponentModel.Description("Said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.")]
        Obscured = 7,
        [System.ComponentModel.Description("This value specifies that parts of the sector are obscured.")]
        PartiallyObscured = 8,
        [System.ComponentModel.Description("Lights that must be in line to be visible.")]
        VisibleInLineOfRange = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSeaArea : int {
        [System.ComponentModel.Description("A natural or artificial passage or channel through shoals or steep banks, or across a line of banks lying between two channels.")]
        Gat = 2,
        [System.ComponentModel.Description("An elevation of the seafloor, at depths generally less than 200 m, but sufficient for safe surface navigation, commonly found on the continental shelf or near an island.")]
        Bank = 3,
        [System.ComponentModel.Description("In oceanography, an obsolete term which was generally restricted to depths greater than 6,000 m.")]
        Deep = 4,
        [System.ComponentModel.Description("A wide indentation in the coastline generally smaller than a gulf and larger than a cove. For the purposes of the United Nations Convention on the Law of the Sea, a bay is a well-marked indentation whose penetration is in such proportion to the width of its mouth as to contain land locked waters and constitute more than a mere curvature of the coast.")]
        Bay = 5,
        [System.ComponentModel.Description("A long, deep, asymmetrical depression with relatively steep sides, that is associated with subduction.")]
        Trench = 6,
        [System.ComponentModel.Description("A depression of the seafloor more or less equidimensional in plan and of variable extent.")]
        Basin = 7,
        [System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
        MudFlats = 8,
        [System.ComponentModel.Description("A shallow elevation composed of consolidated material that may constitute a hazard to surface navigation.")]
        Reef = 9,
        [System.ComponentModel.Description("A rocky formation continuous with and fringing the shore.")]
        Ledge = 10,
        [System.ComponentModel.Description("An elongated, narrow, steep-sided depression that generally deepens down-slope.")]
        Canyon = 11,
        [System.ComponentModel.Description("A navigable narrow part of a bay, strait, river, etc.")]
        Narrows = 12,
        [System.ComponentModel.Description("A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.")]
        Shoal = 13,
        [System.ComponentModel.Description("A distinct elevation with a rounded profile less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        Knoll = 14,
        [System.ComponentModel.Description("An elongated elevation of varying complexity and size, generally having steep sides.")]
        Ridge = 15,
        [System.ComponentModel.Description("A distinct generally equidimensional elevation greater than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        Seamount = 16,
        [System.ComponentModel.Description("Any high tower or spire-shaped pillar or rock or coral, alone or cresting a summit. It may extend above the surface of the water. It may or may not be a hazard to surface navigation.")]
        Pinnacle = 17,
        [System.ComponentModel.Description("An extensive, flat, gently sloping or nearly level region at abyssal depths.")]
        AbyssalPlain = 18,
        [System.ComponentModel.Description("A large, relatively flat elevation that is higher than the surrounding relief with one or more relatively steep sides.")]
        Plateau = 19,
        [System.ComponentModel.Description("A subordinate ridge protruding from a larger feature.")]
        Spur = 20,
        [System.ComponentModel.Description("The flat or gently sloping region adjacent to a continent or around an island that extends from the low water line to a depth, generally about 200m, where there is a marked increase in downward slope.")]
        Shelf = 21,
        [System.ComponentModel.Description("A long depression generally wide and flat bottomed with symmetrical and parallel sides.")]
        Trough = 22,
        [System.ComponentModel.Description("A broad pass or col in a ridge, rise or other elevation.")]
        Saddle = 23,
        [System.ComponentModel.Description("An isolated small elevation on the deep seafloor.")]
        AbyssalHill = 24,
        [System.ComponentModel.Description("A gently dipping slope, with a smooth surface, commonly found around groups of islands and seamounts.")]
        Apron = 25,
        [System.ComponentModel.Description("A gentle slope with a generally smooth surface of the seafloor, characteristically found around groups of islands or seamounts.")]
        ArchipelagicApron = 26,
        [System.ComponentModel.Description("A region adjacent to a continent, normally occupied by or bordering a shelf and sometimes emerging as islands, that is irregular or blocky in plan or profile, with depths well in excess of those typical of a shelf.")]
        Borderland = 27,
        [System.ComponentModel.Description("The zone, generally consisting of shelf, slope and continental rise, separating the continent from the deep seafloor or abyssal plain or plain. Occasionally a trench may be present in place of a continental rise.")]
        ContinentalMargin = 28,
        [System.ComponentModel.Description("A gentle slope rising from the oceanic depths towards the foot of a continental slope.")]
        ContinentalRise = 29,
        [System.ComponentModel.Description("An elongated, characteristically linear, steep slope separating horizontal or gently sloping areas of the seafloor.")]
        Escarpment = 30,
        [System.ComponentModel.Description("A relatively smooth, depositional feature continuously deepening away from a sediment source commonly located at the lower termination of a canyon or canyon system.")]
        Fan = 31,
        [System.ComponentModel.Description("A long narrow zone of irregular topography formed by the movement of tectonic plates associated with an offset of a spreading ridge axis, characterized by steep-sided and/or asymmetrical ridges, troughs or escarpments.")]
        FractureZone = 32,
        [System.ComponentModel.Description("A narrow break in a ridge, rise or other elevation.")]
        Gap = 33,
        [System.ComponentModel.Description("A seamount having a comparatively smooth flat top.")]
        Guyot = 34,
        [System.ComponentModel.Description("[1] A small isolated elevation, smaller than a mountain. [2] A distinct elevation generally of irregular shape, less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        Hill = 35,
        [System.ComponentModel.Description("A depression of limited extent with all sides rising steeply from a relatively flat bottom.")]
        Hole = 36,
        [System.ComponentModel.Description("A depositional embankment bordering a canyon, valley or sea channel.")]
        Levee = 37,
        [System.ComponentModel.Description("The axial depression of the mid-oceanic ridge system.")]
        MedianValley = 38,
        [System.ComponentModel.Description("An annular or partially annular depression commonly located at the base of seamounts, islands and other isolated elevations.")]
        Moat = 39,
        [System.ComponentModel.Description("A natural elevation of the earth's surface rising more or less abruptly from the surrounding level, and attaining an altitude which, relatively to adjacent elevations, is impressive or notable.")]
        Mountains = 40,
        [System.ComponentModel.Description("A conical or pointed elevation on a larger feature such as a seamount.")]
        Peak = 41,
        [System.ComponentModel.Description("A geographically distinct region with a number of shared physiographic characteristics that contrast with those in the surrounding areas. This term should be modified with the generic term that best describes the majority of features in the region, for example \"Seamount\" in Baja California Seamount Province.")]
        Province = 42,
        [System.ComponentModel.Description("A broad elevation that generally rises gently and smoothly from the surrounding relief.")]
        Rise = 43,
        [System.ComponentModel.Description("An elongated, meandering depression, usually occurring on a gently sloping plain or fan.")]
        SeaChannel = 44,
        [System.ComponentModel.Description("Several seamounts in linear or arcuate alignment.")]
        SeamountChain = 45,
        [System.ComponentModel.Description("46:shelf-edge (missing definition)")]
        ShelfEdge = 46,
        [System.ComponentModel.Description("A relatively shallow barrier between BASINS that may inhibit water movement.")]
        Sill = 47,
        [System.ComponentModel.Description("The sloping region that deepens from a shelf to the point where there is a general decrease in gradient.")]
        Slope = 48,
        [System.ComponentModel.Description("A flat or gently sloping region, generally long and narrow, bounded along one edge by a steeper descending slope and along the other by a steeper ascending slope.")]
        Terrace = 49,
        [System.ComponentModel.Description("An elongated depression that generally widens and deepens down-slope.")]
        Valley = 50,
        [System.ComponentModel.Description("An artificial waterway with no flow, or a controlled flow, used for navigation, or for draining or irrigating land (ditch).")]
        Canal = 51,
        [System.ComponentModel.Description("A large body of water entirely surrounded by land.")]
        Lake = 52,
        [System.ComponentModel.Description("A relatively large natural stream of water.")]
        River = 53,
        [System.ComponentModel.Description("A straight section of a river, especially a navigable river between two bends; or an arm of the sea extending into the land.")]
        Reach = 54,
        [System.ComponentModel.Description("A low, flat island of sand, coral, etc. awash or submerged at high water.")]
        IntertidalCay = 55,
        [System.ComponentModel.Description("A seabed volcano, submerged at the chart sounding datum, which may or may not be active.")]
        SubmarineVolcano = 56,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfConveyor : int {
        [System.ComponentModel.Description("A transportation system consisting of load cables strung between pylons on which carrier units (for example: cars or buckets intended to transport people, material, and/or equipment) are suspended.")]
        AerialCableway = 1,
        [System.ComponentModel.Description("A conveyor along which material or people are transported by means of a moving belt.")]
        BeltConveyor = 2,
        [System.ComponentModel.Description("An artificial channel, usually an inclined chute or trough, for carrying water to furnish power, transport logs down a mountainside, etc.")]
        Flume = 3,
        [System.ComponentModel.Description("4:lift/elevator (missing definition)")]
        LiftElevator = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRoad : int {
        [System.ComponentModel.Description("A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.")]
        Motorway = 1,
        [System.ComponentModel.Description("A hard surfaced (metalled) road; a main through route.")]
        MajorRoad = 2,
        [System.ComponentModel.Description("A secondary road for local traffic.")]
        MinorRoad = 3,
        [System.ComponentModel.Description("4:track/path (missing definition)")]
        TrackPath = 4,
        [System.ComponentModel.Description("A main road, in an urban area, for through traffic.")]
        MajorStreet = 5,
        [System.ComponentModel.Description("A secondary road, in an urban area, for local traffic.")]
        MinorStreet = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum bottomFeatureClassification : int {
        [System.ComponentModel.Description("In geology, a break of shear in the earth's crust with an observable displacement between the two sides of the break, and parallel to the plane of the break.")]
        Fault = 502,
        [System.ComponentModel.Description("A large mobile wave-like sediment feature in shallow water and composed of sand. The wavelength may reach 100 metres, the amplitude may be up to 20 metres.")]
        Sandwave = 510,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristicsUnit : int {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        Metres = 1,
        [System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.")]
        MetricTon = 3,
        [System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
        Ton = 4,
        [System.ComponentModel.Description("A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
        ShortTon = 5,
        [System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
        GrossTon = 6,
        [System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
        NetTon = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum firstSensor : int {
        [System.ComponentModel.Description("501:acoustic sensor (missing definition)")]
        AcousticSensor = 501,
        [System.ComponentModel.Description("the object was reported as a result of detecting a fluctuation in the local magnetic field.")]
        MagneticSensor = 502,
        [System.ComponentModel.Description("503:video sensor (missing definition)")]
        VideoSensor = 503,
        [System.ComponentModel.Description("504:diver sighting - (found by diver - in registry) (missing definition)")]
        DiverSightingFoundByDiverInRegistry = 504,
        [System.ComponentModel.Description("506:physical snag (missing definition)")]
        PhysicalSnag = 506,
        [System.ComponentModel.Description("507:observed sinking (missing definition)")]
        ObservedSinking = 507,
        [System.ComponentModel.Description("508:Reported Sinking (missing definition)")]
        ReportedSinking = 508,
        [System.ComponentModel.Description("509:None reported (missing definition)")]
        NoneReported = 509,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum waterLevelEffect : int {
        [System.ComponentModel.Description("Partially covered and partially dry at high water.")]
        PartlySubmergedAtHighWater = 1,
        [System.ComponentModel.Description("Not covered at high water under average meteorological conditions.")]
        AlwaysDry = 2,
        [System.ComponentModel.Description("3:always under water/ (missing definition)")]
        AlwaysUnderWater = 3,
        [System.ComponentModel.Description("Expression intended to indicate an area of a reef or other projection from the bottom of a body of water which periodically extends above and is submerged below the surface. Also referred to as dries or uncovers.")]
        CoversAndUncovers = 4,
        [System.ComponentModel.Description("Flush with, or washed by the waves at low water under average meteorological conditions.")]
        Awash = 5,
        [System.ComponentModel.Description("6:subject to inundation or (missing definition)")]
        SubjectToInundationOr = 6,
        [System.ComponentModel.Description("Resting or moving on the surface of a liquid without sinking.")]
        Floating = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum boundaryStatusType : int {
        [System.ComponentModel.Description("501:definite (missing definition)")]
        Definite = 501,
        [System.ComponentModel.Description("502:indefinite (missing definition)")]
        Indefinite = 502,
        [System.ComponentModel.Description("Has not been defined by either of the adjoining authorities.")]
        NoDefinedBoundary = 504,
        [System.ComponentModel.Description("Boundary has not been ratified")]
        NotYetRatified = 599,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum signalGeneration : int {
        [System.ComponentModel.Description("Activated by radio signal.")]
        RadioActivated = 5,
        [System.ComponentModel.Description("Activated by making a call to a manned station.")]
        CallActivated = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum speciesGrouping : int {
        [System.ComponentModel.Description("Any of an order (Cetacea) of aquatic mostly marine mammals that includes the whales, dolphins, porpoises, and related forms and that have a torpedo-shaped nearly hairless body, paddle-shaped forelimbs but no hind limbs, one or two nares opening externally at the top of the head, and a horizontally flattened tail used for locomotion.")]
        Cetacean = 501,
        [System.ComponentModel.Description("Any of an order or suborder (Pinnipedia) of aquatic carnivorous mammals (such as a seal or walrus) with all four limbs modified into flippers.")]
        Pinniped = 502,
        [System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
        Fish = 503,
        [System.ComponentModel.Description("Any of an order (Testudines synonym Chelonia) of terrestrial, freshwater, and marine reptiles that have a toothless horny beak and a shell of bony dermal plates usually covered with horny shields enclosing the trunk and into which the head, limbs, and tail usually may be withdrawn.")]
        Turtle = 504,
        [System.ComponentModel.Description("Any of a class (Aves) of warm-blooded vertebrates distinguished by having the body more or less completely covered with feathers and the forelimbs modified as wings.")]
        Bird = 505,
        [System.ComponentModel.Description("Any of an order (Sirenia) of aquatic herbivorous mammals (such as a manatee, dugong, or Steller's sea cow) that have large forelimbs resembling paddles, no hind limbs, and a flattened tail resembling a fin.")]
        Sirenian = 506,
        [System.ComponentModel.Description("507:Otter (animal) (missing definition)")]
        OtterAnimal = 507,
        [System.ComponentModel.Description("A large creamy-white carnivorous bear (Ursus maritimus synonym Thalarctos maritimus) that inhabits arctic regions.")]
        PolarBear = 508,
        [System.ComponentModel.Description("Any of numerous venomous aquatic chiefly viviparous elapid snakes of warm seas.")]
        SeaSnake = 509,
        [System.ComponentModel.Description("A reef, often of large extent, composed chiefly of coral and its derivatives.")]
        CoralReef = 510,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfReportingRadioCallingInPoint : int {
        [System.ComponentModel.Description("501:Reporting/Radio calling in point (missing definition)")]
        ReportingRadioCallingInPoint = 501,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfFishingFacility : int {
        [System.ComponentModel.Description("Poles or stakes placed in shallow water to outline a fishing ground or to catch fish.")]
        FishingStake = 1,
        [System.ComponentModel.Description("A structure (usually portable) for catching fish.")]
        FishTrap = 2,
        [System.ComponentModel.Description("A fence of stakes or stones set in a river or along the shore to trap fish.")]
        FishWeir = 3,
        [System.ComponentModel.Description("A net built at sea for catching tunny.")]
        TunnyNet = 4,
    }

    public static class CodeList {
    }

    namespace ComplexAttributes
    {
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
            public String headline { get; set; } = string.Empty;
            public String linkage { get; set; } = string.Empty;
            public String nameOfResource { get; set; } = string.Empty;

            public onlineResource() {
                linkage = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName {
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
            public lastSensor? lastSensor { get; set; } = default;
            public String lastSource { get; set; } = string.Empty;
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
            public String headline { get; set; } = string.Empty;
            public String language { get; set; } = string.Empty;
            public String fileLocator { get; set; } = string.Empty;
            public String text { get; set; } = string.Empty;
            public String fileReference { get; set; } = string.Empty;

            public information() {
                language = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class firstSourceInformation {
            [Required()]
            public firstSensor firstSensor { get; set; }
            public String firstSource { get; set; } = string.Empty;
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

            [Required()]
            public vesselsCharacteristics vesselsCharacteristics { get; set; }

            [Required()]
            public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; }
            public comparisonOperator? comparisonOperator { get; set; } = default;

            public vesselMeasurementsSpecification() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class surfaceCharacteristics {
            public Int32? underlyingLayer { get; set; } = default;
            public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms { get; set; } = [];
            public natureOfSurface? natureOfSurface { get; set; } = default;

            public surfaceCharacteristics() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class magneticInformation {
            public strengthOfMagneticAnomaly? strengthOfMagneticAnomaly { get; set; } = default;
            public Int32? magneticIntensity { get; set; } = default;

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
            public String producerNation { get; set; } = string.Empty;
            public String sourceType { get; set; } = string.Empty;
            public String productionAgency { get; set; } = string.Empty;
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
            [Required()]
            public speedUnits speedUnits { get; set; }
            public String vesselClass { get; set; } = string.Empty;

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
            public String language { get; set; } = string.Empty;

            public shapeInformation() {
                text = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class signalSequence {
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
            public String language { get; set; } = string.Empty;

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
            [Required()]
            public topmarkDaymarkShape topmarkDaymarkShape { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
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
            public List<lightVisibility> lightVisibility { get; set; } = [];
            public Decimal? valueOfNominalRange { get; set; } = default;
            public Boolean? sectorArcExtension { get; set; } = default;
            public directionalCharacter? directionalCharacter { get; set; }

            [Required()]
            public List<colour> colour { get; set; }

            public lightSector() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorCharacteristics {
            public List<signalSequence> signalSequence { get; set; } = [];
            public Decimal? signalPeriod { get; set; } = default;

            [Required()]
            public List<lightSector> lightSector { get; set; }

            [Required()]
            public lightCharacteristic lightCharacteristic { get; set; }
            public List<String> signalGroup { get; set; } = [];

            public sectorCharacteristics() {
                lightSector = new();
            }
        }
    }

    public enum Role {
    }

    namespace Associations
    {
        namespace InformationAssociations
        {
        }

        namespace FeatureAssociations
        {
        }
    }

    namespace Bindings
    {
    }

    namespace InformationTypes
    {
        using ComplexAttributes;
        using DomainModel;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ReferenceToAPublication : InformationNode {
            public DateOnly? editionDate { get; set; } = default;
            public String editionNumber { get; set; } = string.Empty;
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ReferenceToAPublication);

            public ReferenceToAPublication() {
            }
        }
    }

    namespace FeatureTypes
    {
        using ComplexAttributes;
        using DomainModel;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InstallationBuoy : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public List<product> product { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<status> status { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public List<information> information { get; set; } = [];

            [Required()]
            public List<colour> colour { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;

            [Required()]
            public buoyShape buoyShape { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public categoryOfInstallationBuoy? categoryOfInstallationBuoy { get; set; } = default;
            public override string Code => nameof(InstallationBuoy);

            public InstallationBuoy() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DepthArea : FeatureNode {
            [Required()]
            public Decimal depthRangeMaximumValue { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];

            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public override string Code => nameof(DepthArea);

            public DepthArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadioCallingInPoint : FeatureNode {
            public categoryOfReportingRadioCallingInPoint? categoryOfReportingRadioCallingInPoint { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<String> communicationChannel { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<Decimal> orientationValue { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public override string Code => nameof(RadioCallingInPoint);

            public RadioCallingInPoint() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PatrolArea : FeatureNode {
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public String nationality { get; set; } = string.Empty;
            public String controllingAuthority { get; set; } = string.Empty;

            [Required()]
            public categoryOfPatrolArea categoryOfPatrolArea { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<status> status { get; set; } = [];
            public override string Code => nameof(PatrolArea);

            public PatrolArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Checkpoint : FeatureNode {
            public String controllingAuthority { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public categoryOfCheckpoint? categoryOfCheckpoint { get; set; } = default;
            public override string Code => nameof(Checkpoint);

            public Checkpoint() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MarineManagementArea : FeatureNode {
            public restriction? restriction { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<speciesGrouping> speciesGrouping { get; set; } = [];

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }

            [Required()]
            public jurisdiction jurisdiction { get; set; }
            public List<information> information { get; set; } = [];
            public categoryofMarineProtectedArea? categoryofMarineProtectedArea { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public String controllingAuthority { get; set; } = string.Empty;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public status? status { get; set; } = default;
            public List<categoryofRestrictions> categoryofRestrictions { get; set; } = [];
            public List<String> species { get; set; } = [];
            public override string Code => nameof(MarineManagementArea);

            public MarineManagementArea() {
                nationalMaritimeAuthority = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DepthContour : FeatureNode {
            public List<information> information { get; set; } = [];
            public verticalUncertainty? verticalUncertainty { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }

            [Required()]
            public Decimal valueOfDepthContour { get; set; }
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(DepthContour);

            public DepthContour() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class EnvironmentallySensitiveSeaArea : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public String controllingAuthority { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(EnvironmentallySensitiveSeaArea);

            public EnvironmentallySensitiveSeaArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Road : FeatureNode {
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public categoryOfRoad? categoryOfRoad { get; set; } = default;
            public condition? condition { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(Road);

            public Road() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class River : FeatureNode {
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<status> status { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(River);

            public River() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MilitaryPracticeArea : FeatureNode {
            public altitudeRange? altitudeRange { get; set; }
            public String depthRestriction { get; set; } = string.Empty;
            public depthUnits? depthUnits { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String nationality { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<typeofMilitaryActivity> typeofMilitaryActivity { get; set; } = [];
            public String activePeriod { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public Int32? minimumSafeDepth { get; set; } = default;
            public List<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea { get; set; } = [];
            public Int32? bottomVerticalSafetySeparation { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public areaCategory? areaCategory { get; set; } = default;
            public verticalDatum? verticalDatum { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public String controllingAuthority { get; set; } = string.Empty;
            public override string Code => nameof(MilitaryPracticeArea);

            public MilitaryPracticeArea() {
                depthRestriction = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DiscolouredWater : FeatureNode {
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public override string Code => nameof(DiscolouredWater);

            public DiscolouredWater() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CardinalBuoy : FeatureNode {
            [Required()]
            public categoryOfCardinalMark categoryOfCardinalMark { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [Required()]
            public buoyShape buoyShape { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public topmark? topmark { get; set; }
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(CardinalBuoy);

            public CardinalBuoy() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SafeWaterBuoy : FeatureNode {
            [Required()]
            public buoyShape buoyShape { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public topmark? topmark { get; set; }
            public List<status> status { get; set; } = [];
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public colourPattern? colourPattern { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SafeWaterBuoy);

            public SafeWaterBuoy() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadioStation : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];
            public frequencyPair? frequencyPair { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public String callsign { get; set; } = string.Empty;
            public fixedDateRange? fixedDateRange { get; set; }
            public String communicationChannel { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public List<categoryOfRadioStation> categoryOfRadioStation { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Decimal? estimatedRangeofTransmission { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public override string Code => nameof(RadioStation);

            public RadioStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MilitaryExerciseAirspace : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public String controllingAuthority { get; set; } = string.Empty;
            public String activePeriod { get; set; } = string.Empty;
            public altitude? altitude { get; set; }
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public flightLevel? flightLevel { get; set; }
            public override string Code => nameof(MilitaryExerciseAirspace);

            public MilitaryExerciseAirspace() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContiguousZone : FeatureNode {
            public sourceIdentification? sourceIdentification { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Boolean? inDispute { get; set; } = default;

            [Required()]
            public List<String> nationality { get; set; }

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ContiguousZone);

            public ContiguousZone() {
                nationality = new();
                nationalMaritimeAuthority = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NormalBaseline : FeatureNode {
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String nationality { get; set; } = string.Empty;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public status? status { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public override string Code => nameof(NormalBaseline);

            public NormalBaseline() {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableArea : FeatureNode {
            public List<information> information { get; set; } = [];
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<categoryOfCable> categoryOfCable { get; set; } = [];
            public override string Code => nameof(CableArea);

            public CableArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContinentalShelfArea : FeatureNode {
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
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public override string Code => nameof(ContinentalShelfArea);

            public ContinentalShelfArea() {
                nationalMaritimeAuthority = new();
                nationality = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InternalWaters : FeatureNode {
            [Required()]
            public List<String> nationality { get; set; }

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public Boolean? inDispute { get; set; } = default;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public Boolean? lineTypeGeodesic { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public status? status { get; set; } = default;
            public override string Code => nameof(InternalWaters);

            public InternalWaters() {
                nationality = new();
                nationalMaritimeAuthority = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AdministrationArea : FeatureNode {
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inDispute { get; set; } = default;

            [Required()]
            public jurisdiction jurisdiction { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public List<String> nationality { get; set; } = [];
            public override string Code => nameof(AdministrationArea);

            public AdministrationArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Bollard : FeatureNode {
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public condition? condition { get; set; } = default;
            public List<status> status { get; set; } = [];
            public override string Code => nameof(Bollard);

            public Bollard() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Dolphin : FeatureNode {
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Decimal? verticalLength { get; set; } = default;
            public colourPattern? colourPattern { get; set; } = default;

            [Required()]
            public categoryOfDolphin categoryOfDolphin { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public List<information> information { get; set; } = [];
            public Decimal? elevation { get; set; } = default;
            public List<status> status { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public condition? condition { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public override string Code => nameof(Dolphin);

            public Dolphin() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarRange : FeatureNode {
            public List<information> information { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<String> communicationChannel { get; set; } = [];
            public List<status> status { get; set; } = [];
            public override string Code => nameof(RadarRange);

            public RadarRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IsolatedDangerBeacon : FeatureNode {
            public condition? condition { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;

            [Required()]
            public beaconShape beaconShape { get; set; }
            public Boolean? radarConspicuous { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public sourceIdentification? sourceIdentification { get; set; }
            public topmark? topmark { get; set; }
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;

            [Required()]
            public List<colour> colour { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public colourPattern? colourPattern { get; set; } = default;
            public override string Code => nameof(IsolatedDangerBeacon);

            public IsolatedDangerBeacon() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IsolatedDangerBuoy : FeatureNode {
            public fixedDateRange? fixedDateRange { get; set; }
            public topmark? topmark { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;

            [Required()]
            public List<colour> colour { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [Required()]
            public buoyShape buoyShape { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public override string Code => nameof(IsolatedDangerBuoy);

            public IsolatedDangerBuoy() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SubmarineTransitLane : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public Int32? bottomVerticalSafetySeparation { get; set; } = default;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public String controllingAuthority { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public Int32? minimumSafeDepth { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(SubmarineTransitLane);

            public SubmarineTransitLane() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MaritimeSafetyInformationArea : FeatureNode {
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(MaritimeSafetyInformationArea);

            public MaritimeSafetyInformationArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AirspaceRestriction : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public flightLevel? flightLevel { get; set; }
            public String controllingAuthority { get; set; } = string.Empty;
            public altitudeRange? altitudeRange { get; set; }
            public List<information> information { get; set; } = [];
            public verticalDatum? verticalDatum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public catagoryOfAirspaceRestriction? catagoryOfAirspaceRestriction { get; set; } = default;
            public override string Code => nameof(AirspaceRestriction);

            public AirspaceRestriction() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Sounding : FeatureNode {
            public status? status { get; set; } = default;
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public Boolean? displayUncertainties { get; set; } = default;
            public override string Code => nameof(Sounding);

            public Sounding() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeBoundary : FeatureNode {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(TrafficSeparationSchemeBoundary);

            public TrafficSeparationSchemeBoundary() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DumpingGround : FeatureNode {
            public List<categoryOfDumpingGround> categoryOfDumpingGround { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? dateDisused { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DumpingGround);

            public DumpingGround() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AirportAirfield : FeatureNode {
            public List<categoryOfAirportAirfield> categoryOfAirportAirfield { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public condition? condition { get; set; } = default;
            public Int32? runwayLength { get; set; } = default;
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String controllingAuthority { get; set; } = string.Empty;
            public Decimal? elevation { get; set; } = default;
            public verticalDatum? verticalDatum { get; set; } = default;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public String iCAOcode { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public override string Code => nameof(AirportAirfield);

            public AirportAirfield() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FoulGround : FeatureNode {
            public List<status> status { get; set; } = [];
            public Decimal? valueOfSounding { get; set; } = default;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FoulGround);

            public FoulGround() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightAirObstruction : FeatureNode {
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Decimal? valueOfNominalRange { get; set; } = default;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public rythmOfLight? rythmOfLight { get; set; }
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public Int32? flareBearing { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public List<lightVisibility> lightVisibility { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Decimal? relativeHorizontalAccuracy { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? relativeVerticalAccuracy { get; set; } = default;
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<colour> colour { get; set; } = [];
            public override string Code => nameof(LightAirObstruction);

            public LightAirObstruction() {
                pictorialRepresentation = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MooringBuoy : FeatureNode {
            public Decimal? maximumPermittedVesselLength { get; set; } = default;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public buoyShape buoyShape { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? visitorsMooring { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public override string Code => nameof(MooringBuoy);

            public MooringBuoy() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class UnderwaterAwashRock : FeatureNode {
            [Required()]
            public Decimal valueOfSounding { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Decimal? surroundingDepth { get; set; } = default;
            public List<information> information { get; set; } = [];
            public natureOfSurface? natureOfSurface { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public Boolean? displayUncertainties { get; set; } = default;
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public Decimal? defaultClearanceDepth { get; set; } = default;
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? horizontalLength { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public firstSourceInformation? firstSourceInformation { get; set; }
            public lastSourceInformation? lastSourceInformation { get; set; }
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;
            public override string Code => nameof(UnderwaterAwashRock);

            public UnderwaterAwashRock() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableOverhead : FeatureNode {
            public condition? condition { get; set; } = default;
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public categoryOfCable? categoryOfCable { get; set; } = default;
            public verticalClearanceSafe? verticalClearanceSafe { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public visualProminence? visualProminence { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public Decimal? iceFactor { get; set; } = default;
            public override string Code => nameof(CableOverhead);

            public CableOverhead() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ControlledAirspace : FeatureNode {
            public controlledAirspaceClassDesignation? controlledAirspaceClassDesignation { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public categoryOfControlledAirspace? categoryOfControlledAirspace { get; set; } = default;
            public String controllingAuthority { get; set; } = string.Empty;
            public altitude? altitude { get; set; }
            public sourceIdentification? sourceIdentification { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public flightLevel? flightLevel { get; set; }
            public override string Code => nameof(ControlledAirspace);

            public ControlledAirspace() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Obstruction : FeatureNode {
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public String controllingAuthority { get; set; } = string.Empty;
            public List<product> product { get; set; } = [];
            public Boolean? existenceOfRestrictedArea { get; set; } = default;
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;
            public lastSourceInformation? lastSourceInformation { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public firstSourceInformation? firstSourceInformation { get; set; }
            public DateOnly? abandonmentDate { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public Decimal? soundingDepth { get; set; } = default;
            public orientation? orientation { get; set; }
            public soundingDatum? soundingDatum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public magneticInformation? magneticInformation { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalUncertainty? verticalUncertainty { get; set; }
            public condition? condition { get; set; } = default;
            public Int32? generalWaterDepth { get; set; } = default;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public detectionDateRange? detectionDateRange { get; set; }
            public String oprtor { get; set; } = string.Empty;
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public sonarSignalStrength? sonarSignalStrength { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public DateOnly? spuddedDate { get; set; } = default;
            public categoryOfObstruction? categoryOfObstruction { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public DateOnly? dateSunk { get; set; } = default;
            public Decimal? horizontalLength { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public String currentScourDimensions { get; set; } = string.Empty;
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public cardinalPointOrientation? cardinalPointOrientation { get; set; } = default;
            public Decimal? valueOfSounding { get; set; } = default;

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public String nation { get; set; } = string.Empty;
            public Decimal? defaultClearanceDepth { get; set; } = default;
            public Boolean? displayUncertainties { get; set; } = default;
            public override string Code => nameof(Obstruction);

            public Obstruction() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FishingGround : FeatureNode {
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FishingGround);

            public FishingGround() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FishingFacility : FeatureNode {
            public List<information> information { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public condition? condition { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? verticalLength { get; set; } = default;
            public List<status> status { get; set; } = [];
            public categoryOfFishingFacility? categoryOfFishingFacility { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public override string Code => nameof(FishingFacility);

            public FishingFacility() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NavigationSystem : FeatureNode {
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public categoryOfRadioStation? categoryOfRadioStation { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String callsign { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public String communicationChannel { get; set; } = string.Empty;
            public Int32? signalFrequency { get; set; } = default;
            public override string Code => nameof(NavigationSystem);

            public NavigationSystem() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeCrossing : FeatureNode {
            public List<restriction> restriction { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public override string Code => nameof(TrafficSeparationSchemeCrossing);

            public TrafficSeparationSchemeCrossing() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeLanePart : FeatureNode {
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? orientationValue { get; set; } = default;
            public List<status> status { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(TrafficSeparationSchemeLanePart);

            public TrafficSeparationSchemeLanePart() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TerritorialSeaArea : FeatureNode {
            [Required()]
            public List<String> nationality { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public status? status { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TerritorialSeaArea);

            public TerritorialSeaArea() {
                nationality = new();
                nationalMaritimeAuthority = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LateralBeacon : FeatureNode {
            public Decimal? elevation { get; set; } = default;

            [Required()]
            public beaconShape beaconShape { get; set; }
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;

            [Required()]
            public categoryOfLateralMark categoryOfLateralMark { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public Boolean? radarConspicuous { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public topmark? topmark { get; set; }
            public Decimal? height { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [Required()]
            public List<colour> colour { get; set; }
            public override string Code => nameof(LateralBeacon);

            public LateralBeacon() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CoastGuardStation : FeatureNode {
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Boolean? isMRCC { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public List<String> communicationsChannel { get; set; } = [];
            public override string Code => nameof(CoastGuardStation);

            public CoastGuardStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeparationZoneOrLine : FeatureNode {
            public DateOnly? reportedDate { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public override string Code => nameof(SeparationZoneOrLine);

            public SeparationZoneOrLine() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class BottomFeature : FeatureNode {
            public List<information> information { get; set; } = [];
            public Int32? migrationDirection { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? horizontalLength { get; set; } = default;
            public bottomFeatureClassification? bottomFeatureClassification { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public override string Code => nameof(BottomFeature);

            public BottomFeature() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ArchipelagicBaseline : FeatureNode {
            public DateOnly? reportedDate { get; set; } = default;
            public status? status { get; set; } = default;
            public Boolean? inDispute { get; set; } = default;
            public String nationality { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(ArchipelagicBaseline);

            public ArchipelagicBaseline() {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SmallBottomObject : FeatureNode {
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public statusOfSmallBottomObject? statusOfSmallBottomObject { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];

            [Required()]
            public Decimal valueOfSounding { get; set; }
            public override string Code => nameof(SmallBottomObject);

            public SmallBottomObject() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ExclusiveEconomicZone : FeatureNode {
            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Boolean? inDispute { get; set; } = default;

            [Required()]
            public List<String> nationality { get; set; }
            public override string Code => nameof(ExclusiveEconomicZone);

            public ExclusiveEconomicZone() {
                nationalMaritimeAuthority = new();
                nationality = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarStation : FeatureNode {
            public List<status> status { get; set; } = [];
            public categoryOfRadarStation? categoryOfRadarStation { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String callsign { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<String> communicationChannel { get; set; } = [];
            public Decimal? valueOfMaximumRange { get; set; } = default;
            public override string Code => nameof(RadarStation);

            public RadarStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DivingLocation : FeatureNode {
            public Decimal? waterClarity { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public divingActivity? divingActivity { get; set; } = default;
            public override string Code => nameof(DivingLocation);

            public DivingLocation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RestrictedArea : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String nationality { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String controllingAuthority { get; set; } = string.Empty;

            [Required()]
            public List<restriction> restriction { get; set; }
            public override string Code => nameof(RestrictedArea);

            public RestrictedArea() {
                restriction = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableSubmarine : FeatureNode {
            public List<status> status { get; set; } = [];
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public Decimal? buriedDepth { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public categoryOfCable? categoryOfCable { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public condition? condition { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public fixedDateRange? fixedDateRange { get; set; }
            public override string Code => nameof(CableSubmarine);

            public CableSubmarine() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Wreck : FeatureNode {
            public Decimal? surroundingDepth { get; set; } = default;
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public horizontalPositionUncertainty? horizontalPositionUncertainty { get; set; }
            public visualProminence? visualProminence { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Decimal? horizontalLength { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public String currentScourDimensions { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public sonarSignalStrength? sonarSignalStrength { get; set; } = default;
            public List<information> information { get; set; } = [];
            public magneticInformation? magneticInformation { get; set; }
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Decimal? defaultClearanceDepth { get; set; } = default;
            public natureOfSurface? natureOfSurface { get; set; } = default;
            public Decimal? orientationValue { get; set; } = default;
            public String typeOfWreck { get; set; } = string.Empty;

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public categoryOfWreck? categoryOfWreck { get; set; } = default;
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Decimal? height { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String debrisField { get; set; } = string.Empty;

            [Required()]
            public List<String> nationality { get; set; }
            public lastSourceInformation? lastSourceInformation { get; set; }
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;
            public cardinalPointOrientation? cardinalPointOrientation { get; set; } = default;
            public List<vesselMeasurementsSpecification> vesselMeasurementsSpecification { get; set; } = [];
            public Boolean? existenceOfRestrictedArea { get; set; } = default;
            public DateOnly? dateSunk { get; set; } = default;
            public firstSourceInformation? firstSourceInformation { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;
            public Decimal? valueOfSounding { get; set; } = default;
            public List<product> product { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? displayUncertainties { get; set; } = default;
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(Wreck);

            public Wreck() {
                nationality = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class QRoute : FeatureNode {
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public List<status> status { get; set; } = [];
            public qRouteChannelWidth? qRouteChannelWidth { get; set; }
            public directionHeading? directionHeading { get; set; }
            public String nationality { get; set; } = string.Empty;
            public override string Code => nameof(QRoute);

            public QRoute() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CompletenessOfProductSpecification : FeatureNode {
            public String agencyResponsibleForProduction { get; set; } = string.Empty;

            [Required()]
            public categoryOfCompleteness categoryOfCompleteness { get; set; }
            public String copyrightStatement { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CompletenessOfProductSpecification);

            public CompletenessOfProductSpecification() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RescueStation : FeatureNode {
            public List<status> status { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<String> communicationChannel { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<categoryOfRescueStation> categoryOfRescueStation { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RescueStation);

            public RescueStation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CardinalBeacon : FeatureNode {
            public List<information> information { get; set; } = [];
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;

            [Required()]
            public beaconShape beaconShape { get; set; }
            public topmark? topmark { get; set; }

            [Required()]
            public categoryOfCardinalMark categoryOfCardinalMark { get; set; }
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public List<colour> colour { get; set; }
            public Decimal? elevation { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public condition? condition { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(CardinalBeacon);

            public CardinalBeacon() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightVessel : FeatureNode {
            public List<status> status { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Decimal? horizontalLength { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Decimal? horizontalWidth { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public override string Code => nameof(LightVessel);

            public LightVessel() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FisheryZone : FeatureNode {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;

            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public List<String> species { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public status? status { get; set; } = default;
            public override string Code => nameof(FisheryZone);

            public FisheryZone() {
                nationality = string.Empty;
                nationalMaritimeAuthority = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DredgedArea : FeatureNode {
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public DateOnly? dredgedDate { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? depthRangeMaximumValue { get; set; } = default;
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }
            public List<restriction> restriction { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DredgedArea);

            public DredgedArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FerryRoute : FeatureNode {
            public List<status> status { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;

            [Required()]
            public List<categoryOfFerry> categoryOfFerry { get; set; }
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public override string Code => nameof(FerryRoute);

            public FerryRoute() {
                categoryOfFerry = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ShorelineConstruction : FeatureNode {
            public Decimal? horizontalLength { get; set; } = default;
            public gradientOfSlope? gradientOfSlope { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public condition? condition { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public Decimal? horizontalWidth { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public String pictorialRepresentation { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public List<information> information { get; set; } = [];

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public categoryOfShorelineConstruction? categoryOfShorelineConstruction { get; set; } = default;
            public colourPattern? colourPattern { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public override string Code => nameof(ShorelineConstruction);

            public ShorelineConstruction() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CautionArea : FeatureNode {
            public DateOnly? reportedDate { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public status? status { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CautionArea);

            public CautionArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DeepWaterRoutePart : FeatureNode {
            public Boolean? imoAdopted { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<information> information { get; set; } = [];

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public List<status> status { get; set; } = [];

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<restriction> restriction { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public override string Code => nameof(DeepWaterRoutePart);

            public DeepWaterRoutePart() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CurrentNonGravitational : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public orientation orientation { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }

            [Required()]
            public speed speed { get; set; }
            public status? status { get; set; } = default;
            public override string Code => nameof(CurrentNonGravitational);

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
        public partial class DataCoverage : FeatureNode {
            public Int32? drawingIndex { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public categoryOfCoverage? categoryOfCoverage { get; set; } = default;

            [Required()]
            public Int32 optimumDisplayScale { get; set; }

            [Required()]
            public Int32 minimumDisplayScale { get; set; }
            public List<information> information { get; set; } = [];

            [Required()]
            public Int32 maximumDisplayScale { get; set; }
            public override string Code => nameof(DataCoverage);

            public DataCoverage() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeabedArea : FeatureNode {
            public List<information> information { get; set; } = [];
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [Required()]
            public List<surfaceCharacteristics> surfaceCharacteristics { get; set; }
            public Decimal? attenuation { get; set; } = default;
            public override string Code => nameof(SeabedArea);

            public SeabedArea() {
                surfaceCharacteristics = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpecialPurposeGeneralBuoy : FeatureNode {
            public List<information> information { get; set; } = [];

            [Required()]
            public buoyShape buoyShape { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public sourceIdentification? sourceIdentification { get; set; }
            public colourPattern? colourPattern { get; set; } = default;

            [Required()]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }
            public String pictorialRepresentation { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public topmark? topmark { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<fixedDateRange> fixedDateRange { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public override string Code => nameof(SpecialPurposeGeneralBuoy);

            public SpecialPurposeGeneralBuoy() {
                categoryOfSpecialPurposeMark = new();
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightSectored : FeatureNode {
            public List<status> status { get; set; } = [];
            public Decimal? relativeHorizontalAccuracy { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Decimal? relativeVerticalAccuracy { get; set; } = default;
            public List<categoryOfLight> categoryOfLight { get; set; } = [];
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Decimal? height { get; set; } = default;
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public List<sectorCharacteristics> sectorCharacteristics { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public signalGeneration? signalGeneration { get; set; } = default;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(LightSectored);

            public LightSectored() {
                pictorialRepresentation = string.Empty;
                sectorCharacteristics = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IceLine : FeatureNode {
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(IceLine);

            public IceLine() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AnchorageArea : FeatureNode {
            public List<restriction> restriction { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public periodicDateRange? periodicDateRange { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<categoryOfAnchorage> categoryOfAnchorage { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<status> status { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];
            public override string Code => nameof(AnchorageArea);

            public AnchorageArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LateralBuoy : FeatureNode {
            public Boolean? radarConspicuous { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public List<status> status { get; set; } = [];

            [Required()]
            public categoryOfLateralMark categoryOfLateralMark { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;

            [Required()]
            public buoyShape buoyShape { get; set; }
            public topmark? topmark { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public override string Code => nameof(LateralBuoy);

            public LateralBuoy() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeRoundabout : FeatureNode {
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public sourceIdentification? sourceIdentification { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<status> status { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public override string Code => nameof(TrafficSeparationSchemeRoundabout);

            public TrafficSeparationSchemeRoundabout() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DeepWaterRouteCentreline : FeatureNode {
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<featureName> featureName { get; set; } = [];

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Boolean? imoAdopted { get; set; } = default;
            public List<information> information { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [Required()]
            public Boolean basedOnFixedMarks { get; set; }
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public override string Code => nameof(DeepWaterRouteCentreline);

            public DeepWaterRouteCentreline() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightFloat : FeatureNode {
            public Decimal? verticalLength { get; set; } = default;
            public List<status> status { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [Required()]
            public List<colour> colour { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public topmark? topmark { get; set; }
            public List<information> information { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(LightFloat);

            public LightFloat() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightAllAround : FeatureNode {
            public Decimal? verticalLength { get; set; } = default;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public signalGeneration? signalGeneration { get; set; } = default;
            public Decimal? valueOfNominalRange { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public multiplicityOfFeatures multiplicityOfFeatures { get; set; }
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public Decimal? relativeHorizontalAccuracy { get; set; } = default;
            public verticalDatum? verticalDatum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Boolean? majorLight { get; set; } = default;
            public lightVisibility? lightVisibility { get; set; } = default;
            public Int32? flareBearing { get; set; } = default;
            public heightLengthUnits? heightLengthUnits { get; set; } = default;
            public List<categoryOfLight> categoryOfLight { get; set; } = [];

            [Required()]
            public rythmOfLight rythmOfLight { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(LightAllAround);

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
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Coastline : FeatureNode {
            public List<colour> colour { get; set; } = [];
            public List<information> information { get; set; } = [];
            public categoryOfCoastline? categoryOfCoastline { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public override string Code => nameof(Coastline);

            public Coastline() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeaAreaNamedWaterArea : FeatureNode {
            public categoryOfSeaArea? categoryOfSeaArea { get; set; } = default;
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public gradient? gradient { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;
            public override string Code => nameof(SeaAreaNamedWaterArea);

            public SeaAreaNamedWaterArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DropZone : FeatureNode {
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DropZone);

            public DropZone() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Conveyor : FeatureNode {
            public categoryOfConveyor? categoryOfConveyor { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public condition? condition { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public List<information> information { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<status> status { get; set; } = [];
            public Decimal? liftingCapacity { get; set; } = default;
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;
            public fixedDateRange? fixedDateRange { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<product> product { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public override string Code => nameof(Conveyor);

            public Conveyor() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LineOfDelimitation : FeatureNode {
            [Required()]
            public List<String> nationalMaritimeAuthority { get; set; }
            public boundaryStatusType? boundaryStatusType { get; set; } = default;
            public List<information> information { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public sourceIdentification? sourceIdentification { get; set; }
            public jurisdiction? jurisdiction { get; set; } = default;
            public categoryofBoundaryLine? categoryofBoundaryLine { get; set; } = default;
            public Boolean? inDispute { get; set; } = default;
            public override string Code => nameof(LineOfDelimitation);

            public LineOfDelimitation() {
                nationalMaritimeAuthority = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class StraightTerritorialSeaBaseline : FeatureNode {
            public String nationality { get; set; } = string.Empty;
            public sourceIdentification? sourceIdentification { get; set; }
            public DateOnly? reportedDate { get; set; } = default;
            public List<information> information { get; set; } = [];
            public status? status { get; set; } = default;
            public Boolean? inDispute { get; set; } = default;
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(StraightTerritorialSeaBaseline);

            public StraightTerritorialSeaBaseline() {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SafeWaterBeacon : FeatureNode {
            public List<information> information { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Decimal? elevation { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public topmark? topmark { get; set; }
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public condition? condition { get; set; } = default;
            public colourPattern? colourPattern { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? verticalLength { get; set; } = default;

            [Required()]
            public beaconShape beaconShape { get; set; }
            public List<status> status { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public sourceIdentification? sourceIdentification { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [Required()]
            public List<colour> colour { get; set; }
            public visualProminence? visualProminence { get; set; } = default;
            public override string Code => nameof(SafeWaterBeacon);

            public SafeWaterBeacon() {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpecialPurposeGeneralBeacon : FeatureNode {
            public sourceIdentification? sourceIdentification { get; set; }
            public List<information> information { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public colourPattern? colourPattern { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public String pictorialRepresentation { get; set; } = string.Empty;

            [Required()]
            public beaconShape beaconShape { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public topmark? topmark { get; set; }

            [Required()]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;

            [Required()]
            public List<colour> colour { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public override string Code => nameof(SpecialPurposeGeneralBeacon);

            public SpecialPurposeGeneralBeacon() {
                categoryOfSpecialPurposeMark = new();
                colour = new();
            }
        }
    }
}