using System;
using System.Collections.Immutable;
using System.Linq;

namespace S100Framework.DomainModel.S101
{
    public static class Information
    {
        public static Version Version => new Version("1.5.0");
        public static string[] ComplexTypes => ["featureName", "featuresDetected", "fixedDateRange", "frequencyPair", "horizontalClearanceFixed", "horizontalClearanceOpen", "horizontalPositionUncertainty", "information", "measuredDistanceValue", "multiplicityOfFeatures", "onlineResource", "orientation", "periodicDateRange", "radarWaveLength", "sectorInformation", "sectorLimitOne", "sectorLimitTwo", "shapeInformation", "signalSequence", "speed", "surfaceCharacteristics", "surveyDateRange", "telecommunications", "tidalStreamValue", "timeIntervalsByDayOfWeek", "topmark", "valueOfLocalMagneticAnomaly", "verticalUncertainty", "vesselSpeedLimit", "zoneOfConfidence", "directionalCharacter", "rhythmOfLight", "scheduleByDayOfWeek", "sectorLimit", "spatialAccuracy", "tidalStreamPanelValues", "verticalClearanceClosed", "verticalClearanceFixed", "verticalClearanceOpen", "verticalClearanceSafe", "lightSector", "sectorCharacteristics", ];
        public static string[] InformationTypes => ["ContactDetails", "ServiceHours", "NonStandardWorkingDay", "NauticalInformation", "SpatialQuality", ];
        public static string[] FeatureTypes => ["QualityOfNonBathymetricData", "DataCoverage", "NavigationalSystemOfMarks", "LocalDirectionOfBuoyage", "QualityOfBathymetricData", "SoundingDatum", "VerticalDatumOfData", "QualityOfSurvey", "UpdateInformation", "MagneticVariation", "LocalMagneticAnomaly", "Coastline", "LandArea", "IslandGroup", "LandElevation", "River", "Rapids", "Waterfall", "Lake", "LandRegion", "Vegetation", "IceArea", "SlopingGround", "SlopeTopline", "Tideway", "BuiltUpArea", "Building", "AirportAirfield", "Runway", "Helipad", "Bridge", "SpanFixed", "SpanOpening", "Conveyor", "CableOverhead", "PipelineOverhead", "PylonBridgeSupport", "FenceWall", "Railway", "Road", "Tunnel", "Landmark", "SiloTank", "WindTurbine", "FortifiedStructure", "ProductionStorageArea", "Checkpoint", "Hulk", "Pile", "Dyke", "ShorelineConstruction", "StructureOverNavigableWater", "Causeway", "Canal", "DistanceMark", "Gate", "Dam", "Crane", "Berth", "Dolphin", "Bollard", "DryDock", "FloatingDock", "Pontoon", "DockArea", "Gridiron", "LockBasin", "MooringTrot", "SeaAreaNamedWaterArea", "TidalStreamFloodEbb", "CurrentNonGravitational", "WaterTurbulence", "TidalStreamPanelData", "Sounding", "DredgedArea", "SweptArea", "DepthContour", "DepthArea", "DepthNoBottomFound", "UnsurveyedArea", "SeabedArea", "WeedKelp", "Seagrass", "Sandwave", "Spring", "UnderwaterAwashRock", "Wreck", "Obstruction", "FoulGround", "DiscolouredWater", "FishingFacility", "MarineFarmCulture", "OffshorePlatform", "CableSubmarine", "CableArea", "PipelineSubmarineOnLand", "SubmarinePipelineArea", "OffshoreProductionArea", "NavigationLine", "RecommendedTrack", "RangeSystem", "Fairway", "FairwaySystem", "RecommendedRouteCentreline", "TwoWayRoutePart", "TwoWayRoute", "RecommendedTrafficLanePart", "DeepWaterRouteCentreline", "DeepWaterRoutePart", "DeepWaterRoute", "InshoreTrafficZone", "PrecautionaryArea", "TrafficSeparationSchemeLanePart", "SeparationZoneOrLine", "TrafficSeparationSchemeBoundary", "TrafficSeparationSchemeCrossing", "TrafficSeparationSchemeRoundabout", "TrafficSeparationScheme", "ArchipelagicSeaLaneArea", "ArchipelagicSeaLaneAxis", "ArchipelagicSeaLane", "RadioCallingInPoint", "FerryRoute", "RadarLine", "RadarRange", "RadarStation", "AnchorageArea", "MooringArea", "AnchorBerth", "SeaplaneLandingArea", "DumpingGround", "MilitaryPracticeArea", "AdministrationArea", "CargoTranshipmentArea", "CautionArea", "InformationArea", "ContiguousZone", "ContinentalShelfArea", "CustomZone", "ExclusiveEconomicZone", "FisheryZone", "FishingGround", "FreePortArea", "HarbourAreaAdministrative", "LogPond", "OilBarrier", "StraightTerritorialSeaBaseline", "TerritorialSeaArea", "SubmarineTransitLane", "PilotageDistrict", "CollisionRegulationsLimit", "MarinePollutionRegulationsArea", "RestrictedArea", "LightAllAround", "LightSectored", "LightFogDetector", "LightAirObstruction", "LateralBuoy", "CardinalBuoy", "IsolatedDangerBuoy", "SafeWaterBuoy", "SpecialPurposeGeneralBuoy", "EmergencyWreckMarkingBuoy", "InstallationBuoy", "MooringBuoy", "LateralBeacon", "CardinalBeacon", "IsolatedDangerBeacon", "SafeWaterBeacon", "SpecialPurposeGeneralBeacon", "Daymark", "LightFloat", "LightVessel", "Retroreflector", "RadarReflector", "FogSignal", "PhysicalAISAidToNavigation", "VirtualAISAidToNavigation", "RadioStation", "RadarTransponderBeacon", "PilotBoardingPlace", "VesselTrafficServiceArea", "CoastGuardStation", "SignalStationWarning", "SignalStationTraffic", "RescueStation", "HarbourFacility", "SmallCraftFacility", "TextPlacement", "Chart1Feature", ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum beaconShape : int
    {
        [System.ComponentModel.Description("An elongated wood or metal pole, driven into the ground or seabed, which serves as a navigational aid or a support for a navigational aid.")]
        [System.Xml.Serialization.XmlEnum("1")]
        StakePolePerchPost = 1,
        [System.ComponentModel.Description("A tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Withy = 2,
        [System.ComponentModel.Description("A solid structure of the order of 10 metres in height used as a navigational aid.")]
        [System.Xml.Serialization.XmlEnum("3")]
        BeaconTower = 3,
        [System.ComponentModel.Description("A structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LatticeBeacon = 4,
        [System.ComponentModel.Description("A long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PileBeacon = 5,
        [System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Cairn = 6,
        [System.ComponentModel.Description("A tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.")]
        [System.Xml.Serialization.XmlEnum("7")]
        BuoyantBeacon = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum bridgeConstruction : int
    {
        [System.ComponentModel.Description("A typically curved structural member spanning an opening and serving as a support (as for the wall or other weight above the opening).")]
        [System.Xml.Serialization.XmlEnum("1")]
        Arch = 1,
        [System.ComponentModel.Description("A structure consisting of a series of arches or towers supporting a roadway, waterway, etc., across a depression, etc.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Viaduct = 2,
        [System.ComponentModel.Description("A fixed floating bridge supported by pontoons.")]
        [System.Xml.Serialization.XmlEnum("3")]
        PontoonBridge = 3,
        [System.ComponentModel.Description("A fixed bridge consisting of either a roadway or a truss suspended from two or more cables which pass over towers and are anchored by backstays to a firm foundation.")]
        [System.Xml.Serialization.XmlEnum("4")]
        SuspensionBridge = 4,
        [System.ComponentModel.Description("Consists of towers on each side of the watercourse connected by a system of girders on which a carriage runs.")]
        [System.Xml.Serialization.XmlEnum("5")]
        TransporterBridge = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum bridgeFunction : int
    {
        [System.ComponentModel.Description("Of, relating to, or designed for vehicles and especially motor vehicles.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Vehicular = 1,
        [System.ComponentModel.Description("Of, relating to, or designed for vehicles that run on a guiding track(s), especially trains.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Rail = 2,
        [System.ComponentModel.Description("Of, relating to, or designed for walking.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Pedestrian = 3,
        [System.ComponentModel.Description("A bridge supporting an artificially elevated channel, for the conveyance of water.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Aqueduct = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum buildingShape : int
    {
        [System.ComponentModel.Description("A building having many storeys.")]
        [System.Xml.Serialization.XmlEnum("5")]
        HighRiseBuilding = 5,
        [System.ComponentModel.Description("A polyhedron of which one face is a polygon of any number of sides, and the other faces are triangles with a common vertex.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Pyramid = 6,
        [System.ComponentModel.Description("Shaped like a cylinder, which is a solid geometrical figure generated by straight lines fixed in direction and describing with one of its points a closed curve, especially a circle.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Cylindrical = 7,
        [System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Spherical = 8,
        [System.ComponentModel.Description("A shape the sides of which are six equal squares; a regular hexahedron.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Cubic = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum buoyShape : int
    {
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Conical = 1,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Can = 2,
        [System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Spherical = 3,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Pillar = 4,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Spar = 5,
        [System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Barrel = 6,
        [System.ComponentModel.Description("A very large buoy designed to carry a signal light of high luminous intensity at a high elevation.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Superbuoy = 7,
        [System.ComponentModel.Description("A specially constructed shuttle shaped buoy which is used in ice conditions.")]
        [System.Xml.Serialization.XmlEnum("8")]
        IceBuoy = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfAirportAirfield : int
    {
        [System.ComponentModel.Description("A large military airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
        [System.Xml.Serialization.XmlEnum("1")]
        MilitaryAeroplaneAirport = 1,
        [System.ComponentModel.Description("A large airfield usually equipped with a control tower, hangars and accommodation for the receiving and discharging of passengers or cargo.")]
        [System.Xml.Serialization.XmlEnum("2")]
        CivilAeroplaneAirport = 2,
        [System.ComponentModel.Description("A landing place for helicopters controlled by the military.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MilitaryHeliport = 3,
        [System.ComponentModel.Description("A landing place for helicopters, often the roof of a building.")]
        [System.Xml.Serialization.XmlEnum("4")]
        CivilHeliport = 4,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of gliders.")]
        [System.Xml.Serialization.XmlEnum("5")]
        GliderAirfield = 5,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of small aeroplanes.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SmallPlanesAirfield = 6,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of aeroplanes or helicopters in times of emergency.")]
        [System.Xml.Serialization.XmlEnum("8")]
        EmergencyAirfield = 8,
        [System.ComponentModel.Description("An area of land set aside for the take-off and landing of aeroplanes or helicopters in times of search and rescue.")]
        [System.Xml.Serialization.XmlEnum("9")]
        SearchAndRescueAirfield = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfAnchorage : int
    {
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor.")]
        [System.Xml.Serialization.XmlEnum("1")]
        UnrestrictedAnchorage = 1,
        [System.ComponentModel.Description("An area in which vessels of deep draught anchor or may anchor.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DeepWaterAnchorage = 2,
        [System.ComponentModel.Description("An area in which tankers anchor or may anchor.")]
        [System.Xml.Serialization.XmlEnum("3")]
        TankerAnchorage = 3,
        [System.ComponentModel.Description("An area where a vessel anchors when satisfying quarantine regulations.")]
        [System.Xml.Serialization.XmlEnum("5")]
        QuarantineAnchorage = 5,
        [System.ComponentModel.Description("An area in which seaplanes anchor or may anchor.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SeaplaneAnchorage = 6,
        [System.ComponentModel.Description("An area in which yachts and small boats anchor or may anchor.")]
        [System.Xml.Serialization.XmlEnum("7")]
        SmallCraftAnchorage = 7,
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor for periods of up to 24 hours.")]
        [System.Xml.Serialization.XmlEnum("9")]
        AnchorageForPeriodsUpTo24Hours = 9,
        [System.ComponentModel.Description("An area in which vessels may anchor for a period of time not to exceed a specific limit.")]
        [System.Xml.Serialization.XmlEnum("10")]
        AnchorageForALimitedPeriodOfTime = 10,
        [System.ComponentModel.Description("An area in which vessels anchor or may anchor while waiting, for example, for access to a port or berth.")]
        [System.Xml.Serialization.XmlEnum("14")]
        WaitingAnchorage = 14,
        [System.ComponentModel.Description("A location not defined by a regulatory authority that has been reported to be suitable and safe for anchoring.")]
        [System.Xml.Serialization.XmlEnum("15")]
        ReportedAnchorage = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfBuiltUpArea : int
    {
        [System.ComponentModel.Description("An area predominantly occupied by man-made structures used for residential, commercial, and industrial purposes.")]
        [System.Xml.Serialization.XmlEnum("1")]
        UrbanArea = 1,
        [System.ComponentModel.Description("A continuously occupied concentration of tents or lightweight fixed structures (for example: huts) serving as residences.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Settlement = 2,
        [System.ComponentModel.Description("A self-contained group of houses and associated buildings, usually in a country area.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Village = 3,
        [System.ComponentModel.Description("An inhabited place larger and more regularly built and with more complete and independent local government than a village but not incorporated as a city.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Town = 4,
        [System.ComponentModel.Description("A major town inhabited by a large permanent community with all essential services.")]
        [System.Xml.Serialization.XmlEnum("5")]
        City = 5,
        [System.ComponentModel.Description("A complex for holiday-makers with cottages, shops, and entertainment, on site, which is mainly populated on a seasonal basis.")]
        [System.Xml.Serialization.XmlEnum("6")]
        HolidayVillage = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCable : int
    {
        [System.ComponentModel.Description("A cable that transmits or distributes electrical power.")]
        [System.Xml.Serialization.XmlEnum("1")]
        PowerLine = 1,
        [System.ComponentModel.Description("Multiple un-insulated cables usually supported by steel lattice towers. Such features are generally more prominent than normal power lines.")]
        [System.Xml.Serialization.XmlEnum("3")]
        TransmissionLine = 3,
        [System.ComponentModel.Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
        [System.Xml.Serialization.XmlEnum("6")]
        MooringCable = 6,
        [System.ComponentModel.Description("A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Ferry = 7,
        [System.ComponentModel.Description("A cable used for joining components of complex marine structures, for example mooring trots.")]
        [System.Xml.Serialization.XmlEnum("9")]
        JunctionCable = 9,
        [System.ComponentModel.Description("A cable used for the transmission and reception of modulated communication waves/signals.")]
        [System.Xml.Serialization.XmlEnum("10")]
        TelecommunicationsCable = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCanal : int
    {
        [System.ComponentModel.Description("A canal used for navigation as part of a transport system.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Transportation = 1,
        [System.ComponentModel.Description("A canal used to drain excess water from surrounding land.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Drainage = 2,
        [System.ComponentModel.Description("A canal used to supply water for the purpose of irrigation.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Irrigation = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCardinalMark : int
    {
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NW-NE taken from the point of interest; it should be passed to the north side of the mark.")]
        [System.Xml.Serialization.XmlEnum("1")]
        NorthCardinalMark = 1,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NE-SE taken from the point of interest. It should be passed to the east side of the mark.")]
        [System.Xml.Serialization.XmlEnum("2")]
        EastCardinalMark = 2,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SE-SW taken from the point of interest; it should be passed to the south side of the mark.")]
        [System.Xml.Serialization.XmlEnum("3")]
        SouthCardinalMark = 3,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SW-NW taken from the point of interest; it should be passed to the west side of the mark.")]
        [System.Xml.Serialization.XmlEnum("4")]
        WestCardinalMark = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCheckpoint : int
    {
        [System.ComponentModel.Description("Serves as a government checkpoint where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Custom = 1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCoastline : int
    {
        [System.ComponentModel.Description("A coast backed by rock or earth cliffs, gives a good radar return and is useful for visual identification from a considerable distance off, where cliffs alternate with low lying coast along the shoreline.")]
        [System.Xml.Serialization.XmlEnum("1")]
        SteepCoast = 1,
        [System.ComponentModel.Description("A level coast with no obvious topographic features.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FlatCoast = 2,
        [System.ComponentModel.Description("Projecting seaward extension of glacier, usually afloat.")]
        [System.Xml.Serialization.XmlEnum("6")]
        GlacierSeawardEnd = 6,
        [System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Mangrove = 7,
        [System.ComponentModel.Description("A shoreline area made up of spongy land saturated with water. It may have a shallow covering of water, usually with a considerable amount of vegetation appearing above the surface.")]
        [System.Xml.Serialization.XmlEnum("8")]
        MarshyShore = 8,
        [System.ComponentModel.Description("A vertical cliff forming the seaward edge of an ice shelf, ranging in height from 2 metres to 50 metres or more above sea level.")]
        [System.Xml.Serialization.XmlEnum("10")]
        IceCoast = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfConveyor : int
    {
        [System.ComponentModel.Description("A transportation system consisting of load cables strung between pylons on which carrier units (for example: cars or buckets intended to transport people, material, and/or equipment) are suspended.")]
        [System.Xml.Serialization.XmlEnum("1")]
        AerialCableway = 1,
        [System.ComponentModel.Description("A conveyor along which material or people are transported by means of a moving belt.")]
        [System.Xml.Serialization.XmlEnum("2")]
        BeltConveyor = 2,
        [System.ComponentModel.Description("An artificial channel, usually an inclined chute or trough, for carrying water to furnish power, transport logs down a mountainside, etc.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Flume = 3,
        [System.ComponentModel.Description("Any of various mechanical devices for raising objects or materials.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LiftElevator = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCrane : int
    {
        [System.ComponentModel.Description("A high speed, shore-based crane used in the lift-on/lift-off operation of specially constructed containers.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ContainerCraneGantry = 2,
        [System.ComponentModel.Description("A tripodal structure used in dockyards and harbours for stepping masts or lifting loads in to and out of vessels.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Sheerlegs = 3,
        [System.ComponentModel.Description("A crane mounted on rails (track) that can move (usually parallel to the wharf face) in order to load and unload cargo vessels.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TravellingCrane = 4,
        [System.ComponentModel.Description("A type of crane shaped like the letter 'A'.")]
        [System.Xml.Serialization.XmlEnum("5")]
        AFrame = 5,
        [System.ComponentModel.Description("A powerful travelling crane mounted on a movable gantry of large span.")]
        [System.Xml.Serialization.XmlEnum("6")]
        GoliathCrane = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfDam : int
    {
        [System.ComponentModel.Description("A dam erected across a river to raise the level of the water. A fence of stakes set in a river or along the shore as a trap for fish. The word is now restricted to smaller works, the larger are called dams.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Weir = 1,
        [System.ComponentModel.Description("A barrier to check or confine anything in motion; particularly one constructed to hold back water and raise its level to form a reservoir, or to prevent flooding.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Dam = 2,
        [System.ComponentModel.Description("An opening dam across a channel which, when required, is closed to control flood waters.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FloodBarrage = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfDock : int
    {
        [System.ComponentModel.Description("A dock which is open to the sea and in which the water level is affected by tides.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Tidal = 1,
        [System.ComponentModel.Description("A dock in which water can be maintained at any level by closing a gate when the water is at the desired level.")]
        [System.Xml.Serialization.XmlEnum("2")]
        WetDock = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfDolphin : int
    {
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used as a mooring point for vessels.")]
        [System.Xml.Serialization.XmlEnum("1")]
        MooringDolphin = 1,
        [System.ComponentModel.Description("A post or group of posts, which a vessel may swing around for compass adjustment.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DeviationDolphin = 2,
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to extend the berth of a vessel by providing extra mooring points.")]
        [System.Xml.Serialization.XmlEnum("3")]
        BerthingDolphin = 3,
        [System.ComponentModel.Description("A post or group of posts driven into the seabed or riverbed, used to assist in berthing of vessels by taking up some berthing loads; keep vessels from pressing against the pier structure; or to protect structures from possible impact by ships.")]
        [System.Xml.Serialization.XmlEnum("4")]
        FenderOrBreastingDolphin = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfDumpingGround : int
    {
        [System.ComponentModel.Description("An area at sea where chemical waste is dumped.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ChemicalWasteDumpingGround = 2,
        [System.ComponentModel.Description("An area at sea where nuclear waste is dumped.")]
        [System.Xml.Serialization.XmlEnum("3")]
        NuclearWasteDumpingGround = 3,
        [System.ComponentModel.Description("An area at sea where explosives are dumped.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ExplosivesDumpingGround = 4,
        [System.ComponentModel.Description("A sea area where dredged material is deposited.")]
        [System.Xml.Serialization.XmlEnum("5")]
        SpoilGround = 5,
        [System.ComponentModel.Description("An area at sea where disused vessels are scuttled.")]
        [System.Xml.Serialization.XmlEnum("6")]
        VesselDumpingGround = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfFence : int
    {
        [System.ComponentModel.Description("A man-made barrier of relatively light structure used as an enclosure or boundary.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Fence = 1,
        [System.ComponentModel.Description("A continuous growth of shrubbery planted as a fence, a boundary or a wind break.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Hedge = 3,
        [System.ComponentModel.Description("A solid man-made barrier of generally heavy material used as an enclosure, boundary, or for protection.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Wall = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfFerry : int
    {
        [System.ComponentModel.Description("A ferry which may have routes that vary with weather, tide and traffic.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FreeMovingFerry = 1,
        [System.ComponentModel.Description("A ferry that follows a fixed route guided by a cable.")]
        [System.Xml.Serialization.XmlEnum("2")]
        CableFerry = 2,
        [System.ComponentModel.Description("A winter-time ferry which crosses a lead.")]
        [System.Xml.Serialization.XmlEnum("3")]
        IceFerry = 3,
        [System.ComponentModel.Description("A high speed water vessel for civilian use.")]
        [System.Xml.Serialization.XmlEnum("5")]
        HighSpeedFerry = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfFishingFacility : int
    {
        [System.ComponentModel.Description("Poles or stakes placed in shallow water to outline a fishing ground or to catch fish.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FishingStake = 1,
        [System.ComponentModel.Description("A structure (usually portable) for catching fish.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FishTrap = 2,
        [System.ComponentModel.Description("A fence of stakes or stones set in a river or along the shore to trap fish.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FishWeir = 3,
        [System.ComponentModel.Description("A net built at sea for catching tunny.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TunnyNet = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfFogSignal : int
    {
        [System.ComponentModel.Description("A signal produced by the firing of explosive charges.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Explosive = 1,
        [System.ComponentModel.Description("A diaphone uses compressed air and generally emits a powerful low-pitched sound, which often concludes with a brief sound of suddenly lowered pitch, termed the 'grunt'.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Diaphone = 2,
        [System.ComponentModel.Description("A type of fog signal apparatus which produces sound by virtue of the passage of air through slots or holes in a revolving disk.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Siren = 3,
        [System.ComponentModel.Description("A horn having a diaphragm oscillated by electricity.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Nautophone = 4,
        [System.ComponentModel.Description("A reed uses compressed air and emits a weak, high pitched sound.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Reed = 5,
        [System.ComponentModel.Description("A diaphragm horn which operates under the influence of compressed air or steam.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Tyfon = 6,
        [System.ComponentModel.Description("A ringing sound with a short range.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Bell = 7,
        [System.ComponentModel.Description("A distinctive sound made by a jet of air passing through an orifice. The apparatus may be operated automatically, by hand or by air being forced up a tube by waves acting on a buoy.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Whistle = 8,
        [System.ComponentModel.Description("A sound produced by vibration of a disc when struck.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Gong = 9,
        [System.ComponentModel.Description("A horn uses compressed air or electricity to vibrate a diaphragm and exists in a variety of types which differ greatly in their sound and power.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Horn = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfFortifiedStructure : int
    {
        [System.ComponentModel.Description("A large fortified building or structure.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Castle = 1,
        [System.ComponentModel.Description("A fortified enclosure, building, or position able to be defended against an enemy.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Fort = 2,
        [System.ComponentModel.Description("A fortified structure on which artillery is mounted.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Battery = 3,
        [System.ComponentModel.Description("A concrete structure strengthened to give protection against enemy fire, with apertures to allow defensive gunfire.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Blockhouse = 4,
        [System.ComponentModel.Description("A small circular fort with very thick walls (for example Martello tower).")]
        [System.Xml.Serialization.XmlEnum("5")]
        FortifiedTower = 5,
        [System.ComponentModel.Description("An outwork or fieldwork usually square or polygonal and without flanking defences.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Redoubt = 6,
        [System.ComponentModel.Description("A fortified pen to hold submarines.")]
        [System.Xml.Serialization.XmlEnum("8")]
        FortifiedSubmarineShelter = 8,
        [System.ComponentModel.Description("Anything serving as a bulwark or defence.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Rampart = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfGate : int
    {
        [System.ComponentModel.Description("An opening gate used to control flood water.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FloodBarrageGate = 2,
        [System.ComponentModel.Description("A steel structure used for closing the entrance of locks, wet and dry docks.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Caisson = 3,
        [System.ComponentModel.Description("Pair of massive hinged doors at each end of a lock.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LockGate = 4,
        [System.ComponentModel.Description("An opening gate in a dyke.")]
        [System.Xml.Serialization.XmlEnum("5")]
        DykeGate = 5,
        [System.ComponentModel.Description("A sliding gate or other contrivance for changing the level of a body of water by controlling the flow into or out of it.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Sluice = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfHarbourFacility : int
    {
        [System.ComponentModel.Description("A terminal for roll-on roll-off ferries.")]
        [System.Xml.Serialization.XmlEnum("1")]
        RoroTerminal = 1,
        [System.ComponentModel.Description("A terminal for passenger and vehicle ferries.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FerryTerminal = 3,
        [System.ComponentModel.Description("A harbour with facilities for fishing boats.")]
        [System.Xml.Serialization.XmlEnum("4")]
        FishingHarbour = 4,
        [System.ComponentModel.Description("A harbour facility for small boats, yachts, etc., where supplies, repairs, and various services are available.")]
        [System.Xml.Serialization.XmlEnum("5")]
        YachtHarbourMarina = 5,
        [System.ComponentModel.Description("A centre of operations for naval vessels.")]
        [System.Xml.Serialization.XmlEnum("6")]
        NavalBase = 6,
        [System.ComponentModel.Description("A terminal for the bulk handling of liquid cargoes.")]
        [System.Xml.Serialization.XmlEnum("7")]
        TankerTerminal = 7,
        [System.ComponentModel.Description("A terminal for the loading and unloading of passengers.")]
        [System.Xml.Serialization.XmlEnum("8")]
        PassengerTerminal = 8,
        [System.ComponentModel.Description("A place where ships are built or repaired.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Shipyard = 9,
        [System.ComponentModel.Description("A terminal with facilities to load/unload or store shipping containers.")]
        [System.Xml.Serialization.XmlEnum("10")]
        ContainerTerminal = 10,
        [System.ComponentModel.Description("A terminal for the handling of bulk materials such as iron ore, coal, etc.")]
        [System.Xml.Serialization.XmlEnum("11")]
        BulkTerminal = 11,
        [System.ComponentModel.Description("A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.")]
        [System.Xml.Serialization.XmlEnum("12")]
        ShipLift = 12,
        [System.ComponentModel.Description("A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.")]
        [System.Xml.Serialization.XmlEnum("13")]
        StraddleCarrier = 13,
        [System.ComponentModel.Description("A harbour within which the floating equipment (dredges, tugs ...) of harbour services are stationed.")]
        [System.Xml.Serialization.XmlEnum("14")]
        ServiceHarbour = 14,
        [System.ComponentModel.Description("The services of a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area, are available.")]
        [System.Xml.Serialization.XmlEnum("15")]
        PilotageService = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfHulk : int
    {
        [System.ComponentModel.Description("A permanently moored floating structure (for example: an old ship) that is used as a restaurant.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FloatingRestaurant = 1,
        [System.ComponentModel.Description("A ship of historical interest permanently moored as a tourist attraction.")]
        [System.Xml.Serialization.XmlEnum("2")]
        HistoricShip = 2,
        [System.ComponentModel.Description("A permanently moored floating structure (for example: an old ship) that is used as a museum.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FloatingMuseum = 3,
        [System.ComponentModel.Description("A permanently moored floating structure (for example: an old ship) that is used for accommodation.")]
        [System.Xml.Serialization.XmlEnum("4")]
        FloatingAccommodation = 4,
        [System.ComponentModel.Description("A permanently moored floating structure, often constructed from old ships, used as a breakwater.")]
        [System.Xml.Serialization.XmlEnum("5")]
        FloatingBreakwater = 5,
        [System.ComponentModel.Description("A permanently moored floating structure, such as an old ship, used as a casino boat.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Casino = 6,
        [System.ComponentModel.Description("A permanently moored floating structure, often constructed from old ships, used for training purposes.")]
        [System.Xml.Serialization.XmlEnum("7")]
        TrainingVessel = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfIce : int
    {
        [System.ComponentModel.Description("Sea ice which remains fast, generally in the position where originally formed, and which may attain a considerable thickness. It is found along coasts, where it is attached to the shore, or over shoals, where it may be held in position by islands, grounded icebergs or grounded polar ice.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FastIce = 1,
        [System.ComponentModel.Description("A mass of snow and ice continuously moving from higher to lower ground or, if afloat, continuously spreading.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Glacier = 5,
        [System.ComponentModel.Description("Sea ice that is more than one year old (in contrast to winter ice). The WMO code defines polar ice as any sea ice more than one year old and more than 3 metres thick.")]
        [System.Xml.Serialization.XmlEnum("8")]
        PolarIce = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfInstallationBuoy : int
    {
        [System.ComponentModel.Description("Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
        [System.Xml.Serialization.XmlEnum("1")]
        CatenaryAnchorLegMooring = 1,
        [System.ComponentModel.Description("A large mooring buoy used by tankers to load and unload in port approaches or in offshore oil and gas fields.")]
        [System.Xml.Serialization.XmlEnum("2")]
        SingleBuoyMooring = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfLandRegion : int
    {
        [System.ComponentModel.Description("A type of bog, especially a low-lying area, wholly or partly covered with water and dominated by grass-like plants, grasses, sedges and reeds.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Fen = 1,
        [System.ComponentModel.Description("An area of wet, often spongy ground that is subject to frequent flooding or tidal inundations, but not considered to be continually under water. It is characterized by the growth of non woody plants and by the lack of trees.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Marsh = 2,
        [System.ComponentModel.Description("Wet spongy ground consisting of decaying vegetation, which retains stagnant water, too soft to bear the weight of any heavy body.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Bog = 3,
        [System.ComponentModel.Description("A tract of wasteland peat bog, usually covered by a low scrubby growth, but may have scattered small open water holes.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Heathland = 4,
        [System.ComponentModel.Description("A series of connected and aligned mountains or mountain ridges.")]
        [System.Xml.Serialization.XmlEnum("5")]
        MountainRange = 5,
        [System.ComponentModel.Description("Low and relatively level land at a lower elevation than adjoining areas.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Lowlands = 6,
        [System.ComponentModel.Description("A relatively narrow, deep depression with steep sides, the bottom of which generally has a continuous slope.")]
        [System.Xml.Serialization.XmlEnum("7")]
        CanyonLands = 7,
        [System.ComponentModel.Description("A piece of land set aside for crops which are periodically flooded (for example rice paddy).")]
        [System.Xml.Serialization.XmlEnum("8")]
        PaddyField = 8,
        [System.ComponentModel.Description("Of or pertaining to the science or practice of cultivating the soil and rearing animals.")]
        [System.Xml.Serialization.XmlEnum("9")]
        AgriculturalLand = 9,
        [System.ComponentModel.Description("An open grassy plain with few or no trees in a tropical or subtropical region; a tract covered mainly by grasses that have little or no woody tissue.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SavannaGrassland = 10,
        [System.ComponentModel.Description("A piece of ground kept for ornament and/or recreation or maintained in its natural state as a public property or area.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Parkland = 11,
        [System.ComponentModel.Description("An area of spongy land saturated with water. It may have a shallow covering of water, usually with a considerable amount of vegetation appearing above the surface.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Swamp = 12,
        [System.ComponentModel.Description("The sliding down of a mass of land on a mountain or cliff-side; land which has so fallen.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Landslide = 13,
        [System.ComponentModel.Description("The substance that results from the cooling of molten rock.")]
        [System.Xml.Serialization.XmlEnum("14")]
        LavaFlow = 14,
        [System.ComponentModel.Description("Shallow pools of brackish water used for the natural evaporation of sea water to obtain salt.")]
        [System.Xml.Serialization.XmlEnum("15")]
        SaltPan = 15,
        [System.ComponentModel.Description("Any accumulation of loose material deposited by a glacier.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Moraine = 16,
        [System.ComponentModel.Description("Bowl-shaped cavity, at the summit or on the side of a volcano.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Crater = 17,
        [System.ComponentModel.Description("A natural subterranean chamber or series of chambers open to the earth's surface.")]
        [System.Xml.Serialization.XmlEnum("18")]
        Cave = 18,
        [System.ComponentModel.Description("Any high tower or spire-shaped pillar of rock, alone or cresting a summit.")]
        [System.Xml.Serialization.XmlEnum("19")]
        RockColumnOrPinnacle = 19,
        [System.ComponentModel.Description("A small insular feature usually with scant vegetation; usually of sand or coral. Often applied to smaller coral shoals.")]
        [System.Xml.Serialization.XmlEnum("20")]
        Cay = 20,
        [System.ComponentModel.Description("A watercourse that is permanently dry or dry except for the rainy season.")]
        [System.Xml.Serialization.XmlEnum("21")]
        Wadi = 21,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfLandmark : int
    {
        [System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Cairn = 1,
        [System.ComponentModel.Description("A site and associated structures devoted to the burial of the dead.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Cemetery = 2,
        [System.ComponentModel.Description("A vertical structure containing a passage or flue for discharging smoke and gases of combustion.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Chimney = 3,
        [System.ComponentModel.Description("A parabolic aerial for the receipt and transmission of high frequency radio signals.")]
        [System.Xml.Serialization.XmlEnum("4")]
        DishAerial = 4,
        [System.ComponentModel.Description("A staff or pole on which flags are raised.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Flagstaff = 5,
        [System.ComponentModel.Description("A tall structure used for burning-off waste oil or gas.")]
        [System.Xml.Serialization.XmlEnum("6")]
        FlareStack = 6,
        [System.ComponentModel.Description("A relatively tall structure usually held vertical by guy lines.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Mast = 7,
        [System.ComponentModel.Description("A tapered fabric sleeve mounted so as to catch and swing with the wind, thus indicating the wind direction.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Windsock = 8,
        [System.ComponentModel.Description("A structure erected and/or maintained as a memorial to a person and/or event.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Monument = 9,
        [System.ComponentModel.Description("A cylindrical or slightly tapering body of considerably greater length than diameter erected vertically.")]
        [System.Xml.Serialization.XmlEnum("10")]
        ColumnPillar = 10,
        [System.ComponentModel.Description("A slab of metal, usually ornamented, erected as a memorial to a person or event.")]
        [System.Xml.Serialization.XmlEnum("11")]
        MemorialPlaque = 11,
        [System.ComponentModel.Description("A tapering shaft usually of stone or concrete, square or rectangular in section, with a pyramidal apex.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Obelisk = 12,
        [System.ComponentModel.Description("A representation of a living being, sculptured, moulded, or cast in a variety of materials (for example: marble, metal, or plaster).")]
        [System.Xml.Serialization.XmlEnum("13")]
        Statue = 13,
        [System.ComponentModel.Description("A monument, or other structure in form of a cross.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Cross = 14,
        [System.ComponentModel.Description("A landmark comprising a hemispherical or spheroidal shaped structure.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Dome = 15,
        [System.ComponentModel.Description("A device used for directing a radar beam through a search pattern.")]
        [System.Xml.Serialization.XmlEnum("16")]
        RadarScanner = 16,
        [System.ComponentModel.Description("A relatively tall, narrow structure that may either stand alone or may form part of another structure.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Tower = 17,
        [System.ComponentModel.Description("A system of vanes attached to a tower and driven by wind (excluding wind turbines).")]
        [System.Xml.Serialization.XmlEnum("18")]
        Windmill = 18,
        [System.ComponentModel.Description("A tall conical or pyramid-shaped structure often built on the roof or tower of a building, especially a church or mosque.")]
        [System.Xml.Serialization.XmlEnum("20")]
        SpireMinaret = 20,
        [System.ComponentModel.Description("An isolated rocky formation or a single large stone.")]
        [System.Xml.Serialization.XmlEnum("21")]
        LargeRockOrBoulderOnLand = 21,
        [System.ComponentModel.Description("A recoverable point on the earth, whose geographic position has been determined by angular methods with geodetic instruments. A triangulation point is a selected point, which has been marked with a station mark, or it is a conspicuous natural or artificial feature.")]
        [System.Xml.Serialization.XmlEnum("22")]
        TriangulationMark = 22,
        [System.ComponentModel.Description("A marker identifying the location of a surveyed boundary line.")]
        [System.Xml.Serialization.XmlEnum("23")]
        BoundaryMark = 23,
        [System.ComponentModel.Description("Wheels with passenger cars mounted external to the rim and independently rotated by electric motors.")]
        [System.Xml.Serialization.XmlEnum("24")]
        ObservationWheel = 24,
        [System.ComponentModel.Description("A form of decorative gateway or portal, consisting of two upright wooden posts connected at the top by two horizontal crosspieces, commonly found at the entrance to Shinto temples.")]
        [System.Xml.Serialization.XmlEnum("25")]
        Torii = 25,
        [System.ComponentModel.Description("A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians")]
        [System.Xml.Serialization.XmlEnum("26")]
        Bridge = 26,
        [System.ComponentModel.Description("A barrier to check or confine anything in motion; particularly one constructed to hold back water and raise its level to form a reservoir, or to prevent flooding.")]
        [System.Xml.Serialization.XmlEnum("27")]
        Dam = 27,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfLateralMark : int
    {
        [System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
        [System.Xml.Serialization.XmlEnum("1")]
        PortHandLateralMark = 1,
        [System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
        [System.Xml.Serialization.XmlEnum("2")]
        StarboardHandLateralMark = 2,
        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
        [System.Xml.Serialization.XmlEnum("3")]
        PreferredChannelToStarboardLateralMark = 3,
        [System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
        [System.Xml.Serialization.XmlEnum("4")]
        PreferredChannelToPortLateralMark = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfLight : int
    {
        [System.ComponentModel.Description("A light associated with other lights so as to form a leading line to be followed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LeadingLight = 4,
        [System.ComponentModel.Description("An aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.")]
        [System.Xml.Serialization.XmlEnum("5")]
        AeroLight = 5,
        [System.ComponentModel.Description("A broad beam light used to illuminate a structure or area.")]
        [System.Xml.Serialization.XmlEnum("8")]
        FloodLight = 8,
        [System.ComponentModel.Description("A light whose source has a linear form generally horizontal, which can reach a length of several metres.")]
        [System.Xml.Serialization.XmlEnum("9")]
        StripLight = 9,
        [System.ComponentModel.Description("A light placed on or near the support of a main light and having a special use in navigation.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SubsidiaryLight = 10,
        [System.ComponentModel.Description("A powerful light focused so as to illuminate a small area.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Spotlight = 11,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Front = 12,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Rear = 13,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Lower = 14,
        [System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Upper = 15,
        [System.ComponentModel.Description("A light available as a backup to a main light which will be illuminated should the main light fail.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Emergency = 17,
        [System.ComponentModel.Description("A light which enables its approximate bearing to be obtained without the use of a compass.")]
        [System.Xml.Serialization.XmlEnum("18")]
        BearingLight = 18,
        [System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed horizontally.")]
        [System.Xml.Serialization.XmlEnum("19")]
        HorizontallyDisposed = 19,
        [System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed vertically.")]
        [System.Xml.Serialization.XmlEnum("20")]
        VerticallyDisposed = 20,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfMarineFarmCulture : int
    {
        [System.ComponentModel.Description("Hard shelled animals, for example crabs or lobsters.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Crustaceans = 1,
        [System.ComponentModel.Description("A two-part hinged external shell covering that contains a soft-bodied invertebrate.")]
        [System.Xml.Serialization.XmlEnum("2")]
        EdibleBivalveMolluscs = 2,
        [System.ComponentModel.Description("Vertebrate cold blooded animal with gills, living in water.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Fish = 3,
        [System.ComponentModel.Description("The general name for marine plants of the Algae class which grow in long narrow ribbons.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Seaweed = 4,
        [System.ComponentModel.Description("An area where pearls are artificially cultivated.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PearlCultureFarm = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfMilitaryPracticeArea : int
    {
        [System.ComponentModel.Description("An area within which exercises are carried out with torpedoes.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TorpedoExerciseArea = 2,
        [System.ComponentModel.Description("An area within which submarine exercises are carried out.")]
        [System.Xml.Serialization.XmlEnum("3")]
        SubmarineExerciseArea = 3,
        [System.ComponentModel.Description("Areas for bombing and missile exercises.")]
        [System.Xml.Serialization.XmlEnum("4")]
        FiringDangerArea = 4,
        [System.ComponentModel.Description("An area within which mine laying exercises are carried out.")]
        [System.Xml.Serialization.XmlEnum("5")]
        MineLayingPracticeArea = 5,
        [System.ComponentModel.Description("An area for shooting pistols, rifles and machine guns etc. at a target.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SmallArmsFiringRange = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfMooringArea : int
    {
        [System.ComponentModel.Description("An area in which yachts and small boats moor.")]
        [System.Xml.Serialization.XmlEnum("1")]
        SmallCraftMooringArea = 1,
        [System.ComponentModel.Description("An area set aside for the mooring of visiting vessels.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MooringAreaForVisitors = 2,
        [System.ComponentModel.Description("An area set aside for the mooring of tankers.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MooringAreaForTankers = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfNavigationLine : int
    {
        [System.ComponentModel.Description("A straight line that marks the boundary between a safe and a dangerous area or that passes clear of a navigational danger.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ClearingLine = 1,
        [System.ComponentModel.Description("A line passing through one or more fixed marks.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TransitLine = 2,
        [System.ComponentModel.Description("A line passing through one or more clearly defined objects, along the path of which a vessel can approach safely up to a certain distance off.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LeadingLineBearingARecommendedTrack = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfObstruction : int
    {
        [System.ComponentModel.Description("A tree, branch or broken pile embedded in the ocean floor, river or lake bottom and not visible on the surface, forming thereby a hazard to vessels.")]
        [System.Xml.Serialization.XmlEnum("1")]
        SnagStump = 1,
        [System.ComponentModel.Description("A submarine structure projecting some distance above the seabed and capping a temporarily abandoned or suspended oil or gas well.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Wellhead = 2,
        [System.ComponentModel.Description("A structure on an outfall through which liquids are discharged. The structure will usually project above the level of the outfall and can be an obstruction to navigation.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Diffuser = 3,
        [System.ComponentModel.Description("A permanent marine structure usually designed to support or elevate pipelines; especially a structure enclosing a screening device at the offshore end of a potable water intake pipe. The structure is commonly a heavy timber enclosure that has been sunken with rocks or other debris.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Crib = 4,
        [System.ComponentModel.Description("Areas established by private interests, usually sport fishermen, to simulate natural reefs and wrecks that attract fish. The reefs are constructed by dumping assorted junk in areas which may be of very small extent or may stretch a considerable distance along a depth contour.")]
        [System.Xml.Serialization.XmlEnum("5")]
        FishHaven = 5,
        [System.ComponentModel.Description("An area of numerous unidentified dangers to navigation. The area serves as a warning to the mariner that all dangers are not identified individually and that navigation through the area may be hazardous.")]
        [System.Xml.Serialization.XmlEnum("6")]
        FoulArea = 6,
        [System.ComponentModel.Description("Floating barriers, anchored to the bottom, used to deflect the path of floating ice in order to prevent the obstruction of locks, intakes, etc., and to prevent damage to bridge piers and other structures.")]
        [System.Xml.Serialization.XmlEnum("8")]
        IceBoom = 8,
        [System.ComponentModel.Description("Equipment such as anchors, concrete blocks, chains and cables, etc., used to position floating structures such as trot and mooring buoys etc.")]
        [System.Xml.Serialization.XmlEnum("9")]
        GroundTackle = 9,
        [System.ComponentModel.Description("A floating barrier used to protect a river or harbour mouth or to create a sheltered area for storage purposes.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Boom = 10,
        [System.ComponentModel.Description("A device to extract energy from the surface motion of ocean waves or from pressure fluctuations below the surface.")]
        [System.Xml.Serialization.XmlEnum("12")]
        WaveEnergyDevice = 12,
        [System.ComponentModel.Description("A submerged device, not being a ship, together with its appurtenant equipment, deployed at sea essentially for the purpose of collecting, storing or transmitting samples or data relating to the marine environment.")]
        [System.Xml.Serialization.XmlEnum("13")]
        SubsurfaceOceanDataAcquisitionSystem = 13,
        [System.ComponentModel.Description("A man-made structure that may mimic some of the characteristics of a natural reef, intended to attract sea life.")]
        [System.Xml.Serialization.XmlEnum("14")]
        ArtificialReef = 14,
        [System.ComponentModel.Description("A structure placed on the seafloor below a drilling rig to guide the drill.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Template = 15,
        [System.ComponentModel.Description("A large steel structure up to 20 metres in height above the seafloor, or a steel frame secured to the seafloor with piles to anchor the end of a submarine pipeline, for delivery to a production platform.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Manifold = 16,
        [System.ComponentModel.Description("A hill of soil-covered ice pushed up by hydrostatic pressure in an area of permafrost that is located underwater.")]
        [System.Xml.Serialization.XmlEnum("17")]
        SubmergedPingo = 17,
        [System.ComponentModel.Description("The distributed remains of a platform.")]
        [System.Xml.Serialization.XmlEnum("18")]
        RemainsOfPlatform = 18,
        [System.ComponentModel.Description("An instrument used for scientific purposes.")]
        [System.Xml.Serialization.XmlEnum("19")]
        ScientificInstrument = 19,
        [System.ComponentModel.Description("Any of various machines having a rotor, usually with vanes or blades, driven by the pressure, momentum, or reactive thrust of a moving fluid, as steam, water, hot gases, or air, either occurring in the form of free jets or as a fluid passing through and entirely filling a housing around the rotor and is located underwater.")]
        [System.Xml.Serialization.XmlEnum("20")]
        UnderwaterTurbine = 20,
        [System.ComponentModel.Description("An active seabed volcano, which may be submerged or projecting above the water at the chart sounding datum.")]
        [System.Xml.Serialization.XmlEnum("21")]
        ActiveSubmarineVolcano = 21,
        [System.ComponentModel.Description("A submerged net placed around beaches to reduce shark attacks on swimmers.")]
        [System.Xml.Serialization.XmlEnum("22")]
        SharkNet = 22,
        [System.ComponentModel.Description("One of several genera of tropical trees or shrubs which produce many prop roots and grow along low-lying coasts into shallow water.")]
        [System.Xml.Serialization.XmlEnum("23")]
        Mangrove = 23,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfOffshorePlatform : int
    {
        [System.ComponentModel.Description("A temporary mobile structure, either fixed or floating, used in the exploration stages of oil and gas fields.")]
        [System.Xml.Serialization.XmlEnum("1")]
        OilRig = 1,
        [System.ComponentModel.Description("A term used to indicate a permanent offshore structure equipped to control the flow of oil or gas. It does not include entirely submarine structures.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ProductionPlatform = 2,
        [System.ComponentModel.Description("A platform from which one's surroundings or events can be observed, noted or recorded such as for scientific study.")]
        [System.Xml.Serialization.XmlEnum("3")]
        ObservationResearchPlatform = 3,
        [System.ComponentModel.Description("A metal lattice tower, buoyant at one end and attached at the other by a universal joint to a concrete filled base on the seabed. The platform may be fitted with a helicopter platform, emergency accommodation and hawser/hose retrieval.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ArticulatedLoadingPlatform = 4,
        [System.ComponentModel.Description("A rigid frame or tube with a buoyancy device at its upper end, secured at its lower end to a universal joint on a large steel or concrete base resting on the seabed, and at its upper end to a mooring buoy by a chain or wire.")]
        [System.Xml.Serialization.XmlEnum("5")]
        SingleAnchorLegMooring = 5,
        [System.ComponentModel.Description("A platform secured to the seabed and surmounted by a turntable to which ships moor.")]
        [System.Xml.Serialization.XmlEnum("6")]
        MooringTower = 6,
        [System.ComponentModel.Description("A man-made structure usually built for the exploration or exploitation of marine resources, marine scientific research, tidal observations, etc.")]
        [System.Xml.Serialization.XmlEnum("7")]
        ArtificialIsland = 7,
        [System.ComponentModel.Description("An offshore facility consisting of a moored tanker/barge by which the product is extracted, stored and exported.")]
        [System.Xml.Serialization.XmlEnum("8")]
        FloatingProductionStorageAndOffLoadingVessel = 8,
        [System.ComponentModel.Description("A platform used primarily for eating, sleeping and recreation purposes.")]
        [System.Xml.Serialization.XmlEnum("9")]
        AccommodationPlatform = 9,
        [System.ComponentModel.Description("A floating structure with control room, power and storage facilities, attached to the seabed by a flexible pipeline and cables.")]
        [System.Xml.Serialization.XmlEnum("10")]
        NavigationCommunicationAndControlBuoy = 10,
        [System.ComponentModel.Description("A floating structure, anchored to the seabed, for storing oil.")]
        [System.Xml.Serialization.XmlEnum("11")]
        FloatingOilTank = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfOffshoreProductionArea : int
    {
        [System.ComponentModel.Description("A collection of wind turbines that are collocated and are organized as a single power generation unit.")]
        [System.Xml.Serialization.XmlEnum("1")]
        WindFarm = 1,
        [System.ComponentModel.Description("A collection of collocated devices which harness wave energy and are organized as a single power generation unit.")]
        [System.Xml.Serialization.XmlEnum("2")]
        WaveFarm = 2,
        [System.ComponentModel.Description("A collection of collocated devices which harness current (for example tidal) energy and are organized as a single power generation unit.")]
        [System.Xml.Serialization.XmlEnum("3")]
        CurrentFarm = 3,
        [System.ComponentModel.Description("A collection of collocated large-capacity tanks in which petroleum, natural gas, or liquid petrochemicals are stored.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TankFarm = 4,
        [System.ComponentModel.Description("An area in which materials forming, or under, the seabed are removed.")]
        [System.Xml.Serialization.XmlEnum("5")]
        SeabedMaterialExtractionArea = 5,
        [System.ComponentModel.Description("A large-scale photovoltaic system (PV system) designed for the supply of merchant power into the electricity grid. They are differentiated from most building-mounted and other decentralised solar power applications because they supply power at the utility level, rather than to a local user or users. The generic expression utility-scale solar is sometimes used to describe this type of project.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SolarFarm = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfOilBarrier : int
    {
        [System.ComponentModel.Description("A pipe with holes from which air blows. When the air bubbles reach the surface they form a barrier which prevents the spread of oil.")]
        [System.Xml.Serialization.XmlEnum("1")]
        OilRetentionHighPressurePipe = 1,
        [System.ComponentModel.Description("A floating tube shaped structure, with a curtain (2 metre) hanging under it, below the surface, which prevents the spread of oil.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FloatingOilBarrier = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfOpeningBridge : int
    {
        [System.ComponentModel.Description("A movable bridge (or span thereof) which rotates in a horizontal plane about a vertical pivot to allow the passage of vessels.")]
        [System.Xml.Serialization.XmlEnum("3")]
        SwingBridge = 3,
        [System.ComponentModel.Description("A movable bridge (or span thereof) which is capable of being lifted vertically to allow vessels to pass beneath.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LiftingBridge = 4,
        [System.ComponentModel.Description("A counterpoise bridge rotated in a vertical plane about an axis at one or both ends.")]
        [System.Xml.Serialization.XmlEnum("5")]
        BasculeBridge = 5,
        [System.ComponentModel.Description("A general name for bridges of which part or the entire span of the bridge may be raised or drawn aside to allow ships to pass through.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Drawbridge = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfPile : int
    {
        [System.ComponentModel.Description("An elongated wood or metal pole embedded in the seabed to serve as a marker or support.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Stake = 1,
        [System.ComponentModel.Description("A vertical piece of timber, metal or concrete forced into the earth or seabed.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Post = 3,
        [System.ComponentModel.Description("A single structure comprising 3 or more piles held together (sections of heavy timber, steel or concrete), and forced into the earth or seabed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Tripodal = 4,
        [System.ComponentModel.Description("A number of piles, usually in a straight line, and usually connected or bolted together.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Piling = 5,
        [System.ComponentModel.Description("A number of piles, usually in a straight line, but not connected by structural members.")]
        [System.Xml.Serialization.XmlEnum("6")]
        AreaOfPiles = 6,
        [System.ComponentModel.Description("A vertical hollow cylinder of metal, wood, or other material forced into the earth or seabed.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Pipe = 7,
        [System.ComponentModel.Description("A post where to which something (such as a craft) can be moored.")]
        [System.Xml.Serialization.XmlEnum("8")]
        MooringPost = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfPilotBoardingPlace : int
    {
        [System.ComponentModel.Description("Pilot boards from a cruising vessel.")]
        [System.Xml.Serialization.XmlEnum("1")]
        BoardingByPilotCruisingVessel = 1,
        [System.ComponentModel.Description("Pilot boards by helicopter which comes out from the shore.")]
        [System.Xml.Serialization.XmlEnum("2")]
        BoardingByHelicopter = 2,
        [System.ComponentModel.Description("Pilot embarks from a vessel or disembarks to a vessel which comes out from the shore on request.")]
        [System.Xml.Serialization.XmlEnum("3")]
        PilotComesOutFromShore = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfPipelinePipe : int
    {
        [System.ComponentModel.Description("A pipe (generally a sewer or drainage pipe) discharging into the sea or a river.")]
        [System.Xml.Serialization.XmlEnum("2")]
        OutfallPipe = 2,
        [System.ComponentModel.Description("A pipe taking water from a river or other body of water, to drive a mill or supply a canal, waterworks, etc.")]
        [System.Xml.Serialization.XmlEnum("3")]
        IntakePipe = 3,
        [System.ComponentModel.Description("A pipe in a sewage system for carrying water or sewage to a disposal area.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Sewer = 4,
        [System.ComponentModel.Description("A submerged pipe from which warm water bubbles, preventing the surrounding water from freezing.")]
        [System.Xml.Serialization.XmlEnum("5")]
        BubblerSystem = 5,
        [System.ComponentModel.Description("A pipe used for transport (supply) of gas or liquid product.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SupplyPipe = 6,
        [System.ComponentModel.Description("A high pressure sub-surface pipeline (usually on the seafloor) with holes emitting a curtain of air bubbles. Its uses include: the prevention of acoustic transmission through the water; preventing the spread of surface debris or floating liquids; controlling the movement of fish.")]
        [System.Xml.Serialization.XmlEnum("7")]
        BubbleCurtain = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfPreference : int
    {
        [System.ComponentModel.Description("The preferred first choice used in normal conditions.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Primary = 1,
        [System.ComponentModel.Description("The preferred choice in extraordinary conditions.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Alternate = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfProductionArea : int
    {
        [System.ComponentModel.Description("An open-air excavation for the extraction of stone intended principally for use in construction.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Quarry = 1,
        [System.ComponentModel.Description("An excavation made in the terrain for the purpose of extracting and/or exploiting natural resources.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Mine = 2,
        [System.ComponentModel.Description("A reserve stock of material, equipment or other supplies.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Stockpile = 3,
        [System.ComponentModel.Description("A facility including one or more buildings and equipment used for power generation.")]
        [System.Xml.Serialization.XmlEnum("4")]
        PowerStationArea = 4,
        [System.ComponentModel.Description("A facility where petroleum and/or petroleum products are refined.")]
        [System.Xml.Serialization.XmlEnum("5")]
        RefineryArea = 5,
        [System.ComponentModel.Description("An open tract for the storage of wooden lumber and timbers.")]
        [System.Xml.Serialization.XmlEnum("6")]
        TimberYard = 6,
        [System.ComponentModel.Description("A group of buildings where goods are manufactured.")]
        [System.Xml.Serialization.XmlEnum("7")]
        FactoryArea = 7,
        [System.ComponentModel.Description("A collection of collocated large-capacity tanks in which petroleum, natural gas, or liquid petrochemicals are stored.")]
        [System.Xml.Serialization.XmlEnum("8")]
        TankFarm = 8,
        [System.ComponentModel.Description("A collection of wind turbines that are collocated and are organized as a single power generation unit.")]
        [System.Xml.Serialization.XmlEnum("9")]
        WindFarm = 9,
        [System.ComponentModel.Description("Hill of refuse from a mine, industrial plant etc. on land.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SlagHeapSpoilHeap = 10,
        [System.ComponentModel.Description("A plant where production takes place.")]
        [System.Xml.Serialization.XmlEnum("11")]
        ProductionPlant = 11,
        [System.ComponentModel.Description("A large-scale photovoltaic system (PV system) designed for the supply of merchant power into the electricity grid. They are differentiated from most building-mounted and other decentralised solar power applications because they supply power at the utility level, rather than to a local user or users. The generic expression utility-scale solar is sometimes used to describe this type of project.")]
        [System.Xml.Serialization.XmlEnum("12")]
        SolarFarm = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfPylon : int
    {
        [System.ComponentModel.Description("A pylon or pole that supports one or more power lines.")]
        [System.Xml.Serialization.XmlEnum("1")]
        PowerTransmissionPylonPole = 1,
        [System.ComponentModel.Description("A pylon or pole that supports one or more communication lines.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TelephoneTelegraphPylonPole = 2,
        [System.ComponentModel.Description("A tower or pylon supporting steel cables which convey cars, buckets, or other suspended carrier units.")]
        [System.Xml.Serialization.XmlEnum("3")]
        AerialCablewayPylon = 3,
        [System.ComponentModel.Description("A tower and/or pylon from which the deck of a bridge is suspended.")]
        [System.Xml.Serialization.XmlEnum("4")]
        BridgePylonTower = 4,
        [System.ComponentModel.Description("A pillar or abutment that supports a bridge span.")]
        [System.Xml.Serialization.XmlEnum("5")]
        BridgePier = 5,
        [System.ComponentModel.Description("A tower or pylon supporting a suspended pipeline or pipelines.")]
        [System.Xml.Serialization.XmlEnum("6")]
        PipelinePylon = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRadarStation : int
    {
        [System.ComponentModel.Description("A radar station established for traffic surveillance.")]
        [System.Xml.Serialization.XmlEnum("1")]
        RadarSurveillanceStation = 1,
        [System.ComponentModel.Description("A shore-based station which the mariner can contact by radio to obtain a position.")]
        [System.Xml.Serialization.XmlEnum("2")]
        CoastRadarStation = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRadarTransponderBeacon : int
    {
        [System.ComponentModel.Description("A radar marker beacon which continuously transmits a signal appearing as a radial line on a radar screen, the line indicating the direction of the beacon. Ramarks are intended primarily for marine use. The name 'ramark' is derived from the words radar marker.")]
        [System.Xml.Serialization.XmlEnum("1")]
        RamarkRadarBeaconTransmittingContinuously = 1,
        [System.ComponentModel.Description("A radar beacon which returns a coded signal which provides identification of the beacon, as well as range and bearing. The range and bearing are indicated by the location of the first character received on the radar screen. The name 'racon' is derived from the words radar beacon.")]
        [System.Xml.Serialization.XmlEnum("2")]
        RaconRadarTransponderBeacon = 2,
        [System.ComponentModel.Description("A radar beacon that may be used (in conjunction with at least one other radar beacon) to indicate a leading line.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LeadingRaconRadarTransponderBeacon = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRadioStation : int
    {
        [System.ComponentModel.Description("A radio station intended to determine only the direction of other stations by means of transmission from the latter.")]
        [System.Xml.Serialization.XmlEnum("5")]
        RadioDirectionFindingStation = 5,
        [System.ComponentModel.Description("Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.")]
        [System.Xml.Serialization.XmlEnum("10")]
        DifferentialGnss = 10,
        [System.ComponentModel.Description("An electronic position fixing system used mainly by aircraft.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Toran = 11,
        [System.ComponentModel.Description("A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Chaika = 14,
        [System.ComponentModel.Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
        [System.Xml.Serialization.XmlEnum("19")]
        RadioTelephoneStation = 19,
        [System.ComponentModel.Description("An AIS shore station for use by competent authorities to provide AIS service, manage the data link and enable effective ship to shore / shore to ship transmission of information.")]
        [System.Xml.Serialization.XmlEnum("20")]
        AisBaseStation = 20,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRescueStation : int
    {
        [System.ComponentModel.Description("A place where equipment for saving life at sea is maintained; the type of lifeboat may vary from fast, long distance boats to inflatable inshore boats.")]
        [System.Xml.Serialization.XmlEnum("1")]
        RescueStationWithLifeboat = 1,
        [System.ComponentModel.Description("A life saving station equipped with line-carrying rocket apparatus.")]
        [System.Xml.Serialization.XmlEnum("2")]
        RescueStationWithRocket = 2,
        [System.ComponentModel.Description("Shelter or protection from danger or distress at sea.")]
        [System.Xml.Serialization.XmlEnum("4")]
        RefugeForShipwreckedMariners = 4,
        [System.ComponentModel.Description("Shelter or protection from danger in areas exposed to extreme and sudden tides or tidal streams.")]
        [System.Xml.Serialization.XmlEnum("5")]
        RefugeForIntertidalAreaWalkers = 5,
        [System.ComponentModel.Description("A place where a lifeboat is moored ready for use.")]
        [System.Xml.Serialization.XmlEnum("6")]
        LifeboatLyingAtAMooring = 6,
        [System.ComponentModel.Description("A radio station reserved for emergency situations; might also be a public telephone.")]
        [System.Xml.Serialization.XmlEnum("7")]
        AidRadioStation = 7,
        [System.ComponentModel.Description("A place where first aid equipment is available.")]
        [System.Xml.Serialization.XmlEnum("8")]
        FirstAidEquipment = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRestrictedArea : int
    {
        [System.ComponentModel.Description("The area around an offshore installation within which vessels are prohibited from entering without permission. Special regulations protect installations within a safety zone and vessels of all nationalities are required to respect the zone.")]
        [System.Xml.Serialization.XmlEnum("1")]
        OffshoreSafetyZone = 1,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
        [System.Xml.Serialization.XmlEnum("4")]
        NatureReserve = 4,
        [System.ComponentModel.Description("A place where birds are bred and protected.")]
        [System.Xml.Serialization.XmlEnum("5")]
        BirdSanctuary = 5,
        [System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
        [System.Xml.Serialization.XmlEnum("6")]
        GameReserve = 6,
        [System.ComponentModel.Description("A place where seals are protected.")]
        [System.Xml.Serialization.XmlEnum("7")]
        SealSanctuary = 7,
        [System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the seabed in the range and there are cables leading from the range to a control position ashore.")]
        [System.Xml.Serialization.XmlEnum("8")]
        DegaussingRange = 8,
        [System.ComponentModel.Description("An area controlled by the military in which restrictions may apply.")]
        [System.Xml.Serialization.XmlEnum("9")]
        MilitaryArea = 9,
        [System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
        [System.Xml.Serialization.XmlEnum("10")]
        HistoricWreckArea = 10,
        [System.ComponentModel.Description("An area around a navigational aid which vessels are prohibited from entering.")]
        [System.Xml.Serialization.XmlEnum("12")]
        NavigationalAidSafetyZone = 12,
        [System.ComponentModel.Description("An area laid and maintained with explosive mines for defence or practice purposes.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Minefield = 14,
        [System.ComponentModel.Description("An area in which people may swim and therefore vessel movement may be restricted.")]
        [System.Xml.Serialization.XmlEnum("18")]
        SwimmingArea = 18,
        [System.ComponentModel.Description("An area reserved for vessels waiting to enter a harbour.")]
        [System.Xml.Serialization.XmlEnum("19")]
        WaitingArea = 19,
        [System.ComponentModel.Description("An area where marine research takes place.")]
        [System.Xml.Serialization.XmlEnum("20")]
        ResearchArea = 20,
        [System.ComponentModel.Description("An area where dredging is taking place.")]
        [System.Xml.Serialization.XmlEnum("21")]
        DredgingArea = 21,
        [System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
        [System.Xml.Serialization.XmlEnum("22")]
        FishSanctuary = 22,
        [System.ComponentModel.Description("A tract of land or water managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        [System.Xml.Serialization.XmlEnum("23")]
        EcologicalReserve = 23,
        [System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
        [System.Xml.Serialization.XmlEnum("24")]
        NoWakeArea = 24,
        [System.ComponentModel.Description("An area where vessels turn.")]
        [System.Xml.Serialization.XmlEnum("25")]
        SwingingArea = 25,
        [System.ComponentModel.Description("A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.")]
        [System.Xml.Serialization.XmlEnum("27")]
        EnvironmentallySensitiveSeaArea = 27,
        [System.ComponentModel.Description("An area that needs special protection through action by IMO because of its significance for regional ecological, socio-economic or scientific reasons and because it may be vulnerable to damage by international shipping activities.")]
        [System.Xml.Serialization.XmlEnum("28")]
        ParticularlySensitiveSeaArea = 28,
        [System.ComponentModel.Description("An area near a fairway where vessels can go to clear the way or make an about turn and possibly return to a waiting area when nautical conditions impose it.")]
        [System.Xml.Serialization.XmlEnum("29")]
        DisengagementArea = 29,
        [System.ComponentModel.Description("An area in which defence, law and treaty enforcement, and counter-terrorism activities that fall within the port and maritime domain apply.")]
        [System.Xml.Serialization.XmlEnum("30")]
        PortSecurityArea = 30,
        [System.ComponentModel.Description("A place where coral is protected.")]
        [System.Xml.Serialization.XmlEnum("31")]
        CoralSanctuary = 31,
        [System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
        [System.Xml.Serialization.XmlEnum("32")]
        RecreationArea = 32,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRoad : int
    {
        [System.ComponentModel.Description("A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Motorway = 1,
        [System.ComponentModel.Description("A hard surfaced (metalled) road; a main through route.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MajorRoad = 2,
        [System.ComponentModel.Description("A secondary road for local traffic.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MinorRoad = 3,
        [System.ComponentModel.Description("Track - a rough path or way formed by use. Path - a way or track laid down for walking or made by continual treading.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TrackPath = 4,
        [System.ComponentModel.Description("A main road, in an urban area, for through traffic.")]
        [System.Xml.Serialization.XmlEnum("5")]
        MajorStreet = 5,
        [System.ComponentModel.Description("A secondary road, in an urban area, for local traffic.")]
        [System.Xml.Serialization.XmlEnum("6")]
        MinorStreet = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSchedule : int
    {
        [System.ComponentModel.Description("The service, office, is open, fully manned, and operating normally, or the area is accessible as usual.")]
        [System.Xml.Serialization.XmlEnum("1")]
        NormalOperation = 1,
        [System.ComponentModel.Description("The service, office, or area is closed.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Closure = 2,
        [System.ComponentModel.Description("The service is available but not manned.")]
        [System.Xml.Serialization.XmlEnum("3")]
        UnmannedOperation = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSeaArea : int
    {
        [System.ComponentModel.Description("A natural or artificial passage or channel through shoals or steep banks, or across a line of banks lying between two channels.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Gat = 2,
        [System.ComponentModel.Description("An elevation of the seafloor, at depths generally less than 200 m, but sufficient for safe surface navigation, commonly found on the continental shelf or near an island.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Bank = 3,
        [System.ComponentModel.Description("In oceanography, an obsolete term which was generally restricted to depths greater than 6,000 m.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Deep = 4,
        [System.ComponentModel.Description("A wide indentation in the coastline generally smaller than a gulf and larger than a cove. For the purposes of the United Nations Convention on the Law of the Sea, a bay is a well-marked indentation whose penetration is in such proportion to the width of its mouth as to contain land locked waters and constitute more than a mere curvature of the coast.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Bay = 5,
        [System.ComponentModel.Description("A long, deep, asymmetrical depression with relatively steep sides, that is associated with subduction.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Trench = 6,
        [System.ComponentModel.Description("A depression of the seafloor more or less equidimensional in plan and of variable extent.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Basin = 7,
        [System.ComponentModel.Description("A level tract of land, as the bed of a dry lake or an area frequently uncovered at low tide. Usually in plural.")]
        [System.Xml.Serialization.XmlEnum("8")]
        MudFlats = 8,
        [System.ComponentModel.Description("A shallow elevation composed of consolidated material that may constitute a hazard to surface navigation.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Reef = 9,
        [System.ComponentModel.Description("A rocky formation continuous with and fringing the shore.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Ledge = 10,
        [System.ComponentModel.Description("An elongated, narrow, steep-sided depression that generally deepens down-slope.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Canyon = 11,
        [System.ComponentModel.Description("A navigable narrow part of a bay, strait, river, etc.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Narrows = 12,
        [System.ComponentModel.Description("A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Shoal = 13,
        [System.ComponentModel.Description("A distinct elevation with a rounded profile less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Knoll = 14,
        [System.ComponentModel.Description("An elongated elevation of varying complexity and size, generally having steep sides.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Ridge = 15,
        [System.ComponentModel.Description("A distinct generally equidimensional elevation greater than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Seamount = 16,
        [System.ComponentModel.Description("Any high tower or spire-shaped pillar or rock or coral, alone or cresting a summit. It may extend above the surface of the water. It may or may not be a hazard to surface navigation.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Pinnacle = 17,
        [System.ComponentModel.Description("An extensive, flat, gently sloping or nearly level region at abyssal depths.")]
        [System.Xml.Serialization.XmlEnum("18")]
        AbyssalPlain = 18,
        [System.ComponentModel.Description("A large, relatively flat elevation that is higher than the surrounding relief with one or more relatively steep sides.")]
        [System.Xml.Serialization.XmlEnum("19")]
        Plateau = 19,
        [System.ComponentModel.Description("A subordinate ridge protruding from a larger feature.")]
        [System.Xml.Serialization.XmlEnum("20")]
        Spur = 20,
        [System.ComponentModel.Description("The flat or gently sloping region adjacent to a continent or around an island that extends from the low water line to a depth, generally about 200m, where there is a marked increase in downward slope.")]
        [System.Xml.Serialization.XmlEnum("21")]
        Shelf = 21,
        [System.ComponentModel.Description("A long depression generally wide and flat bottomed with symmetrical and parallel sides.")]
        [System.Xml.Serialization.XmlEnum("22")]
        Trough = 22,
        [System.ComponentModel.Description("A broad pass or col in a ridge, rise or other elevation.")]
        [System.Xml.Serialization.XmlEnum("23")]
        Saddle = 23,
        [System.ComponentModel.Description("An isolated small elevation on the deep seafloor.")]
        [System.Xml.Serialization.XmlEnum("24")]
        AbyssalHill = 24,
        [System.ComponentModel.Description("A gently dipping slope, with a smooth surface, commonly found around groups of islands and seamounts.")]
        [System.Xml.Serialization.XmlEnum("25")]
        Apron = 25,
        [System.ComponentModel.Description("A gentle slope with a generally smooth surface of the seafloor, characteristically found around groups of islands or seamounts.")]
        [System.Xml.Serialization.XmlEnum("26")]
        ArchipelagicApron = 26,
        [System.ComponentModel.Description("A region adjacent to a continent, normally occupied by or bordering a shelf and sometimes emerging as islands, that is irregular or blocky in plan or profile, with depths well in excess of those typical of a shelf.")]
        [System.Xml.Serialization.XmlEnum("27")]
        Borderland = 27,
        [System.ComponentModel.Description("The zone, generally consisting of shelf, slope and continental rise, separating the continent from the deep seafloor or abyssal plain or plain. Occasionally a trench may be present in place of a continental rise.")]
        [System.Xml.Serialization.XmlEnum("28")]
        ContinentalMargin = 28,
        [System.ComponentModel.Description("A gentle slope rising from the oceanic depths towards the foot of a continental slope.")]
        [System.Xml.Serialization.XmlEnum("29")]
        ContinentalRise = 29,
        [System.ComponentModel.Description("An elongated, characteristically linear, steep slope separating horizontal or gently sloping areas of the seafloor.")]
        [System.Xml.Serialization.XmlEnum("30")]
        Escarpment = 30,
        [System.ComponentModel.Description("A relatively smooth, depositional feature continuously deepening away from a sediment source commonly located at the lower termination of a canyon or canyon system.")]
        [System.Xml.Serialization.XmlEnum("31")]
        Fan = 31,
        [System.ComponentModel.Description("A long narrow zone of irregular topography formed by the movement of tectonic plates associated with an offset of a spreading ridge axis, characterized by steep-sided and/or asymmetrical ridges, troughs or escarpments.")]
        [System.Xml.Serialization.XmlEnum("32")]
        FractureZone = 32,
        [System.ComponentModel.Description("A narrow break in a ridge, rise or other elevation.")]
        [System.Xml.Serialization.XmlEnum("33")]
        Gap = 33,
        [System.ComponentModel.Description("A seamount having a comparatively smooth flat top.")]
        [System.Xml.Serialization.XmlEnum("34")]
        Guyot = 34,
        [System.ComponentModel.Description("A distinct elevation generally of irregular shape, less than 1000m above the surrounding relief as measured from the deepest isobath that surrounds most of the feature.")]
        [System.Xml.Serialization.XmlEnum("35")]
        Hill = 35,
        [System.ComponentModel.Description("A depression of limited extent with all sides rising steeply from a relatively flat bottom.")]
        [System.Xml.Serialization.XmlEnum("36")]
        Hole = 36,
        [System.ComponentModel.Description("A depositional embankment bordering a canyon, valley or sea channel.")]
        [System.Xml.Serialization.XmlEnum("37")]
        Levee = 37,
        [System.ComponentModel.Description("The axial depression of the mid-oceanic ridge system.")]
        [System.Xml.Serialization.XmlEnum("38")]
        MedianValley = 38,
        [System.ComponentModel.Description("An annular or partially annular depression commonly located at the base of seamounts, islands and other isolated elevations.")]
        [System.Xml.Serialization.XmlEnum("39")]
        Moat = 39,
        [System.ComponentModel.Description("A natural elevation of the earth's surface rising more or less abruptly from the surrounding level, and attaining an altitude which, relatively to adjacent elevations, is impressive or notable.")]
        [System.Xml.Serialization.XmlEnum("40")]
        Mountains = 40,
        [System.ComponentModel.Description("A conical or pointed elevation on a larger feature such as a seamount.")]
        [System.Xml.Serialization.XmlEnum("41")]
        Peak = 41,
        [System.ComponentModel.Description("A geographically distinct region with a number of shared physiographic characteristics that contrast with those in the surrounding areas. This term should be modified with the generic term that best describes the majority of features in the region, for example \"Seamount\" in Baja California Seamount Province.")]
        [System.Xml.Serialization.XmlEnum("42")]
        Province = 42,
        [System.ComponentModel.Description("A broad elevation that generally rises gently and smoothly from the surrounding relief.")]
        [System.Xml.Serialization.XmlEnum("43")]
        Rise = 43,
        [System.ComponentModel.Description("An elongated, meandering depression, usually occurring on a gently sloping plain or fan.")]
        [System.Xml.Serialization.XmlEnum("44")]
        SeaChannel = 44,
        [System.ComponentModel.Description("Several seamounts in linear or arcuate alignment.")]
        [System.Xml.Serialization.XmlEnum("45")]
        SeamountChain = 45,
        [System.ComponentModel.Description("The line along which there is a marked increase in slope at the seaward margin of a shelf.")]
        [System.Xml.Serialization.XmlEnum("46")]
        ShelfEdge = 46,
        [System.ComponentModel.Description("A relatively shallow barrier between BASINS that may inhibit water movement.")]
        [System.Xml.Serialization.XmlEnum("47")]
        Sill = 47,
        [System.ComponentModel.Description("The sloping region that deepens from a shelf to the point where there is a general decrease in gradient.")]
        [System.Xml.Serialization.XmlEnum("48")]
        Slope = 48,
        [System.ComponentModel.Description("A flat or gently sloping region, generally long and narrow, bounded along one edge by a steeper descending slope and along the other by a steeper ascending slope.")]
        [System.Xml.Serialization.XmlEnum("49")]
        Terrace = 49,
        [System.ComponentModel.Description("An elongated depression that generally widens and deepens down-slope.")]
        [System.Xml.Serialization.XmlEnum("50")]
        Valley = 50,
        [System.ComponentModel.Description("An artificial waterway with no flow, or a controlled flow, used for navigation, or for draining or irrigating land (ditch).")]
        [System.Xml.Serialization.XmlEnum("51")]
        Canal = 51,
        [System.ComponentModel.Description("A large body of water entirely surrounded by land.")]
        [System.Xml.Serialization.XmlEnum("52")]
        Lake = 52,
        [System.ComponentModel.Description("A relatively large natural stream of water.")]
        [System.Xml.Serialization.XmlEnum("53")]
        River = 53,
        [System.ComponentModel.Description("A straight section of a river, especially a navigable river between two bends; or an arm of the sea extending into the land.")]
        [System.Xml.Serialization.XmlEnum("54")]
        Reach = 54,
        [System.ComponentModel.Description("A low, flat island of sand, coral, etc. awash or submerged at high water.")]
        [System.Xml.Serialization.XmlEnum("55")]
        IntertidalCay = 55,
        [System.ComponentModel.Description("A seabed volcano, submerged at the chart sounding datum, which may or may not be active.")]
        [System.Xml.Serialization.XmlEnum("56")]
        SubmarineVolcano = 56,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfShorelineConstruction : int
    {
        [System.ComponentModel.Description("A structure protecting a shore area, harbour, anchorage, or basin from waves.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Breakwater = 1,
        [System.ComponentModel.Description("A low artificial wall-like structure of durable material extending from the land to seaward for a particular purpose, such as to protect the coast or to force a current to scour a channel.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Groyne = 2,
        [System.ComponentModel.Description("A form of breakwater alongside which vessels may lie on the sheltered side only; in some cases it may lie entirely within an artificial harbour, permitting vessels to lie along both sides.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Mole = 3,
        [System.ComponentModel.Description("A long, narrow structure extending into the water to afford a berthing place for vessels, to serve as a promenade, etc.")]
        [System.Xml.Serialization.XmlEnum("4")]
        PierJetty = 4,
        [System.ComponentModel.Description("A pier built only for recreational purposes.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PromenadePier = 5,
        [System.ComponentModel.Description("A structure serving as a berthing place for vessels.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Wharf = 6,
        [System.ComponentModel.Description("A wall or bank, often submerged, built to direct or confine the flow of a river or tidal current, or to promote a scour action.")]
        [System.Xml.Serialization.XmlEnum("7")]
        TrainingWall = 7,
        [System.ComponentModel.Description("A layer of broken rock, cobbles, boulders, or fragments of sufficient size to resist the erosive forces of flowing water and wave action.")]
        [System.Xml.Serialization.XmlEnum("8")]
        RipRap = 8,
        [System.ComponentModel.Description("Facing of stone or other material, either permanent or temporary, placed along the edge of a stream, river or canal to stabilize the bank and to protect it from the erosive action of the stream.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Revetment = 9,
        [System.ComponentModel.Description("An embankment or wall for protection against waves or tidal action along a shore or water front.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SeaWall = 10,
        [System.ComponentModel.Description("Steps at the shoreline as the connection between land and water on different levels.")]
        [System.Xml.Serialization.XmlEnum("11")]
        LandingSteps = 11,
        [System.ComponentModel.Description("A sloping structure which may include rails that can either be used, as a landing place, at variable water levels, for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Ramp = 12,
        [System.ComponentModel.Description("The prepared and usually reinforced inclined surface on which keel- and bilge-blocks are laid for supporting a vessel under construction.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Slipway = 13,
        [System.ComponentModel.Description("A protective structure designed to cushion the impact of a vessel and prevent damage.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Fender = 14,
        [System.ComponentModel.Description("A wharf consisting of a solid wall of concrete, masonry, wood etc., such that the water cannot circulate freely under the wharf. The type of construction affects ship-handling; for example, a solid face wharf may give shelter from tidal streams, but under certain circumstances a cushion of water may build up between such a wharf and a ship attempting to berth at it, causing difficulties in ship handling.")]
        [System.Xml.Serialization.XmlEnum("15")]
        SolidFaceWharf = 15,
        [System.ComponentModel.Description("A wharf supported on piles or other structures which allow free circulation of water under the wharf.")]
        [System.Xml.Serialization.XmlEnum("16")]
        OpenFaceWharf = 16,
        [System.ComponentModel.Description("An inclined plane used to dump logs into the water for transport, or to haul logs out of the water for processing.")]
        [System.Xml.Serialization.XmlEnum("17")]
        LogRamp = 17,
        [System.ComponentModel.Description("An artificial pool or swimming enclosure, especially one in the open air, which may be constructed of wire mesh or heavy netting supported by cables, buoys or piles, for swimming in.")]
        [System.Xml.Serialization.XmlEnum("20")]
        SwimmingFacility = 20,
        [System.ComponentModel.Description("A wharf approximately parallel to the shoreline and accommodating ships on one side only, the other side being attached to the shore. It is usually of solid construction, as contrasted with the open pile construction usually used for piers.")]
        [System.Xml.Serialization.XmlEnum("22")]
        Quay = 22,
        [System.ComponentModel.Description("A section of wall designated for tying-up vessels awaiting transit. Bollards and mooring devices are available for both large and small ships.")]
        [System.Xml.Serialization.XmlEnum("23")]
        TieUpWall = 23,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSignalStationTraffic : int
    {
        [System.ComponentModel.Description("A signal station for the control of vessels within a port.")]
        [System.Xml.Serialization.XmlEnum("1")]
        PortControl = 1,
        [System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a port.")]
        [System.Xml.Serialization.XmlEnum("2")]
        PortEntryAndDeparture = 2,
        [System.ComponentModel.Description("A signal station displaying International Port Traffic signals.")]
        [System.Xml.Serialization.XmlEnum("3")]
        InternationalPortTraffic = 3,
        [System.ComponentModel.Description("A signal station for the control of vessels when berthing.")]
        [System.Xml.Serialization.XmlEnum("4")]
        BerthingSignalStation = 4,
        [System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a dock.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Dock = 5,
        [System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a lock.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Lock = 6,
        [System.ComponentModel.Description("A signal station for the control of vessels wishing to pass through a flood control barrage.")]
        [System.Xml.Serialization.XmlEnum("7")]
        FloodBarrageStation = 7,
        [System.ComponentModel.Description("A signal station for the control of vessels wishing to pass under a bridge.")]
        [System.Xml.Serialization.XmlEnum("8")]
        BridgePassage = 8,
        [System.ComponentModel.Description("A signal station indicating when dredging is in progress.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Dredging = 9,
        [System.ComponentModel.Description("Visual signal lights placed in a waterway to indicate to shipping the movements authorized at the time at which they are shown.")]
        [System.Xml.Serialization.XmlEnum("10")]
        TrafficControlLight = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSignalStationWarning : int
    {
        [System.ComponentModel.Description("A signal or message warning of the presence of a danger to navigation.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Danger = 1,
        [System.ComponentModel.Description("A signal or message warning of the presence of a maritime obstruction.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MaritimeObstruction = 2,
        [System.ComponentModel.Description("A signal or message warning of the presence of a cable.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Cable = 3,
        [System.ComponentModel.Description("A signal or message warning of activity in a military practice area.")]
        [System.Xml.Serialization.XmlEnum("4")]
        MilitaryPractice = 4,
        [System.ComponentModel.Description("A station that may receive or transmit distress signals.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Distress = 5,
        [System.ComponentModel.Description("A visual signal displayed to indicate a weather forecast.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Weather = 6,
        [System.ComponentModel.Description("A signal or message conveying information about storm conditions.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Storm = 7,
        [System.ComponentModel.Description("A signal or message conveying information about ice conditions.")]
        [System.Xml.Serialization.XmlEnum("8")]
        IceWarning = 8,
        [System.ComponentModel.Description("An accurate signal marking a specified time or time interval. It is used primarily for determining errors of timepieces. Such signals are usually sent from an observatory by radio, but visual signals are used at some ports.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Time = 9,
        [System.ComponentModel.Description("A signal or message conveying information on tidal conditions in the area in question.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Tide = 10,
        [System.ComponentModel.Description("A signal or message conveying information on condition of tidal currents in the area in question.")]
        [System.Xml.Serialization.XmlEnum("11")]
        TidalStream = 11,
        [System.ComponentModel.Description("A device for measuring the height of tide. A graduated staff in a sheltered area where visual observations can be made; or it may consist of an elaborate recording instrument making a continuous graphic record of tide height against time. Such an instrument is usually actuated by a float in a pipe communicating with the sea through a small hole which filters out shorter waves.")]
        [System.Xml.Serialization.XmlEnum("12")]
        TideGauge = 12,
        [System.ComponentModel.Description("A visual scale which directly shows the height of the water above chart datum or a local datum.")]
        [System.Xml.Serialization.XmlEnum("13")]
        TideScale = 13,
        [System.ComponentModel.Description("A signal or message warning of diving activity.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Diving = 14,
        [System.ComponentModel.Description("A device for measuring and conveying information about the water level (non-tidal) in the area in question.")]
        [System.Xml.Serialization.XmlEnum("15")]
        WaterLevelGauge = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSiloTank : int
    {
        [System.ComponentModel.Description("A large storage structure used for storing loose materials.")]
        [System.Xml.Serialization.XmlEnum("1")]
        SiloInGeneral = 1,
        [System.ComponentModel.Description("A fixed structure for storing liquids.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TankInGeneral = 2,
        [System.ComponentModel.Description("A storage building for grain. Usually a tall frame, metal or concrete structure with an especially compartmented interior.")]
        [System.Xml.Serialization.XmlEnum("3")]
        GrainElevator = 3,
        [System.ComponentModel.Description("A tower supporting an elevated storage tank of water.")]
        [System.Xml.Serialization.XmlEnum("4")]
        WaterTower = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSlope : int
    {
        [System.ComponentModel.Description("An excavation through high ground for a road, canal, etc.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Cutting = 1,
        [System.ComponentModel.Description("A man-made raised long mound of earth or other material.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Embankment = 2,
        [System.ComponentModel.Description("A mound, ridge or hill of drifted material on the sea coast or in a desert.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Dune = 3,
        [System.ComponentModel.Description("A small isolated elevation, smaller than a mountain.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Hill = 4,
        [System.ComponentModel.Description("A dome-shaped hill formed in a permafrost area when the hydrostatic pressure of freezing ground water causes the upheaval of a layer of frozen ground.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Pingo = 5,
        [System.ComponentModel.Description("Land rising abruptly for a considerable distance above the water or surrounding land.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Cliff = 6,
        [System.ComponentModel.Description("A mass of detritus, forming a precipitous, strong slope upon a mountain-side. Also the material composing such a slope.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Scree = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSmallCraftFacility : int
    {
        [System.ComponentModel.Description("A berth set aside for the use of visiting vessels.")]
        [System.Xml.Serialization.XmlEnum("1")]
        VisitorsBerth = 1,
        [System.ComponentModel.Description("A club for mariners generally associated with other small craft facilities.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NauticalClub = 2,
        [System.ComponentModel.Description("A hoist for lifting boats out of the water.")]
        [System.Xml.Serialization.XmlEnum("3")]
        BoatHoist = 3,
        [System.ComponentModel.Description("A place where sails are made or may be taken for repair.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Sailmaker = 4,
        [System.ComponentModel.Description("A place on shore where boats may be built, stored and repaired.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Boatyard = 5,
        [System.ComponentModel.Description("A public house providing food, drink and accommodation.")]
        [System.Xml.Serialization.XmlEnum("6")]
        PublicInn = 6,
        [System.ComponentModel.Description("A commercial establishment serving food.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Restaurant = 7,
        [System.ComponentModel.Description("A dealer in ships' supplies.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Chandler = 8,
        [System.ComponentModel.Description("A place where food and other such supplies are available.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Provisions = 9,
        [System.ComponentModel.Description("A place where a doctor is available to provide medical attention.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Doctor = 10,
        [System.ComponentModel.Description("A place where medical drugs are dispensed.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Pharmacy = 11,
        [System.ComponentModel.Description("A place where fresh water is available.")]
        [System.Xml.Serialization.XmlEnum("12")]
        WaterTap = 12,
        [System.ComponentModel.Description("A place where fuel is available.")]
        [System.Xml.Serialization.XmlEnum("13")]
        FuelStation = 13,
        [System.ComponentModel.Description("A place where a connection to an electrical supply is available.")]
        [System.Xml.Serialization.XmlEnum("14")]
        ElectricityOutlet = 14,
        [System.ComponentModel.Description("A place where bottled gas is available.")]
        [System.Xml.Serialization.XmlEnum("15")]
        BottleGas = 15,
        [System.ComponentModel.Description("A place where showers are available.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Showers = 16,
        [System.ComponentModel.Description("A place where there are facilities for washing clothes.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Launderette = 17,
        [System.ComponentModel.Description("A place where toilets are available for public use.")]
        [System.Xml.Serialization.XmlEnum("18")]
        PublicToilets = 18,
        [System.ComponentModel.Description("A place where mail may be posted.")]
        [System.Xml.Serialization.XmlEnum("19")]
        PostBox = 19,
        [System.ComponentModel.Description("A place where a telephone is available for public use.")]
        [System.Xml.Serialization.XmlEnum("20")]
        PublicTelephone = 20,
        [System.ComponentModel.Description("A place where refuse may be dumped.")]
        [System.Xml.Serialization.XmlEnum("21")]
        RefuseBin = 21,
        [System.ComponentModel.Description("A place where cars may be parked.")]
        [System.Xml.Serialization.XmlEnum("22")]
        CarPark = 22,
        [System.ComponentModel.Description("A place on shore where boats and/or trailers may be parked.")]
        [System.Xml.Serialization.XmlEnum("23")]
        ParkingForBoatsAndTrailers = 23,
        [System.ComponentModel.Description("A place where caravans may be parked or where caravan accommodation is provided.")]
        [System.Xml.Serialization.XmlEnum("24")]
        CaravanSite = 24,
        [System.ComponentModel.Description("A place where visitors may pitch tents and camp.")]
        [System.Xml.Serialization.XmlEnum("25")]
        CampingSite = 25,
        [System.ComponentModel.Description("A place where sewage may be pumped off a vessel.")]
        [System.Xml.Serialization.XmlEnum("26")]
        SewagePumpOutStation = 26,
        [System.ComponentModel.Description("A place where a telephone is available for emergency use only.")]
        [System.Xml.Serialization.XmlEnum("27")]
        EmergencyTelephone = 27,
        [System.ComponentModel.Description("A place where boats may be landed or launched.")]
        [System.Xml.Serialization.XmlEnum("28")]
        LandingLaunchingPlaceForBoats = 28,
        [System.ComponentModel.Description("A place where vessels may berth for the purpose of careening.")]
        [System.Xml.Serialization.XmlEnum("30")]
        ScrubbingBerth = 30,
        [System.ComponentModel.Description("A place where people may go to eat a picnic.")]
        [System.Xml.Serialization.XmlEnum("31")]
        PicnicArea = 31,
        [System.ComponentModel.Description("A place where mechanical repairs can be undertaken to engines or other vessel equipment.")]
        [System.Xml.Serialization.XmlEnum("32")]
        MechanicsWorkshop = 32,
        [System.ComponentModel.Description("A place where a vessel is patrolled by a security service or stored in a secure lockup.")]
        [System.Xml.Serialization.XmlEnum("33")]
        GuardAndOrSecurityService = 33,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSpecialPurposeMark : int
    {
        [System.ComponentModel.Description("A mark used to indicate a firing danger area, usually at sea.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FiringDangerMark = 1,
        [System.ComponentModel.Description("Any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TargetMark = 2,
        [System.ComponentModel.Description("A mark marking the position of a ship which is used as a target during some military exercise.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MarkerShipMark = 3,
        [System.ComponentModel.Description("A mark used to indicate a degaussing range.")]
        [System.Xml.Serialization.XmlEnum("4")]
        DegaussingRangeMark = 4,
        [System.ComponentModel.Description("A mark of relevance to barges.")]
        [System.Xml.Serialization.XmlEnum("5")]
        BargeMark = 5,
        [System.ComponentModel.Description("A mark used to indicate the position of submarine cables or the point at which they run on to the land.")]
        [System.Xml.Serialization.XmlEnum("6")]
        CableMark = 6,
        [System.ComponentModel.Description("A mark used to indicate the limit of a spoil ground.")]
        [System.Xml.Serialization.XmlEnum("7")]
        SpoilGroundMark = 7,
        [System.ComponentModel.Description("A mark used to indicate the position of an outfall or the point at which it leaves the land.")]
        [System.Xml.Serialization.XmlEnum("8")]
        OutfallMark = 8,
        [System.ComponentModel.Description("Ocean Data Acquisition System.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Odas = 9,
        [System.ComponentModel.Description("A mark used to record data for scientific purposes.")]
        [System.Xml.Serialization.XmlEnum("10")]
        RecordingMark = 10,
        [System.ComponentModel.Description("A mark used to indicate a seaplane anchorage.")]
        [System.Xml.Serialization.XmlEnum("11")]
        SeaplaneAnchorageMark = 11,
        [System.ComponentModel.Description("A mark used to indicate a recreation zone.")]
        [System.Xml.Serialization.XmlEnum("12")]
        RecreationZoneMark = 12,
        [System.ComponentModel.Description("A mark indicating a mooring or moorings.")]
        [System.Xml.Serialization.XmlEnum("14")]
        MooringMark = 14,
        [System.ComponentModel.Description("A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Lanby = 15,
        [System.ComponentModel.Description("Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
        [System.Xml.Serialization.XmlEnum("16")]
        LeadingMark = 16,
        [System.ComponentModel.Description("A mark forming part of a transit indicating one end of a measured distance.")]
        [System.Xml.Serialization.XmlEnum("17")]
        MeasuredDistanceMark = 17,
        [System.ComponentModel.Description("A notice board or sign indicating information to the mariner.")]
        [System.Xml.Serialization.XmlEnum("18")]
        NoticeMark = 18,
        [System.ComponentModel.Description("A mark indicating a Traffic Separation Scheme.")]
        [System.Xml.Serialization.XmlEnum("19")]
        TssMark = 19,
        [System.ComponentModel.Description("A mark indicating an anchoring prohibited area.")]
        [System.Xml.Serialization.XmlEnum("20")]
        AnchoringProhibitedMark = 20,
        [System.ComponentModel.Description("A mark indicating that berthing is prohibited.")]
        [System.Xml.Serialization.XmlEnum("21")]
        BerthingProhibitedMark = 21,
        [System.ComponentModel.Description("A mark indicating that overtaking is prohibited.")]
        [System.Xml.Serialization.XmlEnum("22")]
        OvertakingProhibitedMark = 22,
        [System.ComponentModel.Description("A mark indicating a one-way route.")]
        [System.Xml.Serialization.XmlEnum("23")]
        TwoWayTrafficProhibitedMark = 23,
        [System.ComponentModel.Description("A mark indicating that vessels must not generate excessive wake.")]
        [System.Xml.Serialization.XmlEnum("24")]
        ReducedWakeMark = 24,
        [System.ComponentModel.Description("A mark indicating that a speed limit applies.")]
        [System.Xml.Serialization.XmlEnum("25")]
        SpeedLimitMark = 25,
        [System.ComponentModel.Description("A mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
        [System.Xml.Serialization.XmlEnum("26")]
        StopMark = 26,
        [System.ComponentModel.Description("A mark indicating that special caution must be exercised in the vicinity of the mark.")]
        [System.Xml.Serialization.XmlEnum("27")]
        GeneralWarningMark = 27,
        [System.ComponentModel.Description("A mark indicating that a ship should sound its siren or horn.")]
        [System.Xml.Serialization.XmlEnum("28")]
        SoundShipSSirenMark = 28,
        [System.ComponentModel.Description("A mark indicating the minimum vertical space available for passage.")]
        [System.Xml.Serialization.XmlEnum("29")]
        RestrictedVerticalClearanceMark = 29,
        [System.ComponentModel.Description("A mark indicating the maximum draught of vessel permitted.")]
        [System.Xml.Serialization.XmlEnum("30")]
        MaximumVesselSDraughtMark = 30,
        [System.ComponentModel.Description("A mark indicating the minimum horizontal space available for passage.")]
        [System.Xml.Serialization.XmlEnum("31")]
        RestrictedHorizontalClearanceMark = 31,
        [System.ComponentModel.Description("A mark warning of strong currents.")]
        [System.Xml.Serialization.XmlEnum("32")]
        StrongCurrentWarningMark = 32,
        [System.ComponentModel.Description("A mark indicating that berthing is allowed.")]
        [System.Xml.Serialization.XmlEnum("33")]
        BerthingPermittedMark = 33,
        [System.ComponentModel.Description("A mark indicating an overhead power cable.")]
        [System.Xml.Serialization.XmlEnum("34")]
        OverheadPowerCableMark = 34,
        [System.ComponentModel.Description("A mark indicating the gradient of the slope of a dredge channel edge.")]
        [System.Xml.Serialization.XmlEnum("35")]
        ChannelEdgeGradientMark = 35,
        [System.ComponentModel.Description("A mark indicating the presence of a telephone.")]
        [System.Xml.Serialization.XmlEnum("36")]
        TelephoneMark = 36,
        [System.ComponentModel.Description("A mark indicating that a ferry route crosses the ship route; often used with a 'sound ship's siren' mark.")]
        [System.Xml.Serialization.XmlEnum("37")]
        FerryCrossingMark = 37,
        [System.ComponentModel.Description("A mark used to indicate the position of submarine pipelines or the point at which they run on to the land.")]
        [System.Xml.Serialization.XmlEnum("39")]
        PipelineMark = 39,
        [System.ComponentModel.Description("A mark indicating an anchorage area.")]
        [System.Xml.Serialization.XmlEnum("40")]
        AnchorageMark = 40,
        [System.ComponentModel.Description("A mark used to indicate a clearing line.")]
        [System.Xml.Serialization.XmlEnum("41")]
        ClearingMark = 41,
        [System.ComponentModel.Description("A mark indicating the location at which a restriction or requirement exists.")]
        [System.Xml.Serialization.XmlEnum("42")]
        ControlMark = 42,
        [System.ComponentModel.Description("A mark indicating that diving may take place in the vicinity.")]
        [System.Xml.Serialization.XmlEnum("43")]
        DivingMark = 43,
        [System.ComponentModel.Description("A mark providing or indicating a place of safety.")]
        [System.Xml.Serialization.XmlEnum("44")]
        RefugeBeacon = 44,
        [System.ComponentModel.Description("A mark indicating a foul ground.")]
        [System.Xml.Serialization.XmlEnum("45")]
        FoulGroundMark = 45,
        [System.ComponentModel.Description("A mark installed for use by yachtsmen.")]
        [System.Xml.Serialization.XmlEnum("46")]
        YachtingMark = 46,
        [System.ComponentModel.Description("A mark indicating an area where helicopters may land.")]
        [System.Xml.Serialization.XmlEnum("47")]
        HeliportMark = 47,
        [System.ComponentModel.Description("A mark indicating a location at which a GNSS position has been accurately determined.")]
        [System.Xml.Serialization.XmlEnum("48")]
        GnssMark = 48,
        [System.ComponentModel.Description("A mark indicating an area where seaplanes land.")]
        [System.Xml.Serialization.XmlEnum("49")]
        SeaplaneLandingMark = 49,
        [System.ComponentModel.Description("A mark indicating that entry is prohibited.")]
        [System.Xml.Serialization.XmlEnum("50")]
        EntryProhibitedMark = 50,
        [System.ComponentModel.Description("A mark indicating that work (generally construction) is in progress.")]
        [System.Xml.Serialization.XmlEnum("51")]
        WorkInProgressMark = 51,
        [System.ComponentModel.Description("A mark whose detailed characteristics are unknown.")]
        [System.Xml.Serialization.XmlEnum("52")]
        MarkWithUnknownPurpose = 52,
        [System.ComponentModel.Description("A mark indicating a borehole that produces or is capable of producing oil or natural gas.")]
        [System.Xml.Serialization.XmlEnum("53")]
        WellheadMark = 53,
        [System.ComponentModel.Description("A mark indicating the point at which a channel divides separately into two channels.")]
        [System.Xml.Serialization.XmlEnum("54")]
        ChannelSeparationMark = 54,
        [System.ComponentModel.Description("A mark indicating the existence of a fish, mussel, oyster or pearl farm/culture.")]
        [System.Xml.Serialization.XmlEnum("55")]
        MarineFarmMark = 55,
        [System.ComponentModel.Description("A mark indicating the existence or the extent of an artificial reef.")]
        [System.Xml.Serialization.XmlEnum("56")]
        ArtificialReefMark = 56,
        [System.ComponentModel.Description("A mark, used year round, that may be submerged when ice passes through the area.")]
        [System.Xml.Serialization.XmlEnum("57")]
        IceMark = 57,
        [System.ComponentModel.Description("A mark used to define the boundary of a nature reserve.")]
        [System.Xml.Serialization.XmlEnum("58")]
        NatureReserveMark = 58,
        [System.ComponentModel.Description("A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.")]
        [System.Xml.Serialization.XmlEnum("59")]
        FishAggregatingDevice = 59,
        [System.ComponentModel.Description("A mark used to indicate the existence of a wreck.")]
        [System.Xml.Serialization.XmlEnum("60")]
        WreckMark = 60,
        [System.ComponentModel.Description("A mark used to indicate the existence of a customs checkpoint.")]
        [System.Xml.Serialization.XmlEnum("61")]
        CustomsMark = 61,
        [System.ComponentModel.Description("A mark used to indicate the existence of a causeway.")]
        [System.Xml.Serialization.XmlEnum("62")]
        CausewayMark = 62,
        [System.ComponentModel.Description("A surface following buoy used to measure wave activity.")]
        [System.Xml.Serialization.XmlEnum("63")]
        WaveRecorder = 63,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfTemporalVariation : int
    {
        [System.ComponentModel.Description("Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ExtremeEvent = 1,
        [System.ComponentModel.Description("Continuous or frequent change (for example river siltation, sand waves, seasonal storms, icebergs, etc) that is likely to result in new significant shoaling.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LikelyToChangeAndSignificantShoalingExpected = 2,
        [System.ComponentModel.Description("Continuous or frequent change (for example sand wave shift, seasonal storms, icebergs, etc) that is not likely to result in new significant shoaling.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LikelyToChangeButSignificantShoalingNotExpected = 3,
        [System.ComponentModel.Description("Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).")]
        [System.Xml.Serialization.XmlEnum("4")]
        LikelyToChange = 4,
        [System.ComponentModel.Description("Significant change to the seafloor is not expected.")]
        [System.Xml.Serialization.XmlEnum("5")]
        UnlikelyToChange = 5,
        [System.ComponentModel.Description("Not having been assessed.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Unassessed = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfStructure : int
    {
        [System.ComponentModel.Description("A building or shed, usually built partly over water, for sheltering a boat or boats.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Boathouse = 1,
        [System.ComponentModel.Description("A covered or partially covered terminal for the handling of bulk materials such as iron ore, coal, etc.")]
        [System.Xml.Serialization.XmlEnum("2")]
        CoveredBulkTerminal = 2,
        [System.ComponentModel.Description("A covered or partially covered structure serving as a berthing place for vessels.")]
        [System.Xml.Serialization.XmlEnum("3")]
        CoveredWharf = 3,
        [System.ComponentModel.Description("A covered or partially covered terminal within which the floating equipment (dredges, tugs …) of harbour services are berthed and serviced.")]
        [System.Xml.Serialization.XmlEnum("4")]
        CoveredServiceTerminal = 4,
        [System.ComponentModel.Description("A covered or partially covered terminal for the loading and unloading of passengers.")]
        [System.Xml.Serialization.XmlEnum("5")]
        CoveredPassengerTerminal = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfTidalStream : int
    {
        [System.ComponentModel.Description("The horizontal movement of water associated with the rising tide. Flood streams generally set towards the shore, or in the direction of the tide progression.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FloodStream = 1,
        [System.ComponentModel.Description("The horizontal movement of water associated with falling tide. Ebb streams generally set seaward, or in the opposite direction to the tide progression.")]
        [System.Xml.Serialization.XmlEnum("2")]
        EbbStream = 2,
        [System.ComponentModel.Description("Any other horizontal movement of water associated with tides, for example rotary flow.")]
        [System.Xml.Serialization.XmlEnum("3")]
        OtherTidalFlow = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfVegetation : int
    {
        [System.ComponentModel.Description("A shrub or clump of shrubs with stems of moderate length.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Bush = 3,
        [System.ComponentModel.Description("A wood with trees that shed their leaves annually.")]
        [System.Xml.Serialization.XmlEnum("4")]
        DeciduousWood = 4,
        [System.ComponentModel.Description("A wood with evergreen trees of a group usually bearing cones, including yews, cedars and redwoods.")]
        [System.Xml.Serialization.XmlEnum("5")]
        ConiferousWood = 5,
        [System.ComponentModel.Description("Growing trees densely occupying a tract of land.")]
        [System.Xml.Serialization.XmlEnum("6")]
        WoodInGeneralIncMixedWood = 6,
        [System.ComponentModel.Description("Any of various water or marsh plants with a firm stem. (Concise Oxford English Dictionary)")]
        [System.Xml.Serialization.XmlEnum("11")]
        Reed = 11,
        [System.ComponentModel.Description("An individual woody perennial plant, typically having a single stem or trunk growing to a considerable height and bearing lateral branches at some distance from the ground.")]
        [System.Xml.Serialization.XmlEnum("13")]
        TreeInGeneral = 13,
        [System.ComponentModel.Description("Having green foliage all the year round.")]
        [System.Xml.Serialization.XmlEnum("14")]
        EvergreenTree = 14,
        [System.ComponentModel.Description("A cone-bearing, needle-leaved or scale-leaved evergreen tree.")]
        [System.Xml.Serialization.XmlEnum("15")]
        ConiferousTree = 15,
        [System.ComponentModel.Description("A tropical or sub-tropical tree, shrub or vine having a tall, unbranched, columnar trunk. The trunk is crowned by a tuft or large, pleated fan or feather shaped leaves with stout sheathing and often prickly petioles (stalks), the persistent bases of which frequently clothe the trunk.")]
        [System.Xml.Serialization.XmlEnum("16")]
        PalmTree = 16,
        [System.ComponentModel.Description("A rare palm tree with regular branching involving equal or sub-equal division of the apex that results in forking.")]
        [System.Xml.Serialization.XmlEnum("17")]
        NipaPalmTree = 17,
        [System.ComponentModel.Description("A tree characterized by slender, green, often drooping branches that are deeply grooved and that bear, at intervals, whorls of tine leaves.")]
        [System.Xml.Serialization.XmlEnum("18")]
        CasuarinaTree = 18,
        [System.ComponentModel.Description("An instance of a large genus of mostly very large trees (90 metres).")]
        [System.Xml.Serialization.XmlEnum("19")]
        EucalyptTree = 19,
        [System.ComponentModel.Description("Sheds its leaves each year at the end of the period of growth.")]
        [System.Xml.Serialization.XmlEnum("20")]
        DeciduousTree = 20,
        [System.ComponentModel.Description("Casuarina equisetifolia, the most widespread and well-known member of the family Casuarinaceae.")]
        [System.Xml.Serialization.XmlEnum("22")]
        FilaoTree = 22,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfWaterTurbulence : int
    {
        [System.ComponentModel.Description("A wave breaking on the shore, over a reef, etc. Breakers may be roughly classified into three kinds, although the categories may overlap: spilling breakers break gradually over a considerable distance; plunging breakers tend to curl over and break with a crash; and surging breakers peak up, but then instead of spilling or plunging they surge up on the beach face. The French word 'brisant' is also used for the obstacle causing the breaking of the wave.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Breakers = 1,
        [System.ComponentModel.Description("Circular movements of water usually formed where currents pass obstructions, between two adjacent currents flowing counter to each other, or along the edge of a permanent current.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Eddies = 2,
        [System.ComponentModel.Description("Short, breaking waves occurring when a strong current passes over a shoal or other submarine obstruction or meets a contrary current or wind.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Overfalls = 3,
        [System.ComponentModel.Description("Small waves formed on the surface of water by the meeting of opposing tidal currents or by a tidal current crossing an irregular bottom. Vertical oscillation, rather than progressive waves, is characteristic of tide rips.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TideRips = 4,
        [System.ComponentModel.Description("A wave that forms over a submerged offshore reef or rock, sometimes (in very calm weather or at high tide) nearly swelling but in other conditions breaking heavily and producing a dangerous stretch of broken water; the reef or rock itself.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Bombora = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfWeedKelp : int
    {
        [System.ComponentModel.Description("A giant plant sometimes 60 metres long with no roots, it is anchored by hold-fasts or tendrils up to 10 metres long, that cling to rock. Gas filled bubbles on fronds act as floats keeping the kelp just below the surface.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Kelp = 1,
        [System.ComponentModel.Description("The general name for marine plants of the Algae class which grow in long narrow ribbons.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Seaweed = 2,
        [System.ComponentModel.Description("A certain type of seaweed, or more generally, a large floating mass of this seaweed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Sargasso = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfWreck : int
    {
        [System.ComponentModel.Description("A wreck which is not considered to be dangerous to surface navigation.")]
        [System.Xml.Serialization.XmlEnum("1")]
        NonDangerousWreck = 1,
        [System.ComponentModel.Description("A wreck submerged at such a depth as to be considered dangerous to surface navigation.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DangerousWreck = 2,
        [System.ComponentModel.Description("A substantively decayed wreck over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.")]
        [System.Xml.Serialization.XmlEnum("3")]
        DistributedRemainsOfWreck = 3,
        [System.ComponentModel.Description("Wreck of which only the mast(s) is visible at the sounding datum indicated.")]
        [System.Xml.Serialization.XmlEnum("4")]
        WreckShowingMastMasts = 4,
        [System.ComponentModel.Description("Wreck of which any portion of the hull or superstructure is visible at the sounding datum indicated.")]
        [System.Xml.Serialization.XmlEnum("5")]
        WreckShowingAnyPortionOfHullOrSuperstructure = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfZoneOfConfidenceInData : int
    {
        [System.ComponentModel.Description("Positional Accuracy +/- 5 metres + 5% depth; Depth Accuracy 0.5 metre + 1% depth; Full area search undertaken. Significant seafloor features detected and depths measured; Controlled, systematic survey, high position and depth accuracy achieved using DGPS or a minimum three high quality lines of position (LOP) and a multibeam, channel or mechanical sweep system.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ZoneOfConfidenceA1 = 1,
        [System.ComponentModel.Description("Positional Accuracy +/- 20 metres; Depth Accuracy 1.0 metre + 2% depth; Full area search undertaken. Significant seafloor features detected and depths measured; Controlled, systematic survey achieving position and depth accuracy less than ZOC A1 and using a modern survey echosounder and a sonar or mechanical sweep system.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ZoneOfConfidenceA2 = 2,
        [System.ComponentModel.Description("Positional Accuracy +/- 50 metres; Depth Accuracy 1.0 metre + 2% depth; Full area search not achieved, uncharted features hazardous to surface navigation are not expected but may exist; Controlled, systematic survey achieving similar depth but lesser position accuracies than ZOCA2, using a modern survey echosounder, but no sonar or mechanical sweep system.")]
        [System.Xml.Serialization.XmlEnum("3")]
        ZoneOfConfidenceB = 3,
        [System.ComponentModel.Description("Positional Accuracy +/- 500 metres; Depth Accuracy 2.0 metre + 5% depth; Full area search not achieved, depth anomalies may be expected; Low accuracy survey or data collected on an opportunity basis such as soundings on passage.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ZoneOfConfidenceC = 4,
        [System.ComponentModel.Description("Positional Accuracy worse than ZOC C; Depth Accuracy worse than ZOC C; Full area search not achieved, large depth anomalies may be expected; Poor quality data or data that cannot be quality assessed due to lack of information.")]
        [System.Xml.Serialization.XmlEnum("5")]
        ZoneOfConfidenceD = 5,
        [System.ComponentModel.Description("The quality of the bathymetric data has yet to be assessed.")]
        [System.Xml.Serialization.XmlEnum("6")]
        ZoneOfConfidenceU = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum colour : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("1")]
        White = 1,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("2")]
        Black = 2,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("3")]
        Red = 3,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("4")]
        Green = 4,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("5")]
        Blue = 5,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("6")]
        Yellow = 6,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("7")]
        Grey = 7,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("8")]
        Brown = 8,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("9")]
        Amber = 9,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("10")]
        Violet = 10,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("11")]
        Orange = 11,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("12")]
        Magenta = 12,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("13")]
        Pink = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum colourPattern : int
    {
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented horizontally.")]
        [System.Xml.Serialization.XmlEnum("1")]
        HorizontalStripes = 1,
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented vertically.")]
        [System.Xml.Serialization.XmlEnum("2")]
        VerticalStripes = 2,
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).")]
        [System.Xml.Serialization.XmlEnum("3")]
        DiagonalStripes = 3,
        [System.ComponentModel.Description("Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Squared = 4,
        [System.ComponentModel.Description("Straight bands or stripes of differing colours oriented in an unknown direction.")]
        [System.Xml.Serialization.XmlEnum("5")]
        StripesDirectionUnknown = 5,
        [System.ComponentModel.Description("A band or stripe of colour which is displayed around the outer edge of the feature, which may also form a border to an inner pattern or plain colour.")]
        [System.Xml.Serialization.XmlEnum("6")]
        BorderStripe = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum condition : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Being built but not yet capable of function.")]
        [System.Xml.Serialization.XmlEnum("1")]
        UnderConstruction = 1,
        [System.ComponentModel.Description("A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Ruined = 2,
        [System.ComponentModel.Description("An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.")]
        [System.Xml.Serialization.XmlEnum("3")]
        UnderReclamation = 3,
        [System.ComponentModel.Description("A windmill or wind turbine from which the vanes or turbine blades are missing.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Wingless = 4,
        [System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PlannedConstruction = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum dataAssessment : int
    {
        [System.ComponentModel.Description("The quality of the bathymetric data has been assessed.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Assessed = 1,
        [System.ComponentModel.Description("The quality of oceanic bathymetric data (depths deeper than 200 metres) has been assessed, however details are not required.")]
        [System.Xml.Serialization.XmlEnum("2")]
        AssessedOceanic = 2,
        [System.ComponentModel.Description("Not having been assessed.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Unassessed = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum dayOfWeek : int
    {
        [System.ComponentModel.Description("The day of the week following Saturday and preceding Monday.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Sunday = 1,
        [System.ComponentModel.Description("The day of the week following Sunday and preceding Tuesday.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Monday = 2,
        [System.ComponentModel.Description("The day of the week following Monday and preceding Wednesday.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Tuesday = 3,
        [System.ComponentModel.Description("The day of the week following Tuesday and preceding Thursday.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Wednesday = 4,
        [System.ComponentModel.Description("The day of the week following Wednesday and preceding Friday.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Thursday = 5,
        [System.ComponentModel.Description("The day of the week following Thursday and preceding Saturday.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Friday = 6,
        [System.ComponentModel.Description("The day of the week following Friday and preceding Sunday.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Saturday = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum distanceUnitOfMeasurement : int
    {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Metres = 1,
        [System.ComponentModel.Description("A common unit of linear measure in English-speaking countries, equal to 3 feet or 36 inches, and equivalent to 0.9144 metre.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Yards = 2,
        [System.ComponentModel.Description("A unit of length, the common measure of distances equal to 1000 metres, and equivalent to 3280.8 feet or 0.621 mile.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Kilometres = 3,
        [System.ComponentModel.Description("A unit equal to 5280 feet.")]
        [System.Xml.Serialization.XmlEnum("4")]
        StatuteMiles = 4,
        [System.ComponentModel.Description("A unit of length equal to 1,852 metres. This value was approved by the International Hydrographic Conference of 1929 and has been adopted by nearly all maritime states.")]
        [System.Xml.Serialization.XmlEnum("5")]
        NauticalMiles = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum exhibitionConditionOfLight : int
    {
        [System.ComponentModel.Description("A light shown throughout the 24 hours without change of character.")]
        [System.Xml.Serialization.XmlEnum("1")]
        LightShownWithoutChangeOfCharacter = 1,
        [System.ComponentModel.Description("A light which is only exhibited by day.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DaytimeLight = 2,
        [System.ComponentModel.Description("A light which is exhibited in fog or conditions of reduced visibility.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FogLight = 3,
        [System.ComponentModel.Description("A light which is only exhibited at night.")]
        [System.Xml.Serialization.XmlEnum("4")]
        NightLight = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum expositionOfSounding : int
    {
        [System.ComponentModel.Description("The depth corresponds to the depth range of the surrounding depth area; that is, the depth is not shoaler than the minimum depth of the surrounding depth area or deeper than the maximum depth of the surrounding depth area.")]
        [System.Xml.Serialization.XmlEnum("1")]
        WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,
        [System.ComponentModel.Description("The depth is shoaler than the minimum depth of the surrounding depth area.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,
        [System.ComponentModel.Description("The depth is deeper than the maximum depth of the surrounding depth area.")]
        [System.Xml.Serialization.XmlEnum("3")]
        DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum function : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("A local official who has charge of mooring and berthing of vessels, collecting harbour fees, etc.")]
        [System.Xml.Serialization.XmlEnum("2")]
        HarbourMastersOffice = 2,
        [System.ComponentModel.Description("Serves as a government office where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
        [System.Xml.Serialization.XmlEnum("3")]
        CustomsOffice = 3,
        [System.ComponentModel.Description("The office which is charged with the administration of health laws and sanitary inspections.")]
        [System.Xml.Serialization.XmlEnum("4")]
        HealthOffice = 4,
        [System.ComponentModel.Description("An institution or establishment providing medical or surgical treatment for the ill or wounded.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Hospital = 5,
        [System.ComponentModel.Description("The public department, agency or organisation responsible primarily for the collection, transmission and distribution of mail.")]
        [System.Xml.Serialization.XmlEnum("6")]
        PostOffice = 6,
        [System.ComponentModel.Description("An establishment, especially of a comfortable or luxurious kind, where paying visitors are provided with accommodation, meals and other services.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Hotel = 7,
        [System.ComponentModel.Description("A building with platforms where trains arrive, load, discharge and depart.")]
        [System.Xml.Serialization.XmlEnum("8")]
        RailwayStation = 8,
        [System.ComponentModel.Description("The headquarters of a local police force and that is where those under arrest are first charged.")]
        [System.Xml.Serialization.XmlEnum("9")]
        PoliceStation = 9,
        [System.ComponentModel.Description("The headquarters of a local water-police force.")]
        [System.Xml.Serialization.XmlEnum("10")]
        WaterPoliceStation = 10,
        [System.ComponentModel.Description("The office or headquarters of pilots; the place where the services of a pilot may be obtained.")]
        [System.Xml.Serialization.XmlEnum("11")]
        PilotOffice = 11,
        [System.ComponentModel.Description("A distinctive structure or place on shore from which personnel keep watch upon events at sea or along the coast.")]
        [System.Xml.Serialization.XmlEnum("12")]
        PilotLookout = 12,
        [System.ComponentModel.Description("An office for custody, deposit, loan, exchange or issue of money.")]
        [System.Xml.Serialization.XmlEnum("13")]
        BankOffice = 13,
        [System.ComponentModel.Description("The quarters of an executive officer (director, manager, etc.) with responsibility for an administrative area.")]
        [System.Xml.Serialization.XmlEnum("14")]
        HeadquartersForDistrictControl = 14,
        [System.ComponentModel.Description("A building or part of a building for storage of wares or goods.")]
        [System.Xml.Serialization.XmlEnum("15")]
        TransitShedWarehouse = 15,
        [System.ComponentModel.Description("A building or buildings with equipment for manufacturing; a workshop.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Factory = 16,
        [System.ComponentModel.Description("A stationary plant containing apparatus for large scale conversion of some form of energy (such as hydraulic, steam, chemical or nuclear energy) into electrical energy.")]
        [System.Xml.Serialization.XmlEnum("17")]
        PowerStation = 17,
        [System.ComponentModel.Description("A building for the management of affairs.")]
        [System.Xml.Serialization.XmlEnum("18")]
        Administrative = 18,
        [System.ComponentModel.Description("An establishment for teaching and learning (for example school, college, university, etc).")]
        [System.Xml.Serialization.XmlEnum("19")]
        EducationalFacility = 19,
        [System.ComponentModel.Description("A building for public Christian worship.")]
        [System.Xml.Serialization.XmlEnum("20")]
        Church = 20,
        [System.ComponentModel.Description("A place for Christian worship other than a parish, cathedral or church, especially one attached to a private house or institution.")]
        [System.Xml.Serialization.XmlEnum("21")]
        Chapel = 21,
        [System.ComponentModel.Description("A building for public Jewish worship.")]
        [System.Xml.Serialization.XmlEnum("22")]
        Temple = 22,
        [System.ComponentModel.Description("A Hindu or Buddhist temple or sacred building.")]
        [System.Xml.Serialization.XmlEnum("23")]
        Pagoda = 23,
        [System.ComponentModel.Description("A building for public Shinto worship.")]
        [System.Xml.Serialization.XmlEnum("24")]
        ShintoShrine = 24,
        [System.ComponentModel.Description("A building for public Buddhist worship.")]
        [System.Xml.Serialization.XmlEnum("25")]
        BuddhistTemple = 25,
        [System.ComponentModel.Description("A Muslim place of worship.")]
        [System.Xml.Serialization.XmlEnum("26")]
        Mosque = 26,
        [System.ComponentModel.Description("A shrine marking the burial place of a Muslim holy man.")]
        [System.Xml.Serialization.XmlEnum("27")]
        Marabout = 27,
        [System.ComponentModel.Description("Keeping a watch upon events at sea or along the coast.")]
        [System.Xml.Serialization.XmlEnum("28")]
        Lookout = 28,
        [System.ComponentModel.Description("Transmitting and/or receiving electronic communication signals.")]
        [System.Xml.Serialization.XmlEnum("29")]
        Communication = 29,
        [System.ComponentModel.Description("A system for reproducing on a screen visual images transmitted (usually with sound) by radio signals.")]
        [System.Xml.Serialization.XmlEnum("30")]
        Television = 30,
        [System.ComponentModel.Description("Transmitting and/or receiving radio-frequency electromagnetic waves as a means of communication.")]
        [System.Xml.Serialization.XmlEnum("31")]
        Radio = 31,
        [System.ComponentModel.Description("A method, system or technique of using beamed, reflected, and timed radio waves for detecting, locating, or tracking objects, and for measuring altitudes.")]
        [System.Xml.Serialization.XmlEnum("32")]
        Radar = 32,
        [System.ComponentModel.Description("A structure serving as a support for one or more lights.")]
        [System.Xml.Serialization.XmlEnum("33")]
        LightSupport = 33,
        [System.ComponentModel.Description("Broadcasting and receiving signals using microwaves.")]
        [System.Xml.Serialization.XmlEnum("34")]
        Microwave = 34,
        [System.ComponentModel.Description("Generation of chilled liquid and/or gas for cooling purposes.")]
        [System.Xml.Serialization.XmlEnum("35")]
        Cooling = 35,
        [System.ComponentModel.Description("A place from which the surroundings can be observed but at which a watch is not habitually maintained.")]
        [System.Xml.Serialization.XmlEnum("36")]
        Observation = 36,
        [System.ComponentModel.Description("A visual time signal in the form of a ball.")]
        [System.Xml.Serialization.XmlEnum("37")]
        Timeball = 37,
        [System.ComponentModel.Description("Instrument for measuring time and recording hours.")]
        [System.Xml.Serialization.XmlEnum("38")]
        Clock = 38,
        [System.ComponentModel.Description("Used to control the flow of traffic within a specified range of an installation.")]
        [System.Xml.Serialization.XmlEnum("39")]
        Control = 39,
        [System.ComponentModel.Description("Equipment or structure to secure an airship.")]
        [System.Xml.Serialization.XmlEnum("40")]
        AirshipMooring = 40,
        [System.ComponentModel.Description("An arena for holding and viewing events.")]
        [System.Xml.Serialization.XmlEnum("41")]
        Stadium = 41,
        [System.ComponentModel.Description("A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.")]
        [System.Xml.Serialization.XmlEnum("42")]
        BusStation = 42,
        [System.ComponentModel.Description("A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.")]
        [System.Xml.Serialization.XmlEnum("44")]
        SeaRescueControl = 44,
        [System.ComponentModel.Description("A building designed and equipped for making observations of astronomical, meteorological, or other natural phenomena.")]
        [System.Xml.Serialization.XmlEnum("45")]
        Observatory = 45,
        [System.ComponentModel.Description("A building or structure used to crush ore.")]
        [System.Xml.Serialization.XmlEnum("46")]
        OreCrusher = 46,
        [System.ComponentModel.Description("A building or shed, usually built partly over water, for sheltering a boat or boats.")]
        [System.Xml.Serialization.XmlEnum("47")]
        Boathouse = 47,
        [System.ComponentModel.Description("A facility to move solids, liquids or gases by means of pressure or suction.")]
        [System.Xml.Serialization.XmlEnum("48")]
        PumpingStation = 48,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum jurisdiction : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Involving more than one country; covering more than one national area.")]
        [System.Xml.Serialization.XmlEnum("1")]
        International = 1,
        [System.ComponentModel.Description("An area administered or controlled by a single nation.")]
        [System.Xml.Serialization.XmlEnum("2")]
        National = 2,
        [System.ComponentModel.Description("An area smaller than the nation in which it lies.")]
        [System.Xml.Serialization.XmlEnum("3")]
        NationalSubDivision = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum lightCharacteristic : int
    {
        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Fixed = 1,
        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Flashing = 2,
        [System.ComponentModel.Description("A single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LongFlashing = 3,
        [System.ComponentModel.Description("A rhythmic light in which flashes are repeated at a rate of not less than 50 flashes per minutes but less than 80 flashes per minutes. It may be: - Continuous quick-flashing: A quick-flashing light in which a flash is regularly repeated. - Group quick-flashing: A quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
        [System.Xml.Serialization.XmlEnum("4")]
        QuickFlashing = 4,
        [System.ComponentModel.Description("A rhythmic light in which flashes are repeated at a rate of not less than 80 flashes per minute but less than 160 flashes per minute. It may be:- Continuous very quick-flashing: A very quick-flashing light in which a flash is regularly repeated.- Group very quick-flashing: A very quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
        [System.Xml.Serialization.XmlEnum("5")]
        VeryQuickFlashing = 5,
        [System.ComponentModel.Description("A rhythmic light in which flashes are regularly repeated at a rate of not less than 160 flashes per minute.")]
        [System.Xml.Serialization.XmlEnum("6")]
        ContinuousUltraQuickFlashing = 6,
        [System.ComponentModel.Description("A light with all durations of light and darkness equal.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Isophased = 7,
        [System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be:  - Single-occulting: An occulting light in which an eclipse is regularly repeated.  - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated.  - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Occulting = 8,
        [System.ComponentModel.Description("A light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.")]
        [System.Xml.Serialization.XmlEnum("11")]
        InterruptedUltraQuickFlashing = 11,
        [System.ComponentModel.Description("A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Morse = 12,
        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
        [System.Xml.Serialization.XmlEnum("13")]
        FixedAndFlash = 13,
        [System.ComponentModel.Description("A rhythmic light in which a flashing light is combined with a long-flashing light of higher luminous intensity.")]
        [System.Xml.Serialization.XmlEnum("14")]
        FlashAndLongFlash = 14,
        [System.ComponentModel.Description("A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.")]
        [System.Xml.Serialization.XmlEnum("15")]
        OccultingAndFlash = 15,
        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a long-flashing light of higher luminous intensity.")]
        [System.Xml.Serialization.XmlEnum("16")]
        FixedAndLongFlash = 16,
        [System.ComponentModel.Description("An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.")]
        [System.Xml.Serialization.XmlEnum("17")]
        OccultingAlternating = 17,
        [System.ComponentModel.Description("An alternating single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.")]
        [System.Xml.Serialization.XmlEnum("18")]
        LongFlashAlternating = 18,
        [System.ComponentModel.Description("An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        [System.Xml.Serialization.XmlEnum("19")]
        FlashAlternating = 19,
        [System.ComponentModel.Description("A rhythmic light in which a group of quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
        [System.Xml.Serialization.XmlEnum("25")]
        QuickFlashPlusLongFlash = 25,
        [System.ComponentModel.Description("A rhythmic light in which a group of very quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
        [System.Xml.Serialization.XmlEnum("26")]
        VeryQuickFlashPlusLongFlash = 26,
        [System.ComponentModel.Description("A rhythmic light in which a group of ultra quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
        [System.Xml.Serialization.XmlEnum("27")]
        UltraQuickFlashPlusLongFlash = 27,
        [System.ComponentModel.Description("A signal light that shows continuously, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
        [System.Xml.Serialization.XmlEnum("28")]
        Alternating = 28,
        [System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity and different colour.")]
        [System.Xml.Serialization.XmlEnum("29")]
        FixedAndAlternatingFlashing = 29,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum lightVisibility : int
    {
        [System.ComponentModel.Description("Non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).")]
        [System.Xml.Serialization.XmlEnum("1")]
        HighIntensity = 1,
        [System.ComponentModel.Description("Non-marine lights with lower power than marine lights.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LowIntensity = 2,
        [System.ComponentModel.Description("A decrease in the apparent intensity of a light which may occur in the case of partial obstructions.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Faint = 3,
        [System.ComponentModel.Description("A light in a sector is intensified (that is, has longer range than other sectors).")]
        [System.Xml.Serialization.XmlEnum("4")]
        Intensified = 4,
        [System.ComponentModel.Description("A light in a sector is unintensified (that is, has shorter range than other sectors).")]
        [System.Xml.Serialization.XmlEnum("5")]
        Unintensified = 5,
        [System.ComponentModel.Description("A light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.")]
        [System.Xml.Serialization.XmlEnum("6")]
        VisibilityDeliberatelyRestricted = 6,
        [System.ComponentModel.Description("Said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Obscured = 7,
        [System.ComponentModel.Description("This value specifies that parts of the sector are obscured.")]
        [System.Xml.Serialization.XmlEnum("8")]
        PartiallyObscured = 8,
        [System.ComponentModel.Description("Lights that must be in line to be visible.")]
        [System.Xml.Serialization.XmlEnum("9")]
        VisibleInLineOfRange = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum referenceDirection : int
    {
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("5")]
        East = 5,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("13")]
        West = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum marksNavigationalSystemOf : int
    {
        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.")]
        [System.Xml.Serialization.XmlEnum("1")]
        IalaA = 1,
        [System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.")]
        [System.Xml.Serialization.XmlEnum("2")]
        IalaB = 2,
        [System.ComponentModel.Description("Navigational aids do not conform to any defined system.")]
        [System.Xml.Serialization.XmlEnum("9")]
        NoSystem = 9,
        [System.ComponentModel.Description("Navigational aids as required in international, national or regional regulations that contain the same navigational aids as the European Code for Inland Waterways of UNECE, or if there is no regulation for a waterway, navigational aids as recommended in the European Code for Inland Waterways of UNECE.")]
        [System.Xml.Serialization.XmlEnum("11")]
        MainEuropeanInlandWaterwayMarkingSystem = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum nameUsage : int
    {
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
        [System.Xml.Serialization.XmlEnum("1")]
        DefaultNameDisplay = 1,
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
        [System.Xml.Serialization.XmlEnum("2")]
        AlternateNameDisplay = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum natureOfConstruction : int
    {
        [System.ComponentModel.Description("Constructed of stones or bricks, usually quarried, shaped, and mortared.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Masonry = 1,
        [System.ComponentModel.Description("Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Concreted = 2,
        [System.ComponentModel.Description("Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LooseBoulders = 3,
        [System.ComponentModel.Description("Constructed with a surface of hard material, usually a term applied to roads surfaced with asphalt or concrete.")]
        [System.Xml.Serialization.XmlEnum("4")]
        HardSurfaced = 4,
        [System.ComponentModel.Description("Constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Unsurfaced = 5,
        [System.ComponentModel.Description("Constructed from wood.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Wooden = 6,
        [System.ComponentModel.Description("Constructed from metal.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Metal = 7,
        [System.ComponentModel.Description("Constructed from a plastic material strengthened with fibres of glass.")]
        [System.Xml.Serialization.XmlEnum("8")]
        GlassReinforcedPlastic = 8,
        [System.ComponentModel.Description("A structure of crossed wooden or metal strips usually arranged to form a diagonal pattern of open spaces between the strips.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Latticed = 11,
        [System.ComponentModel.Description("[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like.   [2] Something made of such a substance, as a windowpane.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Glass = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum natureOfSurface : int
    {
        [System.ComponentModel.Description("Soft, wet earth.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Mud = 1,
        [System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Clay = 2,
        [System.ComponentModel.Description("An unconsolidated sediment whose particles range in size from 0.0039 to 0.0625 millimetres in diameter (between clay and sand size).")]
        [System.Xml.Serialization.XmlEnum("3")]
        Silt = 3,
        [System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Sand = 4,
        [System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Stone = 5,
        [System.ComponentModel.Description("(Particles of 2.0 - 4.0mm); small stones with coarse sand.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Gravel = 6,
        [System.ComponentModel.Description("A small stone worn smooth and rounded by the action of water, sand, ice, etc. ranging in diameter between 4 and 64 millimetres.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Pebbles = 7,
        [System.ComponentModel.Description("A naturally rounded stone larger than a pebble.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Cobbles = 8,
        [System.ComponentModel.Description("Any formation of natural origin that constitutes an integral part of the lithosphere. The natural occurring material that forms firm, hard, and solid masses.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Rock = 9,
        [System.ComponentModel.Description("The fluid or semi-fluid matter flowing from a volcano. The substance that results from the cooling of the molten rock. Part of the ocean bed is composed of lava.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Lava = 11,
        [System.ComponentModel.Description("Hard calcareous skeletons of many tribes of marine polyps.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Coral = 14,
        [System.ComponentModel.Description("The hard outside covering of an animal. Part of the ocean bed is composed of numerous shells of marine animals.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Shells = 17,
        [System.ComponentModel.Description("A rounded rock with diameter of 256 millimetres or larger.")]
        [System.Xml.Serialization.XmlEnum("18")]
        Boulder = 18,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum natureOfSurfaceQualifyingTerms : int
    {
        [System.ComponentModel.Description("Falls within the smallest size continuum for a particular nature of surface term.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Fine = 1,
        [System.ComponentModel.Description("Falls within the moderate size continuum for a particular nature of surface term.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Medium = 2,
        [System.ComponentModel.Description("Falls within the largest size continuum for a particular nature of surface term.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Coarse = 3,
        [System.ComponentModel.Description("Fractured or in pieces.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Broken = 4,
        [System.ComponentModel.Description("Having an adhesive or glue like property.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Sticky = 5,
        [System.ComponentModel.Description("Not hard or firm.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Soft = 6,
        [System.ComponentModel.Description("Not pliant; thick, resistant to flow.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Stiff = 7,
        [System.ComponentModel.Description("Composed of or containing material ejected from a volcano.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Volcanic = 8,
        [System.ComponentModel.Description("Composed of or containing calcium or calcium carbonate.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Calcareous = 9,
        [System.ComponentModel.Description("Firm; usually refers to an area of the seafloor not covered by unconsolidated sediment.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Hard = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum pilotMovement : int
    {
        [System.ComponentModel.Description("The place where vessels not being navigated according to a pilot's instructions pick up a pilot while in transit from sea to a port or constricted waters for future navigation under pilot instructions.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Embarkation = 1,
        [System.ComponentModel.Description("The place where vessels being navigated under a pilot's instructions in transit from sea to a port or constricted waters drop the pilot and proceed without being subject to pilot instructions.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Disembarkation = 2,
        [System.ComponentModel.Description("The place where vessels being navigated under a pilot's instructions drop off the pilot and pick up a different pilot for future navigation under pilot's instructions.")]
        [System.Xml.Serialization.XmlEnum("3")]
        PilotChange = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum product : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("A thick, slippery liquid that will not dissolve in water, usually petroleum based in the context of storage tanks.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Oil = 1,
        [System.ComponentModel.Description("A substance with particles that can move freely, usually a fuel substance in the context of storage tanks.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Gas = 2,
        [System.ComponentModel.Description("A colourless, odourless, tasteless liquid that is a compound of hydrogen and oxygen.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Water = 3,
        [System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Stone = 4,
        [System.ComponentModel.Description("A hard black mineral that is burned as fuel.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Coal = 5,
        [System.ComponentModel.Description("A solid rock or mineral from which metal is obtained.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Ore = 6,
        [System.ComponentModel.Description("Any substance obtained by or used in a chemical process.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Chemicals = 7,
        [System.ComponentModel.Description("Water that is suitable for human consumption.")]
        [System.Xml.Serialization.XmlEnum("8")]
        DrinkingWater = 8,
        [System.ComponentModel.Description("A white fluid secreted by female mammals as food for their young.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Milk = 9,
        [System.ComponentModel.Description("A mineral from which aluminum is obtained.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Bauxite = 10,
        [System.ComponentModel.Description("A solid substance obtained after gas and tar have been extracted from coal, used as a fuel.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Coke = 11,
        [System.ComponentModel.Description("An oblong lump of cast iron metal.")]
        [System.Xml.Serialization.XmlEnum("12")]
        IronIngots = 12,
        [System.ComponentModel.Description("Sodium chloride obtained from mines or by the evaporation of sea water.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Salt = 13,
        [System.ComponentModel.Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Sand = 14,
        [System.ComponentModel.Description("Wood prepared for use in building or carpentry.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Timber = 15,
        [System.ComponentModel.Description("Powdery fragments of wood made in sawing timber or coarse chips produced for use in manufacturing pressed board.")]
        [System.Xml.Serialization.XmlEnum("16")]
        SawdustWoodChips = 16,
        [System.ComponentModel.Description("Discarded metal suitable for being reprocessed.")]
        [System.Xml.Serialization.XmlEnum("17")]
        ScrapMetal = 17,
        [System.ComponentModel.Description("Natural gas that has been liquefied for ease of transport by cooling the gas to -162 Celsius.")]
        [System.Xml.Serialization.XmlEnum("18")]
        LiquefiedNaturalGas = 18,
        [System.ComponentModel.Description("A compressed gas consisting of flammable light hydrocarbons and derived from petroleum.")]
        [System.Xml.Serialization.XmlEnum("19")]
        LiquefiedPetroleumGas = 19,
        [System.ComponentModel.Description("The fermented juice of grapes.")]
        [System.Xml.Serialization.XmlEnum("20")]
        Wine = 20,
        [System.ComponentModel.Description("A substance made of powdered lime and clay, mixed with water.")]
        [System.Xml.Serialization.XmlEnum("21")]
        Cement = 21,
        [System.ComponentModel.Description("A small hard seed, especially that of any cereal plant such as wheat, rice, corn, rye etc.")]
        [System.Xml.Serialization.XmlEnum("22")]
        Grain = 22,
        [System.ComponentModel.Description("Electric charge or current.")]
        [System.Xml.Serialization.XmlEnum("23")]
        Electricity = 23,
        [System.ComponentModel.Description("The solid form of water.")]
        [System.Xml.Serialization.XmlEnum("24")]
        Ice = 24,
        [System.ComponentModel.Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
        [System.Xml.Serialization.XmlEnum("25")]
        Clay = 25,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum qualityOfHorizontalMeasurement : int
    {
        [System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Approximate = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum qualityOfVerticalMeasurement : int
    {
        [System.ComponentModel.Description("The depth from the chart datum to the seabed (or to the top of a drying feature) is known.")]
        [System.Xml.Serialization.XmlEnum("1")]
        DepthKnown = 1,
        [System.ComponentModel.Description("The depth from chart datum to the seabed, or the shoalest depth of the feature is unknown.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DepthOrLeastDepthUnknown = 2,
        [System.ComponentModel.Description("A depth that may be less than indicated.")]
        [System.Xml.Serialization.XmlEnum("3")]
        DoubtfulSounding = 3,
        [System.ComponentModel.Description("A depth that is considered to be an unreliable value.")]
        [System.Xml.Serialization.XmlEnum("4")]
        UnreliableSounding = 4,
        [System.ComponentModel.Description("The shoalest depth over a feature is of known value.")]
        [System.Xml.Serialization.XmlEnum("6")]
        LeastDepthKnown = 6,
        [System.ComponentModel.Description("The least depth over a feature is unknown, but there is considered to be safe clearance at this depth.")]
        [System.Xml.Serialization.XmlEnum("7")]
        LeastDepthUnknownSafeClearanceAtValueShown = 7,
        [System.ComponentModel.Description("Depth value obtained from a report, but not fully surveyed.")]
        [System.Xml.Serialization.XmlEnum("8")]
        ValueReportedNotSurveyed = 8,
        [System.ComponentModel.Description("Depth value obtained from a report, which it has not been possible to confirm.")]
        [System.Xml.Serialization.XmlEnum("9")]
        ValueReportedNotConfirmed = 9,
        [System.ComponentModel.Description("The depth at which a channel is kept by human influence, usually by dredging.")]
        [System.Xml.Serialization.XmlEnum("10")]
        MaintainedDepth = 10,
        [System.ComponentModel.Description("Depths may be altered by human influence, but will not be routinely maintained.")]
        [System.Xml.Serialization.XmlEnum("11")]
        NotRegularlyMaintained = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum referenceTide : int
    {
        [System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
        [System.Xml.Serialization.XmlEnum("1")]
        HighWater = 1,
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LowWater = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum referenceTideType : int
    {
        [System.ComponentModel.Description("The tides of increased range occurring near the times of full moon and new moon.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Springs = 1,
        [System.ComponentModel.Description("The tides of decreased range occurring near the times of first and last quarter.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Neaps = 2,
        [System.ComponentModel.Description("The tides of mean range occurring between spring and neap tides.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Mean = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum restriction : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("An area within which anchoring is not permitted.")]
        [System.Xml.Serialization.XmlEnum("1")]
        AnchoringProhibited = 1,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which anchoring is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("2")]
        AnchoringRestricted = 2,
        [System.ComponentModel.Description("An area within which fishing is not permitted.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FishingProhibited = 3,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which fishing is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("4")]
        FishingRestricted = 4,
        [System.ComponentModel.Description("An area within which trawling is not permitted.")]
        [System.Xml.Serialization.XmlEnum("5")]
        TrawlingProhibited = 5,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which trawling is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("6")]
        TrawlingRestricted = 6,
        [System.ComponentModel.Description("An area within which navigation and/or anchoring is prohibited.")]
        [System.Xml.Serialization.XmlEnum("7")]
        EntryProhibited = 7,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("8")]
        EntryRestricted = 8,
        [System.ComponentModel.Description("An area within which dredging is not permitted.")]
        [System.Xml.Serialization.XmlEnum("9")]
        DredgingProhibited = 9,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which dredging is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("10")]
        DredgingRestricted = 10,
        [System.ComponentModel.Description("An area within which diving is not permitted.")]
        [System.Xml.Serialization.XmlEnum("11")]
        DivingProhibited = 11,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which diving is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("12")]
        DivingRestricted = 12,
        [System.ComponentModel.Description("Mariners must adjust the speed of their vessels to reduce the wave or wash which may cause erosion or disturb moored vessels.")]
        [System.Xml.Serialization.XmlEnum("13")]
        NoWake = 13,
        [System.ComponentModel.Description("An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.")]
        [System.Xml.Serialization.XmlEnum("14")]
        AreaToBeAvoided = 14,
        [System.ComponentModel.Description("The erection of permanent or temporary fixed structures or artificial islands is prohibited.")]
        [System.Xml.Serialization.XmlEnum("15")]
        ConstructionProhibited = 15,
        [System.ComponentModel.Description("An area within which discharging or dumping is prohibited.")]
        [System.Xml.Serialization.XmlEnum("16")]
        DischargingProhibited = 16,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which discharging or dumping is restricted in accordance with specified conditions.")]
        [System.Xml.Serialization.XmlEnum("17")]
        DischargingRestricted = 17,
        [System.ComponentModel.Description("An area within which industrial or mineral exploration and development are prohibited.")]
        [System.Xml.Serialization.XmlEnum("18")]
        IndustrialOrMineralExplorationDevelopmentProhibited = 18,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which industrial or mineral exploration and development is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("19")]
        IndustrialOrMineralExplorationDevelopmentRestricted = 19,
        [System.ComponentModel.Description("An area within which excavating a hole on the seabed with a drill is prohibited.")]
        [System.Xml.Serialization.XmlEnum("20")]
        DrillingProhibited = 20,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the seabed with a drill is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("21")]
        DrillingRestricted = 21,
        [System.ComponentModel.Description("An area within which the removal of historical artefacts is prohibited.")]
        [System.Xml.Serialization.XmlEnum("22")]
        RemovalOfHistoricalArtefactsProhibited = 22,
        [System.ComponentModel.Description("An area in which cargo transhipment (lightening) is prohibited.")]
        [System.Xml.Serialization.XmlEnum("23")]
        CargoTranshipmentLighteningProhibited = 23,
        [System.ComponentModel.Description("An area in which the dragging of anything along the seabed, for example bottom trawling, is prohibited.")]
        [System.Xml.Serialization.XmlEnum("24")]
        DraggingProhibited = 24,
        [System.ComponentModel.Description("An area in which a vessel is prohibited from stopping.")]
        [System.Xml.Serialization.XmlEnum("25")]
        StoppingProhibited = 25,
        [System.ComponentModel.Description("An area in which landing is prohibited.")]
        [System.Xml.Serialization.XmlEnum("26")]
        LandingProhibited = 26,
        [System.ComponentModel.Description("An area within which speed is restricted.")]
        [System.Xml.Serialization.XmlEnum("27")]
        SpeedRestricted = 27,
        [System.ComponentModel.Description("An area in which swimming is prohibited.")]
        [System.Xml.Serialization.XmlEnum("39")]
        SwimmingProhibited = 39,
        [System.ComponentModel.Description("An area within which any vessel propelled by machinery is prohibited.")]
        [System.Xml.Serialization.XmlEnum("42")]
        PowerDrivenVesselsProhibited = 42,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum signalGeneration : int
    {
        [System.ComponentModel.Description("Signal generation is initiated by a self regulating mechanism such as a timer or light sensor.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Automatically = 1,
        [System.ComponentModel.Description("The signal is generated by the motion of the sea surface such as a bell in a buoy.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ByWaveAction = 2,
        [System.ComponentModel.Description("The signal is generated by a manually operated mechanism such as a hand cranked siren.")]
        [System.Xml.Serialization.XmlEnum("3")]
        ByHand = 3,
        [System.ComponentModel.Description("The signal is generated by the motion of air such as a wind driven whistle.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ByWind = 4,
        [System.ComponentModel.Description("Activated by radio signal.")]
        [System.Xml.Serialization.XmlEnum("5")]
        RadioActivated = 5,
        [System.ComponentModel.Description("Activated by making a call to a manned station.")]
        [System.Xml.Serialization.XmlEnum("6")]
        CallActivated = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum signalStatus : int
    {
        [System.ComponentModel.Description("The indication of an element of a signal sequence being a period of light or sound.")]
        [System.Xml.Serialization.XmlEnum("1")]
        LitSound = 1,
        [System.ComponentModel.Description("The indication of an element of a signal sequence being a period of eclipse or silence.")]
        [System.Xml.Serialization.XmlEnum("2")]
        EclipsedSilent = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum speedUnits : int
    {
        [System.ComponentModel.Description("A unit of speed, expressing the number of kilometres travelled in one hour.")]
        [System.Xml.Serialization.XmlEnum("2")]
        KilometresPerHour = 2,
        [System.ComponentModel.Description("An imperial and United States customary unit of speed expressing the number of statute miles covered in one hour.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MilesPerHour = 3,
        [System.ComponentModel.Description("A nautical unit of speed. One knot is one nautical mile per hour. The name is derived from the knots in the log line.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Knots = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum status : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Intended to last or function indefinitely.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Permanent = 1,
        [System.ComponentModel.Description("Acting on special occasions; happening irregularly.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Occasional = 2,
        [System.ComponentModel.Description("Presented as worthy of confidence, acceptance, use, etc.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Recommended = 3,
        [System.ComponentModel.Description("Use has ceased, but the facility still exists intact; disused.")]
        [System.Xml.Serialization.XmlEnum("4")]
        NotInUse = 4,
        [System.ComponentModel.Description("Recurring at intervals.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PeriodicIntermittent = 5,
        [System.ComponentModel.Description("Set apart for some specific use.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Reserved = 6,
        [System.ComponentModel.Description("Meant to last only for a time.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Temporary = 7,
        [System.ComponentModel.Description("Administered by an individual or corporation, rather than a State or a public body.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Private = 8,
        [System.ComponentModel.Description("Compulsory; enforced.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Mandatory = 9,
        [System.ComponentModel.Description("No longer lit.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Extinguished = 11,
        [System.ComponentModel.Description("Lit by flood lights, strip lights, etc.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Illuminated = 12,
        [System.ComponentModel.Description("Famous in history; of historical interest.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Historic = 13,
        [System.ComponentModel.Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Public = 14,
        [System.ComponentModel.Description("Occur at a time, coincide in point of time, be contemporary or simultaneous.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Synchronized = 15,
        [System.ComponentModel.Description("Looked at or observed over a period of time especially so as to be aware of any movement or change.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Watched = 16,
        [System.ComponentModel.Description("Usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Unwatched = 17,
        [System.ComponentModel.Description("A feature that has been reported but has not been definitely determined to exist.")]
        [System.Xml.Serialization.XmlEnum("18")]
        ExistenceDoubtful = 18,
        [System.ComponentModel.Description("Marked by buoys.")]
        [System.Xml.Serialization.XmlEnum("28")]
        Buoyed = 28,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum surveyType : int
    {
        [System.ComponentModel.Description("A survey made (due to lack of time or facilities) to a lower degree of accuracy and detail than the chosen scale would normally indicate.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ReconnaissanceSketchSurvey = 1,
        [System.ComponentModel.Description("A thorough survey usually conducted with reference to guidelines.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ControlledSurvey = 2,
        [System.ComponentModel.Description("A survey principally aimed at the investigation of underwater obstructions and dangers.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ExaminationSurvey = 4,
        [System.ComponentModel.Description("A survey where soundings are acquired by vessels on passage.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PassageSurvey = 5,
        [System.ComponentModel.Description("A survey where features have been positioned and delimited using remote sensing techniques.")]
        [System.Xml.Serialization.XmlEnum("6")]
        RemotelySensed = 6,
        [System.ComponentModel.Description("A survey achieving 100% coverage using systematic, controlled techniques providing full seafloor coverage or full coverage to a defined depth and an investigation of all contacts.")]
        [System.Xml.Serialization.XmlEnum("7")]
        FullCoverage = 7,
        [System.ComponentModel.Description("A controlled survey but full coverage may not have been achieved.")]
        [System.Xml.Serialization.XmlEnum("8")]
        SystematicSurvey = 8,
        [System.ComponentModel.Description("A survey of lower quality than a full coverage and systematic survey. Such surveys may be further categorized as reconnaissance, sketch, track, passage, remotely sensed and spot-sounding surveys.")]
        [System.Xml.Serialization.XmlEnum("9")]
        NonSystematicSurvey = 9,
        [System.ComponentModel.Description("Not surveyed to modern standards; or due to its age, scale, or positional or vertical uncertainties is not suitable to the type of navigation expected in the area.")]
        [System.Xml.Serialization.XmlEnum("10")]
        InadequatelySurveyed = 10,
        [System.ComponentModel.Description("A survey that uses a regular (for example grid) or irregular pattern of soundings obtained one at a time, and normally with very wide spacing.")]
        [System.Xml.Serialization.XmlEnum("11")]
        SpotSoundingSurvey = 11,
        [System.ComponentModel.Description("A controlled, systematic survey to standard accuracy; using modern survey echo sounder with sonar sweep.")]
        [System.Xml.Serialization.XmlEnum("12")]
        AcousticallySweptSurvey = 12,
        [System.ComponentModel.Description("Swept areas where the clearance depth is accurately known but the actual seabed depth is not accurately known.")]
        [System.Xml.Serialization.XmlEnum("13")]
        MechanicallySweptSurvey = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum updateType : int
    {
        [System.ComponentModel.Description("To put or introduce into the body of something.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Insert = 1,
        [System.ComponentModel.Description("To eliminate especially by removing, cutting out or erasing.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Delete = 2,
        [System.ComponentModel.Description("To make basic or fundamental changes to the characteristics of something, often to give a new orientation to or to serve a new end.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Modify = 3,
        [System.ComponentModel.Description("To change the place or position of something.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Move = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum techniqueOfVerticalMeasurement : int
    {
        [System.ComponentModel.Description("The depth was measured by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FoundByEchoSounder = 1,
        [System.ComponentModel.Description("The depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the seabed and generate a record of the seabed configuration.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FoundBySideScanSonar = 2,
        [System.ComponentModel.Description("The depth was measured by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FoundByMultiBeam = 3,
        [System.ComponentModel.Description("The depth was determined by a person skilled in the practice of diving.")]
        [System.Xml.Serialization.XmlEnum("4")]
        FoundByDiver = 4,
        [System.ComponentModel.Description("The depth was measured by using a line, graduated with attached marks and fastened to a sounding lead.")]
        [System.Xml.Serialization.XmlEnum("5")]
        FoundByLeadLine = 5,
        [System.ComponentModel.Description("The given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.")]
        [System.Xml.Serialization.XmlEnum("8")]
        SweptByVerticalAcousticSystem = 8,
        [System.ComponentModel.Description("The depth was determined by using an instrument that compares electromagnetic signals.")]
        [System.Xml.Serialization.XmlEnum("9")]
        FoundByElectromagneticSensor = 9,
        [System.ComponentModel.Description("The science or art of obtaining reliable measurements from photographs.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Photogrammetry = 10,
        [System.ComponentModel.Description("The depth was determined by using instruments placed aboard an artificial satellite.")]
        [System.Xml.Serialization.XmlEnum("11")]
        SatelliteImagery = 11,
        [System.ComponentModel.Description("The depth was determined by using levelling techniques to find the elevation of the point relative to a datum.")]
        [System.Xml.Serialization.XmlEnum("12")]
        FoundByLevelling = 12,
        [System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a side scan sonar.")]
        [System.Xml.Serialization.XmlEnum("13")]
        SweptBySideScanSonar = 13,
        [System.ComponentModel.Description("The depth was measured by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
        [System.Xml.Serialization.XmlEnum("15")]
        FoundByLidar = 15,
        [System.ComponentModel.Description("A radar with a synthetic aperture antenna which is composed of a large number of elementary transducing elements. The signals are electronically combined into a resulting signal equivalent to that of a single antenna of a given aperture in a given direction.")]
        [System.Xml.Serialization.XmlEnum("16")]
        SyntheticApertureRadar = 16,
        [System.ComponentModel.Description("Term used to describe the imagery derived from subdividing the electromagnetic spectrum into very narrow bandwidths. These narrow bandwidths may be combined with or subtracted from each other in various ways to form images useful in precise terrain or target analysis.")]
        [System.Xml.Serialization.XmlEnum("17")]
        HyperspectralImagery = 17,
        [System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a line or object below the surface at the desired depth; or least depth(s) and position(s) within an area was identified using the same technique.")]
        [System.Xml.Serialization.XmlEnum("18")]
        MechanicallySwept = 18,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum telecommunicationService : int
    {
        [System.ComponentModel.Description("The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Voice = 1,
        [System.ComponentModel.Description("A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Facsimile = 2,
        [System.ComponentModel.Description("Short Message Service is a form of text messaging communication on phones and mobile phones.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Sms = 3,
        [System.ComponentModel.Description("A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Data = 4,
        [System.ComponentModel.Description("Data that is constantly received by and presented to an end-user while being delivered by a provider.")]
        [System.Xml.Serialization.XmlEnum("5")]
        StreamedData = 5,
        [System.ComponentModel.Description("A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).")]
        [System.Xml.Serialization.XmlEnum("6")]
        Telex = 6,
        [System.ComponentModel.Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Telegraph = 7,
        [System.ComponentModel.Description("Messages and other data exchanged between individuals using computers in a network.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Email = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum textType : int
    {
        [System.ComponentModel.Description("The individual name of a feature.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Name = 1,
        [System.ComponentModel.Description("A distinguishing trait, quality, or property of a feature class.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FeatureCharacteristic = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum topmarkDaymarkShape : int
    {
        [System.ComponentModel.Description("Is where the vertex points up. A cone is a solid figure generated by straight lines drawn from a fixed point (the vertex) to a circle in a plane not containing the vertex. Cones are commonly used as International Association of Lighthouse Authorities - IALA topmarks, lateral.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ConePointUp = 1,
        [System.ComponentModel.Description("Is where the vertex points down.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ConePointDown = 2,
        [System.ComponentModel.Description("A curved surface all points of which are equidistant from a fixed point within, called the centre.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Sphere = 3,
        [System.ComponentModel.Description("Two spheres, one above the other. Two black spheres are commonly used as an International Association of Lighthouse Authorities - IALA topmark (isolated danger).")]
        [System.Xml.Serialization.XmlEnum("4")]
        twoSpheres = 4,
        [System.ComponentModel.Description("A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, its ends being parallel circles).")]
        [System.Xml.Serialization.XmlEnum("5")]
        Cylinder = 5,
        [System.ComponentModel.Description("Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Board = 6,
        [System.ComponentModel.Description("Having a shape or a cross-section like the capital letter X. An x-shape as an International Association of Lighthouse Authorities - IALA topmark should be 3 dimensional in shape. It is made of at least three crossed bars.")]
        [System.Xml.Serialization.XmlEnum("7")]
        XShaped = 7,
        [System.ComponentModel.Description("A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.")]
        [System.Xml.Serialization.XmlEnum("8")]
        UprightCross = 8,
        [System.ComponentModel.Description("A cube standing on one of its vertexes. A cube is a solid contained by six equal squares, a regular hexahedron.")]
        [System.Xml.Serialization.XmlEnum("9")]
        CubePointUp = 9,
        [System.ComponentModel.Description("2 cones, one above the other, with their vertices together in the centre.")]
        [System.Xml.Serialization.XmlEnum("10")]
        twoConesPointToPoint = 10,
        [System.ComponentModel.Description("2 cones, one above the other, with their bases together in the centre and their vertices pointing up and down.")]
        [System.Xml.Serialization.XmlEnum("11")]
        twoConesBaseToBase = 11,
        [System.ComponentModel.Description("A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Rhombus = 12,
        [System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing up.")]
        [System.Xml.Serialization.XmlEnum("13")]
        twoConesPointsUpward = 13,
        [System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing down.")]
        [System.Xml.Serialization.XmlEnum("14")]
        twoConesPointsDownward = 14,
        [System.ComponentModel.Description("A bundle of rods or twigs. A besom, point up is where the thicker (untied) end of the besom is at the bottom.")]
        [System.Xml.Serialization.XmlEnum("15")]
        BesomPointUp = 15,
        [System.ComponentModel.Description("A bundle of rods or twigs. A besom, point down is where the thinner (tied) end of the besom is at the bottom.")]
        [System.Xml.Serialization.XmlEnum("16")]
        BesomPointDown = 16,
        [System.ComponentModel.Description("A flag mounted on a short pole.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Flag = 17,
        [System.ComponentModel.Description("A sphere located above a rhombus.")]
        [System.Xml.Serialization.XmlEnum("18")]
        SphereOverARhombus = 18,
        [System.ComponentModel.Description("A plane figure with four right angles and four equal straight sides.")]
        [System.Xml.Serialization.XmlEnum("19")]
        Square = 19,
        [System.ComponentModel.Description("A horizontal rectangle is where the two longer opposite sides are standing horizontally.")]
        [System.Xml.Serialization.XmlEnum("20")]
        RectangleHorizontal = 20,
        [System.ComponentModel.Description("A vertical rectangle is where the two longer opposite sides are standing vertically.")]
        [System.Xml.Serialization.XmlEnum("21")]
        RectangleVertical = 21,
        [System.ComponentModel.Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its longer parallel side.")]
        [System.Xml.Serialization.XmlEnum("22")]
        TrapeziumUp = 22,
        [System.ComponentModel.Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its shorter parallel side.")]
        [System.Xml.Serialization.XmlEnum("23")]
        TrapeziumDown = 23,
        [System.ComponentModel.Description("A figure having three angles and three sides, and which has a vertex at the top.")]
        [System.Xml.Serialization.XmlEnum("24")]
        TrianglePointUp = 24,
        [System.ComponentModel.Description("A figure having three angles and three sides, and which has a side at the top.")]
        [System.Xml.Serialization.XmlEnum("25")]
        TrianglePointDown = 25,
        [System.ComponentModel.Description("A perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
        [System.Xml.Serialization.XmlEnum("26")]
        Circle = 26,
        [System.ComponentModel.Description("Two upright crosses, generally vertically disposed one above the other.")]
        [System.Xml.Serialization.XmlEnum("27")]
        TwoUprightCrossesOneOverTheOther = 27,
        [System.ComponentModel.Description("Having a shape like the capital letter T.")]
        [System.Xml.Serialization.XmlEnum("28")]
        TShape = 28,
        [System.ComponentModel.Description("A triangle, vertex uppermost, located above a circle.")]
        [System.Xml.Serialization.XmlEnum("29")]
        TrianglePointingUpOverACircle = 29,
        [System.ComponentModel.Description("An upright cross located above a circle.")]
        [System.Xml.Serialization.XmlEnum("30")]
        UprightCrossOverACircle = 30,
        [System.ComponentModel.Description("A rhombus located above a circle.")]
        [System.Xml.Serialization.XmlEnum("31")]
        RhombusOverACircle = 31,
        [System.ComponentModel.Description("A circle located over a triangle, vertex uppermost.")]
        [System.Xml.Serialization.XmlEnum("32")]
        CircleOverATrianglePointingUp = 32,
        [System.ComponentModel.Description("An uncommon and/or non-standardized shape as textually described using an associated attribute.")]
        [System.Xml.Serialization.XmlEnum("33")]
        OtherShapeSeeShapeInformation = 33,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum trafficFlow : int
    {
        [System.ComponentModel.Description("Traffic flow in a general direction toward a port or similar destination.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Inbound = 1,
        [System.ComponentModel.Description("Traffic flow in a general direction away from a port or similar point of origin.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Outbound = 2,
        [System.ComponentModel.Description("Traffic flow in one general direction only.")]
        [System.Xml.Serialization.XmlEnum("3")]
        OneWay = 3,
        [System.ComponentModel.Description("Traffic flow in two generally opposite directions.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TwoWay = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum verticalDatum : int
    {
        [System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.")]
        [System.Xml.Serialization.XmlEnum("1")]
        MeanLowWaterSprings = 1,
        [System.ComponentModel.Description("The average height of lower low water springs at a place.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MeanLowerLowWaterSprings = 2,
        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MeanSeaLevel = 3,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LowestLowWater = 4,
        [System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("5")]
        MeanLowWater = 5,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
        [System.Xml.Serialization.XmlEnum("6")]
        LowestLowWaterSprings = 6,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
        [System.Xml.Serialization.XmlEnum("7")]
        ApproximateMeanLowWaterSprings = 7,
        [System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
        [System.Xml.Serialization.XmlEnum("8")]
        IndianSpringLowWater = 8,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
        [System.Xml.Serialization.XmlEnum("9")]
        LowWaterSprings = 9,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
        [System.Xml.Serialization.XmlEnum("10")]
        ApproximateLowestAstronomicalTide = 10,
        [System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
        [System.Xml.Serialization.XmlEnum("11")]
        NearlyLowestLowWater = 11,
        [System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("12")]
        MeanLowerLowWater = 12,
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        [System.Xml.Serialization.XmlEnum("13")]
        LowWater = 13,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
        [System.Xml.Serialization.XmlEnum("14")]
        ApproximateMeanLowWater = 14,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
        [System.Xml.Serialization.XmlEnum("15")]
        ApproximateMeanLowerLowWater = 15,
        [System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("16")]
        MeanHighWater = 16,
        [System.ComponentModel.Description("The average height of the high waters of spring tides.")]
        [System.Xml.Serialization.XmlEnum("17")]
        MeanHighWaterSprings = 17,
        [System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
        [System.Xml.Serialization.XmlEnum("18")]
        HighWater = 18,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
        [System.Xml.Serialization.XmlEnum("19")]
        ApproximateMeanSeaLevel = 19,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
        [System.Xml.Serialization.XmlEnum("20")]
        HighWaterSprings = 20,
        [System.ComponentModel.Description("The average height of higher high waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("21")]
        MeanHigherHighWater = 21,
        [System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
        [System.Xml.Serialization.XmlEnum("22")]
        EquinoctialSpringLowWater = 22,
        [System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        [System.Xml.Serialization.XmlEnum("23")]
        LowestAstronomicalTide = 23,
        [System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        [System.Xml.Serialization.XmlEnum("24")]
        LocalDatum = 24,
        [System.ComponentModel.Description("A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Pere, Quebec, over the period 1970 to 1988.")]
        [System.Xml.Serialization.XmlEnum("25")]
        InternationalGreatLakesDatum1985 = 25,
        [System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
        [System.Xml.Serialization.XmlEnum("26")]
        MeanWaterLevel = 26,
        [System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
        [System.Xml.Serialization.XmlEnum("27")]
        LowerLowWaterLargeTide = 27,
        [System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
        [System.Xml.Serialization.XmlEnum("28")]
        HigherHighWaterLargeTide = 28,
        [System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
        [System.Xml.Serialization.XmlEnum("29")]
        NearlyHighestHighWater = 29,
        [System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        [System.Xml.Serialization.XmlEnum("30")]
        HighestAstronomicalTide = 30,
        [System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
        [System.Xml.Serialization.XmlEnum("44")]
        BalticSeaChartDatum2000 = 44,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum virtualAISAidToNavigationType : int
    {
        [System.ComponentModel.Description("Indicates that it should be passed to the north side of the aid.")]
        [System.Xml.Serialization.XmlEnum("1")]
        NorthCardinal = 1,
        [System.ComponentModel.Description("Indicates that it should be passed to the east side of the aid.")]
        [System.Xml.Serialization.XmlEnum("2")]
        EastCardinal = 2,
        [System.ComponentModel.Description("Indicates that it should be passed to the south side of the aid.")]
        [System.Xml.Serialization.XmlEnum("3")]
        SouthCardinal = 3,
        [System.ComponentModel.Description("Indicates that it should be passed to the west side of the aid.")]
        [System.Xml.Serialization.XmlEnum("4")]
        WestCardinal = 4,
        [System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA A system.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PortLateralIalaA = 5,
        [System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA A system.")]
        [System.Xml.Serialization.XmlEnum("6")]
        StarboardLateralIalaA = 6,
        [System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA B system.")]
        [System.Xml.Serialization.XmlEnum("7")]
        PortLateralIalaB = 7,
        [System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the “conventional direction of buoyage” in the IALA B system.")]
        [System.Xml.Serialization.XmlEnum("8")]
        StarboardLateralIalaB = 8,
        [System.ComponentModel.Description("A mark used alone to indicate a dangerous reef or shoal. The mark may be passed on either hand.")]
        [System.Xml.Serialization.XmlEnum("9")]
        IsolatedDanger = 9,
        [System.ComponentModel.Description("Indicates that there is navigable water around the mark.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SafeWater = 10,
        [System.ComponentModel.Description("A special purpose aid is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notice to Mariners.")]
        [System.Xml.Serialization.XmlEnum("11")]
        SpecialPurpose = 11,
        [System.ComponentModel.Description("A mark used to indicate the existence of a recent wreck.")]
        [System.Xml.Serialization.XmlEnum("12")]
        EmergencyWreckMarking = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum visualProminence : int
    {
        [System.ComponentModel.Description("Term applied to an object either natural or artificial which is distinctly and notably visible from seaward.")]
        [System.Xml.Serialization.XmlEnum("1")]
        VisuallyConspicuous = 1,
        [System.ComponentModel.Description("An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NotVisuallyConspicuous = 2,
        [System.ComponentModel.Description("Objects which are easily identifiable, but do not justify being classed as conspicuous.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Prominent = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum waterLevelEffect : int
    {
        [System.ComponentModel.Description("Partially covered and partially dry at high water.")]
        [System.Xml.Serialization.XmlEnum("1")]
        PartlySubmergedAtHighWater = 1,
        [System.ComponentModel.Description("Not covered at high water under average meteorological conditions.")]
        [System.Xml.Serialization.XmlEnum("2")]
        AlwaysDry = 2,
        [System.ComponentModel.Description("Remains covered by water at all times under average meteorological conditions.")]
        [System.Xml.Serialization.XmlEnum("3")]
        AlwaysUnderWaterSubmerged = 3,
        [System.ComponentModel.Description("Expression intended to indicate an area of a reef or other projection from the bottom of a body of water which periodically extends above and is submerged below the surface. Also referred to as dries or uncovers.")]
        [System.Xml.Serialization.XmlEnum("4")]
        CoversAndUncovers = 4,
        [System.ComponentModel.Description("Flush with, or washed by the waves at low water under average meteorological conditions.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Awash = 5,
        [System.ComponentModel.Description("An area periodically covered by flood water, excluding tidal waters.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SubjectToInundationOrFlooding = 6,
        [System.ComponentModel.Description("Resting or moving on the surface of a liquid without sinking.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Floating = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCargo : int
    {
        [System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel e.g. oil or grain.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Bulk = 1,
        [System.ComponentModel.Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Container = 2,
        [System.ComponentModel.Description("Break bulk cargo normally loaded by crane.")]
        [System.Xml.Serialization.XmlEnum("3")]
        General = 3,
        [System.ComponentModel.Description("Any cargo loaded by pipeline.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Liquid = 4,
        [System.ComponentModel.Description("A fee paying traveller.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Passenger = 5,
        [System.ComponentModel.Description("Live animals carried in bulk.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Livestock = 6,
        [System.ComponentModel.Description("Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.")]
        [System.Xml.Serialization.XmlEnum("7")]
        DangerousOrHazardous = 7,
        [System.ComponentModel.Description("Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.")]
        [System.Xml.Serialization.XmlEnum("8")]
        HeavyLift = 8,
        [System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Ballast = 9,
        [System.ComponentModel.Description("Commodity cargo that is transported unpackaged in large quantities. These types of goods usually need to be kept dry during the whole transportation period.")]
        [System.Xml.Serialization.XmlEnum("10")]
        DryBulkCargo = 10,
        [System.ComponentModel.Description("Liquids or gases that are transported in bulk and carried unpackaged.")]
        [System.Xml.Serialization.XmlEnum("11")]
        LiquidBulkCargo = 11,
        [System.ComponentModel.Description("Cargo transported in refrigerated containers, generally perishable commodities which require temperature-controlled transportation, such as fruit, meat, fish, vegetables, dairy products and other foods.")]
        [System.Xml.Serialization.XmlEnum("12")]
        ReeferContainerCargo = 12,
        [System.ComponentModel.Description("Wheeled cargo, such as cars, busses, trucks, agricultural vehicles and cranes, that are driven on and off the ship on their own wheels or using a platform vehicle, such as a self-propelled modular transporter.")]
        [System.Xml.Serialization.XmlEnum("13")]
        RoRoCargo = 13,
        [System.ComponentModel.Description("Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.")]
        [System.Xml.Serialization.XmlEnum("14")]
        ProjectCargo = 14,
        [System.ComponentModel.Description("Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.")]
        [System.Xml.Serialization.XmlEnum("15")]
        BreakBulkCargo = 15,
    }

    public static class CodeList
    {
    }

    namespace ComplexAttributes
    {
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class featureName
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String name { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public nameUsage? nameUsage { get; set; } = default;

            public featureName()
            {
                language = string.Empty;
                name = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class featuresDetected
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean leastDepthOfDetectedFeaturesMeasured { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean significantFeaturesDetected { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? sizeOfFeaturesDetected { get; set; } = default;

            public featuresDetected()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class fixedDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateEnd { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateStart { get; set; } = default;

            public fixedDateRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class frequencyPair
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? frequencyShoreStationReceives { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Int32 frequencyShoreStationTransmits { get; set; }

            public frequencyPair()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class horizontalClearanceFixed
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal horizontalClearanceValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            public horizontalClearanceFixed()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class horizontalClearanceOpen
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal horizontalClearanceValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            public horizontalClearanceOpen()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class horizontalPositionUncertainty
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal uncertaintyFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            public horizontalPositionUncertainty()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class information
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String fileLocator { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String fileReference { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String headline { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            public information()
            {
                language = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class measuredDistanceValue
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required distanceUnitOfMeasurement distanceUnitOfMeasurement { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String referenceLocation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal waterwayDistance { get; set; }

            public measuredDistanceValue()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class multiplicityOfFeatures
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean multiplicityKnown { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? numberOfFeatures { get; set; } = default;

            public multiplicityOfFeatures()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class onlineResource
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String headline { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String linkage { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nameOfResource { get; set; } = string.Empty;

            public onlineResource()
            {
                linkage = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class orientation
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? orientationUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            public orientation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class periodicDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required DateOnly dateEnd { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required DateOnly dateStart { get; set; }

            public periodicDateRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class radarWaveLength
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String radarBand { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal waveLengthValue { get; set; }

            public radarWaveLength()
            {
                radarBand = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class sectorInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            public sectorInformation()
            {
                text = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class sectorLimitOne
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal sectorBearing { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? sectorLineLength { get; set; } = default;

            public sectorLimitOne()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class sectorLimitTwo
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal sectorBearing { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? sectorLineLength { get; set; } = default;

            public sectorLimitTwo()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class shapeInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            public shapeInformation()
            {
                text = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class signalSequence
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal signalDuration { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required signalStatus signalStatus { get; set; }

            public signalSequence()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class speed
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal speedMaximum { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? speedMinimum { get; set; } = default;

            public speed()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class surfaceCharacteristics
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public natureOfSurface? natureOfSurface { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? underlyingLayer { get; set; } = default;

            public surfaceCharacteristics()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class surveyDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required DateOnly dateEnd { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateStart { get; set; } = default;

            public surveyDateRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class telecommunications
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String telecommunicationIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public telecommunicationService? telecommunicationService { get; set; } = default;

            public telecommunications()
            {
                telecommunicationIdentifier = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class tidalStreamValue
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required orientation orientation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal speedMaximum { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal timeRelativeToTide { get; set; }

            public tidalStreamValue()
            {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class timeIntervalsByDayOfWeek
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<dayOfWeek> dayOfWeek { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? dayOfWeekIsRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<TimeOnly> timeOfDayStart { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<TimeOnly> timeOfDayEnd { get; set; } = [];

            public timeIntervalsByDayOfWeek()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class topmark
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required topmarkDaymarkShape topmarkDaymarkShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<shapeInformation> shapeInformation { get; set; } = [];

            public topmark()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class valueOfLocalMagneticAnomaly
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal magneticAnomalyValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public referenceDirection? referenceDirection { get; set; } = default;

            public valueOfLocalMagneticAnomaly()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class verticalUncertainty
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal uncertaintyFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            public verticalUncertainty()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class vesselSpeedLimit
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal speedLimit { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required speedUnits speedUnits { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String vesselClass { get; set; } = string.Empty;

            public vesselSpeedLimit()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class zoneOfConfidence
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfZoneOfConfidenceInData categoryOfZoneOfConfidenceInData { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalPositionUncertainty? horizontalPositionUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            public zoneOfConfidence()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class directionalCharacter
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? moireEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required orientation orientation { get; set; }

            public directionalCharacter()
            {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class rhythmOfLight
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required lightCharacteristic lightCharacteristic { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> signalGroup { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? signalPeriod { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<signalSequence> signalSequence { get; set; } = [];

            public rhythmOfLight()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class scheduleByDayOfWeek
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfSchedule? categoryOfSchedule { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; }

            public scheduleByDayOfWeek()
            {
                timeIntervalsByDayOfWeek = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class sectorLimit
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required sectorLimitOne sectorLimitOne { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required sectorLimitTwo sectorLimitTwo { get; set; }

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class spatialAccuracy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalPositionUncertainty? horizontalPositionUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            public spatialAccuracy()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class tidalStreamPanelValues
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required referenceTide referenceTide { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required referenceTideType referenceTideType { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? streamDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<tidalStreamValue> tidalStreamValue { get; set; }

            public tidalStreamPanelValues()
            {
                tidalStreamValue = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class verticalClearanceClosed
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal verticalClearanceValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceClosed()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class verticalClearanceFixed
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal verticalClearanceValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceFixed()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class verticalClearanceOpen
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean verticalClearanceUnlimited { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalClearanceValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceOpen()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class verticalClearanceSafe
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal verticalClearanceValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            public verticalClearanceSafe()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class lightSector
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public directionalCharacter? directionalCharacter { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<lightVisibility> lightVisibility { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public sectorLimit? sectorLimit { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfNominalRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<sectorInformation> sectorInformation { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? sectorArcExtension { get; set; } = default;

            public lightSector()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class sectorCharacteristics
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required lightCharacteristic lightCharacteristic { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<lightSector> lightSector { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> signalGroup { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? signalPeriod { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<signalSequence> signalSequence { get; set; } = [];

            public sectorCharacteristics()
            {
                lightSector = new();
            }
        }
    }

    namespace Bindings
    {
        namespace Roles
        {
            public class theAuxiliaryFeature : Role
            {
            }

            public class theCartographicText : Role
            {
            }

            public class theCollection : Role
            {
            }

            public class theComponent : Role
            {
            }

            public class theEquipment : Role
            {
            }

            public class theInformation : Role
            {
            }

            public class thePositionProvider : Role
            {
            }

            public class thePrimaryFeature : Role
            {
            }

            public class theQualityInformation : Role
            {
            }

            public class theRoofedStructure : Role
            {
            }

            public class theStructure : Role
            {
            }

            public class theSupport : Role
            {
            }

            public class theUpdate : Role
            {
            }

            public class theUpdatedObject : Role
            {
            }
        }

        namespace InformationAssociations
        {
            public class AdditionalInformation<T> : InformationAssociation where T : Role
            {
                public AdditionalInformation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class QualityOfBathymetricDataComposition<T> : InformationAssociation where T : Role
            {
                public QualityOfBathymetricDataComposition(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class SpatialAssociation<T> : InformationAssociation where T : Role
            {
                public SpatialAssociation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }
        }

        namespace FeatureAssociations
        {
            public class AidsToNavigationAssociation<T> : FeatureAssociation where T : Role
            {
                public AidsToNavigationAssociation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class ASLAggregation<T> : FeatureAssociation where T : Role
            {
                public ASLAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class BridgeAggregation<T> : FeatureAssociation where T : Role
            {
                public BridgeAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class CautionAreaAssociation<T> : FeatureAssociation where T : Role
            {
                public CautionAreaAssociation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class DeepWaterRouteAggregation<T> : FeatureAssociation where T : Role
            {
                public DeepWaterRouteAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class FairwayAggregation<T> : FeatureAssociation where T : Role
            {
                public FairwayAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class FairwayAuxiliary<T> : FeatureAssociation where T : Role
            {
                public FairwayAuxiliary(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class IslandAggregation<T> : FeatureAssociation where T : Role
            {
                public IslandAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class MooringTrotAggregation<T> : FeatureAssociation where T : Role
            {
                public MooringTrotAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class PilotageDistrictAssociation<T> : FeatureAssociation where T : Role
            {
                public PilotageDistrictAssociation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class RangeSystemAggregation<T> : FeatureAssociation where T : Role
            {
                public RangeSystemAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class RoofedStructureAggregation<T> : FeatureAssociation where T : Role
            {
                public RoofedStructureAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class StructureEquipment<T> : FeatureAssociation where T : Role
            {
                public StructureEquipment(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class TextAssociation<T> : FeatureAssociation where T : Role
            {
                public TextAssociation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class TrafficSeparationSchemeAggregation<T> : FeatureAssociation where T : Role
            {
                public TrafficSeparationSchemeAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class TwoWayRouteAggregation<T> : FeatureAssociation where T : Role
            {
                public TwoWayRouteAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class UpdateAggregation<T> : FeatureAssociation where T : Role
            {
                public UpdateAggregation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class UpdatedInformation<T> : FeatureAssociation where T : Role
            {
                public UpdatedInformation(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }
        }
    }

    namespace InformationTypes
    {
        using ComplexAttributes;
        using Bindings.InformationAssociations;
        using Bindings.Roles;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ContactDetails
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String callSign { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<frequencyPair> frequencyPair { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String mMSICode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<onlineResource> onlineResource { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<telecommunications> telecommunications { get; set; } = [];

            public ContactDetails()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ServiceHours
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public ServiceHours()
            {
                scheduleByDayOfWeek = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class NonStandardWorkingDay
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<DateOnly> dateFixed { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> dateVariable { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public NonStandardWorkingDay()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class NauticalInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            public NauticalInformation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SpatialQuality
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<spatialAccuracy> spatialAccuracy { get; set; } = [];

            public SpatialQuality()
            {
            }
        }
    }

    namespace FeatureTypes
    {
        using ComplexAttributes;
        using InformationTypes;
        using Bindings.InformationAssociations;
        using Bindings.FeatureAssociations;
        using Bindings.Roles;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class QualityOfNonBathymetricData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfTemporalVariation? categoryOfTemporalVariation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required horizontalPositionUncertainty horizontalPositionUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? orientationUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public surveyDateRange? surveyDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public QualityOfNonBathymetricData()
            {
                horizontalPositionUncertainty = new horizontalPositionUncertainty()
                {
                    uncertaintyFixed = default(Decimal),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DataCoverage
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? drawingIndex { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Int32 maximumDisplayScale { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Int32 minimumDisplayScale { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Int32 optimumDisplayScale { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public DataCoverage()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class NavigationalSystemOfMarks
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required marksNavigationalSystemOf marksNavigationalSystemOf { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public NavigationalSystemOfMarks()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LocalDirectionOfBuoyage
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required marksNavigationalSystemOf marksNavigationalSystemOf { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public LocalDirectionOfBuoyage()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class QualityOfBathymetricData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfTemporalVariation categoryOfTemporalVariation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required dataAssessment dataAssessment { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMaximumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required featuresDetected featuresDetected { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean fullSeafloorCoverageAchieved { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public surveyDateRange? surveyDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<zoneOfConfidence> zoneOfConfidence { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public QualityOfBathymetricDataComposition<theQualityInformation>? theQualityInformation { get; set; } = default;

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SoundingDatum
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required verticalDatum verticalDatum { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public SoundingDatum()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class VerticalDatumOfData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required verticalDatum verticalDatum { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public VerticalDatumOfData()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class QualityOfSurvey
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMaximumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public featuresDetected? featuresDetected { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? fullSeafloorCoverageAchieved { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? lineSpacingMaximum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? lineSpacingMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? measurementDistanceMaximum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? measurementDistanceMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleValueMaximum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleValueMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String surveyAuthority { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required surveyDateRange surveyDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<surveyType> surveyType { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class UpdateInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Int32 updateNumber { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required updateType updateType { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            public UpdateInformation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MagneticVariation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required DateOnly referenceYearForMagneticVariation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal valueOfAnnualChangeInMagneticVariation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal valueOfMagneticVariation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public MagneticVariation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LocalMagneticAnomaly
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<valueOfLocalMagneticAnomaly> valueOfLocalMagneticAnomaly { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LocalMagneticAnomaly()
            {
                valueOfLocalMagneticAnomaly = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Coastline
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCoastline? categoryOfCoastline { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfSurface> natureOfSurface { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Coastline()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LandArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LandArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class IslandGroup
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<featureName> featureName { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public IslandGroup()
            {
                featureName = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LandElevation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal elevation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LandElevation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class River
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public River()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Rapids
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Rapids()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Waterfall
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Waterfall()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Lake
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Lake()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LandRegion
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfLandRegion> categoryOfLandRegion { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfSurface> natureOfSurface { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LandRegion()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Vegetation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfVegetation categoryOfVegetation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Vegetation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class IceArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfIce categoryOfIce { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public IceArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SlopingGround
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfSlope? categoryOfSlope { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfSurface> natureOfSurface { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SlopingGround()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SlopeTopline
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfSlope? categoryOfSlope { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfSurface> natureOfSurface { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SlopeTopline()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Tideway
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Tideway()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class BuiltUpArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfBuiltUpArea? categoryOfBuiltUpArea { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inTheWater { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public BuiltUpArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Building
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public buildingShape? buildingShape { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<function> function { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inTheWater { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Building()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AirportAirfield
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfAirportAirfield> categoryOfAirportAirfield { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public AirportAirfield()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Runway
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Runway()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Helipad
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Helipad()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Bridge
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public bridgeConstruction? bridgeConstruction { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<bridgeFunction> bridgeFunction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfOpeningBridge? categoryOfOpeningBridge { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? openingBridge { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Bridge()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SpanFixed
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required verticalClearanceFixed verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SpanFixed()
            {
                verticalClearanceFixed = new verticalClearanceFixed()
                {
                    verticalClearanceValue = default(Decimal),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SpanOpening
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required verticalClearanceClosed verticalClearanceClosed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required verticalClearanceOpen verticalClearanceOpen { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Conveyor
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfConveyor? categoryOfConveyor { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? liftingCapacity { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Conveyor()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CableOverhead
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCable? categoryOfCable { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? iceFactor { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceSafe? verticalClearanceSafe { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CableOverhead()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PipelineOverhead
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfPipelinePipe? categoryOfPipelinePipe { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public PipelineOverhead()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PylonBridgeSupport
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfPylon categoryOfPylon { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public PylonBridgeSupport()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FenceWall
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfFence? categoryOfFence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FenceWall()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Railway
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Railway()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Road
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfRoad? categoryOfRoad { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Road()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Tunnel
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Tunnel()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Landmark
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfLandmark> categoryOfLandmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<function> function { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required visualProminence visualProminence { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inTheWater { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Landmark()
            {
                categoryOfLandmark = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SiloTank
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public buildingShape? buildingShape { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfSiloTank? categoryOfSiloTank { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inTheWater { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SiloTank()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class WindTurbine
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inTheWater { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public WindTurbine()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FortifiedStructure
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfFortifiedStructure? categoryOfFortifiedStructure { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inTheWater { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FortifiedStructure()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ProductionStorageArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfProductionArea categoryOfProductionArea { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ProductionStorageArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Checkpoint
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCheckpoint? categoryOfCheckpoint { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Checkpoint()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Hulk
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfHulk> categoryOfHulk { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Hulk()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Pile
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfPile? categoryOfPile { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Pile()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Dyke
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Dyke()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ShorelineConstruction
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfShorelineConstruction? categoryOfShorelineConstruction { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ShorelineConstruction()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class StructureOverNavigableWater
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfStructure> categoryOfStructure { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required horizontalClearanceFixed horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public product? product { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required verticalClearanceFixed verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Causeway
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Causeway()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Canal
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCanal? categoryOfCanal { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Canal()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DistanceMark
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean distanceMarkVisible { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required measuredDistanceValue measuredDistanceValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DistanceMark()
            {
                measuredDistanceValue = new measuredDistanceValue()
                {
                    distanceUnitOfMeasurement = default(distanceUnitOfMeasurement),
                    waterwayDistance = default(Decimal),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Gate
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfGate? categoryOfGate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceOpen? horizontalClearanceOpen { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceOpen? verticalClearanceOpen { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Gate()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Dam
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfDam? categoryOfDam { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Dam()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Crane
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCrane? categoryOfCrane { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? liftingCapacity { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public orientation? orientation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? radius { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalClearanceFixed? verticalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inTheWater { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Crane()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Berth
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<featureName> featureName { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? minimumBerthDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Berth()
            {
                featureName = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Dolphin
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfDolphin> categoryOfDolphin { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Dolphin()
            {
                categoryOfDolphin = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Bollard
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Bollard()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DryDock
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DryDock()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FloatingDock
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? liftingCapacity { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FloatingDock()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Pontoon
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Pontoon()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DockArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfDock? categoryOfDock { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalClearanceWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DockArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Gridiron
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Gridiron()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LockBasin
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public horizontalClearanceFixed? horizontalClearanceFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LockBasin()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MooringTrot
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public MooringTrot()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SeaAreaNamedWaterArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfSeaArea? categoryOfSeaArea { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SeaAreaNamedWaterArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TidalStreamFloodEbb
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfTidalStream categoryOfTidalStream { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required orientation orientation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required speed speed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CurrentNonGravitational
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required orientation orientation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required speed speed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class WaterTurbulence
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfWaterTurbulence categoryOfWaterTurbulence { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public WaterTurbulence()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TidalStreamPanelData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String stationName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String stationNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<tidalStreamPanelValues> tidalStreamPanelValues { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TidalStreamPanelData()
            {
                stationName = string.Empty;
                tidalStreamPanelValues = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Sounding
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Sounding()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DredgedArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal depthRangeMinimumValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMaximumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dredgedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DredgedArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SweptArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal depthRangeMinimumValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? sweptDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SweptArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DepthContour
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal valueOfDepthContour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DepthContour()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DepthArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal depthRangeMinimumValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal depthRangeMaximumValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DepthArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DepthNoBottomFound
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DepthNoBottomFound()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class UnsurveyedArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public UnsurveyedArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SeabedArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<surfaceCharacteristics> surfaceCharacteristics { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SeabedArea()
            {
                surfaceCharacteristics = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class WeedKelp
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfWeedKelp? categoryOfWeedKelp { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public WeedKelp()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Seagrass
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Seagrass()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Sandwave
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Sandwave()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Spring
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Spring()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class UnderwaterAwashRock
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public expositionOfSounding? expositionOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public natureOfSurface? natureOfSurface { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal valueOfSounding { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required waterLevelEffect waterLevelEffect { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal surroundingDepth { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public UnderwaterAwashRock()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Wreck
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfWreck? categoryOfWreck { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public expositionOfSounding? expositionOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required waterLevelEffect waterLevelEffect { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal surroundingDepth { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Wreck()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Obstruction
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfObstruction? categoryOfObstruction { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public expositionOfSounding? expositionOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfSurface> natureOfSurface { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required waterLevelEffect waterLevelEffect { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? defaultClearanceDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal surroundingDepth { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Obstruction()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FoulGround
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FoulGround()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DiscolouredWater
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DiscolouredWater()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FishingFacility
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfFishingFacility? categoryOfFishingFacility { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FishingFacility()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MarineFarmCulture
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfMarineFarmCulture? categoryOfMarineFarmCulture { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public expositionOfSounding? expositionOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfSounding { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required waterLevelEffect waterLevelEffect { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public MarineFarmCulture()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class OffshorePlatform
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfOffshorePlatform? categoryOfOffshorePlatform { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? flareStack { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public OffshorePlatform()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CableSubmarine
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? buriedDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCable? categoryOfCable { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CableSubmarine()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CableArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfCable> categoryOfCable { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CableArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PipelineSubmarineOnLand
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? buriedDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfPipelinePipe> categoryOfPipelinePipe { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMaximumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public PipelineSubmarineOnLand()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SubmarinePipelineArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfPipelinePipe> categoryOfPipelinePipe { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SubmarinePipelineArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class OffshoreProductionArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfOffshoreProductionArea? categoryOfOffshoreProductionArea { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public waterLevelEffect? waterLevelEffect { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public OffshoreProductionArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class NavigationLine
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfNavigationLine categoryOfNavigationLine { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? measuredDistance { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required orientation orientation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public NavigationLine()
            {
                orientation = new orientation()
                {
                    orientationValue = default(Decimal),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RecommendedTrack
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean basedOnFixedMarks { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required trafficFlow trafficFlow { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RecommendedTrack()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RangeSystem
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RangeSystem()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Fairway
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? orientationValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public trafficFlow? trafficFlow { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Fairway()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FairwaySystem
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FairwaySystem()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RecommendedRouteCentreline
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean basedOnFixedMarks { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? orientationValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public trafficFlow? trafficFlow { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RecommendedRouteCentreline()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TwoWayRoutePart
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? basedOnFixedMarks { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required trafficFlow trafficFlow { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TwoWayRoutePart()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TwoWayRoute
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TwoWayRoute()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RecommendedTrafficLanePart
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RecommendedTrafficLanePart()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DeepWaterRouteCentreline
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Boolean basedOnFixedMarks { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? depthRangeMinimumValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? iMOAdopted { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required trafficFlow trafficFlow { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DeepWaterRouteCentreline()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DeepWaterRoutePart
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal depthRangeMinimumValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? iMOAdopted { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required trafficFlow trafficFlow { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DeepWaterRoutePart()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DeepWaterRoute
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? iMOAdopted { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DeepWaterRoute()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class InshoreTrafficZone
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public InshoreTrafficZone()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PrecautionaryArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? iMOAdopted { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<information> information { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public PrecautionaryArea()
            {
                information = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TrafficSeparationSchemeLanePart
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? orientationValue { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TrafficSeparationSchemeLanePart()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SeparationZoneOrLine
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SeparationZoneOrLine()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TrafficSeparationSchemeBoundary
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TrafficSeparationSchemeBoundary()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TrafficSeparationSchemeCrossing
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TrafficSeparationSchemeCrossing()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TrafficSeparationSchemeRoundabout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TrafficSeparationSchemeRoundabout()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TrafficSeparationScheme
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? iMOAdopted { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TrafficSeparationScheme()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ArchipelagicSeaLaneArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ArchipelagicSeaLaneArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ArchipelagicSeaLaneAxis
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ArchipelagicSeaLaneAxis()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ArchipelagicSeaLane
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ArchipelagicSeaLane()
            {
                nationality = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RadioCallingInPoint
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<Decimal> orientationValue { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required trafficFlow trafficFlow { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RadioCallingInPoint()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FerryRoute
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfFerry> categoryOfFerry { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FerryRoute()
            {
                categoryOfFerry = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RadarLine
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RadarLine()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RadarRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RadarRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RadarStation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String callSign { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfRadarStation> categoryOfRadarStation { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfMaximumRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RadarStation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AnchorageArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfAnchorage> categoryOfAnchorage { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public AnchorageArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MooringArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfMooringArea> categoryOfMooringArea { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedVesselLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public MooringArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AnchorBerth
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfAnchorage> categoryOfAnchorage { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? radius { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public AnchorBerth()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SeaplaneLandingArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SeaplaneLandingArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DumpingGround
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfDumpingGround> categoryOfDumpingGround { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateDisused { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public DumpingGround()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MilitaryPracticeArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfMilitaryPracticeArea> categoryOfMilitaryPracticeArea { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public MilitaryPracticeArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AdministrationArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inDispute { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required jurisdiction jurisdiction { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> nationality { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public AdministrationArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CargoTranshipmentArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CargoTranshipmentArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CautionArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CautionArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class InformationArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public InformationArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ContiguousZone
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inDispute { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<String> nationality { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ContiguousZone()
            {
                nationality = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ContinentalShelfArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<String> nationality { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ContinentalShelfArea()
            {
                nationality = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CustomZone
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CustomZone()
            {
                nationality = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ExclusiveEconomicZone
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inDispute { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<String> nationality { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public ExclusiveEconomicZone()
            {
                nationality = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FisheryZone
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FisheryZone()
            {
                nationality = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FishingGround
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FishingGround()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FreePortArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FreePortArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class HarbourAreaAdministrative
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public HarbourAreaAdministrative()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LogPond
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LogPond()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class OilBarrier
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfOilBarrier? categoryOfOilBarrier { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public OilBarrier()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class StraightTerritorialSeaBaseline
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public StraightTerritorialSeaBaseline()
            {
                nationality = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TerritorialSeaArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inDispute { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<String> nationality { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public TerritorialSeaArea()
            {
                nationality = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SubmarineTransitLane
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SubmarineTransitLane()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PilotageDistrict
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public PilotageDistrict()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CollisionRegulationsLimit
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String regulationCitation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CollisionRegulationsLimit()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MarinePollutionRegulationsArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String regulationCitation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public MarinePollutionRegulationsArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RestrictedArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<restriction> restriction { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RestrictedArea()
            {
                restriction = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LightAllAround
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfLight> categoryOfLight { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? flareBearing { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public lightVisibility? lightVisibility { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? majorLight { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required rhythmOfLight rhythmOfLight { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public signalGeneration? signalGeneration { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfNominalRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LightAllAround()
            {
                colour = new();
                rhythmOfLight = new rhythmOfLight()
                {
                    lightCharacteristic = default(lightCharacteristic),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LightSectored
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfLight> categoryOfLight { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<sectorCharacteristics> sectorCharacteristics { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public signalGeneration? signalGeneration { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LightSectored()
            {
                sectorCharacteristics = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LightFogDetector
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? flareBearing { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public rhythmOfLight? rhythmOfLight { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public signalGeneration? signalGeneration { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LightFogDetector()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LightAirObstruction
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public exhibitionConditionOfLight? exhibitionConditionOfLight { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? flareBearing { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<lightVisibility> lightVisibility { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public multiplicityOfFeatures? multiplicityOfFeatures { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public rhythmOfLight? rhythmOfLight { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfNominalRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public verticalDatum? verticalDatum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LightAirObstruction()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LateralBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfLateralMark categoryOfLateralMark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LateralBuoy()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CardinalBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfCardinalMark categoryOfCardinalMark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CardinalBuoy()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class IsolatedDangerBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public IsolatedDangerBuoy()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SafeWaterBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SafeWaterBuoy()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SpecialPurposeGeneralBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SpecialPurposeGeneralBuoy()
            {
                categoryOfSpecialPurposeMark = new();
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class EmergencyWreckMarkingBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public EmergencyWreckMarkingBuoy()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class InstallationBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfInstallationBuoy? categoryOfInstallationBuoy { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public InstallationBuoy()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MooringBuoy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required buoyShape buoyShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedDraught { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? maximumPermittedVesselLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? visitorsMooring { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public MooringBuoy()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LateralBeacon
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required beaconShape beaconShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfLateralMark categoryOfLateralMark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LateralBeacon()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CardinalBeacon
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required beaconShape beaconShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfCardinalMark categoryOfCardinalMark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CardinalBeacon()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class IsolatedDangerBeacon
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required beaconShape beaconShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public IsolatedDangerBeacon()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SafeWaterBeacon
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required beaconShape beaconShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SafeWaterBeacon()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SpecialPurposeGeneralBeacon
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required beaconShape beaconShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public marksNavigationalSystemOf? marksNavigationalSystemOf { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SpecialPurposeGeneralBeacon()
            {
                categoryOfSpecialPurposeMark = new();
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Daymark
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required topmarkDaymarkShape topmarkDaymarkShape { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<shapeInformation> shapeInformation { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Daymark()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LightFloat
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public topmark? topmark { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LightFloat()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LightVessel
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<colour> colour { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? horizontalWidth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? radarConspicuous { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? verticalLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public visualProminence? visualProminence { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public LightVessel()
            {
                colour = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Retroreflector
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<colour> colour { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public colourPattern? colourPattern { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public Retroreflector()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RadarReflector
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? height { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RadarReflector()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FogSignal
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfFogSignal categoryOfFogSignal { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? signalFrequency { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public signalGeneration? signalGeneration { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String signalGroup { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? signalPeriod { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<signalSequence> signalSequence { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfMaximumRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public FogSignal()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PhysicalAISAidToNavigation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? estimatedRangeOfTransmission { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String mMSICode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public PhysicalAISAidToNavigation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class VirtualAISAidToNavigation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? estimatedRangeOfTransmission { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String mMSICode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public status? status { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required virtualAISAidToNavigationType virtualAISAidToNavigationType { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public VirtualAISAidToNavigation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RadioStation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String callSign { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfRadioStation> categoryOfRadioStation { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? estimatedRangeOfTransmission { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public frequencyPair? frequencyPair { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RadioStation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RadarTransponderBeacon
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<radarWaveLength> radarWaveLength { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public sectorLimit? sectorLimit { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String signalGroup { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<signalSequence> signalSequence { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? valueOfMaximumRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RadarTransponderBeacon()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PilotBoardingPlace
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfPilotBoardingPlace? categoryOfPilotBoardingPlace { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfPreference? categoryOfPreference { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> destination { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<pilotMovement> pilotMovement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public PilotBoardingPlace()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class VesselTrafficServiceArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public VesselTrafficServiceArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CoastGuardStation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? isMRCC { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public CoastGuardStation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SignalStationWarning
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfSignalStationWarning> categoryOfSignalStationWarning { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SignalStationWarning()
            {
                categoryOfSignalStationWarning = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SignalStationTraffic
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfSignalStationTraffic> categoryOfSignalStationTraffic { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SignalStationTraffic()
            {
                categoryOfSignalStationTraffic = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class RescueStation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfRescueStation> categoryOfRescueStation { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public RescueStation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class HarbourFacility
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<natureOfConstruction> natureOfConstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public product? product { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselSpeedLimit> vesselSpeedLimit { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public HarbourFacility()
            {
                categoryOfHarbourFacility = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SmallCraftFacility
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<categoryOfSmallCraftFacility> categoryOfSmallCraftFacility { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictorialRepresentation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public AdditionalInformation<theInformation>? theInformation { get; set; } = default;

            public SmallCraftFacility()
            {
                categoryOfSmallCraftFacility = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TextPlacement
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Int32 textOffsetBearing { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required Int32 textOffsetDistance { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? textRotation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public required List<textType> textType { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;

            public TextPlacement()
            {
                textType = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Chart1Feature
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> drawingInstruction { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            public Chart1Feature()
            {
            }
        }
    }
}