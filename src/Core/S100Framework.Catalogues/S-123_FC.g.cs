using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S123 {
	public class Summary : ISummary
	{
		public static string Name => "Marine Radio Services";
		public static string Scope => "Global";
		public static string ProductId => "S-123";
		public static Version Version => new Version("1.1.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-01-25", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["areaA3ServiceDescription","bearingInformation","broadcastContent","contactAddress","coverageIndication","featureName","fixedDateRange","frequencyPair","frequencyRange","graphic","horizontalPositionUncertainty","information","onlineResource","orientation","periodicDateRange","radioChannelDetails","radiocommunicationIdentifier","rxNCode","scheduleByDayOfWeek","sectorLimit","sectorLimitOne","sectorLimitTwo","spatialAccuracy","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","timesOfTransmission","verticalUncertainty","vesselMeasurementsSpecification"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AssociatedRxN","AuthorityContact","AuthorityHours","AvailableQoS","BroadcastService","BroadcastTransmission","ConnectivityService","ExceptionalWorkday","InclusionType","LocationHours","PermissionType","RadioServiceControl","relatedOrganisation","ServiceContact","ServiceCoordination","SpatialAssociation","TransmissionService"];
		public static string[] FeatureAssociationTypes => ["coreAggregation","fuzzyZoneAggregation","ServiceProvisionArea","TextAssociation"];
		public static string[] InformationTypes => ["Applicability","Authority","BroadcastDetails","ConnectivityQualityOfService","ContactDetails","NauticalInformation","NonStandardWorkingDay","RadioControlCentre","Recommendations","Regulations","Restrictions","ServiceHours","SpatialQuality","TransmissionDetails"];
		public static string[] FeatureTypes => ["ConnectivitySubscriptionArea","GMDSSArea","IndeterminateZone","MetArea","NavArea","NavtexServiceArea","RadioServiceArea","RadioStation","WeatherForecastAndWarningArea","RadioServiceAreaAggregate","DataCoverage","QualityOfNonBathymetricData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType","FuzzyAreaAggregate","RadioServiceAreaAggregate"],
			Primitives.surface => ["ConnectivitySubscriptionArea","GMDSSArea","IndeterminateZone","MetArea","NavArea","NavtexServiceArea","RadioServiceArea","WeatherForecastAndWarningArea","DataCoverage","QualityOfNonBathymetricData"],
			Primitives.point => ["ConnectivitySubscriptionArea","RadioStation","TextPlacement"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [Primitives.noGeometry],
			"ConnectivitySubscriptionArea" => [Primitives.surface,Primitives.point],
			"GMDSSArea" => [Primitives.surface],
			"IndeterminateZone" => [Primitives.surface],
			"MetArea" => [Primitives.surface],
			"NavArea" => [Primitives.surface],
			"NavtexServiceArea" => [Primitives.surface],
			"RadioServiceArea" => [Primitives.surface],
			"RadioStation" => [Primitives.point],
			"WeatherForecastAndWarningArea" => [Primitives.surface],
			"FuzzyAreaAggregate" => [Primitives.noGeometry],
			"RadioServiceAreaAggregate" => [Primitives.noGeometry],
			"DataCoverage" => [Primitives.surface],
			"QualityOfNonBathymetricData" => [Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
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
	/// Classification of broadcast or communications based on public availability and commercial/non-commercial nature.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfBroadcastCommunication : int {
		[System.ComponentModel.Description("A service operated with the intention of earning money.")]
		[EnumMember(Value = "Commercial")] 
		[XmlEnum("1")] 
		Commercial = 1,

		[System.ComponentModel.Description("A service without any financial interest.")]
		[EnumMember(Value = "Non-Commercial")] 
		[XmlEnum("2")] 
		NonCommercial = 2,

		[System.ComponentModel.Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("3")] 
		Public = 3,

		[System.ComponentModel.Description("A service available for limited and predefined customers.")]
		[EnumMember(Value = "Non-Public")] 
		[XmlEnum("4")] 
		NonPublic = 4,
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
		[System.ComponentModel.Description("Unpacked homogenous cargo poured loose in a certain space of a vessel, for example oil or grain.")]
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

		[System.ComponentModel.Description("Commodity cargo that is transported unpackaged in large quantities. These types of goods usually need to be kept dry during the whole transportation period.")]
		[EnumMember(Value = "Dry Bulk Cargo")] 
		[XmlEnum("10")] 
		DryBulkCargo = 10,

		[System.ComponentModel.Description("Liquids or gases that are transported in bulk and carried unpackaged.")]
		[EnumMember(Value = "Liquid Bulk Cargo")] 
		[XmlEnum("11")] 
		LiquidBulkCargo = 11,

		[System.ComponentModel.Description("Cargo transported in refrigerated containers, generally perishable commodities which require temperature-controlled transportation, such as fruit, meat, fish, vegetables, dairy products and other foods.")]
		[EnumMember(Value = "Reefer Container Cargo")] 
		[XmlEnum("12")] 
		ReeferContainerCargo = 12,

		[System.ComponentModel.Description("Wheeled cargo, such as cars, busses, trucks, agricultural vehicles and cranes, that are driven on and off the ship on their own wheels or using a platform vehicle, such as a self-propelled modular transporter.")]
		[EnumMember(Value = "Ro-Ro Cargo")] 
		[XmlEnum("13")] 
		RoRoCargo = 13,

		[System.ComponentModel.Description("Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.")]
		[EnumMember(Value = "Project Cargo")] 
		[XmlEnum("14")] 
		ProjectCargo = 14,

		[System.ComponentModel.Description("Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.")]
		[EnumMember(Value = "Break Bulk Cargo")] 
		[XmlEnum("15")] 
		BreakBulkCargo = 15,
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
	/// Classification of weather forecast and weather warning areas based on source of warnings and forecasts.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfForecastOrWarningArea : int {
		[System.ComponentModel.Description("The forecast and warning area defined by WMO.")]
		[EnumMember(Value = "World Meteorological Organization (WMO)")] 
		[XmlEnum("1")] 
		WorldMeteorologicalOrganizationWmo = 1,

		[System.ComponentModel.Description("The forecast and warning area defined by national authorities covering High Seas.")]
		[EnumMember(Value = "National High Seas")] 
		[XmlEnum("2")] 
		NationalHighSeas = 2,

		[System.ComponentModel.Description("The forecast and warning area defined by national authorities covering offshore waters.")]
		[EnumMember(Value = "National Offshore")] 
		[XmlEnum("3")] 
		NationalOffshore = 3,

		[System.ComponentModel.Description("The forecast and warning area defined by national authorities covering coastal waters.")]
		[EnumMember(Value = "National Coastal")] 
		[XmlEnum("4")] 
		NationalCoastal = 4,

		[System.ComponentModel.Description("The forecast and warning area defined by national authorities covering inshore waters.")]
		[EnumMember(Value = "National Inshore")] 
		[XmlEnum("5")] 
		NationalInshore = 5,

		[System.ComponentModel.Description("The forecast and warning area defined by national authorities covering local waters.")]
		[EnumMember(Value = "National Local")] 
		[XmlEnum("6")] 
		NationalLocal = 6,

		[System.ComponentModel.Description("The solid form of water.")]
		[EnumMember(Value = "Ice")] 
		[XmlEnum("7")] 
		Ice = 7,
	}

	/// <summary>
	/// Classification of GMDSS areas based on availability of GMDSS services and GMDSS equipment requirements.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfGMDSSArea : int {
		[System.ComponentModel.Description("Within range of VHF coast stations with continuous DSC alerting available (about 20 30 miles).")]
		[EnumMember(Value = "Area A1")] 
		[XmlEnum("1")] 
		AreaA1 = 1,

		[System.ComponentModel.Description("Beyond area A1, but within range of MF coastal stations with continuous DSC alerting available (about l00 miles).")]
		[EnumMember(Value = "Area A2")] 
		[XmlEnum("2")] 
		AreaA2 = 2,

		[System.ComponentModel.Description("Beyond Area 1 and Area 2, but within coverage of geostationary maritime communication satellites (in practice this means Inmarsat). This covers the area between roughly 70 deg N and 70 deg S.")]
		[EnumMember(Value = "Area A3")] 
		[XmlEnum("3")] 
		AreaA3 = 3,

		[System.ComponentModel.Description("The sea areas beyond Area 3. The most important of these is the sea around the North Pole (the area around the South Pole is mostly land). Geostationary satellites, which are positioned above the equator, cannot reach this far.")]
		[EnumMember(Value = "Area A4")] 
		[XmlEnum("4")] 
		AreaA4 = 4,
	}

	/// <summary>
	/// Classification of radio services offered by a radio station.
	/// </summary>
	/// <remarks>
	/// A radiobeacon is a radio transmitter which emits a distinctive or characteristic signal on which a bearing may be taken.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("A radio station intended to determine only the direction of other stations by means of transmission from the latter.")]
		[EnumMember(Value = "Radio Direction-Finding Station")] 
		[XmlEnum("5")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.")]
		[EnumMember(Value = "Differential GNSS")] 
		[XmlEnum("10")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
		[EnumMember(Value = "Radio Telephone Station")] 
		[XmlEnum("19")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("An AIS shore station for use by competent authorities to provide AIS service, manage the data link and enable effective ship to shore / shore to ship transmission of information.")]
		[EnumMember(Value = "AIS Base Station")] 
		[XmlEnum("20")] 
		AisBaseStation = 20,
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
	/// An assessment of the likelihood of change over time.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTemporalVariation : int {
		[System.ComponentModel.Description("Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.")]
		[EnumMember(Value = "Extreme Event")] 
		[XmlEnum("1")] 
		ExtremeEvent = 1,

		[System.ComponentModel.Description("Continuous or frequent change (for example river siltation, sand waves, seasonal storms, icebergs, etc) that is likely to result in new significant shoaling.")]
		[EnumMember(Value = "Likely to Change and Significant Shoaling Expected")] 
		[XmlEnum("2")] 
		LikelyToChangeAndSignificantShoalingExpected = 2,

		[System.ComponentModel.Description("Continuous or frequent change (for example sand wave shift, seasonal storms, icebergs, etc) that is not likely to result in new significant shoaling.")]
		[EnumMember(Value = "Likely to Change But Significant Shoaling Not Expected")] 
		[XmlEnum("3")] 
		LikelyToChangeButSignificantShoalingNotExpected = 3,

		[System.ComponentModel.Description("Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).")]
		[EnumMember(Value = "Likely to Change")] 
		[XmlEnum("4")] 
		LikelyToChange = 4,

		[System.ComponentModel.Description("Significant change to the seafloor is not expected.")]
		[EnumMember(Value = "Unlikely to Change")] 
		[XmlEnum("5")] 
		UnlikelyToChange = 5,

		[System.ComponentModel.Description("Not having been assessed.")]
		[EnumMember(Value = "Unassessed")] 
		[XmlEnum("6")] 
		Unassessed = 6,
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
	/// Category of the communication system providing the connectivity coverage for subscription.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfConnectivitySubscription : int {
		[System.ComponentModel.Description("Communication using GEO (Geosynchronous Earth Orbit) satellites")]
		[EnumMember(Value = "Satellite Communication GEO")] 
		[XmlEnum("1")] 
		SatelliteCommunicationGeo = 1,

		[System.ComponentModel.Description("Communication using LEO (Low Earth Orbit) satellites")]
		[EnumMember(Value = "Satellite Communication LEO")] 
		[XmlEnum("2")] 
		SatelliteCommunicationLeo = 2,

		[System.ComponentModel.Description("Communication using cellular network. Cellular netwotk or mobile network enables wireless communication between mobile devices. The final stage of connectivity is achieved by segmenting the comprehensive service area into several compact zones, each called a cell. A stationary transceiver, known as a cell site or base station, provides service in each cell. The cell site links to the primary network infrastructure, employing either a wireless or wired connection.")]
		[EnumMember(Value = "Cellular Communication")] 
		[XmlEnum("3")] 
		CellularCommunication = 3,

		[System.ComponentModel.Description("Communication using ad-hoc networking, which uses whatever resources available to create communication paths from an end-user device to its desired destination, independent from central network infrastructure or administration.")]
		[EnumMember(Value = "Terrestrial Ad-Hoc Communication")] 
		[XmlEnum("4")] 
		TerrestrialAdHocCommunication = 4,
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
	/// Any one of seven days in a week.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dayOfWeek : int {
		[System.ComponentModel.Description("The day of the week following Saturday and preceding Monday.")]
		[EnumMember(Value = "Sunday")] 
		[XmlEnum("1")] 
		Sunday = 1,

		[System.ComponentModel.Description("The day of the week following Sunday and preceding Tuesday.")]
		[EnumMember(Value = "Monday")] 
		[XmlEnum("2")] 
		Monday = 2,

		[System.ComponentModel.Description("The day of the week following Monday and preceding Wednesday.")]
		[EnumMember(Value = "Tuesday")] 
		[XmlEnum("3")] 
		Tuesday = 3,

		[System.ComponentModel.Description("The day of the week following Tuesday and preceding Thursday.")]
		[EnumMember(Value = "Wednesday")] 
		[XmlEnum("4")] 
		Wednesday = 4,

		[System.ComponentModel.Description("The day of the week following Wednesday and preceding Friday.")]
		[EnumMember(Value = "Thursday")] 
		[XmlEnum("5")] 
		Thursday = 5,

		[System.ComponentModel.Description("The day of the week following Thursday and preceding Saturday.")]
		[EnumMember(Value = "Friday")] 
		[XmlEnum("6")] 
		Friday = 6,

		[System.ComponentModel.Description("The day of the week following Friday and preceding Sunday.")]
		[EnumMember(Value = "Saturday")] 
		[XmlEnum("7")] 
		Saturday = 7,
	}

	/// <summary>
	/// A continuous set of frequencies lying between two specified limiting frequencies. (Rec. ITU-R V.662-3)
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum frequencyBand : int {
		[System.ComponentModel.Description("Radio frequencies between 30 kHz and 300 kHz")]
		[EnumMember(Value = "LF")] 
		[XmlEnum("1")] 
		Lf = 1,

		[System.ComponentModel.Description("Radio frequencies between 300 kHz and 3000 kHz")]
		[EnumMember(Value = "MF")] 
		[XmlEnum("2")] 
		Mf = 2,

		[System.ComponentModel.Description("Radio frequencies between 300 kHz and 30 MHz")]
		[EnumMember(Value = "MF/HF")] 
		[XmlEnum("3")] 
		MfHf = 3,

		[System.ComponentModel.Description("Radio frequencies between 3 MHz and 30 MHz")]
		[EnumMember(Value = "HF")] 
		[XmlEnum("4")] 
		Hf = 4,

		[System.ComponentModel.Description("Radio frequencies between 30 MHz and 300 MHz")]
		[EnumMember(Value = "VHF")] 
		[XmlEnum("5")] 
		Vhf = 5,

		[System.ComponentModel.Description("Radio frequencies between 300 MHz and 3 GHz")]
		[EnumMember(Value = "UHF")] 
		[XmlEnum("6")] 
		Uhf = 6,
	}

	/// <summary>
	/// The likelihood that a vessel will experience the phenomenon described by a feature, or that the service described by the feature will be available.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum informationConfidence : int {
		[System.ComponentModel.Description("Virtually certain to be experienced by (or available to) an individual vessel; will be experienced by nearly all vessels.")]
		[EnumMember(Value = "Virtually Certain")] 
		[XmlEnum("1")] 
		VirtuallyCertain = 1,

		[System.ComponentModel.Description("Frequently experienced by (or available to) an individual vessel; experienced by a majority of vessels.")]
		[EnumMember(Value = "High Likelihood")] 
		[XmlEnum("2")] 
		HighLikelihood = 2,

		[System.ComponentModel.Description("Occasionally experienced by (or available to) an individual vessel; experienced by (or available to) about half of all vessels.")]
		[EnumMember(Value = "Medium Likelihood")] 
		[XmlEnum("3")] 
		MediumLikelihood = 3,

		[System.ComponentModel.Description("Unlikely, but sometimes (rarely) experienced by (or available to) an individual vessel; experienced by (or available to) a minority of vessels.")]
		[EnumMember(Value = "Low Likelihood")] 
		[XmlEnum("4")] 
		LowLikelihood = 4,
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
	/// The degree of reliability attributed to a position.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.")]
		[EnumMember(Value = "Approximate")] 
		[XmlEnum("4")] 
		Approximate = 4,
	}

	/// <summary>
	/// The Recognized Mobile Satellite Service (RMSS) providing the service through a satellite system that is recognized by the IMO, for use in the GMDSS
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum servingMobileSatelliteService : int {
		[System.ComponentModel.Description("An international automatic direct-printing satellite-based service using Inmarsat C Enhanced Group Call (EGC) system for the promulgation of Maritime Safety Information (MSI), navigational and meteorological warnings, meteorological forecasts, Search and Rescue (SAR) related information and other urgent safety-related messages to ships.")]
		[EnumMember(Value = "Inmarsat SafetyNET")] 
		[XmlEnum("1")] 
		InmarsatSafetynet = 1,

		[System.ComponentModel.Description("A service based on Iridium mobile-satellite system for the promulgation of Maritime Safety Information (MSI), navigational and meteorological warnings, meteorological forecasts, SAR-related information and other urgent safety-related messages to ships.")]
		[EnumMember(Value = "Iridium SafetyCast")] 
		[XmlEnum("2")] 
		IridiumSafetycast = 2,
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

		[System.ComponentModel.Description("Use has ceased, but the facility still exists intact; disused.")]
		[EnumMember(Value = "Not in Use")] 
		[XmlEnum("4")] 
		NotInUse = 4,

		[System.ComponentModel.Description("Recurring at intervals.")]
		[EnumMember(Value = "Periodic/Intermittent")] 
		[XmlEnum("5")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("Meant to last only for a time.")]
		[EnumMember(Value = "Temporary")] 
		[XmlEnum("7")] 
		Temporary = 7,

		[System.ComponentModel.Description("Administered by an individual or corporation, rather than a State or a public body.")]
		[EnumMember(Value = "Private")] 
		[XmlEnum("8")] 
		Private = 8,

		[System.ComponentModel.Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("14")] 
		Public = 14,

		[System.ComponentModel.Description("Looked at or observed over a period of time especially so as to be aware of any movement or change.")]
		[EnumMember(Value = "Watched")] 
		[XmlEnum("16")] 
		Watched = 16,

		[System.ComponentModel.Description("Usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
		[EnumMember(Value = "Unwatched")] 
		[XmlEnum("17")] 
		Unwatched = 17,

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
	/// The attribute from which a text string is derived.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum textType : int {
		[System.ComponentModel.Description("The individual name of a feature.")]
		[EnumMember(Value = "Name")] 
		[XmlEnum("1")] 
		Name = 1,

		[System.ComponentModel.Description("A distinguishing trait, quality, or property of a feature class.")]
		[EnumMember(Value = "Feature Characteristic")] 
		[XmlEnum("2")] 
		FeatureCharacteristic = 2,
	}

	/// <summary>
	/// Classification of regularity or conditions for transmission.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum transmissionRegularity : int {
		[System.ComponentModel.Description("Transmission is made continuously.")]
		[EnumMember(Value = "Continuous")] 
		[XmlEnum("1")] 
		Continuous = 1,

		[System.ComponentModel.Description("Transmission is made regularly according to a schedule.")]
		[EnumMember(Value = "Regular")] 
		[XmlEnum("2")] 
		Regular = 2,

		[System.ComponentModel.Description("Transmission is made when warning or information is received from another authority.")]
		[EnumMember(Value = "On Receipt")] 
		[XmlEnum("3")] 
		OnReceipt = 3,

		[System.ComponentModel.Description("Transmission is made under specified conditions or when needed.")]
		[EnumMember(Value = "As Required")] 
		[XmlEnum("4")] 
		AsRequired = 4,

		[System.ComponentModel.Description("When you ask for it.")]
		[EnumMember(Value = "On Request")] 
		[XmlEnum("5")] 
		OnRequest = 5,
	}

	/// <summary>
	/// Categorization of the broadcast content by subject.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfBroadcastContent : int {
		[System.ComponentModel.Description("Messages containing urgent information relevant to safe navigation broadcast to ships in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974.")]
		[EnumMember(Value = "Navigational warnings")] 
		[XmlEnum("1")] 
		NavigationalWarnings = 1,

		[System.ComponentModel.Description("Marine meteorological warning and forecast information in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974")]
		[EnumMember(Value = "Meteorological warnings and forecasts")] 
		[XmlEnum("2")] 
		MeteorologicalWarningsAndForecasts = 2,

		[System.ComponentModel.Description("Search and rescue (SAR)-related information provided by the authority responsible for coordinating maritime SAR operations")]
		[EnumMember(Value = "Search and rescue information")] 
		[XmlEnum("3")] 
		SearchAndRescueInformation = 3,

		[System.ComponentModel.Description("Security-related requirements in accordance to International Ship and Port Facility Security (ISPS) Code, or warnings related to acts of piracy and armed robbery against ships")]
		[EnumMember(Value = "Marine security or piracy warnings")] 
		[XmlEnum("4")] 
		MarineSecurityOrPiracyWarnings = 4,

		[System.ComponentModel.Description("Warnings realted to tsunamis and other natural phenomena, such as abnormal changes to sea level")]
		[EnumMember(Value = "Tsunamis or natural phenomena warnings")] 
		[XmlEnum("5")] 
		TsunamisOrNaturalPhenomenaWarnings = 5,

		[System.ComponentModel.Description("Messages related to pilot and VTS service, such as temporary alterations, movement or suspension to pilot or VTS services")]
		[EnumMember(Value = "Pilot and VTS service messages")] 
		[XmlEnum("6")] 
		PilotAndVtsServiceMessages = 6,

		[System.ComponentModel.Description("Information concerning military events, such as military exercises, missile firings.")]
		[EnumMember(Value = "Military information")] 
		[XmlEnum("7")] 
		MilitaryInformation = 7,

		[System.ComponentModel.Description("Broadcast for special services or other application specific messages")]
		[EnumMember(Value = "Special service or application specific messages")] 
		[XmlEnum("8")] 
		SpecialServiceOrApplicationSpecificMessages = 8,
	}

	/// <summary>
	/// Categorization of the connectivity resource by Quality o Service (QoS).
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfConnectivityResource : int {
		[System.ComponentModel.Description("The type of Quality of Service (QoS) Flow or a QoS parameter that defines the minimum data rate that must be guaranteed for a specific service or traffic flow.")]
		[EnumMember(Value = "Guaranteed Bit Rate")] 
		[XmlEnum("1")] 
		GuaranteedBitRate = 1,

		[System.ComponentModel.Description("The type of Quality of Service (QoS) Flow that does not provide the end-user a guaranteed flow bit rate,  typically used for non-time-sensitive applications, e.g., web browsing, buffered streaming, and instant messenger applications")]
		[EnumMember(Value = "Non-Guaranteed Bit Rate")] 
		[XmlEnum("2")] 
		NonGuaranteedBitRate = 2,

		[System.ComponentModel.Description("The type of Quality of Service (QoS) Flow that provides latencies significantly lower than guaranteed flow bit rate. Typically used in mission critical application like automation or intelligent transportation systems")]
		[EnumMember(Value = "Delay Critical Guaranteed Bit Rate")] 
		[XmlEnum("3")] 
		DelayCriticalGuaranteedBitRate = 3,

		[System.ComponentModel.Description("The network or service that does not support quality of service, does its best to deliver packets, but does not guarantee delivery or control delay")]
		[EnumMember(Value = "Best Effort")] 
		[XmlEnum("4")] 
		BestEffort = 4,
	}

	/// <summary>
	/// Type of service of the NAVTEX, an international one or a national one. (IMO MSC.1/Circ.1403/Rev.2 NAVTEX Manual)
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfNAVTEXService : int {
		[System.ComponentModel.Description("The coordinated broadcast and automatic reception on 518 kHz of maritime safety information by means of narrow-band direct-printing telegraphy using the English language. (IMO MSC.1/Circ.1403/Rev.2 NAVTEX Manual)")]
		[EnumMember(Value = "International NAVTEX")] 
		[XmlEnum("1")] 
		InternationalNavtex = 1,

		[System.ComponentModel.Description("The broadcast and automatic reception of maritime safety information by means of narrow-band direct-printing telegraphy using frequencies other than 518 kHz and languages as decided by the Administration concerned. (IMO MSC.1/Circ.1403/Rev.2 NAVTEX Manual)")]
		[EnumMember(Value = "national NAVTEX")] 
		[XmlEnum("2")] 
		NationalNavtex = 2,
	}

	/// <summary>
	/// Categorization of the radio service by the technology or system
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfRadioService : int {
		[System.ComponentModel.Description("Radio service using digital selective calling (DSC) techniques.")]
		[EnumMember(Value = "Digital Selective Calling (DSC)")] 
		[XmlEnum("1")] 
		DigitalSelectiveCallingDsc = 1,

		[System.ComponentModel.Description("Radio service using radio telephony (RT).")]
		[EnumMember(Value = "Radio Telephony (RT)")] 
		[XmlEnum("2")] 
		RadioTelephonyRt = 2,

		[System.ComponentModel.Description("Radio service with the coast station providing a public correspondence service.")]
		[EnumMember(Value = "Public correspondence service (CP)")] 
		[XmlEnum("3")] 
		PublicCorrespondenceServiceCp = 3,

		[System.ComponentModel.Description("Radio service using Radio Telegraphy (WT)")]
		[EnumMember(Value = "Radio Telegraphy (WT)")] 
		[XmlEnum("4")] 
		RadioTelegraphyWt = 4,

		[System.ComponentModel.Description("Radio service using Narrow-Band Direct-Printing (NBDP) telegraphy")]
		[EnumMember(Value = "Radiotelex (NBDP telegraphy)")] 
		[XmlEnum("5")] 
		RadiotelexNbdpTelegraphy = 5,

		[System.ComponentModel.Description("Radio service using radio facsimile")]
		[EnumMember(Value = "Radio facsimile")] 
		[XmlEnum("6")] 
		RadioFacsimile = 6,

		[System.ComponentModel.Description("Radio service using digital modulation in the transmitted signal")]
		[EnumMember(Value = "Digital")] 
		[XmlEnum("7")] 
		Digital = 7,

		[System.ComponentModel.Description("Radio service using data communication")]
		[EnumMember(Value = "Data")] 
		[XmlEnum("8")] 
		Data = 8,

		[System.ComponentModel.Description("The system for the broadcast and automatic reception of maritime safety information by means of narrow-band direct-printing telegraphy.")]
		[EnumMember(Value = "NAVTEX")] 
		[XmlEnum("9")] 
		Navtex = 9,

		[System.ComponentModel.Description("The broadcast of coordinated maritime safety information and search and rescue related information, to a defined geographical area using a recognized mobile satellite service.")]
		[EnumMember(Value = "Enhanced Group Call (EGC)")] 
		[XmlEnum("10")] 
		EnhancedGroupCallEgc = 10,

		[System.ComponentModel.Description("Automatic Identification System")]
		[EnumMember(Value = "AIS")] 
		[XmlEnum("11")] 
		Ais = 11,

		[System.ComponentModel.Description("Application Specific Message")]
		[EnumMember(Value = "ASM")] 
		[XmlEnum("12")] 
		Asm = 12,

		[System.ComponentModel.Description("Communication using a satellite system")]
		[EnumMember(Value = "Satellite communication")] 
		[XmlEnum("13")] 
		SatelliteCommunication = 13,
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
				definition = "Attaching a vessel to a wharf or jetty.",
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
		/// Description of the radio service for area A3 of the Global Maritime Distress and Safety System (GMDSS).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class areaA3ServiceDescription : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Lower(1)]
			public List<servingMobileSatelliteService> servingMobileSatelliteService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("servingMobileSatelliteService")]
			public SerializableEnumeration<servingMobileSatelliteService>[] servingMobileSatelliteServiceElement { get { return [.. servingMobileSatelliteService]; } set { } }

			public bool ShouldSerializeservingMobileSatelliteService() { return servingMobileSatelliteService.Any(); }

			[XmlElement("satelliteOceanRegion")]
			public String? satelliteOceanRegion {get;set;} = default;

			public bool ShouldSerializesatelliteOceanRegion() { return !string.IsNullOrEmpty(satelliteOceanRegion); }

			[XmlElement("mSICoastalWarningArea")]
			public String? mSICoastalWarningArea {get;set;} = default;

			public bool ShouldSerializemSICoastalWarningArea() { return !string.IsNullOrEmpty(mSICoastalWarningArea); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<areaA3ServiceDescription, bool>> _conditionalDpendencies = new Dictionary<string,Func<areaA3ServiceDescription, bool>> {
			};
		}

		/// <summary>
		/// Details related to the content of the broadcast.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class broadcastContent : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Lower(1)]
			public List<typeOfBroadcastContent> typeOfBroadcastContent {get;set;} = [];

			[JsonIgnore]
			[XmlElement("typeOfBroadcastContent")]
			public SerializableEnumeration<typeOfBroadcastContent>[] typeOfBroadcastContentElement { get { return [.. typeOfBroadcastContent]; } set { } }

			public bool ShouldSerializetypeOfBroadcastContent() { return typeOfBroadcastContent.Any(); }

			[XmlElement("subjectIndicatorCharacter")]
			public String? subjectIndicatorCharacter {get;set;} = default;

			public bool ShouldSerializesubjectIndicatorCharacter() { return !string.IsNullOrEmpty(subjectIndicatorCharacter); }

			[XmlElement("subjectDescription")]
			public String? subjectDescription {get;set;} = default;

			public bool ShouldSerializesubjectDescription() { return !string.IsNullOrEmpty(subjectDescription); }

			[XmlElement("observationTime")]
			public S100Framework.DomainModel.S100.Time? observationTime {get;set;} = default;

			public bool ShouldSerializeobservationTime() { return observationTime.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			public transmissionRegularity? transmissionRegularity {get;set;} = default;

			[JsonIgnore]
			[XmlElement("transmissionRegularity")]
			public SerializableEnumeration<transmissionRegularity>? transmissionRegularityElement { get { return transmissionRegularity; } set { } }

			public bool ShouldSerializetransmissionRegularity() { return transmissionRegularity.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<broadcastContent, bool>> _conditionalDpendencies = new Dictionary<string,Func<broadcastContent, bool>> {
			};
		}

		/// <summary>
		/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress : ComplexType {
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<contactAddress, bool>> _conditionalDpendencies = new Dictionary<string,Func<contactAddress, bool>> {
			};
		}

		/// <summary>
		/// Details related to the indication of the radio coverage.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class coverageIndication : ComplexType {
			[XmlElement("minimumReceivedPower")]
			public int? minimumReceivedPower {get;set;} = default;

			public bool ShouldSerializeminimumReceivedPower() { return minimumReceivedPower.HasValue; }

			[XmlElement("presumedReceiverAntennaHeight")]
			public int? presumedReceiverAntennaHeight {get;set;} = default;

			public bool ShouldSerializepresumedReceiverAntennaHeight() { return presumedReceiverAntennaHeight.HasValue; }

			[XmlElement("minimumSignalToInterferenceNoiseRatio")]
			public int? minimumSignalToInterferenceNoiseRatio {get;set;} = default;

			public bool ShouldSerializeminimumSignalToInterferenceNoiseRatio() { return minimumSignalToInterferenceNoiseRatio.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17,24,25,26,27])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("text")]
			public List<String> text {get;set;} = [];

			public bool ShouldSerializetext() { return text.Any(); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<coverageIndication, bool>> _conditionalDpendencies = new Dictionary<string,Func<coverageIndication, bool>> {
			};
		}

		/// <summary>
		/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName : ComplexType {
			[XmlElement("language")]
			public String language {get;set;} = string.Empty;

			[XmlElement("name")]
			public String name {get;set;} = string.Empty;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public nameUsage? nameUsage {get;set;} = default;

			[JsonIgnore]
			[XmlElement("nameUsage")]
			public SerializableEnumeration<nameUsage>? nameUsageElement { get { return nameUsage; } set { } }

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<featureName, bool>> _conditionalDpendencies = new Dictionary<string,Func<featureName, bool>> {
			};
		}

		/// <summary>
		/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
		/// </summary>
		/// <remarks>
		/// Dates must be encoded in the format YYYYMMDD; using 4 digits for the calendar year (YYYY) and, optionally, 2 digits for the month (MM) (for example April = 04) and 2 digits for the day (DD). When no specific month and/or day is required/known, the values are replaced with dashes (-). The date range of a recurring event or occurrence must be encoded using periodicDateRange.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class fixedDateRange : ComplexType {
			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			[XmlElement("dateEnd")]
			public String? dateEnd {get;set;} = default;

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }

			[XmlElement("timeOfDayStart")]
			public S100Framework.DomainModel.S100.Time? timeOfDayStart {get;set;} = default;

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.HasValue; }

			[XmlElement("timeOfDayEnd")]
			public S100Framework.DomainModel.S100.Time? timeOfDayEnd {get;set;} = default;

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<fixedDateRange, bool>> _conditionalDpendencies = new Dictionary<string,Func<fixedDateRange, bool>> {
			};
		}

		/// <summary>
		/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair : ComplexType {
			[XmlElement("frequencyShoreStationReceives")]
			public int? frequencyShoreStationReceives {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }

			[XmlElement("frequencyShoreStationTransmits")]
			public int frequencyShoreStationTransmits {get;set;} = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<frequencyPair, bool>> _conditionalDpendencies = new Dictionary<string,Func<frequencyPair, bool>> {
			};
		}

		/// <summary>
		/// Frequency range of the electromagnetic spectrum in which the transmission is provided.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyRange : ComplexType {
			[XmlElement("frequencyLimitLower")]
			public int? frequencyLimitLower {get;set;} = default;

			public bool ShouldSerializefrequencyLimitLower() { return frequencyLimitLower.HasValue; }

			[XmlElement("frequencyLimitUpper")]
			public int? frequencyLimitUpper {get;set;} = default;

			public bool ShouldSerializefrequencyLimitUpper() { return frequencyLimitUpper.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<frequencyRange, bool>> _conditionalDpendencies = new Dictionary<string,Func<frequencyRange, bool>> {
			};
		}

		/// <summary>
		/// The best estimate of the accuracy of a position.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty : ComplexType {
			[XmlElement("uncertaintyFixed")]
			public double uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			public double? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<horizontalPositionUncertainty, bool>> _conditionalDpendencies = new Dictionary<string,Func<horizontalPositionUncertainty, bool>> {
			};
		}

		/// <summary>
		/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
		/// </summary>
		/// <remarks>
		/// At least one of the sub-attributes file reference or text must be populated.The sub-attribute file reference is generally used for long text strings or those that require formatting, however, there is no restriction on the type of text (except for lexical level) that can be held in files referenced by sub-attribute file reference.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information : ComplexType {
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
			public String language {get;set;} = string.Empty;

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<information, bool>> _conditionalDpendencies = new Dictionary<string,Func<information, bool>> {
			};
		}

		/// <summary>
		/// Information about online sources from which a resource or data can be obtained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource : ComplexType {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("linkage")]
			public String linkage {get;set;} = string.Empty;

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<onlineResource, bool>> _conditionalDpendencies = new Dictionary<string,Func<onlineResource, bool>> {
			};
		}

		/// <summary>
		/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation : ComplexType {
			[XmlElement("orientationUncertainty")]
			public double? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("orientationValue")]
			public double orientationValue {get;set;} = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<orientation, bool>> _conditionalDpendencies = new Dictionary<string,Func<orientation, bool>> {
			};
		}

		/// <summary>
		/// The active period of a recurring event or occurrence.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange : ComplexType {
			[XmlElement("dateStart")]
			public String dateStart {get;set;} = string.Empty;

			[XmlElement("dateEnd")]
			public String dateEnd {get;set;} = string.Empty;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<periodicDateRange, bool>> _conditionalDpendencies = new Dictionary<string,Func<periodicDateRange, bool>> {
			};
		}

		/// <summary>
		/// Details related to the radio channel used in the radio service.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class radioChannelDetails : ComplexType {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("transmissionOfTrafficLists")]
			public Boolean transmissionOfTrafficLists {get;set;} = false;

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<radioChannelDetails, bool>> _conditionalDpendencies = new Dictionary<string,Func<radioChannelDetails, bool>> {
			};
		}

		/// <summary>
		/// Identifiers of the radio station in various maritime radiocommunication services.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class radiocommunicationIdentifier : ComplexType {
			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("selectiveCallNumber")]
			public int? selectiveCallNumber {get;set;} = default;

			public bool ShouldSerializeselectiveCallNumber() { return selectiveCallNumber.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<radiocommunicationIdentifier, bool>> _conditionalDpendencies = new Dictionary<string,Func<radiocommunicationIdentifier, bool>> {
			};
		}

		/// <summary>
		/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rxNCode : ComplexType {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("categoryOfRxN")]
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			public bool ShouldSerializecategoryOfRxN() { return categoryOfRxN != default; }

			[XmlElement("actionOrActivity")]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			public bool ShouldSerializeactionOrActivity() { return actionOrActivity != default; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<rxNCode, bool>> _conditionalDpendencies = new Dictionary<string,Func<rxNCode, bool>> {
			};
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne : ComplexType {
			[XmlElement("sectorBearing")]
			public double sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public double? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<sectorLimitOne, bool>> _conditionalDpendencies = new Dictionary<string,Func<sectorLimitOne, bool>> {
			};
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo : ComplexType {
			[XmlElement("sectorBearing")]
			public double sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public double? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<sectorLimitTwo, bool>> _conditionalDpendencies = new Dictionary<string,Func<sectorLimitTwo, bool>> {
			};
		}

		/// <summary>
		/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surveyDateRange : ComplexType {
			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			[XmlElement("dateEnd")]
			public String dateEnd {get;set;} = string.Empty;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<surveyDateRange, bool>> _conditionalDpendencies = new Dictionary<string,Func<surveyDateRange, bool>> {
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
		public class telecommunications : ComplexType {
			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("telecommunicationIdentifier")]
			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public telecommunicationService? telecommunicationService {get;set;} = default;

			[JsonIgnore]
			[XmlElement("telecommunicationService")]
			public SerializableEnumeration<telecommunicationService>? telecommunicationServiceElement { get { return telecommunicationService; } set { } }

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<telecommunications, bool>> _conditionalDpendencies = new Dictionary<string,Func<telecommunications, bool>> {
			};
		}

		/// <summary>
		/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
		/// </summary>
		/// <remarks>
		/// Exactly one of sub-attributes onlineResource or information must be completed in one instance of textContent. Product specifications may restrict the use or content of onlineResource for security. For example, a product specification may forbid populating onlineResource. Product specification authors must consider whether applications using the data product may be prevented from accessing off-system resources by security policies.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textContent : ComplexType {
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

			[XmlElement("source")]
			[StringLengthConstraint(150)]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<textContent, bool>> _conditionalDpendencies = new Dictionary<string,Func<textContent, bool>> {
			};
		}

		/// <summary>
		/// The regular weekly operation times of a service or schedule.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalsByDayOfWeek : ComplexType {
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<timeIntervalsByDayOfWeek, bool>> _conditionalDpendencies = new Dictionary<string,Func<timeIntervalsByDayOfWeek, bool>> {
			};
		}

		/// <summary>
		/// One or more times in the day when the radio station starts a routine transmission, normally expressed in UTC or local time.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timesOfTransmission : ComplexType {
			[XmlElement("minutePastEvenHours")]
			public int? minutePastEvenHours {get;set;} = default;

			public bool ShouldSerializeminutePastEvenHours() { return minutePastEvenHours.HasValue; }

			[XmlElement("minutePastOddHours")]
			public int? minutePastOddHours {get;set;} = default;

			public bool ShouldSerializeminutePastOddHours() { return minutePastOddHours.HasValue; }

			[XmlElement("minutePastEveryHour")]
			public int? minutePastEveryHour {get;set;} = default;

			public bool ShouldSerializeminutePastEveryHour() { return minutePastEveryHour.HasValue; }

			[XmlElement("transmissionTime")]
			public List<S100Framework.DomainModel.S100.Time> transmissionTime {get;set;} = [];

			public bool ShouldSerializetransmissionTime() { return transmissionTime.Any(); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<timesOfTransmission, bool>> _conditionalDpendencies = new Dictionary<string,Func<timesOfTransmission, bool>> {
			};
		}

		/// <summary>
		/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty : ComplexType {
			[XmlElement("uncertaintyFixed")]
			public double uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			public double? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<verticalUncertainty, bool>> _conditionalDpendencies = new Dictionary<string,Func<verticalUncertainty, bool>> {
			};
		}

		/// <summary>
		/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
		/// </summary>
		/// <remarks>
		/// Combines (i) specifications of vessels' measurable characteristics (length, beam, tonnages, etc.), (ii) limit values for the specified characteristics (with units), (iii) arithmetical comparison operators (greater than, etc.), and (iv) logical operators (AND/OR) to define a subset of vessels characterized by the specified ranges. For example, the combination (draught, 10.5, metres, greaterThan) describes "vessels with draught greater than 10.5 metres".
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselMeasurementsSpecification : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9,10,11,12,13])]
			public vesselsCharacteristics vesselsCharacteristics {get;set;}

			[JsonIgnore]
			[XmlElement("vesselsCharacteristics")]
			public SerializableEnumeration<vesselsCharacteristics> vesselsCharacteristicsElement { get { return vesselsCharacteristics; } set { } }

			[XmlElement("vesselsCharacteristicsValue")]
			public double vesselsCharacteristicsValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,9])]
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<vesselMeasurementsSpecification, bool>> _conditionalDpendencies = new Dictionary<string,Func<vesselMeasurementsSpecification, bool>> {
			};
		}

		/// <summary>
		/// The nature and timings of a daily schedule by days of the week.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class scheduleByDayOfWeek : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfSchedule? categoryOfSchedule {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfSchedule")]
			public SerializableEnumeration<categoryOfSchedule>? categoryOfScheduleElement { get { return categoryOfSchedule; } set { } }

			public bool ShouldSerializecategoryOfSchedule() { return categoryOfSchedule.HasValue; }

			[XmlElement("timeIntervalsByDayOfWeek")]
			[Lower(1)]
			[Upper(10)]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<scheduleByDayOfWeek, bool>> _conditionalDpendencies = new Dictionary<string,Func<scheduleByDayOfWeek, bool>> {
			};
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimit : ComplexType {
			[XmlElement("sectorLimitOne")]
			public sectorLimitOne sectorLimitOne {get;set;} = new sectorLimitOne {
				sectorBearing = default,
			};

			[XmlElement("sectorLimitTwo")]
			public sectorLimitTwo sectorLimitTwo {get;set;} = new sectorLimitTwo {
				sectorBearing = default,
			};
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<sectorLimit, bool>> _conditionalDpendencies = new Dictionary<string,Func<sectorLimit, bool>> {
			};
		}

		/// <summary>
		/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class spatialAccuracy : ComplexType {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<spatialAccuracy, bool>> _conditionalDpendencies = new Dictionary<string,Func<spatialAccuracy, bool>> {
			};
		}

		/// <summary>
		/// A bearing is the direction one object is from another object.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation : ComplexType {
			[XmlElement("distance")]
			public double? distance {get;set;} = default;

			public bool ShouldSerializedistance() { return distance.HasValue; }

			[XmlElement("information")]
			public information? information {get;set;} = default;

			public bool ShouldSerializeinformation() { return information!=default; }

			[XmlElement("orientation")]
			public orientation? orientation {get;set;} = default;

			public bool ShouldSerializeorientation() { return orientation!=default; }

			[XmlElement("sectorLimit")]
			public sectorLimit? sectorLimit {get;set;} = default;

			public bool ShouldSerializesectorLimit() { return sectorLimit!=default; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<bearingInformation, bool>> _conditionalDpendencies = new Dictionary<string,Func<bearingInformation, bool>> {
			};
		}

		/// <summary>
		/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class graphic : ComplexType {
			[XmlElement("pictorialRepresentation")]
			public String pictorialRepresentation {get;set;} = string.Empty;

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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<graphic, bool>> _conditionalDpendencies = new Dictionary<string,Func<graphic, bool>> {
			};
		}

	}
	public enum Role {
		[System.ComponentModel.Description("The location in which the information item applies")]
		appliesInLocation,
		[System.ComponentModel.Description("A pointer to an Authority object")]
		theAuthority,
		[System.ComponentModel.Description("The authority for which service hours are given")]
		theAuthority_srvHrs,
		[System.ComponentModel.Description("The area where the connectivity service is provided.")]
		connectivityServiceArea,
		[System.ComponentModel.Description("The provider of the connectivity service.")]
		connectivityServiceProvider,
		[System.ComponentModel.Description("A pointer to an Contact Details object")]
		theContactDetails,
		[System.ComponentModel.Description("The coordinated service area.")]
		coordinatedService,
		[System.ComponentModel.Description("The authority coordinating the service provision.")]
		coordinatingAuthority,
		[System.ComponentModel.Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
		isApplicableTo,
		[System.ComponentModel.Description("The location for which service hours are given")]
		location_srvHrs,
		[System.ComponentModel.Description("The work hours for a non-standard workday")]
		partialWorkingDay,
		[System.ComponentModel.Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
		permission,
		[System.ComponentModel.Description("The area served by a service provider")]
		serviceArea,
		[System.ComponentModel.Description("Service hours for an authority ore service provider")]
		theServiceHours,
		[System.ComponentModel.Description("Pointer to service or facility")]
		servicePlace,
		[System.ComponentModel.Description("Pointer to a feature from where a provider supplies a service")]
		serviceProvider,
		[System.ComponentModel.Description("The applicable regulation, restriction, recommendation or nautical information")]
		theApplicableRxN,
		[System.ComponentModel.Description("The details of the broadcast service, such as the content and schedule.")]
		theBroadcastDetails,
		[System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
		theCartographicText,
		[System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
		theCollection,
		[System.ComponentModel.Description("A pointer to a part in a whole-part relationship.")]
		theComponent,
		[System.ComponentModel.Description("A pointer to the centre controlling or operating the service.")]
		theControlCentre,
		[System.ComponentModel.Description("A pointer to the controlled or operated service.")]
		theControlledService,
		[System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
		theInformation,
		[System.ComponentModel.Description("The organisation to which information relates")]
		theOrganisation,
		[System.ComponentModel.Description("A pointer to a specific feature(s).")]
		thePositionProvider,
		[System.ComponentModel.Description("The connectivity QoS information for the area.")]
		theQoS,
		[System.ComponentModel.Description("The area where the connectivity QoS information applies.")]
		theQoSArea,
		[System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
		theQualityInformation,
		[System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
		theRxN,
		[System.ComponentModel.Description("The usual service hours to which an exception applies")]
		theServiceHours_nsdy,
		[System.ComponentModel.Description("The details of the radio transmission service.")]
		theTransmissionDetails,
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
		/// Available Quality of Service (QoS) within the area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AvailableQoS : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AvailableQoS);
		}

		/// <summary>
		/// The broadcast content and schedule of a service area or facility
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BroadcastService : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BroadcastService);
		}

		/// <summary>
		/// The transmission details for the broadcast or the broadcast details available from the transmission
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BroadcastTransmission : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BroadcastTransmission);
		}

		/// <summary>
		/// The service that allows users to connect to the internet.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConnectivityService : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ConnectivityService);
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
		/// The radio control centre for a marine radio service
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioServiceControl : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioServiceControl);
		}

		/// <summary>
		/// Related organisation
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class relatedOrganisation : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(relatedOrganisation);
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
		/// The coordinating authority for a service area
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceCoordination : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceCoordination);
		}

		/// <summary>
		/// An association for the binding between a spatial type and its spatial quality information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialAssociation : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpatialAssociation);
		}

		/// <summary>
		/// The radio transmission of a service area or facility
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TransmissionService : InformationAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TransmissionService);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and a geographic feature describing the service or phenomenon.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class coreAggregation : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(coreAggregation);
		}

		/// <summary>
		/// A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and zones of uncertainty about the service or phenomenon.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class fuzzyZoneAggregation : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(fuzzyZoneAggregation);
		}

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
		/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextAssociation : FeatureAssociation {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TextAssociation);
		}
	}

}

namespace S100Framework.DomainModel.S123 {
	using ComplexAttributes;
	using InformationAssociations;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// Generalized information type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class InformationType : InformationNode, IInformationBindingDefinition {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("source")]
			[StringLengthConstraint(150)]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

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
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
					primitives = [],
				},
			];

		}

		/// <summary>
		/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AbstractRxN : InformationType {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("textContent")]
			[Lower(1)]
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
					association = nameof(relatedOrganisation),
					role = Enum.GetName<Role>(Role.theOrganisation)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

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

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public List<categoryOfVessel> categoryOfVessel {get;set;} = [];

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfVesselRegistry? categoryOfVesselRegistry {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfVesselRegistry")]
			public SerializableEnumeration<categoryOfVesselRegistry>? categoryOfVesselRegistryElement { get { return categoryOfVesselRegistry; } set { } }

			public bool ShouldSerializecategoryOfVesselRegistry() { return categoryOfVesselRegistry.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
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

			[XmlElement("vesselMeasurementsSpecification")]
			public List<vesselMeasurementsSpecification> vesselMeasurementsSpecification {get;set;} = [];

			public bool ShouldSerializevesselMeasurementsSpecification() { return vesselMeasurementsSpecification.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<Applicability, bool>> _conditionalDpendencies = new Dictionary<string,Func<Applicability, bool>> {
			};
		}

		/// <summary>
		/// A person or organisation having political or administrative power and control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Authority : InformationType {
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
					upper =  1,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<Authority, bool>> _conditionalDpendencies = new Dictionary<string,Func<Authority, bool>> {
			};
		}

		/// <summary>
		/// Description of the content and schedule of a service using broadcast technology of radiocommunications to deliver information (to every receiver within a direct range). Online resource to access the content may also be included.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BroadcastDetails : InformationType {
			[XmlElement("language")]
			public List<String> language {get;set;} = [];

			public bool ShouldSerializelanguage() { return language.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfBroadcastCommunication? categoryOfBroadcastCommunication {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfBroadcastCommunication")]
			public SerializableEnumeration<categoryOfBroadcastCommunication>? categoryOfBroadcastCommunicationElement { get { return categoryOfBroadcastCommunication; } set { } }

			public bool ShouldSerializecategoryOfBroadcastCommunication() { return categoryOfBroadcastCommunication.HasValue; }

			[XmlElement("broadcastContent")]
			[Lower(1)]
			public List<broadcastContent> broadcastContent {get;set;} = [];

			public bool ShouldSerializebroadcastContent() { return broadcastContent.Any(); }

			[XmlElement("timesOfTransmission")]
			public List<timesOfTransmission> timesOfTransmission {get;set;} = [];

			public bool ShouldSerializetimesOfTransmission() { return timesOfTransmission.Any(); }

			[XmlElement("timeIntervalsByDayOfWeek")]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }

			[XmlElement("onlineResource")]
			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BroadcastDetails);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..BroadcastDetails._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastTransmission),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<BroadcastDetails, bool>> _conditionalDpendencies = new Dictionary<string,Func<BroadcastDetails, bool>> {
			};
		}

		/// <summary>
		/// Information related to the Quality of Service (QoS) of the connectivity.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConnectivityQualityOfService : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public List<typeOfConnectivityResource> typeOfConnectivityResource {get;set;} = [];

			[JsonIgnore]
			[XmlElement("typeOfConnectivityResource")]
			public SerializableEnumeration<typeOfConnectivityResource>[] typeOfConnectivityResourceElement { get { return [.. typeOfConnectivityResource]; } set { } }

			public bool ShouldSerializetypeOfConnectivityResource() { return typeOfConnectivityResource.Any(); }

			[XmlElement("uplinkBandwidth")]
			public double? uplinkBandwidth {get;set;} = default;

			public bool ShouldSerializeuplinkBandwidth() { return uplinkBandwidth.HasValue; }

			[XmlElement("downlinkBandwidth")]
			public double? downlinkBandwidth {get;set;} = default;

			public bool ShouldSerializedownlinkBandwidth() { return downlinkBandwidth.HasValue; }

			[XmlElement("packetDelay")]
			public double? packetDelay {get;set;} = default;

			public bool ShouldSerializepacketDelay() { return packetDelay.HasValue; }

			[XmlElement("maximumDataBurstVolume")]
			public int? maximumDataBurstVolume {get;set;} = default;

			public bool ShouldSerializemaximumDataBurstVolume() { return maximumDataBurstVolume.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17,25,26,27])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ConnectivityQualityOfService);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ConnectivityQualityOfService._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<ConnectivityQualityOfService, bool>> _conditionalDpendencies = new Dictionary<string,Func<ConnectivityQualityOfService, bool>> {
			};
		}

		/// <summary>
		/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : InformationType {
			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("information")]
			public information? information {get;set;} = default;

			public bool ShouldSerializeinformation() { return information!=default; }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("callName")]
			public String? callName {get;set;} = default;

			public bool ShouldSerializecallName() { return !string.IsNullOrEmpty(callName); }

			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

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
					upper =  1,
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theAuthority)!,
					informationTypes = [nameof(Authority),nameof(RadioControlCentre)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<ContactDetails, bool>> _conditionalDpendencies = new Dictionary<string,Func<ContactDetails, bool>> {
			};
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
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<NauticalInformation, bool>> _conditionalDpendencies = new Dictionary<string,Func<NauticalInformation, bool>> {
			};
		}

		/// <summary>
		/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NonStandardWorkingDay : InformationType {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("dateFixed")]
			public List<String> dateFixed {get;set;} = [];

			public bool ShouldSerializedateFixed() { return dateFixed.Any(); }

			[XmlElement("dateVariable")]
			public List<String> dateVariable {get;set;} = [];

			public bool ShouldSerializedateVariable() { return dateVariable.Any(); }

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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<NonStandardWorkingDay, bool>> _conditionalDpendencies = new Dictionary<string,Func<NonStandardWorkingDay, bool>> {
			};
		}

		/// <summary>
		/// The control centre of the radio service or radio stations
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioControlCentre : InformationType {
			[XmlElement("isMRCC")]
			public Boolean? isMRCC {get;set;} = default;

			public bool ShouldSerializeisMRCC() { return isMRCC.HasValue; }

			[XmlElement("acceptAMVER")]
			public Boolean? acceptAMVER {get;set;} = default;

			public bool ShouldSerializeacceptAMVER() { return acceptAMVER.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioControlCentre);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..RadioControlCentre._informationBindingDefinitions];
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
					upper =  1,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<RadioControlCentre, bool>> _conditionalDpendencies = new Dictionary<string,Func<RadioControlCentre, bool>> {
			};
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<Recommendations, bool>> _conditionalDpendencies = new Dictionary<string,Func<Recommendations, bool>> {
			};
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<Regulations, bool>> _conditionalDpendencies = new Dictionary<string,Func<Regulations, bool>> {
			};
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<Restrictions, bool>> _conditionalDpendencies = new Dictionary<string,Func<Restrictions, bool>> {
			};
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
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theAuthority)!,
					informationTypes = [nameof(Authority),nameof(RadioControlCentre)],
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<ServiceHours, bool>> _conditionalDpendencies = new Dictionary<string,Func<ServiceHours, bool>> {
			};
		}

		/// <summary>
		/// The indication of the quality of the locational information for features in a dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfHorizontalMeasurement")]
			public SerializableEnumeration<qualityOfHorizontalMeasurement>? qualityOfHorizontalMeasurementElement { get { return qualityOfHorizontalMeasurement; } set { } }

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			[XmlElement("spatialAccuracy")]
			public List<spatialAccuracy> spatialAccuracy {get;set;} = [];

			public bool ShouldSerializespatialAccuracy() { return spatialAccuracy.Any(); }

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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<SpatialQuality, bool>> _conditionalDpendencies = new Dictionary<string,Func<SpatialQuality, bool>> {
			};
		}

		/// <summary>
		/// Description of the radiocommunication service with respect to the radio method and radio channels for the transfer of information by means of signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TransmissionDetails : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public typeOfRadioService? typeOfRadioService {get;set;} = default;

			[JsonIgnore]
			[XmlElement("typeOfRadioService")]
			public SerializableEnumeration<typeOfRadioService>? typeOfRadioServiceElement { get { return typeOfRadioService; } set { } }

			public bool ShouldSerializetypeOfRadioService() { return typeOfRadioService.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public frequencyBand? frequencyBand {get;set;} = default;

			[JsonIgnore]
			[XmlElement("frequencyBand")]
			public SerializableEnumeration<frequencyBand>? frequencyBandElement { get { return frequencyBand; } set { } }

			public bool ShouldSerializefrequencyBand() { return frequencyBand.HasValue; }

			[XmlElement("classOfEmission")]
			public String? classOfEmission {get;set;} = default;

			public bool ShouldSerializeclassOfEmission() { return !string.IsNullOrEmpty(classOfEmission); }

			[XmlElement("communicationStandard")]
			public String? communicationStandard {get;set;} = default;

			public bool ShouldSerializecommunicationStandard() { return !string.IsNullOrEmpty(communicationStandard); }

			[XmlElement("radioChannelDetails")]
			[Lower(1)]
			public List<radioChannelDetails> radioChannelDetails {get;set;} = [];

			public bool ShouldSerializeradioChannelDetails() { return radioChannelDetails.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TransmissionDetails);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..TransmissionDetails._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastTransmission),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<TransmissionDetails, bool>> _conditionalDpendencies = new Dictionary<string,Func<TransmissionDetails, bool>> {
			};
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
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("source")]
			[StringLengthConstraint(150)]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
					association = nameof(PermissionType),
					role = Enum.GetName<Role>(Role.permission)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
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
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		/// <summary>
		/// An area of connectivity coverage available for the subscription of connectivity service.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConnectivitySubscriptionArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfConnectivitySubscription? categoryOfConnectivitySubscription {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfConnectivitySubscription")]
			public SerializableEnumeration<categoryOfConnectivitySubscription>? categoryOfConnectivitySubscriptionElement { get { return categoryOfConnectivitySubscription; } set { } }

			public bool ShouldSerializecategoryOfConnectivitySubscription() { return categoryOfConnectivitySubscription.HasValue; }

			[XmlElement("communicationStandard")]
			public String? communicationStandard {get;set;} = default;

			public bool ShouldSerializecommunicationStandard() { return !string.IsNullOrEmpty(communicationStandard); }

			[XmlElement("estimatedRangeOfTransmission")]
			public double? estimatedRangeOfTransmission {get;set;} = default;

			public bool ShouldSerializeestimatedRangeOfTransmission() { return estimatedRangeOfTransmission.HasValue; }

			[XmlElement("baseStationAntennaHeight")]
			public double? baseStationAntennaHeight {get;set;} = default;

			public bool ShouldSerializebaseStationAntennaHeight() { return baseStationAntennaHeight.HasValue; }

			[XmlElement("frequencyRange")]
			public List<frequencyRange> frequencyRange {get;set;} = [];

			public bool ShouldSerializefrequencyRange() { return frequencyRange.Any(); }

			[XmlElement("sectorLimit")]
			public List<sectorLimit> sectorLimit {get;set;} = [];

			public bool ShouldSerializesectorLimit() { return sectorLimit.Any(); }

			[XmlElement("coverageIndication")]
			public coverageIndication? coverageIndication {get;set;} = default;

			public bool ShouldSerializecoverageIndication() { return coverageIndication!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ConnectivitySubscriptionArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..ConnectivitySubscriptionArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ConnectivityService),
					role = Enum.GetName<Role>(Role.connectivityServiceProvider)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AvailableQoS),
					role = Enum.GetName<Role>(Role.theQoS)!,
					informationTypes = [nameof(ConnectivityQualityOfService)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..ConnectivitySubscriptionArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..ConnectivitySubscriptionArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<ConnectivitySubscriptionArea, bool>> _conditionalDpendencies = new Dictionary<string,Func<ConnectivitySubscriptionArea, bool>> {
			};
		}

		/// <summary>
		/// An area defined for a global communications service based upon automated systems, both satellite based and terrestrial, to provide distress alerting and promulgation of maritime safety information for mariners.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class GMDSSArea : FeatureType {
			[XmlElement("idNAVAREA")]
			public String idNAVAREA {get;set;} = string.Empty;

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfGMDSSArea categoryOfGMDSSArea {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfGMDSSArea")]
			public SerializableEnumeration<categoryOfGMDSSArea> categoryOfGMDSSAreaElement { get { return categoryOfGMDSSArea; } set { } }

			[XmlElement("areaA3ServiceDescription")]
			public areaA3ServiceDescription? areaA3ServiceDescription {get;set;} = default;

			public bool ShouldSerializeareaA3ServiceDescription() { return areaA3ServiceDescription!=default; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(GMDSSArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..GMDSSArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RadioServiceControl),
					role = Enum.GetName<Role>(Role.theControlCentre)!,
					informationTypes = [nameof(RadioControlCentre)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
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
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..GMDSSArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..GMDSSArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<GMDSSArea, bool>> _conditionalDpendencies = new Dictionary<string,Func<GMDSSArea, bool>> {
			};
		}

		/// <summary>
		/// A region in which the perception of a phenomenon or the availability of a service is known only to a specified level of confidence.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IndeterminateZone : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public informationConfidence? informationConfidence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("informationConfidence")]
			public SerializableEnumeration<informationConfidence>? informationConfidenceElement { get { return informationConfidence; } set { } }

			public bool ShouldSerializeinformationConfidence() { return informationConfidence.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(IndeterminateZone);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..IndeterminateZone._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..IndeterminateZone._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..IndeterminateZone._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 1,
					upper =  1,
					association = nameof(fuzzyZoneAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FuzzyAreaAggregate)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<IndeterminateZone, bool>> _conditionalDpendencies = new Dictionary<string,Func<IndeterminateZone, bool>> {
			};
		}

		/// <summary>
		/// A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of marine meteorological information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MetArea : FeatureType {
			[XmlElement("idMETAREA")]
			public String idMETAREA {get;set;} = string.Empty;

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MetArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..MetArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..MetArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..MetArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<MetArea, bool>> _conditionalDpendencies = new Dictionary<string,Func<MetArea, bool>> {
			};
		}

		/// <summary>
		/// A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of navigational warnings.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavArea : FeatureType {
			[XmlElement("idNAVAREA")]
			public String idNAVAREA {get;set;} = string.Empty;

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..NavArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..NavArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..NavArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<NavArea, bool>> _conditionalDpendencies = new Dictionary<string,Func<NavArea, bool>> {
			};
		}

		/// <summary>
		/// A unique and precisely defined sea area, wholly contained within the NAVTEX coverage area, for which maritime safety information is provided from a particular NAVTEX transmitter.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavtexServiceArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			public typeOfNAVTEXService typeOfNAVTEXService {get;set;}

			[JsonIgnore]
			[XmlElement("typeOfNAVTEXService")]
			public SerializableEnumeration<typeOfNAVTEXService> typeOfNAVTEXServiceElement { get { return typeOfNAVTEXService; } set { } }

			[XmlElement("idNAVAREA")]
			public String idNAVAREA {get;set;} = string.Empty;

			[XmlElement("transmitterIdentificationCharacter")]
			public String transmitterIdentificationCharacter {get;set;} = string.Empty;

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,4,7])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavtexServiceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..NavtexServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..NavtexServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..NavtexServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<NavtexServiceArea, bool>> _conditionalDpendencies = new Dictionary<string,Func<NavtexServiceArea, bool>> {
			};
		}

		/// <summary>
		/// The area where a radio service can be obtained and the characteristics of the radio transmission.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioServiceArea : FeatureType {
			[XmlElement("languageInformation")]
			public String? languageInformation {get;set;} = default;

			public bool ShouldSerializelanguageInformation() { return !string.IsNullOrEmpty(languageInformation); }

			[XmlElement("transmissionPower")]
			public double? transmissionPower {get;set;} = default;

			public bool ShouldSerializetransmissionPower() { return transmissionPower.HasValue; }

			[XmlElement("transmissionOfTrafficLists")]
			public Boolean? transmissionOfTrafficLists {get;set;} = default;

			public bool ShouldSerializetransmissionOfTrafficLists() { return transmissionOfTrafficLists.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioServiceArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadioServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RadioServiceControl),
					role = Enum.GetName<Role>(Role.theControlCentre)!,
					informationTypes = [nameof(RadioControlCentre)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadioServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadioServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(coreAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RadioServiceAreaAggregate)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<RadioServiceArea, bool>> _conditionalDpendencies = new Dictionary<string,Func<RadioServiceArea, bool>> {
			};
		}

		/// <summary>
		/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioStation : FeatureType {
			[XmlIgnore]
			[EnumerationValue([5,10,19,20])]
			public categoryOfRadioStation? categoryOfRadioStation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRadioStation")]
			public SerializableEnumeration<categoryOfRadioStation>? categoryOfRadioStationElement { get { return categoryOfRadioStation; } set { } }

			public bool ShouldSerializecategoryOfRadioStation() { return categoryOfRadioStation.HasValue; }

			[XmlElement("estimatedRangeOfTransmission")]
			public double? estimatedRangeOfTransmission {get;set;} = default;

			public bool ShouldSerializeestimatedRangeOfTransmission() { return estimatedRangeOfTransmission.HasValue; }

			[XmlElement("transmissionContent")]
			public String? transmissionContent {get;set;} = default;

			public bool ShouldSerializetransmissionContent() { return !string.IsNullOrEmpty(transmissionContent); }

			[XmlElement("remoteControlled")]
			public Boolean? remoteControlled {get;set;} = default;

			public bool ShouldSerializeremoteControlled() { return remoteControlled.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,16,17])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("radiocommunicationIdentifier")]
			public radiocommunicationIdentifier radiocommunicationIdentifier {get;set;} = new radiocommunicationIdentifier {
			};

			[XmlElement("sectorLimit")]
			public List<sectorLimit> sectorLimit {get;set;} = [];

			public bool ShouldSerializesectorLimit() { return sectorLimit.Any(); }

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioStation);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadioStation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RadioServiceControl),
					role = Enum.GetName<Role>(Role.theControlCentre)!,
					informationTypes = [nameof(RadioControlCentre)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadioStation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadioStation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceArea)!,
					featureTypes = [nameof(ConnectivitySubscriptionArea),nameof(GMDSSArea),nameof(MetArea),nameof(NavArea),nameof(NavtexServiceArea),nameof(RadioServiceArea),nameof(WeatherForecastAndWarningArea)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<RadioStation, bool>> _conditionalDpendencies = new Dictionary<string,Func<RadioStation, bool>> {
			};
		}

		/// <summary>
		/// An area for which weather forecasts and warnings are provided for specified periods.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WeatherForecastAndWarningArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public categoryOfForecastOrWarningArea categoryOfForecastOrWarningArea {get;set;}

			[JsonIgnore]
			[XmlElement("categoryOfForecastOrWarningArea")]
			public SerializableEnumeration<categoryOfForecastOrWarningArea> categoryOfForecastOrWarningAreaElement { get { return categoryOfForecastOrWarningArea; } set { } }

			[XmlElement("idMETAREA")]
			public String? idMETAREA {get;set;} = default;

			public bool ShouldSerializeidMETAREA() { return !string.IsNullOrEmpty(idMETAREA); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(WeatherForecastAndWarningArea);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..WeatherForecastAndWarningArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..WeatherForecastAndWarningArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..WeatherForecastAndWarningArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<WeatherForecastAndWarningArea, bool>> _conditionalDpendencies = new Dictionary<string,Func<WeatherForecastAndWarningArea, bool>> {
			};
		}

		/// <summary>
		/// Aggregation of a geographic feature describing a service or phenomenon with zones of different confidence about the availability of the service, occurrence of the phenomenon, or applicability of the information described by the geographic feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FuzzyAreaAggregate : FeatureType {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FuzzyAreaAggregate);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..FuzzyAreaAggregate._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..FuzzyAreaAggregate._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..FuzzyAreaAggregate._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 1,
					upper =  default,
					association = nameof(fuzzyZoneAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(IndeterminateZone)],
				},
			];
		}

		/// <summary>
		/// Aggregation of areas where radio services from a single radio service are available to different levels of reliability.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioServiceAreaAggregate : FuzzyAreaAggregate {
			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioServiceAreaAggregate);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FuzzyAreaAggregate._informationBindingDefinitions, ..RadioServiceAreaAggregate._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FuzzyAreaAggregate._featureBindingDefinitions, ..RadioServiceAreaAggregate._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FuzzyAreaAggregate._primitives, ..RadioServiceAreaAggregate._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(coreAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(RadioServiceArea)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<RadioServiceAreaAggregate, bool>> _conditionalDpendencies = new Dictionary<string,Func<RadioServiceAreaAggregate, bool>> {
			};
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

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<DataCoverage, bool>> _conditionalDpendencies = new Dictionary<string,Func<DataCoverage, bool>> {
			};
		}

		/// <summary>
		/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,4,5])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation>? categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }

			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			[XmlElement("horizontalDistanceUncertainty")]
			public double? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[XmlElement("orientationUncertainty")]
			public double? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("surveyDateRange")]
			public surveyDateRange? surveyDateRange {get;set;} = default;

			public bool ShouldSerializesurveyDateRange() { return surveyDateRange!=default; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => QualityOfNonBathymetricData._primitives;
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
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<QualityOfNonBathymetricData, bool>> _conditionalDpendencies = new Dictionary<string,Func<QualityOfNonBathymetricData, bool>> {
			};
		}

		/// <summary>
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("textOffsetBearing")]
			[RangeConstraint<int>(0, 360, Closure.geLtInterval)]
			public int textOffsetBearing {get;set;} = default;

			[XmlElement("textOffsetDistance")]
			public int textOffsetDistance {get;set;} = default;

			[XmlElement("textRotation")]
			public Boolean? textRotation {get;set;} = default;

			public bool ShouldSerializetextRotation() { return textRotation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1])]
			[Lower(1)]
			[Upper(2)]
			public List<textType> textType {get;set;} = [];

			[JsonIgnore]
			[XmlElement("textType")]
			public SerializableEnumeration<textType>[] textTypeElement { get { return [.. textType]; } set { } }

			public bool ShouldSerializetextType() { return textType.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

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
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.thePositionProvider)!,
					featureTypes = [nameof(FeatureType)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;
			public override bool ConditionalUnknown(string name) => _conditionalDpendencies[name](this);

			private IReadOnlyDictionary<string, Func<TextPlacement, bool>> _conditionalDpendencies = new Dictionary<string,Func<TextPlacement, bool>> {
			};
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S123/1.1")]
	[XmlRoot(Namespace = "http://www.iho.int/S123/1.1")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S123/1.1 123_1.1.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S123/1.1", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.Applicability", typeof(InformationTypes.Applicability), Order = 1, ElementName = "Applicability")]
		[XmlElement("InformationTypes.Authority", typeof(InformationTypes.Authority), Order = 1, ElementName = "Authority")]
		[XmlElement("InformationTypes.BroadcastDetails", typeof(InformationTypes.BroadcastDetails), Order = 1, ElementName = "BroadcastDetails")]
		[XmlElement("InformationTypes.ConnectivityQualityOfService", typeof(InformationTypes.ConnectivityQualityOfService), Order = 1, ElementName = "ConnectivityQualityOfService")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.NauticalInformation", typeof(InformationTypes.NauticalInformation), Order = 1, ElementName = "NauticalInformation")]
		[XmlElement("InformationTypes.NonStandardWorkingDay", typeof(InformationTypes.NonStandardWorkingDay), Order = 1, ElementName = "NonStandardWorkingDay")]
		[XmlElement("InformationTypes.RadioControlCentre", typeof(InformationTypes.RadioControlCentre), Order = 1, ElementName = "RadioControlCentre")]
		[XmlElement("InformationTypes.Recommendations", typeof(InformationTypes.Recommendations), Order = 1, ElementName = "Recommendations")]
		[XmlElement("InformationTypes.Regulations", typeof(InformationTypes.Regulations), Order = 1, ElementName = "Regulations")]
		[XmlElement("InformationTypes.Restrictions", typeof(InformationTypes.Restrictions), Order = 1, ElementName = "Restrictions")]
		[XmlElement("InformationTypes.ServiceHours", typeof(InformationTypes.ServiceHours), Order = 1, ElementName = "ServiceHours")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("InformationTypes.TransmissionDetails", typeof(InformationTypes.TransmissionDetails), Order = 1, ElementName = "TransmissionDetails")]
		[XmlElement("FeatureTypes.ConnectivitySubscriptionArea", typeof(FeatureTypes.ConnectivitySubscriptionArea), Order = 1, ElementName = "ConnectivitySubscriptionArea")]
		[XmlElement("FeatureTypes.GMDSSArea", typeof(FeatureTypes.GMDSSArea), Order = 1, ElementName = "GMDSSArea")]
		[XmlElement("FeatureTypes.IndeterminateZone", typeof(FeatureTypes.IndeterminateZone), Order = 1, ElementName = "IndeterminateZone")]
		[XmlElement("FeatureTypes.MetArea", typeof(FeatureTypes.MetArea), Order = 1, ElementName = "MetArea")]
		[XmlElement("FeatureTypes.NavArea", typeof(FeatureTypes.NavArea), Order = 1, ElementName = "NavArea")]
		[XmlElement("FeatureTypes.NavtexServiceArea", typeof(FeatureTypes.NavtexServiceArea), Order = 1, ElementName = "NavtexServiceArea")]
		[XmlElement("FeatureTypes.RadioServiceArea", typeof(FeatureTypes.RadioServiceArea), Order = 1, ElementName = "RadioServiceArea")]
		[XmlElement("FeatureTypes.RadioStation", typeof(FeatureTypes.RadioStation), Order = 1, ElementName = "RadioStation")]
		[XmlElement("FeatureTypes.WeatherForecastAndWarningArea", typeof(FeatureTypes.WeatherForecastAndWarningArea), Order = 1, ElementName = "WeatherForecastAndWarningArea")]
		[XmlElement("FeatureTypes.RadioServiceAreaAggregate", typeof(FeatureTypes.RadioServiceAreaAggregate), Order = 1, ElementName = "RadioServiceAreaAggregate")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1, ElementName = "QualityOfNonBathymetricData")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
