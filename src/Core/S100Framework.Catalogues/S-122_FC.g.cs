using System;
using System.Collections.Immutable;
using System.Linq;

#nullable enable

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
        N = 1,

        [System.ComponentModel.Description("Northnortheast")]
        Nne = 2,

        [System.ComponentModel.Description("Northeast")]
        Ne = 3,

        [System.ComponentModel.Description("Eastnortheast")]
        Ene = 4,

        [System.ComponentModel.Description("East")]
        E = 5,

        [System.ComponentModel.Description("Eastsoutheast")]
        Ese = 6,

        [System.ComponentModel.Description("Southeast")]
        Se = 7,

        [System.ComponentModel.Description("Southsoutheast")]
        Sse = 8,

        [System.ComponentModel.Description("South")]
        S = 9,

        [System.ComponentModel.Description("Southsouthwest")]
        Ssw = 10,

        [System.ComponentModel.Description("Southwest")]
        Sw = 11,

        [System.ComponentModel.Description("Westsouthwest")]
        Wsw = 12,

        [System.ComponentModel.Description("West")]
        W = 13,

        [System.ComponentModel.Description("Westnorthwest")]
        Wnw = 14,

        [System.ComponentModel.Description("Northwest")]
        Nw = 15,

        [System.ComponentModel.Description("Northnorthwest")]
        Nnw = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum onlineFunction : int
    {
        [System.ComponentModel.Description("Online instructions for transferring data from one storage device or system to another. (ISO 19115:2014)")]
        Download = 1,

        [System.ComponentModel.Description("Online information about the resource (ISO 19115:2014)")]
        Information = 2,

        [System.ComponentModel.Description("Online instructions for requesting the resource from the provider (ISO 19115:2014)")]
        OfflineAccess = 3,

        [System.ComponentModel.Description("Online order process for obtaining the resource (ISO 19115:2014).")]
        Order = 4,

        [System.ComponentModel.Description("Online search interface for seeking out information about the resource (ISO 19115:2014).")]
        Search = 5,

        [System.ComponentModel.Description("Complete metadata provided (ISO 19115:2014).")]
        CompleteMetadata = 6,

        [System.ComponentModel.Description("Browse graphic provided (ISO 19115:2014).")]
        BrowseGraphic = 7,

        [System.ComponentModel.Description("Online resource upload capability provided (ISO 19115:2014).")]
        Upload = 8,

        [System.ComponentModel.Description("Online email service provided (ISO 19115:2014)")]
        EmailService = 9,

        [System.ComponentModel.Description("Online browsing provided (ISO 19115:2014)")]
        Browsing = 10,

        [System.ComponentModel.Description("online file access provided (ISO 19115:2014).")]
        FileAccess = 11,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristics : int
    {
        [System.ComponentModel.Description("The maximum length of the ship (L.O.A.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        LengthOverall = 1,

        [System.ComponentModel.Description("The ship's length measured at the waterline (L.W.L.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        LengthAtWaterline = 2,

        [System.ComponentModel.Description("The width or beam of the vessel. (Adapted from http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        Breadth = 3,

        [System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        Draught = 4,

        [System.ComponentModel.Description("	The height of the highest point of a vessel's structure (e.g. radar aerial, funnel, cranes, masthead) above her waterline. (UKHO NP100/2009)")]
        Height = 5,

        [System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        DisplacementTonnage = 6,

        [System.ComponentModel.Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        DisplacementTonnageLight = 7,

        [System.ComponentModel.Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        DisplacementTonnageLoaded = 8,

        [System.ComponentModel.Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        DeadweightTonnage = 9,

        [System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        GrossTonnage = 10,

        [System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.(http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
        PanamaCanalUniversalMeasurementSystemNet = 11,

        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
        Tonnage = 12,

        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
        SuezCanalNetTonnage = 13,

        [System.ComponentModel.Description("Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        SuezCanalGrossTonnage = 14,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum vesselsCharacteristicsUnit : int
    {
        [System.ComponentModel.Description("The metre (or meter) is the base unit of length in the International System of Units (SI). It is defined as the distance travelled by light in vacuum in 1/299,792,458 of a second.")]
        Metre = 1,

        [System.ComponentModel.Description("A foot (plural: feet) is a non-SI unit of length in a number of different systems including English units, Imperial units, and United States customary units. The most commonly used foot today is the international foot. There are three feet in a yard and 12 inches in a foot.")]
        Foot = 2,

        [System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6%.")]
        MetricTon = 3,

        [System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m3) of salt water with a density of 64 lb/ft³ (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty—for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
        Ton = 4,

        [System.ComponentModel.Description("The short ton is a unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some U.S. applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the U.S. system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
        ShortTon = 5,

        [System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity. Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
        GrossTon = 6,

        [System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessel’s earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
        NetTon = 7,

        [System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
        PanamaCanalUniversalMeasurementSystemNetTonnage = 8,

        [System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        SuezCanalNetTonnage = 9,

        [System.ComponentModel.Description("Can be used for net and gross tonnages, including Panama Canal/Universal Measurement System net tonnage and The Suez Canal Net Tonnage.")]
        None = 10,

        [System.ComponentModel.Description("Cubic metres")]
        CubicMetres = 11,

        [System.ComponentModel.Description("The Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
        SuezCanalGrossTonnage = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum comparisonOperator : int
    {
        [System.ComponentModel.Description("The value of the left value is greater than that of the right.(http://en.wikipedia.org/wiki/Logical_connective)")]
        GreaterThan = 1,

        [System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        GreaterThanOrEqualTo = 2,

        [System.ComponentModel.Description("The value of the left expression is less than that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        LessThan = 3,

        [System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
        LessThanOrEqualTo = 4,

        [System.ComponentModel.Description("The two values are equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
        EqualTo = 5,

        [System.ComponentModel.Description("The two values are not equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
        NotEqualTo = 6,
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
    public enum categoryOfRelationship : int
    {
        [System.ComponentModel.Description("use of facility, waterway or service is forbidden")]
        Prohibited = 1,

        [System.ComponentModel.Description("use of facility, waterway or service is not recommended")]
        NotRecommended = 2,

        [System.ComponentModel.Description("use of facility, waterway, or service is permitted but not required")]
        Permitted = 3,

        [System.ComponentModel.Description("use of facility, waterway, or service is recommended")]
        Recommended = 4,

        [System.ComponentModel.Description("use of facility, waterway, or service is required")]
        Required = 5,

        [System.ComponentModel.Description("use of facility, waterway or service is not required")]
        NotRequired = 6,
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
    public enum categoryOfCargo : int
    {
        [System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel e.g. oil or grain.")]
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
    public enum categoryOfVesselTrafficService : int
    {
        [System.ComponentModel.Description("A service to ensure that essential information becomes available in time for on-board navigational decision-making.")]
        InformationService = 1,

        [System.ComponentModel.Description("A service to assist on-board navigational decision-making and to monitor its effects.")]
        TrafficOrganizationService = 2,

        [System.ComponentModel.Description("A service to prevent the development of dangerous maritime traffic situations and to provide for the safe and efficient movement of vessel traffic within the VTS area.")]
        NavigationalAssistanceService = 3,

        [System.ComponentModel.Description("A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.")]
        ShipReportingService = 4,

        [System.ComponentModel.Description("A service established to provide port information without interaction between the customer and the service provider. This information could be inter-alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.")]
        LocalPortService = 5,
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

        [System.ComponentModel.Description("Lit by floodlights, strip lights, etc.")]
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

        [System.ComponentModel.Description("When you ask for it.")]
        OnRequest = 19,

        [System.ComponentModel.Description("To become lower in level.")]
        DropAway = 20,

        [System.ComponentModel.Description("To become higher in level.")]
        Rising = 21,

        [System.ComponentModel.Description("Becoming larger in magnitude.")]
        Increasing = 22,

        [System.ComponentModel.Description("Becoming smaller in magnitude.")]
        Decreasing = 23,

        [System.ComponentModel.Description("Not easily broken or destroyed.")]
        Strong = 24,

        [System.ComponentModel.Description("In a satisfactory condition to use.")]
        Good = 25,

        [System.ComponentModel.Description("Fairly but not very.")]
        Moderately = 26,

        [System.ComponentModel.Description("Not as good as it could be or should.")]
        Poor = 27,

        [System.ComponentModel.Description("Marked by buoys.")]
        Buoyed = 28,

        [System.ComponentModel.Description("Entire observation platform is operating in accordance with, or exceeding, manufacturer specifications.")]
        FullyOperational = 29,

        [System.ComponentModel.Description("At least one instrument that is part of an observation platform is not operating to manufacturer specification.")]
        PartiallyOperational = 30,

        [System.ComponentModel.Description("Floating platform at the mercy of environmental elements, whether intentional or not.")]
        Drifting = 31,

        [System.ComponentModel.Description("Fractured or in pieces.")]
        Broken = 32,

        [System.ComponentModel.Description("Observation platform is intentionally not reporting an environmental observation.")]
        Offline = 33,

        [System.ComponentModel.Description("Observation station, suite of instruments, or an individual instrument, for a particular location, has been removed and is no longer at the particular location.")]
        Discontinued = 34,

        [System.ComponentModel.Description("Observations made by a human observer.")]
        ManualObservation = 35,

        [System.ComponentModel.Description("Status of an observation platform, suite of instruments, or individual instrument is not known or unspecified.")]
        UnknownStatus = 36,

        [System.ComponentModel.Description("Made certain as to truth, accuracy, validity, availability, etc.")]
        Confirmed = 37,

        [System.ComponentModel.Description("Item selected for an action.")]
        Candidate = 38,

        [System.ComponentModel.Description("Item that is in the process of being modified.")]
        UnderModification = 39,

        [System.ComponentModel.Description("Item in the process of being removed or deleted.")]
        UnderRemovalDeletion = 41,

        [System.ComponentModel.Description("Item that has been removed or deleted.")]
        RemovedDeleted = 42,

        [System.ComponentModel.Description("Item selected for modification.")]
        CandidateForModification = 43,
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

        [System.ComponentModel.Description("An area within which excavating a hole on the sea-bottom with a drill is prohibited.")]
        DrillingProhibited = 20,

        [System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the sea-bottom with a drill is restricted in accordance with certain specified conditions.")]
        DrillingRestricted = 21,

        [System.ComponentModel.Description("An area within which the removal of historical artefacts is prohibited.")]
        RemovalOfHistoricalArtefactsProhibited = 22,

        [System.ComponentModel.Description("An area in which cargo transhipment (lightening) is prohibited.")]
        CargoTranshipmentLighteningProhibited = 23,

        [System.ComponentModel.Description("An area in which the dragging of anything along the bottom, e.g. bottom trawling, is prohibited.")]
        DraggingProhibited = 24,

        [System.ComponentModel.Description("An area in which a vessel is prohibited from stopping.")]
        StoppingProhibited = 25,

        [System.ComponentModel.Description("An area in which landing is prohibited.")]
        LandingProhibited = 26,

        [System.ComponentModel.Description("An area within which speed is restricted.")]
        SpeedRestricted = 27,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking is generally prohibited.")]
        OvertakingProhibited = 28,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking between convoys is prohibited.")]
        OvertakingOfConvoysByConvoysProhibited = 29,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which passing or overtaking is generally prohibited.")]
        PassingOrOvertakingProhibited = 30,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not berth.")]
        BerthingProhibited = 31,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which berthing is restricted.")]
        BerthingRestricted = 32,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not make fast to the bank.")]
        MakingFastProhibited = 33,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which making fast to the bank is restricted.")]
        MakingFastRestricted = 34,

        [System.ComponentModel.Description("A specified area designated by appropriate authority, within which all turning is generally prohibited.")]
        TurningProhibited = 35,

        [System.ComponentModel.Description("An area within which the fairway depth is restricted.")]
        RestrictedFairwayDepth = 36,

        [System.ComponentModel.Description("An area within which the fairway width is restricted.")]
        RestrictedFairwayWidth = 37,

        [System.ComponentModel.Description("The use of anchoring spuds (telescopic piles) is prohibited.")]
        UseOfSpudsProhibited = 38,

        [System.ComponentModel.Description("An area in which swimming is prohibited.")]
        SwimmingProhibited = 39,

        [System.ComponentModel.Description("An area within which the emission of SOx is restricted.")]
        SoxEmissionRestricted = 40,

        [System.ComponentModel.Description("An area within which the emission of NOx is restricted.")]
        NoxEmissionRestricted = 41,
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

        [System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the sea bed in the range and there are cables leading from the range to a control position ashore.")]
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

        [System.ComponentModel.Description("A tract of land managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
        EcologicalReserve = 23,

        [System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
        NoWakeArea = 24,

        [System.ComponentModel.Description("An area where vessels turn.")]
        SwingingArea = 25,

        [System.ComponentModel.Description("An area within which people may water ski and therefore vessel movement may be restricted.")]
        WaterSkiingArea = 26,

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

        [System.ComponentModel.Description("An area within which the ship pollution emission is controlled.")]
        ShipPollutionEmissionControl = 33,
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
    public enum logicalConnectives : int
    {
        [System.ComponentModel.Description("All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.")]
        LogicalConjunction = 1,

        [System.ComponentModel.Description("At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.")]
        LogicalDisjunction = 2,
    }


    [System.Serializable()]
    public class categoryOfMarineProtectedArea
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class contactAddress
        {
            public String deliveryPoint { get; set; } = string.Empty;

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
                language = string.Empty;
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
            public Int32? frequencyShoreStationReceives { get; set; } = default;

            public Int32? frequencyShoreStationTransmits { get; set; } = default;

            public frequencyPair()
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

            public String protocolRequest { get; set; } = string.Empty;

            public onlineFunction? onlineFunction { get; set; } = default;

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

            public String headline { get; set; } = string.Empty;

            public rxNCode()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sectorLimitOne
        {
            [Required()]
            public Decimal sectorBearing { get; set; }

            public Int32? sectorLineLength { get; set; } = default;

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

            public Int32? sectorLineLength { get; set; } = default;

            public sectorLimitTwo()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class textContent
        {
            public categoryOfText? categoryOfText { get; set; } = default;

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

            public List<TimeOnly> timeOfDayEnd { get; set; } = [];

            public List<TimeOnly> timeOfDayStart { get; set; } = [];

            public timeIntervalsByDayOfWeek()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class vesselsMeasurements
        {
            [Required()]
            public vesselsCharacteristics vesselsCharacteristics { get; set; }

            [Required()]
            public Decimal vesselsCharacteristicsValue { get; set; }

            [Required()]
            public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; }

            [Required()]
            public comparisonOperator comparisonOperator { get; set; }

            public vesselsMeasurements()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
        public partial class designation
#pragma warning restore CS8981
        {
            public String designationScheme { get; set; } = string.Empty;

            public String designationIdentifier { get; set; } = string.Empty;

            public jurisdiction? jurisdiction { get; set; } = default;

            public String text { get; set; } = string.Empty;

            public designation()
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
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
        public partial class telecommunications
#pragma warning restore CS8981
        {
            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;

            public String contactInstructions { get; set; } = string.Empty;

            public String telecomCarrier { get; set; } = string.Empty;

            public String telecommunicationIdentifier { get; set; } = string.Empty;

            public telecommunicationService? telecommunicationService { get; set; } = default;

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

    namespace Associations
    {
        namespace InformationAssociations
        {

            public class AssociatedRxN : InformationAssociation
            {
                public override string Code => "AssociatedRxN";
                public override string[] Roles => ["theRxN", "appliesInLocation"];
                public AssociatedRxN()
                {
                }
            }


            public class ExceptionalWorkday : InformationAssociation
            {
                public override string Code => "ExceptionalWorkday";
                public override string[] Roles => ["partialWorkingDay", "theServiceHours_nsdy"];
                public ExceptionalWorkday()
                {
                }
            }


            public class ProtectedAreaAuthority : InformationAssociation
            {
                public override string Code => "ProtectedAreaAuthority";
                public override string[] Roles => ["responsibleAuthority", "theMarineProtectedArea"];
                public ProtectedAreaAuthority()
                {
                }
            }


            public class ServiceControl : InformationAssociation
            {
                public override string Code => "ServiceControl";
                public override string[] Roles => ["controlAuthority", "controlledService"];
                public ServiceControl()
                {
                }
            }


            public class RelatedOrganisation : InformationAssociation
            {
                public override string Code => "RelatedOrganisation";
                public override string[] Roles => ["theOrganisation", "theInformation"];
                public RelatedOrganisation()
                {
                }
            }


            public class PermissionType : InformationAssociation
            {
                public override string Code => "PermissionType";
                public override string[] Roles => ["vslLocation", "permission"];
                public PermissionType()
                {
                }
                [Required()]
                public categoryOfRelationship categoryOfRelationship { get; set; }
            }


            public class InclusionType : InformationAssociation
            {
                public override string Code => "InclusionType";
                public override string[] Roles => ["theApplicationRXN", "isApplicableTo"];
                public InclusionType()
                {
                }
                [Required()]
                public membership membership { get; set; }
            }


            public class AuthorityContact : InformationAssociation
            {
                public override string Code => "AuthorityContact";
                public override string[] Roles => ["theAuthority", "theContactDetails"];
                public AuthorityContact()
                {
                }
            }


            public class AuthorityHours : InformationAssociation
            {
                public override string Code => "AuthorityHours";
                public override string[] Roles => ["theAuthority_srvHrs", "theServiceHours"];
                public AuthorityHours()
                {
                }
            }


            public class additionalInformation : InformationAssociation
            {
                public override string Code => "additionalInformation";
                public override string[] Roles => ["informationProvidedFor", "providesInformation"];
                public additionalInformation()
                {
                }
            }

        }
        namespace FeatureAssociations
        {
            using S100Framework.DomainModel.S122.FeatureTypes;
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
        public partial class InformationType : InformationNode
        {
            public List<featureName> featureName { get; set; } = [];

            public fixedDateRange? fixedDateRange { get; set; }

            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            public List<graphic> graphic { get; set; } = [];

            public String source { get; set; } = string.Empty;

            public sourceType? sourceType { get; set; } = default;

            public DateOnly? reportedDate { get; set; } = default;
            public override string Code => nameof(InformationType);

            public InformationType()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class AbstractRxN : InformationType
        {
            public categoryOfAuthority? categoryOfAuthority { get; set; } = default;

            public textContent? textContent { get; set; }

            public List<rxNCode> rxNCode { get; set; } = [];
            public override string Code => nameof(AbstractRxN);

            public AbstractRxN()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class NauticalInformation : AbstractRxN
        {
            public override string Code => nameof(NauticalInformation);

            public NauticalInformation()
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
        public partial class Recommendations : AbstractRxN
        {
            public override string Code => nameof(Recommendations);

            public Recommendations()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class Authority : InformationType
        {
            [Required()]
            public categoryOfAuthority categoryOfAuthority { get; set; }

            public List<textContent> textContent { get; set; } = [];
            public override string Code => nameof(Authority);

            public Authority()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContactDetails : AbstractRxN
        {
            public String callName { get; set; } = string.Empty;

            public String callSign { get; set; } = string.Empty;

            public categoryOfCommunicationPreference? categoryOfCommunicationPreference { get; set; } = default;

            public List<String> communicationChannel { get; set; } = [];

            public String contactInstructions { get; set; } = string.Empty;

            public String mMSICode { get; set; } = string.Empty;

            public List<Int32> signalFrequency { get; set; } = [];

            public List<contactAddress> contactAddress { get; set; } = [];

            public List<frequencyPair> frequencyPair { get; set; } = [];

            public List<onlineResource> onlineResource { get; set; } = [];

            public List<telecommunications> telecommunications { get; set; } = [];

            public List<information> information { get; set; } = [];
            public override string Code => nameof(ContactDetails);

            public ContactDetails()
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
        public partial class ServiceHours : InformationType
        {
            [Required()]
            public List<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; }

            [Required()]
            public information information { get; set; }
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


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class FeatureType : FeatureNode
        {
            public List<featureName> featureName { get; set; } = [];

            public fixedDateRange? fixedDateRange { get; set; }

            public List<periodicDateRange> periodicDateRange { get; set; } = [];

            public List<textContent> textContent { get; set; } = [];

            public String interoperabilityIdentifier { get; set; } = string.Empty;

            public String source { get; set; } = string.Empty;

            public sourceType? sourceType { get; set; } = default;

            public DateOnly? reportedDate { get; set; } = default;
            public override string Code => nameof(FeatureType);

            public FeatureType()
            {
                interoperabilityIdentifier = string.Empty;
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class RestrictedArea : FeatureType
        {
            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];

            [Required()]
            public List<restriction> restriction { get; set; }

            public List<status> status { get; set; } = [];
            public override string Code => nameof(RestrictedArea);

            public RestrictedArea()
            {
                restriction = new();
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class MarineProtectedArea : FeatureType
        {
            [Required()]
            public categoryOfMarineProtectedArea categoryOfMarineProtectedArea { get; set; }

            public List<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = [];

            [Required()]
            public jurisdiction jurisdiction { get; set; }

            public List<restriction> restriction { get; set; } = [];

            public List<status> status { get; set; } = [];

            public List<designation> designation { get; set; } = [];
            public override string Code => nameof(MarineProtectedArea);

            public MarineProtectedArea()
            {
                categoryOfMarineProtectedArea = new categoryOfMarineProtectedArea()
                {
                };
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class VesselTrafficServiceArea : FeatureType
        {
            [Required()]
            public categoryOfVesselTrafficService categoryOfVesselTrafficService { get; set; }
            public override string Code => nameof(VesselTrafficServiceArea);

            public VesselTrafficServiceArea()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DataCoverage : FeatureNode
        {
            public override string Code => nameof(DataCoverage);

            public DataCoverage()
            {
            }
        }


        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class TextPlacement : FeatureNode
        {
            public override string Code => nameof(TextPlacement);

            public TextPlacement()
            {
            }
        }

    }
}