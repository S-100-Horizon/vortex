using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100FC.S127.SimpleAttributes
{
	/// <summary>
	/// A generic term for an administrative region within a country at a level below that of the sovereign state.
	/// </summary>
	public class administrativeDivision : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(administrativeDivision);
		[JsonIgnore]
		public override string S100FC_name => "Administrative Division";

		public static implicit operator administrativeDivision(String? value) => new administrativeDivision { value = value };
	}

	/// <summary>
	/// Name of an application profile that can be used with the online resource.
	/// </summary>
	public class applicationProfile : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(applicationProfile);
		[JsonIgnore]
		public override string S100FC_name => "Application Profile";

		public static implicit operator applicationProfile(String? value) => new applicationProfile { value = value };
	}

	/// <summary>
	/// The designated call name of a station; for example, radio station, radar station, pilot.
	/// </summary>
	public class callName : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(callName);
		[JsonIgnore]
		public override string S100FC_name => "Call Name";

		public static implicit operator callName(String? value) => new callName { value = value };
	}

	/// <summary>
	/// The designated call-sign of a station (radio station, radar station, pilot, ...).
	/// </summary>
	public class callSign : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(callSign);
		[JsonIgnore]
		public override string S100FC_name => "Call Sign";

		public static implicit operator callSign(String? value) => new callSign { value = value };
	}

	/// <summary>
	/// Principal and intermediate compass points.
	/// </summary>
	public class cardinalDirection : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cardinalDirection);
		[JsonIgnore]
		public override string S100FC_name => "Cardinal Direction";
		public static listedValue[] listedValues => [
				new listedValue("North", "348.75-011.25 degrees (true north).",1),
				new listedValue("North Northeast", "011.25 - 033.75 degrees.",2),
				new listedValue("Northeast", "033.75 - 056.25 degrees.",3),
				new listedValue("East Northeast", "056.25-078.75 degrees.",4),
				new listedValue("East", "078.75-101.25 degrees.",5),
				new listedValue("East Southeast", "101.25-123.75 degrees.",6),
				new listedValue("Southeast", "123.75-146.25 degrees.",7),
				new listedValue("South Southeast", "146.25-168.75 degrees.",8),
				new listedValue("South", "168.75-191.25 degrees.",9),
				new listedValue("South Southwest", "191.25-213.75 degrees.",10),
				new listedValue("Southwest", "213.75-236.25 degrees.",11),
				new listedValue("West Southwest", "236.25-258.75 degrees.",12),
				new listedValue("West", "258.75-281.25 degrees.",13),
				new listedValue("West Northwest", "281.25-303.75 degrees.",14),
				new listedValue("Northwest", "303.75 - 326.25 degrees.",15),
				new listedValue("North Northwest", "326.25 - 348.75 degrees.",16),
			];

		public static implicit operator cardinalDirection(int? value) => new cardinalDirection { value = value };
	}

	/// <summary>
	/// The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.
	/// </summary>
	public class categoryOfAuthority : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfAuthority);
		[JsonIgnore]
		public override string S100FC_name => "Category of Authority";
		public static listedValue[] listedValues => [
				new listedValue("Border Control", "The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.",2),
				new listedValue("Police", "The department of government, or civil force, charged with maintaining public order.",3),
				new listedValue("Port", "Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.",4),
				new listedValue("Immigration", "The authority controlling people entering a country.",5),
				new listedValue("Health", "The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.",6),
				new listedValue("Coast Guard", "Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.",7),
				new listedValue("Agricultural", "The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.",8),
				new listedValue("Military", "A military authority which provides control of access to or approval for transit through designated areas or airspace.",9),
				new listedValue("Private Company", "A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.",10),
				new listedValue("Maritime Police", "A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.",11),
				new listedValue("Environmental", "An authority with responsibility for the protection of the environment.",12),
				new listedValue("Fishery", "An authority with responsibility for the control of fisheries.",13),
				new listedValue("Finance", "An authority with responsibility for the control and movement of money.",14),
				new listedValue("Maritime", "A national or regional authority charged with administration of maritime affairs.",15),
				new listedValue("Customs", "The agency or establishment for collecting duties, tolls.",16),
			];

		public static implicit operator categoryOfAuthority(int? value) => new categoryOfAuthority { value = value };
	}

	/// <summary>
	/// Classification of frequencies, VHF channels, telephone numbers, or other means of communication based on preference.
	/// </summary>
	public class categoryOfCommunicationPreference : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfCommunicationPreference);
		[JsonIgnore]
		public override string S100FC_name => "Category of Communication Preference";
		public static listedValue[] listedValues => [
				new listedValue("Preferred Calling", "The first choice channel or frequency to be used when calling a radio station.",1),
				new listedValue("Alternate Calling", "A channel or frequency to be used for calling a radio station when the preferred channel or frequency is busy or is suffering from interference.",2),
				new listedValue("Preferred Working", "The first choice channel or frequency to be used when working with a radio station.",3),
				new listedValue("Alternate Working", "A channel or frequency to be used for working with a radio station when the preferred working channel or frequency is busy or is suffering from interference.",4),
			];

		public static implicit operator categoryOfCommunicationPreference(int? value) => new categoryOfCommunicationPreference { value = value };
	}

	/// <summary>
	/// Classification of the different types of cargo that a ship may be carrying.
	/// </summary>
	public class categoryOfCargo : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfCargo);
		[JsonIgnore]
		public override string S100FC_name => "Category of Cargo";
		public static listedValue[] listedValues => [
				new listedValue("Bulk", "Unpacked homogenous cargo poured loose in a certain space of a vessel, for example oil or grain.",1),
				new listedValue("Container", "One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.",2),
				new listedValue("General", "Break bulk cargo normally loaded by crane.",3),
				new listedValue("Liquid", "Any cargo loaded by pipeline.",4),
				new listedValue("Passenger", "A fee paying traveller.",5),
				new listedValue("Livestock", "Live animals carried in bulk.",6),
				new listedValue("Dangerous or Hazardous", "Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.",7),
				new listedValue("Heavy Lift", "Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.",8),
				new listedValue("Ballast", "Material carried by a ship to ensure its stability.",9),
				new listedValue("Dry Bulk Cargo", "Commodity cargo that is transported unpackaged in large quantities. These types of goods usually need to be kept dry during the whole transportation period.",10),
				new listedValue("Liquid Bulk Cargo", "Liquids or gases that are transported in bulk and carried unpackaged.",11),
				new listedValue("Reefer Container Cargo", "Cargo transported in refrigerated containers, generally perishable commodities which require temperature-controlled transportation, such as fruit, meat, fish, vegetables, dairy products and other foods.",12),
				new listedValue("Ro-Ro Cargo", "Wheeled cargo, such as cars, busses, trucks, agricultural vehicles and cranes, that are driven on and off the ship on their own wheels or using a platform vehicle, such as a self-propelled modular transporter.",13),
				new listedValue("Project Cargo", "Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.",14),
				new listedValue("Break Bulk Cargo", "Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.",15),
			];

		public static implicit operator categoryOfCargo(int? value) => new categoryOfCargo { value = value };
	}

	/// <summary>
	/// Classification of shipping hazards due to traffic volume or density.
	/// </summary>
	public class categoryOfConcentrationOfShippingHazardArea : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfConcentrationOfShippingHazardArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of Concentration of Shipping Hazard Area";
		public static listedValue[] listedValues => [
				new listedValue("Concentration of Merchant Shipping", "Concentration of vessels whose primary purpose is to engage in commerce, including ferries.",1),
				new listedValue("Concentration of Recreational Vessels", "Concentration of powered or sailing vessels principally engaged in recreation, leisure, or sporting competition.",2),
				new listedValue("Concentration of Fishing Vessels", "Concentration of vessels whose primary purpose is to hunt, trap or process fish. The concentration could be on the fishing ground, in transit or in the approaches to home bases or fish markets.",3),
				new listedValue("Concentration of Military Vessels", "Concentration of vessels principally engaged in military activities. This includes activities based on mandate of international organizations (for example, UN). The concentration is in areas others than military exercise areas.",4),
			];

		public static implicit operator categoryOfConcentrationOfShippingHazardArea(int? value) => new categoryOfConcentrationOfShippingHazardArea { value = value };
	}

	/// <summary>
	/// Classification of dangerous goods or hazardous materials based on the International Maritime Dangerous Goods Code (IMDG Code).
	/// </summary>
	public class categoryOfDangerousOrHazardousCargo : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfDangerousOrHazardousCargo);
		[JsonIgnore]
		public override string S100FC_name => "Category Of Dangerous Or Hazardous Cargo";
		public static listedValue[] listedValues => [
				new listedValue("IMDG Code Class 1 Div. 1.1", "Explosives, Division 1: Substances and articles which have a mass explosion hazard.",1),
				new listedValue("IMDG Code Class 1 Div. 1.2", "Explosives, Division 2: Substances and articles which have a projection hazard but not a mass explosion hazard.",2),
				new listedValue("IMDG Code Class 1 Div. 1.3", "Explosives, Division 3: Substances and articles which have a fire hazard and either a minor blast hazard or a minor projection hazard or both, but not a mass explosion hazard.",3),
				new listedValue("IMDG Code Class 1 Div. 1.4", "Explosives, Division 4: Substances and articles which present no significant hazard.",4),
				new listedValue("IMDG Code Class 1 Div. 1.5", "Explosives, Division 5: Very insensitive substances which have a mass explosion hazard.",5),
				new listedValue("IMDG Code Class 1 Div. 1.6", "Explosives, Division 6: Extremely insensitive articles which do not have a mass explosion hazard.",6),
				new listedValue("IMDG Code Class 2 Div. 2.1", "Gases, flammable gases.",7),
				new listedValue("IMDG Code Class 2 Div. 2.2", "Gases, non-flammable, non-toxic gases.",8),
				new listedValue("IMDG Code Class 2 Div. 2.3", "Gases, toxic gases.",9),
				new listedValue("IMDG Code Class 3", "Flammable liquids.",10),
				new listedValue("IMDG Code Class 4 Div. 4.1", "Flammable solids, self-reactive substances and desensitized explosives.",11),
				new listedValue("IMDG Code Class 4 Div. 4.2", "Substances liable to spontaneous combustion.",12),
				new listedValue("IMDG Code Class 4 Div. 4.3", "Substances which, in contact with water, emit flammable gases.",13),
				new listedValue("IMDG Code Class 5 Div. 5.1", "Oxidizing substances.",14),
				new listedValue("IMDG Code Class 5 Div. 5.2", "Organic peroxides.",15),
				new listedValue("IMDG Code Class 6 Div. 6.1", "Toxic substances.",16),
				new listedValue("IMDG Code Class 6 Div. 6.2", "Infectious substances.",17),
				new listedValue("IMDG Code Class 7", "Radioactive material.",18),
				new listedValue("IMDG Code Class 8", "Corrosive substances.",19),
				new listedValue("IMDG Code Class 9", "Miscellaneous dangerous substances and articles.",20),
				new listedValue("Harmful Substances in Packaged Form", "Harmful substances are those substances which are identified as marine pollutants in the International Maritime Dangerous Goods Code (IMDG Code). Packaged form is defined as the forms of containment specified for harmful substances in the IMDG Code.",21),
			];

		public static implicit operator categoryOfDangerousOrHazardousCargo(int? value) => new categoryOfDangerousOrHazardousCargo { value = value };
	}

	/// <summary>
	/// Classification of area by military use.
	/// </summary>
	public class categoryOfMilitaryPracticeArea : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfMilitaryPracticeArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of Military Practice Area";
		public static listedValue[] listedValues => [
				new listedValue("Torpedo Exercise Area", "An area within which exercises are carried out with torpedoes.",2),
				new listedValue("Submarine Exercise Area", "An area within which submarine exercises are carried out.",3),
				new listedValue("Firing Danger Area", "Areas for bombing and missile exercises.",4),
				new listedValue("Mine-Laying Practice Area", "An area within which mine laying exercises are carried out.",5),
				new listedValue("Small Arms Firing Range", "An area for shooting pistols, rifles and machine guns etc. at a target.",6),
			];

		public static implicit operator categoryOfMilitaryPracticeArea(int? value) => new categoryOfMilitaryPracticeArea { value = value };
	}

	/// <summary>
	/// Classification of route guidance given to vessels.
	/// </summary>
	public class categoryOfNavigationLine : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfNavigationLine);
		[JsonIgnore]
		public override string S100FC_name => "Category of Navigation Line";
		public static listedValue[] listedValues => [
				new listedValue("Clearing Line", "A straight line that marks the boundary between a safe and a dangerous area or that passes clear of a navigational danger.",1),
				new listedValue("Transit Line", "A line passing through one or more fixed marks.",2),
				new listedValue("Leading Line Bearing a Recommended Track", "A line passing through one or more clearly defined objects, along the path of which a vessel can approach safely up to a certain distance off.",3),
			];

		public static implicit operator categoryOfNavigationLine(int? value) => new categoryOfNavigationLine { value = value };
	}

	/// <summary>
	/// Classification of pilots and pilot services by type of waterway where piloting services are provided.
	/// </summary>
	public class categoryOfPilot : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfPilot);
		[JsonIgnore]
		public override string S100FC_name => "Category of Pilot";
		public static listedValue[] listedValues => [
				new listedValue("Pilot", "Pilot licenced to conduct vessels during approach from sea to a specified place which may be a handover place, an anchorage or alongside.",1),
				new listedValue("Deep Sea", "Pilot licenced to conduct vessels over extensive sea areas.",2),
				new listedValue("Harbour", "A reporting point of a harbour.",3),
				new listedValue("Bar", "A ridge or succession of ridges of sand or other substances extending across the mouth of a river or harbour and which may obstruct navigation.",4),
				new listedValue("River", "A relatively large natural stream of water.",5),
				new listedValue("Channel", "Pilot licensed to conduct vessels from and to specified places, along the course of a channel. (For example as used in Rio Amazonas and Rio de La Plata.)",6),
				new listedValue("Lake", "A large body of water entirely surrounded by land.",7),
			];

		public static implicit operator categoryOfPilot(int? value) => new categoryOfPilot { value = value };
	}

	/// <summary>
	/// Classification of pilot boarding method.
	/// </summary>
	public class categoryOfPilotBoardingPlace : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfPilotBoardingPlace);
		[JsonIgnore]
		public override string S100FC_name => "Category of Pilot Boarding Place";
		public static listedValue[] listedValues => [
				new listedValue("Boarding by Pilot-Cruising Vessel", "Pilot boards from a cruising vessel.",1),
				new listedValue("Boarding by Helicopter", "Pilot boards by helicopter which comes out from the shore.",2),
				new listedValue("Pilot Comes Out from Shore", "Pilot embarks from a vessel or disembarks on a vessel which comes out from the shore on request.",3),
			];

		public static implicit operator categoryOfPilotBoardingPlace(int? value) => new categoryOfPilotBoardingPlace { value = value };
	}

	/// <summary>
	/// The selection of a first choice compared to other options.
	/// </summary>
	public class categoryOfPreference : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfPreference);
		[JsonIgnore]
		public override string S100FC_name => "Category of Preference";
		public static listedValue[] listedValues => [
				new listedValue("Primary", "The preferred first choice used in normal conditions.",1),
				new listedValue("Alternate", "The preferred choice in extraordinary conditions.",2),
			];

		public static implicit operator categoryOfPreference(int? value) => new categoryOfPreference { value = value };
	}

	/// <summary>
	/// Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.
	/// </summary>
	public class categoryOfRelationship : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRelationship);
		[JsonIgnore]
		public override string S100FC_name => "Category of Relationship";
		public static listedValue[] listedValues => [
				new listedValue("Prohibited", "Use of facility, waterway or service is forbidden.",1),
				new listedValue("Not Recommended", "Use of facility, waterway or service is not recommended.",2),
				new listedValue("Permitted", "Use of facility, waterway, or service is permitted but not required.",3),
				new listedValue("Recommended", "Use of facility, waterway, or service is recommended.",4),
				new listedValue("Required", "Use of facility, waterway, or service is required.",5),
				new listedValue("Not Required", "Use of facility, waterway, or service is not required.",6),
				new listedValue("Exclusively Permitted", "Only vessels of the specified characteristics may use the facility, waterway, or service.",7),
			];

		public static implicit operator categoryOfRelationship(int? value) => new categoryOfRelationship { value = value };
	}

	/// <summary>
	/// The official legal status of each kind of restricted area defines the kind of restriction(s), for example the restriction for a 'game reserve' may be 'entering prohibited'.
	/// </summary>
	public class categoryOfRestrictedArea : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRestrictedArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of Restricted Area";
		public static listedValue[] listedValues => [
				new listedValue("Offshore Safety Zone", "The area around an offshore installation within which vessels are prohibited from entering without permission. Special regulations protect installations within a safety zone and vessels of all nationalities are required to respect the zone.",1),
				new listedValue("Nature Reserve", "A tract of land or water managed so as to preserve its flora, fauna, physical features, etc.",4),
				new listedValue("Bird Sanctuary", "A place where birds are bred and protected.",5),
				new listedValue("Game Reserve", "A place where wild animals or birds hunted for sport or food are kept undisturbed for private use.",6),
				new listedValue("Seal Sanctuary", "A place where seals are protected.",7),
				new listedValue("Degaussing Range", "An area, usually about two cables diameter, within which ships' magnetic fields may be measured; sensing instruments and cables are installed on the sea bed in the range and there are cables leading from the range to a control position ashore.",8),
				new listedValue("Military Area", "An area controlled by the military in which restrictions may apply.",9),
				new listedValue("Historic Wreck Area", "An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).",10),
				new listedValue("Navigational Aid Safety Zone", "An area around a navigational aid which vessels are prohibited from entering.",12),
				new listedValue("Minefield", "An area laid and maintained with explosive mines for defence or practice purposes.",14),
				new listedValue("Waiting Area", "An area reserved for vessels waiting to enter a harbour.",19),
				new listedValue("Research Area", "An area where marine research takes place.",20),
				new listedValue("Fish Sanctuary", "A place where fish (including shellfish and crustaceans) are protected.",22),
				new listedValue("Ecological Reserve", "A tract of land managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.",23),
				new listedValue("Swinging Area", "An area where vessels turn.",25),
				new listedValue("Environmentally Sensitive Sea Area", "A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.",27),
				new listedValue("Particularly Sensitive Sea Area", "An area that needs special protection through action by IMO because of its significance for regional ecological, socio-economic or scientific reasons and because it may be vulnerable to damage by international shipping activities.",28),
				new listedValue("Disengagement Area", "An area near a fairway where vessels can go to clear the way or make an about turn and possibly return to a waiting area when nautical conditions impose it.",29),
				new listedValue("Port Security Area", "An area in which defence, law and treaty enforcement, and counter-terrorism activities that fall within the port and maritime domain apply.",30),
				new listedValue("Coral Sanctuary", "A place where coral is protected.",31),
				new listedValue("Recreation Area", "An area within which recreational activities regularly take place and therefore vessel movement may be restricted.",32),
			];

		public static implicit operator categoryOfRestrictedArea(int? value) => new categoryOfRestrictedArea { value = value };
	}

	/// <summary>
	/// Classification of routeing measures by type.
	/// </summary>
	public class categoryOfRouteingMeasure : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRouteingMeasure);
		[JsonIgnore]
		public override string S100FC_name => "Category of Routeing Measure";
		public static listedValue[] listedValues => [
				new listedValue("Archipelagic Sea Lane", "Sea lanes designated by an archipelagic State for the passage of ships and aircraft.  The Archipelagic Sea Lane aggregates all component parts of an Archipelagic Sea Lane system.",1),
				new listedValue("Deep Water Route", "A route within defined limits which has been accurately surveyed for clearance of sea bottom and submerged obstacles as indicated on the chart.",2),
				new listedValue("Fairway System", "That part of a river, harbour and so on, where the main navigable channel for vessels of larger size lies. It is also the usual course followed by vessels entering or leaving harbours, called ship channel. A fairway system is an aggregation of connected fairway features making up a complex fairway system.",3),
				new listedValue("Recommended Route", "A navigation line, range system, or a recommended track, lane, or route.",4),
				new listedValue("Traffic Separation Scheme", "A routeing measure aimed at the separation of opposing streams of traffic by appropriate means and by the establishment of traffic lanes.",5),
				new listedValue("Two-Way Route", "A route within defined limits inside which two way traffic is established, aimed at providing safe passage of ships through waters where navigation is difficult or dangerous.",6),
			];

		public static implicit operator categoryOfRouteingMeasure(int? value) => new categoryOfRouteingMeasure { value = value };
	}

	/// <summary>
	/// The type of schedule, for instance opening, closure, etc.
	/// </summary>
	public class categoryOfSchedule : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfSchedule);
		[JsonIgnore]
		public override string S100FC_name => "Category of Schedule";
		public static listedValue[] listedValues => [
				new listedValue("Normal Operation", "The service, office, is open, fully manned, and operating normally, or the area is accessible as usual.",1),
				new listedValue("Closure", "The service, office, or area is closed.",2),
				new listedValue("Unmanned Operation", "The service is available but not manned.",3),
			];

		public static implicit operator categoryOfSchedule(int? value) => new categoryOfSchedule { value = value };
	}

	/// <summary>
	/// Classification of ship reports based on IMO standard report formats.
	/// </summary>
	public class categoryOfShipReport : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfShipReport);
		[JsonIgnore]
		public override string S100FC_name => "Category of Ship Report";
		public static listedValue[] listedValues => [
				new listedValue("Sailing Plan", "Before or as near as possible to the time of departure from a port within a system or when entering the area covered by a system (for instance A, B, J, X etc).",1),
				new listedValue("Position Report", "When necessary to ensure effective operation of the system.",2),
				new listedValue("Deviation Report", "When the ships position varies significantly from the position that would have been predicted from previous reports; when changing the reported route; or as decided by the master.",3),
				new listedValue("Final Report", "On arrival at the destination or on leaving the area covered by the system.",4),
				new listedValue("Dangerous Goods Report", "When an incident takes place involving the loss or likely loss overboard of packaged dangerous goods, including those in freight containers, portable tanks, road and rail vehicles and ship-borne barges, into the sea.",5),
				new listedValue("Harmful Substances Report", "Report submitted when an incident takes place involving the discharge or probable discharge of oil or noxious liquid substances in bulk.",6),
				new listedValue("Marine Pollutants Report", "In the case of the loss or likely loss overboard of harmful substances in packaged form, including those in freight containers, portable tanks, road and rail vehicles and ship-borne barges identified in the International Maritime Goods Code as marine pollutants.",7),
				new listedValue("Any Other Report", "Any other type of non-defined report that is made in accordance with the system procedures as notified in accordance with paragraph 9 of the general principles.",8),
			];

		public static implicit operator categoryOfShipReport(int? value) => new categoryOfShipReport { value = value };
	}

	/// <summary>
	/// Classification of station based on the traffic service provided.
	/// </summary>
	public class categoryOfSignalStationTraffic : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfSignalStationTraffic);
		[JsonIgnore]
		public override string S100FC_name => "Category of Signal Station, Traffic";
		public static listedValue[] listedValues => [
				new listedValue("Port Control", "A signal station for the control of vessels within a port.",1),
				new listedValue("Port Entry and Departure", "A signal station for the control of vessels entering or leaving a port.",2),
				new listedValue("International Port Traffic", "A signal station displaying International Port Traffic signals.",3),
				new listedValue("Berthing", "A signal station for the control of vessels when berthing.",4),
				new listedValue("Dock", "A signal station for the control of vessels entering or leaving a dock.",5),
				new listedValue("Lock", "A signal station for the control of vessels entering or leaving a lock.",6),
				new listedValue("Flood Barrage Station", "A signal station for the control of vessels wishing to pass through a flood control barrage.",7),
				new listedValue("Bridge Passage", "A signal station for the control of vessels wishing to pass under a bridge.",8),
				new listedValue("Dredging", "A signal station indicating when dredging is in progress.",9),
				new listedValue("Traffic Control Light", "Visual signal lights placed in a waterway to indicate to shipping the movements authorized at the time at which they are shown.",10),
				new listedValue("Oncoming Traffic Indication", "Indicates the oncoming traffic on an inland waterway.",13),
			];

		public static implicit operator categoryOfSignalStationTraffic(int? value) => new categoryOfSignalStationTraffic { value = value };
	}

	/// <summary>
	/// Classification of station based on the warning service provided.
	/// </summary>
	public class categoryOfSignalStationWarning : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfSignalStationWarning);
		[JsonIgnore]
		public override string S100FC_name => "Category of Signal Station, Warning";
		public static listedValue[] listedValues => [
				new listedValue("Danger", "A signal or message warning of the presence of a danger to navigation.",1),
				new listedValue("Maritime Obstruction", "A signal or message warning of the presence of a maritime obstruction.",2),
				new listedValue("Cable", "A signal or message warning of the presence of a cable.",3),
				new listedValue("Military Practice", "A signal or message warning of activity in a military practice area.",4),
				new listedValue("Distress", "A station that may receive or transmit distress signals.",5),
				new listedValue("Weather", "A visual signal displayed to indicate a weather forecast.",6),
				new listedValue("Storm", "A signal or message conveying information about storm conditions.",7),
				new listedValue("Ice Warning", "A signal or message conveying information about ice conditions.",8),
				new listedValue("Time", "An accurate signal marking a specified time or time interval. It is used primarily for determining errors of timepieces. Such signals are usually sent from an observatory by radio or telegraph, but visual signals are used at some ports.",9),
				new listedValue("Tide", "A signal or message conveying information on tidal conditions in the area in question.",10),
				new listedValue("Tidal Stream", "A signal or message conveying information on condition of tidal currents in the area in question.",11),
				new listedValue("Tide Gauge", "A device for measuring the height of tide. A graduated staff in a sheltered area where visual observations can be made or it may consist of an elaborate recording instrument making a continuous graphic record of tide height against time. Such an instrument is usually actuated by a float in a pipe communicating with the sea through a small hole which filters out shorter waves.",12),
				new listedValue("Tide Scale", "A visual scale which directly shows the height of the water above chart datum or a local datum.",13),
				new listedValue("Diving", "A signal or message warning of diving activity.",14),
				new listedValue("Water Level Gauge", "A device for measuring and conveying information about the water level (non-tidal) in the area in question.",15),
				new listedValue("Vertical Clearance Indication", "An indication of the vertical clearance of a bridge, overhead cable, etc.",16),
				new listedValue("High Water Mark", "An indication of the official high water level.",17),
				new listedValue("Depth Indication", "An indication of the local depth.",18),
			];

		public static implicit operator categoryOfSignalStationWarning(int? value) => new categoryOfSignalStationWarning { value = value };
	}

	/// <summary>
	/// An assessment of the likelihood of change over time.
	/// </summary>
	public class categoryOfTemporalVariation : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfTemporalVariation);
		[JsonIgnore]
		public override string S100FC_name => "Category of Temporal Variation";
		public static listedValue[] listedValues => [
				new listedValue("Extreme Event", "Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.",1),
				new listedValue("Likely to Change", "Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).",4),
				new listedValue("Unlikely to Change", "Significant change to the seafloor is not expected.",5),
				new listedValue("Unassessed", "Not having been assessed.",6),
			];

		public static implicit operator categoryOfTemporalVariation(int? value) => new categoryOfTemporalVariation { value = value };
	}

	/// <summary>
	/// Classification of completeness of textual information in relation to the source material from which it is derived.
	/// </summary>
	public class categoryOfText : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfText);
		[JsonIgnore]
		public override string S100FC_name => "Category of Text";
		public static listedValue[] listedValues => [
				new listedValue("Abstract or Summary", "A statement summarizing the important points of a text.",1),
				new listedValue("Extract", "An excerpt or excerpts from a text.",2),
				new listedValue("Full Text", "The whole text.",3),
			];

		public static implicit operator categoryOfText(int? value) => new categoryOfText { value = value };
	}

	/// <summary>
	/// International classification of traffic separation scheme.
	/// </summary>
	public class categoryOfTrafficSeparationScheme : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfTrafficSeparationScheme);
		[JsonIgnore]
		public override string S100FC_name => "Category of Traffic Separation Scheme";
		public static listedValue[] listedValues => [
				new listedValue("IMO Adopted", "A defined maritime traffic route that has been adopted as an IMO routeing measure.",1),
				new listedValue("Not IMO - Adopted", "A defined Traffic Separation Scheme that has not been adopted as an IMO routing measure.",2),
			];

		public static implicit operator categoryOfTrafficSeparationScheme(int? value) => new categoryOfTrafficSeparationScheme { value = value };
	}

	/// <summary>
	/// The locality of vessel registration or enrolment relative to the nationality of a port, territorial sea, administrative area, exclusive zone or other location.
	/// </summary>
	public class categoryOfVesselRegistry : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfVesselRegistry);
		[JsonIgnore]
		public override string S100FC_name => "Category of Vessel Registry";
		public static listedValue[] listedValues => [
				new listedValue("Domestic", "The vessel is registered or enrolled under the same national flag as the port, harbour, territorial sea, exclusive economic zone, or administrative area in which the object that possesses this attribute applies or is located.",1),
				new listedValue("Foreign", "The vessel is registered or enrolled under a national flag different from the port, harbour, territorial sea, exclusive economic zone, or other administrative area in which the object that possesses this attribute applies or is located.",2),
			];

		public static implicit operator categoryOfVesselRegistry(int? value) => new categoryOfVesselRegistry { value = value };
	}

	/// <summary>
	/// The name of a town or city.
	/// </summary>
	public class cityName : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cityName);
		[JsonIgnore]
		public override string S100FC_name => "City Name";

		public static implicit operator cityName(String? value) => new cityName { value = value };
	}

	/// <summary>
	/// A channel number assigned to a specific radio frequency, frequencies or frequency band.
	/// </summary>
	public class communicationChannel : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(communicationChannel);
		[JsonIgnore]
		public override string S100FC_name => "Communication Channel";

		public static implicit operator communicationChannel(String? value) => new communicationChannel { value = value };
	}

	/// <summary>
	/// Numerical comparison.
	/// </summary>
	public class comparisonOperator : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(comparisonOperator);
		[JsonIgnore]
		public override string S100FC_name => "Comparison Operator";
		public static listedValue[] listedValues => [
				new listedValue("Greater Than", "The value of the left value is greater than that of the right.",1),
				new listedValue("Greater Than or Equal To", "The value of the left expression is greater than or equal to that of the right.",2),
				new listedValue("Less Than", "The value of the left expression is less than that of the right.",3),
				new listedValue("Less Than or Equal To", "The value of the left expression is less than or equal to that of the right.",4),
				new listedValue("Equal To", "The two values are equivalent.",5),
				new listedValue("Not Equal To", "The two values are not equivalent.",6),
			];

		public static implicit operator comparisonOperator(int? value) => new comparisonOperator { value = value };
	}

	/// <summary>
	/// The various conditions of buildings and other constructions.
	/// </summary>
	public class condition : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(condition);
		[JsonIgnore]
		public override string S100FC_name => "Condition";
		public static listedValue[] listedValues => [
				new listedValue("Under Construction", "Being built but not yet capable of function.",1),
				new listedValue("Under Reclamation", "An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.",3),
				new listedValue("Planned Construction", "Detailed planning has been completed but construction has not been initiated.",5),
			];

		public static implicit operator condition(int? value) => new condition { value = value };
	}

	/// <summary>
	/// Instructions provided on how to contact a particular person, organisation or service.
	/// </summary>
	public class contactInstructions : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(contactInstructions);
		[JsonIgnore]
		public override string S100FC_name => "Contact Instructions";

		public static implicit operator contactInstructions(String? value) => new contactInstructions { value = value };
	}

	/// <summary>
	/// The name of a nation.
	/// </summary>
	public class countryName : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(countryName);
		[JsonIgnore]
		public override string S100FC_name => "Country Name";

		public static implicit operator countryName(String? value) => new countryName { value = value };
	}

	/// <summary>
	/// The latest date on which an object (for example a buoy) will be present.
	/// </summary>
	public class dateEnd : S100FC.S100_TruncatedDateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dateEnd);
		[JsonIgnore]
		public override string S100FC_name => "Date End";

		public static implicit operator dateEnd(String? value) => new dateEnd { value = value };
	}

	/// <summary>
	/// The date of an event.
	/// </summary>
	public class dateFixed : S100FC.S100_TruncatedDateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dateFixed);
		[JsonIgnore]
		public override string S100FC_name => "Date Fixed";

		public static implicit operator dateFixed(String? value) => new dateFixed { value = value };
	}

	/// <summary>
	/// The earliest date on which an object (for example a buoy) will be present.
	/// </summary>
	public class dateStart : S100FC.S100_TruncatedDateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dateStart);
		[JsonIgnore]
		public override string S100FC_name => "Date Start";

		public static implicit operator dateStart(String? value) => new dateStart { value = value };
	}

	/// <summary>
	/// A day which is not fixed in the Gregorian calendar.
	/// </summary>
	public class dateVariable : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dateVariable);
		[JsonIgnore]
		public override string S100FC_name => "Date Variable";

		public static implicit operator dateVariable(String? value) => new dateVariable { value = value };
	}

	/// <summary>
	/// Any one of seven days in a week.
	/// </summary>
	public class dayOfWeek : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dayOfWeek);
		[JsonIgnore]
		public override string S100FC_name => "Day of Week";
		public static listedValue[] listedValues => [
				new listedValue("Sunday", "The first day of the week.",1),
				new listedValue("Monday", "The second day of the week.",2),
				new listedValue("Tuesday", "The third day of the week.",3),
				new listedValue("Wednesday", "The fourth day of the week.",4),
				new listedValue("Thursday", "The fifth day of the week.",5),
				new listedValue("Friday", "The sixth day of the week.",6),
				new listedValue("Saturday", "The seventh day of the week.",7),
			];

		public static implicit operator dayOfWeek(int? value) => new dayOfWeek { value = value };
	}

	/// <summary>
	/// A statement expressing if the days of the week identified define a range or not.
	/// </summary>
	public class dayOfWeekIsRange : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dayOfWeekIsRange);
		[JsonIgnore]
		public override string S100FC_name => "Day of Week is Range";

		public static implicit operator dayOfWeekIsRange(Boolean? value) => new dayOfWeekIsRange { value = value };
	}

	/// <summary>
	/// Details of where post can be delivered such as the apartment, name and/or number of a street, building or PO Box.
	/// </summary>
	public class deliveryPoint : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(deliveryPoint);
		[JsonIgnore]
		public override string S100FC_name => "Delivery Point";

		public static implicit operator deliveryPoint(String? value) => new deliveryPoint { value = value };
	}

	/// <summary>
	/// The place or general direction to which a vessel is going or directed.
	/// </summary>
	public class destination : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(destination);
		[JsonIgnore]
		public override string S100FC_name => "Destination";

		public static implicit operator destination(String? value) => new destination { value = value };
	}

	/// <summary>
	/// A numeric measure of the spatial separation between two locations.
	/// </summary>
	public class distance : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(distance);
		[JsonIgnore]
		public override string S100FC_name => "Distance";

		public static implicit operator distance(decimal? value) => new distance { value = value };
	}

	/// <summary>
	/// Whether a vessel must use a shore-based or other resource to obtain up-to-date information.
	/// </summary>
	public class dynamicResource : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dynamicResource);
		[JsonIgnore]
		public override string S100FC_name => "Dynamic Resource";
		public static listedValue[] listedValues => [
				new listedValue("Static", "The information is static, or a source of up-to-date information is unavailable or unknown.",1),
				new listedValue("Mandatory External Dynamic", "An external source of up-to-date information is available and interaction with it to obtain up-to-date information is required.",2),
				new listedValue("Optional External Dynamic", "An external source of up-to-date information is available but interaction with it to obtain up-to-date information is not required.",3),
				new listedValue("Onboard Dynamic", "Up-to-date information may be computed using only onboard resources.",4),
			];

		public static implicit operator dynamicResource(int? value) => new dynamicResource { value = value };
	}

	/// <summary>
	/// The location of a fragment of text or other information in a support file.
	/// </summary>
	public class fileLocator : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fileLocator);
		[JsonIgnore]
		public override string S100FC_name => "File Locator";

		public static implicit operator fileLocator(String? value) => new fileLocator { value = value };
	}

	/// <summary>
	/// The file name of an externally referenced text file.
	/// </summary>
	public class fileReference : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fileReference);
		[JsonIgnore]
		public override string S100FC_name => "File Reference";

		public static implicit operator fileReference(String? value) => new fileReference { value = value };
	}

	/// <summary>
	/// The shore station receiver frequency.
	/// </summary>
	[RangeConstraintInteger(0, int.MaxValue, Closure.gtSemiInterval)]
	public class frequencyShoreStationReceives : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyShoreStationReceives);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Shore Station Receives";

		public static implicit operator frequencyShoreStationReceives(int? value) => new frequencyShoreStationReceives { value = value };
	}

	/// <summary>
	/// The shore station transmitter frequency.
	/// </summary>
	[RangeConstraintInteger(0, int.MaxValue, Closure.gtSemiInterval)]
	public class frequencyShoreStationTransmits : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyShoreStationTransmits);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Shore Station Transmits";

		public static implicit operator frequencyShoreStationTransmits(int? value) => new frequencyShoreStationTransmits { value = value };
	}

	/// <summary>
	/// Words set at the head of a passage or page to introduce or categorize.
	/// </summary>
	public class headline : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(headline);
		[JsonIgnore]
		public override string S100FC_name => "Headline";

		public static implicit operator headline(String? value) => new headline { value = value };
	}

	/// <summary>
	/// The best estimate of the horizontal accuracy of horizontal clearances and distances.
	/// </summary>
	public class horizontalDistanceUncertainty : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(horizontalDistanceUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Horizontal Distance Uncertainty";

		public static implicit operator horizontalDistanceUncertainty(decimal? value) => new horizontalDistanceUncertainty { value = value };
	}

	/// <summary>
	/// Whether a report must be in an IMO standard format.
	/// </summary>
	public class iMOFormatForReporting : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(iMOFormatForReporting);
		[JsonIgnore]
		public override string S100FC_name => "IMO Format for Reporting";

		public static implicit operator iMOFormatForReporting(Boolean? value) => new iMOFormatForReporting { value = value };
	}

	/// <summary>
	/// A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.
	/// </summary>
	public class interoperabilityIdentifier : S100FC.UrnTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(interoperabilityIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Interoperability Identifier";

		public static implicit operator interoperabilityIdentifier(String? value) => new interoperabilityIdentifier { value = value };
	}

	/// <summary>
	/// Classification of ISPS security levels according to the ISPS Code.
	/// </summary>
	public class iSPSLevel : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(iSPSLevel);
		[JsonIgnore]
		public override string S100FC_name => "ISPS level";
		public static listedValue[] listedValues => [
				new listedValue("ISPS Level 1", "The level for which minimum appropriate protective security measures shall be maintained at all times.",1),
				new listedValue("ISPS Level 2", "The level for which appropriate additional protective security measures shall be maintained for a period of time as a result of heightened risk of a security incident.",2),
				new listedValue("ISPS Level 3", "The level for which further specific protective security measures shall be maintained for a limited period of time when a security incident is probable or imminent, although it may not be possible to identify the specific target.",3),
			];

		public static implicit operator iSPSLevel(int? value) => new iSPSLevel { value = value };
	}

	/// <summary>
	/// Whether the vessel is in ballast.
	/// </summary>
	public class inBallast : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(inBallast);
		[JsonIgnore]
		public override string S100FC_name => "In Ballast";

		public static implicit operator inBallast(Boolean? value) => new inBallast { value = value };
	}

	/// <summary>
	/// The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.
	/// </summary>
	public class language : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(language);
		[JsonIgnore]
		public override string S100FC_name => "Language";

		public static implicit operator language(String? value) => new language { value = value };
	}

	/// <summary>
	/// Location (address) for on-line access using a URL/URI address or similar addressing scheme.
	/// </summary>
	public class linkage : S100FC.UriTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(linkage);
		[JsonIgnore]
		public override string S100FC_name => "Linkage";

		public static implicit operator linkage(String? value) => new linkage { value = value };
	}

	/// <summary>
	/// Indicates whether a vessel is included or excluded from the regulation/restriction/recommendation/nautical information.
	/// </summary>
	public class membership : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(membership);
		[JsonIgnore]
		public override string S100FC_name => "Membership";
		public static listedValue[] listedValues => [
				new listedValue("Included", "Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.",1),
				new listedValue("Excluded", "Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.",2),
			];

		public static implicit operator membership(int? value) => new membership { value = value };
	}

	/// <summary>
	/// Classification of the type and display level of the name of a feature in an end-user system.
	/// </summary>
	public class nameUsage : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(nameUsage);
		[JsonIgnore]
		public override string S100FC_name => "Name Usage";
		public static listedValue[] listedValues => [
				new listedValue("Default Name Display", "The name is intended to be displayed when the end-user system is set to the default name/text display setting.",1),
				new listedValue("Alternate Name Display", "The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.",2),
				new listedValue("No Chart Display", "The name or text is not intended to be displayed.",3),
			];

		public static implicit operator nameUsage(int? value) => new nameUsage { value = value };
	}

	/// <summary>
	/// Expresses whether all the constraints described by its co-attributes must be satisfied, or only one such constraint need be satisfied.
	/// </summary>
	public class logicalConnectives : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(logicalConnectives);
		[JsonIgnore]
		public override string S100FC_name => "Logical Connectives";
		public static listedValue[] listedValues => [
				new listedValue("Logical Conjunction", "All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.",1),
				new listedValue("Logical Disjunction", "At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.",2),
			];

		public static implicit operator logicalConnectives(int? value) => new logicalConnectives { value = value };
	}

	/// <summary>
	/// The largest intended viewing scale for the data.
	/// </summary>
	[RangeConstraintInteger(1, int.MaxValue, Closure.geSemiInterval)]
	public class maximumDisplayScale : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Maximum Display Scale";

		public static implicit operator maximumDisplayScale(int? value) => new maximumDisplayScale { value = value };
	}

	/// <summary>
	/// The smallest intended viewing scale for the data.
	/// </summary>
	[RangeConstraintInteger(1, int.MaxValue, Closure.geSemiInterval)]
	public class minimumDisplayScale : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minimumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Minimum Display Scale";

		public static implicit operator minimumDisplayScale(int? value) => new minimumDisplayScale { value = value };
	}

	/// <summary>
	/// The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations, coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.
	/// </summary>
	[StringLengthConstraint(9)]
	[TextPatternConstraint(@"\d{9}")]
	public class mMSICode : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(mMSICode);
		[JsonIgnore]
		public override string S100FC_name => "MMSI Code";

		public static implicit operator mMSICode(String? value) => new mMSICode { value = value };
	}

	/// <summary>
	/// The individual name of a feature.
	/// </summary>
	public class name : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(name);
		[JsonIgnore]
		public override string S100FC_name => "Name";

		public static implicit operator name(String? value) => new name { value = value };
	}

	/// <summary>
	/// Name of the online resource.
	/// </summary>
	public class nameOfResource : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(nameOfResource);
		[JsonIgnore]
		public override string S100FC_name => "Name of Resource";

		public static implicit operator nameOfResource(String? value) => new nameOfResource { value = value };
	}

	/// <summary>
	/// Identifier of membership of a particular nation.
	/// </summary>
	public class nationality : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(nationality);
		[JsonIgnore]
		public override string S100FC_name => "Nationality";

		public static implicit operator nationality(String? value) => new nationality { value = value };
	}

	/// <summary>
	/// The time duration prior to the time the service is needed, when notice must be provided to the service provider.
	/// </summary>
	[PrecisionConstraint(1)]
	public class noticeTimeHours : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(noticeTimeHours);
		[JsonIgnore]
		public override string S100FC_name => "Notice Time Hours";

		public static implicit operator noticeTimeHours(decimal? value) => new noticeTimeHours { value = value };
	}

	/// <summary>
	/// Text string qualifying the notice time hours. This may explain the time specification of the hours (for example, 3 working days for a value of 72 for the notice time hours intended to indicate a time period of 3 days) or consist of other language qualifying the time; for example, On departure from last port or On passing reporting line XY).
	/// </summary>
	public class noticeTimeText : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(noticeTimeText);
		[JsonIgnore]
		public override string S100FC_name => "Notice Time Text";

		public static implicit operator noticeTimeText(String? value) => new noticeTimeText { value = value };
	}

	/// <summary>
	/// Code for function performed by the online resource.
	/// </summary>
	public class onlineFunction : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineFunction);
		[JsonIgnore]
		public override string S100FC_name => "Online Function";
		public static listedValue[] listedValues => [
				new listedValue("Download", "Online instructions for transferring data from one storage device or system to another.",1),
				new listedValue("Offline Access", "Online instructions for requesting the resource from the provider.",3),
				new listedValue("Order", "Online order process for obtaining the resource.",4),
				new listedValue("Search", "To make painstaking investigation or examination.",5),
				new listedValue("Complete Metadata", "Complete metadata provided.",6),
				new listedValue("Browse Graphic", "Browse graphic provided.",7),
				new listedValue("Upload", "Online resource upload capability provided.",8),
				new listedValue("Email Service", "Online email service provided.",9),
				new listedValue("Browsing", "Online browsing provided.",10),
				new listedValue("File Access", "Online file access provided.",11),
			];

		public static implicit operator onlineFunction(int? value) => new onlineFunction { value = value };
	}

	/// <summary>
	/// Detailed text description of what the online resource is/does.
	/// </summary>
	public class onlineResourceDescription : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineResourceDescription);
		[JsonIgnore]
		public override string S100FC_name => "Online Resource Description";

		public static implicit operator onlineResourceDescription(String? value) => new onlineResourceDescription { value = value };
	}

	/// <summary>
	/// Indicates whether the minimum or maximum value should be used to describe a condition or in application processing.
	/// </summary>
	public class operation : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(operation);
		[JsonIgnore]
		public override string S100FC_name => "Operation";
		public static listedValue[] listedValues => [
				new listedValue("Largest Value", "The numerically largest value computed from the applicable attributes or sub-attributes.",1),
				new listedValue("Smallest Value", "The numerically smallest value computed from the applicable attributes or sub-attributes.",2),
			];

		public static implicit operator operation(int? value) => new operation { value = value };
	}

	/// <summary>
	/// The largest intended viewing scale for the data.
	/// </summary>
	[RangeConstraintInteger(1, int.MaxValue, Closure.geSemiInterval)]
	public class optimumDisplayScale : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(optimumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Optimum Display Scale";

		public static implicit operator optimumDisplayScale(int? value) => new optimumDisplayScale { value = value };
	}

	/// <summary>
	/// The best estimate of the accuracy of a bearing.
	/// </summary>
	[PrecisionConstraint(3)]
	[RangeConstraintReal(0.000d, 360.000d, Closure.closedInterval)]
	public class orientationUncertainty : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(orientationUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Orientation Uncertainty";

		public static implicit operator orientationUncertainty(decimal? value) => new orientationUncertainty { value = value };
	}

	/// <summary>
	/// The angular distance measured from true north to the major axis of the feature.
	/// </summary>
	[PrecisionConstraint(1)]
	[RangeConstraintReal(0.0d, 360.0d, Closure.closedInterval)]
	public class orientationValue : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(orientationValue);
		[JsonIgnore]
		public override string S100FC_name => "Orientation Value";

		public static implicit operator orientationValue(decimal? value) => new orientationValue { value = value };
	}

	/// <summary>
	/// Indicates whether a pictorial representation of the feature is available.
	/// </summary>
	public class pictorialRepresentation : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pictorialRepresentation);
		[JsonIgnore]
		public override string S100FC_name => "Pictorial Representation";

		public static implicit operator pictorialRepresentation(String? value) => new pictorialRepresentation { value = value };
	}

	/// <summary>
	/// Short description of the purpose of the image.
	/// </summary>
	public class pictureCaption : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pictureCaption);
		[JsonIgnore]
		public override string S100FC_name => "Picture Caption";

		public static implicit operator pictureCaption(String? value) => new pictureCaption { value = value };
	}

	/// <summary>
	/// A set of information to provide credits to picture creator, copyright owner etc.
	/// </summary>
	public class pictureInformation : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pictureInformation);
		[JsonIgnore]
		public override string S100FC_name => "Picture Information";

		public static implicit operator pictureInformation(String? value) => new pictureInformation { value = value };
	}

	/// <summary>
	/// Classification of pilot activity by arrival, departure, or change of pilot. It may also describe the place where the pilot's advice begins, ends, or is transferred to a different pilot.
	/// </summary>
	public class pilotMovement : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pilotMovement);
		[JsonIgnore]
		public override string S100FC_name => "Pilot Movement";
		public static listedValue[] listedValues => [
				new listedValue("Embarkation", "The place where vessels not being navigated according to a pilot's instructions pick up a pilot while in transit from sea to a port or constricted waters for future navigation under pilot instructions.",1),
				new listedValue("Disembarkation", "The place where vessels being navigated under a pilot's instructions in transit from sea to a port or constricted waters drop the pilot and proceed without being subject to pilot instructions.",2),
				new listedValue("Pilot Change", "The place where vessels being navigated under a pilot's instructions drop off the pilot and pick up a different pilot for future navigation under pilot's instructions.",3),
			];

		public static implicit operator pilotMovement(int? value) => new pilotMovement { value = value };
	}

	/// <summary>
	/// Classification of pilots and pilot services by type of license qualification or type of organization providing services.
	/// </summary>
	public class pilotQualification : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pilotQualification);
		[JsonIgnore]
		public override string S100FC_name => "Pilot Qualification";
		public static listedValue[] listedValues => [
				new listedValue("Government Pilot", "A pilot service carried out by government pilots.",1),
				new listedValue("Pilot Approved by Government", "A pilot service carried out by pilots who are approved by government.",2),
				new listedValue("State Pilot", "A pilot that is licensed by the State (USA) and/or their respective pilot association, required for all foreign vessels and all American vessels under registry, bound for a port with compulsory State pilotage. A federal licence is not sufficient to pilot such vessels into the port.",3),
				new listedValue("Federal Pilot", "A pilot who carries a Federal endorsement, offering services to vessels that are not required to obtain compulsory State pilotage. Services are usually contracted for in advance.",4),
				new listedValue("Company Pilot", "A pilot provided by a commercial company.",5),
				new listedValue("Local Pilot", "A pilot with local knowledge but who does not hold a qualification as a pilot.",6),
				new listedValue("Citizen With Sufficient Local Knowledge", "A pilot service carried out by a citizen with sufficient local knowledge.",7),
				new listedValue("Citizen With Doubtful Local Knowledge", "A pilot service carried out by a citizen whose local knowledge is uncertain.",8),
			];

		public static implicit operator pilotQualification(int? value) => new pilotQualification { value = value };
	}

	/// <summary>
	/// Description of the pilot request procedure.
	/// </summary>
	public class pilotRequest : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pilotRequest);
		[JsonIgnore]
		public override string S100FC_name => "Pilot Request";

		public static implicit operator pilotRequest(String? value) => new pilotRequest { value = value };
	}

	/// <summary>
	/// Description of the pilot vessel. The pilot vessel is a small vessel used by a pilot to go to or from a vessel employing the pilot's services.
	/// </summary>
	public class pilotVessel : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pilotVessel);
		[JsonIgnore]
		public override string S100FC_name => "Pilot Vessel";

		public static implicit operator pilotVessel(String? value) => new pilotVessel { value = value };
	}

	/// <summary>
	/// Known in various countries as a postcode, or ZIP code, the postal code is a series of letters and/or digits that identifies each postal delivery area.
	/// </summary>
	public class postalCode : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(postalCode);
		[JsonIgnore]
		public override string S100FC_name => "Postal Code";

		public static implicit operator postalCode(String? value) => new postalCode { value = value };
	}

	/// <summary>
	/// Connection protocol to be used. Example: ftp, http get KVP, http POST, etc.
	/// </summary>
	public class protocol : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(protocol);
		[JsonIgnore]
		public override string S100FC_name => "Protocol";

		public static implicit operator protocol(String? value) => new protocol { value = value };
	}

	/// <summary>
	/// Request used to access the resource. Structure and content depend on the protocol and standard used by the online resource, such as Web Feature Service standard.
	/// </summary>
	public class protocolRequest : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(protocolRequest);
		[JsonIgnore]
		public override string S100FC_name => "Protocol Request";

		public static implicit operator protocolRequest(String? value) => new protocolRequest { value = value };
	}

	/// <summary>
	/// The degree of reliability attributed to a position.
	/// </summary>
	public class qualityOfHorizontalMeasurement : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(qualityOfHorizontalMeasurement);
		[JsonIgnore]
		public override string S100FC_name => "Quality of Horizontal Measurement";
		public static listedValue[] listedValues => [
				new listedValue("Surveyed", "The position(s) was(were) determined by the operation of making measurements for determining the relative position of points on, above or beneath the earth's surface. Survey implies a regular, controlled survey of any date.",1),
				new listedValue("Unsurveyed", "Survey data is does not exist or is very poor.",2),
				new listedValue("Inadequately Surveyed", "Not surveyed to modern standards; or due to its age, scale, or positional or vertical uncertainties is not suitable to the type of navigation expected in the area.",3),
				new listedValue("Approximate", "A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to an object whose position does not remain fixed.",4),
				new listedValue("Position Doubtful", "Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.",5),
				new listedValue("Unreliable", "A feature's position has been obtained from questionable or unreliable data.",6),
				new listedValue("Reported (Not Surveyed)", "An object whose position has been reported and its position confirmed by some means other than a formal survey such as an independent report of the same object.",7),
				new listedValue("Reported (Not Confirmed)", "An object whose position has been reported and its position has not been confirmed.",8),
				new listedValue("Estimated", "The most probable position of an object determined from incomplete data or data of questionable accuracy.",9),
				new listedValue("Precisely Known", "A position that is of a known value, such as the position of an anchor berth or other defined object.",10),
				new listedValue("Calculated", "A position that is computed from data.",11),
			];

		public static implicit operator qualityOfHorizontalMeasurement(int? value) => new qualityOfHorizontalMeasurement { value = value };
	}

	/// <summary>
	/// Indication as to whether pilotage is available remotely from shore or other location remote from the vessel requiring pilotage or not.
	/// </summary>
	public class remotePilot : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(remotePilot);
		[JsonIgnore]
		public override string S100FC_name => "Remote Pilot";

		public static implicit operator remotePilot(Boolean? value) => new remotePilot { value = value };
	}

	/// <summary>
	/// The date that the item was observed, done, or investigated.
	/// </summary>
	public class reportedDate : S100FC.S100_TruncatedDateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(reportedDate);
		[JsonIgnore]
		public override string S100FC_name => "Reported Date";

		public static implicit operator reportedDate(String? value) => new reportedDate { value = value };
	}

	/// <summary>
	/// Something needed to ensure constant acoustic monitoring.
	/// </summary>
	public class requirementsForMaintenanceOfListeningWatch : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(requirementsForMaintenanceOfListeningWatch);
		[JsonIgnore]
		public override string S100FC_name => "Requirements for Maintenance of Listening Watch";

		public static implicit operator requirementsForMaintenanceOfListeningWatch(String? value) => new requirementsForMaintenanceOfListeningWatch { value = value };
	}

	/// <summary>
	/// The official legal statute of each kind of restricted area.
	/// </summary>
	public class restriction : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(restriction);
		[JsonIgnore]
		public override string S100FC_name => "Restriction";
		public static listedValue[] listedValues => [
				new listedValue("Anchoring Prohibited", "An area within which anchoring is not permitted.",1),
				new listedValue("Anchoring Restricted", "A specified area designated by appropriate authority, within which anchoring is restricted in accordance with certain specified conditions.",2),
				new listedValue("Fishing Prohibited", "An area within which fishing is not permitted.",3),
				new listedValue("Fishing Restricted", "A specified area designated by appropriate authority, within which fishing is restricted in accordance with certain specified conditions.",4),
				new listedValue("Trawling Prohibited", "An area within which trawling is not permitted.",5),
				new listedValue("Trawling Restricted", "A specified area designated by appropriate authority, within which trawling is restricted in accordance with certain specified conditions.",6),
				new listedValue("Entry Prohibited", "An area within which navigation and/or anchoring is prohibited.",7),
				new listedValue("Entry Restricted", "A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.",8),
				new listedValue("Dredging Prohibited", "An area within which dredging is not permitted.",9),
				new listedValue("Dredging Restricted", "A specified area designated by appropriate authority, within which dredging is restricted in accordance with certain specified conditions.",10),
				new listedValue("Diving Prohibited", "An area within which diving is not permitted.",11),
				new listedValue("Diving Restricted", "A specified area designated by appropriate authority, within which diving is restricted in accordance with certain specified conditions.",12),
				new listedValue("No Wake", "Mariners must adjust the speed of their vessels to reduce the wave or wash which may cause erosion or disturb moored vessels.",13),
				new listedValue("Area To Be Avoided", "An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.",14),
				new listedValue("Construction Prohibited", "The erection of permanent or temporary fixed structures or artificial islands is prohibited.",15),
				new listedValue("Discharging Prohibited", "An area within which discharging or dumping is prohibited.",16),
				new listedValue("Discharging Restricted", "A specified area designated by an appropriate authority, within which discharging or dumping is restricted in accordance with specified conditions.",17),
				new listedValue("Industrial or Mineral Exploration/Development Prohibited", "An area within which industrial or mineral exploration and development are prohibited.",18),
				new listedValue("Industrial or Mineral Exploration/Development Restricted", "A specified area designated by an appropriate authority, within which industrial or mineral exploration and development is restricted in accordance with certain specified conditions.",19),
				new listedValue("Drilling Prohibited", "An area within which excavating a hole on the sea-bottom with a drill is prohibited.",20),
				new listedValue("Drilling Restricted", "A specified area designated by an appropriate authority, within which excavating a hole on the sea-bottom with a drill is restricted in accordance with certain specified conditions.",21),
				new listedValue("Removal of Historical Artefacts Prohibited", "An area within which the removal of historical artefacts is prohibited.",22),
				new listedValue("Cargo Transhipment (Lightening) Prohibited", "An area in which cargo transhipment (lightening) is prohibited.",23),
				new listedValue("Dragging Prohibited", "An area in which the dragging of anything along the bottom, e.g. bottom trawling, is prohibited.",24),
				new listedValue("Stopping Prohibited", "An area in which a vessel is prohibited from stopping.",25),
				new listedValue("Landing Prohibited", "An area in which landing is prohibited.",26),
				new listedValue("Speed Restricted", "An area within which speed is restricted.",27),
				new listedValue("Overtaking Prohibited", "A specified area designated by appropriate authority, within which overtaking is generally prohibited.",28),
				new listedValue("Overtaking of Convoys by Convoys Prohibited", "A specified area designated by appropriate authority, within which overtaking between convoys is prohibited.",29),
				new listedValue("Passing or Overtaking Prohibited", "A specified area designated by appropriate authority, within which passing or overtaking is generally prohibited.",30),
				new listedValue("Berthing Prohibited", "A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not berth.",31),
				new listedValue("Berthing Restricted", "A specified area designated by appropriate authority, within which berthing is restricted.",32),
				new listedValue("Making Fast Prohibited", "A specified area designated by appropriate authority, within which vessels, assemblies of floating material or floating establishments may not make fast to the bank.",33),
				new listedValue("Making Fast Restricted", "A specified area designated by appropriate authority, within which making fast to the bank is restricted.",34),
				new listedValue("Turning Prohibited", "A specified area designated by appropriate authority, within which all turning is generally prohibited.",35),
				new listedValue("Restricted Fairway Depth", "An area within which the fairway depth is restricted.",36),
				new listedValue("Restricted Fairway Width", "An area within which the fairway width is restricted.",37),
				new listedValue("Use of Spuds Prohibited", "The use of anchoring spuds (telescopic piles) is prohibited.",38),
				new listedValue("Swimming Prohibited", "An area in which swimming is prohibited.",39),
				new listedValue("SOx Emission Restricted", "An area within which the emission of SOx is restricted.",40),
				new listedValue("NOx Emission Restricted", "An area within which the emission of NOx is restricted.",41),
				new listedValue("Power-Driven Vessels Prohibited", "An area within which any vessel propelled by machinery is prohibited.",42),
				new listedValue("Passing or Overtaking of Convoys by Convoys Prohibited", "A specified area designated by appropriate authority, within which passing or overtaking of convoys by convoys is prohibited",43),
			];

		public static implicit operator restriction(int? value) => new restriction { value = value };
	}

	/// <summary>
	/// The minimum scale at which the feature may be used for example for ECDIS presentation.
	/// </summary>
	public class scaleMinimum : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(scaleMinimum);
		[JsonIgnore]
		public override string S100FC_name => "Scale Minimum";

		public static implicit operator scaleMinimum(int? value) => new scaleMinimum { value = value };
	}

	/// <summary>
	/// A description of the procedure to access the marine service.
	/// </summary>
	public class serviceAccessProcedure : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(serviceAccessProcedure);
		[JsonIgnore]
		public override string S100FC_name => "Service Access Procedure";

		public static implicit operator serviceAccessProcedure(String? value) => new serviceAccessProcedure { value = value };
	}

	/// <summary>
	/// A description of the rate at which the depth in an area decreases.
	/// </summary>
	public class siltationRate : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(siltationRate);
		[JsonIgnore]
		public override string S100FC_name => "Siltation Rate";

		public static implicit operator siltationRate(String? value) => new siltationRate { value = value };
	}

	/// <summary>
	/// The publication, document, or reference work from which information comes or is acquired.
	/// </summary>
	public class source : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(source);
		[JsonIgnore]
		public override string S100FC_name => "Source";

		public static implicit operator source(String? value) => new source { value = value };
	}

	/// <summary>
	/// The production date of the source; for example the date of measurement.
	/// </summary>
	public class sourceDate : S100FC.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceDate);
		[JsonIgnore]
		public override string S100FC_name => "Source Date";

		public static implicit operator sourceDate(DateOnly? value) => new sourceDate { value = value };
	}

	/// <summary>
	/// The standard ship reporting formats according to IMO Resolution A.531(13) General Principles for Ship Reporting System or IMO A.851(20).
	/// </summary>
	public class sRSFormatCode : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sRSFormatCode);
		[JsonIgnore]
		public override string S100FC_name => "SRS Format Code";
		public static listedValue[] listedValues => [
				new listedValue("IMO Ship Reporting Format A", "IMO Ship Reporting Format A-Ship (alpha); Information required: Name, call sign or ship station identity, and flag",1),
				new listedValue("IMO Ship Reporting Format B", "IMO Ship Reporting Format B-Time (bravo); Information required: A 6-digit group giving day of month (first two digits), hours and minutes (last four digits). If other than UTC state time zone used",2),
				new listedValue("IMO Ship Reporting Format C", "IMO Ship Reporting Format C-Position (charlie); Information required: A 4-digit group giving latitude in degrees and minutes suffixed with N (north) or S (south) and a 5-digit group giving longitude in degrees and minutes suffixed with E (east) or W (west)",3),
				new listedValue("IMO Ship Reporting Format D", "IMO Ship Reporting Format D-Position (delta); Information required: True bearing (first 3-digits) and distance (state distance) in nautical miles from a clearly identified landmark (state landmark)",4),
				new listedValue("IMO Ship Reporting Format E", "IMO Ship Reporting Format E-Course (echo); Information required: True course, a 3-digit group",5),
				new listedValue("IMO Ship Reporting Format F", "IMO Ship Reporting Format F-Speed (foxtrot); Information required: Speed in knots and tenths of knots, a 3-digit group",6),
				new listedValue("IMO Ship Reporting Format G", "IMO Ship Reporting Format G-Departed (golf); Information required: Name of last port of call",7),
				new listedValue("IMO Ship Reporting Format H", "IMO Ship Reporting Format H-Entry (hotel); Information required: Entry time expressed as in (B) and entry position expressed as in (C) or (D)",8),
				new listedValue("IMO Ship Reporting Format I", "IMO Ship Reporting Format I-Destination and ETA (india); Information required: Name of port and date time group expressed as in (B)",9),
				new listedValue("IMO Ship Reporting Format J", "IMO Ship Reporting Format J-Pilot (juliet); Information required: State whether a deep-sea or local pilot is on board",10),
				new listedValue("IMO Ship Reporting Format K", "IMO Ship Reporting Format K-Exit (kilo); Information required: Exit time expressed as in (B) and exit position expressed as in (C) or (D)",11),
				new listedValue("IMO Ship Reporting Format L", "IMO Ship Reporting Format L-Route (lima); Information required: Intended track",12),
				new listedValue("IMO Ship Reporting Format M", "IMO Ship Reporting Format M-Radio communications (mike); Information required: State in full names of stations/frequencies guarded",13),
				new listedValue("IMO Ship Reporting Format N", "IMO Ship Reporting Format N-Next report (november); Information required: Date time group expressed as in (B)",14),
				new listedValue("IMO Ship Reporting Format O", "IMO Ship Reporting Format O-Draught (oscar); Information required: 4-digit group giving metres and centimetres",15),
				new listedValue("IMO Ship Reporting Format P", "IMO Ship Reporting Format P-Cargo (papa); Information required: Cargo and brief details of any dangerous cargoes as well as harmful substances and gases that could endanger persons or the environment (See detailed reporting requirements)",16),
				new listedValue("IMO Ship Reporting Format Q", "IMO Ship Reporting Format Q-Defect, damage, deficiency, limitations (quebec); Information required: Brief details of defects, damage, deficiencies or other limitations (See detailed reporting requirements)",17),
				new listedValue("IMO Ship Reporting Format R", "IMO Ship Reporting Format R-Pollution/dangerous goods lost overboard (romeo); Information required: Brief details of type of pollution (oil, chemicals, etc.) or dangerous goods lost overboard;  position expressed as in (C) or (D) (See detailed reporting requirements)",18),
				new listedValue("IMO Ship Reporting Format S", "IMO Ship Reporting Format S-Weather (sierra); Information required: Brief details of weather and sea conditions prevailing",19),
				new listedValue("IMO Ship Reporting Format T", "IMO Ship Reporting Format T-Agent (tango); Information required: Details of name and particulars of ship's representative or owner or both for provision of information (See detailed reporting requirements)",20),
				new listedValue("IMO Ship Reporting Format U", "IMO Ship Reporting Format U-Size and type (uniform); Information required: Details of length, breadth, tonnage, and type, etc., as required",21),
				new listedValue("IMO Ship Reporting Format V", "IMO Ship Reporting Format V-Medic (victor); Information required: Doctor, physician's assistant, nurse, personnel without medical training",22),
				new listedValue("IMO Ship Reporting Format W", "IMO Ship Reporting Format W-Persons (whiskey); Information required: State number",23),
				new listedValue("IMO Ship Reporting Format X", "IMO Ship Reporting Format X-Remarks (x-ray); Information required: Any other information-including, as appropriate, brief details of incident and of other ships involved either in incident, assistance or salvage (See detailed reporting requirements)",24),
				new listedValue("IMO Ship Reporting Format Y", "IMO Ship Reporting Format Y-Relay (yankee); Information required: Content of report",25),
				new listedValue("IMO Ship Reporting Format Z", "IMO Ship Reporting Format Z-End of report (zulu); Information required: No further information required",26),
			];

		public static implicit operator sRSFormatCode(int? value) => new sRSFormatCode { value = value };
	}

	/// <summary>
	/// Type of the source.
	/// </summary>
	public class sourceType : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceType);
		[JsonIgnore]
		public override string S100FC_name => "Source Type";
		public static listedValue[] listedValues => [
				new listedValue("Law or Regulation", "Treaty, convention, or international agreement; law or regulation issued by a national or other authority.",1),
				new listedValue("Official Publication", "Publication not having the force of law, issued by an international organisation or a national or local administration.",2),
				new listedValue("Mariner Report, Confirmed", "Reported by mariner(s) and confirmed by another source.",7),
				new listedValue("Mariner Report, Not Confirmed", "Reported by mariner(s) but not confirmed.",8),
				new listedValue("Industry Publications and Reports", "Shipping and other industry publications, including graphics, charts and web sites.",9),
				new listedValue("Remotely Sensed Images", "Information obtained from satellite images.",10),
				new listedValue("Photographs", "Information obtained from photographs.",11),
				new listedValue("Products Issued by HO Services", "Information obtained from products issued by Hydrographic Offices.",12),
				new listedValue("News Media", "Information obtained from news media.",13),
				new listedValue("Traffic Data", "Information obtained from the analysis of traffic data.",14),
			];

		public static implicit operator sourceType(int? value) => new sourceType { value = value };
	}

	/// <summary>
	/// The condition of an object at a given instant in time.
	/// </summary>
	public class status : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(status);
		[JsonIgnore]
		public override string S100FC_name => "Status";
		public static listedValue[] listedValues => [
				new listedValue("Permanent", "Intended to last or function indefinitely.",1),
				new listedValue("Occasional", "Acting on special occasions; happening irregularly.",2),
				new listedValue("Recommended", "Presented as worthy of confidence, acceptance, use, etc.",3),
				new listedValue("Not in Use", "Use has ceased, but the facility still exists intact; disused.",4),
				new listedValue("Periodic/Intermittent", "Recurring at intervals.",5),
				new listedValue("Reserved", "Set apart for some specific use.",6),
				new listedValue("Temporary", "Meant to last only for a time.",7),
				new listedValue("Private", "Administered by an individual or corporation, rather than a State or a public body.",8),
				new listedValue("Mandatory", "Compulsory; enforced.",9),
				new listedValue("Illuminated", "Lit by floodlights, strip lights, etc.",12),
				new listedValue("Public", "Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.",14),
				new listedValue("Synchronized", "Occur at a time, coincide in point of time, be contemporary or simultaneous.",15),
				new listedValue("Watched", "Looked at or observed over a period of time especially so as to be aware of any movement or change.",16),
				new listedValue("Unwatched", "Usually automatic in operation, without any permanently-stationed personnel to superintend it.",17),
				new listedValue("Existence Doubtful", "A feature that has been reported but has not been definitely determined to exist.",18),
				new listedValue("Buoyed", "Marked by buoys.",28),
			];

		public static implicit operator status(int? value) => new status { value = value };
	}

	/// <summary>
	/// An identifier, such as words, numbers, letters, symbols, or any combination of those used to establish a contact to a particular person, organisation or service.
	/// </summary>
	public class telecommunicationIdentifier : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunicationIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunication Identifier";

		public static implicit operator telecommunicationIdentifier(String? value) => new telecommunicationIdentifier { value = value };
	}

	/// <summary>
	/// The name of a provider or type of carrier for a telecommunication service. This service may include land line based, shore based or satellite based radio connections.
	/// </summary>
	public class telecommunicationCarrier : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunicationCarrier);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunication Carrier";

		public static implicit operator telecommunicationCarrier(String? value) => new telecommunicationCarrier { value = value };
	}

	/// <summary>
	/// Classification of methods of communication over a distance by electrical, electronic, or electromagnetic means.
	/// </summary>
	public class telecommunicationService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunicationService);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunication Service";
		public static listedValue[] listedValues => [
				new listedValue("Voice", "The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.",1),
				new listedValue("Facsimile", "A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.",2),
				new listedValue("SMS", "Short Message Service is a form of text messaging communication on phones and mobile phones.",3),
				new listedValue("Data", "A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.",4),
				new listedValue("Streamed Data", "Data that is constantly received by and presented to an end-user while being delivered by a provider.",5),
				new listedValue("Telex", "A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).",6),
				new listedValue("Telegraph", "An apparatus, system or process for communication at a distance by electric transmission over wire.",7),
				new listedValue("Email", "Messages and other data exchanged between individuals using computers in a network.",8),
			];

		public static implicit operator telecommunicationService(int? value) => new telecommunicationService { value = value };
	}

	/// <summary>
	/// A non-formatted digital text string.
	/// </summary>
	public class text : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(text);
		[JsonIgnore]
		public override string S100FC_name => "Text";

		public static implicit operator text(String? value) => new text { value = value };
	}

	/// <summary>
	/// The angular distance measured from true north that text associated with a feature is positioned from the feature in an end-user system.
	/// </summary>
	[RangeConstraintInteger(0, 360, Closure.geLtInterval)]
	public class textOffsetBearing : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textOffsetBearing);
		[JsonIgnore]
		public override string S100FC_name => "Text Offset Bearing";

		public static implicit operator textOffsetBearing(int? value) => new textOffsetBearing { value = value };
	}

	/// <summary>
	/// The distance that text associated with a feature is positioned from the feature in an end-user system.
	/// </summary>
	[RangeConstraintInteger(0, 50, Closure.gtLeInterval)]
	public class textOffsetDistance : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textOffsetDistance);
		[JsonIgnore]
		public override string S100FC_name => "Text Offset Distance";

		public static implicit operator textOffsetDistance(int? value) => new textOffsetDistance { value = value };
	}

	/// <summary>
	/// A statement that expresses if text associated with a feature is to be rotated in the ECDIS display or not.
	/// </summary>
	public class textRotation : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textRotation);
		[JsonIgnore]
		public override string S100FC_name => "Text Rotation";

		public static implicit operator textRotation(Boolean? value) => new textRotation { value = value };
	}

	/// <summary>
	/// The attribute from which a text string is derived.
	/// </summary>
	public class textType : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textType);
		[JsonIgnore]
		public override string S100FC_name => "Text Type";
		public static listedValue[] listedValues => [
				new listedValue("Name", "The individual name of a feature.",1),
			];

		public static implicit operator textType(int? value) => new textType { value = value };
	}

	/// <summary>
	/// The thickness of ice that the ship can safely transit.
	/// </summary>
	[PrecisionConstraint(0)]
	[RangeConstraintInteger(0, int.MaxValue, Closure.gtSemiInterval)]
	public class thicknessOfIceCapability : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(thicknessOfIceCapability);
		[JsonIgnore]
		public override string S100FC_name => "Thickness of Ice Capability";

		public static implicit operator thicknessOfIceCapability(int? value) => new thicknessOfIceCapability { value = value };
	}

	/// <summary>
	/// The time corresponding to the end of an active period.
	/// </summary>
	public class timeOfDayEnd : S100FC.TimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeOfDayEnd);
		[JsonIgnore]
		public override string S100FC_name => "Time of Day End";

		public static implicit operator timeOfDayEnd(S100FC.S100.Time? value) => new timeOfDayEnd { value = value };
	}

	/// <summary>
	/// The time corresponding to the start of an active period.
	/// </summary>
	public class timeOfDayStart : S100FC.TimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeOfDayStart);
		[JsonIgnore]
		public override string S100FC_name => "Time of Day Start";

		public static implicit operator timeOfDayStart(S100FC.S100.Time? value) => new timeOfDayStart { value = value };
	}

	/// <summary>
	/// Direction of vessels passing a reference point.
	/// </summary>
	public class trafficFlow : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(trafficFlow);
		[JsonIgnore]
		public override string S100FC_name => "Traffic Flow";
		public static listedValue[] listedValues => [
				new listedValue("Inbound", "Traffic flow in a general direction toward a port or similar destination.",1),
				new listedValue("Outbound", "Traffic flow in a general direction away from a port or similar point of origin.",2),
				new listedValue("One-Way", "Traffic flow in one general direction only.",3),
				new listedValue("Two-Way", "Traffic flow in two generally opposite directions.",4),
			];

		public static implicit operator trafficFlow(int? value) => new trafficFlow { value = value };
	}

	/// <summary>
	/// A fixed allowance given by an authority, which is added to draught in order to maintain a minimum under keel clearance.
	/// </summary>
	[PrecisionConstraint(1)]
	public class underKeelAllowanceFixed : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(underKeelAllowanceFixed);
		[JsonIgnore]
		public override string S100FC_name => "Under Keel Allowance Fixed";

		public static implicit operator underKeelAllowanceFixed(decimal? value) => new underKeelAllowanceFixed { value = value };
	}

	/// <summary>
	/// A percentage value, given by an authority, which is applied to ship's beam in order to calculate under keel allowance.
	/// </summary>
	[PrecisionConstraint(0)]
	[RangeConstraintReal(0d, double.MaxValue, Closure.gtSemiInterval)]
	public class underKeelAllowanceVariableBeamBased : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(underKeelAllowanceVariableBeamBased);
		[JsonIgnore]
		public override string S100FC_name => "Under Keel Allowance Variable Beam Based";

		public static implicit operator underKeelAllowanceVariableBeamBased(decimal? value) => new underKeelAllowanceVariableBeamBased { value = value };
	}

	/// <summary>
	/// A percentage value, given by an authority, which is applied to ship's draught in order to calculate under keel allowance.
	/// </summary>
	[PrecisionConstraint(0)]
	[RangeConstraintReal(0d, double.MaxValue, Closure.gtSemiInterval)]
	public class underKeelAllowanceVariableDraughtBased : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(underKeelAllowanceVariableDraughtBased);
		[JsonIgnore]
		public override string S100FC_name => "Under Keel Allowance Variable Draught Based";

		public static implicit operator underKeelAllowanceVariableDraughtBased(decimal? value) => new underKeelAllowanceVariableDraughtBased { value = value };
	}

	/// <summary>
	/// The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.
	/// </summary>
	[PrecisionConstraint(1)]
	public class uncertaintyFixed : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(uncertaintyFixed);
		[JsonIgnore]
		public override string S100FC_name => "Uncertainty Fixed";

		public static implicit operator uncertaintyFixed(decimal? value) => new uncertaintyFixed { value = value };
	}

	/// <summary>
	/// The factor to be applied to the variable component of an uncertainty equation so as to provide the best estimate of the variable horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.
	/// </summary>
	public class uncertaintyVariableFactor : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(uncertaintyVariableFactor);
		[JsonIgnore]
		public override string S100FC_name => "Uncertainty Variable Factor";

		public static implicit operator uncertaintyVariableFactor(decimal? value) => new uncertaintyVariableFactor { value = value };
	}

	/// <summary>
	/// A description of the required handling characteristics of a vessel including hull design, main and auxiliary machinery, cargo handling equipment, navigation equipment and manoeuvring behaviour.
	/// </summary>
	public class vesselPerformance : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselPerformance);
		[JsonIgnore]
		public override string S100FC_name => "Vessel Performance";

		public static implicit operator vesselPerformance(String? value) => new vesselPerformance { value = value };
	}

	/// <summary>
	/// Characteristics of vessels.
	/// </summary>
	public class vesselsCharacteristics : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselsCharacteristics);
		[JsonIgnore]
		public override string S100FC_name => "Vessels Characteristics";
		public static listedValue[] listedValues => [
				new listedValue("Length Overall", "The maximum length of the ship.",1),
				new listedValue("Length at Waterline", "The ship's length measured at the waterline.",2),
				new listedValue("Breadth", "The width or beam of the vessel.",3),
				new listedValue("Draught", "The depth of water necessary to float a vessel fully loaded.",4),
				new listedValue("Displacement Tonnage", "A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement.",6),
				new listedValue("Displacement Tonnage, Light", "The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level.",7),
				new listedValue("Displacement Tonnage, Loaded", "The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft.",8),
				new listedValue("Deadweight Tonnage", "The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity.",9),
				new listedValue("Gross Tonnage", "The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.",10),
				new listedValue("Net Tonnage", "Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.",11),
				new listedValue("Panama Canal/Universal Measurement System Net Tonnage", "The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.",12),
				new listedValue("Suez Canal Net Tonnage", "The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.",13),
			];

		public static implicit operator vesselsCharacteristics(int? value) => new vesselsCharacteristics { value = value };
	}

	/// <summary>
	/// The unit used for vessel characteristics attribute.
	/// </summary>
	public class vesselsCharacteristicsUnit : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselsCharacteristicsUnit);
		[JsonIgnore]
		public override string S100FC_name => "Vessels Characteristics Unit";
		public static listedValue[] listedValues => [
				new listedValue("Metres", "The basic unit of length in the International System of Units (SI) system.",1),
				new listedValue("Metric Ton", "The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.",3),
				new listedValue("Ton", "Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m³) of salt water with a density of 64 lb/ft³(1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).",4),
				new listedValue("Short Ton", "A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).",5),
				new listedValue("Gross Ton", "Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.",6),
				new listedValue("Net Ton", "Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessel's earning space and is a function of the moulded volume of all cargo spaces of the ship.",7),
				new listedValue("Suez Canal Net Tonnage", "The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.",9),
			];

		public static implicit operator vesselsCharacteristicsUnit(int? value) => new vesselsCharacteristicsUnit { value = value };
	}

	/// <summary>
	/// The value of a particular characteristic such as a dimension or tonnage of a vessel.
	/// </summary>
	public class vesselsCharacteristicsValue : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselsCharacteristicsValue);
		[JsonIgnore]
		public override string S100FC_name => "Vessels Characteristics Value";

		public static implicit operator vesselsCharacteristicsValue(decimal? value) => new vesselsCharacteristicsValue { value = value };
	}

	/// <summary>
	/// The tendency of water level to change in a particular direction.
	/// </summary>
	public class waterLevelTrend : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(waterLevelTrend);
		[JsonIgnore]
		public override string S100FC_name => "Water Level Trend";
		public static listedValue[] listedValues => [
				new listedValue("Decreasing", "Becoming smaller in magnitude.",1),
				new listedValue("Increasing", "Becoming larger in magnitude.",2),
				new listedValue("Steady", "Constant.",3),
			];

		public static implicit operator waterLevelTrend(int? value) => new waterLevelTrend { value = value };
	}

	/// <summary>
	/// The action or activity of a vessel.
	/// </summary>
	public class actionOrActivity : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(actionOrActivity);
		[JsonIgnore]
		public override string S100FC_name => "Action or Activity";
		public static listedValue[] listedValues => [
				new listedValue("Navigating With a Pilot", "Carrying a qualified pilot as part of the vessel navigation team.",1),
				new listedValue("Entering Port", "Navigating a vessel into a port.",2),
				new listedValue("Leaving Port", "Navigating a vessel out of a port.",3),
				new listedValue("Berthing", "A signal station for the control of vessels when berthing.",4),
				new listedValue("Slipping", "Detaching a vessel from a wharf or jetty.",5),
				new listedValue("Anchoring", "Attaching a vessel to the seabed by means of an anchor and cable.",6),
				new listedValue("Weighing Anchor", "Detaching a vessel from the seabed by recovering an anchor and cable.",7),
				new listedValue("Transiting", "Navigating a vessel along a route or through a narrow gap, such as under a bridge or through a lock.",8),
				new listedValue("Overtaking", "Navigating a vessel past another traveling broadly in the same direction.",9),
				new listedValue("Reporting", "Providing details such as the name, location or intentions of a vessel.",10),
				new listedValue("Working Cargo", "Loading or unloading cargo.",11),
				new listedValue("Landing", "Placing crew or passengers on shore.",12),
				new listedValue("Diving", "A signal or message warning of diving activity.",13),
				new listedValue("Fishing", "Hunting or catching fish.",14),
				new listedValue("Discharging Overboard", "Releasing anything into the sea; often ballast water; or spoil from dredging elsewhere.",15),
				new listedValue("Passing", "Navigating a vessel past another travelling broadly in the opposite direction.",16),
				new listedValue("Ballast Water Exchange", "Discharge and uptake of ballast water.",17),
				new listedValue("Hull Cleaning", "The removal or treatment of biofouling (accumulation of aquatic organisms including microfouling and macrofouling) from a ship's submerged surfaces, including hull and niche areas, conducted either in-water or during dry-docking. The process includes both proactive cleaning (periodic removal of microfouling) and reactive cleaning (removal of micro- and macrofouling as corrective action).",18),
				new listedValue("Scientific Research", "The conduct of observational, sampling, or experimental activities by authorised personnel to collect scientific or environmental data, which may involve the deployment of scientific instruments, collection of biological or geological samples, or in-water survey operations.",19),
				new listedValue("Tourism", "Organised recreational visitation and leisure activities in marine areas, including sight-seeing, wildlife observation, glass-bottom vessel tours, and guided nature excursions conducted by commercial or permitted operators.",20),
				new listedValue("Education", "Structured activities conducted for training, awareness, or interpretive purposes involving groups or individuals learning about the marine environment, including guided educational programs, school activities, and field instruction conducted within designated marine areas.",21),
				new listedValue("Infrastructure Maintenance", "Inspection, repair, or upkeep of existing marine or coastal infrastructure such as wharves, piers, pipelines, moorings, subsea cables, navigational aids, or coastal protection structures, including minor works that do not expand the original footprint.",22),
			];
	}

	/// <summary>
	/// The principal subject matter of regulations, restrictions, recommendations or nautical information.
	/// </summary>
	public class categoryOfRxN : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRxN);
		[JsonIgnore]
		public override string S100FC_name => "Category of RxN";
		public static listedValue[] listedValues => [
				new listedValue("Navigation", "The process of directing the movement of a craft from one point to another.",1),
				new listedValue("Communication", "Transmitting and/or receiving electronic communication signals.",2),
				new listedValue("Environmental Protection", "Pertaining to environmental protection.",3),
				new listedValue("Wildlife Protection", "Pertaining to wildlife protection.",4),
				new listedValue("Security", "Pertaining to security.",5),
				new listedValue("Customs", "The agency or establishment for collecting duties, tolls.",6),
				new listedValue("Cargo Operation", "Pertaining to cargo operations.",7),
				new listedValue("Refuge", "Pertaining to a place of safety or refuge.",8),
				new listedValue("Health", "The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.",9),
				new listedValue("Natural Resources or Exploitation", "Pertaining to natural resources or exploitation.",10),
				new listedValue("Port", "Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.",11),
				new listedValue("Finance", "An authority with responsibility for the control and movement of money.",12),
				new listedValue("Agriculture", "The science, art, or practice of cultivating the soil, producing crops, and raising livestock and in varying degrees the preparation and marketing of the resulting products.",13),
			];
	}

	/// <summary>
	/// Classification of vessels by function or use.
	/// </summary>
	public class categoryOfVessel : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfVessel);
		[JsonIgnore]
		public override string S100FC_name => "Category of Vessel";
		public static listedValue[] listedValues => [
				new listedValue("General Cargo Vessel", "A vessel which is designed for carrying general cargo, e.g. boxes, sacks.",1),
				new listedValue("Container Carrier", "A vessel designed to carry ISO containers.",2),
				new listedValue("Tanker", "A vessel which is designed for carrying liquid goods, for example oil or water.",3),
				new listedValue("Bulk Carrier", "A vessel which is designed for carrying bulk goods, e.g. coal, ore or grain.",4),
				new listedValue("Passenger Vessel", "A day trip or cabin vessel constructed and equipped to carry more than 12 passengers.",5),
				new listedValue("Roll-On Roll-Off", "A vessel designed to allow road vehicles to be driven on and off; often a ferry.",6),
				new listedValue("Refrigerated Cargo Vessel", "A vessel designed to carry refrigerated cargo.",7),
				new listedValue("Fishing Vessel", "A vessel that is used and equipped for the fishing of living aquatic resources.",8),
				new listedValue("Service", "A vessel which provides a service such as a tug, anchor handler, survey or supply vessel.",9),
				new listedValue("Warship", "A vessel designed for the conduct of military operations.",10),
				new listedValue("Towed or Pushed Composite Unit", "Either a tug and tow, or any combination of a tug providing propulsion to barges or vessels secured ahead or alongside.",11),
				new listedValue("Tug and Tow", "A combination of tug(s) and non-powered tow(s).",12),
				new listedValue("Light Recreational", "A pleasure boat or watercraft, or an excursion vessel used for short cruises such as whale watching.",13),
				new listedValue("Semi-Submersible Offshore Installation", "An installation which is designed to float at all times and which is normally anchored in position when deployed in the offshore gas and oil industry.",14),
				new listedValue("Jack-Up Exploration or Project Installation", "An exploration or project installation with legs which can be raised and lowered. The legs are raised when the installation is re-positioned. When stationary the legs are lowered to the sea floor and the working platform is raised clear of the sea surface.",15),
				new listedValue("Livestock Carrier", "A vessel designed to carry large quantities of live animals.",16),
				new listedValue("Sport Fishing", "A vessel used in fishing for pleasure or competition.",17),
			];
	}

}

namespace S100FC.S127.ComplexAttributes
{
	using S100FC.S127.SimpleAttributes;

	/// <summary>
	/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
	/// </summary>
	public class contactAddress : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(contactAddress);
		[JsonIgnore]
		public override string S100FC_name => "Contact Address";

		#region Attributes
		[JsonIgnore]
		public String? deliveryPoint {
			set { base.SetAttribute(new deliveryPoint { value = value }); }
			get { return base.GetAttributeValue<deliveryPoint>(nameof(deliveryPoint))?.value; }
		}
		[JsonIgnore]
		public String? cityName {
			set { base.SetAttribute(new cityName { value = value }); }
			get { return base.GetAttributeValue<cityName>(nameof(cityName))?.value; }
		}
		[JsonIgnore]
		public String? administrativeDivision {
			set { base.SetAttribute(new administrativeDivision { value = value }); }
			get { return base.GetAttributeValue<administrativeDivision>(nameof(administrativeDivision))?.value; }
		}
		[JsonIgnore]
		public String? countryName {
			set { base.SetAttribute(new countryName { value = value }); }
			get { return base.GetAttributeValue<countryName>(nameof(countryName))?.value; }
		}
		[JsonIgnore]
		public String? postalCode {
			set { base.SetAttribute(new postalCode { value = value }); }
			get { return base.GetAttributeValue<postalCode>(nameof(postalCode))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(deliveryPoint),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new deliveryPoint(),
				},
				new attributeBindingDefinition {
					attribute = nameof(cityName),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new cityName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(administrativeDivision),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new administrativeDivision(),
				},
				new attributeBindingDefinition {
					attribute = nameof(countryName),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new countryName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(postalCode),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new postalCode(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	public class featureName : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(featureName);
		[JsonIgnore]
		public override string S100FC_name => "Feature Name";

		#region Attributes
		[JsonIgnore]
		public String? language {
			set { base.SetAttribute(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
		[JsonIgnore]
		public String? name {
			set { base.SetAttribute(new name { value = value }); }
			get { return base.GetAttributeValue<name>(nameof(name))?.value; }
		}
		[JsonIgnore]
		public int? nameUsage {
			set { base.SetAttribute(new nameUsage { value = value }); }
			get { return base.GetAttributeValue<nameUsage>(nameof(nameUsage))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new language(),
				},
				new attributeBindingDefinition {
					attribute = nameof(name),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new name(),
				},
				new attributeBindingDefinition {
					attribute = nameof(nameUsage),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3],
					CreateInstance = () => new nameUsage(),
				},
			];

		#endregion
	}

	/// <summary>
	/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
	/// </summary>
	public class fixedDateRange : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fixedDateRange);
		[JsonIgnore]
		public override string S100FC_name => "Fixed Date Range";

		#region Attributes
		[JsonIgnore]
		public String? dateStart {
			set { base.SetAttribute(new dateStart { value = value }); }
			get { return base.GetAttributeValue<dateStart>(nameof(dateStart))?.value; }
		}
		[JsonIgnore]
		public String? dateEnd {
			set { base.SetAttribute(new dateEnd { value = value }); }
			get { return base.GetAttributeValue<dateEnd>(nameof(dateEnd))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(dateStart),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new dateStart(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dateEnd),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new dateEnd(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
	/// </summary>
	public class frequencyPair : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyPair);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Pair";

		#region Attributes
		[JsonIgnore]
		public int? frequencyShoreStationReceives {
			set { base.SetAttribute(new frequencyShoreStationReceives { value = value }); }
			get { return base.GetAttributeValue<frequencyShoreStationReceives>(nameof(frequencyShoreStationReceives))?.value; }
		}
		[JsonIgnore]
		public int? frequencyShoreStationTransmits {
			set { base.SetAttribute(new frequencyShoreStationTransmits { value = value }); }
			get { return base.GetAttributeValue<frequencyShoreStationTransmits>(nameof(frequencyShoreStationTransmits))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(frequencyShoreStationReceives),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new frequencyShoreStationReceives(),
				},
				new attributeBindingDefinition {
					attribute = nameof(frequencyShoreStationTransmits),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new frequencyShoreStationTransmits(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The best estimate of the accuracy of a position.
	/// </summary>
	public class horizontalPositionUncertainty : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(horizontalPositionUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Horizontal Position Uncertainty";

		#region Attributes
		[JsonIgnore]
		public decimal? uncertaintyFixed {
			set { base.SetAttribute(new uncertaintyFixed { value = value }); }
			get { return base.GetAttributeValue<uncertaintyFixed>(nameof(uncertaintyFixed))?.value; }
		}
		[JsonIgnore]
		public decimal? uncertaintyVariableFactor {
			set { base.SetAttribute(new uncertaintyVariableFactor { value = value }); }
			get { return base.GetAttributeValue<uncertaintyVariableFactor>(nameof(uncertaintyVariableFactor))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(uncertaintyFixed),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new uncertaintyFixed(),
				},
				new attributeBindingDefinition {
					attribute = nameof(uncertaintyVariableFactor),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new uncertaintyVariableFactor(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	public class information : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(information);
		[JsonIgnore]
		public override string S100FC_name => "Information";

		#region Attributes
		[JsonIgnore]
		public String? fileLocator {
			set { base.SetAttribute(new fileLocator { value = value }); }
			get { return base.GetAttributeValue<fileLocator>(nameof(fileLocator))?.value; }
		}
		[JsonIgnore]
		public String? fileReference {
			set { base.SetAttribute(new fileReference { value = value }); }
			get { return base.GetAttributeValue<fileReference>(nameof(fileReference))?.value; }
		}
		[JsonIgnore]
		public String?[] headline {
			set { base.SetAttribute("headline", [.. value.Select(e=> new headline { value = e })]); }
			get { return base.GetAttributeValues<headline>(nameof(headline)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? language {
			set { base.SetAttribute(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
		[JsonIgnore]
		public String? text {
			set { base.SetAttribute(new text { value = value }); }
			get { return base.GetAttributeValue<text>(nameof(text))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(fileLocator),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new fileLocator(),
				},
				new attributeBindingDefinition {
					attribute = nameof(fileReference),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new fileReference(),
				},
				new attributeBindingDefinition {
					attribute = nameof(headline),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new headline(),
				},
				new attributeBindingDefinition {
					attribute = nameof(language),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new language(),
				},
				new attributeBindingDefinition {
					attribute = nameof(text),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new text(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Span of time, prior to the time the service is needed, for preparations to be made to fulfill the requirement.
	/// </summary>
	public class noticeTime : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(noticeTime);
		[JsonIgnore]
		public override string S100FC_name => "Notice Time";

		#region Attributes
		[JsonIgnore]
		public decimal?[] noticeTimeHours {
			set { base.SetAttribute("noticeTimeHours", [.. value.Select(e=> new noticeTimeHours { value = e })]); }
			get { return base.GetAttributeValues<noticeTimeHours>(nameof(noticeTimeHours)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? noticeTimeText {
			set { base.SetAttribute(new noticeTimeText { value = value }); }
			get { return base.GetAttributeValue<noticeTimeText>(nameof(noticeTimeText))?.value; }
		}
		[JsonIgnore]
		public int? operation {
			set { base.SetAttribute(new operation { value = value }); }
			get { return base.GetAttributeValue<operation>(nameof(operation))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(noticeTimeHours),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new noticeTimeHours(),
				},
				new attributeBindingDefinition {
					attribute = nameof(noticeTimeText),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new noticeTimeText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(operation),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2],
					CreateInstance = () => new operation(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	public class onlineResource : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineResource);
		[JsonIgnore]
		public override string S100FC_name => "Online Resource";

		#region Attributes
		[JsonIgnore]
		public String? linkage {
			set { base.SetAttribute(new linkage { value = value }); }
			get { return base.GetAttributeValue<linkage>(nameof(linkage))?.value; }
		}
		[JsonIgnore]
		public String? protocol {
			set { base.SetAttribute(new protocol { value = value }); }
			get { return base.GetAttributeValue<protocol>(nameof(protocol))?.value; }
		}
		[JsonIgnore]
		public String? applicationProfile {
			set { base.SetAttribute(new applicationProfile { value = value }); }
			get { return base.GetAttributeValue<applicationProfile>(nameof(applicationProfile))?.value; }
		}
		[JsonIgnore]
		public String? nameOfResource {
			set { base.SetAttribute(new nameOfResource { value = value }); }
			get { return base.GetAttributeValue<nameOfResource>(nameof(nameOfResource))?.value; }
		}
		[JsonIgnore]
		public String? onlineResourceDescription {
			set { base.SetAttribute(new onlineResourceDescription { value = value }); }
			get { return base.GetAttributeValue<onlineResourceDescription>(nameof(onlineResourceDescription))?.value; }
		}
		[JsonIgnore]
		public int? onlineFunction {
			set { base.SetAttribute(new onlineFunction { value = value }); }
			get { return base.GetAttributeValue<onlineFunction>(nameof(onlineFunction))?.value; }
		}
		[JsonIgnore]
		public String? protocolRequest {
			set { base.SetAttribute(new protocolRequest { value = value }); }
			get { return base.GetAttributeValue<protocolRequest>(nameof(protocolRequest))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(linkage),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new linkage(),
				},
				new attributeBindingDefinition {
					attribute = nameof(protocol),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new protocol(),
				},
				new attributeBindingDefinition {
					attribute = nameof(applicationProfile),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new applicationProfile(),
				},
				new attributeBindingDefinition {
					attribute = nameof(nameOfResource),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new nameOfResource(),
				},
				new attributeBindingDefinition {
					attribute = nameof(onlineResourceDescription),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new onlineResourceDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(onlineFunction),
					lower = 0,
					upper = 1,
					order = 5,
					permitedValues = [1,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new onlineFunction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(protocolRequest),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new protocolRequest(),
				},
			];

		#endregion
	}

	/// <summary>
	/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
	/// </summary>
	public class orientation : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(orientation);
		[JsonIgnore]
		public override string S100FC_name => "Orientation";

		#region Attributes
		[JsonIgnore]
		public decimal? orientationUncertainty {
			set { base.SetAttribute(new orientationUncertainty { value = value }); }
			get { return base.GetAttributeValue<orientationUncertainty>(nameof(orientationUncertainty))?.value; }
		}
		[JsonIgnore]
		public decimal? orientationValue {
			set { base.SetAttribute(new orientationValue { value = value }); }
			get { return base.GetAttributeValue<orientationValue>(nameof(orientationValue))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(orientationUncertainty),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new orientationUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientationValue),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new orientationValue(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The active period of a recurring event or occurrence.
	/// </summary>
	public class periodicDateRange : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(periodicDateRange);
		[JsonIgnore]
		public override string S100FC_name => "Periodic Date Range";

		#region Attributes
		[JsonIgnore]
		public String? dateStart {
			set { base.SetAttribute(new dateStart { value = value }); }
			get { return base.GetAttributeValue<dateStart>(nameof(dateStart))?.value; }
		}
		[JsonIgnore]
		public String? dateEnd {
			set { base.SetAttribute(new dateEnd { value = value }); }
			get { return base.GetAttributeValue<dateEnd>(nameof(dateEnd))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(dateStart),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new dateStart(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new dateEnd(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
	/// </summary>
	public class rxNCode : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(rxNCode);
		[JsonIgnore]
		public override string S100FC_name => "RxN Code";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfRxN {
			set { base.SetAttribute(new categoryOfRxN { value = value }); }
			get { return base.GetAttributeValue<categoryOfRxN>(nameof(categoryOfRxN))?.value; }
		}
		[JsonIgnore]
		public int? actionOrActivity {
			set { base.SetAttribute(new actionOrActivity { value = value }); }
			get { return base.GetAttributeValue<actionOrActivity>(nameof(actionOrActivity))?.value; }
		}
		[JsonIgnore]
		public String?[] headline {
			set { base.SetAttribute("headline", [.. value.Select(e=> new headline { value = e })]); }
			get { return base.GetAttributeValues<headline>(nameof(headline)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfRxN),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new categoryOfRxN(),
				},
				new attributeBindingDefinition {
					attribute = nameof(actionOrActivity),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22],
					CreateInstance = () => new actionOrActivity(),
				},
				new attributeBindingDefinition {
					attribute = nameof(headline),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new headline(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
	/// </summary>
	public class sourceIndication : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceIndication);
		[JsonIgnore]
		public override string S100FC_name => "Source Indication";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfAuthority {
			set { base.SetAttribute(new categoryOfAuthority { value = value }); }
			get { return base.GetAttributeValue<categoryOfAuthority>(nameof(categoryOfAuthority))?.value; }
		}
		[JsonIgnore]
		public String? countryName {
			set { base.SetAttribute(new countryName { value = value }); }
			get { return base.GetAttributeValue<countryName>(nameof(countryName))?.value; }
		}
		[JsonIgnore]
		public String? source {
			set { base.SetAttribute(new source { value = value }); }
			get { return base.GetAttributeValue<source>(nameof(source))?.value; }
		}
		[JsonIgnore]
		public int? sourceType {
			set { base.SetAttribute(new sourceType { value = value }); }
			get { return base.GetAttributeValue<sourceType>(nameof(sourceType))?.value; }
		}
		[JsonIgnore]
		public String? reportedDate {
			set { base.SetAttribute(new reportedDate { value = value }); }
			get { return base.GetAttributeValue<reportedDate>(nameof(reportedDate))?.value; }
		}
		[JsonIgnore]
		public featureName?[] featureName {
			set { base.SetAttribute("featureName", value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfAuthority),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new attributeBindingDefinition {
					attribute = nameof(countryName),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new countryName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(source),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new source(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceType),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,7,8,9,10,11,12,13,14],
					CreateInstance = () => new sourceType(),
				},
				new attributeBindingDefinition {
					attribute = nameof(reportedDate),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new reportedDate(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new featureName(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
	/// </summary>
	public class surveyDateRange : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(surveyDateRange);
		[JsonIgnore]
		public override string S100FC_name => "Survey Date Range";

		#region Attributes
		[JsonIgnore]
		public String? dateStart {
			set { base.SetAttribute(new dateStart { value = value }); }
			get { return base.GetAttributeValue<dateStart>(nameof(dateStart))?.value; }
		}
		[JsonIgnore]
		public String? dateEnd {
			set { base.SetAttribute(new dateEnd { value = value }); }
			get { return base.GetAttributeValue<dateEnd>(nameof(dateEnd))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(dateStart),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new dateStart(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new dateEnd(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
	/// </summary>
	public class spatialAccuracy : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(spatialAccuracy);
		[JsonIgnore]
		public override string S100FC_name => "Spatial Accuracy";

		#region Attributes
		[JsonIgnore]
		public fixedDateRange? fixedDateRange {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public horizontalPositionUncertainty? horizontalPositionUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<horizontalPositionUncertainty>(nameof(horizontalPositionUncertainty)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	public class telecommunications : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunications);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunications";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfCommunicationPreference {
			set { base.SetAttribute(new categoryOfCommunicationPreference { value = value }); }
			get { return base.GetAttributeValue<categoryOfCommunicationPreference>(nameof(categoryOfCommunicationPreference))?.value; }
		}
		[JsonIgnore]
		public String? telecommunicationIdentifier {
			set { base.SetAttribute(new telecommunicationIdentifier { value = value }); }
			get { return base.GetAttributeValue<telecommunicationIdentifier>(nameof(telecommunicationIdentifier))?.value; }
		}
		[JsonIgnore]
		public String? telecommunicationCarrier {
			set { base.SetAttribute(new telecommunicationCarrier { value = value }); }
			get { return base.GetAttributeValue<telecommunicationCarrier>(nameof(telecommunicationCarrier))?.value; }
		}
		[JsonIgnore]
		public String? contactInstructions {
			set { base.SetAttribute(new contactInstructions { value = value }); }
			get { return base.GetAttributeValue<contactInstructions>(nameof(contactInstructions))?.value; }
		}
		[JsonIgnore]
		public int?[] telecommunicationService {
			set { base.SetAttribute("telecommunicationService", [.. value.Select(e=> new telecommunicationService { value = e })]); }
			get { return base.GetAttributeValues<telecommunicationService>(nameof(telecommunicationService)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCommunicationPreference),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfCommunicationPreference(),
				},
				new attributeBindingDefinition {
					attribute = nameof(telecommunicationIdentifier),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new telecommunicationIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(telecommunicationCarrier),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new telecommunicationCarrier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(contactInstructions),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new contactInstructions(),
				},
				new attributeBindingDefinition {
					attribute = nameof(telecommunicationService),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new telecommunicationService(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
	/// </summary>
	public class textContent : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textContent);
		[JsonIgnore]
		public override string S100FC_name => "Text Content";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfText {
			set { base.SetAttribute(new categoryOfText { value = value }); }
			get { return base.GetAttributeValue<categoryOfText>(nameof(categoryOfText))?.value; }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		[JsonIgnore]
		public onlineResource? onlineResource {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<onlineResource>(nameof(onlineResource)); }
		}
		[JsonIgnore]
		public sourceIndication?[] sourceIndication {
			set { base.SetAttribute("sourceIndication", value); }
			get { return base.GetAttributeValues<sourceIndication>(nameof(sourceIndication)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfText),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new onlineResource(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new sourceIndication(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The regular weekly operation times of a service or schedule.
	/// </summary>
	public class timeIntervalsByDayOfWeek : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeIntervalsByDayOfWeek);
		[JsonIgnore]
		public override string S100FC_name => "Time Intervals by Day of Week";

		#region Attributes
		[JsonIgnore]
		public int?[] dayOfWeek {
			set { base.SetAttribute("dayOfWeek", [.. value.Select(e=> new dayOfWeek { value = e })]); }
			get { return base.GetAttributeValues<dayOfWeek>(nameof(dayOfWeek)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? dayOfWeekIsRange {
			set { base.SetAttribute(new dayOfWeekIsRange { value = value }); }
			get { return base.GetAttributeValue<dayOfWeekIsRange>(nameof(dayOfWeekIsRange))?.value; }
		}
		[JsonIgnore]
		public S100FC.S100.Time?[] timeOfDayStart {
			set { base.SetAttribute("timeOfDayStart", [.. value.Select(e=> new timeOfDayStart { value = e })]); }
			get { return base.GetAttributeValues<timeOfDayStart>(nameof(timeOfDayStart)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public S100FC.S100.Time?[] timeOfDayEnd {
			set { base.SetAttribute("timeOfDayEnd", [.. value.Select(e=> new timeOfDayEnd { value = e })]); }
			get { return base.GetAttributeValues<timeOfDayEnd>(nameof(timeOfDayEnd)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(dayOfWeek),
					lower = 0,
					upper = 7,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new dayOfWeek(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dayOfWeekIsRange),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new dayOfWeekIsRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(timeOfDayStart),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new timeOfDayStart(),
				},
				new attributeBindingDefinition {
					attribute = nameof(timeOfDayEnd),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new timeOfDayEnd(),
				},
			];

		#endregion
	}

	/// <summary>
	/// 	A fixed figure, or a figure derived by calculation, which is added to draught in order to maintain the minimum under keel clearance taking into account the vessel's static and dynamic characteristics, sea state and weather forecast, the reliability of the chart and variance from predicted height of tide or water level.
	/// </summary>
	public class underKeelAllowance : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(underKeelAllowance);
		[JsonIgnore]
		public override string S100FC_name => "Under Keel Allowance";

		#region Attributes
		[JsonIgnore]
		public decimal? underKeelAllowanceFixed {
			set { base.SetAttribute(new underKeelAllowanceFixed { value = value }); }
			get { return base.GetAttributeValue<underKeelAllowanceFixed>(nameof(underKeelAllowanceFixed))?.value; }
		}
		[JsonIgnore]
		public decimal? underKeelAllowanceVariableBeamBased {
			set { base.SetAttribute(new underKeelAllowanceVariableBeamBased { value = value }); }
			get { return base.GetAttributeValue<underKeelAllowanceVariableBeamBased>(nameof(underKeelAllowanceVariableBeamBased))?.value; }
		}
		[JsonIgnore]
		public decimal? underKeelAllowanceVariableDraughtBased {
			set { base.SetAttribute(new underKeelAllowanceVariableDraughtBased { value = value }); }
			get { return base.GetAttributeValue<underKeelAllowanceVariableDraughtBased>(nameof(underKeelAllowanceVariableDraughtBased))?.value; }
		}
		[JsonIgnore]
		public int? operation {
			set { base.SetAttribute(new operation { value = value }); }
			get { return base.GetAttributeValue<operation>(nameof(operation))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(underKeelAllowanceFixed),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new underKeelAllowanceFixed(),
				},
				new attributeBindingDefinition {
					attribute = nameof(underKeelAllowanceVariableBeamBased),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new underKeelAllowanceVariableBeamBased(),
				},
				new attributeBindingDefinition {
					attribute = nameof(underKeelAllowanceVariableDraughtBased),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new underKeelAllowanceVariableDraughtBased(),
				},
				new attributeBindingDefinition {
					attribute = nameof(operation),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2],
					CreateInstance = () => new operation(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
	/// </summary>
	public class vesselMeasurementsSpecification : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselMeasurementsSpecification);
		[JsonIgnore]
		public override string S100FC_name => "Vessel Measurements Specification";

		#region Attributes
		[JsonIgnore]
		public int? comparisonOperator {
			set { base.SetAttribute(new comparisonOperator { value = value }); }
			get { return base.GetAttributeValue<comparisonOperator>(nameof(comparisonOperator))?.value; }
		}
		[JsonIgnore]
		public int? vesselsCharacteristics {
			set { base.SetAttribute(new vesselsCharacteristics { value = value }); }
			get { return base.GetAttributeValue<vesselsCharacteristics>(nameof(vesselsCharacteristics))?.value; }
		}
		[JsonIgnore]
		public decimal? vesselsCharacteristicsValue {
			set { base.SetAttribute(new vesselsCharacteristicsValue { value = value }); }
			get { return base.GetAttributeValue<vesselsCharacteristicsValue>(nameof(vesselsCharacteristicsValue))?.value; }
		}
		[JsonIgnore]
		public int? vesselsCharacteristicsUnit {
			set { base.SetAttribute(new vesselsCharacteristicsUnit { value = value }); }
			get { return base.GetAttributeValue<vesselsCharacteristicsUnit>(nameof(vesselsCharacteristicsUnit))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(comparisonOperator),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new comparisonOperator(),
				},
				new attributeBindingDefinition {
					attribute = nameof(vesselsCharacteristics),
					lower = 1,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,6,7,8,9,10,11,12,13],
					CreateInstance = () => new vesselsCharacteristics(),
				},
				new attributeBindingDefinition {
					attribute = nameof(vesselsCharacteristicsValue),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new vesselsCharacteristicsValue(),
				},
				new attributeBindingDefinition {
					attribute = nameof(vesselsCharacteristicsUnit),
					lower = 1,
					upper = 1,
					order = 3,
					permitedValues = [1,3,4,5,6,7,9],
					CreateInstance = () => new vesselsCharacteristicsUnit(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A bearing is the direction one object is from another object.
	/// </summary>
	public class bearingInformation : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(bearingInformation);
		[JsonIgnore]
		public override string S100FC_name => "Bearing Information";

		#region Attributes
		[JsonIgnore]
		public int? cardinalDirection {
			set { base.SetAttribute(new cardinalDirection { value = value }); }
			get { return base.GetAttributeValue<cardinalDirection>(nameof(cardinalDirection))?.value; }
		}
		[JsonIgnore]
		public decimal? distance {
			set { base.SetAttribute(new distance { value = value }); }
			get { return base.GetAttributeValue<distance>(nameof(distance))?.value; }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		[JsonIgnore]
		public orientation? orientation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<orientation>(nameof(orientation)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(cardinalDirection),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new cardinalDirection(),
				},
				new attributeBindingDefinition {
					attribute = nameof(distance),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new distance(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientation),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new orientation(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
	/// </summary>
	public class graphic : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(graphic);
		[JsonIgnore]
		public override string S100FC_name => "Graphic";

		#region Attributes
		[JsonIgnore]
		public String?[] pictorialRepresentation {
			set { base.SetAttribute("pictorialRepresentation", [.. value.Select(e=> new pictorialRepresentation { value = e })]); }
			get { return base.GetAttributeValues<pictorialRepresentation>(nameof(pictorialRepresentation)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? pictureCaption {
			set { base.SetAttribute(new pictureCaption { value = value }); }
			get { return base.GetAttributeValue<pictureCaption>(nameof(pictureCaption))?.value; }
		}
		[JsonIgnore]
		public DateOnly? sourceDate {
			set { base.SetAttribute(new sourceDate { value = value }); }
			get { return base.GetAttributeValue<sourceDate>(nameof(sourceDate))?.value; }
		}
		[JsonIgnore]
		public String? pictureInformation {
			set { base.SetAttribute(new pictureInformation { value = value }); }
			get { return base.GetAttributeValue<pictureInformation>(nameof(pictureInformation))?.value; }
		}
		[JsonIgnore]
		public bearingInformation? bearingInformation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<bearingInformation>(nameof(bearingInformation)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(pictorialRepresentation),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new pictorialRepresentation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pictureCaption),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new pictureCaption(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceDate),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new sourceDate(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pictureInformation),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new pictureInformation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(bearingInformation),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new bearingInformation(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The nature and timings of a daily schedule by days of the week.
	/// </summary>
	public class scheduleByDayOfWeek : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(scheduleByDayOfWeek);
		[JsonIgnore]
		public override string S100FC_name => "Schedule by Day of Week";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfSchedule {
			set { base.SetAttribute(new categoryOfSchedule { value = value }); }
			get { return base.GetAttributeValue<categoryOfSchedule>(nameof(categoryOfSchedule))?.value; }
		}
		[JsonIgnore]
		public String? text {
			set { base.SetAttribute(new text { value = value }); }
			get { return base.GetAttributeValue<text>(nameof(text))?.value; }
		}
		[JsonIgnore]
		public timeIntervalsByDayOfWeek?[] timeIntervalsByDayOfWeek {
			set { base.SetAttribute("timeIntervalsByDayOfWeek", value); }
			get { return base.GetAttributeValues<timeIntervalsByDayOfWeek>(nameof(timeIntervalsByDayOfWeek)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSchedule),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfSchedule(),
				},
				new attributeBindingDefinition {
					attribute = nameof(text),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new text(),
				},
				new attributeBindingDefinition {
					attribute = nameof(timeIntervalsByDayOfWeek),
					lower = 1,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new timeIntervalsByDayOfWeek(),
				},
			];

		#endregion
	}

}

namespace S100FC.S127.InformationAssociation
{
	using S100FC.S127.SimpleAttributes;
	using S100FC.S127.ComplexAttributes;

	/// <summary>
	/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
	/// </summary>
	public class AdditionalInformation : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AdditionalInformation);
		[JsonIgnore]
		public override string S100FC_name => "Additional information";
		public static string role => "theInformation";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Contact information for an authority
	/// </summary>
	public class AuthorityContact : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AuthorityContact);
		[JsonIgnore]
		public override string S100FC_name => "Authority contact";
		public static string role => "theAuthority";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Service hours for an authority
	/// </summary>
	public class AuthorityHours : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AuthorityHours);
		[JsonIgnore]
		public override string S100FC_name => "Authority hours";
		public static string role => "theAuthority_srvHrs";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
	/// </summary>
	public class AssociatedRxN : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AssociatedRxN);
		[JsonIgnore]
		public override string S100FC_name => "Associated RxN";
		public static string role => "theRxN";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Exception to the usual working day
	/// </summary>
	public class ExceptionalWorkday : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ExceptionalWorkday);
		[JsonIgnore]
		public override string S100FC_name => "Exceptional workday";
		public static string role => "theServiceHours_nsdy";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
	/// </summary>
	public class InclusionType : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(InclusionType);
		[JsonIgnore]
		public override string S100FC_name => "InclusionType";
		public static string role => "theApplicableRxN";

		#region Attributes
		[JsonIgnore]
		public int? membership {
			set { base.SetAttribute(new membership { value = value }); }
			get { return base.GetAttributeValue<membership>(nameof(membership))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(membership),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2],
					CreateInstance = () => new membership(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
	/// </summary>
	public class PermissionType : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PermissionType);
		[JsonIgnore]
		public override string S100FC_name => "Permission Type";
		public static string role => "permission";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfRelationship {
			set { base.SetAttribute(new categoryOfRelationship { value = value }); }
			get { return base.GetAttributeValue<categoryOfRelationship>(nameof(categoryOfRelationship))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfRelationship),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new categoryOfRelationship(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Related organisation
	/// </summary>
	public class RelatedOrganisation : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RelatedOrganisation);
		[JsonIgnore]
		public override string S100FC_name => "Related organisation";
		public static string role => "organisationRelatedRxN";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// The authority with which a report must be filed
	/// </summary>
	public class ReportingAuthority : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ReportingAuthority);
		[JsonIgnore]
		public override string S100FC_name => "Reporting Authority";
		public static string role => "reportTo";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Association between types of reports and classes of vessels which must file report of the type described
	/// </summary>
	public class ReportingRequirement : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ReportingRequirement);
		[JsonIgnore]
		public override string S100FC_name => "Reporting Requirement";
		public static string role => "mustBeFiledBy";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Contact details for a service or facility
	/// </summary>
	public class ServiceContact : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ServiceContact);
		[JsonIgnore]
		public override string S100FC_name => "Service Contact";
		public static string role => "theContactDetails";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// The controlling authority for a service area
	/// </summary>
	public class ServiceControl : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ServiceControl);
		[JsonIgnore]
		public override string S100FC_name => "Service control";
		public static string role => "controlAuthority";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// An association for the binding between a spatial type and its spatial quality information.
	/// </summary>
	public class SpatialAssociation : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SpatialAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Spatial Association";
		public static string role => "theQualityInformation";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Working hours for a service or facility described by a geographic location
	/// </summary>
	public class LocationHours : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LocationHours);
		[JsonIgnore]
		public override string S100FC_name => "Location Hours";
		public static string role => "theServiceHours";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Association between traffic control service and reports required of vessels pertaining to that area
	/// </summary>
	public class TrafficServiceReport : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TrafficServiceReport);
		[JsonIgnore]
		public override string S100FC_name => "Traffic Service Report";
		public static string role => "reptForTrafficServ";

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S127.FeatureAssociation
{
	using S100FC.S127.SimpleAttributes;
	using S100FC.S127.ComplexAttributes;

	/// <summary>
	/// Association linking the location from which a service is provided and the area(s) served.
	/// </summary>
	public class ServiceProvisionArea : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ServiceProvisionArea);
		[JsonIgnore]
		public override string S100FC_name => "Service provision area";
		public static string[] roles => ["serviceArea","serviceProvider"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// A feature association for the binding between a pilotage district and its component pilot boarding places.
	/// </summary>
	public class PilotageDistrictAssociation : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PilotageDistrictAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Pilotage District Association";
		public static string[] roles => ["theCollection","theComponent"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
	public class TextAssociation : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TextAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Text association";
		public static string[] roles => ["thePositionProvider","theCartographicText"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// A feature association for the binding between a traffic control service and auxiliary features.
	/// </summary>
	public class TrafficControlServiceAggregation : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TrafficControlServiceAggregation);
		[JsonIgnore]
		public override string S100FC_name => "Traffic Control Service Aggregation";
		public static string[] roles => ["componentOf","consistsOf"];

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S127.InformationTypes
{
	using S100FC.S127.SimpleAttributes;
	using S100FC.S127.ComplexAttributes;

	/// <summary>
	/// Generalized information type which carries all the common attributes.
	/// </summary>
	public abstract class InformationType : S100FC.InformationType, IInformationBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(InformationType);
		[JsonIgnore]
		public override string S100FC_name => "Information Type";

		#region Attributes
		[JsonIgnore]
		public featureName?[] featureName {
			set { base.SetAttribute("featureName", value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); }
		}
		[JsonIgnore]
		public fixedDateRange? fixedDateRange {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public periodicDateRange?[] periodicDateRange {
			set { base.SetAttribute("periodicDateRange", value); }
			get { return base.GetAttributeValues<periodicDateRange>(nameof(periodicDateRange)); }
		}
		[JsonIgnore]
		public graphic?[] graphic {
			set { base.SetAttribute("graphic", value); }
			get { return base.GetAttributeValues<graphic>(nameof(graphic)); }
		}
		[JsonIgnore]
		public sourceIndication?[] sourceIndication {
			set { base.SetAttribute("sourceIndication", value); }
			get { return base.GetAttributeValues<sourceIndication>(nameof(sourceIndication)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new featureName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new periodicDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(graphic),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new graphic(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new sourceIndication(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => InformationType.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

	/// <summary>
	/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
	/// </summary>
	public abstract class AbstractRxN : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AbstractRxN);
		[JsonIgnore]
		public override string S100FC_name => "AbstractRxN";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfAuthority {
			set { base.SetAttribute(new categoryOfAuthority { value = value }); }
			get { return base.GetAttributeValue<categoryOfAuthority>(nameof(categoryOfAuthority))?.value; }
		}
		[JsonIgnore]
		public rxNCode?[] rxNCode {
			set { base.SetAttribute("rxNCode", value); }
			get { return base.GetAttributeValues<rxNCode>(nameof(rxNCode)); }
		}
		[JsonIgnore]
		public textContent?[] textContent {
			set { base.SetAttribute("textContent", value); }
			get { return base.GetAttributeValues<textContent>(nameof(textContent)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfAuthority),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new attributeBindingDefinition {
					attribute = nameof(rxNCode),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new rxNCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new textContent(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AbstractRxN.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. InformationType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "isApplicableTo",
					association = "InclusionType",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Applicability)],
					CreateInstance = () => new informationBinding<InformationAssociation.InclusionType>() {
						roleType = "association",
						role = "isApplicableTo",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "theOrganisation",
					association = "RelatedOrganisation",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Authority)],
					CreateInstance = () => new informationBinding<InformationAssociation.RelatedOrganisation>() {
						roleType = "association",
						role = "theOrganisation",
					},
				},
			];

		public static informationBinding<InformationAssociation.InclusionType> InclusionType => new informationBinding<InformationAssociation.InclusionType> {
			roleType = "association",
			role = "isApplicableTo",
		};
		public static informationBinding<InformationAssociation.RelatedOrganisation> RelatedOrganisation => new informationBinding<InformationAssociation.RelatedOrganisation> {
			roleType = "association",
			role = "theOrganisation",
		};

		#endregion
	}

	/// <summary>
	/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
	/// </summary>
	public class Applicability : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Applicability);
		[JsonIgnore]
		public override string S100FC_name => "Applicability";

		#region Attributes
		[JsonIgnore]
		public Boolean? inBallast {
			set { base.SetAttribute(new inBallast { value = value }); }
			get { return base.GetAttributeValue<inBallast>(nameof(inBallast))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfCargo {
			set { base.SetAttribute("categoryOfCargo", [.. value.Select(e=> new categoryOfCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfCargo>(nameof(categoryOfCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfDangerousOrHazardousCargo {
			set { base.SetAttribute("categoryOfDangerousOrHazardousCargo", [.. value.Select(e=> new categoryOfDangerousOrHazardousCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfDangerousOrHazardousCargo>(nameof(categoryOfDangerousOrHazardousCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? categoryOfVessel {
			set { base.SetAttribute(new categoryOfVessel { value = value }); }
			get { return base.GetAttributeValue<categoryOfVessel>(nameof(categoryOfVessel))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfVesselRegistry {
			set { base.SetAttribute(new categoryOfVesselRegistry { value = value }); }
			get { return base.GetAttributeValue<categoryOfVesselRegistry>(nameof(categoryOfVesselRegistry))?.value; }
		}
		[JsonIgnore]
		public int? logicalConnectives {
			set { base.SetAttribute(new logicalConnectives { value = value }); }
			get { return base.GetAttributeValue<logicalConnectives>(nameof(logicalConnectives))?.value; }
		}
		[JsonIgnore]
		public int? thicknessOfIceCapability {
			set { base.SetAttribute(new thicknessOfIceCapability { value = value }); }
			get { return base.GetAttributeValue<thicknessOfIceCapability>(nameof(thicknessOfIceCapability))?.value; }
		}
		[JsonIgnore]
		public String? vesselPerformance {
			set { base.SetAttribute(new vesselPerformance { value = value }); }
			get { return base.GetAttributeValue<vesselPerformance>(nameof(vesselPerformance))?.value; }
		}
		[JsonIgnore]
		public String? destination {
			set { base.SetAttribute(new destination { value = value }); }
			get { return base.GetAttributeValue<destination>(nameof(destination))?.value; }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		[JsonIgnore]
		public vesselMeasurementsSpecification?[] vesselMeasurementsSpecification {
			set { base.SetAttribute("vesselMeasurementsSpecification", value); }
			get { return base.GetAttributeValues<vesselMeasurementsSpecification>(nameof(vesselMeasurementsSpecification)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(inBallast),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new inBallast(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfCargo(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfDangerousOrHazardousCargo),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21],
					CreateInstance = () => new categoryOfDangerousOrHazardousCargo(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfVessel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17],
					CreateInstance = () => new categoryOfVessel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfVesselRegistry),
					lower = 0,
					upper = 1,
					order = 4,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfVesselRegistry(),
				},
				new attributeBindingDefinition {
					attribute = nameof(logicalConnectives),
					lower = 0,
					upper = 1,
					order = 5,
					permitedValues = [1,2],
					CreateInstance = () => new logicalConnectives(),
				},
				new attributeBindingDefinition {
					attribute = nameof(thicknessOfIceCapability),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new thicknessOfIceCapability(),
				},
				new attributeBindingDefinition {
					attribute = nameof(vesselPerformance),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new vesselPerformance(),
				},
				new attributeBindingDefinition {
					attribute = nameof(destination),
					lower = 0,
					upper = 1,
					order = 8,
					CreateInstance = () => new destination(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 9,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(vesselMeasurementsSpecification),
					lower = 0,
					upper = 2147483647,
					order = 10,
					CreateInstance = () => new vesselMeasurementsSpecification(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Applicability.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. InformationType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "theApplicableRxN",
					association = "InclusionType",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(AbstractRxN)],
					CreateInstance = () => new informationBinding<InformationAssociation.InclusionType>() {
						roleType = "association",
						role = "theApplicableRxN",
					},
				},
			];

		public static informationBinding<InformationAssociation.InclusionType> InclusionType => new informationBinding<InformationAssociation.InclusionType> {
			roleType = "association",
			role = "theApplicableRxN",
		};

		#endregion
	}

	/// <summary>
	/// A person or organisation having political or administrative power and control.
	/// </summary>
	public class Authority : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Authority);
		[JsonIgnore]
		public override string S100FC_name => "Authority";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfAuthority {
			set { base.SetAttribute(new categoryOfAuthority { value = value }); }
			get { return base.GetAttributeValue<categoryOfAuthority>(nameof(categoryOfAuthority))?.value; }
		}
		[JsonIgnore]
		public textContent? textContent {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<textContent>(nameof(textContent)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfAuthority),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new textContent(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Authority.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. InformationType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "theContactDetails",
					association = "AuthorityContact",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(ContactDetails)],
					CreateInstance = () => new informationBinding<InformationAssociation.AuthorityContact>() {
						roleType = "association",
						role = "theContactDetails",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "organisationRelatedRxN",
					association = "RelatedOrganisation",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(AbstractRxN)],
					CreateInstance = () => new informationBinding<InformationAssociation.RelatedOrganisation>() {
						roleType = "association",
						role = "organisationRelatedRxN",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "theServiceHours",
					association = "AuthorityHours",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.AuthorityHours>() {
						roleType = "association",
						role = "theServiceHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.AuthorityContact> AuthorityContact => new informationBinding<InformationAssociation.AuthorityContact> {
			roleType = "association",
			role = "theContactDetails",
		};
		public static informationBinding<InformationAssociation.RelatedOrganisation> RelatedOrganisation => new informationBinding<InformationAssociation.RelatedOrganisation> {
			roleType = "association",
			role = "organisationRelatedRxN",
		};
		public static informationBinding<InformationAssociation.AuthorityHours> AuthorityHours => new informationBinding<InformationAssociation.AuthorityHours> {
			roleType = "association",
			role = "theServiceHours",
		};

		#endregion
	}

	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	public class ContactDetails : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ContactDetails);
		[JsonIgnore]
		public override string S100FC_name => "Contact Details";

		#region Attributes
		[JsonIgnore]
		public String? callName {
			set { base.SetAttribute(new callName { value = value }); }
			get { return base.GetAttributeValue<callName>(nameof(callName))?.value; }
		}
		[JsonIgnore]
		public String? callSign {
			set { base.SetAttribute(new callSign { value = value }); }
			get { return base.GetAttributeValue<callSign>(nameof(callSign))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfCommunicationPreference {
			set { base.SetAttribute(new categoryOfCommunicationPreference { value = value }); }
			get { return base.GetAttributeValue<categoryOfCommunicationPreference>(nameof(categoryOfCommunicationPreference))?.value; }
		}
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? contactInstructions {
			set { base.SetAttribute(new contactInstructions { value = value }); }
			get { return base.GetAttributeValue<contactInstructions>(nameof(contactInstructions))?.value; }
		}
		[JsonIgnore]
		public String?[] language {
			set { base.SetAttribute("language", [.. value.Select(e=> new language { value = e })]); }
			get { return base.GetAttributeValues<language>(nameof(language)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? mMSICode {
			set { base.SetAttribute(new mMSICode { value = value }); }
			get { return base.GetAttributeValue<mMSICode>(nameof(mMSICode))?.value; }
		}
		[JsonIgnore]
		public contactAddress?[] contactAddress {
			set { base.SetAttribute("contactAddress", value); }
			get { return base.GetAttributeValues<contactAddress>(nameof(contactAddress)); }
		}
		[JsonIgnore]
		public frequencyPair?[] frequencyPair {
			set { base.SetAttribute("frequencyPair", value); }
			get { return base.GetAttributeValues<frequencyPair>(nameof(frequencyPair)); }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		[JsonIgnore]
		public onlineResource?[] onlineResource {
			set { base.SetAttribute("onlineResource", value); }
			get { return base.GetAttributeValues<onlineResource>(nameof(onlineResource)); }
		}
		[JsonIgnore]
		public telecommunications?[] telecommunications {
			set { base.SetAttribute("telecommunications", value); }
			get { return base.GetAttributeValues<telecommunications>(nameof(telecommunications)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(callName),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new callName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(callSign),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new callSign(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCommunicationPreference),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfCommunicationPreference(),
				},
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(contactInstructions),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new contactInstructions(),
				},
				new attributeBindingDefinition {
					attribute = nameof(language),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new language(),
				},
				new attributeBindingDefinition {
					attribute = nameof(mMSICode),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new mMSICode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(contactAddress),
					lower = 0,
					upper = 2147483647,
					order = 7,
					CreateInstance = () => new contactAddress(),
				},
				new attributeBindingDefinition {
					attribute = nameof(frequencyPair),
					lower = 0,
					upper = 2147483647,
					order = 8,
					CreateInstance = () => new frequencyPair(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 9,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					order = 10,
					CreateInstance = () => new onlineResource(),
				},
				new attributeBindingDefinition {
					attribute = nameof(telecommunications),
					lower = 0,
					upper = 2147483647,
					order = 11,
					CreateInstance = () => new telecommunications(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ContactDetails.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. InformationType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "theAuthority",
					association = "AuthorityContact",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Authority)],
					CreateInstance = () => new informationBinding<InformationAssociation.AuthorityContact>() {
						roleType = "association",
						role = "theAuthority",
					},
				},
			];

		public static informationBinding<InformationAssociation.AuthorityContact> AuthorityContact => new informationBinding<InformationAssociation.AuthorityContact> {
			roleType = "association",
			role = "theAuthority",
		};

		#endregion
	}

	/// <summary>
	/// Nautical information about a related area or facility.
	/// </summary>
	public class NauticalInformation : AbstractRxN
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NauticalInformation);
		[JsonIgnore]
		public override string S100FC_name => "Nautical Information";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => NauticalInformation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

	/// <summary>
	/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
	/// </summary>
	public class NonStandardWorkingDay : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NonStandardWorkingDay);
		[JsonIgnore]
		public override string S100FC_name => "Non-Standard Working Day";

		#region Attributes
		[JsonIgnore]
		public String?[] dateFixed {
			set { base.SetAttribute("dateFixed", [.. value.Select(e=> new dateFixed { value = e })]); }
			get { return base.GetAttributeValues<dateFixed>(nameof(dateFixed)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] dateVariable {
			set { base.SetAttribute("dateVariable", [.. value.Select(e=> new dateVariable { value = e })]); }
			get { return base.GetAttributeValues<dateVariable>(nameof(dateVariable)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(dateFixed),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new dateFixed(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dateVariable),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new dateVariable(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new information(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => NonStandardWorkingDay.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

	/// <summary>
	/// Recommendations for a related area or facility.
	/// </summary>
	public class Recommendations : AbstractRxN
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Recommendations);
		[JsonIgnore]
		public override string S100FC_name => "Recommendations";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Recommendations.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

	/// <summary>
	/// Regulations for a related area or facility.
	/// </summary>
	public class Regulations : AbstractRxN
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Regulations);
		[JsonIgnore]
		public override string S100FC_name => "Regulations";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Regulations.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

	/// <summary>
	/// Restrictions for a related area or facility.
	/// </summary>
	public class Restrictions : AbstractRxN
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Restrictions);
		[JsonIgnore]
		public override string S100FC_name => "Restrictions";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Restrictions.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

	/// <summary>
	/// The time when a service is available and known exceptions.
	/// </summary>
	public class ServiceHours : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ServiceHours);
		[JsonIgnore]
		public override string S100FC_name => "Service Hours";

		#region Attributes
		[JsonIgnore]
		public scheduleByDayOfWeek?[] scheduleByDayOfWeek {
			set { base.SetAttribute("scheduleByDayOfWeek", value); }
			get { return base.GetAttributeValues<scheduleByDayOfWeek>(nameof(scheduleByDayOfWeek)); }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(scheduleByDayOfWeek),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new scheduleByDayOfWeek(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new information(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ServiceHours.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. InformationType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "partialWorkingDay",
					association = "ExceptionalWorkday",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(NonStandardWorkingDay)],
					CreateInstance = () => new informationBinding<InformationAssociation.ExceptionalWorkday>() {
						roleType = "association",
						role = "partialWorkingDay",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "theAuthority_srvHrs",
					association = "AuthorityHours",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Authority)],
					CreateInstance = () => new informationBinding<InformationAssociation.AuthorityHours>() {
						roleType = "association",
						role = "theAuthority_srvHrs",
					},
				},
			];

		public static informationBinding<InformationAssociation.ExceptionalWorkday> ExceptionalWorkday => new informationBinding<InformationAssociation.ExceptionalWorkday> {
			roleType = "association",
			role = "partialWorkingDay",
		};
		public static informationBinding<InformationAssociation.AuthorityHours> AuthorityHours => new informationBinding<InformationAssociation.AuthorityHours> {
			roleType = "association",
			role = "theAuthority_srvHrs",
		};

		#endregion
	}

	/// <summary>
	/// Description of how a ship should report to a maritime authority, including when to report, what to report and whether the format conforms to the IMO standard.
	/// </summary>
	public class ShipReport : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ShipReport);
		[JsonIgnore]
		public override string S100FC_name => "Ship Report";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfShipReport {
			set { base.SetAttribute("categoryOfShipReport", [.. value.Select(e=> new categoryOfShipReport { value = e })]); }
			get { return base.GetAttributeValues<categoryOfShipReport>(nameof(categoryOfShipReport)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? iMOFormatForReporting {
			set { base.SetAttribute(new iMOFormatForReporting { value = value }); }
			get { return base.GetAttributeValue<iMOFormatForReporting>(nameof(iMOFormatForReporting))?.value; }
		}
		[JsonIgnore]
		public int?[] sRSFormatCode {
			set { base.SetAttribute("sRSFormatCode", [.. value.Select(e=> new sRSFormatCode { value = e })]); }
			get { return base.GetAttributeValues<sRSFormatCode>(nameof(sRSFormatCode)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public noticeTime?[] noticeTime {
			set { base.SetAttribute("noticeTime", value); }
			get { return base.GetAttributeValues<noticeTime>(nameof(noticeTime)); }
		}
		[JsonIgnore]
		public textContent? textContent {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<textContent>(nameof(textContent)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfShipReport),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new categoryOfShipReport(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iMOFormatForReporting),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new iMOFormatForReporting(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sRSFormatCode),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26],
					CreateInstance = () => new sRSFormatCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(noticeTime),
					lower = 1,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new noticeTime(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new textContent(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ShipReport.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. InformationType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "mustBeFiledBy",
					association = "ReportingRequirement",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Applicability)],
					CreateInstance = () => new informationBinding<InformationAssociation.ReportingRequirement>() {
						roleType = "association",
						role = "mustBeFiledBy",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "reportTo",
					association = "ReportingAuthority",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Authority)],
					CreateInstance = () => new informationBinding<InformationAssociation.ReportingAuthority>() {
						roleType = "association",
						role = "reportTo",
					},
				},
			];

		public static informationBinding<InformationAssociation.ReportingRequirement> ReportingRequirement => new informationBinding<InformationAssociation.ReportingRequirement> {
			roleType = "association",
			role = "mustBeFiledBy",
		};
		public static informationBinding<InformationAssociation.ReportingAuthority> ReportingAuthority => new informationBinding<InformationAssociation.ReportingAuthority> {
			roleType = "association",
			role = "reportTo",
		};

		#endregion
	}

	/// <summary>
	/// The indication of the quality of the locational information for features in a dataset.
	/// </summary>
	public class SpatialQuality : S100FC.InformationType, IInformationBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SpatialQuality);
		[JsonIgnore]
		public override string S100FC_name => "Spatial Quality";

		#region Attributes
		[JsonIgnore]
		public int? qualityOfHorizontalMeasurement {
			set { base.SetAttribute(new qualityOfHorizontalMeasurement { value = value }); }
			get { return base.GetAttributeValue<qualityOfHorizontalMeasurement>(nameof(qualityOfHorizontalMeasurement))?.value; }
		}
		[JsonIgnore]
		public spatialAccuracy?[] spatialAccuracy {
			set { base.SetAttribute("spatialAccuracy", value); }
			get { return base.GetAttributeValues<spatialAccuracy>(nameof(spatialAccuracy)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(qualityOfHorizontalMeasurement),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new qualityOfHorizontalMeasurement(),
				},
				new attributeBindingDefinition {
					attribute = nameof(spatialAccuracy),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new spatialAccuracy(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SpatialQuality.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

}

namespace S100FC.S127.FeatureTypes
{
	using S100FC.S127.SimpleAttributes;
	using S100FC.S127.ComplexAttributes;
	using S100FC.S127.InformationTypes;

	/// <summary>
	/// Generalized feature type which carries all the common attributes.
	/// </summary>
	public abstract class FeatureType : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(FeatureType);
		[JsonIgnore]
		public override string S100FC_name => "Feature Type";

		#region Attributes
		[JsonIgnore]
		public String?[] interoperabilityIdentifier {
			set { base.SetAttribute("interoperabilityIdentifier", [.. value.Select(e=> new interoperabilityIdentifier { value = e })]); }
			get { return base.GetAttributeValues<interoperabilityIdentifier>(nameof(interoperabilityIdentifier)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public featureName?[] featureName {
			set { base.SetAttribute("featureName", value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); }
		}
		[JsonIgnore]
		public fixedDateRange? fixedDateRange {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public periodicDateRange?[] periodicDateRange {
			set { base.SetAttribute("periodicDateRange", value); }
			get { return base.GetAttributeValues<periodicDateRange>(nameof(periodicDateRange)); }
		}
		[JsonIgnore]
		public graphic?[] graphic {
			set { base.SetAttribute("graphic", value); }
			get { return base.GetAttributeValues<graphic>(nameof(graphic)); }
		}
		[JsonIgnore]
		public sourceIndication?[] sourceIndication {
			set { base.SetAttribute("sourceIndication", value); }
			get { return base.GetAttributeValues<sourceIndication>(nameof(sourceIndication)); }
		}
		[JsonIgnore]
		public textContent?[] textContent {
			set { base.SetAttribute("textContent", value); }
			get { return base.GetAttributeValues<textContent>(nameof(textContent)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new featureName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new periodicDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(graphic),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new graphic(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new sourceIndication(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					order = 6,
					CreateInstance = () => new textContent(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => FeatureType.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				new informationBindingDefinition {
					roleType = "association",
					role = "permission",
					association = "PermissionType",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Applicability)],
					CreateInstance = () => new informationBinding<InformationAssociation.PermissionType>() {
						roleType = "association",
						role = "permission",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "theRxN",
					association = "AssociatedRxN",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(AbstractRxN)],
					CreateInstance = () => new informationBinding<InformationAssociation.AssociatedRxN>() {
						roleType = "association",
						role = "theRxN",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "theInformation",
					association = "AdditionalInformation",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(NauticalInformation)],
					CreateInstance = () => new informationBinding<InformationAssociation.AdditionalInformation>() {
						roleType = "association",
						role = "theInformation",
					},
				},
			];

		public static informationBinding<InformationAssociation.PermissionType> PermissionType => new informationBinding<InformationAssociation.PermissionType> {
			roleType = "association",
			role = "permission",
		};
		public static informationBinding<InformationAssociation.AssociatedRxN> AssociatedRxN => new informationBinding<InformationAssociation.AssociatedRxN> {
			roleType = "association",
			role = "theRxN",
		};
		public static informationBinding<InformationAssociation.AdditionalInformation> AdditionalInformation => new informationBinding<InformationAssociation.AdditionalInformation> {
			roleType = "association",
			role = "theInformation",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => FeatureType.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "theCartographicText",
					association = "TextAssociation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(TextPlacement)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TextAssociation>() {
						roleType = "association",
						role = "theCartographicText",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TextAssociation> TextAssociation(string role) => new featureBinding<FeatureAssociation.TextAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TextAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// A feature often associated with contact information for an organization that exercises a management role or offers a service in the location.
	/// </summary>
	public abstract class OrganizationContactArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(OrganizationContactArea);
		[JsonIgnore]
		public override string S100FC_name => "Organization Contact Area";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => OrganizationContactArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. FeatureType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "theContactDetails",
					association = "ServiceContact",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(ContactDetails)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceContact>() {
						roleType = "association",
						role = "theContactDetails",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceContact> ServiceContact => new informationBinding<InformationAssociation.ServiceContact> {
			roleType = "association",
			role = "theContactDetails",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => OrganizationContactArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// A location which may be supervised by a responsible or controlling authority.
	/// </summary>
	public abstract class SupervisedArea : OrganizationContactArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SupervisedArea);
		[JsonIgnore]
		public override string S100FC_name => "Supervised Area";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SupervisedArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. OrganizationContactArea.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "controlAuthority",
					association = "ServiceControl",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(Authority)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceControl>() {
						roleType = "association",
						role = "controlAuthority",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceControl> ServiceControl => new informationBinding<InformationAssociation.ServiceControl> {
			roleType = "association",
			role = "controlAuthority",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SupervisedArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// A service feature generally involving one or more reports from the requester, including communications not strictly considered "reporting".
	/// </summary>
	public abstract class ReportableServiceArea : SupervisedArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ReportableServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "Reportable Service Area";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ReportableServiceArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. SupervisedArea.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "reptForTrafficServ",
					association = "TrafficServiceReport",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(ShipReport)],
					CreateInstance = () => new informationBinding<InformationAssociation.TrafficServiceReport>() {
						roleType = "association",
						role = "reptForTrafficServ",
					},
				},
			];

		public static informationBinding<InformationAssociation.TrafficServiceReport> TrafficServiceReport => new informationBinding<InformationAssociation.TrafficServiceReport> {
			roleType = "association",
			role = "reptForTrafficServ",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => ReportableServiceArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.
	/// </summary>
	public class CautionArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(CautionArea);
		[JsonIgnore]
		public override string S100FC_name => "Caution Area";

		#region Attributes
		[JsonIgnore]
		public int? condition {
			set { base.SetAttribute(new condition { value = value }); }
			get { return base.GetAttributeValue<condition>(nameof(condition))?.value; }
		}
		[JsonIgnore]
		public int? status {
			set { base.SetAttribute(new status { value = value }); }
			get { return base.GetAttributeValue<status>(nameof(status))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(condition),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,3,5],
					CreateInstance = () => new condition(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [5,7],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => CautionArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => CautionArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// An area where hazards, caused by concentrations of shipping, may occur. Hazards are risks to shipping, which stem from sources other than shoal water or obstructions.
	/// </summary>
	public class ConcentrationOfShippingHazardArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ConcentrationOfShippingHazardArea);
		[JsonIgnore]
		public override string S100FC_name => "Concentration of Shipping Hazard Area";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfConcentrationOfShippingHazardArea {
			set { base.SetAttribute("categoryOfConcentrationOfShippingHazardArea", [.. value.Select(e=> new categoryOfConcentrationOfShippingHazardArea { value = e })]); }
			get { return base.GetAttributeValues<categoryOfConcentrationOfShippingHazardArea>(nameof(categoryOfConcentrationOfShippingHazardArea)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfConcentrationOfShippingHazardArea),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfConcentrationOfShippingHazardArea(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,5,7,16,17],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ConcentrationOfShippingHazardArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => ConcentrationOfShippingHazardArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// The area to which an International Ship and Port Facility Security (ISPS) level applies. The ISPS Code is a comprehensive set of measures to enhance the security of ships and port facilities, developed in response to the perceived threats to ships and port facilities in the wake of the 9/11 attacks in the United States.
	/// </summary>
	public class ISPSCodeSecurityLevel : OrganizationContactArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ISPSCodeSecurityLevel);
		[JsonIgnore]
		public override string S100FC_name => "ISPS Code Security Level";

		#region Attributes
		[JsonIgnore]
		public int? iSPSLevel {
			set { base.SetAttribute(new iSPSLevel { value = value }); }
			get { return base.GetAttributeValue<iSPSLevel>(nameof(iSPSLevel))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ISPSCodeSecurityLevel.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => ISPSCodeSecurityLevel.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.curve,Primitives.surface];
	}

	/// <summary>
	/// A broadcast service established to provide port information without interaction between the customer and the service provider. This information could be inter alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.
	/// </summary>
	public class LocalPortBroadcastServiceArea : ReportableServiceArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LocalPortBroadcastServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "Local Port Broadcast Service Area";

		#region Attributes
		[JsonIgnore]
		public String? serviceAccessProcedure {
			set { base.SetAttribute(new serviceAccessProcedure { value = value }); }
			get { return base.GetAttributeValue<serviceAccessProcedure>(nameof(serviceAccessProcedure))?.value; }
		}
		[JsonIgnore]
		public String? requirementsForMaintenanceOfListeningWatch {
			set { base.SetAttribute(new requirementsForMaintenanceOfListeningWatch { value = value }); }
			get { return base.GetAttributeValue<requirementsForMaintenanceOfListeningWatch>(nameof(requirementsForMaintenanceOfListeningWatch))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(serviceAccessProcedure),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new serviceAccessProcedure(),
				},
				new attributeBindingDefinition {
					attribute = nameof(requirementsForMaintenanceOfListeningWatch),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new requirementsForMaintenanceOfListeningWatch(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LocalPortBroadcastServiceArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LocalPortBroadcastServiceArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. ReportableServiceArea.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "consistsOf",
					association = "TrafficControlServiceAggregation",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(RadioCallingInPoint),nameof(RadarRange),nameof(SignalStationWarning),nameof(SignalStationTraffic)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation>() {
						roleType = "association",
						role = "consistsOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TrafficControlServiceAggregation> TrafficControlServiceAggregation(string role) => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TrafficControlServiceAggregation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area within which naval, military or aerial exercises are carried out. Also called an 'exercise area'.
	/// </summary>
	public class MilitaryPracticeArea : SupervisedArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(MilitaryPracticeArea);
		[JsonIgnore]
		public override string S100FC_name => "Military Practice Area";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfMilitaryPracticeArea {
			set { base.SetAttribute("categoryOfMilitaryPracticeArea", [.. value.Select(e=> new categoryOfMilitaryPracticeArea { value = e })]); }
			get { return base.GetAttributeValues<categoryOfMilitaryPracticeArea>(nameof(categoryOfMilitaryPracticeArea)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? nationality {
			set { base.SetAttribute(new nationality { value = value }); }
			get { return base.GetAttributeValue<nationality>(nameof(nationality))?.value; }
		}
		[JsonIgnore]
		public int?[] restriction {
			set { base.SetAttribute("restriction", [.. value.Select(e=> new restriction { value = e })]); }
			get { return base.GetAttributeValues<restriction>(nameof(restriction)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfMilitaryPracticeArea),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [2,3,4,5,6],
					CreateInstance = () => new categoryOfMilitaryPracticeArea(),
				},
				new attributeBindingDefinition {
					attribute = nameof(nationality),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new nationality(),
				},
				new attributeBindingDefinition {
					attribute = nameof(restriction),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,23,24,25,26,27,39],
					CreateInstance = () => new restriction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,5,6,7,16,17],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => MilitaryPracticeArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. SupervisedArea.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "theServiceHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "theServiceHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "theServiceHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => MilitaryPracticeArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
	/// </summary>
	public class PilotBoardingPlace : OrganizationContactArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PilotBoardingPlace);
		[JsonIgnore]
		public override string S100FC_name => "Pilot Boarding Place";

		#region Attributes
		[JsonIgnore]
		public String? callSign {
			set { base.SetAttribute(new callSign { value = value }); }
			get { return base.GetAttributeValue<callSign>(nameof(callSign))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfPilotBoardingPlace {
			set { base.SetAttribute(new categoryOfPilotBoardingPlace { value = value }); }
			get { return base.GetAttributeValue<categoryOfPilotBoardingPlace>(nameof(categoryOfPilotBoardingPlace))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfPreference {
			set { base.SetAttribute(new categoryOfPreference { value = value }); }
			get { return base.GetAttributeValue<categoryOfPreference>(nameof(categoryOfPreference))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfVessel {
			set { base.SetAttribute(new categoryOfVessel { value = value }); }
			get { return base.GetAttributeValue<categoryOfVessel>(nameof(categoryOfVessel))?.value; }
		}
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? destination {
			set { base.SetAttribute(new destination { value = value }); }
			get { return base.GetAttributeValue<destination>(nameof(destination))?.value; }
		}
		[JsonIgnore]
		public int? pilotMovement {
			set { base.SetAttribute(new pilotMovement { value = value }); }
			get { return base.GetAttributeValue<pilotMovement>(nameof(pilotMovement))?.value; }
		}
		[JsonIgnore]
		public String? pilotVessel {
			set { base.SetAttribute(new pilotVessel { value = value }); }
			get { return base.GetAttributeValue<pilotVessel>(nameof(pilotVessel))?.value; }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(callSign),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new callSign(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPilotBoardingPlace),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfPilotBoardingPlace(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPreference),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfPreference(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfVessel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17],
					CreateInstance = () => new categoryOfVessel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(destination),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new destination(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pilotMovement),
					lower = 0,
					upper = 1,
					order = 6,
					permitedValues = [1,2,3],
					CreateInstance = () => new pilotMovement(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pilotVessel),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new pilotVessel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 8,
					permitedValues = [1,2,5,6,9,16,17,28],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => PilotBoardingPlace.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => PilotBoardingPlace.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. OrganizationContactArea.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "theCollection",
					association = "PilotageDistrictAssociation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(PilotageDistrict)],
					CreateInstance = () => new featureBinding<FeatureAssociation.PilotageDistrictAssociation>() {
						roleType = "aggregation",
						role = "theCollection",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "serviceProvider",
					association = "ServiceProvisionArea",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(PilotService)],
					CreateInstance = () => new featureBinding<FeatureAssociation.ServiceProvisionArea>() {
						roleType = "association",
						role = "serviceProvider",
					},
				},
			];

		public static featureBinding<FeatureAssociation.PilotageDistrictAssociation> PilotageDistrictAssociation(string role) => new featureBinding<FeatureAssociation.PilotageDistrictAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("PilotageDistrictAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.ServiceProvisionArea> ServiceProvisionArea(string role) => new featureBinding<FeatureAssociation.ServiceProvisionArea> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("ServiceProvisionArea") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// The service provided by a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area.
	/// </summary>
	public class PilotService : ReportableServiceArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PilotService);
		[JsonIgnore]
		public override string S100FC_name => "Pilot Service";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfPilot {
			set { base.SetAttribute("categoryOfPilot", [.. value.Select(e=> new categoryOfPilot { value = e })]); }
			get { return base.GetAttributeValues<categoryOfPilot>(nameof(categoryOfPilot)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? pilotQualification {
			set { base.SetAttribute(new pilotQualification { value = value }); }
			get { return base.GetAttributeValue<pilotQualification>(nameof(pilotQualification))?.value; }
		}
		[JsonIgnore]
		public String? pilotRequest {
			set { base.SetAttribute(new pilotRequest { value = value }); }
			get { return base.GetAttributeValue<pilotRequest>(nameof(pilotRequest))?.value; }
		}
		[JsonIgnore]
		public Boolean? remotePilot {
			set { base.SetAttribute(new remotePilot { value = value }); }
			get { return base.GetAttributeValue<remotePilot>(nameof(remotePilot))?.value; }
		}
		[JsonIgnore]
		public noticeTime? noticeTime {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<noticeTime>(nameof(noticeTime)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPilot),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new categoryOfPilot(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pilotQualification),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new pilotQualification(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pilotRequest),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new pilotRequest(),
				},
				new attributeBindingDefinition {
					attribute = nameof(remotePilot),
					lower = 1,
					upper = 1,
					order = 3,
					CreateInstance = () => new remotePilot(),
				},
				new attributeBindingDefinition {
					attribute = nameof(noticeTime),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new noticeTime(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => PilotService.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. ReportableServiceArea.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "theServiceHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "theServiceHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "theServiceHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => PilotService.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. ReportableServiceArea.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "serviceArea",
					association = "ServiceProvisionArea",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(PilotageDistrict)],
					CreateInstance = () => new featureBinding<FeatureAssociation.ServiceProvisionArea>() {
						roleType = "association",
						role = "serviceArea",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "serviceArea",
					association = "ServiceProvisionArea",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(PilotBoardingPlace)],
					CreateInstance = () => new featureBinding<FeatureAssociation.ServiceProvisionArea>() {
						roleType = "association",
						role = "serviceArea",
					},
				},
			];

		public static featureBinding<FeatureAssociation.ServiceProvisionArea> ServiceProvisionArea(string role) => new featureBinding<FeatureAssociation.ServiceProvisionArea> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("ServiceProvisionArea") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area within which a pilotage direction exists. Such directions are regulated by a competent harbour authority which dictates circumstances under which they apply.
	/// </summary>
	public class PilotageDistrict : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PilotageDistrict);
		[JsonIgnore]
		public override string S100FC_name => "Pilotage District";

		#region Attributes
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new communicationChannel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => PilotageDistrict.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => PilotageDistrict.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. FeatureType.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "theComponent",
					association = "PilotageDistrictAssociation",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(PilotBoardingPlace)],
					CreateInstance = () => new featureBinding<FeatureAssociation.PilotageDistrictAssociation>() {
						roleType = "aggregation",
						role = "theComponent",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "serviceProvider",
					association = "ServiceProvisionArea",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(PilotService)],
					CreateInstance = () => new featureBinding<FeatureAssociation.ServiceProvisionArea>() {
						roleType = "association",
						role = "serviceProvider",
					},
				},
			];

		public static featureBinding<FeatureAssociation.PilotageDistrictAssociation> PilotageDistrictAssociation(string role) => new featureBinding<FeatureAssociation.PilotageDistrictAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("PilotageDistrictAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.ServiceProvisionArea> ServiceProvisionArea(string role) => new featureBinding<FeatureAssociation.ServiceProvisionArea> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("ServiceProvisionArea") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area where there is a raised risk of piracy or armed robbery.
	/// </summary>
	public class PiracyRiskArea : ReportableServiceArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PiracyRiskArea);
		[JsonIgnore]
		public override string S100FC_name => "Piracy Risk Area";

		#region Attributes
		[JsonIgnore]
		public int?[] restriction {
			set { base.SetAttribute("restriction", [.. value.Select(e=> new restriction { value = e })]); }
			get { return base.GetAttributeValues<restriction>(nameof(restriction)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(restriction),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,14,18,19,20,21,24,25,26,27,31,32,33,34],
					CreateInstance = () => new restriction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,5,7],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => PiracyRiskArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => PiracyRiskArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A place where a ship in need of assistance can take action to enable it to stabilize its condition and reduce the hazards to navigation, and to protect human life and the environment.
	/// </summary>
	public class PlaceOfRefuge : ReportableServiceArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PlaceOfRefuge);
		[JsonIgnore]
		public override string S100FC_name => "Place of Refuge";

		#region Attributes
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,28],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => PlaceOfRefuge.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => PlaceOfRefuge.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// Indicates the coverage of a sea area by a radar surveillance station. Inside this area a vessel may request shore-based radar assistance, particularly in poor visibility.
	/// </summary>
	public class RadarRange : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadarRange);
		[JsonIgnore]
		public override string S100FC_name => "Radar Range";

		#region Attributes
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,4,7],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RadarRange.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RadarRange.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. FeatureType.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "TrafficControlServiceAggregation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(VesselTrafficServiceArea),nameof(LocalPortBroadcastServiceArea),nameof(ShipReportingServiceArea)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TrafficControlServiceAggregation> TrafficControlServiceAggregation(string role) => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TrafficControlServiceAggregation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.
	/// </summary>
	public class RadioCallingInPoint : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadioCallingInPoint);
		[JsonIgnore]
		public override string S100FC_name => "Radio Calling-In Point";

		#region Attributes
		[JsonIgnore]
		public String? callSign {
			set { base.SetAttribute(new callSign { value = value }); }
			get { return base.GetAttributeValue<callSign>(nameof(callSign))?.value; }
		}
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfCargo {
			set { base.SetAttribute("categoryOfCargo", [.. value.Select(e=> new categoryOfCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfCargo>(nameof(categoryOfCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfVessel {
			set { base.SetAttribute("categoryOfVessel", [.. value.Select(e=> new categoryOfVessel { value = e })]); }
			get { return base.GetAttributeValues<categoryOfVessel>(nameof(categoryOfVessel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal?[] orientationValue {
			set { base.SetAttribute("orientationValue", [.. value.Select(e=> new orientationValue { value = e })]); }
			get { return base.GetAttributeValues<orientationValue>(nameof(orientationValue)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? trafficFlow {
			set { base.SetAttribute(new trafficFlow { value = value }); }
			get { return base.GetAttributeValue<trafficFlow>(nameof(trafficFlow))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(callSign),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new callSign(),
				},
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new categoryOfCargo(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfVessel),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17],
					CreateInstance = () => new categoryOfVessel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientationValue),
					lower = 0,
					upper = 2,
					order = 4,
					CreateInstance = () => new orientationValue(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [1,3,4,5,6,7,9],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(trafficFlow),
					lower = 1,
					upper = 1,
					order = 6,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new trafficFlow(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RadioCallingInPoint.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RadioCallingInPoint.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. FeatureType.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "TrafficControlServiceAggregation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(VesselTrafficServiceArea),nameof(LocalPortBroadcastServiceArea),nameof(ShipReportingServiceArea)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TrafficControlServiceAggregation> TrafficControlServiceAggregation(string role) => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TrafficControlServiceAggregation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.curve];
	}

	/// <summary>
	/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
	/// </summary>
	public class RestrictedArea : SupervisedArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RestrictedArea);
		[JsonIgnore]
		public override string S100FC_name => "Restricted Area";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfRestrictedArea {
			set { base.SetAttribute("categoryOfRestrictedArea", [.. value.Select(e=> new categoryOfRestrictedArea { value = e })]); }
			get { return base.GetAttributeValues<categoryOfRestrictedArea>(nameof(categoryOfRestrictedArea)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] restriction {
			set { base.SetAttribute("restriction", [.. value.Select(e=> new restriction { value = e })]); }
			get { return base.GetAttributeValues<restriction>(nameof(restriction)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfRestrictedArea),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,4,5,6,7,8,9,10,12,14,19,20,22,23,25,27,28,29,30,31,32],
					CreateInstance = () => new categoryOfRestrictedArea(),
				},
				new attributeBindingDefinition {
					attribute = nameof(restriction),
					lower = 1,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,35,36,37,38,39,40,41,42,43],
					CreateInstance = () => new restriction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,9,18,28],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RestrictedArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RestrictedArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area or line designating the limits or central line of a routeing measure (or part of a routeing measure). Routeing measures include traffic separation schemes, deep-water routes, two-way routes, archipelagic sea lanes, and fairway systems.
	/// </summary>
	public class RouteingMeasure : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RouteingMeasure);
		[JsonIgnore]
		public override string S100FC_name => "Routeing Measure";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfRouteingMeasure {
			set { base.SetAttribute(new categoryOfRouteingMeasure { value = value }); }
			get { return base.GetAttributeValue<categoryOfRouteingMeasure>(nameof(categoryOfRouteingMeasure))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfTrafficSeparationScheme {
			set { base.SetAttribute(new categoryOfTrafficSeparationScheme { value = value }); }
			get { return base.GetAttributeValue<categoryOfTrafficSeparationScheme>(nameof(categoryOfTrafficSeparationScheme))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfNavigationLine {
			set { base.SetAttribute(new categoryOfNavigationLine { value = value }); }
			get { return base.GetAttributeValue<categoryOfNavigationLine>(nameof(categoryOfNavigationLine))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfRouteingMeasure),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new categoryOfRouteingMeasure(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfTrafficSeparationScheme),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfTrafficSeparationScheme(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfNavigationLine),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfNavigationLine(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RouteingMeasure.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RouteingMeasure.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface,Primitives.curve];
	}

	/// <summary>
	/// A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.
	/// </summary>
	public class ShipReportingServiceArea : ReportableServiceArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ShipReportingServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "Ship Reporting Service Area";

		#region Attributes
		[JsonIgnore]
		public String? serviceAccessProcedure {
			set { base.SetAttribute(new serviceAccessProcedure { value = value }); }
			get { return base.GetAttributeValue<serviceAccessProcedure>(nameof(serviceAccessProcedure))?.value; }
		}
		[JsonIgnore]
		public String? requirementsForMaintenanceOfListeningWatch {
			set { base.SetAttribute(new requirementsForMaintenanceOfListeningWatch { value = value }); }
			get { return base.GetAttributeValue<requirementsForMaintenanceOfListeningWatch>(nameof(requirementsForMaintenanceOfListeningWatch))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(serviceAccessProcedure),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new serviceAccessProcedure(),
				},
				new attributeBindingDefinition {
					attribute = nameof(requirementsForMaintenanceOfListeningWatch),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new requirementsForMaintenanceOfListeningWatch(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ShipReportingServiceArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => ShipReportingServiceArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. ReportableServiceArea.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "consistsOf",
					association = "TrafficControlServiceAggregation",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(RadioCallingInPoint),nameof(RadarRange),nameof(SignalStationWarning),nameof(SignalStationTraffic)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation>() {
						roleType = "association",
						role = "consistsOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TrafficControlServiceAggregation> TrafficControlServiceAggregation(string role) => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TrafficControlServiceAggregation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// A warning signal station is a place on shore from which warning signals are made to ships at sea.
	/// </summary>
	public class SignalStationWarning : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SignalStationWarning);
		[JsonIgnore]
		public override string S100FC_name => "Signal Station Warning";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfSignalStationWarning {
			set { base.SetAttribute("categoryOfSignalStationWarning", [.. value.Select(e=> new categoryOfSignalStationWarning { value = e })]); }
			get { return base.GetAttributeValues<categoryOfSignalStationWarning>(nameof(categoryOfSignalStationWarning)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSignalStationWarning),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18],
					CreateInstance = () => new categoryOfSignalStationWarning(),
				},
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,4,5,7,8,12,14,15,16,17],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SignalStationWarning.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SignalStationWarning.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. FeatureType.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "TrafficControlServiceAggregation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(VesselTrafficServiceArea),nameof(LocalPortBroadcastServiceArea),nameof(ShipReportingServiceArea)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TrafficControlServiceAggregation> TrafficControlServiceAggregation(string role) => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TrafficControlServiceAggregation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A traffic signal station is a place on shore from which signals are made to regulate the movement of traffic.
	/// </summary>
	public class SignalStationTraffic : OrganizationContactArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SignalStationTraffic);
		[JsonIgnore]
		public override string S100FC_name => "Signal Station Traffic";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfSignalStationTraffic {
			set { base.SetAttribute("categoryOfSignalStationTraffic", [.. value.Select(e=> new categoryOfSignalStationTraffic { value = e })]); }
			get { return base.GetAttributeValues<categoryOfSignalStationTraffic>(nameof(categoryOfSignalStationTraffic)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] communicationChannel {
			set { base.SetAttribute("communicationChannel", [.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSignalStationTraffic),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,13],
					CreateInstance = () => new categoryOfSignalStationTraffic(),
				},
				new attributeBindingDefinition {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,4,5,7,8,12,14,15,16,17],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SignalStationTraffic.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SignalStationTraffic.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. OrganizationContactArea.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "TrafficControlServiceAggregation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(VesselTrafficServiceArea),nameof(LocalPortBroadcastServiceArea),nameof(ShipReportingServiceArea)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TrafficControlServiceAggregation> TrafficControlServiceAggregation(string role) => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TrafficControlServiceAggregation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// An area for which an authority has stated under keel allowance requirements.
	/// </summary>
	public class UnderKeelClearanceAllowanceArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(UnderKeelClearanceAllowanceArea);
		[JsonIgnore]
		public override string S100FC_name => "Under Keel Clearance Allowance Area";

		#region Attributes
		[JsonIgnore]
		public underKeelAllowance? underKeelAllowance {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<underKeelAllowance>(nameof(underKeelAllowance)); }
		}
		[JsonIgnore]
		public int? waterLevelTrend {
			set { base.SetAttribute(new waterLevelTrend { value = value }); }
			get { return base.GetAttributeValue<waterLevelTrend>(nameof(waterLevelTrend))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(underKeelAllowance),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new underKeelAllowance(),
				},
				new attributeBindingDefinition {
					attribute = nameof(waterLevelTrend),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new waterLevelTrend(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => UnderKeelClearanceAllowanceArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => UnderKeelClearanceAllowanceArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area for which an authority permits use of dynamic under keel clearance information or provides dynamic information related to under keel clearances.
	/// </summary>
	public class UnderKeelClearanceManagementArea : ReportableServiceArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(UnderKeelClearanceManagementArea);
		[JsonIgnore]
		public override string S100FC_name => "Under Keel Clearance Management Area";

		#region Attributes
		[JsonIgnore]
		public int? dynamicResource {
			set { base.SetAttribute(new dynamicResource { value = value }); }
			get { return base.GetAttributeValue<dynamicResource>(nameof(dynamicResource))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(dynamicResource),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new dynamicResource(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => UnderKeelClearanceManagementArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => UnderKeelClearanceManagementArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
	/// </summary>
	public class VesselTrafficServiceArea : ReportableServiceArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(VesselTrafficServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "Vessel Traffic Service Area";

		#region Attributes
		[JsonIgnore]
		public String? serviceAccessProcedure {
			set { base.SetAttribute(new serviceAccessProcedure { value = value }); }
			get { return base.GetAttributeValue<serviceAccessProcedure>(nameof(serviceAccessProcedure))?.value; }
		}
		[JsonIgnore]
		public String? requirementsForMaintenanceOfListeningWatch {
			set { base.SetAttribute(new requirementsForMaintenanceOfListeningWatch { value = value }); }
			get { return base.GetAttributeValue<requirementsForMaintenanceOfListeningWatch>(nameof(requirementsForMaintenanceOfListeningWatch))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(serviceAccessProcedure),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new serviceAccessProcedure(),
				},
				new attributeBindingDefinition {
					attribute = nameof(requirementsForMaintenanceOfListeningWatch),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new requirementsForMaintenanceOfListeningWatch(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => VesselTrafficServiceArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => VesselTrafficServiceArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. ReportableServiceArea.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "consistsOf",
					association = "TrafficControlServiceAggregation",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(RadioCallingInPoint),nameof(RadarRange),nameof(SignalStationWarning),nameof(SignalStationTraffic)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation>() {
						roleType = "association",
						role = "consistsOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TrafficControlServiceAggregation> TrafficControlServiceAggregation(string role) => new featureBinding<FeatureAssociation.TrafficControlServiceAggregation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TrafficControlServiceAggregation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area in which uniform general information of the waterway exists.
	/// </summary>
	public class WaterwayArea : SupervisedArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(WaterwayArea);
		[JsonIgnore]
		public override string S100FC_name => "Waterway Area";

		#region Attributes
		[JsonIgnore]
		public int? dynamicResource {
			set { base.SetAttribute(new dynamicResource { value = value }); }
			get { return base.GetAttributeValue<dynamicResource>(nameof(dynamicResource))?.value; }
		}
		[JsonIgnore]
		public String? siltationRate {
			set { base.SetAttribute(new siltationRate { value = value }); }
			get { return base.GetAttributeValue<siltationRate>(nameof(siltationRate))?.value; }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(dynamicResource),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new dynamicResource(),
				},
				new attributeBindingDefinition {
					attribute = nameof(siltationRate),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new siltationRate(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,28],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => WaterwayArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => WaterwayArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// A geographical area that describes the coverage and extent of spatial objects.
	/// </summary>
	public class DataCoverage : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DataCoverage);
		[JsonIgnore]
		public override string S100FC_name => "Data Coverage";

		#region Attributes
		[JsonIgnore]
		public String?[] interoperabilityIdentifier {
			set { base.SetAttribute("interoperabilityIdentifier", [.. value.Select(e=> new interoperabilityIdentifier { value = e })]); }
			get { return base.GetAttributeValues<interoperabilityIdentifier>(nameof(interoperabilityIdentifier)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? maximumDisplayScale {
			set { base.SetAttribute(new maximumDisplayScale { value = value }); }
			get { return base.GetAttributeValue<maximumDisplayScale>(nameof(maximumDisplayScale))?.value; }
		}
		[JsonIgnore]
		public int? minimumDisplayScale {
			set { base.SetAttribute(new minimumDisplayScale { value = value }); }
			get { return base.GetAttributeValue<minimumDisplayScale>(nameof(minimumDisplayScale))?.value; }
		}
		[JsonIgnore]
		public int? optimumDisplayScale {
			set { base.SetAttribute(new optimumDisplayScale { value = value }); }
			get { return base.GetAttributeValue<optimumDisplayScale>(nameof(optimumDisplayScale))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(maximumDisplayScale),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new maximumDisplayScale(),
				},
				new attributeBindingDefinition {
					attribute = nameof(minimumDisplayScale),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new minimumDisplayScale(),
				},
				new attributeBindingDefinition {
					attribute = nameof(optimumDisplayScale),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new optimumDisplayScale(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => DataCoverage.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => DataCoverage.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
	/// </summary>
	public class QualityOfNonBathymetricData : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(QualityOfNonBathymetricData);
		[JsonIgnore]
		public override string S100FC_name => "Quality of Non-Bathymetric Data";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfTemporalVariation {
			set { base.SetAttribute(new categoryOfTemporalVariation { value = value }); }
			get { return base.GetAttributeValue<categoryOfTemporalVariation>(nameof(categoryOfTemporalVariation))?.value; }
		}
		[JsonIgnore]
		public decimal? horizontalDistanceUncertainty {
			set { base.SetAttribute(new horizontalDistanceUncertainty { value = value }); }
			get { return base.GetAttributeValue<horizontalDistanceUncertainty>(nameof(horizontalDistanceUncertainty))?.value; }
		}
		[JsonIgnore]
		public decimal? orientationUncertainty {
			set { base.SetAttribute(new orientationUncertainty { value = value }); }
			get { return base.GetAttributeValue<orientationUncertainty>(nameof(orientationUncertainty))?.value; }
		}
		[JsonIgnore]
		public horizontalPositionUncertainty? horizontalPositionUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<horizontalPositionUncertainty>(nameof(horizontalPositionUncertainty)); }
		}
		[JsonIgnore]
		public String?[] interoperabilityIdentifier {
			set { base.SetAttribute("interoperabilityIdentifier", [.. value.Select(e=> new interoperabilityIdentifier { value = e })]); }
			get { return base.GetAttributeValues<interoperabilityIdentifier>(nameof(interoperabilityIdentifier)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public sourceIndication? sourceIndication {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sourceIndication>(nameof(sourceIndication)); }
		}
		[JsonIgnore]
		public surveyDateRange? surveyDateRange {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<surveyDateRange>(nameof(surveyDateRange)); }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfTemporalVariation),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,4,5,6],
					CreateInstance = () => new categoryOfTemporalVariation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(horizontalDistanceUncertainty),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new horizontalDistanceUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientationUncertainty),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new orientationUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new sourceIndication(),
				},
				new attributeBindingDefinition {
					attribute = nameof(surveyDateRange),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new surveyDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 7,
					CreateInstance = () => new information(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => QualityOfNonBathymetricData.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => QualityOfNonBathymetricData.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	public class TextPlacement : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TextPlacement);
		[JsonIgnore]
		public override string S100FC_name => "Text Placement";

		#region Attributes
		[JsonIgnore]
		public int? textOffsetBearing {
			set { base.SetAttribute(new textOffsetBearing { value = value }); }
			get { return base.GetAttributeValue<textOffsetBearing>(nameof(textOffsetBearing))?.value; }
		}
		[JsonIgnore]
		public int? textOffsetDistance {
			set { base.SetAttribute(new textOffsetDistance { value = value }); }
			get { return base.GetAttributeValue<textOffsetDistance>(nameof(textOffsetDistance))?.value; }
		}
		[JsonIgnore]
		public Boolean? textRotation {
			set { base.SetAttribute(new textRotation { value = value }); }
			get { return base.GetAttributeValue<textRotation>(nameof(textRotation))?.value; }
		}
		[JsonIgnore]
		public int?[] textType {
			set { base.SetAttribute("textType", [.. value.Select(e=> new textType { value = e })]); }
			get { return base.GetAttributeValues<textType>(nameof(textType)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? scaleMinimum {
			set { base.SetAttribute(new scaleMinimum { value = value }); }
			get { return base.GetAttributeValue<scaleMinimum>(nameof(scaleMinimum))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(textOffsetBearing),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new textOffsetBearing(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textOffsetDistance),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new textOffsetDistance(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textRotation),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new textRotation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textType),
					lower = 1,
					upper = 2,
					order = 3,
					permitedValues = [1],
					CreateInstance = () => new textType(),
				},
				new attributeBindingDefinition {
					attribute = nameof(scaleMinimum),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new scaleMinimum(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => TextPlacement.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => TextPlacement.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "composition",
					role = "thePositionProvider",
					association = "TextAssociation",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(FeatureType)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TextAssociation>() {
						roleType = "composition",
						role = "thePositionProvider",
					},
				},
			];

		public static featureBinding<FeatureAssociation.TextAssociation> TextAssociation(string role) => new featureBinding<FeatureAssociation.TextAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TextAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

}

namespace S100FC.S127
{
	using System.Text.Json;
	using S100FC.S127.SimpleAttributes;
	using S100FC.S127.ComplexAttributes;
	using S100FC.S127.InformationAssociation;
	using S100FC.S127.FeatureAssociation;
	using S100FC.S127.InformationTypes;
	using S100FC.S127.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "Feature Catalogue for S-127";
		public static string Scope => "Global coverage of maritime areas";
		public static string ProductId => "S-127";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-12-07", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["contactAddress","featureName","fixedDateRange","frequencyPair","horizontalPositionUncertainty","information","noticeTime","onlineResource","orientation","periodicDateRange","rxNCode","sourceIndication","surveyDateRange","spatialAccuracy","telecommunications","textContent","timeIntervalsByDayOfWeek","underKeelAllowance","vesselMeasurementsSpecification","bearingInformation","graphic","scheduleByDayOfWeek"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","InclusionType","PermissionType","RelatedOrganisation","ReportingAuthority","ReportingRequirement","ServiceContact","ServiceControl","SpatialAssociation","LocationHours","TrafficServiceReport"];
		public static string[] FeatureAssociationTypes => ["ServiceProvisionArea","PilotageDistrictAssociation","TextAssociation","TrafficControlServiceAggregation"];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","Applicability","Authority","ContactDetails","NauticalInformation","NonStandardWorkingDay","Recommendations","Regulations","Restrictions","ServiceHours","ShipReport","SpatialQuality"];
		public static string[] FeatureTypes => ["FeatureType","OrganizationContactArea","SupervisedArea","ReportableServiceArea","CautionArea","ConcentrationOfShippingHazardArea","ISPSCodeSecurityLevel","LocalPortBroadcastServiceArea","MilitaryPracticeArea","PilotBoardingPlace","PilotService","PilotageDistrict","PiracyRiskArea","PlaceOfRefuge","RadarRange","RadioCallingInPoint","RestrictedArea","RouteingMeasure","ShipReportingServiceArea","SignalStationWarning","SignalStationTraffic","UnderKeelClearanceAllowanceArea","UnderKeelClearanceManagementArea","VesselTrafficServiceArea","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType","OrganizationContactArea","SupervisedArea","ReportableServiceArea"],
			Primitives.point => ["CautionArea","MilitaryPracticeArea","PilotBoardingPlace","PiracyRiskArea","PlaceOfRefuge","RadioCallingInPoint","SignalStationWarning","SignalStationTraffic","TextPlacement"],
			Primitives.pointSet => [],
			Primitives.curve => ["ISPSCodeSecurityLevel","RadioCallingInPoint","RouteingMeasure"],
			Primitives.surface => ["CautionArea","ConcentrationOfShippingHazardArea","ISPSCodeSecurityLevel","LocalPortBroadcastServiceArea","MilitaryPracticeArea","PilotBoardingPlace","PilotService","PilotageDistrict","PiracyRiskArea","PlaceOfRefuge","RadarRange","RestrictedArea","RouteingMeasure","ShipReportingServiceArea","SignalStationWarning","SignalStationTraffic","UnderKeelClearanceAllowanceArea","UnderKeelClearanceManagementArea","VesselTrafficServiceArea","WaterwayArea","DataCoverage","QualityOfNonBathymetricData"],
			_ => throw new InvalidOperationException(),
		};
	}

	public static class Extensions {
		public static informationBinding CreateInformationBinding(string informationType, string association) => $"{informationType}::{association}" switch {
			"AbstractRxN::InclusionType" => AbstractRxN.InclusionType,
			"AbstractRxN::RelatedOrganisation" => AbstractRxN.RelatedOrganisation,
			"Applicability::InclusionType" => Applicability.InclusionType,
			"Authority::AuthorityContact" => Authority.AuthorityContact,
			"Authority::RelatedOrganisation" => Authority.RelatedOrganisation,
			"Authority::AuthorityHours" => Authority.AuthorityHours,
			"ContactDetails::AuthorityContact" => ContactDetails.AuthorityContact,
			"ServiceHours::ExceptionalWorkday" => ServiceHours.ExceptionalWorkday,
			"ServiceHours::AuthorityHours" => ServiceHours.AuthorityHours,
			"ShipReport::ReportingRequirement" => ShipReport.ReportingRequirement,
			"ShipReport::ReportingAuthority" => ShipReport.ReportingAuthority,
			"FeatureType::PermissionType" => FeatureType.PermissionType,
			"FeatureType::AssociatedRxN" => FeatureType.AssociatedRxN,
			"FeatureType::AdditionalInformation" => FeatureType.AdditionalInformation,
			"OrganizationContactArea::ServiceContact" => OrganizationContactArea.ServiceContact,
			"SupervisedArea::ServiceControl" => SupervisedArea.ServiceControl,
			"ReportableServiceArea::TrafficServiceReport" => ReportableServiceArea.TrafficServiceReport,
			"MilitaryPracticeArea::LocationHours" => MilitaryPracticeArea.LocationHours,
			"PilotService::LocationHours" => PilotService.LocationHours,
			"" => throw new KeyNotFoundException(),
			_ => throw new KeyNotFoundException(),
		};

		public static featureBinding CreateFeatureBinding(string featureType, string association, string role) => $"{featureType}::{association}" switch {
			"FeatureType::TextAssociation" => FeatureType.TextAssociation(role),
			"LocalPortBroadcastServiceArea::TrafficControlServiceAggregation" => LocalPortBroadcastServiceArea.TrafficControlServiceAggregation(role),
			"PilotBoardingPlace::PilotageDistrictAssociation" => PilotBoardingPlace.PilotageDistrictAssociation(role),
			"PilotBoardingPlace::ServiceProvisionArea" => PilotBoardingPlace.ServiceProvisionArea(role),
			"PilotService::ServiceProvisionArea" => PilotService.ServiceProvisionArea(role),
			"PilotageDistrict::PilotageDistrictAssociation" => PilotageDistrict.PilotageDistrictAssociation(role),
			"PilotageDistrict::ServiceProvisionArea" => PilotageDistrict.ServiceProvisionArea(role),
			"RadarRange::TrafficControlServiceAggregation" => RadarRange.TrafficControlServiceAggregation(role),
			"RadioCallingInPoint::TrafficControlServiceAggregation" => RadioCallingInPoint.TrafficControlServiceAggregation(role),
			"ShipReportingServiceArea::TrafficControlServiceAggregation" => ShipReportingServiceArea.TrafficControlServiceAggregation(role),
			"SignalStationWarning::TrafficControlServiceAggregation" => SignalStationWarning.TrafficControlServiceAggregation(role),
			"SignalStationTraffic::TrafficControlServiceAggregation" => SignalStationTraffic.TrafficControlServiceAggregation(role),
			"VesselTrafficServiceArea::TrafficControlServiceAggregation" => VesselTrafficServiceArea.TrafficControlServiceAggregation(role),
			"TextPlacement::TextAssociation" => TextPlacement.TextAssociation(role),
			"" => throw new KeyNotFoundException(),
			_ => throw new KeyNotFoundException(),
		};

		public static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {
			var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
			resolver.Modifiers.Add(typeInfo => {
				if (typeInfo.Type == typeof(S100FC.informationBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AdditionalInformation>), typeDiscriminator: "AdditionalInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AuthorityContact>), typeDiscriminator: "AuthorityContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AuthorityHours>), typeDiscriminator: "AuthorityHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AssociatedRxN>), typeDiscriminator: "AssociatedRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ExceptionalWorkday>), typeDiscriminator: "ExceptionalWorkday"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.InclusionType>), typeDiscriminator: "InclusionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.PermissionType>), typeDiscriminator: "PermissionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.RelatedOrganisation>), typeDiscriminator: "RelatedOrganisation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ReportingAuthority>), typeDiscriminator: "ReportingAuthority"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ReportingRequirement>), typeDiscriminator: "ReportingRequirement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceContact>), typeDiscriminator: "ServiceContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceControl>), typeDiscriminator: "ServiceControl"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.SpatialAssociation>), typeDiscriminator: "SpatialAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.LocationHours>), typeDiscriminator: "LocationHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.TrafficServiceReport>), typeDiscriminator: "TrafficServiceReport"));
				}
				if (typeInfo.Type == typeof(S100FC.featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.ServiceProvisionArea>), typeDiscriminator: "ServiceProvisionArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.PilotageDistrictAssociation>), typeDiscriminator: "PilotageDistrictAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.TextAssociation>), typeDiscriminator: "TextAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.TrafficControlServiceAggregation>), typeDiscriminator: "TrafficControlServiceAggregation"));
				}
				if (typeInfo.Type == typeof(S100FC.attributeBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(administrativeDivision), typeDiscriminator: "administrativeDivision"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(applicationProfile), typeDiscriminator: "applicationProfile"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(callName), typeDiscriminator: "callName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(callSign), typeDiscriminator: "callSign"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cardinalDirection), typeDiscriminator: "cardinalDirection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfAuthority), typeDiscriminator: "categoryOfAuthority"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCommunicationPreference), typeDiscriminator: "categoryOfCommunicationPreference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCargo), typeDiscriminator: "categoryOfCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfConcentrationOfShippingHazardArea), typeDiscriminator: "categoryOfConcentrationOfShippingHazardArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfDangerousOrHazardousCargo), typeDiscriminator: "categoryOfDangerousOrHazardousCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfMilitaryPracticeArea), typeDiscriminator: "categoryOfMilitaryPracticeArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfNavigationLine), typeDiscriminator: "categoryOfNavigationLine"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfPilot), typeDiscriminator: "categoryOfPilot"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfPilotBoardingPlace), typeDiscriminator: "categoryOfPilotBoardingPlace"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfPreference), typeDiscriminator: "categoryOfPreference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRelationship), typeDiscriminator: "categoryOfRelationship"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRestrictedArea), typeDiscriminator: "categoryOfRestrictedArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRouteingMeasure), typeDiscriminator: "categoryOfRouteingMeasure"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSchedule), typeDiscriminator: "categoryOfSchedule"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfShipReport), typeDiscriminator: "categoryOfShipReport"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSignalStationTraffic), typeDiscriminator: "categoryOfSignalStationTraffic"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSignalStationWarning), typeDiscriminator: "categoryOfSignalStationWarning"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfTemporalVariation), typeDiscriminator: "categoryOfTemporalVariation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfText), typeDiscriminator: "categoryOfText"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfTrafficSeparationScheme), typeDiscriminator: "categoryOfTrafficSeparationScheme"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVesselRegistry), typeDiscriminator: "categoryOfVesselRegistry"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cityName), typeDiscriminator: "cityName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(communicationChannel), typeDiscriminator: "communicationChannel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(comparisonOperator), typeDiscriminator: "comparisonOperator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(condition), typeDiscriminator: "condition"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactInstructions), typeDiscriminator: "contactInstructions"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(countryName), typeDiscriminator: "countryName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateEnd), typeDiscriminator: "dateEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateFixed), typeDiscriminator: "dateFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateStart), typeDiscriminator: "dateStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateVariable), typeDiscriminator: "dateVariable"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dayOfWeek), typeDiscriminator: "dayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dayOfWeekIsRange), typeDiscriminator: "dayOfWeekIsRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(deliveryPoint), typeDiscriminator: "deliveryPoint"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(destination), typeDiscriminator: "destination"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(distance), typeDiscriminator: "distance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dynamicResource), typeDiscriminator: "dynamicResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileLocator), typeDiscriminator: "fileLocator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileReference), typeDiscriminator: "fileReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationReceives), typeDiscriminator: "frequencyShoreStationReceives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationTransmits), typeDiscriminator: "frequencyShoreStationTransmits"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(headline), typeDiscriminator: "headline"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalDistanceUncertainty), typeDiscriminator: "horizontalDistanceUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iMOFormatForReporting), typeDiscriminator: "iMOFormatForReporting"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(interoperabilityIdentifier), typeDiscriminator: "interoperabilityIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iSPSLevel), typeDiscriminator: "iSPSLevel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(inBallast), typeDiscriminator: "inBallast"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(language), typeDiscriminator: "language"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(linkage), typeDiscriminator: "linkage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(membership), typeDiscriminator: "membership"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameUsage), typeDiscriminator: "nameUsage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(logicalConnectives), typeDiscriminator: "logicalConnectives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumDisplayScale), typeDiscriminator: "maximumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumDisplayScale), typeDiscriminator: "minimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(mMSICode), typeDiscriminator: "mMSICode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(name), typeDiscriminator: "name"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameOfResource), typeDiscriminator: "nameOfResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nationality), typeDiscriminator: "nationality"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(noticeTimeHours), typeDiscriminator: "noticeTimeHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(noticeTimeText), typeDiscriminator: "noticeTimeText"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineFunction), typeDiscriminator: "onlineFunction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineResourceDescription), typeDiscriminator: "onlineResourceDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(operation), typeDiscriminator: "operation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(optimumDisplayScale), typeDiscriminator: "optimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationUncertainty), typeDiscriminator: "orientationUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationValue), typeDiscriminator: "orientationValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictorialRepresentation), typeDiscriminator: "pictorialRepresentation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureCaption), typeDiscriminator: "pictureCaption"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureInformation), typeDiscriminator: "pictureInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pilotMovement), typeDiscriminator: "pilotMovement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pilotQualification), typeDiscriminator: "pilotQualification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pilotRequest), typeDiscriminator: "pilotRequest"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pilotVessel), typeDiscriminator: "pilotVessel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(postalCode), typeDiscriminator: "postalCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocol), typeDiscriminator: "protocol"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocolRequest), typeDiscriminator: "protocolRequest"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(qualityOfHorizontalMeasurement), typeDiscriminator: "qualityOfHorizontalMeasurement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(remotePilot), typeDiscriminator: "remotePilot"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(reportedDate), typeDiscriminator: "reportedDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(requirementsForMaintenanceOfListeningWatch), typeDiscriminator: "requirementsForMaintenanceOfListeningWatch"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(restriction), typeDiscriminator: "restriction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scaleMinimum), typeDiscriminator: "scaleMinimum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(serviceAccessProcedure), typeDiscriminator: "serviceAccessProcedure"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(siltationRate), typeDiscriminator: "siltationRate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(source), typeDiscriminator: "source"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceDate), typeDiscriminator: "sourceDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sRSFormatCode), typeDiscriminator: "sRSFormatCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceType), typeDiscriminator: "sourceType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(status), typeDiscriminator: "status"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationIdentifier), typeDiscriminator: "telecommunicationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationCarrier), typeDiscriminator: "telecommunicationCarrier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationService), typeDiscriminator: "telecommunicationService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(text), typeDiscriminator: "text"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetBearing), typeDiscriminator: "textOffsetBearing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetDistance), typeDiscriminator: "textOffsetDistance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textRotation), typeDiscriminator: "textRotation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textType), typeDiscriminator: "textType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(thicknessOfIceCapability), typeDiscriminator: "thicknessOfIceCapability"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayEnd), typeDiscriminator: "timeOfDayEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayStart), typeDiscriminator: "timeOfDayStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(trafficFlow), typeDiscriminator: "trafficFlow"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(underKeelAllowanceFixed), typeDiscriminator: "underKeelAllowanceFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(underKeelAllowanceVariableBeamBased), typeDiscriminator: "underKeelAllowanceVariableBeamBased"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(underKeelAllowanceVariableDraughtBased), typeDiscriminator: "underKeelAllowanceVariableDraughtBased"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyFixed), typeDiscriminator: "uncertaintyFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyVariableFactor), typeDiscriminator: "uncertaintyVariableFactor"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselPerformance), typeDiscriminator: "vesselPerformance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristics), typeDiscriminator: "vesselsCharacteristics"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsUnit), typeDiscriminator: "vesselsCharacteristicsUnit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsValue), typeDiscriminator: "vesselsCharacteristicsValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(waterLevelTrend), typeDiscriminator: "waterLevelTrend"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(actionOrActivity), typeDiscriminator: "actionOrActivity"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRxN), typeDiscriminator: "categoryOfRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVessel), typeDiscriminator: "categoryOfVessel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactAddress), typeDiscriminator: "contactAddress"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureName), typeDiscriminator: "featureName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fixedDateRange), typeDiscriminator: "fixedDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyPair), typeDiscriminator: "frequencyPair"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalPositionUncertainty), typeDiscriminator: "horizontalPositionUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(information), typeDiscriminator: "information"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(noticeTime), typeDiscriminator: "noticeTime"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineResource), typeDiscriminator: "onlineResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientation), typeDiscriminator: "orientation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(periodicDateRange), typeDiscriminator: "periodicDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(rxNCode), typeDiscriminator: "rxNCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceIndication), typeDiscriminator: "sourceIndication"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(surveyDateRange), typeDiscriminator: "surveyDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(spatialAccuracy), typeDiscriminator: "spatialAccuracy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunications), typeDiscriminator: "telecommunications"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textContent), typeDiscriminator: "textContent"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeIntervalsByDayOfWeek), typeDiscriminator: "timeIntervalsByDayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(underKeelAllowance), typeDiscriminator: "underKeelAllowance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselMeasurementsSpecification), typeDiscriminator: "vesselMeasurementsSpecification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(bearingInformation), typeDiscriminator: "bearingInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(graphic), typeDiscriminator: "graphic"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scheduleByDayOfWeek), typeDiscriminator: "scheduleByDayOfWeek"));
				}
			});
			jsonSerializerOptions.TypeInfoResolver = resolver;
			return jsonSerializerOptions;
		}
	}
}
