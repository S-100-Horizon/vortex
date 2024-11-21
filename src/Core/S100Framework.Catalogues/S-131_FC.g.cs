using System;
using System.Collections.Immutable;
using System.Linq;

namespace S100Framework.DomainModel.S131
{
    public static class Information
    {
        public static Version Version => new Version("1.0.0");
        public static string[] ComplexTypes => ["contactAddress", "featureName", "fixedDateRange", "frequencyPair", "horizontalPositionUncertainty", "information", "onlineResource", "orientation", "periodicDateRange", "rxNCode", "surveyDateRange", "textContent", "timeIntervalsByDayOfWeek", "usefulMarkDescription", "verticalUncertainty", "vesselsMeasurements", "weatherResource", "bearingInformation", "cargoServicesDescription", "constructionInformation", "depthsDescription", "facilitiesLayoutDescription", "generalPortDescription", "graphic", "landmarkDescription", "limitsDescription", "majorLightDescription", "markedBy", "offshoreMarkDescription", "scheduleByDayOfWeek", "spatialAccuracy", "telecommunications", "generalHarbourInformation", ];
        public static string[] InformationTypes => ["InformationType", "AbstractRxN", "Applicability", "Authority", "AvailablePortServices", "ContactDetails", "Entrance", "NauticalInformation", "NonStandardWorkingDay", "Recommendations", "Regulations", "Restrictions", "ServiceHours", "SpatialQuality", ];
        public static string[] FeatureTypes => ["FeatureType", "OrganizationContactArea", "SupervisedArea", "HarbourPhysicalInfrastructure", "Layout", "AnchorBerth", "AnchorageArea", "Berth", "BerthPosition", "DockArea", "DryDock", "DumpingGround", "FloatingDock", "Gridiron", "HarbourAreaAdministrative", "HarbourAreaSection", "HarbourBasin", "HarbourFacility", "MooringWarpingFacility", "OuterLimit", "PilotBoardingPlace", "SeaplaneLandingArea", "Terminal", "TurningBasin", "WaterwayArea", "DataCoverage", "QualityOfNonBathymetricData", "SoundingDatum", "VerticalDatumOfData", "TextPlacement", ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum berthingAssistance : int
    {
        [System.ComponentModel.Description("Information about assistance or arrangements for a service related to berthing operations.")]
        [System.Xml.Serialization.XmlEnum("1")]
        BerthingInformation = 1,
        [System.ComponentModel.Description("Personnel specializing in the mooring and unmooring of vessels.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LinePersonnel = 2,
        [System.ComponentModel.Description("A boat which assists the securement of a vessel to a berth or mooring with ropes or anchor.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MooringBoat = 3,
        [System.ComponentModel.Description("A locomotive for moving vessels.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Mule = 4,
        [System.ComponentModel.Description("A powerful small boat designed to pull or push larger ships or powerless barges.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Tugboat = 5,
        [System.ComponentModel.Description("A ship equipped to make and maintain a channel through ice.")]
        [System.Xml.Serialization.XmlEnum("6")]
        IcebreakingShip = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum cardinalDirection : int
    {
        [System.ComponentModel.Description("348.75-011.25 degrees (true north).")]
        [System.Xml.Serialization.XmlEnum("1")]
        North = 1,
        [System.ComponentModel.Description("011.25 - 033.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NorthNortheast = 2,
        [System.ComponentModel.Description("033.75 - 056.25 degrees.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Northeast = 3,
        [System.ComponentModel.Description("056.25-078.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("4")]
        EastNortheast = 4,
        [System.ComponentModel.Description("078.75-101.25 degrees.")]
        [System.Xml.Serialization.XmlEnum("5")]
        East = 5,
        [System.ComponentModel.Description("101.25-123.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("6")]
        EastSoutheast = 6,
        [System.ComponentModel.Description("123.75-146.25 degrees.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Southeast = 7,
        [System.ComponentModel.Description("146.25-168.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("8")]
        SouthSoutheast = 8,
        [System.ComponentModel.Description("168.75-191.25 degrees.")]
        [System.Xml.Serialization.XmlEnum("9")]
        South = 9,
        [System.ComponentModel.Description("191.25-213.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SouthSouthwest = 10,
        [System.ComponentModel.Description("213.75-236.25 degrees.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Southwest = 11,
        [System.ComponentModel.Description("236.25-258.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("12")]
        WestSouthwest = 12,
        [System.ComponentModel.Description("258.75-281.25 degrees.")]
        [System.Xml.Serialization.XmlEnum("13")]
        West = 13,
        [System.ComponentModel.Description("281.25-303.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("14")]
        WestNorthwest = 14,
        [System.ComponentModel.Description("303.75 - 326.25 degrees.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Northwest = 15,
        [System.ComponentModel.Description("326.25 - 348.75 degrees.")]
        [System.Xml.Serialization.XmlEnum("16")]
        NorthNorthwest = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum cargoService : int
    {
        [System.ComponentModel.Description("The loading, unloading, moving or handling of cargo, ship's stores, gear, or other materials, into, in, on, or out of any vessel.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Stevedoring = 1,
        [System.ComponentModel.Description("Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.")]
        [System.Xml.Serialization.XmlEnum("2")]
        CargoSurveying = 2,
        [System.ComponentModel.Description("The securement of cargo to the ship's structure and/or other cargo.")]
        [System.Xml.Serialization.XmlEnum("3")]
        CargoLashing = 3,
        [System.ComponentModel.Description("Determination of the quantity of certain types of bulk cargo by assessment of its effect on displacement when loaded in a vessel.")]
        [System.Xml.Serialization.XmlEnum("4")]
        DraughtSurvey = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfAuthority : int
    {
        [System.ComponentModel.Description("The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.")]
        [System.Xml.Serialization.XmlEnum("2")]
        BorderControl = 2,
        [System.ComponentModel.Description("The department of government, or civil force, charged with maintaining public order.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Police = 3,
        [System.ComponentModel.Description("Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Port = 4,
        [System.ComponentModel.Description("The authority controlling people entering a country.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Immigration = 5,
        [System.ComponentModel.Description("The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Health = 6,
        [System.ComponentModel.Description("Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.")]
        [System.Xml.Serialization.XmlEnum("7")]
        CoastGuard = 7,
        [System.ComponentModel.Description("The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Agricultural = 8,
        [System.ComponentModel.Description("A military authority which provides control of access to or approval for transit through designated areas or airspace.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Military = 9,
        [System.ComponentModel.Description("A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.")]
        [System.Xml.Serialization.XmlEnum("10")]
        PrivateCompany = 10,
        [System.ComponentModel.Description("A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.")]
        [System.Xml.Serialization.XmlEnum("11")]
        MaritimePolice = 11,
        [System.ComponentModel.Description("An authority with responsibility for the protection of the environment.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Environmental = 12,
        [System.ComponentModel.Description("An authority with responsibility for the control of fisheries.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Fishery = 13,
        [System.ComponentModel.Description("An authority with responsibility for the control and movement of money.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Finance = 14,
        [System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Maritime = 15,
        [System.ComponentModel.Description("The agency or establishment for collecting duties, tolls.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Customs = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfBerthLocation : int
    {
        [System.ComponentModel.Description("A wharf or quay with reference position(s) given by one or more metre marks.")]
        [System.Xml.Serialization.XmlEnum("1")]
        WharfReferenceMetreMark = 1,
        [System.ComponentModel.Description("A wharf or quay with reference position(s) given by one or more point or points in geographic coordinates.")]
        [System.Xml.Serialization.XmlEnum("2")]
        WharfReferencePosition = 2,
        [System.ComponentModel.Description("A long, narrow structure extending into the water to afford a berthing place for vessels, to serve as a promenade, etc.")]
        [System.Xml.Serialization.XmlEnum("3")]
        PierJetty = 3,
        [System.ComponentModel.Description("Mooring using the vessel's anchors and buoys to secure the vessel at multiple points.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ConventionalMooring = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCargo : int
    {
        [System.ComponentModel.Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Container = 2,
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

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCommunicationPreference : int
    {
        [System.ComponentModel.Description("The first choice channel or frequency to be used when calling a radio station.")]
        [System.Xml.Serialization.XmlEnum("1")]
        PreferredCalling = 1,
        [System.ComponentModel.Description("A channel or frequency to be used for calling a radio station when the preferred channel or frequency is busy or is suffering from interference.")]
        [System.Xml.Serialization.XmlEnum("2")]
        AlternateCalling = 2,
        [System.ComponentModel.Description("The first choice channel or frequency to be used when working with a radio station.")]
        [System.Xml.Serialization.XmlEnum("3")]
        PreferredWorking = 3,
        [System.ComponentModel.Description("A channel or frequency to be used for working with a radio station when the preferred working channel or frequency is busy or is suffering from interference.")]
        [System.Xml.Serialization.XmlEnum("4")]
        AlternateWorking = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfDangerousOrHazardousCargo : int
    {
        [System.ComponentModel.Description("Explosives, Division 1: Substances and articles which have a mass explosion hazard.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ImdgCodeClass1Div11 = 1,
        [System.ComponentModel.Description("Explosives, Division 2: Substances and articles which have a projection hazard but not a mass explosion hazard.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ImdgCodeClass1Div12 = 2,
        [System.ComponentModel.Description("Explosives, Division 3: Substances and articles which have a fire hazard and either a minor blast hazard or a minor projection hazard or both, but not a mass explosion hazard.")]
        [System.Xml.Serialization.XmlEnum("3")]
        ImdgCodeClass1Div13 = 3,
        [System.ComponentModel.Description("Explosives, Division 4: Substances and articles which present no significant hazard.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ImdgCodeClass1Div14 = 4,
        [System.ComponentModel.Description("Explosives, Division 5: Very insensitive substances which have a mass explosion hazard.")]
        [System.Xml.Serialization.XmlEnum("5")]
        ImdgCodeClass1Div15 = 5,
        [System.ComponentModel.Description("Explosives, Division 6: Extremely insensitive articles which do not have a mass explosion hazard.")]
        [System.Xml.Serialization.XmlEnum("6")]
        ImdgCodeClass1Div16 = 6,
        [System.ComponentModel.Description("Gases, flammable gases.")]
        [System.Xml.Serialization.XmlEnum("7")]
        ImdgCodeClass2Div21 = 7,
        [System.ComponentModel.Description("Gases, non-flammable, non-toxic gases.")]
        [System.Xml.Serialization.XmlEnum("8")]
        ImdgCodeClass2Div22 = 8,
        [System.ComponentModel.Description("Gases, toxic gases.")]
        [System.Xml.Serialization.XmlEnum("9")]
        ImdgCodeClass2Div23 = 9,
        [System.ComponentModel.Description("Flammable liquids.")]
        [System.Xml.Serialization.XmlEnum("10")]
        ImdgCodeClass3 = 10,
        [System.ComponentModel.Description("Flammable solids, self-reactive substances and desensitized explosives.")]
        [System.Xml.Serialization.XmlEnum("11")]
        ImdgCodeClass4Div41 = 11,
        [System.ComponentModel.Description("Substances liable to spontaneous combustion.")]
        [System.Xml.Serialization.XmlEnum("12")]
        ImdgCodeClass4Div42 = 12,
        [System.ComponentModel.Description("Substances which, in contact with water, emit flammable gases.")]
        [System.Xml.Serialization.XmlEnum("13")]
        ImdgCodeClass4Div43 = 13,
        [System.ComponentModel.Description("Oxidizing substances.")]
        [System.Xml.Serialization.XmlEnum("14")]
        ImdgCodeClass5Div51 = 14,
        [System.ComponentModel.Description("Organic peroxides.")]
        [System.Xml.Serialization.XmlEnum("15")]
        ImdgCodeClass5Div52 = 15,
        [System.ComponentModel.Description("Toxic substances.")]
        [System.Xml.Serialization.XmlEnum("16")]
        ImdgCodeClass6Div61 = 16,
        [System.ComponentModel.Description("Infectious substances.")]
        [System.Xml.Serialization.XmlEnum("17")]
        ImdgCodeClass6Div62 = 17,
        [System.ComponentModel.Description("Radioactive material.")]
        [System.Xml.Serialization.XmlEnum("18")]
        ImdgCodeClass7 = 18,
        [System.ComponentModel.Description("Corrosive substances.")]
        [System.Xml.Serialization.XmlEnum("19")]
        ImdgCodeClass8 = 19,
        [System.ComponentModel.Description("Miscellaneous dangerous substances and articles.")]
        [System.Xml.Serialization.XmlEnum("20")]
        ImdgCodeClass9 = 20,
        [System.ComponentModel.Description("Harmful substances are those substances which are identified as marine pollutants in the International Maritime Dangerous Goods Code (IMDG Code). Packaged form is defined as the forms of containment specified for harmful substances in the IMDG Code.")]
        [System.Xml.Serialization.XmlEnum("21")]
        HarmfulSubstancesInPackagedForm = 21,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfDepthsDescription : int
    {
        [System.ComponentModel.Description("A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Shoal = 1,
        [System.ComponentModel.Description("General information about the vertical distance from the water surface to the bottom.")]
        [System.Xml.Serialization.XmlEnum("2")]
        GeneralDepth = 2,
        [System.ComponentModel.Description("The least depth in the approach or channel to an area, such as a port or anchorage, governing the maximum draft of vessels that can enter.")]
        [System.Xml.Serialization.XmlEnum("3")]
        ControllingDepth = 3,
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
        [System.ComponentModel.Description("A place where mechanical services or repairs can be undertaken to engines or other vessel equipment.")]
        [System.Xml.Serialization.XmlEnum("16")]
        ServiceAndRepair = 16,
        [System.ComponentModel.Description("A medical control center located in an isolated spot ashore where patients with contagious diseases from vessel in quarantine are taken.")]
        [System.Xml.Serialization.XmlEnum("17")]
        QuarantineStation = 17,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfMooringWarpingFacility : int
    {
        [System.ComponentModel.Description("A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Dolphin = 1,
        [System.ComponentModel.Description("A post or group of posts, which a vessel may swing around for compass adjustment.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DeviationDolphin = 2,
        [System.ComponentModel.Description("Small shaped post, mounted on a wharf or dolphin used to secure ship's lines.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Bollard = 3,
        [System.ComponentModel.Description("A section of wall designated for tying-up vessels awaiting transit. Bollards and mooring devices are available for both large and small ships.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TieUpWall = 4,
        [System.ComponentModel.Description("A long heavy timber or section of steel, wood, concrete, etc., forced into the seabed to serve as a mooring facility.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PostOrPile = 5,
        [System.ComponentModel.Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
        [System.Xml.Serialization.XmlEnum("6")]
        MooringCable = 6,
        [System.ComponentModel.Description("A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.")]
        [System.Xml.Serialization.XmlEnum("7")]
        MooringBuoy = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfPortSection : int
    {
        [System.ComponentModel.Description("The main navigable channel in a harbour or its approaches, for vessels of larger size.")]
        [System.Xml.Serialization.XmlEnum("1")]
        PortFairway = 1,
        [System.ComponentModel.Description("A body of water at a berth or anchor berth, of adequate dimensions to allow a vessel to make fast to the shore, mooring buoys, berthing dolphins or to anchor.")]
        [System.Xml.Serialization.XmlEnum("3")]
        BerthPocket = 3,
        [System.ComponentModel.Description("An area in which sea-planes anchor or may anchor.")]
        [System.Xml.Serialization.XmlEnum("8")]
        SeaplaneAnchorage = 8,
        [System.ComponentModel.Description("An area of water or channel enlargement of increased depth compared to adjacent areas, where the depth is maintained by dredging operations.")]
        [System.Xml.Serialization.XmlEnum("9")]
        DredgedBasin = 9,
        [System.ComponentModel.Description("The area around a port facility or harbour installation within which vessels are prohibited from entering without permission.")]
        [System.Xml.Serialization.XmlEnum("11")]
        PortSafetyZone = 11,
        [System.ComponentModel.Description("A general berth for use by vessels for short term waiting until a loading or discharging berth is available.")]
        [System.Xml.Serialization.XmlEnum("12")]
        LayByBerth = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRelationship : int
    {
        [System.ComponentModel.Description("Use of facility, waterway or service is forbidden.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Prohibited = 1,
        [System.ComponentModel.Description("Use of facility, waterway or service is not recommended.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NotRecommended = 2,
        [System.ComponentModel.Description("Use of facility, waterway, or service is permitted but not required.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Permitted = 3,
        [System.ComponentModel.Description("Use of facility, waterway, or service is recommended.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Recommended = 4,
        [System.ComponentModel.Description("Use of facility, waterway, or service is required.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Required = 5,
        [System.ComponentModel.Description("Use of facility, waterway, or service is not required.")]
        [System.Xml.Serialization.XmlEnum("6")]
        NotRequired = 6,
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
    public enum categoryOfTemporalVariation : int
    {
        [System.ComponentModel.Description("Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ExtremeEvent = 1,
        [System.ComponentModel.Description("Continuous or frequent change (for example river siltation, sand waves, seasonal storms, ice bergs, etc) that is likely to result in new significant shoaling.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LikelyToChangeAndSignificantShoalingExpected = 2,
        [System.ComponentModel.Description("Continuous or frequent change (for example sand wave shift, seasonal storms, ice bergs, etc) that is not likely to result in new significant shoaling.")]
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
    public enum categoryOfText : int
    {
        [System.ComponentModel.Description("A statement summarizing the important points of a text.")]
        [System.Xml.Serialization.XmlEnum("1")]
        AbstractOrSummary = 1,
        [System.ComponentModel.Description("An excerpt or excerpts from a text.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Extract = 2,
        [System.ComponentModel.Description("The whole text.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FullText = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfVesselRegistry : int
    {
        [System.ComponentModel.Description("The vessel is registered or enrolled under the same national flag as the port, harbour, territorial sea, exclusive economic zone, or administrative area in which the object that possesses this attribute applies or is located.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Domestic = 1,
        [System.ComponentModel.Description("The vessel is registered or enrolled under a national flag different from the port, harbour, territorial sea, exclusive economic zone, or other administrative area in which the object that possesses this attribute applies or is located.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Foreign = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum comparisonOperator : int
    {
        [System.ComponentModel.Description("The value of the left value is greater than that of the right.")]
        [System.Xml.Serialization.XmlEnum("1")]
        GreaterThan = 1,
        [System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right.")]
        [System.Xml.Serialization.XmlEnum("2")]
        GreaterThanOrEqualTo = 2,
        [System.ComponentModel.Description("The value of the left expression is less than that of the right.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LessThan = 3,
        [System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LessThanOrEqualTo = 4,
        [System.ComponentModel.Description("The two values are equivalent.")]
        [System.Xml.Serialization.XmlEnum("5")]
        EqualTo = 5,
        [System.ComponentModel.Description("The two values are not equivalent.")]
        [System.Xml.Serialization.XmlEnum("6")]
        NotEqualTo = 6,
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
        [System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PlannedConstruction = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum dayOfWeek : int
    {
        [System.ComponentModel.Description("The first day of the week.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Sunday = 1,
        [System.ComponentModel.Description("The second day of the week.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Monday = 2,
        [System.ComponentModel.Description("The third day of the week.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Tuesday = 3,
        [System.ComponentModel.Description("The fourth day of the week.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Wednesday = 4,
        [System.ComponentModel.Description("The fifth day of the week.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Thursday = 5,
        [System.ComponentModel.Description("The sixth day of the week.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Friday = 6,
        [System.ComponentModel.Description("The seventh day of the week.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Saturday = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum dynamicResource : int
    {
        [System.ComponentModel.Description("The information is static, or a source of up-to-date information is unavailable or unknown.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Static = 1,
        [System.ComponentModel.Description("An external source of up-to-date information is available and interaction with it to obtain up-to-date information is required.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MandatoryExternalDynamic = 2,
        [System.ComponentModel.Description("An external source of up-to-date information is available but interaction with it to obtain up-to-date information is not required.")]
        [System.Xml.Serialization.XmlEnum("3")]
        OptionalExternalDynamic = 3,
        [System.ComponentModel.Description("Up-to-date information may be computed using only onboard resources.")]
        [System.Xml.Serialization.XmlEnum("4")]
        OnboardDynamic = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum firefightingService : int
    {
        [System.ComponentModel.Description("Personnel and equipment that are capable of combating a fire from ashore.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ShoreBasedFirefighting = 1,
        [System.ComponentModel.Description("Trained firefighting personnel with the capability of boarding and combating a fire on a vessel.")]
        [System.Xml.Serialization.XmlEnum("2")]
        OnboardFirefighting = 2,
        [System.ComponentModel.Description("Specialised watercraft with firefighting apparatus designed for fighting shoreline and shipboard fires")]
        [System.Xml.Serialization.XmlEnum("3")]
        FirefightingBoat = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum iSPSLevel : int
    {
        [System.ComponentModel.Description("The level for which minimum appropriate protective security measures shall be maintained at all times.")]
        [System.Xml.Serialization.XmlEnum("1")]
        IspsLevel1 = 1,
        [System.ComponentModel.Description("The level for which appropriate additional protective security measures shall be maintained for a period of time as a result of heightened risk of a security incident.")]
        [System.Xml.Serialization.XmlEnum("2")]
        IspsLevel2 = 2,
        [System.ComponentModel.Description("The level for which further specific protective security measures shall be maintained for a limited period of time when a security incident is probable or imminent, although it may not be possible to identify the specific target.")]
        [System.Xml.Serialization.XmlEnum("3")]
        IspsLevel3 = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum logicalConnectives : int
    {
        [System.ComponentModel.Description("All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.")]
        [System.Xml.Serialization.XmlEnum("1")]
        LogicalConjunction = 1,
        [System.ComponentModel.Description("At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LogicalDisjunction = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum medicalService : int
    {
        [System.ComponentModel.Description("A vehicle for conveying the sick or injured to or from a hospital.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Ambulance = 1,
        [System.ComponentModel.Description("Disinfection or purification with fumes.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Fumigation = 2,
        [System.ComponentModel.Description("A place where a doctor is available to provide medical attention.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Doctor = 3,
        [System.ComponentModel.Description("The isolation of patients with contagious diseases.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Quarantine = 4,
        [System.ComponentModel.Description("A place where substances intended to procure immunity against one or several diseases are administered.")]
        [System.Xml.Serialization.XmlEnum("5")]
        VaccinationCentre = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum membership : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Included = 1,
        [System.ComponentModel.Description("Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Excluded = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum methodOfSecuring : int
    {
        [System.ComponentModel.Description("Vessel is secured perpendicular to the wharf with bow to seaward.")]
        [System.Xml.Serialization.XmlEnum("1")]
        BowToSeaward = 1,
        [System.ComponentModel.Description("Vessel is secured perpendicular to the wharf with stern to the seaward.")]
        [System.Xml.Serialization.XmlEnum("2")]
        SternToSeaward = 2,
        [System.ComponentModel.Description("The vessel is secured perpendicular to the wharf.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MediterraneanMooring = 3,
        [System.ComponentModel.Description("Mooring method/procedure used during onshore wind conditions without a tug.")]
        [System.Xml.Serialization.XmlEnum("4")]
        BalticMooring = 4,
        [System.ComponentModel.Description("Mooring by maneuvering ahead and astern while dropping anchors to secure the vessel with reduced swinging room.")]
        [System.Xml.Serialization.XmlEnum("5")]
        RunningMooring = 5,
        [System.ComponentModel.Description("Mooring by using mainly wind and tide to position the vessel while dropping anchors to secure the vessel with reduced swinging room. Makes limited use of the engine to position the vessel.")]
        [System.Xml.Serialization.XmlEnum("6")]
        StandingMooring = 6,
        [System.ComponentModel.Description("A mooring structure used by tankers to load and unload in port approaches or in offshore oil and gas fields. The size of the structure can vary between a large mooring buoy and a manned floating structure.")]
        [System.Xml.Serialization.XmlEnum("7")]
        SinglePointMooring = 7,
        [System.ComponentModel.Description("Mooring using the vessel's anchors and buoys to secure the vessel at multiple points.")]
        [System.Xml.Serialization.XmlEnum("8")]
        ConventionalMooring = 8,
        [System.ComponentModel.Description("Mooring alongside another vessel.")]
        [System.Xml.Serialization.XmlEnum("9")]
        ShipToShipMooring = 9,
        [System.ComponentModel.Description("Mooring system supported by a spider buoy.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SpiderBuoyMooring = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum onlineFunction : int
    {
        [System.ComponentModel.Description("Online instructions for transferring data from one storage device or system to another.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Download = 1,
        [System.ComponentModel.Description("Online instructions for requesting the resource from the provider.")]
        [System.Xml.Serialization.XmlEnum("3")]
        OfflineAccess = 3,
        [System.ComponentModel.Description("Online order process for obtaining the resource.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Order = 4,
        [System.ComponentModel.Description("To make painstaking investigation or examination.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Search = 5,
        [System.ComponentModel.Description("Complete metadata provided.")]
        [System.Xml.Serialization.XmlEnum("6")]
        CompleteMetadata = 6,
        [System.ComponentModel.Description("Browse graphic provided.")]
        [System.Xml.Serialization.XmlEnum("7")]
        BrowseGraphic = 7,
        [System.ComponentModel.Description("Online resource upload capability provided.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Upload = 8,
        [System.ComponentModel.Description("Online email service provided.")]
        [System.Xml.Serialization.XmlEnum("9")]
        EmailService = 9,
        [System.ComponentModel.Description("Online browsing provided.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Browsing = 10,
        [System.ComponentModel.Description("Online file access provided.")]
        [System.Xml.Serialization.XmlEnum("11")]
        FileAccess = 11,
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum qualityOfHorizontalMeasurement : int
    {
        [System.ComponentModel.Description("The position(s) was(were) determined by the operation of making measurements for determining the relative position of points on, above or beneath the earth's surface. Survey implies a regular, controlled survey of any date.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Surveyed = 1,
        [System.ComponentModel.Description("Survey data is does not exist or is very poor.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Unsurveyed = 2,
        [System.ComponentModel.Description("Not surveyed to modern standards; or due to its age, scale, or positional or vertical uncertainties is not suitable to the type of navigation expected in the area.")]
        [System.Xml.Serialization.XmlEnum("3")]
        InadequatelySurveyed = 3,
        [System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to an object whose position does not remain fixed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Approximate = 4,
        [System.ComponentModel.Description("Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PositionDoubtful = 5,
        [System.ComponentModel.Description("A feature's position has been obtained from questionable or unreliable data.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Unreliable = 6,
        [System.ComponentModel.Description("An object whose position has been reported and its position confirmed by some means other than a formal survey such as an independent report of the same object.")]
        [System.Xml.Serialization.XmlEnum("7")]
        ReportedNotSurveyed = 7,
        [System.ComponentModel.Description("An object whose position has been reported and its position has not been confirmed.")]
        [System.Xml.Serialization.XmlEnum("8")]
        ReportedNotConfirmed = 8,
        [System.ComponentModel.Description("The most probable position of an object determined from incomplete data or data of questionable accuracy.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Estimated = 9,
        [System.ComponentModel.Description("A position that is of a known value, such as the position of an anchor berth or other defined object.")]
        [System.Xml.Serialization.XmlEnum("10")]
        PreciselyKnown = 10,
        [System.ComponentModel.Description("A position that is computed from data.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Calculated = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum repairService : int
    {
        [System.ComponentModel.Description("The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.")]
        [System.Xml.Serialization.XmlEnum("1")]
        CompensationOfMagneticCompass = 1,
        [System.ComponentModel.Description("Underwater inspection and repair performed by divers.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DiverService = 2,
        [System.ComponentModel.Description("Repairs to eqipment installed on the ship's bridge.")]
        [System.Xml.Serialization.XmlEnum("3")]
        BridgeEquipmentRepair = 3,
        [System.ComponentModel.Description("Repair of an engine or machine parts.")]
        [System.Xml.Serialization.XmlEnum("4")]
        EngineRepair = 4,
        [System.ComponentModel.Description("Repair of marine electronic instruments.")]
        [System.Xml.Serialization.XmlEnum("5")]
        ElectronicEquipmentRepair = 5,
        [System.ComponentModel.Description("Repairs to the ship's body, frame, or superstructure.")]
        [System.Xml.Serialization.XmlEnum("6")]
        HullRepair = 6,
        [System.ComponentModel.Description("Repairs to equipment used in the act of navigating a ship.")]
        [System.Xml.Serialization.XmlEnum("7")]
        NavigationalEquipmentRepair = 7,
        [System.ComponentModel.Description("Repairs to propeller hub and blades.")]
        [System.Xml.Serialization.XmlEnum("8")]
        PropellerRepair = 8,
        [System.ComponentModel.Description("Repairs to equipment used in salvage operations.")]
        [System.Xml.Serialization.XmlEnum("9")]
        SalvageGearRepair = 9,
        [System.ComponentModel.Description("Repairs to drive shafts used for transmitting mechanical power and torque to a propeller.")]
        [System.Xml.Serialization.XmlEnum("10")]
        ShaftRepair = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum shipSanitationControl : int
    {
        [System.ComponentModel.Description("Capable of applying measures to ensure that a vessel is free of disease and disease risks, but cannot issue a certificate.")]
        [System.Xml.Serialization.XmlEnum("1")]
        SanitationMeasuresOnly = 1,
        [System.ComponentModel.Description("The competent authority can issue a Ship Sanitation Control Certificate after satisfactorily completing or supervising the completion of ship sanitation control measures.")]
        [System.Xml.Serialization.XmlEnum("2")]
        IssueSscc = 2,
        [System.ComponentModel.Description("The competent authority may issue a Ship Sanitation Control Exemption Certificate if it is satisfied that the ship is free of infection and contamination, including vectors and reservoirs.")]
        [System.Xml.Serialization.XmlEnum("3")]
        IssueSscec = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum sourceType : int
    {
        [System.ComponentModel.Description("Treaty, convention, or international agreement; law or regulation issued by a national or other authority.")]
        [System.Xml.Serialization.XmlEnum("1")]
        LawOrRegulation = 1,
        [System.ComponentModel.Description("Publication not having the force of law, issued by an international organisation or a national or local administration.")]
        [System.Xml.Serialization.XmlEnum("2")]
        OfficialPublication = 2,
        [System.ComponentModel.Description("Reported by mariner(s) and confirmed by another source.")]
        [System.Xml.Serialization.XmlEnum("7")]
        MarinerReportConfirmed = 7,
        [System.ComponentModel.Description("Reported by mariner(s) but not confirmed.")]
        [System.Xml.Serialization.XmlEnum("8")]
        MarinerReportNotConfirmed = 8,
        [System.ComponentModel.Description("Shipping and other industry publications, including graphics, charts and web sites.")]
        [System.Xml.Serialization.XmlEnum("9")]
        IndustryPublicationsAndReports = 9,
        [System.ComponentModel.Description("Information obtained from satellite images.")]
        [System.Xml.Serialization.XmlEnum("10")]
        RemotelySensedImages = 10,
        [System.ComponentModel.Description("Information obtained from photographs.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Photographs = 11,
        [System.ComponentModel.Description("Information obtained from products issued by Hydrographic Offices.")]
        [System.Xml.Serialization.XmlEnum("12")]
        ProductsIssuedByHoServices = 12,
        [System.ComponentModel.Description("Information obtained from news media.")]
        [System.Xml.Serialization.XmlEnum("13")]
        NewsMedia = 13,
        [System.ComponentModel.Description("Information obtained from the analysis of traffic data.")]
        [System.Xml.Serialization.XmlEnum("14")]
        TrafficData = 14,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum supplyService : int
    {
        [System.ComponentModel.Description("The provision of shoreside electrical power to a ship at berth while its main and auxiliary engines are shut down.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ShorePower = 1,
        [System.ComponentModel.Description("Transfer of fuel oil to the fuel compartments of a ship.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FuelOilBunkering = 2,
        [System.ComponentModel.Description("Transfer of liquefied natural gas to the fuel compartments of a ship.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LngBunkering = 3,
        [System.ComponentModel.Description("Substances capable of reducing friction, heat, and wear when introduced as a film between solid surfaces.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Lubricants = 4,
        [System.ComponentModel.Description("The gas into which water is changed by boiling.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Steam = 5,
        [System.ComponentModel.Description("Water which can be used for drinking and food preparation.")]
        [System.Xml.Serialization.XmlEnum("6")]
        PotableWater = 6,
        [System.ComponentModel.Description("A universal hose connection for the supply of water for fighting fires.")]
        [System.Xml.Serialization.XmlEnum("7")]
        InternationalShoreConnection = 7,
        [System.ComponentModel.Description("A place where food and other such supplies are available.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Provisions = 8,
        [System.ComponentModel.Description("A dealer in ships' supplies.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Chandler = 9,
        [System.ComponentModel.Description("A place where mechanical repairs can be undertaken to engines or other vessel equipment.")]
        [System.Xml.Serialization.XmlEnum("10")]
        MechanicsWorkshop = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum technicalPortService : int
    {
        [System.ComponentModel.Description("The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.")]
        [System.Xml.Serialization.XmlEnum("1")]
        CompensationOfMagneticCompass = 1,
        [System.ComponentModel.Description("Neutralization of the strength of the magnetic field of a vessel, by means of suitably arranged electric coils permanently installed in the vessel. See also Degaussing Cable.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Degaussing = 2,
        [System.ComponentModel.Description("Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.")]
        [System.Xml.Serialization.XmlEnum("3")]
        CargoSurveying = 3,
        [System.ComponentModel.Description("Assessment of quality and compliance with applicable law, regulations, and safety standards.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Vetting = 4,
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum verticalDatum : int
    {
        [System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas. Also called spring low water.")]
        [System.Xml.Serialization.XmlEnum("1")]
        MeanLowWaterSprings = 1,
        [System.ComponentModel.Description("The average height of lower low water springs at a place.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MeanLowerLowWaterSprings = 2,
        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MeanSeaLevel = 3,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or some what lower.")]
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
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation. Also called low tide.")]
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
        [System.ComponentModel.Description("The average height of the high waters of spring tides. Also called spring high water.")]
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
    public enum vesselsCharacteristics : int
    {
        [System.ComponentModel.Description("The maximum length of the ship.")]
        [System.Xml.Serialization.XmlEnum("1")]
        LengthOverall = 1,
        [System.ComponentModel.Description("The ship's length measured at the waterline.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LengthAtWaterline = 2,
        [System.ComponentModel.Description("The width or beam of the vessel.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Breadth = 3,
        [System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Draught = 4,
        [System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement.")]
        [System.Xml.Serialization.XmlEnum("6")]
        DisplacementTonnage = 6,
        [System.ComponentModel.Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level.")]
        [System.Xml.Serialization.XmlEnum("7")]
        DisplacementTonnageLight = 7,
        [System.ComponentModel.Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft.")]
        [System.Xml.Serialization.XmlEnum("8")]
        DisplacementTonnageLoaded = 8,
        [System.ComponentModel.Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity.")]
        [System.Xml.Serialization.XmlEnum("9")]
        DeadweightTonnage = 9,
        [System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.")]
        [System.Xml.Serialization.XmlEnum("10")]
        GrossTonnage = 10,
        [System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.")]
        [System.Xml.Serialization.XmlEnum("11")]
        NetTonnage = 11,
        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
        [System.Xml.Serialization.XmlEnum("12")]
        PanamaCanalUniversalMeasurementSystemNetTonnage = 12,
        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [System.Xml.Serialization.XmlEnum("13")]
        SuezCanalNetTonnage = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum vesselsCharacteristicsUnit : int
    {
        [System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Metres = 1,
        [System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MetricTon = 3,
        [System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
        [System.Xml.Serialization.XmlEnum("4")]
        Ton = 4,
        [System.ComponentModel.Description("A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
        [System.Xml.Serialization.XmlEnum("5")]
        ShortTon = 5,
        [System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
        [System.Xml.Serialization.XmlEnum("6")]
        GrossTon = 6,
        [System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
        [System.Xml.Serialization.XmlEnum("7")]
        NetTon = 7,
        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [System.Xml.Serialization.XmlEnum("9")]
        SuezCanalNetTonnage = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum wasteDisposalService : int
    {
        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Oily bilge water\" as specified in MARPOL Annex I.")]
        [System.Xml.Serialization.XmlEnum("1")]
        MarpolAnnexIOilyBilgeWater = 1,
        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Oily Residues (sludge)\" as specified in MARPOL Annex I.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MarpolAnnexIOilyResidues = 2,
        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Oily tank washings (slops)\" as specified in MARPOL Annex I.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MarpolAnnexIOilyTankWashings = 3,
        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Dirty ballast water\" as specified in MARPOL Annex I.")]
        [System.Xml.Serialization.XmlEnum("4")]
        MarpolAnnexIDirtyBallastWater = 4,
        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Scale and sludge from tank cleaning\" as specified in MARPOL Annex I.")]
        [System.Xml.Serialization.XmlEnum("5")]
        MarpolAnnexIScaleAndSludgeFromTankCleaning = 5,
        [System.ComponentModel.Description("The service with facility to receive oil related waste/residue of the type \"Other\" as specified in MARPOL Annex I.")]
        [System.Xml.Serialization.XmlEnum("6")]
        MarpolAnnexIOtherOilyWaste = 6,
        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category X\" as specified in MARPOL Annex II.")]
        [System.Xml.Serialization.XmlEnum("7")]
        MarpolAnnexIiCategoryX = 7,
        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Y\" as specified in MARPOL Annex II.")]
        [System.Xml.Serialization.XmlEnum("8")]
        MarpolAnnexIiCategoryY = 8,
        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Z\" as specified in MARPOL Annex II.")]
        [System.Xml.Serialization.XmlEnum("9")]
        MarpolAnnexIiCategoryZ = 9,
        [System.ComponentModel.Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Other substance\" as specified in MARPOL Annex II.")]
        [System.Xml.Serialization.XmlEnum("10")]
        MarpolAnnexIiCategoryOs = 10,
        [System.ComponentModel.Description("The service with facility to receive waste/residue of the type \"Sewage\" as specified in MARPOL Annex IV.")]
        [System.Xml.Serialization.XmlEnum("11")]
        MarpolAnnexIvSewage = 11,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Plastics\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("12")]
        MarpolAnnexVPlastics = 12,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Food wastes\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("13")]
        MarpolAnnexVFoodWastes = 13,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Domestic wastes\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("14")]
        MarpolAnnexVDomesticWastes = 14,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Cooking oil\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("15")]
        MarpolAnnexVCookingOil = 15,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Incinerator ashes\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("16")]
        MarpolAnnexVIncineratorAshes = 16,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Operational wastes\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("17")]
        MarpolAnnexVOperationalWastes = 17,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Animal carcasses\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("18")]
        MarpolAnnexVAnimalCarcasses = 18,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Fishing gear\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("19")]
        MarpolAnnexVFishingGear = 19,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"E-waste\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("20")]
        MarpolAnnexVEWaste = 20,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Cargo residues not determined to be harmful to the marine environment\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("21")]
        MarpolAnnexVCargoResiduesNonHme = 21,
        [System.ComponentModel.Description("The service with facility to receive garbage related waste/residue of the type \"Cargo residues harmful to the marine environment\", as specified in MARPOL Annex V")]
        [System.Xml.Serialization.XmlEnum("22")]
        MarpolAnnexVCargoResiduesHme = 22,
        [System.ComponentModel.Description("The service with facility to receive air pollution related waste/residue of the type \"Ozone-depleting substances\" as specified in MARPOL Annex VI.")]
        [System.Xml.Serialization.XmlEnum("23")]
        MarpolAnnexViOzoneDepletingSubstances = 23,
        [System.ComponentModel.Description("The service with facility to receive air pollution related waste/residue of the type \"Exhaust gas-cleaning residues\" as specified in MARPOL Annex VI.")]
        [System.Xml.Serialization.XmlEnum("24")]
        MarpolAnnexViExhaustGasCleaningResidues = 24,
    }

    [System.SerializableAttribute()]
    public class actionOrActivity
    {
        [System.Xml.Serialization.XmlTextAttribute()]
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.SerializableAttribute()]
    public class categoryOfRxN
    {
        [System.Xml.Serialization.XmlTextAttribute()]
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.SerializableAttribute()]
    public class categoryOfVessel
    {
        [System.Xml.Serialization.XmlTextAttribute()]
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.SerializableAttribute()]
    public class securitySafetyEmergencyService
    {
        [System.Xml.Serialization.XmlTextAttribute()]
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.SerializableAttribute()]
    public class transportConnection
    {
        [System.Xml.Serialization.XmlTextAttribute()]
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    public static class CodeList
    {
        public static ImmutableArray<actionOrActivity> actionOrActivities => ImmutableArray.Create<actionOrActivity>(new actionOrActivity[] { new() { code = 1, definition = "Carrying a qualified pilot as part of the vessel navigation team.", label = "Navigating With a Pilot", }, new() { code = 2, definition = "Navigating a vessel into a port.", label = "Entering Port", }, new() { code = 3, definition = "Navigating a vessel out of a port.", label = "Leaving Port", }, new() { code = 4, definition = "Attaching a vessel to a wharf or jetty.", label = "Berthing", }, new() { code = 5, definition = "Detaching a vessel from a wharf or jetty.", label = "Slipping", }, new() { code = 6, definition = "Attaching a vessel to the seabed by means of an anchor and cable.", label = "Anchoring", }, new() { code = 7, definition = "Detaching a vessel from the seabed by recovering an anchor and cable.", label = "Weighing Anchor", }, new() { code = 8, definition = "Navigating a vessel along a route or through a narrow gap, such as under a bridge or through a lock.", label = "Transiting", }, new() { code = 9, definition = "Navigating a vessel past another traveling broadly in the same direction.", label = "Overtaking", }, new() { code = 10, definition = "Providing details such as the name, location or intentions of a vessel.", label = "Reporting", }, new() { code = 11, definition = "Loading or unloading cargo.", label = "Working Cargo", }, new() { code = 12, definition = "Placing crew or passengers on shore.", label = "Landing", }, new() { code = 13, definition = "A signal or message warning of diving activity.", label = "Diving", }, new() { code = 14, definition = "Hunting or catching fish.", label = "Fishing", }, new() { code = 15, definition = "Releasing anything into the sea; often ballast water; or spoil from dredging elsewhere.", label = "Discharging Overboard", }, new() { code = 16, definition = "Navigating a vessel past another travelling broadly in the opposite direction.", label = "Passing", }, });
        public static ImmutableArray<categoryOfRxN> categoryOfRxNS => ImmutableArray.Create<categoryOfRxN>(new categoryOfRxN[] { new() { code = 1, definition = "The process of directing the movement of a craft from one point to another.", label = "Navigation", }, new() { code = 2, definition = "Transmitting and/or receiving electronic communication signals.", label = "Communication", }, new() { code = 3, definition = "Pertaining to environmental protection.", label = "Environmental Protection", }, new() { code = 4, definition = "Pertaining to wildlife protection.", label = "Wildlife Protection", }, new() { code = 5, definition = "Pertaining to security.", label = "Security", }, new() { code = 6, definition = "The agency or establishment for collecting duties, tolls.", label = "Customs", }, new() { code = 7, definition = "Pertaining to cargo operations.", label = "Cargo Operation", }, new() { code = 8, definition = "Pertaining to a place of safety or refuge.", label = "Refuge", }, new() { code = 9, definition = "The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.", label = "Health", }, new() { code = 10, definition = "Pertaining to natural resources or exploitation.", label = "Natural Resources or Exploitation", }, new() { code = 11, definition = "Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.", label = "Port", }, new() { code = 12, definition = "An authority with responsibility for the control and movement of money.", label = "Finance", }, new() { code = 13, definition = "The science, art, or practice of cultivating the soil, producing crops, and raising livestock and in varying degrees the preparation and marketing of the resulting products.", label = "Agriculture", }, });
        public static ImmutableArray<categoryOfVessel> categoryOfVessels => ImmutableArray.Create<categoryOfVessel>(new categoryOfVessel[] { new() { code = 1, definition = "A vessel which is designed for carrying general cargo, e.g. boxes, sacks.", label = "General Cargo Vessel", }, new() { code = 2, definition = "A vessel designed to carry ISO containers.", label = "Container Carrier", }, new() { code = 3, definition = "A vessel which is designed for carrying liquid goods, for example oil or water.", label = "Tanker", }, new() { code = 4, definition = "A vessel which is designed for carrying bulk goods, e.g. coal, ore or grain.", label = "Bulk Carrier", }, new() { code = 5, definition = "A day trip or cabin vessel constructed and equipped to carry more than 12 passengers.", label = "Passenger Vessel", }, new() { code = 6, definition = "A vessel designed to allow road vehicles to be driven on and off; often a ferry.", label = "Roll-On Roll-Off", }, new() { code = 7, definition = "A vessel designed to carry refrigerated cargo.", label = "Refrigerated Cargo Vessel", }, new() { code = 8, definition = "A vessel that is used and equipped for the fishing of living aquatic resources.", label = "Fishing Vessel", }, new() { code = 9, definition = "A vessel which provides a service such as a tug, anchor handler, survey or supply vessel.", label = "Service", }, new() { code = 10, definition = "A vessel designed for the conduct of military operations.", label = "Warship", }, new() { code = 11, definition = "Either a tug and tow, or any combination of a tug providing propulsion to barges or vessels secured ahead or alongside.", label = "Towed or Pushed Composite Unit", }, new() { code = 12, definition = "A combination of tug(s) and non-powered tow(s).", label = "Tug and Tow", }, new() { code = 13, definition = "A pleasure boat or watercraft, or an excursion vessel used for short cruises such as whale watching.", label = "Light Recreational", }, new() { code = 14, definition = "An installation which is designed to float at all times and which is normally anchored in position when deployed in the offshore gas and oil industry.", label = "Semi-Submersible Offshore Installation", }, new() { code = 15, definition = "An exploration or project installation with legs which can be raised and lowered. The legs are raised when the installation is re-positioned. When stationary the legs are lowered to the sea floor and the working platform is raised clear of the sea surface.", label = "Jack-Up Exploration or Project Installation", }, new() { code = 16, definition = "A vessel designed to carry large quantities of live animals.", label = "Livestock Carrier", }, new() { code = 17, definition = "A vessel used in fishing for pleasure or competition.", label = "Sport Fishing", }, });
        public static ImmutableArray<securitySafetyEmergencyService> securitySafetyEmergencyServices => ImmutableArray.Create<securitySafetyEmergencyService>(new securitySafetyEmergencyService[] { new() { code = 1, definition = "Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.", label = "Coast Guard", }, new() { code = 2, definition = "The agency or establishment for collecting duties, tolls.", label = "Customs", }, new() { code = 3, definition = "Office for reporting or obtaining information about sudden dangers to the environment such as spillage of polluting or hazardous substances.", label = "Environmental Emergency Information Centre", }, new() { code = 4, definition = "An office or organisation for reporting or coordinating response to emergencies.", label = "Emergency Coordination Centre", }, new() { code = 5, definition = "A place where a vessel is patrolled by a security service or stored in a secure lockup.", label = "Guard and/or Security Service", }, new() { code = 6, definition = "The authority controlling people entering a country.", label = "Immigration", }, new() { code = 7, definition = "The department of government, or civil force, charged with maintaining public order.", label = "Police", }, new() { code = 8, definition = "A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.", label = "Sea Rescue Control", }, });
        public static ImmutableArray<transportConnection> transportConnections => ImmutableArray.Create<transportConnection>(new transportConnection[] { new() { code = 2, definition = "A small airport for the use of helicopters and some other vertical lift aircraft. Heliports typically contain one or more touchdown and liftoff areas and also have facilities such as fuel or hangars. In some larger towns and cities, customs facilities may also be available.", label = "Heliport", }, new() { code = 3, definition = "A small landing surface for helicopters, with minimal or no supporting installations or facilities.", label = "Helipad", }, new() { code = 4, definition = "Small boat with crew that may be hired for single journeys.", label = "Hired Boat", }, new() { code = 5, definition = "A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.", label = "Bus Station", }, new() { code = 6, definition = "A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.", label = "Ferry", }, new() { code = 8, definition = "A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.", label = "Motorway", }, new() { code = 9, definition = "Large open or half decked boat.", label = "Launch", }, new() { code = 11, definition = "The carriage of goods or passengers using navigable waterways such as canals, rivers, lakes, or other stretch of water that is not part of the sea.", label = "Inland Waterway Transport", }, new() { code = 12, definition = "The carriage of specified types of cargo between qualifying ports. The types of cargo and/or qualifying ports are generally specified by law or government regulation.", label = "Short Sea Transportation", }, new() { code = 13, definition = "Specially designated commercially navigable routes in coastal, inland, and intracoastal waters, frequently as waterborne relievers to congested landside routes.", label = "Marine Highway", }, });
    }

    namespace ComplexAttributes
    {
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class contactAddress
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> deliveryPoint { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String cityName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String administrativeDivision { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String countryName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String postalCode { get; set; } = string.Empty;

            public contactAddress()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class featureName
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Boolean? displayName { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String name { get; set; } = string.Empty;

            public featureName()
            {
                name = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class fixedDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public DateOnly? dateStart { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public DateOnly? dateEnd { get; set; } = default;

            public fixedDateRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class frequencyPair
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<Int32> frequencyShoreStationTransmits { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<Int32> frequencyShoreStationReceives { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> contactInstructions { get; set; } = [];

            public frequencyPair()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class horizontalPositionUncertainty
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Decimal uncertaintyFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            public horizontalPositionUncertainty()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class information
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String fileLocator { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String fileReference { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> headline { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String text { get; set; } = string.Empty;

            public information()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class onlineResource
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String onlineResourceLinkageURL { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String protocol { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String applicationProfile { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String nameOfResource { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String onlineResourceDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public onlineFunction? onlineFunction { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String protocolRequest { get; set; } = string.Empty;

            public onlineResource()
            {
                onlineResourceLinkageURL = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class orientation
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? orientationUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Decimal orientationValue { get; set; }

            public orientation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class periodicDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required DateOnly dateStart { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required DateOnly dateEnd { get; set; }

            public periodicDateRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class rxNCode
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfRxN? categoryOfRxN { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public actionOrActivity? actionOrActivity { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> headline { get; set; } = [];

            public rxNCode()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class surveyDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public DateOnly? dateStart { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required DateOnly dateEnd { get; set; }

            public surveyDateRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class textContent
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfText? categoryOfText { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public onlineResource? onlineResource { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public sourceType? sourceType { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public DateOnly? reportedDate { get; set; } = default;

            public textContent()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class timeIntervalsByDayOfWeek
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<dayOfWeek> dayOfWeek { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Boolean? dayOfWeekIsRange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<TimeOnly> timeOfDayStart { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<TimeOnly> timeOfDayEnd { get; set; } = [];

            public timeIntervalsByDayOfWeek()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class usefulMarkDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public usefulMarkDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class verticalUncertainty
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Decimal uncertaintyFixed { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? uncertaintyVariableFactor { get; set; } = default;

            public verticalUncertainty()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class vesselsMeasurements
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required comparisonOperator comparisonOperator { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required vesselsCharacteristics vesselsCharacteristics { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Decimal vesselsCharacteristicsValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; }

            public vesselsMeasurements()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class weatherResource
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public onlineResource? onlineResource { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public dynamicResource? dynamicResource { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public textContent? textContent { get; set; }

            public weatherResource()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class bearingInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public cardinalDirection? cardinalDirection { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? distance { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<Decimal> sectorBearing { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public orientation? orientation { get; set; }

            public bearingInformation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class cargoServicesDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public cargoServicesDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class constructionInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public condition? condition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String development { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<textContent> textContent { get; set; } = [];

            public constructionInformation()
            {
                development = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class depthsDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required categoryOfDepthsDescription categoryOfDepthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public depthsDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class facilitiesLayoutDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public facilitiesLayoutDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class generalPortDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public generalPortDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class graphic
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<String> pictorialRepresentation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String pictureCaption { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public DateTime? sourceDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String pictureInformation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public bearingInformation? bearingInformation { get; set; }

            public graphic()
            {
                pictorialRepresentation = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class landmarkDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public landmarkDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class limitsDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public limitsDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class majorLightDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public majorLightDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class markedBy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public markedBy()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class offshoreMarkDescription
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<textContent> textContent { get; set; }

            public offshoreMarkDescription()
            {
                textContent = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class scheduleByDayOfWeek
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfSchedule? categoryOfSchedule { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; }

            public scheduleByDayOfWeek()
            {
                timeIntervalsByDayOfWeek = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class spatialAccuracy
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public horizontalPositionUncertainty? horizontalPositionUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            public spatialAccuracy()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class telecommunications
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String telecommunicationIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String telecommunicationCarrier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<telecommunicationService> telecommunicationService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public scheduleByDayOfWeek? scheduleByDayOfWeek { get; set; }

            public telecommunications()
            {
                telecommunicationIdentifier = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class generalHarbourInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public generalPortDescription? generalPortDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public facilitiesLayoutDescription? facilitiesLayoutDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public limitsDescription? limitsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public constructionInformation? constructionInformation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public cargoServicesDescription? cargoServicesDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<weatherResource> weatherResource { get; set; } = [];

            public generalHarbourInformation()
            {
            }
        }
    }

    public enum Role
    {
        [System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
        [System.Xml.Serialization.XmlEnum("positions")]
        positions,
        [System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
        [System.Xml.Serialization.XmlEnum("componentOf")]
        componentOf,
        [System.ComponentModel.Description("A pointer to a specific feature(s) for which further information is required.")]
        [System.Xml.Serialization.XmlEnum("informationProvidedFor")]
        informationProvidedFor,
        [System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
        [System.Xml.Serialization.XmlEnum("providesInformation")]
        providesInformation,
        [System.ComponentModel.Description("The applicable regulation, restriction, recommendation or nautical information")]
        [System.Xml.Serialization.XmlEnum("theApplicableRxN")]
        theApplicableRxN,
        [System.ComponentModel.Description("The location in which the information item applies")]
        [System.Xml.Serialization.XmlEnum("appliesInLocation")]
        appliesInLocation,
        [System.ComponentModel.Description("A pointer to an Authority object")]
        [System.Xml.Serialization.XmlEnum("theAuthority")]
        theAuthority,
        [System.ComponentModel.Description("The authority for which service hours are given")]
        [System.Xml.Serialization.XmlEnum("theAuthority_srvHrs")]
        theAuthority_srvHrs,
        [System.ComponentModel.Description("A pointer to an Contact Details object")]
        [System.Xml.Serialization.XmlEnum("theContactDetails")]
        theContactDetails,
        [System.ComponentModel.Description("The controlling organization or authority for a geographically located service")]
        [System.Xml.Serialization.XmlEnum("controlAuthority")]
        controlAuthority,
        [System.ComponentModel.Description("The service controlled by an organisation or authority")]
        [System.Xml.Serialization.XmlEnum("controlledService")]
        controlledService,
        [System.ComponentModel.Description("A pointer to a specific feature(s).")]
        [System.Xml.Serialization.XmlEnum("identifies")]
        identifies,
        [System.ComponentModel.Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
        [System.Xml.Serialization.XmlEnum("isApplicableTo")]
        isApplicableTo,
        [System.ComponentModel.Description("Service hours for an authority or service provider")]
        [System.Xml.Serialization.XmlEnum("theServiceHours")]
        theServiceHours,
        [System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
        [System.Xml.Serialization.XmlEnum("theRxN")]
        theRxN,
        [System.ComponentModel.Description("The usual service hours to which an exception applies")]
        [System.Xml.Serialization.XmlEnum("theServiceHours_nsdy")]
        theServiceHours_nsdy,
        [System.ComponentModel.Description("The location to which the permission statement applies")]
        [System.Xml.Serialization.XmlEnum("vslLocation")]
        vslLocation,
        [System.ComponentModel.Description("The work hours for a non-standard workday")]
        [System.Xml.Serialization.XmlEnum("partialWorkingDay")]
        partialWorkingDay,
        [System.ComponentModel.Description("Pointer to service or facility")]
        [System.Xml.Serialization.XmlEnum("servicePlace")]
        servicePlace,
        [System.ComponentModel.Description("The location for which service hours are given")]
        [System.Xml.Serialization.XmlEnum("location_srvHrs")]
        location_srvHrs,
        [System.ComponentModel.Description("The organisation to which information relates")]
        [System.Xml.Serialization.XmlEnum("theOrganisation")]
        theOrganisation,
        [System.ComponentModel.Description("Information related to an organisation")]
        [System.Xml.Serialization.XmlEnum("theInformation")]
        theInformation,
        [System.ComponentModel.Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
        [System.Xml.Serialization.XmlEnum("permission")]
        permission,
        [System.ComponentModel.Description("Reference to a whole of the same type as the part feature in the relationship.")]
        [System.Xml.Serialization.XmlEnum("constitute")]
        constitute,
        [System.ComponentModel.Description("A reference to a feature that supplements or supports the use of the primary feature in an AuxiliaryFacility relationship.")]
        [System.Xml.Serialization.XmlEnum("auxiliaryFacility")]
        auxiliaryFacility,
        [System.ComponentModel.Description("Reference to the feature within which locations are demarcated.")]
        [System.Xml.Serialization.XmlEnum("demarcatedFeature")]
        demarcatedFeature,
        [System.ComponentModel.Description("Reference to a feature demarcating a location within another feature.")]
        [System.Xml.Serialization.XmlEnum("demarcationIndicator")]
        demarcationIndicator,
        [System.ComponentModel.Description("Reference to an information type describing the entrance to a limit area.")]
        [System.Xml.Serialization.XmlEnum("entranceReference")]
        entranceReference,
        [System.ComponentModel.Description("A reference to the feature to which entrance information pertains.")]
        [System.Xml.Serialization.XmlEnum("entranceTo")]
        entranceTo,
        [System.ComponentModel.Description("Reference to the feature describing a particular instance of physical infrastructure.")]
        [System.Xml.Serialization.XmlEnum("hasInfrastructure")]
        hasInfrastructure,
        [System.ComponentModel.Description("Reference to the feature within which the infrastructure is located.")]
        [System.Xml.Serialization.XmlEnum("infrastructureLocation")]
        infrastructureLocation,
        [System.ComponentModel.Description("Reference to a feature demarcating the extent to which a coastal State claims or may claim a specific jurisdiction.")]
        [System.Xml.Serialization.XmlEnum("limitExtent")]
        limitExtent,
        [System.ComponentModel.Description("Reference to the feature for which a coastal State claims a specific jurisdiction different from the feature's geographic boundary.")]
        [System.Xml.Serialization.XmlEnum("limitReference")]
        limitReference,
        [System.ComponentModel.Description("A reference to the diverse units comprising a feature of a different type.")]
        [System.Xml.Serialization.XmlEnum("layoutUnit")]
        layoutUnit,
        [System.ComponentModel.Description("Reference to the location (feature) where specified services are available.")]
        [System.Xml.Serialization.XmlEnum("locationServed")]
        locationServed,
        [System.ComponentModel.Description("Reference to information about the days and times during which a facility operates or may be used.")]
        [System.Xml.Serialization.XmlEnum("facilityOperatingHours")]
        facilityOperatingHours,
        [System.ComponentModel.Description("A reference to the primary feature in an Auxiliaryfacility relationship.")]
        [System.Xml.Serialization.XmlEnum("primaryFacility")]
        primaryFacility,
        [System.ComponentModel.Description("Reference to an information object describing services.")]
        [System.Xml.Serialization.XmlEnum("serviceDescriptionReference")]
        serviceDescriptionReference,
        [System.ComponentModel.Description("Reference to a part of the same type as the whole feature in the relationship.")]
        [System.Xml.Serialization.XmlEnum("subUnit")]
        subUnit,
        [System.ComponentModel.Description("A pointer to a specific spatial type(s).")]
        [System.Xml.Serialization.XmlEnum("definedFor")]
        definedFor,
        [System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
        [System.Xml.Serialization.XmlEnum("defines")]
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

                public Role[] Roles => new[]
                {
                    Role.providesInformation,
                    Role.informationProvidedFor
                };
            }

            public class AuthorityContact : InformationAssociation
            {
                public AuthorityContact()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.theAuthority,
                    Role.theContactDetails
                };
            }

            public class AuthorityHours : InformationAssociation
            {
                public AuthorityHours()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.theAuthority_srvHrs,
                    Role.theServiceHours
                };
            }

            public class AssociatedRxN : InformationAssociation
            {
                public AssociatedRxN()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.appliesInLocation,
                    Role.theRxN
                };
            }

            public class ExceptionalWorkday : InformationAssociation
            {
                public ExceptionalWorkday()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.theServiceHours_nsdy,
                    Role.partialWorkingDay
                };
            }

            public class ServiceControl : InformationAssociation
            {
                public ServiceControl()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.controlledService,
                    Role.controlAuthority
                };
            }

            public class ServiceContact : InformationAssociation
            {
                public ServiceContact()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.servicePlace,
                    Role.theContactDetails
                };
            }

            public class LocationHours : InformationAssociation
            {
                public LocationHours()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.location_srvHrs,
                    Role.facilityOperatingHours
                };
            }

            public class RelatedOrganisation : InformationAssociation
            {
                public RelatedOrganisation()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.theInformation,
                    Role.theOrganisation
                };
            }

            public class InclusionType : InformationAssociation
            {
                public InclusionType()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.theApplicableRxN,
                    Role.isApplicableTo
                };
                public required membership membership { get; set; }
            }

            public class PermissionType : InformationAssociation
            {
                public PermissionType()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.vslLocation,
                    Role.permission
                };
                public required categoryOfRelationship categoryOfRelationship { get; set; }
            }

            public class SpatialAssociation : InformationAssociation
            {
                public SpatialAssociation()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.defines,
                    Role.definedFor
                };
            }

            public class LimitEntrance : InformationAssociation
            {
                public LimitEntrance()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.entranceTo,
                    Role.entranceReference
                };
            }

            public class ServiceAvailability : InformationAssociation
            {
                public ServiceAvailability()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.locationServed,
                    Role.serviceDescriptionReference
                };
            }
        }

        namespace FeatureAssociations
        {
            public class TextAssociation : FeatureAssociation
            {
                public TextAssociation()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.identifies,
                    Role.positions
                };
            }

            public class Subsection : FeatureAssociation
            {
                public Subsection()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.subUnit,
                    Role.constitute
                };
            }

            public class Infrastructure : FeatureAssociation
            {
                public Infrastructure()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.infrastructureLocation,
                    Role.hasInfrastructure
                };
            }

            public class PrimaryAuxiliaryFacility : FeatureAssociation
            {
                public PrimaryAuxiliaryFacility()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.primaryFacility,
                    Role.auxiliaryFacility
                };
            }

            public class Demarcation : FeatureAssociation
            {
                public Demarcation()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.demarcationIndicator,
                    Role.demarcatedFeature
                };
            }

            public class JurisdictionalLimit : FeatureAssociation
            {
                public JurisdictionalLimit()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.limitReference,
                    Role.limitExtent
                };
            }

            public class LayoutDivision : FeatureAssociation
            {
                public LayoutDivision()
                {
                }

                public Role[] Roles => new[]
                {
                    Role.layoutUnit,
                    Role.componentOf
                };
            }
        }
    }

    namespace Bindings
    {
        public class informationBinding<Tassociation, TinformationType> : DomainModel.Bindings.informationBinding<Tassociation, TinformationType> where Tassociation : InformationAssociation where TinformationType : class
        {
            public informationBinding(Role role)
            {
                base.Role = Enum.GetName(role);
            }
        }

        public class featureBinding<Tassociation, TfeatureType> : DomainModel.Bindings.featureBinding<Tassociation, TfeatureType> where Tassociation : FeatureAssociation where TfeatureType : class
        {
            public featureBinding(Role role)
            {
                base.Role = Enum.GetName(role);
            }
        }
    }

    namespace InformationTypes
    {
        using ComplexAttributes;
        using DomainModel;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<graphic> graphic { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public sourceType? sourceType { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AdditionalInformation, NauticalInformation> providesInformationNauticalInformation => new(Role.providesInformation)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public InformationType()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class AbstractRxN : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfAuthority? categoryOfAuthority { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<rxNCode> rxNCode { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<textContent> textContent { get; set; } = [];

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.InclusionType, Applicability> isApplicableToApplicability => new(Role.isApplicableTo)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.RelatedOrganisation, Authority> theOrganisationAuthority => new(Role.theOrganisation)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public AbstractRxN()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Applicability : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Boolean? inBallast { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfVessel? categoryOfVessel { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfVesselRegistry? categoryOfVesselRegistry { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public logicalConnectives? logicalConnectives { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Int32? thicknessOfIceCapability { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String vesselPerformance { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<vesselsMeasurements> vesselsMeasurements { get; set; } = [];

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.InclusionType, AbstractRxN> theApplicableRxNAbstractRxN => new(Role.theApplicableRxN)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.PermissionType, InformationType> vslLocationInformationType => new(Role.vslLocation)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public Applicability()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Authority : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required categoryOfAuthority categoryOfAuthority { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public textContent? textContent { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AuthorityContact, ContactDetails> theContactDetailsContactDetails => new(Role.theContactDetails)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.RelatedOrganisation, AbstractRxN> theInformationAbstractRxN => new(Role.theInformation)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AuthorityHours, ServiceHours> theServiceHoursServiceHours => new(Role.theServiceHours)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public Authority()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AvailablePortServices : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<firefightingService> firefightingService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<medicalService> medicalService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<repairService> repairService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<technicalPortService> technicalPortService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<shipSanitationControl> shipSanitationControl { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<transportConnection> transportConnection { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<berthingAssistance> berthingAssistance { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<cargoService> cargoService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<securitySafetyEmergencyService> securitySafetyEmergencyService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<wasteDisposalService> wasteDisposalService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<supplyService> supplyService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String tugInformation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<textContent> textContent { get; set; } = [];

            public AvailablePortServices()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ContactDetails : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String callName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String callSign { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<contactAddress> contactAddress { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<Int32> signalFrequency { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<frequencyPair> frequencyPair { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String mMSICode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<onlineResource> onlineResource { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<telecommunications> telecommunications { get; set; } = [];

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AuthorityContact, Authority> theAuthorityAuthority => new(Role.theAuthority)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public ContactDetails()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Entrance : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String entranceDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> associatedFeatureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String localKnowledgeDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String approachDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<markedBy> markedBy { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<landmarkDescription> landmarkDescription { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<offshoreMarkDescription> offshoreMarkDescription { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<majorLightDescription> majorLightDescription { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<usefulMarkDescription> usefulMarkDescription { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<textContent> textContent { get; set; } = [];

            public Entrance()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class NauticalInformation : AbstractRxN
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AdditionalInformation, InformationType> informationProvidedForInformationType => new(Role.informationProvidedFor)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public NauticalInformation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class NonStandardWorkingDay : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<DateOnly> dateFixed { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> dateVariable { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            public NonStandardWorkingDay()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Recommendations : AbstractRxN
        {
            public Recommendations()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Regulations : AbstractRxN
        {
            public Regulations()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Restrictions : AbstractRxN
        {
            public Restrictions()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ServiceHours : InformationType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ExceptionalWorkday, NonStandardWorkingDay> partialWorkingDayNonStandardWorkingDay => new(Role.partialWorkingDay)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AuthorityHours, Authority> theAuthority_srvHrsAuthority => new(Role.theAuthority_srvHrs)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public ServiceHours()
            {
                scheduleByDayOfWeek = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SpatialQuality
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
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
        using DomainModel;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class FeatureType
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationMRN { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String globalLocationNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<rxNCode> rxNCode { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<graphic> graphic { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public sourceType? sourceType { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public DateOnly? reportedDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<textContent> textContent { get; set; } = [];

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.PermissionType, Applicability> permissionApplicability => new(Role.permission)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AssociatedRxN, AbstractRxN> theRxNAbstractRxN => new(Role.theRxN)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.AdditionalInformation, NauticalInformation> providesInformationNauticalInformation => new(Role.providesInformation)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.TextAssociation, TextPlacement> positionsTextPlacement => new(Role.positions)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public FeatureType()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class OrganizationContactArea : FeatureType
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceContact, ContactDetails> theContactDetailsContactDetails => new(Role.theContactDetails)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public OrganizationContactArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class SupervisedArea : OrganizationContactArea
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceControl, Authority> controlAuthorityAuthority => new(Role.controlAuthority)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public SupervisedArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class HarbourPhysicalInfrastructure : SupervisedArea
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? verticalClearanceValue { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.Infrastructure, HarbourAreaSection> infrastructureLocationHarbourAreaSection => new(Role.infrastructureLocation)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public HarbourPhysicalInfrastructure()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class Layout : SupervisedArea
        {
            public Layout()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AnchorBerth : Layout
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceAvailability, AvailablePortServices> serviceDescriptionReferenceAvailablePortServices => new(Role.serviceDescriptionReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.PrimaryAuxiliaryFacility, MooringWarpingFacility> auxiliaryFacilityMooringWarpingFacility => new(Role.auxiliaryFacility)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public AnchorBerth()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AnchorageArea : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public AnchorageArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Berth : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? availableBerthingLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String bollardDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? bollardPull { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? minimumBerthDepth { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? elevation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Boolean? cathodicProtectionSystem { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfBerthLocation? categoryOfBerthLocation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String portFacilityNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> bollardNumber { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String gLNExtension { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> metreMarkNumber { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> manifoldNumber { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String rampNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public methodOfSecuring? methodOfSecuring { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String uNLocationCode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String terminalIdentifier { get; set; } = string.Empty;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceAvailability, AvailablePortServices> serviceDescriptionReferenceAvailablePortServices => new(Role.serviceDescriptionReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.Demarcation, BerthPosition> demarcationIndicatorBerthPosition => new(Role.demarcationIndicator)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public Berth()
            {
                uNLocationCode = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class BerthPosition : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? availableBerthingLength { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String bollardDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? bollardPull { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> bollardNumber { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String gLNExtension { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> metreMarkNumber { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<String> manifoldNumber { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String rampNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.Demarcation, Berth> demarcatedFeatureBerth => new(Role.demarcatedFeature)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.composition
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.PrimaryAuxiliaryFacility, MooringWarpingFacility> auxiliaryFacilityMooringWarpingFacility => new(Role.auxiliaryFacility)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public BerthPosition()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DockArea : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceAvailability, AvailablePortServices> serviceDescriptionReferenceAvailablePortServices => new(Role.serviceDescriptionReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public DockArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DryDock : HarbourPhysicalInfrastructure
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? sillDepth { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public DryDock()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DumpingGround : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public DumpingGround()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class FloatingDock : HarbourPhysicalInfrastructure
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? sillDepth { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public FloatingDock()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Gridiron : HarbourPhysicalInfrastructure
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? sillDepth { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public Gridiron()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class HarbourAreaAdministrative : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String uNLocationCode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String nationality { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String applicableLoadLineZone { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public generalHarbourInformation? generalHarbourInformation { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceAvailability, AvailablePortServices> serviceDescriptionReferenceAvailablePortServices => new(Role.serviceDescriptionReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.JurisdictionalLimit, OuterLimit> limitExtentOuterLimit => new(Role.limitExtent)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> layoutUnitHarbourAreaSection => new(Role.layoutUnit)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public HarbourAreaAdministrative()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class HarbourAreaSection : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfPortSection? categoryOfPortSection { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public facilitiesLayoutDescription? facilitiesLayoutDescription { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceAvailability, AvailablePortServices> serviceDescriptionReferenceAvailablePortServices => new(Role.serviceDescriptionReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaAdministrative> componentOfHarbourAreaAdministrative => new(Role.componentOf)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.Subsection, HarbourAreaSection> constituteHarbourAreaSection => new(Role.constitute)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.Subsection, HarbourAreaSection> subUnitHarbourAreaSection => new(Role.subUnit)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.Infrastructure, HarbourPhysicalInfrastructure> hasInfrastructureHarbourPhysicalInfrastructure => new(Role.hasInfrastructure)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, AnchorageArea> layoutUnitAnchorageArea => new(Role.layoutUnit)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public HarbourAreaSection()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class HarbourBasin : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public HarbourBasin()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class HarbourFacility : HarbourPhysicalInfrastructure
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required List<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public HarbourFacility()
            {
                categoryOfHarbourFacility = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class MooringWarpingFacility : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String iDCode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String bollardDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? bollardPull { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Boolean? heavingLinesFromShore { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceAvailability, AvailablePortServices> serviceDescriptionReferenceAvailablePortServices => new(Role.serviceDescriptionReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.PrimaryAuxiliaryFacility, AnchorBerth> primaryFacilityAnchorBerth => new(Role.primaryFacility)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public MooringWarpingFacility()
            {
                iDCode = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class OuterLimit : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public limitsDescription? limitsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<markedBy> markedBy { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<landmarkDescription> landmarkDescription { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<offshoreMarkDescription> offshoreMarkDescription { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<majorLightDescription> majorLightDescription { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<usefulMarkDescription> usefulMarkDescription { get; set; } = [];

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LimitEntrance, Entrance> entranceReferenceEntrance => new(Role.entranceReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.JurisdictionalLimit, HarbourAreaAdministrative> limitReferenceHarbourAreaAdministrative => new(Role.limitReference)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public OuterLimit()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PilotBoardingPlace : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public PilotBoardingPlace()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SeaplaneLandingArea : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public SeaplaneLandingArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Terminal : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String portFacilityNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfHarbourFacility? categoryOfHarbourFacility { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<product> product { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String terminalIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String sMDGTerminalCode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String uNLocationCode { get; set; } = string.Empty;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.ServiceAvailability, AvailablePortServices> serviceDescriptionReferenceAvailablePortServices => new(Role.serviceDescriptionReference)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, Berth> layoutUnitBerth => new(Role.layoutUnit)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.Infrastructure, HarbourPhysicalInfrastructure> hasInfrastructureHarbourPhysicalInfrastructure => new(Role.hasInfrastructure)
            {
                Lower = 0,
                roleType = DomainModel.Bindings.roleType.association
            };

            public Terminal()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TurningBasin : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public iSPSLevel? iSPSLevel { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public TurningBasin()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class WaterwayArea : Layout
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required categoryOfPortSection categoryOfPortSection { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public depthsDescription? depthsDescription { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String locationByText { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public markedBy? markedBy { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.informationBinding<Associations.InformationAssociations.LocationHours, ServiceHours> location_srvHrsServiceHours => new(Role.location_srvHrs)
            {
                Lower = 0,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.LayoutDivision, HarbourAreaSection> componentOfHarbourAreaSection => new(Role.componentOf)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.aggregation
            };

            public WaterwayArea()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DataCoverage
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Int32 maximumDisplayScale { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Int32 minimumDisplayScale { get; set; }

            public DataCoverage()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class QualityOfNonBathymetricData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public categoryOfTemporalVariation? categoryOfTemporalVariation { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required horizontalPositionUncertainty horizontalPositionUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Decimal? orientationUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public surveyDateRange? surveyDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public verticalUncertainty? verticalUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
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
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SoundingDatum
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required verticalDatum verticalDatum { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            public SoundingDatum()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class VerticalDatumOfData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required verticalDatum verticalDatum { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public List<information> information { get; set; } = [];

            public VerticalDatumOfData()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S131/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S131/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class TextPlacement
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Decimal orientationValue { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public String text { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public required Int32 textOffsetMm { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public textType? textType { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
            public Int32? scaleMinimum { get; set; } = default;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "<Pending>")]
            public static Bindings.featureBinding<Associations.FeatureAssociations.TextAssociation, FeatureType> positionsFeatureType => new(Role.positions)
            {
                Lower = 1,
                Upper = 1,
                roleType = DomainModel.Bindings.roleType.association
            };

            public TextPlacement()
            {
            }
        }
    }
}