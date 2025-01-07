using System;
using System.Collections.Immutable;
using System.Linq;


namespace S100Framework.DomainModel.S122
{

    public static class Information
    {
        public static Version Version => new Version("1.2.1");

        public static string[] ComplexTypes => [
            "contactAddress",
            "featureName",
            "fixedDateRange",
            "frequencyPair",
            "information",
            "onlineResource",
            "orientation",
            "periodicDateRange",
            "rxNCode",
            "sectorLimitOne",
            "sectorLimitTwo",
            "textContent",
            "timeIntervalsByDayOfWeek",
            "vesselsMeasurements",
            "designation",
            "bearingInformation",
            "graphic",
            "scheduleByDayOfWeek",
            "sectorLimit",
            "telecommunications",
        ];

        public static string[] InformationTypes => [
            "InformationType",
            "AbstractRxN",
            "NauticalInformation",
            "Regulations",
            "Restrictions",
            "Recommendations",
            "Authority",
            "ContactDetails",
            "NonStandardWorkingDay",
            "ServiceHours",
            "Applicability",
        ];

        public static string[] FeatureTypes => [
            "FeatureType",
            "RestrictedArea",
            "MarineProtectedArea",
            "VesselTrafficServiceArea",
            "DataCoverage",
            "TextPlacement",
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum cardinalDirection : int
    {
        [System.ComponentModel.Description("North")]
        [System.Xml.Serialization.XmlEnum("1")]
        N = 1,

        [System.ComponentModel.Description("Northnortheast")]
        [System.Xml.Serialization.XmlEnum("2")]
        Nne = 2,

        [System.ComponentModel.Description("Northeast")]
        [System.Xml.Serialization.XmlEnum("3")]
        Ne = 3,

        [System.ComponentModel.Description("Eastnortheast")]
        [System.Xml.Serialization.XmlEnum("4")]
        Ene = 4,

        [System.ComponentModel.Description("East")]
        [System.Xml.Serialization.XmlEnum("5")]
        E = 5,

        [System.ComponentModel.Description("Eastsoutheast")]
        [System.Xml.Serialization.XmlEnum("6")]
        Ese = 6,

        [System.ComponentModel.Description("Southeast")]
        [System.Xml.Serialization.XmlEnum("7")]
        Se = 7,

        [System.ComponentModel.Description("Southsoutheast")]
        [System.Xml.Serialization.XmlEnum("8")]
        Sse = 8,

        [System.ComponentModel.Description("South")]
        [System.Xml.Serialization.XmlEnum("9")]
        S = 9,

        [System.ComponentModel.Description("Southsouthwest")]
        [System.Xml.Serialization.XmlEnum("10")]
        Ssw = 10,

        [System.ComponentModel.Description("Southwest")]
        [System.Xml.Serialization.XmlEnum("11")]
        Sw = 11,

        [System.ComponentModel.Description("Westsouthwest")]
        [System.Xml.Serialization.XmlEnum("12")]
        Wsw = 12,

        [System.ComponentModel.Description("West")]
        [System.Xml.Serialization.XmlEnum("13")]
        W = 13,

        [System.ComponentModel.Description("Westnorthwest")]
        [System.Xml.Serialization.XmlEnum("14")]
        Wnw = 14,

        [System.ComponentModel.Description("Northwest")]
        [System.Xml.Serialization.XmlEnum("15")]
        Nw = 15,

        [System.ComponentModel.Description("Northnorthwest")]
        [System.Xml.Serialization.XmlEnum("16")]
        Nnw = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum onlineFunction : int
    {
        [System.ComponentModel.Description("Online instructions for transferring data from one storage device or system to another. (ISO 19115:2014)")]
        [System.Xml.Serialization.XmlEnum("1")]
        Download = 1,

        [System.ComponentModel.Description("Online information about the resource (ISO 19115:2014)")]
        [System.Xml.Serialization.XmlEnum("2")]
        Information = 2,

        [System.ComponentModel.Description("Online instructions for requesting the resource from the provider (ISO 19115:2014)")]
        [System.Xml.Serialization.XmlEnum("3")]
        OfflineAccess = 3,

        [System.ComponentModel.Description("Online order process for obtaining the resource (ISO 19115:2014).")]
        [System.Xml.Serialization.XmlEnum("4")]
        Order = 4,

        [System.ComponentModel.Description("Online search interface for seeking out information about the resource (ISO 19115:2014).")]
        [System.Xml.Serialization.XmlEnum("5")]
        Search = 5,

        [System.ComponentModel.Description("Complete metadata provided (ISO 19115:2014).")]
        [System.Xml.Serialization.XmlEnum("6")]
        CompleteMetadata = 6,

        [System.ComponentModel.Description("Browse graphic provided (ISO 19115:2014).")]
        [System.Xml.Serialization.XmlEnum("7")]
        BrowseGraphic = 7,

        [System.ComponentModel.Description("Online resource upload capability provided (ISO 19115:2014).")]
        [System.Xml.Serialization.XmlEnum("8")]
        Upload = 8,

        [System.ComponentModel.Description("Online email service provided (ISO 19115:2014)")]
        [System.Xml.Serialization.XmlEnum("9")]
        EmailService = 9,

        [System.ComponentModel.Description("Online browsing provided (ISO 19115:2014)")]
        [System.Xml.Serialization.XmlEnum("10")]
        Browsing = 10,

        [System.ComponentModel.Description("online file access provided (ISO 19115:2014).")]
        [System.Xml.Serialization.XmlEnum("11")]
        FileAccess = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristics : int
    {
        [System.ComponentModel.Description("The maximum length of the ship (L.O.A.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("1")]
        LengthOverall = 1,

        [System.ComponentModel.Description("The ship's length measured at the waterline (L.W.L.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("2")]
        LengthAtWaterline = 2,

        [System.ComponentModel.Description("The width or beam of the vessel. (Adapted from http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("3")]
        Breadth = 3,

        [System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("4")]
        Draught = 4,

        [System.ComponentModel.Description("	The height of the highest point of a vessel's structure (e.g. radar aerial, funnel, cranes, masthead) above her waterline. (UKHO NP100/2009)")]
        [System.Xml.Serialization.XmlEnum("5")]
        Height = 5,

        [System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("6")]
        DisplacementTonnage = 6,

        [System.ComponentModel.Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("7")]
        DisplacementTonnageLight = 7,

        [System.ComponentModel.Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("8")]
        DisplacementTonnageLoaded = 8,

        [System.ComponentModel.Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("9")]
        DeadweightTonnage = 9,

        [System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("10")]
        GrossTonnage = 10,

        [System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.(http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        [System.Xml.Serialization.XmlEnum("11")]
        PanamaCanalUniversalMeasurementSystemNet = 11,

        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
        [System.Xml.Serialization.XmlEnum("12")]
        Tonnage = 12,

        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
        [System.Xml.Serialization.XmlEnum("13")]
        SuezCanalNetTonnage = 13,

        [System.ComponentModel.Description("Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [System.Xml.Serialization.XmlEnum("14")]
        SuezCanalGrossTonnage = 14,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristicsUnit : int
    {
        [System.ComponentModel.Description("The metre (or meter) is the base unit of length in the International System of Units (SI). It is defined as the distance travelled by light in vacuum in 1/299,792,458 of a second.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Metre = 1,

        [System.ComponentModel.Description("A foot (plural: feet) is a non-SI unit of length in a number of different systems including English units, Imperial units, and United States customary units. The most commonly used foot today is the international foot. There are three feet in a yard and 12 inches in a foot.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Foot = 2,

        [System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6%.")]
        [System.Xml.Serialization.XmlEnum("3")]
        MetricTon = 3,

        [System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m3) of salt water with a density of 64 lb/ft³ (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty—for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
        [System.Xml.Serialization.XmlEnum("4")]
        Ton = 4,

        [System.ComponentModel.Description("The short ton is a unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some U.S. applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the U.S. system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
        [System.Xml.Serialization.XmlEnum("5")]
        ShortTon = 5,

        [System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity. Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
        [System.Xml.Serialization.XmlEnum("6")]
        GrossTon = 6,

        [System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessel’s earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
        [System.Xml.Serialization.XmlEnum("7")]
        NetTon = 7,

        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
        [System.Xml.Serialization.XmlEnum("8")]
        PanamaCanalUniversalMeasurementSystemNetTonnage = 8,

        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [System.Xml.Serialization.XmlEnum("9")]
        SuezCanalNetTonnage = 9,

        [System.ComponentModel.Description("Can be used for net and gross tonnages, including Panama Canal/Universal Measurement System net tonnage and The Suez Canal Net Tonnage.")]
        [System.Xml.Serialization.XmlEnum("10")]
        None = 10,

        [System.ComponentModel.Description("Cubic metres")]
        [System.Xml.Serialization.XmlEnum("11")]
        CubicMetres = 11,

        [System.ComponentModel.Description("The Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        [System.Xml.Serialization.XmlEnum("12")]
        SuezCanalGrossTonnage = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum comparisonOperator : int
    {
        [System.ComponentModel.Description("The value of the left value is greater than that of the right.(http://en.wikipedia.org/wiki/Logical_connective)")]
        [System.Xml.Serialization.XmlEnum("1")]
        GreaterThan = 1,

        [System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        [System.Xml.Serialization.XmlEnum("2")]
        GreaterThanOrEqualTo = 2,

        [System.ComponentModel.Description("The value of the left expression is less than that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        [System.Xml.Serialization.XmlEnum("3")]
        LessThan = 3,

        [System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        [System.Xml.Serialization.XmlEnum("4")]
        LessThanOrEqualTo = 4,

        [System.ComponentModel.Description("The two values are equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
        [System.Xml.Serialization.XmlEnum("5")]
        EqualTo = 5,

        [System.ComponentModel.Description("The two values are not equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
        [System.Xml.Serialization.XmlEnum("6")]
        NotEqualTo = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
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
    [System.Serializable()]
    public enum categoryOfRelationship : int
    {
        [System.ComponentModel.Description("use of facility, waterway or service is forbidden")]
        [System.Xml.Serialization.XmlEnum("1")]
        Prohibited = 1,

        [System.ComponentModel.Description("use of facility, waterway or service is not recommended")]
        [System.Xml.Serialization.XmlEnum("2")]
        NotRecommended = 2,

        [System.ComponentModel.Description("use of facility, waterway, or service is permitted but not required")]
        [System.Xml.Serialization.XmlEnum("3")]
        Permitted = 3,

        [System.ComponentModel.Description("use of facility, waterway, or service is recommended")]
        [System.Xml.Serialization.XmlEnum("4")]
        Recommended = 4,

        [System.ComponentModel.Description("use of facility, waterway, or service is required")]
        [System.Xml.Serialization.XmlEnum("5")]
        Required = 5,

        [System.ComponentModel.Description("use of facility, waterway or service is not required")]
        [System.Xml.Serialization.XmlEnum("6")]
        NotRequired = 6,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
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
    [System.Serializable()]
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
    [System.Serializable()]
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
    [System.Serializable()]
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
    [System.Serializable()]
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
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
    [System.Serializable()]
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
    [System.Serializable()]
    public enum categoryOfVesselTrafficService : int
    {
        [System.ComponentModel.Description("A service to ensure that essential information becomes available in time for on-board navigational decision-making.")]
        [System.Xml.Serialization.XmlEnum("1")]
        InformationService = 1,

        [System.ComponentModel.Description("A service to assist on-board navigational decision-making and to monitor its effects.")]
        [System.Xml.Serialization.XmlEnum("2")]
        TrafficOrganizationService = 2,

        [System.ComponentModel.Description("A service to prevent the development of dangerous maritime traffic situations and to provide for the safe and efficient movement of vessel traffic within the VTS area.")]
        [System.Xml.Serialization.XmlEnum("3")]
        NavigationalAssistanceService = 3,

        [System.ComponentModel.Description("A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.")]
        [System.Xml.Serialization.XmlEnum("4")]
        ShipReportingService = 4,

        [System.ComponentModel.Description("A service established to provide port information without interaction between the customer and the service provider. This information could be inter-alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.")]
        [System.Xml.Serialization.XmlEnum("5")]
        LocalPortService = 5,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
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

        [System.ComponentModel.Description("Lit by floodlights, strip lights, etc.")]
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

        [System.ComponentModel.Description("When you ask for it.")]
        [System.Xml.Serialization.XmlEnum("19")]
        OnRequest = 19,

        [System.ComponentModel.Description("To become lower in level.")]
        [System.Xml.Serialization.XmlEnum("20")]
        DropAway = 20,

        [System.ComponentModel.Description("To become higher in level.")]
        [System.Xml.Serialization.XmlEnum("21")]
        Rising = 21,

        [System.ComponentModel.Description("Becoming larger in magnitude.")]
        [System.Xml.Serialization.XmlEnum("22")]
        Increasing = 22,

        [System.ComponentModel.Description("Becoming smaller in magnitude.")]
        [System.Xml.Serialization.XmlEnum("23")]
        Decreasing = 23,

        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        [System.Xml.Serialization.XmlEnum("24")]
        Strong = 24,

        [System.ComponentModel.Description("In a satisfactory condition to use.")]
        [System.Xml.Serialization.XmlEnum("25")]
        Good = 25,

        [System.ComponentModel.Description("Fairly but not very.")]
        [System.Xml.Serialization.XmlEnum("26")]
        Moderately = 26,

        [System.ComponentModel.Description("Not as good as it could be or should.")]
        [System.Xml.Serialization.XmlEnum("27")]
        Poor = 27,

        [System.ComponentModel.Description("Marked by buoys.")]
        [System.Xml.Serialization.XmlEnum("28")]
        Buoyed = 28,

        [System.ComponentModel.Description("Entire observation platform is operating in accordance with, or exceeding, manufacturer specifications.")]
        [System.Xml.Serialization.XmlEnum("29")]
        FullyOperational = 29,

        [System.ComponentModel.Description("At least one instrument that is part of an observation platform is not operating to manufacturer specification.")]
        [System.Xml.Serialization.XmlEnum("30")]
        PartiallyOperational = 30,

        [System.ComponentModel.Description("Floating platform at the mercy of environmental elements, whether intentional or not.")]
        [System.Xml.Serialization.XmlEnum("31")]
        Drifting = 31,

        [System.ComponentModel.Description("Fractured or in pieces.")]
        [System.Xml.Serialization.XmlEnum("32")]
        Broken = 32,

        [System.ComponentModel.Description("Observation platform is intentionally not reporting an environmental observation.")]
        [System.Xml.Serialization.XmlEnum("33")]
        Offline = 33,

        [System.ComponentModel.Description("Observation station, suite of instruments, or an individual instrument, for a particular location, has been removed and is no longer at the particular location.")]
        [System.Xml.Serialization.XmlEnum("34")]
        Discontinued = 34,

        [System.ComponentModel.Description("Observations made by a human observer.")]
        [System.Xml.Serialization.XmlEnum("35")]
        ManualObservation = 35,

        [System.ComponentModel.Description("Status of an observation platform, suite of instruments, or individual instrument is not known or unspecified.")]
        [System.Xml.Serialization.XmlEnum("36")]
        UnknownStatus = 36,

        [System.ComponentModel.Description("Made certain as to truth, accuracy, validity, availability, etc.")]
        [System.Xml.Serialization.XmlEnum("37")]
        Confirmed = 37,

        [System.ComponentModel.Description("Item selected for an action.")]
        [System.Xml.Serialization.XmlEnum("38")]
        Candidate = 38,

        [System.ComponentModel.Description("Item that is in the process of being modified.")]
        [System.Xml.Serialization.XmlEnum("39")]
        UnderModification = 39,

        [System.ComponentModel.Description("Item in the process of being removed or deleted.")]
        [System.Xml.Serialization.XmlEnum("41")]
        UnderRemovalDeletion = 41,

        [System.ComponentModel.Description("Item that has been removed or deleted.")]
        [System.Xml.Serialization.XmlEnum("42")]
        RemovedDeleted = 42,

        [System.ComponentModel.Description("Item selected for modification.")]
        [System.Xml.Serialization.XmlEnum("43")]
        CandidateForModification = 43,
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
    [System.Serializable()]
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

        [System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the sea bed in the range and there are cables leading from the range to a control position ashore.")]
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

        [System.ComponentModel.Description("A tract of land managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        [System.Xml.Serialization.XmlEnum("23")]
        EcologicalReserve = 23,

        [System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
        [System.Xml.Serialization.XmlEnum("24")]
        NoWakeArea = 24,

        [System.ComponentModel.Description("An area where vessels turn.")]
        [System.Xml.Serialization.XmlEnum("25")]
        SwingingArea = 25,

        [System.ComponentModel.Description("An area within which people may water ski and therefore vessel movement may be restricted.")]
        [System.Xml.Serialization.XmlEnum("26")]
        WaterSkiingArea = 26,

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

        [System.ComponentModel.Description("An area within which the ship pollution emission is controlled.")]
        [System.Xml.Serialization.XmlEnum("33")]
        ShipPollutionEmissionControl = 33,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
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
    [System.Serializable()]
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
    [System.Serializable()]
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
    [System.Serializable()]
    public enum logicalConnectives : int
    {
        [System.ComponentModel.Description("All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.")]
        [System.Xml.Serialization.XmlEnum("1")]
        LogicalConjunction = 1,

        [System.ComponentModel.Description("At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.")]
        [System.Xml.Serialization.XmlEnum("2")]
        LogicalDisjunction = 2,
    }


    [System.Serializable()]
    public class categoryOfMarineProtectedArea
    {
        [System.Xml.Serialization.XmlText()]
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class categoryOfVessel
    {
        [System.Xml.Serialization.XmlText()]
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class actionOrActivity
    {
        [System.Xml.Serialization.XmlText()]
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    [System.Serializable()]
    public class categoryOfRxN
    {
        [System.Xml.Serialization.XmlText()]
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    public static class CodeList
    {
        public static ImmutableArray<categoryOfMarineProtectedArea> categoryOfMarineProtectedAreas => ImmutableArray.Create<categoryOfMarineProtectedArea>(new categoryOfMarineProtectedArea[]{
            new() {
                code = 1,
                definition = "-",
                label = "IUCN Category Ia",
            },
            new() {
                code = 2,
                definition = "-",
                label = "IUCN Category Ib",
            },
            new() {
                code = 3,
                definition = "-",
                label = "IUCN Category II",
            },
            new() {
                code = 4,
                definition = "-",
                label = "IUCN Category III",
            },
            new() {
                code = 5,
                definition = "-",
                label = "IUCN Category IV",
            },
            new() {
                code = 6,
                definition = "-",
                label = "IUCN Category V",
            },
            new() {
                code = 7,
                definition = "-",
                label = "IUCN Category VI",
            },
        });

        public static ImmutableArray<categoryOfVessel> categoryOfVessels => ImmutableArray.Create<categoryOfVessel>(new categoryOfVessel[]{
            new() {
                code = 1,
                definition = "-",
                label = "General Cargo Vessel",
            },
            new() {
                code = 2,
                definition = "-",
                label = "Container Carrier",
            },
            new() {
                code = 3,
                definition = "-",
                label = "Tanker",
            },
            new() {
                code = 4,
                definition = "-",
                label = "Bulk Carrier",
            },
            new() {
                code = 5,
                definition = "-",
                label = "Passenger Vessel",
            },
            new() {
                code = 6,
                definition = "-",
                label = "Roll-On Roll-Off",
            },
            new() {
                code = 7,
                definition = "-",
                label = "Refrigerated Cargo Vessel",
            },
            new() {
                code = 8,
                definition = "-",
                label = "Fishing Vessel",
            },
            new() {
                code = 9,
                definition = "-",
                label = "Service",
            },
            new() {
                code = 10,
                definition = "-",
                label = "Warship",
            },
            new() {
                code = 11,
                definition = "-",
                label = "Towed or Pushed Composite Unit",
            },
            new() {
                code = 12,
                definition = "-",
                label = "Tug and Tow",
            },
            new() {
                code = 13,
                definition = "-",
                label = "Light Recreational",
            },
            new() {
                code = 14,
                definition = "-",
                label = "Semi-Submersible Offshore Installation",
            },
            new() {
                code = 15,
                definition = "-",
                label = "Jack-Up Exploration or Project Installation",
            },
            new() {
                code = 16,
                definition = "-",
                label = "Livestock Carrier",
            },
            new() {
                code = 17,
                definition = "-",
                label = "Sport Fishing",
            },
        });

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
                definition = "A signal station for the control of vessels when berthing.",
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
    }

    namespace ComplexAttributes
    {

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class contactAddress
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String deliveryPoint { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String cityName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String administrativeDivision { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String countryName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String postalCode { get; set; } = string.Empty;

            public contactAddress()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? displayName { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String name { get; set; } = string.Empty;

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
        public partial class fixedDateRange
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateStart { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? dateEnd { get; set; } = default;

            public fixedDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class frequencyPair
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? frequencyShoreStationReceives { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? frequencyShoreStationTransmits { get; set; } = default;

            public frequencyPair()
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
        public partial class onlineResource
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String onlineResourceLinkageURL { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String protocol { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String applicationProfile { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String nameOfResource { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String onlineResourceDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String protocolRequest { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public onlineFunction? onlineFunction { get; set; } = default;

            public onlineResource()
            {
                onlineResourceLinkageURL = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class orientation
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? orientationUncertainty { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Decimal orientationValue { get; set; }

            public orientation()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class periodicDateRange
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public DateOnly dateStart { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public DateOnly dateEnd { get; set; }

            public periodicDateRange()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class rxNCode
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfRxN? categoryOfRxN { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public actionOrActivity? actionOrActivity { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String headline { get; set; } = string.Empty;

            public rxNCode()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitOne
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Decimal sectorBearing { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? sectorLineLength { get; set; } = default;

            public sectorLimitOne()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitTwo
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Decimal sectorBearing { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? sectorLineLength { get; set; } = default;

            public sectorLimitTwo()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class textContent
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfText? categoryOfText { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public sourceType? sourceType { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;

            public textContent()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class timeIntervalsByDayOfWeek
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<dayOfWeek> dayOfWeek { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? dayOfWeekIsRange { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<TimeOnly> timeOfDayEnd { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<TimeOnly> timeOfDayStart { get; set; } = [];

            public timeIntervalsByDayOfWeek()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class vesselsMeasurements
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public vesselsCharacteristics vesselsCharacteristics { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public Decimal vesselsCharacteristicsValue { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public comparisonOperator comparisonOperator { get; set; }

            public vesselsMeasurements()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class designation
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String designationScheme { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String designationIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public jurisdiction? jurisdiction { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String text { get; set; } = string.Empty;

            public designation()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class bearingInformation
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public cardinalDirection? cardinalDirection { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Decimal? distance { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<Decimal> sectorBearing { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public orientation? orientation { get; set; }

            public bearingInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class graphic
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<String> pictorialRepresentation { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictureCaption { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateTime? sourceDate { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String pictureInformation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public bearingInformation? bearingInformation { get; set; }

            public graphic()
            {
                pictorialRepresentation = new();
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class scheduleByDayOfWeek
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfSchedule? categoryOfSchedule { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; }

            public scheduleByDayOfWeek()
            {
                timeIntervalsByDayOfWeek = new();
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimit
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public sectorLimitOne sectorLimitOne { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
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
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class telecommunications
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String telecomCarrier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String telecommunicationIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public telecommunicationService? telecommunicationService { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public scheduleByDayOfWeek? scheduleByDayOfWeek { get; set; }

            public telecommunications()
            {
                telecommunicationIdentifier = string.Empty;
            }
        }
    }

    public enum Role
    {
        [System.ComponentModel.Description("The location in which the information item applies")]
        [System.Xml.Serialization.XmlEnum("appliesInLocation")]
        appliesInLocation,

        [System.ComponentModel.Description("The controlling organization or authority for a geographically located service")]
        [System.Xml.Serialization.XmlEnum("controlAuthority")]
        controlAuthority,

        [System.ComponentModel.Description("The service controlled by an organisation or authority")]
        [System.Xml.Serialization.XmlEnum("controlledService")]
        controlledService,

        [System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
        [System.Xml.Serialization.XmlEnum("theRxN")]
        theRxN,

        [System.ComponentModel.Description("The usual service hours to which an exception applies")]
        [System.Xml.Serialization.XmlEnum("theServiceHours_nsdy")]
        theServiceHours_nsdy,

        [System.ComponentModel.Description("The work hours for a non-standard workday")]
        [System.Xml.Serialization.XmlEnum("partialWorkingDay")]
        partialWorkingDay,

        [System.ComponentModel.Description("The responsible authority")]
        [System.Xml.Serialization.XmlEnum("responsibleAuthority")]
        responsibleAuthority,

        [System.ComponentModel.Description("The marine protected area for which the authority is responsible")]
        [System.Xml.Serialization.XmlEnum("theMarineProtectedArea")]
        theMarineProtectedArea,

        [System.ComponentModel.Description("The organisation to which information relates")]
        [System.Xml.Serialization.XmlEnum("theOrganisation")]
        theOrganisation,

        [System.ComponentModel.Description("The information")]
        [System.Xml.Serialization.XmlEnum("theInformation")]
        theInformation,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("permission")]
        permission,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("vslLocation")]
        vslLocation,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("theApplicationRXN")]
        theApplicationRXN,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("isApplicableTo")]
        isApplicableTo,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("theAuthority")]
        theAuthority,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("theContactDetails")]
        theContactDetails,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("theAuthority_srvHrs")]
        theAuthority_srvHrs,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("theServiceHours")]
        theServiceHours,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("informationProvidedFor")]
        informationProvidedFor,

        [System.ComponentModel.Description("-")]
        [System.Xml.Serialization.XmlEnum("providesInformation")]
        providesInformation,
    }

    namespace Associations
    {
        namespace InformationAssociations
        {

            public class AssociatedRxN : InformationAssociation
            {
                public AssociatedRxN()
                {
                }
                public static Role[] Roles => new[] { Role.theRxN, Role.appliesInLocation };
            }


            public class ExceptionalWorkday : InformationAssociation
            {
                public ExceptionalWorkday()
                {
                }
                public static Role[] Roles => new[] { Role.partialWorkingDay, Role.theServiceHours_nsdy };
            }


            public class ProtectedAreaAuthority : InformationAssociation
            {
                public ProtectedAreaAuthority()
                {
                }
                public static Role[] Roles => new[] { Role.responsibleAuthority, Role.theMarineProtectedArea };
            }


            public class ServiceControl : InformationAssociation
            {
                public ServiceControl()
                {
                }
                public static Role[] Roles => new[] { Role.controlAuthority, Role.controlledService };
            }


            public class RelatedOrganisation : InformationAssociation
            {
                public RelatedOrganisation()
                {
                }
                public static Role[] Roles => new[] { Role.theOrganisation, Role.theInformation };
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


            public class InclusionType : InformationAssociation
            {
                public InclusionType()
                {
                }
                public static Role[] Roles => new[] { Role.theApplicationRXN, Role.isApplicableTo };
                [Required()]
                public membership membership { get; set; }
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


            public class additionalInformation : InformationAssociation
            {
                public additionalInformation()
                {
                }
                public static Role[] Roles => new[] { Role.informationProvidedFor, Role.providesInformation };
            }

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
        using S100Framework.DomainModel.Bindings;


        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class InformationType : InformationTypeBase
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<graphic> graphic { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public sourceType? sourceType { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;
            public override string Code => nameof(InformationType);

            public InformationType()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AbstractRxN : InformationType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfAuthority? categoryOfAuthority { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public textContent? textContent { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<rxNCode> rxNCode { get; set; } = [];


            public class theOrganisationRelatedOrganisation : informationBinding
            {
                public static Type[] informationTypes => [typeof(Authority)];
                public Role Role => Role.theOrganisation;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.RelatedOrganisation RelatedOrganisation { get; set; } = new();
            }

            public List<theOrganisationRelatedOrganisation> associationRelatedOrganisation { get; set; } = [];
            public override string Code => nameof(AbstractRxN);

            public AbstractRxN()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NauticalInformation : AbstractRxN
        {

            public class theOrganisationRelatedOrganisation : informationBinding
            {
                public static Type[] informationTypes => [typeof(Authority)];
                public Role Role => Role.theOrganisation;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.RelatedOrganisation RelatedOrganisation { get; set; } = new();
            }

            public List<theOrganisationRelatedOrganisation> associationRelatedOrganisation { get; set; } = [];
            public override string Code => nameof(NauticalInformation);

            public NauticalInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Regulations : AbstractRxN
        {
            public override string Code => nameof(Regulations);

            public Regulations()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Restrictions : AbstractRxN
        {
            public override string Code => nameof(Restrictions);

            public Restrictions()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Recommendations : AbstractRxN
        {
            public override string Code => nameof(Recommendations);

            public Recommendations()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Authority : InformationType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public categoryOfAuthority categoryOfAuthority { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<textContent> textContent { get; set; } = [];


            public class theInformationRelatedOrganisation : informationBinding
            {
                public static Type[] informationTypes => [typeof(AbstractRxN)];
                public Role Role => Role.theInformation;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.RelatedOrganisation RelatedOrganisation { get; set; } = new();
            }

            public List<theInformationRelatedOrganisation> associationRelatedOrganisation { get; set; } = [];


            public class theContactDetailsAuthorityContact : informationBinding
            {
                public static Type[] informationTypes => [typeof(ContactDetails)];
                public Role Role => Role.theContactDetails;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.AuthorityContact AuthorityContact { get; set; } = new();
            }

            public List<theContactDetailsAuthorityContact> associationAuthorityContact { get; set; } = [];


            public class theServiceHoursAuthorityHours : informationBinding
            {
                public static Type[] informationTypes => [typeof(ServiceHours)];
                public Role Role => Role.theServiceHours;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.AuthorityHours AuthorityHours { get; set; } = new();
            }

            public List<theServiceHoursAuthorityHours> associationAuthorityHours { get; set; } = [];
            public override string Code => nameof(Authority);

            public Authority()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContactDetails : AbstractRxN
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String callName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String callSign { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> communicationChannel { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String mMSICode { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<Int32> signalFrequency { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<contactAddress> contactAddress { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<frequencyPair> frequencyPair { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<onlineResource> onlineResource { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<telecommunications> telecommunications { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];


            public class theAuthorityAuthorityContact : informationBinding
            {
                public static Type[] informationTypes => [typeof(Authority)];
                public Role Role => Role.theAuthority;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.AuthorityContact AuthorityContact { get; set; } = new();
            }

            public List<theAuthorityAuthorityContact> associationAuthorityContact { get; set; } = [];
            public override string Code => nameof(ContactDetails);

            public ContactDetails()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NonStandardWorkingDay : InformationType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<DateOnly> dateFixed { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<String> dateVariable { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];


            public class theServiceHours_nsdyExceptionalWorkday : informationBinding
            {
                public static Type[] informationTypes => [typeof(ServiceHours)];
                public Role Role => Role.theServiceHours_nsdy;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.ExceptionalWorkday ExceptionalWorkday { get; set; } = new();
            }

            public List<theServiceHours_nsdyExceptionalWorkday> associationExceptionalWorkday { get; set; } = [];
            public override string Code => nameof(NonStandardWorkingDay);

            public NonStandardWorkingDay()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ServiceHours : InformationType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public information information { get; set; }


            public class theAuthority_srvHrsAuthorityHours : informationBinding
            {
                public static Type[] informationTypes => [typeof(Authority)];
                public Role Role => Role.theAuthority_srvHrs;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.AuthorityHours AuthorityHours { get; set; } = new();
            }

            public List<theAuthority_srvHrsAuthorityHours> associationAuthorityHours { get; set; } = [];


            public class partialWorkingDayExceptionalWorkday : informationBinding
            {
                public static Type[] informationTypes => [typeof(NonStandardWorkingDay)];
                public Role Role => Role.partialWorkingDay;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.ExceptionalWorkday ExceptionalWorkday { get; set; } = new();
            }

            public List<partialWorkingDayExceptionalWorkday> associationExceptionalWorkday { get; set; } = [];
            public override string Code => nameof(ServiceHours);

            public ServiceHours()
            {
                scheduleByDayOfWeek = new();
                information = new information()
                {
                };
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Applicability : InformationType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Boolean? inBallast { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfCargo> categoryOfCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfVessel? categoryOfVessel { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public categoryOfVesselRegistry? categoryOfVesselRegistry { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public logicalConnectives? logicalConnectives { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public Int32? thicknessOfIceCapability { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String vesselPerformance { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<vesselsMeasurements> vesselsMeasurements { get; set; } = [];
            public override string Code => nameof(Applicability);

            public Applicability()
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
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class FeatureType : FeatureTypeBase
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public fixedDateRange? fixedDateRange { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<textContent> textContent { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String interoperabilityIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public sourceType? sourceType { get; set; } = default;

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public DateOnly? reportedDate { get; set; } = default;


            public class theRxNAssociatedRxN : informationBinding
            {
                public static Type[] informationTypes => [typeof(AbstractRxN)];
                public Role Role => Role.theRxN;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.AssociatedRxN AssociatedRxN { get; set; } = new();
            }

            public List<theRxNAssociatedRxN> associationAssociatedRxN { get; set; } = [];


            public class providesInformationadditionalInformation : informationBinding
            {
                public static Type[] informationTypes => [typeof(NauticalInformation)];
                public Role Role => Role.providesInformation;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.additionalInformation additionalInformation { get; set; } = new();
            }

            public List<providesInformationadditionalInformation> associationadditionalInformation { get; set; } = [];
            public override string Code => nameof(FeatureType);

            public FeatureType()
            {
                interoperabilityIdentifier = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RestrictedArea : FeatureType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public List<restriction> restriction { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];
            public override string Code => nameof(RestrictedArea);

            public RestrictedArea()
            {
                restriction = new();
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MarineProtectedArea : FeatureType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public categoryOfMarineProtectedArea categoryOfMarineProtectedArea { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public jurisdiction jurisdiction { get; set; }

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<restriction> restriction { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<status> status { get; set; } = [];

            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            public List<designation> designation { get; set; } = [];


            public class responsibleAuthorityProtectedAreaAuthority : informationBinding
            {
                public static Type[] informationTypes => [typeof(Authority)];
                public Role Role => Role.responsibleAuthority;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.ProtectedAreaAuthority ProtectedAreaAuthority { get; set; } = new();
            }

            public List<responsibleAuthorityProtectedAreaAuthority> associationProtectedAreaAuthority { get; set; } = [];
            public override string Code => nameof(MarineProtectedArea);

            public MarineProtectedArea()
            {
                categoryOfMarineProtectedArea = new categoryOfMarineProtectedArea()
                {
                };
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class VesselTrafficServiceArea : FeatureType
        {
            [System.Xml.Serialization.XmlElement(Namespace = "http://www.iho.int/S100FC/5.2")]
            [Required()]
            public categoryOfVesselTrafficService categoryOfVesselTrafficService { get; set; }


            public class controlAuthorityServiceControl : informationBinding
            {
                public static Type[] informationTypes => [typeof(Authority)];
                public Role Role => Role.controlAuthority;
                public string? RefId { get; set; } = default;
                public Associations.InformationAssociations.ServiceControl ServiceControl { get; set; } = new();
            }

            public controlAuthorityServiceControl? associationServiceControl { get; set; }
            public override string Code => nameof(VesselTrafficServiceArea);

            public VesselTrafficServiceArea()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DataCoverage : FeatureTypeBase
        {
            public override string Code => nameof(DataCoverage);

            public DataCoverage()
            {
            }
        }

        [System.Serializable()]
        [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
        [System.Xml.Serialization.XmlRoot(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TextPlacement : FeatureTypeBase
        {
            public override string Code => nameof(TextPlacement);

            public TextPlacement()
            {
            }
        }
    }
}