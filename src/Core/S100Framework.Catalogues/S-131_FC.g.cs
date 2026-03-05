using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100FC.S131.SimpleAttributes
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
	/// The load line zone in which the port is located. Defined by the International Convention on Load Lines.
	/// </summary>
	public class applicableLoadLineZone : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(applicableLoadLineZone);
		[JsonIgnore]
		public override string S100FC_name => "Applicable Load Line Zone";

		public static implicit operator applicableLoadLineZone(String? value) => new applicableLoadLineZone { value = value };
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
	/// Description of the approach to a location.
	/// </summary>
	public class approachDescription : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(approachDescription);
		[JsonIgnore]
		public override string S100FC_name => "Approach Description";

		public static implicit operator approachDescription(String? value) => new approachDescription { value = value };
	}

	/// <summary>
	/// The name of an associated feature.
	/// </summary>
	public class associatedFeatureName : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(associatedFeatureName);
		[JsonIgnore]
		public override string S100FC_name => "Associated Feature Name";

		public static implicit operator associatedFeatureName(String? value) => new associatedFeatureName { value = value };
	}

	/// <summary>
	/// The length of a berth or dock which is available for use.
	/// </summary>
	[RangeConstraintReal(0.0d, 10000.0d, Closure.closedInterval)]
	public class availableBerthingLength : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(availableBerthingLength);
		[JsonIgnore]
		public override string S100FC_name => "Available Berthing Length";

		public static implicit operator availableBerthingLength(decimal? value) => new availableBerthingLength { value = value };
	}

	/// <summary>
	/// Classification of assistance for mooring or anchoring operations.
	/// </summary>
	public class berthingAssistance : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(berthingAssistance);
		[JsonIgnore]
		public override string S100FC_name => "Berthing Assistance";
		public static listedValue[] listedValues => [
				new listedValue("Berthing Information", "Information about assistance or arrangements for a service related to berthing operations.",1),
				new listedValue("Line Personnel", "Personnel specializing in the mooring and unmooring of vessels.",2),
				new listedValue("Mooring Boat", "A boat which assists the securement of a vessel to a berth or mooring with ropes or anchor.",3),
				new listedValue("Mule", "A locomotive for moving vessels.",4),
				new listedValue("Tugboat", "A powerful small boat designed to pull or push larger ships or powerless barges.",5),
				new listedValue("Icebreaking Ship", "A ship equipped to make and maintain a channel through ice.",6),
			];

		public static implicit operator berthingAssistance(int? value) => new berthingAssistance { value = value };
	}

	/// <summary>
	/// A textual description of the type of bollard at a berth or mooring facility.
	/// </summary>
	public class bollardDescription : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(bollardDescription);
		[JsonIgnore]
		public override string S100FC_name => "Bollard Description";

		public static implicit operator bollardDescription(String? value) => new bollardDescription { value = value };
	}

	/// <summary>
	/// An identifier used to locate a specific bollard.
	/// </summary>
	public class bollardNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(bollardNumber);
		[JsonIgnore]
		public override string S100FC_name => "Bollard Number";

		public static implicit operator bollardNumber(String? value) => new bollardNumber { value = value };
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
	/// Classification of services related to the goods or items carried by vessels.
	/// </summary>
	public class cargoService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cargoService);
		[JsonIgnore]
		public override string S100FC_name => "Cargo Service";
		public static listedValue[] listedValues => [
				new listedValue("Stevedoring", "The loading, unloading, moving or handling of cargo, ship's stores, gear, or other materials, into, in, on, or out of any vessel.",1),
				new listedValue("Cargo Surveying", "Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.",2),
				new listedValue("Cargo Lashing", "The securement of cargo to the ship's structure and/or other cargo.",3),
				new listedValue("Draught Survey", "Determination of the quantity of certain types of bulk cargo by assessment of its effect on displacement when loaded in a vessel.",4),
			];

		public static implicit operator cargoService(int? value) => new cargoService { value = value };
	}

	/// <summary>
	/// Classification of an area where different use types of vessel can remain static.
	/// </summary>
	public class categoryOfAnchorage : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfAnchorage);
		[JsonIgnore]
		public override string S100FC_name => "Category of Anchorage";
		public static listedValue[] listedValues => [
				new listedValue("Unrestricted Anchorage", "An area in which vessels anchor or may anchor.",1),
				new listedValue("Deep Water Anchorage", "An area in which vessels of deep draught anchor or may anchor.",2),
				new listedValue("Tanker Anchorage", "An area in which tankers anchor or may anchor.",3),
				new listedValue("Quarantine Anchorage", "An area where a vessel anchors when satisfying quarantine regulations.",5),
				new listedValue("Seaplane Anchorage", "An area in which seaplanes anchor or may anchor.",6),
				new listedValue("Small Craft Anchorage", "An area in which yachts and small boats anchor or may anchor.",7),
				new listedValue("Anchorage for Periods Up To 24 Hours", "An area in which vessels anchor or may anchor for periods of up to 24 hours.",9),
				new listedValue("Anchorage for a Limited Period of Time", "An area in which vessels may anchor for a period of time not to exceed a specific limit.",10),
				new listedValue("Waiting Anchorage", "An area in which vessels anchor or may anchor while waiting, for example, for access to a port or berth.",14),
				new listedValue("Reported Anchorage", "A location not defined by a regulatory authority that has been reported to be suitable and safe for anchoring.",15),
			];

		public static implicit operator categoryOfAnchorage(int? value) => new categoryOfAnchorage { value = value };
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
	/// Classification of a berth according to the method of describing its location or extent.
	/// </summary>
	public class categoryOfBerthLocation : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfBerthLocation);
		[JsonIgnore]
		public override string S100FC_name => "Category of Berth Location";
		public static listedValue[] listedValues => [
				new listedValue("Wharf Reference Metre Mark", "A wharf or quay with reference position(s) given by one or more metre marks.",1),
				new listedValue("Wharf Reference Position", "A wharf or quay with reference position(s) given by one or more point or points in geographic coordinates.",2),
				new listedValue("Pier (Jetty)", "A long, narrow structure extending into the water to afford a berthing place for vessels, to serve as a promenade, etc.",3),
				new listedValue("Multi-Buoy Mooring Berth", "A designated facility where a vessel may moor, usually by a combination of the mooring buoys and the ship’s anchors.",4),
			];

		public static implicit operator categoryOfBerthLocation(int? value) => new categoryOfBerthLocation { value = value };
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
	/// Classification of significant aspects of depths about which information is provided.
	/// </summary>
	public class categoryOfDepthsDescription : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfDepthsDescription);
		[JsonIgnore]
		public override string S100FC_name => "Category of Depths Description";
		public static listedValue[] listedValues => [
				new listedValue("Shoal", "A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.",1),
				new listedValue("General Depth", "General information about the vertical distance from the water surface to the bottom.",2),
				new listedValue("Controlling Depth", "The least depth in the approach or channel to an area, such as a port or anchorage, governing the maximum draft of vessels that can enter.",3),
			];

		public static implicit operator categoryOfDepthsDescription(int? value) => new categoryOfDepthsDescription { value = value };
	}

	/// <summary>
	/// Classification of a post or group of posts, used for mooring or warping a vessel.
	/// </summary>
	public class categoryOfDolphin : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfDolphin);
		[JsonIgnore]
		public override string S100FC_name => "Category of Dolphin";
		public static listedValue[] listedValues => [
				new listedValue("Mooring Dolphin", "A post or group of posts driven into the seabed or riverbed, used as a mooring point for vessels.",1),
				new listedValue("Deviation Dolphin", "A post or group of posts, which a vessel may swing around for compass adjustment.",2),
				new listedValue("Berthing Dolphin", "A post or group of posts driven into the seabed or riverbed, used to extend the berth of a vessel by providing extra mooring points.",3),
				new listedValue("Fender or Breasting Dolphin", "A post or group of posts driven into the seabed or riverbed, used to assist in berthing of vessels by taking up some berthing loads; keep vessels from pressing against the pier structure; or to protect structures from possible impact by ships.",4),
			];

		public static implicit operator categoryOfDolphin(int? value) => new categoryOfDolphin { value = value };
	}

	/// <summary>
	/// The electrical frequency provided by the power supply station.
	/// </summary>
	public class categoryOfFrequency : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfFrequency);
		[JsonIgnore]
		public override string S100FC_name => "Category of Frequency";
		public static listedValue[] listedValues => [
				new listedValue("50Hz", "50 Hertz",1),
				new listedValue("60Hz", "60 Hertz",2),
			];

		public static implicit operator categoryOfFrequency(int? value) => new categoryOfFrequency { value = value };
	}

	/// <summary>
	/// Classification of harbour use.
	/// </summary>
	public class categoryOfHarbourFacility : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfHarbourFacility);
		[JsonIgnore]
		public override string S100FC_name => "Category of Harbour Facility";
		public static listedValue[] listedValues => [
				new listedValue("RoRo Terminal", "A terminal for roll-on roll-off ferries.",1),
				new listedValue("Ferry Terminal", "A terminal for passenger and vehicle ferries.",3),
				new listedValue("Fishing Harbour", "A harbour with facilities for fishing boats.",4),
				new listedValue("Yacht Harbour/Marina", "A harbour facility for small boats, yachts, etc., where supplies, repairs, and various services are available.",5),
				new listedValue("Naval Base", "A centre of operations for naval vessels.",6),
				new listedValue("Tanker Terminal", "A terminal for the bulk handling of liquid cargoes.",7),
				new listedValue("Passenger Terminal", "A terminal for the loading and unloading of passengers.",8),
				new listedValue("Shipyard", "A place where ships are built or repaired.",9),
				new listedValue("Container Terminal", "A terminal with facilities to load/unload or store shipping containers.",10),
				new listedValue("Bulk Terminal", "A terminal for the handling of bulk materials such as iron ore, coal, etc.",11),
				new listedValue("Ship Lift", "A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.",12),
				new listedValue("Straddle Carrier", "A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.",13),
				new listedValue("Service Harbour", "A harbour within which the floating equipment (dredges, tugs ...) of harbour services are stationed.",14),
				new listedValue("Pilotage Service", "The services of a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area, are available.",15),
				new listedValue("Service and Repair", "A place where mechanical services or repairs can be undertaken to engines or other vessel equipment.",16),
				new listedValue("Quarantine Station", "A medical control center located in an isolated spot ashore where patients with contagious diseases from vessel in quarantine are taken.",17),
			];

		public static implicit operator categoryOfHarbourFacility(int? value) => new categoryOfHarbourFacility { value = value };
	}

	/// <summary>
	/// A place or structure to which a vessel can be secured.
	/// </summary>
	public class categoryOfMooringWarpingFacility : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfMooringWarpingFacility);
		[JsonIgnore]
		public override string S100FC_name => "Category of Mooring/Warping Facility";
		public static listedValue[] listedValues => [
				new listedValue("Tie-Up Wall", "A section of wall designated for tying-up vessels awaiting transit. Bollards and mooring devices are available for both large and small ships.",4),
				new listedValue("Post or Pile", "A long heavy timber or section of steel, wood, concrete, etc., forced into the seabed to serve as a mooring facility.",5),
				new listedValue("Mooring Cable", "A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.",6),
			];

		public static implicit operator categoryOfMooringWarpingFacility(int? value) => new categoryOfMooringWarpingFacility { value = value };
	}

	/// <summary>
	/// The type of plug(s) available at the power supply station.
	/// </summary>
	public class categoryOfPlug : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfPlug);
		[JsonIgnore]
		public override string S100FC_name => "Category of Plug";

		public static implicit operator categoryOfPlug(String? value) => new categoryOfPlug { value = value };
	}

	/// <summary>
	/// Classification of subdivisions of a port or harbour area by usage.
	/// </summary>
	public class categoryOfPortSection : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfPortSection);
		[JsonIgnore]
		public override string S100FC_name => "Category of Port Section";
		public static listedValue[] listedValues => [
				new listedValue("Port Fairway", "The main navigable channel in a harbour or its approaches, for vessels of larger size.",1),
				new listedValue("Berth Pocket", "A body of water at a berth or anchor berth, of adequate dimensions to allow a vessel to make fast to the shore, mooring buoys, berthing dolphins or to anchor.",3),
				new listedValue("Seaplane Anchorage", "An area in which sea-planes anchor or may anchor.",8),
				new listedValue("Dredged Basin", "An area of water or channel enlargement of increased depth compared to adjacent areas, where the depth is maintained by dredging operations.",9),
				new listedValue("Port Safety Zone", "The area around a port facility or harbour installation within which vessels are prohibited from entering without permission.",11),
				new listedValue("Lay-by Berth", "A general berth for use by vessels for short term waiting until a loading or discharging berth is available.",12),
			];

		public static implicit operator categoryOfPortSection(int? value) => new categoryOfPortSection { value = value };
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
	/// Classification of equipment or installations that are used for providing shoreside electrical power to a vessel at berth.
	/// </summary>
	public class categoryOfShorePowerFacility : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfShorePowerFacility);
		[JsonIgnore]
		public override string S100FC_name => "Category of Shore Power Facility";
		public static listedValue[] listedValues => [
				new listedValue("High-Voltage Shore Power System", "Delivers power to vessels using higher voltage (for example, 10 kV or above), suitable for large ports and large vessels. such as tankers, cargo ships, etc.",1),
				new listedValue("Low-Voltage Shore Power System", "Delivers power to vessels using lower voltage, designed for small to medium-sized coastal or riverine terminals and smaller vessels.",2),
				new listedValue("Hybrid Shore Power System", "Delivers power to vessels using high-voltage (for example, 10kV and above) and low-voltage outputs or simultaneous provision of dual-voltage power.",3),
			];

		public static implicit operator categoryOfShorePowerFacility(int? value) => new categoryOfShorePowerFacility { value = value };
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
				new listedValue("Likely to Change and Significant Shoaling Expected", "Continuous or frequent change (for example river siltation, sand waves, seasonal storms, ice bergs, etc) that is likely to result in new significant shoaling.",2),
				new listedValue("Likely to Change But Significant Shoaling Not Expected", "Continuous or frequent change (for example sand wave shift, seasonal storms, ice bergs, etc) that is not likely to result in new significant shoaling.",3),
				new listedValue("Likely to Change", "Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).",4),
				new listedValue("Unlikely to Change", "Significant change to the seafloor is not expected.",5),
				new listedValue("Unassessed", "Not having been assessed.",6),
			];

		public static implicit operator categoryOfTemporalVariation(int? value) => new categoryOfTemporalVariation { value = value };
	}

	/// <summary>
	/// Classification of terminals according to type of use, purpose, or type of cargo loaded or unloaded.
	/// </summary>
	public class categoryOfTerminal : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfTerminal);
		[JsonIgnore]
		public override string S100FC_name => "Category of Terminal";
		public static listedValue[] listedValues => [
				new listedValue("RoRo Terminal", "A terminal for roll-on roll-off ferries.",1),
				new listedValue("Ferry Terminal", "A terminal for passenger and vehicle ferries.",3),
				new listedValue("Tanker Terminal", "A terminal for the bulk handling of liquid cargoes.",7),
				new listedValue("Passenger Terminal", "A terminal for the loading and unloading of passengers.",8),
				new listedValue("Container Terminal", "A terminal with facilities to load/unload or store shipping containers.",10),
				new listedValue("Bulk Terminal", "A terminal for the handling of bulk materials such as iron ore, coal, etc.",11),
			];

		public static implicit operator categoryOfTerminal(int? value) => new categoryOfTerminal { value = value };
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
	/// The electrical voltage provided by the power supply station.
	/// </summary>
	public class categoryOfVoltage : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfVoltage);
		[JsonIgnore]
		public override string S100FC_name => "Category of Voltage";
		public static listedValue[] listedValues => [
				new listedValue("230V", "230 Volts",1),
				new listedValue("400V", "400 Volts.",2),
				new listedValue("120V", "120 Volts",3),
				new listedValue("120V or 240V", "120/240 Volts",4),
				new listedValue("208V", "208 Volts",5),
				new listedValue("440V", "440 Volts",6),
				new listedValue("440V or 690V", "440/690 Volts",7),
				new listedValue("480V", "480 Volts",8),
				new listedValue("690V", "690 Volts",9),
				new listedValue("6600V", "6.6 kiloVolts",10),
				new listedValue("6600V or 11000V", "6.6/11 kiloVolts",11),
				new listedValue("11000V", "11 kiloVolts",12),
				new listedValue("22000V", "22 kiloVolts",13),
				new listedValue("380V", "380 Volts",14),
				new listedValue("11000V or 22000V", "11/22 kiloVolts",15),
			];

		public static implicit operator categoryOfVoltage(int? value) => new categoryOfVoltage { value = value };
	}

	/// <summary>
	/// A system used to protect metal structures against corrosion by supplying direct current to the immersed external surface of the structure.
	/// </summary>
	public class cathodicProtectionSystem : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cathodicProtectionSystem);
		[JsonIgnore]
		public override string S100FC_name => "Cathodic Protection System";

		public static implicit operator cathodicProtectionSystem(Boolean? value) => new cathodicProtectionSystem { value = value };
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
				new listedValue("Ruined", "A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.",2),
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
				new listedValue("Sunday", "The day of the week following Saturday and preceding Monday.",1),
				new listedValue("Monday", "The day of the week following Sunday and preceding Tuesday.",2),
				new listedValue("Tuesday", "The day of the week following Monday and preceding Wednesday.",3),
				new listedValue("Wednesday", "The day of the week following Tuesday and preceding Thursday.",4),
				new listedValue("Thursday", "The day of the week following Wednesday and preceding Friday.",5),
				new listedValue("Friday", "The day of the week following Thursday and preceding Saturday.",6),
				new listedValue("Saturday", "The day of the week following Friday and preceding Sunday.",7),
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
	[StringLengthConstraint(100)]
	public class destination : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(destination);
		[JsonIgnore]
		public override string S100FC_name => "Destination";

		public static implicit operator destination(String? value) => new destination { value = value };
	}

	/// <summary>
	/// Describes a feature that is in development.
	/// </summary>
	public class development : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(development);
		[JsonIgnore]
		public override string S100FC_name => "Development";

		public static implicit operator development(String? value) => new development { value = value };
	}

	/// <summary>
	/// A numeric measure of the spatial separation between two locations.
	/// </summary>
	[PrecisionConstraint(1)]
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
	/// The altitude of the ground level of an object, measured from a specified vertical datum.
	/// </summary>
	[RangeConstraintReal(0.0d, 8850.0d, Closure.closedInterval)]
	public class elevation : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(elevation);
		[JsonIgnore]
		public override string S100FC_name => "Elevation";

		public static implicit operator elevation(decimal? value) => new elevation { value = value };
	}

	/// <summary>
	/// Description of the seaward end of a channel, harbour, dock, etc.
	/// </summary>
	public class entranceDescription : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(entranceDescription);
		[JsonIgnore]
		public override string S100FC_name => "Entrance Description";

		public static implicit operator entranceDescription(String? value) => new entranceDescription { value = value };
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
	/// Services for combating fires, provided by different methods.
	/// </summary>
	public class firefightingService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(firefightingService);
		[JsonIgnore]
		public override string S100FC_name => "Firefighting Service";
		public static listedValue[] listedValues => [
				new listedValue("Shore-Based Firefighting", "Personnel and equipment that are capable of combating a fire from ashore.",1),
				new listedValue("Onboard Firefighting", "Trained firefighting personnel with the capability of boarding and combating a fire on a vessel.",2),
				new listedValue("Firefighting Boat", "Specialised watercraft with firefighting apparatus designed for fighting shoreline and shipboard fires",3),
			];

		public static implicit operator firefightingService(int? value) => new firefightingService { value = value };
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
	/// The GLN extension component is used to identify internal physical locations within a location which is identified with a GLN. Must conform to the rules for GLN extension. (GS1 specification).
	/// </summary>
	public class gLNExtension : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(gLNExtension);
		[JsonIgnore]
		public override string S100FC_name => "GLN Extension";

		public static implicit operator gLNExtension(String? value) => new gLNExtension { value = value };
	}

	/// <summary>
	/// A globally unique, standardised identifier for parties and locations in business processes or supply chains.
	/// </summary>
	[StringLengthConstraint(13)]
	[TextPatternConstraint(@"\d{13}")]
	public class globalLocationNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(globalLocationNumber);
		[JsonIgnore]
		public override string S100FC_name => "Global Location Number";

		public static implicit operator globalLocationNumber(String? value) => new globalLocationNumber { value = value };
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
	/// Ships must take heaving lines thrown from the shore.
	/// </summary>
	public class heavingLinesFromShore : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(heavingLinesFromShore);
		[JsonIgnore]
		public override string S100FC_name => "Heaving Lines From Shore";

		public static implicit operator heavingLinesFromShore(Boolean? value) => new heavingLinesFromShore { value = value };
	}

	/// <summary>
	/// The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.
	/// </summary>
	[RangeConstraintReal(0.0d, double.MaxValue, Closure.gtSemiInterval)]
	public class height : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(height);
		[JsonIgnore]
		public override string S100FC_name => "Height";

		public static implicit operator height(decimal? value) => new height { value = value };
	}

	/// <summary>
	/// The best estimate of the horizontal accuracy of horizontal clearances and distances.
	/// </summary>
	[PrecisionConstraint(1)]
	[RangeConstraintReal(0d, double.MaxValue, Closure.geSemiInterval)]
	public class horizontalDistanceUncertainty : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(horizontalDistanceUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Horizontal Distance Uncertainty";

		public static implicit operator horizontalDistanceUncertainty(decimal? value) => new horizontalDistanceUncertainty { value = value };
	}

	/// <summary>
	/// Identification code as specified in predefined system. Also called identification number.
	/// </summary>
	public class iDCode : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(iDCode);
		[JsonIgnore]
		public override string S100FC_name => "ID Code";

		public static implicit operator iDCode(String? value) => new iDCode { value = value };
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
	/// A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.
	/// </summary>
	[TextPatternConstraint(@"urn:mrn:.+")]
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
		public override string S100FC_name => "ISPS Level";
		public static listedValue[] listedValues => [
				new listedValue("ISPS Level 1", "The level for which minimum appropriate protective security measures shall be maintained at all times.",1),
				new listedValue("ISPS Level 2", "The level for which appropriate additional protective security measures shall be maintained for a period of time as a result of heightened risk of a security incident.",2),
				new listedValue("ISPS Level 3", "The level for which further specific protective security measures shall be maintained for a limited period of time when a security incident is probable or imminent, although it may not be possible to identify the specific target.",3),
			];

		public static implicit operator iSPSLevel(int? value) => new iSPSLevel { value = value };
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
	/// Location (address) for online access using a URL/URI address or similar addressing scheme.
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
	/// Description of local knowledge that may be needed, for example to traverse a location.
	/// </summary>
	public class localKnowledgeDescription : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(localKnowledgeDescription);
		[JsonIgnore]
		public override string S100FC_name => "Local Knowledge Description";

		public static implicit operator localKnowledgeDescription(String? value) => new localKnowledgeDescription { value = value };
	}

	/// <summary>
	/// A textual rendering of a geographic location.
	/// </summary>
	public class locationByText : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(locationByText);
		[JsonIgnore]
		public override string S100FC_name => "Location by Text";

		public static implicit operator locationByText(String? value) => new locationByText { value = value };
	}

	/// <summary>
	/// Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.
	/// </summary>
	public class locationMRN : S100FC.UrnTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(locationMRN);
		[JsonIgnore]
		public override string S100FC_name => "Location Maritime Resource Name";

		public static implicit operator locationMRN(String? value) => new locationMRN { value = value };
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
	/// An identifier for a specific location on a manifold (a pipe or chamber with several openings).
	/// </summary>
	public class manifoldNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(manifoldNumber);
		[JsonIgnore]
		public override string S100FC_name => "Manifold Number";

		public static implicit operator manifoldNumber(String? value) => new manifoldNumber { value = value };
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
	/// The maximum draught of a vessel permitted along a route, in a channel or dock, at a berth, or over a submerged feature.
	/// </summary>
	[PrecisionConstraint(1)]
	[RangeConstraintReal(0.0d, 30.0d, Closure.gtLeInterval)]
	public class maximumPermittedDraught : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximumPermittedDraught);
		[JsonIgnore]
		public override string S100FC_name => "Maximum Permitted Draught";

		public static implicit operator maximumPermittedDraught(decimal? value) => new maximumPermittedDraught { value = value };
	}

	/// <summary>
	/// The maximum length of a vessel permitted in a channel or dock, at a berth, or at an anchorage or mooring.
	/// </summary>
	[PrecisionConstraint(1)]
	[RangeConstraintReal(0.0d, double.MaxValue, Closure.gtSemiInterval)]
	public class maximumPermittedVesselLength : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximumPermittedVesselLength);
		[JsonIgnore]
		public override string S100FC_name => "Maximum Permitted Vessel Length";

		public static implicit operator maximumPermittedVesselLength(decimal? value) => new maximumPermittedVesselLength { value = value };
	}

	/// <summary>
	/// Services for the prevention or treatment of, or response to injury or illness.
	/// </summary>
	public class medicalService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(medicalService);
		[JsonIgnore]
		public override string S100FC_name => "Medical Service";
		public static listedValue[] listedValues => [
				new listedValue("Ambulance", "A vehicle for conveying the sick or injured to or from a hospital.",1),
				new listedValue("Fumigation", "Disinfection or purification with fumes.",2),
				new listedValue("Doctor", "A place where a doctor is available to provide medical attention.",3),
				new listedValue("Quarantine", "The isolation of patients with contagious diseases.",4),
				new listedValue("Vaccination Centre", "A place where substances intended to procure immunity against one or several diseases are administered.",5),
			];

		public static implicit operator medicalService(int? value) => new medicalService { value = value };
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
	/// The process, arrangement or scheme of attachment used to secure a vessel to a berth.
	/// </summary>
	public class methodOfSecuring : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(methodOfSecuring);
		[JsonIgnore]
		public override string S100FC_name => "Method of Securing";
		public static listedValue[] listedValues => [
				new listedValue("Bow to Seaward", "Vessel is secured perpendicular to the wharf with bow to seaward.",1),
				new listedValue("Stern to Seaward", "Vessel is secured perpendicular to the wharf with stern to the seaward.",2),
				new listedValue("Mediterranean Mooring", "The vessel is secured perpendicular to the wharf.",3),
				new listedValue("Baltic Mooring", "Mooring method/procedure used during onshore wind conditions without a tug.",4),
				new listedValue("Running Mooring", "Mooring by maneuvering ahead and astern while dropping anchors to secure the vessel with reduced swinging room.",5),
				new listedValue("Standing Mooring", "Mooring by using mainly wind and tide to position the vessel while dropping anchors to secure the vessel with reduced swinging room. Makes limited use of the engine to position the vessel.",6),
				new listedValue("Single Point Mooring", "A mooring structure used by tankers to load and unload in port approaches or in offshore oil and gas fields. The size of the structure can vary between a large mooring buoy and a manned floating structure.",7),
				new listedValue("Multi-Buoy Mooring", "A facility where a vessel is usually moored by a combination of the ship’s anchors forward and mooring buoys aft and held on a fixed heading. Also called Conventional Buoy Mooring (CBM).",8),
				new listedValue("Ship-to-Ship Mooring", "Mooring alongside another vessel.",9),
				new listedValue("Spider Buoy Mooring", "Mooring system supported by a spider buoy.",10),
			];

		public static implicit operator methodOfSecuring(int? value) => new methodOfSecuring { value = value };
	}

	/// <summary>
	/// An identifier for a specific position along a linear or curvilinear extent of a wharf, quay, or jetty. Numbering may be continued over multiple segments.
	/// </summary>
	public class metreMarkNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(metreMarkNumber);
		[JsonIgnore]
		public override string S100FC_name => "Metre Mark Number";

		public static implicit operator metreMarkNumber(String? value) => new metreMarkNumber { value = value };
	}

	/// <summary>
	/// The least depth of the body of water at the berth or in a berth pocket adjacent to the berth.
	/// </summary>
	[RangeConstraintReal(0.00d, double.MaxValue, Closure.gtSemiInterval)]
	public class minimumBerthDepth : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minimumBerthDepth);
		[JsonIgnore]
		public override string S100FC_name => "Minimum Berth Depth";

		public static implicit operator minimumBerthDepth(decimal? value) => new minimumBerthDepth { value = value };
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
	/// The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.
	/// </summary>
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
	[RangeConstraintReal(0.000d, 360.000d, Closure.geLtInterval)]
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
	/// Number assigned to the port facility in the IMO port facility database.
	/// </summary>
	public class portFacilityNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(portFacilityNumber);
		[JsonIgnore]
		public override string S100FC_name => "Port Facility Number";

		public static implicit operator portFacilityNumber(String? value) => new portFacilityNumber { value = value };
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
	/// The various substances which are transported, stored or exploited.
	/// </summary>
	public class product : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(product);
		[JsonIgnore]
		public override string S100FC_name => "Product";
		public static listedValue[] listedValues => [
				new listedValue("Oil", "A thick, slippery liquid that will not dissolve in water, usually petroleum based in the context of storage tanks.",1),
				new listedValue("Gas", "A substance with particles that can move freely, usually a fuel substance in the context of storage tanks.",2),
				new listedValue("Stone", "A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.",4),
				new listedValue("Coal", "A hard black mineral that is burned as fuel.",5),
				new listedValue("Ore", "A solid rock or mineral from which metal is obtained.",6),
				new listedValue("Chemicals", "Any substance obtained by or used in a chemical process.",7),
				new listedValue("Milk", "A white fluid secreted by female mammals as food for their young.",9),
				new listedValue("Bauxite", "A mineral from which aluminum is obtained.",10),
				new listedValue("Coke", "A solid substance obtained after gas and tar have been extracted from coal, used as a fuel.",11),
				new listedValue("Iron Ingots", "An oblong lump of cast iron metal.",12),
				new listedValue("Salt", "Sodium chloride obtained from mines or by the evaporation of sea water.",13),
				new listedValue("Sand", "Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.",14),
				new listedValue("Timber", "Wood prepared for use in building or carpentry.",15),
				new listedValue("Sawdust/Wood Chips", "Powdery fragments of wood made in sawing timber or coarse chips produced for use in manufacturing pressed board.",16),
				new listedValue("Scrap Metal", "Discarded metal suitable for being reprocessed.",17),
				new listedValue("Liquefied Natural Gas", "Natural gas that has been liquefied for ease of transport by cooling the gas to -162 Celsius.",18),
				new listedValue("Liquefied Petroleum Gas", "A compressed gas consisting of flammable light hydrocarbons and derived from petroleum.",19),
				new listedValue("Wine", "The fermented juice of grapes.",20),
				new listedValue("Cement", "A substance made of powdered lime and clay, mixed with water.",21),
				new listedValue("Grain", "A small hard seed, especially that of any cereal plant such as wheat, rice, corn, rye etc.",22),
			];

		public static implicit operator product(int? value) => new product { value = value };
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
	/// The vector extending from the centre to the periphery of a circular or spherical feature.
	/// </summary>
	[PrecisionConstraint(1)]
	[RangeConstraintReal(0.0d, double.MaxValue, Closure.gtSemiInterval)]
	public class radius : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(radius);
		[JsonIgnore]
		public override string S100FC_name => "Radius";

		public static implicit operator radius(decimal? value) => new radius { value = value };
	}

	/// <summary>
	/// An identifier for a specific ramp (a sloping structure that can be used as a landing place for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel, or for the transfer of rolling cargo).
	/// </summary>
	public class rampNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(rampNumber);
		[JsonIgnore]
		public override string S100FC_name => "Ramp Number";

		public static implicit operator rampNumber(String? value) => new rampNumber { value = value };
	}

	/// <summary>
	/// Work or maintenance activities whereby vessels or equipment are restored to working order, renovated, or improved in condition.
	/// </summary>
	public class repairService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(repairService);
		[JsonIgnore]
		public override string S100FC_name => "Repair Service";
		public static listedValue[] listedValues => [
				new listedValue("Compensation of Magnetic Compass", "The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.",1),
				new listedValue("Diver Service", "Underwater inspection and repair performed by divers.",2),
				new listedValue("Bridge Equipment Repair", "Repairs to eqipment installed on the ship's bridge.",3),
				new listedValue("Engine Repair", "Repair of an engine or machine parts.",4),
				new listedValue("Electronic Equipment Repair", "Repair of marine electronic instruments.",5),
				new listedValue("Hull Repair", "Repairs to the ship's body, frame, or superstructure.",6),
				new listedValue("Navigational Equipment Repair", "Repairs to equipment used in the act of navigating a ship.",7),
				new listedValue("Propeller Repair", "Repairs to propeller hub and blades.",8),
				new listedValue("Salvage Gear Repair", "Repairs to equipment used in salvage operations.",9),
				new listedValue("Shaft Repair", "Repairs to drive shafts used for transmitting mechanical power and torque to a propeller.",10),
			];

		public static implicit operator repairService(int? value) => new repairService { value = value };
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
	/// The maximum safe force or load that a piece of equipment, device, or accessory can handle without breaking or failing under normal conditions.
	/// </summary>
	[RangeConstraintReal(0.0d, double.MaxValue, Closure.gtSemiInterval)]
	public class safeWorkingLoad : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(safeWorkingLoad);
		[JsonIgnore]
		public override string S100FC_name => "Safe Working Load";

		public static implicit operator safeWorkingLoad(decimal? value) => new safeWorkingLoad { value = value };
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
	/// Application of measures to ensure that a vessel is free of disease and disease risks, or issue of completion or exemption certificates for such measures.
	/// </summary>
	public class shipSanitationControl : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(shipSanitationControl);
		[JsonIgnore]
		public override string S100FC_name => "Ship Sanitation Control";
		public static listedValue[] listedValues => [
				new listedValue("Sanitation Measures Only", "Capable of applying measures to ensure that a vessel is free of disease and disease risks, but cannot issue a certificate.",1),
				new listedValue("Issue SSCC", "The competent authority can issue a Ship Sanitation Control Certificate after satisfactorily completing or supervising the completion of ship sanitation control measures.",2),
				new listedValue("Issue SSCEC", "The competent authority may issue a Ship Sanitation Control Exemption Certificate if it is satisfied that the ship is free of infection and contamination, including vectors and reservoirs.",3),
			];

		public static implicit operator shipSanitationControl(int? value) => new shipSanitationControl { value = value };
	}

	/// <summary>
	/// A textual description of precautions for shore power usage.
	/// </summary>
	public class shorePowerDescription : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(shorePowerDescription);
		[JsonIgnore]
		public override string S100FC_name => "Shore Power Description";

		public static implicit operator shorePowerDescription(String? value) => new shorePowerDescription { value = value };
	}

	/// <summary>
	/// An entity that generates, sells, or is responsible for supplying shore power to vessels.
	/// </summary>
	public class shorePowerServiceProvider : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(shorePowerServiceProvider);
		[JsonIgnore]
		public override string S100FC_name => "Shore Power Service Provider";

		public static implicit operator shorePowerServiceProvider(String? value) => new shorePowerServiceProvider { value = value };
	}

	/// <summary>
	/// The greatest depth over a sill.
	/// </summary>
	[RangeConstraintReal(0.0d, 100.0d, Closure.closedInterval)]
	public class sillDepth : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sillDepth);
		[JsonIgnore]
		public override string S100FC_name => "Sill Depth";

		public static implicit operator sillDepth(decimal? value) => new sillDepth { value = value };
	}

	/// <summary>
	/// A code from the SMDG (Ship Message Design Group) Terminal Code List.
	/// </summary>
	public class sMDGTerminalCode : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sMDGTerminalCode);
		[JsonIgnore]
		public override string S100FC_name => "SMDG Terminal Code";

		public static implicit operator sMDGTerminalCode(String? value) => new sMDGTerminalCode { value = value };
	}

	/// <summary>
	/// The publication, document, or reference work from which information comes or is acquired.
	/// </summary>
	[StringLengthConstraint(150)]
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
	/// Classification of services for the provision of materials, goods, utilities, or personal services to vessels, passengers, or crew.
	/// </summary>
	public class supplyService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(supplyService);
		[JsonIgnore]
		public override string S100FC_name => "Supply Service";
		public static listedValue[] listedValues => [
				new listedValue("Shore Power", "The provision of shoreside electrical power to a ship at berth while its main and auxiliary engines are shut down.",1),
				new listedValue("Fuel Oil Bunkering", "Transfer of fuel oil to the fuel compartments of a ship.",2),
				new listedValue("LNG Bunkering", "Transfer of liquefied natural gas to the fuel compartments of a ship.",3),
				new listedValue("Lubricants", "Substances capable of reducing friction, heat, and wear when introduced as a film between solid surfaces.",4),
				new listedValue("Steam", "The gas into which water is changed by boiling.",5),
				new listedValue("Potable Water", "Water which can be used for drinking and food preparation.",6),
				new listedValue("International Shore Connection", "A universal hose connection for the supply of water for fighting fires.",7),
				new listedValue("Provisions", "A place where food and other such supplies are available.",8),
				new listedValue("Chandler", "A dealer in ships' supplies.",9),
				new listedValue("Mechanics Workshop", "A place where mechanical repairs can be undertaken to engines or other vessel equipment.",10),
			];

		public static implicit operator supplyService(int? value) => new supplyService { value = value };
	}

	/// <summary>
	/// Services for the adjustment of vessel equipment or for assessments pertaining to cargo, compliance with regulations, safety, or security.
	/// </summary>
	public class technicalPortService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(technicalPortService);
		[JsonIgnore]
		public override string S100FC_name => "Technical Port Service";
		public static listedValue[] listedValues => [
				new listedValue("Compensation of Magnetic Compass", "The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.",1),
				new listedValue("Degaussing", "Neutralization of the strength of the magnetic field of a vessel, by means of suitably arranged electric coils permanently installed in the vessel. See also Degaussing Cable.",2),
				new listedValue("Cargo Surveying", "Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.",3),
				new listedValue("Vetting", "Assessment of quality and compliance with applicable law, regulations, and safety standards.",4),
			];

		public static implicit operator technicalPortService(int? value) => new technicalPortService { value = value };
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
	/// The unique identifier for a given terminal.
	/// </summary>
	public class terminalIdentifier : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(terminalIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Terminal Identifier";

		public static implicit operator terminalIdentifier(String? value) => new terminalIdentifier { value = value };
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
	/// Textual description of the types and capacities of available tugs.
	/// </summary>
	public class tugInformation : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(tugInformation);
		[JsonIgnore]
		public override string S100FC_name => "Tug Information";

		public static implicit operator tugInformation(String? value) => new tugInformation { value = value };
	}

	/// <summary>
	/// Used to encode the UN Location Code (http://www.unece.org/cefact/locode/service/location.html) or - in Europe - the Inland Ship Reporting Standard (ISRS) Code.
	/// </summary>
	[StringLengthConstraint(20)]
	public class uNLocationCode : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(uNLocationCode);
		[JsonIgnore]
		public override string S100FC_name => "UN Location Code";

		public static implicit operator uNLocationCode(String? value) => new uNLocationCode { value = value };
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
	/// The vertical clearance measured from the horizontal plane towards the feature overhead.
	/// </summary>
	[RangeConstraintReal(0.1d, 100.0d, Closure.closedInterval)]
	public class verticalClearanceValue : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalClearanceValue);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Clearance Value";

		public static implicit operator verticalClearanceValue(decimal? value) => new verticalClearanceValue { value = value };
	}

	/// <summary>
	/// The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.
	/// </summary>
	public class verticalDatum : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalDatum);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Datum";
		public static listedValue[] listedValues => [
				new listedValue("Mean Low Water Springs", "The average height of the low waters of spring tides. This level is used as a tidal datum in some areas. Also called spring low water.",1),
				new listedValue("Mean Lower Low Water Springs", "The average height of lower low water springs at a place.",2),
				new listedValue("Mean Sea Level", "The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.",3),
				new listedValue("Lowest Low Water", "An arbitrary level conforming to the lowest tide observed at a place, or some what lower.",4),
				new listedValue("Mean Low Water", "The average height of all low waters at a place over a 19-year period.",5),
				new listedValue("Lowest Low Water Springs", "An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.",6),
				new listedValue("Approximate Mean Low Water Springs", "An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).",7),
				new listedValue("Indian Spring Low Water", "An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.",8),
				new listedValue("Low Water Springs", "An arbitrary level, approximating that of mean low water springs (MLWS).",9),
				new listedValue("Approximate Lowest Astronomical Tide", "An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).",10),
				new listedValue("Nearly Lowest Low Water", "An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).",11),
				new listedValue("Mean Lower Low Water", "The average height of the lower low waters at a place over a 19-year period.",12),
				new listedValue("Low Water", "The lowest level reached at a place by the water surface in one oscillation. Also called low tide.",13),
				new listedValue("Approximate Mean Low Water", "An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).",14),
				new listedValue("Approximate Mean Lower Low Water", "An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).",15),
				new listedValue("Mean High Water", "The average height of all high waters at a place over a 19-year period.",16),
				new listedValue("Mean High Water Springs", "The average height of the high waters of spring tides. Also called spring high water.",17),
				new listedValue("High Water", "The highest level reached at a place by the water surface in one oscillation.",18),
				new listedValue("Approximate Mean Sea Level", "An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).",19),
				new listedValue("High Water Springs", "An arbitrary level, approximating that of mean high water springs (MHWS).",20),
				new listedValue("Mean Higher High Water", "The average height of higher high waters at a place over a 19-year period.",21),
				new listedValue("Equinoctial Spring Low Water", "The level of low water springs near the time of an equinox.",22),
				new listedValue("Lowest Astronomical Tide", "The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.",23),
				new listedValue("Local Datum", "An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.",24),
				new listedValue("International Great Lakes Datum 1985", "A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Pere, Quebec, over the period 1970 to 1988.",25),
				new listedValue("Mean Water Level", "The average of all hourly water levels over the available period of record.",26),
				new listedValue("Lower Low Water Large Tide", "The average of the lowest low waters, one from each of 19 years of observations.",27),
				new listedValue("Higher High Water Large Tide", "The average of the highest high waters, one from each of 19 years of observations.",28),
				new listedValue("Nearly Highest High Water", "An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.",29),
				new listedValue("Highest Astronomical Tide", "The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.",30),
				new listedValue("Baltic Sea Chart Datum 2000", "The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).",44),
			];

		public static implicit operator verticalDatum(int? value) => new verticalDatum { value = value };
	}

	/// <summary>
	/// The total vertical length of a feature.
	/// </summary>
	[RangeConstraintReal(0.0d, double.MaxValue, Closure.gtSemiInterval)]
	public class verticalLength : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalLength);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Length";

		public static implicit operator verticalLength(decimal? value) => new verticalLength { value = value };
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
				new listedValue("Ton", "Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).",4),
				new listedValue("Short Ton", "A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).",5),
				new listedValue("Gross Ton", "Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.",6),
				new listedValue("Net Ton", "Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.",7),
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
	/// A mooring set aside for the use of visiting vessels.
	/// </summary>
	public class visitorsMooring : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(visitorsMooring);
		[JsonIgnore]
		public override string S100FC_name => "Visitors Mooring";

		public static implicit operator visitorsMooring(Boolean? value) => new visitorsMooring { value = value };
	}

	/// <summary>
	/// Service for the reception of residues, polluting substances, refuse, oily wastes, and by-products from ships.
	/// </summary>
	public class wasteDisposalService : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(wasteDisposalService);
		[JsonIgnore]
		public override string S100FC_name => "Waste Disposal Service";
		public static listedValue[] listedValues => [
				new listedValue("MARPOL Annex I Oily Bilge Water", "The service with facility to receive oil related waste/residue of the type \"Oily bilge water\" as specified in MARPOL Annex I.",1),
				new listedValue("MARPOL Annex I Oily Residues", "The service with facility to receive oil related waste/residue of the type \"Oily Residues (sludge)\" as specified in MARPOL Annex I.",2),
				new listedValue("MARPOL Annex I Oily Tank Washings", "The service with facility to receive oil related waste/residue of the type \"Oily tank washings (slops)\" as specified in MARPOL Annex I.",3),
				new listedValue("MARPOL Annex I Dirty Ballast Water", "The service with facility to receive oil related waste/residue of the type \"Dirty ballast water\" as specified in MARPOL Annex I.",4),
				new listedValue("MARPOL Annex I Scale and Sludge from Tank Cleaning", "The service with facility to receive oil related waste/residue of the type \"Scale and sludge from tank cleaning\" as specified in MARPOL Annex I.",5),
				new listedValue("MARPOL Annex I Other Oily Waste", "The service with facility to receive oil related waste/residue of the type \"Other\" as specified in MARPOL Annex I.",6),
				new listedValue("MARPOL Annex II Category X", "The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category X\" as specified in MARPOL Annex II.",7),
				new listedValue("MARPOL Annex II Category Y", "The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Y\" as specified in MARPOL Annex II.",8),
				new listedValue("MARPOL Annex II Category Z", "The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Z\" as specified in MARPOL Annex II.",9),
				new listedValue("MARPOL Annex II Category OS", "The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Other substance\" as specified in MARPOL Annex II.",10),
				new listedValue("MARPOL Annex IV Sewage", "The service with facility to receive waste/residue of the type \"Sewage\" as specified in MARPOL Annex IV.",11),
				new listedValue("MARPOL Annex V Plastics", "The service with facility to receive garbage related waste/residue of the type \"Plastics\", as specified in MARPOL Annex V",12),
				new listedValue("MARPOL Annex V Food Wastes", "The service with facility to receive garbage related waste/residue of the type \"Food wastes\", as specified in MARPOL Annex V",13),
				new listedValue("MARPOL Annex V Domestic Wastes", "The service with facility to receive garbage related waste/residue of the type \"Domestic wastes\", as specified in MARPOL Annex V",14),
				new listedValue("MARPOL Annex V Cooking Oil", "The service with facility to receive garbage related waste/residue of the type \"Cooking oil\", as specified in MARPOL Annex V",15),
				new listedValue("MARPOL Annex V Incinerator Ashes", "The service with facility to receive garbage related waste/residue of the type \"Incinerator ashes\", as specified in MARPOL Annex V",16),
				new listedValue("MARPOL Annex V Operational Wastes", "The service with facility to receive garbage related waste/residue of the type \"Operational wastes\", as specified in MARPOL Annex V",17),
				new listedValue("MARPOL Annex V Animal Carcasses", "The service with facility to receive garbage related waste/residue of the type \"Animal carcasses\", as specified in MARPOL Annex V",18),
				new listedValue("MARPOL Annex V Fishing Gear", "The service with facility to receive garbage related waste/residue of the type \"Fishing gear\", as specified in MARPOL Annex V",19),
				new listedValue("MARPOL Annex V E-Waste", "The service with facility to receive garbage related waste/residue of the type \"E-waste\", as specified in MARPOL Annex V",20),
				new listedValue("MARPOL Annex V Cargo Residues - non-HME", "The service with facility to receive garbage related waste/residue of the type \"Cargo residues not determined to be harmful to the marine environment\", as specified in MARPOL Annex V",21),
				new listedValue("MARPOL Annex V Cargo Residues - HME", "The service with facility to receive garbage related waste/residue of the type \"Cargo residues harmful to the marine environment\", as specified in MARPOL Annex V",22),
				new listedValue("MARPOL Annex VI Ozone-Depleting Substances", "The service with facility to receive air pollution related waste/residue of the type \"Ozone-depleting substances\" as specified in MARPOL Annex VI.",23),
				new listedValue("MARPOL Annex VI Exhaust Gas-Cleaning Residues", "The service with facility to receive air pollution related waste/residue of the type \"Exhaust gas-cleaning residues\" as specified in MARPOL Annex VI.",24),
			];

		public static implicit operator wasteDisposalService(int? value) => new wasteDisposalService { value = value };
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
				new listedValue("Berthing", "Attaching a vessel to a wharf or jetty.",4),
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

	/// <summary>
	/// Protective services, law enforcement, or services for responding to sudden danger.
	/// </summary>
	public class securitySafetyEmergencyService : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(securitySafetyEmergencyService);
		[JsonIgnore]
		public override string S100FC_name => "Security-Safety-Emergency Service";
		public static listedValue[] listedValues => [
				new listedValue("Coast Guard", "Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.",1),
				new listedValue("Customs", "The agency or establishment for collecting duties, tolls.",2),
				new listedValue("Environmental Emergency Information Centre", "Office for reporting or obtaining information about sudden dangers to the environment such as spillage of polluting or hazardous substances.",3),
				new listedValue("Emergency Coordination Centre", "An office or organisation for reporting or coordinating response to emergencies.",4),
				new listedValue("Guard and/or Security Service", "A place where a vessel is patrolled by a security service or stored in a secure lockup.",5),
				new listedValue("Immigration", "The authority controlling people entering a country.",6),
				new listedValue("Police", "The department of government, or civil force, charged with maintaining public order.",7),
				new listedValue("Sea Rescue Control", "A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.",8),
			];
	}

	/// <summary>
	/// Classification of services for the conveyance of persons and/or goods, according to means of transport, nature of path, or representative installation.
	/// </summary>
	public class transportConnection : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(transportConnection);
		[JsonIgnore]
		public override string S100FC_name => "Transport Connection";
		public static listedValue[] listedValues => [
				new listedValue("Heliport", "A small airport for the use of helicopters and some other vertical lift aircraft. Heliports typically contain one or more touchdown and liftoff areas and also have facilities such as fuel or hangars. In some larger towns and cities, customs facilities may also be available.",2),
				new listedValue("Helipad", "A small landing surface for helicopters, with minimal or no supporting installations or facilities.",3),
				new listedValue("Hired Boat", "Small boat with crew that may be hired for single journeys.",4),
				new listedValue("Bus Station", "A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.",5),
				new listedValue("Ferry", "A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.",6),
				new listedValue("Motorway", "A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.",8),
				new listedValue("Launch", "Large open or half decked boat.",9),
				new listedValue("Inland Waterway Transport", "The carriage of goods or passengers using navigable waterways such as canals, rivers, lakes, or other stretch of water that is not part of the sea.",11),
				new listedValue("Short Sea Transportation", "The carriage of specified types of cargo between qualifying ports. The types of cargo and/or qualifying ports are generally specified by law or government regulation.",12),
				new listedValue("Marine Highway", "Specially designated commercially navigable routes in coastal, inland, and intracoastal waters, frequently as waterborne relievers to congested landside routes.",13),
			];
	}

}

namespace S100FC.S131.ComplexAttributes
{
	using S100FC.S131.SimpleAttributes;

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
		public String?[] deliveryPoint {
			set { base.SetAttribute("deliveryPoint", [.. value.Select(e=> new deliveryPoint { value = e })]); }
			get { return base.GetAttributeValues<deliveryPoint>(nameof(deliveryPoint)).Select(e=>e.value).ToArray(); }
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
					upper = 2147483647,
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
	/// Description of Aids to Navigation or prominent marks which are usually clearly visible and identifiable enough to be used in determining location or direction.
	/// </summary>
	public class usefulMarkDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(usefulMarkDescription);
		[JsonIgnore]
		public override string S100FC_name => "Useful Mark Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
	/// </summary>
	public class verticalUncertainty : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Uncertainty";

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
	/// Links for relevant weather related information.
	/// </summary>
	public class weatherResource : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(weatherResource);
		[JsonIgnore]
		public override string S100FC_name => "Weather Resource";

		#region Attributes
		[JsonIgnore]
		public onlineResource? onlineResource {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<onlineResource>(nameof(onlineResource)); }
		}
		[JsonIgnore]
		public int? dynamicResource {
			set { base.SetAttribute(new dynamicResource { value = value }); }
			get { return base.GetAttributeValue<dynamicResource>(nameof(dynamicResource))?.value; }
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
				new attributeBindingDefinition {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new onlineResource(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dynamicResource),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new dynamicResource(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new textContent(),
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
	/// Description of services related to the goods or items carried by vessels.
	/// </summary>
	public class cargoServicesDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cargoServicesDescription);
		[JsonIgnore]
		public override string S100FC_name => "Cargo Services Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A description of construction or other development in a location where the work will affect vessel operations such as navigation, maneuvering or docking/berthing.
	/// </summary>
	public class constructionInformation : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(constructionInformation);
		[JsonIgnore]
		public override string S100FC_name => "Construction Information";

		#region Attributes
		[JsonIgnore]
		public fixedDateRange? fixedDateRange {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public int? condition {
			set { base.SetAttribute(new condition { value = value }); }
			get { return base.GetAttributeValue<condition>(nameof(condition))?.value; }
		}
		[JsonIgnore]
		public String? development {
			set { base.SetAttribute(new development { value = value }); }
			get { return base.GetAttributeValue<development>(nameof(development))?.value; }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
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
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(condition),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,5],
					CreateInstance = () => new condition(),
				},
				new attributeBindingDefinition {
					attribute = nameof(development),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new development(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Textual description of the characteristics and notable matters pertaining to depths in an area.
	/// </summary>
	public class depthsDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(depthsDescription);
		[JsonIgnore]
		public override string S100FC_name => "Depths Description";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfDepthsDescription {
			set { base.SetAttribute(new categoryOfDepthsDescription { value = value }); }
			get { return base.GetAttributeValue<categoryOfDepthsDescription>(nameof(categoryOfDepthsDescription))?.value; }
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
					attribute = nameof(categoryOfDepthsDescription),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfDepthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Textual description of the layout of port facilities.
	/// </summary>
	public class facilitiesLayoutDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(facilitiesLayoutDescription);
		[JsonIgnore]
		public override string S100FC_name => "Facilities Layout Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// General, introductory information about the port.
	/// </summary>
	public class generalPortDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(generalPortDescription);
		[JsonIgnore]
		public override string S100FC_name => "General Port Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
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
	/// Textual description of selected landmarks that have significance in an area.
	/// </summary>
	public class landmarkDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(landmarkDescription);
		[JsonIgnore]
		public override string S100FC_name => "Landmark Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Description of the area covered by the information specified.
	/// </summary>
	public class limitsDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(limitsDescription);
		[JsonIgnore]
		public override string S100FC_name => "Limits Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A description of navigationally significant lights essential for marking landfalls, offshore dangers, shipping routes, port access channels or protection of the marine environment.
	/// </summary>
	public class majorLightDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(majorLightDescription);
		[JsonIgnore]
		public override string S100FC_name => "Major Light Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Description of the aids to navigation used to mark an area or object.
	/// </summary>
	public class markedBy : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(markedBy);
		[JsonIgnore]
		public override string S100FC_name => "Marked By";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Description of aids to navigation or prominent marks located away from the shore.
	/// </summary>
	public class offshoreMarkDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(offshoreMarkDescription);
		[JsonIgnore]
		public override string S100FC_name => "Offshore Mark Description";

		#region Attributes
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
					attribute = nameof(textContent),
					lower = 1,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new textContent(),
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
		[JsonIgnore]
		public verticalUncertainty? verticalUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<verticalUncertainty>(nameof(verticalUncertainty)); }
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
				new attributeBindingDefinition {
					attribute = nameof(verticalUncertainty),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new verticalUncertainty(),
				},
			];

		#endregion
	}

	/// <summary>
	/// General information about the port or harbour area.
	/// </summary>
	public class generalHarbourInformation : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(generalHarbourInformation);
		[JsonIgnore]
		public override string S100FC_name => "General Harbour Information";

		#region Attributes
		[JsonIgnore]
		public generalPortDescription? generalPortDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<generalPortDescription>(nameof(generalPortDescription)); }
		}
		[JsonIgnore]
		public facilitiesLayoutDescription? facilitiesLayoutDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<facilitiesLayoutDescription>(nameof(facilitiesLayoutDescription)); }
		}
		[JsonIgnore]
		public limitsDescription? limitsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<limitsDescription>(nameof(limitsDescription)); }
		}
		[JsonIgnore]
		public constructionInformation?[] constructionInformation {
			set { base.SetAttribute("constructionInformation", value); }
			get { return base.GetAttributeValues<constructionInformation>(nameof(constructionInformation)); }
		}
		[JsonIgnore]
		public cargoServicesDescription? cargoServicesDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<cargoServicesDescription>(nameof(cargoServicesDescription)); }
		}
		[JsonIgnore]
		public weatherResource?[] weatherResource {
			set { base.SetAttribute("weatherResource", value); }
			get { return base.GetAttributeValues<weatherResource>(nameof(weatherResource)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(generalPortDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new generalPortDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(facilitiesLayoutDescription),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new facilitiesLayoutDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(limitsDescription),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new limitsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(constructionInformation),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new constructionInformation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(cargoServicesDescription),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new cargoServicesDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(weatherResource),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new weatherResource(),
				},
			];

		#endregion
	}

}

namespace S100FC.S131.InformationAssociation
{
	using S100FC.S131.SimpleAttributes;
	using S100FC.S131.ComplexAttributes;

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
	/// Contact details for a service or facility
	/// </summary>
	public class ServiceContact : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ServiceContact);
		[JsonIgnore]
		public override string S100FC_name => "Service contact";
		public static string role => "theContactDetails";

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
		public override string S100FC_name => "Location hours";
		public static string role => "facilityOperatingHours";

		#region Catalogue
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
	/// Association between a limit feature and the entrance for the limit.
	/// </summary>
	public class LimitEntrance : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LimitEntrance);
		[JsonIgnore]
		public override string S100FC_name => "Limit Entrance";
		public static string role => "entranceReference";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// The services available within a location.
	/// </summary>
	public class ServiceAvailability : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ServiceAvailability);
		[JsonIgnore]
		public override string S100FC_name => "Service Availability";
		public static string role => "serviceDescriptionReference";

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S131.FeatureAssociation
{
	using S100FC.S131.SimpleAttributes;
	using S100FC.S131.ComplexAttributes;

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
	/// A division of a feature into parts of the same type as the whole.
	/// </summary>
	public class Subsection : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Subsection);
		[JsonIgnore]
		public override string S100FC_name => "Subsection";
		public static string[] roles => ["subUnit","constitute"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// The infrastructure facilities in an area.
	/// </summary>
	public class Infrastructure : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Infrastructure);
		[JsonIgnore]
		public override string S100FC_name => "Infrastructure";
		public static string[] roles => ["infrastructureLocation","hasInfrastructure"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Describes the relationship between a primary feature and a feature that plays a supporting role in the use of the primary facility by a vessel.
	/// </summary>
	public class PrimaryAuxiliaryFacility : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PrimaryAuxiliaryFacility);
		[JsonIgnore]
		public override string S100FC_name => "Primary/Auxiliary Facility";
		public static string[] roles => ["primaryFacility","auxiliaryFacility"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Demarcation of location(s) within a feature by relation to another feature or features
	/// </summary>
	public class Demarcation : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Demarcation);
		[JsonIgnore]
		public override string S100FC_name => "Demarcation";
		public static string[] roles => ["demarcationIndicator","demarcatedFeature"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// The limit(s) of a jurisdiction claimed by a coastal State.
	/// </summary>
	public class JurisdictionalLimit : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(JurisdictionalLimit);
		[JsonIgnore]
		public override string S100FC_name => "Jurisdictional Limit";
		public static string[] roles => ["limitReference","limitExtent"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// A division of a feature into parts of type(s) different from the type of the whole.
	/// </summary>
	public class LayoutDivision : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LayoutDivision);
		[JsonIgnore]
		public override string S100FC_name => "Layout Division";
		public static string[] roles => ["layoutUnit","componentOf"];

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S131.InformationTypes
{
	using S100FC.S131.SimpleAttributes;
	using S100FC.S131.ComplexAttributes;

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
					permitedValues = [2,5,6,7,8,10,11,12,13,14,15],
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
	/// Services that are available for a given port.
	/// </summary>
	public class AvailablePortServices : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AvailablePortServices);
		[JsonIgnore]
		public override string S100FC_name => "Available Port Services";

		#region Attributes
		[JsonIgnore]
		public int?[] firefightingService {
			set { base.SetAttribute("firefightingService", [.. value.Select(e=> new firefightingService { value = e })]); }
			get { return base.GetAttributeValues<firefightingService>(nameof(firefightingService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] medicalService {
			set { base.SetAttribute("medicalService", [.. value.Select(e=> new medicalService { value = e })]); }
			get { return base.GetAttributeValues<medicalService>(nameof(medicalService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] repairService {
			set { base.SetAttribute("repairService", [.. value.Select(e=> new repairService { value = e })]); }
			get { return base.GetAttributeValues<repairService>(nameof(repairService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] technicalPortService {
			set { base.SetAttribute("technicalPortService", [.. value.Select(e=> new technicalPortService { value = e })]); }
			get { return base.GetAttributeValues<technicalPortService>(nameof(technicalPortService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] shipSanitationControl {
			set { base.SetAttribute("shipSanitationControl", [.. value.Select(e=> new shipSanitationControl { value = e })]); }
			get { return base.GetAttributeValues<shipSanitationControl>(nameof(shipSanitationControl)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] transportConnection {
			set { base.SetAttribute("transportConnection", [.. value.Select(e=> new transportConnection { value = e })]); }
			get { return base.GetAttributeValues<transportConnection>(nameof(transportConnection)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] berthingAssistance {
			set { base.SetAttribute("berthingAssistance", [.. value.Select(e=> new berthingAssistance { value = e })]); }
			get { return base.GetAttributeValues<berthingAssistance>(nameof(berthingAssistance)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] cargoService {
			set { base.SetAttribute("cargoService", [.. value.Select(e=> new cargoService { value = e })]); }
			get { return base.GetAttributeValues<cargoService>(nameof(cargoService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] securitySafetyEmergencyService {
			set { base.SetAttribute("securitySafetyEmergencyService", [.. value.Select(e=> new securitySafetyEmergencyService { value = e })]); }
			get { return base.GetAttributeValues<securitySafetyEmergencyService>(nameof(securitySafetyEmergencyService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] wasteDisposalService {
			set { base.SetAttribute("wasteDisposalService", [.. value.Select(e=> new wasteDisposalService { value = e })]); }
			get { return base.GetAttributeValues<wasteDisposalService>(nameof(wasteDisposalService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] supplyService {
			set { base.SetAttribute("supplyService", [.. value.Select(e=> new supplyService { value = e })]); }
			get { return base.GetAttributeValues<supplyService>(nameof(supplyService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? tugInformation {
			set { base.SetAttribute(new tugInformation { value = value }); }
			get { return base.GetAttributeValue<tugInformation>(nameof(tugInformation))?.value; }
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
					attribute = nameof(firefightingService),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new firefightingService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(medicalService),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5],
					CreateInstance = () => new medicalService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(repairService),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,10],
					CreateInstance = () => new repairService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(technicalPortService),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new technicalPortService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(shipSanitationControl),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [1,2,3],
					CreateInstance = () => new shipSanitationControl(),
				},
				new attributeBindingDefinition {
					attribute = nameof(transportConnection),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [2,3,4,5,6,8,9,11,12,13],
					CreateInstance = () => new transportConnection(),
				},
				new attributeBindingDefinition {
					attribute = nameof(berthingAssistance),
					lower = 0,
					upper = 2147483647,
					order = 6,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new berthingAssistance(),
				},
				new attributeBindingDefinition {
					attribute = nameof(cargoService),
					lower = 0,
					upper = 2147483647,
					order = 7,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new cargoService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(securitySafetyEmergencyService),
					lower = 0,
					upper = 2147483647,
					order = 8,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new securitySafetyEmergencyService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(wasteDisposalService),
					lower = 0,
					upper = 2147483647,
					order = 9,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24],
					CreateInstance = () => new wasteDisposalService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(supplyService),
					lower = 0,
					upper = 2147483647,
					order = 10,
					permitedValues = [1,2,3,4,5,6,7,8,9,10],
					CreateInstance = () => new supplyService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(tugInformation),
					lower = 0,
					upper = 1,
					order = 11,
					CreateInstance = () => new tugInformation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					order = 12,
					CreateInstance = () => new textContent(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AvailablePortServices.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

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
	/// The seaward end of a channel, harbour, dock, etc.
	/// </summary>
	public class Entrance : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Entrance);
		[JsonIgnore]
		public override string S100FC_name => "Entrance";

		#region Attributes
		[JsonIgnore]
		public String? entranceDescription {
			set { base.SetAttribute(new entranceDescription { value = value }); }
			get { return base.GetAttributeValue<entranceDescription>(nameof(entranceDescription))?.value; }
		}
		[JsonIgnore]
		public String?[] associatedFeatureName {
			set { base.SetAttribute("associatedFeatureName", [.. value.Select(e=> new associatedFeatureName { value = e })]); }
			get { return base.GetAttributeValues<associatedFeatureName>(nameof(associatedFeatureName)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? localKnowledgeDescription {
			set { base.SetAttribute(new localKnowledgeDescription { value = value }); }
			get { return base.GetAttributeValue<localKnowledgeDescription>(nameof(localKnowledgeDescription))?.value; }
		}
		[JsonIgnore]
		public String? approachDescription {
			set { base.SetAttribute(new approachDescription { value = value }); }
			get { return base.GetAttributeValue<approachDescription>(nameof(approachDescription))?.value; }
		}
		[JsonIgnore]
		public markedBy?[] markedBy {
			set { base.SetAttribute("markedBy", value); }
			get { return base.GetAttributeValues<markedBy>(nameof(markedBy)); }
		}
		[JsonIgnore]
		public landmarkDescription?[] landmarkDescription {
			set { base.SetAttribute("landmarkDescription", value); }
			get { return base.GetAttributeValues<landmarkDescription>(nameof(landmarkDescription)); }
		}
		[JsonIgnore]
		public offshoreMarkDescription?[] offshoreMarkDescription {
			set { base.SetAttribute("offshoreMarkDescription", value); }
			get { return base.GetAttributeValues<offshoreMarkDescription>(nameof(offshoreMarkDescription)); }
		}
		[JsonIgnore]
		public majorLightDescription?[] majorLightDescription {
			set { base.SetAttribute("majorLightDescription", value); }
			get { return base.GetAttributeValues<majorLightDescription>(nameof(majorLightDescription)); }
		}
		[JsonIgnore]
		public usefulMarkDescription?[] usefulMarkDescription {
			set { base.SetAttribute("usefulMarkDescription", value); }
			get { return base.GetAttributeValues<usefulMarkDescription>(nameof(usefulMarkDescription)); }
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
					attribute = nameof(entranceDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new entranceDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(associatedFeatureName),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new associatedFeatureName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(localKnowledgeDescription),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new localKnowledgeDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(approachDescription),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new approachDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(landmarkDescription),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new landmarkDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(offshoreMarkDescription),
					lower = 0,
					upper = 2147483647,
					order = 6,
					CreateInstance = () => new offshoreMarkDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(majorLightDescription),
					lower = 0,
					upper = 2147483647,
					order = 7,
					CreateInstance = () => new majorLightDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(usefulMarkDescription),
					lower = 0,
					upper = 2147483647,
					order = 8,
					CreateInstance = () => new usefulMarkDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					order = 9,
					CreateInstance = () => new textContent(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Entrance.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

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

namespace S100FC.S131.FeatureTypes
{
	using S100FC.S131.SimpleAttributes;
	using S100FC.S131.ComplexAttributes;
	using S100FC.S131.InformationTypes;

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
		public String? locationMRN {
			set { base.SetAttribute(new locationMRN { value = value }); }
			get { return base.GetAttributeValue<locationMRN>(nameof(locationMRN))?.value; }
		}
		[JsonIgnore]
		public String? globalLocationNumber {
			set { base.SetAttribute(new globalLocationNumber { value = value }); }
			get { return base.GetAttributeValue<globalLocationNumber>(nameof(globalLocationNumber))?.value; }
		}
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
		public rxNCode?[] rxNCode {
			set { base.SetAttribute("rxNCode", value); }
			get { return base.GetAttributeValues<rxNCode>(nameof(rxNCode)); }
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
					attribute = nameof(locationMRN),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new locationMRN(),
				},
				new attributeBindingDefinition {
					attribute = nameof(globalLocationNumber),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new globalLocationNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new featureName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new periodicDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(rxNCode),
					lower = 0,
					upper = 2147483647,
					order = 6,
					CreateInstance = () => new rxNCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(graphic),
					lower = 0,
					upper = 2147483647,
					order = 7,
					CreateInstance = () => new graphic(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					order = 8,
					CreateInstance = () => new sourceIndication(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					order = 9,
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
	/// The physical installations and facilities that support operations in a port or harbour.
	/// </summary>
	public abstract class HarbourPhysicalInfrastructure : SupervisedArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(HarbourPhysicalInfrastructure);
		[JsonIgnore]
		public override string S100FC_name => "Harbour Physical Infrastructure";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => HarbourPhysicalInfrastructure.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => HarbourPhysicalInfrastructure.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. SupervisedArea.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "infrastructureLocation",
					association = "Infrastructure",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection),nameof(Terminal)],
					CreateInstance = () => new featureBinding<FeatureAssociation.Infrastructure>() {
						roleType = "association",
						role = "infrastructureLocation",
					},
				},
			];

		public static featureBinding<FeatureAssociation.Infrastructure> Infrastructure(string role) => new featureBinding<FeatureAssociation.Infrastructure> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("Infrastructure") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// The spatial arrangement of areas and other types of locations that are designated for specified purposes or otherwise distinguished from other areas and locations.
	/// </summary>
	public abstract class Layout : SupervisedArea
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Layout);
		[JsonIgnore]
		public override string S100FC_name => "Layout";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Layout.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Layout.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// A designated area of water where a vessel, sea plane, etc., may anchor.
	/// </summary>
	public class AnchorBerth : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AnchorBerth);
		[JsonIgnore]
		public override string S100FC_name => "Anchor Berth";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfAnchorage {
			set { base.SetAttribute("categoryOfAnchorage", [.. value.Select(e=> new categoryOfAnchorage { value = e })]); }
			get { return base.GetAttributeValues<categoryOfAnchorage>(nameof(categoryOfAnchorage)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfCargo {
			set { base.SetAttribute("categoryOfCargo", [.. value.Select(e=> new categoryOfCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfCargo>(nameof(categoryOfCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? radius {
			set { base.SetAttribute(new radius { value = value }); }
			get { return base.GetAttributeValue<radius>(nameof(radius))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfAnchorage),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,5,6,7,9,10,14],
					CreateInstance = () => new categoryOfAnchorage(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfCargo(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radius),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new radius(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AnchorBerth.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "serviceDescriptionReference",
					association = "ServiceAvailability",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AvailablePortServices)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceAvailability>() {
						roleType = "association",
						role = "serviceDescriptionReference",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceAvailability> ServiceAvailability => new informationBinding<InformationAssociation.ServiceAvailability> {
			roleType = "association",
			role = "serviceDescriptionReference",
		};
		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => AnchorBerth.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "auxiliaryFacility",
					association = "PrimaryAuxiliaryFacility",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(MooringWarpingFacility)],
					CreateInstance = () => new featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility>() {
						roleType = "association",
						role = "auxiliaryFacility",
					},
				},
			];

		public static featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility> PrimaryAuxiliaryFacility(string role) => new featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("PrimaryAuxiliaryFacility") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// An area in which vessels or seaplanes anchor or may anchor.
	/// </summary>
	public class AnchorageArea : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AnchorageArea);
		[JsonIgnore]
		public override string S100FC_name => "Anchorage Area";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfAnchorage {
			set { base.SetAttribute("categoryOfAnchorage", [.. value.Select(e=> new categoryOfAnchorage { value = e })]); }
			get { return base.GetAttributeValues<categoryOfAnchorage>(nameof(categoryOfAnchorage)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? iSPSLevel {
			set { base.SetAttribute(new iSPSLevel { value = value }); }
			get { return base.GetAttributeValue<iSPSLevel>(nameof(iSPSLevel))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfCargo {
			set { base.SetAttribute("categoryOfCargo", [.. value.Select(e=> new categoryOfCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfCargo>(nameof(categoryOfCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfAnchorage),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,5,6,7,9,10,14,15],
					CreateInstance = () => new categoryOfAnchorage(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfCargo(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new markedBy(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AnchorageArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => AnchorageArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// Equipment with material handling or operational capabilities, characterised by wheeled (including tracked) mobility, and which autonomously moves along a preset route based on environmental markers or external guidance signals.
	/// </summary>
	public class AutomatedGuidedVehicle : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AutomatedGuidedVehicle);
		[JsonIgnore]
		public override string S100FC_name => "Automated Guided Vehicle";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AutomatedGuidedVehicle.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => AutomatedGuidedVehicle.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.curve,Primitives.surface];
	}

	/// <summary>
	/// A place, generally named or numbered, where a vessel may moor or anchor.
	/// </summary>
	public class Berth : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Berth);
		[JsonIgnore]
		public override string S100FC_name => "Berth";

		#region Attributes
		[JsonIgnore]
		public decimal? availableBerthingLength {
			set { base.SetAttribute(new availableBerthingLength { value = value }); }
			get { return base.GetAttributeValue<availableBerthingLength>(nameof(availableBerthingLength))?.value; }
		}
		[JsonIgnore]
		public String? bollardDescription {
			set { base.SetAttribute(new bollardDescription { value = value }); }
			get { return base.GetAttributeValue<bollardDescription>(nameof(bollardDescription))?.value; }
		}
		[JsonIgnore]
		public decimal? safeWorkingLoad {
			set { base.SetAttribute(new safeWorkingLoad { value = value }); }
			get { return base.GetAttributeValue<safeWorkingLoad>(nameof(safeWorkingLoad))?.value; }
		}
		[JsonIgnore]
		public decimal? minimumBerthDepth {
			set { base.SetAttribute(new minimumBerthDepth { value = value }); }
			get { return base.GetAttributeValue<minimumBerthDepth>(nameof(minimumBerthDepth))?.value; }
		}
		[JsonIgnore]
		public decimal? elevation {
			set { base.SetAttribute(new elevation { value = value }); }
			get { return base.GetAttributeValue<elevation>(nameof(elevation))?.value; }
		}
		[JsonIgnore]
		public Boolean? cathodicProtectionSystem {
			set { base.SetAttribute(new cathodicProtectionSystem { value = value }); }
			get { return base.GetAttributeValue<cathodicProtectionSystem>(nameof(cathodicProtectionSystem))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfBerthLocation {
			set { base.SetAttribute(new categoryOfBerthLocation { value = value }); }
			get { return base.GetAttributeValue<categoryOfBerthLocation>(nameof(categoryOfBerthLocation))?.value; }
		}
		[JsonIgnore]
		public String? portFacilityNumber {
			set { base.SetAttribute(new portFacilityNumber { value = value }); }
			get { return base.GetAttributeValue<portFacilityNumber>(nameof(portFacilityNumber))?.value; }
		}
		[JsonIgnore]
		public String?[] bollardNumber {
			set { base.SetAttribute("bollardNumber", [.. value.Select(e=> new bollardNumber { value = e })]); }
			get { return base.GetAttributeValues<bollardNumber>(nameof(bollardNumber)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? gLNExtension {
			set { base.SetAttribute(new gLNExtension { value = value }); }
			get { return base.GetAttributeValue<gLNExtension>(nameof(gLNExtension))?.value; }
		}
		[JsonIgnore]
		public String?[] metreMarkNumber {
			set { base.SetAttribute("metreMarkNumber", [.. value.Select(e=> new metreMarkNumber { value = e })]); }
			get { return base.GetAttributeValues<metreMarkNumber>(nameof(metreMarkNumber)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] manifoldNumber {
			set { base.SetAttribute("manifoldNumber", [.. value.Select(e=> new manifoldNumber { value = e })]); }
			get { return base.GetAttributeValues<manifoldNumber>(nameof(manifoldNumber)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? rampNumber {
			set { base.SetAttribute(new rampNumber { value = value }); }
			get { return base.GetAttributeValue<rampNumber>(nameof(rampNumber))?.value; }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public int? methodOfSecuring {
			set { base.SetAttribute(new methodOfSecuring { value = value }); }
			get { return base.GetAttributeValue<methodOfSecuring>(nameof(methodOfSecuring))?.value; }
		}
		[JsonIgnore]
		public String? uNLocationCode {
			set { base.SetAttribute(new uNLocationCode { value = value }); }
			get { return base.GetAttributeValue<uNLocationCode>(nameof(uNLocationCode))?.value; }
		}
		[JsonIgnore]
		public String? terminalIdentifier {
			set { base.SetAttribute(new terminalIdentifier { value = value }); }
			get { return base.GetAttributeValue<terminalIdentifier>(nameof(terminalIdentifier))?.value; }
		}
		[JsonIgnore]
		public String? shorePowerDescription {
			set { base.SetAttribute(new shorePowerDescription { value = value }); }
			get { return base.GetAttributeValue<shorePowerDescription>(nameof(shorePowerDescription))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfFrequency {
			set { base.SetAttribute("categoryOfFrequency", [.. value.Select(e=> new categoryOfFrequency { value = e })]); }
			get { return base.GetAttributeValues<categoryOfFrequency>(nameof(categoryOfFrequency)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfVoltage {
			set { base.SetAttribute("categoryOfVoltage", [.. value.Select(e=> new categoryOfVoltage { value = e })]); }
			get { return base.GetAttributeValues<categoryOfVoltage>(nameof(categoryOfVoltage)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] categoryOfPlug {
			set { base.SetAttribute("categoryOfPlug", [.. value.Select(e=> new categoryOfPlug { value = e })]); }
			get { return base.GetAttributeValues<categoryOfPlug>(nameof(categoryOfPlug)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfCargo {
			set { base.SetAttribute("categoryOfCargo", [.. value.Select(e=> new categoryOfCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfCargo>(nameof(categoryOfCargo)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(availableBerthingLength),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new availableBerthingLength(),
				},
				new attributeBindingDefinition {
					attribute = nameof(bollardDescription),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new bollardDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(safeWorkingLoad),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new safeWorkingLoad(),
				},
				new attributeBindingDefinition {
					attribute = nameof(minimumBerthDepth),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new minimumBerthDepth(),
				},
				new attributeBindingDefinition {
					attribute = nameof(elevation),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new elevation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(cathodicProtectionSystem),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new cathodicProtectionSystem(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfBerthLocation),
					lower = 0,
					upper = 1,
					order = 6,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfBerthLocation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(portFacilityNumber),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new portFacilityNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(bollardNumber),
					lower = 0,
					upper = 2,
					order = 8,
					CreateInstance = () => new bollardNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(gLNExtension),
					lower = 0,
					upper = 1,
					order = 9,
					CreateInstance = () => new gLNExtension(),
				},
				new attributeBindingDefinition {
					attribute = nameof(metreMarkNumber),
					lower = 0,
					upper = 2,
					order = 10,
					CreateInstance = () => new metreMarkNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(manifoldNumber),
					lower = 0,
					upper = 2,
					order = 11,
					CreateInstance = () => new manifoldNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(rampNumber),
					lower = 0,
					upper = 1,
					order = 12,
					CreateInstance = () => new rampNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 13,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(methodOfSecuring),
					lower = 0,
					upper = 1,
					order = 14,
					permitedValues = [1,2,3,4,5,6,7,8,9,10],
					CreateInstance = () => new methodOfSecuring(),
				},
				new attributeBindingDefinition {
					attribute = nameof(uNLocationCode),
					lower = 1,
					upper = 1,
					order = 15,
					CreateInstance = () => new uNLocationCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(terminalIdentifier),
					lower = 0,
					upper = 1,
					order = 16,
					CreateInstance = () => new terminalIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(shorePowerDescription),
					lower = 0,
					upper = 1,
					order = 17,
					CreateInstance = () => new shorePowerDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfFrequency),
					lower = 0,
					upper = 2147483647,
					order = 18,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfFrequency(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfVoltage),
					lower = 0,
					upper = 2147483647,
					order = 19,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfVoltage(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPlug),
					lower = 0,
					upper = 2147483647,
					order = 20,
					CreateInstance = () => new categoryOfPlug(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					order = 21,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfCargo(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Berth.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "serviceDescriptionReference",
					association = "ServiceAvailability",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AvailablePortServices)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceAvailability>() {
						roleType = "association",
						role = "serviceDescriptionReference",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceAvailability> ServiceAvailability => new informationBinding<InformationAssociation.ServiceAvailability> {
			roleType = "association",
			role = "serviceDescriptionReference",
		};
		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Berth.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "demarcationIndicator",
					association = "Demarcation",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(BerthPosition)],
					CreateInstance = () => new featureBinding<FeatureAssociation.Demarcation>() {
						roleType = "association",
						role = "demarcationIndicator",
					},
				},
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection),nameof(Terminal)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.Demarcation> Demarcation(string role) => new featureBinding<FeatureAssociation.Demarcation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("Demarcation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.curve,Primitives.surface];
	}

	/// <summary>
	/// A specific position within a berth where a vessel may be moored or anchored.
	/// </summary>
	public class BerthPosition : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(BerthPosition);
		[JsonIgnore]
		public override string S100FC_name => "Berth Position";

		#region Attributes
		[JsonIgnore]
		public String? bollardNumber {
			set { base.SetAttribute(new bollardNumber { value = value }); }
			get { return base.GetAttributeValue<bollardNumber>(nameof(bollardNumber))?.value; }
		}
		[JsonIgnore]
		public String? gLNExtension {
			set { base.SetAttribute(new gLNExtension { value = value }); }
			get { return base.GetAttributeValue<gLNExtension>(nameof(gLNExtension))?.value; }
		}
		[JsonIgnore]
		public String? metreMarkNumber {
			set { base.SetAttribute(new metreMarkNumber { value = value }); }
			get { return base.GetAttributeValue<metreMarkNumber>(nameof(metreMarkNumber))?.value; }
		}
		[JsonIgnore]
		public String? manifoldNumber {
			set { base.SetAttribute(new manifoldNumber { value = value }); }
			get { return base.GetAttributeValue<manifoldNumber>(nameof(manifoldNumber))?.value; }
		}
		[JsonIgnore]
		public String? rampNumber {
			set { base.SetAttribute(new rampNumber { value = value }); }
			get { return base.GetAttributeValue<rampNumber>(nameof(rampNumber))?.value; }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(bollardNumber),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new bollardNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(gLNExtension),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new gLNExtension(),
				},
				new attributeBindingDefinition {
					attribute = nameof(metreMarkNumber),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new metreMarkNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(manifoldNumber),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new manifoldNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(rampNumber),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new rampNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new locationByText(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => BerthPosition.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => BerthPosition.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "composition",
					role = "demarcatedFeature",
					association = "Demarcation",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(Berth)],
					CreateInstance = () => new featureBinding<FeatureAssociation.Demarcation>() {
						roleType = "composition",
						role = "demarcatedFeature",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "auxiliaryFacility",
					association = "PrimaryAuxiliaryFacility",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(MooringWarpingFacility)],
					CreateInstance = () => new featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility>() {
						roleType = "association",
						role = "auxiliaryFacility",
					},
				},
			];

		public static featureBinding<FeatureAssociation.Demarcation> Demarcation(string role) => new featureBinding<FeatureAssociation.Demarcation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("Demarcation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility> PrimaryAuxiliaryFacility(string role) => new featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("PrimaryAuxiliaryFacility") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// Small shaped post, mounted on a wharf or dolphin used to secure ship's lines.
	/// </summary>
	public class Bollard : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Bollard);
		[JsonIgnore]
		public override string S100FC_name => "Bollard";

		#region Attributes
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		[JsonIgnore]
		public decimal? verticalLength {
			set { base.SetAttribute(new verticalLength { value = value }); }
			get { return base.GetAttributeValue<verticalLength>(nameof(verticalLength))?.value; }
		}
		[JsonIgnore]
		public decimal? safeWorkingLoad {
			set { base.SetAttribute(new safeWorkingLoad { value = value }); }
			get { return base.GetAttributeValue<safeWorkingLoad>(nameof(safeWorkingLoad))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new height(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalLength),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new verticalLength(),
				},
				new attributeBindingDefinition {
					attribute = nameof(safeWorkingLoad),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new safeWorkingLoad(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Bollard.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Bollard.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An artificially enclosed area within which ships may moor and which may have gates to regulate water level.
	/// </summary>
	public class DockArea : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DockArea);
		[JsonIgnore]
		public override string S100FC_name => "Dock Area";

		#region Attributes
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
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
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => DockArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "serviceDescriptionReference",
					association = "ServiceAvailability",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AvailablePortServices)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceAvailability>() {
						roleType = "association",
						role = "serviceDescriptionReference",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceAvailability> ServiceAvailability => new informationBinding<InformationAssociation.ServiceAvailability> {
			roleType = "association",
			role = "serviceDescriptionReference",
		};
		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => DockArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An artificial basin fitted with a gate or caisson, into which vessels can be floated and the water pumped out to expose the vessel's bottom. Also called graving dock.
	/// </summary>
	public class DryDock : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DryDock);
		[JsonIgnore]
		public override string S100FC_name => "Dry Dock";

		#region Attributes
		[JsonIgnore]
		public decimal? sillDepth {
			set { base.SetAttribute(new sillDepth { value = value }); }
			get { return base.GetAttributeValue<sillDepth>(nameof(sillDepth))?.value; }
		}
		[JsonIgnore]
		public decimal? verticalClearanceValue {
			set { base.SetAttribute(new verticalClearanceValue { value = value }); }
			get { return base.GetAttributeValue<verticalClearanceValue>(nameof(verticalClearanceValue))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(sillDepth),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new sillDepth(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalClearanceValue),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new verticalClearanceValue(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => DryDock.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => DryDock.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.
	/// </summary>
	public class Dolphin : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Dolphin);
		[JsonIgnore]
		public override string S100FC_name => "Dolphin";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfDolphin {
			set { base.SetAttribute("categoryOfDolphin", [.. value.Select(e=> new categoryOfDolphin { value = e })]); }
			get { return base.GetAttributeValues<categoryOfDolphin>(nameof(categoryOfDolphin)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfDolphin),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfDolphin(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Dolphin.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Dolphin.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.
	/// </summary>
	public class DumpingGround : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DumpingGround);
		[JsonIgnore]
		public override string S100FC_name => "Dumping Ground";

		#region Attributes
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
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
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => DumpingGround.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => DumpingGround.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface,Primitives.point];
	}

	/// <summary>
	/// An imaginary line parallel to a face of a berth or quay which touches the seaward face of the fenders.
	/// </summary>
	public class FenderLine : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(FenderLine);
		[JsonIgnore]
		public override string S100FC_name => "Fender Line";

		#region Attributes
		[JsonIgnore]
		public orientation? orientation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<orientation>(nameof(orientation)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(orientation),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new orientation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => FenderLine.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => FenderLine.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.curve];
	}

	/// <summary>
	/// A form of dry dock consisting of a floating structure of one or more sections which can be partly submerged by controlled flooding to receive a vessel, then raised by pumping out the water so that the vessel's bottom can be exposed.
	/// </summary>
	public class FloatingDock : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(FloatingDock);
		[JsonIgnore]
		public override string S100FC_name => "Floating Dock";

		#region Attributes
		[JsonIgnore]
		public decimal? sillDepth {
			set { base.SetAttribute(new sillDepth { value = value }); }
			get { return base.GetAttributeValue<sillDepth>(nameof(sillDepth))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(sillDepth),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new sillDepth(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => FloatingDock.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => FloatingDock.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A structure in the intertidal zone serving as a support for vessels at low stages of the tide to permit work on the exposed portion of the vessel's hull.
	/// </summary>
	public class Gridiron : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Gridiron);
		[JsonIgnore]
		public override string S100FC_name => "Gridiron";

		#region Attributes
		[JsonIgnore]
		public decimal? sillDepth {
			set { base.SetAttribute(new sillDepth { value = value }); }
			get { return base.GetAttributeValue<sillDepth>(nameof(sillDepth))?.value; }
		}
		[JsonIgnore]
		public decimal? verticalClearanceValue {
			set { base.SetAttribute(new verticalClearanceValue { value = value }); }
			get { return base.GetAttributeValue<verticalClearanceValue>(nameof(verticalClearanceValue))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(sillDepth),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new sillDepth(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalClearanceValue),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new verticalClearanceValue(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Gridiron.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Gridiron.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// The area over which a harbour authority has jurisdiction.
	/// </summary>
	public class HarbourAreaAdministrative : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(HarbourAreaAdministrative);
		[JsonIgnore]
		public override string S100FC_name => "Harbour Area (Administrative)";

		#region Attributes
		[JsonIgnore]
		public String? uNLocationCode {
			set { base.SetAttribute(new uNLocationCode { value = value }); }
			get { return base.GetAttributeValue<uNLocationCode>(nameof(uNLocationCode))?.value; }
		}
		[JsonIgnore]
		public String? nationality {
			set { base.SetAttribute(new nationality { value = value }); }
			get { return base.GetAttributeValue<nationality>(nameof(nationality))?.value; }
		}
		[JsonIgnore]
		public String? applicableLoadLineZone {
			set { base.SetAttribute(new applicableLoadLineZone { value = value }); }
			get { return base.GetAttributeValue<applicableLoadLineZone>(nameof(applicableLoadLineZone))?.value; }
		}
		[JsonIgnore]
		public int? iSPSLevel {
			set { base.SetAttribute(new iSPSLevel { value = value }); }
			get { return base.GetAttributeValue<iSPSLevel>(nameof(iSPSLevel))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfHarbourFacility {
			set { base.SetAttribute("categoryOfHarbourFacility", [.. value.Select(e=> new categoryOfHarbourFacility { value = e })]); }
			get { return base.GetAttributeValues<categoryOfHarbourFacility>(nameof(categoryOfHarbourFacility)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public generalHarbourInformation? generalHarbourInformation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<generalHarbourInformation>(nameof(generalHarbourInformation)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(uNLocationCode),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new uNLocationCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(nationality),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new nationality(),
				},
				new attributeBindingDefinition {
					attribute = nameof(applicableLoadLineZone),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new applicableLoadLineZone(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfHarbourFacility),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [1,3,4,5,6,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfHarbourFacility(),
				},
				new attributeBindingDefinition {
					attribute = nameof(generalHarbourInformation),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new generalHarbourInformation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => HarbourAreaAdministrative.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "serviceDescriptionReference",
					association = "ServiceAvailability",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AvailablePortServices)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceAvailability>() {
						roleType = "association",
						role = "serviceDescriptionReference",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceAvailability> ServiceAvailability => new informationBinding<InformationAssociation.ServiceAvailability> {
			roleType = "association",
			role = "serviceDescriptionReference",
		};
		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => HarbourAreaAdministrative.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "limitExtent",
					association = "JurisdictionalLimit",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(OuterLimit)],
					CreateInstance = () => new featureBinding<FeatureAssociation.JurisdictionalLimit>() {
						roleType = "association",
						role = "limitExtent",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "layoutUnit",
					association = "LayoutDivision",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "association",
						role = "layoutUnit",
					},
				},
			];

		public static featureBinding<FeatureAssociation.JurisdictionalLimit> JurisdictionalLimit(string role) => new featureBinding<FeatureAssociation.JurisdictionalLimit> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("JurisdictionalLimit") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A distinguishable portion of the area over which a harbour authority has jurisdiction.
	/// </summary>
	public class HarbourAreaSection : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(HarbourAreaSection);
		[JsonIgnore]
		public override string S100FC_name => "Harbour Area Section";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfPortSection {
			set { base.SetAttribute(new categoryOfPortSection { value = value }); }
			get { return base.GetAttributeValue<categoryOfPortSection>(nameof(categoryOfPortSection))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfHarbourFacility {
			set { base.SetAttribute("categoryOfHarbourFacility", [.. value.Select(e=> new categoryOfHarbourFacility { value = e })]); }
			get { return base.GetAttributeValues<categoryOfHarbourFacility>(nameof(categoryOfHarbourFacility)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? iSPSLevel {
			set { base.SetAttribute(new iSPSLevel { value = value }); }
			get { return base.GetAttributeValue<iSPSLevel>(nameof(iSPSLevel))?.value; }
		}
		[JsonIgnore]
		public facilitiesLayoutDescription? facilitiesLayoutDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<facilitiesLayoutDescription>(nameof(facilitiesLayoutDescription)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPortSection),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,3,8,9,11,12],
					CreateInstance = () => new categoryOfPortSection(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfHarbourFacility),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [4,5,6,9,14,15,16,17],
					CreateInstance = () => new categoryOfHarbourFacility(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
				new attributeBindingDefinition {
					attribute = nameof(facilitiesLayoutDescription),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new facilitiesLayoutDescription(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => HarbourAreaSection.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "serviceDescriptionReference",
					association = "ServiceAvailability",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AvailablePortServices)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceAvailability>() {
						roleType = "association",
						role = "serviceDescriptionReference",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceAvailability> ServiceAvailability => new informationBinding<InformationAssociation.ServiceAvailability> {
			roleType = "association",
			role = "serviceDescriptionReference",
		};
		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => HarbourAreaSection.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(HarbourAreaAdministrative)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "constitute",
					association = "Subsection",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.Subsection>() {
						roleType = "aggregation",
						role = "constitute",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "subUnit",
					association = "Subsection",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.Subsection>() {
						roleType = "association",
						role = "subUnit",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "hasInfrastructure",
					association = "Infrastructure",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(HarbourPhysicalInfrastructure)],
					CreateInstance = () => new featureBinding<FeatureAssociation.Infrastructure>() {
						roleType = "association",
						role = "hasInfrastructure",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "layoutUnit",
					association = "LayoutDivision",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(AnchorageArea),nameof(Berth),nameof(DockArea),nameof(DumpingGround),nameof(FenderLine),nameof(HarbourBasin),nameof(PilotBoardingPlace),nameof(SeaplaneLandingArea),nameof(Terminal),nameof(TurningBasin),nameof(WaterwayArea)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "association",
						role = "layoutUnit",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.Subsection> Subsection(string role) => new featureBinding<FeatureAssociation.Subsection> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("Subsection") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.Infrastructure> Infrastructure(string role) => new featureBinding<FeatureAssociation.Infrastructure> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("Infrastructure") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// An enclosed area of water surrounded by quay walls constructed to provide means for the transfer of cargos from and to ships.
	/// </summary>
	public class HarbourBasin : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(HarbourBasin);
		[JsonIgnore]
		public override string S100FC_name => "Harbour Basin";

		#region Attributes
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
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
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => HarbourBasin.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => HarbourBasin.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// A harbour installation with a service or commercial operation of public interest.
	/// </summary>
	public class HarbourFacility : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(HarbourFacility);
		[JsonIgnore]
		public override string S100FC_name => "Harbour Facility";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => HarbourFacility.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => HarbourFacility.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.curve,Primitives.surface];
	}

	/// <summary>
	/// A wet dock in a waterway, permitting a ship to pass from one level to another.
	/// </summary>
	public class LockBasin : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LockBasin);
		[JsonIgnore]
		public override string S100FC_name => "Lock Basin";

		#region Attributes
		[JsonIgnore]
		public decimal? sillDepth {
			set { base.SetAttribute(new sillDepth { value = value }); }
			get { return base.GetAttributeValue<sillDepth>(nameof(sillDepth))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(sillDepth),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new sillDepth(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LockBasin.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LockBasin.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A lock basin is divided into several lock basin parts, if this lock basin has one ground level but several gates.
	/// </summary>
	public class LockBasinPart : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LockBasinPart);
		[JsonIgnore]
		public override string S100FC_name => "Lock Basin Part";

		#region Attributes
		[JsonIgnore]
		public decimal? sillDepth {
			set { base.SetAttribute(new sillDepth { value = value }); }
			get { return base.GetAttributeValue<sillDepth>(nameof(sillDepth))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(sillDepth),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new sillDepth(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LockBasinPart.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LockBasinPart.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
	/// </summary>
	public class MooringBuoy : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(MooringBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Mooring Buoy";

		#region Attributes
		[JsonIgnore]
		public decimal? maximumPermittedDraught {
			set { base.SetAttribute(new maximumPermittedDraught { value = value }); }
			get { return base.GetAttributeValue<maximumPermittedDraught>(nameof(maximumPermittedDraught))?.value; }
		}
		[JsonIgnore]
		public decimal? maximumPermittedVesselLength {
			set { base.SetAttribute(new maximumPermittedVesselLength { value = value }); }
			get { return base.GetAttributeValue<maximumPermittedVesselLength>(nameof(maximumPermittedVesselLength))?.value; }
		}
		[JsonIgnore]
		public decimal? verticalLength {
			set { base.SetAttribute(new verticalLength { value = value }); }
			get { return base.GetAttributeValue<verticalLength>(nameof(verticalLength))?.value; }
		}
		[JsonIgnore]
		public Boolean? visitorsMooring {
			set { base.SetAttribute(new visitorsMooring { value = value }); }
			get { return base.GetAttributeValue<visitorsMooring>(nameof(visitorsMooring))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(maximumPermittedDraught),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new maximumPermittedDraught(),
				},
				new attributeBindingDefinition {
					attribute = nameof(maximumPermittedVesselLength),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new maximumPermittedVesselLength(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalLength),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new verticalLength(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visitorsMooring),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new visitorsMooring(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => MooringBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => MooringBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// The equipment or structure used to secure a vessel.
	/// </summary>
	public class MooringWarpingFacility : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(MooringWarpingFacility);
		[JsonIgnore]
		public override string S100FC_name => "Mooring/Warping Facility";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfMooringWarpingFacility {
			set { base.SetAttribute(new categoryOfMooringWarpingFacility { value = value }); }
			get { return base.GetAttributeValue<categoryOfMooringWarpingFacility>(nameof(categoryOfMooringWarpingFacility))?.value; }
		}
		[JsonIgnore]
		public String? iDCode {
			set { base.SetAttribute(new iDCode { value = value }); }
			get { return base.GetAttributeValue<iDCode>(nameof(iDCode))?.value; }
		}
		[JsonIgnore]
		public String? bollardDescription {
			set { base.SetAttribute(new bollardDescription { value = value }); }
			get { return base.GetAttributeValue<bollardDescription>(nameof(bollardDescription))?.value; }
		}
		[JsonIgnore]
		public decimal? safeWorkingLoad {
			set { base.SetAttribute(new safeWorkingLoad { value = value }); }
			get { return base.GetAttributeValue<safeWorkingLoad>(nameof(safeWorkingLoad))?.value; }
		}
		[JsonIgnore]
		public Boolean? heavingLinesFromShore {
			set { base.SetAttribute(new heavingLinesFromShore { value = value }); }
			get { return base.GetAttributeValue<heavingLinesFromShore>(nameof(heavingLinesFromShore))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfMooringWarpingFacility),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [4,5,6],
					CreateInstance = () => new categoryOfMooringWarpingFacility(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iDCode),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new iDCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(bollardDescription),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new bollardDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(safeWorkingLoad),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new safeWorkingLoad(),
				},
				new attributeBindingDefinition {
					attribute = nameof(heavingLinesFromShore),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new heavingLinesFromShore(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => MooringWarpingFacility.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "serviceDescriptionReference",
					association = "ServiceAvailability",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AvailablePortServices)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceAvailability>() {
						roleType = "association",
						role = "serviceDescriptionReference",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceAvailability> ServiceAvailability => new informationBinding<InformationAssociation.ServiceAvailability> {
			roleType = "association",
			role = "serviceDescriptionReference",
		};
		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => MooringWarpingFacility.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "primaryFacility",
					association = "PrimaryAuxiliaryFacility",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(AnchorBerth),nameof(BerthPosition)],
					CreateInstance = () => new featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility>() {
						roleType = "association",
						role = "primaryFacility",
					},
				},
			];

		public static featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility> PrimaryAuxiliaryFacility(string role) => new featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("PrimaryAuxiliaryFacility") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// Facilities or infrastructure providing shore power to berthed vessels.
	/// </summary>
	public class OnshorePowerFacility : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(OnshorePowerFacility);
		[JsonIgnore]
		public override string S100FC_name => "Onshore Power Facility";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfShorePowerFacility {
			set { base.SetAttribute(new categoryOfShorePowerFacility { value = value }); }
			get { return base.GetAttributeValue<categoryOfShorePowerFacility>(nameof(categoryOfShorePowerFacility))?.value; }
		}
		[JsonIgnore]
		public String? iDCode {
			set { base.SetAttribute(new iDCode { value = value }); }
			get { return base.GetAttributeValue<iDCode>(nameof(iDCode))?.value; }
		}
		[JsonIgnore]
		public String? shorePowerDescription {
			set { base.SetAttribute(new shorePowerDescription { value = value }); }
			get { return base.GetAttributeValue<shorePowerDescription>(nameof(shorePowerDescription))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfVoltage {
			set { base.SetAttribute("categoryOfVoltage", [.. value.Select(e=> new categoryOfVoltage { value = e })]); }
			get { return base.GetAttributeValues<categoryOfVoltage>(nameof(categoryOfVoltage)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfFrequency {
			set { base.SetAttribute("categoryOfFrequency", [.. value.Select(e=> new categoryOfFrequency { value = e })]); }
			get { return base.GetAttributeValues<categoryOfFrequency>(nameof(categoryOfFrequency)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] categoryOfPlug {
			set { base.SetAttribute("categoryOfPlug", [.. value.Select(e=> new categoryOfPlug { value = e })]); }
			get { return base.GetAttributeValues<categoryOfPlug>(nameof(categoryOfPlug)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? shorePowerServiceProvider {
			set { base.SetAttribute(new shorePowerServiceProvider { value = value }); }
			get { return base.GetAttributeValue<shorePowerServiceProvider>(nameof(shorePowerServiceProvider))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfShorePowerFacility),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfShorePowerFacility(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iDCode),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new iDCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(shorePowerDescription),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new shorePowerDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfVoltage),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfVoltage(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfFrequency),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfFrequency(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPlug),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new categoryOfPlug(),
				},
				new attributeBindingDefinition {
					attribute = nameof(shorePowerServiceProvider),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new shorePowerServiceProvider(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => OnshorePowerFacility.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => OnshorePowerFacility.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// The extent to which a coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.
	/// </summary>
	public class OuterLimit : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(OuterLimit);
		[JsonIgnore]
		public override string S100FC_name => "Outer Limit";

		#region Attributes
		[JsonIgnore]
		public limitsDescription? limitsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<limitsDescription>(nameof(limitsDescription)); }
		}
		[JsonIgnore]
		public markedBy?[] markedBy {
			set { base.SetAttribute("markedBy", value); }
			get { return base.GetAttributeValues<markedBy>(nameof(markedBy)); }
		}
		[JsonIgnore]
		public landmarkDescription?[] landmarkDescription {
			set { base.SetAttribute("landmarkDescription", value); }
			get { return base.GetAttributeValues<landmarkDescription>(nameof(landmarkDescription)); }
		}
		[JsonIgnore]
		public offshoreMarkDescription?[] offshoreMarkDescription {
			set { base.SetAttribute("offshoreMarkDescription", value); }
			get { return base.GetAttributeValues<offshoreMarkDescription>(nameof(offshoreMarkDescription)); }
		}
		[JsonIgnore]
		public majorLightDescription?[] majorLightDescription {
			set { base.SetAttribute("majorLightDescription", value); }
			get { return base.GetAttributeValues<majorLightDescription>(nameof(majorLightDescription)); }
		}
		[JsonIgnore]
		public usefulMarkDescription?[] usefulMarkDescription {
			set { base.SetAttribute("usefulMarkDescription", value); }
			get { return base.GetAttributeValues<usefulMarkDescription>(nameof(usefulMarkDescription)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(limitsDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new limitsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(landmarkDescription),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new landmarkDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(offshoreMarkDescription),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new offshoreMarkDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(majorLightDescription),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new majorLightDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(usefulMarkDescription),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new usefulMarkDescription(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => OuterLimit.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "entranceReference",
					association = "LimitEntrance",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(Entrance)],
					CreateInstance = () => new informationBinding<InformationAssociation.LimitEntrance>() {
						roleType = "association",
						role = "entranceReference",
					},
				},
			];

		public static informationBinding<InformationAssociation.LimitEntrance> LimitEntrance => new informationBinding<InformationAssociation.LimitEntrance> {
			roleType = "association",
			role = "entranceReference",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => OuterLimit.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "limitReference",
					association = "JurisdictionalLimit",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaAdministrative)],
					CreateInstance = () => new featureBinding<FeatureAssociation.JurisdictionalLimit>() {
						roleType = "association",
						role = "limitReference",
					},
				},
			];

		public static featureBinding<FeatureAssociation.JurisdictionalLimit> JurisdictionalLimit(string role) => new featureBinding<FeatureAssociation.JurisdictionalLimit> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("JurisdictionalLimit") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.curve,Primitives.surface];
	}

	/// <summary>
	/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
	/// </summary>
	public class PilotBoardingPlace : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PilotBoardingPlace);
		[JsonIgnore]
		public override string S100FC_name => "Pilot Boarding Place";

		#region Attributes
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public int?[] pilotMovement {
			set { base.SetAttribute("pilotMovement", [.. value.Select(e=> new pilotMovement { value = e })]); }
			get { return base.GetAttributeValues<pilotMovement>(nameof(pilotMovement)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
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
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pilotMovement),
					lower = 0,
					upper = 3,
					order = 2,
					permitedValues = [1,2,3],
					CreateInstance = () => new pilotMovement(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 4,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => PilotBoardingPlace.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => PilotBoardingPlace.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface,Primitives.point];
	}

	/// <summary>
	/// A designated portion of water for the landing and take-off of seaplanes.
	/// </summary>
	public class SeaplaneLandingArea : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SeaplaneLandingArea);
		[JsonIgnore]
		public override string S100FC_name => "Seaplane Landing Area";

		#region Attributes
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
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
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SeaplaneLandingArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SeaplaneLandingArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface,Primitives.point];
	}

	/// <summary>
	/// A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.
	/// </summary>
	public class ShipLift : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ShipLift);
		[JsonIgnore]
		public override string S100FC_name => "Ship Lift";

		#region Attributes
		[JsonIgnore]
		public decimal? verticalClearanceValue {
			set { base.SetAttribute(new verticalClearanceValue { value = value }); }
			get { return base.GetAttributeValue<verticalClearanceValue>(nameof(verticalClearanceValue))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(verticalClearanceValue),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new verticalClearanceValue(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ShipLift.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => ShipLift.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.
	/// </summary>
	public class StraddleCarrier : HarbourPhysicalInfrastructure
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(StraddleCarrier);
		[JsonIgnore]
		public override string S100FC_name => "Straddle Carrier";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => StraddleCarrier.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. HarbourPhysicalInfrastructure.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => StraddleCarrier.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// A terminal covers that area on shore which provides buildings and constructions for the transfer of cargo or passengers from and to ships.
	/// </summary>
	public class Terminal : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Terminal);
		[JsonIgnore]
		public override string S100FC_name => "Terminal";

		#region Attributes
		[JsonIgnore]
		public String? portFacilityNumber {
			set { base.SetAttribute(new portFacilityNumber { value = value }); }
			get { return base.GetAttributeValue<portFacilityNumber>(nameof(portFacilityNumber))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfTerminal {
			set { base.SetAttribute(new categoryOfTerminal { value = value }); }
			get { return base.GetAttributeValue<categoryOfTerminal>(nameof(categoryOfTerminal))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfCargo {
			set { base.SetAttribute("categoryOfCargo", [.. value.Select(e=> new categoryOfCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfCargo>(nameof(categoryOfCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] product {
			set { base.SetAttribute("product", [.. value.Select(e=> new product { value = e })]); }
			get { return base.GetAttributeValues<product>(nameof(product)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? terminalIdentifier {
			set { base.SetAttribute(new terminalIdentifier { value = value }); }
			get { return base.GetAttributeValue<terminalIdentifier>(nameof(terminalIdentifier))?.value; }
		}
		[JsonIgnore]
		public String? sMDGTerminalCode {
			set { base.SetAttribute(new sMDGTerminalCode { value = value }); }
			get { return base.GetAttributeValue<sMDGTerminalCode>(nameof(sMDGTerminalCode))?.value; }
		}
		[JsonIgnore]
		public String? uNLocationCode {
			set { base.SetAttribute(new uNLocationCode { value = value }); }
			get { return base.GetAttributeValue<uNLocationCode>(nameof(uNLocationCode))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(portFacilityNumber),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new portFacilityNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfTerminal),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,3,7,8,10,11],
					CreateInstance = () => new categoryOfTerminal(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [3,4,6,7,8,10,11,12,14,15],
					CreateInstance = () => new categoryOfCargo(),
				},
				new attributeBindingDefinition {
					attribute = nameof(product),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,22],
					CreateInstance = () => new product(),
				},
				new attributeBindingDefinition {
					attribute = nameof(terminalIdentifier),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new terminalIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sMDGTerminalCode),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new sMDGTerminalCode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(uNLocationCode),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new uNLocationCode(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Terminal.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "serviceDescriptionReference",
					association = "ServiceAvailability",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AvailablePortServices)],
					CreateInstance = () => new informationBinding<InformationAssociation.ServiceAvailability>() {
						roleType = "association",
						role = "serviceDescriptionReference",
					},
				},
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.ServiceAvailability> ServiceAvailability => new informationBinding<InformationAssociation.ServiceAvailability> {
			roleType = "association",
			role = "serviceDescriptionReference",
		};
		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Terminal.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "layoutUnit",
					association = "LayoutDivision",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(Berth)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "association",
						role = "layoutUnit",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "hasInfrastructure",
					association = "Infrastructure",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(HarbourPhysicalInfrastructure)],
					CreateInstance = () => new featureBinding<FeatureAssociation.Infrastructure>() {
						roleType = "association",
						role = "hasInfrastructure",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.Infrastructure> Infrastructure(string role) => new featureBinding<FeatureAssociation.Infrastructure> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("Infrastructure") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.surface];
	}

	/// <summary>
	/// An area of water or enlargement of a channel used for turning vessels.
	/// </summary>
	public class TurningBasin : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TurningBasin);
		[JsonIgnore]
		public override string S100FC_name => "Turning Basin";

		#region Attributes
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
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
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new markedBy(),
				},
				new attributeBindingDefinition {
					attribute = nameof(iSPSLevel),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new iSPSLevel(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => TurningBasin.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => TurningBasin.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// An area in which uniform general information of the waterway exists.
	/// </summary>
	public class WaterwayArea : Layout
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(WaterwayArea);
		[JsonIgnore]
		public override string S100FC_name => "Waterway Area";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfPortSection {
			set { base.SetAttribute(new categoryOfPortSection { value = value }); }
			get { return base.GetAttributeValue<categoryOfPortSection>(nameof(categoryOfPortSection))?.value; }
		}
		[JsonIgnore]
		public depthsDescription? depthsDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<depthsDescription>(nameof(depthsDescription)); }
		}
		[JsonIgnore]
		public String? locationByText {
			set { base.SetAttribute(new locationByText { value = value }); }
			get { return base.GetAttributeValue<locationByText>(nameof(locationByText))?.value; }
		}
		[JsonIgnore]
		public markedBy? markedBy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<markedBy>(nameof(markedBy)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPortSection),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,3,8,9,11,12],
					CreateInstance = () => new categoryOfPortSection(),
				},
				new attributeBindingDefinition {
					attribute = nameof(depthsDescription),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new depthsDescription(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationByText),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new locationByText(),
				},
				new attributeBindingDefinition {
					attribute = nameof(markedBy),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new markedBy(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => WaterwayArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. Layout.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "facilityOperatingHours",
					association = "LocationHours",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(ServiceHours)],
					CreateInstance = () => new informationBinding<InformationAssociation.LocationHours>() {
						roleType = "association",
						role = "facilityOperatingHours",
					},
				},
			];

		public static informationBinding<InformationAssociation.LocationHours> LocationHours => new informationBinding<InformationAssociation.LocationHours> {
			roleType = "association",
			role = "facilityOperatingHours",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => WaterwayArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Layout.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "aggregation",
					role = "componentOf",
					association = "LayoutDivision",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(HarbourAreaSection)],
					CreateInstance = () => new featureBinding<FeatureAssociation.LayoutDivision>() {
						roleType = "aggregation",
						role = "componentOf",
					},
				},
			];

		public static featureBinding<FeatureAssociation.LayoutDivision> LayoutDivision(string role) => new featureBinding<FeatureAssociation.LayoutDivision> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("LayoutDivision") && binding.role.Equals(role)).roleType,
			role = role,
		};
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
		[JsonIgnore]
		public String?[] interoperabilityIdentifier {
			set { base.SetAttribute("interoperabilityIdentifier", [.. value.Select(e=> new interoperabilityIdentifier { value = e })]); }
			get { return base.GetAttributeValues<interoperabilityIdentifier>(nameof(interoperabilityIdentifier)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(maximumDisplayScale),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new maximumDisplayScale(),
				},
				new attributeBindingDefinition {
					attribute = nameof(minimumDisplayScale),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new minimumDisplayScale(),
				},
				new attributeBindingDefinition {
					attribute = nameof(optimumDisplayScale),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new optimumDisplayScale(),
				},
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new interoperabilityIdentifier(),
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
		public horizontalPositionUncertainty? horizontalPositionUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<horizontalPositionUncertainty>(nameof(horizontalPositionUncertainty)); }
		}
		[JsonIgnore]
		public decimal? orientationUncertainty {
			set { base.SetAttribute(new orientationUncertainty { value = value }); }
			get { return base.GetAttributeValue<orientationUncertainty>(nameof(orientationUncertainty))?.value; }
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
		public verticalUncertainty? verticalUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<verticalUncertainty>(nameof(verticalUncertainty)); }
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
					permitedValues = [1,2,3,4,5,6],
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
					attribute = nameof(horizontalPositionUncertainty),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientationUncertainty),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new orientationUncertainty(),
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
					attribute = nameof(verticalUncertainty),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new verticalUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 8,
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
	/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
	/// </summary>
	public class SoundingDatum : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SoundingDatum);
		[JsonIgnore]
		public override string S100FC_name => "Sounding Datum";

		#region Attributes
		[JsonIgnore]
		public int? verticalDatum {
			set { base.SetAttribute(new verticalDatum { value = value }); }
			get { return base.GetAttributeValue<verticalDatum>(nameof(verticalDatum))?.value; }
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
					attribute = nameof(verticalDatum),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,19,22,23,24,25,26,27,44],
					CreateInstance = () => new verticalDatum(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new information(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SoundingDatum.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SoundingDatum.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.
	/// </summary>
	public class VerticalDatumOfData : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(VerticalDatumOfData);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Datum of Data";

		#region Attributes
		[JsonIgnore]
		public int? verticalDatum {
			set { base.SetAttribute(new verticalDatum { value = value }); }
			get { return base.GetAttributeValue<verticalDatum>(nameof(verticalDatum))?.value; }
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
					attribute = nameof(verticalDatum),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [3,13,16,17,18,19,20,21,24,25,26,28,29,30,44],
					CreateInstance = () => new verticalDatum(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new information(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => VerticalDatumOfData.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => VerticalDatumOfData.featureBindingsDefinitions;

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

namespace S100FC.S131
{
	using System.Text.Json;
	using S100FC.S131.SimpleAttributes;
	using S100FC.S131.ComplexAttributes;
	using S100FC.S131.InformationAssociation;
	using S100FC.S131.FeatureAssociation;
	using S100FC.S131.InformationTypes;
	using S100FC.S131.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "Feature Catalogue for S-131";
		public static string Scope => "Global coverage of maritime areas";
		public static string ProductId => "S-131";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2026-01-07", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["contactAddress","featureName","fixedDateRange","frequencyPair","horizontalPositionUncertainty","information","onlineResource","orientation","periodicDateRange","rxNCode","sourceIndication","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","usefulMarkDescription","verticalUncertainty","vesselMeasurementsSpecification","weatherResource","bearingInformation","cargoServicesDescription","constructionInformation","depthsDescription","facilitiesLayoutDescription","generalPortDescription","graphic","landmarkDescription","limitsDescription","majorLightDescription","markedBy","offshoreMarkDescription","scheduleByDayOfWeek","spatialAccuracy","generalHarbourInformation"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","ServiceControl","ServiceContact","LocationHours","RelatedOrganisation","InclusionType","PermissionType","SpatialAssociation","LimitEntrance","ServiceAvailability"];
		public static string[] FeatureAssociationTypes => ["TextAssociation","Subsection","Infrastructure","PrimaryAuxiliaryFacility","Demarcation","JurisdictionalLimit","LayoutDivision"];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","Applicability","Authority","AvailablePortServices","ContactDetails","Entrance","NauticalInformation","NonStandardWorkingDay","Recommendations","Regulations","Restrictions","ServiceHours","SpatialQuality"];
		public static string[] FeatureTypes => ["FeatureType","OrganizationContactArea","SupervisedArea","HarbourPhysicalInfrastructure","Layout","AnchorBerth","AnchorageArea","AutomatedGuidedVehicle","Berth","BerthPosition","Bollard","DockArea","DryDock","Dolphin","DumpingGround","FenderLine","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourBasin","HarbourFacility","LockBasin","LockBasinPart","MooringBuoy","MooringWarpingFacility","OnshorePowerFacility","OuterLimit","PilotBoardingPlace","SeaplaneLandingArea","ShipLift","StraddleCarrier","Terminal","TurningBasin","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","SoundingDatum","VerticalDatumOfData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType","OrganizationContactArea","SupervisedArea","HarbourPhysicalInfrastructure","Layout"],
			Primitives.point => ["AnchorBerth","AnchorageArea","AutomatedGuidedVehicle","Berth","BerthPosition","Bollard","DryDock","Dolphin","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourFacility","LockBasin","LockBasinPart","MooringBuoy","MooringWarpingFacility","OnshorePowerFacility","PilotBoardingPlace","SeaplaneLandingArea","ShipLift","StraddleCarrier","Terminal","TextPlacement"],
			Primitives.pointSet => [],
			Primitives.curve => ["AutomatedGuidedVehicle","Berth","FenderLine","HarbourFacility","OuterLimit"],
			Primitives.surface => ["AnchorBerth","AnchorageArea","AutomatedGuidedVehicle","Berth","DockArea","DryDock","Dolphin","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourBasin","HarbourFacility","LockBasin","LockBasinPart","OuterLimit","PilotBoardingPlace","SeaplaneLandingArea","ShipLift","StraddleCarrier","Terminal","TurningBasin","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","SoundingDatum","VerticalDatumOfData"],
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
			"FeatureType::PermissionType" => FeatureType.PermissionType,
			"FeatureType::AssociatedRxN" => FeatureType.AssociatedRxN,
			"FeatureType::AdditionalInformation" => FeatureType.AdditionalInformation,
			"OrganizationContactArea::ServiceContact" => OrganizationContactArea.ServiceContact,
			"SupervisedArea::ServiceControl" => SupervisedArea.ServiceControl,
			"AnchorBerth::ServiceAvailability" => AnchorBerth.ServiceAvailability,
			"AnchorBerth::LocationHours" => AnchorBerth.LocationHours,
			"AnchorageArea::LocationHours" => AnchorageArea.LocationHours,
			"AutomatedGuidedVehicle::LocationHours" => AutomatedGuidedVehicle.LocationHours,
			"Berth::ServiceAvailability" => Berth.ServiceAvailability,
			"Berth::LocationHours" => Berth.LocationHours,
			"DockArea::ServiceAvailability" => DockArea.ServiceAvailability,
			"DockArea::LocationHours" => DockArea.LocationHours,
			"DryDock::LocationHours" => DryDock.LocationHours,
			"DumpingGround::LocationHours" => DumpingGround.LocationHours,
			"FloatingDock::LocationHours" => FloatingDock.LocationHours,
			"Gridiron::LocationHours" => Gridiron.LocationHours,
			"HarbourAreaAdministrative::ServiceAvailability" => HarbourAreaAdministrative.ServiceAvailability,
			"HarbourAreaAdministrative::LocationHours" => HarbourAreaAdministrative.LocationHours,
			"HarbourAreaSection::ServiceAvailability" => HarbourAreaSection.ServiceAvailability,
			"HarbourAreaSection::LocationHours" => HarbourAreaSection.LocationHours,
			"HarbourBasin::LocationHours" => HarbourBasin.LocationHours,
			"HarbourFacility::LocationHours" => HarbourFacility.LocationHours,
			"LockBasin::LocationHours" => LockBasin.LocationHours,
			"LockBasinPart::LocationHours" => LockBasinPart.LocationHours,
			"MooringWarpingFacility::ServiceAvailability" => MooringWarpingFacility.ServiceAvailability,
			"MooringWarpingFacility::LocationHours" => MooringWarpingFacility.LocationHours,
			"OnshorePowerFacility::LocationHours" => OnshorePowerFacility.LocationHours,
			"OuterLimit::LimitEntrance" => OuterLimit.LimitEntrance,
			"PilotBoardingPlace::LocationHours" => PilotBoardingPlace.LocationHours,
			"SeaplaneLandingArea::LocationHours" => SeaplaneLandingArea.LocationHours,
			"ShipLift::LocationHours" => ShipLift.LocationHours,
			"StraddleCarrier::LocationHours" => StraddleCarrier.LocationHours,
			"Terminal::ServiceAvailability" => Terminal.ServiceAvailability,
			"Terminal::LocationHours" => Terminal.LocationHours,
			"TurningBasin::LocationHours" => TurningBasin.LocationHours,
			"WaterwayArea::LocationHours" => WaterwayArea.LocationHours,
			"" => throw new KeyNotFoundException(),
			_ => throw new KeyNotFoundException(),
		};

		public static featureBinding CreateFeatureBinding(string featureType, string association, string role) => $"{featureType}::{association}" switch {
			"FeatureType::TextAssociation" => FeatureType.TextAssociation(role),
			"HarbourPhysicalInfrastructure::Infrastructure" => HarbourPhysicalInfrastructure.Infrastructure(role),
			"AnchorBerth::PrimaryAuxiliaryFacility" => AnchorBerth.PrimaryAuxiliaryFacility(role),
			"AnchorageArea::LayoutDivision" => AnchorageArea.LayoutDivision(role),
			"Berth::Demarcation" => Berth.Demarcation(role),
			"Berth::LayoutDivision" => Berth.LayoutDivision(role),
			"BerthPosition::Demarcation" => BerthPosition.Demarcation(role),
			"BerthPosition::PrimaryAuxiliaryFacility" => BerthPosition.PrimaryAuxiliaryFacility(role),
			"DockArea::LayoutDivision" => DockArea.LayoutDivision(role),
			"DumpingGround::LayoutDivision" => DumpingGround.LayoutDivision(role),
			"FenderLine::LayoutDivision" => FenderLine.LayoutDivision(role),
			"HarbourAreaAdministrative::JurisdictionalLimit" => HarbourAreaAdministrative.JurisdictionalLimit(role),
			"HarbourAreaAdministrative::LayoutDivision" => HarbourAreaAdministrative.LayoutDivision(role),
			"HarbourAreaSection::LayoutDivision" => HarbourAreaSection.LayoutDivision(role),
			"HarbourAreaSection::Subsection" => HarbourAreaSection.Subsection(role),
			"HarbourAreaSection::Infrastructure" => HarbourAreaSection.Infrastructure(role),
			"HarbourBasin::LayoutDivision" => HarbourBasin.LayoutDivision(role),
			"MooringWarpingFacility::PrimaryAuxiliaryFacility" => MooringWarpingFacility.PrimaryAuxiliaryFacility(role),
			"OuterLimit::JurisdictionalLimit" => OuterLimit.JurisdictionalLimit(role),
			"PilotBoardingPlace::LayoutDivision" => PilotBoardingPlace.LayoutDivision(role),
			"SeaplaneLandingArea::LayoutDivision" => SeaplaneLandingArea.LayoutDivision(role),
			"Terminal::LayoutDivision" => Terminal.LayoutDivision(role),
			"Terminal::Infrastructure" => Terminal.Infrastructure(role),
			"TurningBasin::LayoutDivision" => TurningBasin.LayoutDivision(role),
			"WaterwayArea::LayoutDivision" => WaterwayArea.LayoutDivision(role),
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceControl>), typeDiscriminator: "ServiceControl"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceContact>), typeDiscriminator: "ServiceContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.LocationHours>), typeDiscriminator: "LocationHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.RelatedOrganisation>), typeDiscriminator: "RelatedOrganisation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.InclusionType>), typeDiscriminator: "InclusionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.PermissionType>), typeDiscriminator: "PermissionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.SpatialAssociation>), typeDiscriminator: "SpatialAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.LimitEntrance>), typeDiscriminator: "LimitEntrance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceAvailability>), typeDiscriminator: "ServiceAvailability"));
				}
				if (typeInfo.Type == typeof(S100FC.featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.TextAssociation>), typeDiscriminator: "TextAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.Subsection>), typeDiscriminator: "Subsection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.Infrastructure>), typeDiscriminator: "Infrastructure"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.PrimaryAuxiliaryFacility>), typeDiscriminator: "PrimaryAuxiliaryFacility"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.Demarcation>), typeDiscriminator: "Demarcation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.JurisdictionalLimit>), typeDiscriminator: "JurisdictionalLimit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.LayoutDivision>), typeDiscriminator: "LayoutDivision"));
				}
				if (typeInfo.Type == typeof(S100FC.attributeBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(administrativeDivision), typeDiscriminator: "administrativeDivision"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(applicableLoadLineZone), typeDiscriminator: "applicableLoadLineZone"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(applicationProfile), typeDiscriminator: "applicationProfile"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(approachDescription), typeDiscriminator: "approachDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(associatedFeatureName), typeDiscriminator: "associatedFeatureName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(availableBerthingLength), typeDiscriminator: "availableBerthingLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(berthingAssistance), typeDiscriminator: "berthingAssistance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(bollardDescription), typeDiscriminator: "bollardDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(bollardNumber), typeDiscriminator: "bollardNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(callName), typeDiscriminator: "callName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(callSign), typeDiscriminator: "callSign"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cardinalDirection), typeDiscriminator: "cardinalDirection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cargoService), typeDiscriminator: "cargoService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfAnchorage), typeDiscriminator: "categoryOfAnchorage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfAuthority), typeDiscriminator: "categoryOfAuthority"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfBerthLocation), typeDiscriminator: "categoryOfBerthLocation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCargo), typeDiscriminator: "categoryOfCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCommunicationPreference), typeDiscriminator: "categoryOfCommunicationPreference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfDangerousOrHazardousCargo), typeDiscriminator: "categoryOfDangerousOrHazardousCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfDepthsDescription), typeDiscriminator: "categoryOfDepthsDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfDolphin), typeDiscriminator: "categoryOfDolphin"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfFrequency), typeDiscriminator: "categoryOfFrequency"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfHarbourFacility), typeDiscriminator: "categoryOfHarbourFacility"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfMooringWarpingFacility), typeDiscriminator: "categoryOfMooringWarpingFacility"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfPlug), typeDiscriminator: "categoryOfPlug"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfPortSection), typeDiscriminator: "categoryOfPortSection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRelationship), typeDiscriminator: "categoryOfRelationship"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSchedule), typeDiscriminator: "categoryOfSchedule"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfShorePowerFacility), typeDiscriminator: "categoryOfShorePowerFacility"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfTemporalVariation), typeDiscriminator: "categoryOfTemporalVariation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfTerminal), typeDiscriminator: "categoryOfTerminal"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfText), typeDiscriminator: "categoryOfText"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVesselRegistry), typeDiscriminator: "categoryOfVesselRegistry"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVoltage), typeDiscriminator: "categoryOfVoltage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cathodicProtectionSystem), typeDiscriminator: "cathodicProtectionSystem"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(development), typeDiscriminator: "development"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(distance), typeDiscriminator: "distance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dynamicResource), typeDiscriminator: "dynamicResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(elevation), typeDiscriminator: "elevation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(entranceDescription), typeDiscriminator: "entranceDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileLocator), typeDiscriminator: "fileLocator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileReference), typeDiscriminator: "fileReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(firefightingService), typeDiscriminator: "firefightingService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationReceives), typeDiscriminator: "frequencyShoreStationReceives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationTransmits), typeDiscriminator: "frequencyShoreStationTransmits"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(gLNExtension), typeDiscriminator: "gLNExtension"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(globalLocationNumber), typeDiscriminator: "globalLocationNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(headline), typeDiscriminator: "headline"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(heavingLinesFromShore), typeDiscriminator: "heavingLinesFromShore"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(height), typeDiscriminator: "height"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalDistanceUncertainty), typeDiscriminator: "horizontalDistanceUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iDCode), typeDiscriminator: "iDCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(inBallast), typeDiscriminator: "inBallast"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(interoperabilityIdentifier), typeDiscriminator: "interoperabilityIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(iSPSLevel), typeDiscriminator: "iSPSLevel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(language), typeDiscriminator: "language"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(linkage), typeDiscriminator: "linkage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(localKnowledgeDescription), typeDiscriminator: "localKnowledgeDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(locationByText), typeDiscriminator: "locationByText"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(locationMRN), typeDiscriminator: "locationMRN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(logicalConnectives), typeDiscriminator: "logicalConnectives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(manifoldNumber), typeDiscriminator: "manifoldNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumDisplayScale), typeDiscriminator: "maximumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumPermittedDraught), typeDiscriminator: "maximumPermittedDraught"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumPermittedVesselLength), typeDiscriminator: "maximumPermittedVesselLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(medicalService), typeDiscriminator: "medicalService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(membership), typeDiscriminator: "membership"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(methodOfSecuring), typeDiscriminator: "methodOfSecuring"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(metreMarkNumber), typeDiscriminator: "metreMarkNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumBerthDepth), typeDiscriminator: "minimumBerthDepth"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumDisplayScale), typeDiscriminator: "minimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(mMSICode), typeDiscriminator: "mMSICode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(name), typeDiscriminator: "name"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameOfResource), typeDiscriminator: "nameOfResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameUsage), typeDiscriminator: "nameUsage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nationality), typeDiscriminator: "nationality"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineFunction), typeDiscriminator: "onlineFunction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineResourceDescription), typeDiscriminator: "onlineResourceDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(optimumDisplayScale), typeDiscriminator: "optimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationUncertainty), typeDiscriminator: "orientationUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationValue), typeDiscriminator: "orientationValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictorialRepresentation), typeDiscriminator: "pictorialRepresentation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureCaption), typeDiscriminator: "pictureCaption"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureInformation), typeDiscriminator: "pictureInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pilotMovement), typeDiscriminator: "pilotMovement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(portFacilityNumber), typeDiscriminator: "portFacilityNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(postalCode), typeDiscriminator: "postalCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(product), typeDiscriminator: "product"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocol), typeDiscriminator: "protocol"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocolRequest), typeDiscriminator: "protocolRequest"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(qualityOfHorizontalMeasurement), typeDiscriminator: "qualityOfHorizontalMeasurement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(radius), typeDiscriminator: "radius"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(rampNumber), typeDiscriminator: "rampNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(repairService), typeDiscriminator: "repairService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(reportedDate), typeDiscriminator: "reportedDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(safeWorkingLoad), typeDiscriminator: "safeWorkingLoad"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scaleMinimum), typeDiscriminator: "scaleMinimum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(shipSanitationControl), typeDiscriminator: "shipSanitationControl"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(shorePowerDescription), typeDiscriminator: "shorePowerDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(shorePowerServiceProvider), typeDiscriminator: "shorePowerServiceProvider"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sillDepth), typeDiscriminator: "sillDepth"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sMDGTerminalCode), typeDiscriminator: "sMDGTerminalCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(source), typeDiscriminator: "source"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceDate), typeDiscriminator: "sourceDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceType), typeDiscriminator: "sourceType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(supplyService), typeDiscriminator: "supplyService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(technicalPortService), typeDiscriminator: "technicalPortService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationCarrier), typeDiscriminator: "telecommunicationCarrier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationIdentifier), typeDiscriminator: "telecommunicationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationService), typeDiscriminator: "telecommunicationService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(terminalIdentifier), typeDiscriminator: "terminalIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(text), typeDiscriminator: "text"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetBearing), typeDiscriminator: "textOffsetBearing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetDistance), typeDiscriminator: "textOffsetDistance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textRotation), typeDiscriminator: "textRotation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textType), typeDiscriminator: "textType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(thicknessOfIceCapability), typeDiscriminator: "thicknessOfIceCapability"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayEnd), typeDiscriminator: "timeOfDayEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayStart), typeDiscriminator: "timeOfDayStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(tugInformation), typeDiscriminator: "tugInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uNLocationCode), typeDiscriminator: "uNLocationCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyFixed), typeDiscriminator: "uncertaintyFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyVariableFactor), typeDiscriminator: "uncertaintyVariableFactor"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalClearanceValue), typeDiscriminator: "verticalClearanceValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalDatum), typeDiscriminator: "verticalDatum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalLength), typeDiscriminator: "verticalLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselPerformance), typeDiscriminator: "vesselPerformance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristics), typeDiscriminator: "vesselsCharacteristics"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsUnit), typeDiscriminator: "vesselsCharacteristicsUnit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsValue), typeDiscriminator: "vesselsCharacteristicsValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(visitorsMooring), typeDiscriminator: "visitorsMooring"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(wasteDisposalService), typeDiscriminator: "wasteDisposalService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(actionOrActivity), typeDiscriminator: "actionOrActivity"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRxN), typeDiscriminator: "categoryOfRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVessel), typeDiscriminator: "categoryOfVessel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(securitySafetyEmergencyService), typeDiscriminator: "securitySafetyEmergencyService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(transportConnection), typeDiscriminator: "transportConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactAddress), typeDiscriminator: "contactAddress"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureName), typeDiscriminator: "featureName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fixedDateRange), typeDiscriminator: "fixedDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyPair), typeDiscriminator: "frequencyPair"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalPositionUncertainty), typeDiscriminator: "horizontalPositionUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(information), typeDiscriminator: "information"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineResource), typeDiscriminator: "onlineResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientation), typeDiscriminator: "orientation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(periodicDateRange), typeDiscriminator: "periodicDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(rxNCode), typeDiscriminator: "rxNCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceIndication), typeDiscriminator: "sourceIndication"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(surveyDateRange), typeDiscriminator: "surveyDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunications), typeDiscriminator: "telecommunications"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textContent), typeDiscriminator: "textContent"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeIntervalsByDayOfWeek), typeDiscriminator: "timeIntervalsByDayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(usefulMarkDescription), typeDiscriminator: "usefulMarkDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalUncertainty), typeDiscriminator: "verticalUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselMeasurementsSpecification), typeDiscriminator: "vesselMeasurementsSpecification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(weatherResource), typeDiscriminator: "weatherResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(bearingInformation), typeDiscriminator: "bearingInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cargoServicesDescription), typeDiscriminator: "cargoServicesDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(constructionInformation), typeDiscriminator: "constructionInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(depthsDescription), typeDiscriminator: "depthsDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(facilitiesLayoutDescription), typeDiscriminator: "facilitiesLayoutDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(generalPortDescription), typeDiscriminator: "generalPortDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(graphic), typeDiscriminator: "graphic"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(landmarkDescription), typeDiscriminator: "landmarkDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(limitsDescription), typeDiscriminator: "limitsDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(majorLightDescription), typeDiscriminator: "majorLightDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(markedBy), typeDiscriminator: "markedBy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(offshoreMarkDescription), typeDiscriminator: "offshoreMarkDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scheduleByDayOfWeek), typeDiscriminator: "scheduleByDayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(spatialAccuracy), typeDiscriminator: "spatialAccuracy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(generalHarbourInformation), typeDiscriminator: "generalHarbourInformation"));
				}
			});
			jsonSerializerOptions.TypeInfoResolver = resolver;
			return jsonSerializerOptions;
		}
	}
}
