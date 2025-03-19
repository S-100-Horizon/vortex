using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;

#nullable enable
namespace S100Framework.DomainModel.S128 {
    public static class Information {
        public static Version Version => new Version("2.0.0");
        public static string[] ComplexTypes => ["contactAddress", "customPaperSize", "defaultLocale", "featureName", "information", "onlineResource", "periodicDateRange", "pricing", "printSize", "productSpecification", "supportFileSpecification", "serviceSpecification", "sourceIndication", "telecommunications", "timeIntervalOfCycle", "weekOfYear", "issuanceCycle", "printInformation", "supportFile", "timeIntervalOfProduct", "referenceToNM",];
        public static string[] InformationAssociationTypes => ["CarriageRequirement", "DistributionDetails", "DistributorContact", "PriceOfElement", "PriceOfNauticalProduct", "ProducerContact", "ProductionDetails", "ProductPackage",];
        public static string[] FeatureAssociationTypes => ["ProductMapping", "Correlated",];
        public static string[] InformationTypes => ["CatalogueSectionHeader", "ContactDetails", "IndicationOfCarriageRequirement", "PriceInformation", "ProducerInformation", "DistributorInformation",];
        public static string[] FeatureTypes => ["CatalogueElement", "NavigationalProduct", "ElectronicProduct", "PhysicalProduct", "S100Service",];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum catalogueElementClassification : int {
        [System.ComponentModel.Description("Electronic Navigational Chart")]
        [EnumMember(Value = "ENC")]
        Enc = 1,
        [System.ComponentModel.Description("Bathymetric Surface")]
        [EnumMember(Value = "Bathymetric Chart")]
        BathymetricChart = 2,
        [System.ComponentModel.Description("Water Level Information for Surface Navigation")]
        [EnumMember(Value = "Water Level Product")]
        WaterLevelProduct = 3,
        [System.ComponentModel.Description("Surface Currents")]
        [EnumMember(Value = "Surface Current Product")]
        SurfaceCurrentProduct = 4,
        [System.ComponentModel.Description("MSI(Maritime Safety Information) service")]
        [EnumMember(Value = "MSI Service")]
        MsiService = 5,
        [System.ComponentModel.Description("Marine Aids to Navigational")]
        [EnumMember(Value = "AtoN Information")]
        AtonInformation = 6,
        [System.ComponentModel.Description("Catalogue Service")]
        [EnumMember(Value = "Catalogue Service")]
        CatalogueService = 7,
        [System.ComponentModel.Description("the services associated with the route")]
        [EnumMember(Value = "Routing Service")]
        RoutingService = 8,
        [System.ComponentModel.Description("ice information")]
        [EnumMember(Value = "Ice Information")]
        IceInformation = 9,
        [System.ComponentModel.Description("The information associated with the route")]
        [EnumMember(Value = "Routing Information")]
        RoutingInformation = 10,
        [System.ComponentModel.Description("A special purpose chart")]
        [EnumMember(Value = "Special Purpose Chart")]
        SpecialPurposeChart = 11,
        [System.ComponentModel.Description("Catalogue of Nautical Products")]
        [EnumMember(Value = "Nautical Publication")]
        NauticalPublication = 12,
        [System.ComponentModel.Description("Printed nautical chart.")]
        [EnumMember(Value = "Printed Nautical Chart")]
        PrintedNauticalChart = 13,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfAuthority : int {
        [System.ComponentModel.Description("The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.")]
        [EnumMember(Value = "border control")]
        BorderControl = 2,
        [System.ComponentModel.Description("The department of government, or civil force, charged with maintaining public order.")]
        [EnumMember(Value = "police")]
        Police = 3,
        [System.ComponentModel.Description("Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.")]
        [EnumMember(Value = "port")]
        Port = 4,
        [System.ComponentModel.Description("The authority controlling people entering a country.")]
        [EnumMember(Value = "immigration")]
        Immigration = 5,
        [System.ComponentModel.Description("The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.")]
        [EnumMember(Value = "health")]
        Health = 6,
        [System.ComponentModel.Description("Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.")]
        [EnumMember(Value = "coast guard")]
        CoastGuard = 7,
        [System.ComponentModel.Description("The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.")]
        [EnumMember(Value = "agricultural")]
        Agricultural = 8,
        [System.ComponentModel.Description("A military authority which provides control of access to or approval for transit through designated areas or airspace.")]
        [EnumMember(Value = "military")]
        Military = 9,
        [System.ComponentModel.Description("A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.")]
        [EnumMember(Value = "private company")]
        PrivateCompany = 10,
        [System.ComponentModel.Description("A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.")]
        [EnumMember(Value = "maritime police")]
        MaritimePolice = 11,
        [System.ComponentModel.Description("An authority with responsibility for the protection of the environment.")]
        [EnumMember(Value = "environmental")]
        Environmental = 12,
        [System.ComponentModel.Description("An authority with responsibility for the control of fisheries.")]
        [EnumMember(Value = "fishery")]
        Fishery = 13,
        [System.ComponentModel.Description("An authority with responsibility for the control and movement of money.")]
        [EnumMember(Value = "finance")]
        Finance = 14,
        [System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
        [EnumMember(Value = "maritime")]
        Maritime = 15,
        [System.ComponentModel.Description("The agency or establishment for collecting duties, tolls.")]
        [EnumMember(Value = "customs")]
        Customs = 16,
        [System.ComponentModel.Description("State agency in charge of marine surveys.")]
        [EnumMember(Value = "hydrographic office")]
        HydrographicOffice = 17,
        [System.ComponentModel.Description("Regional ENC Coordination Centre Entities set up by the IHO.")]
        [EnumMember(Value = "RENC")]
        Renc = 18,
        [System.ComponentModel.Description("Value Added Resellers (VARs), who are able to offer comprehensive end-use services that bring together various navigational products into one package.")]
        [EnumMember(Value = "VARs")]
        Vars = 19,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum nameUsage : int {
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
        [EnumMember(Value = "default name display")]
        DefaultNameDisplay = 1,
        [System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
        [EnumMember(Value = "alternate name display")]
        AlternateNameDisplay = 2,
        [System.ComponentModel.Description("The name or text is not intended to be displayed.")]
        [EnumMember(Value = "no chart display")]
        NoChartDisplay = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum distributionStatus : int {
        [System.ComponentModel.Description("The act or process of producing something.")]
        [EnumMember(Value = "production")]
        Production = 1,
        [System.ComponentModel.Description("The action to withdraw a time stamp (Used when a time stamp has been reported incorrectly).")]
        [EnumMember(Value = "withdrawn")]
        Withdrawn = 2,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum IMOMaritimeService : int {
        [System.ComponentModel.Description("VTS Information Service(IS)")]
        [EnumMember(Value = "Vessel traffic service")]
        VesselTrafficService = 1,
        [System.ComponentModel.Description("Navigational Assistance Service(NAS)")]
        [EnumMember(Value = "Aids to navigation service")]
        AidsToNavigationService = 2,
        [System.ComponentModel.Description("Traffic Organization Service(TOS)")]
        [EnumMember(Value = "Reserved for future use")]
        ReservedForFutureUse = 3,
        [System.ComponentModel.Description("Local Port Service")]
        [EnumMember(Value = "Port support service")]
        PortSupportService = 4,
        [System.ComponentModel.Description("Maritime Safety Information Service(MSI)")]
        [EnumMember(Value = "Maritime safety information service")]
        MaritimeSafetyInformationService = 5,
        [System.ComponentModel.Description("Pilotage service")]
        [EnumMember(Value = "Pilotage service")]
        PilotageService = 6,
        [System.ComponentModel.Description("Tug Service")]
        [EnumMember(Value = "Tug service")]
        TugService = 7,
        [System.ComponentModel.Description("Vessel Shore Reporting")]
        [EnumMember(Value = "Vessel shore reporting")]
        VesselShoreReporting = 8,
        [System.ComponentModel.Description("Telemedical Assistance Service(TMAS)")]
        [EnumMember(Value = "Telemedical assistance service")]
        TelemedicalAssistanceService = 9,
        [System.ComponentModel.Description("Maritime Assistnace Service(MAS)")]
        [EnumMember(Value = "Maritime assistance service")]
        MaritimeAssistanceService = 10,
        [System.ComponentModel.Description("Nautical Chart Service")]
        [EnumMember(Value = "Nautical chart service")]
        NauticalChartService = 11,
        [System.ComponentModel.Description("Nautical Publications Service")]
        [EnumMember(Value = "Nautical publications service")]
        NauticalPublicationsService = 12,
        [System.ComponentModel.Description("Ice Navigation Service")]
        [EnumMember(Value = "Ice navigation service")]
        IceNavigationService = 13,
        [System.ComponentModel.Description("Meteorological Information Service")]
        [EnumMember(Value = "Meteorological information service")]
        MeteorologicalInformationService = 14,
        [System.ComponentModel.Description("Real-time Hydrographic and Environmental Information Service")]
        [EnumMember(Value = "Real-time hydrographic and environmental information services")]
        RealTimeHydrographicAndEnvironmentalInformationServices = 15,
        [System.ComponentModel.Description("Search and Rescue Service")]
        [EnumMember(Value = "Search and rescue service")]
        SearchAndRescueService = 16,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum iso216 : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("The first size as output size on nautical paper chart.")]
        [EnumMember(Value = "A0")]
        A0 = 1,
        [System.ComponentModel.Description("The second size as output size on nautical paper chart.")]
        [EnumMember(Value = "A1")]
        A1 = 2,
        [System.ComponentModel.Description("The third size as output size on nautical paper chart.")]
        [EnumMember(Value = "A2")]
        A2 = 3,
        [System.ComponentModel.Description("The fourth size as output size on nautical paper chart.")]
        [EnumMember(Value = "A3")]
        A3 = 4,
        [System.ComponentModel.Description("The fifth size as output size on nautical paper chart.")]
        [EnumMember(Value = "A4")]
        A4 = 5,
        [System.ComponentModel.Description("The sixth size as output size on nautical paper chart.")]
        [EnumMember(Value = "A5")]
        A5 = 6,
        [System.ComponentModel.Description("The seventh size as output size on nautical paper chart.")]
        [EnumMember(Value = "A6")]
        A6 = 7,
        [System.ComponentModel.Description("The eighth size as output size on nautical paper chart.")]
        [EnumMember(Value = "A7")]
        A7 = 8,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum categoryOfProductMapping : int {
        [System.ComponentModel.Description("A higher prioritized or recommended alternative product or service, that can fully replace another.")]
        [EnumMember(Value = "higherPriorityAlternative")]
        Higherpriorityalternative = 1,
        [System.ComponentModel.Description("A lower prioritized or not recommended alternative product or service, that can fully replace another.")]
        [EnumMember(Value = "lowerPriorityAlternative")]
        Lowerpriorityalternative = 2,
        [System.ComponentModel.Description("A recommended additional product or service, that provides added value to another.")]
        [EnumMember(Value = "recommendedEnhancementProvider")]
        Recommendedenhancementprovider = 3,
        [System.ComponentModel.Description("A product or service, that is recommended to make use of added value provided by another product or service.")]
        [EnumMember(Value = "recommendedEnhancementUser")]
        Recommendedenhancementuser = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum digitalSignatureReference : int {
        [System.ComponentModel.Description("Elliptic Curve Digital Signature Algorithm (ECDSA) that based upon the issuing certificate. It's signed with the issuer's key P-384.")]
        [EnumMember(Value = "ECDSA-384-SHA2")]
        Ecdsa384Sha2 = 8,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum navigationPurpose : int {
        [System.ComponentModel.Description("For port and near shore operations.")]
        [EnumMember(Value = "port")]
        Port = 1,
        [System.ComponentModel.Description("For coast and planning purposes.")]
        [EnumMember(Value = "transit")]
        Transit = 2,
        [System.ComponentModel.Description("For ocean crossing and planning purposes.")]
        [EnumMember(Value = "overview")]
        Overview = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum supportFileFormat : int {
        [System.ComponentModel.Description("UTF-8 text excluding control codes.")]
        [EnumMember(Value = "ASCII")]
        Ascii = 1,
        [System.ComponentModel.Description("JPEG2000 format.")]
        [EnumMember(Value = "JPEG2000")]
        Jpeg2000 = 2,
        [System.ComponentModel.Description("Hypertext Markup Language.")]
        [EnumMember(Value = "HTML")]
        Html = 3,
        [System.ComponentModel.Description("Extensible Markup Language.")]
        [EnumMember(Value = "XML")]
        Xml = 4,
        [System.ComponentModel.Description("Extensible Stylesheet Language Transformations.")]
        [EnumMember(Value = "XSLT")]
        Xslt = 5,
        [System.ComponentModel.Description("Representation of moving images in unspecified format.")]
        [EnumMember(Value = "VIDEO")]
        Video = 6,
        [System.ComponentModel.Description("Tagged Image File Format.")]
        [EnumMember(Value = "TIFF")]
        Tiff = 7,
        [System.ComponentModel.Description("Portable Document Format.")]
        [EnumMember(Value = "PDF/A or U/A")]
        PdfAOrUA = 8,
        [System.ComponentModel.Description("Lua programming language.")]
        [EnumMember(Value = "LUA")]
        Lua = 9,
        [System.ComponentModel.Description("Other format.")]
        [EnumMember(Value = "other")]
        Other = 100,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum supportFilePurpose : int {
        [System.ComponentModel.Description("A file which is new.")]
        [EnumMember(Value = "new")]
        New = 1,
        [System.ComponentModel.Description("A file which replaces an existing file.")]
        [EnumMember(Value = "replacement")]
        Replacement = 2,
        [System.ComponentModel.Description("Deletes an existing file.")]
        [EnumMember(Value = "deletion")]
        Deletion = 3,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum serviceStatus : int {
        [System.ComponentModel.Description("Under terms not final or fully worked out or agreed upon.")]
        [EnumMember(Value = "provisional")]
        Provisional = 1,
        [System.ComponentModel.Description("Merchandise issued for sale or public showing.")]
        [EnumMember(Value = "released")]
        Released = 2,
        [System.ComponentModel.Description("Data that is deprecated in importance and is no longer used and will disappear in the future.")]
        [EnumMember(Value = "deprecated")]
        Deprecated = 3,
        [System.ComponentModel.Description("Item that has been removed or deleted.")]
        [EnumMember(Value = "deleted")]
        Deleted = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum sourceType : int {
        [System.ComponentModel.Description("Treaty, convention, or international agreement; law or regulation issued by a national or other authority.")]
        [EnumMember(Value = "law or regulation")]
        LawOrRegulation = 1,
        [System.ComponentModel.Description("Publication not having the force of law, issued by an international organisation or a national or local administration.")]
        [EnumMember(Value = "official publication")]
        OfficialPublication = 2,
        [System.ComponentModel.Description("Reported by mariner(s) and confirmed by another source.")]
        [EnumMember(Value = "mariner report, confirmed")]
        MarinerReportConfirmed = 7,
        [System.ComponentModel.Description("Reported by mariner(s) but not confirmed.")]
        [EnumMember(Value = "mariner report, not confirmed")]
        MarinerReportNotConfirmed = 8,
        [System.ComponentModel.Description("Shipping and other industry publications, including graphics, charts and web sites.")]
        [EnumMember(Value = "industry publications and reports")]
        IndustryPublicationsAndReports = 9,
        [System.ComponentModel.Description("Information obtained from satellite images.")]
        [EnumMember(Value = "remotely sensed images")]
        RemotelySensedImages = 10,
        [System.ComponentModel.Description("Information obtained from photographs.")]
        [EnumMember(Value = "photographs")]
        Photographs = 11,
        [System.ComponentModel.Description("Information obtained from products issued by Hydrographic Offices.")]
        [EnumMember(Value = "products issued by HO service")]
        ProductsIssuedByHoService = 12,
        [System.ComponentModel.Description("Information obtained from news media.")]
        [EnumMember(Value = "news media")]
        NewsMedia = 13,
        [System.ComponentModel.Description("Information obtained from the analysis of traffic data.")]
        [EnumMember(Value = "traffic data")]
        TrafficData = 14,
        [System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
        [EnumMember(Value = "maritime")]
        Maritime = 15,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum specificUsage : int {
        [System.ComponentModel.Description("For use in the study of the characteristics of maritime zones, in the formulation of plans, in the selection of routes, etc., showing only relevant elements of the coastline, harbours, islands, principal navigational  marks and obstructions, and submarine landforms. 1:1499999 > Scale. ")]
        [EnumMember(Value = "Navigational Purpose Overview")]
        NavigationalPurposeOverview = 1,
        [System.ComponentModel.Description("A nautical chart with universality (i.e., generality) in use, characterized by the requirement that the chart must comprehensively describe various natural elements and socioeconomic elements, and that each element of  the subject matter expressed is universal. The scale is between 1:350000-1:1499999.")]
        [EnumMember(Value = "Navigational Purpose General")]
        NavigationalPurposeGeneral = 2,
        [System.ComponentModel.Description("Used for marine navigation, mainly displaying submarine landforms, navigational marks, navigational obstacles and other elements related to navigation. The scale is between 1:90000-1:349999.")]
        [EnumMember(Value = "Navigational Purpose Coastal")]
        NavigationalPurposeCoastal = 3,
        [System.ComponentModel.Description("Used for near-shore navigation, mainly showing the marine elements close to coastal areas. The scale is between 1:22000-1:89999.")]
        [EnumMember(Value = "Navigational Purpose Approach")]
        NavigationalPurposeApproach = 4,
        [System.ComponentModel.Description("Used for entering and leaving harbours, selecting anchorage, studying harbour topography, and carrying out the construction of harbours. The scale is between 1:4000-1:21999.")]
        [EnumMember(Value = "Navigational Purpose Harbour")]
        NavigationalPurposeHarbour = 5,
        [System.ComponentModel.Description("For ships berthing. Scale > 1:4000.")]
        [EnumMember(Value = "Navigational Purpose Berthing")]
        NavigationalPurposeBerthing = 6,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum telecommunicationService : int {
        [System.ComponentModel.Description("The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.")]
        [EnumMember(Value = "voice")]
        Voice = 1,
        [System.ComponentModel.Description("A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.")]
        [EnumMember(Value = "facsimile")]
        Facsimile = 2,
        [System.ComponentModel.Description("Short Message Service is a form of text messaging communication on phones and mobile phones.")]
        [EnumMember(Value = "sms")]
        Sms = 3,
        [System.ComponentModel.Description("A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.")]
        [EnumMember(Value = "data")]
        Data = 4,
        [System.ComponentModel.Description("Data that is constantly received by and presented to an end-user while being delivered by a provider.")]
        [EnumMember(Value = "streamedData")]
        Streameddata = 5,
        [System.ComponentModel.Description("A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).")]
        [EnumMember(Value = "telex")]
        Telex = 6,
        [System.ComponentModel.Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
        [EnumMember(Value = "telegraph")]
        Telegraph = 7,
        [System.ComponentModel.Description("Messages and other data exchanged between individuals using computers in a network.")]
        [EnumMember(Value = "email")]
        Email = 8,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum typeOfProductFormat : int {
        [System.ComponentModel.Description("Geography Markup Language. An XML-based geographic information encoding language developed by the Open GIS Consortium (OGC) to enhance the interoperability of geographic information.")]
        [EnumMember(Value = "GML")]
        Gml = 1,
        [System.ComponentModel.Description("Specification for a data descriptive file for information interchange.")]
        [EnumMember(Value = "ISO/IEC 8211")]
        IsoIec8211 = 2,
        [System.ComponentModel.Description("Portable Document Format. A file format developed by Adobe in 1993 to present documents, including text formatting and images, in a manner independent of application software, hardware, and operating systems.")]
        [EnumMember(Value = "PDF")]
        Pdf = 3,
        [System.ComponentModel.Description("Hypertext Markup Language. A type of basic web language used to create web documents.")]
        [EnumMember(Value = "HTML")]
        Html = 4,
        [System.ComponentModel.Description("E-book file format.")]
        [EnumMember(Value = "ePub")]
        Epub = 5,
        [System.ComponentModel.Description("For printing hydrographic charts, heavyweight, single layer paper is used. Such paper is generally made wholly or partly from rags and simulates hand-made paper. It is strong, moisture resistant and manufactured to withstand surface erasure.")]
        [EnumMember(Value = "paper")]
        Paper = 6,
        [System.ComponentModel.Description("Grid file format.")]
        [EnumMember(Value = "HDF-5")]
        Hdf5 = 7,
        [System.ComponentModel.Description("Raster data format used by USA and Canada and others.")]
        [EnumMember(Value = "BSB")]
        Bsb = 8,
        [System.ComponentModel.Description("Extension of the TIFF specification to allow the storage of geo- referencing information.")]
        [EnumMember(Value = "GeoTiff")]
        Geotiff = 9,
        [System.ComponentModel.Description("")]
        [EnumMember(Value = "Application")]
        Application = 10,
        [System.ComponentModel.Description("Extensible Markup Language.")]
        [EnumMember(Value = "XML")]
        Xml = 11,
        [System.ComponentModel.Description("Portable Network Graphics format.")]
        [EnumMember(Value = "PNG")]
        Png = 12,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum typeOfTimeIntervalUnit : int {
        [System.ComponentModel.Description("60 minutes or 3600 seconds.")]
        [EnumMember(Value = "hour")]
        Hour = 1,
        [System.ComponentModel.Description("for a day.")]
        [EnumMember(Value = "day")]
        Day = 2,
        [System.ComponentModel.Description("for a month.")]
        [EnumMember(Value = "month")]
        Month = 3,
        [System.ComponentModel.Description("A period of one year.")]
        [EnumMember(Value = "year")]
        Year = 4,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Serializable()]
    public enum verticalDatum : int {
        [System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.")]
        [EnumMember(Value = "Mean Low Water Springs")]
        MeanLowWaterSprings = 1,
        [System.ComponentModel.Description("The average height of lower low water springs at a place.")]
        [EnumMember(Value = "Mean Lower Low Water Springs")]
        MeanLowerLowWaterSprings = 2,
        [System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
        [EnumMember(Value = "Mean Sea Level")]
        MeanSeaLevel = 3,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.")]
        [EnumMember(Value = "Lowest Low Water")]
        LowestLowWater = 4,
        [System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean Low Water")]
        MeanLowWater = 5,
        [System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
        [EnumMember(Value = "Lowest Low Water Springs")]
        LowestLowWaterSprings = 6,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
        [EnumMember(Value = "Approximate Mean Low Water Springs")]
        ApproximateMeanLowWaterSprings = 7,
        [System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
        [EnumMember(Value = "Indian Spring Low Water")]
        IndianSpringLowWater = 8,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
        [EnumMember(Value = "Low Water Springs")]
        LowWaterSprings = 9,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
        [EnumMember(Value = "Approximate Lowest Astronomical Tide")]
        ApproximateLowestAstronomicalTide = 10,
        [System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
        [EnumMember(Value = "Nearly Lowest Low Water")]
        NearlyLowestLowWater = 11,
        [System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean Lower Low Water")]
        MeanLowerLowWater = 12,
        [System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
        [EnumMember(Value = "Low Water")]
        LowWater = 13,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
        [EnumMember(Value = "Approximate Mean Low Water")]
        ApproximateMeanLowWater = 14,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
        [EnumMember(Value = "Approximate Mean Lower Low Water")]
        ApproximateMeanLowerLowWater = 15,
        [System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean High Water")]
        MeanHighWater = 16,
        [System.ComponentModel.Description("The average height of the high waters of spring tides.")]
        [EnumMember(Value = "Mean High Water Springs")]
        MeanHighWaterSprings = 17,
        [System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
        [EnumMember(Value = "High Water")]
        HighWater = 18,
        [System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
        [EnumMember(Value = "Approximate Mean Sea Level")]
        ApproximateMeanSeaLevel = 19,
        [System.ComponentModel.Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
        [EnumMember(Value = "High Water Springs")]
        HighWaterSprings = 20,
        [System.ComponentModel.Description("The average height of higher high waters at a place over a 19-year period.")]
        [EnumMember(Value = "Mean Higher High Water")]
        MeanHigherHighWater = 21,
        [System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
        [EnumMember(Value = "Equinoctial Spring Low Water")]
        EquinoctialSpringLowWater = 22,
        [System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        [EnumMember(Value = "Lowest Astronomical Tide")]
        LowestAstronomicalTide = 23,
        [System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
        [EnumMember(Value = "Local Datum")]
        LocalDatum = 24,
        [System.ComponentModel.Description("A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Pere, Quebec, over the period 1970 to 1988.")]
        [EnumMember(Value = "International Great Lakes Datum 1985")]
        InternationalGreatLakesDatum1985 = 25,
        [System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
        [EnumMember(Value = "Mean Water Level")]
        MeanWaterLevel = 26,
        [System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
        [EnumMember(Value = "Lower Low Water Large Tide")]
        LowerLowWaterLargeTide = 27,
        [System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
        [EnumMember(Value = "Higher High Water Large Tide")]
        HigherHighWaterLargeTide = 28,
        [System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
        [EnumMember(Value = "Nearly Highest High Water")]
        NearlyHighestHighWater = 29,
        [System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
        [EnumMember(Value = "Highest Astronomical Tide")]
        HighestAstronomicalTide = 30,
        [System.ComponentModel.Description("Low water reference level of the local area.")]
        [EnumMember(Value = "Local Low Water Reference Level")]
        LocalLowWaterReferenceLevel = 31,
        [System.ComponentModel.Description("High water reference level of the local area.")]
        [EnumMember(Value = "Local High Water Reference Level")]
        LocalHighWaterReferenceLevel = 32,
        [System.ComponentModel.Description("Mean water reference level of the local area.")]
        [EnumMember(Value = "Local Mean Water Reference Level")]
        LocalMeanWaterReferenceLevel = 33,
        [System.ComponentModel.Description("A low water level which is the result of a defined low water discharge - called \"equivalent discharge\".")]
        [EnumMember(Value = "Equivalent Height of Water (German GlW)")]
        EquivalentHeightOfWaterGermanGlw = 34,
        [System.ComponentModel.Description("Upper limit of water levels where navigation is allowed.")]
        [EnumMember(Value = "Highest Shipping Height of Water (German HSW)")]
        HighestShippingHeightOfWaterGermanHsw = 35,
        [System.ComponentModel.Description("The water level at a discharge, which is exceeded 94 % of the year within a period of 30 years.")]
        [EnumMember(Value = "Reference Low Water Level According to Danube Commission")]
        ReferenceLowWaterLevelAccordingToDanubeCommission = 36,
        [System.ComponentModel.Description("The water level at a discharge, which is exceeded 1% of the year within a period of 30 years.")]
        [EnumMember(Value = "Highest Shipping Height of Water According to Danube Commission")]
        HighestShippingHeightOfWaterAccordingToDanubeCommission = 37,
        [System.ComponentModel.Description("The water level at a discharge, which is exceeded 95% of the year within a period of 20 years.")]
        [EnumMember(Value = "Dutch River Low Water Reference Level (OLR)")]
        DutchRiverLowWaterReferenceLevelOlr = 38,
        [System.ComponentModel.Description("Conditional low water level with established probability.")]
        [EnumMember(Value = "Russian Project Water Level")]
        RussianProjectWaterLevel = 39,
        [System.ComponentModel.Description("Highest water level derived from the upper backwater stream in watercourse or reservoir under the normal operational conditions.")]
        [EnumMember(Value = "Russian Normal Backwater Level")]
        RussianNormalBackwaterLevel = 40,
        [System.ComponentModel.Description("The Ohio River datum.")]
        [EnumMember(Value = "Ohio River Datum")]
        OhioRiverDatum = 41,
        [System.ComponentModel.Description("Dutch High Water Reference Level.")]
        [EnumMember(Value = "Dutch High Water Reference Level")]
        DutchHighWaterReferenceLevel = 42,
        [System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
        [EnumMember(Value = "Baltic Sea Chart Datum 2000")]
        BalticSeaChartDatum2000 = 43,
        [System.ComponentModel.Description("Dutch Estuary Low Water Reference Level (OLW)")]
        [EnumMember(Value = "Dutch Estuary Low Water Reference Level (OLW)")]
        DutchEstuaryLowWaterReferenceLevelOlw = 44,
        [System.ComponentModel.Description("The bottom of the ocean and seas where there is a generally smooth gentle gradient. Also referred to as sea bed (sometimes seabed or sea-bed), and sea bottom.")]
        [EnumMember(Value = "Sea Floor")]
        SeaFloor = 45,
        [System.ComponentModel.Description("Unknown value.")]
        [EnumMember(Value = "Unknown")]
        Unknown = -1,
    }

    [System.Serializable()]
    public class horizontalDatumEpsg {
        public string label { get; set; }
        public string definition { get; set; }
        public int code { get; set; }
    }

    public static class CodeList {
        public static ImmutableArray<horizontalDatumEpsg> horizontalDatumEpsgs => ImmutableArray.Create<horizontalDatumEpsg>(new horizontalDatumEpsg[] { new() { code = 4326, definition = "World Geodetic System 1984, used globally for GPS and geographic coordinates. Specifies coordinates in latitude and longitude degrees.", label = "WGS 84 (EPSG:4326)", }, new() { code = 3857, definition = "A popular web mapping projection used by Google Maps, OpenStreetMap, and Bing Maps. Distorts at the poles but is widely used in online maps.", label = "WGS 84 / Pseudo-Mercator (EPSG:3857)", }, new() { code = 3395, definition = "A global Mercator projection commonly used for mapping applications requiring accurate distance measurements near the equator.", label = "WGS 84 / World Mercator (EPSG:3395)", }, });
    }

    namespace ComplexAttributes {
        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class contactAddress {
            public String? administrativeDivision { get; set; } = null;
            public String? cityName { get; set; } = null;
            public String? countryName { get; set; } = null;
            public List<String> deliveryPoint { get; set; } = [];
            public String? postalCode { get; set; } = null;

            public contactAddress() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class customPaperSize {
            [Required()]
            public Int32 x { get; set; }

            [Required()]
            public Int32 y { get; set; }

            public customPaperSize() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class defaultLocale {
            public String characterEncoding { get; set; } = string.Empty;
            public String countryName { get; set; } = string.Empty;
            public String? language { get; set; } = null;

            public defaultLocale() {
                characterEncoding = string.Empty;
                countryName = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class featureName {
            public String? language { get; set; } = null;
            public String name { get; set; } = string.Empty;
            public nameUsage? nameUsage { get; set; } = default;

            public featureName() {
                name = string.Empty;
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
            public List<String> text { get; set; } = [];

            public information() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class onlineResource {
            public String? applicationProfile { get; set; } = null;
            public String linkage { get; set; } = string.Empty;
            public String? nameOfResource { get; set; } = null;
            public String? onlineDescription { get; set; } = null;
            public String? protocol { get; set; } = null;
            public String? protocolRequest { get; set; } = null;

            public onlineResource() {
                linkage = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class periodicDateRange {
            [Required()]
            public DateOnly dateEnd { get; set; }

            [Required()]
            public DateOnly dateStart { get; set; }

            public periodicDateRange() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public partial class pricing
#pragma warning restore CS8981
        {
            public String? contractPeriod { get; set; } = null;
            public String currency { get; set; } = string.Empty;

            [Required()]
            public Decimal price { get; set; }

            public pricing() {
                currency = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class printSize {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public iso216? iso216 { get; set; } = default;
            public customPaperSize? customPaperSize { get; set; }

            public printSize() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class productSpecification {
            [Required()]
            public DateTime date { get; set; }
            public String? ISSN { get; set; } = null;
            public String name { get; set; } = string.Empty;
            public String version { get; set; } = string.Empty;

            public productSpecification() {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class supportFileSpecification {
            [Required()]
            public DateTime date { get; set; }
            public String name { get; set; } = string.Empty;
            public String version { get; set; } = string.Empty;

            public supportFileSpecification() {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class serviceSpecification {
            [Required()]
            public DateTime date { get; set; }
            public String name { get; set; } = string.Empty;
            public String version { get; set; } = string.Empty;

            public serviceSpecification() {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class sourceIndication {
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
            public categoryOfAuthority? categoryOfAuthority { get; set; } = default;
            public String? countryName { get; set; } = null;
            public DateTime? reportedDate { get; set; } = default;
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
            [EnumerationValue(15)]
            public sourceType? sourceType { get; set; } = default;
            public List<featureName> featureName { get; set; } = [];

            public sourceIndication() {
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

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            public List<telecommunicationService> telecommunicationService { get; set; } = [];

            public telecommunications() {
                contactInstructions = string.Empty;
                telecommunicationIdentifier = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class timeIntervalOfCycle {
            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [Required()]
            public List<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit { get; set; }

            [Required()]
            public Int32 valueOfTime { get; set; }

            public timeIntervalOfCycle() {
                typeOfTimeIntervalUnit = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class weekOfYear {
            [Required()]
            public Int32 weekNumber { get; set; }

            [Required()]
            public Int32 yearNumber { get; set; }

            public weekOfYear() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class issuanceCycle {
            public periodicDateRange? periodicDateRange { get; set; }
            public timeIntervalOfCycle? timeIntervalOfCycle { get; set; }

            public issuanceCycle() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class printInformation {
            public String? printAgency { get; set; } = null;
            public String? printNation { get; set; } = null;
            public String? rePrintEdition { get; set; } = null;
            public String? rePrintNation { get; set; } = null;

            [Required()]
            public printSize printSize { get; set; }

            public printInformation() {
                printSize = new printSize()
                {
                };
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class supportFile {
            public String? comment { get; set; } = null;

            [EnumerationValue(1)]
            [Required()]
            public digitalSignatureReference digitalSignatureReference { get; set; }
            public String? digitalSignatureValue { get; set; } = null;
            public Int32? editionNumber { get; set; } = default;
            public String fileLocator { get; set; } = string.Empty;
            public String fileName { get; set; } = string.Empty;
            public DateTime? issueDate { get; set; } = default;
            public String? otherDataTypeDescription { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            [EnumerationValue(7)]
            [EnumerationValue(8)]
            [EnumerationValue(9)]
            [EnumerationValue(100)]
            [Required()]
            public supportFileFormat supportFileFormat { get; set; }

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [Required()]
            public supportFilePurpose supportFilePurpose { get; set; }

            [Required()]
            public defaultLocale defaultLocale { get; set; }

            [Required()]
            public supportFileSpecification supportFileSpecification { get; set; }

            public supportFile() {
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
        public partial class timeIntervalOfProduct {
            [Required()]
            public DateTime issueDate { get; set; }
            public DateTime? expirationDate { get; set; } = default;
            public issuanceCycle? issuanceCycle { get; set; }

            public timeIntervalOfProduct() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class referenceToNM {
            [Required()]
            public DateTime publicationDate { get; set; }
            public weekOfYear? weekOfYear { get; set; }

            public referenceToNM() {
            }
        }
    }

    public enum Role {
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

    namespace Associations {
        namespace InformationAssociations {
        }

        namespace FeatureAssociations {
            using S100Framework.DomainModel.S128.FeatureTypes;
        }
    }

    namespace Bindings {
    }

    namespace InformationTypes {
        using ComplexAttributes;
        using DomainModel;
        using System.Runtime.Serialization;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class CatalogueSectionHeader : InformationNode {
            [Required()]
            public Int32 catalogueSectionNumber { get; set; }
            public String? catalogueSectionTitle { get; set; } = null;
            public information? information { get; set; }

            [IgnoreDataMember]
            public override string Code => nameof(CatalogueSectionHeader);

            public CatalogueSectionHeader() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ContactDetails : InformationNode {
            public String contactInstructions { get; set; } = string.Empty;
            public List<contactAddress> contactAddress { get; set; } = [];
            public List<information> information { get; set; } = [];
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<telecommunications> telecommunications { get; set; } = [];
            public List<sourceIndication> sourceIndication { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(ContactDetails);

            public ContactDetails() {
                contactInstructions = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class IndicationOfCarriageRequirement : InformationNode {
            public String? domesticCarriageRequirements { get; set; } = null;
            public String? internationalCarriageRequirements { get; set; } = null;
            public List<featureName> featureName { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(IndicationOfCarriageRequirement);

            public IndicationOfCarriageRequirement() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PriceInformation : InformationNode {
            public List<information> information { get; set; } = [];
            public List<onlineResource> onlineResource { get; set; } = [];
            public List<pricing> pricing { get; set; } = [];
            public List<sourceIndication> sourceIndication { get; set; } = [];

            [IgnoreDataMember]
            public override string Code => nameof(PriceInformation);

            public PriceInformation() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ProducerInformation : InformationNode {
            public String agencyResponsibleForProduction { get; set; } = string.Empty;
            public String? agencyName { get; set; } = null;

            [IgnoreDataMember]
            public override string Code => nameof(ProducerInformation);

            public ProducerInformation() {
                agencyResponsibleForProduction = string.Empty;
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class DistributorInformation : InformationNode {
            public String distributorName { get; set; } = string.Empty;

            [IgnoreDataMember]
            public override string Code => nameof(DistributorInformation);

            public DistributorInformation() {
                distributorName = string.Empty;
            }
        }
    }

    namespace FeatureTypes {
        using ComplexAttributes;
        using InformationTypes;
        using DomainModel;
        using System.Runtime.Serialization;

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class CatalogueElement : FeatureNode {
            public String? agencyResponsibleForProduction { get; set; } = null;

            [Required()]
            public List<catalogueElementClassification> catalogueElementClassification { get; set; }
            public String? catalogueElementIdentifier { get; set; } = null;
            public String? classification { get; set; } = null;
            public List<IMOMaritimeService> IMOMaritimeService { get; set; } = [];

            [Required()]
            public Boolean notForNavigation { get; set; }
            public List<featureName> featureName { get; set; } = [];
            public List<information> information { get; set; } = [];
            public onlineResource? onlineResource { get; set; }
            public sourceIndication? sourceIndication { get; set; }
            public List<supportFile> supportFile { get; set; } = [];
            public timeIntervalOfProduct? timeIntervalOfProduct { get; set; }

            [IgnoreDataMember]
            public override string Code => nameof(CatalogueElement);

            public CatalogueElement() {
                catalogueElementClassification = new();
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract partial class NavigationalProduct : CatalogueElement {
            public List<Decimal> approximateGridResolution { get; set; } = [];
            public List<Int32> compilationScale { get; set; } = [];

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            public distributionStatus? distributionStatus { get; set; } = default;
            public Int32? editionNumber { get; set; } = default;
            public Int32? maximumDisplayScale { get; set; } = default;
            public Int32? minimumDisplayScale { get; set; } = default;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            public List<navigationPurpose> navigationPurpose { get; set; } = [];
            public String? optimumDisplayScale { get; set; } = null;
            public String? originalProductNumber { get; set; } = null;
            public String? producerNation { get; set; } = null;
            public String? productNumber { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            [EnumerationValue(5)]
            [EnumerationValue(6)]
            public specificUsage? specificUsage { get; set; } = default;
            public DateTime? updateDate { get; set; } = default;
            public Int32? updateNumber { get; set; } = default;
            public horizontalDatumEpsg? horizontalDatumEpsg { get; set; }

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
            [EnumerationValue(42)]
            [EnumerationValue(43)]
            [EnumerationValue(44)]
            [EnumerationValue(45)]
            public verticalDatum? verticalDatum { get; set; } = default;

            [IgnoreDataMember]
            public override string Code => nameof(NavigationalProduct);

            public NavigationalProduct() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class ElectronicProduct : NavigationalProduct {
            public Boolean? compressionFlag { get; set; } = default;
            public String? datasetName { get; set; } = null;

            [Required()]
            public DateTime issueDate { get; set; }
            public TimeOnly? issueTime { get; set; } = default;

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
            [Required()]
            public typeOfProductFormat typeOfProductFormat { get; set; }
            public productSpecification? productSpecification { get; set; }

            [IgnoreDataMember]
            public override string Code => nameof(ElectronicProduct);

            public ElectronicProduct() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class PhysicalProduct : NavigationalProduct {
            [Required()]
            public DateTime editionDate { get; set; }
            public String? isbn { get; set; } = null;
            public String? publicationNumber { get; set; } = null;
            public String? typeOfPaper { get; set; } = null;
            public printInformation? printInformation { get; set; }
            public referenceToNM? referenceToNM { get; set; }

            [IgnoreDataMember]
            public override string Code => nameof(PhysicalProduct);

            public PhysicalProduct() {
            }
        }

        [System.Serializable()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public partial class S100Service : CatalogueElement {
            public Boolean? compressionFlag { get; set; } = default;
            public String? serviceName { get; set; } = null;

            [EnumerationValue(1)]
            [EnumerationValue(2)]
            [EnumerationValue(3)]
            [EnumerationValue(4)]
            public serviceStatus? serviceStatus { get; set; } = default;

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
            [Required()]
            public typeOfProductFormat typeOfProductFormat { get; set; }
            public serviceSpecification? serviceSpecification { get; set; }
            public productSpecification? productSpecification { get; set; }

            [IgnoreDataMember]
            public override string Code => nameof(S100Service);

            public S100Service() {
            }
        }
    }
}