using System;
using System.Collections.Immutable;
using System.Linq;


namespace S100Framework.DomainModel.S124
{

    public static class Information
    {
        public static Version Version => new Version("1.5");

        public static string[] ComplexTypes => [
            "featureName",
            "dateTimeRange",
            "eNCFeatureReference",
            "featureReference",
            "fixedDateRange",
            "information",
            "warningInformation",
            "chartAffected",
            "affectedChartPublications",
            "locationName",
            "generalArea",
            "locality",
            "messageSeriesIdentifier",
            "nAVWARNTitle",
        ];

        public static string[] InformationTypes => [
            "NAVWARNPreamble",
            "References",
        ];

        public static string[] FeatureTypes => [
            "NAVWARNPart",
            "NAVWARNAreaAffected",
            "TextPlacement",
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum textType : int
    {
        [System.ComponentModel.Description("The individual name of a feature.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Name = 1,

        [System.ComponentModel.Description("The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LightCharacteristic = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum nameUsage : int
    {
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
        [System.Xml.Serialization.XmlEnum("1")]
        DefaultNameDisplay = 1,

        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
        [System.Xml.Serialization.XmlEnum("2")]
        AlternateNameDisplay = 2,

        [System.ComponentModel.Description("The name or text is not intended to be displayed.")]
        [System.Xml.Serialization.XmlEnum("3")]
        NoChartDisplay = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
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

        [System.ComponentModel.Description("An area within which excavating a hole on the sea-bottom with a drill is prohibited.")]
        [System.Xml.Serialization.XmlEnum("20")]
        DrillingProhibited = 20,

        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the sea-bottom with a drill is restricted in accordance with certain specified conditions.")]
        [System.Xml.Serialization.XmlEnum("21")]
        DrillingRestricted = 21,

        [System.ComponentModel.Description("An area within which the removal of historical artefacts is prohibited.")]
        [System.Xml.Serialization.XmlEnum("22")]
        RemovalOfHistoricalArtefactsProhibited = 22,

        [System.ComponentModel.Description("An area in which cargo transhipment (lightening) is prohibited.")]
        [System.Xml.Serialization.XmlEnum("23")]
        CargoTranshipmentLighteningProhibited = 23,

        [System.ComponentModel.Description("An area in which the dragging of anything along the bottom, e.g. bottom trawling, is prohibited.")]
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

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking is generally prohibited.")]
        [System.Xml.Serialization.XmlEnum("28")]
        OvertakingProhibited = 28,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking between convoys is prohibited.")]
        [System.Xml.Serialization.XmlEnum("29")]
        OvertakingOfConvoysByConvoysProhibited = 29,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which passing or overtaking is generally prohibited.")]
        [System.Xml.Serialization.XmlEnum("30")]
        PassingOrOvertakingProhibited = 30,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not berth.")]
        [System.Xml.Serialization.XmlEnum("31")]
        BerthingProhibited = 31,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which berthing is restricted.")]
        [System.Xml.Serialization.XmlEnum("32")]
        BerthingRestricted = 32,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not make fast to the bank.")]
        [System.Xml.Serialization.XmlEnum("33")]
        MakingFastProhibited = 33,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which making fast to the bank is restricted.")]
        [System.Xml.Serialization.XmlEnum("34")]
        MakingFastRestricted = 34,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which all turning is generally prohibited.")]
        [System.Xml.Serialization.XmlEnum("35")]
        TurningProhibited = 35,

        [System.ComponentModel.Description("An area within which the fairway depth is restricted.")]
        [System.Xml.Serialization.XmlEnum("36")]
        RestrictedFairwayDepth = 36,

        [System.ComponentModel.Description("An area within which the fairway width is restricted.")]
        [System.Xml.Serialization.XmlEnum("37")]
        RestrictedFairwayWidth = 37,

        [System.ComponentModel.Description("The use of anchoring spuds (telescopic piles) is prohibited.")]
        [System.Xml.Serialization.XmlEnum("38")]
        UseOfSpudsProhibited = 38,

        [System.ComponentModel.Description("An area in which swimming is prohibited.")]
        [System.Xml.Serialization.XmlEnum("39")]
        SwimmingProhibited = 39,

        [System.ComponentModel.Description("An area within which the emission of SOx is restricted.")]
        [System.Xml.Serialization.XmlEnum("40")]
        SoxEmissionRestricted = 40,

        [System.ComponentModel.Description("An area within which the emission of NOx is restricted.")]
        [System.Xml.Serialization.XmlEnum("41")]
        NoxEmissionRestricted = 41,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum warningType : int
    {
        [System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a local area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.(Adopted from S-53, 2.2.23) Local warning means a navigational warning which covers inshore waters, often within the limits of jurisdiction of a harbour or port authority. (Adopted from S-53, 2.2.10)")]
        [System.Xml.Serialization.XmlEnum("1")]
        LocalNavigationalWarning = 1,

        [System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a coastal  area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended. Coastal warning means a navigational warning promulgated as part of a numbered series by a National Coordinator.")]
        [System.Xml.Serialization.XmlEnum("2")]
        CoastalNavigationalWarning = 2,

        [System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a sub-area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended. Sub-area warning means a navigational warning or in-force bulletin promulgated as part of a numbered series by a Sub-area Coordinator.")]
        [System.Xml.Serialization.XmlEnum("3")]
        SubAreaNavigationalWarning = 3,

        [System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a NAVAREA, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended. NAVAREA warning means a navigational warning promulgated as part of a numbered series by a NAVAREA Coordinator.")]
        [System.Xml.Serialization.XmlEnum("4")]
        NavareaNavigationalWarning = 4,

        [System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the NAVAREA.")]
        [System.Xml.Serialization.XmlEnum("5")]
        NavareaNoWarning = 5,

        [System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the sub-area.")]
        [System.Xml.Serialization.XmlEnum("6")]
        SubAreaNoWarning = 6,

        [System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the coastal area.")]
        [System.Xml.Serialization.XmlEnum("7")]
        CoastalNoWarning = 7,

        [System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the local area.")]
        [System.Xml.Serialization.XmlEnum("8")]
        LocalNoWarning = 8,

        [System.ComponentModel.Description("A list of serial numbers of NAVAREA warnings which are in- force.")]
        [System.Xml.Serialization.XmlEnum("9")]
        NavareaInForceBulletin = 9,

        [System.ComponentModel.Description("A list of serial numbers of sub-area warnings which are in-force.")]
        [System.Xml.Serialization.XmlEnum("10")]
        SubAreaInForceBulletin = 10,

        [System.ComponentModel.Description("A list of serial numbers of coastal warnings which are in- force.")]
        [System.Xml.Serialization.XmlEnum("11")]
        CoastalInForceBulletin = 11,

        [System.ComponentModel.Description("A list of serial numbers of local warnings which are in- force.")]
        [System.Xml.Serialization.XmlEnum("12")]
        LocalInForceBulletin = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum referenceCategory : int
    {
        [System.ComponentModel.Description("Cancellation of warning which is no longer valid.")]
        [System.Xml.Serialization.XmlEnum("1")]
        WarningCancellation = 1,

        [System.ComponentModel.Description("Reference to relevant warning.")]
        [System.Xml.Serialization.XmlEnum("2")]
        WarningReference = 2,

        [System.ComponentModel.Description("Reference to warnings or notices that are considered in-force.")]
        [System.Xml.Serialization.XmlEnum("3")]
        InForce = 3,
    }


    [System.Serializable()]
    public class navwarnTypeDetails
    {
        [System.Xml.Serialization.XmlText()]
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class navwarnTypeGeneral
    {
        [System.Xml.Serialization.XmlText()]
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    public static class CodeList
    {
        public static ImmutableArray<navwarnTypeDetails> navwarnTypeDetails => ImmutableArray.Create<navwarnTypeDetails>(new navwarnTypeDetails[]{
            new() {
                code = 1,
                definition = "The temporary or permanent installation of an acoustical instrument in the marine environment for the purpose of tracking the behavior of marine mammals or to monitor their ecosystems.",
                label = "Acoustic Recorder",
            },
            new() {
                code = 2,
                definition = "A new AIS has been or will be established for a limited period of time.",
                label = "AIS Temporary Establishment",
            },
            new() {
                code = 3,
                definition = "A new AIS site has been or will be established.",
                label = "AIS Transmitter Establishment",
            },
            new() {
                code = 4,
                definition = "The terrestrial AIS transmitter is operating as advertised.",
                label = "AIS Transmitter Operating Properly",
            },
            new() {
                code = 5,
                definition = "The terrestrial AIS transmitter is inoperative due to a technical issue.",
                label = "AIS Transmitter Out Of Service",
            },
            new() {
                code = 6,
                definition = "AIS transmitter has been or will be permanently removed from service.",
                label = "AIS Transmitter Removal",
            },
            new() {
                code = 7,
                definition = "AIS transmitter has been or will be temporarily removed from service.",
                label = "AIS Transmitter Temporary Removal",
            },
            new() {
                code = 8,
                definition = "The terrestrial AIS transmitter is unreliable due to a technical issue or maintenance.",
                label = "AIS Transmitter Unreliable",
            },
            new() {
                code = 9,
                definition = "All aids to navigation on a structure or in an area are unreliable due to environmental impact, equipment failure, etc.",
                label = "All Aids To Navigation Unreliable",
            },
            new() {
                code = 10,
                definition = "A large scale activity where multiple vessels, surveillance aircraft, and shore-based personnel practice a response to the discharge of a pollutant from a ship (or shore) into the marine environment, in order to evaluate the effectiveness of response capability.",
                label = "Anti Pollution Exercise",
            },
            new() {
                code = 11,
                definition = "A real time response by vessels, surveillance aircraft, and shore-based personnel to resolve the discharge of a pollutant from a ship (or shore) into the marine environment.",
                label = "Anti Pollution Operation",
            },
            new() {
                code = 12,
                definition = "The installation of infrastructure at a new location where the farming of fish, shellfish and aquatic plants in fresh or salt water is undertaken; and, failures at these locations where the infrastructure is reported damaged and may be adrift.",
                label = "Aquaculture Site",
            },
            new() {
                code = 13,
                definition = "The outage/failure has been corrected and the aids to navigation has resumed normal operation.",
                label = "AtoN Operating Properly",
            },
            new() {
                code = 14,
                definition = "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be changed.",
                label = "Audible Signal Change",
            },
            new() {
                code = 15,
                definition = "A new audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be established.",
                label = "Audible Signal Establishment",
            },
            new() {
                code = 16,
                definition = "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is operating as advertised.",
                label = "Audible Signal Operating Properly",
            },
            new() {
                code = 17,
                definition = "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is inoperative.",
                label = "Audible Signal Out Of Service",
            },
            new() {
                code = 18,
                definition = "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be permanently removed from service.",
                label = "Audible Signal Removal",
            },
            new() {
                code = 19,
                definition = "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be temporarily changed.",
                label = "Audible Signal Temporary Change",
            },
            new() {
                code = 20,
                definition = "A new audible signal has been or will be established for a limited period of time.",
                label = "Audible Signal Temporary Establishment",
            },
            new() {
                code = 21,
                definition = "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be temporarily removed from service.",
                label = "Audible Signal Temporary Removal",
            },
            new() {
                code = 22,
                definition = "Ice routeing information provided by a recognized authority.",
                label = "Authorized Ice Routeing Information",
            },
            new() {
                code = 23,
                definition = "The characteristics of the beacon have been or will be changed.",
                label = "Beacon Change",
            },
            new() {
                code = 24,
                definition = "The beacon has sustained damage due to external factors (wind, sea state, collision with a vessel).",
                label = "Beacon Damaged",
            },
            new() {
                code = 25,
                definition = "Colour of the beacon daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",
                label = "Beacon Daymark Unreliable",
            },
            new() {
                code = 26,
                definition = "A new beacon has been or will be established.",
                label = "Beacon Establishment",
            },
            new() {
                code = 27,
                definition = "No beacon at the advertised position.",
                label = "Beacon Missing",
            },
            new() {
                code = 28,
                definition = "Beacon has been or will be permanently removed from service.",
                label = "Beacon Removal",
            },
            new() {
                code = 29,
                definition = "The beacon has been restored to normal condition.",
                label = "Beacon Restored To Normal",
            },
            new() {
                code = 30,
                definition = "The characteristics of the beacon have been or will be temporarily changed.",
                label = "Beacon Temporary Change",
            },
            new() {
                code = 31,
                definition = "A new beacon has been or will be established for a limited period of time.",
                label = "Beacon Temporary Establishment",
            },
            new() {
                code = 32,
                definition = "Beacon has been or will be temporarily removed from service.",
                label = "Beacon Temporary Removal",
            },
            new() {
                code = 33,
                definition = "The topmark of the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Beacon Topmark Damaged",
            },
            new() {
                code = 34,
                definition = "The topmark of the beacon is missing.",
                label = "Beacon Topmark Missing",
            },
            new() {
                code = 35,
                definition = "An explosive detonation was observed at sea or blasting operation is scheduled to occur.",
                label = "Blasting Operation",
            },
            new() {
                code = 36,
                definition = "The construction of a structure protecting a shore area, harbour, or anchorage from waves.",
                label = "Breakwater Construction",
            },
            new() {
                code = 37,
                definition = "The published horizontal clearance of the fixed or opening bridge has changed.",
                label = "Bridge Horizontal Clearance Change",
            },
            new() {
                code = 38,
                definition = "The functionality of an opening bridge is compromised. The bridge will remain open.",
                label = "Bridge Unable To Close",
            },
            new() {
                code = 39,
                definition = "The functionality of an opening bridge is compromised. The bridge will remain closed.",
                label = "Bridge Unable To Open",
            },
            new() {
                code = 40,
                definition = "The published vertical clearance of the fixed or opening bridge has changed.",
                label = "Bridge Vertical Clearance Change",
            },
            new() {
                code = 41,
                definition = "The buoy is no longer secured to its moorings and is adrift.",
                label = "Buoy Adrift",
            },
            new() {
                code = 42,
                definition = "The characteristics of the buoy have been or will be changed.",
                label = "Buoy Change",
            },
            new() {
                code = 43,
                definition = "A buoy which was in ice over the winter and has been verified undamaged and in advertised position for the navigational season",
                label = "Buoy Commissioned for Navigation Season",
            },
            new() {
                code = 44,
                definition = "The buoy has been damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Buoy Damaged",
            },
            new() {
                code = 45,
                definition = "Colour of the buoy daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",
                label = "Buoy Daymark Unreliable",
            },
            new() {
                code = 46,
                definition = "A buoy which remains in the water over winter but which is declared unreliable (may be impacted by ice movement).",
                label = "Buoy Decommissioned for Winter",
            },
            new() {
                code = 47,
                definition = "The buoy has suffered extensive damage and is not useable.",
                label = "Buoy Destroyed",
            },
            new() {
                code = 48,
                definition = "A new buoy has been or will be established.",
                label = "Buoy Establishment",
            },
            new() {
                code = 49,
                definition = "No buoy at its advertised/charted position or in the vicinity.",
                label = "Buoy Missing",
            },
            new() {
                code = 50,
                definition = "The buoy has been or will be moved intentionally.",
                label = "Buoy Move",
            },
            new() {
                code = 51,
                definition = "The buoy has been dragged off its advertised position due to wind or current affecting the mooring system.",
                label = "Buoy off Position",
            },
            new() {
                code = 52,
                definition = "The re-establishment of a buoy which was previously announced either destroyed or temporarily removed.",
                label = "Buoy Re-established",
            },
            new() {
                code = 53,
                definition = "Buoy has been or will be permanently removed from service.",
                label = "Buoy Removal",
            },
            new() {
                code = 54,
                definition = "A buoy which has been removed and it&apos;s location is now marked by a winter spar buoy.",
                label = "Buoy Replaced by Winter Spar",
            },
            new() {
                code = 55,
                definition = "The buoy has been restored to normal condition.",
                label = "Buoy Restored to Normal",
            },
            new() {
                code = 56,
                definition = "The characteristics of the buoy have been or will be temporarily changed.",
                label = "Buoy Temporary Change",
            },
            new() {
                code = 57,
                definition = "A new buoy has been or will be established for a limited period of time.",
                label = "Buoy Temporary Establishment",
            },
            new() {
                code = 58,
                definition = "Buoy has been or will be temporarily removed from service.",
                label = "Buoy Temporary Removal",
            },
            new() {
                code = 59,
                definition = "The topmark of the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Buoy Topmark Damaged",
            },
            new() {
                code = 60,
                definition = "The topmark of the buoy is missing.",
                label = "Buoy Topmark Missing",
            },
            new() {
                code = 61,
                definition = "The buoy has been scheduled for removal from service for a fixed term.",
                label = "Buoy Will Be Withdrawn",
            },
            new() {
                code = 62,
                definition = "The buoy has been removed from service for a fixed term.",
                label = "Buoy Withdrawn",
            },
            new() {
                code = 63,
                definition = "A buoy has been withdrawn for the winter season.",
                label = "Buoy Withdrawn for Winter",
            },
            new() {
                code = 64,
                definition = "Operations being undertaken to lay wires, fibres, wire rope or chains underwater or to bury them beneath the sea floor.",
                label = "Cable Laying Operation",
            },
            new() {
                code = 65,
                definition = "Underwater operations undertaken to maintain or repair a submarine cable.",
                label = "Cable Operations",
            },
            new() {
                code = 66,
                definition = "The Chayka station is operating as advertised.",
                label = "Chayka Operating Properly",
            },
            new() {
                code = 67,
                definition = "The Chayka station is inoperative due to a technical issue.",
                label = "Chayka Out Of Service",
            },
            new() {
                code = 68,
                definition = "Chayka station has been or will be permanently removed from service.",
                label = "Chayka Station Removal",
            },
            new() {
                code = 69,
                definition = "Chayka station has been or will be temporarily removed from service.",
                label = "Chayka Station Temporary Removal",
            },
            new() {
                code = 70,
                definition = "The Chayka station is unreliable due to a technical issue or maintenance.",
                label = "Chayka Unreliable",
            },
            new() {
                code = 71,
                definition = "A large concentration of fishing vessels in a small area which may interfere with, hamper, or reduce the ability of another vessel to navigate safely.",
                label = "Cluster of Fishing Vessels",
            },
            new() {
                code = 72,
                definition = "A cargo container which has fallen overboard and is reported adrift.",
                label = "Container Adrift",
            },
            new() {
                code = 73,
                definition = "A wreck submerged at such a depth as to be considered dangerous to surface navigation.",
                label = "Dangerous Wreck",
            },
            new() {
                code = 74,
                definition = "A deceased marine mammal, typically a whale, reported adrift.",
                label = "Dead Whale Adrift",
            },
            new() {
                code = 75,
                definition = "A log which, becoming saturated with water, will start to sink at the heavier end, such that it floats vertically or nearly vertically in the water.",
                label = "Deadhead Adrift",
            },
            new() {
                code = 76,
                definition = "Any vessel abandoned at sea of sufficient size as to pose a hazard to safe navigation.",
                label = "Derelict Vessel Adrift",
            },
            new() {
                code = 77,
                definition = "The DGLONASS station is operating as advertised.",
                label = "DGLONASS Operating Properly",
            },
            new() {
                code = 78,
                definition = "The DGLONASS station is inoperative due to a technical issue.",
                label = "DGLONASS Out Of Service",
            },
            new() {
                code = 79,
                definition = "A new DGLONASS station has been or will be established.",
                label = "DGLONASS Station Establishment",
            },
            new() {
                code = 80,
                definition = "The DGLONASS station is unreliable due to a technical issue or maintenance.",
                label = "DGLONASS Unreliable",
            },
            new() {
                code = 81,
                definition = "The DGPS station is operating as advertised.",
                label = "DGPS Operating Properly",
            },
            new() {
                code = 82,
                definition = "The DGPS station is inoperative due to a technical issue.",
                label = "DGPS Out Of Service",
            },
            new() {
                code = 83,
                definition = "A new DGPS station has been or will be established.",
                label = "DGPS Station Establishment",
            },
            new() {
                code = 84,
                definition = "DGPS station has been or will be permanently removed from service.",
                label = "DGPS Station Removal",
            },
            new() {
                code = 85,
                definition = "DGPS station has been or will be temporarily removed from service.",
                label = "DGPS Station Temporary Removal",
            },
            new() {
                code = 86,
                definition = "The DGPS station is unreliable due to a technical issue or maintenance.",
                label = "DGPS Unreliable",
            },
            new() {
                code = 87,
                definition = "A location where divers are conducting any type of activity at or below the surface of the water.",
                label = "Diving Operation",
            },
            new() {
                code = 88,
                definition = "A structure, formerly attached along the shoreline or extending from the shore into a body of water to which vessels moor, which has broken free of its moorings and is adrift.",
                label = "Dock Adrift",
            },
            new() {
                code = 89,
                definition = "Works in order to increase depth.",
                label = "Dredging Operation",
            },
            new() {
                code = 90,
                definition = "A drill rig is under tow.",
                label = "Drill Rig Under Tow",
            },
            new() {
                code = 91,
                definition = "A drill rig/drill ship has commenced operations at the specified location offshore.",
                label = "Drilling Site Operations",
            },
            new() {
                code = 92,
                definition = "The e-Chayka station is operating as advertised.",
                label = "E-Chayka Operating Properly",
            },
            new() {
                code = 93,
                definition = "The e-Chayka station is inoperative due to a technical issue.",
                label = "E-Chayka Out Of Service",
            },
            new() {
                code = 94,
                definition = "A new e-Chayka station has been or will be established.",
                label = "E-Chayka Station Establishment",
            },
            new() {
                code = 95,
                definition = "The e-Chayka station has been or will be permanently removed from service.",
                label = "E-Chayka Station Removal",
            },
            new() {
                code = 96,
                definition = "The e-Chayka station has been or will be temporarily removed from service",
                label = "E-Chayka Station Temporary Removal",
            },
            new() {
                code = 97,
                definition = "The e-Chayka station is unreliable due to a technical issue or maintenance.",
                label = "E-Chayka Unreliable",
            },
            new() {
                code = 98,
                definition = "Any failure or return to operation of an EGC service offered by a recognized mobile satellite service provider.",
                label = "EGC MSI Service",
            },
            new() {
                code = 99,
                definition = "The EGNOS station is operating as advertised.",
                label = "EGNOS Operating Properly",
            },
            new() {
                code = 100,
                definition = "The EGNOS station is inoperative due to a technical issue.",
                label = "EGNOS Out Of Service",
            },
            new() {
                code = 101,
                definition = "A new EGNOS station has been or will be established.",
                label = "EGNOS Station Establishment",
            },
            new() {
                code = 102,
                definition = "EGNOS station has been or will be permanently removed from service.",
                label = "EGNOS Station Removal",
            },
            new() {
                code = 103,
                definition = "EGNOS station has been or will be temporarily removed from service.",
                label = "EGNOS Station Temporary Removal",
            },
            new() {
                code = 104,
                definition = "The EGNOS station is unreliable due to a technical issue or maintenance.",
                label = "EGNOS Unreliable",
            },
            new() {
                code = 105,
                definition = "The eLORAN station is operating as advertised.",
                label = "ELORAN Operating Properly",
            },
            new() {
                code = 106,
                definition = "The eLORAN station is inoperative due to a technical issue.",
                label = "ELORAN Out Of Service",
            },
            new() {
                code = 107,
                definition = "A new eLORAN station has been or will be established.",
                label = "ELORAN Station Establishment",
            },
            new() {
                code = 108,
                definition = "The eLORAN station has been or will be permanently removed from service.",
                label = "ELORAN Station Removal",
            },
            new() {
                code = 109,
                definition = "The eLORAN station has been or will be temporarily removed from service.",
                label = "ELORAN Station Temporary Removal",
            },
            new() {
                code = 110,
                definition = "The eLORAN station is unreliable due to a technical issue or maintenance.",
                label = "ELORAN Unreliable",
            },
            new() {
                code = 111,
                definition = "An established marine area, temporary or permanent in nature, where vessel traffic is prohibited." + Environment.NewLine +
"A geographical area, within which all other vessels should remain clear unless authorised.",
                label = "Exclusion Zone",
            },
            new() {
                code = 112,
                definition = "Unexploded explosive devices.",
                label = "Explosive Device",
            },
            new() {
                code = 113,
                definition = "The light on the fairway marker is no longer synchronized with another light or group of lights.",
                label = "Fairway Marker - Light Not Synchronized",
            },
            new() {
                code = 114,
                definition = "The light on the fairway marker is inoperative.",
                label = "Fairway Marker - Light Unlit",
            },
            new() {
                code = 115,
                definition = "The operation of the light on the fairway marker is unreliable due to technical problems.",
                label = "Fairway Marker - Light Unreliable",
            },
            new() {
                code = 116,
                definition = "The fairway marker has been damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Fairway Marker Damaged",
            },
            new() {
                code = 117,
                definition = "The fairway marker has suffered extensive damage and is not useable.",
                label = "Fairway Marker Destroyed",
            },
            new() {
                code = 118,
                definition = "The area of which remains hazardous to life after an explosive detonation or the fallout from a rocket launch or space debris.",
                label = "Fallout Hazard",
            },
            new() {
                code = 119,
                definition = "Scheduled public display of pyrotechnics, usually ignited from barges located just offshore, and often accompanied by music.",
                label = "Fireworks",
            },
            new() {
                code = 120,
                definition = "An exercise within a defined area which includes the firing of weapon systems during training or testing that may affect safety at sea.",
                label = "Firing Exercise",
            },
            new() {
                code = 121,
                definition = "A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.",
                label = "Fish Aggregating Device",
            },
            new() {
                code = 122,
                definition = "A fishing net (seine, purse, gill, trawl, bag or other), reported adrift, of sufficient size to pose a hazard to safe navigation.",
                label = "Fishing Net Adrift",
            },
            new() {
                code = 123,
                definition = "A concentration of floating objects, which by the nature of their size and material, could pose a hazard to safe navigation.",
                label = "Floating Debris",
            },
            new() {
                code = 124,
                definition = "The flood light illuminating the beacon is inoperative.",
                label = "Floodlit Beacon - Unlit",
            },
            new() {
                code = 125,
                definition = "The characteristics of the fog signal have been or will be changed.",
                label = "Fog Signal Change",
            },
            new() {
                code = 126,
                definition = "A new fog signal has been or will be established.",
                label = "Fog Signal Establishment",
            },
            new() {
                code = 127,
                definition = "The fog signal is operating as advertised.",
                label = "Fog Signal Operating Properly",
            },
            new() {
                code = 128,
                definition = "The fog signal is inoperative.",
                label = "Fog Signal Out Of Service",
            },
            new() {
                code = 129,
                definition = "Fog signal has been or will be permanently removed from service.",
                label = "Fog Signal Removal",
            },
            new() {
                code = 130,
                definition = "The characteristics of the fog signal have been or will be temporarily changed.",
                label = "Fog Signal Temporary Change",
            },
            new() {
                code = 131,
                definition = "A new fog signal has been or will be established for a limited period of time.",
                label = "Fog Signal Temporary Establishment",
            },
            new() {
                code = 132,
                definition = "Fog signal has been or will be temporarily removed from service.",
                label = "Fog Signal Temporary Removal",
            },
            new() {
                code = 133,
                definition = "The synchronization of the leading lights is abnormal / The synchronization of the range lights is abnormal.",
                label = "Front and Rear Lights out of Synchronization",
            },
            new() {
                code = 134,
                definition = "The front leading beacon has been restored to normal condition. / The front range beacon has been restored to normal condition.",
                label = "Front Beacon Restored to Normal",
            },
            new() {
                code = 135,
                definition = "The front leading beacon is damaged, obscured or missing. / The front range beacon is damaged, obscured or missing.",
                label = "Front Beacon Unreliable",
            },
            new() {
                code = 136,
                definition = "The front leading light is operating as advertised. / The front range light is operating as advertised.",
                label = "Front Light is Operating Properly",
            },
            new() {
                code = 137,
                definition = "The nominal range of the front leading light is reduced. / The nominal range of the front range light is reduced.",
                label = "Front Light Range Reduced",
            },
            new() {
                code = 138,
                definition = "The front leading light is extinguished. / The front range light is extinguished.",
                label = "Front Light Unlit",
            },
            new() {
                code = 139,
                definition = "The operation of the front leading light is unreliable due to technical problems. / The operation of the front range light is unreliable due to technical problems.",
                label = "Front Light Unreliable",
            },
            new() {
                code = 140,
                definition = "Due to technical problems front leading light has no rhythm and is in fixed light mode. / Due to technical problems front range light has no rhythm and is in fixed light mode.",
                label = "Front Light Without Rhythm",
            },
            new() {
                code = 141,
                definition = "The quality of service of a global navigation satellite system is poor due to an internal or external cause (e.g. jamming, space weather).",
                label = "GNSS Degradation",
            },
            new() {
                code = 142,
                definition = "An area which may contain known or unknown navigational hazards which could impact the safe navigation.",
                label = "Hazardous Area",
            },
            new() {
                code = 143,
                definition = "An outage, or return to operation, of an HF service (radiotelephone, digital selective calling or narrow band directing printing telegraphy).",
                label = "HF Service",
            },
            new() {
                code = 144,
                definition = "High water level, potentially over a sustained period of time, such as with extreme weather or river freshet.",
                label = "High Water Level",
            },
            new() {
                code = 145,
                definition = "The reduction in the horizontal distance or navigable width of a canal, channel, lock, etc.",
                label = "Horizontal Clearance Reduced",
            },
            new() {
                code = 146,
                definition = "Activity of vessels or drones/MASS, restricted in their ability to maneuver, engaged in towing of surface or subsurface scientific instruments to gather data on the measurements of subsurface features.",
                label = "Hydrographic Survey Activity",
            },
            new() {
                code = 147,
                definition = "A notice concerning the installation (or removal) of floating barriers, anchored to the bottom, used to deflect the path of floating ice in order to prevent the obstruction of locks, intakes, etc., and to prevent damage to bridge piers and other structures.",
                label = "Ice Boom - Installation or Removal",
            },
            new() {
                code = 148,
                definition = "Information concerning when a designated ice control zone is in force or deactivated. If in-force, mariners must follow established procedures for safe navigation.",
                label = "Ice Control Zone In-Force or Deactivated",
            },
            new() {
                code = 149,
                definition = "An iceberg which is reported outside of the advertised limits of ice.",
                label = "Iceberg Outside Advertised Limits",
            },
            new() {
                code = 150,
                definition = "An exercise in which the signals of radio navigation aids, radars or radio services are disrupted by an intentional cause for training purposes.",
                label = "Jamming Exercise",
            },
            new() {
                code = 151,
                definition = "The light on the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Light Buoy - Light Damaged",
            },
            new() {
                code = 152,
                definition = "The light on the buoy is no longer synchronized with another light or group of lights.",
                label = "Light Buoy - Light Not Synchronized",
            },
            new() {
                code = 153,
                definition = "The light on the buoy is extinguished.",
                label = "Light Buoy - Light Unlit",
            },
            new() {
                code = 154,
                definition = "The operation of the light on the buoy is unreliable due to technical problems.",
                label = "Light Buoy - Light Unreliable",
            },
            new() {
                code = 155,
                definition = "The characteristics of the light have been or will be changed.",
                label = "Light Change",
            },
            new() {
                code = 156,
                definition = "The light daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",
                label = "Light Daymark Unreliable",
            },
            new() {
                code = 157,
                definition = "A new light has been or will be established.",
                label = "Light Establishment",
            },
            new() {
                code = 158,
                definition = "The light is operating as advertised",
                label = "Light Operating Properly",
            },
            new() {
                code = 159,
                definition = "The light is no longer synchronized with another light or group of lights.",
                label = "Light Out Of Synchronization",
            },
            new() {
                code = 160,
                definition = "The nominal range of the light is less than the advertised range.",
                label = "Light Range Reduced",
            },
            new() {
                code = 161,
                definition = "The re-establishment of a light which was previously announced as either destroyed or temporarily removed.",
                label = "Light Re-Establishment",
            },
            new() {
                code = 162,
                definition = "Light has been or will be permanently removed from service.",
                label = "Light Removal",
            },
            new() {
                code = 163,
                definition = "The light on the spar buoy is damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Light Spar Buoy - Light Damaged",
            },
            new() {
                code = 164,
                definition = "The light on the spar buoy is no longer synchronized with another light or group of lights.",
                label = "Light Spar Buoy - Light Not Synchronized",
            },
            new() {
                code = 165,
                definition = "The light on the spar buoy is extinguished.",
                label = "Light Spar Buoy - Light Unlit",
            },
            new() {
                code = 166,
                definition = "The operation of the light on the spar buoy is unreliable due to technical problems.",
                label = "Light Spar Buoy - Light Unreliable",
            },
            new() {
                code = 167,
                definition = "The characteristics of the light have been or will be temporarily changed.",
                label = "Light Temporary Change",
            },
            new() {
                code = 168,
                definition = "A new light has been or will be established for a limited period of time.",
                label = "Light Temporary Establishment",
            },
            new() {
                code = 169,
                definition = "Light has been or will be temporarily removed from service.",
                label = "Light Temporary Removal",
            },
            new() {
                code = 170,
                definition = "The light is extinguished.",
                label = "Light Unlit",
            },
            new() {
                code = 171,
                definition = "The light is unreliable due to technical problems.",
                label = "Light Unreliable",
            },
            new() {
                code = 172,
                definition = "Due to technical problems the light has no more rhythm and is in fixed light mode.",
                label = "Light Without Rhythm",
            },
            new() {
                code = 173,
                definition = "The light on the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Lighted Beacon - Light Damaged",
            },
            new() {
                code = 174,
                definition = "The light on the beacon is no longer synchronized with another light or group of lights.",
                label = "Lighted Beacon - Light Not Synchronized",
            },
            new() {
                code = 175,
                definition = "The light of the beacon is extinguished.",
                label = "Lighted Beacon - Light Unlit",
            },
            new() {
                code = 176,
                definition = "The operation of the light on the beacon is unreliable due to technical problems.",
                label = "Lighted Beacon - Light Unreliable",
            },
            new() {
                code = 177,
                definition = "Notice issued by local health authorities to persons ashore or at sea.",
                label = "Local Health Authority Notice",
            },
            new() {
                code = 178,
                definition = "Lock operation is compromised. The lock is closed.",
                label = "Lock Closed",
            },
            new() {
                code = 179,
                definition = "A log is a tree, stripped of its branches and roots, which is floating horizontally and barely awash.",
                label = "Log Adrift",
            },
            new() {
                code = 180,
                definition = "One or more sections of a chained log boom has broken free of its tow and is adrift.",
                label = "Log Boom Adrift",
            },
            new() {
                code = 181,
                definition = "The LORAN C station is operating as advertised.",
                label = "LORAN C - Operating Properly",
            },
            new() {
                code = 182,
                definition = "The LORAN C station is inoperative due to a technical issue.",
                label = "LORAN C - Out Of Service",
            },
            new() {
                code = 183,
                definition = "The LORAN C station is unreliable due to a technical issue or maintenance.",
                label = "LORAN C - Unreliable",
            },
            new() {
                code = 184,
                definition = "LORAN C station has been or will be permanently removed from service.",
                label = "LORAN C Station Removal",
            },
            new() {
                code = 185,
                definition = "LORAN C station has been or will be temporarily removed from service.",
                label = "LORAN C Station Temporary Removal",
            },
            new() {
                code = 186,
                definition = "Low water level, potentially over a sustained period of time, such as with extreme weather.",
                label = "Low Water Level",
            },
            new() {
                code = 187,
                definition = "The position or status of Marine Aids to Navigation, over an extensive area, is unreliable due to a natural event (freshet, storm surge, flooding).",
                label = "Marine Aids to Navigation Unreliable",
            },
            new() {
                code = 188,
                definition = "The raising or lowering of the national, regional or port-specific maritime security level within a country.",
                label = "Maritime Security Level Changes",
            },
            new() {
                code = 189,
                definition = "Any outage or return to operation of a MF service (radiotelephone, digital selective calling or narrow band directing printing).",
                label = "MF Service",
            },
            new() {
                code = 190,
                definition = "An exercise comprised of multiple vessels and/or aircraft used to train and asses operational capacity and strategy without actual live combat.",
                label = "Military Exercise",
            },
            new() {
                code = 191,
                definition = "A military response to a specific event or situation.",
                label = "Military Operation",
            },
            new() {
                code = 192,
                definition = "An outage of a maritime safety information broadcast service (satellite or terrestrial system).",
                label = "MSI Service",
            },
            new() {
                code = 193,
                definition = "Notice issued by a national health authority to persons ashore or at sea.",
                label = "National Health Authority Notice",
            },
            new() {
                code = 194,
                definition = "Any failure or return to service of the International or National NAVTEX broadcast services.",
                label = "NAVTEX Service Change",
            },
            new() {
                code = 195,
                definition = "New or updated maritime regulation which may impact navigation such as changes to navigation lanes or newly established areas to be avoided.",
                label = "New or Amended Regulation",
            },
            new() {
                code = 196,
                definition = "There are many fishing vessels operating in the area.",
                label = "Numerous Fishing Vessels",
            },
            new() {
                code = 197,
                definition = "Object reported adrift and posing a hazard to safe navigation.",
                label = "Object Adrift",
            },
            new() {
                code = 198,
                definition = "Changes to offshore rig/platforms, either fixed or floating, used for oil/gas production, exploration, research, observation, etc.",
                label = "Offshore Rigs or Platform Changes",
            },
            new() {
                code = 199,
                definition = "The temporary or permanent closing or re-opening of a harbour.",
                label = "Opening or Closing of Harbour",
            },
            new() {
                code = 200,
                definition = "The failure, or return to operation, of the opening or closing of swing bridges.",
                label = "Opening or Closing of Swing Bridge",
            },
            new() {
                code = 201,
                definition = "The temporary closing or re-opening of waters, e.g. waterway, bay, straits.",
                label = "Opening or Closing of Waters",
            },
            new() {
                code = 202,
                definition = "Activity comprised of one or more vessels engaged in the laying of pipe on or beneath the sea floor.",
                label = "Pipe Laying Operation",
            },
            new() {
                code = 203,
                definition = "Underwater operations undertaken to maintain or repair a submarine pipe.",
                label = "Pipe Operations",
            },
            new() {
                code = 204,
                definition = "There are fishing vessels using long fishing gear, such as fishing net and long fishing lines.",
                label = "Presence of Long Fishing Gear",
            },
            new() {
                code = 205,
                definition = "Presence of marine mammals is expected.",
                label = "Presence of Marine Mammals",
            },
            new() {
                code = 206,
                definition = "Self-contained explosive device, either floating or submerged, which could be triggered by the approach or contact with a vessel or submarine.",
                label = "Presence of Naval Mines",
            },
            new() {
                code = 207,
                definition = "A fishing net (seine, purse, gill, trawl, bag or other), reported submerged, or partially submerged, of sufficient size to pose a hazard to safe navigation.",
                label = "Presence of Submerged Fishing Net",
            },
            new() {
                code = 208,
                definition = "Presence of a buoy or object deployed to gather scientific information.",
                label = "Presence of Scientific Equipment",
            },
            new() {
                code = 209,
                definition = "The characteristics of the RACON have been or will be changed.",
                label = "RACON Change",
            },
            new() {
                code = 210,
                definition = "A new RACON has been or will be established.",
                label = "RACON Establishment",
            },
            new() {
                code = 211,
                definition = "The RACON is operating as advertised.",
                label = "RACON Operating Properly",
            },
            new() {
                code = 212,
                definition = "The RACON is inoperative.",
                label = "RACON Out Of Service",
            },
            new() {
                code = 213,
                definition = "RACON has been or will be permanently removed from service.",
                label = "RACON Removal",
            },
            new() {
                code = 214,
                definition = "The characteristics of the RACON have been or will be temporarily changed.",
                label = "RACON Temporary Change",
            },
            new() {
                code = 215,
                definition = "A new RACON has been or will be established for a limited period of time.",
                label = "RACON Temporary Establishment",
            },
            new() {
                code = 216,
                definition = "RACON has been or will be temporarily removed from service.",
                label = "RACON Temporary Removal",
            },
            new() {
                code = 217,
                definition = "The RACON is unreliable due to a technical issue or maintenance.",
                label = "RACON Unreliable",
            },
            new() {
                code = 218,
                definition = "Any failure or return to service of radar in an advertised radar-monitored area which may impact the ability of maritime authorities to track and monitor the movement of vessels.",
                label = "Radar Surveillance System Service Change",
            },
            new() {
                code = 219,
                definition = "The characteristics of the RAMARK have been or will be changed.",
                label = "RAMARK Change",
            },
            new() {
                code = 220,
                definition = "A new RAMARK has been or will be established.",
                label = "RAMARK Establishment",
            },
            new() {
                code = 221,
                definition = "The RAMARK is operating as advertised.",
                label = "RAMARK Operating Properly",
            },
            new() {
                code = 222,
                definition = "The RAMARK is inoperative.",
                label = "RAMARK Out Of Service",
            },
            new() {
                code = 223,
                definition = "RAMARK has been or will be permanently removed from service.",
                label = "RAMARK removal",
            },
            new() {
                code = 224,
                definition = "The characteristics of the RAMARK have been or will be temporarily changed.",
                label = "RAMARK Temporary Change",
            },
            new() {
                code = 225,
                definition = "A new RAMARK has been or will be established for a limited period of time.",
                label = "RAMARK Temporary Establishment",
            },
            new() {
                code = 226,
                definition = "RAMARK has been or will be temporarily removed from service.",
                label = "RAMARK Temporary Removal",
            },
            new() {
                code = 227,
                definition = "The RAMARK is unreliable due to a technical issue or maintenance.",
                label = "RAMARK Unreliable",
            },
            new() {
                code = 228,
                definition = "The rear leading beacon has been restored to normal condition. / The rear range beacon has been restored to normal condition.",
                label = "Rear Beacon Restored to Normal",
            },
            new() {
                code = 229,
                definition = "The rear leading beacon is damaged, obscured or missing. / The rear range beacon is damaged, obscured or missing",
                label = "Rear Beacon Unreliable",
            },
            new() {
                code = 230,
                definition = "The rear leading light is operating as advertised. / The rear range light is operating as advertised.",
                label = "Rear Light is Operating Properly",
            },
            new() {
                code = 231,
                definition = "The nominal range of the rear leading light is reduced. / The nominal range of the rear range light is reduced.",
                label = "Rear Light Range Reduced",
            },
            new() {
                code = 232,
                definition = "The rear leading light is extinguished. / The rear range light is extinguished.",
                label = "Rear Light Unlit",
            },
            new() {
                code = 233,
                definition = "The operation of the rear leading light is unreliable due to technical problems. / The operation of the rear range light is unreliable due to technical problems.",
                label = "Rear Light Unreliable",
            },
            new() {
                code = 234,
                definition = "Due to technical problems, the rear leading light has no rhythm and is in fixed light mode. / Due to technical problems rear range light has no rhythm and is in fixed light mode.",
                label = "Rear Light Without Rhythm",
            },
            new() {
                code = 235,
                definition = "A short or long race of sail, oar or power craft along a predetermined course which may approach or cross navigation lanes.",
                label = "Regatta or Race",
            },
            new() {
                code = 236,
                definition = "The installation, removal, failure or damage of renewable energy devices (Wind turbines/farms, ocean current or wave power plants) which pose a hazard to safe navigation.",
                label = "Renewable Energy Device or Farm Change",
            },
            new() {
                code = 237,
                definition = "A new or revised specified area, temporary or permanent in nature, designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.",
                label = "Restricted Area Changes",
            },
            new() {
                code = 238,
                definition = "Significant changes to the limits or depth of a known sandbar/sandspit, or the discovery of a new sandbar/sandspit, which poses a hazard to safe navigation.",
                label = "Sandspit or Sandbar Change",
            },
            new() {
                code = 239,
                definition = "A large scale activity where multiple vessels, surveillance aircraft, and shore-based personnel practice search and rescue techniques, in order to evaluate the effectiveness of response capability.",
                label = "SAR Exercise",
            },
            new() {
                code = 240,
                definition = "A real time response by vessels, surveillance aircraft, and shore-based personnel participating in an active search and rescue operation.",
                label = "SAR Operation",
            },
            new() {
                code = 241,
                definition = "A buoy fit for scientific purposes which has broken free of its moorings or has been left free and is adrift.",
                label = "Scientific Buoy Adrift",
            },
            new() {
                code = 242,
                definition = "A submerged platform where a scientific instrument is secured and which may or may not be secured to the sea floor by means of an anchor chain.",
                label = "Scientific Moorings",
            },
            new() {
                code = 243,
                definition = "An activity where one or more vessels, restricted in their ability to manoeuvre, navigate along a pre-determine grid pattern in order to collect scientific data.",
                label = "Scientific Survey",
            },
            new() {
                code = 244,
                definition = "Sea testing phase of a vessel.",
                label = "Sea Trials",
            },
            new() {
                code = 245,
                definition = "Activity within a defined area on the water where seaplanes are actively engaged in take-off, landing or taxiing.",
                label = "Seaplane Operations",
            },
            new() {
                code = 246,
                definition = "The completion of the process to place summer buoys (and the removal of any winter spar buoys).",
                label = "Seasonal Commissioning Complete",
            },
            new() {
                code = 247,
                definition = "The commencement of the process to place summer buoys (and the removal of any winter spar buoys).",
                label = "Seasonal Commissioning in Progress",
            },
            new() {
                code = 248,
                definition = "The completion of the process to remove summer buoys (and possibly replace some with winter spar buoys).",
                label = "Seasonal Decommissioning Complete",
            },
            new() {
                code = 249,
                definition = "The commencement of the process to remove summer buoys (and possibly replace some with winter spar buoys).",
                label = "Seasonal Decommissioning in Progress",
            },
            new() {
                code = 250,
                definition = "The light sector has been fully or partly obscured.",
                label = "Sector Light - Sector Obscured",
            },
            new() {
                code = 251,
                definition = "The characteristics of the sector light have been or will be changed.",
                label = "Sector Light Change",
            },
            new() {
                code = 252,
                definition = "The characteristics of the sector light have been or will be temporarily changed.",
                label = "Sector Light Temporary Change",
            },
            new() {
                code = 253,
                definition = "Changes to the national, regional or port-specific maritime security regulations.",
                label = "Security Regulation Change",
            },
            new() {
                code = 254,
                definition = "The commencement or cessation of the complex operations of a seismic survey.",
                label = "Seismic Survey Operation",
            },
            new() {
                code = 255,
                definition = "Confirmed significant change to the depth or position of a charted sounding/shoal, or the discovery of a new shoal, which poses a hazard to safe navigation.",
                label = "Shallow Depth Confirmed",
            },
            new() {
                code = 256,
                definition = "Reported significant change to the depth or position of a charted sounding/shoal, or the discovery of a new shoal, which poses a hazard to safe navigation.",
                label = "Shallow Depth Reported",
            },
            new() {
                code = 257,
                definition = "The spar buoy is no longer secured to its moorings and has gone adrift from its advertised position.",
                label = "Spar Buoy Adrift",
            },
            new() {
                code = 258,
                definition = "The spar buoy has been damaged due to external factors (wind, sea state, collision with a vessel).",
                label = "Spar Buoy Damaged",
            },
            new() {
                code = 259,
                definition = "The spar buoy has suffered extensive damage and is not useable.",
                label = "Spar Buoy Destroyed",
            },
            new() {
                code = 260,
                definition = "No spar buoy at its advertised position or in the vicinity.",
                label = "Spar Buoy Missing",
            },
            new() {
                code = 261,
                definition = "The spar buoy has been or will be moved intentionally.",
                label = "Spar Buoy Move",
            },
            new() {
                code = 262,
                definition = "The spar buoy has been dragged off its advertised position due to wind or current affecting the mooring system.",
                label = "Spar Buoy off Position",
            },
            new() {
                code = 263,
                definition = "The re-establishment of a spar buoy which was previously announced either destroyed or temporarily removed.",
                label = "Spar Buoy Re-established",
            },
            new() {
                code = 264,
                definition = "The spar buoy has been restored to normal condition.",
                label = "Spar Buoy Restored to Normal",
            },
            new() {
                code = 265,
                definition = "The topmark of the spar buoy is missing.",
                label = "Spar Buoy Topmark Missing",
            },
            new() {
                code = 266,
                definition = "The spar buoy has been removed from service for a fixed term.",
                label = "Spar Buoy Withdrawn",
            },
            new() {
                code = 267,
                definition = "A rise above normal water level on the open coast due only to the action of wind stress on the water surface. Storm surge resulting from a hurricane or other intense storm also includes the rise in level due to atmospheric pressure reduction as well as that due to wind stress. A storm surge is more severe when it occurs in conjunction with a high tide. Also called storm tide, storm wave, tidal wave.",
                label = "Storm Surge",
            },
            new() {
                code = 268,
                definition = "Change in status, location or depth of a submerged or seabed cable which poses a hazard to safe navigation, anchoring or fishing.",
                label = "Submarine Cable Changes",
            },
            new() {
                code = 269,
                definition = "Change in status, location or depth of a submerged or seabed pipeline which poses a hazard to safe navigation, anchoring or fishing.",
                label = "Submarine Pipeline Changes",
            },
            new() {
                code = 270,
                definition = "Any object under water; not showing above water.",
                label = "Submerged Object",
            },
            new() {
                code = 271,
                definition = "A mooring which is under water and which may or may not be secured to the sea floor by means of an anchor chain.",
                label = "Subsurface Mooring",
            },
            new() {
                code = 272,
                definition = "A single person or groups of persons will be / are swimming in or near navigation lanes.",
                label = "Swimmers",
            },
            new() {
                code = 273,
                definition = "The establishment of a buoy or group of buoys for a limited period of time (i.e. during summer season or during marine construction projects).",
                label = "Temporary Buoyage",
            },
            new() {
                code = 274,
                definition = "The installation or removal of a tide gauge.",
                label = "Tide Gauge Change",
            },
            new() {
                code = 275,
                definition = "An area is experiencing a significantly high volume of vessel traffic which could potentially impede the progress of a vessel.",
                label = "Traffic Congestion",
            },
            new() {
                code = 276,
                definition = "An alert message concerning strong waves, the widespread inundation of water, due to an earthquake, landslide or volcanic eruption, which is issued when the threat is imminent, expected or occurring.",
                label = "Tsunami Warning",
            },
            new() {
                code = 277,
                definition = "A newly located rock, submerged or partially submerged rock, which had not been previously charted.",
                label = "Uncharted Rock",
            },
            new() {
                code = 278,
                definition = "Underwater work to maintain or repair subsurface structures (e.g. drill head).",
                label = "Underwater Operations",
            },
            new() {
                code = 279,
                definition = "An unidentified radar target, within the advertised limits of ice, but not yet visually confirmed as being an iceberg.",
                label = "Unidentified Radar Target - Possible Iceberg",
            },
            new() {
                code = 280,
                definition = "A tow, which by the nature of the size, shape or dimensions of the object being towed, is cumbersome to effectively tow regardless of the conditions of the waterway.",
                label = "Unwieldy Tow",
            },
            new() {
                code = 281,
                definition = "The characteristics of the V-AIS have been or will be changed.",
                label = "V-AIS Change",
            },
            new() {
                code = 282,
                definition = "A new V-AIS has been or will be established.",
                label = "V-AIS Establishment",
            },
            new() {
                code = 283,
                definition = "Virtual AIS aid to navigation is operating as advertised.",
                label = "V-AIS Operating Properly",
            },
            new() {
                code = 284,
                definition = "Virtual AIS aid to navigation is extinguished.",
                label = "V-AIS Out Of Service",
            },
            new() {
                code = 285,
                definition = "V-AIS has been or will be permanently removed from service.",
                label = "V-AIS Removal",
            },
            new() {
                code = 286,
                definition = "The characteristics of the V-AIS have been or will be temporarily changed.",
                label = "V-AIS Temporary Change",
            },
            new() {
                code = 287,
                definition = "A new V-AIS has been or will be established for a limited period of time.",
                label = "V-AIS Temporary Establishment",
            },
            new() {
                code = 288,
                definition = "V-AIS has been or will be temporarily removed from service.",
                label = "V-AIS Temporary Removal",
            },
            new() {
                code = 289,
                definition = "Virtual AIS aid is unreliable due to a technical issue or maintenance.",
                label = "V-AIS Unreliable",
            },
            new() {
                code = 290,
                definition = "The reduction in the vertical distance between the air draft of a vessel and the lowest point on a bridge structure, cable or pipeline of which the vessel is intending to pass underneath.",
                label = "Vertical Clearance Reduced",
            },
            new() {
                code = 291,
                definition = "A vessel at sea or which has lost mechanical capability and cannot be moored or anchored.",
                label = "Vessel Adrift",
            },
            new() {
                code = 292,
                definition = "A vessel adrift at sea or safely anchored/moored, which has been damaged or has experienced some sort of mechanical or electrical failure so it can no longer sail.",
                label = "Vessel Disabled",
            },
            new() {
                code = 293,
                definition = "Any outage or return to operation of any VHF service (radiotelephone or digital selective calling).",
                label = "VHF Service Change",
            },
            new() {
                code = 294,
                definition = "Volcano activity impacting safe navigation.",
                label = "Volcano Activity",
            },
            new() {
                code = 295,
                definition = "Change to an existing vessel traffic service zone limit, procedure and or provision of broadcast service relating to vessels operating within that zone.",
                label = "VTS Change",
            },
            new() {
                code = 296,
                definition = "Temporary or permanent changes to a waterway/fairway which may render it unsafe/safe for marine traffic.",
                label = "Waterway Recommended or Not Recommended For Shipping",
            },
            new() {
                code = 297,
                definition = "The commencement or cessation of wharf construction.",
                label = "Wharf Construction",
            },
            new() {
                code = 298,
                definition = "An active marine project, either on the surface or under water, which may affect the navigation of vessels.",
                label = "Works in Progress",
            },
            new() {
                code = 299,
                definition = "Notice issued by World Health Organization to persons ashore or at sea.",
                label = "World Health Organization Notice",
            },
        });

        public static ImmutableArray<navwarnTypeGeneral> navwarnTypeGenerals => ImmutableArray.Create<navwarnTypeGeneral>(new navwarnTypeGeneral[]{
            new() {
                code = 1,
                definition = "Any casualties to lights, fog signals, buoys and other aids to navigation affecting shipping; establishment of major new aids to navigation or significant changes to existing ones, when such establishment or change might be misleading to shipping.",
                label = "Aids to Navigation Changes",
            },
            new() {
                code = 2,
                definition = "New or established aquaculture and fishing installations.",
                label = "Aquaculture and Fishing Installations",
            },
            new() {
                code = 3,
                definition = "Drifting hazards, including derelict ships, containers, other large items, etc.",
                label = "Drifting Hazards",
            },
            new() {
                code = 4,
                definition = "Operating anomalies identified within ECDIS, including issues with official data.",
                label = "ECDIS Operating Anomalies including Official Data Issues",
            },
            new() {
                code = 5,
                definition = "Hazards likely to constitute a danger to navigation.",
                label = "Other Hazards",
            },
            new() {
                code = 6,
                definition = "Health advisories or information.",
                label = "Health Advisories",
            },
            new() {
                code = 7,
                definition = "Newly discovered icebergs, changes to ice conditions and ice related information likely to impact navigation.",
                label = "Ice Information",
            },
            new() {
                code = 8,
                definition = "A list of serial numbers of warnings which are in-force.",
                label = "In-Force Bulletin",
            },
            new() {
                code = 9,
                definition = "Natural phenomena adversely affecting the marine environment.",
                label = "Dangerous Natural Phenomena",
            },
            new() {
                code = 10,
                definition = "Newly discovered rocks, shoals, reefs and wrecks likely to constitute a danger to navigation and, if relevant, their markings.",
                label = "Newly Discovered Dangers",
            },
            new() {
                code = 11,
                definition = "New or established complex structures situated at sea, including rigs, drilling platforms, offshore wind turbines, cables and pipelines.",
                label = "Offshore Infrastructure",
            },
            new() {
                code = 12,
                definition = "Acts of piracy and armed robbery against ships.",
                label = "Piracy or Robbery",
            },
            new() {
                code = 13,
                definition = "Any failure or return to service of terrestrial or satellite radio services used to determine the position of an object.",
                label = "Communication or Broadcast Service Change",
            },
            new() {
                code = 14,
                definition = "Changes to the established navigational routes or specific procedures related to them.",
                label = "Routeing Change",
            },
            new() {
                code = 15,
                definition = "Deployment or removal of scientific instruments on the surface, subsurface or on the sea floor.",
                label = "Scientific Instruments Change",
            },
            new() {
                code = 16,
                definition = "Changes to the maritime security levels in a country, a specific region or port. Or, changes to maritime security regulations.",
                label = "Security Requirement Change",
            },
            new() {
                code = 17,
                definition = "Events which might affect the safety of shipping, sometimes over wide areas, e.g. naval exercises, missile firings, space missions, nuclear tests, ordnance dumping zones, etc.",
                label = "Special Operations",
            },
            new() {
                code = 18,
                definition = "Objects being towed which are impacting navigation of vessels in its vicinity.",
                label = "Towing Operations",
            },
            new() {
                code = 19,
                definition = "Works at sea or onshore which might affect navigation.",
                label = "Works",
            },
            new() {
                code = 20,
                definition = "An update on the position, movement or status of rigs or drill ships within a defined area.",
                label = "Rig List",
            },
        });
    }

    namespace ComplexAttributes
    {

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String name { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public nameUsage? nameUsage { get; set; } = default;

            public featureName()
            {
                language = string.Empty;
                name = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class dateTimeRange
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public DateTime dateTimeEnd { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public DateTime dateTimeStart { get; set; }

            public dateTimeRange()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class eNCFeatureReference
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String editionNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String eNCName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<String> featureObjectIdentifier { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String updateNumber { get; set; } = string.Empty;

            public eNCFeatureReference()
            {
                editionNumber = string.Empty;
                eNCName = string.Empty;
                featureObjectIdentifier = new();
                updateNumber = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureReference
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> featureIdentifier { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public dateTimeRange dateTimeRange { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> atoNNumber { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<eNCFeatureReference> eNCFeatureReference { get; set; } = [];

            public featureReference()
            {
                dateTimeRange = new dateTimeRange()
                {
                    dateTimeEnd = default(DateTime),
                    dateTimeStart = default(DateTime),
                };
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class fixedDateRange
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateEnd { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateStart { get; set; } = default;

            public fixedDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class information
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String fileLocator { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String fileReference { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String headline { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            public information()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class warningInformation
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public information? information { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<navwarnTypeDetails> navwarnTypeDetails { get; set; } = [];

            public warningInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class chartAffected
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String chartNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String chartPlanNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public DateTime editionDate { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateTime? lastNoticeDate { get; set; } = default;

            public chartAffected()
            {
                chartNumber = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class affectedChartPublications
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public chartAffected? chartAffected { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String chartPublicationIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String internationalChartAffected { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String publicationAffected { get; set; } = string.Empty;

            public affectedChartPublications()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class locationName
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            public locationName()
            {
                text = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class generalArea
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String localityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<locationName> locationName { get; set; }

            public generalArea()
            {
                locationName = new();
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class locality
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String localityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<locationName> locationName { get; set; }

            public locality()
            {
                locationName = new();
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class messageSeriesIdentifier
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String agencyResponsibleForProduction { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String countryName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nameOfSeries { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String warningIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Int32 warningNumber { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public warningType warningType { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Int32 year { get; set; }

            public messageSeriesIdentifier()
            {
                agencyResponsibleForProduction = string.Empty;
                nameOfSeries = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class nAVWARNTitle
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            public nAVWARNTitle()
            {
                text = string.Empty;
            }
        }
    }

    public enum Role
    {
        [System.ComponentModel.Description("TBD")]
        [System.Xml.Serialization.XmlEnum("affects")]
        affects,

        [System.ComponentModel.Description("TBD")]
        [System.Xml.Serialization.XmlEnum("impacts")]
        impacts,

        [System.ComponentModel.Description("A pointer to a specific feature(s).")]
        [System.Xml.Serialization.XmlEnum("identifies")]
        identifies,

        [System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
        [System.Xml.Serialization.XmlEnum("positions")]
        positions,

        [System.ComponentModel.Description("TBD")]
        [System.Xml.Serialization.XmlEnum("theWarningPart")]
        theWarningPart,

        [System.ComponentModel.Description("TBD")]
        [System.Xml.Serialization.XmlEnum("header")]
        header,

        [System.ComponentModel.Description("TBD")]
        [System.Xml.Serialization.XmlEnum("theWarning")]
        theWarning,

        [System.ComponentModel.Description("TBD")]
        [System.Xml.Serialization.XmlEnum("theReferences")]
        theReferences,
    }

    namespace Associations
    {
        namespace InformationAssociations
        {

            public class NWPreambleContent : InformationAssociation
            {
                public NWPreambleContent()
                {
                }
                public static Role[] Roles => new[] { Role.theWarningPart, Role.header };
            }


            public class NWReferences : InformationAssociation
            {
                public NWReferences()
                {
                }
                public static Role[] Roles => new[] { Role.theWarning, Role.theReferences };
            }

        }
        namespace FeatureAssociations
        {

            public class AreaAffected : FeatureAssociation
            {
                public AreaAffected()
                {
                }
                public static Role[] Roles => new[] { Role.affects, Role.impacts };
            }


            public class TextAssociation : FeatureAssociation
            {
                public TextAssociation()
                {
                }
                public static Role[] Roles => new[] { Role.identifies, Role.positions };
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


        public class theReferencesNWReferencesNAVWARNPreambleBinding : informationBinding
        {
            public override Type[] informationTypes => [typeof(References)];
            public Role Role => Role.theReferences;
            public Associations.InformationAssociations.NWReferences NWReferences { get; set; } = new();
        }


        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NAVWARNPreamble : InformationTypeBase
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<affectedChartPublications> affectedChartPublications { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<generalArea> generalArea { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<locality> locality { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public messageSeriesIdentifier messageSeriesIdentifier { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<nAVWARNTitle> nAVWARNTitle { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateTime? cancellationDate { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Boolean intService { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public navwarnTypeGeneral navwarnTypeGeneral { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public DateTime publicationTime { get; set; }
            public List<theReferencesNWReferencesNAVWARNPreambleBinding> theReferencesNWReferences { get; set; } = [];
            public override string Code => nameof(NAVWARNPreamble);

            public NAVWARNPreamble()
            {
                generalArea = new();
                messageSeriesIdentifier = new messageSeriesIdentifier()
                {
                    agencyResponsibleForProduction = string.Empty,
                    nameOfSeries = string.Empty,
                    warningNumber = default(Int32),
                    warningType = default(warningType),
                    year = default(Int32),
                };
                navwarnTypeGeneral = new navwarnTypeGeneral()
                {
                };
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class References : InformationTypeBase
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<messageSeriesIdentifier> messageSeriesIdentifier { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Boolean noMessageOnHand { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public referenceCategory referenceCategory { get; set; }
            public override string Code => nameof(References);

            public References()
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


        public class positionsTextAssociationNAVWARNPartBinding : featureBinding
        {
            public override Type[] featureTypes => [typeof(TextPlacement)];
            public Role Role => Role.positions;
            public Associations.FeatureAssociations.TextAssociation TextAssociation { get; set; } = new();
        }


        public class affectsAreaAffectedNAVWARNPartBinding : featureBinding
        {
            public override Type[] featureTypes => [typeof(NAVWARNAreaAffected)];
            public Role Role => Role.affects;
            public Associations.FeatureAssociations.AreaAffected AreaAffected { get; set; } = new();
        }


        public class headerNWPreambleContentNAVWARNPartBinding : informationBinding
        {
            public override Type[] informationTypes => [typeof(NAVWARNPreamble)];
            public Role Role => Role.header;
            public Associations.InformationAssociations.NWPreambleContent NWPreambleContent { get; set; } = new();
        }


        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NAVWARNPart : FeatureTypeBase
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureReference> featureReference { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<fixedDateRange> fixedDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public warningInformation warningInformation { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public restriction? restriction { get; set; } = default;
            public headerNWPreambleContentNAVWARNPartBinding headerNWPreambleContent { get; set; }
            public List<affectsAreaAffectedNAVWARNPartBinding> affectsAreaAffected { get; set; } = [];
            public List<positionsTextAssociationNAVWARNPartBinding> positionsTextAssociation { get; set; } = [];
            public override string Code => nameof(NAVWARNPart);

            public NAVWARNPart()
            {
                warningInformation = new warningInformation()
                {
                };
            }
        }

        public class impactsAreaAffectedNAVWARNAreaAffectedBinding : featureBinding
        {
            public override Type[] featureTypes => [typeof(NAVWARNPart)];
            public Role Role => Role.impacts;
            public Associations.FeatureAssociations.AreaAffected AreaAffected { get; set; } = new();
        }


        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NAVWARNAreaAffected : FeatureTypeBase
        {
            public impactsAreaAffectedNAVWARNAreaAffectedBinding impactsAreaAffected { get; set; }
            public override string Code => nameof(NAVWARNAreaAffected);

            public NAVWARNAreaAffected()
            {
            }
        }

        public class identifiesTextAssociationTextPlacementBinding : featureBinding
        {
            public override Type[] featureTypes => [typeof(NAVWARNPart)];
            public Role Role => Role.identifies;
            public Associations.FeatureAssociations.TextAssociation TextAssociation { get; set; } = new();
        }


        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TextPlacement : FeatureTypeBase
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Int32 textOffsetBearing { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Int32 textOffsetDistance { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? textRotation { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public textType? textType { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? scaleMinimum { get; set; } = default;
            public identifiesTextAssociationTextPlacementBinding? identifiesTextAssociation { get; set; }
            public override string Code => nameof(TextPlacement);

            public TextPlacement()
            {
            }
        }
    }
}