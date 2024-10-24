using System;
using System.Collections.Immutable;
using System.Linq;

namespace S100Framework.DomainModel.S201
{
    public static class Information
    {
        public static Version Version => new Version("1.1.0");
        public static string[] ComplexTypes => ["changeDetails", "contactAddress", "surveyDateRange", ];
        public static string[] InformationTypes => ["AtoNStatusInformation", "SpatialUncertainty", ];
        public static string[] FeatureTypes => ["BeaconSpecialPurposeGeneral", "BeaconLateral", "BeaconCardinal", "BeaconIsolatedDanger", "BeaconSafeWater", "BuoyInstallation", "BuoyLateral", "BuoyCardinal", "BuoySafeWater", "BuoyIsolatedDanger", "BuoySpecialPurposeGeneral", "OffshorePlatform", "LightVessel", "Pile", "SiloTank", "Landmark", "LightFloat", "Lighthouse", "Topmark", "Light", "FogSignal", "RetroReflector", "RadarReflector", "EnvironmentObservationEquipment", "Daymark", "RadarTransponderBeacon", "RecommendedTrack", "NavigationLine", "Aggregation", "Association", "DataCoverage", "LocalDirectionOfBuoyage", "NavigationalSystemOfMarks", "QualityOfNonBathymetricData", "SoundingDatum", "VerticalDatumOfData", "AidsToNavigation", "Equipment", "StructureObject", "GenericBeacon", "GenericBuoy", ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum atonRemoval : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        BuoyRemoval = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        BuoyTemporaryRemoval = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        LightRemoval = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        LightTemporaryRemoval = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        BeaconRemoval = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        BeaconTemporaryRemoval = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        FogSignalRemoval = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        FogSignalTemporaryRemoval = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        AudibleSignalRemoval = 9,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("10")]
        AudibleSignalTemporaryRemoval = 10,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("11")]
        VAisRemoval = 11,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("12")]
        VAisTemporaryRemoval = 12,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("13")]
        RaconSignalRemoval = 13,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("14")]
        RaconTemporaryRemoval = 14,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("15")]
        DgpsRemoval = 15,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("16")]
        DgpsTemporaryRemoval = 16,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("17")]
        EgnosRemoval = 17,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("18")]
        EgnosTemporaryRemoval = 18,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("19")]
        LoranCStationRemoval = 19,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("20")]
        LoranCStationTemporaryRemoval = 20,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("21")]
        EloranRemoval = 21,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("22")]
        EloranTemporaryRemoval = 22,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("23")]
        ChaykaStationRemoval = 23,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("24")]
        ChaykaStationTemporaryRemoval = 24,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("25")]
        EChaykaStationRemoval = 25,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("26")]
        EChaykaStationTemporaryRemoval = 26,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum changeTypes : int
    {
        [System.ComponentModel.Description("Temporary changes")]
        [System.Xml.Serialization.XmlEnum("1")]
        TemporaryChanges = 1,
        [System.ComponentModel.Description("Proposed changes")]
        [System.Xml.Serialization.XmlEnum("2")]
        ProposedChanges = 2,
        [System.ComponentModel.Description("Advance notice of changes")]
        [System.Xml.Serialization.XmlEnum("3")]
        AdvanceNoticeOfChanges = 3,
        [System.ComponentModel.Description("Discrepancy")]
        [System.Xml.Serialization.XmlEnum("4")]
        Discrepancy = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum atonReplacement : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        BuoyChange = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        BuoyTemporaryChange = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        LightChange = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        LightTemporaryChange = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        SectorLightChange = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        SectorLightTemporaryChange = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        BeaconChange = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        BeaconTemporaryChange = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        FogSignalChange = 9,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("10")]
        FogSignalTemporaryChange = 10,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("11")]
        AudibleSignalChange = 11,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("12")]
        AudibleSignalTemporaryChange = 12,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("13")]
        VAisChange = 13,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("14")]
        VAisTemporaryChange = 14,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("15")]
        RaconSignalChange = 15,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("16")]
        RaconTemporaryChange = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum atonCommissioning : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        BuoyEstablishment = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        LightEstablishment = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        BeaconEstablishment = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        AudibleSignalEstablishment = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        FogSignalEstablishment = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        AisTransmitterEstablishment = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        VAisEstablishment = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        RaconEstablishment = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        DgpsStationEstablishment = 9,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("10")]
        EloranStationEstablishment = 10,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("11")]
        DglonassStationEstablishment = 11,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("12")]
        EChaykaStationEstablishment = 12,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("13")]
        EgnosEstablishment = 13,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum radioAidsChange : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        AisTransmitterOutOfServive = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        AisTransmitterUnrealiable = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        AisTransmitterOperatingProperly = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        VAisOutOfService = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        VAisUnrealiable = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        VAisOperatingProperly = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        RaconOutOfService = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        RaconUnrealiable = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        RaconOperatingProperly = 9,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("10")]
        DgpsOutOfService = 10,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("11")]
        DgpsUnrealiable = 11,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("12")]
        DgpsOperatingProperly = 12,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("13")]
        LoranCOperatingProperly = 13,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("14")]
        LoranCUnrealiable = 14,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("15")]
        LoranCOutOfService = 15,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("16")]
        EloranOperatingProperly = 16,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("17")]
        EloranUnrealiable = 17,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("18")]
        EloranOutOfService = 18,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("19")]
        DglonassOperatingProperly = 19,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("20")]
        DglonassUnrealiable = 20,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("21")]
        DglonassOutOfService = 21,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("22")]
        ChaykaOperatingProperly = 22,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("23")]
        ChaykaUnrealiable = 23,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("24")]
        ChaykaOutOfService = 24,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("25")]
        EChaykaOperatingProperly = 25,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("26")]
        EChaykaUnrealiable = 26,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("27")]
        EChaykaOutOfService = 27,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("28")]
        EgnosOperatingProperly = 28,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("29")]
        EgnosUnrealiable = 29,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("30")]
        EgnosOutOfService = 30,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum fogSignals : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        AudibleSignalOutOfService = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        FogSignalOutOfService = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        AudibleSignalOperatingProperly = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        FogSignalOperatingProperly = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum leadingLightsChange : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        FrontLeadingRangeLightUnlit = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        RearLeadingRangeLightUnlit = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        FrontLeadingRangeLightUnreliable = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        RearLeadingRangeLightUnreliable = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        FrontLeadingRangeLightLightRangeReduced = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        RearLeadingRangeLightLightRangeReduced = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        FrontLeadingRangeLightWithoutRhythm = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        RearLeadingRangeLightWithoutRhythm = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        LeadingRangeLightsOutOfSynchronization = 9,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("10")]
        FrontLeadingRangeBeaconUnreliable = 10,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("11")]
        RearLeadingRangeBeaconUnreliable = 11,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("12")]
        FrontLeadingRangeLightIsOperatingProperly = 12,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("13")]
        RearLeadingRangeLightIsOperatingProperly = 13,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("14")]
        FrontLeadingRangeBeaconRestoredToNormal = 14,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("15")]
        RearLeadingRangeBeaconRestoredToNormal = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum beaconChange : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        BeaconMissing = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        BeaconDamaged = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        LightBeaconUnlit = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        LightBeaconUnreliable = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        LightBeaconNotSymchronized = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        LightDamaged = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        BeaconTopmarkMissing = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        BeaconTopmarkDamaged = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        BeaconDaymarkUnreliable = 9,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("10")]
        FloodlitBeaconUnlit = 10,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("11")]
        BeaconRestoredToNormal = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum buoyChange : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        LightBuoyLightUnlit = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        LightBuoyLightUnreliable = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        LightBuoyLightNotSynchronized = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        LightBuoyLightDamaged = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        BuoyMissing = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        BuoyOffPosition = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        BuoyMove = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        BuoyDrift = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        BuoyDamaged = 9,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("10")]
        BuoyRestoredToNormal = 10,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("11")]
        BuoyDestroyed = 11,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("12")]
        BuoyReEstablishment = 12,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("13")]
        BuoyTopmarkMissing = 13,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("14")]
        BuoyTopmarkDamaged = 14,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("15")]
        BuoyDaymarkUnreliable = 15,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("16")]
        BuoyWillBeWithdrawn = 16,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("17")]
        BuoyWithdrawn = 17,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("18")]
        LiftedForWinter = 18,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("19")]
        ReplacedByWinterSpar = 19,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("20")]
        DecommissionedForWinter = 20,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("21")]
        RecommissionedForNavigationSeason = 21,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("22")]
        MarineAidsToNavigationUnreliable = 22,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("23")]
        SeasonalDecommissioningComplete = 23,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("24")]
        SeasonalDecommissioningInProgress = 24,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("25")]
        SeasonalRecommissioningComplete = 25,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("26")]
        SeasonalRecommissioningInProgress = 26,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum lightChange : int
    {
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("1")]
        LightUnlit = 1,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("2")]
        LightUnreliable = 2,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("3")]
        LightReEstablishment = 3,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("4")]
        LightRangeReduced = 4,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("5")]
        LightWithoutRhythm = 5,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("6")]
        LightOutOfSynchronization = 6,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("7")]
        LightDaymarkUnreliable = 7,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("8")]
        LightOperatingProperly = 8,
        [System.ComponentModel.Description(".")]
        [System.Xml.Serialization.XmlEnum("9")]
        SectorLightSectorObscured = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum aidAvailabilityCategory : int
    {
        [System.ComponentModel.Description("An AtoN or system of AtoN that is considered by the Competent Authority to be of vital navigational significance.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Category1 = 1,
        [System.ComponentModel.Description("An AtoN or system of AtoN that is considered by the Competent Authority to be of important navigational significance.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Category2 = 2,
        [System.ComponentModel.Description("An AtoN or system of AtoN that is considered by the Competent Authority to be of necessary navigational significance.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Category3 = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum beaconShape : int
    {
        [System.ComponentModel.Description("an elongated wood or metal pole, embedded in the bottom to serve as a navigational aid or a support for a navigational aid.")]
        [System.Xml.Serialization.XmlEnum("1")]
        StakePolePerchPost = 1,
        [System.ComponentModel.Description("a tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Withy = 2,
        [System.ComponentModel.Description("a solid structure of the order of 10 metres in height used as a navigational aid.")]
        [System.Xml.Serialization.XmlEnum("3")]
        BeaconTower = 3,
        [System.ComponentModel.Description("a structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LatticeBeacon = 4,
        [System.ComponentModel.Description("a long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PileBeacon = 5,
        [System.ComponentModel.Description("a mound of stones, usually conical or pyramidal, raised specifically for maritime navigation.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Cairn = 6,
        [System.ComponentModel.Description("a tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.")]
        [System.Xml.Serialization.XmlEnum("7")]
        BuoyantBeacon = 7,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum buildingShape : int
    {
        [System.ComponentModel.Description("a building having many storeys.")]
        [System.Xml.Serialization.XmlEnum("5")]
        HighRiseBuilding = 5,
        [System.ComponentModel.Description("a polyhedron of which one face is a polygon of any number of sides, and the other faces are triangles with a common vertex.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Pyramid = 6,
        [System.ComponentModel.Description("shaped like a cylinder, which is a solid geometrical figure generated by straight lines fixed in direction and describing with one of its points a closed curve, especially a circle.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Cylindrical = 7,
        [System.ComponentModel.Description("shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Spherical = 8,
        [System.ComponentModel.Description("a shape the sides of which are six equal squares a regular hexahedron.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Cubic = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum buoyShape : int
    {
        [System.ComponentModel.Description("the upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ConicalNunOgival = 1,
        [System.ComponentModel.Description("the upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.")]
        [System.Xml.Serialization.XmlEnum("2")]
        CanCylindrical = 2,
        [System.ComponentModel.Description("the upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a part of a sphere.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Spherical = 3,
        [System.ComponentModel.Description("the upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Pillar = 4,
        [System.ComponentModel.Description("the upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.")]
        [System.Xml.Serialization.XmlEnum("5")]
        SparSpindle = 5,
        [System.ComponentModel.Description("the upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.")]
        [System.Xml.Serialization.XmlEnum("6")]
        BarrelTun = 6,
        [System.ComponentModel.Description("a very large buoy, generally more than 5m in diameter.")]
        [System.Xml.Serialization.XmlEnum("7")]
        SuperBuoy = 7,
        [System.ComponentModel.Description("a specially constructed shuttle shaped buoy which is used in ice conditions.")]
        [System.Xml.Serialization.XmlEnum("8")]
        IceBuoy = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfCardinalMark : int
    {
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NW-NE taken from the point of interest it should be passed to the north side of the mark.")]
        [System.Xml.Serialization.XmlEnum("1")]
        NorthCardinalMark = 1,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing NE-SE taken from the point of interest it should be passed to the east side of the mark.")]
        [System.Xml.Serialization.XmlEnum("2")]
        EastCardinalMark = 2,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SE-SW taken from the point of interest it should be passed to the south side of the mark.")]
        [System.Xml.Serialization.XmlEnum("3")]
        SouthCardinalMark = 3,
        [System.ComponentModel.Description("Quadrant bounded by the true bearing SW-NW taken from the point of interest it should be passed to the west side of the mark.")]
        [System.Xml.Serialization.XmlEnum("4")]
        WestCardinalMark = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfFogSignal : int
    {
        [System.ComponentModel.Description("a signal produced by the firing of explosive charges.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Explosive = 1,
        [System.ComponentModel.Description("a diaphone uses compressed air and generally emits a powerful low-pitched sound, which often concludes with a brief sound of suddenly lowered pitch, termed the 'grunt'.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Diaphone = 2,
        [System.ComponentModel.Description("a siren uses compressed air and exists in a variety of types which differ considerably in their sound and power.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Siren = 3,
        [System.ComponentModel.Description("a horn having a diaphragm oscillated by electricity")]
        [System.Xml.Serialization.XmlEnum("4")]
        Nautophone = 4,
        [System.ComponentModel.Description("a reed uses compressed air and emits a weak, high pitched sound.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Reed = 5,
        [System.ComponentModel.Description("a diaphragm horn which operates under the influence of compressed air or steam")]
        [System.Xml.Serialization.XmlEnum("6")]
        Tyfon = 6,
        [System.ComponentModel.Description("a ringing sound with a short range.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Bell = 7,
        [System.ComponentModel.Description("a distinctive sound made by a jet of air passing through an orifice.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Whistle = 8,
        [System.ComponentModel.Description("a sound produced by vibration of a disc when struck.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Gong = 9,
        [System.ComponentModel.Description("a horn uses compressed air or electricity to vibrate a diaphragm and exists in a variety of types which differ greatly in their sound and power.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Horn = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfInstallationBuoy : int
    {
        [System.ComponentModel.Description("incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
        [System.Xml.Serialization.XmlEnum("1")]
        CatenaryAnchorLegMooringCalm = 1,
        [System.ComponentModel.Description("a mooring structure used by tankers to load and unload in port approaches or in offshore oil and gas fields. The size of the structure can vary between a large mooring buoy and a manned floating structure. Also known as single point mooring (SPM)")]
        [System.Xml.Serialization.XmlEnum("2")]
        SingleBuoyMooringSbm = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfLandmark : int
    {
        [System.ComponentModel.Description("a mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Cairn = 1,
        [System.ComponentModel.Description("an area of land for burying the dead.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Cemetery = 2,
        [System.ComponentModel.Description("a vertical structure containing a passage or flue for discharging smoke and gases.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Chimney = 3,
        [System.ComponentModel.Description("a parabolic aerial for the receipt and transmission of high frequency radio signals.")]
        [System.Xml.Serialization.XmlEnum("4")]
        DishAerial = 4,
        [System.ComponentModel.Description("a staff or pole on which flags are raised.")]
        [System.Xml.Serialization.XmlEnum("5")]
        FlagstaffFlagpole = 5,
        [System.ComponentModel.Description("a tall structure used for burning-off waste oil or gas. Normally showing a flame and located at refineries.")]
        [System.Xml.Serialization.XmlEnum("6")]
        FlareStack = 6,
        [System.ComponentModel.Description("a straight vertical piece of timber or a hollow cylinder.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Mast = 7,
        [System.ComponentModel.Description("a tapered fabric sleeve mounted so as to catch and swing with the wind, thus indicating the wind direction.")]
        [System.Xml.Serialization.XmlEnum("8")]
        WindSock = 8,
        [System.ComponentModel.Description("a structure erected or maintained as a memorial to a person or event.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Monument = 9,
        [System.ComponentModel.Description("a cylindrical or slightly tapering body of considerably greater length than diameter erected vertically.")]
        [System.Xml.Serialization.XmlEnum("10")]
        ColumnPillar = 10,
        [System.ComponentModel.Description("a slab of metal, usually ornamented, erected as a memorial to a person or event.")]
        [System.Xml.Serialization.XmlEnum("11")]
        MemorialPlaque = 11,
        [System.ComponentModel.Description("a tapering shaft usually of stone or concrete, square or rectangular in section, with a pyramidal apex.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Obelisk = 12,
        [System.ComponentModel.Description("a representation of a human, animal or fantasy figure in marble, bronze, etc.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Statue = 13,
        [System.ComponentModel.Description("a monument, or other structure in form of a cross.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Cross = 14,
        [System.ComponentModel.Description("a landmark comprising a hemispherical or spheroidal shaped structure")]
        [System.Xml.Serialization.XmlEnum("15")]
        Dome = 15,
        [System.ComponentModel.Description("a device used for directing a radar beam through a search pattern")]
        [System.Xml.Serialization.XmlEnum("16")]
        RadarScanner = 16,
        [System.ComponentModel.Description("a relatively tall structure which may be used for observation, support, storage or communication etc.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Tower = 17,
        [System.ComponentModel.Description("a wind driven system of vanes attached to a tower like structure (excluding wind-generated power plants).")]
        [System.Xml.Serialization.XmlEnum("18")]
        Windmill = 18,
        [System.ComponentModel.Description("a modern structure for the use of windpower.")]
        [System.Xml.Serialization.XmlEnum("19")]
        Windmotor = 19,
        [System.ComponentModel.Description("a tall conical or pyramid-shaped structure often built on the roof or tower of a building, especially a church or mosque.")]
        [System.Xml.Serialization.XmlEnum("20")]
        SpireMinaret = 20,
        [System.ComponentModel.Description("an isolated rocky formation or a single large stone")]
        [System.Xml.Serialization.XmlEnum("21")]
        LargeRockOrBoulderOnLand = 21,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfLateralMark : int
    {
        [System.ComponentModel.Description("indicates the port boundary of a navigational channel or suggested route when proceeding in the 'conventional direction of buoyage'.")]
        [System.Xml.Serialization.XmlEnum("1")]
        PortHandLateralMark = 1,
        [System.ComponentModel.Description("indicates the starboard boundary of a navigational channel or suggested route when proceeding in the 'conventional direction of buoyage'.")]
        [System.Xml.Serialization.XmlEnum("2")]
        StarboardHandLateralMark = 2,
        [System.ComponentModel.Description("at a point where a channel divides, when proceeding in the 'conventional direction of buoyage', the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
        [System.Xml.Serialization.XmlEnum("3")]
        PreferredChannelToStarboardLateralMark = 3,
        [System.ComponentModel.Description("at a point where a channel divides, when proceeding in the 'conventional direction of buoyage', the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
        [System.Xml.Serialization.XmlEnum("4")]
        PreferredChannelToPortLateralMark = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfLight : int
    {
        [System.ComponentModel.Description("a light illuminating a sector of very narrow angle and intended to mark a direction to follow.")]
        [System.Xml.Serialization.XmlEnum("1")]
        DirectionalFunction = 1,
        [System.ComponentModel.Description("a light associated with other lights so as to form a leading line to be followed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LeadingLight = 4,
        [System.ComponentModel.Description("an aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.")]
        [System.Xml.Serialization.XmlEnum("5")]
        AeroLight = 5,
        [System.ComponentModel.Description("a light marking an obstacle which constitutes a danger to air navigation.")]
        [System.Xml.Serialization.XmlEnum("6")]
        AirObstructionLight = 6,
        [System.ComponentModel.Description("a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.")]
        [System.Xml.Serialization.XmlEnum("7")]
        FogDetectorLight = 7,
        [System.ComponentModel.Description("a broad beam light used to illuminate a structure or area.")]
        [System.Xml.Serialization.XmlEnum("8")]
        FloodLight = 8,
        [System.ComponentModel.Description("a light whose source has a linear form generally horizontal, which can reach a length of several metres.")]
        [System.Xml.Serialization.XmlEnum("9")]
        StripLight = 9,
        [System.ComponentModel.Description("a light placed on or near the support of a main light and having a special use in navigation.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SubsidiaryLight = 10,
        [System.ComponentModel.Description("a powerful light focused so as to illuminate a small area.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Spotlight = 11,
        [System.ComponentModel.Description("term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Front = 12,
        [System.ComponentModel.Description("term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Rear = 13,
        [System.ComponentModel.Description("term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Lower = 14,
        [System.ComponentModel.Description("term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Upper = 15,
        [System.ComponentModel.Description("a short range (up to 2km) type of directional light. Sodium lighting gives a yellow background to a screen on which a vertical black line will be seen by an observer on the centre line.")]
        [System.Xml.Serialization.XmlEnum("16")]
        MoireEffect = 16,
        [System.ComponentModel.Description("a light available as a backup to a main light which will be illuminated should the main light fail.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Emergency = 17,
        [System.ComponentModel.Description("a light which enables its approximate bearing to be obtained without the use of a compass.")]
        [System.Xml.Serialization.XmlEnum("18")]
        BearingLight = 18,
        [System.ComponentModel.Description("a group of lights of identical character and almost identical position, that are disposed horizontally.")]
        [System.Xml.Serialization.XmlEnum("19")]
        HorizontallyDisposed = 19,
        [System.ComponentModel.Description("a group of lights of identical character and almost identical position, that are disposed vertically.")]
        [System.Xml.Serialization.XmlEnum("20")]
        VerticallyDisposed = 20,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfNavigationLine : int
    {
        [System.ComponentModel.Description("a straight line that marks the boundary between a safe and a dangerous area or that passes clear of a navigational danger.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ClearingLine = 1,
        [System.ComponentModel.Description("a line passing through one or more fixed marks.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TransitLine = 2,
        [System.ComponentModel.Description("a line passing through one or more clearly defined objects, along the path of which a vessel can approach safely up to a certain distance off.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LeadingLineBearingARecommendedTrack = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfOffshorePlatform : int
    {
        [System.ComponentModel.Description("a temporary mobile structure, either fixed or floating, used in the exploration stages of oil and gas fields.")]
        [System.Xml.Serialization.XmlEnum("1")]
        OilDerrickRig = 1,
        [System.ComponentModel.Description("a term used to indicate a permanent offshore structure equipped to control the flow of oil or gas. It does not include entirely submarine structures.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ProductionPlatform = 2,
        [System.ComponentModel.Description("a platform from which one's surroundings or events can be observed, noted or recorded such as for scientific study.")]
        [System.Xml.Serialization.XmlEnum("3")]
        ObservationResearchPlatform = 3,
        [System.ComponentModel.Description("a metal lattice tower, buoyant at one end and attached at the other by a universal joint to a concrete filled base on the sea bed. The platform may be fitted with a helicopter platform, emergency accommodation and hawser/hose retrieval.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ArticulatedLoadingPlatformAlp = 4,
        [System.ComponentModel.Description("a rigid frame or tube with a buoyancy device at its upper end , secured at its lower end to a universal joint on a large steel or concrete base resting on the sea bed, and at its upper end to a mooring buoy by a chain or wire.")]
        [System.Xml.Serialization.XmlEnum("5")]
        SingleAnchorLegMooringSalm = 5,
        [System.ComponentModel.Description("a platform secured to the sea bed and surmounted by a turntable to which ships moor.")]
        [System.Xml.Serialization.XmlEnum("6")]
        MooringTower = 6,
        [System.ComponentModel.Description("a man-made structure usually built for the exploration or exploitation of marine resources, marine scientific research, tidal observations, etc.")]
        [System.Xml.Serialization.XmlEnum("7")]
        ArtificialIsland = 7,
        [System.ComponentModel.Description("an offshore oil/gas facility consisting of a moored tanker/barge by which the product is extracted, stored and exported.")]
        [System.Xml.Serialization.XmlEnum("8")]
        FloatingProductionStorageAndOffloadingVesselFpso = 8,
        [System.ComponentModel.Description("a platform used primarily for eating, sleeping and recreation purposes.")]
        [System.Xml.Serialization.XmlEnum("9")]
        AccommodationPlatform = 9,
        [System.ComponentModel.Description("a floating structure with control room, power and storage facilities, attached to the sea bed by a flexible pipeline and cables.")]
        [System.Xml.Serialization.XmlEnum("10")]
        NavigationCommunicationAndControlBuoyNccb = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfPile : int
    {
        [System.ComponentModel.Description("an elongated wood or metal pole embedded in the bottom to serve as a marker or support.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Stake = 1,
        [System.ComponentModel.Description("a vertical piece of timber, metal or concrete forced into the earth or sea bed.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Post = 3,
        [System.ComponentModel.Description("a single structure comprising 3 or more piles held together (sections of heavy timber, steel or concrete), and forced into the earth or sea bed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Tripodal = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRadarTransponderBeacon : int
    {
        [System.ComponentModel.Description("a radar marker beacon which continuously transmits a signal appearing as a radial line on a radar screen, the line indicating the direction of the beacon. Ramarks are intended primarily for marine use. The name 'ramark' is derived from the words radar marker.")]
        [System.Xml.Serialization.XmlEnum("1")]
        RamarkRadarBeaconTransmittingContinuously = 1,
        [System.ComponentModel.Description("a radar beacon which returns a coded signal which provides identification of the beacon, as well as range and bearing. The range and bearing are indicated by the location of the first character received on the radar screen. The name 'racon' is derived from the words radar beacon.")]
        [System.Xml.Serialization.XmlEnum("2")]
        RaconRadarTransponderBeacon = 2,
        [System.ComponentModel.Description("a radar beacon that may be used (in conjunction with at least one other radar beacon) to indicate a leading line.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LeadingRaconRadarTransponderBeacon = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfRecommendedTrack : int
    {
        [System.ComponentModel.Description("a straight route (known as a recommended track, range or leading line), which comprises at least two structures (usually beacons or daymarks) and/or natural features, which may carry lights and/or top-marks. The structures/features are positioned so that when observed to be in line, a vessel can follow a known bearing with safety.")]
        [System.Xml.Serialization.XmlEnum("1")]
        BasedOnASystemOfFixedMarks = 1,
        [System.ComponentModel.Description("a route (known as a recommended track or preferred route) which is not based on a series of structures or features in line.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NotBasedOnASystemOfFixedMarks = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSiloTank : int
    {
        [System.ComponentModel.Description("a generally cylindrical tower used for storing fodder or grain.")]
        [System.Xml.Serialization.XmlEnum("1")]
        SiloInGeneral = 1,
        [System.ComponentModel.Description("a fixed structure for storing liquids.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TankInGeneral = 2,
        [System.ComponentModel.Description("a storage building for grain. Usually a tall frame, metal or concrete structure with an especially compartmented interior.")]
        [System.Xml.Serialization.XmlEnum("3")]
        GrainElevator = 3,
        [System.ComponentModel.Description("a tower with an elevated container used to hold water.")]
        [System.Xml.Serialization.XmlEnum("4")]
        WaterTower = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfSpecialPurposeMark : int
    {
        [System.ComponentModel.Description("a mark used to indicate a firing danger area, usually at sea.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FiringDangerMark = 1,
        [System.ComponentModel.Description("any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TargetMark = 2,
        [System.ComponentModel.Description("a mark marking the position of a ship which is used as a target during some military exercise.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MarkerShipMark = 3,
        [System.ComponentModel.Description("a mark used to indicate a degaussing range.")]
        [System.Xml.Serialization.XmlEnum("4")]
        DegaussingRangeMark = 4,
        [System.ComponentModel.Description("a mark of relevance to barges.")]
        [System.Xml.Serialization.XmlEnum("5")]
        BargeMark = 5,
        [System.ComponentModel.Description("a mark used to indicate the position of submarine cables or the point at which they run on to the land.")]
        [System.Xml.Serialization.XmlEnum("6")]
        CableMark = 6,
        [System.ComponentModel.Description("a mark used to indicate the limit of a spoil ground")]
        [System.Xml.Serialization.XmlEnum("7")]
        SpoilGroundMark = 7,
        [System.ComponentModel.Description("a mark used to indicate the position of an outfall or the point at which it leaves the land.")]
        [System.Xml.Serialization.XmlEnum("8")]
        OutfallMark = 8,
        [System.ComponentModel.Description("Ocean Data Acquisition System")]
        [System.Xml.Serialization.XmlEnum("9")]
        Odas = 9,
        [System.ComponentModel.Description("a mark used to record data for scientific purposes.")]
        [System.Xml.Serialization.XmlEnum("10")]
        RecordingMark = 10,
        [System.ComponentModel.Description("a mark used to indicate a seaplane anchorage.")]
        [System.Xml.Serialization.XmlEnum("11")]
        SeaplaneAnchorageMark = 11,
        [System.ComponentModel.Description("a mark used to indicate a recreation zone.")]
        [System.Xml.Serialization.XmlEnum("12")]
        RecreationZoneMark = 12,
        [System.ComponentModel.Description("a privately maintained mark.")]
        [System.Xml.Serialization.XmlEnum("13")]
        PrivateMark = 13,
        [System.ComponentModel.Description("a mark indicating a mooring or moorings.")]
        [System.Xml.Serialization.XmlEnum("14")]
        MooringMark = 14,
        [System.ComponentModel.Description("a large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Lanby = 15,
        [System.ComponentModel.Description("aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
        [System.Xml.Serialization.XmlEnum("16")]
        LeadingMark = 16,
        [System.ComponentModel.Description("a mark forming part of a transit indicating one end of a measured distance.")]
        [System.Xml.Serialization.XmlEnum("17")]
        MeasuredDistanceMark = 17,
        [System.ComponentModel.Description("a notice board or sign indicating information to the mariner.")]
        [System.Xml.Serialization.XmlEnum("18")]
        NoticeMark = 18,
        [System.ComponentModel.Description("a mark indicating a traffic separation scheme.")]
        [System.Xml.Serialization.XmlEnum("19")]
        TssMark = 19,
        [System.ComponentModel.Description("a mark indicating an anchoring prohibited area.")]
        [System.Xml.Serialization.XmlEnum("20")]
        AnchoringProhibitedMark = 20,
        [System.ComponentModel.Description("a mark indicating that berthing is prohibited.")]
        [System.Xml.Serialization.XmlEnum("21")]
        BerthingProhibitedMark = 21,
        [System.ComponentModel.Description("a mark indicating that overtaking is prohibited.")]
        [System.Xml.Serialization.XmlEnum("22")]
        OvertakingProhibitedMark = 22,
        [System.ComponentModel.Description("a mark indicating a one-way route.")]
        [System.Xml.Serialization.XmlEnum("23")]
        TwoWayTrafficProhibitedMark = 23,
        [System.ComponentModel.Description("a mark indicating that vessels must not generate excessive wake.")]
        [System.Xml.Serialization.XmlEnum("24")]
        ReducedWakeMark = 24,
        [System.ComponentModel.Description("a mark indicating that a speed limit applies.")]
        [System.Xml.Serialization.XmlEnum("25")]
        SpeedLimitMark = 25,
        [System.ComponentModel.Description("a mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
        [System.Xml.Serialization.XmlEnum("26")]
        StopMark = 26,
        [System.ComponentModel.Description("a mark indicating that special caution must be exercised in the vicinity of the mark.")]
        [System.Xml.Serialization.XmlEnum("27")]
        GeneralWarningMark = 27,
        [System.ComponentModel.Description("a mark indicating that a ship should sound its siren or horn.")]
        [System.Xml.Serialization.XmlEnum("28")]
        SoundShipsSirenMark = 28,
        [System.ComponentModel.Description("a mark indicating the minimum vertical space available for passage.")]
        [System.Xml.Serialization.XmlEnum("29")]
        RestrictedVerticalClearanceMark = 29,
        [System.ComponentModel.Description("a mark indicating the maximum draught of vessel permitted.")]
        [System.Xml.Serialization.XmlEnum("30")]
        MaximumVesselSDraughtMark = 30,
        [System.ComponentModel.Description("a mark indicating the minimum horizontal space available for passage.")]
        [System.Xml.Serialization.XmlEnum("31")]
        RestrictedHorizontalClearanceMark = 31,
        [System.ComponentModel.Description("a mark warning of strong currents.")]
        [System.Xml.Serialization.XmlEnum("32")]
        StrongCurrentWarningMark = 32,
        [System.ComponentModel.Description("a mark indicating that berthing is allowed.")]
        [System.Xml.Serialization.XmlEnum("33")]
        BerthingPermittedMark = 33,
        [System.ComponentModel.Description("a mark indicating an overhead power cable.")]
        [System.Xml.Serialization.XmlEnum("34")]
        OverheadPowerCableMark = 34,
        [System.ComponentModel.Description("a mark indicating the gradient of the slope of a dredge channel edge.")]
        [System.Xml.Serialization.XmlEnum("35")]
        ChannelEdgeGradientMark = 35,
        [System.ComponentModel.Description("a mark indicating the presence of a telephone.")]
        [System.Xml.Serialization.XmlEnum("36")]
        TelephoneMark = 36,
        [System.ComponentModel.Description("a mark indicating that a ferry route crosses the ship route often used with a 'sound ship's siren' mark.")]
        [System.Xml.Serialization.XmlEnum("37")]
        FerryCrossingMark = 37,
        [System.ComponentModel.Description("a mark used to indicate the position of submarine pipelines or the point at which they run on to the land.")]
        [System.Xml.Serialization.XmlEnum("39")]
        PipelineMark = 39,
        [System.ComponentModel.Description("a mark indicating an anchorage area.")]
        [System.Xml.Serialization.XmlEnum("40")]
        AnchorageMark = 40,
        [System.ComponentModel.Description("a mark used to indicate a clearing line.")]
        [System.Xml.Serialization.XmlEnum("41")]
        ClearingMark = 41,
        [System.ComponentModel.Description("a mark indicating the location at which a restriction or requirement exists.")]
        [System.Xml.Serialization.XmlEnum("42")]
        ControlMark = 42,
        [System.ComponentModel.Description("a mark indicating that diving may take place in the vicinity.")]
        [System.Xml.Serialization.XmlEnum("43")]
        DivingMark = 43,
        [System.ComponentModel.Description("a mark providing or indicating a place of safety.")]
        [System.Xml.Serialization.XmlEnum("44")]
        RefugeBeacon = 44,
        [System.ComponentModel.Description("a mark indicating a foul ground.")]
        [System.Xml.Serialization.XmlEnum("45")]
        FoulGroundMark = 45,
        [System.ComponentModel.Description("a mark installed for use by yachtsmen.")]
        [System.Xml.Serialization.XmlEnum("46")]
        YachtingMark = 46,
        [System.ComponentModel.Description("a mark indicating an area where helicopters may land.")]
        [System.Xml.Serialization.XmlEnum("47")]
        HeliportMark = 47,
        [System.ComponentModel.Description("a mark indicating a location at which a GNSS position has been accurately determined.")]
        [System.Xml.Serialization.XmlEnum("48")]
        GnssMark = 48,
        [System.ComponentModel.Description("a mark indicating an area where sea-planes land.")]
        [System.Xml.Serialization.XmlEnum("49")]
        SeaplaneLandingMark = 49,
        [System.ComponentModel.Description("a mark indicating that entry is prohibited.")]
        [System.Xml.Serialization.XmlEnum("50")]
        EntryProhibitedMark = 50,
        [System.ComponentModel.Description("a mark indicating that work (generally construction) is in progress.")]
        [System.Xml.Serialization.XmlEnum("51")]
        WorkInProgressMark = 51,
        [System.ComponentModel.Description("a mark whose detailed characteristics are unknown.")]
        [System.Xml.Serialization.XmlEnum("52")]
        MarkWithUnknownPurpose = 52,
        [System.ComponentModel.Description("a mark indicating a borehole that produces or is capable of producing oil or natural gas.")]
        [System.Xml.Serialization.XmlEnum("53")]
        WellheadMark = 53,
        [System.ComponentModel.Description("a mark indicating the point at which a channel divides separately into two channels.")]
        [System.Xml.Serialization.XmlEnum("54")]
        ChannelSeparationMark = 54,
        [System.ComponentModel.Description("a mark indicating the existence of a fish, mussel, oyster or pearl farm/ culture.")]
        [System.Xml.Serialization.XmlEnum("55")]
        MarineFarmMark = 55,
        [System.ComponentModel.Description("a mark indicating the existence or the extent of an artificial reef.")]
        [System.Xml.Serialization.XmlEnum("56")]
        ArtificialReefMark = 56,
        [System.ComponentModel.Description("A mark indicating a jetski prohibited area")]
        [System.Xml.Serialization.XmlEnum("64")]
        JetskiProhibited = 64,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfTemporalVariation : int
    {
        [System.ComponentModel.Description("Temporal variation not assessed or cannot be determined.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Unassessed = 1,
        [System.ComponentModel.Description("No new hydrographic survey conducted after an event (e.g. hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor significantly.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Event = 2,
        [System.ComponentModel.Description("Continuous or frequent change (e.g. river siltation, sand waves, seasonal storms, icebergs, etc).")]
        [System.Xml.Serialization.XmlEnum("3")]
        LikelyToChange = 3,
        [System.ComponentModel.Description("Likely to change but significant shoaling unlikely")]
        [System.Xml.Serialization.XmlEnum("4")]
        LikelyToChangeButSignificantShoalingUnlikely = 4,
        [System.ComponentModel.Description("Significant change to the seafloor is not expected.")]
        [System.Xml.Serialization.XmlEnum("5")]
        UnlikelyToChange = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum colour : int
    {
#pragma warning restore CS8981
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
        [System.ComponentModel.Description("straight bands or stripes of differing colours painted horizontally.")]
        [System.Xml.Serialization.XmlEnum("1")]
        HorizontalStripes = 1,
        [System.ComponentModel.Description("straight bands or stripes of differing colours painted vertically.")]
        [System.Xml.Serialization.XmlEnum("2")]
        VerticalStripes = 2,
        [System.ComponentModel.Description("straight bands or stripes of differing colours painted diagonally (ie not horizontally or vertically).")]
        [System.Xml.Serialization.XmlEnum("3")]
        DiagonalStripes = 3,
        [System.ComponentModel.Description("often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Squared = 4,
        [System.ComponentModel.Description("straight bands or stripes of differing colours painted in an unknown direction.")]
        [System.Xml.Serialization.XmlEnum("5")]
        StripesDirectionUnknown = 5,
        [System.ComponentModel.Description("a band or stripe of colour which is displayed around the outer edge of the object, which may also form a border to an inner pattern or plain colour.")]
        [System.Xml.Serialization.XmlEnum("6")]
        BorderStripe = 6,
        [System.ComponentModel.Description("One solid colour of uniform coverage")]
        [System.Xml.Serialization.XmlEnum("7")]
        SingleColour = 7,
        [System.ComponentModel.Description("A four-sided shape that is made up of two pairs of parallel lines and that has four right angles, on a different coloured background")]
        [System.Xml.Serialization.XmlEnum("8")]
        Rectangle = 8,
        [System.ComponentModel.Description("a shape that is made up of three lines and three angles, on a different coloured background")]
        [System.Xml.Serialization.XmlEnum("9")]
        Triangle = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum condition : int
    {
#pragma warning restore CS8981
        [System.ComponentModel.Description("a structure that is in the process of being built.")]
        [System.Xml.Serialization.XmlEnum("1")]
        UnderConstruction = 1,
        [System.ComponentModel.Description("a structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Ruined = 2,
        [System.ComponentModel.Description("an area of the sea that is being reclaimed as land, usually by the dumping of earth and other material.")]
        [System.Xml.Serialization.XmlEnum("3")]
        UnderReclamation = 3,
        [System.ComponentModel.Description("a windmill or windmotor from which the turbine blades are missing.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Wingless = 4,
        [System.ComponentModel.Description("an area where a future construction is planned.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PlannedConstruction = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum exhibitionConditionOfLight : int
    {
        [System.ComponentModel.Description("a light shown throughout the 24 hours without change of character.")]
        [System.Xml.Serialization.XmlEnum("1")]
        LightShownWithoutChangeOfCharacter = 1,
        [System.ComponentModel.Description("a light which is only exhibited by day.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DaytimeLight = 2,
        [System.ComponentModel.Description("a light which is exhibited in fog or conditions of reduced visibility.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FogLight = 3,
        [System.ComponentModel.Description("a light which is only exhibited at night.")]
        [System.Xml.Serialization.XmlEnum("4")]
        NightLight = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum function : int
    {
#pragma warning restore CS8981
        [System.ComponentModel.Description("the office of the local official who has charge of mooring and berthing of vessels, collecting harbour fees, etc.")]
        [System.Xml.Serialization.XmlEnum("2")]
        HarbourMasterSOffice = 2,
        [System.ComponentModel.Description("an office which is charged with enforcing customs regulations.")]
        [System.Xml.Serialization.XmlEnum("3")]
        CustomsOffice = 3,
        [System.ComponentModel.Description("the office which is charged with the administration of health laws and sanitary inspections.")]
        [System.Xml.Serialization.XmlEnum("4")]
        HealthOffice = 4,
        [System.ComponentModel.Description("an institution or establishment providing medical or surgical treatment for the ill or wounded.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Hospital = 5,
        [System.ComponentModel.Description("the public department, agency or organisation responsible primarily for the collection, transmission and distribution of mail.")]
        [System.Xml.Serialization.XmlEnum("6")]
        PostOffice = 6,
        [System.ComponentModel.Description("an establishment, especially of a comfortable or luxurious kind, where paying visitors are provided with accommodation, meals and other services.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Hotel = 7,
        [System.ComponentModel.Description("a building with platforms where trains arrive, load, discharge and depart.")]
        [System.Xml.Serialization.XmlEnum("8")]
        RailwayStation = 8,
        [System.ComponentModel.Description("the office of the local police force.")]
        [System.Xml.Serialization.XmlEnum("9")]
        PoliceStation = 9,
        [System.ComponentModel.Description("the headquarters of a local water-police force.")]
        [System.Xml.Serialization.XmlEnum("10")]
        WaterPoliceStation = 10,
        [System.ComponentModel.Description("the office or headquarters of pilots the place where the services of a pilot may be obtained.")]
        [System.Xml.Serialization.XmlEnum("11")]
        PilotOffice = 11,
        [System.ComponentModel.Description("a distinctive structure on shore from which personnel keep watch upon events at sea or along the coast.")]
        [System.Xml.Serialization.XmlEnum("12")]
        PilotLookout = 12,
        [System.ComponentModel.Description("an office for custody, deposit, loan, exchange or issue of money.")]
        [System.Xml.Serialization.XmlEnum("13")]
        BankOffice = 13,
        [System.ComponentModel.Description("the quarters of an executive officer (director, manager, etc.) with responsibility for an administrative area.")]
        [System.Xml.Serialization.XmlEnum("14")]
        HeadquartersForDistrictControl = 14,
        [System.ComponentModel.Description("a building or part of a building for storage of wares or goods.")]
        [System.Xml.Serialization.XmlEnum("15")]
        TransitShedWarehouse = 15,
        [System.ComponentModel.Description("a building or buildings with equipment for manufacturing a workshop.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Factory = 16,
        [System.ComponentModel.Description("a stationary plant containing apparatus for large scale conversion of some form of energy (such as hydraulic, steam, chemical or nuclear energy) into electrical energy.")]
        [System.Xml.Serialization.XmlEnum("17")]
        PowerStation = 17,
        [System.ComponentModel.Description("a building for the management of affairs.")]
        [System.Xml.Serialization.XmlEnum("18")]
        Administrative = 18,
        [System.ComponentModel.Description("a building concerned with education (e.g. school, college, university, etc.)")]
        [System.Xml.Serialization.XmlEnum("19")]
        EducationalFacility = 19,
        [System.ComponentModel.Description("a building for public Christian worship.")]
        [System.Xml.Serialization.XmlEnum("20")]
        Church = 20,
        [System.ComponentModel.Description("a place for Christian worship other than a parish, cathedral or church, especially one attached to a private house or institution.")]
        [System.Xml.Serialization.XmlEnum("21")]
        Chapel = 21,
        [System.ComponentModel.Description("a building for public Jewish worship.")]
        [System.Xml.Serialization.XmlEnum("22")]
        Temple = 22,
        [System.ComponentModel.Description("a Hindu or Buddhist temple or sacred building.")]
        [System.Xml.Serialization.XmlEnum("23")]
        Pagoda = 23,
        [System.ComponentModel.Description("a building for public Shinto worship.")]
        [System.Xml.Serialization.XmlEnum("24")]
        ShintoShrine = 24,
        [System.ComponentModel.Description("see pagoda.")]
        [System.Xml.Serialization.XmlEnum("25")]
        BuddhistTemple = 25,
        [System.ComponentModel.Description("a Muslim place of worship.")]
        [System.Xml.Serialization.XmlEnum("26")]
        Mosque = 26,
        [System.ComponentModel.Description("a shrine marking the burial place of a Muslim holy man.")]
        [System.Xml.Serialization.XmlEnum("27")]
        Marabout = 27,
        [System.ComponentModel.Description("keeping a watch upon events at sea or along the coast.")]
        [System.Xml.Serialization.XmlEnum("28")]
        Lookout = 28,
        [System.ComponentModel.Description("transmitting and/or receiving electronic communication signals.")]
        [System.Xml.Serialization.XmlEnum("29")]
        Communication = 29,
        [System.ComponentModel.Description("broadcast of television signals.")]
        [System.Xml.Serialization.XmlEnum("30")]
        Television = 30,
        [System.ComponentModel.Description("broadcast of radio signals.")]
        [System.Xml.Serialization.XmlEnum("31")]
        Radio = 31,
        [System.ComponentModel.Description("a method, system or technique of using beamed, reflected, and timed radio waves for detecting, locating, or tracking objects, and for measuring altitudes.")]
        [System.Xml.Serialization.XmlEnum("32")]
        Radar = 32,
        [System.ComponentModel.Description("supporting a light")]
        [System.Xml.Serialization.XmlEnum("33")]
        LightSupport = 33,
        [System.ComponentModel.Description("broadcasting and receiving signals using microwaves.")]
        [System.Xml.Serialization.XmlEnum("34")]
        Microwave = 34,
        [System.ComponentModel.Description("dissipating heat.")]
        [System.Xml.Serialization.XmlEnum("35")]
        Cooling = 35,
        [System.ComponentModel.Description("a place from which the surroundings can be observed but at which a watch is not habitually maintained.")]
        [System.Xml.Serialization.XmlEnum("36")]
        Observation = 36,
        [System.ComponentModel.Description("a visual time signal in form of a ball")]
        [System.Xml.Serialization.XmlEnum("37")]
        TimeBall = 37,
        [System.ComponentModel.Description("visual time signal.")]
        [System.Xml.Serialization.XmlEnum("38")]
        Clock = 38,
        [System.ComponentModel.Description("used to control the flow of air, rail, or marine traffic.")]
        [System.Xml.Serialization.XmlEnum("39")]
        Control = 39,
        [System.ComponentModel.Description("a facility to secure an airship.")]
        [System.Xml.Serialization.XmlEnum("40")]
        AirshipMooring = 40,
        [System.ComponentModel.Description("a large usually unroofed building with tiers of seats for spectators")]
        [System.Xml.Serialization.XmlEnum("41")]
        Stadium = 41,
        [System.ComponentModel.Description("a location at which buses arrive and from which they depart.")]
        [System.Xml.Serialization.XmlEnum("42")]
        BusStation = 42,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum lightCharacteristic : int
    {
        [System.ComponentModel.Description("a signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Fixed = 1,
        [System.ComponentModel.Description("a rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Flashing = 2,
        [System.ComponentModel.Description("a flashing light in which a single flash of not less than two seconds duration is regularly repeated.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LongFlashing = 3,
        [System.ComponentModel.Description("a light exhibiting without interruption very rapid regular alternations of light and darkness.")]
        [System.Xml.Serialization.XmlEnum("4")]
        QuickFlashing = 4,
        [System.ComponentModel.Description("a flashing light in which flashes are repeated at a rate of not less than 80 flashes per minute but less than 160 flashes per minute.")]
        [System.Xml.Serialization.XmlEnum("5")]
        VeryQuickFlashing = 5,
        [System.ComponentModel.Description("a flashing light in which flashes are repeated at a rate of not less than 160 flashes per minute.")]
        [System.Xml.Serialization.XmlEnum("6")]
        UltraQuickFlashing = 6,
        [System.ComponentModel.Description("a light with all durations of light and darkness equal.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Isophased = 7,
        [System.ComponentModel.Description("a rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Occulting = 8,
        [System.ComponentModel.Description("a quick light in which the sequence of flashes is interrupted by regularly repeated eclipses of constant and long duration.")]
        [System.Xml.Serialization.XmlEnum("9")]
        InterruptedQuickFlashing = 9,
        [System.ComponentModel.Description("a light in which the very rapid alterations of light and darkness are interrupted at regular intervals by eclipses of long duration.")]
        [System.Xml.Serialization.XmlEnum("10")]
        InterruptedVeryQuickFlashing = 10,
        [System.ComponentModel.Description("a light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.")]
        [System.Xml.Serialization.XmlEnum("11")]
        InterruptedUltraQuickFlashing = 11,
        [System.ComponentModel.Description("a rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Morse = 12,
        [System.ComponentModel.Description("a rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
        [System.Xml.Serialization.XmlEnum("13")]
        FixedFlash = 13,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("14")]
        FlashLongFlash = 14,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("15")]
        OccultingFlash = 15,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("16")]
        FixedLongFlash = 16,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("17")]
        OccultingAlternating = 17,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("18")]
        LongFlashAlternating = 18,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("19")]
        FlashAlternating = 19,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("25")]
        QuickFlashPlusLongFlash = 25,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("26")]
        VeryQuickFlashPlusLongFlash = 26,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("27")]
        UltraQuickFlashPlusLongFlash = 27,
        [System.ComponentModel.Description("a signal light that shows, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
        [System.Xml.Serialization.XmlEnum("28")]
        Alternating = 28,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("29")]
        FixedAndAlternatingFlashing = 29,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum lightVisibility : int
    {
        [System.ComponentModel.Description("non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).")]
        [System.Xml.Serialization.XmlEnum("1")]
        HighIntensity = 1,
        [System.ComponentModel.Description("non-marine lights with lower power than marine lights.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LowIntensity = 2,
        [System.ComponentModel.Description("a decrease in the apparent intensity of a light which may occur in the case of partial obstructions.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Faint = 3,
        [System.ComponentModel.Description("a light in a sector is intensified (i.e. has longer range than other sectors).")]
        [System.Xml.Serialization.XmlEnum("4")]
        Intensified = 4,
        [System.ComponentModel.Description("a light in a sector is unintensified (i.e. has shorter range than other sectors).")]
        [System.Xml.Serialization.XmlEnum("5")]
        Unintensified = 5,
        [System.ComponentModel.Description("a light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.")]
        [System.Xml.Serialization.XmlEnum("6")]
        VisibilityDeliberatelyRestricted = 6,
        [System.ComponentModel.Description("said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Obscured = 7,
        [System.ComponentModel.Description("this value specifies that parts of the sector are obscured.")]
        [System.Xml.Serialization.XmlEnum("8")]
        PartiallyObscured = 8,
        [System.ComponentModel.Description("lights that must be in line to be visible.")]
        [System.Xml.Serialization.XmlEnum("9")]
        VisibleInLineOfRange = 9,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum marksNavigationalSystemOf : int
    {
        [System.ComponentModel.Description("navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.")]
        [System.Xml.Serialization.XmlEnum("1")]
        IalaA = 1,
        [System.ComponentModel.Description("navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.")]
        [System.Xml.Serialization.XmlEnum("2")]
        IalaB = 2,
        [System.ComponentModel.Description("navigational aids do not conform to any defined system.")]
        [System.Xml.Serialization.XmlEnum("9")]
        NoSystem = 9,
        [System.ComponentModel.Description("navigational aids conform to a defined system other than International Association of Lighthouse Authorities -IALA.")]
        [System.Xml.Serialization.XmlEnum("10")]
        OtherSystem = 10,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum installationType : int
    {
        [System.ComponentModel.Description("Fixed Topmark")]
        [System.Xml.Serialization.XmlEnum("1")]
        Fixed = 1,
        [System.ComponentModel.Description("Floating Topmark")]
        [System.Xml.Serialization.XmlEnum("2")]
        Floating = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum natureOfConstruction : int
    {
        [System.ComponentModel.Description("constructed of brick or stone.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Masonry = 1,
        [System.ComponentModel.Description("constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Concreted = 2,
        [System.ComponentModel.Description("constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
        [System.Xml.Serialization.XmlEnum("3")]
        LooseBoulders = 3,
        [System.ComponentModel.Description("constructed with a surface of hard material, usually a term applied to roads surfaced with asphalt or concrete.")]
        [System.Xml.Serialization.XmlEnum("4")]
        HardSurface = 4,
        [System.ComponentModel.Description("constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Unsurfaced = 5,
        [System.ComponentModel.Description("constructed from wood.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Wooden = 6,
        [System.ComponentModel.Description("constructed from metal.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Metal = 7,
        [System.ComponentModel.Description("constructed from a plastic material strengthened with fibres of glass.")]
        [System.Xml.Serialization.XmlEnum("8")]
        GlassReinforcedPlasticGrp = 8,
        [System.ComponentModel.Description("the application of paint to some other construction or natural feature.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Painted = 9,
        [System.ComponentModel.Description("Constructed from fiberglass")]
        [System.Xml.Serialization.XmlEnum("13")]
        Fiberglass = 13,
        [System.ComponentModel.Description("Constructed from plastic")]
        [System.Xml.Serialization.XmlEnum("14")]
        Plastic = 14,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum product : int
    {
#pragma warning restore CS8981
        [System.ComponentModel.Description("a thick, slippery liquid that will not dissolve in water, usually petroleum based in the context of storage tanks.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Oil = 1,
        [System.ComponentModel.Description("a substance with particles that can move freely, usually a fuel substance in the context of storage tanks.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Gas = 2,
        [System.ComponentModel.Description("a colourless, odourless, tasteless liquid that is a compound of hydrogen and oxygen.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Water = 3,
        [System.ComponentModel.Description("a general term for rock fragments.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Stone = 4,
        [System.ComponentModel.Description("a hard black mineral that is burned as fuel.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Coal = 5,
        [System.ComponentModel.Description("a solid rock or mineral from which metal is obtained.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Ore = 6,
        [System.ComponentModel.Description("any substance obtained by or used in a chemical process.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Chemicals = 7,
        [System.ComponentModel.Description("water that is suitable for human consumption.")]
        [System.Xml.Serialization.XmlEnum("8")]
        DrinkingWater = 8,
        [System.ComponentModel.Description("a white fluid secreted by female mammals as food for their young.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Milk = 9,
        [System.ComponentModel.Description("a mineral from which aluminum is obtained.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Bauxite = 10,
        [System.ComponentModel.Description("a solid substance obtained after gas and tar have been extracted from coal, used as a fuel.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Coke = 11,
        [System.ComponentModel.Description("an oblong lump of cast iron metal.")]
        [System.Xml.Serialization.XmlEnum("12")]
        IronIngots = 12,
        [System.ComponentModel.Description("sodium chloride obtained from mines or by the evaporation of sea water.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Salt = 13,
        [System.ComponentModel.Description("tiny grains of crushed or worn rock.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Sand = 14,
        [System.ComponentModel.Description("wood prepared for use in building or carpentry.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Timber = 15,
        [System.ComponentModel.Description("powdery fragments of wood made in sawing timber or coarse chips produced for use in manufacturing pressed board.")]
        [System.Xml.Serialization.XmlEnum("16")]
        SawdustWoodChips = 16,
        [System.ComponentModel.Description("discarded metal suitable for being reprocessed.")]
        [System.Xml.Serialization.XmlEnum("17")]
        ScrapMetal = 17,
        [System.ComponentModel.Description("a compressed gas consisting of flammable light hydrocarbons and derived from natural gas.")]
        [System.Xml.Serialization.XmlEnum("18")]
        LiquifiedNaturalGasLng = 18,
        [System.ComponentModel.Description("a compressed gas consisting of flammable light hydrocarbons and derived from petroleum.")]
        [System.Xml.Serialization.XmlEnum("19")]
        LiquifiedPetroleumGasLpg = 19,
        [System.ComponentModel.Description("the fermanted juice of grapes.")]
        [System.Xml.Serialization.XmlEnum("20")]
        Wine = 20,
        [System.ComponentModel.Description("a substance made of powdered lime and clay, mixed with water.")]
        [System.Xml.Serialization.XmlEnum("21")]
        Cement = 21,
        [System.ComponentModel.Description("a small hard seed, especially that of any cereal plant such as wheat, rice, corn, rye etc.")]
        [System.Xml.Serialization.XmlEnum("22")]
        Grain = 22,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum qualityOfPosition : int
    {
        [System.ComponentModel.Description("the position(s) was(were) determined by the operation of making measurements for determining the relative position of points on, above or beneath the earth's surface. Survey implies a regular, controlled survey of any date.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Surveyed = 1,
        [System.ComponentModel.Description("survey data is does not exist or is very poor.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Unsurveyed = 2,
        [System.ComponentModel.Description("position data is of a very poor quality.")]
        [System.Xml.Serialization.XmlEnum("3")]
        InadequatelySurveyed = 3,
        [System.ComponentModel.Description("a position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to an object whose position does not remain fixed.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Approximate = 4,
        [System.ComponentModel.Description("an object whose position has been reported but which is considered to be doubtful.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PositionDoubtful = 5,
        [System.ComponentModel.Description("an object's position obtained from questionable or unreliable data.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Unreliable = 6,
        [System.ComponentModel.Description("an object whose position has been reported and its position confirmed by some means other than a formal survey such as an independent report of the same object.")]
        [System.Xml.Serialization.XmlEnum("7")]
        ReportedNotSurveyed = 7,
        [System.ComponentModel.Description("an object whose position has been reported and its position has not been confirmed.")]
        [System.Xml.Serialization.XmlEnum("8")]
        ReportedNotConfirmed = 8,
        [System.ComponentModel.Description("the most probable position of an object determined from incomplete data or data of questionable accuracy.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Estimated = 9,
        [System.ComponentModel.Description("a position that is of a known value, such as the position of an anchor berth or other defined object.")]
        [System.Xml.Serialization.XmlEnum("10")]
        PreciselyKnown = 10,
        [System.ComponentModel.Description("a position that is computed from data.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Calculated = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum qualityOfSoundingMeasurement : int
    {
        [System.ComponentModel.Description("the depth from chart datum to the bottom is a known value.")]
        [System.Xml.Serialization.XmlEnum("1")]
        DepthKnown = 1,
        [System.ComponentModel.Description("the depth from chart datum to the bottom is unknown.")]
        [System.Xml.Serialization.XmlEnum("2")]
        DepthOrLeastDepthUnknown = 2,
        [System.ComponentModel.Description("a depth that may be less than indicated.")]
        [System.Xml.Serialization.XmlEnum("3")]
        DoubtfulSounding = 3,
        [System.ComponentModel.Description("a depth that is considered to be an unreliable value.")]
        [System.Xml.Serialization.XmlEnum("4")]
        UnreliableSounding = 4,
        [System.ComponentModel.Description("upon investigation the bottom was not found at this depth.")]
        [System.Xml.Serialization.XmlEnum("5")]
        NoBottomFoundAtValueShown = 5,
        [System.ComponentModel.Description("the shoalest depth over a feature is of known value.")]
        [System.Xml.Serialization.XmlEnum("6")]
        LeastDepthKnown = 6,
        [System.ComponentModel.Description("the least depth over a feature is unknown, but there is considered to be safe clearance at this depth.")]
        [System.Xml.Serialization.XmlEnum("7")]
        LeastDepthUnknownSafeClearanceAtDepthShown = 7,
        [System.ComponentModel.Description("depth value obtained from a report, but not fully surveyed.")]
        [System.Xml.Serialization.XmlEnum("8")]
        ValueReportedNotSurveyed = 8,
        [System.ComponentModel.Description("depth value obtained from a report, which it has not been possible to confirm.")]
        [System.Xml.Serialization.XmlEnum("9")]
        ValueReportedNotConfirmed = 9,
        [System.ComponentModel.Description("the depth at which a channel is kept by human influence, usually by dredging.")]
        [System.Xml.Serialization.XmlEnum("10")]
        MaintainedDepth = 10,
        [System.ComponentModel.Description("depths may be altered by human influence, but will not be routinely maintained.")]
        [System.Xml.Serialization.XmlEnum("11")]
        NotRegularlyMaintained = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum radarConspicuous : int
    {
        [System.ComponentModel.Description("an object which returns a strong radar echo.")]
        [System.Xml.Serialization.XmlEnum("1")]
        RadarConspicuous = 1,
        [System.ComponentModel.Description("an object which does not return a particularly strong radar echo.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NotRadarConspicuous = 2,
        [System.ComponentModel.Description("an object which returns a strong radar echo, having a radar reflector.")]
        [System.Xml.Serialization.XmlEnum("3")]
        RadarConspicuousHasRadarReflector = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum signalGeneration : int
    {
        [System.ComponentModel.Description("signal generation is initiated by a self regulating mechanism such as a timer or light sensor.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Automatically = 1,
        [System.ComponentModel.Description("the signal is generated by the motion of the sea surface such as a bell in a buoy.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ByWaveAction = 2,
        [System.ComponentModel.Description("the signal is generated by a manually operated mechanism such as a hand cranked siren.")]
        [System.Xml.Serialization.XmlEnum("3")]
        ByHand = 3,
        [System.ComponentModel.Description("the signal is generated by the motion of air such as a wind driven whistle.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ByWind = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum status : int
    {
#pragma warning restore CS8981
        [System.ComponentModel.Description("intended to last or function indefinitely.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Permanent = 1,
        [System.ComponentModel.Description("acting on special occasions happening irregularly.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Occasional = 2,
        [System.ComponentModel.Description("presented as worthy of confidence, acceptance, use, etc.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Recommended = 3,
        [System.ComponentModel.Description("no longer used for the purpose intended disused.")]
        [System.Xml.Serialization.XmlEnum("4")]
        NotInUse = 4,
        [System.ComponentModel.Description("recurring at intervals.")]
        [System.Xml.Serialization.XmlEnum("5")]
        PeriodicIntermittent = 5,
        [System.ComponentModel.Description("set apart for some specific use.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Reserved = 6,
        [System.ComponentModel.Description("meant to last only for a time.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Temporary = 7,
        [System.ComponentModel.Description("not in public ownership or operation.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Private = 8,
        [System.ComponentModel.Description("compulsory enforced.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Mandatory = 9,
        [System.ComponentModel.Description("no longer lit")]
        [System.Xml.Serialization.XmlEnum("11")]
        Extinguished = 11,
        [System.ComponentModel.Description("lit by floodlights, strip lights, etc.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Illuminated = 12,
        [System.ComponentModel.Description("famous in history of historical interest.")]
        [System.Xml.Serialization.XmlEnum("13")]
        Historic = 13,
        [System.ComponentModel.Description("belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
        [System.Xml.Serialization.XmlEnum("14")]
        Public = 14,
        [System.ComponentModel.Description("occur at a time, coincide in point of time, be contemporary or simultaneous.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Synchronized = 15,
        [System.ComponentModel.Description("looked at or observed over a period of time especially so as to be aware of any movement or change.")]
        [System.Xml.Serialization.XmlEnum("16")]
        Watched = 16,
        [System.ComponentModel.Description("usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
        [System.Xml.Serialization.XmlEnum("17")]
        UnWatched = 17,
        [System.ComponentModel.Description("an object that has been reported but has not been definitely determined to exist.")]
        [System.Xml.Serialization.XmlEnum("18")]
        ExistenceDoubtful = 18,
        [System.ComponentModel.Description("made certain as to truth, accuracy, validity, availability, etc.")]
        [System.Xml.Serialization.XmlEnum("29")]
        Confirmed = 29,
        [System.ComponentModel.Description("Item selected for an action")]
        [System.Xml.Serialization.XmlEnum("30")]
        Candidate = 30,
        [System.ComponentModel.Description("Item that is in the process of being modified")]
        [System.Xml.Serialization.XmlEnum("31")]
        UnderModification = 31,
        [System.ComponentModel.Description("Item selected for modification")]
        [System.Xml.Serialization.XmlEnum("32")]
        CandidateForModification = 32,
        [System.ComponentModel.Description("Item in the process of being removed or deleted")]
        [System.Xml.Serialization.XmlEnum("33")]
        UnderRemovalDeletion = 33,
        [System.ComponentModel.Description("Item that has been removed or deleted")]
        [System.Xml.Serialization.XmlEnum("34")]
        RemovedDeleted = 34,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum techniqueOfSoundingMeasurement : int
    {
        [System.ComponentModel.Description("the depth was determined by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.")]
        [System.Xml.Serialization.XmlEnum("1")]
        FoundByEchoSounder = 1,
        [System.ComponentModel.Description("the depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the bottom and generate a record of the bottom configuration.")]
        [System.Xml.Serialization.XmlEnum("2")]
        FoundBySideScanSonar = 2,
        [System.ComponentModel.Description("the depth was determined by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.")]
        [System.Xml.Serialization.XmlEnum("3")]
        FoundByMultiBeam = 3,
        [System.ComponentModel.Description("the depth was determined by a person skilled in the practice of diving.")]
        [System.Xml.Serialization.XmlEnum("4")]
        FoundByDiver = 4,
        [System.ComponentModel.Description("the depth was determined by using a line, graduated with attached marks and fastened to a sounding lead.")]
        [System.Xml.Serialization.XmlEnum("5")]
        FoundByLeadLine = 5,
        [System.ComponentModel.Description("the given area was determined to be free from navigational dangers to a certain depth by towing a buoyed wire at the desired depth by two launches, or a least depth was identified using the same technique.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SweptByWireDrag = 6,
        [System.ComponentModel.Description("the depth was determined by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
        [System.Xml.Serialization.XmlEnum("7")]
        FoundByLaser = 7,
        [System.ComponentModel.Description("the given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.")]
        [System.Xml.Serialization.XmlEnum("8")]
        SweptByVerticalAcousticSystem = 8,
        [System.ComponentModel.Description("the depth was determined by using an instrument that compares electromagnetic signals.")]
        [System.Xml.Serialization.XmlEnum("9")]
        FoundByElectromagneticSensor = 9,
        [System.ComponentModel.Description("the depth was determined by applying mathematical techniques to photographs.")]
        [System.Xml.Serialization.XmlEnum("10")]
        Photogrammetry = 10,
        [System.ComponentModel.Description("the depth was determined by using instruments placed aboard an artificial satellite.")]
        [System.Xml.Serialization.XmlEnum("11")]
        SatelliteImagery = 11,
        [System.ComponentModel.Description("the depth was determined by using levelling techniques to find the elevation of the point relative to a datum.")]
        [System.Xml.Serialization.XmlEnum("12")]
        FoundByLevelling = 12,
        [System.ComponentModel.Description("the given area was determined to be free from navigational dangers to a certain depth by towing a side-scan-sonar.")]
        [System.Xml.Serialization.XmlEnum("13")]
        SweptBySideScanSonar = 13,
        [System.ComponentModel.Description("the sounding was determined from a bottom model constructed using a computer.")]
        [System.Xml.Serialization.XmlEnum("14")]
        ComputerGenerated = 14,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum topmarkDaymarkShape : int
    {
        [System.ComponentModel.Description("is where the vertex points up. A cone is a solid figure generated by straight lines drawn from a fixed point (the vertex) to a circle in a plane not containing the vertex. Cones are commonly used as International Association of Lighthouse Authorities - IALA topmarks lateral.")]
        [System.Xml.Serialization.XmlEnum("1")]
        ConePointUp = 1,
        [System.ComponentModel.Description("is where the vertex points down. A cone is a solid figure generated by straight lines drawn from a fixed point (the vertex) to a circle in a plane not containing the vertex. Cones are commonly used as International Association of Lighthouse Authorities - IALA topmarks lateral.")]
        [System.Xml.Serialization.XmlEnum("2")]
        ConePointDown = 2,
        [System.ComponentModel.Description("a body the surface of which is at all points equidistant from the centre. Spheres are commonly used as International Association of Lighthouse Authorities - IALA topmarks safe water.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Sphere = 3,
        [System.ComponentModel.Description("two black spheres are commonly used as an International Association of Lighthouse Authorities - IALA topmark (isolated danger).")]
        [System.Xml.Serialization.XmlEnum("4")]
        twoSpheres = 4,
        [System.ComponentModel.Description("a solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, it's ends being parallel circles). Cylinders are commonly used as International Association of Lighthouse Authorities - IALA topmarks lateral.")]
        [System.Xml.Serialization.XmlEnum("5")]
        CylinderCan = 5,
        [System.ComponentModel.Description("usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Board = 6,
        [System.ComponentModel.Description("having a shape or a cross-section like the capital letter X. An x-shape as an International Association of Lighthouse Authorities - IALA topmark should be 3 dimensional in shape. It is made of at least three crossed bars.")]
        [System.Xml.Serialization.XmlEnum("7")]
        XShapeStAndrewSCross = 7,
        [System.ComponentModel.Description("a cross with one vertical member and one horizontal member, i.e. similar in shape to the character '+'.")]
        [System.Xml.Serialization.XmlEnum("8")]
        UprightCrossStGeorgeSCross = 8,
        [System.ComponentModel.Description("a cube standing on one of its vertexes. A cube is a solid contained by six equal squares a regular hexahedron (The New Shorter Oxford English Dictionary. 1993. vol 2)")]
        [System.Xml.Serialization.XmlEnum("9")]
        CubePointUp = 9,
        [System.ComponentModel.Description("2 cones, one above the other, with their vertices together in the centre.")]
        [System.Xml.Serialization.XmlEnum("10")]
        twoConesPointToPoint = 10,
        [System.ComponentModel.Description("2 cones, one above the other, with their bases together in the centre and their vertices pointing up and down.")]
        [System.Xml.Serialization.XmlEnum("11")]
        twoConesBaseToBase = 11,
        [System.ComponentModel.Description("a plane figure having four equal sides and equal opposite angles (two acute and two obtuse) an oblique equilateral parallelogram.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Rhombus = 12,
        [System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing up.")]
        [System.Xml.Serialization.XmlEnum("13")]
        twoConesPointsUpward = 13,
        [System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing down.")]
        [System.Xml.Serialization.XmlEnum("14")]
        twoConesPointsDownward = 14,
        [System.ComponentModel.Description("besom: a bundle of rods or twigs. perch: a staff placed on top of a buoy, rock or shoal as a mark for navigation.")]
        [System.Xml.Serialization.XmlEnum("15")]
        BesomPointUpBroomOrPerch = 15,
        [System.ComponentModel.Description("besom: a bundle of rods or twigs. perch: a staff placed on top of a buoy, rock or shoal as a mark for navigation.")]
        [System.Xml.Serialization.XmlEnum("16")]
        BesomPointDownBroomOrPerch = 16,
        [System.ComponentModel.Description("a flag mounted on a short pole.")]
        [System.Xml.Serialization.XmlEnum("17")]
        Flag = 17,
        [System.ComponentModel.Description("A sphere located above a rhombus.")]
        [System.Xml.Serialization.XmlEnum("18")]
        SphereOverRhombus = 18,
        [System.ComponentModel.Description("a plane figure with four right angles and four equal straight sides")]
        [System.Xml.Serialization.XmlEnum("19")]
        Square = 19,
        [System.ComponentModel.Description("a rectangle is a plane figure with four right angles and four straight sides, opposite sides being parallel and equal in length . A horizontal rectangle is where the two longer opposite sides are standing horizontally.")]
        [System.Xml.Serialization.XmlEnum("20")]
        RectangleHorizontal = 20,
        [System.ComponentModel.Description("a rectangle is a plane figure with four right angles and four straight sides, opposite sides being parallel and equal in length. A vertical rectangle is where the two longer opposite sides are standing vertically.")]
        [System.Xml.Serialization.XmlEnum("21")]
        RectangleVertical = 21,
        [System.ComponentModel.Description("which stands on its longer parallel side. A trapezium is a quadrilateral having one pair of opposite sides parallel.")]
        [System.Xml.Serialization.XmlEnum("22")]
        TrapeziumUp = 22,
        [System.ComponentModel.Description("which stands on its shorter parallel side. A trapezium is a quadrilateral having one pair of opposite sides parallel.")]
        [System.Xml.Serialization.XmlEnum("23")]
        TrapeziumDown = 23,
        [System.ComponentModel.Description("A triangle, point up. A triangle is a figure having three angles and three sides.")]
        [System.Xml.Serialization.XmlEnum("24")]
        TrianglePointUp = 24,
        [System.ComponentModel.Description("A triangle, point down. A triangle is a figure having three angles and three sides.")]
        [System.Xml.Serialization.XmlEnum("25")]
        TrianglePointDown = 25,
        [System.ComponentModel.Description("a perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
        [System.Xml.Serialization.XmlEnum("26")]
        Circle = 26,
        [System.ComponentModel.Description("two upright crosses, generally vertically disposed one above the other.")]
        [System.Xml.Serialization.XmlEnum("27")]
        TwoUprightCrossesOneOverTheOther = 27,
        [System.ComponentModel.Description("having a shape like the capital letter T.")]
        [System.Xml.Serialization.XmlEnum("28")]
        TShape = 28,
        [System.ComponentModel.Description("a triangle, vertex uppermost, located above a circle.")]
        [System.Xml.Serialization.XmlEnum("29")]
        TrianglePointingUpOverACircle = 29,
        [System.ComponentModel.Description("an upright cross located above a circle.")]
        [System.Xml.Serialization.XmlEnum("30")]
        UprightCrossOverACircle = 30,
        [System.ComponentModel.Description("a rhombus located above a circle.")]
        [System.Xml.Serialization.XmlEnum("31")]
        RhombusOverACircle = 31,
        [System.ComponentModel.Description("a circle located over a triangle, vertex uppermost.")]
        [System.Xml.Serialization.XmlEnum("32")]
        CircleOverATrianglePointingUp = 32,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("33")]
        OtherShapeSeeInform = 33,
        [System.ComponentModel.Description("Having the form of or consisting of a tube.")]
        [System.Xml.Serialization.XmlEnum("34")]
        Tubular = 34,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum trafficFlow : int
    {
        [System.ComponentModel.Description("traffic flow in a general direction toward a port or similar destination.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Inbound = 1,
        [System.ComponentModel.Description("traffic flow in a general direction away from a port or similar point of origin.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Outbound = 2,
        [System.ComponentModel.Description("traffic flow in one general direction only.")]
        [System.Xml.Serialization.XmlEnum("3")]
        OneWay = 3,
        [System.ComponentModel.Description("traffic flow in two generally opposite directions.")]
        [System.Xml.Serialization.XmlEnum("4")]
        TwoWay = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum verticalDatum : int
    {
        [System.ComponentModel.Description("(MLWS) - the average height of the low waters of spring tides.")]
        [System.Xml.Serialization.XmlEnum("1")]
        MeanLowWaterSprings = 1,
        [System.ComponentModel.Description("(MLLWS) - the average height of lower low water springs at a place.")]
        [System.Xml.Serialization.XmlEnum("2")]
        MeanLowerLowWaterSprings = 2,
        [System.ComponentModel.Description("(MSL) - the average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MeanSeaLevel = 3,
        [System.ComponentModel.Description("an arbitrary level conforming to the lowest tide observed at a place, or some what lower.")]
        [System.Xml.Serialization.XmlEnum("4")]
        LowestLowWater = 4,
        [System.ComponentModel.Description("(MLW) - the average height of all low waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("5")]
        MeanLowWater = 5,
        [System.ComponentModel.Description("an arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
        [System.Xml.Serialization.XmlEnum("6")]
        LowestLowWaterSprings = 6,
        [System.ComponentModel.Description("an arbitrary level, usually within ' 0.3m from that of mean low water springs (MLWS).")]
        [System.Xml.Serialization.XmlEnum("7")]
        ApproximateMeanLowWaterSprings = 7,
        [System.ComponentModel.Description("(ISLW) - an arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides.")]
        [System.Xml.Serialization.XmlEnum("8")]
        IndianSpringLowWater = 8,
        [System.ComponentModel.Description("an arbitrary level, approximating that of mean low water springs (MLWS).")]
        [System.Xml.Serialization.XmlEnum("9")]
        LowWaterSprings = 9,
        [System.ComponentModel.Description("an arbitrary level, usually within ' 0.3m from that of lowest astronomical tide (LAT).")]
        [System.Xml.Serialization.XmlEnum("10")]
        ApproximateLowestAstronomicalTide = 10,
        [System.ComponentModel.Description("an arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian spring low water (ISLW).")]
        [System.Xml.Serialization.XmlEnum("11")]
        NearlyLowestLowWater = 11,
        [System.ComponentModel.Description("(MLLW) - the average height of the lower low waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("12")]
        MeanLowerLowWater = 12,
        [System.ComponentModel.Description("an approximation of mean low water adopted as the reference level for a limited area, irrespective of better determinations at a later date.")]
        [System.Xml.Serialization.XmlEnum("13")]
        LowWater = 13,
        [System.ComponentModel.Description("an arbitrary level, usually within ' 0.3m from that of mean low water (MLW).")]
        [System.Xml.Serialization.XmlEnum("14")]
        ApproximateMeanLowWater = 14,
        [System.ComponentModel.Description("an arbitrary level, usually within ' 0.3m from that of mean lower low water (MLLW).")]
        [System.Xml.Serialization.XmlEnum("15")]
        ApproximateMeanLowerLowWater = 15,
        [System.ComponentModel.Description("(MHW) - the average height of all high waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("16")]
        MeanHighWater = 16,
        [System.ComponentModel.Description("(MHWS) - the average height of the high waters of spring tides.")]
        [System.Xml.Serialization.XmlEnum("17")]
        MeanHighWaterSprings = 17,
        [System.ComponentModel.Description("the highest level reached at a place by the water surface in one tidal cycle.")]
        [System.Xml.Serialization.XmlEnum("18")]
        HighWater = 18,
        [System.ComponentModel.Description("an arbitrary level, usually within ' 0.3m from that of mean sea level (MSL).")]
        [System.Xml.Serialization.XmlEnum("19")]
        ApproximateMeanSeaLevel = 19,
        [System.ComponentModel.Description("an arbitrary level, approximating that of mean high water springs (MHWS).")]
        [System.Xml.Serialization.XmlEnum("20")]
        HighWaterSprings = 20,
        [System.ComponentModel.Description("(MHHW) - the average height of higher high waters at a place over a 19-year period.")]
        [System.Xml.Serialization.XmlEnum("21")]
        MeanHigherHighWater = 21,
        [System.ComponentModel.Description("the level of low water springs near the time of an equinox.")]
        [System.Xml.Serialization.XmlEnum("22")]
        EquinoctialSpringLowWater = 22,
        [System.ComponentModel.Description("(LAT) - the lowest tide level which can be predicted to occur under average meterological conditions and under any combination of astronomical conditions.")]
        [System.Xml.Serialization.XmlEnum("23")]
        LowestAstronomicalTide = 23,
        [System.ComponentModel.Description("an arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        [System.Xml.Serialization.XmlEnum("24")]
        LocalDatum = 24,
        [System.ComponentModel.Description("(IGLD 1985) - a vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-P??re, Quebec, over the period 1970 to 1988.")]
        [System.Xml.Serialization.XmlEnum("25")]
        InternationalGreatLakesDatum1985 = 25,
        [System.ComponentModel.Description("the average of all hourly water levels over the available period of record.")]
        [System.Xml.Serialization.XmlEnum("26")]
        MeanWaterLevel = 26,
        [System.ComponentModel.Description("(LLWLT) - the average of the lowest low waters, one from each of 19 years of observations.")]
        [System.Xml.Serialization.XmlEnum("27")]
        LowerLowWaterLargeTide = 27,
        [System.ComponentModel.Description("(HHWLT) - the average of the highest high waters, one from each of 19 years of observations.")]
        [System.Xml.Serialization.XmlEnum("28")]
        HigherHighWaterLargeTide = 28,
        [System.ComponentModel.Description("an arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
        [System.Xml.Serialization.XmlEnum("29")]
        NearlyHighestHighWater = 29,
        [System.ComponentModel.Description("the highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        [System.Xml.Serialization.XmlEnum("30")]
        HighestAstronomicalTideHat = 30,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum visuallyConspicuous : int
    {
        [System.ComponentModel.Description("term applied to an object either natural or artificial which is distinctly and notably visible from seaward.")]
        [System.Xml.Serialization.XmlEnum("1")]
        VisuallyConspicuous = 1,
        [System.ComponentModel.Description("an object which is visible from seaward, but is not conspicuous.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NotVisuallyConspicuous = 2,
    }

    [System.SerializableAttribute()]
    public class categoryOfAggregation
    {
        [System.Xml.Serialization.XmlTextAttribute()]
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.SerializableAttribute()]
    public class categoryOfAssociation
    {
        [System.Xml.Serialization.XmlTextAttribute()]
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    public static class CodeList
    {
        public static ImmutableArray<categoryOfAggregation> categoryOfAggregations => ImmutableArray.Create<categoryOfAggregation>(new categoryOfAggregation[] { new() { code = 1, definition = "A line passing through two or more clearly defined charted objects, and along which a vessel can approach safely.", label = "leading line", }, new() { code = 2, definition = "Two or more objects in line. Such objects are said to be in range. An observer having them in range is said to be on the range.", label = "range system", }, new() { code = 3, definition = "A course at sea, whose ends are indicated by ranges ashore, and whose length has been accurately measured for determining the speed of vessels.", label = "measured distance", }, });
        public static ImmutableArray<categoryOfAssociation> categoryOfAssociations => ImmutableArray.Create<categoryOfAssociation>(new categoryOfAssociation[] { new() { code = 1, definition = "A group of channel marks which indicate channel limits", label = "channel markings", }, new() { code = 2, definition = "One or more aids to navigation and the danger(s) they mark", label = "danger markings", }, });
    }

    namespace ComplexAttributes
    {
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class changeDetails
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public buoyChange? buoyChange { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required lightChange lightChange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required beaconChange beaconChange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required leadingLightsChange leadingLightsChange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required fogSignals fogSignals { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required radioAidsChange radioAidsChange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required atonCommissioning atonCommissioning { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required atonReplacement atonReplacement { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required atonRemoval atonRemoval { get; set; }

            public changeDetails()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class contactAddress
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public List<String> deliveryPoint { get; set; } = new();

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String cityName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String administrativeDivision { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String country { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String postalCode { get; set; } = string.Empty;

            public contactAddress()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class surveyDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required DateOnly dateEnd { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public DateOnly? dateStart { get; set; } = default;

            public surveyDateRange()
            {
            }
        }
    }

    namespace InformationTypes
    {
        using ComplexAttributes;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class AtoNStatusInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required changeDetails changeDetails { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public changeTypes? changeTypes { get; set; } = default;

            public AtoNStatusInformation()
            {
                changeDetails = new changeDetails()
                {
                    lightChange = default(lightChange),
                    beaconChange = default(beaconChange),
                    leadingLightsChange = default(leadingLightsChange),
                    fogSignals = default(fogSignals),
                    radioAidsChange = default(radioAidsChange),
                    atonCommissioning = default(atonCommissioning),
                    atonReplacement = default(atonReplacement),
                    atonRemoval = default(atonRemoval),
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SpatialUncertainty
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public qualityOfPosition? qualityOfPosition { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public Decimal? positionalAccuracy { get; set; } = default;

            public SpatialUncertainty()
            {
            }
        }
    }

    namespace FeatureTypes
    {
        using ComplexAttributes;
        using InformationTypes;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Aggregation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required categoryOfAggregation categoryOfAggregation { get; set; }

            public Aggregation()
            {
                categoryOfAggregation = new categoryOfAggregation()
                {
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class Association
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required categoryOfAssociation categoryOfAssociation { get; set; }

            public Association()
            {
                categoryOfAssociation = new categoryOfAssociation()
                {
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DataCoverage
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required Int32 maximumDisplayScale { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required Int32 minimumDisplayScale { get; set; }

            public DataCoverage()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class LocalDirectionOfBuoyage
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required Decimal orientation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public Int32? scaleMinimum { get; set; } = default;

            public LocalDirectionOfBuoyage()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class NavigationalSystemOfMarks
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required marksNavigationalSystemOf marksNavigationalSystemOf { get; set; }

            public NavigationalSystemOfMarks()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class QualityOfNonBathymetricData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required categoryOfTemporalVariation categoryOfTemporalVariation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public Decimal? directionUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public Decimal? horizontalDistanceUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required Decimal horizontalPositionUncertainty { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String information { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String informationInNationalLanguage { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String textualDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public String textualDescriptionInNationalLanguage { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public Decimal? verticalUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public surveyDateRange? surveyDateRange { get; set; }

            public QualityOfNonBathymetricData()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class SoundingDatum
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required verticalDatum verticalDatum { get; set; }

            public SoundingDatum()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class VerticalDatumOfData
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required verticalDatum verticalDatum { get; set; }

            public VerticalDatumOfData()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class AidsToNavigation
        {
            public AidsToNavigation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class Equipment : AidsToNavigation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public required aidAvailabilityCategory aidAvailabilityCategory { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S201/1.0")]
            public contactAddress? contactAddress { get; set; }

            public Equipment()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class StructureObject : AidsToNavigation
        {
            public StructureObject()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class GenericBeacon : StructureObject
        {
            public GenericBeacon()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S201/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S201/1.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class GenericBuoy : StructureObject
        {
            public GenericBuoy()
            {
            }
        }
    }
}