using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S122 {
	public class Summary : ISummary
	{
		public static string Name => "Marine Protected Area";
		public static string Scope => "";
		public static string ProductId => "S-122";
		public static Version Version => new Version("1.2.1");
		public static DateOnly VersionDate => DateOnly.ParseExact("2024-09-16", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["bearingInformation","contactAddress","featureName","fixedDateRange","frequencyPair","graphic","information","onlineResource","orientation","periodicDateRange","rxNCode","scheduleByDayOfWeek","sectorLimit","sectorLimitOne","sectorLimitTwo","telecommunications","textContent","timeIntervalsByDayOfWeek","vesselsMeasurements","designation"];
		public static string[] InformationAssociationTypes => ["AssociatedRxN","ExceptionalWorkday","ProtectedAreaAuthority","ServiceControl","RelatedOrganisation","PermissionType","InclusionType","AuthorityContact","AuthorityHours","additionalInformation"];
		public static string[] FeatureAssociationTypes => [];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","NauticalInformation","Regulations","Restrictions","Recommendations","Authority","ContactDetails","NonStandardWorkingDay","ServiceHours","Applicability"];
		public static string[] FeatureTypes => ["RestrictedArea","MarineProtectedArea","VesselTrafficServiceArea","DataCoverage","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType"],
			Primitives.surface => ["RestrictedArea","MarineProtectedArea","VesselTrafficServiceArea","DataCoverage"],
			Primitives.curve => ["MarineProtectedArea"],
			Primitives.point => ["TextPlacement"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [Primitives.noGeometry],
			"RestrictedArea" => [Primitives.surface],
			"MarineProtectedArea" => [Primitives.curve,Primitives.surface],
			"VesselTrafficServiceArea" => [Primitives.surface],
			"DataCoverage" => [Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalDirection : int {
		[System.ComponentModel.Description("North")]
		[EnumMember(Value = "N")] 
		[XmlEnum("1")] 
		N = 1,

		[System.ComponentModel.Description("Northnortheast")]
		[EnumMember(Value = "NNE")] 
		[XmlEnum("2")] 
		Nne = 2,

		[System.ComponentModel.Description("Northeast")]
		[EnumMember(Value = "NE")] 
		[XmlEnum("3")] 
		Ne = 3,

		[System.ComponentModel.Description("Eastnortheast")]
		[EnumMember(Value = "ENE")] 
		[XmlEnum("4")] 
		Ene = 4,

		[System.ComponentModel.Description("East")]
		[EnumMember(Value = "E")] 
		[XmlEnum("5")] 
		E = 5,

		[System.ComponentModel.Description("Eastsoutheast")]
		[EnumMember(Value = "ESE")] 
		[XmlEnum("6")] 
		Ese = 6,

		[System.ComponentModel.Description("Southeast")]
		[EnumMember(Value = "SE")] 
		[XmlEnum("7")] 
		Se = 7,

		[System.ComponentModel.Description("Southsoutheast")]
		[EnumMember(Value = "SSE")] 
		[XmlEnum("8")] 
		Sse = 8,

		[System.ComponentModel.Description("South")]
		[EnumMember(Value = "S")] 
		[XmlEnum("9")] 
		S = 9,

		[System.ComponentModel.Description("Southsouthwest")]
		[EnumMember(Value = "SSW")] 
		[XmlEnum("10")] 
		Ssw = 10,

		[System.ComponentModel.Description("Southwest")]
		[EnumMember(Value = "SW")] 
		[XmlEnum("11")] 
		Sw = 11,

		[System.ComponentModel.Description("Westsouthwest")]
		[EnumMember(Value = "WSW")] 
		[XmlEnum("12")] 
		Wsw = 12,

		[System.ComponentModel.Description("West")]
		[EnumMember(Value = "W")] 
		[XmlEnum("13")] 
		W = 13,

		[System.ComponentModel.Description("Westnorthwest")]
		[EnumMember(Value = "WNW")] 
		[XmlEnum("14")] 
		Wnw = 14,

		[System.ComponentModel.Description("Northwest")]
		[EnumMember(Value = "NW")] 
		[XmlEnum("15")] 
		Nw = 15,

		[System.ComponentModel.Description("Northnorthwest")]
		[EnumMember(Value = "NNW")] 
		[XmlEnum("16")] 
		Nnw = 16,
	}

	/// <summary>
	/// Code for function performed by the online resource (ISO 19115)
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum onlineFunction : int {
		[System.ComponentModel.Description("Online instructions for transferring data from one storage device or system to another. (ISO 19115:2014)")]
		[EnumMember(Value = "Download")] 
		[XmlEnum("1")] 
		Download = 1,

		[System.ComponentModel.Description("Online information about the resource (ISO 19115:2014)")]
		[EnumMember(Value = "Information")] 
		[XmlEnum("2")] 
		Information = 2,

		[System.ComponentModel.Description("Online instructions for requesting the resource from the provider (ISO 19115:2014)")]
		[EnumMember(Value = "Offline Access")] 
		[XmlEnum("3")] 
		OfflineAccess = 3,

		[System.ComponentModel.Description("Online order process for obtaining the resource (ISO 19115:2014).")]
		[EnumMember(Value = "Order")] 
		[XmlEnum("4")] 
		Order = 4,

		[System.ComponentModel.Description("Online search interface for seeking out information about the resource (ISO 19115:2014).")]
		[EnumMember(Value = "Search")] 
		[XmlEnum("5")] 
		Search = 5,

		[System.ComponentModel.Description("Complete metadata provided (ISO 19115:2014).")]
		[EnumMember(Value = "Complete Metadata")] 
		[XmlEnum("6")] 
		CompleteMetadata = 6,

		[System.ComponentModel.Description("Browse graphic provided (ISO 19115:2014).")]
		[EnumMember(Value = "Browse Graphic")] 
		[XmlEnum("7")] 
		BrowseGraphic = 7,

		[System.ComponentModel.Description("Online resource upload capability provided (ISO 19115:2014).")]
		[EnumMember(Value = "Upload")] 
		[XmlEnum("8")] 
		Upload = 8,

		[System.ComponentModel.Description("Online email service provided (ISO 19115:2014)")]
		[EnumMember(Value = "Email Service")] 
		[XmlEnum("9")] 
		EmailService = 9,

		[System.ComponentModel.Description("Online browsing provided (ISO 19115:2014)")]
		[EnumMember(Value = "Browsing")] 
		[XmlEnum("10")] 
		Browsing = 10,

		[System.ComponentModel.Description("online file access provided (ISO 19115:2014).")]
		[EnumMember(Value = "File Access")] 
		[XmlEnum("11")] 
		FileAccess = 11,
	}

	/// <summary>
	/// Characteristics of vessels.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("The maximum length of the ship (L.O.A.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Length Overall")] 
		[XmlEnum("1")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("The ship's length measured at the waterline (L.W.L.). (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Length at waterline")] 
		[XmlEnum("2")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("The width or beam of the vessel. (Adapted from http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Breadth")] 
		[XmlEnum("3")] 
		Breadth = 3,

		[System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Draught")] 
		[XmlEnum("4")] 
		Draught = 4,

		[System.ComponentModel.Description("	The height of the highest point of a vessel's structure (e.g. radar aerial, funnel, cranes, masthead) above her waterline. (UKHO NP100/2009)")]
		[EnumMember(Value = "Height")] 
		[XmlEnum("5")] 
		Height = 5,

		[System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Displacement Tonnage")] 
		[XmlEnum("6")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Displacement Tonnage, Light")] 
		[XmlEnum("7")] 
		DisplacementTonnageLight = 7,

		[System.ComponentModel.Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Displacement Tonnage, Loaded")] 
		[XmlEnum("8")] 
		DisplacementTonnageLoaded = 8,

		[System.ComponentModel.Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Deadweight Tonnage")] 
		[XmlEnum("9")] 
		DeadweightTonnage = 9,

		[System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers. (http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Gross Tonnage")] 
		[XmlEnum("10")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.(http://en.wikipedia.org/wiki/Ship_measurements; 24 July 2010)")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net")] 
		[XmlEnum("11")] 
		PanamaCanalUniversalMeasurementSystemNet = 11,

		[System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
		[EnumMember(Value = "Tonnage")] 
		[XmlEnum("12")] 
		Tonnage = 12,

		[System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate. (Adapted from http://en.wikipedia.org/wiki/Tonnage 4 Oct 2010)")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("13")] 
		SuezCanalNetTonnage = 13,

		[System.ComponentModel.Description("Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
		[EnumMember(Value = "Suez Canal Gross Tonnage")] 
		[XmlEnum("14")] 
		SuezCanalGrossTonnage = 14,
	}

	/// <summary>
	/// The unit used for vessel characteristics attribute
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("The metre (or meter) is the base unit of length in the International System of Units (SI). It is defined as the distance travelled by light in vacuum in 1/299,792,458 of a second.")]
		[EnumMember(Value = "Metre")] 
		[XmlEnum("1")] 
		Metre = 1,

		[System.ComponentModel.Description("A foot (plural: feet) is a non-SI unit of length in a number of different systems including English units, Imperial units, and United States customary units. The most commonly used foot today is the international foot. There are three feet in a yard and 12 inches in a foot.")]
		[EnumMember(Value = "Foot")] 
		[XmlEnum("2")] 
		Foot = 2,

		[System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6%.")]
		[EnumMember(Value = "Metric Ton")] 
		[XmlEnum("3")] 
		MetricTon = 3,

		[System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m3) of salt water with a density of 64 lb/ft³ (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty—for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
		[EnumMember(Value = "Ton")] 
		[XmlEnum("4")] 
		Ton = 4,

		[System.ComponentModel.Description("The short ton is a unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some U.S. applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the U.S. system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
		[EnumMember(Value = "Short Ton")] 
		[XmlEnum("5")] 
		ShortTon = 5,

		[System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity. Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
		[EnumMember(Value = "Gross ton")] 
		[XmlEnum("6")] 
		GrossTon = 6,

		[System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessel’s earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
		[EnumMember(Value = "Net Ton")] 
		[XmlEnum("7")] 
		NetTon = 7,

		[System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net Tonnage")] 
		[XmlEnum("8")] 
		PanamaCanalUniversalMeasurementSystemNetTonnage = 8,

		[System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("9")] 
		SuezCanalNetTonnage = 9,

		[System.ComponentModel.Description("Can be used for net and gross tonnages, including Panama Canal/Universal Measurement System net tonnage and The Suez Canal Net Tonnage.")]
		[EnumMember(Value = "None")] 
		[XmlEnum("10")] 
		None = 10,

		[System.ComponentModel.Description("Cubic metres")]
		[EnumMember(Value = "Cubic Metres")] 
		[XmlEnum("11")] 
		CubicMetres = 11,

		[System.ComponentModel.Description("The Suez Canal Gross Tonnage (SCGT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
		[EnumMember(Value = "Suez Canal Gross Tonnage")] 
		[XmlEnum("12")] 
		SuezCanalGrossTonnage = 12,
	}

	/// <summary>
	/// Numerical comparison.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("The value of the left value is greater than that of the right.(http://en.wikipedia.org/wiki/Logical_connective)")]
		[EnumMember(Value = "Greater than")] 
		[XmlEnum("1")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
		[EnumMember(Value = "Greater than or equal to")] 
		[XmlEnum("2")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("The value of the left expression is less than that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
		[EnumMember(Value = "Less than")] 
		[XmlEnum("3")] 
		LessThan = 3,

		[System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right. (http://en.wikipedia.org/wiki/Logical_connective)")]
		[EnumMember(Value = "Less than or equal to")] 
		[XmlEnum("4")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("The two values are equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
		[EnumMember(Value = "Equal to")] 
		[XmlEnum("5")] 
		EqualTo = 5,

		[System.ComponentModel.Description("The two values are not equivalent. (adapted http://en.wikipedia.org/wiki/Logical_connective)")]
		[EnumMember(Value = "Not equal to")] 
		[XmlEnum("6")] 
		NotEqualTo = 6,
	}

	/// <summary>
	/// Any one of seven days in a week.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dayOfWeek : int {
		[System.ComponentModel.Description("The first day of the week.")]
		[EnumMember(Value = "Sunday")] 
		[XmlEnum("1")] 
		Sunday = 1,

		[System.ComponentModel.Description("The second day of the week.")]
		[EnumMember(Value = "Monday")] 
		[XmlEnum("2")] 
		Monday = 2,

		[System.ComponentModel.Description("The third day of the week.")]
		[EnumMember(Value = "Tuesday")] 
		[XmlEnum("3")] 
		Tuesday = 3,

		[System.ComponentModel.Description("The fourth day of the week.")]
		[EnumMember(Value = "Wednesday")] 
		[XmlEnum("4")] 
		Wednesday = 4,

		[System.ComponentModel.Description("The fifth day of the week.")]
		[EnumMember(Value = "Thursday")] 
		[XmlEnum("5")] 
		Thursday = 5,

		[System.ComponentModel.Description("The sixth day of the week.")]
		[EnumMember(Value = "Friday")] 
		[XmlEnum("6")] 
		Friday = 6,

		[System.ComponentModel.Description("The seventh day of the week.")]
		[EnumMember(Value = "Saturday")] 
		[XmlEnum("7")] 
		Saturday = 7,
	}

	/// <summary>
	/// Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRelationship : int {
		[System.ComponentModel.Description("use of facility, waterway or service is forbidden")]
		[EnumMember(Value = "Prohibited")] 
		[XmlEnum("1")] 
		Prohibited = 1,

		[System.ComponentModel.Description("use of facility, waterway or service is not recommended")]
		[EnumMember(Value = "Not Recommended")] 
		[XmlEnum("2")] 
		NotRecommended = 2,

		[System.ComponentModel.Description("use of facility, waterway, or service is permitted but not required")]
		[EnumMember(Value = "Permitted")] 
		[XmlEnum("3")] 
		Permitted = 3,

		[System.ComponentModel.Description("use of facility, waterway, or service is recommended")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("4")] 
		Recommended = 4,

		[System.ComponentModel.Description("use of facility, waterway, or service is required")]
		[EnumMember(Value = "Required")] 
		[XmlEnum("5")] 
		Required = 5,

		[System.ComponentModel.Description("use of facility, waterway or service is not required")]
		[EnumMember(Value = "Not Required")] 
		[XmlEnum("6")] 
		NotRequired = 6,
	}

	/// <summary>
	/// Indicates whether a vessel is included or excluded from the regulation / restriction / recommendation / nautical information
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum membership : int {
		[System.ComponentModel.Description("Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.")]
		[EnumMember(Value = "included")] 
		[XmlEnum("1")] 
		Included = 1,

		[System.ComponentModel.Description("Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.")]
		[EnumMember(Value = "excluded")] 
		[XmlEnum("2")] 
		Excluded = 2,
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
	/// The type of schedule, for instance opening, closure, etc.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSchedule : int {
		[System.ComponentModel.Description("The service, office, is open, fully manned, and operating normally, or the area is accessible as usual.")]
		[EnumMember(Value = "Normal Operation")] 
		[XmlEnum("1")] 
		NormalOperation = 1,

		[System.ComponentModel.Description("The service, office, or area is closed.")]
		[EnumMember(Value = "Closure")] 
		[XmlEnum("2")] 
		Closure = 2,

		[System.ComponentModel.Description("The service is available but not manned.")]
		[EnumMember(Value = "Unmanned Operation")] 
		[XmlEnum("3")] 
		UnmannedOperation = 3,
	}

	/// <summary>
	/// Classification of dangerous goods or hazardous materials based on the International Maritime Dangerous Goods Code (IMDG Code).
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDangerousOrHazardousCargo : int {
		[System.ComponentModel.Description("Explosives, Division 1: Substances and articles which have a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.1")] 
		[XmlEnum("1")] 
		ImdgCodeClass1Div11 = 1,

		[System.ComponentModel.Description("Explosives, Division 2: Substances and articles which have a projection hazard but not a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.2")] 
		[XmlEnum("2")] 
		ImdgCodeClass1Div12 = 2,

		[System.ComponentModel.Description("Explosives, Division 3: Substances and articles which have a fire hazard and either a minor blast hazard or a minor projection hazard or both, but not a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.3")] 
		[XmlEnum("3")] 
		ImdgCodeClass1Div13 = 3,

		[System.ComponentModel.Description("Explosives, Division 4: Substances and articles which present no significant hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.4")] 
		[XmlEnum("4")] 
		ImdgCodeClass1Div14 = 4,

		[System.ComponentModel.Description("Explosives, Division 5: Very insensitive substances which have a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.5")] 
		[XmlEnum("5")] 
		ImdgCodeClass1Div15 = 5,

		[System.ComponentModel.Description("Explosives, Division 6: Extremely insensitive articles which do not have a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.6")] 
		[XmlEnum("6")] 
		ImdgCodeClass1Div16 = 6,

		[System.ComponentModel.Description("Gases, flammable gases.")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.1")] 
		[XmlEnum("7")] 
		ImdgCodeClass2Div21 = 7,

		[System.ComponentModel.Description("Gases, non-flammable, non-toxic gases.")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.2")] 
		[XmlEnum("8")] 
		ImdgCodeClass2Div22 = 8,

		[System.ComponentModel.Description("Gases, toxic gases.")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.3")] 
		[XmlEnum("9")] 
		ImdgCodeClass2Div23 = 9,

		[System.ComponentModel.Description("Flammable liquids.")]
		[EnumMember(Value = "IMDG Code Class 3")] 
		[XmlEnum("10")] 
		ImdgCodeClass3 = 10,

		[System.ComponentModel.Description("Flammable solids, self-reactive substances and desensitized explosives.")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.1")] 
		[XmlEnum("11")] 
		ImdgCodeClass4Div41 = 11,

		[System.ComponentModel.Description("Substances liable to spontaneous combustion.")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.2")] 
		[XmlEnum("12")] 
		ImdgCodeClass4Div42 = 12,

		[System.ComponentModel.Description("Substances which, in contact with water, emit flammable gases.")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.3")] 
		[XmlEnum("13")] 
		ImdgCodeClass4Div43 = 13,

		[System.ComponentModel.Description("Oxidizing substances.")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.1")] 
		[XmlEnum("14")] 
		ImdgCodeClass5Div51 = 14,

		[System.ComponentModel.Description("Organic peroxides.")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.2")] 
		[XmlEnum("15")] 
		ImdgCodeClass5Div52 = 15,

		[System.ComponentModel.Description("Toxic substances.")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.1")] 
		[XmlEnum("16")] 
		ImdgCodeClass6Div61 = 16,

		[System.ComponentModel.Description("Infectious substances.")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.2")] 
		[XmlEnum("17")] 
		ImdgCodeClass6Div62 = 17,

		[System.ComponentModel.Description("Radioactive material.")]
		[EnumMember(Value = "IMDG Code Class 7")] 
		[XmlEnum("18")] 
		ImdgCodeClass7 = 18,

		[System.ComponentModel.Description("Corrosive substances.")]
		[EnumMember(Value = "IMDG Code Class 8")] 
		[XmlEnum("19")] 
		ImdgCodeClass8 = 19,

		[System.ComponentModel.Description("Miscellaneous dangerous substances and articles.")]
		[EnumMember(Value = "IMDG Code Class 9")] 
		[XmlEnum("20")] 
		ImdgCodeClass9 = 20,

		[System.ComponentModel.Description("Harmful substances are those substances which are identified as marine pollutants in the International Maritime Dangerous Goods Code (IMDG Code). Packaged form is defined as the forms of containment specified for harmful substances in the IMDG Code.")]
		[EnumMember(Value = "Harmful Substances in Packaged Form")] 
		[XmlEnum("21")] 
		HarmfulSubstancesInPackagedForm = 21,
	}

	/// <summary>
	/// Classification of the different types of cargo that a ship may be carrying.
	/// </summary>
	/// <remarks>
	/// If item 7 is used, the nature of dangerous or hazardous cargoes can be amplified with category of dangerous or hazardous cargo.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel e.g. oil or grain.")]
		[EnumMember(Value = "Bulk")] 
		[XmlEnum("1")] 
		Bulk = 1,

		[System.ComponentModel.Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
		[EnumMember(Value = "Container")] 
		[XmlEnum("2")] 
		Container = 2,

		[System.ComponentModel.Description("Break bulk cargo normally loaded by crane.")]
		[EnumMember(Value = "General")] 
		[XmlEnum("3")] 
		General = 3,

		[System.ComponentModel.Description("Any cargo loaded by pipeline.")]
		[EnumMember(Value = "Liquid")] 
		[XmlEnum("4")] 
		Liquid = 4,

		[System.ComponentModel.Description("A fee paying traveller.")]
		[EnumMember(Value = "Passenger")] 
		[XmlEnum("5")] 
		Passenger = 5,

		[System.ComponentModel.Description("Live animals carried in bulk.")]
		[EnumMember(Value = "Livestock")] 
		[XmlEnum("6")] 
		Livestock = 6,

		[System.ComponentModel.Description("Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.")]
		[EnumMember(Value = "Dangerous or Hazardous")] 
		[XmlEnum("7")] 
		DangerousOrHazardous = 7,

		[System.ComponentModel.Description("Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.")]
		[EnumMember(Value = "Heavy Lift")] 
		[XmlEnum("8")] 
		HeavyLift = 8,

		[System.ComponentModel.Description("Material carried by a ship to ensure its stability.")]
		[EnumMember(Value = "Ballast")] 
		[XmlEnum("9")] 
		Ballast = 9,
	}

	/// <summary>
	/// Classification of frequencies, VHF channels, telephone numbers, or other means of communication based on preference.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCommunicationPreference : int {
		[System.ComponentModel.Description("The first choice channel or frequency to be used when calling a radio station.")]
		[EnumMember(Value = "Preferred Calling")] 
		[XmlEnum("1")] 
		PreferredCalling = 1,

		[System.ComponentModel.Description("A channel or frequency to be used for calling a radio station when the preferred channel or frequency is busy or is suffering from interference.")]
		[EnumMember(Value = "Alternate Calling")] 
		[XmlEnum("2")] 
		AlternateCalling = 2,

		[System.ComponentModel.Description("The first choice channel or frequency to be used when working with a radio station.")]
		[EnumMember(Value = "Preferred Working")] 
		[XmlEnum("3")] 
		PreferredWorking = 3,

		[System.ComponentModel.Description("A channel or frequency to be used for working with a radio station when the preferred working channel or frequency is busy or is suffering from interference.")]
		[EnumMember(Value = "Alternate Working")] 
		[XmlEnum("4")] 
		AlternateWorking = 4,
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
	}

	/// <summary>
	/// Classification of vessel traffic services based on the nature of the control or services provided.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfVesselTrafficService : int {
		[System.ComponentModel.Description("A service to ensure that essential information becomes available in time for on-board navigational decision-making.")]
		[EnumMember(Value = "Information Service")] 
		[XmlEnum("1")] 
		InformationService = 1,

		[System.ComponentModel.Description("A service to assist on-board navigational decision-making and to monitor its effects.")]
		[EnumMember(Value = "Traffic Organization Service")] 
		[XmlEnum("2")] 
		TrafficOrganizationService = 2,

		[System.ComponentModel.Description("A service to prevent the development of dangerous maritime traffic situations and to provide for the safe and efficient movement of vessel traffic within the VTS area.")]
		[EnumMember(Value = "Navigational Assistance Service")] 
		[XmlEnum("3")] 
		NavigationalAssistanceService = 3,

		[System.ComponentModel.Description("A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.")]
		[EnumMember(Value = "Ship Reporting Service")] 
		[XmlEnum("4")] 
		ShipReportingService = 4,

		[System.ComponentModel.Description("A service established to provide port information without interaction between the customer and the service provider. This information could be inter-alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.")]
		[EnumMember(Value = "Local Port Service")] 
		[XmlEnum("5")] 
		LocalPortService = 5,
	}

	/// <summary>
	/// The condition of an object at a given instant in time.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum status : int {
		[System.ComponentModel.Description("Intended to last or function indefinitely.")]
		[EnumMember(Value = "Permanent")] 
		[XmlEnum("1")] 
		Permanent = 1,

		[System.ComponentModel.Description("Acting on special occasions; happening irregularly.")]
		[EnumMember(Value = "Occasional")] 
		[XmlEnum("2")] 
		Occasional = 2,

		[System.ComponentModel.Description("Presented as worthy of confidence, acceptance, use, etc.")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("3")] 
		Recommended = 3,

		[System.ComponentModel.Description("Use has ceased, but the facility still exists intact; disused.")]
		[EnumMember(Value = "Not in Use")] 
		[XmlEnum("4")] 
		NotInUse = 4,

		[System.ComponentModel.Description("Recurring at intervals.")]
		[EnumMember(Value = "Periodic/Intermittent")] 
		[XmlEnum("5")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("Set apart for some specific use.")]
		[EnumMember(Value = "Reserved")] 
		[XmlEnum("6")] 
		Reserved = 6,

		[System.ComponentModel.Description("Meant to last only for a time.")]
		[EnumMember(Value = "Temporary")] 
		[XmlEnum("7")] 
		Temporary = 7,

		[System.ComponentModel.Description("Administered by an individual or corporation, rather than a State or a public body.")]
		[EnumMember(Value = "Private")] 
		[XmlEnum("8")] 
		Private = 8,

		[System.ComponentModel.Description("Compulsory; enforced.")]
		[EnumMember(Value = "Mandatory")] 
		[XmlEnum("9")] 
		Mandatory = 9,

		[System.ComponentModel.Description("No longer lit.")]
		[EnumMember(Value = "Extinguished")] 
		[XmlEnum("11")] 
		Extinguished = 11,

		[System.ComponentModel.Description("Lit by floodlights, strip lights, etc.")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

		[System.ComponentModel.Description("Famous in history; of historical interest.")]
		[EnumMember(Value = "Historic")] 
		[XmlEnum("13")] 
		Historic = 13,

		[System.ComponentModel.Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("14")] 
		Public = 14,

		[System.ComponentModel.Description("Occur at a time, coincide in point of time, be contemporary or simultaneous.")]
		[EnumMember(Value = "Synchronized")] 
		[XmlEnum("15")] 
		Synchronized = 15,

		[System.ComponentModel.Description("Looked at or observed over a period of time especially so as to be aware of any movement or change.")]
		[EnumMember(Value = "Watched")] 
		[XmlEnum("16")] 
		Watched = 16,

		[System.ComponentModel.Description("Usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
		[EnumMember(Value = "Unwatched")] 
		[XmlEnum("17")] 
		Unwatched = 17,

		[System.ComponentModel.Description("A feature that has been reported but has not been definitely determined to exist.")]
		[EnumMember(Value = "Existence Doubtful")] 
		[XmlEnum("18")] 
		ExistenceDoubtful = 18,

		[System.ComponentModel.Description("When you ask for it.")]
		[EnumMember(Value = "On Request")] 
		[XmlEnum("19")] 
		OnRequest = 19,

		[System.ComponentModel.Description("To become lower in level.")]
		[EnumMember(Value = "Drop Away")] 
		[XmlEnum("20")] 
		DropAway = 20,

		[System.ComponentModel.Description("To become higher in level.")]
		[EnumMember(Value = "Rising")] 
		[XmlEnum("21")] 
		Rising = 21,

		[System.ComponentModel.Description("Becoming larger in magnitude.")]
		[EnumMember(Value = "Increasing")] 
		[XmlEnum("22")] 
		Increasing = 22,

		[System.ComponentModel.Description("Becoming smaller in magnitude.")]
		[EnumMember(Value = "Decreasing")] 
		[XmlEnum("23")] 
		Decreasing = 23,

		[System.ComponentModel.Description("Not easily broken or destroyed.")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("24")] 
		Strong = 24,

		[System.ComponentModel.Description("In a satisfactory condition to use.")]
		[EnumMember(Value = "Good")] 
		[XmlEnum("25")] 
		Good = 25,

		[System.ComponentModel.Description("Fairly but not very.")]
		[EnumMember(Value = "Moderately")] 
		[XmlEnum("26")] 
		Moderately = 26,

		[System.ComponentModel.Description("Not as good as it could be or should.")]
		[EnumMember(Value = "Poor")] 
		[XmlEnum("27")] 
		Poor = 27,

		[System.ComponentModel.Description("Marked by buoys.")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,

		[System.ComponentModel.Description("Entire observation platform is operating in accordance with, or exceeding, manufacturer specifications.")]
		[EnumMember(Value = "Fully Operational")] 
		[XmlEnum("29")] 
		FullyOperational = 29,

		[System.ComponentModel.Description("At least one instrument that is part of an observation platform is not operating to manufacturer specification.")]
		[EnumMember(Value = "Partially Operational")] 
		[XmlEnum("30")] 
		PartiallyOperational = 30,

		[System.ComponentModel.Description("Floating platform at the mercy of environmental elements, whether intentional or not.")]
		[EnumMember(Value = "Drifting")] 
		[XmlEnum("31")] 
		Drifting = 31,

		[System.ComponentModel.Description("Fractured or in pieces.")]
		[EnumMember(Value = "Broken")] 
		[XmlEnum("32")] 
		Broken = 32,

		[System.ComponentModel.Description("Observation platform is intentionally not reporting an environmental observation.")]
		[EnumMember(Value = "Offline")] 
		[XmlEnum("33")] 
		Offline = 33,

		[System.ComponentModel.Description("Observation station, suite of instruments, or an individual instrument, for a particular location, has been removed and is no longer at the particular location.")]
		[EnumMember(Value = "Discontinued")] 
		[XmlEnum("34")] 
		Discontinued = 34,

		[System.ComponentModel.Description("Observations made by a human observer.")]
		[EnumMember(Value = "Manual Observation")] 
		[XmlEnum("35")] 
		ManualObservation = 35,

		[System.ComponentModel.Description("Status of an observation platform, suite of instruments, or individual instrument is not known or unspecified.")]
		[EnumMember(Value = "Unknown Status")] 
		[XmlEnum("36")] 
		UnknownStatus = 36,

		[System.ComponentModel.Description("Made certain as to truth, accuracy, validity, availability, etc.")]
		[EnumMember(Value = "Confirmed")] 
		[XmlEnum("37")] 
		Confirmed = 37,

		[System.ComponentModel.Description("Item selected for an action.")]
		[EnumMember(Value = "Candidate")] 
		[XmlEnum("38")] 
		Candidate = 38,

		[System.ComponentModel.Description("Item that is in the process of being modified.")]
		[EnumMember(Value = "Under Modification")] 
		[XmlEnum("39")] 
		UnderModification = 39,

		[System.ComponentModel.Description("Item in the process of being removed or deleted.")]
		[EnumMember(Value = "Under Removal / Deletion")] 
		[XmlEnum("41")] 
		UnderRemovalDeletion = 41,

		[System.ComponentModel.Description("Item that has been removed or deleted.")]
		[EnumMember(Value = "Removed / Deleted")] 
		[XmlEnum("42")] 
		RemovedDeleted = 42,

		[System.ComponentModel.Description("Item selected for modification.")]
		[EnumMember(Value = "Candidate for Modification")] 
		[XmlEnum("43")] 
		CandidateForModification = 43,
	}

	/// <summary>
	/// The official legal statute of each kind of restricted area.
	/// </summary>
	/// <remarks>
	/// Defines the kind of restriction(s), for example, the restriction for 'a game preserve' may be 'entry prohibited', the restriction for an 'anchoring prohibition' is 'anchoring prohibited'. The complete information about the restriction(s), actually held in handbooks or other publications, may be encoded using an Information type.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum restriction : int {
		[System.ComponentModel.Description("An area within which anchoring is not permitted.")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		[XmlEnum("1")] 
		AnchoringProhibited = 1,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which anchoring is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Anchoring Restricted")] 
		[XmlEnum("2")] 
		AnchoringRestricted = 2,

		[System.ComponentModel.Description("An area within which fishing is not permitted.")]
		[EnumMember(Value = "Fishing Prohibited")] 
		[XmlEnum("3")] 
		FishingProhibited = 3,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which fishing is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Fishing Restricted")] 
		[XmlEnum("4")] 
		FishingRestricted = 4,

		[System.ComponentModel.Description("An area within which trawling is not permitted.")]
		[EnumMember(Value = "Trawling Prohibited")] 
		[XmlEnum("5")] 
		TrawlingProhibited = 5,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which trawling is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Trawling Restricted")] 
		[XmlEnum("6")] 
		TrawlingRestricted = 6,

		[System.ComponentModel.Description("An area within which navigation and/or anchoring is prohibited.")]
		[EnumMember(Value = "Entry Prohibited")] 
		[XmlEnum("7")] 
		EntryProhibited = 7,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Entry Restricted")] 
		[XmlEnum("8")] 
		EntryRestricted = 8,

		[System.ComponentModel.Description("An area within which dredging is not permitted.")]
		[EnumMember(Value = "Dredging Prohibited")] 
		[XmlEnum("9")] 
		DredgingProhibited = 9,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which dredging is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Dredging Restricted")] 
		[XmlEnum("10")] 
		DredgingRestricted = 10,

		[System.ComponentModel.Description("An area within which diving is not permitted.")]
		[EnumMember(Value = "Diving Prohibited")] 
		[XmlEnum("11")] 
		DivingProhibited = 11,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which diving is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Diving Restricted")] 
		[XmlEnum("12")] 
		DivingRestricted = 12,

		[System.ComponentModel.Description("Mariners must adjust the speed of their vessels to reduce the wave or wash which may cause erosion or disturb moored vessels.")]
		[EnumMember(Value = "No Wake")] 
		[XmlEnum("13")] 
		NoWake = 13,

		[System.ComponentModel.Description("An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.")]
		[EnumMember(Value = "Area To Be Avoided")] 
		[XmlEnum("14")] 
		AreaToBeAvoided = 14,

		[System.ComponentModel.Description("The erection of permanent or temporary fixed structures or artificial islands is prohibited.")]
		[EnumMember(Value = "Construction Prohibited")] 
		[XmlEnum("15")] 
		ConstructionProhibited = 15,

		[System.ComponentModel.Description("An area within which discharging or dumping is prohibited.")]
		[EnumMember(Value = "Discharging Prohibited")] 
		[XmlEnum("16")] 
		DischargingProhibited = 16,

		[System.ComponentModel.Description("A specified area designated by an appropriate authority, within which discharging or dumping is restricted in accordance with specified conditions.")]
		[EnumMember(Value = "Discharging Restricted")] 
		[XmlEnum("17")] 
		DischargingRestricted = 17,

		[System.ComponentModel.Description("An area within which industrial or mineral exploration and development are prohibited.")]
		[EnumMember(Value = "Industrial or Mineral Exploration/Development Prohibited")] 
		[XmlEnum("18")] 
		IndustrialOrMineralExplorationDevelopmentProhibited = 18,

		[System.ComponentModel.Description("A specified area designated by an appropriate authority, within which industrial or mineral exploration and development is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Industrial or Mineral Exploration/Development Restricted")] 
		[XmlEnum("19")] 
		IndustrialOrMineralExplorationDevelopmentRestricted = 19,

		[System.ComponentModel.Description("An area within which excavating a hole on the sea-bottom with a drill is prohibited.")]
		[EnumMember(Value = "Drilling Prohibited")] 
		[XmlEnum("20")] 
		DrillingProhibited = 20,

		[System.ComponentModel.Description("A specified area designated by an appropriate authority, within which excavating a hole on the sea-bottom with a drill is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Drilling Restricted")] 
		[XmlEnum("21")] 
		DrillingRestricted = 21,

		[System.ComponentModel.Description("An area within which the removal of historical artefacts is prohibited.")]
		[EnumMember(Value = "Removal of Historical Artefacts Prohibited")] 
		[XmlEnum("22")] 
		RemovalOfHistoricalArtefactsProhibited = 22,

		[System.ComponentModel.Description("An area in which cargo transhipment (lightening) is prohibited.")]
		[EnumMember(Value = "Cargo Transhipment (Lightening) Prohibited")] 
		[XmlEnum("23")] 
		CargoTranshipmentLighteningProhibited = 23,

		[System.ComponentModel.Description("An area in which the dragging of anything along the bottom, e.g. bottom trawling, is prohibited.")]
		[EnumMember(Value = "Dragging Prohibited")] 
		[XmlEnum("24")] 
		DraggingProhibited = 24,

		[System.ComponentModel.Description("An area in which a vessel is prohibited from stopping.")]
		[EnumMember(Value = "Stopping Prohibited")] 
		[XmlEnum("25")] 
		StoppingProhibited = 25,

		[System.ComponentModel.Description("An area in which landing is prohibited.")]
		[EnumMember(Value = "Landing Prohibited")] 
		[XmlEnum("26")] 
		LandingProhibited = 26,

		[System.ComponentModel.Description("An area within which speed is restricted.")]
		[EnumMember(Value = "Speed Restricted")] 
		[XmlEnum("27")] 
		SpeedRestricted = 27,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking is generally prohibited.")]
		[EnumMember(Value = "Overtaking Prohibited")] 
		[XmlEnum("28")] 
		OvertakingProhibited = 28,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which overtaking between convoys is prohibited.")]
		[EnumMember(Value = "Overtaking of Convoys by Convoys Prohibited")] 
		[XmlEnum("29")] 
		OvertakingOfConvoysByConvoysProhibited = 29,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which passing or overtaking is generally prohibited.")]
		[EnumMember(Value = "Passing or Overtaking Prohibited")] 
		[XmlEnum("30")] 
		PassingOrOvertakingProhibited = 30,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not berth.")]
		[EnumMember(Value = "Berthing Prohibited")] 
		[XmlEnum("31")] 
		BerthingProhibited = 31,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which berthing is restricted.")]
		[EnumMember(Value = "Berthing Restricted")] 
		[XmlEnum("32")] 
		BerthingRestricted = 32,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not make fast to the bank.")]
		[EnumMember(Value = "Making Fast Prohibited")] 
		[XmlEnum("33")] 
		MakingFastProhibited = 33,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which making fast to the bank is restricted.")]
		[EnumMember(Value = "Making Fast Restricted")] 
		[XmlEnum("34")] 
		MakingFastRestricted = 34,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which all turning is generally prohibited.")]
		[EnumMember(Value = "Turning Prohibited")] 
		[XmlEnum("35")] 
		TurningProhibited = 35,

		[System.ComponentModel.Description("An area within which the fairway depth is restricted.")]
		[EnumMember(Value = "Restricted Fairway Depth")] 
		[XmlEnum("36")] 
		RestrictedFairwayDepth = 36,

		[System.ComponentModel.Description("An area within which the fairway width is restricted.")]
		[EnumMember(Value = "Restricted Fairway Width")] 
		[XmlEnum("37")] 
		RestrictedFairwayWidth = 37,

		[System.ComponentModel.Description("The use of anchoring spuds (telescopic piles) is prohibited.")]
		[EnumMember(Value = "Use of Spuds Prohibited")] 
		[XmlEnum("38")] 
		UseOfSpudsProhibited = 38,

		[System.ComponentModel.Description("An area in which swimming is prohibited.")]
		[EnumMember(Value = "Swimming Prohibited")] 
		[XmlEnum("39")] 
		SwimmingProhibited = 39,

		[System.ComponentModel.Description("An area within which the emission of SOx is restricted.")]
		[EnumMember(Value = "SOx Emission Restricted")] 
		[XmlEnum("40")] 
		SoxEmissionRestricted = 40,

		[System.ComponentModel.Description("An area within which the emission of NOx is restricted.")]
		[EnumMember(Value = "NOx Emission Restricted")] 
		[XmlEnum("41")] 
		NoxEmissionRestricted = 41,
	}

	/// <summary>
	/// The jurisdiction applicable to an administrative area.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum jurisdiction : int {
		[System.ComponentModel.Description("Involving more than one country; covering more than one national area.")]
		[EnumMember(Value = "International")] 
		[XmlEnum("1")] 
		International = 1,

		[System.ComponentModel.Description("An area administered or controlled by a single nation.")]
		[EnumMember(Value = "National")] 
		[XmlEnum("2")] 
		National = 2,

		[System.ComponentModel.Description("An area smaller than the nation in which it lies.")]
		[EnumMember(Value = "National Sub-Division")] 
		[XmlEnum("3")] 
		NationalSubDivision = 3,
	}

	/// <summary>
	/// The official legal status of each kind of restricted area defines the kind of restriction(s), for example the restriction for a 'game reserve' may be 'entering prohibited'.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRestrictedArea : int {
		[System.ComponentModel.Description("The area around an offshore installation within which vessels are prohibited from entering without permission. Special regulations protect installations within a safety zone and vessels of all nationalities are required to respect the zone.")]
		[EnumMember(Value = "Offshore Safety Zone")] 
		[XmlEnum("1")] 
		OffshoreSafetyZone = 1,

		[System.ComponentModel.Description("A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.")]
		[EnumMember(Value = "Nature Reserve")] 
		[XmlEnum("4")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("A place where birds are bred and protected.")]
		[EnumMember(Value = "Bird Sanctuary")] 
		[XmlEnum("5")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.")]
		[EnumMember(Value = "Game Reserve")] 
		[XmlEnum("6")] 
		GameReserve = 6,

		[System.ComponentModel.Description("A place where seals are protected.")]
		[EnumMember(Value = "Seal Sanctuary")] 
		[XmlEnum("7")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the sea bed in the range and there are cables leading from the range to a control position ashore.")]
		[EnumMember(Value = "Degaussing Range")] 
		[XmlEnum("8")] 
		DegaussingRange = 8,

		[System.ComponentModel.Description("An area controlled by the military in which restrictions may apply.")]
		[EnumMember(Value = "Military Area")] 
		[XmlEnum("9")] 
		MilitaryArea = 9,

		[System.ComponentModel.Description("An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).")]
		[EnumMember(Value = "Historic Wreck Area")] 
		[XmlEnum("10")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("An area around a navigational aid which vessels are prohibited from entering.")]
		[EnumMember(Value = "Navigational Aid Safety Zone")] 
		[XmlEnum("12")] 
		NavigationalAidSafetyZone = 12,

		[System.ComponentModel.Description("An area laid and maintained with explosive mines for defence or practice purposes.")]
		[EnumMember(Value = "Minefield")] 
		[XmlEnum("14")] 
		Minefield = 14,

		[System.ComponentModel.Description("An area in which people may swim and therefore vessel movement may be restricted.")]
		[EnumMember(Value = "Swimming Area")] 
		[XmlEnum("18")] 
		SwimmingArea = 18,

		[System.ComponentModel.Description("An area reserved for vessels waiting to enter a harbour.")]
		[EnumMember(Value = "Waiting Area")] 
		[XmlEnum("19")] 
		WaitingArea = 19,

		[System.ComponentModel.Description("An area where marine research takes place.")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("An area where dredging is taking place.")]
		[EnumMember(Value = "Dredging Area")] 
		[XmlEnum("21")] 
		DredgingArea = 21,

		[System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("A tract of land managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("An area in which a vessels' speed must be reduced in order to reduce the size of the wake it produces.")]
		[EnumMember(Value = "No Wake Area")] 
		[XmlEnum("24")] 
		NoWakeArea = 24,

		[System.ComponentModel.Description("An area where vessels turn.")]
		[EnumMember(Value = "Swinging Area")] 
		[XmlEnum("25")] 
		SwingingArea = 25,

		[System.ComponentModel.Description("An area within which people may water ski and therefore vessel movement may be restricted.")]
		[EnumMember(Value = "Water Skiing Area")] 
		[XmlEnum("26")] 
		WaterSkiingArea = 26,

		[System.ComponentModel.Description("A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area")] 
		[XmlEnum("27")] 
		EnvironmentallySensitiveSeaArea = 27,

		[System.ComponentModel.Description("An area that needs special protection through action by IMO because of its significance for regional ecological, socio-economic or scientific reasons and because it may be vulnerable to damage by international shipping activities.")]
		[EnumMember(Value = "Particularly Sensitive Sea Area")] 
		[XmlEnum("28")] 
		ParticularlySensitiveSeaArea = 28,

		[System.ComponentModel.Description("An area near a fairway where vessels can go to clear the way or make an about turn and possibly return to a waiting area when nautical conditions impose it.")]
		[EnumMember(Value = "Disengagement Area")] 
		[XmlEnum("29")] 
		DisengagementArea = 29,

		[System.ComponentModel.Description("An area in which defence, law and treaty enforcement, and counter-terrorism activities that fall within the port and maritime domain apply.")]
		[EnumMember(Value = "Port Security Area")] 
		[XmlEnum("30")] 
		PortSecurityArea = 30,

		[System.ComponentModel.Description("A place where coral is protected.")]
		[EnumMember(Value = "Coral Sanctuary")] 
		[XmlEnum("31")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("An area within which recreational activities regularly take place and therefore vessel movement may be restricted.")]
		[EnumMember(Value = "Recreation Area")] 
		[XmlEnum("32")] 
		RecreationArea = 32,

		[System.ComponentModel.Description("An area within which the ship pollution emission is controlled.")]
		[EnumMember(Value = "Ship Pollution Emission Control")] 
		[XmlEnum("33")] 
		ShipPollutionEmissionControl = 33,
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
	}

	/// <summary>
	/// Classification of completeness of textual information in relation to the source material from which it is derived.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfText : int {
		[System.ComponentModel.Description("A statement summarizing the important points of a text.")]
		[EnumMember(Value = "Abstract or Summary")] 
		[XmlEnum("1")] 
		AbstractOrSummary = 1,

		[System.ComponentModel.Description("An excerpt or excerpts from a text.")]
		[EnumMember(Value = "Extract")] 
		[XmlEnum("2")] 
		Extract = 2,

		[System.ComponentModel.Description("The whole text.")]
		[EnumMember(Value = "Full Text")] 
		[XmlEnum("3")] 
		FullText = 3,
	}

	/// <summary>
	/// The locality of vessel registration or enrolment relative to the nationality of a port, territorial sea, administrative area, exclusive zone or other location.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfVesselRegistry : int {
		[System.ComponentModel.Description("The vessel is registered or enrolled under the same national flag as the port, harbour, territorial sea, exclusive economic zone, or administrative area in which the object that possesses this attribute applies or is located.")]
		[EnumMember(Value = "Domestic")] 
		[XmlEnum("1")] 
		Domestic = 1,

		[System.ComponentModel.Description("The vessel is registered or enrolled under a national flag different from the port, harbour, territorial sea, exclusive economic zone, or other administrative area in which the object that possesses this attribute applies or is located.")]
		[EnumMember(Value = "Foreign")] 
		[XmlEnum("2")] 
		Foreign = 2,
	}

	/// <summary>
	/// Expresses whether all the constraints described by its co-attributes must be satisfied, or only one such constraint need be satisfied.
	/// </summary>
	/// <remarks>
	/// Is intended to be used with co-attributes that encode limits on vessel dimensions, type of cargo, and other characteristics. The combination of constraints described by logicalConnectives and its co-attributes defines a subset of vessels to which information described by a feature or information type instance applies (or does not apply, is required, recommended, etc.). The relationship between the vessel subset and the information is indicated by an association - see PermissionType and InclusionType). The two listed values of logicalConnective are two of the basic operations of Boolean logic. The third basic operation (not) is not used.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum logicalConnectives : int {
		[System.ComponentModel.Description("All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.")]
		[EnumMember(Value = "Logical Conjunction")] 
		[XmlEnum("1")] 
		LogicalConjunction = 1,

		[System.ComponentModel.Description("At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.")]
		[EnumMember(Value = "Logical Disjunction")] 
		[XmlEnum("2")] 
		LogicalDisjunction = 2,
	}

	/// <summary>
	/// -
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Serializable()]
	public class categoryOfMarineProtectedArea
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	[System.Serializable()]
	public class categoryOfVessel
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// The action or activity of a vessel.
	/// </summary>
	[System.Serializable()]
	public class actionOrActivity
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// The principal subject matter of regulations, restrictions, recommendations or nautical information.
	/// </summary>
	[System.Serializable()]
	public class categoryOfRxN
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
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

	namespace ComplexAttributes {
		/// <summary>
		/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress {
			[XmlElement("deliveryPoint")]
			public String? deliveryPoint {get;set;} = default;

			public bool ShouldSerializedeliveryPoint() { return !string.IsNullOrEmpty(deliveryPoint); }

			[XmlElement("cityName")]
			public String? cityName {get;set;} = default;

			public bool ShouldSerializecityName() { return !string.IsNullOrEmpty(cityName); }

			[XmlElement("administrativeDivision")]
			public String? administrativeDivision {get;set;} = default;

			public bool ShouldSerializeadministrativeDivision() { return !string.IsNullOrEmpty(administrativeDivision); }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlElement("postalCode")]
			public String? postalCode {get;set;} = default;

			public bool ShouldSerializepostalCode() { return !string.IsNullOrEmpty(postalCode); }
		}

		/// <summary>
		/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[XmlElement("displayName")]
			public Boolean? displayName {get;set;} = default;

			public bool ShouldSerializedisplayName() { return displayName.HasValue; }

			[XmlElement("language")]
			public String language {get;set;} = string.Empty;

			[XmlElement("name")]
			public String name {get;set;} = string.Empty;
		}

		/// <summary>
		/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
		/// </summary>
		/// <remarks>
		/// Dates must be encoded in the format YYYYMMDD; using 4 digits for the calendar year (YYYY) and, optionally, 2 digits for the month (MM) (for example April = 04) and 2 digits for the day (DD). When no specific month and/or day is required/known, the values are replaced with dashes (-). The date range of a recurring event or occurrence must be encoded using periodicDateRange.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class fixedDateRange {
			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			[XmlElement("dateEnd")]
			public String? dateEnd {get;set;} = default;

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }
		}

		/// <summary>
		/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			[XmlElement("frequencyShoreStationReceives")]
			public int? frequencyShoreStationReceives {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }

			[XmlElement("frequencyShoreStationTransmits")]
			public int? frequencyShoreStationTransmits {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationTransmits() { return frequencyShoreStationTransmits.HasValue; }
		}

		/// <summary>
		/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
		/// </summary>
		/// <remarks>
		/// At least one of the sub-attributes file reference or text must be populated.The sub-attribute file reference is generally used for long text strings or those that require formatting, however, there is no restriction on the type of text (except for lexical level) that can be held in files referenced by sub-attribute file reference.
		/// </remarks>
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
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }
		}

		/// <summary>
		/// Information about online sources from which a resource or data can be obtained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("onlineResourceLinkageURL")]
			public String onlineResourceLinkageURL {get;set;} = string.Empty;

			[XmlElement("protocol")]
			public String? protocol {get;set;} = default;

			public bool ShouldSerializeprotocol() { return !string.IsNullOrEmpty(protocol); }

			[XmlElement("applicationProfile")]
			public String? applicationProfile {get;set;} = default;

			public bool ShouldSerializeapplicationProfile() { return !string.IsNullOrEmpty(applicationProfile); }

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }

			[XmlElement("onlineResourceDescription")]
			public String? onlineResourceDescription {get;set;} = default;

			public bool ShouldSerializeonlineResourceDescription() { return !string.IsNullOrEmpty(onlineResourceDescription); }

			[XmlElement("protocolRequest")]
			public String? protocolRequest {get;set;} = default;

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }

			[XmlIgnore]
			public onlineFunction? onlineFunction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("onlineFunction")]
			public SerializableEnumeration<onlineFunction>? onlineFunctionElement { get { return onlineFunction; } set { } }

			public bool ShouldSerializeonlineFunction() { return onlineFunction.HasValue; }
		}

		/// <summary>
		/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation {
			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("orientationValue")]
			public decimal orientationValue {get;set;} = default;
		}

		/// <summary>
		/// The active period of a recurring event or occurrence.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[XmlElement("dateStart")]
			public String dateStart {get;set;} = string.Empty;

			[XmlElement("dateEnd")]
			public String dateEnd {get;set;} = string.Empty;
		}

		/// <summary>
		/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rxNCode {
			[XmlElement("categoryOfRxN")]
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			public bool ShouldSerializecategoryOfRxN() { return categoryOfRxN != default; }

			[XmlElement("actionOrActivity")]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			public bool ShouldSerializeactionOrActivity() { return actionOrActivity != default; }

			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne {
			[XmlElement("sectorBearing")]
			public decimal sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public int? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo {
			[XmlElement("sectorBearing")]
			public decimal sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public int? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
		}

		/// <summary>
		/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
		/// </summary>
		/// <remarks>
		/// Exactly one of sub-attributes onlineResource or information must be completed in one instance of textContent. Product specifications may restrict the use or content of onlineResource for security. For example, a product specification may forbid populating onlineResource. Product specification authors must consider whether applications using the data product may be prevented from accessing off-system resources by security policies.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textContent {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfText? categoryOfText {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfText")]
			public SerializableEnumeration<categoryOfText>? categoryOfTextElement { get { return categoryOfText; } set { } }

			public bool ShouldSerializecategoryOfText() { return categoryOfText.HasValue; }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sourceType")]
			public SerializableEnumeration<sourceType>? sourceTypeElement { get { return sourceType; } set { } }

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		/// <summary>
		/// The regular weekly operation times of a service or schedule.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalsByDayOfWeek {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public List<dayOfWeek> dayOfWeek {get;set;} = [];

			[JsonIgnore]
			[XmlElement("dayOfWeek")]
			public SerializableEnumeration<dayOfWeek>[] dayOfWeekElement { get { return [.. dayOfWeek]; } set { } }

			public bool ShouldSerializedayOfWeek() { return dayOfWeek.Any(); }

			[XmlElement("dayOfWeekIsRange")]
			public Boolean? dayOfWeekIsRange {get;set;} = default;

			public bool ShouldSerializedayOfWeekIsRange() { return dayOfWeekIsRange.HasValue; }

			[XmlElement("timeOfDayEnd")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayEnd {get;set;} = [];

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.Any(); }

			[XmlElement("timeOfDayStart")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayStart {get;set;} = [];

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.Any(); }
		}

		/// <summary>
		/// Values, discovered by measuring, that correspond to vessels characteristics.
		/// </summary>
		/// <remarks>
		/// VSLVAL has been set to REAL assuming 3 decimal places, i.e.: 10.000 m. That would give the result: 1. VSLMSM [VSLCAR=4 (draught); VSLVAL=10.5; VSLUNT=1 (m); COMPOP=2 (>=) ] the regulation applies for vsl of 10.5 m draught and above. 2. VSLMSM [VSLCAR=9 (deadweight); VSLVAL=2000; VSLUNT=4 (ton); COMPOP=5 (=) ] the regulation applies for vsl of exactly 2000 DWT. 3. VSLMSM [VSLCAR=1 (L.O.A.); VSLVAL=150; VSLUNT=1 (m); COMPOP=3 (<)] the regulation applies for vsl of less than 150 m length. Using a further example: 4. [VSLMSM [VSLCAR=1 (L.O.A.); VSLVAL=50; VSLUNT=1 (m); COMPOP=1 (>)]], CATVSL=3 (tanker), LOGCON=1 (and), LIMTYP=2 (required); associated to a PILBOP object: tankers with LOA > 50.0 m must use the PILBOP. In an example for tankers between 50 and 100 m in length, the coding is like this: 5. [VSLMSM [VSLCAR=1 (L.O.A.); VSLVAL=50; VSLUNT=1 (m); COMPOP=1 (>)], [VSLCAR=1 (L.O.A.); VSLVAL=100; VSLUNT=1 (m); COMPOP=3 (<)]], CATVSL=3 (tanker), LOGCON=1 (and), LIMTYP=2 (required).
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselsMeasurements {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9,10,11,12,13])]
			public vesselsCharacteristics vesselsCharacteristics {get;set;}

			[JsonIgnore]
			[XmlElement("vesselsCharacteristics")]
			public SerializableEnumeration<vesselsCharacteristics> vesselsCharacteristicsElement { get { return vesselsCharacteristics; } set { } }

			[XmlElement("vesselsCharacteristicsValue")]
			public decimal vesselsCharacteristicsValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([3,4,5,6,7,9])]
			public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;}

			[JsonIgnore]
			[XmlElement("vesselsCharacteristicsUnit")]
			public SerializableEnumeration<vesselsCharacteristicsUnit> vesselsCharacteristicsUnitElement { get { return vesselsCharacteristicsUnit; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public comparisonOperator comparisonOperator {get;set;}

			[JsonIgnore]
			[XmlElement("comparisonOperator")]
			public SerializableEnumeration<comparisonOperator> comparisonOperatorElement { get { return comparisonOperator; } set { } }
		}

		/// <summary>
		/// An official name, title or description. This can be an identifier itself, or an identifier which is an instance of a named designation scheme.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class designation {
			[XmlElement("designationScheme")]
			public String? designationScheme {get;set;} = default;

			public bool ShouldSerializedesignationScheme() { return !string.IsNullOrEmpty(designationScheme); }

			[XmlElement("designationIdentifier")]
			public String? designationIdentifier {get;set;} = default;

			public bool ShouldSerializedesignationIdentifier() { return !string.IsNullOrEmpty(designationIdentifier); }

			[XmlIgnore]
			public jurisdiction? jurisdiction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("jurisdiction")]
			public SerializableEnumeration<jurisdiction>? jurisdictionElement { get { return jurisdiction; } set { } }

			public bool ShouldSerializejurisdiction() { return jurisdiction.HasValue; }

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }
		}

		/// <summary>
		/// A bearing is the direction one object is from another object.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation {
			[XmlIgnore]
			public cardinalDirection? cardinalDirection {get;set;} = default;

			[JsonIgnore]
			[XmlElement("cardinalDirection")]
			public SerializableEnumeration<cardinalDirection>? cardinalDirectionElement { get { return cardinalDirection; } set { } }

			public bool ShouldSerializecardinalDirection() { return cardinalDirection.HasValue; }

			[XmlElement("distance")]
			public decimal? distance {get;set;} = default;

			public bool ShouldSerializedistance() { return distance.HasValue; }

			[XmlElement("sectorBearing")]
			public List<decimal> sectorBearing {get;set;} = [];

			public bool ShouldSerializesectorBearing() { return sectorBearing.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("orientation")]
			public orientation? orientation {get;set;} = default;

			public bool ShouldSerializeorientation() { return orientation!=default; }
		}

		/// <summary>
		/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class graphic {
			[XmlElement("pictorialRepresentation")]
			public List<String> pictorialRepresentation {get;set;} = [];

			public bool ShouldSerializepictorialRepresentation() { return pictorialRepresentation.Any(); }

			[XmlElement("pictureCaption")]
			public String? pictureCaption {get;set;} = default;

			public bool ShouldSerializepictureCaption() { return !string.IsNullOrEmpty(pictureCaption); }

			[XmlIgnore]
			public DateOnly? sourceDate {get;set;} = default;

			public bool ShouldSerializesourceDate() { return sourceDate.HasValue; }

			[XmlElement("pictureInformation")]
			public String? pictureInformation {get;set;} = default;

			public bool ShouldSerializepictureInformation() { return !string.IsNullOrEmpty(pictureInformation); }

			[XmlElement("bearingInformation")]
			public bearingInformation? bearingInformation {get;set;} = default;

			public bool ShouldSerializebearingInformation() { return bearingInformation!=default; }
		}

		/// <summary>
		/// The nature and timings of a daily schedule by days of the week.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class scheduleByDayOfWeek {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfSchedule? categoryOfSchedule {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfSchedule")]
			public SerializableEnumeration<categoryOfSchedule>? categoryOfScheduleElement { get { return categoryOfSchedule; } set { } }

			public bool ShouldSerializecategoryOfSchedule() { return categoryOfSchedule.HasValue; }

			[XmlElement("timeIntervalsByDayOfWeek")]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimit {
			[XmlElement("sectorLimitOne")]
			public sectorLimitOne sectorLimitOne {get;set;} = new sectorLimitOne {
				sectorBearing = default,
			};

			[XmlElement("sectorLimitTwo")]
			public sectorLimitTwo sectorLimitTwo {get;set;} = new sectorLimitTwo {
				sectorBearing = default,
			};
		}

		/// <summary>
		/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
		/// </summary>
		/// <remarks>
		/// If no value is populated for the sub-attribute telecommunication service, this means the service is by voice communication. If no value is populated for the sub-attribute telecommunication carrier, this means the service is by land line communication.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("telecomCarrier")]
			public String? telecomCarrier {get;set;} = default;

			public bool ShouldSerializetelecomCarrier() { return !string.IsNullOrEmpty(telecomCarrier); }

			[XmlElement("telecommunicationIdentifier")]
			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public telecommunicationService? telecommunicationService {get;set;} = default;

			[JsonIgnore]
			[XmlElement("telecommunicationService")]
			public SerializableEnumeration<telecommunicationService>? telecommunicationServiceElement { get { return telecommunicationService; } set { } }

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.HasValue; }

			[XmlElement("scheduleByDayOfWeek")]
			public scheduleByDayOfWeek? scheduleByDayOfWeek {get;set;} = default;

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek!=default; }
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

	namespace InformationAssociations {
		/// <summary>
		/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AssociatedRxN : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AssociatedRxN);
		}

		/// <summary>
		/// Exception to the usual working day
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ExceptionalWorkday : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ExceptionalWorkday);
		}

		/// <summary>
		/// There may be more than one such authority depending on how responsibilities are divided
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProtectedAreaAuthority : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ProtectedAreaAuthority);
		}

		/// <summary>
		/// The controlling authority for a service area
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceControl : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceControl);
		}

		/// <summary>
		/// Related organisation
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RelatedOrganisation : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RelatedOrganisation);
		}

		/// <summary>
		/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PermissionType : InformationAssociation {
			[XmlIgnore]
			public categoryOfRelationship categoryOfRelationship {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfRelationship")]
			public SerializableEnumeration<categoryOfRelationship> categoryOfRelationshipElement { get { return categoryOfRelationship; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PermissionType);
		}

		/// <summary>
		/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InclusionType : InformationAssociation {
			[XmlIgnore]
			public membership membership {get;set;}

			[JsonIgnore]
			[XmlElement("membership")]
			public SerializableEnumeration<membership> membershipElement { get { return membership; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InclusionType);
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityContact : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AuthorityContact);
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityHours : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AuthorityHours);
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class additionalInformation : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(additionalInformation);
		}
	}

}

namespace S100Framework.DomainModel.S122 {
	using ComplexAttributes;
	using InformationAssociations;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// Generalized information type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InformationType : InformationNode, IInformationBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("graphic")]
			public List<graphic> graphic {get;set;} = [];

			public bool ShouldSerializegraphic() { return graphic.Any(); }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sourceType")]
			public SerializableEnumeration<sourceType>? sourceTypeElement { get { return sourceType; } set { } }

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InformationType);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationType._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AbstractRxN : InformationType {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

			[XmlElement("rxNCode")]
			public List<rxNCode> rxNCode {get;set;} = [];

			public bool ShouldSerializerxNCode() { return rxNCode.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AbstractRxN);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..AbstractRxN._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theOrganisation)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Nautical information about a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NauticalInformation : AbstractRxN {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NauticalInformation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..NauticalInformation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theOrganisation)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Regulations for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Regulations : AbstractRxN {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Regulations);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..Regulations._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Restrictions for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Restrictions : AbstractRxN {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Restrictions);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..Restrictions._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Recommendations for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Recommendations : AbstractRxN {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Recommendations);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..Recommendations._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A person or organisation having political or administrative power and control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Authority : InformationType {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public categoryOfAuthority categoryOfAuthority {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority> categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Authority);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..Authority._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(AbstractRxN)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
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
		public partial class ContactDetails : AbstractRxN {
			[XmlElement("callName")]
			public String? callName {get;set;} = default;

			public bool ShouldSerializecallName() { return !string.IsNullOrEmpty(callName); }

			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("signalFrequency")]
			public List<int> signalFrequency {get;set;} = [];

			public bool ShouldSerializesignalFrequency() { return signalFrequency.Any(); }

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..ContactDetails._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NonStandardWorkingDay : InformationType {
			[XmlElement("dateFixed")]
			public List<String> dateFixed {get;set;} = [];

			public bool ShouldSerializedateFixed() { return dateFixed.Any(); }

			[XmlElement("dateVariable")]
			public List<String> dateVariable {get;set;} = [];

			public bool ShouldSerializedateVariable() { return dateVariable.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NonStandardWorkingDay);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..NonStandardWorkingDay._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ExceptionalWorkday),
					role = Enum.GetName<Role>(Role.theServiceHours_nsdy)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// The time when a service is available and known exceptions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceHours : InformationType {
			[XmlElement("scheduleByDayOfWeek")]
			public List<scheduleByDayOfWeek> scheduleByDayOfWeek {get;set;} = [];

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek.Any(); }

			[XmlElement("information")]
			public information information {get;set;} = new information {
			};

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceHours);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ServiceHours._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theAuthority_srvHrs)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ExceptionalWorkday),
					role = Enum.GetName<Role>(Role.partialWorkingDay)!,
					informationTypes = [nameof(NonStandardWorkingDay)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Applicability : InformationType {
			[XmlElement("inBallast")]
			public Boolean? inBallast {get;set;} = default;

			public bool ShouldSerializeinBallast() { return inBallast.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21])]
			public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfDangerousOrHazardousCargo")]
			public SerializableEnumeration<categoryOfDangerousOrHazardousCargo>[] categoryOfDangerousOrHazardousCargoElement { get { return [.. categoryOfDangerousOrHazardousCargo]; } set { } }

			public bool ShouldSerializecategoryOfDangerousOrHazardousCargo() { return categoryOfDangerousOrHazardousCargo.Any(); }

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public categoryOfVessel? categoryOfVessel {get;set;} = default;

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel != default; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfVesselRegistry? categoryOfVesselRegistry {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfVesselRegistry")]
			public SerializableEnumeration<categoryOfVesselRegistry>? categoryOfVesselRegistryElement { get { return categoryOfVesselRegistry; } set { } }

			public bool ShouldSerializecategoryOfVesselRegistry() { return categoryOfVesselRegistry.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public logicalConnectives? logicalConnectives {get;set;} = default;

			[JsonIgnore]
			[XmlElement("logicalConnectives")]
			public SerializableEnumeration<logicalConnectives>? logicalConnectivesElement { get { return logicalConnectives; } set { } }

			public bool ShouldSerializelogicalConnectives() { return logicalConnectives.HasValue; }

			[XmlElement("thicknessOfIceCapability")]
			public int? thicknessOfIceCapability {get;set;} = default;

			public bool ShouldSerializethicknessOfIceCapability() { return thicknessOfIceCapability.HasValue; }

			[XmlElement("vesselPerformance")]
			public String? vesselPerformance {get;set;} = default;

			public bool ShouldSerializevesselPerformance() { return !string.IsNullOrEmpty(vesselPerformance); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("vesselsMeasurements")]
			public List<vesselsMeasurements> vesselsMeasurements {get;set;} = [];

			public bool ShouldSerializevesselsMeasurements() { return vesselsMeasurements.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Applicability);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..Applicability._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}
	}
	namespace FeatureTypes {
		using InformationTypes;
		using System.Xml;
		using System.Xml.Linq;

		/// <summary>
		/// Generalized feature type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FeatureType : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String interoperabilityIdentifier {get;set;} = string.Empty;

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sourceType")]
			public SerializableEnumeration<sourceType>? sourceTypeElement { get { return sourceType; } set { } }

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FeatureType);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FeatureType._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AssociatedRxN),
					role = Enum.GetName<Role>(Role.theRxN)!,
					informationTypes = [nameof(AbstractRxN)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(additionalInformation),
					role = Enum.GetName<Role>(Role.providesInformation)!,
					informationTypes = [nameof(NauticalInformation)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureType._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FeatureType._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RestrictedArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RestrictedArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RestrictedArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RestrictedArea._primitives];
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
		/// Any area of the intertidal or sub-tidal terrain, together with its overlying water and associated flora, fauna, historical and cultural features, which has been reserved by law or other effective means to protect part or all of the enclosed environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MarineProtectedArea : FeatureType {
			[XmlElement("categoryOfMarineProtectedArea")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public categoryOfMarineProtectedArea categoryOfMarineProtectedArea {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public jurisdiction jurisdiction {get;set;}

			[JsonIgnore]
			[XmlElement("jurisdiction")]
			public SerializableEnumeration<jurisdiction> jurisdictionElement { get { return jurisdiction; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("designation")]
			public List<designation> designation {get;set;} = [];

			public bool ShouldSerializedesignation() { return designation.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MarineProtectedArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..MarineProtectedArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProtectedAreaAuthority),
					role = Enum.GetName<Role>(Role.responsibleAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..MarineProtectedArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..MarineProtectedArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
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
		/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VesselTrafficServiceArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			public categoryOfVesselTrafficService categoryOfVesselTrafficService {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfVesselTrafficService")]
			public SerializableEnumeration<categoryOfVesselTrafficService> categoryOfVesselTrafficServiceElement { get { return categoryOfVesselTrafficService; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(VesselTrafficServiceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..VesselTrafficServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceControl),
					role = Enum.GetName<Role>(Role.controlAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..VesselTrafficServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..VesselTrafficServiceArea._primitives];
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
		/// A geographical area that describes the coverage and extent of spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DataCoverage);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DataCoverage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TextPlacement);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TextPlacement._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S122/1.2")]
	[XmlRoot(Namespace = "http://www.iho.int/S122/1.2")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S122/1.2 122_1.2.1.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S122/1.2", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.InformationType", typeof(InformationTypes.InformationType), Order = 1, ElementName = "InformationType")]
		[XmlElement("InformationTypes.AbstractRxN", typeof(InformationTypes.AbstractRxN), Order = 1, ElementName = "AbstractRxN")]
		[XmlElement("InformationTypes.NauticalInformation", typeof(InformationTypes.NauticalInformation), Order = 1, ElementName = "NauticalInformation")]
		[XmlElement("InformationTypes.Regulations", typeof(InformationTypes.Regulations), Order = 1, ElementName = "Regulations")]
		[XmlElement("InformationTypes.Restrictions", typeof(InformationTypes.Restrictions), Order = 1, ElementName = "Restrictions")]
		[XmlElement("InformationTypes.Recommendations", typeof(InformationTypes.Recommendations), Order = 1, ElementName = "Recommendations")]
		[XmlElement("InformationTypes.Authority", typeof(InformationTypes.Authority), Order = 1, ElementName = "Authority")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.NonStandardWorkingDay", typeof(InformationTypes.NonStandardWorkingDay), Order = 1, ElementName = "NonStandardWorkingDay")]
		[XmlElement("InformationTypes.ServiceHours", typeof(InformationTypes.ServiceHours), Order = 1, ElementName = "ServiceHours")]
		[XmlElement("InformationTypes.Applicability", typeof(InformationTypes.Applicability), Order = 1, ElementName = "Applicability")]
		[XmlElement("FeatureTypes.RestrictedArea", typeof(FeatureTypes.RestrictedArea), Order = 1, ElementName = "RestrictedArea")]
		[XmlElement("FeatureTypes.MarineProtectedArea", typeof(FeatureTypes.MarineProtectedArea), Order = 1, ElementName = "MarineProtectedArea")]
		[XmlElement("FeatureTypes.VesselTrafficServiceArea", typeof(FeatureTypes.VesselTrafficServiceArea), Order = 1, ElementName = "VesselTrafficServiceArea")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
