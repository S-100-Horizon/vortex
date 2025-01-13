using System;
using System.Collections.Immutable;
using System.Linq;


namespace S100Framework.DomainModel.S128
{

    public static class Information
    {
        public static Version Version => new Version("2.0.0");

        public static string[] ComplexTypes => [
            "contactAddress",
            "customPaperSize",
            "defaultLocale",
            "featureName",
            "information",
            "onlineResource",
            "periodicDateRange",
            "pricing",
            "printSize",
            "productSpecification",
            "supportFileSpecification",
            "serviceSpecification",
            "sourceIndication",
            "telecommunications",
            "timeIntervalOfCycle",
            "weekOfYear",
            "issuanceCycle",
            "printInformation",
            "supportFile",
            "timeIntervalOfProduct",
            "referenceToNM",
        ];

        public static string[] InformationTypes => [
            "CatalogueSectionHeader",
            "ContactDetails",
            "IndicationOfCarriageRequirement",
            "PriceInformation",
            "ProducerInformation",
            "DistributorInformation",
        ];

        public static string[] FeatureTypes => [
            "CatalogueElement",
            "NavigationalProduct",
            "ElectronicProduct",
            "PhysicalProduct",
            "S100Service",
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum catalogueElementClassification : int
    {
        [System.ComponentModel.Description("Electronic Navigational Chart")]
        Enc = 1,

        [System.ComponentModel.Description("Bathymetric Surface")]
        BathymetricChart = 2,

        [System.ComponentModel.Description("Water Level Information for Surface Navigation")]
        WaterLevelProduct = 3,

        [System.ComponentModel.Description("Surface Currents")]
        SurfaceCurrentProduct = 4,

        [System.ComponentModel.Description("MSI(Maritime Safety Information) service")]
        MsiService = 5,

        [System.ComponentModel.Description("Marine Aids to Navigational")]
        AtonInformation = 6,

        [System.ComponentModel.Description("Catalogue Service")]
        CatalogueService = 7,

        [System.ComponentModel.Description("the services associated with the route")]
        RoutingService = 8,

        [System.ComponentModel.Description("ice information")]
        IceInformation = 9,

        [System.ComponentModel.Description("The information associated with the route")]
        RoutingInformation = 10,

        [System.ComponentModel.Description("A special purpose chart")]
        SpecialPurposeChart = 11,

        [System.ComponentModel.Description("Catalogue of Nautical Products")]
        NauticalPublication = 12,

        [System.ComponentModel.Description("Printed nautical chart.")]
        PrintedNauticalChart = 13,
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

        [System.ComponentModel.Description("State agency in charge of marine surveys.")]
        HydrographicOffice = 17,

        [System.ComponentModel.Description("Regional ENC Coordination Centre Entities set up by the IHO.")]
        Renc = 18,

        [System.ComponentModel.Description("Value Added Resellers (VARs), who are able to offer comprehensive end-use services that bring together various navigational products into one package.")]
        Vars = 19,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum nameUsage : int
    {
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
        DefaultNameDisplay = 1,

        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
        AlternateNameDisplay = 2,

        [System.ComponentModel.Description("The name or text is not intended to be displayed.")]
        NoChartDisplay = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum distributionStatus : int
    {
        [System.ComponentModel.Description("The act or process of producing something.")]
        Production = 1,

        [System.ComponentModel.Description("The action to withdraw a time stamp (Used when a time stamp has been reported incorrectly).")]
        Withdrawn = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum IMOMaritimeService : int
    {
        [System.ComponentModel.Description("VTS Information Service(IS)")]
        VesselTrafficService = 1,

        [System.ComponentModel.Description("Navigational Assistance Service(NAS)")]
        AidsToNavigationService = 2,

        [System.ComponentModel.Description("Traffic Organization Service(TOS)")]
        ReservedForFutureUse = 3,

        [System.ComponentModel.Description("Local Port Service")]
        PortSupportService = 4,

        [System.ComponentModel.Description("Maritime Safety Information Service(MSI)")]
        MaritimeSafetyInformationService = 5,

        [System.ComponentModel.Description("Pilotage service")]
        PilotageService = 6,

        [System.ComponentModel.Description("Tug Service")]
        TugService = 7,

        [System.ComponentModel.Description("Vessel Shore Reporting")]
        VesselShoreReporting = 8,

        [System.ComponentModel.Description("Telemedical Assistance Service(TMAS)")]
        TelemedicalAssistanceService = 9,

        [System.ComponentModel.Description("Maritime Assistnace Service(MAS)")]
        MaritimeAssistanceService = 10,

        [System.ComponentModel.Description("Nautical Chart Service")]
        NauticalChartService = 11,

        [System.ComponentModel.Description("Nautical Publications Service")]
        NauticalPublicationsService = 12,

        [System.ComponentModel.Description("Ice Navigation Service")]
        IceNavigationService = 13,

        [System.ComponentModel.Description("Meteorological Information Service")]
        MeteorologicalInformationService = 14,

        [System.ComponentModel.Description("Real-time Hydrographic and Environmental Information Service")]
        RealTimeHydrographicAndEnvironmentalInformationServices = 15,

        [System.ComponentModel.Description("Search and Rescue Service")]
        SearchAndRescueService = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public enum iso216 : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("The first size as output size on nautical paper chart.")]
        A0 = 1,

        [System.ComponentModel.Description("The second size as output size on nautical paper chart.")]
        A1 = 2,

        [System.ComponentModel.Description("The third size as output size on nautical paper chart.")]
        A2 = 3,

        [System.ComponentModel.Description("The fourth size as output size on nautical paper chart.")]
        A3 = 4,

        [System.ComponentModel.Description("The fifth size as output size on nautical paper chart.")]
        A4 = 5,

        [System.ComponentModel.Description("The sixth size as output size on nautical paper chart.")]
        A5 = 6,

        [System.ComponentModel.Description("The seventh size as output size on nautical paper chart.")]
        A6 = 7,

        [System.ComponentModel.Description("The eighth size as output size on nautical paper chart.")]
        A7 = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfProductMapping : int
    {
        [System.ComponentModel.Description("A higher prioritized or recommended alternative product or service, that can fully replace another.")]
        Higherpriorityalternative = 1,

        [System.ComponentModel.Description("A lower prioritized or not recommended alternative product or service, that can fully replace another.")]
        Lowerpriorityalternative = 2,

        [System.ComponentModel.Description("A recommended additional product or service, that provides added value to another.")]
        Recommendedenhancementprovider = 3,

        [System.ComponentModel.Description("A product or service, that is recommended to make use of added value provided by another product or service.")]
        Recommendedenhancementuser = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum digitalSignatureReference : int
    {
        [System.ComponentModel.Description("Elliptic Curve Digital Signature Algorithm (ECDSA) that based upon the issuing certificate. It's signed with the issuer's key P-384.")]
        Ecdsa384Sha2 = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum navigationPurpose : int
    {
        [System.ComponentModel.Description("For port and near shore operations.")]
        Port = 1,

        [System.ComponentModel.Description("For coast and planning purposes.")]
        Transit = 2,

        [System.ComponentModel.Description("For ocean crossing and planning purposes.")]
        Overview = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum supportFileFormat : int
    {
        [System.ComponentModel.Description("UTF-8 text excluding control codes.")]
        Ascii = 1,

        [System.ComponentModel.Description("JPEG2000 format.")]
        Jpeg2000 = 2,

        [System.ComponentModel.Description("Hypertext Markup Language.")]
        Html = 3,

        [System.ComponentModel.Description("Extensible Markup Language.")]
        Xml = 4,

        [System.ComponentModel.Description("Extensible Stylesheet Language Transformations.")]
        Xslt = 5,

        [System.ComponentModel.Description("Representation of moving images in unspecified format.")]
        Video = 6,

        [System.ComponentModel.Description("Tagged Image File Format.")]
        Tiff = 7,

        [System.ComponentModel.Description("Portable Document Format.")]
        PdfAOrUA = 8,

        [System.ComponentModel.Description("Lua programming language.")]
        Lua = 9,

        [System.ComponentModel.Description("Other format.")]
        Other = 100,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum supportFilePurpose : int
    {
        [System.ComponentModel.Description("A file which is new.")]
        New = 1,

        [System.ComponentModel.Description("A file which replaces an existing file.")]
        Replacement = 2,

        [System.ComponentModel.Description("Deletes an existing file.")]
        Deletion = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum serviceStatus : int
    {
        [System.ComponentModel.Description("Under terms not final or fully worked out or agreed upon.")]
        Provisional = 1,

        [System.ComponentModel.Description("Merchandise issued for sale or public showing.")]
        Released = 2,

        [System.ComponentModel.Description("Data that is deprecated in importance and is no longer used and will disappear in the future.")]
        Deprecated = 3,

        [System.ComponentModel.Description("Item that has been removed or deleted.")]
        Deleted = 4,
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
        ProductsIssuedByHoService = 12,

        [System.ComponentModel.Description("Information obtained from news media.")]
        NewsMedia = 13,

        [System.ComponentModel.Description("Information obtained from the analysis of traffic data.")]
        TrafficData = 14,

        [System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
        Maritime = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum specificUsage : int
    {
        [System.ComponentModel.Description("For use in the study of the characteristics of maritime zones, in the formulation of plans, in the selection of routes, etc., showing only relevant elements of the coastline, harbours, islands, principal navigational  marks and obstructions, and submarine landforms. 1:1499999 > Scale. ")]
        NavigationalPurposeOverview = 1,

        [System.ComponentModel.Description("A nautical chart with universality (i.e., generality) in use, characterized by the requirement that the chart must comprehensively describe various natural elements and socioeconomic elements, and that each element of  the subject matter expressed is universal. The scale is between 1:350000-1:1499999.")]
        NavigationalPurposeGeneral = 2,

        [System.ComponentModel.Description("Used for marine navigation, mainly displaying submarine landforms, navigational marks, navigational obstacles and other elements related to navigation. The scale is between 1:90000-1:349999.")]
        NavigationalPurposeCoastal = 3,

        [System.ComponentModel.Description("Used for near-shore navigation, mainly showing the marine elements close to coastal areas. The scale is between 1:22000-1:89999.")]
        NavigationalPurposeApproach = 4,

        [System.ComponentModel.Description("Used for entering and leaving harbours, selecting anchorage, studying harbour topography, and carrying out the construction of harbours. The scale is between 1:4000-1:21999.")]
        NavigationalPurposeHarbour = 5,

        [System.ComponentModel.Description("For ships berthing. Scale > 1:4000.")]
        NavigationalPurposeBerthing = 6,
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
        Streameddata = 5,

        [System.ComponentModel.Description("A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).")]
        Telex = 6,

        [System.ComponentModel.Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
        Telegraph = 7,

        [System.ComponentModel.Description("Messages and other data exchanged between individuals using computers in a network.")]
        Email = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum typeOfProductFormat : int
    {
        [System.ComponentModel.Description("Geography Markup Language. An XML-based geographic information encoding language developed by the Open GIS Consortium (OGC) to enhance the interoperability of geographic information.")]
        Gml = 1,

        [System.ComponentModel.Description("Specification for a data descriptive file for information interchange.")]
        IsoIec8211 = 2,

        [System.ComponentModel.Description("Portable Document Format. A file format developed by Adobe in 1993 to present documents, including text formatting and images, in a manner independent of application software, hardware, and operating systems.")]
        Pdf = 3,

        [System.ComponentModel.Description("Hypertext Markup Language. A type of basic web language used to create web documents.")]
        Html = 4,

        [System.ComponentModel.Description("E-book file format.")]
        Epub = 5,

        [System.ComponentModel.Description("For printing hydrographic charts, heavyweight, single layer paper is used. Such paper is generally made wholly or partly from rags and simulates hand-made paper. It is strong, moisture resistant and manufactured to withstand surface erasure.")]
        Paper = 6,

        [System.ComponentModel.Description("Grid file format.")]
        Hdf5 = 7,

        [System.ComponentModel.Description("Raster data format used by USA and Canada and others.")]
        Bsb = 8,

        [System.ComponentModel.Description("Extension of the TIFF specification to allow the storage of geo- referencing information.")]
        Geotiff = 9,

        [System.ComponentModel.Description("")]
        Application = 10,

        [System.ComponentModel.Description("Extensible Markup Language.")]
        Xml = 11,

        [System.ComponentModel.Description("Portable Network Graphics format.")]
        Png = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum typeOfTimeIntervalUnit : int
    {
        [System.ComponentModel.Description("60 minutes or 3600 seconds.")]
        Hour = 1,

        [System.ComponentModel.Description("for a day.")]
        Day = 2,

        [System.ComponentModel.Description("for a month.")]
        Month = 3,

        [System.ComponentModel.Description("A period of one year.")]
        Year = 4,
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

        [System.ComponentModel.Description("Low water reference level of the local area.")]
        LocalLowWaterReferenceLevel = 31,

        [System.ComponentModel.Description("High water reference level of the local area.")]
        LocalHighWaterReferenceLevel = 32,

        [System.ComponentModel.Description("Mean water reference level of the local area.")]
        LocalMeanWaterReferenceLevel = 33,

        [System.ComponentModel.Description("A low water level which is the result of a defined low water discharge - called \"equivalent discharge\".")]
        EquivalentHeightOfWaterGermanGlw = 34,

        [System.ComponentModel.Description("Upper limit of water levels where navigation is allowed.")]
        HighestShippingHeightOfWaterGermanHsw = 35,

        [System.ComponentModel.Description("The water level at a discharge, which is exceeded 94 % of the year within a period of 30 years.")]
        ReferenceLowWaterLevelAccordingToDanubeCommission = 36,

        [System.ComponentModel.Description("The water level at a discharge, which is exceeded 1% of the year within a period of 30 years.")]
        HighestShippingHeightOfWaterAccordingToDanubeCommission = 37,

        [System.ComponentModel.Description("The water level at a discharge, which is exceeded 95% of the year within a period of 20 years.")]
        DutchRiverLowWaterReferenceLevelOlr = 38,

        [System.ComponentModel.Description("Conditional low water level with established probability.")]
        RussianProjectWaterLevel = 39,

        [System.ComponentModel.Description("Highest water level derived from the upper backwater stream in watercourse or reservoir under the normal operational conditions.")]
        RussianNormalBackwaterLevel = 40,

        [System.ComponentModel.Description("The Ohio River datum.")]
        OhioRiverDatum = 41,

        [System.ComponentModel.Description("Dutch High Water Reference Level.")]
        DutchHighWaterReferenceLevel = 42,

        [System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
        BalticSeaChartDatum2000 = 43,

        [System.ComponentModel.Description("Dutch Estuary Low Water Reference Level (OLW)")]
        DutchEstuaryLowWaterReferenceLevelOlw = 44,

        [System.ComponentModel.Description("The bottom of the ocean and seas where there is a generally smooth gentle gradient. Also referred to as sea bed (sometimes seabed or sea-bed), and sea bottom.")]
        SeaFloor = 45,
    }


    [System.Serializable()]
    public class horizontalDatumEpsg
    {
        public string label { get; set; }

        public string definition { get; set; }

        public int code { get; set; }
    }


    public static class CodeList
    {
        public static ImmutableArray<horizontalDatumEpsg> horizontalDatumEpsgs => ImmutableArray.Create<horizontalDatumEpsg>(new horizontalDatumEpsg[]{
            new() {
                code = 4326,
                definition = "World Geodetic System 1984, used globally for GPS and geographic coordinates. Specifies coordinates in latitude and longitude degrees.",
                label = "WGS 84 (EPSG:4326)",
            },
            new() {
                code = 3857,
                definition = "A popular web mapping projection used by Google Maps, OpenStreetMap, and Bing Maps. Distorts at the poles but is widely used in online maps.",
                label = "WGS 84 / Pseudo-Mercator (EPSG:3857)",
            },
            new() {
                code = 3395,
                definition = "A global Mercator projection commonly used for mapping applications requiring accurate distance measurements near the equator.",
                label = "WGS 84 / World Mercator (EPSG:3395)",
            },
        });
    }

    namespace ComplexAttributes
    {

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class contactAddress
        {
            public String administrativeDivision { get; set; } = string.Empty;
            public String cityName { get; set; } = string.Empty;
            public String countryName { get; set; } = string.Empty;
            public List<String> deliveryPoint { get; set; } = [];
            public String postalCode { get; set; } = string.Empty;

            public contactAddress()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class customPaperSize
        {
            [Required()]
            public Int32 x { get; set; }

            [Required()]
            public Int32 y { get; set; }

            public customPaperSize()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class defaultLocale
        {
            public String characterEncoding { get; set; } = string.Empty;
            public String countryName { get; set; } = string.Empty;
            public String language { get; set; } = string.Empty;

            public defaultLocale()
            {
                characterEncoding = string.Empty;
                countryName = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName
        {
            public String language { get; set; } = string.Empty;
            public String name { get; set; } = string.Empty;
            public nameUsage? nameUsage { get; set; } = default;

            public featureName()
            {
                name = string.Empty;
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
            public List<String> text { get; set; } = [];

            public information()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class onlineResource
        {
            public String applicationProfile { get; set; } = string.Empty;
            public String linkage { get; set; } = string.Empty;
            public String nameOfResource { get; set; } = string.Empty;
            public String onlineDescription { get; set; } = string.Empty;
            public String protocol { get; set; } = string.Empty;
            public String protocolRequest { get; set; } = string.Empty;

            public onlineResource()
            {
                linkage = string.Empty;
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
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class pricing
#pragma warning restore CS8981
        {
            public String contractPeriod { get; set; } = string.Empty;
            public String currency { get; set; } = string.Empty;

            [Required()]
            public Decimal price { get; set; }

            public pricing()
            {
                currency = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class printSize
        {
            public iso216? iso216 { get; set; } = default;
            public customPaperSize? customPaperSize { get; set; }

            public printSize()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class productSpecification
        {
            [Required()]
            public DateTime date { get; set; }
            public String ISSN { get; set; } = string.Empty;
            public String name { get; set; } = string.Empty;
            public String version { get; set; } = string.Empty;

            public productSpecification()
            {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class supportFileSpecification
        {
            [Required()]
            public DateTime date { get; set; }
            public String name { get; set; } = string.Empty;
            public String version { get; set; } = string.Empty;

            public supportFileSpecification()
            {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class serviceSpecification
        {
            [Required()]
            public DateTime date { get; set; }
            public String name { get; set; } = string.Empty;
            public String version { get; set; } = string.Empty;

            public serviceSpecification()
            {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sourceIndication
        {
            public categoryOfAuthority? categoryOfAuthority { get; set; } = default;
            public String countryName { get; set; } = string.Empty;
            public DateTime? reportedDate { get; set; } = default;
            public String source { get; set; } = string.Empty;
            public sourceType? sourceType { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            public sourceIndication()
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
            public List<telecommunicationService> telecommunicationService { get; set; } = [];

            public telecommunications()
            {
                contactInstructions = string.Empty;
                telecommunicationIdentifier = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class timeIntervalOfCycle
        {
            [Required()]
            public List<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit { get; set; }

            [Required()]
            public Int32 valueOfTime { get; set; }

            public timeIntervalOfCycle()
            {
                typeOfTimeIntervalUnit = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class weekOfYear
        {
            [Required()]
            public Int32 weekNumber { get; set; }

            [Required()]
            public Int32 yearNumber { get; set; }

            public weekOfYear()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class issuanceCycle
        {
            public periodicDateRange? periodicDateRange { get; set; }
            public timeIntervalOfCycle? timeIntervalOfCycle { get; set; }

            public issuanceCycle()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class printInformation
        {
            public String printAgency { get; set; } = string.Empty;
            public String printNation { get; set; } = string.Empty;
            public String rePrintEdition { get; set; } = string.Empty;
            public String rePrintNation { get; set; } = string.Empty;

            [Required()]
            public printSize printSize { get; set; }

            public printInformation()
            {
                printSize = new printSize()
                {
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class supportFile
        {
            public String comment { get; set; } = string.Empty;

            [Required()]
            public digitalSignatureReference digitalSignatureReference { get; set; }
            public String digitalSignatureValue { get; set; } = string.Empty;
            public Int32? editionNumber { get; set; } = default;
            public String fileLocator { get; set; } = string.Empty;
            public String fileName { get; set; } = string.Empty;
            public DateTime? issueDate { get; set; } = default;
            public String otherDataTypeDescription { get; set; } = string.Empty;

            [Required()]
            public supportFileFormat supportFileFormat { get; set; }

            [Required()]
            public supportFilePurpose supportFilePurpose { get; set; }

            [Required()]
            public defaultLocale defaultLocale { get; set; }

            [Required()]
            public supportFileSpecification supportFileSpecification { get; set; }

            public supportFile()
            {
                fileLocator = string.Empty;
                fileName = string.Empty;
                defaultLocale = new defaultLocale()
                {
                    characterEncoding = string.Empty,
                    countryName = string.Empty,
                };
                supportFileSpecification = new supportFileSpecification()
                {
                    date = default(DateTime),
                    name = string.Empty,
                    version = string.Empty,
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class timeIntervalOfProduct
        {
            [Required()]
            public DateTime issueDate { get; set; }
            public DateTime? expirationDate { get; set; } = default;
            public issuanceCycle? issuanceCycle { get; set; }

            public timeIntervalOfProduct()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class referenceToNM
        {
            [Required()]
            public DateTime publicationDate { get; set; }
            public weekOfYear? weekOfYear { get; set; }

            public referenceToNM()
            {
            }
        }
    }

    public enum Role
    {
        [System.ComponentModel.Description("the top section of a catalogue")]
        catalogueHeader,

        [System.ComponentModel.Description("Container of element.")]
        elementContainer,

        [System.ComponentModel.Description("Catalogue of Elements.")]
        theCatalogueElement,

        [System.ComponentModel.Description("Types of nautical products")]
        theCatalogueOfNauticalProduct,

        [System.ComponentModel.Description("Information on how to reach a person or organization by postal, internet, telephone, telex and radio systems.")]
        theContactDetails,

        [System.ComponentModel.Description("One that distributes.")]
        theDistributor,

        [System.ComponentModel.Description("a component or part within the context of maritime information and charts.")]
        theElement,

        [System.ComponentModel.Description("Information of price.")]
        thePriceInformation,

        [System.ComponentModel.Description("information about the producer or creator of chart")]
        theProducer,

        [System.ComponentModel.Description("indicates supporting material or information related to a specific element or data.")]
        theReference,

        [System.ComponentModel.Description("essential conditions or functionalities for a specific system or process.")]
        theRequirement,

        [System.ComponentModel.Description("Source of information or data.")]
        theSource,

        [System.ComponentModel.Description("")]
        main,

        [System.ComponentModel.Description("")]
        panel,
    }

    namespace Associations
    {
        namespace InformationAssociations
        {

            public class CarriageRequirement : InformationAssociation
            {
                public override string Code => "CarriageRequirement";
                public override string[] Roles => ["theElement", "theRequirement"];
                public CarriageRequirement()
                {
                }
            }


            public class DistributionDetails : InformationAssociation
            {
                public override string Code => "DistributionDetails";
                public override string[] Roles => ["catalogueHeader", "theDistributor"];
                public DistributionDetails()
                {
                }
            }


            public class DistributorContact : InformationAssociation
            {
                public override string Code => "DistributorContact";
                public override string[] Roles => ["theDistributor", "theContactDetails"];
                public DistributorContact()
                {
                }
            }


            public class PriceOfElement : InformationAssociation
            {
                public override string Code => "PriceOfElement";
                public override string[] Roles => ["theCatalogueElement", "thePriceInformation"];
                public PriceOfElement()
                {
                }
            }


            public class PriceOfNauticalProduct : InformationAssociation
            {
                public override string Code => "PriceOfNauticalProduct";
                public override string[] Roles => ["theCatalogueOfNauticalProduct", "thePriceInformation"];
                public PriceOfNauticalProduct()
                {
                }
            }


            public class ProducerContact : InformationAssociation
            {
                public override string Code => "ProducerContact";
                public override string[] Roles => ["theProducer", "theContactDetails"];
                public ProducerContact()
                {
                }
            }


            public class ProductionDetails : InformationAssociation
            {
                public override string Code => "ProductionDetails";
                public override string[] Roles => ["catalogueHeader", "theProducer"];
                public ProductionDetails()
                {
                }
            }


            public class ProductPackage : InformationAssociation
            {
                public override string Code => "ProductPackage";
                public override string[] Roles => ["theCatalogueElement", "elementContainer"];
                public ProductPackage()
                {
                }
            }

        }
        namespace FeatureAssociations
        {
            using S100Framework.DomainModel.S128.FeatureTypes;

            public class ProductMapping : FeatureAssociation
            {
                public override string Code => "ProductMapping";
                public override string[] Roles => ["theSource", "theReference"];
                public ProductMapping()
                {
                }

                public Type[] theSources => [];
                public Type[] theReferences => [typeof(CatalogueElement)];


                [Required()]
                public categoryOfProductMapping categoryOfProductMapping { get; set; }
            }


            public class Correlated : FeatureAssociation
            {
                public override string Code => "Correlated";
                public override string[] Roles => ["main", "panel"];
                public Correlated()
                {
                }

                public Type[] mains => [typeof(NavigationalProduct)];
                public Type[] panels => [];


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
        public partial class CatalogueSectionHeader : InformationNode
        {
            [Required()]
            public Int32 catalogueSectionNumber { get; set; }
            public String catalogueSectionTitle { get; set; } = string.Empty;
            public information? information { get; set; }
            public override string Code => nameof(CatalogueSectionHeader);

            public CatalogueSectionHeader()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContactDetails : InformationNode
        {
            public String contactInstructions { get; set; } = string.Empty;
            public List<contactAddress> contactAddress { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<telecommunications> telecommunications { get; set; } = [];
            public List<sourceIndication> sourceIndication { get; set; } = [];
            public override string Code => nameof(ContactDetails);

            public ContactDetails()
            {
                contactInstructions = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IndicationOfCarriageRequirement : InformationNode
        {
            public String domesticCarriageRequirements { get; set; } = string.Empty;
            public String internationalCarriageRequirements { get; set; } = string.Empty;
            public List<featureName> featureName { get; set; } = [];
            public override string Code => nameof(IndicationOfCarriageRequirement);

            public IndicationOfCarriageRequirement()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PriceInformation : InformationNode
        {
            public List<information> information { get; set; } = [];
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<pricing> pricing { get; set; } = [];
            public List<sourceIndication> sourceIndication { get; set; } = [];
            public override string Code => nameof(PriceInformation);

            public PriceInformation()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ProducerInformation : InformationNode
        {
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public String agencyName { get; set; } = string.Empty;
            public override string Code => nameof(ProducerInformation);

            public ProducerInformation()
            {
                agencyResponsibleForProduction = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DistributorInformation : InformationNode
        {
            public String distributorName { get; set; } = string.Empty;
            public override string Code => nameof(DistributorInformation);

            public DistributorInformation()
            {
                distributorName = string.Empty;
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
        public abstract partial class CatalogueElement : FeatureNode
        {
            public String agencyResponsibleForProduction { get; set; } = string.Empty;

            [Required()]
            public List<catalogueElementClassification> catalogueElementClassification { get; set; }
            public String catalogueElementIdentifier { get; set; } = string.Empty;
            public String classification { get; set; } = string.Empty;
            public List<IMOMaritimeService> IMOMaritimeService { get; set; } = [];

            [Required()]
            public Boolean notForNavigation { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public onlineResource? onlineResource { get; set; }
            public sourceIndication? sourceIndication { get; set; }
            public List<supportFile> supportFile { get; set; } = [];
            public timeIntervalOfProduct? timeIntervalOfProduct { get; set; }
            public override string Code => nameof(CatalogueElement);

            public CatalogueElement()
            {
                catalogueElementClassification = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class NavigationalProduct : CatalogueElement
        {
            public List<Decimal> approximateGridResolution { get; set; } = [];
            public List<Int32> compilationScale { get; set; } = [];
            public distributionStatus? distributionStatus { get; set; } = default;
            public Int32? editionNumber { get; set; } = default;
            public Int32? maximumDisplayScale { get; set; } = default;
            public Int32? minimumDisplayScale { get; set; } = default;
            public List<navigationPurpose> navigationPurpose { get; set; } = [];
            public String optimumDisplayScale { get; set; } = string.Empty;
            public String originalProductNumber { get; set; } = string.Empty;
            public String producerNation { get; set; } = string.Empty;
            public String productNumber { get; set; } = string.Empty;
            public specificUsage? specificUsage { get; set; } = default;
            public DateTime? updateDate { get; set; } = default;
            public Int32? updateNumber { get; set; } = default;
            public horizontalDatumEpsg? horizontalDatumEpsg { get; set; }
            public verticalDatum? verticalDatum { get; set; } = default;
            public override string Code => nameof(NavigationalProduct);

            public NavigationalProduct()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ElectronicProduct : NavigationalProduct
        {
            public Boolean? compressionFlag { get; set; } = default;
            public String datasetName { get; set; } = string.Empty;

            [Required()]
            public DateTime issueDate { get; set; }
            public TimeOnly? issueTime { get; set; } = default;

            [Required()]
            public typeOfProductFormat typeOfProductFormat { get; set; }
            public productSpecification? productSpecification { get; set; }
            public override string Code => nameof(ElectronicProduct);

            public ElectronicProduct()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PhysicalProduct : NavigationalProduct
        {
            [Required()]
            public DateTime editionDate { get; set; }
            public String isbn { get; set; } = string.Empty;
            public String publicationNumber { get; set; } = string.Empty;
            public String typeOfPaper { get; set; } = string.Empty;
            public printInformation? printInformation { get; set; }
            public referenceToNM? referenceToNM { get; set; }
            public override string Code => nameof(PhysicalProduct);

            public PhysicalProduct()
            {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class S100Service : CatalogueElement
        {
            public Boolean? compressionFlag { get; set; } = default;
            public String serviceName { get; set; } = string.Empty;
            public serviceStatus? serviceStatus { get; set; } = default;

            [Required()]
            public typeOfProductFormat typeOfProductFormat { get; set; }
            public serviceSpecification? serviceSpecification { get; set; }
            public productSpecification? productSpecification { get; set; }
            public override string Code => nameof(S100Service);

            public S100Service()
            {
            }
        }
    }
}