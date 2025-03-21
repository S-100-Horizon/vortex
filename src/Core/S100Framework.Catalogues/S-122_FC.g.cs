using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;

#nullable enable
namespace S100Framework.DomainModel.S122 {
    public static class Information {
        public static Version Version => new Version("1.2.1");
        public static string[] ComplexTypes => ["contactAddress", "featureName", "fixedDateRange", "frequencyPair", "information", "onlineResource", "orientation", "periodicDateRange", "rxNCode", "sectorLimitOne", "sectorLimitTwo", "textContent", "timeIntervalsByDayOfWeek", "vesselsMeasurements", "designation", "bearingInformation", "graphic", "scheduleByDayOfWeek", "sectorLimit", "telecommunications",];
        public static string[] SpatialAssociationTypes => [];
        public static string[] InformationAssociationTypes => ["AssociatedRxN", "ExceptionalWorkday", "ProtectedAreaAuthority", "ServiceControl", "RelatedOrganisation", "PermissionType", "InclusionType", "AuthorityContact", "AuthorityHours", "additionalInformation",];
        public static string[] FeatureAssociationTypes => [];
        public static string[] InformationTypes => ["InformationType", "AbstractRxN", "NauticalInformation", "Regulations", "Restrictions", "Recommendations", "Authority", "ContactDetails", "NonStandardWorkingDay", "ServiceHours", "Applicability",];
        public static string[] FeatureTypes => ["FeatureType", "RestrictedArea", "MarineProtectedArea", "VesselTrafficServiceArea", "DataCoverage", "TextPlacement",];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum cardinalDirection : int {
        [System.ComponentModel.Description("North")]
        [EnumMember(Value = "N")]
        N = 1,
        [System.ComponentModel.Description("Northnortheast")]
        [EnumMember(Value = "NNE")]
        Nne = 2,
        [System.ComponentModel.Description("Northeast")]
        [EnumMember(Value = "NE")]
        Ne = 3,
        [System.ComponentModel.Description("Eastnortheast")]
        [EnumMember(Value = "ENE")]
        Ene = 4,
        [System.ComponentModel.Description("East")]
        [EnumMember(Value = "E")]
        E = 5,
        [System.ComponentModel.Description("Eastsoutheast")]
        [EnumMember(Value = "ESE")]
        Ese = 6,
        [System.ComponentModel.Description("Southeast")]
        [EnumMember(Value = "SE")]
        Se = 7,
        [System.ComponentModel.Description("Southsoutheast")]
        [EnumMember(Value = "SSE")]
        Sse = 8,
        [System.ComponentModel.Description("South")]
        [EnumMember(Value = "S")]
        S = 9,
        [System.ComponentModel.Description("Southsouthwest")]
        [EnumMember(Value = "SSW")]
        Ssw = 10,
        [System.ComponentModel.Description("Southwest")]
        [EnumMember(Value = "SW")]
        Sw = 11,
        [System.ComponentModel.Description("Westsouthwest")]
        [EnumMember(Value = "WSW")]
        Wsw = 12,
        [System.ComponentModel.Description("West")]
        [EnumMember(Value = "W")]
        W = 13,
        [System.ComponentModel.Description("Westnorthwest")]
        [EnumMember(Value = "WNW")]
        Wnw = 14,
        [System.ComponentModel.Description("Northwest")]
        [EnumMember(Value = "NW")]
        Nw = 15,
        [System.ComponentModel.Description("Northnorthwest")]
        [EnumMember(Value = "NNW")]
        Nnw = 16,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum onlineFunction : int {
        [System.ComponentModel.Description("Online instructions for transferring data from one storage device or system to another. (ISO 19115:2014)")]
        [EnumMember(Value = "Download")]
        Download = 1,
        [System.ComponentModel.Description("Online information about the resource (ISO 19115:2014)")]
        [EnumMember(Value = "Information")]
        Information = 2,
        [System.ComponentModel.Description("Online instructions for requesting the resource from the provider (ISO 19115:2014)")]
        [EnumMember(Value = "Offline Access")]
        OfflineAccess = 3,
        [System.ComponentModel.Description("Online order process for obtaining the resource (ISO 19115:2014).")]
        [EnumMember(Value = "Order")]
        Order = 4,
        [System.ComponentModel.Description("Online search interface for seeking out information about the resource (ISO 19115:2014).")]
        [EnumMember(Value = "Search")]
        Search = 5,
        [System.ComponentModel.Description("Complete metadata provided (ISO 19115:2014).")]
        [EnumMember(Value = "Complete Metadata")]
        CompleteMetadata = 6,
        [System.ComponentModel.Description("Browse graphic provided (ISO 19115:2014).")]
        [EnumMember(Value = "Browse Graphic")]
        BrowseGraphic = 7,
        [System.ComponentModel.Description("Online resource upload capability provided (ISO 19115:2014).")]
        [EnumMember(Value = "Upload")]
        Upload = 8,
        [System.ComponentModel.Description("Online email service provided (ISO 19115:2014)")]
        [EnumMember(Value = "Email Service")]
        EmailService = 9,
        [System.ComponentModel.Description("Online browsing provided (ISO 19115:2014)")]
        [EnumMember(Value = "Browsing")]
        Browsing = 10,
        [System.ComponentModel.Description("online file access provided (ISO 19115:2014).")]
        [EnumMember(Value = "File Access")]
        FileAccess = 11,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristics : int {
        [System.ComponentModel.Description("The maximum length of the ship (L.O.A.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Length Overall")]
        LengthOverall = 1,
        [System.ComponentModel.Description("The ship's length measured at the waterline (L.W.L.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Length at waterline")]
        LengthAtWaterline = 2,
        [System.ComponentModel.Description("The width or beam of the vessel. (Adapted from http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Breadth")]
        Breadth = 3,
        [System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Draught")]
        Draught = 4,
        [System.ComponentModel.Description("	The height of the highest point of a vessel's structure (e.g. radar aerial, funnel, cranes, masthead) above her waterline. (UKHO NP100/2009)")]
        [EnumMember(Value = "Height")]
        Height = 5,
        [System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Displacement Tonnage")]
        DisplacementTonnage = 6,
        [System.ComponentModel.Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Displacement Tonnage, Light")]
        DisplacementTonnageLight = 7,
        [System.ComponentModel.Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Displacement Tonnage, Loaded")]
        DisplacementTonnageLoaded = 8,
        [System.ComponentModel.Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Deadweight Tonnage")]
        DeadweightTonnage = 9,
        [System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Gross Tonnage")]
        GrossTonnage = 10,
        [System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.(http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [EnumMember(Value = "Panama Canal/Universal Measurement System Net")]
        PanamaCanalUniversalMeasurementSystemNet = 11,
        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
        [EnumMember(Value = "Tonnage")]
        Tonnage = 12,
        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
        [EnumMember(Value = "Suez Canal Net Tonnage")]
        SuezCanalNetTonnage = 13,
        [System.ComponentModel.Description("Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [EnumMember(Value = "Suez Canal Gross Tonnage")]
        SuezCanalGrossTonnage = 14,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristicsUnit : int {
        [System.ComponentModel.Description("The metre (or meter) is the base unit of length in the International System of Units (SI). It is defined as the distance travelled by light in vacuum in 1/299,792,458 of a second.")]
        [EnumMember(Value = "Metre")]
        Metre = 1,
        [System.ComponentModel.Description("A foot (plural: feet) is a non-SI unit of length in a number of different systems including English units, Imperial units, and United States customary units. The most commonly used foot today is the international foot. There are three feet in a yard and 12 inches in a foot.")]
        [EnumMember(Value = "Foot")]
        Foot = 2,
        [System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6%.")]
        [EnumMember(Value = "Metric Ton")]
        MetricTon = 3,
        [System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m3) of salt water with a density of 64 lb/ft³ (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty—for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
        [EnumMember(Value = "Ton")]
        Ton = 4,
        [System.ComponentModel.Description("The short ton is a unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some U.S. applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the U.S. system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
        [EnumMember(Value = "Short Ton")]
        ShortTon = 5,
        [System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity. Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
        [EnumMember(Value = "Gross ton")]
        GrossTon = 6,
        [System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessel’s earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
        [EnumMember(Value = "Net Ton")]
        NetTon = 7,
        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
        [EnumMember(Value = "Panama Canal/Universal Measurement System Net Tonnage")]
        PanamaCanalUniversalMeasurementSystemNetTonnage = 8,
        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [EnumMember(Value = "Suez Canal Net Tonnage")]
        SuezCanalNetTonnage = 9,
        [System.ComponentModel.Description("Can be used for net and gross tonnages, including Panama Canal/Universal Measurement System net tonnage and The Suez Canal Net Tonnage.")]
        [EnumMember(Value = "None")]
        None = 10,
        [System.ComponentModel.Description("Cubic metres")]
        [EnumMember(Value = "Cubic Metres")]
        CubicMetres = 11,
        [System.ComponentModel.Description("The Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [EnumMember(Value = "Suez Canal Gross Tonnage")]
        SuezCanalGrossTonnage = 12,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum comparisonOperator : int {
        [System.ComponentModel.Description("The value of the left value is greater than that of the right.(http://en.wikipedia.org/wiki/Logical_connective)")]
        [EnumMember(Value = "Greater than")]
        GreaterThan = 1,
        [System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        [EnumMember(Value = "Greater than or equal to")]
        GreaterThanOrEqualTo = 2,
        [System.ComponentModel.Description("The value of the left expression is less than that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        [EnumMember(Value = "Less than")]
        LessThan = 3,
        [System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        [EnumMember(Value = "Less than or equal to")]
        LessThanOrEqualTo = 4,
        [System.ComponentModel.Description("The two values are equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
        [EnumMember(Value = "Equal to")]
        EqualTo = 5,
        [System.ComponentModel.Description("The two values are not equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
        [EnumMember(Value = "Not equal to")]
        NotEqualTo = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum dayOfWeek : int {
        [System.ComponentModel.Description("The first day of the week.")]
        [EnumMember(Value = "Sunday")]
        Sunday = 1,
        [System.ComponentModel.Description("The second day of the week.")]
        [EnumMember(Value = "Monday")]
        Monday = 2,
        [System.ComponentModel.Description("The third day of the week.")]
        [EnumMember(Value = "Tuesday")]
        Tuesday = 3,
        [System.ComponentModel.Description("The fourth day of the week.")]
        [EnumMember(Value = "Wednesday")]
        Wednesday = 4,
        [System.ComponentModel.Description("The fifth day of the week.")]
        [EnumMember(Value = "Thursday")]
        Thursday = 5,
        [System.ComponentModel.Description("The sixth day of the week.")]
        [EnumMember(Value = "Friday")]
        Friday = 6,
        [System.ComponentModel.Description("The seventh day of the week.")]
        [EnumMember(Value = "Saturday")]
        Saturday = 7,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfRelationship : int {
        [System.ComponentModel.Description("use of facility, waterway or service is forbidden")]
        [EnumMember(Value = "Prohibited")]
        Prohibited = 1,
        [System.ComponentModel.Description("use of facility, waterway or service is not recommended")]
        [EnumMember(Value = "Not Recommended")]
        NotRecommended = 2,
        [System.ComponentModel.Description("use of facility, waterway, or service is permitted but not required")]
        [EnumMember(Value = "Permitted")]
        Permitted = 3,
        [System.ComponentModel.Description("use of facility, waterway, or service is recommended")]
        [EnumMember(Value = "Recommended")]
        Recommended = 4,
        [System.ComponentModel.Description("use of facility, waterway, or service is required")]
        [EnumMember(Value = "Required")]
        Required = 5,
        [System.ComponentModel.Description("use of facility, waterway or service is not required")]
        [EnumMember(Value = "Not Required")]
        NotRequired = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum membership : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.")]
        [EnumMember(Value = "included")]
        Included = 1,
        [System.ComponentModel.Description("Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.")]
        [EnumMember(Value = "excluded")]
        Excluded = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum telecommunicationService : int {
        [System.ComponentModel.Description("The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.")]
        [EnumMember(Value = "Voice")]
        Voice = 1,
        [System.ComponentModel.Description("A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.")]
        [EnumMember(Value = "Facsimile")]
        Facsimile = 2,
        [System.ComponentModel.Description("Short Message Service is a form of text messaging communication on phones and mobile phones.")]
        [EnumMember(Value = "SMS")]
        Sms = 3,
        [System.ComponentModel.Description("A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.")]
        [EnumMember(Value = "Data")]
        Data = 4,
        [System.ComponentModel.Description("Data that is constantly received by and presented to an end-user while being delivered by a provider.")]
        [EnumMember(Value = "Streamed Data")]
        StreamedData = 5,
        [System.ComponentModel.Description("A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).")]
        [EnumMember(Value = "Telex")]
        Telex = 6,
        [System.ComponentModel.Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
        [EnumMember(Value = "Telegraph")]
        Telegraph = 7,
        [System.ComponentModel.Description("Messages and other data exchanged between individuals using computers in a network.")]
        [EnumMember(Value = "Email")]
        Email = 8,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfSchedule : int {
        [System.ComponentModel.Description("The service, office, is open, fully manned, and operating normally, or the area is accessible as usual.")]
        [EnumMember(Value = "Normal Operation")]
        NormalOperation = 1,
        [System.ComponentModel.Description("The service, office, or area is closed.")]
        [EnumMember(Value = "Closure")]
        Closure = 2,
        [System.ComponentModel.Description("The service is available but not manned.")]
        [EnumMember(Value = "Unmanned Operation")]
        UnmannedOperation = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfDangerousOrHazardousCargo : int {
        [System.ComponentModel.Description("Explosives, Division 1: Substances and articles which have a mass explosion hazard.")]
        [EnumMember(Value = "IMDG Code Class 1 Div. 1.1")]
        ImdgCodeClass1Div11 = 1,
        [System.ComponentModel.Description("Explosives, Division 2: Substances and articles which have a projection hazard but not a mass explosion hazard.")]
        [EnumMember(Value = "IMDG Code Class 1 Div. 1.2")]
        ImdgCodeClass1Div12 = 2,
        [System.ComponentModel.Description("Explosives, Division 3: Substances and articles which have a fire hazard and either a minor blast hazard or a minor projection hazard or both, but not a mass explosion hazard.")]
        [EnumMember(Value = "IMDG Code Class 1 Div. 1.3")]
        ImdgCodeClass1Div13 = 3,
        [System.ComponentModel.Description("Explosives, Division 4: Substances and articles which present no significant hazard.")]
        [EnumMember(Value = "IMDG Code Class 1 Div. 1.4")]
        ImdgCodeClass1Div14 = 4,
        [System.ComponentModel.Description("Explosives, Division 5: Very insensitive substances which have a mass explosion hazard.")]
        [EnumMember(Value = "IMDG Code Class 1 Div. 1.5")]
        ImdgCodeClass1Div15 = 5,
        [System.ComponentModel.Description("Explosives, Division 6: Extremely insensitive articles which do not have a mass explosion hazard.")]
        [EnumMember(Value = "IMDG Code Class 1 Div. 1.6")]
        ImdgCodeClass1Div16 = 6,
        [System.ComponentModel.Description("Gases, flammable gases.")]
        [EnumMember(Value = "IMDG Code Class 2 Div. 2.1")]
        ImdgCodeClass2Div21 = 7,
        [System.ComponentModel.Description("Gases, non-flammable, non-toxic gases.")]
        [EnumMember(Value = "IMDG Code Class 2 Div. 2.2")]
        ImdgCodeClass2Div22 = 8,
        [System.ComponentModel.Description("Gases, toxic gases.")]
        [EnumMember(Value = "IMDG Code Class 2 Div. 2.3")]
        ImdgCodeClass2Div23 = 9,
        [System.ComponentModel.Description("Flammable liquids.")]
        [EnumMember(Value = "IMDG Code Class 3")]
        ImdgCodeClass3 = 10,
        [System.ComponentModel.Description("Flammable solids, self-reactive substances and desensitized explosives.")]
        [EnumMember(Value = "IMDG Code Class 4 Div. 4.1")]
        ImdgCodeClass4Div41 = 11,
        [System.ComponentModel.Description("Substances liable to spontaneous combustion.")]
        [EnumMember(Value = "IMDG Code Class 4 Div. 4.2")]
        ImdgCodeClass4Div42 = 12,
        [System.ComponentModel.Description("Substances which, in contact with water, emit flammable gases.")]
        [EnumMember(Value = "IMDG Code Class 4 Div. 4.3")]
        ImdgCodeClass4Div43 = 13,
        [System.ComponentModel.Description("Oxidizing substances.")]
        [EnumMember(Value = "IMDG Code Class 5 Div. 5.1")]
        ImdgCodeClass5Div51 = 14,
        [System.ComponentModel.Description("Organic peroxides.")]
        [EnumMember(Value = "IMDG Code Class 5 Div. 5.2")]
        ImdgCodeClass5Div52 = 15,
        [System.ComponentModel.Description("Toxic substances.")]
        [EnumMember(Value = "IMDG Code Class 6 Div. 6.1")]
        ImdgCodeClass6Div61 = 16,
        [System.ComponentModel.Description("Infectious substances.")]
        [EnumMember(Value = "IMDG Code Class 6 Div. 6.2")]
        ImdgCodeClass6Div62 = 17,
        [System.ComponentModel.Description("Radioactive material.")]
        [EnumMember(Value = "IMDG Code Class 7")]
        ImdgCodeClass7 = 18,
        [System.ComponentModel.Description("Corrosive substances.")]
        [EnumMember(Value = "IMDG Code Class 8")]
        ImdgCodeClass8 = 19,
        [System.ComponentModel.Description("Miscellaneous dangerous substances and articles.")]
        [EnumMember(Value = "IMDG Code Class 9")]
        ImdgCodeClass9 = 20,
        [System.ComponentModel.Description("Harmful substances are those substances which are identified as marine pollutants in the International Maritime Dangerous Goods Code (IMDG Code). Packaged form is defined as the forms of containment specified for harmful substances in the IMDG Code.")]
        [EnumMember(Value = "Harmful Substances in Packaged Form")]
        HarmfulSubstancesInPackagedForm = 21,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCargo : int {
        [System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel e.g. oil or grain.")]
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
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfCommunicationPreference : int {
        [System.ComponentModel.Description("The first choice channel or frequency to be used when calling a radio station.")]
        [EnumMember(Value = "Preferred Calling")]
        PreferredCalling = 1,
        [System.ComponentModel.Description("A channel or frequency to be used for calling a radio station when the preferred channel or frequency is busy or is suffering from interference.")]
        [EnumMember(Value = "Alternate Calling")]
        AlternateCalling = 2,
        [System.ComponentModel.Description("The first choice channel or frequency to be used when working with a radio station.")]
        [EnumMember(Value = "Preferred Working")]
        PreferredWorking = 3,
        [System.ComponentModel.Description("A channel or frequency to be used for working with a radio station when the preferred working channel or frequency is busy or is suffering from interference.")]
        [EnumMember(Value = "Alternate Working")]
        AlternateWorking = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAuthority : int {
        [System.ComponentModel.Description("The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.")]
        [EnumMember(Value = "Border Control")]
        BorderControl = 2,
        [System.ComponentModel.Description("The department of government, or civil force, charged with maintaining public order.")]
        [EnumMember(Value = "Police")]
        Police = 3,
        [System.ComponentModel.Description("Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.")]
        [EnumMember(Value = "Port")]
        Port = 4,
        [System.ComponentModel.Description("The authority controlling people entering a country.")]
        [EnumMember(Value = "Immigration")]
        Immigration = 5,
        [System.ComponentModel.Description("The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.")]
        [EnumMember(Value = "Health")]
        Health = 6,
        [System.ComponentModel.Description("Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.")]
        [EnumMember(Value = "Coast Guard")]
        CoastGuard = 7,
        [System.ComponentModel.Description("The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.")]
        [EnumMember(Value = "Agricultural")]
        Agricultural = 8,
        [System.ComponentModel.Description("A military authority which provides control of access to or approval for transit through designated areas or airspace.")]
        [EnumMember(Value = "Military")]
        Military = 9,
        [System.ComponentModel.Description("A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.")]
        [EnumMember(Value = "Private Company")]
        PrivateCompany = 10,
        [System.ComponentModel.Description("A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.")]
        [EnumMember(Value = "Maritime Police")]
        MaritimePolice = 11,
        [System.ComponentModel.Description("An authority with responsibility for the protection of the environment.")]
        [EnumMember(Value = "Environmental")]
        Environmental = 12,
        [System.ComponentModel.Description("An authority with responsibility for the control of fisheries.")]
        [EnumMember(Value = "Fishery")]
        Fishery = 13,
        [System.ComponentModel.Description("An authority with responsibility for the control and movement of money.")]
        [EnumMember(Value = "Finance")]
        Finance = 14,
        [System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
        [EnumMember(Value = "Maritime")]
        Maritime = 15,
        [System.ComponentModel.Description("The agency or establishment for collecting duties, tolls.")]
        [EnumMember(Value = "Customs")]
        Customs = 16,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfVesselTrafficService : int {
        [System.ComponentModel.Description("A service to ensure that essential information becomes available in time for on-board navigational decision-making.")]
        [EnumMember(Value = "Information Service")]
        InformationService = 1,
        [System.ComponentModel.Description("A service to assist on-board navigational decision-making and to monitor its effects.")]
        [EnumMember(Value = "Traffic Organization Service")]
        TrafficOrganizationService = 2,
        [System.ComponentModel.Description("A service to prevent the development of dangerous maritime traffic situations and to provide for the safe and efficient movement of vessel traffic within the VTS area.")]
        [EnumMember(Value = "Navigational Assistance Service")]
        NavigationalAssistanceService = 3,
        [System.ComponentModel.Description("A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.")]
        [EnumMember(Value = "Ship Reporting Service")]
        ShipReportingService = 4,
        [System.ComponentModel.Description("A service established to provide port information without interaction between the customer and the service provider. This information could be inter-alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.")]
        [EnumMember(Value = "Local Port Service")]
        LocalPortService = 5,
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
        [System.ComponentModel.Description("Recurring at intervals.")]
        [EnumMember(Value = "Periodic/Intermittent")]
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
        [System.ComponentModel.Description("Lit by floodlights, strip lights, etc.")]
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
        [System.ComponentModel.Description("When you ask for it.")]
        [EnumMember(Value = "On Request")]
        OnRequest = 19,
        [System.ComponentModel.Description("To become lower in level.")]
        [EnumMember(Value = "Drop Away")]
        DropAway = 20,
        [System.ComponentModel.Description("To become higher in level.")]
        [EnumMember(Value = "Rising")]
        Rising = 21,
        [System.ComponentModel.Description("Becoming larger in magnitude.")]
        [EnumMember(Value = "Increasing")]
        Increasing = 22,
        [System.ComponentModel.Description("Becoming smaller in magnitude.")]
        [EnumMember(Value = "Decreasing")]
        Decreasing = 23,
        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        [EnumMember(Value = "Strong")]
        Strong = 24,
        [System.ComponentModel.Description("In a satisfactory condition to use.")]
        [EnumMember(Value = "Good")]
        Good = 25,
        [System.ComponentModel.Description("Fairly but not very.")]
        [EnumMember(Value = "Moderately")]
        Moderately = 26,
        [System.ComponentModel.Description("Not as good as it could be or should.")]
        [EnumMember(Value = "Poor")]
        Poor = 27,
        [System.ComponentModel.Description("Marked by buoys.")]
        [EnumMember(Value = "Buoyed")]
        Buoyed = 28,
        [System.ComponentModel.Description("Entire observation platform is operating in accordance with, or exceeding, manufacturer specifications.")]
        [EnumMember(Value = "Fully Operational")]
        FullyOperational = 29,
        [System.ComponentModel.Description("At least one instrument that is part of an observation platform is not operating to manufacturer specification.")]
        [EnumMember(Value = "Partially Operational")]
        PartiallyOperational = 30,
        [System.ComponentModel.Description("Floating platform at the mercy of environmental elements, whether intentional or not.")]
        [EnumMember(Value = "Drifting")]
        Drifting = 31,
        [System.ComponentModel.Description("Fractured or in pieces.")]
        [EnumMember(Value = "Broken")]
        Broken = 32,
        [System.ComponentModel.Description("Observation platform is intentionally not reporting an environmental observation.")]
        [EnumMember(Value = "Offline")]
        Offline = 33,
        [System.ComponentModel.Description("Observation station, suite of instruments, or an individual instrument, for a particular location, has been removed and is no longer at the particular location.")]
        [EnumMember(Value = "Discontinued")]
        Discontinued = 34,
        [System.ComponentModel.Description("Observations made by a human observer.")]
        [EnumMember(Value = "Manual Observation")]
        ManualObservation = 35,
        [System.ComponentModel.Description("Status of an observation platform, suite of instruments, or individual instrument is not known or unspecified.")]
        [EnumMember(Value = "Unknown Status")]
        UnknownStatus = 36,
        [System.ComponentModel.Description("Made certain as to truth, accuracy, validity, availability, etc.")]
        [EnumMember(Value = "Confirmed")]
        Confirmed = 37,
        [System.ComponentModel.Description("Item selected for an action.")]
        [EnumMember(Value = "Candidate")]
        Candidate = 38,
        [System.ComponentModel.Description("Item that is in the process of being modified.")]
        [EnumMember(Value = "Under Modification")]
        UnderModification = 39,
        [System.ComponentModel.Description("Item in the process of being removed or deleted.")]
        [EnumMember(Value = "Under Removal / Deletion")]
        UnderRemovalDeletion = 41,
        [System.ComponentModel.Description("Item that has been removed or deleted.")]
        [EnumMember(Value = "Removed / Deleted")]
        RemovedDeleted = 42,
        [System.ComponentModel.Description("Item selected for modification.")]
        [EnumMember(Value = "Candidate for Modification")]
        CandidateForModification = 43,
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
        [System.ComponentModel.Description("An area within which industrial or mineral exploration and development are prohibited.")]
        [EnumMember(Value = "Industrial or Mineral Exploration/Development Prohibited")]
        IndustrialOrMineralExplorationDevelopmentProhibited = 18,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which industrial or mineral exploration and development is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Industrial or Mineral Exploration/Development Restricted")]
        IndustrialOrMineralExplorationDevelopmentRestricted = 19,
        [System.ComponentModel.Description("An area within which excavating a hole on the sea-bottom with a drill is prohibited.")]
        [EnumMember(Value = "Drilling Prohibited")]
        DrillingProhibited = 20,
        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the sea-bottom with a drill is restricted in accordance with certain specified conditions.")]
        [EnumMember(Value = "Drilling Restricted")]
        DrillingRestricted = 21,
        [System.ComponentModel.Description("An area within which the removal of historical artefacts is prohibited.")]
        [EnumMember(Value = "Removal of Historical Artefacts Prohibited")]
        RemovalOfHistoricalArtefactsProhibited = 22,
        [System.ComponentModel.Description("An area in which cargo transhipment (lightening) is prohibited.")]
        [EnumMember(Value = "Cargo Transhipment (Lightening) Prohibited")]
        CargoTranshipmentLighteningProhibited = 23,
        [System.ComponentModel.Description("An area in which the dragging of anything along the bottom, e.g. bottom trawling, is prohibited.")]
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
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking is generally prohibited.")]
        [EnumMember(Value = "Overtaking Prohibited")]
        OvertakingProhibited = 28,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking between convoys is prohibited.")]
        [EnumMember(Value = "Overtaking of Convoys by Convoys Prohibited")]
        OvertakingOfConvoysByConvoysProhibited = 29,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which passing or overtaking is generally prohibited.")]
        [EnumMember(Value = "Passing or Overtaking Prohibited")]
        PassingOrOvertakingProhibited = 30,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not berth.")]
        [EnumMember(Value = "Berthing Prohibited")]
        BerthingProhibited = 31,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which berthing is restricted.")]
        [EnumMember(Value = "Berthing Restricted")]
        BerthingRestricted = 32,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not make fast to the bank.")]
        [EnumMember(Value = "Making Fast Prohibited")]
        MakingFastProhibited = 33,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which making fast to the bank is restricted.")]
        [EnumMember(Value = "Making Fast Restricted")]
        MakingFastRestricted = 34,
        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which all turning is generally prohibited.")]
        [EnumMember(Value = "Turning Prohibited")]
        TurningProhibited = 35,
        [System.ComponentModel.Description("An area within which the fairway depth is restricted.")]
        [EnumMember(Value = "Restricted Fairway Depth")]
        RestrictedFairwayDepth = 36,
        [System.ComponentModel.Description("An area within which the fairway width is restricted.")]
        [EnumMember(Value = "Restricted Fairway Width")]
        RestrictedFairwayWidth = 37,
        [System.ComponentModel.Description("The use of anchoring spuds (telescopic piles) is prohibited.")]
        [EnumMember(Value = "Use of Spuds Prohibited")]
        UseOfSpudsProhibited = 38,
        [System.ComponentModel.Description("An area in which swimming is prohibited.")]
        [EnumMember(Value = "Swimming Prohibited")]
        SwimmingProhibited = 39,
        [System.ComponentModel.Description("An area within which the emission of SOx is restricted.")]
        [EnumMember(Value = "SOx Emission Restricted")]
        SoxEmissionRestricted = 40,
        [System.ComponentModel.Description("An area within which the emission of NOx is restricted.")]
        [EnumMember(Value = "NOx Emission Restricted")]
        NoxEmissionRestricted = 41,
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
        [System.ComponentModel.Description("An area smaller than the nation in which it lies.")]
        [EnumMember(Value = "National Sub-Division")]
        NationalSubDivision = 3,
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
        [System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the sea bed in the range and there are cables leading from the range to a control position ashore.")]
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
        [System.ComponentModel.Description("A tract of land managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        [EnumMember(Value = "Ecological Reserve")]
        EcologicalReserve = 23,
        [System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
        [EnumMember(Value = "No Wake Area")]
        NoWakeArea = 24,
        [System.ComponentModel.Description("An area where vessels turn.")]
        [EnumMember(Value = "Swinging Area")]
        SwingingArea = 25,
        [System.ComponentModel.Description("An area within which people may water ski and therefore vessel movement may be restricted.")]
        [EnumMember(Value = "Water Skiing Area")]
        WaterSkiingArea = 26,
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
        [System.ComponentModel.Description("An area within which the ship pollution emission is controlled.")]
        [EnumMember(Value = "Ship Pollution Emission Control")]
        ShipPollutionEmissionControl = 33,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum sourceType : int {
        [System.ComponentModel.Description("Treaty, convention, or international agreement; law or regulation issued by a national or other authority.")]
        [EnumMember(Value = "Law or Regulation")]
        LawOrRegulation = 1,
        [System.ComponentModel.Description("Publication not having the force of law, issued by an international organisation or a national or local administration.")]
        [EnumMember(Value = "Official Publication")]
        OfficialPublication = 2,
        [System.ComponentModel.Description("Reported by mariner(s) and confirmed by another source.")]
        [EnumMember(Value = "Mariner Report, Confirmed")]
        MarinerReportConfirmed = 7,
        [System.ComponentModel.Description("Reported by mariner(s) but not confirmed.")]
        [EnumMember(Value = "Mariner Report, Not Confirmed")]
        MarinerReportNotConfirmed = 8,
        [System.ComponentModel.Description("Shipping and other industry publications, including graphics, charts and web sites.")]
        [EnumMember(Value = "Industry Publications and Reports")]
        IndustryPublicationsAndReports = 9,
        [System.ComponentModel.Description("Information obtained from satellite images.")]
        [EnumMember(Value = "Remotely Sensed Images")]
        RemotelySensedImages = 10,
        [System.ComponentModel.Description("Information obtained from photographs.")]
        [EnumMember(Value = "Photographs")]
        Photographs = 11,
        [System.ComponentModel.Description("Information obtained from products issued by Hydrographic Offices.")]
        [EnumMember(Value = "Products Issued by HO Services")]
        ProductsIssuedByHoServices = 12,
        [System.ComponentModel.Description("Information obtained from news media.")]
        [EnumMember(Value = "News Media")]
        NewsMedia = 13,
        [System.ComponentModel.Description("Information obtained from the analysis of traffic data.")]
        [EnumMember(Value = "Traffic Data")]
        TrafficData = 14,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfText : int {
        [System.ComponentModel.Description("A statement summarizing the important points of a text.")]
        [EnumMember(Value = "Abstract or Summary")]
        AbstractOrSummary = 1,
        [System.ComponentModel.Description("An excerpt or excerpts from a text.")]
        [EnumMember(Value = "Extract")]
        Extract = 2,
        [System.ComponentModel.Description("The whole text.")]
        [EnumMember(Value = "Full Text")]
        FullText = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfVesselRegistry : int {
        [System.ComponentModel.Description("The vessel is registered or enrolled under the same national flag as the port, harbour, territorial sea, exclusive economic zone, or administrative area in which the object that possesses this attribute applies or is located.")]
        [EnumMember(Value = "Domestic")]
        Domestic = 1,
        [System.ComponentModel.Description("The vessel is registered or enrolled under a national flag different from the port, harbour, territorial sea, exclusive economic zone, or other administrative area in which the object that possesses this attribute applies or is located.")]
        [EnumMember(Value = "Foreign")]
        Foreign = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum logicalConnectives : int {
        [System.ComponentModel.Description("All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.")]
        [EnumMember(Value = "Logical Conjunction")]
        LogicalConjunction = 1,
        [System.ComponentModel.Description("At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.")]
        [EnumMember(Value = "Logical Disjunction")]
        LogicalDisjunction = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Serializable()]
    public class categoryOfMarineProtectedArea {
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.Serializable()]
    public class categoryOfVessel {
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.Serializable()]
    public class actionOrActivity {
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    [System.Serializable()]
    public class categoryOfRxN {
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    public static class CodeList {
        public static ImmutableArray<categoryOfMarineProtectedArea> categoryOfMarineProtectedAreas => ImmutableArray.Create<categoryOfMarineProtectedArea>(new categoryOfMarineProtectedArea[] { new() { code = 1, definition = "-", label = "IUCN Category Ia", }, new() { code = 2, definition = "-", label = "IUCN Category Ib", }, new() { code = 3, definition = "-", label = "IUCN Category II", }, new() { code = 4, definition = "-", label = "IUCN Category III", }, new() { code = 5, definition = "-", label = "IUCN Category IV", }, new() { code = 6, definition = "-", label = "IUCN Category V", }, new() { code = 7, definition = "-", label = "IUCN Category VI", }, });
        public static ImmutableArray<categoryOfVessel> categoryOfVessels => ImmutableArray.Create<categoryOfVessel>(new categoryOfVessel[] { new() { code = 1, definition = "-", label = "General Cargo Vessel", }, new() { code = 2, definition = "-", label = "Container Carrier", }, new() { code = 3, definition = "-", label = "Tanker", }, new() { code = 4, definition = "-", label = "Bulk Carrier", }, new() { code = 5, definition = "-", label = "Passenger Vessel", }, new() { code = 6, definition = "-", label = "Roll-On Roll-Off", }, new() { code = 7, definition = "-", label = "Refrigerated Cargo Vessel", }, new() { code = 8, definition = "-", label = "Fishing Vessel", }, new() { code = 9, definition = "-", label = "Service", }, new() { code = 10, definition = "-", label = "Warship", }, new() { code = 11, definition = "-", label = "Towed or Pushed Composite Unit", }, new() { code = 12, definition = "-", label = "Tug and Tow", }, new() { code = 13, definition = "-", label = "Light Recreational", }, new() { code = 14, definition = "-", label = "Semi-Submersible Offshore Installation", }, new() { code = 15, definition = "-", label = "Jack-Up Exploration or Project Installation", }, new() { code = 16, definition = "-", label = "Livestock Carrier", }, new() { code = 17, definition = "-", label = "Sport Fishing", }, });
        public static ImmutableArray<actionOrActivity> actionOrActivities => ImmutableArray.Create<actionOrActivity>(new actionOrActivity[] { new() { code = 1, definition = "Carrying a qualified pilot as part of the vessel navigation team.", label = "Navigating With a Pilot", }, new() { code = 2, definition = "Navigating a vessel into a port.", label = "Entering Port", }, new() { code = 3, definition = "Navigating a vessel out of a port.", label = "Leaving Port", }, new() { code = 4, definition = "A signal station for the control of vessels when berthing.", label = "Berthing", }, new() { code = 5, definition = "Detaching a vessel from a wharf or jetty.", label = "Slipping", }, new() { code = 6, definition = "Attaching a vessel to the seabed by means of an anchor and cable.", label = "Anchoring", }, new() { code = 7, definition = "Detaching a vessel from the seabed by recovering an anchor and cable.", label = "Weighing Anchor", }, new() { code = 8, definition = "Navigating a vessel along a route or through a narrow gap, such as under a bridge or through a lock.", label = "Transiting", }, new() { code = 9, definition = "Navigating a vessel past another traveling broadly in the same direction.", label = "Overtaking", }, new() { code = 10, definition = "Providing details such as the name, location or intentions of a vessel.", label = "Reporting", }, new() { code = 11, definition = "Loading or unloading cargo.", label = "Working Cargo", }, new() { code = 12, definition = "Placing crew or passengers on shore.", label = "Landing", }, new() { code = 13, definition = "A signal or message warning of diving activity.", label = "Diving", }, new() { code = 14, definition = "Hunting or catching fish.", label = "Fishing", }, new() { code = 15, definition = "Releasing anything into the sea; often ballast water; or spoil from dredging elsewhere.", label = "Discharging Overboard", }, new() { code = 16, definition = "Navigating a vessel past another travelling broadly in the opposite direction.", label = "Passing", }, });
        public static ImmutableArray<categoryOfRxN> categoryOfRxNS => ImmutableArray.Create<categoryOfRxN>(new categoryOfRxN[] { new() { code = 1, definition = "The process of directing the movement of a craft from one point to another.", label = "Navigation", }, new() { code = 2, definition = "Transmitting and/or receiving electronic communication signals.", label = "Communication", }, new() { code = 3, definition = "Pertaining to environmental protection.", label = "Environmental Protection", }, new() { code = 4, definition = "Pertaining to wildlife protection.", label = "Wildlife Protection", }, new() { code = 5, definition = "Pertaining to security.", label = "Security", }, new() { code = 6, definition = "The agency or establishment for collecting duties, tolls.", label = "Customs", }, new() { code = 7, definition = "Pertaining to cargo operations.", label = "Cargo Operation", }, new() { code = 8, definition = "Pertaining to a place of safety or refuge.", label = "Refuge", }, new() { code = 9, definition = "The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.", label = "Health", }, new() { code = 10, definition = "Pertaining to natural resources or exploitation.", label = "Natural Resources or Exploitation", }, new() { code = 11, definition = "Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.", label = "Port", }, new() { code = 12, definition = "An authority with responsibility for the control and movement of money.", label = "Finance", }, new() { code = 13, definition = "The science, art, or practice of cultivating the soil, producing crops, and raising livestock and in varying degrees the preparation and marketing of the resulting products.", label = "Agriculture", }, });
    }

    namespace ComplexAttributes {
        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class contactAddress {
            public String? deliveryPoint { get; set; } = null;
            public String? cityName { get; set; } = null;
            public String? administrativeDivision { get; set; } = null;
            public String? countryName { get; set; } = null;
            public String? postalCode { get; set; } = null;

            public contactAddress() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName {
            public Boolean? displayName { get; set; } = default;
            public String language { get; set; } = string.Empty;
            public String name { get; set; } = string.Empty;

            public featureName() {
                language = string.Empty;
                name = string.Empty;
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
        public partial class frequencyPair {
            public Int32? frequencyShoreStationReceives { get; set; } = default;
            public Int32? frequencyShoreStationTransmits { get; set; } = default;

            public frequencyPair() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class information
#pragma warning restore CS8981
        {
            public String? fileLocator { get; set; } = null;
            public String? fileReference { get; set; } = null;
            public String? headline { get; set; } = null;
            public String? language { get; set; } = null;
            public String? text { get; set; } = null;

            public information() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class onlineResource {
            public String onlineResourceLinkageURL { get; set; } = string.Empty;
            public String? protocol { get; set; } = null;
            public String? applicationProfile { get; set; } = null;
            public String? nameOfResource { get; set; } = null;
            public String? onlineResourceDescription { get; set; } = null;
            public String? protocolRequest { get; set; } = null;
            public onlineFunction? onlineFunction { get; set; } = default;

            public onlineResource() {
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

            public orientation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class periodicDateRange {
            [Required()]
            public DateOnly dateStart { get; set; }

            [Required()]
            public DateOnly dateEnd { get; set; }

            public periodicDateRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class rxNCode {
            public categoryOfRxN? categoryOfRxN { get; set; }
            public actionOrActivity? actionOrActivity { get; set; }
            public String? headline { get; set; } = null;

            public rxNCode() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitOne {
            [Required()]
            public Decimal sectorBearing { get; set; }
            public Int32? sectorLineLength { get; set; } = default;

            public sectorLimitOne() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitTwo {
            [Required()]
            public Decimal sectorBearing { get; set; }
            public Int32? sectorLineLength { get; set; } = default;

            public sectorLimitTwo() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class textContent {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public categoryOfText? categoryOfText { get; set; } = default;
            public String? source { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            public sourceType? sourceType { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            public textContent() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class timeIntervalsByDayOfWeek {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            public List<dayOfWeek> dayOfWeek { get; set; } = [];
            public Boolean? dayOfWeekIsRange { get; set; } = default;
            public List<TimeOnly> timeOfDayEnd { get; set; } = [];
            public List<TimeOnly> timeOfDayStart { get; set; } = [];

            public timeIntervalsByDayOfWeek() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class vesselsMeasurements {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [Required()]
            public vesselsCharacteristics vesselsCharacteristics { get; set; }

            [Required()]
            public Decimal vesselsCharacteristicsValue { get; set; }

            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(9)]
            [Required()]
            public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [Required()]
            public comparisonOperator comparisonOperator { get; set; }

            public vesselsMeasurements() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class designation
#pragma warning restore CS8981
        {
            public String? designationScheme { get; set; } = null;
            public String? designationIdentifier { get; set; } = null;
            public jurisdiction? jurisdiction { get; set; } = default;
            public String? text { get; set; } = null;

            public designation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class bearingInformation {
            public cardinalDirection? cardinalDirection { get; set; } = default;
            public Decimal? distance { get; set; } = default;
            public List<Decimal> sectorBearing { get; set; } = [];
            public List<information> information { get; set; } = [];
            public orientation? orientation { get; set; }

            public bearingInformation() {
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
            public String? pictureCaption { get; set; } = null;
            public DateTime? sourceDate { get; set; } = default;
            public String? pictureInformation { get; set; } = null;
            public bearingInformation? bearingInformation { get; set; }

            public graphic() {
                pictorialRepresentation = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class scheduleByDayOfWeek {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public categoryOfSchedule? categoryOfSchedule { get; set; } = default;

            [Required()]
            public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; }

            public scheduleByDayOfWeek() {
                timeIntervalsByDayOfWeek = new();
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
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class telecommunications
#pragma warning restore CS8981
        {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;
            public String? contactInstructions { get; set; } = null;
            public String? telecomCarrier { get; set; } = null;
            public String telecommunicationIdentifier { get; set; } = string.Empty;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public telecommunicationService? telecommunicationService { get; set; } = default;
            public scheduleByDayOfWeek? scheduleByDayOfWeek { get; set; }

            public telecommunications() {
                telecommunicationIdentifier = string.Empty;
            }
        }
    }

    public enum Role {
        [System.ComponentModel.Description("The location in which the information item applies")]
        appliesInLocation,
        [System.ComponentModel.Description("The controlling organization or authority for a geographically located service")]
        controlAuthority,
        [System.ComponentModel.Description("The service controlled by an organisation or authority")]
        controlledService,
        [System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
        theRxN,
        [System.ComponentModel.Description("The usual service hours to which an exception applies")]
        theServiceHours_nsdy,
        [System.ComponentModel.Description("The work hours for a non-standard workday")]
        partialWorkingDay,
        [System.ComponentModel.Description("The responsible authority")]
        responsibleAuthority,
        [System.ComponentModel.Description("The marine protected area for which the authority is responsible")]
        theMarineProtectedArea,
        [System.ComponentModel.Description("The organisation to which information relates")]
        theOrganisation,
        [System.ComponentModel.Description("The information")]
        theInformation,
        [System.ComponentModel.Description("-")]
        permission,
        [System.ComponentModel.Description("-")]
        vslLocation,
        [System.ComponentModel.Description("-")]
        theApplicationRXN,
        [System.ComponentModel.Description("-")]
        isApplicableTo,
        [System.ComponentModel.Description("-")]
        theAuthority,
        [System.ComponentModel.Description("-")]
        theContactDetails,
        [System.ComponentModel.Description("-")]
        theAuthority_srvHrs,
        [System.ComponentModel.Description("-")]
        theServiceHours,
        [System.ComponentModel.Description("-")]
        informationProvidedFor,
        [System.ComponentModel.Description("-")]
        providesInformation,
    }

    namespace Associations {
        namespace SpatialAssociations {
        }

        namespace InformationAssociations {
            using S100Framework.DomainModel.S122.InformationTypes;

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class AssociatedRxN : InformationAssociation {
                public List<RefId> theRxN { get; set; } = [];

                [IgnoreDataMember]
                public virtual String[] theRxNInformationTypes => [];
                public override string Code => nameof(AssociatedRxN);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "theRxN" => theRxNInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public AssociatedRxN() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class ExceptionalWorkday : InformationAssociation {
                public List<RefId> partialWorkingDay { get; set; } = [];
                public List<RefId> theServiceHours_nsdy { get; set; } = [];

                [IgnoreDataMember]
                public virtual String[] partialWorkingDayInformationTypes => [];

                [IgnoreDataMember]
                public virtual String[] theServiceHours_nsdyInformationTypes => [];
                public override string Code => nameof(ExceptionalWorkday);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "partialWorkingDay" => partialWorkingDayInformationTypes,
                    "theServiceHours_nsdy" => theServiceHours_nsdyInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public ExceptionalWorkday() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class ProtectedAreaAuthority : InformationAssociation {
                public List<RefId> responsibleAuthority { get; set; } = [];

                [IgnoreDataMember]
                public virtual String[] responsibleAuthorityInformationTypes => [];
                public override string Code => nameof(ProtectedAreaAuthority);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "responsibleAuthority" => responsibleAuthorityInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public ProtectedAreaAuthority() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class ServiceControl : InformationAssociation {
                public RefId? controlAuthority { get; set; }

                [IgnoreDataMember]
                public virtual String[] controlAuthorityInformationTypes => [];
                public override string Code => nameof(ServiceControl);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "controlAuthority" => controlAuthorityInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public ServiceControl() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class RelatedOrganisation : InformationAssociation {
                public List<RefId> theOrganisation { get; set; } = [];
                public List<RefId> theInformation { get; set; } = [];

                [IgnoreDataMember]
                public virtual String[] theOrganisationInformationTypes => [];

                [IgnoreDataMember]
                public virtual String[] theInformationInformationTypes => [];
                public override string Code => nameof(RelatedOrganisation);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "theOrganisation" => theOrganisationInformationTypes,
                    "theInformation" => theInformationInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public RelatedOrganisation() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class PermissionType : InformationAssociation {
                [Required()]
                public categoryOfRelationship categoryOfRelationship { get; set; }
                public override string Code => nameof(PermissionType);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    _ => throw new InvalidOperationException(),
                };
                public PermissionType() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class InclusionType : InformationAssociation {
                [Required()]
                public membership membership { get; set; }
                public override string Code => nameof(InclusionType);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    _ => throw new InvalidOperationException(),
                };
                public InclusionType() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class AuthorityContact : InformationAssociation {
                public List<RefId> theAuthority { get; set; } = [];
                public List<RefId> theContactDetails { get; set; } = [];

                [IgnoreDataMember]
                public virtual String[] theAuthorityInformationTypes => [];

                [IgnoreDataMember]
                public virtual String[] theContactDetailsInformationTypes => [];
                public override string Code => nameof(AuthorityContact);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "theAuthority" => theAuthorityInformationTypes,
                    "theContactDetails" => theContactDetailsInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public AuthorityContact() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class AuthorityHours : InformationAssociation {
                public List<RefId> theAuthority_srvHrs { get; set; } = [];
                public List<RefId> theServiceHours { get; set; } = [];

                [IgnoreDataMember]
                public virtual String[] theAuthority_srvHrsInformationTypes => [];

                [IgnoreDataMember]
                public virtual String[] theServiceHoursInformationTypes => [];
                public override string Code => nameof(AuthorityHours);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "theAuthority_srvHrs" => theAuthority_srvHrsInformationTypes,
                    "theServiceHours" => theServiceHoursInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public AuthorityHours() {
                }
            }

            [System.Serializable()]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public partial class additionalInformation : InformationAssociation {
                public List<RefId> providesInformation { get; set; } = [];

                [IgnoreDataMember]
                public virtual String[] providesInformationInformationTypes => [];
                public override string Code => nameof(additionalInformation);

                public string[]? this[Role role] => this[role.ToString()];
                public override string[]? this[string role] => role switch
                {
                    "providesInformation" => providesInformationInformationTypes,
                    _ => throw new InvalidOperationException(),
                };
                public additionalInformation() {
                }
            }
        }

        namespace FeatureAssociations {
            using S100Framework.DomainModel.S122.FeatureTypes;
        }
    }

    namespace Bindings {
    }

    namespace InformationTypes {
        using ComplexAttributes;
        using DomainModel;
        using System.Runtime.Serialization;
        using S100Framework.DomainModel.S122.Associations.InformationAssociations;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InformationType : InformationNode {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<graphic> graphic { get; set; } = [];
            public String? source { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            public sourceType? sourceType { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [IgnoreDataMember]
            public override string Code => nameof(InformationType);

            public InformationType() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AbstractRxN : InformationType {
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
            public categoryOfAuthority? categoryOfAuthority { get; set; } = default;
            public textContent? textContent { get; set; }
            public List<rxNCode> rxNCode { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(AbstractRxN);

            public class RelatedOrganisation_theOrganisation : RelatedOrganisation {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theOrganisationInformationTypes => ["Authority"];

                public RelatedOrganisation_theOrganisation() {
                    base.AssociationConnectorTypeName = typeof(AbstractRxN).Name;
                }
            };
            public AbstractRxN() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NauticalInformation : AbstractRxN {
            [IgnoreDataMember]
            public override string Code => nameof(NauticalInformation);

            public class RelatedOrganisation_theOrganisation : RelatedOrganisation {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theOrganisationInformationTypes => ["Authority"];

                public RelatedOrganisation_theOrganisation() {
                    base.AssociationConnectorTypeName = typeof(NauticalInformation).Name;
                }
            };
            public NauticalInformation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Regulations : AbstractRxN {
            [IgnoreDataMember]
            public override string Code => nameof(Regulations);

            public Regulations() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Restrictions : AbstractRxN {
            [IgnoreDataMember]
            public override string Code => nameof(Restrictions);

            public Restrictions() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Recommendations : AbstractRxN {
            [IgnoreDataMember]
            public override string Code => nameof(Recommendations);

            public Recommendations() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Authority : InformationType {
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
            [Required()]
            public categoryOfAuthority categoryOfAuthority { get; set; }
            public List<textContent> textContent { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(Authority);

            public class RelatedOrganisation_theInformation : RelatedOrganisation {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theInformationInformationTypes => ["AbstractRxN"];

                public RelatedOrganisation_theInformation() {
                    base.AssociationConnectorTypeName = typeof(Authority).Name;
                }
            };
            public class AuthorityContact_theContactDetails : AuthorityContact {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theContactDetailsInformationTypes => ["ContactDetails"];

                public AuthorityContact_theContactDetails() {
                    base.AssociationConnectorTypeName = typeof(Authority).Name;
                }
            };
            public class AuthorityHours_theServiceHours : AuthorityHours {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theServiceHoursInformationTypes => ["ServiceHours"];

                public AuthorityHours_theServiceHours() {
                    base.AssociationConnectorTypeName = typeof(Authority).Name;
                }
            };
            public Authority() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContactDetails : AbstractRxN {
            public String? callName { get; set; } = null;
            public String? callSign { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;
            public List<String> communicationChannel { get; set; } = [];
            public String? contactInstructions { get; set; } = null;
            public String? mMSICode { get; set; } = null;
            public List<Int32> signalFrequency { get; set; } = [];
            public List<contactAddress> contactAddress { get; set; } = [];
            public List<frequencyPair> frequencyPair { get; set; } = [];
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<telecommunications> telecommunications { get; set; } = [];
            public List<information> information { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(ContactDetails);

            public class AuthorityContact_theAuthority : AuthorityContact {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theAuthorityInformationTypes => ["Authority"];

                public AuthorityContact_theAuthority() {
                    base.AssociationConnectorTypeName = typeof(ContactDetails).Name;
                }
            };
            public ContactDetails() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NonStandardWorkingDay : InformationType {
            public List<DateOnly> dateFixed { get; set; } = [];
            public List<String> dateVariable { get; set; } = [];
            public List<information> information { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(NonStandardWorkingDay);

            public class ExceptionalWorkday_theServiceHours_nsdy : ExceptionalWorkday {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theServiceHours_nsdyInformationTypes => ["ServiceHours"];

                public ExceptionalWorkday_theServiceHours_nsdy() {
                    base.AssociationConnectorTypeName = typeof(NonStandardWorkingDay).Name;
                }
            };
            public NonStandardWorkingDay() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ServiceHours : InformationType {
            [Required()]
            public List<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; }

            [Required()]
            public information information { get; set; }

            [IgnoreDataMember]
            public override string Code => nameof(ServiceHours);

            public class AuthorityHours_theAuthority_srvHrs : AuthorityHours {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theAuthority_srvHrsInformationTypes => ["Authority"];

                public AuthorityHours_theAuthority_srvHrs() {
                    base.AssociationConnectorTypeName = typeof(ServiceHours).Name;
                }
            };
            public class ExceptionalWorkday_partialWorkingDay : ExceptionalWorkday {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] partialWorkingDayInformationTypes => ["NonStandardWorkingDay"];

                public ExceptionalWorkday_partialWorkingDay() {
                    base.AssociationConnectorTypeName = typeof(ServiceHours).Name;
                }
            };
            public ServiceHours() {
                scheduleByDayOfWeek = new();
                information = new information()
                {
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Applicability : InformationType {
            public Boolean? inBallast { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

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
            public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo { get; set; } = [];

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
            public categoryOfVessel? categoryOfVessel { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public categoryOfVesselRegistry? categoryOfVesselRegistry { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public logicalConnectives? logicalConnectives { get; set; } = default;
            public Int32? thicknessOfIceCapability { get; set; } = default;
            public String? vesselPerformance { get; set; } = null;
            public List<information> information { get; set; } = [];
            public List<vesselsMeasurements> vesselsMeasurements { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(Applicability);

            public Applicability() {
            }
        }
    }

    namespace FeatureTypes {
        using ComplexAttributes;
        using InformationTypes;
        using DomainModel;
        using System.Runtime.Serialization;
        using S100Framework.DomainModel.S122.Associations.InformationAssociations;
        using S100Framework.DomainModel.S122.Associations.FeatureAssociations;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class FeatureType : FeatureNode {
            public List<featureName> featureName { get; set; } = [];
            public fixedDateRange? fixedDateRange { get; set; }
            public List<periodicDateRange> periodicDateRange { get; set; } = [];
            public List<textContent> textContent { get; set; } = [];
            public String interoperabilityIdentifier { get; set; } = string.Empty;
            public String? source { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(10)]
            [EnumerationValue(11)]
            [EnumerationValue(12)]
            [EnumerationValue(13)]
            [EnumerationValue(14)]
            public sourceType? sourceType { get; set; } = default;
            public DateOnly? reportedDate { get; set; } = default;

            [IgnoreDataMember]
            public override string Code => nameof(FeatureType);

            public class AssociatedRxN_theRxN : AssociatedRxN {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] theRxNInformationTypes => ["AbstractRxN"];

                public AssociatedRxN_theRxN() {
                    base.AssociationConnectorTypeName = typeof(FeatureType).Name;
                }
            };
            public class additionalInformation_providesInformation : additionalInformation {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] providesInformationInformationTypes => ["NauticalInformation"];

                public additionalInformation_providesInformation() {
                    base.AssociationConnectorTypeName = typeof(FeatureType).Name;
                }
            };
            public FeatureType() {
                interoperabilityIdentifier = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RestrictedArea : FeatureType {
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
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            [EnumerationValue(33)]
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];

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
            [EnumerationValue(34)]
            [EnumerationValue(35)]
            [EnumerationValue(36)]
            [EnumerationValue(37)]
            [EnumerationValue(38)]
            [EnumerationValue(39)]
            [EnumerationValue(40)]
            [EnumerationValue(41)]
            [Required()]
            public List<restriction> restriction { get; set; }

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
            [EnumerationValue(41)]
            [EnumerationValue(42)]
            [EnumerationValue(43)]
            public List<status> status { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(RestrictedArea);

            public RestrictedArea() {
                restriction = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MarineProtectedArea : FeatureType {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [Required()]
            public categoryOfMarineProtectedArea categoryOfMarineProtectedArea { get; set; }

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
            [EnumerationValue(26)]
            [EnumerationValue(27)]
            [EnumerationValue(28)]
            [EnumerationValue(29)]
            [EnumerationValue(30)]
            [EnumerationValue(31)]
            [EnumerationValue(32)]
            [EnumerationValue(33)]
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [Required()]
            public jurisdiction jurisdiction { get; set; }

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
            [EnumerationValue(34)]
            [EnumerationValue(35)]
            [EnumerationValue(36)]
            [EnumerationValue(37)]
            [EnumerationValue(38)]
            [EnumerationValue(39)]
            [EnumerationValue(40)]
            [EnumerationValue(41)]
            public List<restriction> restriction { get; set; } = [];

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
            [EnumerationValue(41)]
            [EnumerationValue(42)]
            [EnumerationValue(43)]
            public List<status> status { get; set; } = [];
            public List<designation> designation { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(MarineProtectedArea);

            public class ProtectedAreaAuthority_responsibleAuthority : ProtectedAreaAuthority {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] responsibleAuthorityInformationTypes => ["Authority"];

                public ProtectedAreaAuthority_responsibleAuthority() {
                    base.AssociationConnectorTypeName = typeof(MarineProtectedArea).Name;
                }
            };
            public MarineProtectedArea() {
                categoryOfMarineProtectedArea = new categoryOfMarineProtectedArea()
                {
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class VesselTrafficServiceArea : FeatureType {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [Required()]
            public categoryOfVesselTrafficService categoryOfVesselTrafficService { get; set; }

            [IgnoreDataMember]
            public override string Code => nameof(VesselTrafficServiceArea);

            public class ServiceControl_controlAuthority : ServiceControl {
                public override roleType? roleType => DomainModel.roleType.association;

                [IgnoreDataMember]
                public override String[] controlAuthorityInformationTypes => ["Authority"];

                public ServiceControl_controlAuthority() {
                    base.AssociationConnectorTypeName = typeof(VesselTrafficServiceArea).Name;
                }
            };
            public VesselTrafficServiceArea() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DataCoverage : FeatureNode {
            [IgnoreDataMember]
            public override string Code => nameof(DataCoverage);

            public DataCoverage() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TextPlacement : FeatureNode {
            [IgnoreDataMember]
            public override string Code => nameof(TextPlacement);

            public TextPlacement() {
            }
        }
    }
}