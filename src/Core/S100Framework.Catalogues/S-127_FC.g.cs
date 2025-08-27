using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S127 {
	public class Summary : ISummary
	{
		public static string Name => "Feature Catalogue for S-127";
		public static string Scope => "Global coverage of maritime areas";
		public static string ProductId => "S-127";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2022-12-30", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["bearingInformation","contactAddress","featureName","fixedDateRange","frequencyPair","graphic","horizontalPositionUncertainty","information","noticeTime","onlineResource","orientation","scheduleByDayOfWeek","periodicDateRange","radiocommunications","rxNCode","sourceIndication","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","underKeelAllowance","vesselsMeasurements"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","InclusionType","PermissionType","RelatedOrganisation","ReportingAuthority","ReportingRequirement","ServiceContact","ServiceControl","SpatialAssociation","LocationHours","TrafficServiceReport"];
		public static string[] FeatureAssociationTypes => ["ServiceProvisionArea","PilotageDistrictAssociation","TextAssociation","TrafficControlServiceAggregation"];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","Applicability","Authority","ContactDetails","NauticalInformation","NonStandardWorkingDay","ServiceHours","ShipReport","Recommendations","Regulations","Restrictions","SpatialQuality","SpatialQualityPoints"];
		public static string[] FeatureTypes => ["CautionArea","ConcentrationOfShippingHazardArea","ISPSCodeSecurityLevel","LocalPortServiceArea","MilitaryPracticeArea","PilotBoardingPlace","PilotService","PilotageDistrict","PiracyRiskArea","PlaceOfRefuge","RadarRange","RadioCallingInPoint","RestrictedAreaNavigational","RestrictedAreaRegulatory","RouteingMeasure","ShipReportingServiceArea","SignalStationWarning","SignalStationTraffic","UnderKeelClearanceAllowanceArea","UnderKeelClearanceManagementArea","VesselTrafficServiceArea","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType","OrganizationContactArea","SupervisedArea","ReportableServiceArea"],
			Primitives.point => ["CautionArea","MilitaryPracticeArea","PilotBoardingPlace","PiracyRiskArea","PlaceOfRefuge","RadioCallingInPoint","SignalStationWarning","SignalStationTraffic","TextPlacement"],
			Primitives.surface => ["CautionArea","ConcentrationOfShippingHazardArea","ISPSCodeSecurityLevel","LocalPortServiceArea","MilitaryPracticeArea","PilotBoardingPlace","PilotService","PilotageDistrict","PiracyRiskArea","PlaceOfRefuge","RadarRange","RestrictedAreaNavigational","RestrictedAreaRegulatory","RouteingMeasure","ShipReportingServiceArea","SignalStationWarning","SignalStationTraffic","UnderKeelClearanceAllowanceArea","UnderKeelClearanceManagementArea","VesselTrafficServiceArea","WaterwayArea","DataQuality","QualityOfTemporalVariation","DataCoverage","QualityOfNonBathymetricData"],
			Primitives.curve => ["ISPSCodeSecurityLevel","RadioCallingInPoint","RouteingMeasure"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [Primitives.noGeometry],
			"OrganizationContactArea" => [Primitives.noGeometry],
			"SupervisedArea" => [Primitives.noGeometry],
			"ReportableServiceArea" => [Primitives.noGeometry],
			"CautionArea" => [Primitives.point,Primitives.surface],
			"ConcentrationOfShippingHazardArea" => [Primitives.surface],
			"ISPSCodeSecurityLevel" => [Primitives.curve,Primitives.surface],
			"LocalPortServiceArea" => [Primitives.surface],
			"MilitaryPracticeArea" => [Primitives.point,Primitives.surface],
			"PilotBoardingPlace" => [Primitives.point,Primitives.surface],
			"PilotService" => [Primitives.surface],
			"PilotageDistrict" => [Primitives.surface],
			"PiracyRiskArea" => [Primitives.point,Primitives.surface],
			"PlaceOfRefuge" => [Primitives.point,Primitives.surface],
			"RadarRange" => [Primitives.surface],
			"RadioCallingInPoint" => [Primitives.point,Primitives.curve],
			"RestrictedAreaNavigational" => [Primitives.surface],
			"RestrictedAreaRegulatory" => [Primitives.surface],
			"RouteingMeasure" => [Primitives.surface,Primitives.curve],
			"ShipReportingServiceArea" => [Primitives.surface],
			"SignalStationWarning" => [Primitives.point,Primitives.surface],
			"SignalStationTraffic" => [Primitives.point,Primitives.surface],
			"UnderKeelClearanceAllowanceArea" => [Primitives.surface],
			"UnderKeelClearanceManagementArea" => [Primitives.surface],
			"VesselTrafficServiceArea" => [Primitives.surface],
			"WaterwayArea" => [Primitives.surface],
			"DataQuality" => [Primitives.surface],
			"QualityOfTemporalVariation" => [Primitives.surface],
			"DataCoverage" => [Primitives.surface],
			"QualityOfNonBathymetricData" => [Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Principal and intermediate compass points.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalDirection : int {
		[System.ComponentModel.Description("348.75-011.25 degrees (true north).")]
		[EnumMember(Value = "North")] 
		[XmlEnum("1")] 
		North = 1,

		[System.ComponentModel.Description("011.25 - 033.75 degrees.")]
		[EnumMember(Value = "North Northeast")] 
		[XmlEnum("2")] 
		NorthNortheast = 2,

		[System.ComponentModel.Description("033.75 - 056.25 degrees.")]
		[EnumMember(Value = "Northeast")] 
		[XmlEnum("3")] 
		Northeast = 3,

		[System.ComponentModel.Description("056.25-078.75 degrees.")]
		[EnumMember(Value = "East Northeast")] 
		[XmlEnum("4")] 
		EastNortheast = 4,

		[System.ComponentModel.Description("078.75-101.25 degrees.")]
		[EnumMember(Value = "East")] 
		[XmlEnum("5")] 
		East = 5,

		[System.ComponentModel.Description("101.25-123.75 degrees.")]
		[EnumMember(Value = "East Southeast")] 
		[XmlEnum("6")] 
		EastSoutheast = 6,

		[System.ComponentModel.Description("123.75-146.25 degrees.")]
		[EnumMember(Value = "Southeast")] 
		[XmlEnum("7")] 
		Southeast = 7,

		[System.ComponentModel.Description("146.25-168.75 degrees.")]
		[EnumMember(Value = "South Southeast")] 
		[XmlEnum("8")] 
		SouthSoutheast = 8,

		[System.ComponentModel.Description("168.75-191.25 degrees.")]
		[EnumMember(Value = "South")] 
		[XmlEnum("9")] 
		South = 9,

		[System.ComponentModel.Description("191.25-213.75 degrees.")]
		[EnumMember(Value = "South Southwest")] 
		[XmlEnum("10")] 
		SouthSouthwest = 10,

		[System.ComponentModel.Description("213.75-236.25 degrees.")]
		[EnumMember(Value = "Southwest")] 
		[XmlEnum("11")] 
		Southwest = 11,

		[System.ComponentModel.Description("236.25-258.75 degrees.")]
		[EnumMember(Value = "West Southwest")] 
		[XmlEnum("12")] 
		WestSouthwest = 12,

		[System.ComponentModel.Description("258.75-281.25 degrees.")]
		[EnumMember(Value = "West")] 
		[XmlEnum("13")] 
		West = 13,

		[System.ComponentModel.Description("281.25-303.75 degrees.")]
		[EnumMember(Value = "West Northwest")] 
		[XmlEnum("14")] 
		WestNorthwest = 14,

		[System.ComponentModel.Description("303.75 - 326.25 degrees.")]
		[EnumMember(Value = "Northwest")] 
		[XmlEnum("15")] 
		Northwest = 15,

		[System.ComponentModel.Description("326.25 - 348.75 degrees.")]
		[EnumMember(Value = "North Northwest")] 
		[XmlEnum("16")] 
		NorthNorthwest = 16,
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
	/// Classification of shipping hazards due to traffic volume or density.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfConcentrationOfShippingHazardArea : int {
		[System.ComponentModel.Description("Concentration of vessels whose primary purpose is to engage in commerce, including ferries.")]
		[EnumMember(Value = "Concentration of Merchant Shipping")] 
		[XmlEnum("1")] 
		ConcentrationOfMerchantShipping = 1,

		[System.ComponentModel.Description("Concentration of powered or sailing vessels principally engaged in recreation, leisure, or sporting competition.")]
		[EnumMember(Value = "Concentration of Recreational Vessels")] 
		[XmlEnum("2")] 
		ConcentrationOfRecreationalVessels = 2,

		[System.ComponentModel.Description("Concentration of vessels whose primary purpose is to hunt, trap or process fish. The concentration could be on the fishing ground, in transit or in the approaches to home bases or fish markets.")]
		[EnumMember(Value = "Concentration of Fishing Vessels")] 
		[XmlEnum("3")] 
		ConcentrationOfFishingVessels = 3,

		[System.ComponentModel.Description("Concentration of vessels principally engaged in military activities. This includes activities based on mandate of international organizations (for example, UN). The concentration is in areas others than military exercise areas.")]
		[EnumMember(Value = "Concentration of Military Vessels")] 
		[XmlEnum("4")] 
		ConcentrationOfMilitaryVessels = 4,
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
	/// Classification of maritime broadcast based on the nature of information conveyed.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMaritimeBroadcast : int {
		[System.ComponentModel.Description("A message containing urgent information relevant to safe navigation broadcast to ships in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.")]
		[EnumMember(Value = "Navigational Warning")] 
		[XmlEnum("1")] 
		NavigationalWarning = 1,

		[System.ComponentModel.Description("Warning of adverse weather conditions.")]
		[EnumMember(Value = "Meteorological Warning")] 
		[XmlEnum("2")] 
		MeteorologicalWarning = 2,

		[System.ComponentModel.Description("Report of the ice situation and restrictions to shipping.")]
		[EnumMember(Value = "Ice Report")] 
		[XmlEnum("3")] 
		IceReport = 3,

		[System.ComponentModel.Description("Broadcast message with information about an ongoing Search and Rescue operation.")]
		[EnumMember(Value = "SAR Information")] 
		[XmlEnum("4")] 
		SarInformation = 4,

		[System.ComponentModel.Description("Warning of possible attack by pirates.")]
		[EnumMember(Value = "Pirate Attack Warning")] 
		[XmlEnum("5")] 
		PirateAttackWarning = 5,

		[System.ComponentModel.Description("Broadcast message containing meteorological forecast.")]
		[EnumMember(Value = "Meteorological Forecast")] 
		[XmlEnum("6")] 
		MeteorologicalForecast = 6,

		[System.ComponentModel.Description("Broadcast message about a pilot service.")]
		[EnumMember(Value = "Pilot Service Message")] 
		[XmlEnum("7")] 
		PilotServiceMessage = 7,

		[System.ComponentModel.Description("Broadcast message about AIS information.")]
		[EnumMember(Value = "AIS Information")] 
		[XmlEnum("8")] 
		AisInformation = 8,

		[System.ComponentModel.Description("Broadcast message about the LORAN service.")]
		[EnumMember(Value = "LORAN Message")] 
		[XmlEnum("9")] 
		LoranMessage = 9,

		[System.ComponentModel.Description("Broadcast message about Satellite Navigation service.")]
		[EnumMember(Value = "SATNAV Message")] 
		[XmlEnum("10")] 
		SatnavMessage = 10,

		[System.ComponentModel.Description("Warning of winds of Beaufort force 8 or 9.")]
		[EnumMember(Value = "Gale Warning")] 
		[XmlEnum("11")] 
		GaleWarning = 11,

		[System.ComponentModel.Description("Warning of winds of Beaufort force 10 or over.")]
		[EnumMember(Value = "Storm Warning")] 
		[XmlEnum("12")] 
		StormWarning = 12,

		[System.ComponentModel.Description("Warning of hurricanes in the North Atlantic and eastern North Pacific, typhoons in the Western Pacific, cyclones in the Indian Ocean and cyclones of similar nature in other regions.")]
		[EnumMember(Value = "Tropical Revolving Storm Warning")] 
		[XmlEnum("13")] 
		TropicalRevolvingStormWarning = 13,

		[System.ComponentModel.Description("Navigational warning or in-force bulletin promulgated as part of a numbered series by a NAVAREA coordinator.")]
		[EnumMember(Value = "NAVAREA Warning")] 
		[XmlEnum("14")] 
		NavareaWarning = 14,

		[System.ComponentModel.Description("A navigational warning, or in-force bulletin, promulgated as part of a numbered series by a National Coordinator.")]
		[EnumMember(Value = "Coastal Warning")] 
		[XmlEnum("15")] 
		CoastalWarning = 15,

		[System.ComponentModel.Description("Warning which covers inshore waters, often within the limits of jurisdiction of a harbour or port authority.")]
		[EnumMember(Value = "Local Warning")] 
		[XmlEnum("16")] 
		LocalWarning = 16,

		[System.ComponentModel.Description("Warning of actual or expected low water level.")]
		[EnumMember(Value = "Low Water Level Warning/Negative Tidal Surge")] 
		[XmlEnum("17")] 
		LowWaterLevelWarningNegativeTidalSurge = 17,

		[System.ComponentModel.Description("Warning of accretion of ice on ships.")]
		[EnumMember(Value = "Icing Warning")] 
		[XmlEnum("18")] 
		IcingWarning = 18,

		[System.ComponentModel.Description("Broadcasts about tsunamis, including watches, advisories, and other types of messages relating to tsunamis or potential tsunamis.")]
		[EnumMember(Value = "Tsunami Broadcast")] 
		[XmlEnum("19")] 
		TsunamiBroadcast = 19,
	}

	/// <summary>
	/// Classification of area by military use.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMilitaryPracticeArea : int {
		[System.ComponentModel.Description("An area within which exercises are carried out with torpedoes.")]
		[EnumMember(Value = "Torpedo Exercise Area")] 
		[XmlEnum("2")] 
		TorpedoExerciseArea = 2,

		[System.ComponentModel.Description("An area within which submarine exercises are carried out.")]
		[EnumMember(Value = "Submarine Exercise Area")] 
		[XmlEnum("3")] 
		SubmarineExerciseArea = 3,

		[System.ComponentModel.Description("Areas for bombing and missile exercises.")]
		[EnumMember(Value = "Firing Danger Area")] 
		[XmlEnum("4")] 
		FiringDangerArea = 4,

		[System.ComponentModel.Description("An area within which mine laying exercises are carried out.")]
		[EnumMember(Value = "Mine-Laying Practice Area")] 
		[XmlEnum("5")] 
		MineLayingPracticeArea = 5,

		[System.ComponentModel.Description("An area for shooting pistols, rifles and machine guns etc. at a target.")]
		[EnumMember(Value = "Small Arms Firing Range")] 
		[XmlEnum("6")] 
		SmallArmsFiringRange = 6,
	}

	/// <summary>
	/// Classification of route guidance given to vessels.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfNavigationLine : int {
		[System.ComponentModel.Description("A straight line that marks the boundary between a safe and a dangerous area or that passes clear of a navigational danger.")]
		[EnumMember(Value = "Clearing Line")] 
		[XmlEnum("1")] 
		ClearingLine = 1,

		[System.ComponentModel.Description("A line passing through one or more fixed marks.")]
		[EnumMember(Value = "Transit Line")] 
		[XmlEnum("2")] 
		TransitLine = 2,

		[System.ComponentModel.Description("A line passing through one or more clearly defined objects, along the path of which a vessel can approach safely up to a certain distance off.")]
		[EnumMember(Value = "Leading Line Bearing a Recommended Track")] 
		[XmlEnum("3")] 
		LeadingLineBearingARecommendedTrack = 3,
	}

	/// <summary>
	/// Classification of pilots and pilot services by type of waterway where piloting services are provided.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPilot : int {
		[System.ComponentModel.Description("Pilot licenced to conduct vessels during approach from sea to a specified place which may be a handover place, an anchorage or alongside.")]
		[EnumMember(Value = "Pilot")] 
		[XmlEnum("1")] 
		Pilot = 1,

		[System.ComponentModel.Description("Pilot licenced to conduct vessels over extensive sea areas.")]
		[EnumMember(Value = "Deep Sea")] 
		[XmlEnum("2")] 
		DeepSea = 2,

		[System.ComponentModel.Description("A reporting point of a harbour.")]
		[EnumMember(Value = "Harbour")] 
		[XmlEnum("3")] 
		Harbour = 3,

		[System.ComponentModel.Description("A ridge or succession of ridges of sand or other substances extending across the mouth of a river or harbour and which may obstruct navigation.")]
		[EnumMember(Value = "Bar")] 
		[XmlEnum("4")] 
		Bar = 4,

		[System.ComponentModel.Description("A relatively large natural stream of water.")]
		[EnumMember(Value = "River")] 
		[XmlEnum("5")] 
		River = 5,

		[System.ComponentModel.Description("Pilot licensed to conduct vessels from and to specified places, along the course of a channel. (For example as used in Rio Amazonas and Rio de La Plata.)")]
		[EnumMember(Value = "Channel")] 
		[XmlEnum("6")] 
		Channel = 6,

		[System.ComponentModel.Description("A large body of water entirely surrounded by land.")]
		[EnumMember(Value = "Lake")] 
		[XmlEnum("7")] 
		Lake = 7,
	}

	/// <summary>
	/// Classification of pilot boarding method.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPilotBoardingPlace : int {
		[System.ComponentModel.Description("Pilot boards from a cruising vessel.")]
		[EnumMember(Value = "Boarding by Pilot-Cruising Vessel")] 
		[XmlEnum("1")] 
		BoardingByPilotCruisingVessel = 1,

		[System.ComponentModel.Description("Pilot boards by helicopter which comes out from the shore.")]
		[EnumMember(Value = "Boarding by Helicopter")] 
		[XmlEnum("2")] 
		BoardingByHelicopter = 2,

		[System.ComponentModel.Description("Pilot embarks from a vessel or disembarks on a vessel which comes out from the shore on request.")]
		[EnumMember(Value = "Pilot Comes Out from Shore")] 
		[XmlEnum("3")] 
		PilotComesOutFromShore = 3,
	}

	/// <summary>
	/// The selection of a first choice compared to other options.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPreference : int {
		[System.ComponentModel.Description("The preferred first choice used in normal conditions.")]
		[EnumMember(Value = "Primary")] 
		[XmlEnum("1")] 
		Primary = 1,

		[System.ComponentModel.Description("The preferred choice in extraordinary conditions.")]
		[EnumMember(Value = "Alternate")] 
		[XmlEnum("2")] 
		Alternate = 2,
	}

	/// <summary>
	/// Categories of radiocommunications based on frequency band and radio traffic method.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioMethods : int {
		[System.ComponentModel.Description("Frequency in a frequency range between 30 and 300 kHz used for voice traffic.")]
		[EnumMember(Value = "Low Frequency Voice Traffic")] 
		[XmlEnum("1")] 
		LowFrequencyVoiceTraffic = 1,

		[System.ComponentModel.Description("Frequency in a frequency range between 300 and 3000 kHz used for voice traffic.")]
		[EnumMember(Value = "Medium Frequency Voice Traffic")] 
		[XmlEnum("2")] 
		MediumFrequencyVoiceTraffic = 2,

		[System.ComponentModel.Description("Frequency in a frequency range between 3 and 30 MHz used for voice traffic.")]
		[EnumMember(Value = "High Frequency (HF) Voice Traffic")] 
		[XmlEnum("3")] 
		HighFrequencyHfVoiceTraffic = 3,

		[System.ComponentModel.Description("Frequency in a frequency range between 30 and 300 MHz used for voice traffic.")]
		[EnumMember(Value = "Very High Frequency (VHF) Voice Traffic")] 
		[XmlEnum("4")] 
		VeryHighFrequencyVhfVoiceTraffic = 4,

		[System.ComponentModel.Description("An automated direct printing service,in the high frequency range, similar to NAVTEX, but does not offer all of the same functionality such as avoiding repeated messages.")]
		[EnumMember(Value = "High Frequency Narrow Band Direct Printing")] 
		[XmlEnum("5")] 
		HighFrequencyNarrowBandDirectPrinting = 5,

		[System.ComponentModel.Description("The system for the broadcast and automatic reception of Maritime Safety Information by means of narrow-band direct-printing telegraphy.")]
		[EnumMember(Value = "NAVTEX")] 
		[XmlEnum("6")] 
		Navtex = 6,

		[System.ComponentModel.Description("SafetyNET is an international automatic direct-printing satellite-based service for the promulgation of navigational and meteorological warnings, meteorological forecasts and other urgent safety-related messages - maritime safety information (MSI) - to ships.")]
		[EnumMember(Value = "SafetyNET")] 
		[XmlEnum("7")] 
		Safetynet = 7,

		[System.ComponentModel.Description("A communications system consisting of teletypewriters connected to a telephonic network to send and receive Narrow Band Direct Printing.")]
		[EnumMember(Value = "NBDP Telegraphy (Narrow Band Direct Printing Telegraphy)")] 
		[XmlEnum("8")] 
		NbdpTelegraphyNarrowBandDirectPrintingTelegraphy = 8,

		[System.ComponentModel.Description("A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.")]
		[EnumMember(Value = "Facsimile")] 
		[XmlEnum("9")] 
		Facsimile = 9,

		[System.ComponentModel.Description("A Russian system transmitting navigational information, sent by radio and containing information relevant to coastal waters of foreign countries and high seas.")]
		[EnumMember(Value = "NAVIP")] 
		[XmlEnum("10")] 
		Navip = 10,

		[System.ComponentModel.Description("Frequency in a frequency range between 30 and 300 kHz used for digital traffic.")]
		[EnumMember(Value = "Low Frequency Digital Traffic")] 
		[XmlEnum("11")] 
		LowFrequencyDigitalTraffic = 11,

		[System.ComponentModel.Description("Frequency in a frequency range between 300 and 3000 kHz used for digital traffic.")]
		[EnumMember(Value = "Medium Frequency Digital Traffic")] 
		[XmlEnum("12")] 
		MediumFrequencyDigitalTraffic = 12,

		[System.ComponentModel.Description("Frequency in a frequency range between 3 and 30 MHz used for digital traffic.")]
		[EnumMember(Value = "High Frequency (HF) Digital Traffic")] 
		[XmlEnum("13")] 
		HighFrequencyHfDigitalTraffic = 13,

		[System.ComponentModel.Description("Frequency in a frequency range between 30 and 300 MHz used for digital traffic.")]
		[EnumMember(Value = "Very High Frequency (VHF) Digital Traffic")] 
		[XmlEnum("14")] 
		VeryHighFrequencyVhfDigitalTraffic = 14,

		[System.ComponentModel.Description("Frequency in a frequency range between 30 and 300 kHz used for telegraph traffic.")]
		[EnumMember(Value = "Low Frequency Telegraph Traffic")] 
		[XmlEnum("15")] 
		LowFrequencyTelegraphTraffic = 15,

		[System.ComponentModel.Description("Frequency in a frequency range between 300 and 3000 kHz used for telegraph traffic.")]
		[EnumMember(Value = "Medium Frequency Telegraph Traffic")] 
		[XmlEnum("16")] 
		MediumFrequencyTelegraphTraffic = 16,

		[System.ComponentModel.Description("Frequency in a frequency range between 3 and 30 MHz used for telegraph traffic.")]
		[EnumMember(Value = "High Frequency (HF) Telegraph Traffic")] 
		[XmlEnum("17")] 
		HighFrequencyHfTelegraphTraffic = 17,

		[System.ComponentModel.Description("Frequency in a frequency range between 300 and 3000 kHz used for Digital Selective Call traffic.")]
		[EnumMember(Value = "Medium Frequency Digital Selective Call Traffic")] 
		[XmlEnum("18")] 
		MediumFrequencyDigitalSelectiveCallTraffic = 18,

		[System.ComponentModel.Description("Frequency in a frequency range between 3 and 30 MHz used for Digital Selective Call traffic.")]
		[EnumMember(Value = "High Frequency (HF) Digital Selective Call Traffic")] 
		[XmlEnum("19")] 
		HighFrequencyHfDigitalSelectiveCallTraffic = 19,

		[System.ComponentModel.Description("Frequency in a frequency range between 30 and 300 MHz used for Digital Selective Call traffic.")]
		[EnumMember(Value = "Very High Frequency (VHF) Digital Selective Call Traffic")] 
		[XmlEnum("20")] 
		VeryHighFrequencyVhfDigitalSelectiveCallTraffic = 20,
	}

	/// <summary>
	/// Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRelationship : int {
		[System.ComponentModel.Description("Use of facility, waterway or service is forbidden.")]
		[EnumMember(Value = "Prohibited")] 
		[XmlEnum("1")] 
		Prohibited = 1,

		[System.ComponentModel.Description("Use of facility, waterway or service is not recommended.")]
		[EnumMember(Value = "Not Recommended")] 
		[XmlEnum("2")] 
		NotRecommended = 2,

		[System.ComponentModel.Description("Use of facility, waterway, or service is permitted but not required.")]
		[EnumMember(Value = "Permitted")] 
		[XmlEnum("3")] 
		Permitted = 3,

		[System.ComponentModel.Description("Use of facility, waterway, or service is recommended.")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("4")] 
		Recommended = 4,

		[System.ComponentModel.Description("Use of facility, waterway, or service is required.")]
		[EnumMember(Value = "Required")] 
		[XmlEnum("5")] 
		Required = 5,

		[System.ComponentModel.Description("Use of facility, waterway, or service is not required.")]
		[EnumMember(Value = "Not Required")] 
		[XmlEnum("6")] 
		NotRequired = 6,
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

		[System.ComponentModel.Description("An area reserved for vessels waiting to enter a harbour.")]
		[EnumMember(Value = "Waiting Area")] 
		[XmlEnum("19")] 
		WaitingArea = 19,

		[System.ComponentModel.Description("An area where marine research takes place.")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("A place where fish (including shellfish and crustaceans) are protected.")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("A tract of land managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("An area where vessels turn.")]
		[EnumMember(Value = "Swinging Area")] 
		[XmlEnum("25")] 
		SwingingArea = 25,

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
	}

	/// <summary>
	/// Classification of routeing measures by type.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRouteingMeasure : int {
		[System.ComponentModel.Description("Sea lanes designated by an archipelagic State for the passage of ships and aircraft.  The Archipelagic Sea Lane aggregates all component parts of an Archipelagic Sea Lane system.")]
		[EnumMember(Value = "Archipelagic Sea Lane")] 
		[XmlEnum("1")] 
		ArchipelagicSeaLane = 1,

		[System.ComponentModel.Description("A route within defined limits which has been accurately surveyed for clearance of sea bottom and submerged obstacles as indicated on the chart.")]
		[EnumMember(Value = "Deep Water Route")] 
		[XmlEnum("2")] 
		DeepWaterRoute = 2,

		[System.ComponentModel.Description("That part of a river, harbour and so on, where the main navigable channel for vessels of larger size lies. It is also the usual course followed by vessels entering or leaving harbours, called ship channel. A fairway system is an aggregation of connected fairway features making up a complex fairway system.")]
		[EnumMember(Value = "Fairway System")] 
		[XmlEnum("3")] 
		FairwaySystem = 3,

		[System.ComponentModel.Description("A navigation line, range system, or a recommended track, lane, or route.")]
		[EnumMember(Value = "Recommended Route")] 
		[XmlEnum("4")] 
		RecommendedRoute = 4,

		[System.ComponentModel.Description("A routeing measure aimed at the separation of opposing streams of traffic by appropriate means and by the establishment of traffic lanes.")]
		[EnumMember(Value = "Traffic Separation Scheme")] 
		[XmlEnum("5")] 
		TrafficSeparationScheme = 5,

		[System.ComponentModel.Description("A route within defined limits inside which two way traffic is established, aimed at providing safe passage of ships through waters where navigation is difficult or dangerous.")]
		[EnumMember(Value = "Two-Way Route")] 
		[XmlEnum("6")] 
		TwoWayRoute = 6,
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
	/// Classification of ship reports based on IMO standard report formats.
	/// </summary>
	/// <remarks>
	/// Through Resolution A.851(20), the IMO encourages authorities to require standard formats and procedures for ship reporting and recognizes that some authorities require amended formats. (Appendix to IMO Resolution A.851(20) GENERAL PRINCIPLES FOR SHIP REPORTING SYSTEMS AND SHIP REPORTING REQUIREMENTS, INCLUDING GUIDELINES FOR REPORTING INCIDENTS INVOLVING DANGEROUS GOODS, HARMFUL SUBSTANCES AND/OR MARINE POLLUTANTS.)
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfShipReport : int {
		[System.ComponentModel.Description("Before or as near as possible to the time of departure from a port within a system or when entering the area covered by a system (for instance A, B, J, X etc).")]
		[EnumMember(Value = "Sailing Plan")] 
		[XmlEnum("1")] 
		SailingPlan = 1,

		[System.ComponentModel.Description("When necessary to ensure effective operation of the system.")]
		[EnumMember(Value = "Position Report")] 
		[XmlEnum("2")] 
		PositionReport = 2,

		[System.ComponentModel.Description("When the ships position varies significantly from the position that would have been predicted from previous reports; when changing the reported route; or as decided by the master.")]
		[EnumMember(Value = "Deviation Report")] 
		[XmlEnum("3")] 
		DeviationReport = 3,

		[System.ComponentModel.Description("On arrival at the destination or on leaving the area covered by the system.")]
		[EnumMember(Value = "Final Report")] 
		[XmlEnum("4")] 
		FinalReport = 4,

		[System.ComponentModel.Description("When an incident takes place involving the loss or likely loss overboard of packaged dangerous goods, including those in freight containers, portable tanks, road and rail vehicles and ship-borne barges, into the sea.")]
		[EnumMember(Value = "Dangerous Goods Report")] 
		[XmlEnum("5")] 
		DangerousGoodsReport = 5,

		[System.ComponentModel.Description("Report submitted when an incident takes place involving the discharge or probable discharge of oil or noxious liquid substances in bulk.")]
		[EnumMember(Value = "Harmful Substances Report")] 
		[XmlEnum("6")] 
		HarmfulSubstancesReport = 6,

		[System.ComponentModel.Description("In the case of the loss or likely loss overboard of harmful substances in packaged form, including those in freight containers, portable tanks, road and rail vehicles and ship-borne barges identified in the International Maritime Goods Code as marine pollutants.")]
		[EnumMember(Value = "Marine Pollutants Report")] 
		[XmlEnum("7")] 
		MarinePollutantsReport = 7,

		[System.ComponentModel.Description("Any other type of non-defined report that is made in accordance with the system procedures as notified in accordance with paragraph 9 of the general principles.")]
		[EnumMember(Value = "Any Other Report")] 
		[XmlEnum("8")] 
		AnyOtherReport = 8,
	}

	/// <summary>
	/// Classification of station based on the traffic service provided.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSignalStationTraffic : int {
		[System.ComponentModel.Description("A signal station for the control of vessels within a port.")]
		[EnumMember(Value = "Port Control")] 
		[XmlEnum("1")] 
		PortControl = 1,

		[System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a port.")]
		[EnumMember(Value = "Port Entry and Departure")] 
		[XmlEnum("2")] 
		PortEntryAndDeparture = 2,

		[System.ComponentModel.Description("A signal station displaying International Port Traffic signals.")]
		[EnumMember(Value = "International Port Traffic")] 
		[XmlEnum("3")] 
		InternationalPortTraffic = 3,

		[System.ComponentModel.Description("A signal station for the control of vessels when berthing.")]
		[EnumMember(Value = "Berthing")] 
		[XmlEnum("4")] 
		Berthing = 4,

		[System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a dock.")]
		[EnumMember(Value = "Dock")] 
		[XmlEnum("5")] 
		Dock = 5,

		[System.ComponentModel.Description("A signal station for the control of vessels entering or leaving a lock.")]
		[EnumMember(Value = "Lock")] 
		[XmlEnum("6")] 
		Lock = 6,

		[System.ComponentModel.Description("A signal station for the control of vessels wishing to pass through a flood control barrage.")]
		[EnumMember(Value = "Flood Barrage Station")] 
		[XmlEnum("7")] 
		FloodBarrageStation = 7,

		[System.ComponentModel.Description("A signal station for the control of vessels wishing to pass under a bridge.")]
		[EnumMember(Value = "Bridge Passage")] 
		[XmlEnum("8")] 
		BridgePassage = 8,

		[System.ComponentModel.Description("A signal station indicating when dredging is in progress.")]
		[EnumMember(Value = "Dredging")] 
		[XmlEnum("9")] 
		Dredging = 9,

		[System.ComponentModel.Description("Visual signal lights placed in a waterway to indicate to shipping the movements authorized at the time at which they are shown.")]
		[EnumMember(Value = "Traffic Control Light")] 
		[XmlEnum("10")] 
		TrafficControlLight = 10,

		[System.ComponentModel.Description("Indicates the oncoming traffic on an inland waterway.")]
		[EnumMember(Value = "Oncoming Traffic Indication")] 
		[XmlEnum("13")] 
		OncomingTrafficIndication = 13,
	}

	/// <summary>
	/// Classification of station based on the warning service provided.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSignalStationWarning : int {
		[System.ComponentModel.Description("A signal or message warning of the presence of a danger to navigation.")]
		[EnumMember(Value = "Danger")] 
		[XmlEnum("1")] 
		Danger = 1,

		[System.ComponentModel.Description("A signal or message warning of the presence of a maritime obstruction.")]
		[EnumMember(Value = "Maritime Obstruction")] 
		[XmlEnum("2")] 
		MaritimeObstruction = 2,

		[System.ComponentModel.Description("A signal or message warning of the presence of a cable.")]
		[EnumMember(Value = "Cable")] 
		[XmlEnum("3")] 
		Cable = 3,

		[System.ComponentModel.Description("A signal or message warning of activity in a military practice area.")]
		[EnumMember(Value = "Military Practice")] 
		[XmlEnum("4")] 
		MilitaryPractice = 4,

		[System.ComponentModel.Description("A station that may receive or transmit distress signals.")]
		[EnumMember(Value = "Distress")] 
		[XmlEnum("5")] 
		Distress = 5,

		[System.ComponentModel.Description("A visual signal displayed to indicate a weather forecast.")]
		[EnumMember(Value = "Weather")] 
		[XmlEnum("6")] 
		Weather = 6,

		[System.ComponentModel.Description("A signal or message conveying information about storm conditions.")]
		[EnumMember(Value = "Storm")] 
		[XmlEnum("7")] 
		Storm = 7,

		[System.ComponentModel.Description("A signal or message conveying information about ice conditions.")]
		[EnumMember(Value = "Ice Warning")] 
		[XmlEnum("8")] 
		IceWarning = 8,

		[System.ComponentModel.Description("An accurate signal marking a specified time or time interval. It is used primarily for determining errors of timepieces. Such signals are usually sent from an observatory by radio or telegraph, but visual signals are used at some ports.")]
		[EnumMember(Value = "Time")] 
		[XmlEnum("9")] 
		Time = 9,

		[System.ComponentModel.Description("A signal or message conveying information on tidal conditions in the area in question.")]
		[EnumMember(Value = "Tide")] 
		[XmlEnum("10")] 
		Tide = 10,

		[System.ComponentModel.Description("A signal or message conveying information on condition of tidal currents in the area in question.")]
		[EnumMember(Value = "Tidal Stream")] 
		[XmlEnum("11")] 
		TidalStream = 11,

		[System.ComponentModel.Description("A device for measuring the height of tide. A graduated staff in a sheltered area where visual observations can be made or it may consist of an elaborate recording instrument making a continuous graphic record of tide height against time. Such an instrument is usually actuated by a float in a pipe communicating with the sea through a small hole which filters out shorter waves.")]
		[EnumMember(Value = "Tide Gauge")] 
		[XmlEnum("12")] 
		TideGauge = 12,

		[System.ComponentModel.Description("A visual scale which directly shows the height of the water above chart datum or a local datum.")]
		[EnumMember(Value = "Tide Scale")] 
		[XmlEnum("13")] 
		TideScale = 13,

		[System.ComponentModel.Description("A signal or message warning of diving activity.")]
		[EnumMember(Value = "Diving")] 
		[XmlEnum("14")] 
		Diving = 14,

		[System.ComponentModel.Description("A device for measuring and conveying information about the water level (non-tidal) in the area in question.")]
		[EnumMember(Value = "Water Level Gauge")] 
		[XmlEnum("15")] 
		WaterLevelGauge = 15,

		[System.ComponentModel.Description("An indication of the vertical clearance of a bridge, overhead cable, etc.")]
		[EnumMember(Value = "Vertical Clearance Indication")] 
		[XmlEnum("16")] 
		VerticalClearanceIndication = 16,

		[System.ComponentModel.Description("An indication of the official high water level.")]
		[EnumMember(Value = "High Water Mark")] 
		[XmlEnum("17")] 
		HighWaterMark = 17,

		[System.ComponentModel.Description("An indication of the local depth.")]
		[EnumMember(Value = "Depth Indication")] 
		[XmlEnum("18")] 
		DepthIndication = 18,
	}

	/// <summary>
	/// An assessment of the likelihood of change over time.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTemporalVariation : int {
		[System.ComponentModel.Description("Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.")]
		[EnumMember(Value = "Extreme Event")] 
		[XmlEnum("1")] 
		ExtremeEvent = 1,

		[System.ComponentModel.Description("Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).")]
		[EnumMember(Value = "Likely to Change")] 
		[XmlEnum("4")] 
		LikelyToChange = 4,

		[System.ComponentModel.Description("Significant change to the seafloor is not expected.")]
		[EnumMember(Value = "Unlikely to Change")] 
		[XmlEnum("5")] 
		UnlikelyToChange = 5,
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
	/// International classification of traffic separation scheme.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTrafficSeparationScheme : int {
		[System.ComponentModel.Description("A defined maritime traffic route that has been adopted as an IMO routeing measure.")]
		[EnumMember(Value = "IMO Adopted")] 
		[XmlEnum("1")] 
		ImoAdopted = 1,

		[System.ComponentModel.Description("A defined Traffic Separation Scheme that has not been adopted as an IMO routing measure.")]
		[EnumMember(Value = "Not IMO - Adopted")] 
		[XmlEnum("2")] 
		NotImoAdopted = 2,
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
	}

	/// <summary>
	/// Numerical comparison.
	/// </summary>
	/// <remarks>
	/// Provides the relation between the value given in the model and the real ship's value.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("The value of the left value is greater than that of the right.")]
		[EnumMember(Value = "Greater Than")] 
		[XmlEnum("1")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("The value of the left expression is greater than or equal to that of the right.")]
		[EnumMember(Value = "Greater Than or Equal To")] 
		[XmlEnum("2")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("The value of the left expression is less than that of the right.")]
		[EnumMember(Value = "Less Than")] 
		[XmlEnum("3")] 
		LessThan = 3,

		[System.ComponentModel.Description("The value of the left expression is less than or equal to that of the right.")]
		[EnumMember(Value = "Less Than or Equal To")] 
		[XmlEnum("4")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("The two values are equivalent.")]
		[EnumMember(Value = "Equal To")] 
		[XmlEnum("5")] 
		EqualTo = 5,

		[System.ComponentModel.Description("The two values are not equivalent.")]
		[EnumMember(Value = "Not Equal To")] 
		[XmlEnum("6")] 
		NotEqualTo = 6,
	}

	/// <summary>
	/// The various conditions of buildings and other constructions.
	/// </summary>
	/// <remarks>
	/// The default 'condition' should be considered to be completed, undamaged and working normally.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum condition : int {
		[System.ComponentModel.Description("Being built but not yet capable of function.")]
		[EnumMember(Value = "Under Construction")] 
		[XmlEnum("1")] 
		UnderConstruction = 1,

		[System.ComponentModel.Description("An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.")]
		[EnumMember(Value = "Under Reclamation")] 
		[XmlEnum("3")] 
		UnderReclamation = 3,

		[System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,
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
	/// Whether a vessel must use a shore-based or other resource to obtain up-to-date information.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dynamicResource : int {
		[System.ComponentModel.Description("The information is static, or a source of up-to-date information is unavailable or unknown.")]
		[EnumMember(Value = "Static")] 
		[XmlEnum("1")] 
		Static = 1,

		[System.ComponentModel.Description("An external source of up-to-date information is available and interaction with it to obtain up-to-date information is required.")]
		[EnumMember(Value = "Mandatory External Dynamic")] 
		[XmlEnum("2")] 
		MandatoryExternalDynamic = 2,

		[System.ComponentModel.Description("An external source of up-to-date information is available but interaction with it to obtain up-to-date information is not required.")]
		[EnumMember(Value = "Optional External Dynamic")] 
		[XmlEnum("3")] 
		OptionalExternalDynamic = 3,

		[System.ComponentModel.Description("Up-to-date information may be computed using only onboard resources.")]
		[EnumMember(Value = "Onboard Dynamic")] 
		[XmlEnum("4")] 
		OnboardDynamic = 4,
	}

	/// <summary>
	/// Classification of ISPS security levels according to the ISPS Code.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iSPSLevel : int {
		[System.ComponentModel.Description("The level for which minimum appropriate protective security measures shall be maintained at all times.")]
		[EnumMember(Value = "ISPS Level 1")] 
		[XmlEnum("1")] 
		IspsLevel1 = 1,

		[System.ComponentModel.Description("The level for which appropriate additional protective security measures shall be maintained for a period of time as a result of heightened risk of a security incident.")]
		[EnumMember(Value = "ISPS Level 2")] 
		[XmlEnum("2")] 
		IspsLevel2 = 2,

		[System.ComponentModel.Description("The level for which further specific protective security measures shall be maintained for a limited period of time when a security incident is probable or imminent, although it may not be possible to identify the specific target.")]
		[EnumMember(Value = "ISPS Level 3")] 
		[XmlEnum("3")] 
		IspsLevel3 = 3,
	}

	/// <summary>
	/// Indicates whether a vessel is included or excluded from the regulation/restriction/recommendation/nautical information.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum membership : int {
		[System.ComponentModel.Description("Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.")]
		[EnumMember(Value = "Included")] 
		[XmlEnum("1")] 
		Included = 1,

		[System.ComponentModel.Description("Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.")]
		[EnumMember(Value = "Excluded")] 
		[XmlEnum("2")] 
		Excluded = 2,
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
	/// Code for function performed by the online resource.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum onlineFunction : int {
		[System.ComponentModel.Description("Online instructions for transferring data from one storage device or system to another.")]
		[EnumMember(Value = "Download")] 
		[XmlEnum("1")] 
		Download = 1,

		[System.ComponentModel.Description("Online instructions for requesting the resource from the provider.")]
		[EnumMember(Value = "Offline Access")] 
		[XmlEnum("3")] 
		OfflineAccess = 3,

		[System.ComponentModel.Description("Online order process for obtaining the resource.")]
		[EnumMember(Value = "Order")] 
		[XmlEnum("4")] 
		Order = 4,

		[System.ComponentModel.Description("To make painstaking investigation or examination.")]
		[EnumMember(Value = "Search")] 
		[XmlEnum("5")] 
		Search = 5,

		[System.ComponentModel.Description("Complete metadata provided.")]
		[EnumMember(Value = "Complete Metadata")] 
		[XmlEnum("6")] 
		CompleteMetadata = 6,

		[System.ComponentModel.Description("Browse graphic provided.")]
		[EnumMember(Value = "Browse Graphic")] 
		[XmlEnum("7")] 
		BrowseGraphic = 7,

		[System.ComponentModel.Description("Online resource upload capability provided.")]
		[EnumMember(Value = "Upload")] 
		[XmlEnum("8")] 
		Upload = 8,

		[System.ComponentModel.Description("Online email service provided.")]
		[EnumMember(Value = "Email Service")] 
		[XmlEnum("9")] 
		EmailService = 9,

		[System.ComponentModel.Description("Online browsing provided.")]
		[EnumMember(Value = "Browsing")] 
		[XmlEnum("10")] 
		Browsing = 10,

		[System.ComponentModel.Description("Online file access provided.")]
		[EnumMember(Value = "File Access")] 
		[XmlEnum("11")] 
		FileAccess = 11,
	}

	/// <summary>
	/// Indicates whether the minimum or maximum value should be used to describe a condition or in application processing.
	/// </summary>
	/// <remarks>
	/// Null attributes are ignored. Example use: Complex attribute underkeelAllowance with UKCFIX=2.5, UKCVAR=10.00, OPERAT=1 inicates that the under-keel allowance required is the greater of 2.5 metres or 10% of the ship's draught.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum operation : int {
		[System.ComponentModel.Description("The numerically largest value computed from the applicable attributes or sub-attributes.")]
		[EnumMember(Value = "Largest Value")] 
		[XmlEnum("1")] 
		LargestValue = 1,

		[System.ComponentModel.Description("The numerically smallest value computed from the applicable attributes or sub-attributes.")]
		[EnumMember(Value = "Smallest Value")] 
		[XmlEnum("2")] 
		SmallestValue = 2,
	}

	/// <summary>
	/// Classification of pilot activity by arrival, departure, or change of pilot. It may also describe the place where the pilot's advice begins, ends, or is transferred to a different pilot.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum pilotMovement : int {
		[System.ComponentModel.Description("The place where vessels not being navigated according to a pilots instructions pick up a pilot while in transit from sea to a port or constricted waters for future navigation under pilot instructions.")]
		[EnumMember(Value = "Embarkation")] 
		[XmlEnum("1")] 
		Embarkation = 1,

		[System.ComponentModel.Description("The place where vessels being navigated under a pilots instructions in transit from sea to a port or constricted waters drop the pilot and proceed without being subject to pilot instructions.")]
		[EnumMember(Value = "Disembarkation")] 
		[XmlEnum("2")] 
		Disembarkation = 2,

		[System.ComponentModel.Description("The place where vessels being navigated under a pilots instructions drop off the pilot and pick up a different pilot for future navigation under pilots instructions.")]
		[EnumMember(Value = "Pilot Change")] 
		[XmlEnum("3")] 
		PilotChange = 3,
	}

	/// <summary>
	/// Classification of pilots and pilot services by type of license qualification or type of organization providing services.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum pilotQualification : int {
		[System.ComponentModel.Description("A pilot service carried out by government pilots.")]
		[EnumMember(Value = "Government Pilot")] 
		[XmlEnum("1")] 
		GovernmentPilot = 1,

		[System.ComponentModel.Description("A pilot service carried out by pilots who are approved by government.")]
		[EnumMember(Value = "Pilot Approved by Government")] 
		[XmlEnum("2")] 
		PilotApprovedByGovernment = 2,

		[System.ComponentModel.Description("A pilot that is licensed by the State (USA) and/or their respective pilot association, required for all foreign vessels and all American vessels under registry, bound for a port with compulsory State pilotage. A federal licence is not sufficient to pilot such vessels into the port.")]
		[EnumMember(Value = "State Pilot")] 
		[XmlEnum("3")] 
		StatePilot = 3,

		[System.ComponentModel.Description("A pilot who carries a Federal endorsement, offering services to vessels that are not required to obtain compulsory State pilotage. Services are usually contracted for in advance.")]
		[EnumMember(Value = "Federal Pilot")] 
		[XmlEnum("4")] 
		FederalPilot = 4,

		[System.ComponentModel.Description("A pilot provided by a commercial company.")]
		[EnumMember(Value = "Company Pilot")] 
		[XmlEnum("5")] 
		CompanyPilot = 5,

		[System.ComponentModel.Description("A pilot with local knowledge but who does not hold a qualification as a pilot.")]
		[EnumMember(Value = "Local Pilot")] 
		[XmlEnum("6")] 
		LocalPilot = 6,

		[System.ComponentModel.Description("A pilot service carried out by a citizen with sufficient local knowledge.")]
		[EnumMember(Value = "Citizen With Sufficient Local Knowledge")] 
		[XmlEnum("7")] 
		CitizenWithSufficientLocalKnowledge = 7,

		[System.ComponentModel.Description("A pilot service carried out by a citizen whose local knowledge is uncertain.")]
		[EnumMember(Value = "Citizen With Doubtful Local Knowledge")] 
		[XmlEnum("8")] 
		CitizenWithDoubtfulLocalKnowledge = 8,
	}

	/// <summary>
	/// The degree of reliability attributed to a position.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("The position(s) was(were) determined by the operation of making measurements for determining the relative position of points on, above or beneath the earth's surface. Survey implies a regular, controlled survey of any date.")]
		[EnumMember(Value = "Surveyed")] 
		[XmlEnum("1")] 
		Surveyed = 1,

		[System.ComponentModel.Description("Survey data is does not exist or is very poor.")]
		[EnumMember(Value = "Unsurveyed")] 
		[XmlEnum("2")] 
		Unsurveyed = 2,

		[System.ComponentModel.Description("Not surveyed to modern standards; or due to its age, scale, or positional or vertical uncertainties is not suitable to the type of navigation expected in the area.")]
		[EnumMember(Value = "Inadequately Surveyed")] 
		[XmlEnum("3")] 
		InadequatelySurveyed = 3,

		[System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to an object whose position does not remain fixed.")]
		[EnumMember(Value = "Approximate")] 
		[XmlEnum("4")] 
		Approximate = 4,

		[System.ComponentModel.Description("Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.")]
		[EnumMember(Value = "Position Doubtful")] 
		[XmlEnum("5")] 
		PositionDoubtful = 5,

		[System.ComponentModel.Description("A feature's position has been obtained from questionable or unreliable data.")]
		[EnumMember(Value = "Unreliable")] 
		[XmlEnum("6")] 
		Unreliable = 6,

		[System.ComponentModel.Description("An object whose position has been reported and its position confirmed by some means other than a formal survey such as an independent report of the same object.")]
		[EnumMember(Value = "Reported (Not Surveyed)")] 
		[XmlEnum("7")] 
		ReportedNotSurveyed = 7,

		[System.ComponentModel.Description("An object whose position has been reported and its position has not been confirmed.")]
		[EnumMember(Value = "Reported (Not Confirmed)")] 
		[XmlEnum("8")] 
		ReportedNotConfirmed = 8,

		[System.ComponentModel.Description("The most probable position of an object determined from incomplete data or data of questionable accuracy.")]
		[EnumMember(Value = "Estimated")] 
		[XmlEnum("9")] 
		Estimated = 9,

		[System.ComponentModel.Description("A position that is of a known value, such as the position of an anchor berth or other defined object.")]
		[EnumMember(Value = "Precisely Known")] 
		[XmlEnum("10")] 
		PreciselyKnown = 10,

		[System.ComponentModel.Description("A position that is computed from data.")]
		[EnumMember(Value = "Calculated")] 
		[XmlEnum("11")] 
		Calculated = 11,
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

		[System.ComponentModel.Description("An area in which swimming is prohibited.")]
		[EnumMember(Value = "Swimming Prohibited")] 
		[XmlEnum("39")] 
		SwimmingProhibited = 39,
	}

	/// <summary>
	/// The tendency of water level to change in a particular direction.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum waterLevelTrend : int {
		[System.ComponentModel.Description("Becoming smaller in magnitude.")]
		[EnumMember(Value = "Decreasing")] 
		[XmlEnum("1")] 
		Decreasing = 1,

		[System.ComponentModel.Description("Becoming larger in magnitude.")]
		[EnumMember(Value = "Increasing")] 
		[XmlEnum("2")] 
		Increasing = 2,

		[System.ComponentModel.Description("Constant.")]
		[EnumMember(Value = "Steady")] 
		[XmlEnum("3")] 
		Steady = 3,
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

		[System.ComponentModel.Description("Lit by floodlights, strip lights, etc.")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

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

		[System.ComponentModel.Description("Marked by buoys.")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,
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
	/// The anchor point of a text string.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum textJustification : int {
		[System.ComponentModel.Description("Of, relating to, or located on or near the side of a person or thing that is turned toward the west when the subject is facing north (opposed to right).")]
		[EnumMember(Value = "Left")] 
		[XmlEnum("1")] 
		Left = 1,

		[System.ComponentModel.Description("Equidistant from all bordering or adjacent areas; situated in the centre.")]
		[EnumMember(Value = "Centred")] 
		[XmlEnum("2")] 
		Centred = 2,

		[System.ComponentModel.Description("Of, relating to, or located on or near the side of a person or thing that is turned toward the east when the subject is facing north (opposed to left).")]
		[EnumMember(Value = "Right")] 
		[XmlEnum("3")] 
		Right = 3,
	}

	/// <summary>
	/// The attribute from which a text string is derived.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum textType : int {
		[System.ComponentModel.Description("The individual name of a feature.")]
		[EnumMember(Value = "Name")] 
		[XmlEnum("1")] 
		Name = 1,
	}

	/// <summary>
	/// Direction of vessels passing a reference point.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum trafficFlow : int {
		[System.ComponentModel.Description("Traffic flow in a general direction toward a port or similar destination.")]
		[EnumMember(Value = "Inbound")] 
		[XmlEnum("1")] 
		Inbound = 1,

		[System.ComponentModel.Description("Traffic flow in a general direction away from a port or similar point of origin.")]
		[EnumMember(Value = "Outbound")] 
		[XmlEnum("2")] 
		Outbound = 2,

		[System.ComponentModel.Description("Traffic flow in one general direction only.")]
		[EnumMember(Value = "One-Way")] 
		[XmlEnum("3")] 
		OneWay = 3,

		[System.ComponentModel.Description("Traffic flow in two generally opposite directions.")]
		[EnumMember(Value = "Two-Way")] 
		[XmlEnum("4")] 
		TwoWay = 4,
	}

	/// <summary>
	/// Characteristics of vessels.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("The maximum length of the ship.")]
		[EnumMember(Value = "Length Overall")] 
		[XmlEnum("1")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("The ship's length measured at the waterline.")]
		[EnumMember(Value = "Length at Waterline")] 
		[XmlEnum("2")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("The width or beam of the vessel.")]
		[EnumMember(Value = "Breadth")] 
		[XmlEnum("3")] 
		Breadth = 3,

		[System.ComponentModel.Description("The depth of water necessary to float a vessel fully loaded.")]
		[EnumMember(Value = "Draught")] 
		[XmlEnum("4")] 
		Draught = 4,

		[System.ComponentModel.Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement.")]
		[EnumMember(Value = "Displacement Tonnage")] 
		[XmlEnum("6")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level.")]
		[EnumMember(Value = "Displacement Tonnage, Light")] 
		[XmlEnum("7")] 
		DisplacementTonnageLight = 7,

		[System.ComponentModel.Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft.")]
		[EnumMember(Value = "Displacement Tonnage, Loaded")] 
		[XmlEnum("8")] 
		DisplacementTonnageLoaded = 8,

		[System.ComponentModel.Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity.")]
		[EnumMember(Value = "Deadweight Tonnage")] 
		[XmlEnum("9")] 
		DeadweightTonnage = 9,

		[System.ComponentModel.Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.")]
		[EnumMember(Value = "Gross Tonnage")] 
		[XmlEnum("10")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.")]
		[EnumMember(Value = "Net Tonnage")] 
		[XmlEnum("11")] 
		NetTonnage = 11,

		[System.ComponentModel.Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net Tonnage")] 
		[XmlEnum("12")] 
		PanamaCanalUniversalMeasurementSystemNetTonnage = 12,

		[System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("13")] 
		SuezCanalNetTonnage = 13,
	}

	/// <summary>
	/// The unit used for vessel characteristics attribute.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("The basic unit of length in the International System of Units (SI) system.")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[System.ComponentModel.Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.")]
		[EnumMember(Value = "Metric Ton")] 
		[XmlEnum("3")] 
		MetricTon = 3,

		[System.ComponentModel.Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
		[EnumMember(Value = "Ton")] 
		[XmlEnum("4")] 
		Ton = 4,

		[System.ComponentModel.Description("A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
		[EnumMember(Value = "Short Ton")] 
		[XmlEnum("5")] 
		ShortTon = 5,

		[System.ComponentModel.Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
		[EnumMember(Value = "Gross Ton")] 
		[XmlEnum("6")] 
		GrossTon = 6,

		[System.ComponentModel.Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
		[EnumMember(Value = "Net Ton")] 
		[XmlEnum("7")] 
		NetTon = 7,

		[System.ComponentModel.Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("9")] 
		SuezCanalNetTonnage = 9,
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

	/// <summary>
	/// Classification of vessels by function or use.
	/// </summary>
	[System.Serializable()]
	public class categoryOfVessel
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	public static class CodeList
	{
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

		public static ImmutableArray<categoryOfVessel> categoryOfVessels => ImmutableArray.Create<categoryOfVessel>(new categoryOfVessel[]{
			new() {
				code = 1,
				definition = "A vessel which is designed for carrying general cargo, e.g. boxes, sacks.",
				label = "General Cargo Vessel",
			},
			new() {
				code = 2,
				definition = "A vessel designed to carry ISO containers.",
				label = "Container Carrier",
			},
			new() {
				code = 3,
				definition = "A vessel which is designed for carrying liquid goods, for example oil or water.",
				label = "Tanker",
			},
			new() {
				code = 4,
				definition = "A vessel which is designed for carrying bulk goods, e.g. coal, ore or grain.",
				label = "Bulk Carrier",
			},
			new() {
				code = 5,
				definition = "A day trip or cabin vessel constructed and equipped to carry more than 12 passengers.",
				label = "Passenger Vessel",
			},
			new() {
				code = 6,
				definition = "A vessel designed to allow road vehicles to be driven on and off; often a ferry.",
				label = "Roll-On Roll-Off",
			},
			new() {
				code = 7,
				definition = "A vessel designed to carry refrigerated cargo.",
				label = "Refrigerated Cargo Vessel",
			},
			new() {
				code = 8,
				definition = "A vessel that is used and equipped for the fishing of living aquatic resources.",
				label = "Fishing Vessel",
			},
			new() {
				code = 9,
				definition = "A vessel which provides a service such as a tug, anchor handler, survey or supply vessel.",
				label = "Service",
			},
			new() {
				code = 10,
				definition = "A vessel designed for the conduct of military operations.",
				label = "Warship",
			},
			new() {
				code = 11,
				definition = "Either a tug and tow, or any combination of a tug providing propulsion to barges or vessels secured ahead or alongside.",
				label = "Towed or Pushed Composite Unit",
			},
			new() {
				code = 12,
				definition = "A combination of tug(s) and non-powered tow(s).",
				label = "Tug and Tow",
			},
			new() {
				code = 13,
				definition = "A pleasure boat or watercraft, or an excursion vessel used for short cruises such as whale watching.",
				label = "Light Recreational",
			},
			new() {
				code = 14,
				definition = "An installation which is designed to float at all times and which is normally anchored in position when deployed in the offshore gas and oil industry.",
				label = "Semi-Submersible Offshore Installation",
			},
			new() {
				code = 15,
				definition = "An exploration or project installation with legs which can be raised and lowered. The legs are raised when the installation is re-positioned. When stationary the legs are lowered to the sea floor and the working platform is raised clear of the sea surface.",
				label = "Jack-Up Exploration or Project Installation",
			},
			new() {
				code = 16,
				definition = "A vessel designed to carry large quantities of live animals.",
				label = "Livestock Carrier",
			},
			new() {
				code = 17,
				definition = "A vessel used in fishing for pleasure or competition.",
				label = "Sport Fishing",
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
			public List<String> deliveryPoint {get;set;} = [];

			public bool ShouldSerializedeliveryPoint() { return deliveryPoint.Any(); }

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
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

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
			[XmlElement("dateEnd")]
			public String? dateEnd {get;set;} = default;

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }

			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }
		}

		/// <summary>
		/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			[XmlElement("frequencyShoreStationTransmits")]
			public List<int> frequencyShoreStationTransmits {get;set;} = [];

			public bool ShouldSerializefrequencyShoreStationTransmits() { return frequencyShoreStationTransmits.Any(); }

			[XmlElement("frequencyShoreStationReceives")]
			public List<int> frequencyShoreStationReceives {get;set;} = [];

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.Any(); }

			[XmlElement("contactInstructions")]
			public List<String> contactInstructions {get;set;} = [];

			public bool ShouldSerializecontactInstructions() { return contactInstructions.Any(); }
		}

		/// <summary>
		/// The best estimate of the accuracy of a position.
		/// </summary>
		/// <remarks>
		/// The expected input is the maximum of the two-dimensional error. The error is assumed to be positive and negative.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty {
			[XmlElement("uncertaintyFixed")]
			public decimal uncertaintyFixed {get;set;} = default;
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
		/// Span of time, prior to the time the service is needed, for preparations to be made to fulfill the requirement.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class noticeTime {
			[XmlElement("noticeTimeHours")]
			public List<decimal> noticeTimeHours {get;set;} = [];

			public bool ShouldSerializenoticeTimeHours() { return noticeTimeHours.Any(); }

			[XmlElement("noticeTimeText")]
			public String? noticeTimeText {get;set;} = default;

			public bool ShouldSerializenoticeTimeText() { return !string.IsNullOrEmpty(noticeTimeText); }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public operation? operation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("operation")]
			public SerializableEnumeration<operation>? operationElement { get { return operation; } set { } }

			public bool ShouldSerializeoperation() { return operation.HasValue; }
		}

		/// <summary>
		/// Information about online sources from which a resource or data can be obtained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("linkage")]
			public String linkage {get;set;} = string.Empty;

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

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public onlineFunction? onlineFunction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("onlineFunction")]
			public SerializableEnumeration<onlineFunction>? onlineFunctionElement { get { return onlineFunction; } set { } }

			public bool ShouldSerializeonlineFunction() { return onlineFunction.HasValue; }

			[XmlElement("protocolRequest")]
			public String? protocolRequest {get;set;} = default;

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }
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
		/// <remarks>
		/// The sub-attributes date start and date end should be encoded using 4 digits for the calendar year (YYYY), 2 digits for the month (MM) (for example April = 04) and 2 digits for the day (DD). When no specific year is required (that is, the feature is removed at the same time each year) the following two cases may be considered: - same day each year: ----MMDD - same month each year: ----MM-- This conforms to ISO 8601:2004.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[XmlElement("dateEnd")]
			public String dateEnd {get;set;} = string.Empty;

			[XmlElement("dateStart")]
			public String dateStart {get;set;} = string.Empty;
		}

		/// <summary>
		/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rxNCode {
			[XmlElement("categoryOfRxN")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			public bool ShouldSerializecategoryOfRxN() { return categoryOfRxN != default; }

			[XmlElement("actionOrActivity")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			public bool ShouldSerializeactionOrActivity() { return actionOrActivity != default; }

			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }
		}

		/// <summary>
		/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIndication {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }
		}

		/// <summary>
		/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surveyDateRange {
			[XmlElement("dateEnd")]
			public String dateEnd {get;set;} = string.Empty;

			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }
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

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }
		}

		/// <summary>
		/// The regular weekly operation times of a service or schedule.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalsByDayOfWeek {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			[Upper(7)]
			public List<dayOfWeek> dayOfWeek {get;set;} = [];

			[JsonIgnore]
			[XmlElement("dayOfWeek")]
			public SerializableEnumeration<dayOfWeek>[] dayOfWeekElement { get { return [.. dayOfWeek]; } set { } }

			public bool ShouldSerializedayOfWeek() { return dayOfWeek.Any(); }

			[XmlElement("dayOfWeekIsRange")]
			public Boolean? dayOfWeekIsRange {get;set;} = default;

			public bool ShouldSerializedayOfWeekIsRange() { return dayOfWeekIsRange.HasValue; }

			[XmlElement("timeOfDayStart")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayStart {get;set;} = [];

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.Any(); }

			[XmlElement("timeOfDayEnd")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayEnd {get;set;} = [];

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.Any(); }
		}

		/// <summary>
		/// 	A fixed figure, or a figure derived by calculation, which is added to draught in order to maintain the minimum under keel clearance taking into account the vessel's static and dynamic characteristics, sea state and weather forecast, the reliability of the chart and variance from predicted height of tide or water level.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class underKeelAllowance {
			[XmlElement("underKeelAllowanceFixed")]
			public decimal? underKeelAllowanceFixed {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowanceFixed() { return underKeelAllowanceFixed.HasValue; }

			[XmlElement("underKeelAllowanceVariableBeamBased")]
			public decimal? underKeelAllowanceVariableBeamBased {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowanceVariableBeamBased() { return underKeelAllowanceVariableBeamBased.HasValue; }

			[XmlElement("underKeelAllowanceVariableDraughtBased")]
			public decimal? underKeelAllowanceVariableDraughtBased {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowanceVariableDraughtBased() { return underKeelAllowanceVariableDraughtBased.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public operation? operation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("operation")]
			public SerializableEnumeration<operation>? operationElement { get { return operation; } set { } }

			public bool ShouldSerializeoperation() { return operation.HasValue; }
		}

		/// <summary>
		/// Values, discovered by measuring, that correspond to vessels characteristics.
		/// </summary>
		/// <remarks>
		/// Combines (i) specifications of vessels' measurable characteristics (length, beam, tonnages, etc.), (ii) limit values for the specified characteristics (with units), (iii) arithmetical comparison operators (greater than, etc.), and (iv) logical operators (AND/OR) to define a subset of vessels characterized by the specified ranges. For example, the combination (draught, 10.5, metres, greaterThan) describes "vessels with draught greater than 10.5 metres".
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselsMeasurements {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public comparisonOperator comparisonOperator {get;set;}

			[JsonIgnore]
			[XmlElement("comparisonOperator")]
			public SerializableEnumeration<comparisonOperator> comparisonOperatorElement { get { return comparisonOperator; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public vesselsCharacteristics vesselsCharacteristics {get;set;}

			[JsonIgnore]
			[XmlElement("vesselsCharacteristics")]
			public SerializableEnumeration<vesselsCharacteristics> vesselsCharacteristicsElement { get { return vesselsCharacteristics; } set { } }

			[XmlElement("vesselsCharacteristicsValue")]
			public decimal vesselsCharacteristicsValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;}

			[JsonIgnore]
			[XmlElement("vesselsCharacteristicsUnit")]
			public SerializableEnumeration<vesselsCharacteristicsUnit> vesselsCharacteristicsUnitElement { get { return vesselsCharacteristicsUnit; } set { } }
		}

		/// <summary>
		/// A bearing is the direction one object is from another object.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public cardinalDirection? cardinalDirection {get;set;} = default;

			[JsonIgnore]
			[XmlElement("cardinalDirection")]
			public SerializableEnumeration<cardinalDirection>? cardinalDirectionElement { get { return cardinalDirection; } set { } }

			public bool ShouldSerializecardinalDirection() { return cardinalDirection.HasValue; }

			[XmlElement("distance")]
			public decimal? distance {get;set;} = default;

			public bool ShouldSerializedistance() { return distance.HasValue; }

			[XmlElement("sectorBearing")]
			[Upper(2)]
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
			[Lower(1)]
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
			[Lower(1)]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }
		}

		/// <summary>
		/// Detailed radiocommunications description with channels, frequencies, preferences and time schedules.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class radiocommunications {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19])]
			public List<categoryOfMaritimeBroadcast> categoryOfMaritimeBroadcast {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfMaritimeBroadcast")]
			public SerializableEnumeration<categoryOfMaritimeBroadcast>[] categoryOfMaritimeBroadcastElement { get { return [.. categoryOfMaritimeBroadcast]; } set { } }

			public bool ShouldSerializecategoryOfMaritimeBroadcast() { return categoryOfMaritimeBroadcast.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20])]
			public List<categoryOfRadioMethods> categoryOfRadioMethods {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRadioMethods")]
			public SerializableEnumeration<categoryOfRadioMethods>[] categoryOfRadioMethodsElement { get { return [.. categoryOfRadioMethods]; } set { } }

			public bool ShouldSerializecategoryOfRadioMethods() { return categoryOfRadioMethods.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("signalFrequency")]
			public List<int> signalFrequency {get;set;} = [];

			public bool ShouldSerializesignalFrequency() { return signalFrequency.Any(); }

			[XmlElement("transmissionContent")]
			public String? transmissionContent {get;set;} = default;

			public bool ShouldSerializetransmissionContent() { return !string.IsNullOrEmpty(transmissionContent); }

			[XmlElement("timeIntervalsByDayOfWeek")]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }
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

			[XmlElement("telecommunicationIdentifier")]
			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlElement("telecommunicationCarrier")]
			public String? telecommunicationCarrier {get;set;} = default;

			public bool ShouldSerializetelecommunicationCarrier() { return !string.IsNullOrEmpty(telecommunicationCarrier); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("telecommunicationService")]
			public SerializableEnumeration<telecommunicationService>[] telecommunicationServiceElement { get { return [.. telecommunicationService]; } set { } }

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.Any(); }

			[XmlElement("scheduleByDayOfWeek")]
			public scheduleByDayOfWeek? scheduleByDayOfWeek {get;set;} = default;

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek!=default; }
		}

	}
	public enum Role {
		[System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
		componentOf,
		[System.ComponentModel.Description("A pointer to a part in a whole-part relationship.")]
		consistsOf,
		[System.ComponentModel.Description("The applicable regulation, restriction, recommendation or nautical information")]
		theApplicableRxN,
		[System.ComponentModel.Description("The location in which the information item applies")]
		appliesInLocation,
		[System.ComponentModel.Description("A pointer to an Authority object")]
		theAuthority,
		[System.ComponentModel.Description("The authority for which service hours are given")]
		theAuthority_srvHrs,
		[System.ComponentModel.Description("A pointer to an Contact Details object")]
		theContactDetails,
		[System.ComponentModel.Description("The controlling organization or authority for a geographically located service")]
		controlAuthority,
		[System.ComponentModel.Description("The service controlled by an organisation or authority")]
		controlledService,
		[System.ComponentModel.Description("A pointer to a specific spatial type(s).")]
		definedFor,
		[System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
		defines,
		[System.ComponentModel.Description("A pointer to a specific feature(s).")]
		identifies,
		[System.ComponentModel.Description("A pointer to a specific feature(s) for which further information is required.")]
		informationProvidedFor,
		[System.ComponentModel.Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
		isApplicableTo,
		[System.ComponentModel.Description("The location for which service hours are given")]
		location_srvHrs,
		[System.ComponentModel.Description("The information")]
		theInformation,
		[System.ComponentModel.Description("The organisation to which information relates")]
		theOrganisation,
		[System.ComponentModel.Description("The work hours for a non-standard workday")]
		partialWorkingDay,
		[System.ComponentModel.Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
		permission,
		[System.ComponentModel.Description("The class (generally, qualifying vessels) which must file the report")]
		mustBeFiledBy,
		[System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
		positions,
		[System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
		providesInformation,
		[System.ComponentModel.Description("The feature pertaining to a report")]
		reptForLocation,
		[System.ComponentModel.Description("The organisation or place to which a report is sent.")]
		reportTo,
		[System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
		theRxN,
		[System.ComponentModel.Description("Service hours for an authority or service provider")]
		theServiceHours,
		[System.ComponentModel.Description("The usual service hours to which an exception applies")]
		theServiceHours_nsdy,
		[System.ComponentModel.Description("Pointer to service or facility")]
		servicePlace,
		[System.ComponentModel.Description("The area served by a service provider")]
		serviceArea,
		[System.ComponentModel.Description("Pointer to a feature from where a provider supplies a service")]
		serviceProvider,
		[System.ComponentModel.Description("The report to be filed by a vessel")]
		theShipReport,
		[System.ComponentModel.Description("The report for a traffic service")]
		reptForTrafficServ,
		[System.ComponentModel.Description("The location to which the permission statement applies")]
		vslLocation,
	}

	namespace InformationAssociations {
		/// <summary>
		/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AdditionalInformation : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AdditionalInformation);
		}

		/// <summary>
		/// Contact information for an authority
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityContact : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AuthorityContact);
		}

		/// <summary>
		/// Service hours for an authority
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityHours : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AuthorityHours);
		}

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
		/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InclusionType : InformationAssociation {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			public membership membership {get;set;}

			[JsonIgnore]
			[XmlElement("membership")]
			public SerializableEnumeration<membership> membershipElement { get { return membership; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InclusionType);
		}

		/// <summary>
		/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PermissionType : InformationAssociation {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public categoryOfRelationship categoryOfRelationship {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfRelationship")]
			public SerializableEnumeration<categoryOfRelationship> categoryOfRelationshipElement { get { return categoryOfRelationship; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PermissionType);
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
		/// The authority with which a report must be filed
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ReportingAuthority : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ReportingAuthority);
		}

		/// <summary>
		/// Association between types of reports and classes of vessels which must file report of the type described
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ReportingRequirement : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ReportingRequirement);
		}

		/// <summary>
		/// Contact details for a service or facility
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceContact : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceContact);
		}

		/// <summary>
		/// Association between a geographically located service and the organisation that controls it
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceControl : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceControl);
		}

		/// <summary>
		/// Association for linking spatial quality to spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialAssociation : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpatialAssociation);
		}

		/// <summary>
		/// Working hours for a service or facility described by a geographic location
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocationHours : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LocationHours);
		}

		/// <summary>
		/// Association between traffic control service and reports required of vessels pertaining to that area
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficServiceReport : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TrafficServiceReport);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// Association linking the location from which a service is provided and the area(s) served.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceProvisionArea : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceProvisionArea);
		}

		/// <summary>
		/// A feature association for the binding between a pilotage district and its component pilot boarding places.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotageDistrictAssociation : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PilotageDistrictAssociation);
		}

		/// <summary>
		/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextAssociation : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TextAssociation);
		}

		/// <summary>
		/// A feature association for the binding between a traffic control service and auxiliary features.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficControlServiceAggregation : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TrafficControlServiceAggregation);
		}
	}

}

namespace S100Framework.DomainModel.S127 {
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
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIndication")]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InformationType);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationType._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.providesInformation)!,
					informationTypes = [nameof(NauticalInformation)],
					primitives = [],
				},
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
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[XmlElement("graphic")]
			public List<graphic> graphic {get;set;} = [];

			public bool ShouldSerializegraphic() { return graphic.Any(); }

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
					association = nameof(InclusionType),
					role = Enum.GetName<Role>(Role.isApplicableTo)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theOrganisation)!,
					informationTypes = [nameof(AbstractRxN)],
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
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(InclusionType),
					role = Enum.GetName<Role>(Role.theApplicableRxN)!,
					informationTypes = [nameof(AbstractRxN)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ReportingRequirement),
					role = Enum.GetName<Role>(Role.theShipReport)!,
					informationTypes = [nameof(ShipReport)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PermissionType),
					role = Enum.GetName<Role>(Role.vslLocation)!,
					informationTypes = [nameof(InformationType)],
					primitives = [],
				},
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
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public categoryOfAuthority categoryOfAuthority {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority> categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

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
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ReportingAuthority),
					role = Enum.GetName<Role>(Role.theShipReport)!,
					informationTypes = [nameof(ShipReport)],
					primitives = [],
				},
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
		public partial class ContactDetails : InformationType {
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

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("radiocommunications")]
			public List<radiocommunications> radiocommunications {get;set;} = [];

			public bool ShouldSerializeradiocommunications() { return radiocommunications.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ContactDetails._informationBindingDefinitions];
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
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.informationProvidedFor)!,
					informationTypes = [nameof(InformationType)],
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
			[Lower(1)]
			public List<scheduleByDayOfWeek> scheduleByDayOfWeek {get;set;} = [];

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
					association = nameof(ExceptionalWorkday),
					role = Enum.GetName<Role>(Role.partialWorkingDay)!,
					informationTypes = [nameof(NonStandardWorkingDay)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theAuthority_srvHrs)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Description of how a ship should report to a maritime authority, including when to report, what to report and whether the format conforms to the IMO standard.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShipReport : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Lower(1)]
			public List<categoryOfShipReport> categoryOfShipReport {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfShipReport")]
			public SerializableEnumeration<categoryOfShipReport>[] categoryOfShipReportElement { get { return [.. categoryOfShipReport]; } set { } }

			public bool ShouldSerializecategoryOfShipReport() { return categoryOfShipReport.Any(); }

			[XmlElement("iMOFormatForReporting")]
			public Boolean iMOFormatForReporting {get;set;} = false;

			[XmlElement("noticeTime")]
			[Lower(1)]
			public List<noticeTime> noticeTime {get;set;} = [];

			public bool ShouldSerializenoticeTime() { return noticeTime.Any(); }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShipReport);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ShipReport._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ReportingRequirement),
					role = Enum.GetName<Role>(Role.mustBeFiledBy)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ReportingAuthority),
					role = Enum.GetName<Role>(Role.reportTo)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
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
		/// The indication of the quality of the locational information for features in a dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,4,5])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation>? categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }

			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfHorizontalMeasurement")]
			public SerializableEnumeration<qualityOfHorizontalMeasurement>? qualityOfHorizontalMeasurementElement { get { return qualityOfHorizontalMeasurement; } set { } }

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpatialQuality);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Spatial quality points.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQualityPoints : SpatialQuality {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpatialQualityPoints);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SpatialQuality._informationBindingDefinitions, ..SpatialQualityPoints._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
		/// Generalized feature type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FeatureType : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

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
					association = nameof(PermissionType),
					role = Enum.GetName<Role>(Role.permission)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
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
					association = nameof(AdditionalInformation),
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
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.positions)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		/// <summary>
		/// A feature often associated with contact information for an organization that exercises a management role or offers a service in the location.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class OrganizationContactArea : FeatureType {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(OrganizationContactArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..OrganizationContactArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..OrganizationContactArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..OrganizationContactArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A location which may be supervised by a responsible or controlling authority.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class SupervisedArea : OrganizationContactArea {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SupervisedArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..SupervisedArea._informationBindingDefinitions];
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
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..SupervisedArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..SupervisedArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A service feature generally involving one or more reports from the requester, including communications not strictly considered "reporting".
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class ReportableServiceArea : SupervisedArea {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ReportableServiceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..ReportableServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficServiceReport),
					role = Enum.GetName<Role>(Role.reptForTrafficServ)!,
					informationTypes = [nameof(ShipReport)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..ReportableServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..ReportableServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CautionArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,3,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([5,7])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CautionArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..CautionArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..CautionArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..CautionArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
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
		/// An area where hazards, caused by concentrations of shipping, may occur. Hazards are risks to shipping, which stem from sources other than shoal water or obstructions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConcentrationOfShippingHazardArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public List<categoryOfConcentrationOfShippingHazardArea> categoryOfConcentrationOfShippingHazardArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfConcentrationOfShippingHazardArea")]
			public SerializableEnumeration<categoryOfConcentrationOfShippingHazardArea>[] categoryOfConcentrationOfShippingHazardAreaElement { get { return [.. categoryOfConcentrationOfShippingHazardArea]; } set { } }

			public bool ShouldSerializecategoryOfConcentrationOfShippingHazardArea() { return categoryOfConcentrationOfShippingHazardArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ConcentrationOfShippingHazardArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..ConcentrationOfShippingHazardArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..ConcentrationOfShippingHazardArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..ConcentrationOfShippingHazardArea._primitives];
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
		/// The area to which an International Ship and Port Facility Security (ISPS) level applies. The ISPS Code is a comprehensive set of measures to enhance the security of ships and port facilities, developed in response to the perceived threats to ships and port facilities in the wake of the 9/11 attacks in the United States.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ISPSCodeSecurityLevel : OrganizationContactArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public iSPSLevel iSPSLevel {get;set;}

			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel> iSPSLevelElement { get { return iSPSLevel; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ISPSCodeSecurityLevel);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..ISPSCodeSecurityLevel._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..ISPSCodeSecurityLevel._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..ISPSCodeSecurityLevel._primitives];
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
		/// A service established to provide port information without interaction between the customer and the service provider. This information could be inter alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocalPortServiceArea : ReportableServiceArea {
			[XmlElement("serviceAccessProcedure")]
			public String? serviceAccessProcedure {get;set;} = default;

			public bool ShouldSerializeserviceAccessProcedure() { return !string.IsNullOrEmpty(serviceAccessProcedure); }

			[XmlElement("requirementsForMaintenanceOfListeningWatch")]
			public String requirementsForMaintenanceOfListeningWatch {get;set;} = string.Empty;

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LocalPortServiceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..LocalPortServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..LocalPortServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..LocalPortServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadioCallingInPoint)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadarRange)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationTraffic)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area within which naval, military or aerial exercises are carried out. Also called an 'exercise area'.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MilitaryPracticeArea : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6])]
			public List<categoryOfMilitaryPracticeArea> categoryOfMilitaryPracticeArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfMilitaryPracticeArea")]
			public SerializableEnumeration<categoryOfMilitaryPracticeArea>[] categoryOfMilitaryPracticeAreaElement { get { return [.. categoryOfMilitaryPracticeArea]; } set { } }

			public bool ShouldSerializecategoryOfMilitaryPracticeArea() { return categoryOfMilitaryPracticeArea.Any(); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,6,7,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MilitaryPracticeArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..MilitaryPracticeArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..MilitaryPracticeArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..MilitaryPracticeArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
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
		/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotBoardingPlace : OrganizationContactArea {
			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfPilotBoardingPlace? categoryOfPilotBoardingPlace {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfPilotBoardingPlace")]
			public SerializableEnumeration<categoryOfPilotBoardingPlace>? categoryOfPilotBoardingPlaceElement { get { return categoryOfPilotBoardingPlace; } set { } }

			public bool ShouldSerializecategoryOfPilotBoardingPlace() { return categoryOfPilotBoardingPlace.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfPreference? categoryOfPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfPreference")]
			public SerializableEnumeration<categoryOfPreference>? categoryOfPreferenceElement { get { return categoryOfPreference; } set { } }

			public bool ShouldSerializecategoryOfPreference() { return categoryOfPreference.HasValue; }

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public categoryOfVessel? categoryOfVessel {get;set;} = default;

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel != default; }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("destination")]
			public String? destination {get;set;} = default;

			public bool ShouldSerializedestination() { return !string.IsNullOrEmpty(destination); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public pilotMovement? pilotMovement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("pilotMovement")]
			public SerializableEnumeration<pilotMovement>? pilotMovementElement { get { return pilotMovement; } set { } }

			public bool ShouldSerializepilotMovement() { return pilotMovement.HasValue; }

			[XmlElement("pilotVessel")]
			public String? pilotVessel {get;set;} = default;

			public bool ShouldSerializepilotVessel() { return !string.IsNullOrEmpty(pilotVessel); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,6,9,16,17,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PilotBoardingPlace);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..PilotBoardingPlace._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..PilotBoardingPlace._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..PilotBoardingPlace._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(PilotageDistrictAssociation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(PilotageDistrict)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(PilotService)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The service provided by a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotService : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public List<categoryOfPilot> categoryOfPilot {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfPilot")]
			public SerializableEnumeration<categoryOfPilot>[] categoryOfPilotElement { get { return [.. categoryOfPilot]; } set { } }

			public bool ShouldSerializecategoryOfPilot() { return categoryOfPilot.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public pilotQualification? pilotQualification {get;set;} = default;

			[JsonIgnore]
			[XmlElement("pilotQualification")]
			public SerializableEnumeration<pilotQualification>? pilotQualificationElement { get { return pilotQualification; } set { } }

			public bool ShouldSerializepilotQualification() { return pilotQualification.HasValue; }

			[XmlElement("pilotRequest")]
			public String? pilotRequest {get;set;} = default;

			public bool ShouldSerializepilotRequest() { return !string.IsNullOrEmpty(pilotRequest); }

			[XmlElement("remotePilot")]
			public Boolean remotePilot {get;set;} = false;

			[XmlElement("noticeTime")]
			public noticeTime? noticeTime {get;set;} = default;

			public bool ShouldSerializenoticeTime() { return noticeTime!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PilotService);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..PilotService._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..PilotService._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..PilotService._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceArea)!,
					featureTypes = [nameof(PilotageDistrict)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceArea)!,
					featureTypes = [nameof(PilotBoardingPlace)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area within which a pilotage direction exists. Such directions are regulated by a competent harbour authority which dictates circumstances under which they apply.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotageDistrict : FeatureType {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PilotageDistrict);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..PilotageDistrict._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..PilotageDistrict._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..PilotageDistrict._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  default,
					association = nameof(PilotageDistrictAssociation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(PilotBoardingPlace)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(PilotService)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area where there is a raised risk of piracy or armed robbery.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PiracyRiskArea : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,14,18,19,20,21,24,25,26,27,31,32,33,34])]
			[Lower(1)]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PiracyRiskArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..PiracyRiskArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..PiracyRiskArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..PiracyRiskArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
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
		/// A place where a ship in need of assistance can take action to enable it to stabilize its condition and reduce the hazards to navigation, and to protect human life and the environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PlaceOfRefuge : ReportableServiceArea {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PlaceOfRefuge);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..PlaceOfRefuge._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..PlaceOfRefuge._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..PlaceOfRefuge._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
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
		/// Indicates the coverage of a sea area by a radar surveillance station. Inside this area a vessel may request shore-based radar assistance, particularly in poor visibility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarRange : FeatureType {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,7])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadarRange);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadarRange._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadarRange._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadarRange._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioCallingInPoint : FeatureType {
			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public List<categoryOfVessel> categoryOfVessel {get;set;} = [];

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel.Any(); }

			[XmlElement("orientationValue")]
			[Upper(2)]
			public List<decimal> orientationValue {get;set;} = [];

			public bool ShouldSerializeorientationValue() { return orientationValue.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,9])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public trafficFlow trafficFlow {get;set;}

			[JsonIgnore]
			[XmlElement("trafficFlow")]
			public SerializableEnumeration<trafficFlow> trafficFlowElement { get { return trafficFlow; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioCallingInPoint);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadioCallingInPoint._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadioCallingInPoint._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadioCallingInPoint._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.curve
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A specified area on land or water designated by an appropriate authority within which access or navigation is restricted in accordance with certain specified conditions. A navigational restricted area is an area where the restrictions have a direct impact on the navigation of a vessel in the area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedAreaNavigational : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,19,20,22,23,25,27,28,29,30,31,32])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,13,14,25,26,27,28,29,30,35,36,37])]
			[Lower(1)]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,9,18,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RestrictedAreaNavigational);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..RestrictedAreaNavigational._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..RestrictedAreaNavigational._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..RestrictedAreaNavigational._primitives];
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
		/// A specified area on land or water designated by an appropriate authority within which access or navigation is restricted in accordance with certain specified conditions. A regulatory restricted area is an area where the restrictions have no direct impact on the navigation of a vessel in the area, but impact on the activities that can take place within the area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedAreaRegulatory : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,19,20,22,23,25,27,28,29,30,31,32])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([3,4,5,6,9,10,11,12,15,16,17,18,19,20,21,22,23,24,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,9,18,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RestrictedAreaRegulatory);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..RestrictedAreaRegulatory._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..RestrictedAreaRegulatory._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..RestrictedAreaRegulatory._primitives];
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
		/// An area or line designating the limits or central line of a routeing measure (or part of a routeing measure). Routeing measures include traffic separation schemes, deep-water routes, two-way routes, archipelagic sea lanes, and fairway systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RouteingMeasure : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public categoryOfRouteingMeasure categoryOfRouteingMeasure {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfRouteingMeasure")]
			public SerializableEnumeration<categoryOfRouteingMeasure> categoryOfRouteingMeasureElement { get { return categoryOfRouteingMeasure; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfTrafficSeparationScheme? categoryOfTrafficSeparationScheme {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTrafficSeparationScheme")]
			public SerializableEnumeration<categoryOfTrafficSeparationScheme>? categoryOfTrafficSeparationSchemeElement { get { return categoryOfTrafficSeparationScheme; } set { } }

			public bool ShouldSerializecategoryOfTrafficSeparationScheme() { return categoryOfTrafficSeparationScheme.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfNavigationLine? categoryOfNavigationLine {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfNavigationLine")]
			public SerializableEnumeration<categoryOfNavigationLine>? categoryOfNavigationLineElement { get { return categoryOfNavigationLine; } set { } }

			public bool ShouldSerializecategoryOfNavigationLine() { return categoryOfNavigationLine.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RouteingMeasure);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RouteingMeasure._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RouteingMeasure._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RouteingMeasure._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.curve
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
		/// A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShipReportingServiceArea : ReportableServiceArea {
			[XmlElement("serviceAccessProcedure")]
			public String? serviceAccessProcedure {get;set;} = default;

			public bool ShouldSerializeserviceAccessProcedure() { return !string.IsNullOrEmpty(serviceAccessProcedure); }

			[XmlElement("requirementsForMaintenanceOfListeningWatch")]
			public String requirementsForMaintenanceOfListeningWatch {get;set;} = string.Empty;

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShipReportingServiceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..ShipReportingServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..ShipReportingServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..ShipReportingServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadioCallingInPoint)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadarRange)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationTraffic)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A warning signal station is a place on shore from which warning signals are made to ships at sea.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SignalStationWarning : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18])]
			[Lower(1)]
			public List<categoryOfSignalStationWarning> categoryOfSignalStationWarning {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfSignalStationWarning")]
			public SerializableEnumeration<categoryOfSignalStationWarning>[] categoryOfSignalStationWarningElement { get { return [.. categoryOfSignalStationWarning]; } set { } }

			public bool ShouldSerializecategoryOfSignalStationWarning() { return categoryOfSignalStationWarning.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,14,15,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SignalStationWarning);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..SignalStationWarning._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..SignalStationWarning._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..SignalStationWarning._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A traffic signal station is a place on shore from which signals are made to regulate the movement of traffic.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SignalStationTraffic : OrganizationContactArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,13])]
			[Lower(1)]
			public List<categoryOfSignalStationTraffic> categoryOfSignalStationTraffic {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfSignalStationTraffic")]
			public SerializableEnumeration<categoryOfSignalStationTraffic>[] categoryOfSignalStationTrafficElement { get { return [.. categoryOfSignalStationTraffic]; } set { } }

			public bool ShouldSerializecategoryOfSignalStationTraffic() { return categoryOfSignalStationTraffic.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,14,15,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SignalStationTraffic);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..SignalStationTraffic._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..SignalStationTraffic._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..SignalStationTraffic._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area for which an authority has stated under keel allowance requirements.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnderKeelClearanceAllowanceArea : FeatureType {
			[XmlElement("underKeelAllowance")]
			public underKeelAllowance? underKeelAllowance {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowance() { return underKeelAllowance!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public waterLevelTrend? waterLevelTrend {get;set;} = default;

			[JsonIgnore]
			[XmlElement("waterLevelTrend")]
			public SerializableEnumeration<waterLevelTrend>? waterLevelTrendElement { get { return waterLevelTrend; } set { } }

			public bool ShouldSerializewaterLevelTrend() { return waterLevelTrend.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(UnderKeelClearanceAllowanceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..UnderKeelClearanceAllowanceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..UnderKeelClearanceAllowanceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..UnderKeelClearanceAllowanceArea._primitives];
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
		/// An area for which an authority permits use of dynamic under keel clearance information or provides dynamic information related to under keel clearances.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnderKeelClearanceManagementArea : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public dynamicResource dynamicResource {get;set;}

			[JsonIgnore]
			[XmlElement("dynamicResource")]
			public SerializableEnumeration<dynamicResource> dynamicResourceElement { get { return dynamicResource; } set { } }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(UnderKeelClearanceManagementArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..UnderKeelClearanceManagementArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..UnderKeelClearanceManagementArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..UnderKeelClearanceManagementArea._primitives];
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
		/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VesselTrafficServiceArea : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public List<categoryOfVesselTrafficService> categoryOfVesselTrafficService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfVesselTrafficService")]
			public SerializableEnumeration<categoryOfVesselTrafficService>[] categoryOfVesselTrafficServiceElement { get { return [.. categoryOfVesselTrafficService]; } set { } }

			public bool ShouldSerializecategoryOfVesselTrafficService() { return categoryOfVesselTrafficService.Any(); }

			[XmlElement("serviceAccessProcedure")]
			public String? serviceAccessProcedure {get;set;} = default;

			public bool ShouldSerializeserviceAccessProcedure() { return !string.IsNullOrEmpty(serviceAccessProcedure); }

			[XmlElement("requirementsForMaintenanceOfListeningWatch")]
			public String requirementsForMaintenanceOfListeningWatch {get;set;} = string.Empty;

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(VesselTrafficServiceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..VesselTrafficServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..VesselTrafficServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..VesselTrafficServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadioCallingInPoint)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadarRange)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationTraffic)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area in which uniform general information of the waterway exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WaterwayArea : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public dynamicResource dynamicResource {get;set;}

			[JsonIgnore]
			[XmlElement("dynamicResource")]
			public SerializableEnumeration<dynamicResource> dynamicResourceElement { get { return dynamicResource; } set { } }

			[XmlElement("siltationRate")]
			public String? siltationRate {get;set;} = default;

			public bool ShouldSerializesiltationRate() { return !string.IsNullOrEmpty(siltationRate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(WaterwayArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..WaterwayArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..WaterwayArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..WaterwayArea._primitives];
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
		/// Abstract feature type for data quality meta-features.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class DataQuality : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DataQuality);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DataQuality._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DataQuality._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DataQuality._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// Abstract type for meta-feature which can describe temporal variation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class QualityOfTemporalVariation : DataQuality {
			[XmlIgnore]
			[EnumerationValue([1,4,5])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation>? categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }

			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(QualityOfTemporalVariation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..DataQuality._informationBindingDefinitions, ..QualityOfTemporalVariation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..DataQuality._featureBindingDefinitions, ..QualityOfTemporalVariation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..DataQuality._primitives, ..QualityOfTemporalVariation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A geographical area that describes the coverage and extent of spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("maximumDisplayScale")]
			public int maximumDisplayScale {get;set;} = default;

			[XmlElement("minimumDisplayScale")]
			public int minimumDisplayScale {get;set;} = default;

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
		/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : QualityOfTemporalVariation {
			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			[XmlElement("surveyDateRange")]
			public surveyDateRange? surveyDateRange {get;set;} = default;

			public bool ShouldSerializesurveyDateRange() { return surveyDateRange!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..QualityOfTemporalVariation._informationBindingDefinitions, ..QualityOfNonBathymetricData._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..QualityOfTemporalVariation._featureBindingDefinitions, ..QualityOfNonBathymetricData._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..QualityOfTemporalVariation._primitives, ..QualityOfNonBathymetricData._primitives];
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
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("flipBearing")]
			public decimal? flipBearing {get;set;} = default;

			public bool ShouldSerializeflipBearing() { return flipBearing.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public textJustification textJustification {get;set;}

			[JsonIgnore]
			[XmlElement("textJustification")]
			public SerializableEnumeration<textJustification> textJustificationElement { get { return textJustification; } set { } }

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }

			[XmlIgnore]
			[EnumerationValue([1])]
			public textType? textType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("textType")]
			public SerializableEnumeration<textType>? textTypeElement { get { return textType; } set { } }

			public bool ShouldSerializetextType() { return textType.HasValue; }

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
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.identifies)!,
					featureTypes = [nameof(FeatureType)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S127/2.0")]
	[XmlRoot(Namespace = "http://www.iho.int/S127/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S127/2.0 127_2.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S127/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.InformationType", typeof(InformationTypes.InformationType), Order = 1, ElementName = "InformationType")]
		[XmlElement("InformationTypes.AbstractRxN", typeof(InformationTypes.AbstractRxN), Order = 1, ElementName = "AbstractRxN")]
		[XmlElement("InformationTypes.Applicability", typeof(InformationTypes.Applicability), Order = 1, ElementName = "Applicability")]
		[XmlElement("InformationTypes.Authority", typeof(InformationTypes.Authority), Order = 1, ElementName = "Authority")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.NauticalInformation", typeof(InformationTypes.NauticalInformation), Order = 1, ElementName = "NauticalInformation")]
		[XmlElement("InformationTypes.NonStandardWorkingDay", typeof(InformationTypes.NonStandardWorkingDay), Order = 1, ElementName = "NonStandardWorkingDay")]
		[XmlElement("InformationTypes.ServiceHours", typeof(InformationTypes.ServiceHours), Order = 1, ElementName = "ServiceHours")]
		[XmlElement("InformationTypes.ShipReport", typeof(InformationTypes.ShipReport), Order = 1, ElementName = "ShipReport")]
		[XmlElement("InformationTypes.Recommendations", typeof(InformationTypes.Recommendations), Order = 1, ElementName = "Recommendations")]
		[XmlElement("InformationTypes.Regulations", typeof(InformationTypes.Regulations), Order = 1, ElementName = "Regulations")]
		[XmlElement("InformationTypes.Restrictions", typeof(InformationTypes.Restrictions), Order = 1, ElementName = "Restrictions")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("InformationTypes.SpatialQualityPoints", typeof(InformationTypes.SpatialQualityPoints), Order = 1, ElementName = "SpatialQualityPoints")]
		[XmlElement("FeatureTypes.CautionArea", typeof(FeatureTypes.CautionArea), Order = 1, ElementName = "CautionArea")]
		[XmlElement("FeatureTypes.ConcentrationOfShippingHazardArea", typeof(FeatureTypes.ConcentrationOfShippingHazardArea), Order = 1, ElementName = "ConcentrationOfShippingHazardArea")]
		[XmlElement("FeatureTypes.ISPSCodeSecurityLevel", typeof(FeatureTypes.ISPSCodeSecurityLevel), Order = 1, ElementName = "ISPSCodeSecurityLevel")]
		[XmlElement("FeatureTypes.LocalPortServiceArea", typeof(FeatureTypes.LocalPortServiceArea), Order = 1, ElementName = "LocalPortServiceArea")]
		[XmlElement("FeatureTypes.MilitaryPracticeArea", typeof(FeatureTypes.MilitaryPracticeArea), Order = 1, ElementName = "MilitaryPracticeArea")]
		[XmlElement("FeatureTypes.PilotBoardingPlace", typeof(FeatureTypes.PilotBoardingPlace), Order = 1, ElementName = "PilotBoardingPlace")]
		[XmlElement("FeatureTypes.PilotService", typeof(FeatureTypes.PilotService), Order = 1, ElementName = "PilotService")]
		[XmlElement("FeatureTypes.PilotageDistrict", typeof(FeatureTypes.PilotageDistrict), Order = 1, ElementName = "PilotageDistrict")]
		[XmlElement("FeatureTypes.PiracyRiskArea", typeof(FeatureTypes.PiracyRiskArea), Order = 1, ElementName = "PiracyRiskArea")]
		[XmlElement("FeatureTypes.PlaceOfRefuge", typeof(FeatureTypes.PlaceOfRefuge), Order = 1, ElementName = "PlaceOfRefuge")]
		[XmlElement("FeatureTypes.RadarRange", typeof(FeatureTypes.RadarRange), Order = 1, ElementName = "RadarRange")]
		[XmlElement("FeatureTypes.RadioCallingInPoint", typeof(FeatureTypes.RadioCallingInPoint), Order = 1, ElementName = "RadioCallingInPoint")]
		[XmlElement("FeatureTypes.RestrictedAreaNavigational", typeof(FeatureTypes.RestrictedAreaNavigational), Order = 1, ElementName = "RestrictedAreaNavigational")]
		[XmlElement("FeatureTypes.RestrictedAreaRegulatory", typeof(FeatureTypes.RestrictedAreaRegulatory), Order = 1, ElementName = "RestrictedAreaRegulatory")]
		[XmlElement("FeatureTypes.RouteingMeasure", typeof(FeatureTypes.RouteingMeasure), Order = 1, ElementName = "RouteingMeasure")]
		[XmlElement("FeatureTypes.ShipReportingServiceArea", typeof(FeatureTypes.ShipReportingServiceArea), Order = 1, ElementName = "ShipReportingServiceArea")]
		[XmlElement("FeatureTypes.SignalStationWarning", typeof(FeatureTypes.SignalStationWarning), Order = 1, ElementName = "SignalStationWarning")]
		[XmlElement("FeatureTypes.SignalStationTraffic", typeof(FeatureTypes.SignalStationTraffic), Order = 1, ElementName = "SignalStationTraffic")]
		[XmlElement("FeatureTypes.UnderKeelClearanceAllowanceArea", typeof(FeatureTypes.UnderKeelClearanceAllowanceArea), Order = 1, ElementName = "UnderKeelClearanceAllowanceArea")]
		[XmlElement("FeatureTypes.UnderKeelClearanceManagementArea", typeof(FeatureTypes.UnderKeelClearanceManagementArea), Order = 1, ElementName = "UnderKeelClearanceManagementArea")]
		[XmlElement("FeatureTypes.VesselTrafficServiceArea", typeof(FeatureTypes.VesselTrafficServiceArea), Order = 1, ElementName = "VesselTrafficServiceArea")]
		[XmlElement("FeatureTypes.WaterwayArea", typeof(FeatureTypes.WaterwayArea), Order = 1, ElementName = "WaterwayArea")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1, ElementName = "QualityOfNonBathymetricData")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
