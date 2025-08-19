using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S128 {
	public class Summary : ISummary
	{
		public static string Name => "S-128 Catalogue of Nautical Products";
		public static string Scope => "Catalogue of Nautical Products";
		public static string ProductId => "S-128";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-04-30", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["contactAddress","customPaperSize","defaultLocale","featureName","information","issuanceCycle","onlineResource","periodicDateRange","pricing","printInformation","printSize","productSpecification","supportFile","supportFileSpecification","serviceSpecification","sourceIndication","telecommunications","timeIntervalOfProduct","timeIntervalOfCycle","referenceToNM","weekOfYear"];
		public static string[] InformationAssociationTypes => ["CarriageRequirement","DistributionDetails","DistributorContact","PriceOfElement","PriceOfNauticalProduct","ProducerContact","ProductionDetails","ProductPackage"];
		public static string[] FeatureAssociationTypes => ["ProductMapping","Correlated"];
		public static string[] InformationTypes => ["CatalogueSectionHeader","ContactDetails","IndicationOfCarriageRequirement","PriceInformation","ProducerInformation","DistributorInformation"];
		public static string[] FeatureTypes => ["ElectronicProduct","PhysicalProduct","S100Service"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.surface => ["CatalogueElement","NavigationalProduct","ElectronicProduct","PhysicalProduct","S100Service"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"CatalogueElement" => [Primitives.surface],
			"NavigationalProduct" => [Primitives.surface],
			"ElectronicProduct" => [Primitives.surface],
			"PhysicalProduct" => [Primitives.surface],
			"S100Service" => [Primitives.surface],
			_ or "" => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Classification of a catalogue element.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum catalogueElementClassification : int {
		[System.ComponentModel.Description("Electronic Navigational Chart")]
		[EnumMember(Value = "ENC")] 
		[XmlEnum("1")] 
		Enc = 1,

		[System.ComponentModel.Description("A topographic chart of the bed of a body of water, or a part of it. Generally, bathymetric charts show depths by contour lines and gradient tints.")]
		[EnumMember(Value = "Bathymetric Chart")] 
		[XmlEnum("2")] 
		BathymetricChart = 2,

		[System.ComponentModel.Description("Water Level Information for Surface Navigation")]
		[EnumMember(Value = "Water Level Product")] 
		[XmlEnum("3")] 
		WaterLevelProduct = 3,

		[System.ComponentModel.Description("A product representing the water velocity at one or more geographic locations down to a given depth.")]
		[EnumMember(Value = "Surface Current Product")] 
		[XmlEnum("4")] 
		SurfaceCurrentProduct = 4,

		[System.ComponentModel.Description("An outage of a maritime safety information broadcast service (satellite or terrestrial system).")]
		[EnumMember(Value = "MSI Service")] 
		[XmlEnum("5")] 
		MsiService = 5,

		[System.ComponentModel.Description("A service providing information related to Marine Aids to Navigation.")]
		[EnumMember(Value = "AtoN Information")] 
		[XmlEnum("6")] 
		AtonInformation = 6,

		[System.ComponentModel.Description("A service providing structured records of items.")]
		[EnumMember(Value = "Catalogue Service")] 
		[XmlEnum("7")] 
		CatalogueService = 7,

		[System.ComponentModel.Description("Services associated with Ships Routeing.")]
		[EnumMember(Value = "Routeing Service")] 
		[XmlEnum("8")] 
		RouteingService = 8,

		[System.ComponentModel.Description("Newly discovered icebergs, changes to ice conditions and ice related information likely to impact navigation.")]
		[EnumMember(Value = "Ice Information")] 
		[XmlEnum("9")] 
		IceInformation = 9,

		[System.ComponentModel.Description("Information associated with Ships Routeing.")]
		[EnumMember(Value = "Routeing Information")] 
		[XmlEnum("10")] 
		RouteingInformation = 10,

		[System.ComponentModel.Description("Any chart designed primarily to meet specific requirements.")]
		[EnumMember(Value = "Special Purpose Chart")] 
		[XmlEnum("11")] 
		SpecialPurposeChart = 11,

		[System.ComponentModel.Description("A (nautical chart or) nautical publication is a \"a special-purpose map or book, or a specially compiled database from which such a map or book is derived, that is issued officially by or on the authority of a Government, authorized Hydrographic Office or other relevant government institution and is designed to meet the requirements of marine navigation\".")]
		[EnumMember(Value = "Nautical Publication")] 
		[XmlEnum("12")] 
		NauticalPublication = 12,

		[System.ComponentModel.Description("A printed nautical chart is a \"a special-purpose map , that is issued officially by or on the authority of a Government, authorized Hydrographic Office or other relevant government institution and is designed to meet the requirements of marine navigation\".")]
		[EnumMember(Value = "Printed Nautical Chart")] 
		[XmlEnum("13")] 
		PrintedNauticalChart = 13,
	}

	/// <summary>
	/// The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAuthority : int {
		[System.ComponentModel.Description("The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.")]
		[EnumMember(Value = "Border Control")] 
		[XmlEnum("2")] 
		BorderControl = 2,

		[System.ComponentModel.Description("The department of government, or civil force, charged with maintaining public order.")]
		[EnumMember(Value = "Police")] 
		[XmlEnum("3")] 
		Police = 3,

		[System.ComponentModel.Description("Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.")]
		[EnumMember(Value = "Port")] 
		[XmlEnum("4")] 
		Port = 4,

		[System.ComponentModel.Description("The authority controlling people entering a country.")]
		[EnumMember(Value = "Immigration")] 
		[XmlEnum("5")] 
		Immigration = 5,

		[System.ComponentModel.Description("The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.")]
		[EnumMember(Value = "Health")] 
		[XmlEnum("6")] 
		Health = 6,

		[System.ComponentModel.Description("Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.")]
		[EnumMember(Value = "Coast Guard")] 
		[XmlEnum("7")] 
		CoastGuard = 7,

		[System.ComponentModel.Description("The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.")]
		[EnumMember(Value = "Agricultural")] 
		[XmlEnum("8")] 
		Agricultural = 8,

		[System.ComponentModel.Description("A military authority which provides control of access to or approval for transit through designated areas or airspace.")]
		[EnumMember(Value = "Military")] 
		[XmlEnum("9")] 
		Military = 9,

		[System.ComponentModel.Description("A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.")]
		[EnumMember(Value = "Private Company")] 
		[XmlEnum("10")] 
		PrivateCompany = 10,

		[System.ComponentModel.Description("A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.")]
		[EnumMember(Value = "Maritime Police")] 
		[XmlEnum("11")] 
		MaritimePolice = 11,

		[System.ComponentModel.Description("An authority with responsibility for the protection of the environment.")]
		[EnumMember(Value = "Environmental")] 
		[XmlEnum("12")] 
		Environmental = 12,

		[System.ComponentModel.Description("An authority with responsibility for the control of fisheries.")]
		[EnumMember(Value = "Fishery")] 
		[XmlEnum("13")] 
		Fishery = 13,

		[System.ComponentModel.Description("An authority with responsibility for the control and movement of money.")]
		[EnumMember(Value = "Finance")] 
		[XmlEnum("14")] 
		Finance = 14,

		[System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
		[EnumMember(Value = "Maritime")] 
		[XmlEnum("15")] 
		Maritime = 15,

		[System.ComponentModel.Description("The agency or establishment for collecting duties, tolls.")]
		[EnumMember(Value = "Customs")] 
		[XmlEnum("16")] 
		Customs = 16,

		[System.ComponentModel.Description("State agency in charge of marine surveys and hydrography.")]
		[EnumMember(Value = "Hydrographic Office")] 
		[XmlEnum("17")] 
		HydrographicOffice = 17,

		[System.ComponentModel.Description("Regional ENC Coordination Centre.")]
		[EnumMember(Value = "RENC")] 
		[XmlEnum("18")] 
		Renc = 18,

		[System.ComponentModel.Description("Value Added Resellers (VARs), who are able to offer comprehensive end-use services that bring together various navigational products into one package.")]
		[EnumMember(Value = "VARs")] 
		[XmlEnum("19")] 
		Vars = 19,
	}

	/// <summary>
	/// Value derived from the digital signature.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum digitalSignatureValue : int {
		[System.ComponentModel.Description("Meta data record identifier for QualityOfBathymetric Coverage")]
		[EnumMember(Value = "ID")] 
		[XmlEnum("1")] 
		Id = 1,

		[System.ComponentModel.Description("Specifies the algorithm used to compute digital signature value.")]
		[EnumMember(Value = "Digital Signature Reference")] 
		[XmlEnum("2")] 
		DigitalSignatureReference = 2,
	}

	/// <summary>
	/// Classification of the type and display level of the name of a feature in an end-user system.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum nameUsage : int {
		[System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
		[EnumMember(Value = "Default Name Display")] 
		[XmlEnum("1")] 
		DefaultNameDisplay = 1,

		[System.ComponentModel.Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
		[EnumMember(Value = "Alternate Name Display")] 
		[XmlEnum("2")] 
		AlternateNameDisplay = 2,

		[System.ComponentModel.Description("The name or text is not intended to be displayed.")]
		[EnumMember(Value = "No Chart Display")] 
		[XmlEnum("3")] 
		NoChartDisplay = 3,
	}

	/// <summary>
	/// Supply status of nautical products.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum distributionStatus : int {
		[System.ComponentModel.Description("A product or service that is currently in production.")]
		[EnumMember(Value = "Production")] 
		[XmlEnum("1")] 
		Production = 1,

		[System.ComponentModel.Description("A product or service that has been withdrawn.")]
		[EnumMember(Value = "Withdrawn")] 
		[XmlEnum("2")] 
		Withdrawn = 2,
	}

	/// <summary>
	/// A maritime service as identified by the International Maritime Organization (IMO).
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iMOMaritimeService : int {
		[System.ComponentModel.Description("Any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organization of the traffic involving national or regional schemes.")]
		[EnumMember(Value = "Vessel Traffic Service")] 
		[XmlEnum("1")] 
		VesselTrafficService = 1,

		[System.ComponentModel.Description("A service providing up-to-date information of Aids to Navigation.")]
		[EnumMember(Value = "Aids to Navigation Service")] 
		[XmlEnum("2")] 
		AidsToNavigationService = 2,

		[System.ComponentModel.Description("An option that is reserved for future use")]
		[EnumMember(Value = "Reserved for Future Use")] 
		[XmlEnum("3")] 
		ReservedForFutureUse = 3,

		[System.ComponentModel.Description("A service that provides information necessary to organize and support port calls and varies depending on the local needs.")]
		[EnumMember(Value = "Port Support Service")] 
		[XmlEnum("4")] 
		PortSupportService = 4,

		[System.ComponentModel.Description("A service providing navigational and meteorological warnings, meteorological forecasts and other urgent safety-related messages broadcast to ships.")]
		[EnumMember(Value = "Maritime Safety Information Service")] 
		[XmlEnum("5")] 
		MaritimeSafetyInformationService = 5,

		[System.ComponentModel.Description("The services of a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area, are available.")]
		[EnumMember(Value = "Pilotage Service")] 
		[XmlEnum("6")] 
		PilotageService = 6,

		[System.ComponentModel.Description("A service that contributes to the safety of navigation, protection of the marine environment, and efficiency of marine transportation by conducting different types of operations including tugboats, such as ship assistance, salvalge, towage, escort etc.")]
		[EnumMember(Value = "Tug Service")] 
		[XmlEnum("7")] 
		TugService = 7,

		[System.ComponentModel.Description("A service providing information related to Vessel Shore Reporting and Ship reporting systems.")]
		[EnumMember(Value = "Vessel Shore Reporting")] 
		[XmlEnum("8")] 
		VesselShoreReporting = 8,

		[System.ComponentModel.Description("A service to provide decision support and advice to the seafarer on board responsible for medical care.")]
		[EnumMember(Value = "Telemedical Assistance Service")] 
		[XmlEnum("9")] 
		TelemedicalAssistanceService = 9,

		[System.ComponentModel.Description("A service to manage communications between the coastal State, ships' officers requiring assistance and other responsible maritime organizations: fleet owners, salvage companies, port authorities, brokers, etc.")]
		[EnumMember(Value = "Maritime Assistance Service")] 
		[XmlEnum("10")] 
		MaritimeAssistanceService = 10,

		[System.ComponentModel.Description("A service that provides geospatial information (in digital and / or printed format) to support safe maritime navigation with the aim to fulfill SOLAS regulation V/19.2.1.4 requirements for ships to carry \"nautical charts and nautical publications to plan and display the ship's route for the intended voyage and to plot and monitor positions throughout the voyage\".")]
		[EnumMember(Value = "Nautical Chart Service")] 
		[XmlEnum("11")] 
		NauticalChartService = 11,

		[System.ComponentModel.Description("A service to provide information as a support to the navigation process. This comprises information to complement nautical charts, such as information on ports and sea areas, as well as the contact information of authorities and services for a sea area or port. It further describes regulations, restrictions, recommendations and other nautical information applicable in these areas, and aim to fulfill  SOLAS regulation V/19.2.1.4 requirements for ships to carry \"nautical charts and nautical publications to plan and display the ship's route for the intended voyage and to plot and monitor positions throughout the voyage\".")]
		[EnumMember(Value = "Nautical Publications Service")] 
		[XmlEnum("12")] 
		NauticalPublicationsService = 12,

		[System.ComponentModel.Description("A service to provide ice navigation information to ships in and in the vicinity of possible ice infested regions.")]
		[EnumMember(Value = "Ice Navigation Service")] 
		[XmlEnum("13")] 
		IceNavigationService = 13,

		[System.ComponentModel.Description("A service to provide meteorological information (digitally) to ships.")]
		[EnumMember(Value = "Meteorological Information Service")] 
		[XmlEnum("14")] 
		MeteorologicalInformationService = 14,

		[System.ComponentModel.Description("A service providing hydrographic and environmental observations and forecasts, such as water level and surface current information.")]
		[EnumMember(Value = "Real-Time Hydrographic and Environmental Information Service")] 
		[XmlEnum("15")] 
		RealTimeHydrographicAndEnvironmentalInformationService = 15,

		[System.ComponentModel.Description("A service aimed at providing information about and assist with Search and Rescue functions.")]
		[EnumMember(Value = "Search and Rescue Service")] 
		[XmlEnum("16")] 
		SearchAndRescueService = 16,
	}

	/// <summary>
	/// ISO 216 is a paper-size standard established by the International Organization for Standardization (ISO).
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iSO216 : int {
		[System.ComponentModel.Description("The paper size A0, as defined in ISO 216.")]
		[EnumMember(Value = "A0")] 
		[XmlEnum("1")] 
		A0 = 1,

		[System.ComponentModel.Description("The first size as output size on nautical paper chart. Referring to ISO 216.")]
		[EnumMember(Value = "A1")] 
		[XmlEnum("2")] 
		A1 = 2,

		[System.ComponentModel.Description("The paper size A2, as defined in ISO 216.")]
		[EnumMember(Value = "A2")] 
		[XmlEnum("3")] 
		A2 = 3,

		[System.ComponentModel.Description("The fourth size as output size on nautical paper chart. Referring to ISO 216.")]
		[EnumMember(Value = "A3")] 
		[XmlEnum("4")] 
		A3 = 4,

		[System.ComponentModel.Description("The fifth size as output size on nautical paper chart. Referring to ISO 216.")]
		[EnumMember(Value = "A4")] 
		[XmlEnum("5")] 
		A4 = 5,

		[System.ComponentModel.Description("The sixth size as output size on nautical paper chart. Referring to ISO 216.")]
		[EnumMember(Value = "A5")] 
		[XmlEnum("6")] 
		A5 = 6,

		[System.ComponentModel.Description("The seventh size as output size on nautical paper chart. Referring to ISO 216.")]
		[EnumMember(Value = "A6")] 
		[XmlEnum("7")] 
		A6 = 7,

		[System.ComponentModel.Description("The eighth size as output size on nautical paper chart. Referring to ISO 216.")]
		[EnumMember(Value = "A7")] 
		[XmlEnum("8")] 
		A7 = 8,
	}

	/// <summary>
	/// A classification of the internal relationships between products and services.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfProductMapping : int {
		[System.ComponentModel.Description("A higher prioritized or recommended alternative product or service, that can fully replace another.")]
		[EnumMember(Value = "Higher Priority Alternative")] 
		[XmlEnum("1")] 
		HigherPriorityAlternative = 1,

		[System.ComponentModel.Description("A lower prioritized or not recommended alternative product or service, that can fully replace another.")]
		[EnumMember(Value = "Lower Priority Alternative")] 
		[XmlEnum("2")] 
		LowerPriorityAlternative = 2,

		[System.ComponentModel.Description("A recommended additional product or service, that provides added value to another.")]
		[EnumMember(Value = "Recommended Enhancement Provider")] 
		[XmlEnum("3")] 
		RecommendedEnhancementProvider = 3,

		[System.ComponentModel.Description("A product or service, that is recommended to make use of added value provided by another product or service.")]
		[EnumMember(Value = "Recommended Enhancement User")] 
		[XmlEnum("4")] 
		RecommendedEnhancementUser = 4,
	}

	/// <summary>
	/// Specifies the algorithm used to compute digital signature value.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum digitalSignatureReference : int {
		[System.ComponentModel.Description("Elliptic Curve Digital Signature Algorithm (ECDSA) that uses signatures based on the issuing certificate and generated using the issuer’s P-384 elliptic curve key.")]
		[EnumMember(Value = "ECDSA-384-SHA2")] 
		[XmlEnum("8")] 
		Ecdsa384Sha2 = 8,
	}

	/// <summary>
	/// The navigational purpose of the dataset.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum navigationPurpose : int {
		[System.ComponentModel.Description("Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.")]
		[EnumMember(Value = "Port")] 
		[XmlEnum("1")] 
		Port = 1,

		[System.ComponentModel.Description("(1) In astronomy, the apparent passage of a star or other celestial body across a defined line of the celestial sphere, as a meridian, prime vertical, or almucantar. When no line is specified, a transit across the meridian is usually intended. See Meridian Transit.  (2) The apparent passage of a star or other celestial body across a line in the reticle of a telescope, or some line of sight.  (3) The apparent passage of a smaller celestial body across the disk of a larger celestial body.  (4) A surveying instrument composed of a horizontal circle graduated in circular measure and an alidade with a telescope which can be reversed in its supports without being lifted therefrom. Also, the act of making such a reversal.  (5) A theodolite having a telescope that can be transited in its supports is a transit, and is sometimes termed a transit theodolite. All modern theodolites are transits.  (6) An astronomical instrument having a telescope which can be so adjusted in position that the line of sight may be made to define a vertical circle. A transit used in astronomical work is usually termed either an astronomic(al) transit or a transit instrument.  (7) In navigation, the position of two distant, fixed objects when they are in line to an observer; the line passing through them and the observer being a line of position. See also Range.")]
		[EnumMember(Value = "Transit")] 
		[XmlEnum("2")] 
		Transit = 2,

		[System.ComponentModel.Description("For ocean crossing and planning purposes.")]
		[EnumMember(Value = "Overview")] 
		[XmlEnum("3")] 
		Overview = 3,
	}

	/// <summary>
	/// The format used for the support file.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supportFileFormat : int {
		[System.ComponentModel.Description("UTF-8 text excluding control codes.")]
		[EnumMember(Value = "ASCII")] 
		[XmlEnum("1")] 
		Ascii = 1,

		[System.ComponentModel.Description("JPEG2000 format.")]
		[EnumMember(Value = "JPEG2000")] 
		[XmlEnum("2")] 
		Jpeg2000 = 2,

		[System.ComponentModel.Description("Hypertext Markup Language.")]
		[EnumMember(Value = "HTML")] 
		[XmlEnum("3")] 
		Html = 3,

		[System.ComponentModel.Description("Extensible Markup Language.")]
		[EnumMember(Value = "XML")] 
		[XmlEnum("4")] 
		Xml = 4,

		[System.ComponentModel.Description("Extensible Stylesheet Language Transformations.")]
		[EnumMember(Value = "XSLT")] 
		[XmlEnum("5")] 
		Xslt = 5,

		[System.ComponentModel.Description("A digital recording of an image or set of images (such as a movie or animation).")]
		[EnumMember(Value = "Video")] 
		[XmlEnum("6")] 
		Video = 6,

		[System.ComponentModel.Description("Tagged Image File Format (TIFF).")]
		[EnumMember(Value = "TIFF")] 
		[XmlEnum("7")] 
		Tiff = 7,

		[System.ComponentModel.Description("Portable Document Format.")]
		[EnumMember(Value = "PDF/A Or U/A")] 
		[XmlEnum("8")] 
		PdfAOrUA = 8,

		[System.ComponentModel.Description("Lua programming language.")]
		[EnumMember(Value = "LUA")] 
		[XmlEnum("9")] 
		Lua = 9,

		[System.ComponentModel.Description("Being the one or ones distinct from that or those first mentioned or implied.")]
		[EnumMember(Value = "Other")] 
		[XmlEnum("100")] 
		Other = 100,
	}

	/// <summary>
	/// The reason for inclusion of the support file.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supportFilePurpose : int {
		[System.ComponentModel.Description("A file which is new.")]
		[EnumMember(Value = "New")] 
		[XmlEnum("1")] 
		New = 1,

		[System.ComponentModel.Description("A file which replaces an existing file.")]
		[EnumMember(Value = "Replacement")] 
		[XmlEnum("2")] 
		Replacement = 2,

		[System.ComponentModel.Description("Deletes an existing file.")]
		[EnumMember(Value = "Deletion")] 
		[XmlEnum("3")] 
		Deletion = 3,
	}

	/// <summary>
	/// Types of status of services.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum serviceStatus : int {
		[System.ComponentModel.Description("Indicates a temporary, preliminary, or interim status. A provisional item is not yet finalized or fully approved.")]
		[EnumMember(Value = "Provisional")] 
		[XmlEnum("1")] 
		Provisional = 1,

		[System.ComponentModel.Description("Indicates a finalized, officially approved, or publicly available status. A released item is ready for general use or distribution.")]
		[EnumMember(Value = "Released")] 
		[XmlEnum("2")] 
		Released = 2,

		[System.ComponentModel.Description("Indicates that a feature, method, product, or component is no longer recommended for use but is still available.")]
		[EnumMember(Value = "Deprecated")] 
		[XmlEnum("3")] 
		Deprecated = 3,

		[System.ComponentModel.Description("Indicates that a feature, method, product, or component is no longer available or has been permanently removed.")]
		[EnumMember(Value = "Deleted")] 
		[XmlEnum("4")] 
		Deleted = 4,
	}

	/// <summary>
	/// Type of the source.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sourceType : int {
		[System.ComponentModel.Description("Treaty, convention, or international agreement; law or regulation issued by a national or other authority.")]
		[EnumMember(Value = "Law or Regulation")] 
		[XmlEnum("1")] 
		LawOrRegulation = 1,

		[System.ComponentModel.Description("Publication not having the force of law, issued by an international organisation or a national or local administration.")]
		[EnumMember(Value = "Official Publication")] 
		[XmlEnum("2")] 
		OfficialPublication = 2,

		[System.ComponentModel.Description("Reported by mariner(s) and confirmed by another source.")]
		[EnumMember(Value = "Mariner Report, Confirmed")] 
		[XmlEnum("7")] 
		MarinerReportConfirmed = 7,

		[System.ComponentModel.Description("Reported by mariner(s) but not confirmed.")]
		[EnumMember(Value = "Mariner Report, Not Confirmed")] 
		[XmlEnum("8")] 
		MarinerReportNotConfirmed = 8,

		[System.ComponentModel.Description("Shipping and other industry publications, including graphics, charts and web sites.")]
		[EnumMember(Value = "Industry Publications and Reports")] 
		[XmlEnum("9")] 
		IndustryPublicationsAndReports = 9,

		[System.ComponentModel.Description("Information obtained from satellite images.")]
		[EnumMember(Value = "Remotely Sensed Images")] 
		[XmlEnum("10")] 
		RemotelySensedImages = 10,

		[System.ComponentModel.Description("Information obtained from photographs.")]
		[EnumMember(Value = "Photographs")] 
		[XmlEnum("11")] 
		Photographs = 11,

		[System.ComponentModel.Description("Information obtained from products issued by Hydrographic Offices.")]
		[EnumMember(Value = "Products Issued by HO Services")] 
		[XmlEnum("12")] 
		ProductsIssuedByHoServices = 12,

		[System.ComponentModel.Description("Information obtained from news media.")]
		[EnumMember(Value = "News Media")] 
		[XmlEnum("13")] 
		NewsMedia = 13,

		[System.ComponentModel.Description("Information obtained from the analysis of traffic data.")]
		[EnumMember(Value = "Traffic Data")] 
		[XmlEnum("14")] 
		TrafficData = 14,

		[System.ComponentModel.Description("A national or regional authority charged with administration of maritime affairs.")]
		[EnumMember(Value = "Maritime")] 
		[XmlEnum("15")] 
		Maritime = 15,
	}

	/// <summary>
	/// The use for which the dataset is intended.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum specificUsage : int {
		[System.ComponentModel.Description("For use in the study of the characteristics of maritime zones, in the formulation of plans, in the selection of routes, etc., showing only relevant elements of the coastline, harbours, islands, principal navigational marks and obstructions, and submarine landforms.")]
		[EnumMember(Value = "Navigational Purpose Overview")] 
		[XmlEnum("1")] 
		NavigationalPurposeOverview = 1,

		[System.ComponentModel.Description("A nautical chart with universality (i.e., generality) in use, characterized by the requirement that the chart must comprehensively describe various natural elements and socioeconomic elements, and that each element of the subject matter expressed is universal.")]
		[EnumMember(Value = "Navigational Purpose General")] 
		[XmlEnum("2")] 
		NavigationalPurposeGeneral = 2,

		[System.ComponentModel.Description("Used for marine navigation, mainly displaying submarine landforms, navigational marks, navigational obstacles and other elements related to navigation.")]
		[EnumMember(Value = "Navigational Purpose Coastal")] 
		[XmlEnum("3")] 
		NavigationalPurposeCoastal = 3,

		[System.ComponentModel.Description("Used for near-shore navigation, mainly showing the marine elements close to coastal areas.")]
		[EnumMember(Value = "Navigational Purpose Approach")] 
		[XmlEnum("4")] 
		NavigationalPurposeApproach = 4,

		[System.ComponentModel.Description("Used for entering and leaving harbours, selecting anchorage, studying harbour topography, and carrying out the construction of harbours.")]
		[EnumMember(Value = "Navigational Purpose Harbour")] 
		[XmlEnum("5")] 
		NavigationalPurposeHarbour = 5,

		[System.ComponentModel.Description("For ships berthing.")]
		[EnumMember(Value = "Navigational Purpose Berthing")] 
		[XmlEnum("6")] 
		NavigationalPurposeBerthing = 6,
	}

	/// <summary>
	/// Classification of methods of communication over a distance by electrical, electronic, or electromagnetic means.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum telecommunicationService : int {
		[System.ComponentModel.Description("The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.")]
		[EnumMember(Value = "Voice")] 
		[XmlEnum("1")] 
		Voice = 1,

		[System.ComponentModel.Description("A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.")]
		[EnumMember(Value = "Facsimile")] 
		[XmlEnum("2")] 
		Facsimile = 2,

		[System.ComponentModel.Description("Short Message Service is a form of text messaging communication on phones and mobile phones.")]
		[EnumMember(Value = "SMS")] 
		[XmlEnum("3")] 
		Sms = 3,

		[System.ComponentModel.Description("A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.")]
		[EnumMember(Value = "Data")] 
		[XmlEnum("4")] 
		Data = 4,

		[System.ComponentModel.Description("Data that is constantly received by and presented to an end-user while being delivered by a provider.")]
		[EnumMember(Value = "Streamed Data")] 
		[XmlEnum("5")] 
		StreamedData = 5,

		[System.ComponentModel.Description("A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).")]
		[EnumMember(Value = "Telex")] 
		[XmlEnum("6")] 
		Telex = 6,

		[System.ComponentModel.Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
		[EnumMember(Value = "Telegraph")] 
		[XmlEnum("7")] 
		Telegraph = 7,

		[System.ComponentModel.Description("Messages and other data exchanged between individuals using computers in a network.")]
		[EnumMember(Value = "Email")] 
		[XmlEnum("8")] 
		Email = 8,
	}

	/// <summary>
	/// The type of product format.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfProductFormat : int {
		[System.ComponentModel.Description("Geography Markup Language. An XML-based geographic information encoding language developed by the Open GIS Consortium (OGC) to enhance the interoperability of geographic information.")]
		[EnumMember(Value = "GML")] 
		[XmlEnum("1")] 
		Gml = 1,

		[System.ComponentModel.Description("Specification for a data descriptive file for information interchange.")]
		[EnumMember(Value = "ISO/IEC 8211")] 
		[XmlEnum("2")] 
		IsoIec8211 = 2,

		[System.ComponentModel.Description("Portable Document Format. A file format developed by Adobe in 1993 to present documents, including text formatting and images, in a manner independent of application software, hardware, and operating systems.")]
		[EnumMember(Value = "PDF")] 
		[XmlEnum("3")] 
		Pdf = 3,

		[System.ComponentModel.Description("Hypertext Markup Language.")]
		[EnumMember(Value = "HTML")] 
		[XmlEnum("4")] 
		Html = 4,

		[System.ComponentModel.Description("E-book file format.")]
		[EnumMember(Value = "ePub")] 
		[XmlEnum("5")] 
		Epub = 5,

		[System.ComponentModel.Description("For printing hydrographic charts, heavyweight, single layer paper is used. Such paper is generally made wholly or partly from rags and simulates hand-made paper. It is strong, moisture resistant and manufactured to withstand surface erasure.")]
		[EnumMember(Value = "Paper")] 
		[XmlEnum("6")] 
		Paper = 6,

		[System.ComponentModel.Description("Hierarchical Data Format version 5 is a file format and data model designed for storing and organizing large amounts of numerical data efficiently.")]
		[EnumMember(Value = "HDF-5")] 
		[XmlEnum("7")] 
		Hdf5 = 7,

		[System.ComponentModel.Description("A file format used primarily for storing nautical charts in raster form.")]
		[EnumMember(Value = "BSB")] 
		[XmlEnum("8")] 
		Bsb = 8,

		[System.ComponentModel.Description("Extension of the TIFF specification to allow the storage of geo- referencing information.")]
		[EnumMember(Value = "GeoTiff")] 
		[XmlEnum("9")] 
		Geotiff = 9,

		[System.ComponentModel.Description("Provision of data in a format including operational functionality, such as a software program designed to perform specific tasks or functions for the user.")]
		[EnumMember(Value = "Application")] 
		[XmlEnum("10")] 
		Application = 10,

		[System.ComponentModel.Description("Extensible Markup Language.")]
		[EnumMember(Value = "XML")] 
		[XmlEnum("11")] 
		Xml = 11,

		[System.ComponentModel.Description("Portable Network Graphics format.")]
		[EnumMember(Value = "PNG")] 
		[XmlEnum("12")] 
		Png = 12,
	}

	/// <summary>
	/// The unit of a value indicating a time Time Interval.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfTimeIntervalUnit : int {
		[System.ComponentModel.Description("A unit of time equal to 60 minutes or 3600 seconds.")]
		[EnumMember(Value = "Hour")] 
		[XmlEnum("1")] 
		Hour = 1,

		[System.ComponentModel.Description("(1) The duration of one rotation of the earth, or occasionally another celestial body, on its axis. It is measured by successive transits of a reference point on the celestial sphere over the meridian, and each type takes its name from the reference used.  (2) The period of daylight, as distinguished from night.")]
		[EnumMember(Value = "Day")] 
		[XmlEnum("2")] 
		Day = 2,

		[System.ComponentModel.Description("A measure of time based on the motion of the moon in its orbit.")]
		[EnumMember(Value = "Month")] 
		[XmlEnum("3")] 
		Month = 3,

		[System.ComponentModel.Description("A period of one revolution of the earth around the sun.")]
		[EnumMember(Value = "Year")] 
		[XmlEnum("4")] 
		Year = 4,
	}

	/// <summary>
	/// The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		[XmlEnum("1")] 
		MeanLowWaterSprings = 1,

		[System.ComponentModel.Description("The average height of lower low water springs at a place.")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		[XmlEnum("2")] 
		MeanLowerLowWaterSprings = 2,

		[System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("3")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.")]
		[EnumMember(Value = "Lowest Low Water")] 
		[XmlEnum("4")] 
		LowestLowWater = 4,

		[System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Low Water")] 
		[XmlEnum("5")] 
		MeanLowWater = 5,

		[System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		[XmlEnum("6")] 
		LowestLowWaterSprings = 6,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		[XmlEnum("7")] 
		ApproximateMeanLowWaterSprings = 7,

		[System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		[XmlEnum("8")] 
		IndianSpringLowWater = 8,

		[System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
		[EnumMember(Value = "Low Water Springs")] 
		[XmlEnum("9")] 
		LowWaterSprings = 9,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		[XmlEnum("10")] 
		ApproximateLowestAstronomicalTide = 10,

		[System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		[XmlEnum("11")] 
		NearlyLowestLowWater = 11,

		[System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		[XmlEnum("12")] 
		MeanLowerLowWater = 12,

		[System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation.")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("13")] 
		LowWater = 13,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		[XmlEnum("14")] 
		ApproximateMeanLowWater = 14,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		[XmlEnum("15")] 
		ApproximateMeanLowerLowWater = 15,

		[System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean High Water")] 
		[XmlEnum("16")] 
		MeanHighWater = 16,

		[System.ComponentModel.Description("The average height of the high waters of spring tides.")]
		[EnumMember(Value = "Mean High Water Springs")] 
		[XmlEnum("17")] 
		MeanHighWaterSprings = 17,

		[System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
		[EnumMember(Value = "High Water")] 
		[XmlEnum("18")] 
		HighWater = 18,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("19")] 
		ApproximateMeanSeaLevel = 19,

		[System.ComponentModel.Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
		[EnumMember(Value = "High Water Springs")] 
		[XmlEnum("20")] 
		HighWaterSprings = 20,

		[System.ComponentModel.Description("The average height of higher high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Higher High Water")] 
		[XmlEnum("21")] 
		MeanHigherHighWater = 21,

		[System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		[XmlEnum("22")] 
		EquinoctialSpringLowWater = 22,

		[System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		[XmlEnum("23")] 
		LowestAstronomicalTide = 23,

		[System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("24")] 
		LocalDatum = 24,

		[System.ComponentModel.Description("A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Père, Quebec, over the period 1970 to 1988.")]
		[EnumMember(Value = "International Great Lakes Datum 1985")] 
		[XmlEnum("25")] 
		InternationalGreatLakesDatum1985 = 25,

		[System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("26")] 
		MeanWaterLevel = 26,

		[System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		[XmlEnum("27")] 
		LowerLowWaterLargeTide = 27,

		[System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		[XmlEnum("28")] 
		HigherHighWaterLargeTide = 28,

		[System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		[XmlEnum("29")] 
		NearlyHighestHighWater = 29,

		[System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		[XmlEnum("30")] 
		HighestAstronomicalTide = 30,

		[System.ComponentModel.Description("Low water reference level of the local area.")]
		[EnumMember(Value = "Local Low Water Reference Level")] 
		[XmlEnum("31")] 
		LocalLowWaterReferenceLevel = 31,

		[System.ComponentModel.Description("High water reference level of the local area.")]
		[EnumMember(Value = "Local High Water Reference Level")] 
		[XmlEnum("32")] 
		LocalHighWaterReferenceLevel = 32,

		[System.ComponentModel.Description("Mean water reference level of the local area.")]
		[EnumMember(Value = "Local Mean Water Reference Level")] 
		[XmlEnum("33")] 
		LocalMeanWaterReferenceLevel = 33,

		[System.ComponentModel.Description("A low water level which is the result of a defined low water discharge - called \"equivalent discharge\".")]
		[EnumMember(Value = "Equivalent Height of Water (German GlW)")] 
		[XmlEnum("34")] 
		EquivalentHeightOfWaterGermanGlw = 34,

		[System.ComponentModel.Description("Upper limit of water levels where navigation is allowed.")]
		[EnumMember(Value = "Highest Shipping Height of Water (German HSW)")] 
		[XmlEnum("35")] 
		HighestShippingHeightOfWaterGermanHsw = 35,

		[System.ComponentModel.Description("The water level at a discharge, which is exceeded 94 % of the year within a period of 30 years.")]
		[EnumMember(Value = "Reference Low Water Level According to Danube Commission")] 
		[XmlEnum("36")] 
		ReferenceLowWaterLevelAccordingToDanubeCommission = 36,

		[System.ComponentModel.Description("The water level at a discharge, which is exceeded 1% of the year within a period of 30 years.")]
		[EnumMember(Value = "Highest Shipping Height of Water According to Danube Commission")] 
		[XmlEnum("37")] 
		HighestShippingHeightOfWaterAccordingToDanubeCommission = 37,

		[System.ComponentModel.Description("The water level at a discharge, which is exceeded 95% of the year within a period of 20 years.")]
		[EnumMember(Value = "Dutch River Low Water Reference Level (OLR)")] 
		[XmlEnum("38")] 
		DutchRiverLowWaterReferenceLevelOlr = 38,

		[System.ComponentModel.Description("Conditional low water level with established probability.")]
		[EnumMember(Value = "Russian Project Water Level")] 
		[XmlEnum("39")] 
		RussianProjectWaterLevel = 39,

		[System.ComponentModel.Description("Highest water level derived from the upper backwater stream in watercourse or reservoir under the normal operational conditions.")]
		[EnumMember(Value = "Russian Normal Backwater Level")] 
		[XmlEnum("40")] 
		RussianNormalBackwaterLevel = 40,

		[System.ComponentModel.Description("The Ohio River datum.")]
		[EnumMember(Value = "Ohio River Datum")] 
		[XmlEnum("41")] 
		OhioRiverDatum = 41,

		[System.ComponentModel.Description("Dutch High Water Reference Level.")]
		[EnumMember(Value = "Dutch High Water Reference Level")] 
		[XmlEnum("43")] 
		DutchHighWaterReferenceLevel = 43,

		[System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum2000 = 44,

		[System.ComponentModel.Description("Dutch Estuary Low Water Reference Level (OLW)")]
		[EnumMember(Value = "Dutch Estuary Low Water Reference Level (OLW)")] 
		[XmlEnum("45")] 
		DutchEstuaryLowWaterReferenceLevelOlw = 45,

		[System.ComponentModel.Description("The 2020 update to the International Great Lakes Datum, the official reference system used to measure water level heights in the Great Lakes, connecting channels, and the St. Lawrence River system.")]
		[EnumMember(Value = "International Great Lakes Datum 2020")] 
		[XmlEnum("46")] 
		InternationalGreatLakesDatum2020 = 46,

		[System.ComponentModel.Description("The bottom of the ocean and seas where there is a generally smooth gentle gradient. Also referred to as sea bed (sometimes seabed or sea-bed), and sea bottom.")]
		[EnumMember(Value = "Sea Floor")] 
		[XmlEnum("47")] 
		SeaFloor = 47,

		[System.ComponentModel.Description("A two-dimensional (in the horizontal plane) field representing the air-sea interface, with high-frequency fluctuations such as wind waves and swell, but not astronomical tides, filtered out.")]
		[EnumMember(Value = "Sea Surface")] 
		[XmlEnum("48")] 
		SeaSurface = 48,

		[System.ComponentModel.Description("A vertical reference near the lowest astronomical tide (LAT), below which the sea level falls only very exceptionally.")]
		[EnumMember(Value = "Hydrographic Zero")] 
		[XmlEnum("49")] 
		HydrographicZero = 49,
	}

	/// <summary>
	/// Horizontal reference as an EPSG code representing a valid entry in the EPSG Geodetic Parameter Dataset, as maintained by the Geodesy Subcommittee of the IOGP Geomatics Committee, and provided online at epsg.org.
	/// </summary>
	/// <remarks>
	/// codeListType=open enumeration; encoding=other: [something]
	/// </remarks>
	[System.Serializable()]
	public class horizontalDatumEPSGCode
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	public static class CodeList
	{
		public static ImmutableArray<horizontalDatumEPSGCode> horizontalDatumEPSGCodes => ImmutableArray.Create<horizontalDatumEPSGCode>(new horizontalDatumEPSGCode[]{
			new() {
				code = 3395,
				definition = "A global Mercator projection commonly used for mapping applications requiring accurate distance measurements near the equator.",
				label = "EPSG3395 (World Mercator)",
			},
			new() {
				code = 3857,
				definition = "A popular web mapping projection used by Google Maps, OpenStreetMap, and Bing Maps. Distorts at the poles but is widely used in online maps.",
				label = "EPSG3857 (Pseudo-Mercator)",
			},
			new() {
				code = 4326,
				definition = "World Geodetic System 1984, used globally for GPS and geographic coordinates. Specifies coordinates in latitude and longitude degrees.",
				label = "EPSG4326 (WGS84)",
			},
		});
	}

	namespace ComplexAttributes {
		/// <summary>
		/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress {
			[XmlElement("administrativeDivision")]
			public String? administrativeDivision {get;set;} = default;

			public bool ShouldSerializeadministrativeDivision() { return !string.IsNullOrEmpty(administrativeDivision); }

			[XmlElement("cityName")]
			public String? cityName {get;set;} = default;

			public bool ShouldSerializecityName() { return !string.IsNullOrEmpty(cityName); }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlElement("deliveryPoint")]
			public List<String> deliveryPoint {get;set;} = [];

			public bool ShouldSerializedeliveryPoint() { return deliveryPoint.Any(); }

			[XmlElement("postalCode")]
			public String? postalCode {get;set;} = default;

			public bool ShouldSerializepostalCode() { return !string.IsNullOrEmpty(postalCode); }
		}

		/// <summary>
		/// User specified paper size width x, height y
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class customPaperSize {
			[XmlElement("paperWidth")]
			public decimal paperWidth {get;set;} = default;

			[XmlElement("paperLength")]
			public decimal paperLength {get;set;} = default;
		}

		/// <summary>
		/// Locale of an option that is selected automatically unless an alternative is specified.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class defaultLocale {
			[XmlElement("characterEncoding")]
			public String characterEncoding {get;set;} = string.Empty;

			[XmlElement("countryName")]
			public String countryName {get;set;} = string.Empty;

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		/// <summary>
		/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("name")]
			public String name {get;set;} = string.Empty;

			[XmlIgnore]
			public nameUsage? nameUsage {get;set;} = default;

			[JsonIgnore]
			[XmlElement("nameUsage")]
			public SerializableEnumeration<nameUsage>? nameUsageElement { get { return nameUsage; } set { } }

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }
		}

		/// <summary>
		/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			[XmlElement("fileLocator")]
			public String? fileLocator {get;set;} = default;

			public bool ShouldSerializefileLocator() { return !string.IsNullOrEmpty(fileLocator); }

			[XmlElement("fileReference")]
			public String? fileReference {get;set;} = default;

			public bool ShouldSerializefileReference() { return !string.IsNullOrEmpty(fileReference); }

			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("text")]
			public List<String> text {get;set;} = [];

			public bool ShouldSerializetext() { return text.Any(); }
		}

		/// <summary>
		/// Information about online sources from which a resource or data can be obtained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("applicationProfile")]
			public String? applicationProfile {get;set;} = default;

			public bool ShouldSerializeapplicationProfile() { return !string.IsNullOrEmpty(applicationProfile); }

			[XmlElement("linkage")]
			public String linkage {get;set;} = string.Empty;

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }

			[XmlElement("onlineDescription")]
			public String? onlineDescription {get;set;} = default;

			public bool ShouldSerializeonlineDescription() { return !string.IsNullOrEmpty(onlineDescription); }

			[XmlElement("protocol")]
			public String? protocol {get;set;} = default;

			public bool ShouldSerializeprotocol() { return !string.IsNullOrEmpty(protocol); }

			[XmlElement("protocolRequest")]
			public String? protocolRequest {get;set;} = default;

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }
		}

		/// <summary>
		/// The active period of a recurring event or occurrence.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[XmlElement("dateEnd")]
			public String dateEnd {get;set;} = string.Empty;

			[XmlElement("dateStart")]
			public String dateStart {get;set;} = string.Empty;
		}

		/// <summary>
		/// A decision or establishment of a price.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class pricing {
			[XmlElement("contractPeriod")]
			public String? contractPeriod {get;set;} = default;

			public bool ShouldSerializecontractPeriod() { return !string.IsNullOrEmpty(contractPeriod); }

			[XmlElement("currency")]
			public String currency {get;set;} = string.Empty;

			[XmlElement("price")]
			public decimal price {get;set;} = default;
		}

		/// <summary>
		/// Size of nautical paper charts.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printSize {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public iSO216? iSO216 {get;set;} = default;

			[JsonIgnore]
			[XmlElement("iSO216")]
			public SerializableEnumeration<iSO216>? iSO216Element { get { return iSO216; } set { } }

			public bool ShouldSerializeiSO216() { return iSO216.HasValue; }

			[XmlElement("customPaperSize")]
			public customPaperSize? customPaperSize {get;set;} = default;

			public bool ShouldSerializecustomPaperSize() { return customPaperSize!=default; }
		}

		/// <summary>
		/// The name of the product specification to which a nautical product adheres.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class productSpecification {
			[XmlIgnore]
			public DateOnly editionDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("iSSN")]
			public String? iSSN {get;set;} = default;

			public bool ShouldSerializeiSSN() { return !string.IsNullOrEmpty(iSSN); }

			[XmlElement("name")]
			public String name {get;set;} = string.Empty;

			[XmlElement("version")]
			public String version {get;set;} = string.Empty;
		}

		/// <summary>
		/// The name of the product specification to which a support file adheres.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFileSpecification {
			[XmlIgnore]
			public DateOnly editionDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("name")]
			public String name {get;set;} = string.Empty;

			[XmlElement("version")]
			public String version {get;set;} = string.Empty;
		}

		/// <summary>
		/// The name of the (product) specification to which a nautical service adheres.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class serviceSpecification {
			[XmlIgnore]
			public DateOnly editionDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("name")]
			public String name {get;set;} = string.Empty;

			[XmlElement("version")]
			public String version {get;set;} = string.Empty;
		}

		/// <summary>
		/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIndication {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlIgnore]
			public DateOnly? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return reportedDate.HasValue; }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14,15])]
			public sourceType? sourceType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sourceType")]
			public SerializableEnumeration<sourceType>? sourceTypeElement { get { return sourceType; } set { } }

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }
		}

		/// <summary>
		/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			[XmlElement("contactInstructions")]
			public String contactInstructions {get;set;} = string.Empty;

			[XmlElement("telecommunicationIdentifier")]
			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("telecommunicationService")]
			public SerializableEnumeration<telecommunicationService>[] telecommunicationServiceElement { get { return [.. telecommunicationService]; } set { } }

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.Any(); }
		}

		/// <summary>
		/// The temporal interval of the cycle over which data is produced.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalOfCycle {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public List<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit {get;set;} = [];

			[JsonIgnore]
			[XmlElement("typeOfTimeIntervalUnit")]
			public SerializableEnumeration<typeOfTimeIntervalUnit>[] typeOfTimeIntervalUnitElement { get { return [.. typeOfTimeIntervalUnit]; } set { } }

			public bool ShouldSerializetypeOfTimeIntervalUnit() { return typeOfTimeIntervalUnit.Any(); }

			[XmlElement("valueOfTime")]
			public int valueOfTime {get;set;} = default;
		}

		/// <summary>
		/// The indication of a specific week within a specific year.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class weekOfYear {
			[XmlElement("weekNumber")]
			public int weekNumber {get;set;} = default;

			[XmlElement("yearNumber")]
			public int yearNumber {get;set;} = default;
		}

		/// <summary>
		/// The cycle of issuing a product or service.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class issuanceCycle {
			[XmlElement("periodicDateRange")]
			public periodicDateRange? periodicDateRange {get;set;} = default;

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }

			[XmlElement("timeIntervalOfCycle")]
			public timeIntervalOfCycle? timeIntervalOfCycle {get;set;} = default;

			public bool ShouldSerializetimeIntervalOfCycle() { return timeIntervalOfCycle!=default; }
		}

		/// <summary>
		/// Information on the printing of nautical paper charts.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printInformation {
			[XmlElement("printAgency")]
			public String? printAgency {get;set;} = default;

			public bool ShouldSerializeprintAgency() { return !string.IsNullOrEmpty(printAgency); }

			[XmlElement("printNation")]
			public String? printNation {get;set;} = default;

			public bool ShouldSerializeprintNation() { return !string.IsNullOrEmpty(printNation); }

			[XmlElement("reprintEdition")]
			public String? reprintEdition {get;set;} = default;

			public bool ShouldSerializereprintEdition() { return !string.IsNullOrEmpty(reprintEdition); }

			[XmlElement("reprintNation")]
			public String? reprintNation {get;set;} = default;

			public bool ShouldSerializereprintNation() { return !string.IsNullOrEmpty(reprintNation); }

			[XmlElement("printSize")]
			public printSize printSize {get;set;} = new printSize {
			};
		}

		/// <summary>
		/// Information on additional files used in addition to nautical products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFile {
			[XmlElement("comment")]
			public String? comment {get;set;} = default;

			public bool ShouldSerializecomment() { return !string.IsNullOrEmpty(comment); }

			[XmlIgnore]
			[EnumerationValue([8])]
			public digitalSignatureReference digitalSignatureReference {get;set;}

			[JsonIgnore]
			[XmlElement("digitalSignatureReference")]
			public SerializableEnumeration<digitalSignatureReference> digitalSignatureReferenceElement { get { return digitalSignatureReference; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public digitalSignatureValue? digitalSignatureValue {get;set;} = default;

			[JsonIgnore]
			[XmlElement("digitalSignatureValue")]
			public SerializableEnumeration<digitalSignatureValue>? digitalSignatureValueElement { get { return digitalSignatureValue; } set { } }

			public bool ShouldSerializedigitalSignatureValue() { return digitalSignatureValue.HasValue; }

			[XmlElement("editionNumber")]
			public int? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return editionNumber.HasValue; }

			[XmlElement("fileLocator")]
			public String fileLocator {get;set;} = string.Empty;

			[XmlElement("fileName")]
			public String fileName {get;set;} = string.Empty;

			[XmlIgnore]
			public DateOnly? issueDate {get;set;} = default;

			public bool ShouldSerializeissueDate() { return issueDate.HasValue; }

			[XmlElement("otherDataTypeDescription")]
			public String? otherDataTypeDescription {get;set;} = default;

			public bool ShouldSerializeotherDataTypeDescription() { return !string.IsNullOrEmpty(otherDataTypeDescription); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,100])]
			public supportFileFormat supportFileFormat {get;set;}

			[JsonIgnore]
			[XmlElement("supportFileFormat")]
			public SerializableEnumeration<supportFileFormat> supportFileFormatElement { get { return supportFileFormat; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public supportFilePurpose supportFilePurpose {get;set;}

			[JsonIgnore]
			[XmlElement("supportFilePurpose")]
			public SerializableEnumeration<supportFilePurpose> supportFilePurposeElement { get { return supportFilePurpose; } set { } }

			[XmlElement("defaultLocale")]
			public defaultLocale defaultLocale {get;set;} = new defaultLocale {
				characterEncoding = string.Empty,
				countryName = string.Empty,
			};

			[XmlElement("supportFileSpecification")]
			public supportFileSpecification supportFileSpecification {get;set;} = new supportFileSpecification {
				editionDate = default,
				name = string.Empty,
				version = string.Empty,
			};
		}

		/// <summary>
		/// The temporal interval over which the product is updated or renewed.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalOfProduct {
			[XmlIgnore]
			public DateOnly? expirationDate {get;set;} = default;

			public bool ShouldSerializeexpirationDate() { return expirationDate.HasValue; }

			[XmlIgnore]
			public DateOnly issueDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "issueDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime issueDateField {
				get { return issueDate.ToDateTime(TimeOnly.MinValue); }
				set { issueDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("issuanceCycle")]
			public issuanceCycle? issuanceCycle {get;set;} = default;

			public bool ShouldSerializeissuanceCycle() { return issuanceCycle!=default; }
		}

		/// <summary>
		/// A reference to a of specific Notice to Mariners.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class referenceToNM {
			[XmlIgnore]
			public DateOnly publicationDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "publicationDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime publicationDateField {
				get { return publicationDate.ToDateTime(TimeOnly.MinValue); }
				set { publicationDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("weekOfYear")]
			public weekOfYear? weekOfYear {get;set;} = default;

			public bool ShouldSerializeweekOfYear() { return weekOfYear!=default; }
		}

	}
	public enum Role {
		[System.ComponentModel.Description("The top section of a catalogue.")]
		catalogueHeader,
		[System.ComponentModel.Description("A container of elements.")]
		elementContainer,
		[System.ComponentModel.Description("Reference to an element within a catalogue.")]
		theCatalogueElement,
		[System.ComponentModel.Description("Reference to a Catalogue of Nautical product.")]
		theCatalogueOfNauticalProduct,
		[System.ComponentModel.Description("Reference to Contact details.")]
		theContactDetails,
		[System.ComponentModel.Description("Reference to the distributor.")]
		theDistributor,
		[System.ComponentModel.Description("Reference to an element.")]
		theElement,
		[System.ComponentModel.Description("Reference to price information.")]
		thePriceInformation,
		[System.ComponentModel.Description("Reference to a producer.")]
		theProducer,
		[System.ComponentModel.Description("Reference to  supporting material or information related to a specific element or data.")]
		theReference,
		[System.ComponentModel.Description("Reference to a requirement for a specific system or process.")]
		theRequirement,
		[System.ComponentModel.Description("Reference to the source of information or data.")]
		theSource,
		[System.ComponentModel.Description("Reference to the main product containg panel(s).")]
		theMain,
		[System.ComponentModel.Description("Reference to the panel of a main product.")]
		thePanel,
	}

	namespace InformationAssociations {
		/// <summary>
		/// A carriage requirement required by SOLAS or other regulation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CarriageRequirement : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CarriageRequirement);
		}

		/// <summary>
		/// Details related to distribution.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributionDetails : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DistributionDetails);
		}

		/// <summary>
		/// Contact information of distributor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributorContact : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DistributorContact);
		}

		/// <summary>
		/// An association of price information to a catalogue element.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceOfElement : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PriceOfElement);
		}

		/// <summary>
		/// The price of a nautical product.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceOfNauticalProduct : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PriceOfNauticalProduct);
		}

		/// <summary>
		/// Contact information of producer.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProducerContact : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ProducerContact);
		}

		/// <summary>
		/// Contact information of a producing organization.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductionDetails : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ProductionDetails);
		}

		/// <summary>
		/// A package or distinct set of products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductPackage : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ProductPackage);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// Mapping between traditional products and S-100 Products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductMapping : FeatureAssociation {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfProductMapping categoryOfProductMapping {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfProductMapping")]
			public SerializableEnumeration<categoryOfProductMapping> categoryOfProductMappingElement { get { return categoryOfProductMapping; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ProductMapping);
		}

		/// <summary>
		/// A supplementary or secondary part of the product, which may appear multiple times, offering control or display functionalities depending on its configuration.
			
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Correlated : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Correlated);
		}
	}

}

namespace S100Framework.DomainModel.S128 {
	using ComplexAttributes;
	using InformationAssociations;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// A header identifying a section within a catalogue.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CatalogueSectionHeader : InformationNode, IInformationBindingDefinition {
			[XmlElement("catalogueSectionNumber")]
			public int catalogueSectionNumber {get;set;} = default;

			[XmlElement("catalogueSectionTitle")]
			public String? catalogueSectionTitle {get;set;} = default;

			public bool ShouldSerializecatalogueSectionTitle() { return !string.IsNullOrEmpty(catalogueSectionTitle); }

			[XmlElement("information")]
			public information? information {get;set;} = default;

			public bool ShouldSerializeinformation() { return information!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CatalogueSectionHeader);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CatalogueSectionHeader._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PriceOfNauticalProduct),
					role = Enum.GetName<Role>(Role.thePriceInformation)!,
					informationTypes = [nameof(PriceInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ProductionDetails),
					role = Enum.GetName<Role>(Role.theProducer)!,
					informationTypes = [nameof(ProducerInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributionDetails),
					role = Enum.GetName<Role>(Role.theDistributor)!,
					informationTypes = [nameof(DistributorInformation)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : InformationNode, IInformationBindingDefinition {
			[XmlElement("contactInstructions")]
			public String contactInstructions {get;set;} = string.Empty;

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("sourceIndication")]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ProducerContact),
					role = Enum.GetName<Role>(Role.theProducer)!,
					informationTypes = [nameof(ProducerInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(DistributorContact),
					role = Enum.GetName<Role>(Role.theDistributor)!,
					informationTypes = [nameof(DistributorInformation)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// An indication of the type or justification of a carriage requirement.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IndicationOfCarriageRequirement : InformationNode, IInformationBindingDefinition {
			[XmlElement("domesticCarriageRequirements")]
			public String? domesticCarriageRequirements {get;set;} = default;

			public bool ShouldSerializedomesticCarriageRequirements() { return !string.IsNullOrEmpty(domesticCarriageRequirements); }

			[XmlElement("internationalCarriageRequirements")]
			public String? internationalCarriageRequirements {get;set;} = default;

			public bool ShouldSerializeinternationalCarriageRequirements() { return !string.IsNullOrEmpty(internationalCarriageRequirements); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(IndicationOfCarriageRequirement);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IndicationOfCarriageRequirement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Pricing information of nautical products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("pricing")]
			public List<pricing> pricing {get;set;} = [];

			public bool ShouldSerializepricing() { return pricing.Any(); }

			[XmlElement("sourceIndication")]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PriceInformation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => PriceInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PriceOfNauticalProduct),
					role = Enum.GetName<Role>(Role.theCatalogueOfNauticalProduct)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information about the authority responsible for production.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProducerInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public String agencyResponsibleForProduction {get;set;} = string.Empty;

			[XmlElement("agencyName")]
			public String? agencyName {get;set;} = default;

			public bool ShouldSerializeagencyName() { return !string.IsNullOrEmpty(agencyName); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ProducerInformation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ProducerInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProducerContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProductionDetails),
					role = Enum.GetName<Role>(Role.catalogueHeader)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information related to a distributor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributorInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("distributorName")]
			public String distributorName {get;set;} = string.Empty;

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DistributorInformation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DistributorInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributionDetails),
					role = Enum.GetName<Role>(Role.catalogueHeader)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributorContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}
	}
	namespace FeatureTypes {
		using FeatureAssociations;
		using InformationTypes;
		using System.Xml;
		using System.Xml.Linq;

		/// <summary>
		/// An element within a catalogue of elements.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class CatalogueElement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlIgnore]
			public List<catalogueElementClassification> catalogueElementClassification {get;set;} = [];

			[JsonIgnore]
			[XmlElement("catalogueElementClassification")]
			public SerializableEnumeration<catalogueElementClassification>[] catalogueElementClassificationElement { get { return [.. catalogueElementClassification]; } set { } }

			public bool ShouldSerializecatalogueElementClassification() { return catalogueElementClassification.Any(); }

			[XmlElement("catalogueElementIdentifier")]
			public String? catalogueElementIdentifier {get;set;} = default;

			public bool ShouldSerializecatalogueElementIdentifier() { return !string.IsNullOrEmpty(catalogueElementIdentifier); }

			[XmlElement("classification")]
			public String? classification {get;set;} = default;

			public bool ShouldSerializeclassification() { return !string.IsNullOrEmpty(classification); }

			[XmlIgnore]
			public List<iMOMaritimeService> iMOMaritimeService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("iMOMaritimeService")]
			public SerializableEnumeration<iMOMaritimeService>[] iMOMaritimeServiceElement { get { return [.. iMOMaritimeService]; } set { } }

			public bool ShouldSerializeiMOMaritimeService() { return iMOMaritimeService.Any(); }

			[XmlElement("notForNavigation")]
			public Boolean notForNavigation {get;set;} = false;

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			[XmlElement("supportFile")]
			public List<supportFile> supportFile {get;set;} = [];

			public bool ShouldSerializesupportFile() { return supportFile.Any(); }

			[XmlElement("timeIntervalOfProduct")]
			public timeIntervalOfProduct? timeIntervalOfProduct {get;set;} = default;

			public bool ShouldSerializetimeIntervalOfProduct() { return timeIntervalOfProduct!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CatalogueElement);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CatalogueElement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(CarriageRequirement),
					role = Enum.GetName<Role>(Role.theRequirement)!,
					informationTypes = [nameof(IndicationOfCarriageRequirement)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PriceOfElement),
					role = Enum.GetName<Role>(Role.thePriceInformation)!,
					informationTypes = [nameof(PriceInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(ProductPackage),
					role = Enum.GetName<Role>(Role.elementContainer)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CatalogueElement._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CatalogueElement._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProductMapping),
					role = Enum.GetName<Role>(Role.theReference)!,
					featureTypes = [nameof(CatalogueElement)],
				},
			];
		}

		/// <summary>
		/// A physical or electronic product, that is primarily intended for navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class NavigationalProduct : CatalogueElement {
			[XmlElement("approximateGridResolution")]
			public List<decimal> approximateGridResolution {get;set;} = [];

			public bool ShouldSerializeapproximateGridResolution() { return approximateGridResolution.Any(); }

			[XmlElement("compilationScale")]
			public List<int> compilationScale {get;set;} = [];

			public bool ShouldSerializecompilationScale() { return compilationScale.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public distributionStatus? distributionStatus {get;set;} = default;

			[JsonIgnore]
			[XmlElement("distributionStatus")]
			public SerializableEnumeration<distributionStatus>? distributionStatusElement { get { return distributionStatus; } set { } }

			public bool ShouldSerializedistributionStatus() { return distributionStatus.HasValue; }

			[XmlElement("editionNumber")]
			public int? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return editionNumber.HasValue; }

			[XmlElement("maximumDisplayScale")]
			public int? maximumDisplayScale {get;set;} = default;

			public bool ShouldSerializemaximumDisplayScale() { return maximumDisplayScale.HasValue; }

			[XmlElement("minimumDisplayScale")]
			public int? minimumDisplayScale {get;set;} = default;

			public bool ShouldSerializeminimumDisplayScale() { return minimumDisplayScale.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public List<navigationPurpose> navigationPurpose {get;set;} = [];

			[JsonIgnore]
			[XmlElement("navigationPurpose")]
			public SerializableEnumeration<navigationPurpose>[] navigationPurposeElement { get { return [.. navigationPurpose]; } set { } }

			public bool ShouldSerializenavigationPurpose() { return navigationPurpose.Any(); }

			[XmlElement("optimumDisplayScale")]
			public String? optimumDisplayScale {get;set;} = default;

			public bool ShouldSerializeoptimumDisplayScale() { return !string.IsNullOrEmpty(optimumDisplayScale); }

			[XmlElement("originalProductNumber")]
			public String? originalProductNumber {get;set;} = default;

			public bool ShouldSerializeoriginalProductNumber() { return !string.IsNullOrEmpty(originalProductNumber); }

			[XmlElement("producerNation")]
			public String? producerNation {get;set;} = default;

			public bool ShouldSerializeproducerNation() { return !string.IsNullOrEmpty(producerNation); }

			[XmlElement("productNumber")]
			public String? productNumber {get;set;} = default;

			public bool ShouldSerializeproductNumber() { return !string.IsNullOrEmpty(productNumber); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public specificUsage? specificUsage {get;set;} = default;

			[JsonIgnore]
			[XmlElement("specificUsage")]
			public SerializableEnumeration<specificUsage>? specificUsageElement { get { return specificUsage; } set { } }

			public bool ShouldSerializespecificUsage() { return specificUsage.HasValue; }

			[XmlIgnore]
			public DateOnly? updateDate {get;set;} = default;

			public bool ShouldSerializeupdateDate() { return updateDate.HasValue; }

			[XmlElement("updateNumber")]
			public int? updateNumber {get;set;} = default;

			public bool ShouldSerializeupdateNumber() { return updateNumber.HasValue; }

			[XmlElement("horizontalDatumEPSGCode")]
			public horizontalDatumEPSGCode? horizontalDatumEPSGCode {get;set;} = default;

			public bool ShouldSerializehorizontalDatumEPSGCode() { return horizontalDatumEPSGCode != default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavigationalProduct);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..CatalogueElement._informationBindingDefinitions, ..NavigationalProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..CatalogueElement._featureBindingDefinitions, ..NavigationalProduct._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..CatalogueElement._primitives, ..NavigationalProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Correlated),
					role = Enum.GetName<Role>(Role.theMain)!,
					featureTypes = [nameof(NavigationalProduct)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Correlated),
					role = Enum.GetName<Role>(Role.thePanel)!,
					featureTypes = [nameof(NavigationalProduct)],
				},
			];
		}

		/// <summary>
		/// Electronic navigation product.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ElectronicProduct : NavigationalProduct {
			[XmlElement("compressionFlag")]
			public Boolean? compressionFlag {get;set;} = default;

			public bool ShouldSerializecompressionFlag() { return compressionFlag.HasValue; }

			[XmlElement("datasetName")]
			public String? datasetName {get;set;} = default;

			public bool ShouldSerializedatasetName() { return !string.IsNullOrEmpty(datasetName); }

			[XmlIgnore]
			public DateOnly issueDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "issueDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime issueDateField {
				get { return issueDate.ToDateTime(TimeOnly.MinValue); }
				set { issueDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("issueTime")]
			public S100Framework.DomainModel.S100.Time? issueTime {get;set;} = default;

			public bool ShouldSerializeissueTime() { return issueTime.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public typeOfProductFormat typeOfProductFormat {get;set;}

			[JsonIgnore]
			[XmlElement("typeOfProductFormat")]
			public SerializableEnumeration<typeOfProductFormat> typeOfProductFormatElement { get { return typeOfProductFormat; } set { } }

			[XmlElement("productSpecification")]
			public productSpecification? productSpecification {get;set;} = default;

			public bool ShouldSerializeproductSpecification() { return productSpecification!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ElectronicProduct);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..NavigationalProduct._informationBindingDefinitions, ..ElectronicProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..NavigationalProduct._featureBindingDefinitions, ..ElectronicProduct._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..NavigationalProduct._primitives, ..ElectronicProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A product printed on paper.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalProduct : NavigationalProduct {
			[XmlIgnore]
			public DateOnly editionDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("iSBN")]
			public String? iSBN {get;set;} = default;

			public bool ShouldSerializeiSBN() { return !string.IsNullOrEmpty(iSBN); }

			[XmlElement("publicationNumber")]
			public String? publicationNumber {get;set;} = default;

			public bool ShouldSerializepublicationNumber() { return !string.IsNullOrEmpty(publicationNumber); }

			[XmlElement("typeOfPhysicalProduct")]
			public String? typeOfPhysicalProduct {get;set;} = default;

			public bool ShouldSerializetypeOfPhysicalProduct() { return !string.IsNullOrEmpty(typeOfPhysicalProduct); }

			[XmlElement("printInformation")]
			public printInformation? printInformation {get;set;} = default;

			public bool ShouldSerializeprintInformation() { return printInformation!=default; }

			[XmlElement("referenceToNM")]
			public referenceToNM? referenceToNM {get;set;} = default;

			public bool ShouldSerializereferenceToNM() { return referenceToNM!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PhysicalProduct);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..NavigationalProduct._informationBindingDefinitions, ..PhysicalProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..NavigationalProduct._featureBindingDefinitions, ..PhysicalProduct._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..NavigationalProduct._primitives, ..PhysicalProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A service that makes use of S-100 based product specifications to support data transfer.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class S100Service : CatalogueElement {
			[XmlElement("compressionFlag")]
			public Boolean? compressionFlag {get;set;} = default;

			public bool ShouldSerializecompressionFlag() { return compressionFlag.HasValue; }

			[XmlElement("serviceName")]
			public String? serviceName {get;set;} = default;

			public bool ShouldSerializeserviceName() { return !string.IsNullOrEmpty(serviceName); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public serviceStatus? serviceStatus {get;set;} = default;

			[JsonIgnore]
			[XmlElement("serviceStatus")]
			public SerializableEnumeration<serviceStatus>? serviceStatusElement { get { return serviceStatus; } set { } }

			public bool ShouldSerializeserviceStatus() { return serviceStatus.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public typeOfProductFormat typeOfProductFormat {get;set;}

			[JsonIgnore]
			[XmlElement("typeOfProductFormat")]
			public SerializableEnumeration<typeOfProductFormat> typeOfProductFormatElement { get { return typeOfProductFormat; } set { } }

			[XmlElement("serviceSpecification")]
			public serviceSpecification? serviceSpecification {get;set;} = default;

			public bool ShouldSerializeserviceSpecification() { return serviceSpecification!=default; }

			[XmlElement("productSpecification")]
			public productSpecification? productSpecification {get;set;} = default;

			public bool ShouldSerializeproductSpecification() { return productSpecification!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(S100Service);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..CatalogueElement._informationBindingDefinitions, ..S100Service._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..CatalogueElement._featureBindingDefinitions, ..S100Service._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..CatalogueElement._primitives, ..S100Service._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S128/2.0")]
	[XmlRoot(Namespace = "http://www.iho.int/S128/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S128/2.0 128_2.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S128/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.CatalogueSectionHeader", typeof(InformationTypes.CatalogueSectionHeader), Order = 1, ElementName = "CatalogueSectionHeader")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.IndicationOfCarriageRequirement", typeof(InformationTypes.IndicationOfCarriageRequirement), Order = 1, ElementName = "IndicationOfCarriageRequirement")]
		[XmlElement("InformationTypes.PriceInformation", typeof(InformationTypes.PriceInformation), Order = 1, ElementName = "PriceInformation")]
		[XmlElement("InformationTypes.ProducerInformation", typeof(InformationTypes.ProducerInformation), Order = 1, ElementName = "ProducerInformation")]
		[XmlElement("InformationTypes.DistributorInformation", typeof(InformationTypes.DistributorInformation), Order = 1, ElementName = "DistributorInformation")]
		[XmlElement("FeatureTypes.ElectronicProduct", typeof(FeatureTypes.ElectronicProduct), Order = 1, ElementName = "ElectronicProduct")]
		[XmlElement("FeatureTypes.PhysicalProduct", typeof(FeatureTypes.PhysicalProduct), Order = 1, ElementName = "PhysicalProduct")]
		[XmlElement("FeatureTypes.S100Service", typeof(FeatureTypes.S100Service), Order = 1, ElementName = "S100Service")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
