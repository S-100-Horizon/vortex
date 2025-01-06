using System;
using System.Collections.Immutable;
using System.Linq;


namespace S100Framework.DomainModel.S131
{

    public static class Information
    {
        public static Version Version => new Version("1.0.0");

        public static string[] ComplexTypes => [
            "contactAddress",
            "featureName",
            "fixedDateRange",
            "frequencyPair",
            "horizontalPositionUncertainty",
            "information",
            "onlineResource",
            "orientation",
            "periodicDateRange",
            "rxNCode",
            "surveyDateRange",
            "textContent",
            "timeIntervalsByDayOfWeek",
            "usefulMarkDescription",
            "verticalUncertainty",
            "vesselsMeasurements",
            "weatherResource",
            "bearingInformation",
            "cargoServicesDescription",
            "constructionInformation",
            "depthsDescription",
            "facilitiesLayoutDescription",
            "generalPortDescription",
            "graphic",
            "landmarkDescription",
            "limitsDescription",
            "majorLightDescription",
            "markedBy",
            "offshoreMarkDescription",
            "scheduleByDayOfWeek",
            "spatialAccuracy",
            "telecommunications",
            "generalHarbourInformation",
        ];

        public static string[] InformationTypes => [
            "InformationType",
            "AbstractRxN",
            "Applicability",
            "Authority",
            "AvailablePortServices",
            "ContactDetails",
            "Entrance",
            "NauticalInformation",
            "NonStandardWorkingDay",
            "Recommendations",
            "Regulations",
            "Restrictions",
            "ServiceHours",
            "SpatialQuality",
        ];

        public static string[] FeatureTypes => [
            "FeatureType",
            "OrganizationContactArea",
            "SupervisedArea",
            "HarbourPhysicalInfrastructure",
            "Layout",
            "AnchorBerth",
            "AnchorageArea",
            "Berth",
            "BerthPosition",
            "DockArea",
            "DryDock",
            "DumpingGround",
            "FloatingDock",
            "Gridiron",
            "HarbourAreaAdministrative",
            "HarbourAreaSection",
            "HarbourBasin",
            "HarbourFacility",
            "MooringWarpingFacility",
            "OuterLimit",
            "PilotBoardingPlace",
            "SeaplaneLandingArea",
            "Terminal",
            "TurningBasin",
            "WaterwayArea",
            "DataCoverage",
            "QualityOfNonBathymetricData",
            "SoundingDatum",
            "VerticalDatumOfData",
            "TextPlacement",
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum berthingAssistance : int
    {
        [System.ComponentModel.Description("Information about assistance or arrangements for a service related to berthing operations.")]
        BerthingInformation = 1,

        [System.ComponentModel.Description("Personnel specializing in the mooring and unmooring of vessels.")]
        LinePersonnel = 2,

        [System.ComponentModel.Description("A boat which assists the securement of a vessel to a berth or mooring with ropes or anchor.")]
        MooringBoat = 3,

        [System.ComponentModel.Description("A locomotive for moving vessels.")]
        Mule = 4,

        [System.ComponentModel.Description("A powerful small boat designed to pull or push larger ships or powerless barges.")]
        Tugboat = 5,

        [System.ComponentModel.Description("A ship equipped to make and maintain a channel through ice.")]
        IcebreakingShip = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum cardinalDirection : int
    {
        [System.ComponentModel.Description("348.75-011.25 degrees (true north).")]
        North = 1,

        [System.ComponentModel.Description("011.25 - 033.75 degrees.")]
        NorthNortheast = 2,

        [System.ComponentModel.Description("033.75 - 056.25 degrees.")]
        Northeast = 3,

        [System.ComponentModel.Description("056.25-078.75 degrees.")]
        EastNortheast = 4,

        [System.ComponentModel.Description("078.75-101.25 degrees.")]
        East = 5,

        [System.ComponentModel.Description("101.25-123.75 degrees.")]
        EastSoutheast = 6,

        [System.ComponentModel.Description("123.75-146.25 degrees.")]
        Southeast = 7,

        [System.ComponentModel.Description("146.25-168.75 degrees.")]
        SouthSoutheast = 8,

        [System.ComponentModel.Description("168.75-191.25 degrees.")]
        South = 9,

        [System.ComponentModel.Description("191.25-213.75 degrees.")]
        SouthSouthwest = 10,

        [System.ComponentModel.Description("213.75-236.25 degrees.")]
        Southwest = 11,

        [System.ComponentModel.Description("236.25-258.75 degrees.")]
        WestSouthwest = 12,

        [System.ComponentModel.Description("258.75-281.25 degrees.")]
        West = 13,

        [System.ComponentModel.Description("281.25-303.75 degrees.")]
        WestNorthwest = 14,

        [System.ComponentModel.Description("303.75 - 326.25 degrees.")]
        Northwest = 15,

        [System.ComponentModel.Description("326.25 - 348.75 degrees.")]
        NorthNorthwest = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum cargoService : int
    {
        [System.ComponentModel.Description("The loading, unloading, moving or handling of cargo, ship's stores, gear, or other materials, into, in, on, or out of any vessel.")]
        Stevedoring = 1,

        [System.ComponentModel.Description("Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.")]
        CargoSurveying = 2,

        [System.ComponentModel.Description("The securement of cargo to the ship's structure and/or other cargo.")]
        CargoLashing = 3,

        [System.ComponentModel.Description("Determination of the quantity of certain types of bulk cargo by assessment of its effect on displacement when loaded in a vessel.")]
        DraughtSurvey = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAuthority : int
    {
        [System.ComponentModel.Description("The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.")]
        BorderControl = 2,

        [System.ComponentModel.Description("The department of government, or civil force, charged with maintaining public order.")]
        Police = 3,

        [System.ComponentModel.Description("Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.")]
        Port = 4,

        [System.ComponentModel.Description("The authority controlling people entering a country.")]
        Immigration = 5,

        [System.ComponentModel.Description("The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.")]
        Health = 6,

        [System.ComponentModel.Description("Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.")]
        CoastGuard = 7,

        [System.ComponentModel.Description("The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.")]
        Agricultural = 8,

        [System.ComponentModel.Description("A military authority which provides control of access to or approval for transit through designated areas or airspace.")]
        Military = 9,

        [System.ComponentModel.Description("A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.")]
        PrivateCompany = 10,

        [System.ComponentModel.Description("A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.")]
        MaritimePolice = 11,

        [System.ComponentModel.Description("An authority with responsibility for the protection of the environment.")]
        Environmental = 12,

        [System.ComponentModel.Description("An authority with responsibility for the control of fisheries.")]
        Fishery = 13,

        [System.ComponentModel.Description("An authority with responsibility for the control and movement of money.")]
        Finance = 14,

        [System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
        Maritime = 15,

        [System.ComponentModel.Description("The agency or establishment for collecting duties, tolls.")]
        Customs = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfBerthLocation : int
    {
        [System.ComponentModel.Description("A wharf or quay with reference position(s) given by one or more metre marks.")]
        WharfReferenceMetreMark = 1,

        [System.ComponentModel.Description("A wharf or quay with reference position(s) given by one or more point or points in geographic coordinates.")]
        WharfReferencePosition = 2,

        [System.ComponentModel.Description("A long, narrow structure extending into the water to afford a berthing place for vessels, to serve as a promenade, etc.")]
        PierJetty = 3,

        [System.ComponentModel.Description("Mooring using the vessel's anchors and buoys to secure the vessel at multiple points.")]
        ConventionalMooring = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCargo : int
    {
        [System.ComponentModel.Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
        Container = 2,

        [System.ComponentModel.Description("A fee paying traveller.")]
        Passenger = 5,

        [System.ComponentModel.Description("Live animals carried in bulk.")]
        Livestock = 6,

        [System.ComponentModel.Description("Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.")]
        DangerousOrHazardous = 7,

        [System.ComponentModel.Description("Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.")]
        HeavyLift = 8,

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

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCommunicationPreference : int
    {
        [System.ComponentModel.Description("The first choice channel or frequency to be used when calling a radio station.")]
        PreferredCalling = 1,

        [System.ComponentModel.Description("A channel or frequency to be used for calling a radio station when the preferred channel or frequency is busy or is suffering from interference.")]
        AlternateCalling = 2,

        [System.ComponentModel.Description("The first choice channel or frequency to be used when working with a radio station.")]
        PreferredWorking = 3,

        [System.ComponentModel.Description("A channel or frequency to be used for working with a radio station when the preferred working channel or frequency is busy or is suffering from interference.")]
        AlternateWorking = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDangerousOrHazardousCargo : int
    {
        [System.ComponentModel.Description("Explosives, Division 1: Substances and articles which have a mass explosion hazard.")]
        ImdgCodeClass1Div11 = 1,

        [System.ComponentModel.Description("Explosives, Division 2: Substances and articles which have a projection hazard but not a mass explosion hazard.")]
        ImdgCodeClass1Div12 = 2,

        [System.ComponentModel.Description("Explosives, Division 3: Substances and articles which have a fire hazard and either a minor blast hazard or a minor projection hazard or both, but not a mass explosion hazard.")]
        ImdgCodeClass1Div13 = 3,

        [System.ComponentModel.Description("Explosives, Division 4: Substances and articles which present no significant hazard.")]
        ImdgCodeClass1Div14 = 4,

        [System.ComponentModel.Description("Explosives, Division 5: Very insensitive substances which have a mass explosion hazard.")]
        ImdgCodeClass1Div15 = 5,

        [System.ComponentModel.Description("Explosives, Division 6: Extremely insensitive articles which do not have a mass explosion hazard.")]
        ImdgCodeClass1Div16 = 6,

        [System.ComponentModel.Description("Gases, flammable gases.")]
        ImdgCodeClass2Div21 = 7,

        [System.ComponentModel.Description("Gases, non-flammable, non-toxic gases.")]
        ImdgCodeClass2Div22 = 8,

        [System.ComponentModel.Description("Gases, toxic gases.")]
        ImdgCodeClass2Div23 = 9,

        [System.ComponentModel.Description("Flammable liquids.")]
        ImdgCodeClass3 = 10,

        [System.ComponentModel.Description("Flammable solids, self-reactive substances and desensitized explosives.")]
        ImdgCodeClass4Div41 = 11,

        [System.ComponentModel.Description("Substances liable to spontaneous combustion.")]
        ImdgCodeClass4Div42 = 12,

        [System.ComponentModel.Description("Substances which, in contact with water, emit flammable gases.")]
        ImdgCodeClass4Div43 = 13,

        [System.ComponentModel.Description("Oxidizing substances.")]
        ImdgCodeClass5Div51 = 14,

        [System.ComponentModel.Description("Organic peroxides.")]
        ImdgCodeClass5Div52 = 15,

        [System.ComponentModel.Description("Toxic substances.")]
        ImdgCodeClass6Div61 = 16,

        [System.ComponentModel.Description("Infectious substances.")]
        ImdgCodeClass6Div62 = 17,

        [System.ComponentModel.Description("Radioactive material.")]
        ImdgCodeClass7 = 18,

        [System.ComponentModel.Description("Corrosive substances.")]
        ImdgCodeClass8 = 19,

        [System.ComponentModel.Description("Miscellaneous dangerous substances and articles.")]
        ImdgCodeClass9 = 20,

        [System.ComponentModel.Description("Harmful substances are those substances which are identified as marine pollutants in the International Maritime Dangerous Goods Code (IMDG Code). Packaged form is defined as the forms of containment specified for harmful substances in the IMDG Code.")]
        HarmfulSubstancesInPackagedForm = 21,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDepthsDescription : int
    {
        [System.ComponentModel.Description("A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.")]
        Shoal = 1,

        [System.ComponentModel.Description("General information about the vertical distance from the water surface to the bottom.")]
        GeneralDepth = 2,

        [System.ComponentModel.Description("The least depth in the approach or channel to an area, such as a port or anchorage, governing the maximum draft of vessels that can enter.")]
        ControllingDepth = 3,
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

        [System.ComponentModel.Description("A place where mechanical services or repairs can be undertaken to engines or other vessel equipment.")]
        ServiceAndRepair = 16,

        [System.ComponentModel.Description("A medical control center located in an isolated spot ashore where patients with contagious diseases from vessel in quarantine are taken.")]
        QuarantineStation = 17,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfMooringWarpingFacility : int
    {
        [System.ComponentModel.Description("A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.")]
        Dolphin = 1,

        [System.ComponentModel.Description("A post or group of posts, which a vessel may swing around for compass adjustment.")]
        DeviationDolphin = 2,

        [System.ComponentModel.Description("Small shaped post, mounted on a wharf or dolphin used to secure ship's lines.")]
        Bollard = 3,

        [System.ComponentModel.Description("A section of wall designated for tying-up vessels awaiting transit. Bollards and mooring devices are available for both large and small ships.")]
        TieUpWall = 4,

        [System.ComponentModel.Description("A long heavy timber or section of steel, wood, concrete, etc., forced into the seabed to serve as a mooring facility.")]
        PostOrPile = 5,

        [System.ComponentModel.Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
        MooringCable = 6,

        [System.ComponentModel.Description("A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.")]
        MooringBuoy = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfPortSection : int
    {
        [System.ComponentModel.Description("The main navigable channel in a harbour or its approaches, for vessels of larger size.")]
        PortFairway = 1,

        [System.ComponentModel.Description("A body of water at a berth or anchor berth, of adequate dimensions to allow a vessel to make fast to the shore, mooring buoys, berthing dolphins or to anchor.")]
        BerthPocket = 3,

        [System.ComponentModel.Description("An area in which sea-planes anchor or may anchor.")]
        SeaplaneAnchorage = 8,

        [System.ComponentModel.Description("An area of water or channel enlargement of increased depth compared to adjacent areas, where the depth is maintained by dredging operations.")]
        DredgedBasin = 9,

        [System.ComponentModel.Description("The area around a port facility or harbour installation within which vessels are prohibited from entering without permission.")]
        PortSafetyZone = 11,

        [System.ComponentModel.Description("A general berth for use by vessels for short term waiting until a loading or discharging berth is available.")]
        LayByBerth = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRelationship : int
    {
        [System.ComponentModel.Description("Use of facility, waterway or service is forbidden.")]
        Prohibited = 1,

        [System.ComponentModel.Description("Use of facility, waterway or service is not recommended.")]
        NotRecommended = 2,

        [System.ComponentModel.Description("Use of facility, waterway, or service is permitted but not required.")]
        Permitted = 3,

        [System.ComponentModel.Description("Use of facility, waterway, or service is recommended.")]
        Recommended = 4,

        [System.ComponentModel.Description("Use of facility, waterway, or service is required.")]
        Required = 5,

        [System.ComponentModel.Description("Use of facility, waterway, or service is not required.")]
        NotRequired = 6,
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
    public enum categoryOfTemporalVariation : int
    {
        [System.ComponentModel.Description("Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.")]
        ExtremeEvent = 1,

        [System.ComponentModel.Description("Continuous or frequent change (for example river siltation, sand waves, seasonal storms, ice bergs, etc) that is likely to result in new significant shoaling.")]
        LikelyToChangeAndSignificantShoalingExpected = 2,

        [System.ComponentModel.Description("Continuous or frequent change (for example sand wave shift, seasonal storms, ice bergs, etc) that is not likely to result in new significant shoaling.")]
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
    public enum categoryOfText : int
    {
        [System.ComponentModel.Description("A statement summarizing the important points of a text.")]
        AbstractOrSummary = 1,

        [System.ComponentModel.Description("An excerpt or excerpts from a text.")]
        Extract = 2,

        [System.ComponentModel.Description("The whole text.")]
        FullText = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfVesselRegistry : int
    {
        [System.ComponentModel.Description("The vessel is registered or enrolled under the same national flag as the port, harbour, territorial sea, exclusive economic zone, or administrative area in which the object that possesses this attribute applies or is located.")]
        Domestic = 1,

        [System.ComponentModel.Description("The vessel is registered or enrolled under a national flag different from the port, harbour, territorial sea, exclusive economic zone, or other administrative area in which the object that possesses this attribute applies or is located.")]
        Foreign = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum comparisonOperator : int
    {
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum dayOfWeek : int
    {
        [System.ComponentModel.Description("The first day of the week.")]
        Sunday = 1,

        [System.ComponentModel.Description("The second day of the week.")]
        Monday = 2,

        [System.ComponentModel.Description("The third day of the week.")]
        Tuesday = 3,

        [System.ComponentModel.Description("The fourth day of the week.")]
        Wednesday = 4,

        [System.ComponentModel.Description("The fifth day of the week.")]
        Thursday = 5,

        [System.ComponentModel.Description("The sixth day of the week.")]
        Friday = 6,

        [System.ComponentModel.Description("The seventh day of the week.")]
        Saturday = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum dynamicResource : int
    {
        [System.ComponentModel.Description("The information is static, or a source of up-to-date information is unavailable or unknown.")]
        Static = 1,

        [System.ComponentModel.Description("An external source of up-to-date information is available and interaction with it to obtain up-to-date information is required.")]
        MandatoryExternalDynamic = 2,

        [System.ComponentModel.Description("An external source of up-to-date information is available but interaction with it to obtain up-to-date information is not required.")]
        OptionalExternalDynamic = 3,

        [System.ComponentModel.Description("Up-to-date information may be computed using only onboard resources.")]
        OnboardDynamic = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum firefightingService : int
    {
        [System.ComponentModel.Description("Personnel and equipment that are capable of combating a fire from ashore.")]
        ShoreBasedFirefighting = 1,

        [System.ComponentModel.Description("Trained firefighting personnel with the capability of boarding and combating a fire on a vessel.")]
        OnboardFirefighting = 2,

        [System.ComponentModel.Description("Specialised watercraft with firefighting apparatus designed for fighting shoreline and shipboard fires")]
        FirefightingBoat = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum iSPSLevel : int
    {
        [System.ComponentModel.Description("The level for which minimum appropriate protective security measures shall be maintained at all times.")]
        IspsLevel1 = 1,

        [System.ComponentModel.Description("The level for which appropriate additional protective security measures shall be maintained for a period of time as a result of heightened risk of a security incident.")]
        IspsLevel2 = 2,

        [System.ComponentModel.Description("The level for which further specific protective security measures shall be maintained for a limited period of time when a security incident is probable or imminent, although it may not be possible to identify the specific target.")]
        IspsLevel3 = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum logicalConnectives : int
    {
        [System.ComponentModel.Description("All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.")]
        LogicalConjunction = 1,

        [System.ComponentModel.Description("At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.")]
        LogicalDisjunction = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum medicalService : int
    {
        [System.ComponentModel.Description("A vehicle for conveying the sick or injured to or from a hospital.")]
        Ambulance = 1,

        [System.ComponentModel.Description("Disinfection or purification with fumes.")]
        Fumigation = 2,

        [System.ComponentModel.Description("A place where a doctor is available to provide medical attention.")]
        Doctor = 3,

        [System.ComponentModel.Description("The isolation of patients with contagious diseases.")]
        Quarantine = 4,

        [System.ComponentModel.Description("A place where substances intended to procure immunity against one or several diseases are administered.")]
        VaccinationCentre = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public enum membership : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.")]
        Included = 1,

        [System.ComponentModel.Description("Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.")]
        Excluded = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum methodOfSecuring : int
    {
        [System.ComponentModel.Description("Vessel is secured perpendicular to the wharf with bow to seaward.")]
        BowToSeaward = 1,

        [System.ComponentModel.Description("Vessel is secured perpendicular to the wharf with stern to the seaward.")]
        SternToSeaward = 2,

        [System.ComponentModel.Description("The vessel is secured perpendicular to the wharf.")]
        MediterraneanMooring = 3,

        [System.ComponentModel.Description("Mooring method/procedure used during onshore wind conditions without a tug.")]
        BalticMooring = 4,

        [System.ComponentModel.Description("Mooring by maneuvering ahead and astern while dropping anchors to secure the vessel with reduced swinging room.")]
        RunningMooring = 5,

        [System.ComponentModel.Description("Mooring by using mainly wind and tide to position the vessel while dropping anchors to secure the vessel with reduced swinging room. Makes limited use of the engine to position the vessel.")]
        StandingMooring = 6,

        [System.ComponentModel.Description("A mooring structure used by tankers to load and unload in port approaches or in offshore oil and gas fields. The size of the structure can vary between a large mooring buoy and a manned floating structure.")]
        SinglePointMooring = 7,

        [System.ComponentModel.Description("Mooring using the vessel's anchors and buoys to secure the vessel at multiple points.")]
        ConventionalMooring = 8,

        [System.ComponentModel.Description("Mooring alongside another vessel.")]
        ShipToShipMooring = 9,

        [System.ComponentModel.Description("Mooring system supported by a spider buoy.")]
        SpiderBuoyMooring = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum onlineFunction : int
    {
        [System.ComponentModel.Description("Online instructions for transferring data from one storage device or system to another.")]
        Download = 1,

        [System.ComponentModel.Description("Online instructions for requesting the resource from the provider.")]
        OfflineAccess = 3,

        [System.ComponentModel.Description("Online order process for obtaining the resource.")]
        Order = 4,

        [System.ComponentModel.Description("To make painstaking investigation or examination.")]
        Search = 5,

        [System.ComponentModel.Description("Complete metadata provided.")]
        CompleteMetadata = 6,

        [System.ComponentModel.Description("Browse graphic provided.")]
        BrowseGraphic = 7,

        [System.ComponentModel.Description("Online resource upload capability provided.")]
        Upload = 8,

        [System.ComponentModel.Description("Online email service provided.")]
        EmailService = 9,

        [System.ComponentModel.Description("Online browsing provided.")]
        Browsing = 10,

        [System.ComponentModel.Description("Online file access provided.")]
        FileAccess = 11,
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

        [System.ComponentModel.Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
        Stone = 4,

        [System.ComponentModel.Description("A hard black mineral that is burned as fuel.")]
        Coal = 5,

        [System.ComponentModel.Description("A solid rock or mineral from which metal is obtained.")]
        Ore = 6,

        [System.ComponentModel.Description("Any substance obtained by or used in a chemical process.")]
        Chemicals = 7,

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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum qualityOfHorizontalMeasurement : int
    {
        [System.ComponentModel.Description("The position(s) was(were) determined by the operation of making measurements for determining the relative position of points on, above or beneath the earth's surface. Survey implies a regular, controlled survey of any date.")]
        Surveyed = 1,

        [System.ComponentModel.Description("Survey data is does not exist or is very poor.")]
        Unsurveyed = 2,

        [System.ComponentModel.Description("Not surveyed to modern standards; or due to its age, scale, or positional or vertical uncertainties is not suitable to the type of navigation expected in the area.")]
        InadequatelySurveyed = 3,

        [System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to an object whose position does not remain fixed.")]
        Approximate = 4,

        [System.ComponentModel.Description("Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.")]
        PositionDoubtful = 5,

        [System.ComponentModel.Description("A feature's position has been obtained from questionable or unreliable data.")]
        Unreliable = 6,

        [System.ComponentModel.Description("An object whose position has been reported and its position confirmed by some means other than a formal survey such as an independent report of the same object.")]
        ReportedNotSurveyed = 7,

        [System.ComponentModel.Description("An object whose position has been reported and its position has not been confirmed.")]
        ReportedNotConfirmed = 8,

        [System.ComponentModel.Description("The most probable position of an object determined from incomplete data or data of questionable accuracy.")]
        Estimated = 9,

        [System.ComponentModel.Description("A position that is of a known value, such as the position of an anchor berth or other defined object.")]
        PreciselyKnown = 10,

        [System.ComponentModel.Description("A position that is computed from data.")]
        Calculated = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum repairService : int
    {
        [System.ComponentModel.Description("The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.")]
        CompensationOfMagneticCompass = 1,

        [System.ComponentModel.Description("Underwater inspection and repair performed by divers.")]
        DiverService = 2,

        [System.ComponentModel.Description("Repairs to eqipment installed on the ship's bridge.")]
        BridgeEquipmentRepair = 3,

        [System.ComponentModel.Description("Repair of an engine or machine parts.")]
        EngineRepair = 4,

        [System.ComponentModel.Description("Repair of marine electronic instruments.")]
        ElectronicEquipmentRepair = 5,

        [System.ComponentModel.Description("Repairs to the ship's body, frame, or superstructure.")]
        HullRepair = 6,

        [System.ComponentModel.Description("Repairs to equipment used in the act of navigating a ship.")]
        NavigationalEquipmentRepair = 7,

        [System.ComponentModel.Description("Repairs to propeller hub and blades.")]
        PropellerRepair = 8,

        [System.ComponentModel.Description("Repairs to equipment used in salvage operations.")]
        SalvageGearRepair = 9,

        [System.ComponentModel.Description("Repairs to drive shafts used for transmitting mechanical power and torque to a propeller.")]
        ShaftRepair = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum shipSanitationControl : int
    {
        [System.ComponentModel.Description("Capable of applying measures to ensure that a vessel is free of disease and disease risks, but cannot issue a certificate.")]
        SanitationMeasuresOnly = 1,

        [System.ComponentModel.Description("The competent authority can issue a Ship Sanitation Control Certificate after satisfactorily completing or supervising the completion of ship sanitation control measures.")]
        IssueSscc = 2,

        [System.ComponentModel.Description("The competent authority may issue a Ship Sanitation Control Exemption Certificate if it is satisfied that the ship is free of infection and contamination, including vectors and reservoirs.")]
        IssueSscec = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum sourceType : int
    {
        [System.ComponentModel.Description("Treaty, convention, or international agreement; law or regulation issued by a national or other authority.")]
        LawOrRegulation = 1,

        [System.ComponentModel.Description("Publication not having the force of law, issued by an international organisation or a national or local administration.")]
        OfficialPublication = 2,

        [System.ComponentModel.Description("Reported by mariner(s) and confirmed by another source.")]
        MarinerReportConfirmed = 7,

        [System.ComponentModel.Description("Reported by mariner(s) but not confirmed.")]
        MarinerReportNotConfirmed = 8,

        [System.ComponentModel.Description("Shipping and other industry publications, including graphics, charts and web sites.")]
        IndustryPublicationsAndReports = 9,

        [System.ComponentModel.Description("Information obtained from satellite images.")]
        RemotelySensedImages = 10,

        [System.ComponentModel.Description("Information obtained from photographs.")]
        Photographs = 11,

        [System.ComponentModel.Description("Information obtained from products issued by Hydrographic Offices.")]
        ProductsIssuedByHoServices = 12,

        [System.ComponentModel.Description("Information obtained from news media.")]
        NewsMedia = 13,

        [System.ComponentModel.Description("Information obtained from the analysis of traffic data.")]
        TrafficData = 14,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum supplyService : int
    {
        [System.ComponentModel.Description("The provision of shoreside electrical power to a ship at berth while its main and auxiliary engines are shut down.")]
        ShorePower = 1,

        [System.ComponentModel.Description("Transfer of fuel oil to the fuel compartments of a ship.")]
        FuelOilBunkering = 2,

        [System.ComponentModel.Description("Transfer of liquefied natural gas to the fuel compartments of a ship.")]
        LngBunkering = 3,

        [System.ComponentModel.Description("Substances capable of reducing friction, heat, and wear when introduced as a film between solid surfaces.")]
        Lubricants = 4,

        [System.ComponentModel.Description("The gas into which water is changed by boiling.")]
        Steam = 5,

        [System.ComponentModel.Description("Water which can be used for drinking and food preparation.")]
        PotableWater = 6,

        [System.ComponentModel.Description("A universal hose connection for the supply of water for fighting fires.")]
        InternationalShoreConnection = 7,

        [System.ComponentModel.Description("A place where food and other such supplies are available.")]
        Provisions = 8,

        [System.ComponentModel.Description("A dealer in ships' supplies.")]
        Chandler = 9,

        [System.ComponentModel.Description("A place where mechanical repairs can be undertaken to engines or other vessel equipment.")]
        MechanicsWorkshop = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum technicalPortService : int
    {
        [System.ComponentModel.Description("The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.")]
        CompensationOfMagneticCompass = 1,

        [System.ComponentModel.Description("Neutralization of the strength of the magnetic field of a vessel, by means of suitably arranged electric coils permanently installed in the vessel. See also Degaussing Cable.")]
        Degaussing = 2,

        [System.ComponentModel.Description("Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.")]
        CargoSurveying = 3,

        [System.ComponentModel.Description("Assessment of quality and compliance with applicable law, regulations, and safety standards.")]
        Vetting = 4,
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum verticalDatum : int
    {
        [System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas. Also called spring low water.")]
        MeanLowWaterSprings = 1,

        [System.ComponentModel.Description("The average height of lower low water springs at a place.")]
        MeanLowerLowWaterSprings = 2,

        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        MeanSeaLevel = 3,

        [System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or some what lower.")]
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

        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation. Also called low tide.")]
        LowWater = 13,

        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
        ApproximateMeanLowWater = 14,

        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
        ApproximateMeanLowerLowWater = 15,

        [System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
        MeanHighWater = 16,

        [System.ComponentModel.Description("The average height of the high waters of spring tides. Also called spring high water.")]
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

        [System.ComponentModel.Description("A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Pere, Quebec, over the period 1970 to 1988.")]
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
    public enum vesselsCharacteristics : int
    {
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

        [System.ComponentModel.Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level.")]
        DisplacementTonnageLight = 7,

        [System.ComponentModel.Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft.")]
        DisplacementTonnageLoaded = 8,

        [System.ComponentModel.Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity.")]
        DeadweightTonnage = 9,

        [System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.")]
        GrossTonnage = 10,

        [System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.")]
        NetTonnage = 11,

        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
        PanamaCanalUniversalMeasurementSystemNetTonnage = 12,

        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        SuezCanalNetTonnage = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristicsUnit : int
    {
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

        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        SuezCanalNetTonnage = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum wasteDisposalService : int
    {
        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Oily bilge water\" as specified in MARPOL Annex I.")]
        MarpolAnnexIOilyBilgeWater = 1,

        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Oily Residues (sludge)\" as specified in MARPOL Annex I.")]
        MarpolAnnexIOilyResidues = 2,

        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Oily tank washings (slops)\" as specified in MARPOL Annex I.")]
        MarpolAnnexIOilyTankWashings = 3,

        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Dirty ballast water\" as specified in MARPOL Annex I.")]
        MarpolAnnexIDirtyBallastWater = 4,

        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Scale and sludge from tank cleaning\" as specified in MARPOL Annex I.")]
        MarpolAnnexIScaleAndSludgeFromTankCleaning = 5,

        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Other\" as specified in MARPOL Annex I.")]
        MarpolAnnexIOtherOilyWaste = 6,

        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category X\" as specified in MARPOL Annex II.")]
        MarpolAnnexIiCategoryX = 7,

        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Y\" as specified in MARPOL Annex II.")]
        MarpolAnnexIiCategoryY = 8,

        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Z\" as specified in MARPOL Annex II.")]
        MarpolAnnexIiCategoryZ = 9,

        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Other substance\" as specified in MARPOL Annex II.")]
        MarpolAnnexIiCategoryOs = 10,

        [System.ComponentModel.Description("The service with facility to receive waste/residue of the type \"Sewage\" as specified in MARPOL Annex IV.")]
        MarpolAnnexIvSewage = 11,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Plastics\", as specified in MARPOL Annex V")]
        MarpolAnnexVPlastics = 12,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Food wastes\", as specified in MARPOL Annex V")]
        MarpolAnnexVFoodWastes = 13,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Domestic wastes\", as specified in MARPOL Annex V")]
        MarpolAnnexVDomesticWastes = 14,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Cooking oil\", as specified in MARPOL Annex V")]
        MarpolAnnexVCookingOil = 15,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Incinerator ashes\", as specified in MARPOL Annex V")]
        MarpolAnnexVIncineratorAshes = 16,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Operational wastes\", as specified in MARPOL Annex V")]
        MarpolAnnexVOperationalWastes = 17,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Animal carcasses\", as specified in MARPOL Annex V")]
        MarpolAnnexVAnimalCarcasses = 18,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Fishing gear\", as specified in MARPOL Annex V")]
        MarpolAnnexVFishingGear = 19,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"E-waste\", as specified in MARPOL Annex V")]
        MarpolAnnexVEWaste = 20,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Cargo residues not determined to be harmful to the marine environment\", as specified in MARPOL Annex V")]
        MarpolAnnexVCargoResiduesNonHme = 21,

        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Cargo residues harmful to the marine environment\", as specified in MARPOL Annex V")]
        MarpolAnnexVCargoResiduesHme = 22,

        [System.ComponentModel.Description("The service with facility to receive air pollution related waste/residue of the type \"Ozone-depleting substances\" as specified in MARPOL Annex VI.")]
        MarpolAnnexViOzoneDepletingSubstances = 23,

        [System.ComponentModel.Description("The service with facility to receive air pollution related waste/residue of the type \"Exhaust gas-cleaning residues\" as specified in MARPOL Annex VI.")]
        MarpolAnnexViExhaustGasCleaningResidues = 24,
    }


    [System.Serializable()]
    public class actionOrActivity
    {
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class categoryOfRxN
    {
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class categoryOfVessel
    {
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class securitySafetyEmergencyService
    {
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class transportConnection
    {
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    public static class CodeList
    {
        public static ImmutableArray<actionOrActivity> actionOrActivities => ImmutableArray.Create<actionOrActivity>(new actionOrActivity[]{
            new() {
                code = 1,
                definition = "Carrying a qualified pilot as part of the vessel navigation team.",
                label = "Navigating With a Pilot",
            },
            new() {
                code = 2,
                definition = "Navigating a vessel into a port.",
                label = "Entering Port",
            },
            new() {
                code = 3,
                definition = "Navigating a vessel out of a port.",
                label = "Leaving Port",
            },
            new() {
                code = 4,
                definition = "Attaching a vessel to a wharf or jetty.",
                label = "Berthing",
            },
            new() {
                code = 5,
                definition = "Detaching a vessel from a wharf or jetty.",
                label = "Slipping",
            },
            new() {
                code = 6,
                definition = "Attaching a vessel to the seabed by means of an anchor and cable.",
                label = "Anchoring",
            },
            new() {
                code = 7,
                definition = "Detaching a vessel from the seabed by recovering an anchor and cable.",
                label = "Weighing Anchor",
            },
            new() {
                code = 8,
                definition = "Navigating a vessel along a route or through a narrow gap, such as under a bridge or through a lock.",
                label = "Transiting",
            },
            new() {
                code = 9,
                definition = "Navigating a vessel past another traveling broadly in the same direction.",
                label = "Overtaking",
            },
            new() {
                code = 10,
                definition = "Providing details such as the name, location or intentions of a vessel.",
                label = "Reporting",
            },
            new() {
                code = 11,
                definition = "Loading or unloading cargo.",
                label = "Working Cargo",
            },
            new() {
                code = 12,
                definition = "Placing crew or passengers on shore.",
                label = "Landing",
            },
            new() {
                code = 13,
                definition = "A signal or message warning of diving activity.",
                label = "Diving",
            },
            new() {
                code = 14,
                definition = "Hunting or catching fish.",
                label = "Fishing",
            },
            new() {
                code = 15,
                definition = "Releasing anything into the sea; often ballast water; or spoil from dredging elsewhere.",
                label = "Discharging Overboard",
            },
            new() {
                code = 16,
                definition = "Navigating a vessel past another travelling broadly in the opposite direction.",
                label = "Passing",
            },
        });

        public static ImmutableArray<categoryOfRxN> categoryOfRxNS => ImmutableArray.Create<categoryOfRxN>(new categoryOfRxN[]{
            new() {
                code = 1,
                definition = "The process of directing the movement of a craft from one point to another.",
                label = "Navigation",
            },
            new() {
                code = 2,
                definition = "Transmitting and/or receiving electronic communication signals.",
                label = "Communication",
            },
            new() {
                code = 3,
                definition = "Pertaining to environmental protection.",
                label = "Environmental Protection",
            },
            new() {
                code = 4,
                definition = "Pertaining to wildlife protection.",
                label = "Wildlife Protection",
            },
            new() {
                code = 5,
                definition = "Pertaining to security.",
                label = "Security",
            },
            new() {
                code = 6,
                definition = "The agency or establishment for collecting duties, tolls.",
                label = "Customs",
            },
            new() {
                code = 7,
                definition = "Pertaining to cargo operations.",
                label = "Cargo Operation",
            },
            new() {
                code = 8,
                definition = "Pertaining to a place of safety or refuge.",
                label = "Refuge",
            },
            new() {
                code = 9,
                definition = "The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.",
                label = "Health",
            },
            new() {
                code = 10,
                definition = "Pertaining to natural resources or exploitation.",
                label = "Natural Resources or Exploitation",
            },
            new() {
                code = 11,
                definition = "Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.",
                label = "Port",
            },
            new() {
                code = 12,
                definition = "An authority with responsibility for the control and movement of money.",
                label = "Finance",
            },
            new() {
                code = 13,
                definition = "The science, art, or practice of cultivating the soil, producing crops, and raising livestock and in varying degrees the preparation and marketing of the resulting products.",
                label = "Agriculture",
            },
        });

        public static ImmutableArray<categoryOfVessel> categoryOfVessels => ImmutableArray.Create<categoryOfVessel>(new categoryOfVessel[]{
            new() {
                code = 1,
                definition = "A vessel which is designed for carrying general cargo, e.g. boxes, sacks.",
                label = "General Cargo Vessel",
            },
            new() {
                code = 2,
                definition = "A vessel designed to carry ISO containers.",
                label = "Container Carrier",
            },
            new() {
                code = 3,
                definition = "A vessel which is designed for carrying liquid goods, for example oil or water.",
                label = "Tanker",
            },
            new() {
                code = 4,
                definition = "A vessel which is designed for carrying bulk goods, e.g. coal, ore or grain.",
                label = "Bulk Carrier",
            },
            new() {
                code = 5,
                definition = "A day trip or cabin vessel constructed and equipped to carry more than 12 passengers.",
                label = "Passenger Vessel",
            },
            new() {
                code = 6,
                definition = "A vessel designed to allow road vehicles to be driven on and off; often a ferry.",
                label = "Roll-On Roll-Off",
            },
            new() {
                code = 7,
                definition = "A vessel designed to carry refrigerated cargo.",
                label = "Refrigerated Cargo Vessel",
            },
            new() {
                code = 8,
                definition = "A vessel that is used and equipped for the fishing of living aquatic resources.",
                label = "Fishing Vessel",
            },
            new() {
                code = 9,
                definition = "A vessel which provides a service such as a tug, anchor handler, survey or supply vessel.",
                label = "Service",
            },
            new() {
                code = 10,
                definition = "A vessel designed for the conduct of military operations.",
                label = "Warship",
            },
            new() {
                code = 11,
                definition = "Either a tug and tow, or any combination of a tug providing propulsion to barges or vessels secured ahead or alongside.",
                label = "Towed or Pushed Composite Unit",
            },
            new() {
                code = 12,
                definition = "A combination of tug(s) and non-powered tow(s).",
                label = "Tug and Tow",
            },
            new() {
                code = 13,
                definition = "A pleasure boat or watercraft, or an excursion vessel used for short cruises such as whale watching.",
                label = "Light Recreational",
            },
            new() {
                code = 14,
                definition = "An installation which is designed to float at all times and which is normally anchored in position when deployed in the offshore gas and oil industry.",
                label = "Semi-Submersible Offshore Installation",
            },
            new() {
                code = 15,
                definition = "An exploration or project installation with legs which can be raised and lowered. The legs are raised when the installation is re-positioned. When stationary the legs are lowered to the sea floor and the working platform is raised clear of the sea surface.",
                label = "Jack-Up Exploration or Project Installation",
            },
            new() {
                code = 16,
                definition = "A vessel designed to carry large quantities of live animals.",
                label = "Livestock Carrier",
            },
            new() {
                code = 17,
                definition = "A vessel used in fishing for pleasure or competition.",
                label = "Sport Fishing",
            },
        });

        public static ImmutableArray<securitySafetyEmergencyService> securitySafetyEmergencyServices => ImmutableArray.Create<securitySafetyEmergencyService>(new securitySafetyEmergencyService[]{
            new() {
                code = 1,
                definition = "Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.",
                label = "Coast Guard",
            },
            new() {
                code = 2,
                definition = "The agency or establishment for collecting duties, tolls.",
                label = "Customs",
            },
            new() {
                code = 3,
                definition = "Office for reporting or obtaining information about sudden dangers to the environment such as spillage of polluting or hazardous substances.",
                label = "Environmental Emergency Information Centre",
            },
            new() {
                code = 4,
                definition = "An office or organisation for reporting or coordinating response to emergencies.",
                label = "Emergency Coordination Centre",
            },
            new() {
                code = 5,
                definition = "A place where a vessel is patrolled by a security service or stored in a secure lockup.",
                label = "Guard and/or Security Service",
            },
            new() {
                code = 6,
                definition = "The authority controlling people entering a country.",
                label = "Immigration",
            },
            new() {
                code = 7,
                definition = "The department of government, or civil force, charged with maintaining public order.",
                label = "Police",
            },
            new() {
                code = 8,
                definition = "A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.",
                label = "Sea Rescue Control",
            },
        });

        public static ImmutableArray<transportConnection> transportConnections => ImmutableArray.Create<transportConnection>(new transportConnection[]{
            new() {
                code = 2,
                definition = "A small airport for the use of helicopters and some other vertical lift aircraft. Heliports typically contain one or more touchdown and liftoff areas and also have facilities such as fuel or hangars. In some larger towns and cities, customs facilities may also be available.",
                label = "Heliport",
            },
            new() {
                code = 3,
                definition = "A small landing surface for helicopters, with minimal or no supporting installations or facilities.",
                label = "Helipad",
            },
            new() {
                code = 4,
                definition = "Small boat with crew that may be hired for single journeys.",
                label = "Hired Boat",
            },
            new() {
                code = 5,
                definition = "A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.",
                label = "Bus Station",
            },
            new() {
                code = 6,
                definition = "A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.",
                label = "Ferry",
            },
            new() {
                code = 8,
                definition = "A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.",
                label = "Motorway",
            },
            new() {
                code = 9,
                definition = "Large open or half decked boat.",
                label = "Launch",
            },
            new() {
                code = 11,
                definition = "The carriage of goods or passengers using navigable waterways such as canals, rivers, lakes, or other stretch of water that is not part of the sea.",
                label = "Inland Waterway Transport",
            },
            new() {
                code = 12,
                definition = "The carriage of specified types of cargo between qualifying ports. The types of cargo and/or qualifying ports are generally specified by law or government regulation.",
                label = "Short Sea Transportation",
            },
            new() {
                code = 13,
                definition = "Specially designated commercially navigable routes in coastal, inland, and intracoastal waters, frequently as waterborne relievers to congested landside routes.",
                label = "Marine Highway",
            },
        });
    }

    namespace ComplexAttributes
    {

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class contactAddress
        {
            public List<String> deliveryPoint { get; set; } = [];
            public String cityName { get; set; } = string.Empty;
            public String administrativeDivision { get; set; } = string.Empty;
            public String countryName { get; set; } = string.Empty;
            public String postalCode { get; set; } = string.Empty;

            public contactAddress()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName
        {
            public Boolean? displayName { get; set; } = default;
            public String language { get; set; } = string.Empty;
            public String name { get; set; } = string.Empty;

            public featureName()
            {
                name = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class fixedDateRange
        {
            public DateOnly? dateStart { get; set; } = default;
            public DateOnly? dateEnd { get; set; } = default;

            public fixedDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class frequencyPair
        {
            public List<Int32> frequencyShoreStationTransmits { get; set; } = [];
            public List<Int32> frequencyShoreStationReceives { get; set; } = [];
            public List<String> contactInstructions { get; set; } = [];

            public frequencyPair()
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
            public List<String> headline { get; set; } = [];
            public String language { get; set; } = string.Empty;
            public String text { get; set; } = string.Empty;

            public information()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class onlineResource
        {
            public String onlineResourceLinkageURL { get; set; } = string.Empty;
            public String protocol { get; set; } = string.Empty;
            public String applicationProfile { get; set; } = string.Empty;
            public String nameOfResource { get; set; } = string.Empty;
            public String onlineResourceDescription { get; set; } = string.Empty;
            public onlineFunction? onlineFunction { get; set; } = default;
            public String protocolRequest { get; set; } = string.Empty;

            public onlineResource()
            {
                onlineResourceLinkageURL = string.Empty;
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
            public DateOnly dateStart { get; set; }

            [Required()]
            public DateOnly dateEnd { get; set; }

            public periodicDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class rxNCode
        {
            public categoryOfRxN? categoryOfRxN { get; set; }
            public actionOrActivity? actionOrActivity { get; set; }
            public List<String> headline { get; set; } = [];

            public rxNCode()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class surveyDateRange
        {
            public DateOnly? dateStart { get; set; } = default;

            [Required()]
            public DateOnly dateEnd { get; set; }

            public surveyDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class textContent
        {
            public categoryOfText? categoryOfText { get; set; } = default;
            public List<information> information { get; set; } = [];
            public onlineResource? onlineResource { get; set; }
            public String source { get; set; } = string.Empty;
            public sourceType? sourceType { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            public textContent()
            {
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
        public partial class usefulMarkDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public usefulMarkDescription()
            {
                textContent = new();
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
        public partial class vesselsMeasurements
        {
            [Required()]
            public comparisonOperator comparisonOperator { get; set; }

            [Required()]
            public vesselsCharacteristics vesselsCharacteristics { get; set; }

            [Required()]
            public Decimal vesselsCharacteristicsValue { get; set; }

            [Required()]
            public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; }

            public vesselsMeasurements()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class weatherResource
        {
            public onlineResource? onlineResource { get; set; }
            public dynamicResource? dynamicResource { get; set; } = default;
            public textContent? textContent { get; set; }

            public weatherResource()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class bearingInformation
        {
            public cardinalDirection? cardinalDirection { get; set; } = default;
            public Decimal? distance { get; set; } = default;
            public List<Decimal> sectorBearing { get; set; } = [];
            public List<information> information { get; set; } = [];
            public orientation? orientation { get; set; }

            public bearingInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class cargoServicesDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public cargoServicesDescription()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class constructionInformation
        {
            public fixedDateRange? fixedDateRange { get; set; }
            public condition? condition { get; set; } = default;
            public String development { get; set; } = string.Empty;
            public String locationByText { get; set; } = string.Empty;
            public List<textContent> textContent { get; set; } = [];

            public constructionInformation()
            {
                development = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class depthsDescription
        {
            [Required()]
            public categoryOfDepthsDescription categoryOfDepthsDescription { get; set; }

            [Required()]
            public List<textContent> textContent { get; set; }

            public depthsDescription()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class facilitiesLayoutDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public facilitiesLayoutDescription()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class generalPortDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public generalPortDescription()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class graphic
#pragma warning restore CS8981
        {
            [Required()]
            public List<String> pictorialRepresentation { get; set; }
            public String pictureCaption { get; set; } = string.Empty;
            public DateTime? sourceDate { get; set; } = default;
            public String pictureInformation { get; set; } = string.Empty;
            public bearingInformation? bearingInformation { get; set; }

            public graphic()
            {
                pictorialRepresentation = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class landmarkDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public landmarkDescription()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class limitsDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public limitsDescription()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class majorLightDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public majorLightDescription()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class markedBy
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public markedBy()
            {
                textContent = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class offshoreMarkDescription
        {
            [Required()]
            public List<textContent> textContent { get; set; }

            public offshoreMarkDescription()
            {
                textContent = new();
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
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class telecommunications
#pragma warning restore CS8981
        {
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;
            public String telecommunicationIdentifier { get; set; } = string.Empty;
            public String telecommunicationCarrier { get; set; } = string.Empty;
            public String contactInstructions { get; set; } = string.Empty;
            public List<telecommunicationService> telecommunicationService { get; set; } = [];
            public scheduleByDayOfWeek? scheduleByDayOfWeek { get; set; }

            public telecommunications()
            {
                telecommunicationIdentifier = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class generalHarbourInformation
        {
            public generalPortDescription? generalPortDescription { get; set; }
            public facilitiesLayoutDescription? facilitiesLayoutDescription { get; set; }
            public limitsDescription? limitsDescription { get; set; }
            public constructionInformation? constructionInformation { get; set; }
            public cargoServicesDescription? cargoServicesDescription { get; set; }
            public List<weatherResource> weatherResource { get; set; } = [];

            public generalHarbourInformation()
            {
            }
        }
    }

    public enum Role
    {
        [System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
        positions,

        [System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
        componentOf,

        [System.ComponentModel.Description("A pointer to a specific feature(s) for which further information is required.")]
        informationProvidedFor,

        [System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
        providesInformation,

        [System.ComponentModel.Description("The applicable regulation, restriction, recommendation or nautical information")]
        theApplicableRxN,

        [System.ComponentModel.Description("The location in which the information item applies")]
        appliesInLocation,

        [System.ComponentModel.Description("A pointer to an Authority object")]
        theAuthority,

        [System.ComponentModel.Description("The authority for which service hours are given")]
        theAuthority_srvHrs,

        [System.ComponentModel.Description("A pointer to an Contact Details object")]
        theContactDetails,

        [System.ComponentModel.Description("The controlling organization or authority for a geographically located service")]
        controlAuthority,

        [System.ComponentModel.Description("The service controlled by an organisation or authority")]
        controlledService,

        [System.ComponentModel.Description("A pointer to a specific feature(s).")]
        identifies,

        [System.ComponentModel.Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
        isApplicableTo,

        [System.ComponentModel.Description("Service hours for an authority or service provider")]
        theServiceHours,

        [System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
        theRxN,

        [System.ComponentModel.Description("The usual service hours to which an exception applies")]
        theServiceHours_nsdy,

        [System.ComponentModel.Description("The location to which the permission statement applies")]
        vslLocation,

        [System.ComponentModel.Description("The work hours for a non-standard workday")]
        partialWorkingDay,

        [System.ComponentModel.Description("Pointer to service or facility")]
        servicePlace,

        [System.ComponentModel.Description("The location for which service hours are given")]
        location_srvHrs,

        [System.ComponentModel.Description("The organisation to which information relates")]
        theOrganisation,

        [System.ComponentModel.Description("Information related to an organisation")]
        theInformation,

        [System.ComponentModel.Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
        permission,

        [System.ComponentModel.Description("Reference to a whole of the same type as the part feature in the relationship.")]
        constitute,

        [System.ComponentModel.Description("A reference to a feature that supplements or supports the use of the primary feature in an AuxiliaryFacility relationship.")]
        auxiliaryFacility,

        [System.ComponentModel.Description("Reference to the feature within which locations are demarcated.")]
        demarcatedFeature,

        [System.ComponentModel.Description("Reference to a feature demarcating a location within another feature.")]
        demarcationIndicator,

        [System.ComponentModel.Description("Reference to an information type describing the entrance to a limit area.")]
        entranceReference,

        [System.ComponentModel.Description("A reference to the feature to which entrance information pertains.")]
        entranceTo,

        [System.ComponentModel.Description("Reference to the feature describing a particular instance of physical infrastructure.")]
        hasInfrastructure,

        [System.ComponentModel.Description("Reference to the feature within which the infrastructure is located.")]
        infrastructureLocation,

        [System.ComponentModel.Description("Reference to a feature demarcating the extent to which a coastal State claims or may claim a specific jurisdiction.")]
        limitExtent,

        [System.ComponentModel.Description("Reference to the feature for which a coastal State claims a specific jurisdiction different from the feature's geographic boundary.")]
        limitReference,

        [System.ComponentModel.Description("A reference to the diverse units comprising a feature of a different type.")]
        layoutUnit,

        [System.ComponentModel.Description("Reference to the location (feature) where specified services are available.")]
        locationServed,

        [System.ComponentModel.Description("Reference to information about the days and times during which a facility operates or may be used.")]
        facilityOperatingHours,

        [System.ComponentModel.Description("A reference to the primary feature in an Auxiliaryfacility relationship.")]
        primaryFacility,

        [System.ComponentModel.Description("Reference to an information object describing services.")]
        serviceDescriptionReference,

        [System.ComponentModel.Description("Reference to a part of the same type as the whole feature in the relationship.")]
        subUnit,

        [System.ComponentModel.Description("A pointer to a specific spatial type(s).")]
        definedFor,

        [System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
        defines,
    }

    namespace Associations
    {
        namespace InformationAssociations
        {

            public class AdditionalInformation : InformationAssociation
            {
                public AdditionalInformation()
                {
                }
                public static Role[] Roles => new[] { Role.providesInformation, Role.informationProvidedFor };
            }


            public class AuthorityContact : InformationAssociation
            {
                public AuthorityContact()
                {
                }
                public static Role[] Roles => new[] { Role.theAuthority, Role.theContactDetails };
            }


            public class AuthorityHours : InformationAssociation
            {
                public AuthorityHours()
                {
                }
                public static Role[] Roles => new[] { Role.theAuthority_srvHrs, Role.theServiceHours };
            }


            public class AssociatedRxN : InformationAssociation
            {
                public AssociatedRxN()
                {
                }
                public static Role[] Roles => new[] { Role.appliesInLocation, Role.theRxN };
            }


            public class ExceptionalWorkday : InformationAssociation
            {
                public ExceptionalWorkday()
                {
                }
                public static Role[] Roles => new[] { Role.theServiceHours_nsdy, Role.partialWorkingDay };
            }


            public class ServiceControl : InformationAssociation
            {
                public ServiceControl()
                {
                }
                public static Role[] Roles => new[] { Role.controlledService, Role.controlAuthority };
            }


            public class ServiceContact : InformationAssociation
            {
                public ServiceContact()
                {
                }
                public static Role[] Roles => new[] { Role.servicePlace, Role.theContactDetails };
            }


            public class LocationHours : InformationAssociation
            {
                public LocationHours()
                {
                }
                public static Role[] Roles => new[] { Role.location_srvHrs, Role.facilityOperatingHours };
            }


            public class RelatedOrganisation : InformationAssociation
            {
                public RelatedOrganisation()
                {
                }
                public static Role[] Roles => new[] { Role.theInformation, Role.theOrganisation };
            }


            public class InclusionType : InformationAssociation
            {
                public InclusionType()
                {
                }
                public static Role[] Roles => new[] { Role.theApplicableRxN, Role.isApplicableTo };
                [Required()]
                public membership membership { get; set; }
            }


            public class PermissionType : InformationAssociation
            {
                public PermissionType()
                {
                }
                public static Role[] Roles => new[] { Role.vslLocation, Role.permission };
                [Required()]
                public categoryOfRelationship categoryOfRelationship { get; set; }
            }


            public class SpatialAssociation : InformationAssociation
            {
                public SpatialAssociation()
                {
                }
                public static Role[] Roles => new[] { Role.defines, Role.definedFor };
            }


            public class LimitEntrance : InformationAssociation
            {
                public LimitEntrance()
                {
                }
                public static Role[] Roles => new[] { Role.entranceTo, Role.entranceReference };
            }


            public class ServiceAvailability : InformationAssociation
            {
                public ServiceAvailability()
                {
                }
                public static Role[] Roles => new[] { Role.locationServed, Role.serviceDescriptionReference };
            }

        }
        namespace FeatureAssociations
        {

            public class TextAssociation : FeatureAssociation
            {
                public TextAssociation()
                {
                }
                public static Role[] Roles => new[] { Role.identifies, Role.positions };
            }


            public class Subsection : FeatureAssociation
            {
                public Subsection()
                {
                }
                public static Role[] Roles => new[] { Role.subUnit, Role.constitute };
            }


            public class Infrastructure : FeatureAssociation
            {
                public Infrastructure()
                {
                }
                public static Role[] Roles => new[] { Role.infrastructureLocation, Role.hasInfrastructure };
            }


            public class PrimaryAuxiliaryFacility : FeatureAssociation
            {
                public PrimaryAuxiliaryFacility()
                {
                }
                public static Role[] Roles => new[] { Role.primaryFacility, Role.auxiliaryFacility };
            }


            public class Demarcation : FeatureAssociation
            {
                public Demarcation()
                {
                }
                public static Role[] Roles => new[] { Role.demarcationIndicator, Role.demarcatedFeature };
            }


            public class JurisdictionalLimit : FeatureAssociation
            {
                public JurisdictionalLimit()
                {
                }
                public static Role[] Roles => new[] { Role.limitReference, Role.limitExtent };
            }


            public class LayoutDivision : FeatureAssociation
            {
                public LayoutDivision()
                {
                }
                public static Role[] Roles => new[] { Role.layoutUnit, Role.componentOf };
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
        using S100Framework.DomainModel.Bindings;


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class InformationType : InformationTypeBase
        {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<graphic> graphic { get; set; } = [];
            public String source { get; set; } = string.Empty;
            public sourceType? sourceType { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<informationBinding<Associations.InformationAssociations.AdditionalInformation>> providesInformationOfAdditionalInformation { get; set; } = [];
            public override string Code => nameof(InformationType);

            public InformationType()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class AbstractRxN : InformationType
        {
            public categoryOfAuthority? categoryOfAuthority { get; set; } = default;
            public List<rxNCode> rxNCode { get; set; } = [];
            public List<textContent> textContent { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.InclusionType>> isApplicableToOfInclusionType { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.RelatedOrganisation>> theOrganisationOfRelatedOrganisation { get; set; } = [];
            public override string Code => nameof(AbstractRxN);

            public AbstractRxN()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Applicability : InformationType
        {
            public Boolean? inBallast { get; set; } = default;
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];
            public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo { get; set; } = [];
            public categoryOfVessel? categoryOfVessel { get; set; }
            public categoryOfVesselRegistry? categoryOfVesselRegistry { get; set; } = default;
            public logicalConnectives? logicalConnectives { get; set; } = default;
            public Int32? thicknessOfIceCapability { get; set; } = default;
            public String vesselPerformance { get; set; } = string.Empty;
            public List<information> information { get; set; } = [];
            public List<vesselsMeasurements> vesselsMeasurements { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.InclusionType>> theApplicableRxNOfInclusionType { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.PermissionType>> vslLocationOfPermissionType { get; set; } = [];
            public override string Code => nameof(Applicability);

            public Applicability()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Authority : InformationType
        {
            [Required()]
            public categoryOfAuthority categoryOfAuthority { get; set; }
            public textContent? textContent { get; set; }
            public List<informationBinding<Associations.InformationAssociations.AuthorityContact>> theContactDetailsOfAuthorityContact { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.RelatedOrganisation>> theInformationOfRelatedOrganisation { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.AuthorityHours>> theServiceHoursOfAuthorityHours { get; set; } = [];
            public override string Code => nameof(Authority);

            public Authority()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AvailablePortServices : InformationType
        {
            public List<firefightingService> firefightingService { get; set; } = [];
            public List<medicalService> medicalService { get; set; } = [];
            public List<repairService> repairService { get; set; } = [];
            public List<technicalPortService> technicalPortService { get; set; } = [];
            public List<shipSanitationControl> shipSanitationControl { get; set; } = [];
            public List<transportConnection> transportConnection { get; set; } = [];
            public List<berthingAssistance> berthingAssistance { get; set; } = [];
            public List<cargoService> cargoService { get; set; } = [];
            public List<securitySafetyEmergencyService> securitySafetyEmergencyService { get; set; } = [];
            public List<wasteDisposalService> wasteDisposalService { get; set; } = [];
            public List<supplyService> supplyService { get; set; } = [];
            public String tugInformation { get; set; } = string.Empty;
            public List<textContent> textContent { get; set; } = [];
            public override string Code => nameof(AvailablePortServices);

            public AvailablePortServices()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContactDetails : InformationType
        {
            public String callName { get; set; } = string.Empty;
            public String callSign { get; set; } = string.Empty;
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;
            public List<String> communicationChannel { get; set; } = [];
            public List<contactAddress> contactAddress { get; set; } = [];
            public String contactInstructions { get; set; } = string.Empty;
            public List<Int32> signalFrequency { get; set; } = [];
            public List<frequencyPair> frequencyPair { get; set; } = [];
            public List<information> information { get; set; } = [];
            public String mMSICode { get; set; } = string.Empty;
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<telecommunications> telecommunications { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.AuthorityContact>> theAuthorityOfAuthorityContact { get; set; } = [];
            public override string Code => nameof(ContactDetails);

            public ContactDetails()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Entrance : InformationType
        {
            public String entranceDescription { get; set; } = string.Empty;
            public List<String> associatedFeatureName { get; set; } = [];
            public String localKnowledgeDescription { get; set; } = string.Empty;
            public String approachDescription { get; set; } = string.Empty;
            public List<markedBy> markedBy { get; set; } = [];
            public List<landmarkDescription> landmarkDescription { get; set; } = [];
            public List<offshoreMarkDescription> offshoreMarkDescription { get; set; } = [];
            public List<majorLightDescription> majorLightDescription { get; set; } = [];
            public List<usefulMarkDescription> usefulMarkDescription { get; set; } = [];
            public List<textContent> textContent { get; set; } = [];
            public override string Code => nameof(Entrance);

            public Entrance()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NauticalInformation : AbstractRxN
        {
            public List<informationBinding<Associations.InformationAssociations.AdditionalInformation>> informationProvidedForOfAdditionalInformation { get; set; } = [];
            public override string Code => nameof(NauticalInformation);

            public NauticalInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NonStandardWorkingDay : InformationType
        {
            public List<DateOnly> dateFixed { get; set; } = [];
            public List<String> dateVariable { get; set; } = [];
            public List<information> information { get; set; } = [];
            public override string Code => nameof(NonStandardWorkingDay);

            public NonStandardWorkingDay()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Recommendations : AbstractRxN
        {
            public override string Code => nameof(Recommendations);

            public Recommendations()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Regulations : AbstractRxN
        {
            public override string Code => nameof(Regulations);

            public Regulations()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Restrictions : AbstractRxN
        {
            public override string Code => nameof(Restrictions);

            public Restrictions()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ServiceHours : InformationType
        {
            [Required()]
            public List<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; }
            public List<information> information { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.ExceptionalWorkday>> partialWorkingDayOfExceptionalWorkday { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.AuthorityHours>> theAuthority_srvHrsOfAuthorityHours { get; set; } = [];
            public override string Code => nameof(ServiceHours);

            public ServiceHours()
            {
                scheduleByDayOfWeek = new();
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
        using S100Framework.DomainModel.Bindings;


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class FeatureType : FeatureTypeBase
        {
            public String locationMRN { get; set; } = string.Empty;
            public String globalLocationNumber { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<rxNCode> rxNCode { get; set; } = [];
            public List<graphic> graphic { get; set; } = [];
            public String source { get; set; } = string.Empty;
            public sourceType? sourceType { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;
            public List<textContent> textContent { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.PermissionType>> permissionOfPermissionType { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.AssociatedRxN>> theRxNOfAssociatedRxN { get; set; } = [];
            public List<informationBinding<Associations.InformationAssociations.AdditionalInformation>> providesInformationOfAdditionalInformation { get; set; } = [];
            public featureBinding<Associations.FeatureAssociations.TextAssociation>? positionsOfTextAssociation { get; set; }
            public override string Code => nameof(FeatureType);

            public FeatureType()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class OrganizationContactArea : FeatureType
        {
            public List<informationBinding<Associations.InformationAssociations.ServiceContact>> theContactDetailsOfServiceContact { get; set; } = [];
            public override string Code => nameof(OrganizationContactArea);

            public OrganizationContactArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class SupervisedArea : OrganizationContactArea
        {
            public informationBinding<Associations.InformationAssociations.ServiceControl>? controlAuthorityOfServiceControl { get; set; }
            public override string Code => nameof(SupervisedArea);

            public SupervisedArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class HarbourPhysicalInfrastructure : SupervisedArea
        {
            public Decimal? verticalClearanceValue { get; set; } = default;
            public featureBinding<Associations.FeatureAssociations.Infrastructure>? infrastructureLocationOfInfrastructure { get; set; }
            public override string Code => nameof(HarbourPhysicalInfrastructure);

            public HarbourPhysicalInfrastructure()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class Layout : SupervisedArea
        {
            public override string Code => nameof(Layout);

            public Layout()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AnchorBerth : Layout
        {
            public informationBinding<Associations.InformationAssociations.ServiceAvailability>? serviceDescriptionReferenceOfServiceAvailability { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public List<featureBinding<Associations.FeatureAssociations.PrimaryAuxiliaryFacility>> auxiliaryFacilityOfPrimaryAuxiliaryFacility { get; set; } = [];
            public override string Code => nameof(AnchorBerth);

            public AnchorBerth()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AnchorageArea : Layout
        {
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(AnchorageArea);

            public AnchorageArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Berth : Layout
        {
            public Decimal? availableBerthingLength { get; set; } = default;
            public String bollardDescription { get; set; } = string.Empty;
            public Decimal? bollardPull { get; set; } = default;
            public Decimal? minimumBerthDepth { get; set; } = default;
            public Decimal? elevation { get; set; } = default;
            public Boolean? cathodicProtectionSystem { get; set; } = default;
            public categoryOfBerthLocation? categoryOfBerthLocation { get; set; } = default;
            public String portFacilityNumber { get; set; } = string.Empty;
            public List<String> bollardNumber { get; set; } = [];
            public String gLNExtension { get; set; } = string.Empty;
            public List<String> metreMarkNumber { get; set; } = [];
            public List<String> manifoldNumber { get; set; } = [];
            public String rampNumber { get; set; } = string.Empty;
            public String locationByText { get; set; } = string.Empty;
            public methodOfSecuring? methodOfSecuring { get; set; } = default;
            public String uNLocationCode { get; set; } = string.Empty;
            public String terminalIdentifier { get; set; } = string.Empty;
            public informationBinding<Associations.InformationAssociations.ServiceAvailability>? serviceDescriptionReferenceOfServiceAvailability { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public List<featureBinding<Associations.FeatureAssociations.Demarcation>> demarcationIndicatorOfDemarcation { get; set; } = [];
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(Berth);

            public Berth()
            {
                uNLocationCode = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class BerthPosition : Layout
        {
            public Decimal? availableBerthingLength { get; set; } = default;
            public String bollardDescription { get; set; } = string.Empty;
            public Decimal? bollardPull { get; set; } = default;
            public List<String> bollardNumber { get; set; } = [];
            public String gLNExtension { get; set; } = string.Empty;
            public List<String> metreMarkNumber { get; set; } = [];
            public List<String> manifoldNumber { get; set; } = [];
            public String rampNumber { get; set; } = string.Empty;
            public String locationByText { get; set; } = string.Empty;
            public featureBinding<Associations.FeatureAssociations.Demarcation> demarcatedFeatureOfDemarcation { get; set; }
            public List<featureBinding<Associations.FeatureAssociations.PrimaryAuxiliaryFacility>> auxiliaryFacilityOfPrimaryAuxiliaryFacility { get; set; } = [];
            public override string Code => nameof(BerthPosition);

            public BerthPosition()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DockArea : Layout
        {
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.ServiceAvailability>? serviceDescriptionReferenceOfServiceAvailability { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(DockArea);

            public DockArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DryDock : HarbourPhysicalInfrastructure
        {
            public Decimal? sillDepth { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public override string Code => nameof(DryDock);

            public DryDock()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DumpingGround : Layout
        {
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(DumpingGround);

            public DumpingGround()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class FloatingDock : HarbourPhysicalInfrastructure
        {
            public Decimal? sillDepth { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public override string Code => nameof(FloatingDock);

            public FloatingDock()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Gridiron : HarbourPhysicalInfrastructure
        {
            public Decimal? sillDepth { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public override string Code => nameof(Gridiron);

            public Gridiron()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class HarbourAreaAdministrative : Layout
        {
            public String uNLocationCode { get; set; } = string.Empty;
            public String nationality { get; set; } = string.Empty;
            public String applicableLoadLineZone { get; set; } = string.Empty;
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = [];
            public generalHarbourInformation? generalHarbourInformation { get; set; }
            public informationBinding<Associations.InformationAssociations.ServiceAvailability>? serviceDescriptionReferenceOfServiceAvailability { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.JurisdictionalLimit>? limitExtentOfJurisdictionalLimit { get; set; }
            public List<featureBinding<Associations.FeatureAssociations.LayoutDivision>> layoutUnitOfLayoutDivision { get; set; } = [];
            public override string Code => nameof(HarbourAreaAdministrative);

            public HarbourAreaAdministrative()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class HarbourAreaSection : Layout
        {
            public categoryOfPortSection? categoryOfPortSection { get; set; } = default;
            public List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = [];
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public facilitiesLayoutDescription? facilitiesLayoutDescription { get; set; }
            public informationBinding<Associations.InformationAssociations.ServiceAvailability>? serviceDescriptionReferenceOfServiceAvailability { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision>? componentOfOfLayoutDivision { get; set; }
            public featureBinding<Associations.FeatureAssociations.Subsection>? constituteOfSubsection { get; set; }
            public List<featureBinding<Associations.FeatureAssociations.Subsection>> subUnitOfSubsection { get; set; } = [];
            public List<featureBinding<Associations.FeatureAssociations.Infrastructure>> hasInfrastructureOfInfrastructure { get; set; } = [];
            public List<featureBinding<Associations.FeatureAssociations.LayoutDivision>> layoutUnitOfLayoutDivision { get; set; } = [];
            public override string Code => nameof(HarbourAreaSection);

            public HarbourAreaSection()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class HarbourBasin : Layout
        {
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(HarbourBasin);

            public HarbourBasin()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class HarbourFacility : HarbourPhysicalInfrastructure
        {
            [Required()]
            public List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public override string Code => nameof(HarbourFacility);

            public HarbourFacility()
            {
                categoryOfHarbourFacility = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MooringWarpingFacility : Layout
        {
            [Required()]
            public categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility { get; set; }
            public String iDCode { get; set; } = string.Empty;
            public String bollardDescription { get; set; } = string.Empty;
            public Decimal? bollardPull { get; set; } = default;
            public Boolean? heavingLinesFromShore { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.ServiceAvailability>? serviceDescriptionReferenceOfServiceAvailability { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.PrimaryAuxiliaryFacility>? primaryFacilityOfPrimaryAuxiliaryFacility { get; set; }
            public override string Code => nameof(MooringWarpingFacility);

            public MooringWarpingFacility()
            {
                iDCode = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class OuterLimit : Layout
        {
            public limitsDescription? limitsDescription { get; set; }
            public List<markedBy> markedBy { get; set; } = [];
            public List<landmarkDescription> landmarkDescription { get; set; } = [];
            public List<offshoreMarkDescription> offshoreMarkDescription { get; set; } = [];
            public List<majorLightDescription> majorLightDescription { get; set; } = [];
            public List<usefulMarkDescription> usefulMarkDescription { get; set; } = [];
            public informationBinding<Associations.InformationAssociations.LimitEntrance>? entranceReferenceOfLimitEntrance { get; set; }
            public featureBinding<Associations.FeatureAssociations.JurisdictionalLimit> limitReferenceOfJurisdictionalLimit { get; set; }
            public override string Code => nameof(OuterLimit);

            public OuterLimit()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PilotBoardingPlace : Layout
        {
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(PilotBoardingPlace);

            public PilotBoardingPlace()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class SeaplaneLandingArea : Layout
        {
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(SeaplaneLandingArea);

            public SeaplaneLandingArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Terminal : Layout
        {
            public String portFacilityNumber { get; set; } = string.Empty;
            public categoryOfHarbourFacility? categoryOfHarbourFacility { get; set; } = default;
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];
            public List<product> product { get; set; } = [];
            public String terminalIdentifier { get; set; } = string.Empty;
            public String sMDGTerminalCode { get; set; } = string.Empty;
            public String uNLocationCode { get; set; } = string.Empty;
            public informationBinding<Associations.InformationAssociations.ServiceAvailability>? serviceDescriptionReferenceOfServiceAvailability { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public List<featureBinding<Associations.FeatureAssociations.LayoutDivision>> layoutUnitOfLayoutDivision { get; set; } = [];
            public List<featureBinding<Associations.FeatureAssociations.Infrastructure>> hasInfrastructureOfInfrastructure { get; set; } = [];
            public override string Code => nameof(Terminal);

            public Terminal()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TurningBasin : Layout
        {
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public iSPSLevel? iSPSLevel { get; set; } = default;
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(TurningBasin);

            public TurningBasin()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class WaterwayArea : Layout
        {
            [Required()]
            public categoryOfPortSection categoryOfPortSection { get; set; }
            public depthsDescription? depthsDescription { get; set; }
            public String locationByText { get; set; } = string.Empty;
            public markedBy? markedBy { get; set; }
            public informationBinding<Associations.InformationAssociations.LocationHours>? location_srvHrsOfLocationHours { get; set; }
            public featureBinding<Associations.FeatureAssociations.LayoutDivision> componentOfOfLayoutDivision { get; set; }
            public override string Code => nameof(WaterwayArea);

            public WaterwayArea()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DataCoverage : FeatureTypeBase
        {
            [Required()]
            public Int32 maximumDisplayScale { get; set; }

            [Required()]
            public Int32 minimumDisplayScale { get; set; }
            public override string Code => nameof(DataCoverage);

            public DataCoverage()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class QualityOfNonBathymetricData : FeatureTypeBase
        {
            public categoryOfTemporalVariation? categoryOfTemporalVariation { get; set; } = default;
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            [Required()]
            public horizontalPositionUncertainty horizontalPositionUncertainty { get; set; }
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
        public partial class SoundingDatum : FeatureTypeBase
        {
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
        public partial class TextPlacement : FeatureTypeBase
        {
            [Required()]
            public Decimal orientationValue { get; set; }
            public String text { get; set; } = string.Empty;

            [Required()]
            public Int32 textOffsetMm { get; set; }
            public textType? textType { get; set; } = default;
            public Int32? scaleMinimum { get; set; } = default;
            public featureBinding<Associations.FeatureAssociations.TextAssociation> positionsOfTextAssociation { get; set; }
            public override string Code => nameof(TextPlacement);

            public TextPlacement()
            {
            }
        }
    }
}