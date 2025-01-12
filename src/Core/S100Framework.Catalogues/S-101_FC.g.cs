using System;
using System.Collections.Immutable;
using System.Linq;


namespace S100Framework.DomainModel.S101
{

    public static class Information
    {
        public static Version Version => new Version("2.0.0");

        public static string[] ComplexTypes => [
            "featureName",
            "featuresDetected",
            "fixedDateRange",
            "frequencyPair",
            "horizontalClearanceFixed",
            "horizontalClearanceOpen",
            "horizontalPositionUncertainty",
            "information",
            "measuredDistanceValue",
            "multiplicityOfFeatures",
            "onlineResource",
            "orientation",
            "periodicDateRange",
            "radarWaveLength",
            "sectorInformation",
            "sectorLimitOne",
            "sectorLimitTwo",
            "shapeInformation",
            "signalSequence",
            "speed",
            "surfaceCharacteristics",
            "surveyDateRange",
            "telecommunications",
            "tidalStreamValue",
            "timeIntervalsByDayOfWeek",
            "topmark",
            "valueOfLocalMagneticAnomaly",
            "verticalUncertainty",
            "vesselSpeedLimit",
            "zoneOfConfidence",
            "directionalCharacter",
            "rhythmOfLight",
            "scheduleByDayOfWeek",
            "sectorLimit",
            "spatialAccuracy",
            "tidalStreamPanelValues",
            "verticalClearanceClosed",
            "verticalClearanceFixed",
            "verticalClearanceOpen",
            "verticalClearanceSafe",
            "lightSector",
            "sectorCharacteristics",
        ];

        public static string[] InformationTypes => [
            "ContactDetails",
            "ServiceHours",
            "NonStandardWorkingDay",
            "NauticalInformation",
            "SpatialQuality",
        ];

        public static string[] FeatureTypes => [
            "QualityOfNonBathymetricData",
            "DataCoverage",
            "NavigationalSystemOfMarks",
            "LocalDirectionOfBuoyage",
            "QualityOfBathymetricData",
            "SoundingDatum",
            "VerticalDatumOfData",
            "QualityOfSurvey",
            "UpdateInformation",
            "MagneticVariation",
            "LocalMagneticAnomaly",
            "Coastline",
            "LandArea",
            "IslandGroup",
            "LandElevation",
            "River",
            "Rapids",
            "Waterfall",
            "Lake",
            "LandRegion",
            "Vegetation",
            "IceArea",
            "SlopingGround",
            "SlopeTopline",
            "Tideway",
            "BuiltUpArea",
            "Building",
            "AirportAirfield",
            "Runway",
            "Helipad",
            "Bridge",
            "SpanFixed",
            "SpanOpening",
            "Conveyor",
            "CableOverhead",
            "PipelineOverhead",
            "PylonBridgeSupport",
            "FenceWall",
            "Railway",
            "Road",
            "Tunnel",
            "Landmark",
            "SiloTank",
            "WindTurbine",
            "FortifiedStructure",
            "ProductionStorageArea",
            "Checkpoint",
            "Hulk",
            "Pile",
            "Dyke",
            "ShorelineConstruction",
            "StructureOverNavigableWater",
            "Causeway",
            "Canal",
            "DistanceMark",
            "Gate",
            "Dam",
            "Crane",
            "Berth",
            "Dolphin",
            "Bollard",
            "DryDock",
            "FloatingDock",
            "Pontoon",
            "DockArea",
            "Gridiron",
            "LockBasin",
            "MooringTrot",
            "SeaAreaNamedWaterArea",
            "TidalStreamFloodEbb",
            "CurrentNonGravitational",
            "WaterTurbulence",
            "TidalStreamPanelData",
            "Sounding",
            "DredgedArea",
            "SweptArea",
            "DepthContour",
            "DepthArea",
            "DepthNoBottomFound",
            "UnsurveyedArea",
            "SeabedArea",
            "WeedKelp",
            "Seagrass",
            "Sandwave",
            "Spring",
            "UnderwaterAwashRock",
            "Wreck",
            "Obstruction",
            "FoulGround",
            "DiscolouredWater",
            "FishingFacility",
            "MarineFarmCulture",
            "OffshorePlatform",
            "CableSubmarine",
            "CableArea",
            "PipelineSubmarineOnLand",
            "SubmarinePipelineArea",
            "OffshoreProductionArea",
            "NavigationLine",
            "RecommendedTrack",
            "RangeSystem",
            "Fairway",
            "FairwaySystem",
            "RecommendedRouteCentreline",
            "TwoWayRoutePart",
            "TwoWayRoute",
            "RecommendedTrafficLanePart",
            "DeepWaterRouteCentreline",
            "DeepWaterRoutePart",
            "DeepWaterRoute",
            "InshoreTrafficZone",
            "PrecautionaryArea",
            "TrafficSeparationSchemeLanePart",
            "SeparationZoneOrLine",
            "TrafficSeparationSchemeBoundary",
            "TrafficSeparationSchemeCrossing",
            "TrafficSeparationSchemeRoundabout",
            "TrafficSeparationScheme",
            "ArchipelagicSeaLaneArea",
            "ArchipelagicSeaLaneAxis",
            "ArchipelagicSeaLane",
            "RadioCallingInPoint",
            "FerryRoute",
            "RadarLine",
            "RadarRange",
            "RadarStation",
            "AnchorageArea",
            "MooringArea",
            "AnchorBerth",
            "SeaplaneLandingArea",
            "DumpingGround",
            "MilitaryPracticeArea",
            "AdministrationArea",
            "CargoTranshipmentArea",
            "CautionArea",
            "InformationArea",
            "ContiguousZone",
            "ContinentalShelfArea",
            "CustomZone",
            "ExclusiveEconomicZone",
            "FisheryZone",
            "FishingGround",
            "FreePortArea",
            "HarbourAreaAdministrative",
            "LogPond",
            "OilBarrier",
            "StraightTerritorialSeaBaseline",
            "TerritorialSeaArea",
            "SubmarineTransitLane",
            "PilotageDistrict",
            "CollisionRegulationsLimit",
            "MarinePollutionRegulationsArea",
            "RestrictedArea",
            "LightAllAround",
            "LightSectored",
            "LightFogDetector",
            "LightAirObstruction",
            "LateralBuoy",
            "CardinalBuoy",
            "IsolatedDangerBuoy",
            "SafeWaterBuoy",
            "SpecialPurposeGeneralBuoy",
            "EmergencyWreckMarkingBuoy",
            "InstallationBuoy",
            "MooringBuoy",
            "LateralBeacon",
            "CardinalBeacon",
            "IsolatedDangerBeacon",
            "SafeWaterBeacon",
            "SpecialPurposeGeneralBeacon",
            "Daymark",
            "LightFloat",
            "LightVessel",
            "Retroreflector",
            "RadarReflector",
            "FogSignal",
            "PhysicalAISAidToNavigation",
            "VirtualAISAidToNavigation",
            "RadioStation",
            "RadarTransponderBeacon",
            "PilotBoardingPlace",
            "VesselTrafficServiceArea",
            "CoastGuardStation",
            "SignalStationWarning",
            "SignalStationTraffic",
            "RescueStation",
            "HarbourFacility",
            "SmallCraftFacility",
            "TextPlacement",
            "Chart1Feature",
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum beaconShape : int
    {
        [System.ComponentModel.Description("An elongated wood or metal pole, driven into the ground or seabed, which serves as a navigational aid or a support for a navigational aid.")]
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
    public enum bridgeConstruction : int
    {
        [System.ComponentModel.Description("A typically curved structural member spanning an opening and serving as a support (as for the wall or other weight above the opening).")]
        Arch = 1,

        [System.ComponentModel.Description("A structure consisting of a series of arches or towers supporting a roadway, waterway, etc., across a depression, etc.")]
        Viaduct = 2,

        [System.ComponentModel.Description("A fixed floating bridge supported by pontoons.")]
        PontoonBridge = 3,

        [System.ComponentModel.Description("A fixed bridge consisting of either a roadway or a truss suspended from two or more cables which pass over towers and are anchored by backstays to a firm foundation.")]
        SuspensionBridge = 4,

        [System.ComponentModel.Description("Consists of towers on each side of the watercourse connected by a system of girders on which a carriage runs.")]
        TransporterBridge = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum bridgeFunction : int
    {
        [System.ComponentModel.Description("Of, relating to, or designed for vehicles and especially motor vehicles.")]
        Vehicular = 1,

        [System.ComponentModel.Description("Of, relating to, or designed for vehicles that run on a guiding track(s), especially trains.")]
        Rail = 2,

        [System.ComponentModel.Description("Of, relating to, or designed for walking.")]
        Pedestrian = 3,

        [System.ComponentModel.Description("A bridge supporting an artificially elevated channel, for the conveyance of water.")]
        Aqueduct = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum buildingShape : int
    {
        [System.ComponentModel.Description("A building having many storeys.")]
        HighRiseBuilding = 5,

        [System.ComponentModel.Description("A polyhedron of which one face is a polygon of any number of sides, and the other faces are triangles with a common vertex.")]
        Pyramid = 6,

        [System.ComponentModel.Description("Shaped like a cylinder, which is a solid geometrical figure generated by straight lines fixed in direction and describing with one of its points a closed curve, especially a circle.")]
        Cylindrical = 7,

        [System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
        Spherical = 8,

        [System.ComponentModel.Description("A shape the sides of which are six equal squares; a regular hexahedron.")]
        Cubic = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum buoyShape : int
    {
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
    public enum categoryOfAirportAirfield : int
    {
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

        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of aeroplanes or helicopters in times of search and rescue.")]
        SearchAndRescueAirfield = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAnchorage : int
    {
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
    public enum categoryOfBuiltUpArea : int
    {
        [System.ComponentModel.Description("An area predominantly occupied by man-made structures used for residential, commercial, and industrial purposes.")]
        UrbanArea = 1,

        [System.ComponentModel.Description("A continuously occupied concentration of tents or lightweight fixed structures (for example: huts) serving as residences.")]
        Settlement = 2,

        [System.ComponentModel.Description("A self-contained group of houses and associated buildings, usually in a country area.")]
        Village = 3,

        [System.ComponentModel.Description("An inhabited place larger and more regularly built and with more complete and independent local government than a village but not incorporated as a city.")]
        Town = 4,

        [System.ComponentModel.Description("A major town inhabited by a large permanent community with all essential services.")]
        City = 5,

        [System.ComponentModel.Description("A complex for holiday-makers with cottages, shops, and entertainment, on site, which is mainly populated on a seasonal basis.")]
        HolidayVillage = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCable : int
    {
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
    public enum categoryOfCanal : int
    {
        [System.ComponentModel.Description("A canal used for navigation as part of a transport system.")]
        Transportation = 1,

        [System.ComponentModel.Description("A canal used to drain excess water from surrounding land.")]
        Drainage = 2,

        [System.ComponentModel.Description("A canal used to supply water for the purpose of irrigation.")]
        Irrigation = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCardinalMark : int
    {
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
    public enum categoryOfCheckpoint : int
    {
        [System.ComponentModel.Description("Serves as a government checkpoint where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
        Custom = 1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCoastline : int
    {
        [System.ComponentModel.Description("A coast backed by rock or earth cliffs, gives a good radar return and is useful for visual identification from a considerable distance off, where cliffs alternate with low lying coast along the shoreline.")]
        SteepCoast = 1,

        [System.ComponentModel.Description("A level coast with no obvious topographic features.")]
        FlatCoast = 2,

        [System.ComponentModel.Description("Projecting seaward extension of glacier, usually afloat.")]
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
    public enum categoryOfConveyor : int
    {
        [System.ComponentModel.Description("A transportation system consisting of load cables strung between pylons on which carrier units (for example: cars or buckets intended to transport people, material, and/or equipment) are suspended.")]
        AerialCableway = 1,

        [System.ComponentModel.Description("A conveyor along which material or people are transported by means of a moving belt.")]
        BeltConveyor = 2,

        [System.ComponentModel.Description("An artificial channel, usually an inclined chute or trough, for carrying water to furnish power, transport logs down a mountainside, etc.")]
        Flume = 3,

        [System.ComponentModel.Description("Any of various mechanical devices for raising objects or materials.")]
        LiftElevator = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCrane : int
    {
        [System.ComponentModel.Description("A high speed, shore-based crane used in the lift-on/lift-off operation of specially constructed containers.")]
        ContainerCraneGantry = 2,

        [System.ComponentModel.Description("A tripodal structure used in dockyards and harbours for stepping masts or lifting loads in to and out of vessels.")]
        Sheerlegs = 3,

        [System.ComponentModel.Description("A crane mounted on rails (track) that can move (usually parallel to the wharf face) in order to load and unload cargo vessels.")]
        TravellingCrane = 4,

        [System.ComponentModel.Description("A type of crane shaped like the letter 'A'.")]
        AFrame = 5,

        [System.ComponentModel.Description("A powerful travelling crane mounted on a movable gantry of large span.")]
        GoliathCrane = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDam : int
    {
        [System.ComponentModel.Description("A dam erected across a river to raise the level of the water. A fence of stakes set in a river or along the shore as a trap for fish. The word is now restricted to smaller works, the larger are called dams.")]
        Weir = 1,

        [System.ComponentModel.Description("A barrier to check or confine anything in motion; particularly one constructed to hold back water and raise its level to form a reservoir, or to prevent flooding.")]
        Dam = 2,

        [System.ComponentModel.Description("An opening dam across a channel which, when required, is closed to control flood waters.")]
        FloodBarrage = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDock : int
    {
        [System.ComponentModel.Description("A dock which is open to the sea and in which the water level is affected by tides.")]
        Tidal = 1,

        [System.ComponentModel.Description("A dock in which water can be maintained at any level by closing a gate when the water is at the desired level.")]
        WetDock = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDolphin : int
    {
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
    public enum categoryOfDumpingGround : int
    {
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
    public enum categoryOfFence : int
    {
        [System.ComponentModel.Description("A man-made barrier of relatively light structure used as an enclosure or boundary.")]
        Fence = 1,

        [System.ComponentModel.Description("A continuous growth of shrubbery planted as a fence, a boundary or a wind break.")]
        Hedge = 3,

        [System.ComponentModel.Description("A solid man-made barrier of generally heavy material used as an enclosure, boundary, or for protection.")]
        Wall = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfFerry : int
    {
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
    public enum categoryOfFishingFacility : int
    {
        [System.ComponentModel.Description("Poles or stakes placed in shallow water to outline a fishing ground or to catch fish.")]
        FishingStake = 1,

        [System.ComponentModel.Description("A structure (usually portable) for catching fish.")]
        FishTrap = 2,

        [System.ComponentModel.Description("A fence of stakes or stones set in a river or along the shore to trap fish.")]
        FishWeir = 3,

        [System.ComponentModel.Description("A net built at sea for catching tunny.")]
        TunnyNet = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfFogSignal : int
    {
        [System.ComponentModel.Description("A signal produced by the firing of explosive charges.")]
        Explosive = 1,

        [System.ComponentModel.Description("A diaphone uses compressed air and generally emits a powerful low-pitched sound, which often concludes with a brief sound of suddenly lowered pitch, termed the 'grunt'.")]
        Diaphone = 2,

        [System.ComponentModel.Description("A type of fog signal apparatus which produces sound by virtue of the passage of air through slots or holes in a revolving disk.")]
        Siren = 3,

        [System.ComponentModel.Description("A horn having a diaphragm oscillated by electricity.")]
        Nautophone = 4,

        [System.ComponentModel.Description("A reed uses compressed air and emits a weak, high pitched sound.")]
        Reed = 5,

        [System.ComponentModel.Description("A diaphragm horn which operates under the influence of compressed air or steam.")]
        Tyfon = 6,

        [System.ComponentModel.Description("A ringing sound with a short range.")]
        Bell = 7,

        [System.ComponentModel.Description("A distinctive sound made by a jet of air passing through an orifice. The apparatus may be operated automatically, by hand or by air being forced up a tube by waves acting on a buoy.")]
        Whistle = 8,

        [System.ComponentModel.Description("A sound produced by vibration of a disc when struck.")]
        Gong = 9,

        [System.ComponentModel.Description("A horn uses compressed air or electricity to vibrate a diaphragm and exists in a variety of types which differ greatly in their sound and power.")]
        Horn = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfFortifiedStructure : int
    {
        [System.ComponentModel.Description("A large fortified building or structure.")]
        Castle = 1,

        [System.ComponentModel.Description("A fortified enclosure, building, or position able to be defended against an enemy.")]
        Fort = 2,

        [System.ComponentModel.Description("A fortified structure on which artillery is mounted.")]
        Battery = 3,

        [System.ComponentModel.Description("A concrete structure strengthened to give protection against enemy fire, with apertures to allow defensive gunfire.")]
        Blockhouse = 4,

        [System.ComponentModel.Description("A small circular fort with very thick walls (for example Martello tower).")]
        FortifiedTower = 5,

        [System.ComponentModel.Description("An outwork or fieldwork usually square or polygonal and without flanking defences.")]
        Redoubt = 6,

        [System.ComponentModel.Description("A fortified pen to hold submarines.")]
        FortifiedSubmarineShelter = 8,

        [System.ComponentModel.Description("Anything serving as a bulwark or defence.")]
        Rampart = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfGate : int
    {
        [System.ComponentModel.Description("An opening gate used to control flood water.")]
        FloodBarrageGate = 2,

        [System.ComponentModel.Description("A steel structure used for closing the entrance of locks, wet and dry docks.")]
        Caisson = 3,

        [System.ComponentModel.Description("Pair of massive hinged doors at each end of a lock.")]
        LockGate = 4,

        [System.ComponentModel.Description("An opening gate in a dyke.")]
        DykeGate = 5,

        [System.ComponentModel.Description("A sliding gate or other contrivance for changing the level of a body of water by controlling the flow into or out of it.")]
        Sluice = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfHarbourFacility : int
    {
        [System.ComponentModel.Description("A terminal for roll-on roll-off ferries.")]
        RoroTerminal = 1,

        [System.ComponentModel.Description("A terminal for passenger and vehicle ferries.")]
        FerryTerminal = 3,

        [System.ComponentModel.Description("A harbour with facilities for fishing boats.")]
        FishingHarbour = 4,

        [System.ComponentModel.Description("A harbour facility for small boats, yachts, etc., where supplies, repairs, and various services are available.")]
        YachtHarbourMarina = 5,

        [System.ComponentModel.Description("A centre of operations for naval vessels.")]
        NavalBase = 6,

        [System.ComponentModel.Description("A terminal for the bulk handling of liquid cargoes.")]
        TankerTerminal = 7,

        [System.ComponentModel.Description("A terminal for the loading and unloading of passengers.")]
        PassengerTerminal = 8,

        [System.ComponentModel.Description("A place where ships are built or repaired.")]
        Shipyard = 9,

        [System.ComponentModel.Description("A terminal with facilities to load/unload or store shipping containers.")]
        ContainerTerminal = 10,

        [System.ComponentModel.Description("A terminal for the handling of bulk materials such as iron ore, coal, etc.")]
        BulkTerminal = 11,

        [System.ComponentModel.Description("A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.")]
        ShipLift = 12,

        [System.ComponentModel.Description("A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.")]
        StraddleCarrier = 13,

        [System.ComponentModel.Description("A harbour within which the floating equipment (dredges, tugs ...) of harbour services are stationed.")]
        ServiceHarbour = 14,

        [System.ComponentModel.Description("The services of a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area, are available.")]
        PilotageService = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfHulk : int
    {
        [System.ComponentModel.Description("A permanently moored floating structure (for example: an old ship) that is used as a restaurant.")]
        FloatingRestaurant = 1,

        [System.ComponentModel.Description("A ship of historical interest permanently moored as a tourist attraction.")]
        HistoricShip = 2,

        [System.ComponentModel.Description("A permanently moored floating structure (for example: an old ship) that is used as a museum.")]
        FloatingMuseum = 3,

        [System.ComponentModel.Description("A permanently moored floating structure (for example: an old ship) that is used for accommodation.")]
        FloatingAccommodation = 4,

        [System.ComponentModel.Description("A permanently moored floating structure, often constructed from old ships, used as a breakwater.")]
        FloatingBreakwater = 5,

        [System.ComponentModel.Description("A permanently moored floating structure, such as an old ship, used as a casino boat.")]
        Casino = 6,

        [System.ComponentModel.Description("A permanently moored floating structure, often constructed from old ships, used for training purposes.")]
        TrainingVessel = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfIce : int
    {
        [System.ComponentModel.Description("Sea ice which remains fast, generally in the position where originally formed, and which may attain a considerable thickness. It is found along coasts, where it is attached to the shore, or over shoals, where it may be held in position by islands, grounded icebergs or grounded polar ice.")]
        FastIce = 1,

        [System.ComponentModel.Description("A mass of snow and ice continuously moving from higher to lower ground or, if afloat, continuously spreading.")]
        Glacier = 5,

        [System.ComponentModel.Description("Sea ice that is more than one year old (in contrast to winter ice). The WMO code defines polar ice as any sea ice more than one year old and more than 3 metres thick.")]
        PolarIce = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfInstallationBuoy : int
    {
        [System.ComponentModel.Description("Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
        CatenaryAnchorLegMooring = 1,

        [System.ComponentModel.Description("A large mooring buoy used by tankers to load and unload in port approaches or in offshore oil and gas fields.")]
        SingleBuoyMooring = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLandRegion : int
    {
        [System.ComponentModel.Description("A type of bog, especially a low-lying area, wholly or partly covered with water and dominated by grass-like plants, grasses, sedges and reeds.")]
        Fen = 1,

        [System.ComponentModel.Description("An area of wet, often spongy ground that is subject to frequent flooding or tidal inundations, but not considered to be continually under water. It is characterized by the growth of non woody plants and by the lack of trees.")]
        Marsh = 2,

        [System.ComponentModel.Description("Wet spongy ground consisting of decaying vegetation, which retains stagnant water, too soft to bear the weight of any heavy body.")]
        Bog = 3,

        [System.ComponentModel.Description("A tract of wasteland peat bog, usually covered by a low scrubby growth, but may have scattered small open water holes.")]
        Heathland = 4,

        [System.ComponentModel.Description("A series of connected and aligned mountains or mountain ridges.")]
        MountainRange = 5,

        [System.ComponentModel.Description("Low and relatively level land at a lower elevation than adjoining areas.")]
        Lowlands = 6,

        [System.ComponentModel.Description("A relatively narrow, deep depression with steep sides, the bottom of which generally has a continuous slope.")]
        CanyonLands = 7,

        [System.ComponentModel.Description("A piece of land set aside for crops which are periodically flooded (for example rice paddy).")]
        PaddyField = 8,

        [System.ComponentModel.Description("Of or pertaining to the science or practice of cultivating the soil and rearing animals.")]
        AgriculturalLand = 9,

        [System.ComponentModel.Description("An open grassy plain with few or no trees in a tropical or subtropical region; a tract covered mainly by grasses that have little or no woody tissue.")]
        SavannaGrassland = 10,

        [System.ComponentModel.Description("A piece of ground kept for ornament and/or recreation or maintained in its natural state as a public property or area.")]
        Parkland = 11,

        [System.ComponentModel.Description("An area of spongy land saturated with water. It may have a shallow covering of water, usually with a considerable amount of vegetation appearing above the surface.")]
        Swamp = 12,

        [System.ComponentModel.Description("The sliding down of a mass of land on a mountain or cliff-side; land which has so fallen.")]
        Landslide = 13,

        [System.ComponentModel.Description("The substance that results from the cooling of molten rock.")]
        LavaFlow = 14,

        [System.ComponentModel.Description("Shallow pools of brackish water used for the natural evaporation of sea water to obtain salt.")]
        SaltPan = 15,

        [System.ComponentModel.Description("Any accumulation of loose material deposited by a glacier.")]
        Moraine = 16,

        [System.ComponentModel.Description("Bowl-shaped cavity, at the summit or on the side of a volcano.")]
        Crater = 17,

        [System.ComponentModel.Description("A natural subterranean chamber or series of chambers open to the earth's surface.")]
        Cave = 18,

        [System.ComponentModel.Description("Any high tower or spire-shaped pillar of rock, alone or cresting a summit.")]
        RockColumnOrPinnacle = 19,

        [System.ComponentModel.Description("A small insular feature usually with scant vegetation; usually of sand or coral. Often applied to smaller coral shoals.")]
        Cay = 20,

        [System.ComponentModel.Description("A watercourse that is permanently dry or dry except for the rainy season.")]
        Wadi = 21,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLandmark : int
    {
        [System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
        Cairn = 1,

        [System.ComponentModel.Description("A site and associated structures devoted to the burial of the dead.")]
        Cemetery = 2,

        [System.ComponentModel.Description("A vertical structure containing a passage or flue for discharging smoke and gases of combustion.")]
        Chimney = 3,

        [System.ComponentModel.Description("A parabolic aerial for the receipt and transmission of high frequency radio signals.")]
        DishAerial = 4,

        [System.ComponentModel.Description("A staff or pole on which flags are raised.")]
        Flagstaff = 5,

        [System.ComponentModel.Description("A tall structure used for burning-off waste oil or gas.")]
        FlareStack = 6,

        [System.ComponentModel.Description("A relatively tall structure usually held vertical by guy lines.")]
        Mast = 7,

        [System.ComponentModel.Description("A tapered fabric sleeve mounted so as to catch and swing with the wind, thus indicating the wind direction.")]
        Windsock = 8,

        [System.ComponentModel.Description("A structure erected and/or maintained as a memorial to a person and/or event.")]
        Monument = 9,

        [System.ComponentModel.Description("A cylindrical or slightly tapering body of considerably greater length than diameter erected vertically.")]
        ColumnPillar = 10,

        [System.ComponentModel.Description("A slab of metal, usually ornamented, erected as a memorial to a person or event.")]
        MemorialPlaque = 11,

        [System.ComponentModel.Description("A tapering shaft usually of stone or concrete, square or rectangular in section, with a pyramidal apex.")]
        Obelisk = 12,

        [System.ComponentModel.Description("A representation of a living being, sculptured, moulded, or cast in a variety of materials (for example: marble, metal, or plaster).")]
        Statue = 13,

        [System.ComponentModel.Description("A monument, or other structure in form of a cross.")]
        Cross = 14,

        [System.ComponentModel.Description("A landmark comprising a hemispherical or spheroidal shaped structure.")]
        Dome = 15,

        [System.ComponentModel.Description("A device used for directing a radar beam through a search pattern.")]
        RadarScanner = 16,

        [System.ComponentModel.Description("A relatively tall, narrow structure that may either stand alone or may form part of another structure.")]
        Tower = 17,

        [System.ComponentModel.Description("A system of vanes attached to a tower and driven by wind (excluding wind turbines).")]
        Windmill = 18,

        [System.ComponentModel.Description("A tall conical or pyramid-shaped structure often built on the roof or tower of a building, especially a church or mosque.")]
        SpireMinaret = 20,

        [System.ComponentModel.Description("An isolated rocky formation or a single large stone.")]
        LargeRockOrBoulderOnLand = 21,

        [System.ComponentModel.Description("A recoverable point on the earth, whose geographic position has been determined by angular methods with geodetic instruments. A triangulation point is a selected point, which has been marked with a station mark, or it is a conspicuous natural or artificial feature.")]
        TriangulationMark = 22,

        [System.ComponentModel.Description("A marker identifying the location of a surveyed boundary line.")]
        BoundaryMark = 23,

        [System.ComponentModel.Description("Wheels with passenger cars mounted external to the rim and independently rotated by electric motors.")]
        ObservationWheel = 24,

        [System.ComponentModel.Description("A form of decorative gateway or portal, consisting of two upright wooden posts connected at the top by two horizontal crosspieces, commonly found at the entrance to Shinto temples.")]
        Torii = 25,

        [System.ComponentModel.Description("A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.")]
        Bridge = 26,

        [System.ComponentModel.Description("A barrier to check or confine anything in motion; particularly one constructed to hold back water and raise its level to form a reservoir, or to prevent flooding.")]
        Dam = 27,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLateralMark : int
    {
        [System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
        PortHandLateralMark = 1,

        [System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
        StarboardHandLateralMark = 2,

        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
        PreferredChannelToStarboardLateralMark = 3,

        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
        PreferredChannelToPortLateralMark = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfLight : int
    {
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
    public enum categoryOfMarineFarmCulture : int
    {
        [System.ComponentModel.Description("Hard shelled animals, for example crabs or lobsters.")]
        Crustaceans = 1,

        [System.ComponentModel.Description("A two-part hinged external shell covering that contains a soft-bodied invertebrate.")]
        EdibleBivalveMolluscs = 2,

        [System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
        Fish = 3,

        [System.ComponentModel.Description("The general name for marine plants of the Algae class which grow in long narrow ribbons.")]
        Seaweed = 4,

        [System.ComponentModel.Description("An area where pearls are artificially cultivated.")]
        PearlCultureFarm = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfMilitaryPracticeArea : int
    {
        [System.ComponentModel.Description("An area within which exercises are carried out with torpedoes.")]
        TorpedoExerciseArea = 2,

        [System.ComponentModel.Description("An area within which submarine exercises are carried out.")]
        SubmarineExerciseArea = 3,

        [System.ComponentModel.Description("Areas for bombing and missile exercises.")]
        FiringDangerArea = 4,

        [System.ComponentModel.Description("An area within which mine laying exercises are carried out.")]
        MineLayingPracticeArea = 5,

        [System.ComponentModel.Description("An area for shooting pistols, rifles and machine guns etc. at a target.")]
        SmallArmsFiringRange = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfMooringArea : int
    {
        [System.ComponentModel.Description("An area in which yachts and small boats moor.")]
        SmallCraftMooringArea = 1,

        [System.ComponentModel.Description("An area set aside for the mooring of visiting vessels.")]
        MooringAreaForVisitors = 2,

        [System.ComponentModel.Description("An area set aside for the mooring of tankers.")]
        MooringAreaForTankers = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfNavigationLine : int
    {
        [System.ComponentModel.Description("A straight line that marks the boundary between a safe and a dangerous area or that passes clear of a navigational danger.")]
        ClearingLine = 1,

        [System.ComponentModel.Description("A line passing through one or more fixed marks.")]
        TransitLine = 2,

        [System.ComponentModel.Description("A line passing through one or more clearly defined objects, along the path of which a vessel can approach safely up to a certain distance off.")]
        LeadingLineBearingARecommendedTrack = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfObstruction : int
    {
        [System.ComponentModel.Description("A tree, branch or broken pile embedded in the ocean floor, river or lake bottom and not visible on the surface, forming thereby a hazard to vessels.")]
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

        [System.ComponentModel.Description("A submerged device, not being a ship, together with its appurtenant equipment, deployed at sea essentially for the purpose of collecting, storing or transmitting samples or data relating to the marine environment.")]
        SubsurfaceOceanDataAcquisitionSystem = 13,

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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfOffshorePlatform : int
    {
        [System.ComponentModel.Description("A temporary mobile structure, either fixed or floating, used in the exploration stages of oil and gas fields.")]
        OilRig = 1,

        [System.ComponentModel.Description("A term used to indicate a permanent offshore structure equipped to control the flow of oil or gas. It does not include entirely submarine structures.")]
        ProductionPlatform = 2,

        [System.ComponentModel.Description("A platform from which one's surroundings or events can be observed, noted or recorded such as for scientific study.")]
        ObservationResearchPlatform = 3,

        [System.ComponentModel.Description("A metal lattice tower, buoyant at one end and attached at the other by a universal joint to a concrete filled base on the seabed. The platform may be fitted with a helicopter platform, emergency accommodation and hawser/hose retrieval.")]
        ArticulatedLoadingPlatform = 4,

        [System.ComponentModel.Description("A rigid frame or tube with a buoyancy device at its upper end, secured at its lower end to a universal joint on a large steel or concrete base resting on the seabed, and at its upper end to a mooring buoy by a chain or wire.")]
        SingleAnchorLegMooring = 5,

        [System.ComponentModel.Description("A platform secured to the seabed and surmounted by a turntable to which ships moor.")]
        MooringTower = 6,

        [System.ComponentModel.Description("A man-made structure usually built for the exploration or exploitation of marine resources, marine scientific research, tidal observations, etc.")]
        ArtificialIsland = 7,

        [System.ComponentModel.Description("An offshore facility consisting of a moored tanker/barge by which the product is extracted, stored and exported.")]
        FloatingProductionStorageAndOffLoadingVessel = 8,

        [System.ComponentModel.Description("A platform used primarily for eating, sleeping and recreation purposes.")]
        AccommodationPlatform = 9,

        [System.ComponentModel.Description("A floating structure with control room, power and storage facilities, attached to the seabed by a flexible pipeline and cables.")]
        NavigationCommunicationAndControlBuoy = 10,

        [System.ComponentModel.Description("A floating structure, anchored to the seabed, for storing oil.")]
        FloatingOilTank = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfOffshoreProductionArea : int
    {
        [System.ComponentModel.Description("A collection of wind turbines that are collocated and are organized as a single power generation unit.")]
        WindFarm = 1,

        [System.ComponentModel.Description("A collection of collocated devices which harness wave energy and are organized as a single power generation unit.")]
        WaveFarm = 2,

        [System.ComponentModel.Description("A collection of collocated devices which harness current (for example tidal) energy and are organized as a single power generation unit.")]
        CurrentFarm = 3,

        [System.ComponentModel.Description("A collection of collocated large-capacity tanks in which petroleum, natural gas, or liquid petrochemicals are stored.")]
        TankFarm = 4,

        [System.ComponentModel.Description("An area in which materials forming, or under, the seabed are removed.")]
        SeabedMaterialExtractionArea = 5,

        [System.ComponentModel.Description("A large-scale photovoltaic system (PV system) designed for the supply of merchant power into the electricity grid. They are differentiated from most building-mounted and other decentralised solar power applications because they supply power at the utility level, rather than to a local user or users. The generic expression utility-scale solar is sometimes used to describe this type of project.")]
        SolarFarm = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfOilBarrier : int
    {
        [System.ComponentModel.Description("A pipe with holes from which air blows. When the air bubbles reach the surface they form a barrier which prevents the spread of oil.")]
        OilRetentionHighPressurePipe = 1,

        [System.ComponentModel.Description("A floating tube shaped structure, with a curtain (2 metre) hanging under it, below the surface, which prevents the spread of oil.")]
        FloatingOilBarrier = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfOpeningBridge : int
    {
        [System.ComponentModel.Description("A movable bridge (or span thereof) which rotates in a horizontal plane about a vertical pivot to allow the passage of vessels.")]
        SwingBridge = 3,

        [System.ComponentModel.Description("A movable bridge (or span thereof) which is capable of being lifted vertically to allow vessels to pass beneath.")]
        LiftingBridge = 4,

        [System.ComponentModel.Description("A counterpoise bridge rotated in a vertical plane about an axis at one or both ends.")]
        BasculeBridge = 5,

        [System.ComponentModel.Description("A general name for bridges of which part or the entire span of the bridge may be raised or drawn aside to allow ships to pass through.")]
        Drawbridge = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPile : int
    {
        [System.ComponentModel.Description("An elongated wood or metal pole embedded in the seabed to serve as a marker or support.")]
        Stake = 1,

        [System.ComponentModel.Description("A vertical piece of timber, metal or concrete forced into the earth or seabed.")]
        Post = 3,

        [System.ComponentModel.Description("A single structure comprising 3 or more piles held together (sections of heavy timber, steel or concrete), and forced into the earth or seabed.")]
        Tripodal = 4,

        [System.ComponentModel.Description("A number of piles, usually in a straight line, and usually connected or bolted together.")]
        Piling = 5,

        [System.ComponentModel.Description("A number of piles, usually in a straight line, but not connected by structural members.")]
        AreaOfPiles = 6,

        [System.ComponentModel.Description("A vertical hollow cylinder of metal, wood, or other material forced into the earth or seabed.")]
        Pipe = 7,

        [System.ComponentModel.Description("A post where to which something (such as a craft) can be moored.")]
        MooringPost = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPilotBoardingPlace : int
    {
        [System.ComponentModel.Description("Pilot boards from a cruising vessel.")]
        BoardingByPilotCruisingVessel = 1,

        [System.ComponentModel.Description("Pilot boards by helicopter which comes out from the shore.")]
        BoardingByHelicopter = 2,

        [System.ComponentModel.Description("Pilot embarks from a vessel or disembarks to a vessel which comes out from the shore on request.")]
        PilotComesOutFromShore = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPipelinePipe : int
    {
        [System.ComponentModel.Description("A pipe (generally a sewer or drainage pipe) discharging into the sea or a river.")]
        OutfallPipe = 2,

        [System.ComponentModel.Description("A pipe taking water from a river or other body of water, to drive a mill or supply a canal, waterworks, etc.")]
        IntakePipe = 3,

        [System.ComponentModel.Description("A pipe in a sewage system for carrying water or sewage to a disposal area.")]
        Sewer = 4,

        [System.ComponentModel.Description("A submerged pipe from which warm water bubbles, preventing the surrounding water from freezing.")]
        BubblerSystem = 5,

        [System.ComponentModel.Description("A pipe used for transport (supply) of gas or liquid product.")]
        SupplyPipe = 6,

        [System.ComponentModel.Description("A high pressure sub-surface pipeline (usually on the seafloor) with holes emitting a curtain of air bubbles. Its uses include: the prevention of acoustic transmission through the water; preventing the spread of surface debris or floating liquids; controlling the movement of fish.")]
        BubbleCurtain = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPreference : int
    {
        [System.ComponentModel.Description("The preferred first choice used in normal conditions.")]
        Primary = 1,

        [System.ComponentModel.Description("The preferred choice in extraordinary conditions.")]
        Alternate = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfProductionArea : int
    {
        [System.ComponentModel.Description("An open-air excavation for the extraction of stone intended principally for use in construction.")]
        Quarry = 1,

        [System.ComponentModel.Description("An excavation made in the terrain for the purpose of extracting and/or exploiting natural resources.")]
        Mine = 2,

        [System.ComponentModel.Description("A reserve stock of material, equipment or other supplies.")]
        Stockpile = 3,

        [System.ComponentModel.Description("A facility including one or more buildings and equipment used for power generation.")]
        PowerStationArea = 4,

        [System.ComponentModel.Description("A facility where petroleum and/or petroleum products are refined.")]
        RefineryArea = 5,

        [System.ComponentModel.Description("An open tract for the storage of wooden lumber and timbers.")]
        TimberYard = 6,

        [System.ComponentModel.Description("A group of buildings where goods are manufactured.")]
        FactoryArea = 7,

        [System.ComponentModel.Description("A collection of collocated large-capacity tanks in which petroleum, natural gas, or liquid petrochemicals are stored.")]
        TankFarm = 8,

        [System.ComponentModel.Description("A collection of wind turbines that are collocated and are organized as a single power generation unit.")]
        WindFarm = 9,

        [System.ComponentModel.Description("Hill of refuse from a mine, industrial plant etc. on land.")]
        SlagHeapSpoilHeap = 10,

        [System.ComponentModel.Description("A plant where production takes place.")]
        ProductionPlant = 11,

        [System.ComponentModel.Description("A large-scale photovoltaic system (PV system) designed for the supply of merchant power into the electricity grid. They are differentiated from most building-mounted and other decentralised solar power applications because they supply power at the utility level, rather than to a local user or users. The generic expression utility-scale solar is sometimes used to describe this type of project.")]
        SolarFarm = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPylon : int
    {
        [System.ComponentModel.Description("A pylon or pole that supports one or more power lines.")]
        PowerTransmissionPylonPole = 1,

        [System.ComponentModel.Description("A pylon or pole that supports one or more communication lines.")]
        TelephoneTelegraphPylonPole = 2,

        [System.ComponentModel.Description("A tower or pylon supporting steel cables which convey cars, buckets, or other suspended carrier units.")]
        AerialCablewayPylon = 3,

        [System.ComponentModel.Description("A tower and/or pylon from which the deck of a bridge is suspended.")]
        BridgePylonTower = 4,

        [System.ComponentModel.Description("A pillar or abutment that supports a bridge span.")]
        BridgePier = 5,

        [System.ComponentModel.Description("A tower or pylon supporting a suspended pipeline or pipelines.")]
        PipelinePylon = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRadarStation : int
    {
        [System.ComponentModel.Description("A radar station established for traffic surveillance.")]
        RadarSurveillanceStation = 1,

        [System.ComponentModel.Description("A shore-based station which the mariner can contact by radio to obtain a position.")]
        CoastRadarStation = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRadarTransponderBeacon : int
    {
        [System.ComponentModel.Description("A radar marker beacon which continuously transmits a signal appearing as a radial line on a radar screen, the line indicating the direction of the beacon. Ramarks are intended primarily for marine use. The name 'ramark' is derived from the words radar marker.")]
        RamarkRadarBeaconTransmittingContinuously = 1,

        [System.ComponentModel.Description("A radar beacon which returns a coded signal which provides identification of the beacon, as well as range and bearing. The range and bearing are indicated by the location of the first character received on the radar screen. The name 'racon' is derived from the words radar beacon.")]
        RaconRadarTransponderBeacon = 2,

        [System.ComponentModel.Description("A radar beacon that may be used (in conjunction with at least one other radar beacon) to indicate a leading line.")]
        LeadingRaconRadarTransponderBeacon = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRadioStation : int
    {
        [System.ComponentModel.Description("A radio station intended to determine only the direction of other stations by means of transmission from the latter.")]
        RadioDirectionFindingStation = 5,

        [System.ComponentModel.Description("Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.")]
        DifferentialGnss = 10,

        [System.ComponentModel.Description("An electronic position fixing system used mainly by aircraft.")]
        Toran = 11,

        [System.ComponentModel.Description("A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
        Chaika = 14,

        [System.ComponentModel.Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
        RadioTelephoneStation = 19,

        [System.ComponentModel.Description("An AIS shore station for use by competent authorities to provide AIS service, manage the data link and enable effective ship to shore / shore to ship transmission of information.")]
        AisBaseStation = 20,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRescueStation : int
    {
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
    public enum categoryOfRestrictedArea : int
    {
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRoad : int
    {
        [System.ComponentModel.Description("A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.")]
        Motorway = 1,

        [System.ComponentModel.Description("A hard surfaced (metalled) road; a main through route.")]
        MajorRoad = 2,

        [System.ComponentModel.Description("A secondary road for local traffic.")]
        MinorRoad = 3,

        [System.ComponentModel.Description("Track - a rough path or way formed by use. Path - a way or track laid down for walking or made by continual treading.")]
        TrackPath = 4,

        [System.ComponentModel.Description("A main road, in an urban area, for through traffic.")]
        MajorStreet = 5,

        [System.ComponentModel.Description("A secondary road, in an urban area, for local traffic.")]
        MinorStreet = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSchedule : int
    {
        [System.ComponentModel.Description("The service, office, is open, fully manned, and operating normally, or the area is accessible as usual.")]
        NormalOperation = 1,

        [System.ComponentModel.Description("The service, office, or area is closed.")]
        Closure = 2,

        [System.ComponentModel.Description("The service is available but not manned.")]
        UnmannedOperation = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSeaArea : int
    {
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

        [System.ComponentModel.Description("A distinct elevation generally of irregular shape, less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
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

        [System.ComponentModel.Description("The line along which there is a marked increase in slope at the seaward margin of a shelf.")]
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
    public enum categoryOfShorelineConstruction : int
    {
        [System.ComponentModel.Description("A structure protecting a shore area, harbour, anchorage, or basin from waves.")]
        Breakwater = 1,

        [System.ComponentModel.Description("A low artificial wall-like structure of durable material extending from the land to seaward for a particular purpose, such as to protect the coast or to force a current to scour a channel.")]
        Groyne = 2,

        [System.ComponentModel.Description("A form of breakwater alongside which vessels may lie on the sheltered side only; in some cases it may lie entirely within an artificial harbour, permitting vessels to lie along both sides.")]
        Mole = 3,

        [System.ComponentModel.Description("A long, narrow structure extending into the water to afford a berthing place for vessels, to serve as a promenade, etc.")]
        PierJetty = 4,

        [System.ComponentModel.Description("A pier built only for recreational purposes.")]
        PromenadePier = 5,

        [System.ComponentModel.Description("A structure serving as a berthing place for vessels.")]
        Wharf = 6,

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

        [System.ComponentModel.Description("A sloping structure which may include rails that can either be used, as a landing place, at variable water levels, for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel.")]
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

        [System.ComponentModel.Description("A section of wall designated for tying-up vessels awaiting transit. Bollards and mooring devices are available for both large and small ships.")]
        TieUpWall = 23,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSignalStationTraffic : int
    {
        [System.ComponentModel.Description("A signal station for the control of vessels within a port.")]
        PortControl = 1,

        [System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a port.")]
        PortEntryAndDeparture = 2,

        [System.ComponentModel.Description("A signal station displaying International Port Traffic signals.")]
        InternationalPortTraffic = 3,

        [System.ComponentModel.Description("A signal station for the control of vessels when berthing.")]
        BerthingSignalStation = 4,

        [System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a dock.")]
        Dock = 5,

        [System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a lock.")]
        Lock = 6,

        [System.ComponentModel.Description("A signal station for the control of vessels wishing to pass through a flood control barrage.")]
        FloodBarrageStation = 7,

        [System.ComponentModel.Description("A signal station for the control of vessels wishing to pass under a bridge.")]
        BridgePassage = 8,

        [System.ComponentModel.Description("A signal station indicating when dredging is in progress.")]
        Dredging = 9,

        [System.ComponentModel.Description("Visual signal lights placed in a waterway to indicate to shipping the movements authorized at the time at which they are shown.")]
        TrafficControlLight = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSignalStationWarning : int
    {
        [System.ComponentModel.Description("A signal or message warning of the presence of a danger to navigation.")]
        Danger = 1,

        [System.ComponentModel.Description("A signal or message warning of the presence of a maritime obstruction.")]
        MaritimeObstruction = 2,

        [System.ComponentModel.Description("A signal or message warning of the presence of a cable.")]
        Cable = 3,

        [System.ComponentModel.Description("A signal or message warning of activity in a military practice area.")]
        MilitaryPractice = 4,

        [System.ComponentModel.Description("A station that may receive or transmit distress signals.")]
        Distress = 5,

        [System.ComponentModel.Description("A visual signal displayed to indicate a weather forecast.")]
        Weather = 6,

        [System.ComponentModel.Description("A signal or message conveying information about storm conditions.")]
        Storm = 7,

        [System.ComponentModel.Description("A signal or message conveying information about ice conditions.")]
        IceWarning = 8,

        [System.ComponentModel.Description("An accurate signal marking a specified time or time interval. It is used primarily for determining errors of timepieces. Such signals are usually sent from an observatory by radio, but visual signals are used at some ports.")]
        Time = 9,

        [System.ComponentModel.Description("A signal or message conveying information on tidal conditions in the area in question.")]
        Tide = 10,

        [System.ComponentModel.Description("A signal or message conveying information on condition of tidal currents in the area in question.")]
        TidalStream = 11,

        [System.ComponentModel.Description("A device for measuring the height of tide. A graduated staff in a sheltered area where visual observations can be made; or it may consist of an elaborate recording instrument making a continuous graphic record of tide height against time. Such an instrument is usually actuated by a float in a pipe communicating with the sea through a small hole which filters out shorter waves.")]
        TideGauge = 12,

        [System.ComponentModel.Description("A visual scale which directly shows the height of the water above chart datum or a local datum.")]
        TideScale = 13,

        [System.ComponentModel.Description("A signal or message warning of diving activity.")]
        Diving = 14,

        [System.ComponentModel.Description("A device for measuring and conveying information about the water level (non-tidal) in the area in question.")]
        WaterLevelGauge = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSiloTank : int
    {
        [System.ComponentModel.Description("A large storage structure used for storing loose materials.")]
        SiloInGeneral = 1,

        [System.ComponentModel.Description("A fixed structure for storing liquids.")]
        TankInGeneral = 2,

        [System.ComponentModel.Description("A storage building for grain. Usually a tall frame, metal or concrete structure with an especially compartmented interior.")]
        GrainElevator = 3,

        [System.ComponentModel.Description("A tower supporting an elevated storage tank of water.")]
        WaterTower = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSlope : int
    {
        [System.ComponentModel.Description("An excavation through high ground for a road, canal, etc.")]
        Cutting = 1,

        [System.ComponentModel.Description("A man-made raised long mound of earth or other material.")]
        Embankment = 2,

        [System.ComponentModel.Description("A mound, ridge or hill of drifted material on the sea coast or in a desert.")]
        Dune = 3,

        [System.ComponentModel.Description("A small isolated elevation, smaller than a mountain.")]
        Hill = 4,

        [System.ComponentModel.Description("A dome-shaped hill formed in a permafrost area when the hydrostatic pressure of freezing ground water causes the upheaval of a layer of frozen ground.")]
        Pingo = 5,

        [System.ComponentModel.Description("Land rising abruptly for a considerable distance above the water or surrounding land.")]
        Cliff = 6,

        [System.ComponentModel.Description("A mass of detritus, forming a precipitous, strong slope upon a mountain-side. Also the material composing such a slope.")]
        Scree = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSmallCraftFacility : int
    {
        [System.ComponentModel.Description("A berth set aside for the use of visiting vessels.")]
        VisitorsBerth = 1,

        [System.ComponentModel.Description("A club for mariners generally associated with other small craft facilities.")]
        NauticalClub = 2,

        [System.ComponentModel.Description("A hoist for lifting boats out of the water.")]
        BoatHoist = 3,

        [System.ComponentModel.Description("A place where sails are made or may be taken for repair.")]
        Sailmaker = 4,

        [System.ComponentModel.Description("A place on shore where boats may be built, stored and repaired.")]
        Boatyard = 5,

        [System.ComponentModel.Description("A public house providing food, drink and accommodation.")]
        PublicInn = 6,

        [System.ComponentModel.Description("A commercial establishment serving food.")]
        Restaurant = 7,

        [System.ComponentModel.Description("A dealer in ships' supplies.")]
        Chandler = 8,

        [System.ComponentModel.Description("A place where food and other such supplies are available.")]
        Provisions = 9,

        [System.ComponentModel.Description("A place where a doctor is available to provide medical attention.")]
        Doctor = 10,

        [System.ComponentModel.Description("A place where medical drugs are dispensed.")]
        Pharmacy = 11,

        [System.ComponentModel.Description("A place where fresh water is available.")]
        WaterTap = 12,

        [System.ComponentModel.Description("A place where fuel is available.")]
        FuelStation = 13,

        [System.ComponentModel.Description("A place where a connection to an electrical supply is available.")]
        ElectricityOutlet = 14,

        [System.ComponentModel.Description("A place where bottled gas is available.")]
        BottleGas = 15,

        [System.ComponentModel.Description("A place where showers are available.")]
        Showers = 16,

        [System.ComponentModel.Description("A place where there are facilities for washing clothes.")]
        Launderette = 17,

        [System.ComponentModel.Description("A place where toilets are available for public use.")]
        PublicToilets = 18,

        [System.ComponentModel.Description("A place where mail may be posted.")]
        PostBox = 19,

        [System.ComponentModel.Description("A place where a telephone is available for public use.")]
        PublicTelephone = 20,

        [System.ComponentModel.Description("A place where refuse may be dumped.")]
        RefuseBin = 21,

        [System.ComponentModel.Description("A place where cars may be parked.")]
        CarPark = 22,

        [System.ComponentModel.Description("A place on shore where boats and/or trailers may be parked.")]
        ParkingForBoatsAndTrailers = 23,

        [System.ComponentModel.Description("A place where caravans may be parked or where caravan accommodation is provided.")]
        CaravanSite = 24,

        [System.ComponentModel.Description("A place where visitors may pitch tents and camp.")]
        CampingSite = 25,

        [System.ComponentModel.Description("A place where sewage may be pumped off a vessel.")]
        SewagePumpOutStation = 26,

        [System.ComponentModel.Description("A place where a telephone is available for emergency use only.")]
        EmergencyTelephone = 27,

        [System.ComponentModel.Description("A place where boats may be landed or launched.")]
        LandingLaunchingPlaceForBoats = 28,

        [System.ComponentModel.Description("A place where vessels may berth for the purpose of careening.")]
        ScrubbingBerth = 30,

        [System.ComponentModel.Description("A place where people may go to eat a picnic.")]
        PicnicArea = 31,

        [System.ComponentModel.Description("A place where mechanical repairs can be undertaken to engines or other vessel equipment.")]
        MechanicsWorkshop = 32,

        [System.ComponentModel.Description("A place where a vessel is patrolled by a security service or stored in a secure lockup.")]
        GuardAndOrSecurityService = 33,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSpecialPurposeMark : int
    {
        [System.ComponentModel.Description("A mark used to indicate a firing danger area, usually at sea.")]
        FiringDangerMark = 1,

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

        [System.ComponentModel.Description("A mark used to indicate a seaplane anchorage.")]
        SeaplaneAnchorageMark = 11,

        [System.ComponentModel.Description("A mark used to indicate a recreation zone.")]
        RecreationZoneMark = 12,

        [System.ComponentModel.Description("A mark indicating a mooring or moorings.")]
        MooringMark = 14,

        [System.ComponentModel.Description("A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
        Lanby = 15,

        [System.ComponentModel.Description("Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
        LeadingMark = 16,

        [System.ComponentModel.Description("A mark forming part of a transit indicating one end of a measured distance.")]
        MeasuredDistanceMark = 17,

        [System.ComponentModel.Description("A notice board or sign indicating information to the mariner.")]
        NoticeMark = 18,

        [System.ComponentModel.Description("A mark indicating a Traffic Separation Scheme.")]
        TssMark = 19,

        [System.ComponentModel.Description("A mark indicating an anchoring prohibited area.")]
        AnchoringProhibitedMark = 20,

        [System.ComponentModel.Description("A mark indicating that berthing is prohibited.")]
        BerthingProhibitedMark = 21,

        [System.ComponentModel.Description("A mark indicating that overtaking is prohibited.")]
        OvertakingProhibitedMark = 22,

        [System.ComponentModel.Description("A mark indicating a one-way route.")]
        TwoWayTrafficProhibitedMark = 23,

        [System.ComponentModel.Description("A mark indicating that vessels must not generate excessive wake.")]
        ReducedWakeMark = 24,

        [System.ComponentModel.Description("A mark indicating that a speed limit applies.")]
        SpeedLimitMark = 25,

        [System.ComponentModel.Description("A mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
        StopMark = 26,

        [System.ComponentModel.Description("A mark indicating that special caution must be exercised in the vicinity of the mark.")]
        GeneralWarningMark = 27,

        [System.ComponentModel.Description("A mark indicating that a ship should sound its siren or horn.")]
        SoundShipSSirenMark = 28,

        [System.ComponentModel.Description("A mark indicating the minimum vertical space available for passage.")]
        RestrictedVerticalClearanceMark = 29,

        [System.ComponentModel.Description("A mark indicating the maximum draught of vessel permitted.")]
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

        [System.ComponentModel.Description("A mark whose detailed characteristics are unknown.")]
        MarkWithUnknownPurpose = 52,

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
    public enum categoryOfTemporalVariation : int
    {
        [System.ComponentModel.Description("Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.")]
        ExtremeEvent = 1,

        [System.ComponentModel.Description("Continuous or frequent change (for example river siltation, sand waves, seasonal storms, icebergs, etc) that is likely to result in new significant shoaling.")]
        LikelyToChangeAndSignificantShoalingExpected = 2,

        [System.ComponentModel.Description("Continuous or frequent change (for example sand wave shift, seasonal storms, icebergs, etc) that is not likely to result in new significant shoaling.")]
        LikelyToChangeButSignificantShoalingNotExpected = 3,

        [System.ComponentModel.Description("Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).")]
        LikelyToChange = 4,

        [System.ComponentModel.Description("Significant change to the seafloor is not expected.")]
        UnlikelyToChange = 5,

        [System.ComponentModel.Description("Not having been assessed.")]
        Unassessed = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfStructure : int
    {
        [System.ComponentModel.Description("A building or shed, usually built partly over water, for sheltering a boat or boats.")]
        Boathouse = 1,

        [System.ComponentModel.Description("A covered or partially covered terminal for the handling of bulk materials such as iron ore, coal, etc.")]
        CoveredBulkTerminal = 2,

        [System.ComponentModel.Description("A covered or partially covered structure serving as a berthing place for vessels.")]
        CoveredWharf = 3,

        [System.ComponentModel.Description("A covered or partially covered terminal within which the floating equipment (dredges, tugs …) of harbour services are berthed and serviced.")]
        CoveredServiceTerminal = 4,

        [System.ComponentModel.Description("A covered or partially covered terminal for the loading and unloading of passengers.")]
        CoveredPassengerTerminal = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfTidalStream : int
    {
        [System.ComponentModel.Description("The horizontal movement of water associated with the rising tide. Flood streams generally set towards the shore, or in the direction of the tide progression.")]
        FloodStream = 1,

        [System.ComponentModel.Description("The horizontal movement of water associated with falling tide. Ebb streams generally set seaward, or in the opposite direction to the tide progression.")]
        EbbStream = 2,

        [System.ComponentModel.Description("Any other horizontal movement of water associated with tides, for example rotary flow.")]
        OtherTidalFlow = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfVegetation : int
    {
        [System.ComponentModel.Description("A shrub or clump of shrubs with stems of moderate length.")]
        Bush = 3,

        [System.ComponentModel.Description("A wood with trees that shed their leaves annually.")]
        DeciduousWood = 4,

        [System.ComponentModel.Description("A wood with evergreen trees of a group usually bearing cones, including yews, cedars and redwoods.")]
        ConiferousWood = 5,

        [System.ComponentModel.Description("Growing trees densely occupying a tract of land.")]
        WoodInGeneralIncMixedWood = 6,

        [System.ComponentModel.Description("Any of various water or marsh plants with a firm stem. (Concise Oxford English Dictionary)")]
        Reed = 11,

        [System.ComponentModel.Description("An individual woody perennial plant, typically having a single stem or trunk growing to a considerable height and bearing lateral branches at some distance from the ground.")]
        TreeInGeneral = 13,

        [System.ComponentModel.Description("Having green foliage all the year round.")]
        EvergreenTree = 14,

        [System.ComponentModel.Description("A cone-bearing, needle-leaved or scale-leaved evergreen tree.")]
        ConiferousTree = 15,

        [System.ComponentModel.Description("A tropical or sub-tropical tree, shrub or vine having a tall, unbranched, columnar trunk. The trunk is crowned by a tuft or large, pleated fan or feather shaped leaves with stout sheathing and often prickly petioles (stalks), the persistent bases of which frequently clothe the trunk.")]
        PalmTree = 16,

        [System.ComponentModel.Description("A rare palm tree with regular branching involving equal or sub-equal division of the apex that results in forking.")]
        NipaPalmTree = 17,

        [System.ComponentModel.Description("A tree characterized by slender, green, often drooping branches that are deeply grooved and that bear, at intervals, whorls of tine leaves.")]
        CasuarinaTree = 18,

        [System.ComponentModel.Description("An instance of a large genus of mostly very large trees (90 metres).")]
        EucalyptTree = 19,

        [System.ComponentModel.Description("Sheds its leaves each year at the end of the period of growth.")]
        DeciduousTree = 20,

        [System.ComponentModel.Description("Casuarina equisetifolia, the most widespread and well-known member of the family Casuarinaceae.")]
        FilaoTree = 22,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfWaterTurbulence : int
    {
        [System.ComponentModel.Description("A wave breaking on the shore, over a reef, etc. Breakers may be roughly classified into three kinds, although the categories may overlap: spilling breakers break gradually over a considerable distance; plunging breakers tend to curl over and break with a crash; and surging breakers peak up, but then instead of spilling or plunging they surge up on the beach face. The French word 'brisant' is also used for the obstacle causing the breaking of the wave.")]
        Breakers = 1,

        [System.ComponentModel.Description("Circular movements of water usually formed where currents pass obstructions, between two adjacent currents flowing counter to each other, or along the edge of a permanent current.")]
        Eddies = 2,

        [System.ComponentModel.Description("Short, breaking waves occurring when a strong current passes over a shoal or other submarine obstruction or meets a contrary current or wind.")]
        Overfalls = 3,

        [System.ComponentModel.Description("Small waves formed on the surface of water by the meeting of opposing tidal currents or by a tidal current crossing an irregular bottom. Vertical oscillation, rather than progressive waves, is characteristic of tide rips.")]
        TideRips = 4,

        [System.ComponentModel.Description("A wave that forms over a submerged offshore reef or rock, sometimes (in very calm weather or at high tide) nearly swelling but in other conditions breaking heavily and producing a dangerous stretch of broken water; the reef or rock itself.")]
        Bombora = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfWeedKelp : int
    {
        [System.ComponentModel.Description("A giant plant sometimes 60 metres long with no roots, it is anchored by hold-fasts or tendrils up to 10 metres long, that cling to rock. Gas filled bubbles on fronds act as floats keeping the kelp just below the surface.")]
        Kelp = 1,

        [System.ComponentModel.Description("The general name for marine plants of the Algae class which grow in long narrow ribbons.")]
        Seaweed = 2,

        [System.ComponentModel.Description("A certain type of seaweed, or more generally, a large floating mass of this seaweed.")]
        Sargasso = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfWreck : int
    {
        [System.ComponentModel.Description("A wreck which is not considered to be dangerous to surface navigation.")]
        NonDangerousWreck = 1,

        [System.ComponentModel.Description("A wreck submerged at such a depth as to be considered dangerous to surface navigation.")]
        DangerousWreck = 2,

        [System.ComponentModel.Description("A substantively decayed wreck over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.")]
        DistributedRemainsOfWreck = 3,

        [System.ComponentModel.Description("Wreck of which only the mast(s) is visible at the sounding datum indicated.")]
        WreckShowingMastMasts = 4,

        [System.ComponentModel.Description("Wreck of which any portion of the hull or superstructure is visible at the sounding datum indicated.")]
        WreckShowingAnyPortionOfHullOrSuperstructure = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfZoneOfConfidenceInData : int
    {
        [System.ComponentModel.Description("Positional Accuracy +/- 5 metres + 5% depth; Depth Accuracy 0.5 metre + 1% depth; Full area search undertaken. Significant seafloor features detected and depths measured; Controlled, systematic survey, high position and depth accuracy achieved using DGPS or a minimum three high quality lines of position (LOP) and a multibeam, channel or mechanical sweep system.")]
        ZoneOfConfidenceA1 = 1,

        [System.ComponentModel.Description("Positional Accuracy +/- 20 metres; Depth Accuracy 1.0 metre + 2% depth; Full area search undertaken. Significant seafloor features detected and depths measured; Controlled, systematic survey achieving position and depth accuracy less than ZOC A1 and using a modern survey echosounder and a sonar or mechanical sweep system.")]
        ZoneOfConfidenceA2 = 2,

        [System.ComponentModel.Description("Positional Accuracy +/- 50 metres; Depth Accuracy 1.0 metre + 2% depth; Full area search not achieved, uncharted features hazardous to surface navigation are not expected but may exist; Controlled, systematic survey achieving similar depth but lesser position accuracies than ZOCA2, using a modern survey echosounder, but no sonar or mechanical sweep system.")]
        ZoneOfConfidenceB = 3,

        [System.ComponentModel.Description("Positional Accuracy +/- 500 metres; Depth Accuracy 2.0 metre + 5% depth; Full area search not achieved, depth anomalies may be expected; Low accuracy survey or data collected on an opportunity basis such as soundings on passage.")]
        ZoneOfConfidenceC = 4,

        [System.ComponentModel.Description("Positional Accuracy worse than ZOC C; Depth Accuracy worse than ZOC C; Full area search not achieved, large depth anomalies may be expected; Poor quality data or data that cannot be quality assessed due to lack of information.")]
        ZoneOfConfidenceD = 5,

        [System.ComponentModel.Description("The quality of the bathymetric data has yet to be assessed.")]
        ZoneOfConfidenceU = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public enum colour : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("")]
        White = 1,

        [System.ComponentModel.Description("")]
        Black = 2,

        [System.ComponentModel.Description("")]
        Red = 3,

        [System.ComponentModel.Description("")]
        Green = 4,

        [System.ComponentModel.Description("")]
        Blue = 5,

        [System.ComponentModel.Description("")]
        Yellow = 6,

        [System.ComponentModel.Description("")]
        Grey = 7,

        [System.ComponentModel.Description("")]
        Brown = 8,

        [System.ComponentModel.Description("")]
        Amber = 9,

        [System.ComponentModel.Description("")]
        Violet = 10,

        [System.ComponentModel.Description("")]
        Orange = 11,

        [System.ComponentModel.Description("")]
        Magenta = 12,

        [System.ComponentModel.Description("")]
        Pink = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum colourPattern : int
    {
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented horizontally.")]
        HorizontalStripes = 1,

        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented vertically.")]
        VerticalStripes = 2,

        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).")]
        DiagonalStripes = 3,

        [System.ComponentModel.Description("Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
        Squared = 4,

        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented in an unknown direction.")]
        StripesDirectionUnknown = 5,

        [System.ComponentModel.Description("A band or stripe of colour which is displayed around the outer edge of the feature, which may also form a border to an inner pattern or plain colour.")]
        BorderStripe = 6,
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

        [System.ComponentModel.Description("A windmill or wind turbine from which the vanes or turbine blades are missing.")]
        Wingless = 4,

        [System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
        PlannedConstruction = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum dataAssessment : int
    {
        [System.ComponentModel.Description("The quality of the bathymetric data has been assessed.")]
        Assessed = 1,

        [System.ComponentModel.Description("The quality of oceanic bathymetric data (depths deeper than 200 metres) has been assessed, however details are not required.")]
        AssessedOceanic = 2,

        [System.ComponentModel.Description("Not having been assessed.")]
        Unassessed = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum dayOfWeek : int
    {
        [System.ComponentModel.Description("The day of the week following Saturday and preceding Monday.")]
        Sunday = 1,

        [System.ComponentModel.Description("The day of the week following Sunday and preceding Tuesday.")]
        Monday = 2,

        [System.ComponentModel.Description("The day of the week following Monday and preceding Wednesday.")]
        Tuesday = 3,

        [System.ComponentModel.Description("The day of the week following Tuesday and preceding Thursday.")]
        Wednesday = 4,

        [System.ComponentModel.Description("The day of the week following Wednesday and preceding Friday.")]
        Thursday = 5,

        [System.ComponentModel.Description("The day of the week following Thursday and preceding Saturday.")]
        Friday = 6,

        [System.ComponentModel.Description("The day of the week following Friday and preceding Sunday.")]
        Saturday = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum distanceUnitOfMeasurement : int
    {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        Metres = 1,

        [System.ComponentModel.Description("A common unit of linear measure in English-speaking countries, equal to 3 feet or 36 inches, and equivalent to 0.9144 metre.")]
        Yards = 2,

        [System.ComponentModel.Description("A unit of length, the common measure of distances equal to 1000 metres, and equivalent to 3280.8 feet or 0.621 mile.")]
        Kilometres = 3,

        [System.ComponentModel.Description("A unit equal to 5280 feet.")]
        StatuteMiles = 4,

        [System.ComponentModel.Description("A unit of length equal to 1,852 metres. This value was approved by the International Hydrographic Conference of 1929 and has been adopted by nearly all maritime states.")]
        NauticalMiles = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum exhibitionConditionOfLight : int
    {
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
    public enum expositionOfSounding : int
    {
        [System.ComponentModel.Description("The depth corresponds to the depth range of the surrounding depth area; that is, the depth is not shoaler than the minimum depth of the surrounding depth area or deeper than the maximum depth of the surrounding depth area.")]
        WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,

        [System.ComponentModel.Description("The depth is shoaler than the minimum depth of the surrounding depth area.")]
        ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,

        [System.ComponentModel.Description("The depth is deeper than the maximum depth of the surrounding depth area.")]
        DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public enum function : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("A local official who has charge of mooring and berthing of vessels, collecting harbour fees, etc.")]
        HarbourMastersOffice = 2,

        [System.ComponentModel.Description("Serves as a government office where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
        CustomsOffice = 3,

        [System.ComponentModel.Description("The office which is charged with the administration of health laws and sanitary inspections.")]
        HealthOffice = 4,

        [System.ComponentModel.Description("An institution or establishment providing medical or surgical treatment for the ill or wounded.")]
        Hospital = 5,

        [System.ComponentModel.Description("The public department, agency or organisation responsible primarily for the collection, transmission and distribution of mail.")]
        PostOffice = 6,

        [System.ComponentModel.Description("An establishment, especially of a comfortable or luxurious kind, where paying visitors are provided with accommodation, meals and other services.")]
        Hotel = 7,

        [System.ComponentModel.Description("A building with platforms where trains arrive, load, discharge and depart.")]
        RailwayStation = 8,

        [System.ComponentModel.Description("The headquarters of a local police force and that is where those under arrest are first charged.")]
        PoliceStation = 9,

        [System.ComponentModel.Description("The headquarters of a local water-police force.")]
        WaterPoliceStation = 10,

        [System.ComponentModel.Description("The office or headquarters of pilots; the place where the services of a pilot may be obtained.")]
        PilotOffice = 11,

        [System.ComponentModel.Description("A distinctive structure or place on shore from which personnel keep watch upon events at sea or along the coast.")]
        PilotLookout = 12,

        [System.ComponentModel.Description("An office for custody, deposit, loan, exchange or issue of money.")]
        BankOffice = 13,

        [System.ComponentModel.Description("The quarters of an executive officer (director, manager, etc.) with responsibility for an administrative area.")]
        HeadquartersForDistrictControl = 14,

        [System.ComponentModel.Description("A building or part of a building for storage of wares or goods.")]
        TransitShedWarehouse = 15,

        [System.ComponentModel.Description("A building or buildings with equipment for manufacturing; a workshop.")]
        Factory = 16,

        [System.ComponentModel.Description("A stationary plant containing apparatus for large scale conversion of some form of energy (such as hydraulic, steam, chemical or nuclear energy) into electrical energy.")]
        PowerStation = 17,

        [System.ComponentModel.Description("A building for the management of affairs.")]
        Administrative = 18,

        [System.ComponentModel.Description("An establishment for teaching and learning (for example school, college, university, etc).")]
        EducationalFacility = 19,

        [System.ComponentModel.Description("A building for public Christian worship.")]
        Church = 20,

        [System.ComponentModel.Description("A place for Christian worship other than a parish, cathedral or church, especially one attached to a private house or institution.")]
        Chapel = 21,

        [System.ComponentModel.Description("A building for public Jewish worship.")]
        Temple = 22,

        [System.ComponentModel.Description("A Hindu or Buddhist temple or sacred building.")]
        Pagoda = 23,

        [System.ComponentModel.Description("A building for public Shinto worship.")]
        ShintoShrine = 24,

        [System.ComponentModel.Description("A building for public Buddhist worship.")]
        BuddhistTemple = 25,

        [System.ComponentModel.Description("A Muslim place of worship.")]
        Mosque = 26,

        [System.ComponentModel.Description("A shrine marking the burial place of a Muslim holy man.")]
        Marabout = 27,

        [System.ComponentModel.Description("Keeping a watch upon events at sea or along the coast.")]
        Lookout = 28,

        [System.ComponentModel.Description("Transmitting and/or receiving electronic communication signals.")]
        Communication = 29,

        [System.ComponentModel.Description("A system for reproducing on a screen visual images transmitted (usually with sound) by radio signals.")]
        Television = 30,

        [System.ComponentModel.Description("Transmitting and/or receiving radio-frequency electromagnetic waves as a means of communication.")]
        Radio = 31,

        [System.ComponentModel.Description("A method, system or technique of using beamed, reflected, and timed radio waves for detecting, locating, or tracking objects, and for measuring altitudes.")]
        Radar = 32,

        [System.ComponentModel.Description("A structure serving as a support for one or more lights.")]
        LightSupport = 33,

        [System.ComponentModel.Description("Broadcasting and receiving signals using microwaves.")]
        Microwave = 34,

        [System.ComponentModel.Description("Generation of chilled liquid and/or gas for cooling purposes.")]
        Cooling = 35,

        [System.ComponentModel.Description("A place from which the surroundings can be observed but at which a watch is not habitually maintained.")]
        Observation = 36,

        [System.ComponentModel.Description("A visual time signal in the form of a ball.")]
        Timeball = 37,

        [System.ComponentModel.Description("Instrument for measuring time and recording hours.")]
        Clock = 38,

        [System.ComponentModel.Description("Used to control the flow of traffic within a specified range of an installation.")]
        Control = 39,

        [System.ComponentModel.Description("Equipment or structure to secure an airship.")]
        AirshipMooring = 40,

        [System.ComponentModel.Description("An arena for holding and viewing events.")]
        Stadium = 41,

        [System.ComponentModel.Description("A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.")]
        BusStation = 42,

        [System.ComponentModel.Description("A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.")]
        SeaRescueControl = 44,

        [System.ComponentModel.Description("A building designed and equipped for making observations of astronomical, meteorological, or other natural phenomena.")]
        Observatory = 45,

        [System.ComponentModel.Description("A building or structure used to crush ore.")]
        OreCrusher = 46,

        [System.ComponentModel.Description("A building or shed, usually built partly over water, for sheltering a boat or boats.")]
        Boathouse = 47,

        [System.ComponentModel.Description("A facility to move solids, liquids or gases by means of pressure or suction.")]
        PumpingStation = 48,
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

        [System.ComponentModel.Description("An area smaller than the nation in which it lies.")]
        NationalSubDivision = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lightCharacteristic : int
    {
        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
        Fixed = 1,

        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        Flashing = 2,

        [System.ComponentModel.Description("A single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.")]
        LongFlashing = 3,

        [System.ComponentModel.Description("A rhythmic light in which flashes are repeated at a rate of not less than 50 flashes per minutes but less than 80 flashes per minutes. It may be: - Continuous quick-flashing: A quick-flashing light in which a flash is regularly repeated. - Group quick-flashing: A quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
        QuickFlashing = 4,

        [System.ComponentModel.Description("A rhythmic light in which flashes are repeated at a rate of not less than 80 flashes per minute but less than 160 flashes per minute. It may be:- Continuous very quick-flashing: A very quick-flashing light in which a flash is regularly repeated.- Group very quick-flashing: A very quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
        VeryQuickFlashing = 5,

        [System.ComponentModel.Description("A rhythmic light in which flashes are regularly repeated at a rate of not less than 160 flashes per minute.")]
        ContinuousUltraQuickFlashing = 6,

        [System.ComponentModel.Description("A light with all durations of light and darkness equal.")]
        Isophased = 7,

        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be:  - Single-occulting: An occulting light in which an eclipse is regularly repeated.  - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated.  - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
        Occulting = 8,

        [System.ComponentModel.Description("A light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.")]
        InterruptedUltraQuickFlashing = 11,

        [System.ComponentModel.Description("A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
        Morse = 12,

        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
        FixedAndFlash = 13,

        [System.ComponentModel.Description("A rhythmic light in which a flashing light is combined with a long-flashing light of higher luminous intensity.")]
        FlashAndLongFlash = 14,

        [System.ComponentModel.Description("A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.")]
        OccultingAndFlash = 15,

        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a long-flashing light of higher luminous intensity.")]
        FixedAndLongFlash = 16,

        [System.ComponentModel.Description("An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.")]
        OccultingAlternating = 17,

        [System.ComponentModel.Description("An alternating single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.")]
        LongFlashAlternating = 18,

        [System.ComponentModel.Description("An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        FlashAlternating = 19,

        [System.ComponentModel.Description("A rhythmic light in which a group of quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
        QuickFlashPlusLongFlash = 25,

        [System.ComponentModel.Description("A rhythmic light in which a group of very quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
        VeryQuickFlashPlusLongFlash = 26,

        [System.ComponentModel.Description("A rhythmic light in which a group of ultra quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
        UltraQuickFlashPlusLongFlash = 27,

        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
        Alternating = 28,

        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity and different colour.")]
        FixedAndAlternatingFlashing = 29,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum lightVisibility : int
    {
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
    public enum referenceDirection : int
    {
        [System.ComponentModel.Description("")]
        East = 5,

        [System.ComponentModel.Description("")]
        West = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum marksNavigationalSystemOf : int
    {
        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.")]
        IalaA = 1,

        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.")]
        IalaB = 2,

        [System.ComponentModel.Description("Navigational aids do not conform to any defined system.")]
        NoSystem = 9,

        [System.ComponentModel.Description("Navigational aids as required in international, national or regional regulations that contain the same navigational aids as the European Code for Inland Waterways of UNECE, or if there is no regulation for a waterway, navigational aids as recommended in the European Code for Inland Waterways of UNECE.")]
        MainEuropeanInlandWaterwayMarkingSystem = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum nameUsage : int
    {
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
        DefaultNameDisplay = 1,

        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
        AlternateNameDisplay = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfConstruction : int
    {
        [System.ComponentModel.Description("Constructed of stones or bricks, usually quarried, shaped, and mortared.")]
        Masonry = 1,

        [System.ComponentModel.Description("Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
        Concreted = 2,

        [System.ComponentModel.Description("Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
        LooseBoulders = 3,

        [System.ComponentModel.Description("Constructed with a surface of hard material, usually a term applied to roads surfaced with asphalt or concrete.")]
        HardSurfaced = 4,

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

        [System.ComponentModel.Description("[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like.   [2] Something made of such a substance, as a windowpane.")]
        Glass = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum natureOfSurface : int
    {
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
    public enum natureOfSurfaceQualifyingTerms : int
    {
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
    public enum pilotMovement : int
    {
        [System.ComponentModel.Description("The place where vessels not being navigated according to a pilot's instructions pick up a pilot while in transit from sea to a port or constricted waters for future navigation under pilot instructions.")]
        Embarkation = 1,

        [System.ComponentModel.Description("The place where vessels being navigated under a pilot's instructions in transit from sea to a port or constricted waters drop the pilot and proceed without being subject to pilot instructions.")]
        Disembarkation = 2,

        [System.ComponentModel.Description("The place where vessels being navigated under a pilot's instructions drop off the pilot and pick up a different pilot for future navigation under pilot's instructions.")]
        PilotChange = 3,
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

        [System.ComponentModel.Description("Powdery fragments of wood made in sawing timber or coarse chips produced for use in manufacturing pressed board.")]
        SawdustWoodChips = 16,

        [System.ComponentModel.Description("Discarded metal suitable for being reprocessed.")]
        ScrapMetal = 17,

        [System.ComponentModel.Description("Natural gas that has been liquefied for ease of transport by cooling the gas to -162 Celsius.")]
        LiquefiedNaturalGas = 18,

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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum qualityOfHorizontalMeasurement : int
    {
        [System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.")]
        Approximate = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum qualityOfVerticalMeasurement : int
    {
        [System.ComponentModel.Description("The depth from the chart datum to the seabed (or to the top of a drying feature) is known.")]
        DepthKnown = 1,

        [System.ComponentModel.Description("The depth from chart datum to the seabed, or the shoalest depth of the feature is unknown.")]
        DepthOrLeastDepthUnknown = 2,

        [System.ComponentModel.Description("A depth that may be less than indicated.")]
        DoubtfulSounding = 3,

        [System.ComponentModel.Description("A depth that is considered to be an unreliable value.")]
        UnreliableSounding = 4,

        [System.ComponentModel.Description("The shoalest depth over a feature is of known value.")]
        LeastDepthKnown = 6,

        [System.ComponentModel.Description("The least depth over a feature is unknown, but there is considered to be safe clearance at this depth.")]
        LeastDepthUnknownSafeClearanceAtValueShown = 7,

        [System.ComponentModel.Description("Depth value obtained from a report, but not fully surveyed.")]
        ValueReportedNotSurveyed = 8,

        [System.ComponentModel.Description("Depth value obtained from a report, which it has not been possible to confirm.")]
        ValueReportedNotConfirmed = 9,

        [System.ComponentModel.Description("The depth at which a channel is kept by human influence, usually by dredging.")]
        MaintainedDepth = 10,

        [System.ComponentModel.Description("Depths may be altered by human influence, but will not be routinely maintained.")]
        NotRegularlyMaintained = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum referenceTide : int
    {
        [System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
        HighWater = 1,

        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        LowWater = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum referenceTideType : int
    {
        [System.ComponentModel.Description("The tides of increased range occurring near the times of full moon and new moon.")]
        Springs = 1,

        [System.ComponentModel.Description("The tides of decreased range occurring near the times of first and last quarter.")]
        Neaps = 2,

        [System.ComponentModel.Description("The tides of mean range occurring between spring and neap tides.")]
        Mean = 3,
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

        [System.ComponentModel.Description("An area within which industrial or mineral exploration and development are prohibited.")]
        IndustrialOrMineralExplorationDevelopmentProhibited = 18,

        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which industrial or mineral exploration and development is restricted in accordance with certain specified conditions.")]
        IndustrialOrMineralExplorationDevelopmentRestricted = 19,

        [System.ComponentModel.Description("An area within which excavating a hole on the seabed with a drill is prohibited.")]
        DrillingProhibited = 20,

        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the seabed with a drill is restricted in accordance with certain specified conditions.")]
        DrillingRestricted = 21,

        [System.ComponentModel.Description("An area within which the removal of historical artefacts is prohibited.")]
        RemovalOfHistoricalArtefactsProhibited = 22,

        [System.ComponentModel.Description("An area in which cargo transhipment (lightening) is prohibited.")]
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

        [System.ComponentModel.Description("An area within which any vessel propelled by machinery is prohibited.")]
        PowerDrivenVesselsProhibited = 42,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum signalGeneration : int
    {
        [System.ComponentModel.Description("Signal generation is initiated by a self regulating mechanism such as a timer or light sensor.")]
        Automatically = 1,

        [System.ComponentModel.Description("The signal is generated by the motion of the sea surface such as a bell in a buoy.")]
        ByWaveAction = 2,

        [System.ComponentModel.Description("The signal is generated by a manually operated mechanism such as a hand cranked siren.")]
        ByHand = 3,

        [System.ComponentModel.Description("The signal is generated by the motion of air such as a wind driven whistle.")]
        ByWind = 4,

        [System.ComponentModel.Description("Activated by radio signal.")]
        RadioActivated = 5,

        [System.ComponentModel.Description("Activated by making a call to a manned station.")]
        CallActivated = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum signalStatus : int
    {
        [System.ComponentModel.Description("The indication of an element of a signal sequence being a period of light or sound.")]
        LitSound = 1,

        [System.ComponentModel.Description("The indication of an element of a signal sequence being a period of eclipse or silence.")]
        EclipsedSilent = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum speedUnits : int
    {
        [System.ComponentModel.Description("A unit of speed, expressing the number of kilometres travelled in one hour.")]
        KilometresPerHour = 2,

        [System.ComponentModel.Description("An imperial and United States customary unit of speed expressing the number of statute miles covered in one hour.")]
        MilesPerHour = 3,

        [System.ComponentModel.Description("A nautical unit of speed. One knot is one nautical mile per hour. The name is derived from the knots in the log line.")]
        Knots = 4,
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

        [System.ComponentModel.Description("Recurring at intervals.")]
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum surveyType : int
    {
        [System.ComponentModel.Description("A survey made (due to lack of time or facilities) to a lower degree of accuracy and detail than the chosen scale would normally indicate.")]
        ReconnaissanceSketchSurvey = 1,

        [System.ComponentModel.Description("A thorough survey usually conducted with reference to guidelines.")]
        ControlledSurvey = 2,

        [System.ComponentModel.Description("A survey principally aimed at the investigation of underwater obstructions and dangers.")]
        ExaminationSurvey = 4,

        [System.ComponentModel.Description("A survey where soundings are acquired by vessels on passage.")]
        PassageSurvey = 5,

        [System.ComponentModel.Description("A survey where features have been positioned and delimited using remote sensing techniques.")]
        RemotelySensed = 6,

        [System.ComponentModel.Description("A survey achieving 100% coverage using systematic, controlled techniques providing full seafloor coverage or full coverage to a defined depth and an investigation of all contacts.")]
        FullCoverage = 7,

        [System.ComponentModel.Description("A controlled survey but full coverage may not have been achieved.")]
        SystematicSurvey = 8,

        [System.ComponentModel.Description("A survey of lower quality than a full coverage and systematic survey. Such surveys may be further categorized as reconnaissance, sketch, track, passage, remotely sensed and spot-sounding surveys.")]
        NonSystematicSurvey = 9,

        [System.ComponentModel.Description("Not surveyed to modern standards; or due to its age, scale, or positional or vertical uncertainties is not suitable to the type of navigation expected in the area.")]
        InadequatelySurveyed = 10,

        [System.ComponentModel.Description("A survey that uses a regular (for example grid) or irregular pattern of soundings obtained one at a time, and normally with very wide spacing.")]
        SpotSoundingSurvey = 11,

        [System.ComponentModel.Description("A controlled, systematic survey to standard accuracy; using modern survey echo sounder with sonar sweep.")]
        AcousticallySweptSurvey = 12,

        [System.ComponentModel.Description("Swept areas where the clearance depth is accurately known but the actual seabed depth is not accurately known.")]
        MechanicallySweptSurvey = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum updateType : int
    {
        [System.ComponentModel.Description("To put or introduce into the body of something.")]
        Insert = 1,

        [System.ComponentModel.Description("To eliminate especially by removing, cutting out or erasing.")]
        Delete = 2,

        [System.ComponentModel.Description("To make basic or fundamental changes to the characteristics of something, often to give a new orientation to or to serve a new end.")]
        Modify = 3,

        [System.ComponentModel.Description("To change the place or position of something.")]
        Move = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum techniqueOfVerticalMeasurement : int
    {
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

        [System.ComponentModel.Description("The depth was determined by using levelling techniques to find the elevation of the point relative to a datum.")]
        FoundByLevelling = 12,

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
    public enum telecommunicationService : int
    {
        [System.ComponentModel.Description("The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.")]
        Voice = 1,

        [System.ComponentModel.Description("A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.")]
        Facsimile = 2,

        [System.ComponentModel.Description("Short Message Service is a form of text messaging communication on phones and mobile phones.")]
        Sms = 3,

        [System.ComponentModel.Description("A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.")]
        Data = 4,

        [System.ComponentModel.Description("Data that is constantly received by and presented to an end-user while being delivered by a provider.")]
        StreamedData = 5,

        [System.ComponentModel.Description("A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).")]
        Telex = 6,

        [System.ComponentModel.Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
        Telegraph = 7,

        [System.ComponentModel.Description("Messages and other data exchanged between individuals using computers in a network.")]
        Email = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum textType : int
    {
        [System.ComponentModel.Description("The individual name of a feature.")]
        Name = 1,

        [System.ComponentModel.Description("A distinguishing trait, quality, or property of a feature class.")]
        FeatureCharacteristic = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum topmarkDaymarkShape : int
    {
        [System.ComponentModel.Description("Is where the vertex points up.")]
        ConePointUp = 1,

        [System.ComponentModel.Description("Is where the vertex points down.")]
        ConePointDown = 2,

        [System.ComponentModel.Description("A curved surface all points of which are equidistant from a fixed point within, called the centre.")]
        Sphere = 3,

        [System.ComponentModel.Description("Two spheres, one above the other. Two black spheres are commonly used as an International Association of Lighthouse Authorities - IALA topmark (isolated danger).")]
        twoSpheres = 4,

        [System.ComponentModel.Description("A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, its ends being parallel circles).")]
        Cylinder = 5,

        [System.ComponentModel.Description("Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
        Board = 6,

        [System.ComponentModel.Description("Having a shape or a cross-section like the capital letter X.")]
        XShaped = 7,

        [System.ComponentModel.Description("A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.")]
        UprightCross = 8,

        [System.ComponentModel.Description("A cube standing on one of its vertexes. A cube is a solid contained by six equal squares, a regular hexahedron.")]
        CubePointUp = 9,

        [System.ComponentModel.Description("2 cones, one above the other, with their vertices together in the centre.")]
        twoConesPointToPoint = 10,

        [System.ComponentModel.Description("2 cones, one above the other, with their bases together in the centre and their vertices pointing up and down.")]
        twoConesBaseToBase = 11,

        [System.ComponentModel.Description("A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.")]
        Rhombus = 12,

        [System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing up.")]
        twoConesPointsUpward = 13,

        [System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing down.")]
        twoConesPointsDownward = 14,

        [System.ComponentModel.Description("A bundle of rods or twigs. A besom, point up is where the thicker (untied) end of the besom is at the bottom.")]
        BesomPointUp = 15,

        [System.ComponentModel.Description("A bundle of rods or twigs. A besom, point down is where the thinner (tied) end of the besom is at the bottom.")]
        BesomPointDown = 16,

        [System.ComponentModel.Description("A flag mounted on a short pole.")]
        Flag = 17,

        [System.ComponentModel.Description("A sphere located above a rhombus.")]
        SphereOverARhombus = 18,

        [System.ComponentModel.Description("A plane figure with four right angles and four equal straight sides.")]
        Square = 19,

        [System.ComponentModel.Description("A horizontal rectangle is where the two longer opposite sides are standing horizontally.")]
        RectangleHorizontal = 20,

        [System.ComponentModel.Description("A vertical rectangle is where the two longer opposite sides are standing vertically.")]
        RectangleVertical = 21,

        [System.ComponentModel.Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its longer parallel side.")]
        TrapeziumUp = 22,

        [System.ComponentModel.Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its shorter parallel side.")]
        TrapeziumDown = 23,

        [System.ComponentModel.Description("A figure having three angles and three sides, and which has a vertex at the top.")]
        TrianglePointUp = 24,

        [System.ComponentModel.Description("A figure having three angles and three sides, and which has a side at the top.")]
        TrianglePointDown = 25,

        [System.ComponentModel.Description("A perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
        Circle = 26,

        [System.ComponentModel.Description("Two upright crosses, generally vertically disposed one above the other.")]
        TwoUprightCrossesOneOverTheOther = 27,

        [System.ComponentModel.Description("Having a shape like the capital letter T.")]
        TShape = 28,

        [System.ComponentModel.Description("A triangle, vertex uppermost, located above a circle.")]
        TrianglePointingUpOverACircle = 29,

        [System.ComponentModel.Description("An upright cross located above a circle.")]
        UprightCrossOverACircle = 30,

        [System.ComponentModel.Description("A rhombus located above a circle.")]
        RhombusOverACircle = 31,

        [System.ComponentModel.Description("A circle located over a triangle, vertex uppermost.")]
        CircleOverATrianglePointingUp = 32,

        [System.ComponentModel.Description("An uncommon and/or non-standardized shape as textually described using an associated attribute.")]
        OtherShapeSeeShapeInformation = 33,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum trafficFlow : int
    {
        [System.ComponentModel.Description("Traffic flow in a general direction toward a port or similar destination.")]
        Inbound = 1,

        [System.ComponentModel.Description("Traffic flow in a general direction away from a port or similar point of origin.")]
        Outbound = 2,

        [System.ComponentModel.Description("Traffic flow in one general direction only.")]
        OneWay = 3,

        [System.ComponentModel.Description("Traffic flow in two generally opposite directions.")]
        TwoWay = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum verticalDatum : int
    {
        [System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.")]
        MeanLowWaterSprings = 1,

        [System.ComponentModel.Description("The average height of lower low water springs at a place.")]
        MeanLowerLowWaterSprings = 2,

        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        MeanSeaLevel = 3,

        [System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.")]
        LowestLowWater = 4,

        [System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
        MeanLowWater = 5,

        [System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
        LowestLowWaterSprings = 6,

        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
        ApproximateMeanLowWaterSprings = 7,

        [System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
        IndianSpringLowWater = 8,

        [System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
        LowWaterSprings = 9,

        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
        ApproximateLowestAstronomicalTide = 10,

        [System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
        NearlyLowestLowWater = 11,

        [System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
        MeanLowerLowWater = 12,

        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        LowWater = 13,

        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
        ApproximateMeanLowWater = 14,

        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
        ApproximateMeanLowerLowWater = 15,

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

        [System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
        EquinoctialSpringLowWater = 22,

        [System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        LowestAstronomicalTide = 23,

        [System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        LocalDatum = 24,

        [System.ComponentModel.Description("A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Père, Quebec, over the period 1970 to 1988.")]
        InternationalGreatLakesDatum1985 = 25,

        [System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
        MeanWaterLevel = 26,

        [System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
        LowerLowWaterLargeTide = 27,

        [System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
        HigherHighWaterLargeTide = 28,

        [System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
        NearlyHighestHighWater = 29,

        [System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        HighestAstronomicalTide = 30,

        [System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
        BalticSeaChartDatum2000 = 44,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum virtualAISAidToNavigationType : int
    {
        [System.ComponentModel.Description("Indicates that it should be passed to the north side of the aid.")]
        NorthCardinal = 1,

        [System.ComponentModel.Description("Indicates that it should be passed to the east side of the aid.")]
        EastCardinal = 2,

        [System.ComponentModel.Description("Indicates that it should be passed to the south side of the aid.")]
        SouthCardinal = 3,

        [System.ComponentModel.Description("Indicates that it should be passed to the west side of the aid.")]
        WestCardinal = 4,

        [System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA A system.")]
        PortLateralIalaA = 5,

        [System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA A system.")]
        StarboardLateralIalaA = 6,

        [System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA B system.")]
        PortLateralIalaB = 7,

        [System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA B system.")]
        StarboardLateralIalaB = 8,

        [System.ComponentModel.Description("A mark used alone to indicate a dangerous reef or shoal. The mark may be passed on either hand.")]
        IsolatedDanger = 9,

        [System.ComponentModel.Description("Indicates that there is navigable water around the mark.")]
        SafeWater = 10,

        [System.ComponentModel.Description("A special purpose aid is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notice to Mariners.")]
        SpecialPurpose = 11,

        [System.ComponentModel.Description("A mark used to indicate the existence of a recent wreck.")]
        EmergencyWreckMarking = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum visualProminence : int
    {
        [System.ComponentModel.Description("Term applied to an object either natural or artificial which is distinctly and notably visible from seaward.")]
        VisuallyConspicuous = 1,

        [System.ComponentModel.Description("An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.")]
        NotVisuallyConspicuous = 2,

        [System.ComponentModel.Description("Objects which are easily identifiable, but do not justify being classed as conspicuous.")]
        Prominent = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum waterLevelEffect : int
    {
        [System.ComponentModel.Description("Partially covered and partially dry at high water.")]
        PartlySubmergedAtHighWater = 1,

        [System.ComponentModel.Description("Not covered at high water under average meteorological conditions.")]
        AlwaysDry = 2,

        [System.ComponentModel.Description("Remains covered by water at all times under average meteorological conditions.")]
        AlwaysUnderWaterSubmerged = 3,

        [System.ComponentModel.Description("Expression intended to indicate an area of a reef or other projection from the bottom of a body of water which periodically extends above and is submerged below the surface. Also referred to as dries or uncovers.")]
        CoversAndUncovers = 4,

        [System.ComponentModel.Description("Flush with, or washed by the waves at low water under average meteorological conditions.")]
        Awash = 5,

        [System.ComponentModel.Description("An area periodically covered by flood water, excluding tidal waters.")]
        SubjectToInundationOrFlooding = 6,

        [System.ComponentModel.Description("Resting or moving on the surface of a liquid without sinking.")]
        Floating = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCargo : int
    {
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

        [System.ComponentModel.Description("Wheeled cargo, such as cars, busses, trucks, agricultural vehicles and cranes, that are driven on and off the ship on their own wheels or using a platform vehicle, such as a self-propelled modular transporter.")]
        RoRoCargo = 13,

        [System.ComponentModel.Description("Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.")]
        ProjectCargo = 14,

        [System.ComponentModel.Description("Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.")]
        BreakBulkCargo = 15,
    }


    public static class CodeList
    {
    }

    namespace ComplexAttributes
    {

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName
        {
            public String language { get; set; } = string.Empty;
            public String name { get; set; } = string.Empty;
            public nameUsage? nameUsage { get; set; } = default;

            public featureName()
            {
                language = string.Empty;
                name = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featuresDetected
        {
            [Required()]
            public Boolean leastDepthOfDetectedFeaturesMeasured { get; set; }

            [Required()]
            public Boolean significantFeaturesDetected { get; set; }
            public Decimal? sizeOfFeaturesDetected { get; set; } = default;

            public featuresDetected()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class fixedDateRange
        {
            public DateOnly? dateEnd { get; set; } = default;
            public DateOnly? dateStart { get; set; } = default;

            public fixedDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class frequencyPair
        {
            public Int32? frequencyShoreStationReceives { get; set; } = default;

            [Required()]
            public Int32 frequencyShoreStationTransmits { get; set; }

            public frequencyPair()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class horizontalClearanceFixed
        {
            [Required()]
            public Decimal horizontalClearanceValue { get; set; }
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            public horizontalClearanceFixed()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class horizontalClearanceOpen
        {
            [Required()]
            public Decimal horizontalClearanceValue { get; set; }
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            public horizontalClearanceOpen()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class horizontalPositionUncertainty
        {
            [Required()]
            public Decimal uncertaintyFixed { get; set; }
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            public horizontalPositionUncertainty()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class information
#pragma warning restore CS8981
        {
            public String fileLocator { get; set; } = string.Empty;
            public String fileReference { get; set; } = string.Empty;
            public String headline { get; set; } = string.Empty;
            public String language { get; set; } = string.Empty;
            public String text { get; set; } = string.Empty;

            public information()
            {
                language = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class measuredDistanceValue
        {
            [Required()]
            public distanceUnitOfMeasurement distanceUnitOfMeasurement { get; set; }
            public String referenceLocation { get; set; } = string.Empty;

            [Required()]
            public Decimal waterwayDistance { get; set; }

            public measuredDistanceValue()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class multiplicityOfFeatures
        {
            [Required()]
            public Boolean multiplicityKnown { get; set; }
            public Int32? numberOfFeatures { get; set; } = default;

            public multiplicityOfFeatures()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class onlineResource
        {
            public String headline { get; set; } = string.Empty;
            public String linkage { get; set; } = string.Empty;
            public String nameOfResource { get; set; } = string.Empty;

            public onlineResource()
            {
                linkage = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class orientation
#pragma warning restore CS8981
        {
            public Decimal? orientationUncertainty { get; set; } = default;

            [Required()]
            public Decimal orientationValue { get; set; }

            public orientation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class periodicDateRange
        {
            [Required()]
            public DateOnly dateEnd { get; set; }

            [Required()]
            public DateOnly dateStart { get; set; }

            public periodicDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class radarWaveLength
        {
            public String radarBand { get; set; } = string.Empty;

            [Required()]
            public Decimal waveLengthValue { get; set; }

            public radarWaveLength()
            {
                radarBand = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorInformation
        {
            public String language { get; set; } = string.Empty;
            public String text { get; set; } = string.Empty;

            public sectorInformation()
            {
                text = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitOne
        {
            [Required()]
            public Decimal sectorBearing { get; set; }
            public Decimal? sectorLineLength { get; set; } = default;

            public sectorLimitOne()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitTwo
        {
            [Required()]
            public Decimal sectorBearing { get; set; }
            public Decimal? sectorLineLength { get; set; } = default;

            public sectorLimitTwo()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class shapeInformation
        {
            public String language { get; set; } = string.Empty;
            public String text { get; set; } = string.Empty;

            public shapeInformation()
            {
                text = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class signalSequence
        {
            [Required()]
            public Decimal signalDuration { get; set; }

            [Required()]
            public signalStatus signalStatus { get; set; }

            public signalSequence()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class speed
#pragma warning restore CS8981
        {
            [Required()]
            public Decimal speedMaximum { get; set; }
            public Decimal? speedMinimum { get; set; } = default;

            public speed()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class surfaceCharacteristics
        {
            public natureOfSurface? natureOfSurface { get; set; } = default;
            public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms { get; set; } = [];
            public Int32? underlyingLayer { get; set; } = default;

            public surfaceCharacteristics()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class surveyDateRange
        {
            [Required()]
            public DateOnly dateEnd { get; set; }
            public DateOnly? dateStart { get; set; } = default;

            public surveyDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class telecommunications
#pragma warning restore CS8981
        {
            public String contactInstructions { get; set; } = string.Empty;
            public String telecommunicationIdentifier { get; set; } = string.Empty;
            public telecommunicationService? telecommunicationService { get; set; } = default;

            public telecommunications()
            {
                telecommunicationIdentifier = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class tidalStreamValue
        {
            [Required()]
            public orientation orientation { get; set; }

            [Required()]
            public Decimal speedMaximum { get; set; }

            [Required()]
            public Decimal timeRelativeToTide { get; set; }

            public tidalStreamValue()
            {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class timeIntervalsByDayOfWeek
        {
            public List<dayOfWeek> dayOfWeek { get; set; } = [];
            public Boolean? dayOfWeekIsRange { get; set; } = default;
            public List<TimeOnly> timeOfDayStart { get; set; } = [];
            public List<TimeOnly> timeOfDayEnd { get; set; } = [];

            public timeIntervalsByDayOfWeek()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class topmark
#pragma warning restore CS8981
        {
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;

            [Required()]
            public topmarkDaymarkShape topmarkDaymarkShape { get; set; }
            public List<shapeInformation> shapeInformation { get; set; } = [];

            public topmark()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class valueOfLocalMagneticAnomaly
        {
            [Required()]
            public Decimal magneticAnomalyValue { get; set; }
            public referenceDirection? referenceDirection { get; set; } = default;

            public valueOfLocalMagneticAnomaly()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalUncertainty
        {
            [Required()]
            public Decimal uncertaintyFixed { get; set; }
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            public verticalUncertainty()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class vesselSpeedLimit
        {
            [Required()]
            public Decimal speedLimit { get; set; }

            [Required()]
            public speedUnits speedUnits { get; set; }
            public String vesselClass { get; set; } = string.Empty;

            public vesselSpeedLimit()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class zoneOfConfidence
        {
            [Required()]
            public categoryOfZoneOfConfidenceInData categoryOfZoneOfConfidenceInData { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public horizontalPositionUncertainty? horizontalPositionUncertainty { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }

            public zoneOfConfidence()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class directionalCharacter
        {
            public Boolean? moireEffect { get; set; } = default;

            [Required()]
            public orientation orientation { get; set; }

            public directionalCharacter()
            {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class rhythmOfLight
        {
            [Required()]
            public lightCharacteristic lightCharacteristic { get; set; }
            public List<String> signalGroup { get; set; } = [];
            public Decimal? signalPeriod { get; set; } = default;
            public List<signalSequence> signalSequence { get; set; } = [];

            public rhythmOfLight()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class scheduleByDayOfWeek
        {
            public categoryOfSchedule? categoryOfSchedule { get; set; } = default;

            [Required()]
            public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; }

            public scheduleByDayOfWeek()
            {
                timeIntervalsByDayOfWeek = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimit
        {
            [Required()]
            public sectorLimitOne sectorLimitOne { get; set; }

            [Required()]
            public sectorLimitTwo sectorLimitTwo { get; set; }

            public sectorLimit()
            {
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
        public partial class spatialAccuracy
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public horizontalPositionUncertainty? horizontalPositionUncertainty { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }

            public spatialAccuracy()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class tidalStreamPanelValues
        {
            [Required()]
            public referenceTide referenceTide { get; set; }

            [Required()]
            public referenceTideType referenceTideType { get; set; }
            public Decimal? streamDepth { get; set; } = default;

            [Required()]
            public List<tidalStreamValue> tidalStreamValue { get; set; }

            public tidalStreamPanelValues()
            {
                tidalStreamValue = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalClearanceClosed
        {
            [Required()]
            public Decimal verticalClearanceValue { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceClosed()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalClearanceFixed
        {
            [Required()]
            public Decimal verticalClearanceValue { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceFixed()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalClearanceOpen
        {
            [Required()]
            public Boolean verticalClearanceUnlimited { get; set; }
            public Decimal? verticalClearanceValue { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceOpen()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class verticalClearanceSafe
        {
            [Required()]
            public Decimal verticalClearanceValue { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceSafe()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class lightSector
        {
            [Required()]
            public List<colour> colour { get; set; }
            public directionalCharacter? directionalCharacter { get; set; }
            public List<lightVisibility> lightVisibility { get; set; } = [];
            public sectorLimit? sectorLimit { get; set; }
            public Decimal? valueOfNominalRange { get; set; } = default;
            public List<sectorInformation> sectorInformation { get; set; } = [];
            public Boolean? sectorArcExtension { get; set; } = default;

            public lightSector()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorCharacteristics
        {
            [Required()]
            public lightCharacteristic lightCharacteristic { get; set; }

            [Required()]
            public List<lightSector> lightSector { get; set; }
            public List<String> signalGroup { get; set; } = [];
            public Decimal? signalPeriod { get; set; } = default;
            public List<signalSequence> signalSequence { get; set; } = [];

            public sectorCharacteristics()
            {
                lightSector = new();
            }
        }
    }

    public enum Role
    {
        [System.ComponentModel.Description("A pointer to incidental, secondary or supplementary features related to the referenced feature.")]
        theAuxiliaryFeature,

        [System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
        theCartographicText,

        [System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
        theCollection,

        [System.ComponentModel.Description("A pointer to a part in a whole-part relationship.")]
        theComponent,

        [System.ComponentModel.Description("A pointer to the feature(s) supported by a structure feature.")]
        theEquipment,

        [System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
        theInformation,

        [System.ComponentModel.Description("A pointer to a specific feature(s).")]
        thePositionProvider,

        [System.ComponentModel.Description("A pointer to a feature to which incidental, secondary or supplementary features are related.")]
        thePrimaryFeature,

        [System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
        theQualityInformation,

        [System.ComponentModel.Description("A pointer to a supported roofed structure.")]
        theRoofedStructure,

        [System.ComponentModel.Description("A pointer to the feature that equipment feature(s) are supported by.")]
        theStructure,

        [System.ComponentModel.Description("A pointer to the feature(s) that support a structure.")]
        theSupport,

        [System.ComponentModel.Description("A pointer to a feature that describes changes made to a dataset.")]
        theUpdate,

        [System.ComponentModel.Description("A pointer to a feature that has been updated.")]
        theUpdatedObject,
    }

    namespace Associations
    {
        namespace InformationAssociations
        {

            public class AdditionalInformation : InformationAssociation
            {
                public override string Code => "AdditionalInformation";
                public override string[] Roles => ["theInformation"];
                public AdditionalInformation()
                {
                }
            }


            public class QualityOfBathymetricDataComposition : InformationAssociation
            {
                public override string Code => "QualityOfBathymetricDataComposition";
                public override string[] Roles => ["theQualityInformation"];
                public QualityOfBathymetricDataComposition()
                {
                }
            }


            public class SpatialAssociation : InformationAssociation
            {
                public override string Code => "SpatialAssociation";
                public override string[] Roles => ["theQualityInformation"];
                public SpatialAssociation()
                {
                }
            }

        }
        namespace FeatureAssociations
        {
            using S100Framework.DomainModel.S101.FeatureTypes;

            public class AidsToNavigationAssociation : FeatureAssociation
            {
                public override string Code => "AidsToNavigationAssociation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public AidsToNavigationAssociation()
                {
                }

                public Type[] theCollections => [typeof(DeepWaterRoute), typeof(FairwaySystem), typeof(TrafficSeparationScheme), typeof(TwoWayRoute), typeof(ArchipelagicSeaLane)];
                public Type[] theComponents => [typeof(CardinalBeacon), typeof(CardinalBuoy), typeof(Daymark), typeof(EmergencyWreckMarkingBuoy), typeof(IsolatedDangerBeacon), typeof(IsolatedDangerBuoy), typeof(LateralBeacon), typeof(LateralBuoy), typeof(LightFloat), typeof(LightVessel), typeof(Pile), typeof(SafeWaterBeacon), typeof(SafeWaterBuoy), typeof(SpecialPurposeGeneralBeacon), typeof(SpecialPurposeGeneralBuoy), typeof(Building), typeof(Crane), typeof(Dolphin), typeof(FishingFacility), typeof(FortifiedStructure), typeof(Landmark), typeof(MooringBuoy), typeof(OffshorePlatform), typeof(SiloTank), typeof(WindTurbine), typeof(Bridge), typeof(Conveyor), typeof(FloatingDock), typeof(Hulk), typeof(PipelineOverhead), typeof(Pontoon), typeof(PylonBridgeSupport), typeof(ShorelineConstruction), typeof(SpanFixed), typeof(SpanOpening), typeof(StructureOverNavigableWater)];


            }


            public class ASLAggregation : FeatureAssociation
            {
                public override string Code => "ASLAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public ASLAggregation()
                {
                }

                public Type[] theCollections => [typeof(ArchipelagicSeaLane)];
                public Type[] theComponents => [typeof(ArchipelagicSeaLaneArea), typeof(ArchipelagicSeaLaneAxis)];


            }


            public class BridgeAggregation : FeatureAssociation
            {
                public override string Code => "BridgeAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public BridgeAggregation()
                {
                }

                public Type[] theCollections => [typeof(Bridge)];
                public Type[] theComponents => [typeof(SpanFixed), typeof(SpanOpening), typeof(Pontoon), typeof(PylonBridgeSupport)];


            }


            public class CautionAreaAssociation : FeatureAssociation
            {
                public override string Code => "CautionAreaAssociation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public CautionAreaAssociation()
                {
                }

                public Type[] theCollections => [typeof(CautionArea)];
                public Type[] theComponents => [typeof(ArchipelagicSeaLane), typeof(TrafficSeparationScheme)];


            }


            public class DeepWaterRouteAggregation : FeatureAssociation
            {
                public override string Code => "DeepWaterRouteAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public DeepWaterRouteAggregation()
                {
                }

                public Type[] theCollections => [typeof(DeepWaterRoute)];
                public Type[] theComponents => [typeof(DeepWaterRouteCentreline), typeof(DeepWaterRoutePart)];


            }


            public class FairwayAggregation : FeatureAssociation
            {
                public override string Code => "FairwayAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public FairwayAggregation()
                {
                }

                public Type[] theCollections => [typeof(FairwaySystem)];
                public Type[] theComponents => [typeof(Fairway)];


            }


            public class FairwayAuxiliary : FeatureAssociation
            {
                public override string Code => "FairwayAuxiliary";
                public override string[] Roles => ["thePrimaryFeature", "theAuxiliaryFeature"];
                public FairwayAuxiliary()
                {
                }

                public Type[] thePrimaryFeatures => [typeof(Fairway)];
                public Type[] theAuxiliaryFeatures => [typeof(CardinalBeacon), typeof(CardinalBuoy), typeof(CautionArea), typeof(Daymark), typeof(DredgedArea), typeof(IsolatedDangerBeacon), typeof(IsolatedDangerBuoy), typeof(LateralBeacon), typeof(LateralBuoy), typeof(LightFloat), typeof(LightVessel), typeof(Landmark), typeof(Pile), typeof(RangeSystem), typeof(RecommendedRouteCentreline), typeof(RecommendedTrack), typeof(RestrictedArea), typeof(SafeWaterBeacon), typeof(SafeWaterBuoy), typeof(SpecialPurposeGeneralBeacon), typeof(SpecialPurposeGeneralBuoy), typeof(SweptArea)];


            }


            public class IslandAggregation : FeatureAssociation
            {
                public override string Code => "IslandAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public IslandAggregation()
                {
                }

                public Type[] theCollections => [typeof(IslandGroup)];
                public Type[] theComponents => [typeof(LandArea), typeof(IslandGroup)];


            }


            public class MooringTrotAggregation : FeatureAssociation
            {
                public override string Code => "MooringTrotAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public MooringTrotAggregation()
                {
                }

                public Type[] theCollections => [typeof(MooringTrot)];
                public Type[] theComponents => [typeof(Berth), typeof(CableSubmarine), typeof(MooringBuoy), typeof(Obstruction)];


            }


            public class PilotageDistrictAssociation : FeatureAssociation
            {
                public override string Code => "PilotageDistrictAssociation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public PilotageDistrictAssociation()
                {
                }

                public Type[] theCollections => [typeof(PilotageDistrict)];
                public Type[] theComponents => [typeof(PilotBoardingPlace)];


            }


            public class RangeSystemAggregation : FeatureAssociation
            {
                public override string Code => "RangeSystemAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public RangeSystemAggregation()
                {
                }

                public Type[] theCollections => [typeof(RangeSystem)];
                public Type[] theComponents => [typeof(CardinalBeacon), typeof(Building), typeof(Daymark), typeof(Dolphin), typeof(FortifiedStructure), typeof(IsolatedDangerBeacon), typeof(Landmark), typeof(LateralBeacon), typeof(LightAllAround), typeof(LightSectored), typeof(NavigationLine), typeof(Pile), typeof(RadarTransponderBeacon), typeof(RangeSystem), typeof(RecommendedRouteCentreline), typeof(RecommendedTrack), typeof(SafeWaterBeacon), typeof(SiloTank), typeof(SpecialPurposeGeneralBeacon)];


            }


            public class RoofedStructureAggregation : FeatureAssociation
            {
                public override string Code => "RoofedStructureAggregation";
                public override string[] Roles => ["theRoofedStructure", "theSupport"];
                public RoofedStructureAggregation()
                {
                }

                public Type[] theRoofedStructures => [typeof(StructureOverNavigableWater)];
                public Type[] theSupports => [typeof(PylonBridgeSupport)];


            }


            public class StructureEquipment : FeatureAssociation
            {
                public override string Code => "StructureEquipment";
                public override string[] Roles => ["theStructure", "theEquipment"];
                public StructureEquipment()
                {
                }

                public Type[] theStructures => [typeof(Building), typeof(Landmark), typeof(OffshorePlatform), typeof(Bridge), typeof(Crane), typeof(CardinalBeacon), typeof(CardinalBuoy), typeof(Conveyor), typeof(Dolphin), typeof(EmergencyWreckMarkingBuoy), typeof(FishingFacility), typeof(FloatingDock), typeof(FortifiedStructure), typeof(Hulk), typeof(InstallationBuoy), typeof(IsolatedDangerBeacon), typeof(IsolatedDangerBuoy), typeof(LateralBeacon), typeof(LateralBuoy), typeof(LightFloat), typeof(LightVessel), typeof(MooringBuoy), typeof(Pile), typeof(PipelineOverhead), typeof(Pontoon), typeof(PylonBridgeSupport), typeof(SafeWaterBeacon), typeof(SafeWaterBuoy), typeof(ShorelineConstruction), typeof(SiloTank), typeof(SpanFixed), typeof(SpanOpening), typeof(SpecialPurposeGeneralBeacon), typeof(SpecialPurposeGeneralBuoy), typeof(StructureOverNavigableWater), typeof(WindTurbine), typeof(Wreck), typeof(Daymark), typeof(LightAllAround), typeof(LightSectored), typeof(CableOverhead)];
                public Type[] theEquipments => [typeof(Daymark), typeof(DistanceMark), typeof(FogSignal), typeof(Helipad), typeof(LightAllAround), typeof(LightFogDetector), typeof(PhysicalAISAidToNavigation), typeof(RadarTransponderBeacon), typeof(Retroreflector), typeof(SignalStationTraffic), typeof(SignalStationWarning), typeof(LightSectored), typeof(LightAirObstruction), typeof(RadarReflector), typeof(Bollard)];


            }


            public class TextAssociation : FeatureAssociation
            {
                public override string Code => "TextAssociation";
                public override string[] Roles => ["theCartographicText", "thePositionProvider"];
                public TextAssociation()
                {
                }

                public Type[] theCartographicTexts => [typeof(TextPlacement)];
                public Type[] thePositionProviders => [typeof(AdministrationArea), typeof(AirportAirfield), typeof(AnchorBerth), typeof(AnchorageArea), typeof(ArchipelagicSeaLane), typeof(ArchipelagicSeaLaneArea), typeof(ArchipelagicSeaLaneAxis), typeof(Berth), typeof(Bollard), typeof(Bridge), typeof(Building), typeof(BuiltUpArea), typeof(CableArea), typeof(CableOverhead), typeof(CableSubmarine), typeof(Canal), typeof(CardinalBuoy), typeof(CardinalBeacon), typeof(CargoTranshipmentArea), typeof(Causeway), typeof(Chart1Feature), typeof(Checkpoint), typeof(CoastGuardStation), typeof(Coastline), typeof(CollisionRegulationsLimit), typeof(ContinentalShelfArea), typeof(Conveyor), typeof(Crane), typeof(CurrentNonGravitational), typeof(Dam), typeof(Daymark), typeof(DeepWaterRoute), typeof(DeepWaterRouteCentreline), typeof(DeepWaterRoutePart), typeof(DistanceMark), typeof(DockArea), typeof(Dolphin), typeof(DredgedArea), typeof(DryDock), typeof(DumpingGround), typeof(Dyke), typeof(EmergencyWreckMarkingBuoy), typeof(Fairway), typeof(FairwaySystem), typeof(FenceWall), typeof(FerryRoute), typeof(FisheryZone), typeof(FishingFacility), typeof(FishingGround), typeof(FloatingDock), typeof(FogSignal), typeof(FortifiedStructure), typeof(FoulGround), typeof(FreePortArea), typeof(Gate), typeof(Gridiron), typeof(HarbourAreaAdministrative), typeof(HarbourFacility), typeof(Helipad), typeof(Hulk), typeof(IceArea), typeof(InformationArea), typeof(InstallationBuoy), typeof(IslandGroup), typeof(IsolatedDangerBeacon), typeof(IsolatedDangerBuoy), typeof(Lake), typeof(LandArea), typeof(LandElevation), typeof(LandRegion), typeof(Landmark), typeof(LateralBeacon), typeof(LateralBuoy), typeof(LightAirObstruction), typeof(LightAllAround), typeof(LightFloat), typeof(LightFogDetector), typeof(LightSectored), typeof(LightVessel), typeof(LocalMagneticAnomaly), typeof(LockBasin), typeof(LogPond), typeof(MarineFarmCulture), typeof(MarinePollutionRegulationsArea), typeof(MilitaryPracticeArea), typeof(MooringArea), typeof(MooringBuoy), typeof(MooringTrot), typeof(Obstruction), typeof(OffshorePlatform), typeof(OffshoreProductionArea), typeof(OilBarrier), typeof(PhysicalAISAidToNavigation), typeof(Pile), typeof(PilotBoardingPlace), typeof(PilotageDistrict), typeof(PipelineOverhead), typeof(PipelineSubmarineOnLand), typeof(Pontoon), typeof(PrecautionaryArea), typeof(ProductionStorageArea), typeof(PylonBridgeSupport), typeof(RadarLine), typeof(RadarRange), typeof(RadarStation), typeof(RadarTransponderBeacon), typeof(RadioCallingInPoint), typeof(RadioStation), typeof(Railway), typeof(RangeSystem), typeof(Rapids), typeof(RecommendedRouteCentreline), typeof(RecommendedTrack), typeof(RescueStation), typeof(RestrictedArea), typeof(River), typeof(Road), typeof(Runway), typeof(SafeWaterBeacon), typeof(SafeWaterBuoy), typeof(SeaAreaNamedWaterArea), typeof(SeabedArea), typeof(Seagrass), typeof(SeaplaneLandingArea), typeof(ShorelineConstruction), typeof(SignalStationTraffic), typeof(SignalStationWarning), typeof(SiloTank), typeof(SlopeTopline), typeof(SlopingGround), typeof(SmallCraftFacility), typeof(Sounding), typeof(SpanFixed), typeof(SpanOpening), typeof(SpecialPurposeGeneralBeacon), typeof(SpecialPurposeGeneralBuoy), typeof(Spring), typeof(StructureOverNavigableWater), typeof(SubmarinePipelineArea), typeof(SubmarineTransitLane), typeof(SweptArea), typeof(TidalStreamFloodEbb), typeof(TidalStreamPanelData), typeof(Tideway), typeof(TrafficSeparationScheme), typeof(Tunnel), typeof(TwoWayRoute), typeof(UnderwaterAwashRock), typeof(Vegetation), typeof(VesselTrafficServiceArea), typeof(VirtualAISAidToNavigation), typeof(WaterTurbulence), typeof(Waterfall), typeof(WeedKelp), typeof(WindTurbine), typeof(Wreck)];


            }


            public class TrafficSeparationSchemeAggregation : FeatureAssociation
            {
                public override string Code => "TrafficSeparationSchemeAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public TrafficSeparationSchemeAggregation()
                {
                }

                public Type[] theCollections => [typeof(TrafficSeparationScheme)];
                public Type[] theComponents => [typeof(DeepWaterRoute), typeof(DeepWaterRouteCentreline), typeof(DeepWaterRoutePart), typeof(InshoreTrafficZone), typeof(PrecautionaryArea), typeof(RestrictedArea), typeof(SeparationZoneOrLine), typeof(TrafficSeparationScheme), typeof(TrafficSeparationSchemeBoundary), typeof(TrafficSeparationSchemeCrossing), typeof(TrafficSeparationSchemeLanePart), typeof(TrafficSeparationSchemeRoundabout), typeof(TwoWayRoute), typeof(TwoWayRoutePart)];


            }


            public class TwoWayRouteAggregation : FeatureAssociation
            {
                public override string Code => "TwoWayRouteAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public TwoWayRouteAggregation()
                {
                }

                public Type[] theCollections => [typeof(TwoWayRoute)];
                public Type[] theComponents => [typeof(TwoWayRoutePart)];


            }


            public class UpdateAggregation : FeatureAssociation
            {
                public override string Code => "UpdateAggregation";
                public override string[] Roles => ["theCollection", "theComponent"];
                public UpdateAggregation()
                {
                }

                public Type[] theCollections => [typeof(UpdateInformation)];
                public Type[] theComponents => [typeof(UpdateInformation)];


            }


            public class UpdatedInformation : FeatureAssociation
            {
                public override string Code => "UpdatedInformation";
                public override string[] Roles => ["theUpdate", "theUpdatedObject"];
                public UpdatedInformation()
                {
                }

                public Type[] theUpdates => [typeof(UpdateInformation), typeof(AdministrationArea), typeof(AirportAirfield), typeof(AnchorBerth), typeof(AnchorageArea), typeof(ArchipelagicSeaLane), typeof(ArchipelagicSeaLaneArea), typeof(ArchipelagicSeaLaneAxis), typeof(Berth), typeof(Bollard), typeof(Bridge), typeof(Building), typeof(BuiltUpArea), typeof(CableArea), typeof(CableOverhead), typeof(CableSubmarine), typeof(Canal), typeof(CardinalBeacon), typeof(CardinalBuoy), typeof(CargoTranshipmentArea), typeof(Causeway), typeof(CautionArea), typeof(Checkpoint), typeof(CoastGuardStation), typeof(Coastline), typeof(CollisionRegulationsLimit), typeof(ContiguousZone), typeof(ContinentalShelfArea), typeof(Conveyor), typeof(Crane), typeof(CurrentNonGravitational), typeof(CustomZone), typeof(Dam), typeof(Daymark), typeof(DeepWaterRoute), typeof(DeepWaterRouteCentreline), typeof(DeepWaterRoutePart), typeof(DepthArea), typeof(DepthContour), typeof(DepthNoBottomFound), typeof(DiscolouredWater), typeof(DistanceMark), typeof(DockArea), typeof(Dolphin), typeof(DredgedArea), typeof(DryDock), typeof(DumpingGround), typeof(Dyke), typeof(EmergencyWreckMarkingBuoy), typeof(ExclusiveEconomicZone), typeof(Fairway), typeof(FairwaySystem), typeof(FenceWall), typeof(FerryRoute), typeof(FisheryZone), typeof(FishingFacility), typeof(FishingGround), typeof(FloatingDock), typeof(FogSignal), typeof(FortifiedStructure), typeof(FoulGround), typeof(FreePortArea), typeof(Gate), typeof(Gridiron), typeof(HarbourAreaAdministrative), typeof(HarbourFacility), typeof(Helipad), typeof(Hulk), typeof(IceArea), typeof(InformationArea), typeof(InshoreTrafficZone), typeof(InstallationBuoy), typeof(IslandGroup), typeof(IsolatedDangerBeacon), typeof(IsolatedDangerBuoy), typeof(Lake), typeof(LandArea), typeof(LandElevation), typeof(LandRegion), typeof(Landmark), typeof(LateralBeacon), typeof(LateralBuoy), typeof(LightAirObstruction), typeof(LightAllAround), typeof(LightFloat), typeof(LightFogDetector), typeof(LightSectored), typeof(LightVessel), typeof(LocalDirectionOfBuoyage), typeof(LocalMagneticAnomaly), typeof(LockBasin), typeof(LogPond), typeof(MagneticVariation), typeof(MarineFarmCulture), typeof(MarinePollutionRegulationsArea), typeof(MilitaryPracticeArea), typeof(MooringArea), typeof(MooringBuoy), typeof(MooringTrot), typeof(NavigationLine), typeof(NavigationalSystemOfMarks), typeof(Obstruction), typeof(OffshorePlatform), typeof(OffshoreProductionArea), typeof(OilBarrier), typeof(PhysicalAISAidToNavigation), typeof(Pile), typeof(PilotBoardingPlace), typeof(PilotageDistrict), typeof(PipelineOverhead), typeof(PipelineSubmarineOnLand), typeof(Pontoon), typeof(PrecautionaryArea), typeof(ProductionStorageArea), typeof(PylonBridgeSupport), typeof(QualityOfBathymetricData), typeof(QualityOfNonBathymetricData), typeof(QualityOfSurvey), typeof(RadarLine), typeof(RadarRange), typeof(RadarReflector), typeof(RadarStation), typeof(RadarTransponderBeacon), typeof(RadioCallingInPoint), typeof(RadioStation), typeof(Railway), typeof(RangeSystem), typeof(Rapids), typeof(RecommendedRouteCentreline), typeof(RecommendedTrack), typeof(RecommendedTrafficLanePart), typeof(RescueStation), typeof(RestrictedArea), typeof(Retroreflector), typeof(River), typeof(Road), typeof(Runway), typeof(SafeWaterBeacon), typeof(SafeWaterBuoy), typeof(Sandwave), typeof(SeaAreaNamedWaterArea), typeof(SeabedArea), typeof(Seagrass), typeof(SeaplaneLandingArea), typeof(SeparationZoneOrLine), typeof(ShorelineConstruction), typeof(SignalStationTraffic), typeof(SignalStationWarning), typeof(SiloTank), typeof(SmallCraftFacility), typeof(SlopeTopline), typeof(SlopingGround), typeof(Sounding), typeof(SoundingDatum), typeof(SpanFixed), typeof(SpanOpening), typeof(SpecialPurposeGeneralBeacon), typeof(SpecialPurposeGeneralBuoy), typeof(Spring), typeof(StraightTerritorialSeaBaseline), typeof(StructureOverNavigableWater), typeof(SubmarinePipelineArea), typeof(SubmarineTransitLane), typeof(SweptArea), typeof(TerritorialSeaArea), typeof(TidalStreamPanelData), typeof(TidalStreamFloodEbb), typeof(Tideway), typeof(TrafficSeparationScheme), typeof(TrafficSeparationSchemeBoundary), typeof(TrafficSeparationSchemeCrossing), typeof(TrafficSeparationSchemeLanePart), typeof(TrafficSeparationSchemeRoundabout), typeof(Tunnel), typeof(TwoWayRoute), typeof(TwoWayRoutePart), typeof(UnderwaterAwashRock), typeof(UnsurveyedArea), typeof(Vegetation), typeof(VerticalDatumOfData), typeof(VesselTrafficServiceArea), typeof(VirtualAISAidToNavigation), typeof(WaterTurbulence), typeof(Waterfall), typeof(WeedKelp), typeof(WindTurbine), typeof(Wreck)];
                public Type[] theUpdatedObjects => [];


            }

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
        public partial class ContactDetails : InformationTypeBase
        {
            public String callSign { get; set; } = string.Empty;
            public List<String> communicationChannel { get; set; } = [];
            public String contactInstructions { get; set; } = string.Empty;
            public fixedDateRange? fixedDateRange { get; set; }
            public List<frequencyPair> frequencyPair { get; set; } = [];
            public String mMSICode { get; set; } = string.Empty;
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<telecommunications> telecommunications { get; set; } = [];
            public override string Code => nameof(ContactDetails);

            public ContactDetails()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ServiceHours : InformationTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [Required()]
            public List<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ServiceHours);

            public ServiceHours()
            {
                scheduleByDayOfWeek = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NonStandardWorkingDay : InformationTypeBase
        {
            public List<DateOnly> dateFixed { get; set; } = [];
            public List<String> dateVariable { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(NonStandardWorkingDay);

            public NonStandardWorkingDay()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NauticalInformation : InformationTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(NauticalInformation);

            public NauticalInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpatialQuality : InformationTypeBase
        {
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;
            public List<spatialAccuracy> spatialAccuracy { get; set; } = [];
            public override string Code => nameof(SpatialQuality);

            public SpatialQuality()
            {
            }
        }
    }

    namespace FeatureTypes
    {
        using ComplexAttributes;
        using InformationTypes;
        using DomainModel;


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class QualityOfNonBathymetricData : FeatureTypeBase
        {
            public categoryOfTemporalVariation? categoryOfTemporalVariation { get; set; } = default;
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            [Required()]
            public horizontalPositionUncertainty horizontalPositionUncertainty { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? orientationUncertainty { get; set; } = default;
            public surveyDateRange? surveyDateRange { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(QualityOfNonBathymetricData);

            public QualityOfNonBathymetricData()
            {
                horizontalPositionUncertainty = new horizontalPositionUncertainty()
                {
                    uncertaintyFixed = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DataCoverage : FeatureTypeBase
        {
            public Int32? drawingIndex { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Int32 maximumDisplayScale { get; set; }

            [Required()]
            public Int32 minimumDisplayScale { get; set; }

            [Required()]
            public Int32 optimumDisplayScale { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DataCoverage);

            public DataCoverage()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NavigationalSystemOfMarks : FeatureTypeBase
        {
            [Required()]
            public marksNavigationalSystemOf marksNavigationalSystemOf { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(NavigationalSystemOfMarks);

            public NavigationalSystemOfMarks()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LocalDirectionOfBuoyage : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public marksNavigationalSystemOf marksNavigationalSystemOf { get; set; }

            [Required()]
            public Decimal orientationValue { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LocalDirectionOfBuoyage);

            public LocalDirectionOfBuoyage()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class QualityOfBathymetricData : FeatureTypeBase
        {
            [Required()]
            public categoryOfTemporalVariation categoryOfTemporalVariation { get; set; }

            [Required()]
            public dataAssessment dataAssessment { get; set; }
            public Decimal? depthRangeMaximumValue { get; set; } = default;
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [Required()]
            public featuresDetected featuresDetected { get; set; }

            [Required()]
            public Boolean fullSeafloorCoverageAchieved { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public surveyDateRange? surveyDateRange { get; set; }

            [Required()]
            public List<zoneOfConfidence> zoneOfConfidence { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(QualityOfBathymetricData);

            public QualityOfBathymetricData()
            {
                featuresDetected = new featuresDetected()
                {
                    leastDepthOfDetectedFeaturesMeasured = default(Boolean),
                    significantFeaturesDetected = default(Boolean),
                };
                zoneOfConfidence = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SoundingDatum : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public verticalDatum verticalDatum { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SoundingDatum);

            public SoundingDatum()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class VerticalDatumOfData : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public verticalDatum verticalDatum { get; set; }
            public List<information> information { get; set; } = [];
            public override string Code => nameof(VerticalDatumOfData);

            public VerticalDatumOfData()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class QualityOfSurvey : FeatureTypeBase
        {
            public Decimal? depthRangeMaximumValue { get; set; } = default;
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public featuresDetected? featuresDetected { get; set; }
            public Boolean? fullSeafloorCoverageAchieved { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? lineSpacingMaximum { get; set; } = default;
            public Int32? lineSpacingMinimum { get; set; } = default;
            public Int32? measurementDistanceMaximum { get; set; } = default;
            public Int32? measurementDistanceMinimum { get; set; } = default;
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public Int32? scaleValueMaximum { get; set; } = default;
            public Int32? scaleValueMinimum { get; set; } = default;
            public String surveyAuthority { get; set; } = string.Empty;

            [Required()]
            public surveyDateRange surveyDateRange { get; set; }

            [Required()]
            public List<surveyType> surveyType { get; set; }
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(QualityOfSurvey);

            public QualityOfSurvey()
            {
                surveyAuthority = string.Empty;
                surveyDateRange = new surveyDateRange()
                {
                    dateEnd = default(DateOnly),
                };
                surveyType = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class UpdateInformation : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Int32 updateNumber { get; set; }

            [Required()]
            public updateType updateType { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public String source { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(UpdateInformation);

            public UpdateInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MagneticVariation : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public DateOnly referenceYearForMagneticVariation { get; set; }

            [Required()]
            public Decimal valueOfAnnualChangeInMagneticVariation { get; set; }

            [Required()]
            public Decimal valueOfMagneticVariation { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(MagneticVariation);

            public MagneticVariation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LocalMagneticAnomaly : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;

            [Required()]
            public List<valueOfLocalMagneticAnomaly> valueOfLocalMagneticAnomaly { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LocalMagneticAnomaly);

            public LocalMagneticAnomaly()
            {
                valueOfLocalMagneticAnomaly = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Coastline : FeatureTypeBase
        {
            public categoryOfCoastline? categoryOfCoastline { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Coastline);

            public Coastline()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LandArea : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public status? status { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LandArea);

            public LandArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IslandGroup : FeatureTypeBase
        {
            [Required()]
            public List<featureName> featureName { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(IslandGroup);

            public IslandGroup()
            {
                featureName = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LandElevation : FeatureTypeBase
        {
            [Required()]
            public Decimal elevation { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LandElevation);

            public LandElevation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class River : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public status? status { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(River);

            public River()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Rapids : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Rapids);

            public Rapids()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Waterfall : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Waterfall);

            public Waterfall()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Lake : FeatureTypeBase
        {
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public status? status { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Lake);

            public Lake()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LandRegion : FeatureTypeBase
        {
            public List<categoryOfLandRegion> categoryOfLandRegion { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LandRegion);

            public LandRegion()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Vegetation : FeatureTypeBase
        {
            [Required()]
            public categoryOfVegetation categoryOfVegetation { get; set; }
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Vegetation);

            public Vegetation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IceArea : FeatureTypeBase
        {
            [Required()]
            public categoryOfIce categoryOfIce { get; set; }
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(IceArea);

            public IceArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SlopingGround : FeatureTypeBase
        {
            public categoryOfSlope? categoryOfSlope { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SlopingGround);

            public SlopingGround()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SlopeTopline : FeatureTypeBase
        {
            public categoryOfSlope? categoryOfSlope { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SlopeTopline);

            public SlopeTopline()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Tideway : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Tideway);

            public Tideway()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class BuiltUpArea : FeatureTypeBase
        {
            public categoryOfBuiltUpArea? categoryOfBuiltUpArea { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inTheWater { get; set; } = default;
            public override string Code => nameof(BuiltUpArea);

            public BuiltUpArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Building : FeatureTypeBase
        {
            public buildingShape? buildingShape { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<function> function { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inTheWater { get; set; } = default;
            public override string Code => nameof(Building);

            public Building()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AirportAirfield : FeatureTypeBase
        {
            public List<categoryOfAirportAirfield> categoryOfAirportAirfield { get; set; } = [];
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(AirportAirfield);

            public AirportAirfield()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Runway : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Runway);

            public Runway()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Helipad : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Helipad);

            public Helipad()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Bridge : FeatureTypeBase
        {
            public bridgeConstruction? bridgeConstruction { get; set; } = default;
            public List<bridgeFunction> bridgeFunction { get; set; } = [];
            public categoryOfOpeningBridge? categoryOfOpeningBridge { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? openingBridge { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Bridge);

            public Bridge()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpanFixed : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public verticalClearanceFixed verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(SpanFixed);

            public SpanFixed()
            {
                verticalClearanceFixed = new verticalClearanceFixed()
                {
                    verticalClearanceValue = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpanOpening : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public verticalClearanceClosed verticalClearanceClosed { get; set; }

            [Required()]
            public verticalClearanceOpen verticalClearanceOpen { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(SpanOpening);

            public SpanOpening()
            {
                verticalClearanceClosed = new verticalClearanceClosed()
                {
                    verticalClearanceValue = default(Decimal),
                };
                verticalClearanceOpen = new verticalClearanceOpen()
                {
                    verticalClearanceUnlimited = default(Boolean),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Conveyor : FeatureTypeBase
        {
            public categoryOfConveyor? categoryOfConveyor { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? liftingCapacity { get; set; } = default;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<product> product { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Conveyor);

            public Conveyor()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableOverhead : FeatureTypeBase
        {
            public categoryOfCable? categoryOfCable { get; set; } = default;
            public condition? condition { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? iceFactor { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public verticalClearanceSafe? verticalClearanceSafe { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CableOverhead);

            public CableOverhead()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PipelineOverhead : FeatureTypeBase
        {
            public categoryOfPipelinePipe? categoryOfPipelinePipe { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<product> product { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(PipelineOverhead);

            public PipelineOverhead()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PylonBridgeSupport : FeatureTypeBase
        {
            [Required()]
            public categoryOfPylon categoryOfPylon { get; set; }
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(PylonBridgeSupport);

            public PylonBridgeSupport()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FenceWall : FeatureTypeBase
        {
            public categoryOfFence? categoryOfFence { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FenceWall);

            public FenceWall()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Railway : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Railway);

            public Railway()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Road : FeatureTypeBase
        {
            public categoryOfRoad? categoryOfRoad { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Road);

            public Road()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Tunnel : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Tunnel);

            public Tunnel()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Landmark : FeatureTypeBase
        {
            [Required()]
            public List<categoryOfLandmark> categoryOfLandmark { get; set; }
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; } = [];
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public List<function> function { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;

            [Required()]
            public visualProminence visualProminence { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inTheWater { get; set; } = default;
            public override string Code => nameof(Landmark);

            public Landmark()
            {
                categoryOfLandmark = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SiloTank : FeatureTypeBase
        {
            public buildingShape? buildingShape { get; set; } = default;
            public categoryOfSiloTank? categoryOfSiloTank { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<product> product { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inTheWater { get; set; } = default;
            public override string Code => nameof(SiloTank);

            public SiloTank()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class WindTurbine : FeatureTypeBase
        {
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inTheWater { get; set; } = default;
            public override string Code => nameof(WindTurbine);

            public WindTurbine()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FortifiedStructure : FeatureTypeBase
        {
            public categoryOfFortifiedStructure? categoryOfFortifiedStructure { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inTheWater { get; set; } = default;
            public override string Code => nameof(FortifiedStructure);

            public FortifiedStructure()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ProductionStorageArea : FeatureTypeBase
        {
            [Required()]
            public categoryOfProductionArea categoryOfProductionArea { get; set; }
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<product> product { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(ProductionStorageArea);

            public ProductionStorageArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Checkpoint : FeatureTypeBase
        {
            public categoryOfCheckpoint? categoryOfCheckpoint { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Checkpoint);

            public Checkpoint()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Hulk : FeatureTypeBase
        {
            public List<categoryOfHulk> categoryOfHulk { get; set; } = [];
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Hulk);

            public Hulk()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Pile : FeatureTypeBase
        {
            public categoryOfPile? categoryOfPile { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Pile);

            public Pile()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Dyke : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Dyke);

            public Dyke()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ShorelineConstruction : FeatureTypeBase
        {
            public categoryOfShorelineConstruction? categoryOfShorelineConstruction { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ShorelineConstruction);

            public ShorelineConstruction()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class StructureOverNavigableWater : FeatureTypeBase
        {
            public List<categoryOfStructure> categoryOfStructure { get; set; } = [];
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;

            [Required()]
            public horizontalClearanceFixed horizontalClearanceFixed { get; set; }
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public product? product { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];

            [Required()]
            public verticalClearanceFixed verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(StructureOverNavigableWater);

            public StructureOverNavigableWater()
            {
                horizontalClearanceFixed = new horizontalClearanceFixed()
                {
                    horizontalClearanceValue = default(Decimal),
                };
                verticalClearanceFixed = new verticalClearanceFixed()
                {
                    verticalClearanceValue = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Causeway : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Causeway);

            public Causeway()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Canal : FeatureTypeBase
        {
            public categoryOfCanal? categoryOfCanal { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Canal);

            public Canal()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DistanceMark : FeatureTypeBase
        {
            [Required()]
            public Boolean distanceMarkVisible { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public measuredDistanceValue measuredDistanceValue { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DistanceMark);

            public DistanceMark()
            {
                measuredDistanceValue = new measuredDistanceValue()
                {
                    distanceUnitOfMeasurement = default(distanceUnitOfMeasurement),
                    waterwayDistance = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Gate : FeatureTypeBase
        {
            public categoryOfGate? categoryOfGate { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public horizontalClearanceOpen? horizontalClearanceOpen { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public verticalClearanceOpen? verticalClearanceOpen { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Gate);

            public Gate()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Dam : FeatureTypeBase
        {
            public categoryOfDam? categoryOfDam { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Dam);

            public Dam()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Crane : FeatureTypeBase
        {
            public categoryOfCrane? categoryOfCrane { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? liftingCapacity { get; set; } = default;
            public orientation? orientation { get; set; }
            public Boolean? radarConspicuous { get; set; } = default;
            public Decimal? radius { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Boolean? inTheWater { get; set; } = default;
            public override string Code => nameof(Crane);

            public Crane()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Berth : FeatureTypeBase
        {
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [Required()]
            public List<featureName> featureName { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalClearanceLength { get; set; } = default;
            public Decimal? horizontalClearanceWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Decimal? minimumBerthDepth { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Berth);

            public Berth()
            {
                featureName = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Dolphin : FeatureTypeBase
        {
            [Required()]
            public List<categoryOfDolphin> categoryOfDolphin { get; set; }
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Dolphin);

            public Dolphin()
            {
                categoryOfDolphin = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Bollard : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Bollard);

            public Bollard()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DryDock : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalClearanceLength { get; set; } = default;
            public Decimal? horizontalClearanceWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DryDock);

            public DryDock()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FloatingDock : FeatureTypeBase
        {
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalClearanceLength { get; set; } = default;
            public Decimal? horizontalClearanceWidth { get; set; } = default;
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? liftingCapacity { get; set; } = default;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(FloatingDock);

            public FloatingDock()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Pontoon : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Pontoon);

            public Pontoon()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DockArea : FeatureTypeBase
        {
            public categoryOfDock? categoryOfDock { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public Decimal? horizontalClearanceLength { get; set; } = default;
            public Decimal? horizontalClearanceWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DockArea);

            public DockArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Gridiron : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Gridiron);

            public Gridiron()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LockBasin : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LockBasin);

            public LockBasin()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MooringTrot : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(MooringTrot);

            public MooringTrot()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeaAreaNamedWaterArea : FeatureTypeBase
        {
            public categoryOfSeaArea? categoryOfSeaArea { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SeaAreaNamedWaterArea);

            public SeaAreaNamedWaterArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TidalStreamFloodEbb : FeatureTypeBase
        {
            [Required()]
            public categoryOfTidalStream categoryOfTidalStream { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public orientation orientation { get; set; }

            [Required()]
            public speed speed { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TidalStreamFloodEbb);

            public TidalStreamFloodEbb()
            {
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
        public partial class CurrentNonGravitational : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public orientation orientation { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [Required()]
            public speed speed { get; set; }
            public status? status { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CurrentNonGravitational);

            public CurrentNonGravitational()
            {
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
        public partial class WaterTurbulence : FeatureTypeBase
        {
            [Required()]
            public categoryOfWaterTurbulence categoryOfWaterTurbulence { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(WaterTurbulence);

            public WaterTurbulence()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TidalStreamPanelData : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String stationName { get; set; } = string.Empty;
            public String stationNumber { get; set; } = string.Empty;

            [Required()]
            public List<tidalStreamPanelValues> tidalStreamPanelValues { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TidalStreamPanelData);

            public TidalStreamPanelData()
            {
                stationName = string.Empty;
                tidalStreamPanelValues = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Sounding : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public status? status { get; set; } = default;
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Sounding);

            public Sounding()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DredgedArea : FeatureTypeBase
        {
            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }
            public Decimal? depthRangeMaximumValue { get; set; } = default;
            public DateOnly? dredgedDate { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DredgedArea);

            public DredgedArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SweptArea : FeatureTypeBase
        {
            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? sweptDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SweptArea);

            public SweptArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DepthContour : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Decimal valueOfDepthContour { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DepthContour);

            public DepthContour()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DepthArea : FeatureTypeBase
        {
            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }

            [Required()]
            public Decimal depthRangeMaximumValue { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DepthArea);

            public DepthArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DepthNoBottomFound : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DepthNoBottomFound);

            public DepthNoBottomFound()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class UnsurveyedArea : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(UnsurveyedArea);

            public UnsurveyedArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeabedArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public List<surfaceCharacteristics> surfaceCharacteristics { get; set; }
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SeabedArea);

            public SeabedArea()
            {
                surfaceCharacteristics = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class WeedKelp : FeatureTypeBase
        {
            public categoryOfWeedKelp? categoryOfWeedKelp { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(WeedKelp);

            public WeedKelp()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Seagrass : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Seagrass);

            public Seagrass()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Sandwave : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Sandwave);

            public Sandwave()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Spring : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Spring);

            public Spring()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class UnderwaterAwashRock : FeatureTypeBase
        {
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public natureOfSurface? natureOfSurface { get; set; } = default;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public status? status { get; set; } = default;
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public Decimal valueOfSounding { get; set; }

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [Required()]
            public Decimal surroundingDepth { get; set; }
            public override string Code => nameof(UnderwaterAwashRock);

            public UnderwaterAwashRock()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Wreck : FeatureTypeBase
        {
            public categoryOfWreck? categoryOfWreck { get; set; } = default;
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Decimal? valueOfSounding { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [Required()]
            public Decimal surroundingDepth { get; set; }
            public override string Code => nameof(Wreck);

            public Wreck()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Obstruction : FeatureTypeBase
        {
            public categoryOfObstruction? categoryOfObstruction { get; set; } = default;
            public condition? condition { get; set; } = default;
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public List<natureOfSurface> natureOfSurface { get; set; } = [];
            public List<product> product { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Decimal? valueOfSounding { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [Required()]
            public Decimal surroundingDepth { get; set; }
            public override string Code => nameof(Obstruction);

            public Obstruction()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FoulGround : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public Decimal? valueOfSounding { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FoulGround);

            public FoulGround()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DiscolouredWater : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DiscolouredWater);

            public DiscolouredWater()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FishingFacility : FeatureTypeBase
        {
            public categoryOfFishingFacility? categoryOfFishingFacility { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FishingFacility);

            public FishingFacility()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MarineFarmCulture : FeatureTypeBase
        {
            public categoryOfMarineFarmCulture? categoryOfMarineFarmCulture { get; set; } = default;
            public expositionOfSounding? expositionOfSounding { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Decimal? valueOfSounding { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [Required()]
            public waterLevelEffect waterLevelEffect { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(MarineFarmCulture);

            public MarineFarmCulture()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class OffshorePlatform : FeatureTypeBase
        {
            public categoryOfOffshorePlatform? categoryOfOffshorePlatform { get; set; } = default;
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Boolean? flareStack { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<product> product { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(OffshorePlatform);

            public OffshorePlatform()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableSubmarine : FeatureTypeBase
        {
            public Decimal? buriedDepth { get; set; } = default;
            public categoryOfCable? categoryOfCable { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CableSubmarine);

            public CableSubmarine()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CableArea : FeatureTypeBase
        {
            public List<categoryOfCable> categoryOfCable { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CableArea);

            public CableArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PipelineSubmarineOnLand : FeatureTypeBase
        {
            public Decimal? buriedDepth { get; set; } = default;
            public List<categoryOfPipelinePipe> categoryOfPipelinePipe { get; set; } = [];
            public condition? condition { get; set; } = default;
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public Decimal? depthRangeMaximumValue { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<product> product { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(PipelineSubmarineOnLand);

            public PipelineSubmarineOnLand()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SubmarinePipelineArea : FeatureTypeBase
        {
            public List<categoryOfPipelinePipe> categoryOfPipelinePipe { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<product> product { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SubmarinePipelineArea);

            public SubmarinePipelineArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class OffshoreProductionArea : FeatureTypeBase
        {
            public categoryOfOffshoreProductionArea? categoryOfOffshoreProductionArea { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<product> product { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public waterLevelEffect? waterLevelEffect { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(OffshoreProductionArea);

            public OffshoreProductionArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NavigationLine : FeatureTypeBase
        {
            [Required()]
            public categoryOfNavigationLine categoryOfNavigationLine { get; set; }
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? measuredDistance { get; set; } = default;

            [Required()]
            public orientation orientation { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(NavigationLine);

            public NavigationLine()
            {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RecommendedTrack : FeatureTypeBase
        {
            [Required()]
            public Boolean basedOnFixedMarks { get; set; }
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RecommendedTrack);

            public RecommendedTrack()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RangeSystem : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RangeSystem);

            public RangeSystem()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Fairway : FeatureTypeBase
        {
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Decimal? orientationValue { get; set; } = default;
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public trafficFlow? trafficFlow { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Fairway);

            public Fairway()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FairwaySystem : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FairwaySystem);

            public FairwaySystem()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RecommendedRouteCentreline : FeatureTypeBase
        {
            [Required()]
            public Boolean basedOnFixedMarks { get; set; }
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? orientationValue { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];
            public trafficFlow? trafficFlow { get; set; } = default;
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RecommendedRouteCentreline);

            public RecommendedRouteCentreline()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TwoWayRoutePart : FeatureTypeBase
        {
            public Boolean? basedOnFixedMarks { get; set; } = default;
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TwoWayRoutePart);

            public TwoWayRoutePart()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TwoWayRoute : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TwoWayRoute);

            public TwoWayRoute()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RecommendedTrafficLanePart : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RecommendedTrafficLanePart);

            public RecommendedTrafficLanePart()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DeepWaterRouteCentreline : FeatureTypeBase
        {
            [Required()]
            public Boolean basedOnFixedMarks { get; set; }
            public Decimal? depthRangeMinimumValue { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Boolean? iMOAdopted { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DeepWaterRouteCentreline);

            public DeepWaterRouteCentreline()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DeepWaterRoutePart : FeatureTypeBase
        {
            [Required()]
            public Decimal depthRangeMinimumValue { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Boolean? iMOAdopted { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public verticalUncertainty? verticalUncertainty { get; set; }
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DeepWaterRoutePart);

            public DeepWaterRoutePart()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DeepWaterRoute : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Boolean? iMOAdopted { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DeepWaterRoute);

            public DeepWaterRoute()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InshoreTrafficZone : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(InshoreTrafficZone);

            public InshoreTrafficZone()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PrecautionaryArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Boolean? iMOAdopted { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;

            [Required()]
            public List<information> information { get; set; }
            public override string Code => nameof(PrecautionaryArea);

            public PrecautionaryArea()
            {
                information = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeLanePart : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? orientationValue { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TrafficSeparationSchemeLanePart);

            public TrafficSeparationSchemeLanePart()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeparationZoneOrLine : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SeparationZoneOrLine);

            public SeparationZoneOrLine()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeBoundary : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TrafficSeparationSchemeBoundary);

            public TrafficSeparationSchemeBoundary()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeCrossing : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TrafficSeparationSchemeCrossing);

            public TrafficSeparationSchemeCrossing()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationSchemeRoundabout : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TrafficSeparationSchemeRoundabout);

            public TrafficSeparationSchemeRoundabout()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TrafficSeparationScheme : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Boolean? iMOAdopted { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TrafficSeparationScheme);

            public TrafficSeparationScheme()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ArchipelagicSeaLaneArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ArchipelagicSeaLaneArea);

            public ArchipelagicSeaLaneArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ArchipelagicSeaLaneAxis : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ArchipelagicSeaLaneAxis);

            public ArchipelagicSeaLaneAxis()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ArchipelagicSeaLane : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ArchipelagicSeaLane);

            public ArchipelagicSeaLane()
            {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadioCallingInPoint : FeatureTypeBase
        {
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<Decimal> orientationValue { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];

            [Required()]
            public trafficFlow trafficFlow { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RadioCallingInPoint);

            public RadioCallingInPoint()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FerryRoute : FeatureTypeBase
        {
            [Required()]
            public List<categoryOfFerry> categoryOfFerry { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FerryRoute);

            public FerryRoute()
            {
                categoryOfFerry = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarLine : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public Decimal orientationValue { get; set; }
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RadarLine);

            public RadarLine()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarRange : FeatureTypeBase
        {
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RadarRange);

            public RadarRange()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarStation : FeatureTypeBase
        {
            public String callSign { get; set; } = string.Empty;
            public List<categoryOfRadarStation> categoryOfRadarStation { get; set; } = [];
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Decimal? valueOfMaximumRange { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RadarStation);

            public RadarStation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AnchorageArea : FeatureTypeBase
        {
            public List<categoryOfAnchorage> categoryOfAnchorage { get; set; } = [];
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(AnchorageArea);

            public AnchorageArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MooringArea : FeatureTypeBase
        {
            public List<categoryOfMooringArea> categoryOfMooringArea { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Decimal? maximumPermittedVesselLength { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public override string Code => nameof(MooringArea);

            public MooringArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AnchorBerth : FeatureTypeBase
        {
            public List<categoryOfAnchorage> categoryOfAnchorage { get; set; } = [];
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Decimal? radius { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(AnchorBerth);

            public AnchorBerth()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeaplaneLandingArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SeaplaneLandingArea);

            public SeaplaneLandingArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DumpingGround : FeatureTypeBase
        {
            public List<categoryOfDumpingGround> categoryOfDumpingGround { get; set; } = [];
            public DateOnly? dateDisused { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(DumpingGround);

            public DumpingGround()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MilitaryPracticeArea : FeatureTypeBase
        {
            public List<categoryOfMilitaryPracticeArea> categoryOfMilitaryPracticeArea { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(MilitaryPracticeArea);

            public MilitaryPracticeArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AdministrationArea : FeatureTypeBase
        {
            public Boolean? inDispute { get; set; } = default;

            [Required()]
            public jurisdiction jurisdiction { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<String> nationality { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(AdministrationArea);

            public AdministrationArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CargoTranshipmentArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CargoTranshipmentArea);

            public CargoTranshipmentArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CautionArea : FeatureTypeBase
        {
            public condition? condition { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public status? status { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(CautionArea);

            public CautionArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InformationArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public DateOnly? reportedDate { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(InformationArea);

            public InformationArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContiguousZone : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public Boolean? inDispute { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public List<String> nationality { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ContiguousZone);

            public ContiguousZone()
            {
                nationality = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContinentalShelfArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public List<String> nationality { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ContinentalShelfArea);

            public ContinentalShelfArea()
            {
                nationality = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CustomZone : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CustomZone);

            public CustomZone()
            {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ExclusiveEconomicZone : FeatureTypeBase
        {
            public Boolean? inDispute { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public List<String> nationality { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(ExclusiveEconomicZone);

            public ExclusiveEconomicZone()
            {
                nationality = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FisheryZone : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FisheryZone);

            public FisheryZone()
            {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FishingGround : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FishingGround);

            public FishingGround()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FreePortArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FreePortArea);

            public FreePortArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class HarbourAreaAdministrative : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(HarbourAreaAdministrative);

            public HarbourAreaAdministrative()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LogPond : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LogPond);

            public LogPond()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class OilBarrier : FeatureTypeBase
        {
            public categoryOfOilBarrier? categoryOfOilBarrier { get; set; } = default;
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(OilBarrier);

            public OilBarrier()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class StraightTerritorialSeaBaseline : FeatureTypeBase
        {
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(StraightTerritorialSeaBaseline);

            public StraightTerritorialSeaBaseline()
            {
                nationality = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TerritorialSeaArea : FeatureTypeBase
        {
            public Boolean? inDispute { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [Required()]
            public List<String> nationality { get; set; }
            public List<restriction> restriction { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(TerritorialSeaArea);

            public TerritorialSeaArea()
            {
                nationality = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SubmarineTransitLane : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public List<restriction> restriction { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SubmarineTransitLane);

            public SubmarineTransitLane()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PilotageDistrict : FeatureTypeBase
        {
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(PilotageDistrict);

            public PilotageDistrict()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CollisionRegulationsLimit : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public String regulationCitation { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CollisionRegulationsLimit);

            public CollisionRegulationsLimit()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MarinePollutionRegulationsArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String regulationCitation { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(MarinePollutionRegulationsArea);

            public MarinePollutionRegulationsArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RestrictedArea : FeatureTypeBase
        {
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [Required()]
            public List<restriction> restriction { get; set; }
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RestrictedArea);

            public RestrictedArea()
            {
                restriction = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightAllAround : FeatureTypeBase
        {
            public List<categoryOfLight> categoryOfLight { get; set; } = [];

            [Required()]
            public List<colour> colour { get; set; }
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? flareBearing { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public lightVisibility? lightVisibility { get; set; } = default;
            public Boolean? majorLight { get; set; } = default;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [Required()]
            public rhythmOfLight rhythmOfLight { get; set; }
            public signalGeneration? signalGeneration { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? valueOfNominalRange { get; set; } = default;
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LightAllAround);

            public LightAllAround()
            {
                colour = new();
                rhythmOfLight = new rhythmOfLight()
                {
                    lightCharacteristic = default(lightCharacteristic),
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightSectored : FeatureTypeBase
        {
            public List<categoryOfLight> categoryOfLight { get; set; } = [];
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [Required()]
            public List<sectorCharacteristics> sectorCharacteristics { get; set; }
            public signalGeneration? signalGeneration { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalDatum? verticalDatum { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LightSectored);

            public LightSectored()
            {
                sectorCharacteristics = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightFogDetector : FeatureTypeBase
        {
            public List<colour> colour { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? flareBearing { get; set; } = default;
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public rhythmOfLight? rhythmOfLight { get; set; }
            public signalGeneration? signalGeneration { get; set; } = default;
            public List<status> status { get; set; } = [];
            public verticalDatum? verticalDatum { get; set; } = default;
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LightFogDetector);

            public LightFogDetector()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightAirObstruction : FeatureTypeBase
        {
            public List<colour> colour { get; set; } = [];
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Int32? flareBearing { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? height { get; set; } = default;
            public List<lightVisibility> lightVisibility { get; set; } = [];
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public rhythmOfLight? rhythmOfLight { get; set; }
            public List<status> status { get; set; } = [];
            public Decimal? valueOfNominalRange { get; set; } = default;
            public verticalDatum? verticalDatum { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(LightAirObstruction);

            public LightAirObstruction()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LateralBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }

            [Required()]
            public categoryOfLateralMark categoryOfLateralMark { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(LateralBuoy);

            public LateralBuoy()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CardinalBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }

            [Required()]
            public categoryOfCardinalMark categoryOfCardinalMark { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(CardinalBuoy);

            public CardinalBuoy()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IsolatedDangerBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(IsolatedDangerBuoy);

            public IsolatedDangerBuoy()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SafeWaterBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(SafeWaterBuoy);

            public SafeWaterBuoy()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpecialPurposeGeneralBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }

            [Required()]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(SpecialPurposeGeneralBuoy);

            public SpecialPurposeGeneralBuoy()
            {
                categoryOfSpecialPurposeMark = new();
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class EmergencyWreckMarkingBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(EmergencyWreckMarkingBuoy);

            public EmergencyWreckMarkingBuoy()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InstallationBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }
            public categoryOfInstallationBuoy? categoryOfInstallationBuoy { get; set; } = default;

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<product> product { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(InstallationBuoy);

            public InstallationBuoy()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MooringBuoy : FeatureTypeBase
        {
            [Required()]
            public buoyShape buoyShape { get; set; }
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? maximumPermittedDraught { get; set; } = default;
            public Decimal? maximumPermittedVesselLength { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public Boolean? visitorsMooring { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(MooringBuoy);

            public MooringBuoy()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LateralBeacon : FeatureTypeBase
        {
            [Required()]
            public beaconShape beaconShape { get; set; }

            [Required()]
            public categoryOfLateralMark categoryOfLateralMark { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Decimal? height { get; set; } = default;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(LateralBeacon);

            public LateralBeacon()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CardinalBeacon : FeatureTypeBase
        {
            [Required()]
            public beaconShape beaconShape { get; set; }

            [Required()]
            public categoryOfCardinalMark categoryOfCardinalMark { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(CardinalBeacon);

            public CardinalBeacon()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IsolatedDangerBeacon : FeatureTypeBase
        {
            [Required()]
            public beaconShape beaconShape { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(IsolatedDangerBeacon);

            public IsolatedDangerBeacon()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SafeWaterBeacon : FeatureTypeBase
        {
            [Required()]
            public beaconShape beaconShape { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(SafeWaterBeacon);

            public SafeWaterBeacon()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SpecialPurposeGeneralBeacon : FeatureTypeBase
        {
            [Required()]
            public beaconShape beaconShape { get; set; }

            [Required()]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public condition? condition { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(SpecialPurposeGeneralBeacon);

            public SpecialPurposeGeneralBeacon()
            {
                categoryOfSpecialPurposeMark = new();
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Daymark : FeatureTypeBase
        {
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; } = [];

            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];

            [Required()]
            public topmarkDaymarkShape topmarkDaymarkShape { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public List<shapeInformation> shapeInformation { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(Daymark);

            public Daymark()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightFloat : FeatureTypeBase
        {
            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public topmark? topmark { get; set; }
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(LightFloat);

            public LightFloat()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class LightVessel : FeatureTypeBase
        {
            [Required()]
            public List<colour> colour { get; set; }
            public colourPattern? colourPattern { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? horizontalLength { get; set; } = default;
            public Decimal? horizontalWidth { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Boolean? radarConspicuous { get; set; } = default;
            public List<status> status { get; set; } = [];
            public Decimal? verticalLength { get; set; } = default;
            public visualProminence? visualProminence { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(LightVessel);

            public LightVessel()
            {
                colour = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Retroreflector : FeatureTypeBase
        {
            public List<colour> colour { get; set; } = [];
            public colourPattern? colourPattern { get; set; } = default;
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(Retroreflector);

            public Retroreflector()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarReflector : FeatureTypeBase
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public Decimal? height { get; set; } = default;
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RadarReflector);

            public RadarReflector()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FogSignal : FeatureTypeBase
        {
            [Required()]
            public categoryOfFogSignal categoryOfFogSignal { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public Int32? signalFrequency { get; set; } = default;
            public signalGeneration? signalGeneration { get; set; } = default;
            public String signalGroup { get; set; } = string.Empty;
            public Decimal? signalPeriod { get; set; } = default;
            public List<signalSequence> signalSequence { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Decimal? valueOfMaximumRange { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(FogSignal);

            public FogSignal()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PhysicalAISAidToNavigation : FeatureTypeBase
        {
            public Decimal? estimatedRangeOfTransmission { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String mMSICode { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public status? status { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(PhysicalAISAidToNavigation);

            public PhysicalAISAidToNavigation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class VirtualAISAidToNavigation : FeatureTypeBase
        {
            public Decimal? estimatedRangeOfTransmission { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String mMSICode { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public status? status { get; set; } = default;

            [Required()]
            public virtualAISAidToNavigationType virtualAISAidToNavigationType { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(VirtualAISAidToNavigation);

            public VirtualAISAidToNavigation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadioStation : FeatureTypeBase
        {
            public String callSign { get; set; } = string.Empty;
            public List<categoryOfRadioStation> categoryOfRadioStation { get; set; } = [];
            public List<String> communicationChannel { get; set; } = [];
            public Decimal? estimatedRangeOfTransmission { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public frequencyPair? frequencyPair { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RadioStation);

            public RadioStation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RadarTransponderBeacon : FeatureTypeBase
        {
            [Required()]
            public categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<radarWaveLength> radarWaveLength { get; set; } = [];
            public sectorLimit? sectorLimit { get; set; }
            public String signalGroup { get; set; } = string.Empty;
            public List<signalSequence> signalSequence { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Decimal? valueOfMaximumRange { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RadarTransponderBeacon);

            public RadarTransponderBeacon()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PilotBoardingPlace : FeatureTypeBase
        {
            public categoryOfPilotBoardingPlace? categoryOfPilotBoardingPlace { get; set; } = default;
            public categoryOfPreference? categoryOfPreference { get; set; } = default;
            public List<String> communicationChannel { get; set; } = [];
            public List<String> destination { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<pilotMovement> pilotMovement { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(PilotBoardingPlace);

            public PilotBoardingPlace()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class VesselTrafficServiceArea : FeatureTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(VesselTrafficServiceArea);

            public VesselTrafficServiceArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CoastGuardStation : FeatureTypeBase
        {
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public Boolean? isMRCC { get; set; } = default;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(CoastGuardStation);

            public CoastGuardStation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SignalStationWarning : FeatureTypeBase
        {
            [Required()]
            public List<categoryOfSignalStationWarning> categoryOfSignalStationWarning { get; set; }
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SignalStationWarning);

            public SignalStationWarning()
            {
                categoryOfSignalStationWarning = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SignalStationTraffic : FeatureTypeBase
        {
            [Required()]
            public List<categoryOfSignalStationTraffic> categoryOfSignalStationTraffic { get; set; }
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(SignalStationTraffic);

            public SignalStationTraffic()
            {
                categoryOfSignalStationTraffic = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RescueStation : FeatureTypeBase
        {
            public List<categoryOfRescueStation> categoryOfRescueStation { get; set; } = [];
            public List<String> communicationChannel { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public override string Code => nameof(RescueStation);

            public RescueStation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class HarbourFacility : FeatureTypeBase
        {
            [Required()]
            public List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; }
            public List<String> communicationChannel { get; set; } = [];
            public condition? condition { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public product? product { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<restriction> restriction { get; set; } = [];
            public List<status> status { get; set; } = [];
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(HarbourFacility);

            public HarbourFacility()
            {
                categoryOfHarbourFacility = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SmallCraftFacility : FeatureTypeBase
        {
            [Required()]
            public List<categoryOfSmallCraftFacility> categoryOfSmallCraftFacility { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<status> status { get; set; } = [];
            public Int32? scaleMinimum { get; set; } = default;
            public List<information> information { get; set; } = [];
            public String pictorialRepresentation { get; set; } = string.Empty;
            public override string Code => nameof(SmallCraftFacility);

            public SmallCraftFacility()
            {
                categoryOfSmallCraftFacility = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TextPlacement : FeatureTypeBase
        {
            [Required()]
            public Int32 textOffsetBearing { get; set; }

            [Required()]
            public Int32 textOffsetDistance { get; set; }
            public Boolean? textRotation { get; set; } = default;

            [Required()]
            public List<textType> textType { get; set; }
            public Int32? scaleMinimum { get; set; } = default;
            public override string Code => nameof(TextPlacement);

            public TextPlacement()
            {
                textType = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Chart1Feature : FeatureTypeBase
        {
            public List<String> drawingInstruction { get; set; } = [];
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(Chart1Feature);

            public Chart1Feature()
            {
            }
        }
    }
}