using System;
using System.Collections.Immutable;
using System.Linq;

namespace S100Framework.DomainModel.S128
{
    public static class Information
    {
        public static Version Version => new Version("2.0.0");
        public static string[] ComplexTypes => ["contactAddress", "customPaperSize", "defaultLocale", "featureName", "information", "onlineResource", "periodicDateRange", "pricing", "printSize", "productSpecification", "supportFileSpecification", "serviceSpecification", "sourceIndication", "telecommunications", "timeIntervalOfCycle", "issuanceCycle", "printInformation", "supportFile", "timeIntervalOfProduct", ];
        public static string[] InformationTypes => ["CatalogueSectionHeader", "ContactDetails", "IndicationOfCarriageRequirement", "PriceInformation", "ProducerInformation", "DistributorInformation", ];
        public static string[] FeatureTypes => ["CatalogueElement", "NavigationalProduct", "ElectronicProduct", "PhysicalProduct", "S100Service", ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum catalogueElementClassification : int
    {
        [System.ComponentModel.Description("Electronic Navigational Chart")]
        [System.Xml.Serialization.XmlEnum("1")]
        Enc = 1,
        [System.ComponentModel.Description("Bathymetric Surface")]
        [System.Xml.Serialization.XmlEnum("2")]
        BathymetricChart = 2,
        [System.ComponentModel.Description("Water Level Information for Surface Navigation")]
        [System.Xml.Serialization.XmlEnum("3")]
        WaterLevelProduct = 3,
        [System.ComponentModel.Description("Surface Currents")]
        [System.Xml.Serialization.XmlEnum("4")]
        SurfaceCurrentProduct = 4,
        [System.ComponentModel.Description("MSI(Maritime Safety Information) service")]
        [System.Xml.Serialization.XmlEnum("5")]
        MsiService = 5,
        [System.ComponentModel.Description("Marine Aids to Navigational")]
        [System.Xml.Serialization.XmlEnum("6")]
        AtonInformation = 6,
        [System.ComponentModel.Description("Catalogue Service")]
        [System.Xml.Serialization.XmlEnum("7")]
        CatalogueService = 7,
        [System.ComponentModel.Description("the services associated with the route")]
        [System.Xml.Serialization.XmlEnum("8")]
        RoutingService = 8,
        [System.ComponentModel.Description("ice information")]
        [System.Xml.Serialization.XmlEnum("9")]
        IceInformation = 9,
        [System.ComponentModel.Description("The information associated with the route")]
        [System.Xml.Serialization.XmlEnum("10")]
        RoutingInformation = 10,
        [System.ComponentModel.Description("A special purpose chart")]
        [System.Xml.Serialization.XmlEnum("11")]
        SpecialPurposeChart = 11,
        [System.ComponentModel.Description("Catalogue of Nautical Products")]
        [System.Xml.Serialization.XmlEnum("12")]
        NauticalPublication = 12,
        [System.ComponentModel.Description("Printed nautical chart.")]
        [System.Xml.Serialization.XmlEnum("13")]
        PrintedNauticalChart = 13,
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
        [System.ComponentModel.Description("State agency in charge of marine surveys.")]
        [System.Xml.Serialization.XmlEnum("17")]
        HydrographicOffice = 17,
        [System.ComponentModel.Description("Regional ENC Coordination Centre Entities set up by the IHO.")]
        [System.Xml.Serialization.XmlEnum("18")]
        Renc = 18,
        [System.ComponentModel.Description("Value Added Resellers (VARs), who are able to offer comprehensive end-use services that bring together various navigational products into one package.")]
        [System.Xml.Serialization.XmlEnum("19")]
        Vars = 19,
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
        [System.ComponentModel.Description("The name or text is not intended to be displayed.")]
        [System.Xml.Serialization.XmlEnum("3")]
        NoChartDisplay = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum distributionStatus : int
    {
        [System.ComponentModel.Description("The act or process of producing something.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Production = 1,
        [System.ComponentModel.Description("The action to withdraw a time stamp (Used when a time stamp has been reported incorrectly).")]
        [System.Xml.Serialization.XmlEnum("2")]
        Withdrawn = 2,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum IMOMaritimeService : int
    {
        [System.ComponentModel.Description("VTS Information Service(IS)")]
        [System.Xml.Serialization.XmlEnum("1")]
        VesselTrafficService = 1,
        [System.ComponentModel.Description("Navigational Assistance Service(NAS)")]
        [System.Xml.Serialization.XmlEnum("2")]
        AidsToNavigationService = 2,
        [System.ComponentModel.Description("Traffic Organization Service(TOS)")]
        [System.Xml.Serialization.XmlEnum("3")]
        ReservedForFutureUse = 3,
        [System.ComponentModel.Description("Local Port Service")]
        [System.Xml.Serialization.XmlEnum("4")]
        PortSupportService = 4,
        [System.ComponentModel.Description("Maritime Safety Information Service(MSI)")]
        [System.Xml.Serialization.XmlEnum("5")]
        MaritimeSafetyInformationService = 5,
        [System.ComponentModel.Description("Pilotage service")]
        [System.Xml.Serialization.XmlEnum("6")]
        PilotageService = 6,
        [System.ComponentModel.Description("Tug Service")]
        [System.Xml.Serialization.XmlEnum("7")]
        TugService = 7,
        [System.ComponentModel.Description("Vessel Shore Reporting")]
        [System.Xml.Serialization.XmlEnum("8")]
        VesselShoreReporting = 8,
        [System.ComponentModel.Description("Telemedical Assistance Service(TMAS)")]
        [System.Xml.Serialization.XmlEnum("9")]
        TelemedicalAssistanceService = 9,
        [System.ComponentModel.Description("Maritime Assistnace Service(MAS)")]
        [System.Xml.Serialization.XmlEnum("10")]
        MaritimeAssistanceService = 10,
        [System.ComponentModel.Description("Nautical Chart Service")]
        [System.Xml.Serialization.XmlEnum("11")]
        NauticalChartService = 11,
        [System.ComponentModel.Description("Nautical Publications Service")]
        [System.Xml.Serialization.XmlEnum("12")]
        NauticalPublicationsService = 12,
        [System.ComponentModel.Description("Ice Navigation Service")]
        [System.Xml.Serialization.XmlEnum("13")]
        IceNavigationService = 13,
        [System.ComponentModel.Description("Meteorological Information Service")]
        [System.Xml.Serialization.XmlEnum("14")]
        MeteorologicalInformationService = 14,
        [System.ComponentModel.Description("Real-time Hydrographic and Environmental Information Service")]
        [System.Xml.Serialization.XmlEnum("15")]
        RealTimeHydrographicAndEnvironmentalInformationServices = 15,
        [System.ComponentModel.Description("Search and Rescue Service")]
        [System.Xml.Serialization.XmlEnum("16")]
        SearchAndRescueService = 16,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    public enum iso216 : int
#pragma warning restore CS8981
    {
        [System.ComponentModel.Description("The first size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("1")]
        A0 = 1,
        [System.ComponentModel.Description("The second size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("2")]
        A1 = 2,
        [System.ComponentModel.Description("The third size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("3")]
        A2 = 3,
        [System.ComponentModel.Description("The fourth size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("4")]
        A3 = 4,
        [System.ComponentModel.Description("The fifth size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("5")]
        A4 = 5,
        [System.ComponentModel.Description("The sixth size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("6")]
        A5 = 6,
        [System.ComponentModel.Description("The seventh size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("7")]
        A6 = 7,
        [System.ComponentModel.Description("The eighth size as output size on nautical paper chart.")]
        [System.Xml.Serialization.XmlEnum("8")]
        A7 = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum categoryOfProductMapping : int
    {
        [System.ComponentModel.Description("A higher prioritized or recommended alternative product or service, that can fully replace another.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Higherpriorityalternative = 1,
        [System.ComponentModel.Description("A lower prioritized or not recommended alternative product or service, that can fully replace another.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Lowerpriorityalternative = 2,
        [System.ComponentModel.Description("A recommended additional product or service, that provides added value to another.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Recommendedenhancementprovider = 3,
        [System.ComponentModel.Description("A product or service, that is recommended to make use of added value provided by another product or service.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Recommendedenhancementuser = 4,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum digitalSignatureReference : int
    {
        [System.ComponentModel.Description("Elliptic Curve Digital Signature Algorithm (ECDSA) that based upon the issuing certificate. It's signed with the issuer's key P-384.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Ecdsa384Sha2 = 8,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum encodingFormat : int
    {
        [System.ComponentModel.Description("Specification for a data descriptive file for information interchange.")]
        [System.Xml.Serialization.XmlEnum("1")]
        IsoIec8211 = 1,
        [System.ComponentModel.Description("Geography Markup Language. An XML-based geographic information encoding language developed by the Open GIS Consortium (OGC) to enhance the interoperability of geographic information.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Gml = 2,
        [System.ComponentModel.Description("Grid file format.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Hdf5 = 3,
        [System.ComponentModel.Description("The encoding is defined in the Product Specification.")]
        [System.Xml.Serialization.XmlEnum("100")]
        Undefined = 100,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum navigationPurpose : int
    {
        [System.ComponentModel.Description("For port and near shore operations.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Port = 1,
        [System.ComponentModel.Description("For coast and planning purposes.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Transit = 2,
        [System.ComponentModel.Description("For ocean crossing and planning purposes.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Overview = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum supportFileFormat : int
    {
        [System.ComponentModel.Description("UTF-8 text excluding control codes.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Ascii = 1,
        [System.ComponentModel.Description("JPEG2000 format.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Jpeg2000 = 2,
        [System.ComponentModel.Description("Hypertext Markup Language.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Html = 3,
        [System.ComponentModel.Description("Extensible Markup Language.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Xml = 4,
        [System.ComponentModel.Description("Extensible Stylesheet Language Transformations.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Xslt = 5,
        [System.ComponentModel.Description("Representation of moving images in unspecified format.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Video = 6,
        [System.ComponentModel.Description("Tagged Image File Format.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Tiff = 7,
        [System.ComponentModel.Description("Portable Document Format.")]
        [System.Xml.Serialization.XmlEnum("8")]
        PdfAOrUA = 8,
        [System.ComponentModel.Description("Lua programming language.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Lua = 9,
        [System.ComponentModel.Description("Other format.")]
        [System.Xml.Serialization.XmlEnum("100")]
        Other = 100,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum supportFilePurpose : int
    {
        [System.ComponentModel.Description("A file which is new.")]
        [System.Xml.Serialization.XmlEnum("1")]
        New = 1,
        [System.ComponentModel.Description("A file which replaces an existing file.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Replacement = 2,
        [System.ComponentModel.Description("Deletes an existing file.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Deletion = 3,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum serviceStatus : int
    {
        [System.ComponentModel.Description("Under terms not final or fully worked out or agreed upon.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Provisional = 1,
        [System.ComponentModel.Description("Merchandise issued for sale or public showing.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Released = 2,
        [System.ComponentModel.Description("Data that is deprecated in importance and is no longer used and will disappear in the future.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Deprecated = 3,
        [System.ComponentModel.Description("Item that has been removed or deleted.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Deleted = 4,
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
        ProductsIssuedByHoService = 12,
        [System.ComponentModel.Description("Information obtained from news media.")]
        [System.Xml.Serialization.XmlEnum("13")]
        NewsMedia = 13,
        [System.ComponentModel.Description("Information obtained from the analysis of traffic data.")]
        [System.Xml.Serialization.XmlEnum("14")]
        TrafficData = 14,
        [System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
        [System.Xml.Serialization.XmlEnum("15")]
        Maritime = 15,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum specificUsage : int
    {
        [System.ComponentModel.Description("For use in the study of the characteristics of maritime zones, in the formulation of plans, in the selection of routes, etc., showing only relevant elements of the coastline, harbours, islands, principal navigational  marks and obstructions, and submarine landforms. 1:1499999 > Scale. ")]
        [System.Xml.Serialization.XmlEnum("1")]
        NavigationalPurposeOverview = 1,
        [System.ComponentModel.Description("A nautical chart with universality (i.e., generality) in use, characterized by the requirement that the chart must comprehensively describe various natural elements and socioeconomic elements, and that each element of  the subject matter expressed is universal. The scale is between 1:350000-1:1499999.")]
        [System.Xml.Serialization.XmlEnum("2")]
        NavigationalPurposeGeneral = 2,
        [System.ComponentModel.Description("Used for marine navigation, mainly displaying submarine landforms, navigational marks, navigational obstacles and other elements related to navigation. The scale is between 1:90000-1:349999.")]
        [System.Xml.Serialization.XmlEnum("3")]
        NavigationalPurposeCoastal = 3,
        [System.ComponentModel.Description("Used for near-shore navigation, mainly showing the marine elements close to coastal areas. The scale is between 1:22000-1:89999.")]
        [System.Xml.Serialization.XmlEnum("4")]
        NavigationalPurposeApproach = 4,
        [System.ComponentModel.Description("Used for entering and leaving harbours, selecting anchorage, studying harbour topography, and carrying out the construction of harbours. The scale is between 1:4000-1:21999.")]
        [System.Xml.Serialization.XmlEnum("5")]
        NavigationalPurposeHarbour = 5,
        [System.ComponentModel.Description("For ships berthing. Scale > 1:4000.")]
        [System.Xml.Serialization.XmlEnum("6")]
        NavigationalPurposeBerthing = 6,
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
        Streameddata = 5,
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
    public enum typeOfProductFormat : int
    {
        [System.ComponentModel.Description("Geography Markup Language. An XML-based geographic information encoding language developed by the Open GIS Consortium (OGC) to enhance the interoperability of geographic information.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Gml = 1,
        [System.ComponentModel.Description("Specification for a data descriptive file for information interchange.")]
        [System.Xml.Serialization.XmlEnum("2")]
        IsoIec8211 = 2,
        [System.ComponentModel.Description("Portable Document Format. A file format developed by Adobe in 1993 to present documents, including text formatting and images, in a manner independent of application software, hardware, and operating systems.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Pdf = 3,
        [System.ComponentModel.Description("Hypertext Markup Language. A type of basic web language used to create web documents.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Html = 4,
        [System.ComponentModel.Description("E-book file format.")]
        [System.Xml.Serialization.XmlEnum("5")]
        Epub = 5,
        [System.ComponentModel.Description("For printing hydrographic charts, heavyweight, single layer paper is used. Such paper is generally made wholly or partly from rags and simulates hand-made paper. It is strong, moisture resistant and manufactured to withstand surface erasure.")]
        [System.Xml.Serialization.XmlEnum("6")]
        Paper = 6,
        [System.ComponentModel.Description("Grid file format.")]
        [System.Xml.Serialization.XmlEnum("7")]
        Hdf5 = 7,
        [System.ComponentModel.Description("Raster data format used by USA and Canada and others.")]
        [System.Xml.Serialization.XmlEnum("8")]
        Bsb = 8,
        [System.ComponentModel.Description("Extension of the TIFF specification to allow the storage of geo- referencing information.")]
        [System.Xml.Serialization.XmlEnum("9")]
        Geotiff = 9,
        [System.ComponentModel.Description("")]
        [System.Xml.Serialization.XmlEnum("10")]
        Application = 10,
        [System.ComponentModel.Description("Extensible Markup Language.")]
        [System.Xml.Serialization.XmlEnum("11")]
        Xml = 11,
        [System.ComponentModel.Description("Portable Network Graphics format.")]
        [System.Xml.Serialization.XmlEnum("12")]
        Png = 12,
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.SerializableAttribute()]
    public enum typeOfTimeIntervalUnit : int
    {
        [System.ComponentModel.Description("60 minutes or 3600 seconds.")]
        [System.Xml.Serialization.XmlEnum("1")]
        Hour = 1,
        [System.ComponentModel.Description("for a day.")]
        [System.Xml.Serialization.XmlEnum("2")]
        Day = 2,
        [System.ComponentModel.Description("for a month.")]
        [System.Xml.Serialization.XmlEnum("3")]
        Month = 3,
        [System.ComponentModel.Description("A period of one year.")]
        [System.Xml.Serialization.XmlEnum("4")]
        Year = 4,
    }

    public static class CodeList
    {
    }

    namespace ComplexAttributes
    {
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class contactAddress
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String administrativeDivision { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String cityName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String countryName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<String> deliveryPoint { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String postalCode { get; set; } = string.Empty;

            public contactAddress()
            {
                cityName = string.Empty;
                countryName = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class customPaperSize
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required Int32 x { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required Int32 y { get; set; }

            public customPaperSize()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class defaultLocale
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String characterEncoding { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String countryName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String language { get; set; } = string.Empty;

            public defaultLocale()
            {
                characterEncoding = string.Empty;
                countryName = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class featureName
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String name { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public nameUsage? nameUsage { get; set; } = default;

            public featureName()
            {
                name = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class information
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String fileLocator { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String fileReference { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String headline { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String language { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<String> text { get; set; } = [];

            public information()
            {
                headline = string.Empty;
                language = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class onlineResource
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String applicationProfile { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String linkage { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String nameOfResource { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String onlineDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String protocol { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String protocolRequest { get; set; } = string.Empty;

            public onlineResource()
            {
                linkage = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class periodicDateRange
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateOnly dateEnd { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateOnly dateStart { get; set; }

            public periodicDateRange()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class pricing
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String contractPeriod { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String currency { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required Decimal price { get; set; }

            public pricing()
            {
                contractPeriod = string.Empty;
                currency = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class printSize
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public iso216? iso216 { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public customPaperSize? customPaperSize { get; set; }

            public printSize()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class productSpecification
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateTime date { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String ISSN { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String name { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String version { get; set; } = string.Empty;

            public productSpecification()
            {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class supportFileSpecification
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateTime date { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String name { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String version { get; set; } = string.Empty;

            public supportFileSpecification()
            {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class serviceSpecification
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateTime date { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String name { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String version { get; set; } = string.Empty;

            public serviceSpecification()
            {
                name = string.Empty;
                version = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class sourceIndication
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required List<categoryOfAuthority> categoryOfAuthority { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String countryName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String reportedDate { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String source { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required sourceType sourceType { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<featureName> featureName { get; set; } = [];

            public sourceIndication()
            {
                categoryOfAuthority = new();
                reportedDate = string.Empty;
                source = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

        public class telecommunications
#pragma warning restore CS8981
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String telecommunicationIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<telecommunicationService> telecommunicationService { get; set; } = [];

            public telecommunications()
            {
                contactInstructions = string.Empty;
                telecommunicationIdentifier = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class timeIntervalOfCycle
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required List<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required Int32 valueOfTime { get; set; }

            public timeIntervalOfCycle()
            {
                typeOfTimeIntervalUnit = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class issuanceCycle
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public periodicDateRange? periodicDateRange { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public timeIntervalOfCycle? timeIntervalOfCycle { get; set; }

            public issuanceCycle()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class printInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String printAgency { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String printNation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public DateTime? printWeek { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public DateTime? printYear { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String rePrintEdition { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String rePrintNation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required printSize printSize { get; set; }

            public printInformation()
            {
                printSize = new printSize()
                {
                };
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class supportFile
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String comment { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required digitalSignatureReference digitalSignatureReference { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String digitalSignatureValue { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public Int32? editionNumber { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String fileLocator { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String fileName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public DateTime? issueDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String otherDataTypeDescription { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required supportFileFormat supportFileFormat { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required supportFilePurpose supportFilePurpose { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required defaultLocale defaultLocale { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required supportFileSpecification supportFileSpecification { get; set; }

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

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class timeIntervalOfProduct
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateTime issueDate { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public DateTime? expirationDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public issuanceCycle? issuanceCycle { get; set; }

            public timeIntervalOfProduct()
            {
            }
        }
    }

    namespace Bindings
    {
        namespace Roles
        {
            public class catalogueHeader : Role
            {
            }

            public class elementContainer : Role
            {
            }

            public class theCatalogueElement : Role
            {
            }

            public class theCatalogueOfNauticalProduct : Role
            {
            }

            public class theContactDetails : Role
            {
            }

            public class theDistributor : Role
            {
            }

            public class theElement : Role
            {
            }

            public class thePriceInformation : Role
            {
            }

            public class theProducer : Role
            {
            }

            public class theReference : Role
            {
            }

            public class theRequirement : Role
            {
            }

            public class theSource : Role
            {
            }
        }

        namespace InformationAssociations
        {
            public class CarriageRequirement<T> : InformationAssociation where T : Role
            {
                public CarriageRequirement(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class DistributionDetails<T> : InformationAssociation where T : Role
            {
                public DistributionDetails(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class DistributorContact<T> : InformationAssociation where T : Role
            {
                public DistributorContact(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class PriceOfElement<T> : InformationAssociation where T : Role
            {
                public PriceOfElement(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class PriceOfNauticalProduct<T> : InformationAssociation where T : Role
            {
                public PriceOfNauticalProduct(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class ProducerContact<T> : InformationAssociation where T : Role
            {
                public ProducerContact(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class ProductionDetails<T> : InformationAssociation where T : Role
            {
                public ProductionDetails(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }

            public class ProductPackage<T> : InformationAssociation where T : Role
            {
                public ProductPackage(string foreignKey = "") : base(foreignKey)
                {
                }

                public string role => typeof(T).Name;
            }
        }

        namespace FeatureAssociations
        {
            public class ProductMapping<T> : FeatureAssociation where T : Role
            {
                public ProductMapping(string foreignKey = "") : base(foreignKey)
                {
                }

                public required categoryOfProductMapping categoryOfProductMapping { get; set; }
                public string role => typeof(T).Name;
            }
        }
    }

    namespace InformationTypes
    {
        using ComplexAttributes;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class CatalogueSectionHeader
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required Int32 catalogueSectionNumber { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String catalogueSectionTitle { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public information? information { get; set; }

            public CatalogueSectionHeader()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ContactDetails
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String contactInstructions { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<contactAddress> contactAddress { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<onlineResource> onlineResource { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<telecommunications> telecommunications { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<sourceIndication> sourceIndication { get; set; } = [];

            public ContactDetails()
            {
                contactInstructions = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class IndicationOfCarriageRequirement
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String domesticCarriageRequirements { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String internationalCarriageRequirements { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<featureName> featureName { get; set; } = [];

            public IndicationOfCarriageRequirement()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PriceInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<onlineResource> onlineResource { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<pricing> pricing { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<sourceIndication> sourceIndication { get; set; } = [];

            public PriceInformation()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ProducerInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String agencyResponsibleForProduction { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String agencyName { get; set; } = string.Empty;

            public ProducerInformation()
            {
                agencyResponsibleForProduction = string.Empty;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class DistributorInformation
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String distributorName { get; set; } = string.Empty;

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
        using Bindings.InformationAssociations;
        using Bindings.FeatureAssociations;
        using Bindings.Roles;

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class CatalogueElement
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String agencyResponsibleForProduction { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required List<catalogueElementClassification> catalogueElementClassification { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String catalogueElementIdentifier { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String classification { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<IMOMaritimeService> IMOMaritimeService { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String keywords { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required Boolean notForNavigation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<featureName> featureName { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<information> information { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public onlineResource? onlineResource { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public sourceIndication? sourceIndication { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<supportFile> supportFile { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public timeIntervalOfProduct? timeIntervalOfProduct { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<CarriageRequirement<theRequirement>> theRequirement { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<PriceOfElement<thePriceInformation>> thePriceInformation { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required List<ProductPackage<elementContainer>> elementContainer { get; set; }

            public CatalogueElement()
            {
                catalogueElementClassification = new();
                elementContainer = new();
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public abstract class NavigationalProduct : CatalogueElement
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public Int32? approximateGridResolution { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<Int32> compilationScale { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public distributionStatus? distributionStatus { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required Int32 editionNumber { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public Int32? maximumDisplayScale { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public Int32? minimumDisplayScale { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public List<navigationPurpose> navigationPurpose { get; set; } = [];

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String optimumDisplayScale { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String originalProductNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String producerNation { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String productNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public specificUsage? specificUsage { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public DateTime? updateDate { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public Int32? updateNumber { get; set; } = default;

            public NavigationalProduct()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class ElectronicProduct : NavigationalProduct
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public Boolean? compressionFlag { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String datasetName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required encodingFormat encodingFormat { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateTime issueDate { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public TimeOnly? issueTime { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required typeOfProductFormat typeOfProductFormat { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public productSpecification? productSpecification { get; set; }

            public ElectronicProduct()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class PhysicalProduct : NavigationalProduct
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required DateTime editionDate { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String isbn { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String publicationNumber { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String typeOfPaper { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public printInformation? printInformation { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public DateTime? referenceToNM { get; set; } = default;

            public PhysicalProduct()
            {
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public class S100Service : CatalogueElement
        {
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public Boolean? compressionFlag { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required encodingFormat encodingFormat { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public String serviceName { get; set; } = string.Empty;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public serviceStatus? serviceStatus { get; set; } = default;

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public required typeOfProductFormat typeOfProductFormat { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public serviceSpecification? serviceSpecification { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S128/2.0")]
            public productSpecification? productSpecification { get; set; }

            public S100Service()
            {
            }
        }
    }
}